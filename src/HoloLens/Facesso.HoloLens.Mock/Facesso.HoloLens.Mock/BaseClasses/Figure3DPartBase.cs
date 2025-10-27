using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Facesso.HoloLens;
using FacessoHoloLens.Common;
using FacessoHoloLens.Content;
using SharpDX.Direct2D1;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using Windows.Perception.Spatial;
using Windows.UI.Input.Spatial;

namespace FacessoHoloLens
{
    public class Figure3DPartBase : Disposer, IDebuggableFigure
    {
        // Cached reference to device resources.
        private DeviceResources myDeviceResources;

        // Direct3D resources for figure geometry.
        private SharpDX.Direct3D11.InputLayout myInputLayout;
        private SharpDX.Direct3D11.Buffer myVertexBuffer;
        private SharpDX.Direct3D11.Buffer myIndexBuffer;
        private SharpDX.Direct3D11.VertexShader myVertexShader;
        private SharpDX.Direct3D11.GeometryShader myGeometryShader;
        private SharpDX.Direct3D11.PixelShader myPixelShader;
        private SharpDX.Direct3D11.Buffer myModelConstantBuffer;

        // System resources for figure geometry.
        private ModelConstantBuffer myModelConstantBufferData;
        private int myIndexCount = 0;
        private Vector3 myPosition = new Vector3(0.0f, 0.0f, -2.0f);

        private readonly Matrix4x4 myFlipMatrix = Matrix4x4.CreateFromAxisAngle(new Vector3(1, 0, 0), (float) Math.PI);

        // Variables used with the rendering loop.
        private bool myLoadingComplete = false;

        // If the current D3D Device supports VPRT, we can avoid using a geometry
        // shader just to set the render target array index.
        private bool myUsingVprtShaders = false;

        private Texture2D myTexture2d;
        private SamplerState mySampler;
        private RenderTarget myRenderTarget;

        private string myDebugInfo;
        private SpatialPointerPose myPointerPose;
        private SpatialCoordinateSystem myWorldCoordinateSystem;

        protected const float TEXTURE_X_RES = 1280;
        protected const float TEXTURE_Y_RES = 720;
        protected const float TEXTURE_X_TO_Y_RATIO = TEXTURE_X_RES / TEXTURE_Y_RES;

        protected Figure3DPartBase()
        {
        }

        public static async Task<t> GetInitializedInstanceAsync<t>(DeviceResources deviceResources) where t:Figure3DPartBase,new()
        {
            var instanceToReturn = new t();
            instanceToReturn.myDeviceResources = deviceResources;
            await instanceToReturn.CreateDeviceDependentResourcesAsync();
            return instanceToReturn;
        }

        /// <summary>
        /// Creates device-based resources to store a constant buffer, cube
        /// geometry, and vertex and pixel shaders. In some cases this will also 
        /// store a geometry shader.
        /// </summary>
        public async Task CreateDeviceDependentResourcesAsync()
        {
            ReleaseDeviceDependentResources();

            myUsingVprtShaders = myDeviceResources.D3DDeviceSupportsVprt;

            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            // On devices that do support the D3D11_FEATURE_D3D11_OPTIONS3::
            // VPAndRTArrayIndexFromAnyShaderFeedingRasterizer optional feature
            // we can avoid using a pass-through geometry shader to set the render
            // target array index, thus avoiding any overhead that would be 
            // incurred by setting the geometry shader stage.
            var vertexShaderFileName = myUsingVprtShaders ? "Content\\Shaders\\VPRTVertexShader.cso" : "Content\\Shaders\\VertexShader.cso";

            // Load the compiled vertex shader.
            var vertexShaderByteCode = await DirectXHelper.ReadDataAsync(await folder.GetFileAsync(vertexShaderFileName));

            // After the vertex shader file is loaded, create the shader and input layout.
            myVertexShader = this.ToDispose(new SharpDX.Direct3D11.VertexShader(
                myDeviceResources.D3DDevice,
                vertexShaderByteCode));

            SharpDX.Direct3D11.InputElement[] vertexDesc =
            {
                new SharpDX.Direct3D11.InputElement("POSITION", 0, SharpDX.DXGI.Format.R32G32B32_Float,  0, 0, SharpDX.Direct3D11.InputClassification.PerVertexData, 0),
                new SharpDX.Direct3D11.InputElement("TEXCOORD", 0, SharpDX.DXGI.Format.R32G32_Float, 12, 0, SharpDX.Direct3D11.InputClassification.PerVertexData, 0),
            };

            myInputLayout = this.ToDispose(new SharpDX.Direct3D11.InputLayout(
                myDeviceResources.D3DDevice,
                vertexShaderByteCode,
                vertexDesc));

            if (!myUsingVprtShaders)
            {
                // Load the compiled pass-through geometry shader.
                var geometryShaderByteCode = await DirectXHelper.ReadDataAsync(await folder.GetFileAsync("Content\\Shaders\\GeometryShader.cso"));

                // After the pass-through geometry shader file is loaded, create the shader.
                myGeometryShader = this.ToDispose(new SharpDX.Direct3D11.GeometryShader(
                    myDeviceResources.D3DDevice,
                    geometryShaderByteCode));
            }

            // Load the compiled pixel shader.
            var pixelShaderByteCode = await DirectXHelper.ReadDataAsync(await folder.GetFileAsync("Content\\Shaders\\PixelShader.cso"));

            // After the pixel shader file is loaded, create the shader.
            myPixelShader = this.ToDispose(new SharpDX.Direct3D11.PixelShader(
                myDeviceResources.D3DDevice,
                pixelShaderByteCode));

            // Load mesh vertices. Each vertex has a position and a color.
            // Note that the cube size has changed from the default DirectX app
            // template. Windows Holographic is scaled in meters, so to draw the
            // cube at a comfortable size we made the cube width 0.2 m (20 cm).
            VertexPositionCoordinate[] cubeVertices = GetCubeVertices();

            myVertexBuffer = this.ToDispose(SharpDX.Direct3D11.Buffer.Create(
                myDeviceResources.D3DDevice,
                SharpDX.Direct3D11.BindFlags.VertexBuffer,
                cubeVertices));

            // Load mesh indices. Each trio of indices represents
            // a triangle to be rendered on the screen.
            // For example: 0,2,1 means that the vertices with indexes
            // 0, 2 and 1 from the vertex buffer compose the 
            // first triangle of this mesh.
            ushort[] cubeIndices = GetCubeIndices();

            myIndexCount = cubeIndices.Length;

            myIndexBuffer = this.ToDispose(SharpDX.Direct3D11.Buffer.Create(
                myDeviceResources.D3DDevice,
                SharpDX.Direct3D11.BindFlags.IndexBuffer,
                cubeIndices));

            // Create a constant buffer to store the model matrix.
            myModelConstantBuffer = this.ToDispose(SharpDX.Direct3D11.Buffer.Create(
                myDeviceResources.D3DDevice,
                SharpDX.Direct3D11.BindFlags.ConstantBuffer,
                ref myModelConstantBufferData));

            SetupTexture();

            // Once the cube is loaded, the object is ready to be rendered.
            myLoadingComplete = true;
        }



        internal protected virtual VertexPositionCoordinate[] GetCubeVertices()
        {
            return null;
        }

        internal protected virtual ushort[] GetCubeIndices()
        {
            return null;
        }

        internal protected virtual void SetupTexture()
        {
            var context = this.myDeviceResources.D3DDeviceContext;
            var factory = new SharpDX.Direct2D1.Factory();

            myTexture2d = new Texture2D(this.myDeviceResources.D3DDevice, new Texture2DDescription()
            {
                ArraySize = 1,
                BindFlags = BindFlags.RenderTarget | BindFlags.ShaderResource,
                CpuAccessFlags = CpuAccessFlags.None,
                Format = Format.B8G8R8A8_UNorm,
                Width = (int) TEXTURE_X_RES,
                Height = (int) TEXTURE_Y_RES,
                MipLevels = 1,
                OptionFlags = ResourceOptionFlags.None,
                SampleDescription = new SampleDescription()
                {
                    Count = 1,
                    Quality = 0

                },
                Usage = ResourceUsage.Default
            });

            var surface = myTexture2d.QueryInterface<Surface>();

            var pFormat = new SharpDX.Direct2D1.PixelFormat();
            pFormat.Format = Format.Unknown;
            pFormat.AlphaMode = SharpDX.Direct2D1.AlphaMode.Premultiplied;
            var rtp = new RenderTargetProperties(RenderTargetType.Default,
                                                 pFormat, 0, 0,
                                                 RenderTargetUsage.None,
                                                 FeatureLevel.Level_DEFAULT);

            myRenderTarget = new SharpDX.Direct2D1.RenderTarget(factory, surface, rtp);

            var samplerStateDescription = new SamplerStateDescription
            {

                AddressU = TextureAddressMode.Border,
                AddressV = TextureAddressMode.Border,
                AddressW = TextureAddressMode.Border,
                Filter = SharpDX.Direct3D11.Filter.Anisotropic,
                BorderColor = new RawColor4(0.2f, 0.2f, 0.2f, 1f)
            };

            mySampler = new SamplerState(this.myDeviceResources.D3DDevice, samplerStateDescription);
        }


        /// <summary>
        /// Releases device-based resources.
        /// </summary>
        public void ReleaseDeviceDependentResources()
        {
            myLoadingComplete = false;
            myUsingVprtShaders = false;
            this.RemoveAndDispose(ref myVertexShader);
            this.RemoveAndDispose(ref myInputLayout);
            this.RemoveAndDispose(ref myPixelShader);
            this.RemoveAndDispose(ref myGeometryShader);
            this.RemoveAndDispose(ref myModelConstantBuffer);
            this.RemoveAndDispose(ref myVertexBuffer);
            this.RemoveAndDispose(ref myIndexBuffer);
        }

        public Vector3 Position
        {
            get { return myPosition; }
            set
            {
                if (!object.Equals(myPosition,value))
                {
                    myPosition = value;
                    OnPositionChanged();
                }
            }
        }

        protected virtual void OnPositionChanged()
        {
        }

        internal protected virtual Matrix4x4 TransformFigure()
        {
            return Matrix4x4.Identity;
        }

        internal protected virtual bool IsFlipped
        {
            get { return false; }
        }

        /// <summary>
        /// Called once per frame, rotates the cube and calculates the model and view matrices.
        /// </summary>
        internal virtual void UpdateInternal(StepTimer timer, Matrix4x4 genericTransformation)
        {

            Matrix4x4 modelRotation = TransformFigure();

            if (IsFlipped)
            {
                modelRotation = modelRotation * myFlipMatrix;
            }

            // Position the cube.
            Matrix4x4 modelTranslation = Matrix4x4.CreateTranslation(myPosition);

            // Put everything together.
            modelTranslation = modelTranslation * genericTransformation;

            // Multiply to get the transform matrix.
            // Note that this transform does not enforce a particular coordinate system. The calling
            // class is responsible for rendering this content in a consistent manner.
            Matrix4x4 modelTransform = modelRotation * modelTranslation;

            // The view and projection matrices are provided by the system; they are associated
            // with holographic cameras, and updated on a per-camera basis.
            // Here, we provide the model transform for the sample hologram. The model transform
            // matrix is transposed to prepare it for the shader.
            this.myModelConstantBufferData.model = Matrix4x4.Transpose(modelTransform);

            // Loading is asynchronous. Resources must be created before they can be updated.
            if (!myLoadingComplete)
            {
                return;
            }

            // Use the D3D device context to update Direct3D device-based resources.
            var context = this.myDeviceResources.D3DDeviceContext;

            // Update the model transform buffer for the hologram.
            context.UpdateSubresource(ref this.myModelConstantBufferData, this.myModelConstantBuffer);
        }

        /// <summary>
        /// Renders one frame using the vertex and pixel shaders.
        /// On devices that do not support the D3D11_FEATURE_D3D11_OPTIONS3::
        /// VPAndRTArrayIndexFromAnyShaderFeedingRasterizer optional feature,
        /// a pass-through geometry shader is also used to set the render 
        /// target array index.
        /// </summary>
        public void Render()
        {
            // Loading is asynchronous. Resources must be created before drawing can occur.
            if (!this.myLoadingComplete)
            {
                return;
            }

            var context = this.myDeviceResources.D3DDeviceContext;

            var src = new ShaderResourceView(this.myDeviceResources.D3DDevice, myTexture2d);


            // Each vertex is one instance of the VertexPositionColor struct.
            int stride = SharpDX.Utilities.SizeOf<VertexPositionCoordinate>();
            int offset = 0;
            var bufferBinding = new SharpDX.Direct3D11.VertexBufferBinding(this.myVertexBuffer, stride, offset);
            context.InputAssembler.SetVertexBuffers(0, bufferBinding);
            context.InputAssembler.SetIndexBuffer(
                this.myIndexBuffer,
                SharpDX.DXGI.Format.R16_UInt, // Each index is one 16-bit unsigned integer (short).
                0);
            context.InputAssembler.PrimitiveTopology = SharpDX.Direct3D.PrimitiveTopology.TriangleList;
            context.InputAssembler.InputLayout = this.myInputLayout;

            //// Attach the vertex shader.
            context.VertexShader.SetShader(this.myVertexShader, null, 0);

            // Apply the model constant buffer to the vertex shader.
            context.VertexShader.SetConstantBuffers(0, this.myModelConstantBuffer);

            if (!this.myUsingVprtShaders)
            {
                // On devices that do not support the D3D11_FEATURE_D3D11_OPTIONS3::
                // VPAndRTArrayIndexFromAnyShaderFeedingRasterizer optional feature,
                // a pass-through geometry shader is used to set the render target 
                // array index.
                context.GeometryShader.SetShader(this.myGeometryShader, null, 0);
            }

            OnDrawing2DTextureContext(myRenderTarget);

            // Attach the pixel shader.
            context.PixelShader.SetShader(this.myPixelShader, null, 0);
            context.PixelShader.SetShaderResource(0, src);
            context.PixelShader.SetSampler(0, mySampler);

            // Draw the objects.
            context.DrawIndexedInstanced(
                myIndexCount,     // Index count per instance.
                2,              // Instance count.
                0,              // Start index location.
                0,              // Base vertex location.
                0               // Start instance location.
                );
        }

        public virtual void OnDrawing2DTextureContext(RenderTarget renderTarget)
        {
        }

        public string DebugInfo
        {
            get { return myDebugInfo; }
            set
            {
                if (!object.Equals(myDebugInfo, value))
                {
                    myDebugInfo = value;
                }
            }
        }

        public SpatialPointerPose PointerPose
        {
            get
            {
                return myPointerPose;
            }

            set
            {
                if (!object.Equals(myPointerPose,value))
                {
                    myPointerPose = value;
                }
            }
        }

        public SpatialCoordinateSystem WorldCoordinateSystem
        {
            get
            {
                return myWorldCoordinateSystem;
            }

            set
            {
                if (!object.Equals(myWorldCoordinateSystem, value))
                {
                    myWorldCoordinateSystem = value;
                }
            }
        }
    }
}

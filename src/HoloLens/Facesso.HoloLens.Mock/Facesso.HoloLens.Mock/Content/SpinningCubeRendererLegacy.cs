using System;
using System.Numerics;
using FacessoHoloLens.Common;
using SharpDX.Direct2D1;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using Windows.UI.Input.Spatial;
using SharpDX.WIC;

namespace FacessoHoloLens.Content
{
    /// <summary>
    /// This sample renderer instantiates a basic rendering pipeline.
    /// </summary>
    internal class SpinningCubeRendererLegacy : Disposer
    {
        // Cached reference to device resources.
        private DeviceResources                     deviceResources;

        // Direct3D resources for cube geometry.
        private SharpDX.Direct3D11.InputLayout      inputLayout;
        private SharpDX.Direct3D11.Buffer           vertexBuffer;
        private SharpDX.Direct3D11.Buffer           indexBuffer;
        private SharpDX.Direct3D11.VertexShader     vertexShader;
        private SharpDX.Direct3D11.GeometryShader   geometryShader;
        private SharpDX.Direct3D11.PixelShader      pixelShader;
        private SharpDX.Direct3D11.Buffer           modelConstantBuffer;

        // System resources for cube geometry.
        private ModelConstantBuffer                 modelConstantBufferData;
        private int                                 indexCount = 0;
        private Vector3                             position = new Vector3(0.0f, 0.0f, -2.0f);

        // Variables used with the rendering loop.
        private bool                                loadingComplete = false;
        private float                               degreesPerSecond = 45.0f;


        // If the current D3D Device supports VPRT, we can avoid using a geometry
        // shader just to set the render target array index.
        private bool                                usingVprtShaders = false;

        private Texture2D myTexture2d;
        private SamplerState mySampler;
        private RenderTarget myRenderTarget;
        private float myBlue;
        private int myx;
        private int myy;
        private int myxstep=1;
        private int myystep=1;

        /// <summary>
        /// Loads vertex and pixel shaders from files and instantiates the cube geometry.
        /// </summary>
        public SpinningCubeRendererLegacy(DeviceResources deviceResources)
        {
            this.deviceResources  = deviceResources;

            this.CreateDeviceDependentResourcesAsync();
        }

        // This function uses a SpatialPointerPose to position the world-locked hologram
        // two meters in front of the user's heading.
        public void PositionHologram(SpatialPointerPose pointerPose)
        {
            if (null != pointerPose)
            {
                // Get the gaze direction relative to the given coordinate system.
                Vector3 headPosition        = pointerPose.Head.Position;
                Vector3 headDirection       = pointerPose.Head.ForwardDirection;

                // The hologram is positioned two meters along the user's gaze direction.
                float   distanceFromUser    = 2.0f; // meters
                Vector3 gazeAtTwoMeters     = headPosition + (distanceFromUser * headDirection);

                // This will be used as the translation component of the hologram's
                // model transform.
                this.position = gazeAtTwoMeters;
            }
        }

        /// <summary>
        /// Called once per frame, rotates the cube and calculates the model and view matrices.
        /// </summary>
        public void Update(StepTimer timer)
        {
            // Rotate the cube.
            // Convert degrees to radians, then convert seconds to rotation angle.
            float     radiansPerSecond  = this.degreesPerSecond * ((float)Math.PI / 180.0f);
            double    totalRotation     = timer.TotalSeconds * radiansPerSecond;
            float     radians           = (float)System.Math.IEEERemainder(totalRotation, 2 * Math.PI);
            Matrix4x4 modelRotation     = Matrix4x4.CreateFromAxisAngle(new Vector3(0, 1, 0), -radians);


            // Position the cube.
            Matrix4x4 modelTranslation  = Matrix4x4.CreateTranslation(position);


            // Multiply to get the transform matrix.
            // Note that this transform does not enforce a particular coordinate system. The calling
            // class is responsible for rendering this content in a consistent manner.
            Matrix4x4 modelTransform    = modelRotation * modelTranslation;

            // The view and projection matrices are provided by the system; they are associated
            // with holographic cameras, and updated on a per-camera basis.
            // Here, we provide the model transform for the sample hologram. The model transform
            // matrix is transposed to prepare it for the shader.
            this.modelConstantBufferData.model = Matrix4x4.Transpose(modelTransform);

            // Loading is asynchronous. Resources must be created before they can be updated.
            if (!loadingComplete)
            {
                return;
            }

            // Use the D3D device context to update Direct3D device-based resources.
            var context = this.deviceResources.D3DDeviceContext;

            // Update the model transform buffer for the hologram.
            context.UpdateSubresource(ref this.modelConstantBufferData, this.modelConstantBuffer);
        }

        private void SetupTexture()
        {
            var context = this.deviceResources.D3DDeviceContext;
            var factory = new SharpDX.Direct2D1.Factory();

            myTexture2d = new Texture2D(this.deviceResources.D3DDevice, new Texture2DDescription()
            {
                ArraySize = 1,
                BindFlags = BindFlags.RenderTarget | BindFlags.ShaderResource,
                CpuAccessFlags = CpuAccessFlags.None,
                Format = Format.B8G8R8A8_UNorm,
                Width = 1280,
                Height = 720,
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
            
            mySampler = new SamplerState(this.deviceResources.D3DDevice, samplerStateDescription);
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
            if (!this.loadingComplete)
            {
                return;
            }

            var context = this.deviceResources.D3DDeviceContext;

            var src = new ShaderResourceView(this.deviceResources.D3DDevice, myTexture2d);


            // Each vertex is one instance of the VertexPositionColor struct.
            int stride = SharpDX.Utilities.SizeOf<VertexPositionCoordinate>();
            int offset = 0;
            var bufferBinding = new SharpDX.Direct3D11.VertexBufferBinding(this.vertexBuffer, stride, offset);
            context.InputAssembler.SetVertexBuffers(0, bufferBinding);
            context.InputAssembler.SetIndexBuffer(
                this.indexBuffer,
                SharpDX.DXGI.Format.R16_UInt, // Each index is one 16-bit unsigned integer (short).
                0);
            context.InputAssembler.PrimitiveTopology = SharpDX.Direct3D.PrimitiveTopology.TriangleList;
            context.InputAssembler.InputLayout = this.inputLayout;

            //// Attach the vertex shader.
            context.VertexShader.SetShader(this.vertexShader, null, 0);

            // Apply the model constant buffer to the vertex shader.
            context.VertexShader.SetConstantBuffers(0, this.modelConstantBuffer);

            if (!this.usingVprtShaders)
            {
                // On devices that do not support the D3D11_FEATURE_D3D11_OPTIONS3::
                // VPAndRTArrayIndexFromAnyShaderFeedingRasterizer optional feature,
                // a pass-through geometry shader is used to set the render target 
                // array index.
                context.GeometryShader.SetShader(this.geometryShader, null, 0);
            }

            var brush = new SolidColorBrush(myRenderTarget, new RawColor4(1f, 0f, 0f, 1f));

            myRenderTarget.BeginDraw();
            myRenderTarget.Clear(new RawColor4(0.0f, 0.0f, 1f, 1f));

            myx += myxstep;
            myy += myystep;

            if (myx > 1279 || myx < 1)
                myxstep = -myxstep;

            if (myy > 719 || myy < 1)
                myystep = -myystep;

            myRenderTarget.DrawLine(new RawVector2() { X = 0, Y = 0 },
                                    new RawVector2() { X = myx, Y = myy },
                                    brush, 3);

            myRenderTarget.DrawLine(new RawVector2() { X = myx, Y = 0 },
                                    new RawVector2() { X = 0, Y = myy },
                                    brush, 3);
            myRenderTarget.EndDraw();

            myBlue += 0.01f;
            if (myBlue > 1)
                myBlue = 1;

            // Attach the pixel shader.
            context.PixelShader.SetShader(this.pixelShader, null, 0);
            context.PixelShader.SetShaderResource(0, src);
            context.PixelShader.SetSampler(0, mySampler);

            // Draw the objects.
            context.DrawIndexedInstanced(
                indexCount,     // Index count per instance.
                2,              // Instance count.
                0,              // Start index location.
                0,              // Base vertex location.
                0               // Start instance location.
                );


            
        }

        /// <summary>
        /// Creates device-based resources to store a constant buffer, cube
        /// geometry, and vertex and pixel shaders. In some cases this will also 
        /// store a geometry shader.
        /// </summary>
        public async void CreateDeviceDependentResourcesAsync()
        {
            ReleaseDeviceDependentResources();

            usingVprtShaders = deviceResources.D3DDeviceSupportsVprt;

            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            
            // On devices that do support the D3D11_FEATURE_D3D11_OPTIONS3::
            // VPAndRTArrayIndexFromAnyShaderFeedingRasterizer optional feature
            // we can avoid using a pass-through geometry shader to set the render
            // target array index, thus avoiding any overhead that would be 
            // incurred by setting the geometry shader stage.
            var vertexShaderFileName = usingVprtShaders ? "Content\\Shaders\\VPRTVertexShader.cso" : "Content\\Shaders\\VertexShader.cso";

            // Load the compiled vertex shader.
            var vertexShaderByteCode = await DirectXHelper.ReadDataAsync(await folder.GetFileAsync(vertexShaderFileName));

            // After the vertex shader file is loaded, create the shader and input layout.
            vertexShader = this.ToDispose(new SharpDX.Direct3D11.VertexShader(
                deviceResources.D3DDevice,
                vertexShaderByteCode));

            SharpDX.Direct3D11.InputElement[] vertexDesc =
            {
                new SharpDX.Direct3D11.InputElement("POSITION", 0, SharpDX.DXGI.Format.R32G32B32_Float,  0, 0, SharpDX.Direct3D11.InputClassification.PerVertexData, 0),
                new SharpDX.Direct3D11.InputElement("TEXCOORD", 0, SharpDX.DXGI.Format.R32G32_Float, 12, 0, SharpDX.Direct3D11.InputClassification.PerVertexData, 0),
            };

            inputLayout = this.ToDispose(new SharpDX.Direct3D11.InputLayout(
                deviceResources.D3DDevice,
                vertexShaderByteCode,
                vertexDesc));
            
            if (!usingVprtShaders)
            {
                // Load the compiled pass-through geometry shader.
                var geometryShaderByteCode = await DirectXHelper.ReadDataAsync(await folder.GetFileAsync("Content\\Shaders\\GeometryShader.cso"));

                // After the pass-through geometry shader file is loaded, create the shader.
                geometryShader = this.ToDispose(new SharpDX.Direct3D11.GeometryShader(
                    deviceResources.D3DDevice,
                    geometryShaderByteCode));
            }

            // Load the compiled pixel shader.
            var pixelShaderByteCode = await DirectXHelper.ReadDataAsync(await folder.GetFileAsync("Content\\Shaders\\PixelShader.cso"));

            // After the pixel shader file is loaded, create the shader.
            pixelShader = this.ToDispose(new SharpDX.Direct3D11.PixelShader(
                deviceResources.D3DDevice,
                pixelShaderByteCode));

            // Load mesh vertices. Each vertex has a position and a color.
            // Note that the cube size has changed from the default DirectX app
            // template. Windows Holographic is scaled in meters, so to draw the
            // cube at a comfortable size we made the cube width 0.2 m (20 cm).
            //VertexPositionCoordinate[] cubeVertices =
            //{
            //};

            VertexPositionCoordinate[] cubeVertices =
            {
                new VertexPositionCoordinate(new Vector3(-0.2f, -0.1f,  0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3(-0.2f,  0.1f,  0.02f), new Vector2(0f, 1f)),
                new VertexPositionCoordinate(new Vector3( 0.2f, -0.1f,  0.02f), new Vector2(1.0f,0.0f)),
                new VertexPositionCoordinate(new Vector3( 0.2f,  0.1f,  0.02f), new Vector2(1f, 1.0f)),
                new VertexPositionCoordinate(new Vector3(-0.2f, -0.1f, -0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3(-0.2f, -0.1f,  0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3(-0.2f,  0.1f, -0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3(-0.2f,  0.1f,  0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3( 0.2f, -0.1f, -0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3( 0.2f, -0.1f,  0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3( 0.2f,  0.1f, -0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3( 0.2f,  0.1f,  0.02f), new Vector2(0f,0f)),
            };


            vertexBuffer = this.ToDispose(SharpDX.Direct3D11.Buffer.Create(
                deviceResources.D3DDevice,
                SharpDX.Direct3D11.BindFlags.VertexBuffer,
                cubeVertices));

            // Load mesh indices. Each trio of indices represents
            // a triangle to be rendered on the screen.
            // For example: 0,2,1 means that the vertices with indexes
            // 0, 2 and 1 from the vertex buffer compose the 
            // first triangle of this mesh.
            //ushort[] cubeIndices =
            //{

            //    1,3,7, // +z
            //    1,7,5,
            //};

            ushort[] cubeIndices =
            {
                6,5,4, // -x
                6,7,5,

                10,8,9, // +x
                10,9,11,

                4,5,9, // -y
                4,9,8,

                6,10,11, // +y
                6,11,7,

                4,8,10, // -z
                4,10,6,

                0,1,3, // +z
                0,3,2,
            };


            indexCount = cubeIndices.Length;

            indexBuffer = this.ToDispose(SharpDX.Direct3D11.Buffer.Create(
                deviceResources.D3DDevice,
                SharpDX.Direct3D11.BindFlags.IndexBuffer,
                cubeIndices));

            // Create a constant buffer to store the model matrix.
            modelConstantBuffer = this.ToDispose(SharpDX.Direct3D11.Buffer.Create(
                deviceResources.D3DDevice,
                SharpDX.Direct3D11.BindFlags.ConstantBuffer,
                ref modelConstantBufferData));

            SetupTexture();

            // Once the cube is loaded, the object is ready to be rendered.
            loadingComplete = true;
        }

        /// <summary>
        /// Releases device-based resources.
        /// </summary>
        public void ReleaseDeviceDependentResources()
        {
            loadingComplete = false;
            usingVprtShaders = false;
            this.RemoveAndDispose(ref vertexShader);
            this.RemoveAndDispose(ref inputLayout);
            this.RemoveAndDispose(ref pixelShader);
            this.RemoveAndDispose(ref geometryShader);
            this.RemoveAndDispose(ref modelConstantBuffer);
            this.RemoveAndDispose(ref vertexBuffer);
            this.RemoveAndDispose(ref indexBuffer);
        }

        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}

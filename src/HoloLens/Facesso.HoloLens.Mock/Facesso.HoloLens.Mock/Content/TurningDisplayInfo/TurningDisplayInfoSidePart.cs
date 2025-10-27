using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using FacessoHoloLens.Common;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace FacessoHoloLens.Content
{
    public class TurningDisplayInfoSideParts : Figure3DPartBase
    {

        protected internal override VertexPositionCoordinate[] GetCubeVertices()
        {
            VertexPositionCoordinate[] cubeVertices =
            {
                new VertexPositionCoordinate(new Vector3(-0.4f, -0.2f, -0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3(-0.4f, -0.2f,  0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3(-0.4f,  0.2f, -0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3(-0.4f,  0.2f,  0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3( 0.4f, -0.2f, -0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3( 0.4f, -0.2f,  0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3( 0.4f,  0.2f, -0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3( 0.4f,  0.2f,  0.02f), new Vector2(0f,0f)),
            };

            return cubeVertices;
        }

        protected internal override ushort[] GetCubeIndices()
        {
            ushort[] cubeIndices =
            {
                2,6,7, 
                3,2,7,
                7,6,5,
                6,4,5,
                0,5,4,
                0,1,5,
                3,1,0,
                3,0,2
            };

            return cubeIndices;
        }

        protected internal override bool IsFlipped
        {
            get
            {
                return false;
            }
        }

        public override void OnDrawing2DTextureContext(RenderTarget renderTarget)
        {
            base.OnDrawing2DTextureContext(renderTarget);
        }

        public void Update(StepTimer timer)
        {
            // Rotate the cube.
            // Convert degrees to radians, then convert seconds to rotation angle.
            float rotationAngle = 145;
            float radians = (float)System.Math.IEEERemainder(rotationAngle, 2 * Math.PI);

            base.UpdateInternal(timer, Matrix4x4.Identity);
        }
    }
}

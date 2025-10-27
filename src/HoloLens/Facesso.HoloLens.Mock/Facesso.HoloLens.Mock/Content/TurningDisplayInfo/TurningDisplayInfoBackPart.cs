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
    public class TurningDisplayInfoBackPart : Figure3DPartBase
    {
        private int myx;
        private int myy;
        private int myxstep = 1;
        private int myystep = 1;

        protected internal override VertexPositionCoordinate[] GetCubeVertices()
        {
            //VertexPositionCoordinate[] cubeVertices =
            //{
            //    new VertexPositionCoordinate(new Vector3(-0.2f, -0.1f,  0.02f), new Vector2(0f,0f)),
            //    new VertexPositionCoordinate(new Vector3(-0.2f,  0.1f,  0.02f), new Vector2(0f, 1f)),
            //    new VertexPositionCoordinate(new Vector3( 0.2f, -0.1f,  0.02f), new Vector2(1.0f,0.0f)),
            //    new VertexPositionCoordinate(new Vector3( 0.2f,  0.1f,  0.02f), new Vector2(1f, 1.0f)),
            //    new VertexPositionCoordinate(new Vector3(-0.2f, -0.1f, -0.02f), new Vector2(0f,0f)),
            //    new VertexPositionCoordinate(new Vector3(-0.2f, -0.1f,  0.02f), new Vector2(0f,0f)),
            //    new VertexPositionCoordinate(new Vector3(-0.2f,  0.1f, -0.02f), new Vector2(0f,0f)),
            //    new VertexPositionCoordinate(new Vector3(-0.2f,  0.1f,  0.02f), new Vector2(0f,0f)),
            //    new VertexPositionCoordinate(new Vector3( 0.2f, -0.1f, -0.02f), new Vector2(0f,0f)),
            //    new VertexPositionCoordinate(new Vector3( 0.2f, -0.1f,  0.02f), new Vector2(0f,0f)),
            //    new VertexPositionCoordinate(new Vector3( 0.2f,  0.1f, -0.02f), new Vector2(0f,0f)),
            //    new VertexPositionCoordinate(new Vector3( 0.2f,  0.1f,  0.02f), new Vector2(0f,0f)),
            //};

            //return cubeVertices;

            VertexPositionCoordinate[] cubeVertices =
            {
                new VertexPositionCoordinate(new Vector3(-0.4f, -0.2f,  -0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3(-0.4f,  0.2f,  -0.02f), new Vector2(0f, 1f)),
                new VertexPositionCoordinate(new Vector3( 0.4f, -0.2f,  -0.02f), new Vector2(1.0f,0.0f)),
                new VertexPositionCoordinate(new Vector3( 0.4f,  0.2f,  -0.02f), new Vector2(1f, 1.0f)),
            };

            return cubeVertices;
        }


        protected internal override ushort[] GetCubeIndices()
        {
            ushort[] cubeIndices =
            {
                3,1,0, // -z
                2,3,0,
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

        public async override void OnDrawing2DTextureContext(RenderTarget renderTarget)
        {
            await Task.Run(() =>
            {
                renderTarget.BeginDraw();
                renderTarget.Clear(new RawColor4(0.0f, 0.0f, 1f, 1f));

                var brush = new SolidColorBrush(renderTarget, new RawColor4(1f, 0f, 0f, 1f));

                myx += myxstep;
                myy += myystep;

                if (myx > 1279 || myx < 1)
                    myxstep = -myxstep;

                if (myy > 719 || myy < 1)
                    myystep = -myystep;

                renderTarget.DrawLine(new RawVector2() { X = 0, Y = 0 },
                                        new RawVector2() { X = myx, Y = myy },
                                        brush, 3);

                renderTarget.DrawLine(new RawVector2() { X = myx, Y = 0 },
                                        new RawVector2() { X = 0, Y = myy },
                                        brush, 3);
            });
            renderTarget.EndDraw();
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

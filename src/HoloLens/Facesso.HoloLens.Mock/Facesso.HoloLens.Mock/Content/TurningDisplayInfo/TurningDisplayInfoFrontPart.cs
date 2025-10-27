using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Facesso.HoloLens.BaseClasses;
using FacessoHoloLens.Common;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using MathNet.Spatial.Euclidean;

namespace FacessoHoloLens.Content
{
    public class TurningDisplayInfoFrontPart : Figure3DPartBase
    {
        private int myx;
        private int myy;
        private int myxstep = 1;
        private int myystep = 1;
        private DirectWriteHelper myTextRenderer;

        public TurningDisplayInfoFrontPart()
        {
            myTextRenderer = new DirectWriteHelper("Segoe UI", 26);
        }

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
                new VertexPositionCoordinate(new Vector3(-0.4f, -0.2f,  0.02f), new Vector2(0f,0f)),
                new VertexPositionCoordinate(new Vector3(-0.4f,  0.2f,  0.02f), new Vector2(0f, 1f)),
                new VertexPositionCoordinate(new Vector3( 0.4f, -0.2f,  0.02f), new Vector2(1f,0f)),
                new VertexPositionCoordinate(new Vector3( 0.4f,  0.2f,  0.02f), new Vector2(1f, 1f)),
            };

            // TODO: Generate from cubeVertices (finding 2D 0,0 and 2D 1,1)
            myArea = new RawRectangleF(-0.4f, -0.2f, 0.4f, 0.2f);

            myPlane = new MathNet.Spatial.Euclidean.Plane(new Point3D(cubeVertices[0].pos.X, cubeVertices[0].pos.Y, cubeVertices[0].pos.Z + Position.Z),
                                                          new Point3D(cubeVertices[1].pos.X, cubeVertices[1].pos.Y, cubeVertices[1].pos.Z + Position.Z),
                                                          new Point3D(cubeVertices[2].pos.X, cubeVertices[2].pos.Y, cubeVertices[2].pos.Z + Position.Z));
            return cubeVertices;
        }

        private RawRectangleF myArea;

        public RawRectangleF Area
        {
            get { return myArea; }
        }

        protected internal override ushort[] GetCubeIndices()
        {
           // ushort[] cubeIndices =
           //{
           //     6,5,4, // -x
           //     6,7,5,

           //     10,8,9, // +x
           //     10,9,11,

           //     4,5,9, // -y
           //     4,9,8,

           //     6,10,11, // +y
           //     6,11,7,

           //     4,8,10, // -z
           //     4,10,6,

           //     0,1,3, // +z
           //     0,3,2,
           // };

           // return cubeIndices;

            ushort[] cubeIndices =
            {
                1,3,0, // +z
                3,2,0,
            };

            return cubeIndices;
        }

        private const float MIN_SCALE_X = -4f;
        private const float MIN_SCALE_Y = -3f;
        private const float MAX_SCALE_X = 4f;
        private const float MAX_SCALE_Y = 3f;
        private const float DELTA_X = MAX_SCALE_X-MIN_SCALE_X;
        private const float DELTA_Y = MAX_SCALE_Y - MIN_SCALE_Y;

        private readonly Func<float, float> RadToDeg = new Func<float, float>(
                                                       (angle) => (float) (angle * (180 / Math.PI)));

        private readonly Func<float, float> DegToRad = new Func<float, float>(
                                                       (angle) => (float) (angle * (Math.PI / 180)));
        private MathNet.Spatial.Euclidean.Plane myPlane;
        private float myGazePointScaleX;
        private float myGazePointScaleY;

        protected override void OnPositionChanged()
        {
            base.OnPositionChanged();
            myPlane = new MathNet.Spatial.Euclidean.Plane(0, 0, -1, 0.02 + Position.Z);
            myGazePointScaleX = DELTA_X / (myArea.Right - myArea.Left);
            myGazePointScaleY = DELTA_Y / (myArea.Top - myArea.Bottom);
        }

        public async override void OnDrawing2DTextureContext(RenderTarget renderTarget)
        {

            await Task.Run(() =>
            {

                try
                {
                    renderTarget.BeginDraw();

                    var transformMatrix = new Matrix3x2(1, 0, 0, -1, 0, 720);

                    //var rotation = Matrix3x2.CreateRotation((float)Math.PI);


                    //tmp.M11 = -1;
                    //var rotation = ;

                    //var offset = Matrix3x2.CreateTranslation(new Vector2(-640f, -384f));

                    //tmp = Matrix3x2.Multiply(tmp, offset);
                    var rawMatrix = new RawMatrix3x2(transformMatrix.M11,
                                                     transformMatrix.M12,
                                                     transformMatrix.M21,
                                                     transformMatrix.M22,
                                                     transformMatrix.M31,
                                                     transformMatrix.M32);

                    
                    renderTarget.Transform = rawMatrix;
                    renderTarget.Clear(new RawColor4(0.0f, 0.0f, 1f, 1f));

                    var redBrush = new SolidColorBrush(renderTarget, new RawColor4(1f, 0f, 0f, 1f));
                    var greenBrush= new SolidColorBrush(renderTarget, new RawColor4(0f, 1f, 0f, 1f));
                    var yellowBrush = new SolidColorBrush(renderTarget, new RawColor4(1f, 1f, 0f, 1f));
                    var transparentBrush = new SolidColorBrush(renderTarget, new RawColor4(1, 1, 1, 0));

                    //var gazeLine = new Line3D(new Point3D(PointerPose.Head.ForwardDirection.X, PointerPose.Head.ForwardDirection.Y, PointerPose.Head.ForwardDirection.Z),
                    //                          new Point3D(PointerPose.Head.Position.X, PointerPose.Head.Position.Y, PointerPose.Head.Position.Z));

                    //var gazeRay = new Ray3D(new Point3D(PointerPose.Head.ForwardDirection.X, PointerPose.Head.ForwardDirection.Y, PointerPose.Head.ForwardDirection.Z), 
                    //                        gazeLine.Direction);

                    var gazeRay = new Ray3D(new Point3D(PointerPose.Head.Position.X, PointerPose.Head.Position.Y, PointerPose.Head.Position.Z),
                                            new UnitVector3D(PointerPose.Head.ForwardDirection.X, PointerPose.Head.ForwardDirection.Y, PointerPose.Head.ForwardDirection.Z));

                    var intersection = myPlane.IntersectionWith(gazeRay);

                    var startPoint = new RawVector2()
                    {
                        X = base.PointerPose.Head.Position.X,
                        Y = base.PointerPose.Head.Position.Z
                    };

                    var endPoint = new RawVector2()
                    {
                        X = base.PointerPose.Head.ForwardDirection.X + startPoint.X,
                        Y = base.PointerPose.Head.ForwardDirection.Z + startPoint.Y
                    };

                    // Calculate the Angle from Head to Gaze-Point 
                    // relative from original coordinate system

                    var pcGaze = new PolarCoordinate(endPoint.X - startPoint.X,
                                                     endPoint.Y - startPoint.Y);

                    // Alpha is always 90 Deg, since the object is parallel to the X-axis.
                    var α = 90;

                    // Beta is the Gazes vector angle relative to the X-axis, but we need its Angle
                    // relative to the Y-axis, so we subtract it from 90.
                    var β = RadToDeg(pcGaze.Angle) + 90;

                    // Since all angles always add up to 180 Deg, we know γ as well.
                    float tmpFac = 1;

                    if (β<0)
                    {
                        β = Math.Abs(β);
                    }

                    var γ = 180 - (α + β);

                    // This is side C of hour triangle. It's Length is the Delta of HoloPos and HeadPos.
                    var c = Position.Z - base.PointerPose.Head.Position.Z;
                    tmpFac = Math.Sign(c);

                    // With the Law of sines, we can now calculator the Length of a...
                    var a = (float)(c  / Math.Sin(DegToRad(γ)));

                    // ...which we now assume to be a Polar Coordiante (a,β), and we can calculate that back
                    // into the cartesian coordiante system.
                    var gazeHologramIntersection = new PolarCoordinate();
                    gazeHologramIntersection.Length = a;
                    gazeHologramIntersection.Angle = pcGaze.Angle;

                    if (DebugInfo != null)
                    {
                        myTextRenderer.RenderText(renderTarget, 0, 100, redBrush,
                            DebugInfo + $"\r\n Gaze Intersect X/Y, β, a: " +
                                    $"{intersection.X.ToString("0.0000")}/" +
                                    $"{intersection.Y.ToString("0.0000")}/" +
                                    $"{intersection.Z.ToString("0.0000")}/"); // + $" - {β.ToString("0.00")}, {a.ToString("0.00")}");
                    }

                    transformMatrix = Matrix3x2.CreateScale(TEXTURE_X_RES / DELTA_X , -TEXTURE_Y_RES / DELTA_Y) *
                                      Matrix3x2.CreateTranslation(TEXTURE_X_RES / 2, TEXTURE_Y_RES / 2);

                    rawMatrix = new RawMatrix3x2(transformMatrix.M11,
                                                     transformMatrix.M12,
                                                     transformMatrix.M21,
                                                     transformMatrix.M22,
                                                     transformMatrix.M31,
                                                     transformMatrix.M32);
                    renderTarget.Transform = rawMatrix;

                    try
                    {
                        // Drawing Coordinate System (2D where Z becomes Y and Y is neglected).
                        renderTarget.DrawLine(new RawVector2() { X = MIN_SCALE_X, Y = -0 },
                                                new RawVector2() { X = MAX_SCALE_X, Y = 0 },
                                                greenBrush, 0.05f);

                        renderTarget.DrawLine(new RawVector2() { X = 0, Y = MIN_SCALE_Y },
                        new RawVector2() { X = 0, Y = MAX_SCALE_Y },
                        greenBrush, 0.05f);

                        // Drawing the front Face as 2D figure.
                        renderTarget.DrawLine(new RawVector2() { X = Position.X + Area.Left, Y = Position.Z },
                                     new RawVector2() { X = Position.X + Area.Right, Y = Position.Z },
                                     redBrush, 0.05f);

                        renderTarget.DrawLine(startPoint, endPoint, redBrush, 0.05f);
                        renderTarget.DrawEllipse(new Ellipse(new RawVector2((float)(intersection.X-Position.X) * myGazePointScaleX,
                                                                            (float)(intersection.Y-Position.Y) * myGazePointScaleY), 0.1f, 0.1f),
                                                yellowBrush, 0.02f);
                        //renderTarget.DrawEllipse(new Ellipse(new RawVector2((float)intersection.X, (float)intersection.Y), 0.015f, 0.015f), transparentBrush,0.01f);
                    }

                    catch (Exception e)
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    if (Debugger.IsAttached)
                        Debugger.Break();
                }
                
            });

            try
            {
                renderTarget.EndDraw();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception on EndDraw:" + e.Message);
            }
        }

        internal override void UpdateInternal(StepTimer timer, Matrix4x4 genericTransformation)
        {
            base.UpdateInternal(timer, genericTransformation);
        }
    }
}

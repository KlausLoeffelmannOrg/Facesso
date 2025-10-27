using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Mathematics.Interop;

namespace Facesso.HoloLens.BaseClasses
{
    public class RayPlaneIntersection
    {
        public RayPlaneIntersection()
        {

        }

        private RawVector3 myHeadPosition;

        public RawVector3 HeadPosition
        {
            get { return myHeadPosition; }
            set { myHeadPosition = value; }
        }

        private RawVector3 myHeadForwardPosition;

        public RawVector3 HeadForwardPosition
        {
            get { return myHeadForwardPosition; }
            set { myHeadForwardPosition = value; }
        }

        private RawRectangleF myPlane;

        public RawRectangleF Plane
        {
            get { return myPlane; }
            set { myPlane = value; }
        }

        private RawVector3 myPlaneCenterPoint;

        public RawVector3 PlaneCenterPoint
        {
            get { return myPlaneCenterPoint; }
            set { myPlaneCenterPoint = value; }
        }

        private float myPlaneYaw;

        public float Yaw
        {
            get { return myPlaneYaw; }
            set { myPlaneYaw = value; }
        }

        private float myPlanePitch;

        public float Pitch
        {
            get { return myPlanePitch; }
            set { myPlanePitch = value; }
        }
    }
}

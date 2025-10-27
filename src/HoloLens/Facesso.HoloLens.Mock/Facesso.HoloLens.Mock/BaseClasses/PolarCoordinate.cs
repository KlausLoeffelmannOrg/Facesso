using System;

namespace Facesso.HoloLens.BaseClasses
{
    struct PolarCoordinate
    {
        private float myAngle;
        private float myLength;
        private float myX;
        private float myY;

        public PolarCoordinate(float x, float y)
        {
            
            myX = x;
            myY = y;
            myAngle = (float)Math.Atan2(myY, myX);
            myLength = (float)Math.Sqrt(myX * myX + myY * myY);
        }

        public float Angle
        {
            get { return myAngle; }
            set
            {
                if (!object.Equals(myAngle, value))
                {
                    myAngle = value;
                    myX = (float)(myLength * Math.Cos(myAngle));
                    myY = (float)(myLength * Math.Sin(myAngle));
                }
            }
        }

        public float Length
        {
            get { return myLength; }
            set
            {
                if (!object.Equals(myLength, value))
                {
                    myLength = value;
                    myX = (float)(myLength * Math.Cos(myAngle));
                    myY = (float)(myLength * Math.Sin(myAngle));
                }
            }
        }

        public float X
        {
            get { return myX; }
            set
            {
                if (!object.Equals(myX, value))
                {
                    myX = value;
                    myAngle = (float)Math.Atan2(myY, myX);
                    myLength = (float)Math.Sqrt(myX * myX + myY * myY);
                }
            }
        }

        public float Y
        {
            get { return myY; }
            set
            {
                if (!object.Equals(myY, value))
                {
                    myY = value;
                    myAngle = (float)Math.Atan2(myY, myX);
                    myLength = (float)Math.Sqrt(myX * myX + myY * myY);
                }
            }
        }
    }
}

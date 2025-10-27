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
using Windows.Perception.Spatial;
using Windows.UI.Input.Spatial;

namespace FacessoHoloLens
{
    public class Figure3DBase : Disposer, IDebuggableFigure
    {
        List<Figure3DPartBase> myFigureParts = null;
        private Vector3 myPosition;

        protected string myDebugInfo;
        protected SpatialPointerPose myPointerPose;
        protected SpatialCoordinateSystem myWorldCoordinateSystem;

        protected Figure3DBase()
        {
        }

        public static async Task<t> GetInitializedInstanceAsync<t>(DeviceResources deviceResources) where t : Figure3DBase, new()
        {
            var instanceToReturn = new t();
            instanceToReturn.myFigureParts = await instanceToReturn.OnAssemble3DPartsAsync(deviceResources);
            var taskList = new List<Task>();

            foreach (var item in instanceToReturn.myFigureParts)
            {
                taskList.Add(item.CreateDeviceDependentResourcesAsync());
            }

            await Task.WhenAll(taskList);
            return instanceToReturn;
        }

        public async Task RecreateDeviceDependentResourcesAsync()
        {
            foreach (var item in myFigureParts)
            {
                await item.CreateDeviceDependentResourcesAsync();
            }
        }

        protected virtual async Task<List<Figure3DPartBase>> OnAssemble3DPartsAsync(DeviceResources deviceResources)
        {
            await Task.Delay(0);
            return new List<Figure3DPartBase>();
        }

        public void ReleaseDeviceDependentResources()
        {
            foreach (var item in myFigureParts)
            {
                item.ReleaseDeviceDependentResources();
            }
        }

        public void Render()
        {
            foreach (var item in myFigureParts)
            {
                item.Render();
            }
        }

        internal protected virtual Matrix4x4 GenericTransform()
        {
            return Matrix4x4.Identity;
        }

        internal protected virtual void Update(StepTimer timer)
        {
            foreach (var item in myFigureParts)
            {
                item.UpdateInternal(timer,GenericTransform());
            }
        }

        public Vector3 Position
        {
            get
            {
                return myPosition;
            }

            set
            {
                myPosition = value;

                foreach (var item in myFigureParts)
                {
                    item.Position = value;
                }
            }
        }

        // This function uses a SpatialPointerPose to position the world-locked hologram
        // two meters in front of the user's heading.
        public void PositionHologram(SpatialPointerPose pointerPose)
        {
            OnPositionHologram(pointerPose);
        }

        protected virtual void OnPositionHologram(SpatialPointerPose pointerPose)
        {
            if (null != pointerPose)
            {
                // Get the gaze direction relative to the given coordinate system.
                Vector3 headPosition = pointerPose.Head.Position;
                Vector3 headDirection = pointerPose.Head.ForwardDirection;
                

                // The hologram is positioned two meters along the user's gaze direction.
                float distanceFromUser = 2.0f; // meters
                Vector3 gazeAtTwoMeters = headPosition + (distanceFromUser * headDirection);

                // This will be used as the translation component of the hologram's
                // model transform.
                this.Position = gazeAtTwoMeters;
            }
        }

        public List<Figure3DPartBase> FigureParts
        {
            get { return myFigureParts; }
        }

        public virtual string DebugInfo
        {
            get { return myDebugInfo; }
            set
            {
                if (!object.Equals(myDebugInfo, value))
                {
                    myDebugInfo = value;
                    foreach (var item in myFigureParts)
                    {
                        item.DebugInfo = value;
                    }
                }
            }
        }

        public virtual SpatialPointerPose PointerPose
        {
            get
            {
                return myPointerPose;
            }

            set
            {
                if (!object.Equals(myPointerPose, value))
                {
                    myPointerPose = value;
                    foreach (var item in myFigureParts)
                    {
                        item.PointerPose= value;
                    }
                }
            }
        }

        public virtual SpatialCoordinateSystem WorldCoordinateSystem
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
                    foreach (var item in myFigureParts)
                    {
                        item.WorldCoordinateSystem = value;
                    }
                }
            }
        }

    }
}

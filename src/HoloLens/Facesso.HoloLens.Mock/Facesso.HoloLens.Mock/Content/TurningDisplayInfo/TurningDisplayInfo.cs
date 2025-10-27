using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using FacessoHoloLens.Common;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using Windows.Perception.Spatial;
using Windows.UI.Input.Spatial;

namespace FacessoHoloLens.Content
{
    public class TurningDisplayInfo:Figure3DBase
    {
        protected async override Task<List<Figure3DPartBase>> OnAssemble3DPartsAsync(DeviceResources deviceResources)
        {
            var returnList=await base.OnAssemble3DPartsAsync(deviceResources);
            returnList.Add(await Figure3DPartBase.GetInitializedInstanceAsync<TurningDisplayInfoBackPart>(deviceResources));
            returnList.Add(await Figure3DPartBase.GetInitializedInstanceAsync<TurningDisplayInfoSideParts>(deviceResources));
            returnList.Add(await Figure3DPartBase.GetInitializedInstanceAsync<TurningDisplayInfoFrontPart>(deviceResources));
            return returnList;
        }

        public override string DebugInfo
        {
            get { return myDebugInfo; }
            set
            {
                if (!object.Equals(myDebugInfo, value))
                {
                    myDebugInfo = value;
                    FigureParts[(int) TurningDisplayInfoParts.FrontPart].DebugInfo = value;
                }
            }
        }
    }

    public enum TurningDisplayInfoParts 
    {
        Backpart=0,
        SideParts=1,
        FrontPart=2
    }
}

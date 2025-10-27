using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Perception.Spatial;
using Windows.UI.Input.Spatial;

namespace Facesso.HoloLens
{
    public interface IDebuggableFigure
    {
        string DebugInfo { get; set; }
        SpatialPointerPose PointerPose { get; set; }
        SpatialCoordinateSystem WorldCoordinateSystem { get; set; }

    }
}

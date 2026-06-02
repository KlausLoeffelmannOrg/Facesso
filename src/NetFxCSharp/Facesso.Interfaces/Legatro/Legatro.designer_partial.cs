using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class ViewTimeLogNativeVerbatim
    {
        public bool IsWorksiteChange
        {
            get
            {
                if ((Facesso.Interfaces.BookingTypes)(this.BookingType) == BookingTypes.Arrive & this.WorkEntityNumber.HasValue)
                {
                    return true;
                }

                return false;
            }
        }
    }

    public enum BookingTypes
    {
        Undefined = 0,
        Arrive = 1,
        Leave = 2,
        WorkBreak = 3,
        DownTime = 4,
        OffSiteWork = 5,
    }
}
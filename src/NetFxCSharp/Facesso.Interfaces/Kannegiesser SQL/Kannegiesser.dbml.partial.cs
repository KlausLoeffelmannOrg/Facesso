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
    public partial class GetMachinesResult
    {
        public override string ToString()
        {
            return this.MachineID + ": " + this.MachineName;
        }
    }
}
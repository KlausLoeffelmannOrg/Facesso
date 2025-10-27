using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class FunctionLog
    {
        public Guid IdfunctionLog { get; set; }
        public Guid Idsubsidiary { get; set; }
        public string FunctionText { get; set; }
        public Guid CalledByIduser { get; set; }
        public DateTime DateCalled { get; set; }
        public string OnComputer { get; set; }

        public virtual Users Users { get; set; }
    }
}

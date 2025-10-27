using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class ApplicationSettings
    {
        public Guid IdapplicationSettings { get; set; }
        public Guid Idsubsidiary { get; set; }
        public bool IsGlobal { get; set; }
        public Guid Iduser { get; set; }
        public string Settings { get; set; }

        public virtual Users Id { get; set; }
    }
}

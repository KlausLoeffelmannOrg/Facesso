using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class SkillProvided
    {
        public Guid IdskillProvided { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid Idemployee { get; set; }
        public Guid Idskill { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Skills Ids { get; set; }
        public virtual Employees Id { get; set; }
    }
}

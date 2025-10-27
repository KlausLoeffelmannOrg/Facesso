using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class SkillNeeded
    {
        public Guid IdskillNeeded { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid Idskill { get; set; }
        public Guid IdworkGroup { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Skills Ids { get; set; }
        public virtual WorkGroups Id { get; set; }
    }
}

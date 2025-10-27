using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class Skills
    {
        public Skills()
        {
            SkillNeeded = new HashSet<SkillNeeded>();
            SkillProvided = new HashSet<SkillProvided>();
        }

        public Guid Idskill { get; set; }
        public Guid Idsubsidiary { get; set; }
        public string SkillDescription { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual ICollection<SkillNeeded> SkillNeeded { get; set; }
        public virtual ICollection<SkillProvided> SkillProvided { get; set; }
        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}

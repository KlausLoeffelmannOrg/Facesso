using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class LabourValues
    {
        public Guid IdlabourValue { get; set; }
        public Guid Idsubsidiary { get; set; }
        public int IdlabourValueInternal { get; set; }
        public Guid IdcostCenter { get; set; }
        public int LabourValueNumber { get; set; }
        public string LabourValueName { get; set; }
        public string LabourValueDescription { get; set; }
        public double TeHmin { get; set; }
        public string Dimension { get; set; }
        public bool IsActive { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime WasCurrentFrom { get; set; }
        public DateTime WasCurrentTo { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}

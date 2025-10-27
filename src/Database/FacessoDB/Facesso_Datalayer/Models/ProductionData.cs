using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class ProductionData
    {
        public ProductionData()
        {
            ProductionDataItems = new HashSet<ProductionDataItems>();
            ProductionDataItemsForInsert = new HashSet<ProductionDataItemsForInsert>();
        }

        public Guid IdproductionData { get; set; }
        public Guid Idsubsidiary { get; set; }
        public Guid IdworkGroup { get; set; }
        public int IdworkGroupInternal { get; set; }
        public Guid Idemployee { get; set; }
        public DateTime ProductionDate { get; set; }
        public byte Shift { get; set; }
        public double TotalReferenceIwt { get; set; }
        public double TotalEffectiveIwt { get; set; }
        public double TotalEffectiveIwtadj { get; set; }
        public double TotalDownTime { get; set; }
        public double TotalWorkBreakTime { get; set; }
        public double DegreeOfTime { get; set; }
        public double DegreeOfTimeAdj { get; set; }
        public bool InsertedByInterface { get; set; }
        public bool IsSuspended { get; set; }
        public DateTime LastEdited { get; set; }
        public Guid LastEditedByIduser { get; set; }

        public virtual ICollection<ProductionDataItems> ProductionDataItems { get; set; }
        public virtual ICollection<ProductionDataItemsForInsert> ProductionDataItemsForInsert { get; set; }
        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
        public virtual WorkGroups Id { get; set; }
    }
}

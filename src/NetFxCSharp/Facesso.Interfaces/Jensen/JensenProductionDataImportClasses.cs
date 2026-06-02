using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    [FacessoImportFilterName("Jensen Produktionsdatenimport", FacessoImportType.WorkGroupData, FacessoInterfaceBrand.KannegiesserProductionData)]
    public partial class JensenProductionDataImportTaskElement : FacessoProductionDataImportTaskItemBase
    {
        private string myJensenSQLConnectionString;
        private string myJensenDeviceID;
        private System.DateTime myCurrDate;
        private DataTable myCurrOrgData;
        private ProductionDataTable myCurrFacData;
        public string JensenSQLConnectionString
        {
            get
            {
                return myJensenSQLConnectionString;
            }

            set
            {
                myJensenSQLConnectionString = value;
            }
        }

        public string JensenDeviceID
        {
            get
            {
                return myJensenDeviceID;
            }

            set
            {
                myJensenDeviceID = value;
            }
        }

        public override System.Windows.Forms.DialogResult ConfigureImportFilter()
        {
            frmJensenProdDataConfigDialog locFrm = new frmJensenProdDataConfigDialog();
            return locFrm.HandleDialog(this);
        }

        public override IImportResultTable GetData(System.DateTime ProductionDate, ShiftCombination Shift)
        {
            retrieveDataForDate(ProductionDate);
            return myCurrFacData;
        }

        public override FacessoImportType ImportType
        {
            get
            {
                return FacessoImportType.WorkGroupData;
            }
        }

        public override FacessoInterfaceBrand InterfaceBrand
        {
            get
            {
                return FacessoInterfaceBrand.JensenProductionData;
            }
        }

        public override System.Windows.Forms.DialogResult ConfigureGenericInterface()
        {
            return System.Windows.Forms.DialogResult.OK;
        }

        public override bool IsGenericInterfaceConfigured
        {
            get
            {
                return true;
            }
        }

        public override FacessoConversionItemsBase AssembleConversionItems()
        {
            return base.AssembleConversionItems();
        }
    }
}
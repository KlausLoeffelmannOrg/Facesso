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
    [FacessoImportFilterName("Kannegiesser Produktionsdatenimport", FacessoImportType.WorkGroupData, FacessoInterfaceBrand.KannegiesserProductionData)]
    public partial class KannegiesserProductionDataImportTaskElement : FacessoProductionDataImportTaskItemBase
    {
        private string myPathToDeviceData;
        private System.DateTime myCurrDate;
        private DataTable myCurrOrgData;
        private ProductionDataTable myCurrFacData;
        public string PathToDeviceData
        {
            get
            {
                return myPathToDeviceData;
            }

            set
            {
                myPathToDeviceData = value;
            }
        }

        public override System.Windows.Forms.DialogResult ConfigureImportFilter()
        {
            frmKannegiesserProdDataConfigDialog locFrm = new frmKannegiesserProdDataConfigDialog();
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
                return FacessoInterfaceBrand.KannegiesserProductionData;
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
            if (PathToDeviceData == null)
            {
                return null;
            }

            FacessoConversionItemsBase locConversionItems = default(FacessoConversionItemsBase);
            locConversionItems = new FacessoConversionItemsBase();
            OleDbConnection locConnection = new OleDbConnection(ConnectionString);
            using (locConnection)
            {
                OleDbDataAdapter locAdapter = new OleDbDataAdapter("SELECT * FROM ARTPAR", locConnection);
                DataTable locTable = new DataTable();
                int locIntBack = locAdapter.Fill(locTable);
                foreach (DataRow locRow in locTable.Rows)
                {
                    locConversionItems.Add(new FacessoConversionItemBase(System.Convert.ToInt32(locRow["INDEX"]), locRow["NAME"].ToString()));
                }
            }

            return locConversionItems;
        }

        public string ConnectionString
        {
            get
            {
                string locConnString = default(string);
                if (myPathToDeviceData == null)
                {
                    return null;
                }

                locConnString = "Jet OLEDB:Database Password=;";
                locConnString += "Data Source=" + myPathToDeviceData + ";Password=;";
                locConnString += "Provider=\"Microsoft.Jet.OLEDB.4.0\";";
                locConnString += "Extended Properties=dBASE IV;";
                locConnString += "Jet OLEDB:SFP=False;";
                locConnString += "Mode=Share Deny None;";
                locConnString += "User ID=Admin;";
                return locConnString;
            }
        }
    }
}
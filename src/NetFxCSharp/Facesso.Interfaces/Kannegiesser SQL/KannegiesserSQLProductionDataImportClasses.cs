using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    [FacessoImportFilterName("Kannegiesser SQL Produktionsdatenimport", FacessoImportType.WorkGroupData, FacessoInterfaceBrand.KannegiesserSQLProductionData)]
    public partial class KannegiesserSQLProductionDataImportTaskElement : FacessoProductionDataImportTaskItemBase
    {
        private string myKannegiesserSQLConnectionString;
        private System.DateTime myCurrDate;
        private DataTable myCurrOrgData;
        private ProductionDataTable myCurrFacData;
        public string KannegiesserDeviceID { get; set; }

        public override System.Windows.Forms.DialogResult ConfigureImportFilter()
        {
            frmKannegiesserSQLProdDataConfigDialog locFrm = new frmKannegiesserSQLProdDataConfigDialog();
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
                return FacessoInterfaceBrand.KannegiesserSQLProductionData;
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
            if (KannegiesserSQLConnectionString == null)
            {
                return null;
            }

            FacessoConversionItemsBase locConversionItems = default(FacessoConversionItemsBase);
            locConversionItems = new FacessoConversionItemsBase();
            var oc = new KannegiesserDataContext();
            var artpar = (
                from prgItems in oc.GetArticles()select prgItems);
            foreach (var artItems in artpar)
            {
                locConversionItems.Add(new FacessoConversionItemBase(artItems.ArticleID, artItems.ArticleName));
            }

            return locConversionItems;
        }

        //Dass es hier zwei Eigenschaften gibt, die den SQL-Connection-String zurückliefern, hat historische Gründe.
        public string ConnectionString
        {
            get
            {
                return myKannegiesserSQLConnectionString;
            }
        }

        public string KannegiesserSQLConnectionString
        {
            get
            {
                return myKannegiesserSQLConnectionString;
            }

            set
            {
                myKannegiesserSQLConnectionString = value;
            }
        }
    }
}
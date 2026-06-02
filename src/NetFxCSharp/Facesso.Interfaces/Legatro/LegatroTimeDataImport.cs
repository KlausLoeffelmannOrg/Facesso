using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    [FacessoImportFilterName("Legato-Zeitdatenimport", FacessoImportType.TimeKeepingData, FacessoInterfaceBrand.LegatroTimeKeeping)]
    public class LegatroTimeDataImport : TimeDataImportBase
    {
        private string myLegatroSQLConnectionString;
        public override System.Windows.Forms.DialogResult ConfigureGenericInterface()
        {
            return MessageBox.Show("Configure Inport Filter");
        }

        public override System.Windows.Forms.DialogResult ConfigureImportFilter()
        {
            frmLegatroTimeDataConfigDialog frm = new frmLegatroTimeDataConfigDialog();
            return frm.HandleDialog(this);
        }

        public override IImportResultTable GetData(System.DateTime ProductionDate, ShiftCombination Shift)
        {
            LegatroTimeDataTransformation ltdt = new LegatroTimeDataTransformation(ProductionDate, (int)(Shift), this);
            ltdt.Convert();
            return ltdt.ResultTable();
        }

        public override FacessoInterfaceBrand InterfaceBrand
        {
            get
            {
                return FacessoInterfaceBrand.LegatroTimeKeeping;
            }
        }

        public string LegatroSQLConnectionString
        {
            get
            {
                return myLegatroSQLConnectionString;
            }

            set
            {
                myLegatroSQLConnectionString = value;
            }
        }

        public override FacessoConversionItemsBase AssembleConversionItems()
        {
            if (string.IsNullOrEmpty(LegatroSQLConnectionString))
            {
                return null;
            }

            FacessoConversionItemsBase locConversionItems = new FacessoConversionItemsBase();
            LegatroDataContext dc = new LegatroDataContext(LegatroSQLConnectionString);
            var wg = (
                from wgItems in dc.WorksitesOrProjects
                orderby wgItems.WorkEntityNumber
                select wgItems);
            foreach (var wgItem in wg)
            {
                locConversionItems.Add(new FacessoConversionItemBase(wgItem.WorkEntityNumber, wgItem.WorkEntityName));
            }

            return locConversionItems;
        }

        public override bool IsGenericInterfaceConfigured
        {
            get
            {
                return true;
            }
        }
    }
}
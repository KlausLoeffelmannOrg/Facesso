using Facesso.Data;
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
    public partial class frmNewImportTask
    {
        private IFacessoImportTaskItem myImportTaskToReturn;
        public IFacessoImportTaskItem GetImportTask()
        {
            InitializeHeaders();
            InitializeTaskTemplates();
            this.ShowDialog();
            return myImportTaskToReturn;
        }

        private void InitializeHeaders()
        {
            {
                var __with0 = lvwTaskTemplates;
                {
                    var __with1 = __with0.Columns;
                    __with1.Add("Task-Name", -2, System.Windows.Forms.HorizontalAlignment.Left);
                    __with1.Add("Import-Typ", -2, System.Windows.Forms.HorizontalAlignment.Left);
                }
            }

            {
                var __with2 = lvwDeviceClasses;
                {
                    var __with3 = __with2.Columns;
                    __with3.Add("Geräte-Klasse", -2, System.Windows.Forms.HorizontalAlignment.Left);
                }
            }
        }

        private void InitializeTaskTemplates()
        {
            WorkGroupInfoItems locWorkgroups = new WorkGroupInfoItems(true);
            FacessoTaskItemTemplate locTaskTemplate = default(FacessoTaskItemTemplate);
            ListViewItem locLvwItem = default(ListViewItem);
            lvwTaskTemplates.Items.Clear();
            long locCount = 0;
            //TimeKeeping-Importfilter hinzufügen
            locTaskTemplate = new FacessoTaskItemTemplate(locCount, "Für allgemeine Zeiterfassung", FacessoImportType.TimeKeepingData);
            locLvwItem = new ListViewItem(locTaskTemplate.ToString());
            locLvwItem.Tag = locTaskTemplate;
            locLvwItem.SubItems.Add("Zeiterfassung");
            lvwTaskTemplates.Items.Add(locLvwItem);
            //Produktiv-Site-Importfilter hinzufügen
            foreach (WorkGroupInfo locWorkgroup in locWorkgroups)
            {
                locTaskTemplate = new FacessoTaskItemTemplate(locCount, "für Prod.-Site: " + locWorkgroup.WorkGroupNumber + ": " + locWorkgroup.WorkGroupName, FacessoImportType.WorkGroupData, locWorkgroup.IDWorkGroup);
                locLvwItem = new ListViewItem(locTaskTemplate.ToString());
                locLvwItem.Tag = locTaskTemplate;
                locLvwItem.SubItems.Add("Produktionsdaten");
                lvwTaskTemplates.Items.Add(locLvwItem);
            }
        }

        private void InitializeDeviceClasses(FacessoImportType ImportType)
        {
            lvwDeviceClasses.Items.Clear();
            if (ImportType == FacessoImportType.NotDefined)
            {
                return;
            }

            foreach (FacessoInterfaceClassItem locItem in frmImport.Interfaces)
            {
                if (locItem.InterfaceAttribute.ImportType == ImportType)
                {
                    ListViewItem locLvwItem = new ListViewItem(locItem.InterfaceAttribute.ImportFiltername);
                    locLvwItem.Tag = locItem;
                    lvwDeviceClasses.Items.Add(locLvwItem);
                }
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            myImportTaskToReturn = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void lvwTaskTemplates_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lvwTaskTemplates.SelectedIndices.Count == 0)
            {
                InitializeDeviceClasses(FacessoImportType.NotDefined);
                return;
            }

            FacessoTaskItemTemplate locSelectedItem = ((FacessoTaskItemTemplate)lvwTaskTemplates.SelectedItems[0].Tag);
            InitializeDeviceClasses(locSelectedItem.ImportType);
        }

        private void lvwDeviceClasses_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lvwTaskTemplates.SelectedIndices.Count == 0)
            {
                btnOK.Enabled = false;
                return;
            }

            btnOK.Enabled = true;
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            //Aus den TaskTemplates eine Instanz für die Konfigurierung der Klasse erstellen
            FacessoTaskItemTemplate locTemplate = ((FacessoTaskItemTemplate)lvwTaskTemplates.SelectedItems[0].Tag);
            FacessoInterfaceClassItem locInterface = ((FacessoInterfaceClassItem)lvwDeviceClasses.SelectedItems[0].Tag);
            Type locTaskType = locInterface.InterfaceType;
            //Instanz des Objektes mit parameterlosem Konstruktor erstellen
            object locObject = locTaskType.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance, null, null, null);
            //In den richtigen Typ casten
            myImportTaskToReturn = ((IFacessoImportTaskItem)locObject);
            myImportTaskToReturn.IDWorkgroup = locTemplate.IDWorkgroup;
            myImportTaskToReturn.Name = locTemplate.Name + " mit " + locInterface.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public frmNewImportTask()
        {
            InitializeComponent();
        }
    }
}
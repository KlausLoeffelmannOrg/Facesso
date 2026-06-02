using Facesso;
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class frmProductionDataConfigureDialogBase
    {
        private IFacessoImportTaskItem myTaskItem;
        private LabourValueInfoCollection myLabourValues;
        protected bool myAllowMultipleAssignments;
        public DialogResult HandleDialog(IFacessoImportTaskItem TaskItem)
        {
            myTaskItem = TaskItem;
            myLabourValues = LabourValueInfoCollection.GetWorkGroupAssignedLabourValues(FacessoGeneric.LoginInfo.IDSubsidiary, myTaskItem.ForWorkgroup);
            InitializeControls();
            RebuildLists();
            this.ShowDialog();
            return this.DialogResult;
        }

        protected IFacessoImportTaskItem TaskItem
        {
            get
            {
                return myTaskItem;
            }

            set
            {
                myTaskItem = value;
            }
        }

        protected virtual void InitializeControls()
        {
            {
                var __with0 = lvwDeviceItems;
                __with0.Columns.Add("ID", -2, HorizontalAlignment.Left);
                __with0.Columns.Add("Beschreibung", -2, HorizontalAlignment.Left);
                __with0.Columns.Add("Arbeitswert", -2, HorizontalAlignment.Left);
            }

            if (myTaskItem.ConversionItems == null)
            {
                myTaskItem.ConversionItems = myTaskItem.ConversionItemsDelegate.Invoke();
            }

            lblTitel.Text = "Konfiguration für Produktiv-Site:" + System.Environment.NewLine + myTaskItem.ForWorkgroup.ListItemText;
        }

        protected virtual void RebuildLists()
        {
            LabourValueInfo locSelectedLabourValue = null;
            IFacessoConversionItem locSelectedDeviceItem = null;
            try
            {
                locSelectedLabourValue = ucLabourValues.FirstSelectedLabourValue;
                locSelectedDeviceItem = ((IFacessoConversionItem)lvwDeviceItems.SelectedItems[0].Tag);
            }
            catch (Exception ex)
            {
            }

            lvwDeviceItems.BeginUpdate();
            lvwDeviceItems.Items.Clear();
            //Nur neu aufbauen, wenn die ableitende Klasse
            //diese Eigenschaft auf True setzt.
            if (!(BlockDeviceListBuilding))
            {
                if (myTaskItem.ConversionItems != null)
                {
                    foreach (IFacessoConversionItem locItem in myTaskItem.ConversionItems)
                    {
                        ListViewItem locLvwItem = new ListViewItem(locItem.AlienElementID.ToString("000000"));
                        locLvwItem.SubItems.Add(locItem.Itemname);
                        if (locItem.HomeElementID == -1)
                        {
                            locLvwItem.SubItems.Add("- - -");
                        }
                        else
                        {
                            locLvwItem.SubItems.Add(locItem.HomeElementName);
                            locLvwItem.Font = new Font(locLvwItem.Font, FontStyle.Bold);
                        }

                        locLvwItem.Tag = locItem;
                        lvwDeviceItems.Items.Add(locLvwItem);
                    }
                }

                lvwDeviceItems.Columns[0].Width = -2;
                lvwDeviceItems.Columns[1].Width = -2;
                lvwDeviceItems.Columns[2].Width = -2;
            }

            lvwDeviceItems.EndUpdate();
            LabourValueInfoCollection locToAssignList = new LabourValueInfoCollection();
            foreach (LabourValueInfo locItem in myLabourValues)
            {
                locToAssignList.Add(locItem);
            }

            //Elemente, die schon verwendet wurden, nur dann entfernen, wenn
            //Mehrfachzuweisungen nicht erlaubt sind!
            if (!(myAllowMultipleAssignments))
            {
                foreach (ListViewItem locDestItem in lvwDeviceItems.Items)
                {
                    IFacessoConversionItem locItem = ((IFacessoConversionItem)locDestItem.Tag);
                    locToAssignList.Remove(new ActiveDev.IntKey(locItem.HomeElementID));
                }
            }

            ucLabourValues.LabourValues = locToAssignList;
            //Dafür sorgen, dass zuvor Dargestellte wieder angezeigt werden.
            if (locSelectedLabourValue != null)
            {
                ucLabourValues.SelectLabourValue(locSelectedLabourValue, true);
            }

            if (locSelectedDeviceItem != null)
            {
                foreach (ListViewItem locItem in lvwDeviceItems.Items)
                {
                    IFacessoConversionItem locDevItem = ((IFacessoConversionItem)locItem.Tag);
                    if (locDevItem.AlienElementID == locSelectedDeviceItem.AlienElementID)
                    {
                        locItem.Selected = true;
                        locItem.EnsureVisible();
                    }
                }
            }
        }

        protected virtual void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            if (ucLabourValues.FirstSelectedLabourValue == null)
            {
                MessageBox.Show("Bitte wählen Sie zunächst einen REFA-Arbeitswert aus, den Sie an die Geräte-IDs zuweisen möchten!", "Fehlende Arbeitswertauswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lvwDeviceItems.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie zunächst eine DeviceID aus, der Sie den REFA-Arbeitswert zuweisen möchten!", "Fehlender Device-ID-Auswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            LabourValueInfo locLabourValue = ucLabourValues.FirstSelectedLabourValue;
            IFacessoConversionItem locDeviceItem = ((IFacessoConversionItem)lvwDeviceItems.SelectedItems[0].Tag);
            locDeviceItem.HomeElementID = locLabourValue.IDLabourValue;
            locDeviceItem.HomeElementName = locLabourValue.LabourValueNumber + ": " + locLabourValue.LabourValueName;
            RebuildLists();
        }

        protected virtual void btnRemove_Click(System.Object sender, System.EventArgs e)
        {
            if (lvwDeviceItems.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie zunächst eine DeviceID aus, deren REFA-Arbeitswert-Zuweisung Sie aufheben möchten!", "Fehlender Device-ID-Auswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            IFacessoConversionItem locDeviceItem = ((IFacessoConversionItem)lvwDeviceItems.SelectedItems[0].Tag);
            locDeviceItem.HomeElementID = -1;
            locDeviceItem.HomeElementName = null;
            RebuildLists();
        }

        protected virtual void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected virtual void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        protected virtual bool BlockDeviceListBuilding
        {
            get
            {
                return false;
            }
        }

        public frmProductionDataConfigureDialogBase()
        {
            InitializeComponent();
        }
    }
}
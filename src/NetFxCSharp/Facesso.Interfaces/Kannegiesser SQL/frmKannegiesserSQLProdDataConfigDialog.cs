using ActiveDev.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class frmKannegiesserSQLProdDataConfigDialog
    {
        private bool mySetByAssignment;
        private void btnChoosePath_Click(System.Object sender, System.EventArgs e)
        {
            PickSqlConnectionString();
        }

        private void PickSqlConnectionString()
        {
            ADDatabaseConnectionDialog locFB = new ADDatabaseConnectionDialog();
            SqlConnectionStringBuilder locCB = locFB.GetConnectionBuilder("Kannegiesser-SQL-Verbindung:");
            if (locCB != null)
            {
                txtSqlConnectionString.Text = locCB.ToString();
            }
            else
            {
                lblDevice.Enabled = false;
                cmbDevice.Enabled = false;
                return;
            }

            if (TryPopulateKannegiesserDevices())
            {
                lblDevice.Enabled = true;
                cmbDevice.Enabled = true;
                ((KannegiesserSQLProductionDataImportTaskElement)TaskItem).KannegiesserSQLConnectionString = locCB.ToString();
                ((KannegiesserSQLProductionDataImportTaskElement)TaskItem).KannegiesserDeviceID = null;
                TaskItem.ConversionItems = ((KannegiesserSQLProductionDataImportTaskElement)TaskItem).AssembleConversionItems();
                RebuildLists();
            }
            else
            {
                lblDevice.Enabled = false;
                cmbDevice.Enabled = false;
            }
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();
            if (string.IsNullOrEmpty(((KannegiesserSQLProductionDataImportTaskElement)TaskItem).KannegiesserSQLConnectionString))
            {
                PickSqlConnectionString();
            }
            else
            {
                txtSqlConnectionString.Text = ((KannegiesserSQLProductionDataImportTaskElement)TaskItem).KannegiesserSQLConnectionString;
            }

            if (TryPopulateKannegiesserDevices())
            {
                SetKannegiesserDevice(((KannegiesserSQLProductionDataImportTaskElement)TaskItem).KannegiesserDeviceID);
            }

            myAllowMultipleAssignments = true;
        }

        protected override bool BlockDeviceListBuilding
        {
            get
            {
                try
                {
                    if (((KannegiesserSQLProductionDataImportTaskElement)TaskItem).KannegiesserSQLConnectionString != null)
                    {
                        if (((KannegiesserSQLProductionDataImportTaskElement)TaskItem).KannegiesserDeviceID != null)
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                return true;
            }
        }

        private void cmbDevice_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            ((KannegiesserSQLProductionDataImportTaskElement)TaskItem).KannegiesserDeviceID = GetKannegiesserDevice();
            if (mySetByAssignment)
            {
                mySetByAssignment = false;
            }
            else
            {
                TaskItem.ConversionItems = ((KannegiesserSQLProductionDataImportTaskElement)TaskItem).AssembleConversionItems();
            }

            RebuildLists();
        }

        private bool TryPopulateKannegiesserDevices()
        {
            if (txtSqlConnectionString.Text != null)
            {
                //Versuchen, aufzumachen
                SqlConnection locConnection = new SqlConnection(txtSqlConnectionString.Text);
                using (locConnection)
                {
                    try
                    {
                        locConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Verbindung zur Kannegiesser-Datenbankinstanz konnte nicht hergestellt werden!", "Verbindungsfehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    KannegiesserDataContext oc = new KannegiesserDataContext(txtSqlConnectionString.Text);
                    var machineList = ((
                        from item in oc.GetMachines()select item)).ToList();
                    cmbDevice.Items.Clear();
                    cmbDevice.Items.Add("- nicht definiert -");
                    if (machineList.Count > 0)
                    {
                        foreach (var item in machineList)
                        {
                            cmbDevice.Items.Add(item);
                        }
                    }
                }

                return true;
            }

            return default(bool);
        }

        private string GetKannegiesserDevice()
        {
            if (cmbDevice.SelectedIndex <= 0)
            {
                return null;
            }

            if (cmbDevice.SelectedItem != null)
            {
                return ((GetMachinesResult)cmbDevice.SelectedItem).MachineID.ToString();
            }

            return null;
        }

        private void SetKannegiesserDevice(string Device)
        {
            mySetByAssignment = true;
            if (string.IsNullOrEmpty(Device))
            {
                cmbDevice.SelectedIndex = 0;
                return;
            }

            for (int locIndex = 0; locIndex <= cmbDevice.Items.Count - 1; locIndex++)
            {
                if (locIndex > 0)
                {
                    if (((GetMachinesResult)cmbDevice.Items[locIndex]).MachineID.ToString() == Device)
                    {
                        cmbDevice.SelectedIndex = locIndex;
                        return;
                    }
                }
            }

            cmbDevice.SelectedIndex = 0;
        }

        public frmKannegiesserSQLProdDataConfigDialog()
        {
            InitializeComponent();
        }
    }
}
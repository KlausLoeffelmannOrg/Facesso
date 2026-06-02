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
    public partial class frmJensenProdDataConfigDialog
    {
        private void btnChoosePath_Click(System.Object sender, System.EventArgs e)
        {
            ADDatabaseConnectionDialog locFB = new ADDatabaseConnectionDialog();
            SqlConnectionStringBuilder locCB = locFB.GetConnectionBuilder("Jensen-SQL-Verbindung:");
            if (locCB != null)
            {
                txtSqlConnectionString.Text = locCB.ToString();
                ((JensenProductionDataImportTaskElement)TaskItem).JensenSQLConnectionString = locCB.ToString();
                ((JensenProductionDataImportTaskElement)TaskItem).JensenDeviceID = null;
                TryPopulateJensenDevices();
            }
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();
            txtSqlConnectionString.Text = ((JensenProductionDataImportTaskElement)TaskItem).JensenSQLConnectionString;
            if (TryPopulateJensenDevices())
            {
                SetJensenDevice(((JensenProductionDataImportTaskElement)TaskItem).JensenDeviceID);
            }

            myAllowMultipleAssignments = false;
        }

        protected override bool BlockDeviceListBuilding
        {
            get
            {
                try
                {
                    if (((JensenProductionDataImportTaskElement)TaskItem).JensenSQLConnectionString != null)
                    {
                        if (((JensenProductionDataImportTaskElement)TaskItem).JensenDeviceID != null)
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

        private void cmbJensenDevice_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            ((JensenProductionDataImportTaskElement)TaskItem).JensenDeviceID = GetJensenDevice();
            RebuildLists();
        }

        public bool TryPopulateJensenDevices()
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
                        MessageBox.Show("Verbindung zur Jensendatenbank konnte nicht hergestellt werden!", "Verbindungsfehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                        lblDevice.Enabled = false;
                        cmbDevice.Enabled = false;
                    }

                    SqlCommand locCommand = new SqlCommand("SELECT TargetID FROM LogInfo", locConnection);
                    SqlDataReader locReader = locCommand.ExecuteReader();
                    cmbDevice.Items.Clear();
                    cmbDevice.Items.Add("- nicht definiert -");
                    if (locReader.HasRows)
                    {
                        while (locReader.Read())
                        {
                            cmbDevice.Items.Add(locReader.GetString(locReader.GetOrdinal("TargetID")));
                        }
                    }
                }

                lblDevice.Enabled = true;
                cmbDevice.Enabled = true;
                return true;
            }

            return default(bool);
        }

        private string GetJensenDevice()
        {
            if (cmbDevice.SelectedItem != null)
            {
                return cmbDevice.SelectedItem.ToString();
            }

            return null;
        }

        private void SetJensenDevice(string Device)
        {
            for (int locIndex = 0; locIndex <= cmbDevice.Items.Count - 1; locIndex++)
            {
                if (cmbDevice.Items[locIndex].ToString() == Device)
                {
                    cmbDevice.SelectedIndex = locIndex;
                    return;
                }
            }

            cmbDevice.SelectedIndex = 0;
        }

        public frmJensenProdDataConfigDialog()
        {
            InitializeComponent();
        }
    }
}
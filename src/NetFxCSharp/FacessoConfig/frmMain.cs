using Facesso;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FacessoConfig
{
    public partial class frmMain
    {
        public frmMain()
        {
            // This call is required by the designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
        }

        private void btnSetupDatabase_Click(System.Object sender, System.EventArgs e)
        {
            frmDbSetupWizard locDbSetupWizard = new frmDbSetupWizard();
            locDbSetupWizard.ShowDialog();
        }

        private void btnActivateFacesso_Click(System.Object sender, System.EventArgs e)
        {
            frmSetupWizard locSetupWizard = new frmSetupWizard();
            locSetupWizard.ShowDialog();
        }

        private void btnSetDatabaseInstance_Click(System.Object sender, System.EventArgs e)
        {
            ActiveDev.Data.SqlClient.ADDatabaseConnectionDialog locFrm = new ActiveDev.Data.SqlClient.ADDatabaseConnectionDialog();
            SqlConnectionStringBuilder locSqlConnBuilder = locFrm.GetConnectionBuilder();
            if (locSqlConnBuilder != null)
            {
                RegistryHelper.SetConnectionString(locSqlConnBuilder.ToString());
            }
        }

        private void btnUpdateSchema_Click(System.Object sender, System.EventArgs e)
        {
        }
    }
}
namespace ActiveDev.Data.SqlClient
{
    partial class ADDatabaseConnectionDialog
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private System.ComponentModel.IContainer components = null;

        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.SqlDatabaseConnector = new ActiveDev.Data.SqlClient.ADSqlDatabaseConnector();
            this.SuspendLayout();
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(139, 433);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(237, 433);
            //
            // btnTestConnection
            //
            this.btnTestConnection.Location = new System.Drawing.Point(12, 433);
            //
            // txtLoginString
            //
            this.txtLoginString.Location = new System.Drawing.Point(12, 381);
            //
            // SqlDatabaseConnector
            //
            this.SqlDatabaseConnector.CredentialMethod = ActiveDev.Data.SqlClient.SqlCredentialMethods.WindowsIntegratedSecurity;
            this.SqlDatabaseConnector.CredentialParameters = null;
            this.SqlDatabaseConnector.DatabaseSource = ActiveDev.Data.SqlClient.SqlDatabaseSource.FromSqlServerInstance;
            this.SqlDatabaseConnector.FileToAttach = "";
            this.SqlDatabaseConnector.Location = new System.Drawing.Point(12, 213);
            this.SqlDatabaseConnector.LogicalDatabasename = "";
            this.SqlDatabaseConnector.MaximumSize = new System.Drawing.Size(0, 162);
            this.SqlDatabaseConnector.MinimumSize = new System.Drawing.Size(317, 162);
            this.SqlDatabaseConnector.Name = "SqlDatabaseConnector";
            this.SqlDatabaseConnector.Size = new System.Drawing.Size(317, 162);
            this.SqlDatabaseConnector.SqlInstance = null;
            this.SqlDatabaseConnector.TabIndex = 4;
            //
            // ADDatabaseConnectionDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(337, 475);
            this.Controls.Add(this.SqlDatabaseConnector);
            this.Name = "ADDatabaseConnectionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.txtLoginString, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnTestConnection, 0);
            this.Controls.SetChildIndex(this.SqlDatabaseConnector, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

            // Wire events
            this.SqlDatabaseConnector.ParametersChanged += new System.EventHandler(this.SqlDatabaseConnector_ParametersChanged);
        }

        internal ADSqlDatabaseConnector SqlDatabaseConnector;
    }
}

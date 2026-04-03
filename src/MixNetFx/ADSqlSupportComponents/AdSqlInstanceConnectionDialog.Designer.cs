namespace ActiveDev.Data.SqlClient
{
    partial class ADSqlInstanceConnectionDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtLoginString = new System.Windows.Forms.TextBox();
            this.SqlServerConnector = new ActiveDev.Data.SqlClient.AdSqlServerConnector();
            this.SuspendLayout();
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnOK.Location = new System.Drawing.Point(139, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnCancel.Location = new System.Drawing.Point(237, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // btnTestConnection
            //
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnTestConnection.Location = new System.Drawing.Point(12, 265);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(110, 30);
            this.btnTestConnection.TabIndex = 3;
            this.btnTestConnection.Text = "Verbindung testen";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            //
            // txtLoginString
            //
            this.txtLoginString.Location = new System.Drawing.Point(12, 213);
            this.txtLoginString.Multiline = true;
            this.txtLoginString.Name = "txtLoginString";
            this.txtLoginString.Size = new System.Drawing.Size(317, 45);
            this.txtLoginString.TabIndex = 6;
            this.txtLoginString.Text = "Server=";
            //
            // SqlServerConnector
            //
            this.SqlServerConnector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.SqlServerConnector.CredentialMethod = ActiveDev.Data.SqlClient.SqlCredentialMethods.WindowsIntegratedSecurity;
            this.SqlServerConnector.Location = new System.Drawing.Point(12, 12);
            this.SqlServerConnector.MaximumSize = new System.Drawing.Size(0, 195);
            this.SqlServerConnector.MinimumSize = new System.Drawing.Size(317, 195);
            this.SqlServerConnector.Name = "SqlServerConnector";
            this.SqlServerConnector.Size = new System.Drawing.Size(317, 195);
            this.SqlServerConnector.TabIndex = 0;
            //
            // ADSqlInstanceConnectionDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 307);
            this.Controls.Add(this.txtLoginString);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.SqlServerConnector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ADSqlInstanceConnectionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server-Login";
            this.ResumeLayout(false);
            this.PerformLayout();

            // Wire events
            this.SqlServerConnector.ParametersChanged += new System.EventHandler(this.SqlServerConnector_ParametersChanges);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
        }

        internal AdSqlServerConnector SqlServerConnector;
        protected internal System.Windows.Forms.Button btnOK;
        protected internal System.Windows.Forms.Button btnCancel;
        protected internal System.Windows.Forms.Button btnTestConnection;
        protected internal System.Windows.Forms.TextBox txtLoginString;
    }
}

namespace ActiveDev.Data.SqlClient
{
    partial class ADSqlDatabaseConnector
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
            this.gbDatabase = new System.Windows.Forms.GroupBox();
            this.lblLogicalName = new System.Windows.Forms.Label();
            this.txtLogicalDatabaseName = new System.Windows.Forms.TextBox();
            this.lblFileToAttach = new System.Windows.Forms.Label();
            this.btnFileSelector = new System.Windows.Forms.Button();
            this.txtFileToAttach = new System.Windows.Forms.TextBox();
            this.optAttachDatabase = new System.Windows.Forms.RadioButton();
            this.optUseDatabasesOfInstance = new System.Windows.Forms.RadioButton();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.SqlDatabases = new ActiveDev.Data.SqlClient.ADSqlDatabasesInfoComboBox();
            this.gbDatabase.SuspendLayout();
            this.SuspendLayout();
            //
            // gbDatabase
            //
            this.gbDatabase.Controls.Add(this.lblLogicalName);
            this.gbDatabase.Controls.Add(this.txtLogicalDatabaseName);
            this.gbDatabase.Controls.Add(this.lblFileToAttach);
            this.gbDatabase.Controls.Add(this.btnFileSelector);
            this.gbDatabase.Controls.Add(this.txtFileToAttach);
            this.gbDatabase.Controls.Add(this.optAttachDatabase);
            this.gbDatabase.Controls.Add(this.optUseDatabasesOfInstance);
            this.gbDatabase.Controls.Add(this.lblDatabase);
            this.gbDatabase.Controls.Add(this.SqlDatabases);
            this.gbDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDatabase.Location = new System.Drawing.Point(0, 0);
            this.gbDatabase.Name = "gbDatabase";
            this.gbDatabase.Size = new System.Drawing.Size(269, 162);
            this.gbDatabase.TabIndex = 0;
            this.gbDatabase.TabStop = false;
            this.gbDatabase.Text = "Auswahl der SQL-Datenbank:";
            //
            // lblLogicalName
            //
            this.lblLogicalName.AutoSize = true;
            this.lblLogicalName.Location = new System.Drawing.Point(6, 135);
            this.lblLogicalName.Name = "lblLogicalName";
            this.lblLogicalName.Size = new System.Drawing.Size(87, 13);
            this.lblLogicalName.TabIndex = 7;
            this.lblLogicalName.Text = "Logischer Name:";
            //
            // txtLogicalDatabaseName
            //
            this.txtLogicalDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.txtLogicalDatabaseName.Location = new System.Drawing.Point(96, 132);
            this.txtLogicalDatabaseName.Name = "txtLogicalDatabaseName";
            this.txtLogicalDatabaseName.Size = new System.Drawing.Size(163, 20);
            this.txtLogicalDatabaseName.TabIndex = 8;
            //
            // lblFileToAttach
            //
            this.lblFileToAttach.AutoSize = true;
            this.lblFileToAttach.Location = new System.Drawing.Point(58, 110);
            this.lblFileToAttach.Name = "lblFileToAttach";
            this.lblFileToAttach.Size = new System.Drawing.Size(35, 13);
            this.lblFileToAttach.TabIndex = 4;
            this.lblFileToAttach.Text = "Datei:";
            //
            // btnFileSelector
            //
            this.btnFileSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnFileSelector.Location = new System.Drawing.Point(234, 106);
            this.btnFileSelector.Name = "btnFileSelector";
            this.btnFileSelector.Size = new System.Drawing.Size(25, 20);
            this.btnFileSelector.TabIndex = 6;
            this.btnFileSelector.Text = "...";
            this.btnFileSelector.UseVisualStyleBackColor = true;
            //
            // txtFileToAttach
            //
            this.txtFileToAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.txtFileToAttach.Location = new System.Drawing.Point(96, 106);
            this.txtFileToAttach.Name = "txtFileToAttach";
            this.txtFileToAttach.Size = new System.Drawing.Size(137, 20);
            this.txtFileToAttach.TabIndex = 5;
            //
            // optAttachDatabase
            //
            this.optAttachDatabase.AutoSize = true;
            this.optAttachDatabase.Location = new System.Drawing.Point(6, 85);
            this.optAttachDatabase.Name = "optAttachDatabase";
            this.optAttachDatabase.Size = new System.Drawing.Size(155, 17);
            this.optAttachDatabase.TabIndex = 3;
            this.optAttachDatabase.Text = "Datenbankdatei anhängen:";
            this.optAttachDatabase.UseVisualStyleBackColor = true;
            //
            // optUseDatabasesOfInstance
            //
            this.optUseDatabasesOfInstance.AutoSize = true;
            this.optUseDatabasesOfInstance.Checked = true;
            this.optUseDatabasesOfInstance.Location = new System.Drawing.Point(6, 24);
            this.optUseDatabasesOfInstance.Name = "optUseDatabasesOfInstance";
            this.optUseDatabasesOfInstance.Size = new System.Drawing.Size(261, 17);
            this.optUseDatabasesOfInstance.TabIndex = 0;
            this.optUseDatabasesOfInstance.TabStop = true;
            this.optUseDatabasesOfInstance.Text = "In der Instanz vorhandene Datenbank verwenden";
            this.optUseDatabasesOfInstance.UseVisualStyleBackColor = true;
            //
            // lblDatabase
            //
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(30, 52);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(63, 13);
            this.lblDatabase.TabIndex = 1;
            this.lblDatabase.Text = "Datenbank:";
            //
            // SqlDatabases
            //
            this.SqlDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.SqlDatabases.CredentialMethod = ActiveDev.Data.SqlClient.SqlCredentialMethods.WindowsIntegratedSecurity;
            this.SqlDatabases.CredentialParameters = null;
            this.SqlDatabases.FormattingEnabled = true;
            this.SqlDatabases.Location = new System.Drawing.Point(96, 49);
            this.SqlDatabases.Name = "SqlDatabases";
            this.SqlDatabases.QueryInfoOnDropDown = true;
            this.SqlDatabases.Size = new System.Drawing.Size(163, 21);
            this.SqlDatabases.SqlInstance = null;
            this.SqlDatabases.TabIndex = 2;
            //
            // ADSqlDatabaseConnector
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDatabase);
            this.MaximumSize = new System.Drawing.Size(0, 162);
            this.MinimumSize = new System.Drawing.Size(269, 162);
            this.Name = "ADSqlDatabaseConnector";
            this.Size = new System.Drawing.Size(269, 162);
            this.gbDatabase.ResumeLayout(false);
            this.gbDatabase.PerformLayout();
            this.ResumeLayout(false);

            // Wire events
            this.optUseDatabasesOfInstance.CheckedChanged += new System.EventHandler(this.optUseDatabasesOfInstance_CheckedChanged);
            this.btnFileSelector.Click += new System.EventHandler(this.btnFileSelector_Click);
            this.txtLogicalDatabaseName.TextChanged += new System.EventHandler(this.SqlParameters_TextChanged);
            this.txtFileToAttach.TextChanged += new System.EventHandler(this.SqlParameters_TextChanged);
            this.SqlDatabases.TextChanged += new System.EventHandler(this.SqlParameters_TextChanged);
        }

        internal System.Windows.Forms.GroupBox gbDatabase;
        internal System.Windows.Forms.Label lblLogicalName;
        internal System.Windows.Forms.TextBox txtLogicalDatabaseName;
        internal System.Windows.Forms.Label lblFileToAttach;
        internal System.Windows.Forms.Button btnFileSelector;
        internal System.Windows.Forms.TextBox txtFileToAttach;
        internal System.Windows.Forms.RadioButton optAttachDatabase;
        internal System.Windows.Forms.RadioButton optUseDatabasesOfInstance;
        internal System.Windows.Forms.Label lblDatabase;
        internal ADSqlDatabasesInfoComboBox SqlDatabases;
    }
}

namespace ActiveDev.Data.SqlClient
{
    partial class AdSqlServerConnector
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
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.chkUseSXDefaultInstance = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.optUseMixedMode = new System.Windows.Forms.RadioButton();
            this.optUseIntegratedSecurity = new System.Windows.Forms.RadioButton();
            this.InstanceCombo = new ActiveDev.Data.SqlClient.ADSqlInstanceInfoComboBox();
            this.lblServerInstances = new System.Windows.Forms.Label();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            //
            // gbMain
            //
            this.gbMain.Controls.Add(this.chkUseSXDefaultInstance);
            this.gbMain.Controls.Add(this.txtPassword);
            this.gbMain.Controls.Add(this.lblPassword);
            this.gbMain.Controls.Add(this.txtUserID);
            this.gbMain.Controls.Add(this.lblUserID);
            this.gbMain.Controls.Add(this.optUseMixedMode);
            this.gbMain.Controls.Add(this.optUseIntegratedSecurity);
            this.gbMain.Controls.Add(this.InstanceCombo);
            this.gbMain.Controls.Add(this.lblServerInstances);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(317, 195);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Verbindung zur SQL Server-Instanz";
            //
            // chkUseSXDefaultInstance
            //
            this.chkUseSXDefaultInstance.AutoSize = true;
            this.chkUseSXDefaultInstance.Location = new System.Drawing.Point(13, 52);
            this.chkUseSXDefaultInstance.Name = "chkUseSXDefaultInstance";
            this.chkUseSXDefaultInstance.Size = new System.Drawing.Size(295, 17);
            this.chkUseSXDefaultInstance.TabIndex = 0;
            this.chkUseSXDefaultInstance.Text = "SQL Express Standardinstanz des Computers verwenden";
            this.chkUseSXDefaultInstance.UseVisualStyleBackColor = true;
            //
            // txtPassword
            //
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.txtPassword.Location = new System.Drawing.Point(146, 163);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = (char)42;
            this.txtPassword.Size = new System.Drawing.Size(165, 20);
            this.txtPassword.TabIndex = 8;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(87, 166);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Passwort:";
            //
            // txtUserID
            //
            this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.txtUserID.Location = new System.Drawing.Point(146, 138);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(165, 20);
            this.txtUserID.TabIndex = 6;
            this.txtUserID.Text = "sa";
            //
            // lblUserID
            //
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(62, 141);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(78, 13);
            this.lblUserID.TabIndex = 5;
            this.lblUserID.Text = "Benutzername:";
            //
            // optUseMixedMode
            //
            this.optUseMixedMode.AutoSize = true;
            this.optUseMixedMode.Location = new System.Drawing.Point(9, 113);
            this.optUseMixedMode.Name = "optUseMixedMode";
            this.optUseMixedMode.Size = new System.Drawing.Size(289, 17);
            this.optUseMixedMode.TabIndex = 4;
            this.optUseMixedMode.Text = "Mixed Mode - Folgende Kontoinformationen verwenden:";
            this.optUseMixedMode.UseVisualStyleBackColor = true;
            //
            // optUseIntegratedSecurity
            //
            this.optUseIntegratedSecurity.AutoSize = true;
            this.optUseIntegratedSecurity.Checked = true;
            this.optUseIntegratedSecurity.Location = new System.Drawing.Point(9, 88);
            this.optUseIntegratedSecurity.Name = "optUseIntegratedSecurity";
            this.optUseIntegratedSecurity.Size = new System.Drawing.Size(225, 17);
            this.optUseIntegratedSecurity.TabIndex = 3;
            this.optUseIntegratedSecurity.TabStop = true;
            this.optUseIntegratedSecurity.Text = "Integrierte Windows Sicherheit verwenden";
            this.optUseIntegratedSecurity.UseVisualStyleBackColor = true;
            //
            // InstanceCombo
            //
            this.InstanceCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.InstanceCombo.FormattingEnabled = true;
            this.InstanceCombo.Location = new System.Drawing.Point(126, 22);
            this.InstanceCombo.Name = "InstanceCombo";
            this.InstanceCombo.QueryInfoOnDropDown = true;
            this.InstanceCombo.Size = new System.Drawing.Size(185, 21);
            this.InstanceCombo.TabIndex = 2;
            //
            // lblServerInstances
            //
            this.lblServerInstances.AutoSize = true;
            this.lblServerInstances.Location = new System.Drawing.Point(6, 25);
            this.lblServerInstances.Name = "lblServerInstances";
            this.lblServerInstances.Size = new System.Drawing.Size(114, 13);
            this.lblServerInstances.TabIndex = 1;
            this.lblServerInstances.Text = "SQL Server-Instanzen:";
            //
            // AdSqlServerConnector
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMain);
            this.MaximumSize = new System.Drawing.Size(0, 195);
            this.MinimumSize = new System.Drawing.Size(317, 195);
            this.Name = "AdSqlServerConnector";
            this.Size = new System.Drawing.Size(317, 195);
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.ResumeLayout(false);

            // Wire events
            this.chkUseSXDefaultInstance.CheckedChanged += new System.EventHandler(this.chkUseSXDefaultInstance_CheckedChanged);
            this.optUseMixedMode.CheckedChanged += new System.EventHandler(this.optUseMixedMode_CheckedChanged);
            this.InstanceCombo.TextChanged += new System.EventHandler(this.InstanceCombo_TextChanged);
            this.txtUserID.TextChanged += new System.EventHandler(this.txtCredential_TextChanged);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtCredential_TextChanged);
        }

        internal System.Windows.Forms.GroupBox gbMain;
        internal System.Windows.Forms.RadioButton optUseMixedMode;
        internal System.Windows.Forms.RadioButton optUseIntegratedSecurity;
        internal ADSqlInstanceInfoComboBox InstanceCombo;
        internal System.Windows.Forms.Label lblServerInstances;
        internal System.Windows.Forms.CheckBox chkUseSXDefaultInstance;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.Label lblUserID;
    }
}

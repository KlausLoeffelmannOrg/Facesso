namespace ActiveDev.Data.SqlClient
{
    partial class ADAttachDatabaseDialog
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
            this.components = new System.ComponentModel.Container();
            this.btnOK = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnGetConnectionString = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.DBDirectoryPicker = new ActiveDev.Data.SqlClient.ADSQLDirectoryPicker();
            this.SuspendLayout();
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(219, 364);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 31);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            // Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(144, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Verbindung zum SQL-Server:";
            //
            // btnGetConnectionString
            //
            this.btnGetConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnGetConnectionString.Location = new System.Drawing.Point(409, 25);
            this.btnGetConnectionString.Name = "btnGetConnectionString";
            this.btnGetConnectionString.Size = new System.Drawing.Size(26, 22);
            this.btnGetConnectionString.TabIndex = 3;
            this.btnGetConnectionString.Text = "...";
            this.btnGetConnectionString.UseVisualStyleBackColor = true;
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnCancel.Location = new System.Drawing.Point(330, 364);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // txtConnectionString
            //
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.txtConnectionString.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                global::ActiveDev.Data.SqlClient.My.MySettings.Default,
                "AttachDatabaseDialogConnectionString", true,
                System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtConnectionString.Location = new System.Drawing.Point(12, 27);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(391, 43);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.Text = global::ActiveDev.Data.SqlClient.My.MySettings.Default.AttachDatabaseDialogConnectionString;
            //
            // DBDirectoryPicker
            //
            this.DBDirectoryPicker.ConnectionString = null;
            this.DBDirectoryPicker.ExtensionFilter = ".mdf";
            this.DBDirectoryPicker.ImageIndex = 0;
            this.DBDirectoryPicker.Location = new System.Drawing.Point(12, 76);
            this.DBDirectoryPicker.Name = "DBDirectoryPicker";
            this.DBDirectoryPicker.SelectedImageIndex = 0;
            this.DBDirectoryPicker.Size = new System.Drawing.Size(423, 282);
            this.DBDirectoryPicker.TabIndex = 5;
            //
            // ADAttachDatabaseDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 407);
            this.Controls.Add(this.DBDirectoryPicker);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGetConnectionString);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.btnOK);
            this.Name = "ADAttachDatabaseDialog";
            this.Text = "Datenbankdatei an SQL-Server anhängen";
            this.ResumeLayout(false);
            this.PerformLayout();

            // Wire events
            this.btnGetConnectionString.Click += new System.EventHandler(this.btnGetConnectionString_Click);
            this.Load += new System.EventHandler(this.ADAttachDatabaseDialog_Load);
            this.DBDirectoryPicker.SelectedFileNodeChanged += new System.EventHandler<ADFileTreeViewEventArgs>(this.DBDirectoryPicker_SelectedFileNodeChanged);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        }

        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.TextBox txtConnectionString;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnGetConnectionString;
        internal System.Windows.Forms.Button btnCancel;
        internal ADSQLDirectoryPicker DBDirectoryPicker;
    }
}

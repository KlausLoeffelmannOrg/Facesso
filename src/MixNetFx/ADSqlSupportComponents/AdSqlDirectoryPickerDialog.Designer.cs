namespace ActiveDev.Data.SqlClient
{
    partial class ADSqlDirectoryPickerDialog
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
            this.DirectoryPicker = new ActiveDev.Data.SqlClient.ADSQLDirectoryPicker();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // DirectoryPicker
            //
            this.DirectoryPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.DirectoryPicker.ConnectionString = null;
            this.DirectoryPicker.ExtensionFilter = ".mdf";
            this.DirectoryPicker.ImageIndex = 0;
            this.DirectoryPicker.Location = new System.Drawing.Point(12, 12);
            this.DirectoryPicker.Name = "DirectoryPicker";
            this.DirectoryPicker.SelectedImageIndex = 0;
            this.DirectoryPicker.Size = new System.Drawing.Size(452, 310);
            this.DirectoryPicker.TabIndex = 0;
            //
            // txtPath
            //
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.txtPath.Location = new System.Drawing.Point(12, 328);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(452, 20);
            this.txtPath.TabIndex = 1;
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(254, 354);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(362, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // ADSqlDirectoryPickerDialog
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(476, 390);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.DirectoryPicker);
            this.Name = "ADSqlDirectoryPickerDialog";
            this.Text = "Verzeichnis/Datei auf SQL-Server auswählen";
            this.ResumeLayout(false);
            this.PerformLayout();

            // Wire events
            this.DirectoryPicker.SelectedFileNodeChanged += new System.EventHandler<ADFileTreeViewEventArgs>(this.DirectoryPicker_SelectedFileNodeChanged);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }

        internal ADSQLDirectoryPicker DirectoryPicker;
        internal System.Windows.Forms.TextBox txtPath;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
    }
}

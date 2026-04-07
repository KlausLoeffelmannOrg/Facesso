namespace Facesso
{
    partial class ucFacessoPathSettings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.btnChooseSharedFolder = new System.Windows.Forms.Button();
            this.txtSharedFolder = new System.Windows.Forms.TextBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.txtUpdateUrl = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.btnChooseUpdateDirectory = new System.Windows.Forms.Button();
            this.txtUpdateDirectory = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtInstallationDirectory = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.btnChooseSharedFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnChooseSharedFolder.Location = new System.Drawing.Point(440, 97);
            this.btnChooseSharedFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnChooseSharedFolder.Name = "btnChooseSharedFolder";
            this.btnChooseSharedFolder.Size = new System.Drawing.Size(25, 22);
            this.btnChooseSharedFolder.TabIndex = 19;
            this.btnChooseSharedFolder.Text = "...";
            this.btnChooseSharedFolder.UseVisualStyleBackColor = true;
            this.btnChooseSharedFolder.Click += new System.EventHandler(this.btnChooseSharedFolder_Click);

            this.txtSharedFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtSharedFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtSharedFolder.Location = new System.Drawing.Point(158, 97);
            this.txtSharedFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtSharedFolder.Name = "txtSharedFolder";
            this.txtSharedFolder.ReadOnly = true;
            this.txtSharedFolder.Size = new System.Drawing.Size(274, 22);
            this.txtSharedFolder.TabIndex = 18;

            this.Label18.AutoSize = true;
            this.Label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label18.Location = new System.Drawing.Point(42, 100);
            this.Label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(108, 16);
            this.Label18.TabIndex = 17;
            this.Label18.Text = "Verteilter Ordner:";

            this.txtUpdateUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtUpdateUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtUpdateUrl.Location = new System.Drawing.Point(158, 67);
            this.txtUpdateUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUpdateUrl.Name = "txtUpdateUrl";
            this.txtUpdateUrl.Size = new System.Drawing.Size(274, 22);
            this.txtUpdateUrl.TabIndex = 16;

            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label15.Location = new System.Drawing.Point(63, 70);
            this.Label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(87, 16);
            this.Label15.TabIndex = 15;
            this.Label15.Text = "Update-URL:";

            this.btnChooseUpdateDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnChooseUpdateDirectory.Location = new System.Drawing.Point(440, 37);
            this.btnChooseUpdateDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.btnChooseUpdateDirectory.Name = "btnChooseUpdateDirectory";
            this.btnChooseUpdateDirectory.Size = new System.Drawing.Size(25, 25);
            this.btnChooseUpdateDirectory.TabIndex = 14;
            this.btnChooseUpdateDirectory.Text = "...";
            this.btnChooseUpdateDirectory.UseVisualStyleBackColor = true;
            this.btnChooseUpdateDirectory.Click += new System.EventHandler(this.btnChooseUpdateDirectory_Click);

            this.txtUpdateDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtUpdateDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtUpdateDirectory.Location = new System.Drawing.Point(158, 37);
            this.txtUpdateDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.txtUpdateDirectory.Name = "txtUpdateDirectory";
            this.txtUpdateDirectory.ReadOnly = true;
            this.txtUpdateDirectory.Size = new System.Drawing.Size(274, 22);
            this.txtUpdateDirectory.TabIndex = 13;

            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label8.Location = new System.Drawing.Point(21, 40);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(129, 16);
            this.Label8.TabIndex = 12;
            this.Label8.Text = "Update-Verzeichnis:";

            this.txtInstallationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtInstallationDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtInstallationDirectory.Location = new System.Drawing.Point(158, 7);
            this.txtInstallationDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.txtInstallationDirectory.Name = "txtInstallationDirectory";
            this.txtInstallationDirectory.ReadOnly = true;
            this.txtInstallationDirectory.Size = new System.Drawing.Size(274, 22);
            this.txtInstallationDirectory.TabIndex = 11;

            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label4.Location = new System.Drawing.Point(4, 10);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(148, 16);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Installationsverzeichnis:";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChooseSharedFolder);
            this.Controls.Add(this.txtSharedFolder);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.txtUpdateUrl);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.btnChooseUpdateDirectory);
            this.Controls.Add(this.txtUpdateDirectory);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtInstallationDirectory);
            this.Controls.Add(this.Label4);
            this.Name = "ucFacessoPathSettings";
            this.Size = new System.Drawing.Size(469, 130);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Button btnChooseSharedFolder;
        internal System.Windows.Forms.TextBox txtSharedFolder;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.TextBox txtUpdateUrl;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Button btnChooseUpdateDirectory;
        internal System.Windows.Forms.TextBox txtUpdateDirectory;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtInstallationDirectory;
        internal System.Windows.Forms.Label Label4;
    }
}

namespace Facesso
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbUsernames = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSubsidiary = new System.Windows.Forms.Label();
            this.cmbSubsidiary = new System.Windows.Forms.ComboBox();
            this.myErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();

            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(74, 21);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(97, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "&Benutzername:";

            this.cmbUsernames.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsernames.FormattingEnabled = true;
            this.cmbUsernames.Location = new System.Drawing.Point(175, 18);
            this.cmbUsernames.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUsernames.Name = "cmbUsernames";
            this.cmbUsernames.Size = new System.Drawing.Size(195, 24);
            this.cmbUsernames.TabIndex = 1;

            this.btnOK.Location = new System.Drawing.Point(413, 13);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 33);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(106, 61);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 16);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "&Kennwort:";

            this.txtPassword.Location = new System.Drawing.Point(175, 58);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = (char)42;
            this.txtPassword.Size = new System.Drawing.Size(193, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);

            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(413, 56);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 33);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.lblSubsidiary.AutoSize = true;
            this.lblSubsidiary.Location = new System.Drawing.Point(97, 99);
            this.lblSubsidiary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubsidiary.Name = "lblSubsidiary";
            this.lblSubsidiary.Size = new System.Drawing.Size(74, 16);
            this.lblSubsidiary.TabIndex = 4;
            this.lblSubsidiary.Text = "&Subsidiarit:";

            this.cmbSubsidiary.FormattingEnabled = true;
            this.cmbSubsidiary.Location = new System.Drawing.Point(175, 96);
            this.cmbSubsidiary.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSubsidiary.Name = "cmbSubsidiary";
            this.cmbSubsidiary.Size = new System.Drawing.Size(194, 24);
            this.cmbSubsidiary.TabIndex = 5;

            this.myErrorProvider.ContainerControl = this;

            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(9, 51);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(50, 46);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 8;
            this.PictureBox1.TabStop = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(528, 151);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.cmbSubsidiary);
            this.Controls.Add(this.lblSubsidiary);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbUsernames);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facesso - Benutzeranmeldung";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbUsernames;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label lblSubsidiary;
        internal System.Windows.Forms.ComboBox cmbSubsidiary;
        internal System.Windows.Forms.ErrorProvider myErrorProvider;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}

namespace ActiveDev
{
    partial class frmMain
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
            this.mtbPreSerial = new System.Windows.Forms.MaskedTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbProgramID = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.mtbLimit1 = new System.Windows.Forms.MaskedTextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.mtbLimit2 = new System.Windows.Forms.MaskedTextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.mtbBestBefore = new System.Windows.Forms.MaskedTextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.mtbLimit3 = new System.Windows.Forms.MaskedTextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.mtbLimit4 = new System.Windows.Forms.MaskedTextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.btnQuitProgram = new System.Windows.Forms.Button();
            this.btnCalcSerial = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.mtbPreSerial.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbPreSerial.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.mtbPreSerial.HideSelection = false;
            this.mtbPreSerial.Location = new System.Drawing.Point(12, 45);
            this.mtbPreSerial.Margin = new System.Windows.Forms.Padding(4);
            this.mtbPreSerial.Mask = ">AAAAA - AAAAA - AAAAA";
            this.mtbPreSerial.Name = "mtbPreSerial";
            this.mtbPreSerial.Size = new System.Drawing.Size(263, 26);
            this.mtbPreSerial.TabIndex = 1;
            this.mtbPreSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbPreSerial.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;

            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 25);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(117, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Vorseriennummer:";

            this.cmbProgramID.FormattingEnabled = true;
            this.cmbProgramID.Location = new System.Drawing.Point(12, 109);
            this.cmbProgramID.Name = "cmbProgramID";
            this.cmbProgramID.Size = new System.Drawing.Size(220, 24);
            this.cmbProgramID.TabIndex = 3;

            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(13, 90);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(91, 16);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Programm-ID:";

            this.mtbLimit1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbLimit1.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.mtbLimit1.HideSelection = false;
            this.mtbLimit1.Location = new System.Drawing.Point(248, 110);
            this.mtbLimit1.Margin = new System.Windows.Forms.Padding(4);
            this.mtbLimit1.Mask = "000";
            this.mtbLimit1.Name = "mtbLimit1";
            this.mtbLimit1.Size = new System.Drawing.Size(185, 26);
            this.mtbLimit1.TabIndex = 5;
            this.mtbLimit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbLimit1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;

            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(246, 90);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(92, 16);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Limit1 (Users):";

            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(13, 149);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(139, 16);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Limit2 (Internet-Users):";

            this.mtbLimit2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbLimit2.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.mtbLimit2.HideSelection = false;
            this.mtbLimit2.Location = new System.Drawing.Point(15, 169);
            this.mtbLimit2.Margin = new System.Windows.Forms.Padding(4);
            this.mtbLimit2.Mask = "000";
            this.mtbLimit2.Name = "mtbLimit2";
            this.mtbLimit2.Size = new System.Drawing.Size(217, 26);
            this.mtbLimit2.TabIndex = 7;
            this.mtbLimit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbLimit2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;

            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(246, 209);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(118, 16);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Gültig für (Monate):";

            this.mtbBestBefore.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbBestBefore.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.mtbBestBefore.HideSelection = false;
            this.mtbBestBefore.Location = new System.Drawing.Point(248, 229);
            this.mtbBestBefore.Margin = new System.Windows.Forms.Padding(4);
            this.mtbBestBefore.Mask = "000";
            this.mtbBestBefore.Name = "mtbBestBefore";
            this.mtbBestBefore.Size = new System.Drawing.Size(185, 26);
            this.mtbBestBefore.TabIndex = 13;
            this.mtbBestBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbBestBefore.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;

            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(246, 150);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(119, 16);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Limit3 (Mitarbeiter):";

            this.mtbLimit3.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbLimit3.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.mtbLimit3.HideSelection = false;
            this.mtbLimit3.Location = new System.Drawing.Point(248, 170);
            this.mtbLimit3.Margin = new System.Windows.Forms.Padding(4);
            this.mtbLimit3.Mask = "00000";
            this.mtbLimit3.Name = "mtbLimit3";
            this.mtbLimit3.Size = new System.Drawing.Size(185, 26);
            this.mtbLimit3.TabIndex = 9;
            this.mtbLimit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbLimit3.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;

            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(13, 208);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(101, 16);
            this.Label7.TabIndex = 10;
            this.Label7.Text = "Limit4 (Custom):";

            this.mtbLimit4.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbLimit4.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.mtbLimit4.HideSelection = false;
            this.mtbLimit4.Location = new System.Drawing.Point(15, 228);
            this.mtbLimit4.Margin = new System.Windows.Forms.Padding(4);
            this.mtbLimit4.Mask = "00000";
            this.mtbLimit4.Name = "mtbLimit4";
            this.mtbLimit4.Size = new System.Drawing.Size(217, 26);
            this.mtbLimit4.TabIndex = 11;
            this.mtbLimit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbLimit4.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;

            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label8.Location = new System.Drawing.Point(13, 295);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(113, 16);
            this.Label8.TabIndex = 14;
            this.Label8.Text = "Seriennummer:";

            this.txtSerialNumber.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtSerialNumber.Location = new System.Drawing.Point(13, 314);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(572, 26);
            this.txtSerialNumber.TabIndex = 15;
            this.txtSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.btnQuitProgram.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuitProgram.Location = new System.Drawing.Point(501, 39);
            this.btnQuitProgram.Name = "btnQuitProgram";
            this.btnQuitProgram.Size = new System.Drawing.Size(140, 32);
            this.btnQuitProgram.TabIndex = 17;
            this.btnQuitProgram.Text = "Programm beenden";
            this.btnQuitProgram.Click += new System.EventHandler(this.btnQuitProgram_Click);

            this.btnCalcSerial.Location = new System.Drawing.Point(282, 42);
            this.btnCalcSerial.Name = "btnCalcSerial";
            this.btnCalcSerial.Size = new System.Drawing.Size(151, 29);
            this.btnCalcSerial.TabIndex = 16;
            this.btnCalcSerial.Text = "Calc Serial";
            this.btnCalcSerial.Click += new System.EventHandler(this.btnCalcSerial_Click);

            this.AcceptButton = this.btnCalcSerial;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuitProgram;
            this.ClientSize = new System.Drawing.Size(653, 373);
            this.Controls.Add(this.btnCalcSerial);
            this.Controls.Add(this.btnQuitProgram);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.mtbLimit4);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.mtbLimit3);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.mtbBestBefore);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.mtbLimit2);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.mtbLimit1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbProgramID);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.mtbPreSerial);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AD-Serial";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.MaskedTextBox mtbPreSerial;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbProgramID;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.MaskedTextBox mtbLimit1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.MaskedTextBox mtbLimit2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.MaskedTextBox mtbBestBefore;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.MaskedTextBox mtbLimit3;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.MaskedTextBox mtbLimit4;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtSerialNumber;
        internal System.Windows.Forms.Button btnQuitProgram;
        internal System.Windows.Forms.Button btnCalcSerial;
    }
}

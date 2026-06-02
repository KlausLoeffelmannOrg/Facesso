using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class frmJensenProdDataConfigDialog : Facesso.Interfaces.frmProductionDataConfigureDialogBase
    {
        //Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        //Wird vom Windows Form-Designer benötigt.
        private System.ComponentModel.IContainer components;
        //Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        //Das Bearbeiten ist mit dem Windows Form-Designer möglich.
        //Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.btnChoosePath = new System.Windows.Forms.Button();
            this.btnChoosePath.Click += btnChoosePath_Click;
            this.Label1 = new System.Windows.Forms.Label();
            this.txtSqlConnectionString = new System.Windows.Forms.TextBox();
            this.lblDevice = new System.Windows.Forms.Label();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.cmbDevice.SelectedIndexChanged += cmbJensenDevice_SelectedIndexChanged;
            this.SuspendLayout();
            //
            //lblTitel
            //
            this.lblTitel.Size = new System.Drawing.Size(774, 46);
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(572, 537);
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(674, 537);
            //
            //lvwDeviceItems
            //
            this.lvwDeviceItems.Size = new System.Drawing.Size(321, 394);
            //
            //ucLabourValues
            //
            this.ucLabourValues.Size = new System.Drawing.Size(321, 394);
            //
            //btnChoosePath
            //
            this.btnChoosePath.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnChoosePath.Location = new System.Drawing.Point(507, 490);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(30, 20);
            this.btnChoosePath.TabIndex = 16;
            this.btnChoosePath.Text = "...";
            this.btnChoosePath.UseVisualStyleBackColor = true;
            //
            //Label1
            //
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 493);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(211, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Maschinendaten Verbindungszeichenfolge:";
            //
            //txtSqlConnectionString
            //
            this.txtSqlConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.txtSqlConnectionString.Location = new System.Drawing.Point(228, 490);
            this.txtSqlConnectionString.Multiline = true;
            this.txtSqlConnectionString.Name = "txtSqlConnectionString";
            this.txtSqlConnectionString.ReadOnly = true;
            this.txtSqlConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSqlConnectionString.Size = new System.Drawing.Size(273, 54);
            this.txtSqlConnectionString.TabIndex = 15;
            //
            //lblDevice
            //
            this.lblDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.lblDevice.AutoSize = true;
            this.lblDevice.Enabled = false;
            this.lblDevice.Location = new System.Drawing.Point(166, 554);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(56, 13);
            this.lblDevice.TabIndex = 17;
            this.lblDevice.Text = "Maschine:";
            //
            //cmbDevice
            //
            this.cmbDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice.Enabled = false;
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Items.AddRange(new object[] { "- Nicht festgelegt -", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            this.cmbDevice.Location = new System.Drawing.Point(228, 550);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(273, 21);
            this.cmbDevice.TabIndex = 18;
            //
            //frmJensenProdDataConfigDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.ClientSize = new System.Drawing.Size(784, 576);
            this.Controls.Add(this.cmbDevice);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.btnChoosePath);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtSqlConnectionString);
            this.Name = "frmJensenProdDataConfigDialog";
            this.Controls.SetChildIndex(this.lblTitel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtSqlConnectionString, 0);
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.btnChoosePath, 0);
            this.Controls.SetChildIndex(this.lblDevice, 0);
            this.Controls.SetChildIndex(this.cmbDevice, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Button btnChoosePath;

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtSqlConnectionString;
        internal System.Windows.Forms.Label lblDevice;
        internal System.Windows.Forms.ComboBox cmbDevice;
    }
}
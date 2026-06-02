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
    public partial class frmKannegiesserProdDataConfigDialog : Facesso.Interfaces.frmProductionDataConfigureDialogBase
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
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPathToDeviceData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            //lblTitel
            //
            this.lblTitel.Size = new System.Drawing.Size(716, 46);
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(528, 475);
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(630, 475);
            //
            //btnChoosePath
            //
            this.btnChoosePath.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnChoosePath.Location = new System.Drawing.Point(454, 475);
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
            this.Label1.Location = new System.Drawing.Point(11, 478);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(128, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Pfad zu Maschinendaten:";
            //
            //txtPathToDeviceData
            //
            this.txtPathToDeviceData.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.txtPathToDeviceData.Location = new System.Drawing.Point(145, 475);
            this.txtPathToDeviceData.Name = "txtPathToDeviceData";
            this.txtPathToDeviceData.ReadOnly = true;
            this.txtPathToDeviceData.Size = new System.Drawing.Size(303, 20);
            this.txtPathToDeviceData.TabIndex = 15;
            //
            //frmKannegiesserProdDataConfigDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.ClientSize = new System.Drawing.Size(726, 529);
            this.Controls.Add(this.btnChoosePath);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtPathToDeviceData);
            this.Name = "frmKannegiesserProdDataConfigDialog";
            this.Controls.SetChildIndex(this.lblTitel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtPathToDeviceData, 0);
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.btnChoosePath, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button _btnChoosePath;
        internal System.Windows.Forms.Button btnChoosePath
        {
            get
            {
                return _btnChoosePath;
            }

            set
            {
                if (_btnChoosePath != null)
                {
                    _btnChoosePath.Click -= btnChoosePath_Click;
                }

                _btnChoosePath = value;
                if (_btnChoosePath != null)
                {
                    _btnChoosePath.Click += btnChoosePath_Click;
                }
            }
        }

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtPathToDeviceData;
    }
}
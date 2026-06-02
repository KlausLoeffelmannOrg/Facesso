using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class frmWorkGroupAnalysisManager : frmBaseFacesso
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lstAnalysis = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNewAnalysis = new System.Windows.Forms.Button();
            this.btnUseAnalysis = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtAnalysisName = new System.Windows.Forms.TextBox();
            this.txtAnalysisMenuName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbMenuIndex = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnEditAnalysis = new System.Windows.Forms.Button();
            this.btnDeleteAnalysis = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.lstAnalysis);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(397, 194);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Analysen:";
            //
            //lstAnalysis
            //
            this.lstAnalysis.FormattingEnabled = true;
            this.lstAnalysis.Location = new System.Drawing.Point(6, 21);
            this.lstAnalysis.Name = "lstAnalysis";
            this.lstAnalysis.Size = new System.Drawing.Size(385, 160);
            this.lstAnalysis.TabIndex = 0;
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(447, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(127, 35);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //btnNewAnalysis
            //
            this.btnNewAnalysis.Location = new System.Drawing.Point(447, 94);
            this.btnNewAnalysis.Name = "btnNewAnalysis";
            this.btnNewAnalysis.Size = new System.Drawing.Size(127, 35);
            this.btnNewAnalysis.TabIndex = 9;
            this.btnNewAnalysis.Text = "Neue Analyse...";
            this.btnNewAnalysis.UseVisualStyleBackColor = true;
            //
            //btnUseAnalysis
            //
            this.btnUseAnalysis.Location = new System.Drawing.Point(447, 217);
            this.btnUseAnalysis.Name = "btnUseAnalysis";
            this.btnUseAnalysis.Size = new System.Drawing.Size(127, 35);
            this.btnUseAnalysis.TabIndex = 12;
            this.btnUseAnalysis.Text = "Analyse anwenden...";
            this.btnUseAnalysis.UseVisualStyleBackColor = true;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 219);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Analyse-Name:";
            //
            //txtAnalysisName
            //
            this.txtAnalysisName.Location = new System.Drawing.Point(104, 216);
            this.txtAnalysisName.Name = "txtAnalysisName";
            this.txtAnalysisName.Size = new System.Drawing.Size(305, 20);
            this.txtAnalysisName.TabIndex = 2;
            //
            //txtAnalysisMenuName
            //
            this.txtAnalysisMenuName.Location = new System.Drawing.Point(104, 242);
            this.txtAnalysisMenuName.Name = "txtAnalysisMenuName";
            this.txtAnalysisMenuName.Size = new System.Drawing.Size(305, 20);
            this.txtAnalysisMenuName.TabIndex = 4;
            this.txtAnalysisMenuName.Visible = false;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 245);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(68, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Menu-Name:";
            this.Label2.Visible = false;
            //
            //cmbMenuIndex
            //
            this.cmbMenuIndex.FormattingEnabled = true;
            this.cmbMenuIndex.Location = new System.Drawing.Point(104, 269);
            this.cmbMenuIndex.Name = "cmbMenuIndex";
            this.cmbMenuIndex.Size = new System.Drawing.Size(305, 21);
            this.cmbMenuIndex.TabIndex = 6;
            this.cmbMenuIndex.Visible = false;
            //
            //Label3
            //
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 272);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 13);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Menu-Index:";
            this.Label3.Visible = false;
            //
            //btnEditAnalysis
            //
            this.btnEditAnalysis.Location = new System.Drawing.Point(447, 135);
            this.btnEditAnalysis.Name = "btnEditAnalysis";
            this.btnEditAnalysis.Size = new System.Drawing.Size(127, 35);
            this.btnEditAnalysis.TabIndex = 10;
            this.btnEditAnalysis.Text = "Analyse bearbeiten...";
            this.btnEditAnalysis.UseVisualStyleBackColor = true;
            //
            //btnDeleteAnalysis
            //
            this.btnDeleteAnalysis.Location = new System.Drawing.Point(447, 176);
            this.btnDeleteAnalysis.Name = "btnDeleteAnalysis";
            this.btnDeleteAnalysis.Size = new System.Drawing.Size(127, 35);
            this.btnDeleteAnalysis.TabIndex = 11;
            this.btnDeleteAnalysis.Text = "Analyse l�schen...";
            this.btnDeleteAnalysis.UseVisualStyleBackColor = true;
            //
            //btnApply
            //
            this.btnApply.Location = new System.Drawing.Point(447, 53);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(127, 35);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "�bernehmen";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            //
            //frmWorkGroupAnalysisManager
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 302);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnDeleteAnalysis);
            this.Controls.Add(this.btnEditAnalysis);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cmbMenuIndex);
            this.Controls.Add(this.txtAnalysisMenuName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtAnalysisName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnUseAnalysis);
            this.Controls.Add(this.btnNewAnalysis);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmWorkGroupAnalysisManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager f�r Produktiv-Site-Analysen";
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button _btnOK;
        internal System.Windows.Forms.Button btnOK
        {
            get
            {
                return _btnOK;
            }

            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnNewAnalysis;
        internal System.Windows.Forms.Button btnNewAnalysis
        {
            get
            {
                return _btnNewAnalysis;
            }

            set
            {
                if (_btnNewAnalysis != null)
                {
                    _btnNewAnalysis.Click -= btnNewAnalysis_Click;
                }

                _btnNewAnalysis = value;
                if (_btnNewAnalysis != null)
                {
                    _btnNewAnalysis.Click += btnNewAnalysis_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnUseAnalysis;
        internal System.Windows.Forms.Button btnUseAnalysis
        {
            get
            {
                return _btnUseAnalysis;
            }

            set
            {
                if (_btnUseAnalysis != null)
                {
                    _btnUseAnalysis.Click -= btnUseAnalysis_Click;
                }

                _btnUseAnalysis = value;
                if (_btnUseAnalysis != null)
                {
                    _btnUseAnalysis.Click += btnUseAnalysis_Click;
                }
            }
        }

        private System.Windows.Forms.ListBox _lstAnalysis;
        internal System.Windows.Forms.ListBox lstAnalysis
        {
            get
            {
                return _lstAnalysis;
            }

            set
            {
                if (_lstAnalysis != null)
                {
                    _lstAnalysis.SelectedIndexChanged -= lstAnalysis_SelectedIndexChanged;
                }

                _lstAnalysis = value;
                if (_lstAnalysis != null)
                {
                    _lstAnalysis.SelectedIndexChanged += lstAnalysis_SelectedIndexChanged;
                }
            }
        }

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtAnalysisName;
        internal System.Windows.Forms.TextBox txtAnalysisMenuName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbMenuIndex;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button _btnEditAnalysis;
        internal System.Windows.Forms.Button btnEditAnalysis
        {
            get
            {
                return _btnEditAnalysis;
            }

            set
            {
                if (_btnEditAnalysis != null)
                {
                    _btnEditAnalysis.Click -= btnEditAnalysis_Click;
                }

                _btnEditAnalysis = value;
                if (_btnEditAnalysis != null)
                {
                    _btnEditAnalysis.Click += btnEditAnalysis_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnDeleteAnalysis;
        internal System.Windows.Forms.Button btnDeleteAnalysis
        {
            get
            {
                return _btnDeleteAnalysis;
            }

            set
            {
                if (_btnDeleteAnalysis != null)
                {
                    _btnDeleteAnalysis.Click -= btnDeleteAnalysis_Click;
                }

                _btnDeleteAnalysis = value;
                if (_btnDeleteAnalysis != null)
                {
                    _btnDeleteAnalysis.Click += btnDeleteAnalysis_Click;
                }
            }
        }

        internal System.Windows.Forms.Button btnApply;
    }
}
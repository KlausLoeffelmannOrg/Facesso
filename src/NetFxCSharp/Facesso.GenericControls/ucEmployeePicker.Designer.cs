using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.GenericControls
{
    public partial class ucEmployeePicker : System.Windows.Forms.UserControl
    {
        //UserControl overrides dispose to clean up the component list.
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.chkOnlyIncentiveEmployees = new System.Windows.Forms.CheckBox();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.elvMain = new Facesso.GenericControls.ucEmployeeListView();
            this.Panel1.SuspendLayout();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            //
            //Panel1
            //
            this.Panel1.Controls.Add(this.btnCancel);
            this.Panel1.Controls.Add(this.btnOK);
            this.Panel1.Controls.Add(this.txtSearchText);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.chkOnlyIncentiveEmployees);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(487, 62);
            this.Panel1.TabIndex = 1;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(73, 36);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Abbrechen";
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(17, 36);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(50, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            //
            //txtSearchText
            //
            this.txtSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.txtSearchText.Location = new System.Drawing.Point(150, 2);
            this.txtSearchText.Multiline = true;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(335, 60);
            this.txtSearchText.TabIndex = 1;
            //
            //Label1
            //
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label1.Location = new System.Drawing.Point(4, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(147, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Beliebige &Suchbegriffe:";
            //
            //chkOnlyIncentiveEmployees
            //
            this.chkOnlyIncentiveEmployees.AutoSize = true;
            this.chkOnlyIncentiveEmployees.Checked = true;
            this.chkOnlyIncentiveEmployees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyIncentiveEmployees.Location = new System.Drawing.Point(17, 18);
            this.chkOnlyIncentiveEmployees.Name = "chkOnlyIncentiveEmployees";
            this.chkOnlyIncentiveEmployees.Size = new System.Drawing.Size(130, 17);
            this.chkOnlyIncentiveEmployees.TabIndex = 4;
            this.chkOnlyIncentiveEmployees.Text = "nur Prämienmitarbeiter";
            //
            //SplitContainer1
            //
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            //SplitContainer1.Panel1
            //
            this.SplitContainer1.Panel1.Controls.Add(this.Panel1);
            this.SplitContainer1.Panel1MinSize = 50;
            //
            //SplitContainer1.Panel2
            //
            this.SplitContainer1.Panel2.Controls.Add(this.elvMain);
            this.SplitContainer1.Size = new System.Drawing.Size(487, 315);
            this.SplitContainer1.SplitterDistance = 62;
            this.SplitContainer1.TabIndex = 2;
            this.SplitContainer1.Text = "SplitContainer1";
            //
            //elvMain
            //
            this.elvMain.AutoGroup = true;
            this.elvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elvMain.EmployeeInfoCollection = null;
            this.elvMain.EmployeeSortOrder = Facesso.GenericControls.EmployeeSortOrder.PersonnelNumber;
            this.elvMain.FullRowSelect = true;
            this.elvMain.HideSelection = false;
            this.elvMain.Location = new System.Drawing.Point(0, 0);
            this.elvMain.Name = "elvMain";
            this.elvMain.OnlyActiveEmployees = false;
            this.elvMain.Size = new System.Drawing.Size(487, 249);
            this.elvMain.TabIndex = 0;
            this.elvMain.View = System.Windows.Forms.View.Details;
            //
            //ucEmployeePicker
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainer1);
            this.Name = "ucEmployeePicker";
            this.Size = new System.Drawing.Size(487, 315);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.TextBox _txtSearchText;
        internal System.Windows.Forms.TextBox txtSearchText
        {
            get
            {
                return _txtSearchText;
            }

            set
            {
                if (_txtSearchText != null)
                {
                    _txtSearchText.TextChanged -= txtSearchText_TextChanged;
                }

                _txtSearchText = value;
                if (_txtSearchText != null)
                {
                    _txtSearchText.TextChanged += txtSearchText_TextChanged;
                }
            }
        }

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        private System.Windows.Forms.CheckBox _chkOnlyIncentiveEmployees;
        internal System.Windows.Forms.CheckBox chkOnlyIncentiveEmployees
        {
            get
            {
                return _chkOnlyIncentiveEmployees;
            }

            set
            {
                if (_chkOnlyIncentiveEmployees != null)
                {
                    _chkOnlyIncentiveEmployees.CheckedChanged -= chkOnlyIncentiveEmployees_CheckedChanged;
                }

                _chkOnlyIncentiveEmployees = value;
                if (_chkOnlyIncentiveEmployees != null)
                {
                    _chkOnlyIncentiveEmployees.CheckedChanged += chkOnlyIncentiveEmployees_CheckedChanged;
                }
            }
        }

        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        internal Facesso.GenericControls.ucEmployeeListView elvMain;
    }
}
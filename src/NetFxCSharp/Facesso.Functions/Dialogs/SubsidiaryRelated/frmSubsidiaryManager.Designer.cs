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
    internal partial class frmSubsidiaryManager : frmBaseFacesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubsidiaryManager));
            this.tcSubsidiaries = new System.Windows.Forms.TabControl();
            this.tpSubsidiaries = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelete.Click += btnDelete_Click;
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnEdit.Click += btnEdit_Click;
            this.btnNew = new System.Windows.Forms.Button();
            this.btnNew.Click += btnNew_Click;
            this.arvSubsidiaries = new ActiveDev.ADAutoReportView();
            this.tpTerminology = new System.Windows.Forms.TabPage();
            this.btnApplyNewTerm = new System.Windows.Forms.Button();
            this.txtSubsidiarySynonym = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOK.Click += btnOK_Click;
            this.tcSubsidiaries.SuspendLayout();
            this.tpSubsidiaries.SuspendLayout();
            this.tpTerminology.SuspendLayout();
            this.SuspendLayout();
            //
            //tcSubsidiaries
            //
            this.tcSubsidiaries.Controls.Add(this.tpSubsidiaries);
            this.tcSubsidiaries.Controls.Add(this.tpTerminology);
            this.tcSubsidiaries.Location = new System.Drawing.Point(14, 14);
            this.tcSubsidiaries.Margin = new System.Windows.Forms.Padding(4);
            this.tcSubsidiaries.Name = "tcSubsidiaries";
            this.tcSubsidiaries.SelectedIndex = 0;
            this.tcSubsidiaries.Size = new System.Drawing.Size(594, 364);
            this.tcSubsidiaries.TabIndex = 0;
            //
            //tpSubsidiaries
            //
            this.tpSubsidiaries.Controls.Add(this.btnDelete);
            this.tpSubsidiaries.Controls.Add(this.btnEdit);
            this.tpSubsidiaries.Controls.Add(this.btnNew);
            this.tpSubsidiaries.Controls.Add(this.arvSubsidiaries);
            this.tpSubsidiaries.Location = new System.Drawing.Point(4, 25);
            this.tpSubsidiaries.Margin = new System.Windows.Forms.Padding(4);
            this.tpSubsidiaries.Name = "tpSubsidiaries";
            this.tpSubsidiaries.Padding = new System.Windows.Forms.Padding(4);
            this.tpSubsidiaries.Size = new System.Drawing.Size(586, 335);
            this.tpSubsidiaries.TabIndex = 0;
            this.tpSubsidiaries.Text = "Subsidiarit�ten";
            this.tpSubsidiaries.UseVisualStyleBackColor = false;
            //
            //btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(456, 93);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 35);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "L�schen...";
            //
            //btnEdit
            //
            this.btnEdit.Location = new System.Drawing.Point(456, 52);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(117, 35);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Bearbeiten...";
            //
            //btnNew
            //
            this.btnNew.Location = new System.Drawing.Point(456, 11);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(117, 35);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "Neu...";
            //
            //arvSubsidiaries
            //
            this.arvSubsidiaries.FullRowSelect = true;
            this.arvSubsidiaries.GridLines = true;
            this.arvSubsidiaries.HideSelection = false;
            this.arvSubsidiaries.List = null;
            this.arvSubsidiaries.ListViewMode = ActiveDev.AutoReportMode.Details;
            this.arvSubsidiaries.Location = new System.Drawing.Point(13, 12);
            this.arvSubsidiaries.Name = "arvSubsidiaries";
            this.arvSubsidiaries.Size = new System.Drawing.Size(432, 308);
            this.arvSubsidiaries.TabIndex = 0;
            this.arvSubsidiaries.View = System.Windows.Forms.View.Details;
            //
            //tpTerminology
            //
            this.tpTerminology.Controls.Add(this.btnApplyNewTerm);
            this.tpTerminology.Controls.Add(this.txtSubsidiarySynonym);
            this.tpTerminology.Controls.Add(this.Label3);
            this.tpTerminology.Controls.Add(this.Label2);
            this.tpTerminology.Controls.Add(this.Label1);
            this.tpTerminology.Location = new System.Drawing.Point(4, 25);
            this.tpTerminology.Margin = new System.Windows.Forms.Padding(4);
            this.tpTerminology.Name = "tpTerminology";
            this.tpTerminology.Padding = new System.Windows.Forms.Padding(4);
            this.tpTerminology.Size = new System.Drawing.Size(586, 335);
            this.tpTerminology.TabIndex = 1;
            this.tpTerminology.Text = "Terminologie";
            this.tpTerminology.UseVisualStyleBackColor = false;
            //
            //btnApplyNewTerm
            //
            this.btnApplyNewTerm.Location = new System.Drawing.Point(333, 225);
            this.btnApplyNewTerm.Name = "btnApplyNewTerm";
            this.btnApplyNewTerm.Size = new System.Drawing.Size(180, 28);
            this.btnApplyNewTerm.TabIndex = 4;
            this.btnApplyNewTerm.Text = "Neuen Begriff �bernehmen";
            //
            //txtSubsidiarySynonym
            //
            this.txtSubsidiarySynonym.Location = new System.Drawing.Point(214, 179);
            this.txtSubsidiarySynonym.Name = "txtSubsidiarySynonym";
            this.txtSubsidiarySynonym.Size = new System.Drawing.Size(299, 22);
            this.txtSubsidiarySynonym.TabIndex = 3;
            //
            //Label3
            //
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(30, 182);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(182, 16);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Bezeichnung f�r Subsidiarit�t:";
            //
            //Label2
            //
            this.Label2.Location = new System.Drawing.Point(24, 108);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(503, 52);
            this.Label2.TabIndex = 1;
            this.Label2.Text = resources.GetString("Label2.Text");
            //
            //Label1
            //
            this.Label1.Location = new System.Drawing.Point(24, 27);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(503, 66);
            this.Label1.TabIndex = 0;
            this.Label1.Text = resources.GetString("Label1.Text");
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(463, 385);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(141, 34);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            //
            //frmSubsidiaryManager
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 428);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tcSubsidiaries);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSubsidiaryManager";
            this.Text = "Subsidiarit�ten-Manager:";
            this.tcSubsidiaries.ResumeLayout(false);
            this.tpSubsidiaries.ResumeLayout(false);
            this.tpTerminology.ResumeLayout(false);
            this.tpTerminology.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.TabControl tcSubsidiaries;
        internal System.Windows.Forms.TabPage tpSubsidiaries;
        internal System.Windows.Forms.TabPage tpTerminology;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnApplyNewTerm;
        internal System.Windows.Forms.TextBox txtSubsidiarySynonym;
        internal System.Windows.Forms.Button btnOK;

        internal System.Windows.Forms.Button btnDelete;

        internal System.Windows.Forms.Button btnEdit;

        internal System.Windows.Forms.Button btnNew;

        internal ActiveDev.ADAutoReportView arvSubsidiaries;
    }
}
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

namespace Facesso
{
    public partial class frmTSImport : Facesso.GenericControls.frmBaseFacesso
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
            this.Label1 = new System.Windows.Forms.Label();
            this.txtAccessPathAndFile = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnOpenFile.Click += btnOpenFile_Click;
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOK.Click += btnOK_Click;
            this.btnImportNow = new System.Windows.Forms.Button();
            this.btnImportNow.Click += btnImportNow_Click;
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkTransformProductionData = new System.Windows.Forms.CheckBox();
            this.chkTransformEmployeeTimes = new System.Windows.Forms.CheckBox();
            this.chkAllowNewCostCenterAlignment = new System.Windows.Forms.CheckBox();
            this.chkTransformBaseData = new System.Windows.Forms.CheckBox();
            this.chkGenerateRandomData = new System.Windows.Forms.CheckBox();
            this.chkGenerateRandomData.CheckedChanged += chkGenerateRandomData_CheckedChanged;
            this.ndbTransformFrom = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.adinMonthToAdd = new ActiveDev.Controls.ADNullableIntBox();
            this.SuspendLayout();
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(101, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Access-Datenbank:";
            //
            //txtAccessPathAndFile
            //
            this.txtAccessPathAndFile.Location = new System.Drawing.Point(115, 17);
            this.txtAccessPathAndFile.Name = "txtAccessPathAndFile";
            this.txtAccessPathAndFile.Size = new System.Drawing.Size(290, 20);
            this.txtAccessPathAndFile.TabIndex = 1;
            //
            //btnOpenFile
            //
            this.btnOpenFile.Location = new System.Drawing.Point(406, 17);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(23, 20);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "...";
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(474, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 38);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            //
            //btnImportNow
            //
            this.btnImportNow.Location = new System.Drawing.Point(474, 83);
            this.btnImportNow.Name = "btnImportNow";
            this.btnImportNow.Size = new System.Drawing.Size(112, 39);
            this.btnImportNow.TabIndex = 8;
            this.btnImportNow.Text = "Jetzt importieren";
            //
            //lblStatus
            //
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Location = new System.Drawing.Point(12, 307);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(574, 54);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Leerlauf";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //chkTransformProductionData
            //
            this.chkTransformProductionData.AutoSize = true;
            this.chkTransformProductionData.Checked = true;
            this.chkTransformProductionData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTransformProductionData.Location = new System.Drawing.Point(115, 203);
            this.chkTransformProductionData.Name = "chkTransformProductionData";
            this.chkTransformProductionData.Size = new System.Drawing.Size(182, 17);
            this.chkTransformProductionData.TabIndex = 6;
            this.chkTransformProductionData.Text = "Produktionsmengen �bernehmen";
            this.chkTransformProductionData.UseVisualStyleBackColor = true;
            //
            //chkTransformEmployeeTimes
            //
            this.chkTransformEmployeeTimes.AutoSize = true;
            this.chkTransformEmployeeTimes.Checked = true;
            this.chkTransformEmployeeTimes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTransformEmployeeTimes.Location = new System.Drawing.Point(115, 226);
            this.chkTransformEmployeeTimes.Name = "chkTransformEmployeeTimes";
            this.chkTransformEmployeeTimes.Size = new System.Drawing.Size(165, 17);
            this.chkTransformEmployeeTimes.TabIndex = 7;
            this.chkTransformEmployeeTimes.Text = "Mitarbeiterzeiten �bernehmen";
            this.chkTransformEmployeeTimes.UseVisualStyleBackColor = true;
            //
            //chkAllowNewCostCenterAlignment
            //
            this.chkAllowNewCostCenterAlignment.AutoSize = true;
            this.chkAllowNewCostCenterAlignment.Location = new System.Drawing.Point(115, 157);
            this.chkAllowNewCostCenterAlignment.Name = "chkAllowNewCostCenterAlignment";
            this.chkAllowNewCostCenterAlignment.Size = new System.Drawing.Size(343, 17);
            this.chkAllowNewCostCenterAlignment.TabIndex = 5;
            this.chkAllowNewCostCenterAlignment.Text = "Nach Stammdaten�bernahme, Kostenstellen manuell neu zuordnen";
            this.chkAllowNewCostCenterAlignment.UseVisualStyleBackColor = true;
            //
            //chkTransformBaseData
            //
            this.chkTransformBaseData.AutoSize = true;
            this.chkTransformBaseData.Checked = true;
            this.chkTransformBaseData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTransformBaseData.Location = new System.Drawing.Point(115, 180);
            this.chkTransformBaseData.Name = "chkTransformBaseData";
            this.chkTransformBaseData.Size = new System.Drawing.Size(451, 17);
            this.chkTransformBaseData.TabIndex = 11;
            this.chkTransformBaseData.Text = "Stammdaten neu �bernehmen (alle Daten der Subsidiarit�t werden dabei zuvor gel�sc" + "ht!!!)";
            this.chkTransformBaseData.UseVisualStyleBackColor = true;
            //
            //chkGenerateRandomData
            //
            this.chkGenerateRandomData.AutoSize = true;
            this.chkGenerateRandomData.Location = new System.Drawing.Point(115, 105);
            this.chkGenerateRandomData.Name = "chkGenerateRandomData";
            this.chkGenerateRandomData.Size = new System.Drawing.Size(209, 17);
            this.chkGenerateRandomData.TabIndex = 12;
            this.chkGenerateRandomData.Text = "Zufallsdaten aus Realdaten generieren";
            this.chkGenerateRandomData.UseVisualStyleBackColor = true;
            //
            //ndbTransformFrom
            //
            this.ndbTransformFrom.BackColor = System.Drawing.SystemColors.Window;
            this.ndbTransformFrom.CaptionToValueRatio = 500;
            this.ndbTransformFrom.ColorOnFocus = true;
            this.ndbTransformFrom.FailedValidationErrorMessage = null;
            this.ndbTransformFrom.HasCaption = true;
            this.ndbTransformFrom.IndependentDatafieldName = null;
            this.ndbTransformFrom.Location = new System.Drawing.Point(115, 69);
            this.ndbTransformFrom.Name = "ndbTransformFrom";
            this.ndbTransformFrom.NullString = "* --- *";
            this.ndbTransformFrom.NullValueMessage = null;
            this.ndbTransformFrom.Size = new System.Drawing.Size(290, 20);
            this.ndbTransformFrom.TabIndex = 13;
            this.ndbTransformFrom.Text = "Daten�bernahme ab:";
            this.ndbTransformFrom.ValueAreaLength = 145;
            //
            //adinMonthToAdd
            //
            this.adinMonthToAdd.BackColor = System.Drawing.SystemColors.Window;
            this.adinMonthToAdd.CaptionToValueRatio = 500;
            this.adinMonthToAdd.ColorOnFocus = true;
            this.adinMonthToAdd.Enabled = false;
            this.adinMonthToAdd.FailedValidationErrorMessage = null;
            this.adinMonthToAdd.FormularText = "";
            this.adinMonthToAdd.HasCaption = true;
            this.adinMonthToAdd.IndependentDatafieldName = null;
            this.adinMonthToAdd.Location = new System.Drawing.Point(115, 131);
            this.adinMonthToAdd.MaxValue = 0;
            this.adinMonthToAdd.MinValue = 0;
            this.adinMonthToAdd.Name = "adinMonthToAdd";
            this.adinMonthToAdd.NullString = "* --- *";
            this.adinMonthToAdd.NullValueMessage = null;
            this.adinMonthToAdd.Size = new System.Drawing.Size(290, 20);
            this.adinMonthToAdd.TabIndex = 14;
            this.adinMonthToAdd.Text = "Hinzuzuf�gende Monate:";
            this.adinMonthToAdd.ValueAreaLength = 145;
            //
            //frmTSImport
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 370);
            this.Controls.Add(this.adinMonthToAdd);
            this.Controls.Add(this.ndbTransformFrom);
            this.Controls.Add(this.chkGenerateRandomData);
            this.Controls.Add(this.chkTransformBaseData);
            this.Controls.Add(this.chkAllowNewCostCenterAlignment);
            this.Controls.Add(this.chkTransformEmployeeTimes);
            this.Controls.Add(this.chkTransformProductionData);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnImportNow);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtAccessPathAndFile);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTSImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stammdatenimport aus Access-Datenbank:";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtAccessPathAndFile;
        internal System.Windows.Forms.Button btnOpenFile;

        internal System.Windows.Forms.Button btnOK;

        internal System.Windows.Forms.Button btnImportNow;

        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.CheckBox chkTransformProductionData;
        internal System.Windows.Forms.CheckBox chkTransformEmployeeTimes;
        internal System.Windows.Forms.CheckBox chkAllowNewCostCenterAlignment;
        internal System.Windows.Forms.CheckBox chkTransformBaseData;
        internal System.Windows.Forms.CheckBox chkGenerateRandomData;

        internal ActiveDev.Controls.ADNullableDateTimeBox ndbTransformFrom;
        internal ActiveDev.Controls.ADNullableIntBox adinMonthToAdd;
    }
}
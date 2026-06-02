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
    public partial class frmWorkGroupPrintBaseData : frmBaseFacesso
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrint.Click += btnPrint_Click;
            this.btnOK = new System.Windows.Forms.Button();
            this.optOnlyPrintWorkgroups = new System.Windows.Forms.RadioButton();
            this.optPrintWorkgroups = new System.Windows.Forms.RadioButton();
            this.chkPrintAssignedLabourValues = new System.Windows.Forms.CheckBox();
            this.chkPrintShiftTimes = new System.Windows.Forms.CheckBox();
            this.chkVisualieProductivityHistory = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.nudMonths = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)this.nudMonths).BeginInit();
            this.SuspendLayout();
            //
            //btnPrint
            //
            this.btnPrint.Location = new System.Drawing.Point(393, 47);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(97, 29);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Drucken...";
            this.btnPrint.UseVisualStyleBackColor = true;
            //
            //btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(393, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //optOnlyPrintWorkgroups
            //
            this.optOnlyPrintWorkgroups.AutoSize = true;
            this.optOnlyPrintWorkgroups.Location = new System.Drawing.Point(12, 106);
            this.optOnlyPrintWorkgroups.Name = "optOnlyPrintWorkgroups";
            this.optOnlyPrintWorkgroups.Size = new System.Drawing.Size(188, 17);
            this.optOnlyPrintWorkgroups.TabIndex = 2;
            this.optOnlyPrintWorkgroups.TabStop = true;
            this.optOnlyPrintWorkgroups.Text = "Nur Liste der Arbeitswerte drucken";
            this.optOnlyPrintWorkgroups.UseVisualStyleBackColor = true;
            //
            //optPrintWorkgroups
            //
            this.optPrintWorkgroups.AutoSize = true;
            this.optPrintWorkgroups.Location = new System.Drawing.Point(12, 12);
            this.optPrintWorkgroups.Name = "optPrintWorkgroups";
            this.optPrintWorkgroups.Size = new System.Drawing.Size(138, 17);
            this.optPrintWorkgroups.TabIndex = 5;
            this.optPrintWorkgroups.TabStop = true;
            this.optPrintWorkgroups.Text = "Produktiv-Sites drucken";
            this.optPrintWorkgroups.UseVisualStyleBackColor = true;
            //
            //chkPrintAssignedLabourValues
            //
            this.chkPrintAssignedLabourValues.AutoSize = true;
            this.chkPrintAssignedLabourValues.Location = new System.Drawing.Point(29, 35);
            this.chkPrintAssignedLabourValues.Name = "chkPrintAssignedLabourValues";
            this.chkPrintAssignedLabourValues.Size = new System.Drawing.Size(252, 17);
            this.chkPrintAssignedLabourValues.TabIndex = 6;
            this.chkPrintAssignedLabourValues.Text = "zugeordnete REFA-Arbeitswerte mit ausdrucken";
            this.chkPrintAssignedLabourValues.UseVisualStyleBackColor = true;
            //
            //chkPrintShiftTimes
            //
            this.chkPrintShiftTimes.AutoSize = true;
            this.chkPrintShiftTimes.Location = new System.Drawing.Point(29, 58);
            this.chkPrintShiftTimes.Name = "chkPrintShiftTimes";
            this.chkPrintShiftTimes.Size = new System.Drawing.Size(280, 17);
            this.chkPrintShiftTimes.TabIndex = 7;
            this.chkPrintShiftTimes.Text = "Schichtzeitrahmen der Arbeitsgruppen mit ausdrucken";
            this.chkPrintShiftTimes.UseVisualStyleBackColor = true;
            //
            //chkVisualieProductivityHistory
            //
            this.chkVisualieProductivityHistory.AutoSize = true;
            this.chkVisualieProductivityHistory.Location = new System.Drawing.Point(29, 81);
            this.chkVisualieProductivityHistory.Name = "chkVisualieProductivityHistory";
            this.chkVisualieProductivityHistory.Size = new System.Drawing.Size(174, 17);
            this.chkVisualieProductivityHistory.TabIndex = 8;
            this.chkVisualieProductivityHistory.Text = "Produktivitätsverlauf der letzten";
            this.chkVisualieProductivityHistory.UseVisualStyleBackColor = true;
            this.chkVisualieProductivityHistory.Visible = false;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(264, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(103, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Monate visualisieren";
            this.Label1.Visible = false;
            //
            //nudMonths
            //
            this.nudMonths.Location = new System.Drawing.Point(202, 80);
            this.nudMonths.Maximum = new decimal (new int[] { 12, 0, 0, 0 });
            this.nudMonths.Minimum = new decimal (new int[] { 3, 0, 0, 0 });
            this.nudMonths.Name = "nudMonths";
            this.nudMonths.Size = new System.Drawing.Size(56, 20);
            this.nudMonths.TabIndex = 11;
            this.nudMonths.Value = new decimal (new int[] { 3, 0, 0, 0 });
            this.nudMonths.Visible = false;
            //
            //frmWorkGroupPrintBaseData
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 134);
            this.Controls.Add(this.nudMonths);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.chkVisualieProductivityHistory);
            this.Controls.Add(this.chkPrintShiftTimes);
            this.Controls.Add(this.chkPrintAssignedLabourValues);
            this.Controls.Add(this.optPrintWorkgroups);
            this.Controls.Add(this.optOnlyPrintWorkgroups);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmWorkGroupPrintBaseData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Produktiv-Sites/REFA-Arbeitswert-Basisdaten drucken";
            ((System.ComponentModel.ISupportInitialize)this.nudMonths).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Button btnPrint;

        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.RadioButton optOnlyPrintWorkgroups;
        internal System.Windows.Forms.RadioButton optPrintWorkgroups;
        internal System.Windows.Forms.CheckBox chkPrintAssignedLabourValues;
        internal System.Windows.Forms.CheckBox chkPrintShiftTimes;
        internal System.Windows.Forms.CheckBox chkVisualieProductivityHistory;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.NumericUpDown nudMonths;
    }
}
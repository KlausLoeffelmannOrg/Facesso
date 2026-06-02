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
    public partial class frmIncentiveWageCalc : frmBaseFacesso
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
            Facesso.MonthRangePickerResult MonthRangePickerResult1 = new Facesso.MonthRangePickerResult();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.elvEmployees = new Facesso.GenericControls.ucEmployeeListView();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnUnselectAll.Click += btnUnselectAll_Click;
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectAll.Click += btnSelectAll_Click;
            this.btnPerformCalculation = new System.Windows.Forms.Button();
            this.btnPerformCalculation.Click += btnPerformCalculation_Click;
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOK.Click += btnOK_Click;
            this.Label1 = new System.Windows.Forms.Label();
            this.pbEmployeesToAnalyse = new System.Windows.Forms.ProgressBar();
            this.lblCurrentEmployee = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.MonthRangePicker = new Facesso.GenericControls.ucMonthRangePicker();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.elvEmployees);
            this.GroupBox1.Controls.Add(this.btnUnselectAll);
            this.GroupBox1.Controls.Add(this.pbEmployeesToAnalyse);
            this.GroupBox1.Controls.Add(this.btnSelectAll);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(470, 337);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Mitarbeiter, die in Aufstellung einbezogen werden sollen:";
            //
            //elvEmployees
            //
            this.elvEmployees.AutoGroup = true;
            this.elvEmployees.EmployeeInfoCollection = null;
            this.elvEmployees.EmployeeSortOrder = Facesso.GenericControls.EmployeeSortOrder.PersonnelNumber;
            this.elvEmployees.FullRowSelect = true;
            this.elvEmployees.HideSelection = false;
            this.elvEmployees.Location = new System.Drawing.Point(6, 19);
            this.elvEmployees.Name = "elvEmployees";
            this.elvEmployees.OnlyActiveEmployees = true;
            this.elvEmployees.OnlyIncentiveEmployees = false;
            this.elvEmployees.Size = new System.Drawing.Size(454, 225);
            this.elvEmployees.TabIndex = 3;
            this.elvEmployees.UseCompatibleStateImageBehavior = false;
            this.elvEmployees.View = System.Windows.Forms.View.Details;
            //
            //btnUnselectAll
            //
            this.btnUnselectAll.Location = new System.Drawing.Point(6, 250);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(124, 23);
            this.btnUnselectAll.TabIndex = 2;
            this.btnUnselectAll.Text = "Markierung aufheben";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            //
            //btnSelectAll
            //
            this.btnSelectAll.Location = new System.Drawing.Point(136, 250);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(124, 23);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Alle markieren";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            //
            //btnPerformCalculation
            //
            this.btnPerformCalculation.Location = new System.Drawing.Point(497, 317);
            this.btnPerformCalculation.Name = "btnPerformCalculation";
            this.btnPerformCalculation.Size = new System.Drawing.Size(155, 32);
            this.btnPerformCalculation.TabIndex = 3;
            this.btnPerformCalculation.Text = "Auswertung durchf�hren...";
            this.btnPerformCalculation.UseVisualStyleBackColor = true;
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(658, 317);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(111, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 289);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(168, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Noch zu berechnende Mitarbeiter:";
            //
            //pbEmployeesToAnalyse
            //
            this.pbEmployeesToAnalyse.Location = new System.Drawing.Point(6, 310);
            this.pbEmployeesToAnalyse.Name = "pbEmployeesToAnalyse";
            this.pbEmployeesToAnalyse.Size = new System.Drawing.Size(454, 21);
            this.pbEmployeesToAnalyse.TabIndex = 6;
            //
            //lblCurrentEmployee
            //
            this.lblCurrentEmployee.AutoSize = true;
            this.lblCurrentEmployee.Location = new System.Drawing.Point(188, 358);
            this.lblCurrentEmployee.Name = "lblCurrentEmployee";
            this.lblCurrentEmployee.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentEmployee.TabIndex = 7;
            //
            //GroupBox2
            //
            this.GroupBox2.Controls.Add(this.MonthRangePicker);
            this.GroupBox2.Location = new System.Drawing.Point(491, 12);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(295, 278);
            this.GroupBox2.TabIndex = 8;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Abrechnungszeitraumparameter";
            //
            //UcMonthRangePicker1
            //
            this.MonthRangePicker.Location = new System.Drawing.Point(6, 21);
            this.MonthRangePicker.MaximumSize = new System.Drawing.Size(280, 290);
            this.MonthRangePicker.MinimumSize = new System.Drawing.Size(280, 250);
            MonthRangePickerResult1.MonthRangeBase = Facesso.MonthRangeBase.FirstToLastPrevious;
            MonthRangePickerResult1.RelatedMonth = Facesso.RelatedMonth.PreviousMonth;
            this.MonthRangePicker.Name = "UcMonthRangePicker1";
            this.MonthRangePicker.Size = new System.Drawing.Size(280, 250);
            this.MonthRangePicker.TabIndex = 5;
            //
            //frmIncentiveWageCalc
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 359);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.lblCurrentEmployee);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnPerformCalculation);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmIncentiveWageCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pr�mienlohnabrechnung Mitarbeiter";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnSelectAll;

        internal System.Windows.Forms.Button btnUnselectAll;

        internal System.Windows.Forms.Button btnPerformCalculation;

        internal System.Windows.Forms.Button btnOK;

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ProgressBar pbEmployeesToAnalyse;
        internal System.Windows.Forms.Label lblCurrentEmployee;
        internal Facesso.GenericControls.ucEmployeeListView elvEmployees;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal Facesso.GenericControls.ucMonthRangePicker MonthRangePicker;
    }
}
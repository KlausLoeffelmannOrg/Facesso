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
    public partial class ucMonthRangePicker : System.Windows.Forms.UserControl
    {
        //UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
            this.Label4 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpTo.ValueChanged += dtps_ValuesChanged;
            this.Label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom.ValueChanged += dtps_ValuesChanged;
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.optSecondLastMonth = new System.Windows.Forms.RadioButton();
            this.optSecondLastMonth.CheckedChanged += optRelatedMonth_Changed;
            this.optPreviousMonth = new System.Windows.Forms.RadioButton();
            this.optPreviousMonth.CheckedChanged += optRelatedMonth_Changed;
            this.optCurrentMonth = new System.Windows.Forms.RadioButton();
            this.optCurrentMonth.CheckedChanged += optRelatedMonth_Changed;
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbMonthRange = new System.Windows.Forms.ComboBox();
            this.cmbMonthRange.SelectedIndexChanged += cmbMonthRange_SelectedIndexChanged;
            this.optFreeRange = new System.Windows.Forms.RadioButton();
            this.optRelatedMonth = new System.Windows.Forms.RadioButton();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            //
            //Label4
            //
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(36, 219);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(23, 13);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "bis:";
            //
            //dtpTo
            //
            this.dtpTo.Location = new System.Drawing.Point(65, 215);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(212, 20);
            this.dtpTo.TabIndex = 19;
            //
            //Label3
            //
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(31, 193);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(28, 13);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "von:";
            //
            //dtpFrom
            //
            this.dtpFrom.Location = new System.Drawing.Point(65, 189);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(212, 20);
            this.dtpFrom.TabIndex = 17;
            //
            //GroupBox2
            //
            this.GroupBox2.Controls.Add(this.optSecondLastMonth);
            this.GroupBox2.Controls.Add(this.optPreviousMonth);
            this.GroupBox2.Controls.Add(this.optCurrentMonth);
            this.GroupBox2.Location = new System.Drawing.Point(6, 68);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(271, 83);
            this.GroupBox2.TabIndex = 16;
            this.GroupBox2.TabStop = false;
            //
            //optSecondLastMonth
            //
            this.optSecondLastMonth.AutoSize = true;
            this.optSecondLastMonth.Location = new System.Drawing.Point(6, 59);
            this.optSecondLastMonth.Name = "optSecondLastMonth";
            this.optSecondLastMonth.Size = new System.Drawing.Size(140, 17);
            this.optSecondLastMonth.TabIndex = 6;
            this.optSecondLastMonth.TabStop = true;
            this.optSecondLastMonth.Text = "Vor zwei Monaten (###)";
            this.optSecondLastMonth.UseVisualStyleBackColor = true;
            //
            //optPreviousMonth
            //
            this.optPreviousMonth.AutoSize = true;
            this.optPreviousMonth.Location = new System.Drawing.Point(6, 36);
            this.optPreviousMonth.Name = "optPreviousMonth";
            this.optPreviousMonth.Size = new System.Drawing.Size(100, 17);
            this.optPreviousMonth.TabIndex = 5;
            this.optPreviousMonth.TabStop = true;
            this.optPreviousMonth.Text = "Vormonat (###)";
            this.optPreviousMonth.UseVisualStyleBackColor = true;
            //
            //optCurrentMonth
            //
            this.optCurrentMonth.AutoSize = true;
            this.optCurrentMonth.Location = new System.Drawing.Point(6, 13);
            this.optCurrentMonth.Name = "optCurrentMonth";
            this.optCurrentMonth.Size = new System.Drawing.Size(129, 17);
            this.optCurrentMonth.TabIndex = 4;
            this.optCurrentMonth.TabStop = true;
            this.optCurrentMonth.Text = "Aktueller Monat (###)";
            this.optCurrentMonth.UseVisualStyleBackColor = true;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(170, 13);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "Monatlicher Abrechnungszeitraum:";
            //
            //cmbMonthRange
            //
            this.cmbMonthRange.FormattingEnabled = true;
            this.cmbMonthRange.Items.AddRange(new object[] { "von 1. bis letzten des Vor-Bezugsmonats", "vom 1. bis letzten des Bezugsmonats", "vom 10. des Vor-Bezugsmonats bis  9. des Bezugmonats", "vom 15. des Vor-Bezugsmonats bis  14. des Bezugmonats", "vom 20. des Vor-Bezugsmonats bis 19. des Bezugsmonats" });
            this.cmbMonthRange.Location = new System.Drawing.Point(6, 17);
            this.cmbMonthRange.Name = "cmbMonthRange";
            this.cmbMonthRange.Size = new System.Drawing.Size(271, 21);
            this.cmbMonthRange.TabIndex = 14;
            //
            //optFreeRange
            //
            this.optFreeRange.AutoSize = true;
            this.optFreeRange.Location = new System.Drawing.Point(6, 166);
            this.optFreeRange.Name = "optFreeRange";
            this.optFreeRange.Size = new System.Drawing.Size(150, 17);
            this.optFreeRange.TabIndex = 13;
            this.optFreeRange.TabStop = true;
            this.optFreeRange.Text = "Frei gewählter Zeitbereich:";
            this.optFreeRange.UseVisualStyleBackColor = true;
            //
            //optRelatedMonth
            //
            this.optRelatedMonth.AutoSize = true;
            this.optRelatedMonth.Location = new System.Drawing.Point(6, 53);
            this.optRelatedMonth.Name = "optRelatedMonth";
            this.optRelatedMonth.Size = new System.Drawing.Size(92, 17);
            this.optRelatedMonth.TabIndex = 12;
            this.optRelatedMonth.TabStop = true;
            this.optRelatedMonth.Text = "Bezugsmonat:";
            this.optRelatedMonth.UseVisualStyleBackColor = true;
            //
            //ucMonthRangePicker
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbMonthRange);
            this.Controls.Add(this.optFreeRange);
            this.Controls.Add(this.optRelatedMonth);
            this.MaximumSize = new System.Drawing.Size(280, 290);
            this.MinimumSize = new System.Drawing.Size(280, 250);
            this.Name = "ucMonthRangePicker";
            this.Size = new System.Drawing.Size(280, 250);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DateTimePicker dtpTo;

        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DateTimePicker dtpFrom;

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.RadioButton optSecondLastMonth;

        internal System.Windows.Forms.RadioButton optPreviousMonth;

        internal System.Windows.Forms.RadioButton optCurrentMonth;

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbMonthRange;

        internal System.Windows.Forms.RadioButton optFreeRange;
        internal System.Windows.Forms.RadioButton optRelatedMonth;
    }
}
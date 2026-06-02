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
    public partial class frmEmployeeTimeList : frmBaseFacesso
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOK.Click += btnOK_Click;
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefresh.Click += btnRefresh_Click;
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrint.Click += btnPrint_Click;
            this.btnCurrentMonth = new System.Windows.Forms.Button();
            this.btnCurrentMonth.Click += btnCurrentMonth_Click;
            this.btnLastMonth = new System.Windows.Forms.Button();
            this.btnLastMonth.Click += btnLastMonth_Click;
            this.btnSecondLastMonth = new System.Windows.Forms.Button();
            this.btnSecondLastMonth.Click += btnSecondLastMonth_Click;
            this.dgvTimeList = new Facesso.GenericControls.ucTimeLogItemsDataGridView();
            this.dgvTimeList.TimeLogItemDoubleClick += dgvTimeList_TimeLogItemDoubleClick;
            ((System.ComponentModel.ISupportInitialize)this.dgvTimeList).BeginInit();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnOK.Location = new System.Drawing.Point(549, 458);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //dtpTo
            //
            this.dtpTo.Location = new System.Drawing.Point(15, 65);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(203, 20);
            this.dtpTo.TabIndex = 12;
            //
            //dtpFrom
            //
            this.dtpFrom.Location = new System.Drawing.Point(15, 26);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(203, 20);
            this.dtpFrom.TabIndex = 11;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 49);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(23, 13);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "bis:";
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(28, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "von:";
            //
            //btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnRefresh.Location = new System.Drawing.Point(541, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 25);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Aktualisieren";
            this.btnRefresh.UseVisualStyleBackColor = true;
            //
            //btnPrint
            //
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnPrint.Location = new System.Drawing.Point(423, 458);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 31);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "Drucken...";
            this.btnPrint.UseVisualStyleBackColor = true;
            //
            //btnCurrentMonth
            //
            this.btnCurrentMonth.Location = new System.Drawing.Point(252, 24);
            this.btnCurrentMonth.Name = "btnCurrentMonth";
            this.btnCurrentMonth.Size = new System.Drawing.Size(129, 21);
            this.btnCurrentMonth.TabIndex = 16;
            this.btnCurrentMonth.Text = "laufender Monat";
            this.btnCurrentMonth.UseVisualStyleBackColor = true;
            //
            //btnLastMonth
            //
            this.btnLastMonth.Location = new System.Drawing.Point(252, 45);
            this.btnLastMonth.Name = "btnLastMonth";
            this.btnLastMonth.Size = new System.Drawing.Size(129, 21);
            this.btnLastMonth.TabIndex = 17;
            this.btnLastMonth.Text = "letzter Monat";
            this.btnLastMonth.UseVisualStyleBackColor = true;
            //
            //btnSecondLastMonth
            //
            this.btnSecondLastMonth.Location = new System.Drawing.Point(252, 65);
            this.btnSecondLastMonth.Name = "btnSecondLastMonth";
            this.btnSecondLastMonth.Size = new System.Drawing.Size(129, 21);
            this.btnSecondLastMonth.TabIndex = 18;
            this.btnSecondLastMonth.Text = "vorletzter Monat";
            this.btnSecondLastMonth.UseVisualStyleBackColor = true;
            //
            //dgvTimeList
            //
            this.dgvTimeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.dgvTimeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeList.EmployeeTimeLogItems = null;
            this.dgvTimeList.Location = new System.Drawing.Point(3, 101);
            this.dgvTimeList.Name = "dgvTimeList";
            this.dgvTimeList.SingleEmployeeList = false;
            this.dgvTimeList.Size = new System.Drawing.Size(666, 345);
            this.dgvTimeList.TabIndex = 13;
            //
            //frmEmployeeTimeList
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 501);
            this.Controls.Add(this.btnSecondLastMonth);
            this.Controls.Add(this.btnLastMonth);
            this.Controls.Add(this.btnCurrentMonth);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.dgvTimeList);
            this.Controls.Add(this.btnOK);
            this.Name = "frmEmployeeTimeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zeitenliste für:";
            ((System.ComponentModel.ISupportInitialize)this.dgvTimeList).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Button btnOK;

        internal System.Windows.Forms.DateTimePicker dtpTo;
        internal System.Windows.Forms.DateTimePicker dtpFrom;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal Facesso.GenericControls.ucTimeLogItemsDataGridView dgvTimeList;

        internal System.Windows.Forms.Button btnRefresh;

        internal System.Windows.Forms.Button btnPrint;

        internal System.Windows.Forms.Button btnCurrentMonth;

        internal System.Windows.Forms.Button btnLastMonth;

        internal System.Windows.Forms.Button btnSecondLastMonth;
    }
}
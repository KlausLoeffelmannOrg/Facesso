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
    public partial class frmTimeLogResultTable : System.Windows.Forms.Form
    {
        //Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Wird vom Windows Form-Designer benötigt.
        private System.ComponentModel.IContainer components;
        //Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        //Das Bearbeiten ist mit dem Windows Form-Designer möglich.
        //Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource ReportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource ReportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btnOK = new System.Windows.Forms.Button();
            this.rvEmployeeTimeLogResult = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tcReports = new System.Windows.Forms.TabControl();
            this.tpEmployeeReport = new System.Windows.Forms.TabPage();
            this.tpWorksiteReport = new System.Windows.Forms.TabPage();
            this.rvWorksiteTimeLogResult = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TimeDataRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tcReports.SuspendLayout();
            this.tpEmployeeReport.SuspendLayout();
            this.tpWorksiteReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.TimeDataRowBindingSource).BeginInit();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(590, 613);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(115, 38);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "So übernehmen";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //rvEmployeeTimeLogResult
            //
            this.rvEmployeeTimeLogResult.Dock = System.Windows.Forms.DockStyle.Fill;
            ReportDataSource1.Name = "Facesso_Interfaces_TimeDataRow";
            ReportDataSource1.Value = this.TimeDataRowBindingSource;
            this.rvEmployeeTimeLogResult.LocalReport.DataSources.Add(ReportDataSource1);
            this.rvEmployeeTimeLogResult.LocalReport.ReportEmbeddedResource = "Facesso.Interfaces.rptTimeLogImportResults.rdlc";
            this.rvEmployeeTimeLogResult.Location = new System.Drawing.Point(3, 3);
            this.rvEmployeeTimeLogResult.Name = "rvEmployeeTimeLogResult";
            this.rvEmployeeTimeLogResult.Size = new System.Drawing.Size(800, 565);
            this.rvEmployeeTimeLogResult.TabIndex = 2;
            //
            //btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnCancel.Location = new System.Drawing.Point(711, 613);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 38);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Nicht übernehmen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //tcReports
            //
            this.tcReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.tcReports.Controls.Add(this.tpEmployeeReport);
            this.tcReports.Controls.Add(this.tpWorksiteReport);
            this.tcReports.Location = new System.Drawing.Point(12, 12);
            this.tcReports.Name = "tcReports";
            this.tcReports.SelectedIndex = 0;
            this.tcReports.Size = new System.Drawing.Size(814, 597);
            this.tcReports.TabIndex = 4;
            //
            //tpEmployeeReport
            //
            this.tpEmployeeReport.Controls.Add(this.rvEmployeeTimeLogResult);
            this.tpEmployeeReport.Location = new System.Drawing.Point(4, 22);
            this.tpEmployeeReport.Name = "tpEmployeeReport";
            this.tpEmployeeReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmployeeReport.Size = new System.Drawing.Size(806, 571);
            this.tpEmployeeReport.TabIndex = 0;
            this.tpEmployeeReport.Text = "Mitarbeiter";
            this.tpEmployeeReport.UseVisualStyleBackColor = true;
            //
            //tpWorksiteReport
            //
            this.tpWorksiteReport.Controls.Add(this.rvWorksiteTimeLogResult);
            this.tpWorksiteReport.Location = new System.Drawing.Point(4, 22);
            this.tpWorksiteReport.Name = "tpWorksiteReport";
            this.tpWorksiteReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpWorksiteReport.Size = new System.Drawing.Size(806, 571);
            this.tpWorksiteReport.TabIndex = 1;
            this.tpWorksiteReport.Text = "Arbeitsgruppen";
            this.tpWorksiteReport.UseVisualStyleBackColor = true;
            //
            //rvWorksiteTimeLogResult
            //
            this.rvWorksiteTimeLogResult.Dock = System.Windows.Forms.DockStyle.Fill;
            ReportDataSource2.Name = "TimeDataRow";
            ReportDataSource2.Value = this.TimeDataRowBindingSource;
            this.rvWorksiteTimeLogResult.LocalReport.DataSources.Add(ReportDataSource2);
            this.rvWorksiteTimeLogResult.LocalReport.ReportEmbeddedResource = "Facesso.Interfaces.rptWorksiteTimeLogImportResult.rdlc";
            this.rvWorksiteTimeLogResult.Location = new System.Drawing.Point(3, 3);
            this.rvWorksiteTimeLogResult.Name = "rvWorksiteTimeLogResult";
            this.rvWorksiteTimeLogResult.Size = new System.Drawing.Size(800, 565);
            this.rvWorksiteTimeLogResult.TabIndex = 0;
            //
            //TimeDataRowBindingSource
            //
            this.TimeDataRowBindingSource.DataSource = typeof(Facesso.Interfaces.TimeDataRow);
            //
            //frmTimeLogResultTable
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 663);
            this.Controls.Add(this.tcReports);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmTimeLogResultTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zeitübernahmeergebnisse:";
            this.tcReports.ResumeLayout(false);
            this.tpEmployeeReport.ResumeLayout(false);
            this.tpWorksiteReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.TimeDataRowBindingSource).EndInit();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.Button btnOK;
        internal Microsoft.Reporting.WinForms.ReportViewer rvEmployeeTimeLogResult;
        internal System.Windows.Forms.BindingSource TimeDataRowBindingSource;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TabControl tcReports;
        internal System.Windows.Forms.TabPage tpEmployeeReport;
        internal System.Windows.Forms.TabPage tpWorksiteReport;
        internal Microsoft.Reporting.WinForms.ReportViewer rvWorksiteTimeLogResult;
    }
}
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
    public partial class ReportEmployeeMasterData : frmBaseFacesso
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
            this.rvEmployees = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MasterDataSet = new Facesso.Functions.MasterDataSet();
            this.EmployeesWithCostCentersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmployeesWithCostCentersTableAdapter = new Facesso.Functions.MasterDataSetTableAdapters.EmployeesWithCostCentersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)this.MasterDataSet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.EmployeesWithCostCentersBindingSource).BeginInit();
            this.SuspendLayout();
            //
            //rvEmployees
            //
            this.rvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            ReportDataSource1.Name = "MasterDataSet_EmployeesWithCostCenters";
            ReportDataSource1.Value = this.EmployeesWithCostCentersBindingSource;
            this.rvEmployees.LocalReport.DataSources.Add(ReportDataSource1);
            this.rvEmployees.LocalReport.ReportEmbeddedResource = "Facesso.Functions.ReportsEmployeeMasterData.rdlc";
            this.rvEmployees.Location = new System.Drawing.Point(12, 12);
            this.rvEmployees.Name = "rvEmployees";
            this.rvEmployees.Size = new System.Drawing.Size(510, 411);
            this.rvEmployees.TabIndex = 0;
            //
            //MasterDataSet
            //
            this.MasterDataSet.DataSetName = "MasterDataSet";
            this.MasterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            //
            //EmployeesWithCostCentersBindingSource
            //
            this.EmployeesWithCostCentersBindingSource.DataMember = "EmployeesWithCostCenters";
            this.EmployeesWithCostCentersBindingSource.DataSource = this.MasterDataSet;
            //
            //EmployeesWithCostCentersTableAdapter
            //
            this.EmployeesWithCostCentersTableAdapter.ClearBeforeFill = true;
            //
            //ReportEmployeeMasterData
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 435);
            this.Controls.Add(this.rvEmployees);
            this.Name = "ReportEmployeeMasterData";
            this.Text = "Mitarbeiterstammdaten";
            ((System.ComponentModel.ISupportInitialize)this.MasterDataSet).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.EmployeesWithCostCentersBindingSource).EndInit();
            this.ResumeLayout(false);
        }

        internal Microsoft.Reporting.WinForms.ReportViewer rvEmployees;
        internal System.Windows.Forms.BindingSource EmployeesWithCostCentersBindingSource;
        internal Facesso.Functions.MasterDataSet MasterDataSet;
        internal Facesso.Functions.MasterDataSetTableAdapters.EmployeesWithCostCentersTableAdapter EmployeesWithCostCentersTableAdapter;
    }
}
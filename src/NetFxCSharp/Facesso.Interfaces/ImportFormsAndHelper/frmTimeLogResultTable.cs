using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class frmTimeLogResultTable
    {
        private TimeDataTable myTimeLogData;
        private System.DateTime myProductionDate;
        private void frmTimeLogResultTable_Load(System.Object sender, System.EventArgs e)
        {
            List<ReportParameter> tmpParams = new List<ReportParameter>();
            tmpParams.Add(new ReportParameter("ReportDate", myProductionDate.ToString()));
            this.rvEmployeeTimeLogResult.LocalReport.SetParameters(tmpParams);
            this.rvWorksiteTimeLogResult.LocalReport.SetParameters(tmpParams);
            this.TimeDataRowBindingSource.DataSource = myTimeLogData;
            this.rvEmployeeTimeLogResult.RefreshReport();
            this.rvWorksiteTimeLogResult.RefreshReport();
        }

        public DialogResult ShowDialog(TimeDataTable timeLogData, System.DateTime ProductionDate)
        {
            myProductionDate = ProductionDate;
            myTimeLogData = timeLogData;
            return base.ShowDialog();
        }

        public frmTimeLogResultTable()
        {
            this.Load += frmTimeLogResultTable_Load;
            InitializeComponent();
        }
    }
}
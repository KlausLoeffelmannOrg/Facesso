using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class ReportEmployeeMasterData
    {
        private void ReportEmployeeMasterData_Load(System.Object sender, System.EventArgs e)
        {
            //TODO: Diese Codezeile l�dt Daten in die Tabelle "MasterDataSet.EmployeesWithCostCenters".
            //Sie k�nnen sie bei Bedarf verschieben oder entfernen.
            this.EmployeesWithCostCentersTableAdapter.Connection = new SqlConnection(FacessoGeneric.SQLConnectionString);
            this.EmployeesWithCostCentersTableAdapter.Fill(this.MasterDataSet.EmployeesWithCostCenters);
            this.rvEmployees.RefreshReport();
        }

        public ReportEmployeeMasterData()
        {
            this.Load += ReportEmployeeMasterData_Load;
            InitializeComponent();
        }
    }
}
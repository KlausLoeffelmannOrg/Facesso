using Facesso.Data;
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

namespace Facesso.Functions
{
    public partial class frmEmployeePicker
    {
        public frmEmployeePicker()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            this.AcceptButton = ucEmployeePicker.btnOK;
            this.CancelButton = ucEmployeePicker.btnCancel;
            ucEmployeePicker.btnOK.Click += OKClickHandler;
            ucEmployeePicker.btnCancel.Click += CancelClickHandler;
        }

        public EmployeeInfoItems GetEmployeeSelection()
        {
            using (this)
            {
                ucEmployeePicker.Employees = new EmployeeInfoItems(0);
                this.ShowDialog();
                if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    return ucEmployeePicker.SelectedEmployees;
                }
                else
                {
                    return null;
                }
            }

            return default(EmployeeInfoItems);
        }

        private void OKClickHandler(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CancelClickHandler(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
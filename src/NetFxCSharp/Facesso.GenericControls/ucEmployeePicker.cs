using Facesso.Data;
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
    public partial class ucEmployeePicker
    {
        public ucEmployeePicker()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            elvMain.AutoGroup = true;
            elvMain.MultiSelect = true;
            elvMain.OnlyActiveEmployees = true;
            elvMain.OnlyIncentiveEmployees = true;
        }

        public EmployeeInfoItems Employees
        {
            get
            {
                return elvMain.EmployeeInfoCollection;
            }

            set
            {
                elvMain.EmployeeInfoCollection = value;
            }
        }

        public EmployeeInfo FirstSelectedEmployee
        {
            get
            {
                return elvMain.FirstSelectedEmployee;
            }
        }

        public EmployeeInfoItems SelectedEmployees
        {
            get
            {
                return elvMain.SelectedEmployees;
            }
        }

        private void txtSearchText_TextChanged(System.Object sender, System.EventArgs e)
        {
            string locString = txtSearchText.Text;
            int locPersonnelNr = default(int);
            string[] locParts = default(string[]);
            bool locFlag = default(bool);
            EmployeeInfoItems locEmployees = new EmployeeInfoItems();
            locParts = locString.Split(new char[] { ',', '.', ';' });
            foreach (string _vbForEach_locS in locParts)
            {
                string locS = _vbForEach_locS;
                {
                    if (locS.Trim().Length == 0)
                    {
                        continue;
                    }

                    locS = locS.ToLower();
                    locFlag = int.TryParse(locS, out locPersonnelNr);
                    foreach (EmployeeInfo locItem in this.Employees)
                    {
                        if (locFlag)
                        {
                            if (locItem.PersonnelNumber == locPersonnelNr)
                            {
                                try
                                {
                                    locEmployees.Add(locItem);
                                }
                                catch (Exception ex)
                                {
                                }

                                break;
                            }
                        }

                        if (locItem.LastName.ToLower().StartsWith(locS))
                        {
                            try
                            {
                                locEmployees.Add(locItem);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }

            elvMain.SetCustomGroup("Gefundene Treffer aus Eingabe", locEmployees);
        }

        private void chkOnlyIncentiveEmployees_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            elvMain.OnlyActiveEmployees = chkOnlyIncentiveEmployees.Checked;
        }
    }
}
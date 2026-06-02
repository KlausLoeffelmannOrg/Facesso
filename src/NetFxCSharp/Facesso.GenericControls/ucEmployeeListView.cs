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
    public class ucEmployeeListView : System.Windows.Forms.ListView
    {
        private bool myAutoGroup;
        private EmployeeInfoItems myEmployeeInfoItems;
        private EmployeeSortOrder myEmployeeSortOrder;
        private byte myMaxDigitsPersonnelNumber;
        private byte myMaxDigitsCostCenterNo;
        private DataTable myDataTable;
        private string myLastSortColumn;
        private CustomListViewGroups<EmployeeInfo> myCustomGroups;
        private int myPersonnelNoGroupingResulution;
        private bool myOnlyActiveEmployees;
        private bool myOnlyIncentiveEmployees;
        public ucEmployeeListView() : base()
        {
            this.FullRowSelect = true;
            this.View = System.Windows.Forms.View.Details;
            this.HideSelection = false;
            myEmployeeSortOrder = EmployeeSortOrder.PersonnelNumber;
            this.Columns.Add("Personal-Nr.:", -2);
            this.Columns.Add("Nachname/Vorname:", -2);
            this.Columns.Add("Kostenstellenname:", -2);
            this.Columns.Add("/-nummer:", -2);
            myLastSortColumn = "PersonnelNumber";
            myAutoGroup = true;
            myPersonnelNoGroupingResulution = 100;
            myOnlyActiveEmployees = true;
            myOnlyIncentiveEmployees = false;
            myCustomGroups = new CustomListViewGroups<EmployeeInfo>();
        }

        public void AddCustomGroup(string GroupName, EmployeeInfoItems eic)
        {
            myCustomGroups.Insert(0, new CustomListViewGroup<EmployeeInfo>(GroupName, eic));
            rebuildList();
        }

        public void SetCustomGroup(string GroupName, EmployeeInfoItems eic)
        {
            if (myCustomGroups.Contains(GroupName))
            {
                myCustomGroups[GroupName].InfoItems = eic;
            }
            else
            {
                myCustomGroups.Add(new CustomListViewGroup<EmployeeInfo>(GroupName, eic));
            }

            rebuildList();
        }

        public void DeleteCustomGroup(string GroupName, bool Refresh)
        {
            if (GroupName == null)
            {
                return;
            }

            if (myCustomGroups.Contains(GroupName))
            {
                this.myCustomGroups.Remove(GroupName);
                if (Refresh)
                {
                    rebuildList();
                }
            }
        }

        public void AddSelectedEmployee(EmployeeInfo Employee)
        {
            foreach (EmployeeListViewItem locELvi in this.SelectedItems)
            {
                if (locELvi.IDEmployee == Employee.IDEmployee)
                {
                    locELvi.Selected = true;
                }
            }
        }

        public EmployeeInfo FirstSelectedEmployee
        {
            get
            {
                if (this.SelectedIndices.Count == 0)
                {
                    return null;
                }

                return this.EmployeeInfoCollection[new ActiveDev.IntKey(((EmployeeListViewItem)this.SelectedItems[0]).IDEmployee)];
            }
        }

        public EmployeeInfoItems SelectedEmployees
        {
            get
            {
                EmployeeInfoItems locLvic = new EmployeeInfoItems();
                foreach (EmployeeListViewItem locLvi in this.SelectedItems)
                {
                    locLvic.Add(this.EmployeeInfoCollection[new ActiveDev.IntKey(((EmployeeListViewItem)locLvi).IDEmployee)]);
                }

                return locLvic;
            }
        }

        public EmployeeInfoItems EmployeeInfoCollection
        {
            get
            {
                return myEmployeeInfoItems;
            }

            set
            {
                myEmployeeInfoItems = value;
                if (value != null)
                {
                    SetMaxDigits();
                    AssignToDataTable();
                }

                rebuildList();
            }
        }

        public EmployeeSortOrder EmployeeSortOrder
        {
            get
            {
                return myEmployeeSortOrder;
            }

            set
            {
                myEmployeeSortOrder = value;
                rebuildList();
            }
        }

        public bool OnlyActiveEmployees
        {
            get
            {
                return myOnlyActiveEmployees;
            }

            set
            {
                myOnlyActiveEmployees = value;
                rebuildList();
            }
        }

        public bool OnlyIncentiveEmployees
        {
            get
            {
                return myOnlyIncentiveEmployees;
            }

            set
            {
                myOnlyIncentiveEmployees = value;
                rebuildList();
            }
        }

        public bool AutoGroup
        {
            get
            {
                return myAutoGroup;
            }

            set
            {
                myAutoGroup = value;
            }
        }

        private void rebuildList()
        {
            this.BeginUpdate();
            this.Items.Clear();
            this.Groups.Clear();
            if (myDataTable == null)
            {
                this.EndUpdate();
                return;
            }

            foreach (DataRow locRow in myDataTable.Rows)
            {
                if (myCustomGroups == null)
                {
                    locRow["GroupNameIndex"] = 0;
                }
                else
                {
                    locRow["GroupNameIndex"] = myCustomGroups.GroupSortIndexOfID(Convert.ToInt32(locRow["IDEmployee"]));
                }
            }

            myDataTable.DefaultView.Sort = "GroupNameIndex DESC, " + EmployeeSortOrder.ToString() + ", " + myLastSortColumn;
            ListViewItem locLastItem = null;
            ListViewGroup locCurrentGroup = null;
            int LastDelta = -1;
            int locCustomGroupIndex = default(int);
            int locOldCustomGroupIndex = -1;
            foreach (DataRowView locRow in myDataTable.DefaultView)
            {
                //TODO: ! Nicht, wenn diese in der Gruppe vorhanden sind!
                if ((!(System.Convert.ToBoolean(locRow["IsActive"]))) & OnlyActiveEmployees)
                {
                    continue;
                }

                //TODO: ! Nicht, wenn diese in der Gruppe vorhanden sind!
                if ((!(System.Convert.ToBoolean(locRow["IsIncentive"]))) & OnlyIncentiveEmployees)
                {
                    continue;
                }

                EmployeeListViewItem locItem = new EmployeeListViewItem(System.Convert.ToInt32(locRow["IDEmployee"]), System.Convert.ToInt32(locRow["PersonnelNumber"]), locRow["LastName"].ToString(), locRow["CostCenterName"].ToString(), System.Convert.ToInt32(locRow["CostCenterNo"]));
                if (!(Convert.ToBoolean(locRow["IsIncentive"])))
                {
                    locItem.ForeColor = Color.Blue;
                }

                if (!(Convert.ToBoolean(locRow["IsActive"])))
                {
                    locItem.ForeColor = Color.DarkGray;
                }

                this.Items.Add(locItem);
                //Die Gruppen bilden, falls es sich um die dafür richtige Sortierung handelt
                if (AutoGroup)
                {
                    locCustomGroupIndex = System.Convert.ToInt32(locRow["GroupNameIndex"]);
                    if (locCustomGroupIndex != locOldCustomGroupIndex)
                    {
                        if (locCustomGroupIndex > 0)
                        {
                            locCurrentGroup = new ListViewGroup(myCustomGroups[locCustomGroupIndex - 1].GroupName);
                            this.Groups.Add(locCurrentGroup);
                        }
                        else
                        {
                            locCurrentGroup = null;
                        }
                    }

                    locOldCustomGroupIndex = locCustomGroupIndex;
                    if (locCustomGroupIndex > 0)
                    {
                        locItem.Group = locCurrentGroup;
                        this.SelectedIndices.Add(locItem.Index);
                    }
                    else
                    {
                        if (this.EmployeeSortOrder == EmployeeSortOrder.LastName | this.EmployeeSortOrder == EmployeeSortOrder.CostCenterName | this.EmployeeSortOrder == EmployeeSortOrder.PersonnelNumber | this.EmployeeSortOrder == EmployeeSortOrder.CostCenterNo)
                        {
                            if (this.EmployeeSortOrder == EmployeeSortOrder.PersonnelNumber)
                            {
                                locItem.Tag = System.Convert.ToInt32(locRow["PersonnelNumber"]) / myPersonnelNoGroupingResulution;
                            }
                            else if (this.EmployeeSortOrder == EmployeeSortOrder.LastName)
                            {
                                locItem.Tag = Microsoft.VisualBasic.Strings.AscW(locRow["LastName"].ToString());
                            }
                            else if (this.EmployeeSortOrder == EmployeeSortOrder.CostCenterNo)
                            {
                                locItem.Tag = System.Convert.ToInt32(locRow["CostCenterNo"]);
                            }
                            else if (this.EmployeeSortOrder == EmployeeSortOrder.CostCenterName)
                            {
                                locItem.Tag = System.Convert.ToString(locRow["CostCenterName"]);
                            }

                            if (locCurrentGroup == null)
                            {
                                if (this.EmployeeSortOrder == EmployeeSortOrder.PersonnelNumber)
                                {
                                    locCurrentGroup = new ListViewGroup("Mitarbeiter ab Nummer:" + locRow["PersonnelNumber"].ToString());
                                    this.Groups.Add(locCurrentGroup);
                                }
                                else if (this.EmployeeSortOrder == EmployeeSortOrder.LastName)
                                {
                                    int locCharValue = Microsoft.VisualBasic.Strings.AscW(locRow["LastName"].ToString());
                                    locCurrentGroup = new ListViewGroup("Mitarbeiter alphabetisch:" + Microsoft.VisualBasic.Strings.ChrW(locCharValue));
                                    this.Groups.Add(locCurrentGroup);
                                }
                                else if (this.EmployeeSortOrder == EmployeeSortOrder.CostCenterName)
                                {
                                    locCurrentGroup = new ListViewGroup("Mitarbeiter mit Kostenstellen namens:" + locRow["CostCenterName"].ToString());
                                    this.Groups.Add(locCurrentGroup);
                                }
                                else if (this.EmployeeSortOrder == EmployeeSortOrder.CostCenterNo)
                                {
                                    locCurrentGroup = new ListViewGroup("Mitarbeiter ab Kostenstellennr:" + locRow["CostCenterNo"].ToString());
                                    this.Groups.Add(locCurrentGroup);
                                }
                            }

                            if (locLastItem != null)
                            {
                                if (this.EmployeeSortOrder == EmployeeSortOrder.PersonnelNumber)
                                {
                                    if (LastDelta > -1)
                                    {
                                        if (LastDelta != (System.Convert.ToInt32(locItem.Tag) * myPersonnelNoGroupingResulution - System.Convert.ToInt32(locLastItem.Tag) * myPersonnelNoGroupingResulution))
                                        {
                                            locCurrentGroup = new ListViewGroup("Mitarbeiter ab Nummer:" + locRow["PersonnelNumber"].ToString());
                                            this.Groups.Add(locCurrentGroup);
                                            goto Label;
                                        }
                                    }
                                }
                                else if (this.EmployeeSortOrder == EmployeeSortOrder.LastName)
                                {
                                    int locCharValue = Microsoft.VisualBasic.Strings.AscW(locRow["LastName"].ToString());
                                    if (locCharValue != System.Convert.ToInt32(locLastItem.Tag))
                                    {
                                        locCurrentGroup = new ListViewGroup("Mitarbeiter alphabetisch:" + Microsoft.VisualBasic.Strings.ChrW(locCharValue));
                                        this.Groups.Add(locCurrentGroup);
                                    }
                                }
                                else if (this.EmployeeSortOrder == EmployeeSortOrder.CostCenterName)
                                {
                                    if (locRow["CostCenterName"].ToString() != System.Convert.ToString(locLastItem.Tag))
                                    {
                                        locCurrentGroup = new ListViewGroup("Mitarbeiter mit Kostenstellen namens:" + locRow["CostCenterName"].ToString());
                                        this.Groups.Add(locCurrentGroup);
                                    }
                                }
                                else if (this.EmployeeSortOrder == EmployeeSortOrder.CostCenterNo)
                                {
                                    if (System.Convert.ToInt32(locItem.Tag) != System.Convert.ToInt32(locLastItem.Tag))
                                    {
                                        locCurrentGroup = new ListViewGroup("Mitarbeiter ab Kostenstellennr:" + locRow["CostCenterNo"].ToString());
                                        this.Groups.Add(locCurrentGroup);
                                        goto Label;
                                    }
                                }

                                if (this.EmployeeSortOrder == EmployeeSortOrder.PersonnelNumber | this.EmployeeSortOrder == EmployeeSortOrder.CostCenterNo)
                                {
                                    LastDelta = System.Convert.ToInt32(locItem.Tag) * myPersonnelNoGroupingResulution - System.Convert.ToInt32(locLastItem.Tag) * myPersonnelNoGroupingResulution;
                                }
                            }

                            Label:
                                locItem.Group = locCurrentGroup;
                            locLastItem = locItem;
                        }
                    }
                }
            }

            this.Columns[0].Width = -2;
            this.Columns[1].Width = -2;
            this.Columns[2].Width = -2;
            this.Columns[3].Width = -2;
            this.EndUpdate();
        }

        private void AssignToDataTable()
        {
            myDataTable = new DataTable();
            {
                var __with0 = myDataTable.Columns;
                __with0.Add("IDEmployee", typeof(int));
                __with0.Add("PersonnelNumber", typeof(string));
                __with0.Add("LastName", typeof(string));
                __with0.Add("CostCenterName", typeof(string));
                __with0.Add("CostCenterNo", typeof(string));
                __with0.Add("GroupNameIndex", typeof(int));
                __with0.Add("IsActive", typeof(bool));
                __with0.Add("IsIncentive", typeof(bool));
            }

            foreach (EmployeeInfo locEi in myEmployeeInfoItems)
            {
                DataRow locTc = myDataTable.NewRow();
                locTc["IDEmployee"] = locEi.IDEmployee;
                locTc["PersonnelNumber"] = locEi.PersonnelNumber.ToString(new string ('0', myMaxDigitsPersonnelNumber));
                locTc["LastName"] = locEi.LastName + ", " + locEi.FirstName;
                locTc["CostCenterName"] = locEi.CostCenterName;
                locTc["CostCenterNo"] = locEi.CostCenterNo.ToString(new string ('0', myMaxDigitsCostCenterNo));
                locTc["IsActive"] = locEi.IsActive;
                locTc["IsIncentive"] = locEi.IsIncentive;
                myDataTable.Rows.Add(locTc);
            }
        }

        //Ermittelt die höchste Anzahl der Ziffern in der Liste
        private void SetMaxDigits()
        {
            myMaxDigitsCostCenterNo = 0;
            myMaxDigitsPersonnelNumber = 0;
            foreach (EmployeeInfo locWgi in myEmployeeInfoItems)
            {
                if (locWgi.CostCenterNo.ToString().Length > myMaxDigitsCostCenterNo)
                {
                    myMaxDigitsCostCenterNo = System.Convert.ToByte(locWgi.CostCenterNo.ToString().Length);
                }

                if (locWgi.PersonnelNumber.ToString().Length > myMaxDigitsPersonnelNumber)
                {
                    myMaxDigitsPersonnelNumber = System.Convert.ToByte(locWgi.PersonnelNumber.ToString().Length);
                }
            }
        }

        protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);
            myLastSortColumn = this.EmployeeSortOrder.ToString();
            this.EmployeeSortOrder = ((EmployeeSortOrder)Enum.ToObject(typeof(EmployeeSortOrder), e.Column));
        }
    }

    public class EmployeeListViewItem : ListViewItem
    {
        private int _IDEmployee;
        public EmployeeListViewItem(int IDEmployee, int PersonnelNumber, string LastName, string CostCenterName, int CostCenterNo) : base(PersonnelNumber.ToString())
        {
            _IDEmployee = IDEmployee;
            this.SubItems.Add(LastName);
            this.SubItems.Add(CostCenterName);
            this.SubItems.Add(CostCenterNo.ToString());
        }

        public int IDEmployee
        {
            get
            {
                return _IDEmployee;
            }

            set
            {
                _IDEmployee = value;
            }
        }
    }

    public enum EmployeeSortOrder
    {
        PersonnelNumber,
        LastName,
        CostCenterName,
        CostCenterNo,
    }
}
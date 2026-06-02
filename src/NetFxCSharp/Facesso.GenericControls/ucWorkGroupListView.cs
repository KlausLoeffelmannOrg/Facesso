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
    public class ucWorkGroupListView : System.Windows.Forms.ListView
    {
        private bool myAutoGroup;
        private WorkGroupInfoItems myWorkGroupInfoCollection;
        private WorkGroupSortOrder myWorkGroupSortOrder;
        private byte myMaxDigitsWorkGroupNo;
        private byte myMaxDigitsCostCenterNo;
        private DataTable myDataTable;
        private string myLastSortColumn;
        private bool myOnlyActiveWorkgroups;
        private int myWorkGroupNoGroupingResolution;
        public ucWorkGroupListView() : base()
        {
            this.FullRowSelect = true;
            this.View = System.Windows.Forms.View.Details;
            this.HideSelection = false;
            myWorkGroupSortOrder = WorkGroupSortOrder.WorkGroupNumber;
            this.Columns.Add("Produktiv-Site-Nr.:", -2);
            this.Columns.Add("Produktiv-Site-Name:", -2);
            this.Columns.Add("Kostenstellenname:", -2);
            this.Columns.Add("/nummer:", -2);
            myLastSortColumn = "WorkGroupNumber";
            myAutoGroup = true;
            myOnlyActiveWorkgroups = true;
            myWorkGroupNoGroupingResolution = 10;
        }

        public WorkGroupInfo FirstSelectedWorkGroup
        {
            get
            {
                if (this.SelectedIndices.Count == 0)
                {
                    return null;
                }

                return this.WorkGroupInfoItems[new ActiveDev.IntKey(int.Parse(this.SelectedItems[0].Name))];
            }
        }

        public WorkGroupInfoItems SelectedWorkGroups
        {
            get
            {
                WorkGroupInfoItems locLvic = new WorkGroupInfoItems();
                foreach (ListViewItem locLvi in this.SelectedItems)
                {
                    locLvic.Add(this.WorkGroupInfoItems[new ActiveDev.IntKey(int.Parse(locLvi.Name))]);
                }

                return locLvic;
            }
        }

        public WorkGroupInfoItems CheckedWorkGroups
        {
            get
            {
                WorkGroupInfoItems locLvic = new WorkGroupInfoItems();
                foreach (ListViewItem locLvi in this.CheckedItems)
                {
                    locLvic.Add(this.WorkGroupInfoItems[new ActiveDev.IntKey(int.Parse(locLvi.Name))]);
                }

                return locLvic;
            }
        }

        public WorkGroupInfoItems WorkGroupInfoItems
        {
            get
            {
                return myWorkGroupInfoCollection;
            }

            set
            {
                myWorkGroupInfoCollection = value;
                if (value != null)
                {
                    SetMaxDigits();
                    AssignToDataTable();
                }

                rebuildList();
            }
        }

        public WorkGroupSortOrder WorkGroupSortOrder
        {
            get
            {
                return myWorkGroupSortOrder;
            }

            set
            {
                myWorkGroupSortOrder = value;
                rebuildList();
            }
        }

        public bool OnlyActiveWorkgroups
        {
            get
            {
                return myOnlyActiveWorkgroups;
            }

            set
            {
                myOnlyActiveWorkgroups = value;
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

            myDataTable.DefaultView.Sort = WorkGroupSortOrder.ToString() + ", " + myLastSortColumn;
            ListViewItem locLastItem = null;
            ListViewGroup locCurrentGroup = null;
            int LastDelta = -1;
            foreach (DataRowView locRow in myDataTable.DefaultView)
            {
                if (OnlyActiveWorkgroups & (!(System.Convert.ToBoolean(locRow["IsActive"]))))
                {
                    continue;
                }

                ListViewItem locItem = new ListViewItem(locRow["WorkGroupNumber"].ToString());
                locItem.SubItems.Add(locRow["WorkGroupName"].ToString());
                locItem.SubItems.Add(locRow["CostCenterName"].ToString());
                locItem.SubItems.Add(locRow["CostCenterNo"].ToString());
                locItem.Name = locRow["IDWorkGroup"].ToString();
                if (Convert.ToBoolean(locRow["HasProductionData"]))
                {
                    locItem.Font = new Font(locItem.Font, FontStyle.Bold);
                }

                if (!(Convert.ToBoolean(locRow["IsActive"])))
                {
                    locItem.ForeColor = Color.DarkGray;
                }

                this.Items.Add(locItem);
                //Die Gruppen bilden, falls es sich um die dafür richtige Sortierung handelt
                if (AutoGroup)
                {
                    if (this.WorkGroupSortOrder == WorkGroupSortOrder.WorkGroupName | this.WorkGroupSortOrder == WorkGroupSortOrder.CostCenterName | this.WorkGroupSortOrder == WorkGroupSortOrder.WorkGroupNumber | this.WorkGroupSortOrder == WorkGroupSortOrder.CostCenterNo)
                    {
                        if (this.WorkGroupSortOrder == WorkGroupSortOrder.WorkGroupNumber)
                        {
                            locItem.Tag = System.Convert.ToInt32(locRow["WorkGroupNumber"]) / myWorkGroupNoGroupingResolution;
                        }
                        else if (this.WorkGroupSortOrder == WorkGroupSortOrder.WorkGroupName)
                        {
                            locItem.Tag = Microsoft.VisualBasic.Strings.AscW(locRow["WorkGroupName"].ToString());
                        }
                        else if (this.WorkGroupSortOrder == WorkGroupSortOrder.CostCenterNo)
                        {
                            locItem.Tag = System.Convert.ToInt32(locRow["CostCenterNo"]);
                        }
                        else if (this.WorkGroupSortOrder == WorkGroupSortOrder.CostCenterName)
                        {
                            locItem.Tag = System.Convert.ToString(locRow["CostCenterName"]);
                        }

                        if (locCurrentGroup == null)
                        {
                            if (this.WorkGroupSortOrder == WorkGroupSortOrder.WorkGroupNumber)
                            {
                                locCurrentGroup = new ListViewGroup("Produktiv-Sites ab Nummer:" + locRow["WorkGroupNumber"].ToString());
                                this.Groups.Add(locCurrentGroup);
                            }
                            else if (this.WorkGroupSortOrder == WorkGroupSortOrder.WorkGroupName)
                            {
                                int locCharValue = Microsoft.VisualBasic.Strings.AscW(locRow["WorkGroupName"].ToString());
                                locCurrentGroup = new ListViewGroup("Produktiv-Sites alphabetisch:" + Microsoft.VisualBasic.Strings.ChrW(locCharValue));
                                this.Groups.Add(locCurrentGroup);
                            }
                            else if (this.WorkGroupSortOrder == WorkGroupSortOrder.CostCenterName)
                            {
                                locCurrentGroup = new ListViewGroup("Produktiv-Sites mit Kostenstellen namens:" + locRow["CostCenterName"].ToString());
                                this.Groups.Add(locCurrentGroup);
                            }
                            else if (this.WorkGroupSortOrder == WorkGroupSortOrder.CostCenterNo)
                            {
                                locCurrentGroup = new ListViewGroup("Produktiv-Sites ab Kostenstellennr:" + locRow["CostCenterNo"].ToString());
                                this.Groups.Add(locCurrentGroup);
                            }
                        }

                        if (locLastItem != null)
                        {
                            if (this.WorkGroupSortOrder == WorkGroupSortOrder.WorkGroupNumber)
                            {
                                if (LastDelta > -1)
                                {
                                    if (LastDelta != (System.Convert.ToInt32(locItem.Tag) * myWorkGroupNoGroupingResolution - System.Convert.ToInt32(locLastItem.Tag) * myWorkGroupNoGroupingResolution))
                                    {
                                        locCurrentGroup = new ListViewGroup("Produktiv-Sites ab Nummer:" + locRow["WorkGroupNumber"].ToString());
                                        this.Groups.Add(locCurrentGroup);
                                        goto Label;
                                    }
                                }
                            }
                            else if (this.WorkGroupSortOrder == WorkGroupSortOrder.WorkGroupName)
                            {
                                int locCharValue = Microsoft.VisualBasic.Strings.AscW(locRow["WorkGroupName"].ToString());
                                if (locCharValue != System.Convert.ToInt32(locLastItem.Tag))
                                {
                                    locCurrentGroup = new ListViewGroup("Produktiv-Sites alphabetisch:" + Microsoft.VisualBasic.Strings.ChrW(locCharValue));
                                    this.Groups.Add(locCurrentGroup);
                                }
                            }
                            else if (this.WorkGroupSortOrder == WorkGroupSortOrder.CostCenterName)
                            {
                                if (locRow["CostCenterName"].ToString() != System.Convert.ToString(locLastItem.Tag))
                                {
                                    locCurrentGroup = new ListViewGroup("Produktiv-Sites mit Kostenstellen namens:" + locRow["CostCenterName"].ToString());
                                    this.Groups.Add(locCurrentGroup);
                                }
                            }
                            else if (this.WorkGroupSortOrder == WorkGroupSortOrder.CostCenterNo)
                            {
                                if (System.Convert.ToInt32(locItem.Tag) != System.Convert.ToInt32(locLastItem.Tag))
                                {
                                    locCurrentGroup = new ListViewGroup("Produktiv-Sites ab Kostenstellennr:" + locRow["CostCenterNo"].ToString());
                                    this.Groups.Add(locCurrentGroup);
                                    goto Label;
                                }
                            }

                            if (this.WorkGroupSortOrder == WorkGroupSortOrder.WorkGroupNumber | this.WorkGroupSortOrder == WorkGroupSortOrder.CostCenterNo)
                            {
                                LastDelta = System.Convert.ToInt32(locItem.Tag) * myWorkGroupNoGroupingResolution - System.Convert.ToInt32(locLastItem.Tag) * myWorkGroupNoGroupingResolution;
                            }
                        }

                        Label:
                            locItem.Group = locCurrentGroup;
                        locLastItem = locItem;
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
                __with0.Add("IDWorkGroup", typeof(int));
                __with0.Add("WorkGroupNumber", typeof(string));
                __with0.Add("WorkGroupName", typeof(string));
                __with0.Add("CostCenterName", typeof(string));
                __with0.Add("CostCenterNo", typeof(string));
                __with0.Add("HasProductionData", typeof(bool));
                __with0.Add("IsActive", typeof(bool));
            }

            foreach (WorkGroupInfo locWgi in myWorkGroupInfoCollection)
            {
                DataRow locTc = myDataTable.NewRow();
                locTc["IDWorkGroup"] = locWgi.IDWorkGroup;
                locTc["WorkGroupNumber"] = locWgi.WorkGroupNumber.ToString(new string ('0', myMaxDigitsWorkGroupNo));
                locTc["WorkGroupName"] = locWgi.WorkGroupName;
                locTc["CostCenterName"] = locWgi.CostCenterName;
                locTc["CostCenterNo"] = locWgi.CostCenterNo.ToString(new string ('0', myMaxDigitsCostCenterNo));
                locTc["HasProductionData"] = locWgi.HasProductionData;
                locTc["IsActive"] = locWgi.IsActive;
                myDataTable.Rows.Add(locTc);
            }
        }

        //Ermittelt die höchste Anzahl der Ziffern in der Liste
        private void SetMaxDigits()
        {
            myMaxDigitsCostCenterNo = 0;
            myMaxDigitsWorkGroupNo = 0;
            foreach (WorkGroupInfo locWgi in myWorkGroupInfoCollection)
            {
                if (locWgi.CostCenterNo.ToString().Length > myMaxDigitsCostCenterNo)
                {
                    myMaxDigitsCostCenterNo = System.Convert.ToByte(locWgi.CostCenterNo.ToString().Length);
                }

                if (locWgi.WorkGroupNumber.ToString().Length > myMaxDigitsWorkGroupNo)
                {
                    myMaxDigitsWorkGroupNo = System.Convert.ToByte(locWgi.WorkGroupNumber.ToString().Length);
                }
            }
        }

        protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);
            myLastSortColumn = this.WorkGroupSortOrder.ToString();
            this.WorkGroupSortOrder = ((WorkGroupSortOrder)Enum.ToObject(typeof(WorkGroupSortOrder), e.Column));
        }
    }

    public enum WorkGroupSortOrder
    {
        WorkGroupNumber,
        WorkGroupName,
        CostCenterName,
        CostCenterNo,
    }
}
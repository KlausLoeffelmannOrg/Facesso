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
    public class ucCostCenterListView : System.Windows.Forms.ListView
    {
        private bool myAutoGroup;
        private CostcenterInfoItems myCostCenterInfoCollection;
        private CostCenterSortOrder myCostCenterSortOrder;
        private byte myMaxDigitsCostCenterNo;
        private DataTable myDataTable;
        private string myLastSortColumn;
        private int myCostCenterNoGroupingResolution;
        public ucCostCenterListView() : base()
        {
            this.FullRowSelect = true;
            this.View = System.Windows.Forms.View.Details;
            this.HideSelection = false;
            myCostCenterSortOrder = CostCenterSortOrder.CostCenterNumber;
            this.Columns.Add("Nr.:", -2);
            this.Columns.Add("Kostenstellenname:", -2);
            this.Columns.Add("Beschreibung:", -2);
            myLastSortColumn = "CostCenterNumber";
            myAutoGroup = true;
            myCostCenterNoGroupingResolution = 10;
        }

        public CostcenterInfo FirstSelectedCostCenter
        {
            get
            {
                if (this.SelectedIndices.Count == 0)
                {
                    return null;
                }

                return this.CostCenterInfoCollection[new ActiveDev.IntKey(int.Parse(this.SelectedItems[0].Name))];
            }
        }

        public CostcenterInfoItems SelectedCostCenters
        {
            get
            {
                CostcenterInfoItems locLvic = new CostcenterInfoItems();
                foreach (ListViewItem locLvi in this.SelectedItems)
                {
                    locLvic.Add(this.CostCenterInfoCollection[new ActiveDev.IntKey(int.Parse(locLvi.Name))]);
                }

                return locLvic;
            }
        }

        public CostcenterInfoItems CostCenterInfoCollection
        {
            get
            {
                return myCostCenterInfoCollection;
            }

            set
            {
                myCostCenterInfoCollection = value;
                if (value != null)
                {
                    SetMaxDigits();
                    AssignToDataTable();
                }

                rebuildList();
            }
        }

        public CostCenterSortOrder CostCenterSortOrder
        {
            get
            {
                return myCostCenterSortOrder;
            }

            set
            {
                myCostCenterSortOrder = value;
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

            myDataTable.DefaultView.Sort = CostCenterSortOrder.ToString() + ", " + myLastSortColumn;
            ListViewItem locLastItem = null;
            ListViewGroup locCurrentGroup = null;
            int LastDelta = -1;
            foreach (DataRowView locRow in myDataTable.DefaultView)
            {
                ListViewItem locItem = new ListViewItem(locRow["CostCenterNumber"].ToString());
                locItem.SubItems.Add(locRow["CostCenterName"].ToString());
                locItem.SubItems.Add(locRow["CostCenterDescription"].ToString());
                locItem.Name = locRow["IDCostCenter"].ToString();
                this.Items.Add(locItem);
                //Die Gruppen bilden, falls es sich um die daf�r richtige Sortierung handelt
                if (AutoGroup)
                {
                    if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterName | this.CostCenterSortOrder == CostCenterSortOrder.CostCenterNumber | this.CostCenterSortOrder == CostCenterSortOrder.CostCenterDescription)
                    {
                        if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterNumber)
                        {
                            locItem.Tag = System.Convert.ToInt32(locRow["CostCenterNumber"]) / myCostCenterNoGroupingResolution;
                        }
                        else if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterName)
                        {
                            locItem.Tag = Microsoft.VisualBasic.Strings.AscW(locRow["CostCenterName"].ToString());
                        }
                        else if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterDescription)
                        {
                            locItem.Tag = System.Convert.ToString(locRow["CostCenterDescription"]);
                        }

                        if (locCurrentGroup == null)
                        {
                            if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterNumber)
                            {
                                locCurrentGroup = new ListViewGroup("Kostenstellen ab Nummer:" + locRow["CostCenterNumber"].ToString());
                                this.Groups.Add(locCurrentGroup);
                            }
                            else if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterName)
                            {
                                int locCharValue = Microsoft.VisualBasic.Strings.AscW(locRow["CostCenterName"].ToString());
                                locCurrentGroup = new ListViewGroup("Kostenstellennamen alphabetisch:" + Microsoft.VisualBasic.Strings.ChrW(locCharValue));
                                this.Groups.Add(locCurrentGroup);
                            }
                            else if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterDescription)
                            {
                                locCurrentGroup = new ListViewGroup("Kostenstellenbeschreibungen alphabetisch:" + locRow["CostCenterDescription"].ToString());
                                this.Groups.Add(locCurrentGroup);
                            }
                        }

                        if (locLastItem != null)
                        {
                            if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterNumber)
                            {
                                if (LastDelta > -1)
                                {
                                    if (LastDelta != (System.Convert.ToInt32(locItem.Tag) * myCostCenterNoGroupingResolution - System.Convert.ToInt32(locLastItem.Tag) * myCostCenterNoGroupingResolution))
                                    {
                                        locCurrentGroup = new ListViewGroup("Kostenstellen ab Nummer:" + locRow["CostCenterNumber"].ToString());
                                        this.Groups.Add(locCurrentGroup);
                                        goto Label;
                                    }
                                }
                            }
                            else if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterName)
                            {
                                int locCharValue = Microsoft.VisualBasic.Strings.AscW(locRow["CostCenterName"].ToString());
                                if (locCharValue != System.Convert.ToInt32(locLastItem.Tag))
                                {
                                    locCurrentGroup = new ListViewGroup("ProduktivKostenstellennamen alphabetisch:" + Microsoft.VisualBasic.Strings.ChrW(locCharValue));
                                    this.Groups.Add(locCurrentGroup);
                                }
                            }
                            else if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterDescription)
                            {
                                if (locRow["CostCenterDescription"].ToString() != System.Convert.ToString(locLastItem.Tag))
                                {
                                    locCurrentGroup = new ListViewGroup("Kostenstellenbeschreibungen alphabetisch:" + locRow["CostCenterDescription"].ToString());
                                    this.Groups.Add(locCurrentGroup);
                                }
                            }

                            if (this.CostCenterSortOrder == CostCenterSortOrder.CostCenterNumber)
                            {
                                LastDelta = System.Convert.ToInt32(locItem.Tag) * myCostCenterNoGroupingResolution - System.Convert.ToInt32(locLastItem.Tag) * myCostCenterNoGroupingResolution;
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
            this.EndUpdate();
        }

        private void AssignToDataTable()
        {
            myDataTable = new DataTable();
            {
                var __with0 = myDataTable.Columns;
                __with0.Add("IDCostCenter", typeof(int));
                __with0.Add("CostCenterNumber", typeof(string));
                __with0.Add("CostCenterName", typeof(string));
                __with0.Add("CostCenterDescription", typeof(string));
            }

            foreach (CostcenterInfo locWgi in myCostCenterInfoCollection)
            {
                DataRow locTc = myDataTable.NewRow();
                locTc["IDCostCenter"] = locWgi.IDCostCenter;
                locTc["CostCenterNumber"] = locWgi.CostCenterNo;
                locTc["CostCenterName"] = locWgi.CostCenterName;
                locTc["CostCenterDescription"] = locWgi.CostCenterDescription;
                myDataTable.Rows.Add(locTc);
            }
        }

        //Ermittelt die h�chste Anzahl der Ziffern in der Liste
        private void SetMaxDigits()
        {
            myMaxDigitsCostCenterNo = 0;
            foreach (CostcenterInfo locWgi in myCostCenterInfoCollection)
            {
                if (locWgi.CostCenterNo.ToString().Length > myMaxDigitsCostCenterNo)
                {
                    myMaxDigitsCostCenterNo = System.Convert.ToByte(locWgi.CostCenterNo.ToString().Length);
                }
            }
        }

        protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);
            myLastSortColumn = this.CostCenterSortOrder.ToString();
            this.CostCenterSortOrder = ((CostCenterSortOrder)Enum.ToObject(typeof(CostCenterSortOrder), e.Column));
        }
    }

    public enum CostCenterSortOrder
    {
        CostCenterNumber,
        CostCenterName,
        CostCenterDescription,
    }
}
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
    public class ucLabourValueListView : System.Windows.Forms.ListView
    {
        private bool myAutoGroup;
        private LabourValueInfoCollection myLabourValueInfoCollection;
        private LabourValuesSortOrder myLabourValueSortOrder;
        private byte myMaxDigitsLabourValueNo;
        private byte myMaxDigitsCostCenterNo;
        private DataTable myDataTable;
        private string myLastSortColumn;
        public ucLabourValueListView() : base()
        {
            this.FullRowSelect = true;
            this.HideSelection = false;
            this.View = System.Windows.Forms.View.Details;
            myLabourValueSortOrder = LabourValuesSortOrder.LabourValueNumber;
            this.Columns.Add("Arbeitswert-Nr.:", -2);
            this.Columns.Add("Arbeitswert-Name/Tätigkeits-Beschreibung:", -2);
            this.Columns.Add("Kostenstellenname:", -2);
            this.Columns.Add("/nummer:", -2);
            this.Columns.Add("Basiswertname", -2);
            this.Columns.Add("Basiswert", -2);
            this.Columns.Add("Einheit", -2);
            myLastSortColumn = "LabourValueNumber";
            myAutoGroup = true;
        }

        public LabourValuesSortOrder LabourValueSortOrder
        {
            get
            {
                return myLabourValueSortOrder;
            }

            set
            {
                myLabourValueSortOrder = value;
                rebuildList();
            }
        }

        public LabourValueInfoCollection LabourValues
        {
            get
            {
                return myLabourValueInfoCollection;
            }

            set
            {
                myLabourValueInfoCollection = value;
                if (value != null)
                {
                    SetMaxDigits();
                }

                AssignToDataTable();
                rebuildList();
            }
        }

        public LabourValueInfo FirstSelectedLabourValue
        {
            get
            {
                if (this.SelectedIndices.Count == 0)
                {
                    return null;
                }

                return this.LabourValues[new ActiveDev.IntKey(int.Parse(this.SelectedItems[0].Name))];
            }
        }

        public LabourValueInfoCollection SelectedLabourValues
        {
            get
            {
                LabourValueInfoCollection locLvic = new LabourValueInfoCollection();
                foreach (ListViewItem locLvi in this.SelectedItems)
                {
                    locLvic.Add(this.LabourValues[new ActiveDev.IntKey(int.Parse(locLvi.Name))]);
                }

                return locLvic;
            }
        }

        public void SelectLabourValue(LabourValueInfo labourValue, bool EnsureVisible)
        {
            foreach (ListViewItem locLvi in this.SelectedItems)
            {
                if (int.Parse(locLvi.Name) == labourValue.IDLabourValue)
                {
                    locLvi.Selected = true;
                    if (EnsureVisible)
                    {
                        locLvi.EnsureVisible();
                    }
                }
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
                rebuildList();
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

            myDataTable.DefaultView.Sort = LabourValueSortOrder.ToString() + ", " + myLastSortColumn;
            ListViewItem locLastItem = null;
            ListViewGroup locCurrentGroup = null;
            int LastDelta = -1;
            foreach (DataRowView locRow in myDataTable.DefaultView)
            {
                ListViewItem locItem = new ListViewItem(locRow["LabourValueNumber"].ToString());
                locItem.SubItems.Add(locRow["LabourValueName"].ToString());
                locItem.SubItems.Add(locRow["CostCenterName"].ToString());
                locItem.SubItems.Add(locRow["CostCenterNo"].ToString());
                locItem.SubItems.Add(locRow["BaseValueSynonym"].ToString());
                locItem.SubItems.Add(locRow["TeHMin"].ToString());
                locItem.SubItems.Add(locRow["Dimension"].ToString());
                locItem.Name = locRow["IDLabourValue"].ToString();
                this.Items.Add(locItem);
                //Die Gruppen bilden, falls es sich um die dafür richtige Sortierung handelt
                if (AutoGroup)
                {
                    if (this.LabourValueSortOrder == LabourValuesSortOrder.LabourValueName | this.LabourValueSortOrder == LabourValuesSortOrder.CostCenterName | this.LabourValueSortOrder == LabourValuesSortOrder.LabourValueNumber | this.LabourValueSortOrder == LabourValuesSortOrder.CostCenterNo)
                    {
                        if (this.LabourValueSortOrder == LabourValuesSortOrder.LabourValueNumber)
                        {
                            locItem.Tag = System.Convert.ToInt32(locRow["LabourValueNumber"]);
                        }
                        else if (this.LabourValueSortOrder == LabourValuesSortOrder.LabourValueName)
                        {
                            locItem.Tag = Microsoft.VisualBasic.Strings.AscW(locRow["LabourValueName"].ToString());
                        }
                        else if (this.LabourValueSortOrder == LabourValuesSortOrder.CostCenterNo)
                        {
                            locItem.Tag = System.Convert.ToInt32(locRow["CostCenterNo"]);
                        }
                        else if (this.LabourValueSortOrder == LabourValuesSortOrder.CostCenterName)
                        {
                            locItem.Tag = System.Convert.ToString(locRow["CostCenterName"]);
                        }

                        if (locCurrentGroup == null)
                        {
                            if (this.LabourValueSortOrder == LabourValuesSortOrder.LabourValueNumber)
                            {
                                locCurrentGroup = new ListViewGroup("Arbeitswerte ab Nummer:" + locRow["LabourValueNumber"].ToString());
                                this.Groups.Add(locCurrentGroup);
                            }
                            else if (this.LabourValueSortOrder == LabourValuesSortOrder.LabourValueName)
                            {
                                int locCharValue = Microsoft.VisualBasic.Strings.AscW(locRow["LabourValueName"].ToString());
                                locCurrentGroup = new ListViewGroup("Arbeitswerte alphabetisch:" + Microsoft.VisualBasic.Strings.ChrW(locCharValue));
                                this.Groups.Add(locCurrentGroup);
                            }
                            else if (this.LabourValueSortOrder == LabourValuesSortOrder.CostCenterName)
                            {
                                locCurrentGroup = new ListViewGroup("Arbeitswerte mit Kostenstellen namens:" + locRow["CostCenterName"].ToString());
                                this.Groups.Add(locCurrentGroup);
                            }
                            else if (this.LabourValueSortOrder == LabourValuesSortOrder.CostCenterNo)
                            {
                                locCurrentGroup = new ListViewGroup("Arbeitswerte ab Kostenstellennr:" + locRow["CostCenterNo"].ToString());
                                this.Groups.Add(locCurrentGroup);
                            }
                        }

                        if (locLastItem != null)
                        {
                            if (this.LabourValueSortOrder == LabourValuesSortOrder.LabourValueNumber)
                            {
                                if (LastDelta > -1)
                                {
                                    if (LastDelta != (System.Convert.ToInt32(locItem.Tag) - System.Convert.ToInt32(locLastItem.Tag)))
                                    {
                                        locCurrentGroup = new ListViewGroup("Arbeitswerte ab Nummer:" + locRow["LabourValueNumber"].ToString());
                                        this.Groups.Add(locCurrentGroup);
                                        goto Label;
                                    }
                                }
                            }
                            else if (this.LabourValueSortOrder == LabourValuesSortOrder.LabourValueName)
                            {
                                int locCharValue = Microsoft.VisualBasic.Strings.AscW(locRow["LabourValueName"].ToString());
                                if (locCharValue != System.Convert.ToInt32(locLastItem.Tag))
                                {
                                    locCurrentGroup = new ListViewGroup("Arbeitswerte alphabetisch:" + Microsoft.VisualBasic.Strings.ChrW(locCharValue));
                                    this.Groups.Add(locCurrentGroup);
                                }
                            }
                            else if (this.LabourValueSortOrder == LabourValuesSortOrder.CostCenterName)
                            {
                                if (locRow["CostCenterName"].ToString() != System.Convert.ToString(locLastItem.Tag))
                                {
                                    locCurrentGroup = new ListViewGroup("Arbeitswerte mit Kostenstellen namens:" + locRow["CostCenterName"].ToString());
                                    this.Groups.Add(locCurrentGroup);
                                }
                            }
                            else if (this.LabourValueSortOrder == LabourValuesSortOrder.CostCenterNo)
                            {
                                if (System.Convert.ToInt32(locItem.Tag) != System.Convert.ToInt32(locLastItem.Tag))
                                {
                                    locCurrentGroup = new ListViewGroup("Arbeitswerte ab Kostenstellennr:" + locRow["CostCenterNo"].ToString());
                                    this.Groups.Add(locCurrentGroup);
                                    goto Label;
                                }
                            }

                            if (this.LabourValueSortOrder == LabourValuesSortOrder.LabourValueNumber | this.LabourValueSortOrder == LabourValuesSortOrder.CostCenterNo)
                            {
                                LastDelta = System.Convert.ToInt32(locItem.Tag) - System.Convert.ToInt32(locLastItem.Tag);
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
            this.Columns[4].Width = -1;
            this.Columns[5].Width = -1;
            this.EndUpdate();
        }

        private void AssignToDataTable()
        {
            if (myLabourValueInfoCollection == null)
            {
                myDataTable = null;
                return;
            }

            myDataTable = new DataTable();
            {
                var __with0 = myDataTable.Columns;
                __with0.Add("IDLabourValue", typeof(int));
                __with0.Add("LabourValueNumber", typeof(string));
                __with0.Add("LabourValueName", typeof(string));
                __with0.Add("CostCenterName", typeof(string));
                __with0.Add("CostCenterNo", typeof(string));
                __with0.Add("BaseValueSynonym", typeof(string));
                __with0.Add("TeHMin", typeof(string));
                __with0.Add("Dimension", typeof(string));
            }

            foreach (LabourValueInfo locLbi in myLabourValueInfoCollection)
            {
                DataRow locTc = myDataTable.NewRow();
                locTc["IDLabourValue"] = locLbi.IDLabourValue;
                locTc["LabourValueNumber"] = locLbi.LabourValueNumber.ToString(new string ('0', myMaxDigitsLabourValueNo));
                locTc["LabourValueName"] = locLbi.LabourValueName;
                locTc["CostCenterName"] = locLbi.CostCenterName;
                locTc["CostCenterNo"] = locLbi.CostCenterNo.ToString(new string ('0', myMaxDigitsCostCenterNo));
                locTc["BaseValueSynonym"] = locLbi.BaseValueSynonym;
                locTc["TeHMin"] = locLbi.TeHMin.ToString("#,##0" + Microsoft.VisualBasic.Interaction.IIf(locLbi.BaseValuePrecision == 0, "", "." + new string ('0', locLbi.BaseValuePrecision)).ToString());
                locTc["Dimension"] = locLbi.TeHMin;
                myDataTable.Rows.Add(locTc);
            }
        }

        //TODO: Ausformulieren - Ermittelt die höchste Anzahl der Ziffern in der Liste
        private void SetMaxDigits()
        {
            myMaxDigitsCostCenterNo = 0;
            myMaxDigitsLabourValueNo = 0;
            foreach (LabourValueInfo locLbi in myLabourValueInfoCollection)
            {
                if (locLbi.CostCenterNo.ToString().Length > myMaxDigitsCostCenterNo)
                {
                    myMaxDigitsCostCenterNo = System.Convert.ToByte(locLbi.CostCenterNo.ToString().Length);
                }

                if (locLbi.LabourValueNumber.ToString().Length > myMaxDigitsLabourValueNo)
                {
                    myMaxDigitsLabourValueNo = System.Convert.ToByte(locLbi.LabourValueNumber.ToString().Length);
                }
            }
        }

        protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);
            myLastSortColumn = this.LabourValueSortOrder.ToString();
            this.LabourValueSortOrder = ((LabourValuesSortOrder)Enum.ToObject(typeof(LabourValuesSortOrder), e.Column));
        }
    }

    public enum LabourValuesSortOrder
    {
        LabourValueNumber,
        LabourValueName,
        CostCenterName,
        CostCenterNo,
        BaseValueSynonym,
        TeHMin,
        Dimension,
    }
}
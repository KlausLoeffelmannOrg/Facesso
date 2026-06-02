using ActiveDev;
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
    public class ucTimeLogItemsDataGridView : DataGridView
    {
        private EmployeeTimeLogInfo myEmployeeTimeLogItems;
        private bool mySingleEmployeeList;
        private WorkGroupInfoItems myWorkGroups;
        public delegate void TimeLogItemDoubleClickEventHandler(object sender, TimeLogItemClickEventArgs e);
        public event TimeLogItemDoubleClickEventHandler TimeLogItemDoubleClick;
        public ucTimeLogItemsDataGridView() : base()
        {
            this.DoubleBuffered = true;
        }

        public void AssignData()
        {
            InitializeHeaders();
            if (myWorkGroups == null)
            {
                myWorkGroups = new WorkGroupInfoItems(true);
            }

            if (myEmployeeTimeLogItems == null)
            {
                return;
            }

            foreach (EmployeeTimeLogInfoItem locEi in myEmployeeTimeLogItems)
            {
                this.Rows.Add(new object[] { locEi.IDTimeLog, locEi.EmployeeInfo.PersonnelNumber, locEi.EmployeeInfo.LastName + ", " + locEi.EmployeeInfo.FirstName, myWorkGroups[new IntKey(locEi.IDWorkGroup)].DisplayName, locEi.Shift, locEi.ShiftStart, locEi.ShiftEnd, locEi.WorkBreak, locEi.DownTime, locEi.Handicap, locEi.TimeDeltaStrings });
            }
        }

        public EmployeeTimeLogInfo EmployeeTimeLogItems
        {
            get
            {
                return myEmployeeTimeLogItems;
            }

            set
            {
                if (value == null)
                {
                    this.Rows.Clear();
                    myEmployeeTimeLogItems = null;
                    return;
                }

                this.Rows.Clear();
                myEmployeeTimeLogItems = value;
                AssignData();
            }
        }

        public EmployeeTimeLogInfo SelectedEmployeeTimeLogItems
        {
            get
            {
                EmployeeTimeLogInfo locEtli = new EmployeeTimeLogInfo();
                foreach (DataGridViewRow locRow in this.Rows)
                {
                    if (locRow.Selected)
                    {
                        locEtli.Add(myEmployeeTimeLogItems[System.Convert.ToInt64(this["IDTimeLog", locRow.Index].Value)]);
                    }
                }

                return locEtli;
            }
        }

        public void SelectEmployeeItems(EmployeeTimeLogInfo Etli)
        {
            this.ClearSelection();
            foreach (EmployeeTimeLogInfoItem locSourceRow in Etli)
            {
                foreach (DataGridViewRow locDestRow in this.Rows)
                {
                    if (System.Convert.ToInt64(locDestRow.Cells["IDTimeLog"].Value) == locSourceRow.IDTimeLog)
                    {
                        locDestRow.Selected = true;
                    }
                }
            }
        }

        public bool SingleEmployeeList
        {
            get
            {
                return mySingleEmployeeList;
            }

            set
            {
                if (value != mySingleEmployeeList)
                {
                    mySingleEmployeeList = value;
                    AssignData();
                }
            }
        }

        public void InitializeHeaders()
        {
            DataGridViewColumn locColumn = default(DataGridViewColumn);
            DataGridViewTextBoxCell locDateCell = new DataGridViewTextBoxCell();
            locDateCell.MaxInputLength = 8;
            DataGridViewTextBoxCell locIntCell = new DataGridViewTextBoxCell();
            locIntCell.MaxInputLength = 6;
            Font locHeaderFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            Font locCellFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            this.ColumnHeadersDefaultCellStyle.Font = locHeaderFont;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = false;
            {
                var __with0 = this.Columns;
                __with0.Clear();
                //ID (nicht sichtbar)
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Visible = false;
                locColumn.Name = "IDTimeLog";
                __with0.Add(locColumn);
                //Personalnummer
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 100;
                locColumn.DisplayIndex = 0;
                locColumn.HeaderText = "Pers.-Nr.:";
                locColumn.MinimumWidth = 50;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locHeaderFont;
                locColumn.Name = "PersonnelNr";
                locColumn.Visible = !(SingleEmployeeList);
                __with0.Add(locColumn);
                //Name, Vorname
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 300;
                locColumn.DisplayIndex = 1;
                locColumn.HeaderText = "Name, Vorname:";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "LastnameFirstname";
                locColumn.Visible = !(SingleEmployeeList);
                __with0.Add(locColumn);
                //Produktiv-Site
                locColumn = new DataGridViewColumn(locDateCell);
                locColumn.Width = 150;
                locColumn.DisplayIndex = 2;
                locColumn.HeaderText = "Produktiv-Site";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "ShiftStart";
                locColumn.Visible = mySingleEmployeeList;
                __with0.Add(locColumn);
                //Schicht
                locColumn = new DataGridViewColumn(locIntCell);
                locColumn.Width = 75;
                locColumn.DisplayIndex = 3;
                locColumn.HeaderText = "Schicht";
                locColumn.MinimumWidth = 50;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.DefaultCellStyle.Format = "0";
                locColumn.Visible = SingleEmployeeList;
                locColumn.Name = "Schicht";
                __with0.Add(locColumn);
                //Startzeit
                locColumn = new DataGridViewColumn(locDateCell);
                locColumn.DisplayIndex = 4;
                locColumn.HeaderText = "Start";
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                if (SingleEmployeeList)
                {
                    locColumn.DefaultCellStyle.Format = "dd.MM.yy; HH:mm";
                    locColumn.Width = 120;
                    locColumn.MinimumWidth = 80;
                }
                else
                {
                    locColumn.DefaultCellStyle.Format = "(ddd), HH:mm";
                    locColumn.Width = 75;
                    locColumn.MinimumWidth = 50;
                }

                locColumn.Name = "ShiftStart";
                __with0.Add(locColumn);
                //Endzeit
                locColumn = new DataGridViewColumn(locDateCell);
                locColumn.DisplayIndex = 5;
                locColumn.HeaderText = "Ende";
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                if (SingleEmployeeList)
                {
                    locColumn.DefaultCellStyle.Format = "dd.MM.yy; HH:mm";
                    locColumn.Width = 120;
                    locColumn.MinimumWidth = 80;
                }
                else
                {
                    locColumn.DefaultCellStyle.Format = "(ddd), HH:mm";
                    locColumn.Width = 75;
                    locColumn.MinimumWidth = 50;
                }

                locColumn.Name = "ShiftEnd";
                __with0.Add(locColumn);
                //Pause
                locColumn = new DataGridViewColumn(locIntCell);
                locColumn.Width = 75;
                locColumn.DisplayIndex = 6;
                locColumn.HeaderText = "Pause";
                locColumn.MinimumWidth = 50;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.DefaultCellStyle.Format = "#,##0";
                locColumn.Name = "Pause";
                __with0.Add(locColumn);
                //Ausfallzeit
                locColumn = new DataGridViewColumn(locIntCell);
                locColumn.Width = 75;
                locColumn.DisplayIndex = 7;
                locColumn.HeaderText = "Ausfall";
                locColumn.MinimumWidth = 50;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.DefaultCellStyle.Format = "#,##0";
                locColumn.Name = "DownTime";
                __with0.Add(locColumn);
                //Handycap
                locColumn = new DataGridViewColumn(locIntCell);
                locColumn.Width = 75;
                locColumn.DisplayIndex = 8;
                locColumn.HeaderText = "Handicap";
                locColumn.MinimumWidth = 50;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.DefaultCellStyle.Format = "##0 \\%";
                locColumn.Visible = !(SingleEmployeeList);
                locColumn.Name = "Handycap";
                __with0.Add(locColumn);
                //Zeiten
                locColumn = new DataGridViewColumn(locIntCell);
                locColumn.Width = 150;
                locColumn.DisplayIndex = 9;
                locColumn.HeaderText = "Zeitendelta";
                locColumn.MinimumWidth = 50;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "DeltaTimes";
                __with0.Add(locColumn);
            }

            this.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        protected override void OnCellDoubleClick(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            base.OnCellDoubleClick(e);
            if (e.RowIndex >= 0)
            {
                TimeLogItemDoubleClick?.Invoke(this, new TimeLogItemClickEventArgs(myEmployeeTimeLogItems[System.Convert.ToInt64(this["IDTimeLog", e.RowIndex].Value)]));
            }
        }

        protected override void OnCellEndEdit(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            base.OnCellEndEdit(e);
            if (this.SelectedRows.Count == 1)
            {
            }
            else
            {
            }
        }

        protected override void OnCellValidating(System.Windows.Forms.DataGridViewCellValidatingEventArgs e)
        {
        }

        protected override void OnCellParsing(System.Windows.Forms.DataGridViewCellParsingEventArgs e)
        {
        }
    }

    public class TimeLogItemClickEventArgs : EventArgs
    {
        private EmployeeTimeLogInfoItem myTimeLogItem;
        public TimeLogItemClickEventArgs(EmployeeTimeLogInfoItem tli)
        {
            myTimeLogItem = tli;
        }

        public EmployeeTimeLogInfoItem EmployeeTimeLogItem
        {
            get
            {
                return myTimeLogItem;
            }

            set
            {
                myTimeLogItem = value;
            }
        }
    }
}
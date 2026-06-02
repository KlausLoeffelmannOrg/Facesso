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
    public abstract class ucObjectContentDataGridView<ObjectType> : DataGridView
    {
        private ObjectType myObject;
        public ucObjectContentDataGridView() : base()
        {
            this.DoubleBuffered = true;
        }

        public virtual ObjectType Object
        {
            get
            {
                return myObject;
            }

            set
            {
                myObject = value;
                if (value == null)
                {
                    this.Rows.Clear();
                }
                else
                {
                    this.Rows.Clear();
                    InitializeHeaders();
                    AssignValues();
                }
            }
        }

        protected abstract void AssignValues();
        public void InitializeHeaders()
        {
            DataGridViewColumn locColumn = default(DataGridViewColumn);
            DataGridViewTextBoxCell locTextCell = new DataGridViewTextBoxCell();
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
                //Eigenschaft
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Width = 120;
                locColumn.DisplayIndex = 0;
                locColumn.HeaderText = "Eigenschaft:";
                locColumn.MinimumWidth = 50;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.False;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locHeaderFont;
                locColumn.Name = "Property";
                __with0.Add(locColumn);
                //Wert
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 500;
                locColumn.DisplayIndex = 1;
                locColumn.HeaderText = "Wert:";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.False;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "Value";
                __with0.Add(locColumn);
            }

            this.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }
    }
}
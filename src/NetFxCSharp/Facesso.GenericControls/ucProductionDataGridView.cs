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
    public class ucProductionDataGridView : DataGridView
    {
        private ProductionData myProductionDataItems;
        private int myRowHeightToRestore;
        private bool myOnlyShowActivatedLabourValues;
        public ucProductionDataGridView() : base()
        {
            myOnlyShowActivatedLabourValues = false;
            this.DoubleBuffered = true;
        }

        public void AssignData()
        {
            InitializeHeaders();
            foreach (ProductionDataItem locPDI in myProductionDataItems)
            {
                if ((OnlyShowActivatedLabourValues & locPDI.LabourValue.IsActive) | (!(OnlyShowActivatedLabourValues)))
                {
                    this.Rows.Add(new object[] { locPDI.LabourValue.LabourValueNumber, locPDI.LabourValue.LabourValueName, locPDI.Amount, locPDI.LabourValue.Dimension, locPDI.LabourValue.TeHMin, locPDI.SubTotal, locPDI.LabourValue.IDLabourValue });
                }
            }
        }

        public bool OnlyShowActivatedLabourValues
        {
            get
            {
                return myOnlyShowActivatedLabourValues;
            }

            set
            {
                if (value != myOnlyShowActivatedLabourValues)
                {
                    myOnlyShowActivatedLabourValues = value;
                    if (ProductionData != null)
                    {
                        this.Rows.Clear();
                        AssignData();
                    }
                }
            }
        }

        public ProductionData ProductionData
        {
            get
            {
                return myProductionDataItems;
            }

            set
            {
                if (value == null)
                {
                    this.Rows.Clear();
                    myProductionDataItems = null;
                    return;
                }

                if (value != myProductionDataItems)
                {
                    this.Rows.Clear();
                    myProductionDataItems = value;
                    AssignData();
                }
            }
        }

        protected override bool SetCurrentCellAddressCore(int columnIndex, int rowIndex, bool setAnchorCellAddress, bool validateCurrentCell, bool throughMouseClick)
        {
            if (rowIndex > -1)
            {
                if (columnIndex != 2)
                {
                    columnIndex = 2;
                }
            }

            return base.SetCurrentCellAddressCore(columnIndex, rowIndex, setAnchorCellAddress, validateCurrentCell, throughMouseClick);
        }

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
                //Arbeitswertnummer
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Width = 60;
                locColumn.DisplayIndex = 0;
                locColumn.HeaderText = "AW-Nr.:";
                locColumn.MinimumWidth = 50;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locHeaderFont;
                locColumn.Name = "LabourValueNumber";
                __with0.Add(locColumn);
                //Arbeitswertname
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                locColumn.FillWeight = 500;
                locColumn.DisplayIndex = 1;
                locColumn.HeaderText = "Arbeitswertname:";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "LabourValueName";
                __with0.Add(locColumn);
                //Menge
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Width = 120;
                locColumn.DisplayIndex = 2;
                locColumn.HeaderText = "Produktionsmenge:";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = false;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "Amount";
                locColumn.DefaultCellStyle.Format = "#,##0.00";
                __with0.Add(locColumn);
                //Dimension
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Width = 75;
                locColumn.DisplayIndex = 3;
                locColumn.HeaderText = "Einheit:";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "Dimension";
                __with0.Add(locColumn);
                //TeInHMin
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Width = 75;
                locColumn.DisplayIndex = 4;
                locColumn.HeaderText = "te in HMin:";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locCellFont;
                locColumn.Name = "Amount";
                __with0.Add(locColumn);
                //Summe
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.Width = 75;
                locColumn.DisplayIndex = 5;
                locColumn.HeaderText = "Summe:";
                locColumn.MinimumWidth = 100;
                locColumn.ReadOnly = true;
                locColumn.Resizable = DataGridViewTriState.True;
                locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                locColumn.DefaultCellStyle.Font = locHeaderFont;
                locColumn.Name = "Subtotal";
                locColumn.DefaultCellStyle.Format = "#,##0.00";
                __with0.Add(locColumn);
                //IDLabourvalue (nicht sichtbar)
                locColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());
                locColumn.ReadOnly = true;
                locColumn.Visible = false;
                locColumn.Name = "IDLabourValue";
                locColumn.DisplayIndex = 6;
                __with0.Add(locColumn);
            }

            this.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        protected override void OnCellEndEdit(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            base.OnCellEndEdit(e);
            if (this.SelectedRows.Count == 1)
            {
                this.ProductionData[ProductionDataItemsIndex(e.RowIndex)].Amount = System.Convert.ToDouble(this.CurrentRow.Cells["Amount"].Value);
                this.ProductionData[ProductionDataItemsIndex(e.RowIndex)].ManuallyEdited = true;
                this.CurrentRow.Cells["SubTotal"].Value = this.ProductionData[ProductionDataItemsIndex(e.RowIndex)].SubTotal;
            }
            else
            {
                double locAmount = System.Convert.ToDouble(this.CurrentRow.Cells["Amount"].Value);
                foreach (DataGridViewRow locRow in this.SelectedRows)
                {
                    this.ProductionData[ProductionDataItemsIndex(locRow.Index)].Amount = locAmount;
                    this.ProductionData[ProductionDataItemsIndex(locRow.Index)].ManuallyEdited = true;
                    locRow.Cells["Amount"].Value = locAmount;
                    locRow.Cells["SubTotal"].Value = this.ProductionData[ProductionDataItemsIndex(locRow.Index)].SubTotal;
                }
            }
        }

        protected override void OnCellValidating(System.Windows.Forms.DataGridViewCellValidatingEventArgs e)
        {
            string locFormular = e.FormattedValue.ToString();
            ActiveDev.ADFormularParser locFormParser = new ActiveDev.ADFormularParser(locFormular);
            try
            {
                double locTest = locFormParser.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beim Auswerten der Formel ist ein Fehler aufgetreten." + System.Environment.NewLine + "Bitte korrigieren Sie Ihre Eingabe!", "Fehler in Ausdruck:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            base.OnCellValidating(e);
        }

        protected override void OnCellParsing(System.Windows.Forms.DataGridViewCellParsingEventArgs e)
        {
            base.OnCellParsing(e);
            string locFormular = e.Value.ToString();
            ActiveDev.ADFormularParser locFormParser = new ActiveDev.ADFormularParser(locFormular);
            e.Value = locFormParser.Result;
            e.ParsingApplied = true;
        }

        private int ProductionDataItemsIndex(int currentRowIndex)
        {
            int locIDLabourValue = System.Convert.ToInt32(this.Rows[currentRowIndex].Cells["IDLabourValue"].Value);
            for (int locIndex = 0; locIndex <= ProductionData.Count - 1; locIndex++)
            {
                if (ProductionData[locIndex].LabourValue.IDLabourValue == locIDLabourValue)
                {
                    return locIndex;
                }
            }

            return -1;
        }
    }
}
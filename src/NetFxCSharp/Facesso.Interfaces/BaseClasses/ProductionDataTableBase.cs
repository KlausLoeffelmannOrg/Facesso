using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public interface IImportResultTable
    {
        /// <summary>
        /// Ermittelt die Anzahl der vorhandenen Zeilen mit Import-Daten, die für die Konvertierung anstehen.
        /// </summary>
        /// <returns>Interger-Wert, der die Anzahl der Zeilen repräsentiert.</returns>
        /// <remarks></remarks>
        int Count();
        /// <summary>
        /// Liefert den Wert des primären Quell-Identifizierers der angegebenen Zeile. Dieser Quell-Identifizierer
        /// hält die Daten einer zu konvertierenden ID. Beispielsweise ist er die Programmnummer, die dann
        /// in einen Arbeitswert umgewandelt wird, oder die Personalnummer-ID eines externen BDE-Dateinsatzes,
        /// die dann in die Employee-ID umgewandelt wird.
        /// </summary>
        /// <param name = "Index">Nummer der Zeile, dessen primärer Quell-Identifizierer abgerufen werden soll.</param>
        /// <returns>Integer-Wert mit dem konvertierten Wert.</returns>
        /// <remarks></remarks>
        int GetPrimarySourceIdentifier(int Index);
        /// <summary>
        /// Bestimmt den Wert des primären Quell-Identifizierers der angegebenen Zeile. Dieser Quell-Identifizierer
        /// hält die Daten einer zu konvertierenden ID. Beispielsweise ist er die Programmnummer, die dann
        /// in einen Arbeitswert umgewandelt wird, oder die Personalnummer-ID eines externen BDE-Dateinsatzes,
        /// die dann in die Employee-ID umgewandelt wird.
        /// </summary>
        /// <param name = "Index">Nummer der Zeile, dessen primärer Quell-Identifizierer abgerufen werden soll.</param>
        /// <param name = "DestID">Die neue ID, durch die die alte ersetzt werden soll.</param>
        /// <remarks></remarks>
        void SetPrimaryDestinationIdentifier(int Index, int DestID);
    }

    public class ProductionDataTable : DataTable, IEnumerable, IImportResultTable
    {
        public ProductionDataTable()
        {
            {
                var __with0 = this.Columns;
                __with0.Add("ID", typeof(int));
                __with0.Add("ProgramNo", typeof(int));
                __with0.Add("IDLabourValue", typeof(int));
                __with0.Add("Shift", typeof(byte));
                __with0.Add("StartTime", typeof(System.DateTime));
                __with0.Add("EndTime", typeof(System.DateTime));
                __with0.Add("TotalAmount", typeof(double));
            }

            this.Columns["ID"].AutoIncrementSeed = 1;
            this.Columns["ID"].AutoIncrementStep = 1;
            this.Columns["ID"].AutoIncrement = true;
        }

        public void AddProductionDataRow(ProductionDataRow pdRow)
        {
            this.Rows.Add(pdRow);
        }

        public ProductionDataRow NewProductionDataRow()
        {
            return ((ProductionDataRow)this.NewRow());
        }

        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
        {
            return new ProductionDataRow(builder);
        }

        protected override System.Type GetRowType()
        {
            return typeof(ProductionDataRow);
        }

        public virtual System.Collections.IEnumerator GetEnumerator()
        {
            return this.Rows.GetEnumerator();
        }

        public ProductionDataRow this[int index]
        {
            get
            {
                return ((ProductionDataRow)this.Rows[index]);
            }
        }

        public int Count()
        {
            return this.Rows.Count;
        }

        public int GetPrimarySourceIdentifier(int Index)
        {
            return this[Index].ProgramNo;
        }

        public void SetPrimaryDestinationIdentifier(int Index, int DestID)
        {
            this[Index].IDLabourValue = DestID;
        }
    }

    public class ProductionDataRow : DataRow
    {
        public ProductionDataRow(DataRowBuilder rb) : base(rb)
        {
        }

        public int ID
        {
            get
            {
                return System.Convert.ToInt32(this["ID"]);
            }

            set
            {
                this["ID"] = value;
            }
        }

        public int ProgramNo
        {
            get
            {
                return System.Convert.ToInt32(this["ProgramNo"]);
            }

            set
            {
                this["ProgramNo"] = value;
            }
        }

        public int IDLabourValue
        {
            get
            {
                return System.Convert.ToInt32(this["IDLabourValue"]);
            }

            set
            {
                this["IDLabourValue"] = value;
            }
        }

        public byte Shift
        {
            get
            {
                return System.Convert.ToByte(this["Shift"]);
            }

            set
            {
                this["Shift"] = value;
            }
        }

        public System.DateTime StartTime
        {
            get
            {
                return System.Convert.ToDateTime(this["StartTime"]);
            }

            set
            {
                this["StartTime"] = value;
            }
        }

        public System.DateTime EndTime
        {
            get
            {
                return System.Convert.ToDateTime(this["EndTime"]);
            }

            set
            {
                this["EndTime"] = value;
            }
        }

        public double TotalAmount
        {
            get
            {
                return System.Convert.ToDouble(this["TotalAmount"]);
            }

            set
            {
                this["TotalAmount"] = value;
            }
        }
    }
}
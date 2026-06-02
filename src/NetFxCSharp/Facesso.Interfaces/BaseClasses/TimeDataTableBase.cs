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
    public interface ITimeLogImportResultTable : IImportResultTable
    {
        /// <summary>
        /// Liefert den Wert des sekundären Quell-Identifizierers der angegebenen Zeile. Dieser Quell-Identifizierer
        /// hält die Daten einer zu konvertierenden ID. Beispielsweise ist er die Kostenstelle einer BDE, die dann
        /// in eine Arbeitsgruppe umgewandelt wird.
        /// </summary>
        /// <param name = "Index">Nummer der Zeile, dessen sekundärer Quell-Identifizierer abgerufen werden soll.</param>
        /// <returns>Integer-Wert mit dem konvertierten Wert.</returns>
        /// <remarks></remarks>
        int GetSecondarySourceIdentifier(int Index);
        /// <summary>
        /// Bestimmt den Wert des sekundären Quell-Identifizierers der angegebenen Zeile. Dieser Quell-Identifizierer
        /// hält die Daten einer zu konvertierenden ID. Beispielsweise ist er die Kostenstelle einer BDE, die dann
        /// in eine Arbeitsgruppe umgewandelt wird.
        /// </summary>
        /// <param name = "Index">Nummer der Zeile, dessen sekundärer Quell-Identifizierer abgerufen werden soll.</param>
        /// <param name = "DestID">Die neue ID, durch die die alte ersetzt werden soll.</param>
        /// <remarks></remarks>
        void SetSecondaryDestinationIdentifier(int Index, int DestID);
    }

    public class TimeDataTable : DataTable, IEnumerable, ITimeLogImportResultTable
    {
        public TimeDataTable()
        {
            {
                var __with0 = this.Columns;
                __with0.Add("ID", typeof(int));
                __with0.Add("EmployeeNo", typeof(int));
                __with0.Add("EmployeeDescription", typeof(string));
                __with0.Add("AlienEmployeeNo", typeof(int));
                __with0.Add("WorkgroupNo", typeof(int));
                __with0.Add("WorkgroupDescription", typeof(string));
                // Zum Beispiel eine Kostenstelle einer Kostenstellenbuchung eines Fremdsystems oder eine WorkEntityNo in Legatro
                __with0.Add("AlienID", typeof(int));
                __with0.Add("StartTime", typeof(System.DateTime));
                __with0.Add("EndTime", typeof(System.DateTime));
                __with0.Add("Shift", typeof(byte));
                __with0.Add("DownTime", typeof(int));
                __with0.Add("WorkBreak", typeof(int));
                __with0.Add("Handicap", typeof(double));
                __with0.Add("HasDiscrepancies", typeof(bool));
                __with0.Add("DiscrepanciesText", typeof(string));
            }

            this.Columns["ID"].AutoIncrementSeed = 1;
            this.Columns["ID"].AutoIncrementStep = 1;
            this.Columns["ID"].AutoIncrement = true;
        }

        public void AddTimeDataRow(TimeDataRow pdRow)
        {
            this.Rows.Add(pdRow);
        }

        public TimeDataRow NewTimeDataRow()
        {
            return ((TimeDataRow)this.NewRow());
        }

        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
        {
            return new TimeDataRow(builder);
        }

        protected override System.Type GetRowType()
        {
            return typeof(TimeDataRow);
        }

        public virtual System.Collections.IEnumerator GetEnumerator()
        {
            return this.Rows.GetEnumerator();
        }

        public TimeDataRow this[int index]
        {
            get
            {
                return ((TimeDataRow)this.Rows[index]);
            }
        }

        /// <summary>
        /// Ermittelt den primäre Quell-Identifizierer, der dann mit SetPrimaryDestinationIdentifier in den Facesso-Standard konvertiert werden kann (Kostenstelle-->Produktivsite).
        /// </summary>
        /// <param name = "Index">Nummer der Zeile in der Quelltabelle.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetPrimarySourceIdentifier(int Index)
        {
            return this[Index].WorkgroupNo;
        }

        /// <summary>
        /// Setzt den primäre Quell-Identifizierer, der mit GetPrimaryDestinationIdentifier in den Facesso-Standard konvertiert werden kann (Kostenstelle-->Produktivsite).
        /// </summary>
        /// <param name = "Index"></param>
        /// <param name = "DestId"></param>
        /// <remarks></remarks>
        public void SetPrimaryDestinationIdentifier(int Index, int DestId)
        {
            this[Index].AlienID = DestId;
        }

        /// <summary>
        /// Ermittelt die Anzahl der Zeilen in der Konvertierungstabelle.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int Count()
        {
            return this.Rows.Count;
        }

        /// <summary>
        /// Ermittelt den sekundären Quell-Identifizierer, der dann mit SetSecondaryDestinationIdentifier in den Facesso-Standard konvertiert werden kann (Fremd-Personal-ID in Facesso-Personalnummer).
        /// </summary>
        /// <param name = "Index">Nummer der Zeile in der Quelltabelle.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public int GetSecondarySourceIdentifier(int Index)
        {
            return this[Index].EmployeeNo;
        }

        /// <summary>
        /// Setzt den sekundären Quell-Identifizierer, der mit GetSecondaryDestinationIdentifier in den Facesso-Standard konvertiert werden kann (Fremd-Personal-ID in Facesso-Personalnummer).
        /// </summary>
        /// <param name = "Index">Nummer der Zeile in der Quelltabelle.</param>
        /// <remarks></remarks>
        public void SetSecondaryDestinationIdentifier(int Index, int DestID)
        {
            this[Index].AlienEmployeeNo = DestID;
        }

        public IEnumerable<TimeDataRow> TimeDataRows
        {
            get
            {
                List<TimeDataRow> tmpList = new List<TimeDataRow>();
                foreach (var rowItem in this.Rows)
                {
                    tmpList.Add(((TimeDataRow)rowItem));
                }

                return tmpList;
            }
        }
    }

    public class TimeDataRow : DataRow
    {
        public TimeDataRow(DataRowBuilder rb) : base(rb)
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

        public int EmployeeNo
        {
            get
            {
                return System.Convert.ToInt32(this["EmployeeNo"]);
            }

            set
            {
                this["EmployeeNo"] = value;
            }
        }

        public string EmployeeDescription
        {
            get
            {
                return this["EmployeeDescription"].ToString();
            }

            set
            {
                this["EmployeeDescription"] = value;
            }
        }

        public int AlienEmployeeNo
        {
            get
            {
                return System.Convert.ToInt32(this["AlienEmployeeNo"]);
            }

            set
            {
                this["AlienEmployeeNo"] = value;
            }
        }

        public int WorkgroupNo
        {
            get
            {
                return System.Convert.ToInt32(this["WorkgroupNo"]);
            }

            set
            {
                this["WorkgroupNo"] = value;
            }
        }

        public string WorkgroupDescription
        {
            get
            {
                return this["WorkgroupDescription"].ToString();
            }

            set
            {
                this["WorkgroupDescription"] = value;
            }
        }

        public int AlienID
        {
            get
            {
                return System.Convert.ToInt32(this["AlienID"]);
            }

            set
            {
                this["AlienID"] = value;
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

        public int DownTime
        {
            get
            {
                return System.Convert.ToInt32(this["DownTime"]);
            }

            set
            {
                this["DownTime"] = value;
            }
        }

        public int WorkBreak
        {
            get
            {
                return System.Convert.ToInt32(this["WorkBreak"]);
            }

            set
            {
                this["WorkBreak"] = value;
            }
        }

        public double? Handicap
        {
            get
            {
                return ((this["Handicap"]) == DBNull.Value ? default(double) : System.Convert.ToDouble(this["Handicap"]));
            }

            set
            {
                this["Handicap"] = value;
            }
        }

        public bool HasDiscrepancies
        {
            get
            {
                return System.Convert.ToBoolean(this["HasDiscrepancies"]);
            }

            set
            {
                this["HasDiscrepancies"] = value;
            }
        }

        public string DiscrepanciesText
        {
            get
            {
                return this["DiscrepanciesText"].ToString();
            }

            set
            {
                this["DiscrepanciesText"] = value;
            }
        }
    }
}
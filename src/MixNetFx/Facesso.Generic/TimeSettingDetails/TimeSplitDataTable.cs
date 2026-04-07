using System;
using System.Collections;
using System.Data;

namespace Facesso
{
    public class TimeSplitDataTable : DataTable, IEnumerable
    {
        public TimeSplitDataTable()
        {
            Columns.Add("ID", typeof(int));
            Columns.Add("ProductionDate", typeof(DateTime));
            Columns.Add("Shift", typeof(byte));
            Columns.Add("StartTime", typeof(DateTime));
            Columns.Add("EndTime", typeof(DateTime));
            Columns.Add("InShiftProRata", typeof(double));
            Columns.Add("FromOriginalProRata", typeof(double));

            Columns["ID"].AutoIncrementSeed = 1;
            Columns["ID"].AutoIncrementStep = 1;
            Columns["ID"].AutoIncrement = true;
        }

        public void AddProductionDataRow(TimeSplitDataRow pdRow)
        {
            Rows.Add(pdRow);
        }

        public TimeSplitDataRow NewProductionDataRow()
        {
            return (TimeSplitDataRow)NewRow();
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new TimeSplitDataRow(builder);
        }

        protected override Type GetRowType()
        {
            return typeof(TimeSplitDataRow);
        }

        public new IEnumerator GetEnumerator()
        {
            return Rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public TimeSplitDataRow this[int index] => (TimeSplitDataRow)Rows[index];

        public new int Count => Rows.Count;
    }

    public class TimeSplitDataRow : DataRow
    {
        internal TimeSplitDataRow(DataRowBuilder rb) : base(rb) { }

        public int ID
        {
            get { return (int)this["ID"]; }
            set { this["ID"] = value; }
        }

        public DateTime ProductionDate
        {
            get { return (DateTime)this["ProductionDate"]; }
            set { this["ProductionDate"] = value; }
        }

        public byte Shift
        {
            get { return (byte)this["Shift"]; }
            set { this["Shift"] = value; }
        }

        public DateTime StartTime
        {
            get { return (DateTime)this["StartTime"]; }
            set { this["StartTime"] = value; }
        }

        public DateTime EndTime
        {
            get { return (DateTime)this["EndTime"]; }
            set { this["EndTime"] = value; }
        }

        public double InShiftProRata
        {
            get { return (double)this["InShiftProRata"]; }
            set { this["InShiftProRata"] = value; }
        }

        public double FromOriginalProRata
        {
            get { return (double)this["FromOriginalProRata"]; }
            set { this["FromOriginalProRata"] = value; }
        }
    }
}

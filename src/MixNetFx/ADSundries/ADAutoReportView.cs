using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ActiveDev
{

    public class ADAutoReportView : ListView
    {

        private SortedList<int, ADAutoReportColumn> myColumnNames;
        private IList myIList;
        private int myHelperOrderNo;
        private AutoReportMode myListViewMode;

        public ADAutoReportView() : base()
        {
            // Auf Detailansicht umschalten
            View = View.Details;
            // Bei Fokusverlust Markierung dennoch anzeigen
            HideSelection = false;
            // Ganze Reihe soll selektiert werden
            FullRowSelect = true;
            myHelperOrderNo = ushort.MaxValue + 1;
            myListViewMode = AutoReportMode.Details;
        }

        #region Elemente-Klassen (privat)

        // Speichert eine einzelne Spalteneinstellung
        private class ADAutoReportColumn
        {

            private string myPropertyName;
            private string myDisplayName;
            private int myColumnWidth;
            private int myOrderNo;
            private AutoReportPurpose myPurpose;

            public ADAutoReportColumn(string PropertyName, string Displayname)
            {
                myPropertyName = PropertyName;
                myDisplayName = Displayname;
            }

            // Speichert den Eigenschaftennamen
            public string PropertyName
            {
                get
                {
                    return myPropertyName;
                }
                set
                {
                    myPropertyName = value;
                }
            }

            // Steuert die Ausgabe
            public AutoReportPurpose Purpose
            {
                get
                {
                    return myPurpose;
                }
                set
                {
                    myPurpose = value;
                }
            }

            // Speichert den Namen dieser Eigenschaft, der als Spaltentitel
            // angezeigt werden soll.
            public string DisplayName
            {
                get
                {
                    return myDisplayName;
                }
                set
                {
                    myDisplayName = value;
                }
            }

            // Speichert die Spaltenbreite
            public int ColumnWidth
            {
                get
                {
                    return myColumnWidth;
                }
                set
                {
                    myColumnWidth = value;
                }
            }

            // Speichert die Rangfolgennr. für das Sortieren der Spalten
            public int OrderNo
            {
                get
                {
                    return myOrderNo;
                }
                set
                {
                    myOrderNo = value;
                }
            }
        }
        #endregion

        public AutoReportMode ListViewMode
        {
            get
            {
                return myListViewMode;
            }
            set
            {
                myListViewMode = value;
            }
        }

        public IList List
        {
            get
            {
                return myIList;
            }

            // Setzen der Eigenschaft:
            set
            {
                BeginUpdate();
                // Alle Inhalte löschen
                Items.Clear();
                // Allte Spaltentitel löschen
                Columns.Clear();
                if (value is null)
                {
                    // Abbrechen, falls Nothing zugewiesen wurde
                    EndUpdate();
                    return;
                }
                else
                {
                    // Liste zuweisen
                    myIList = value;
                    // Die Spaltennamen und Objekteigenschaften entweder durch das Objekt
                    // selbst oder zugewiesene Attribute ermitteln und in myColumnNamens 
                    // speichern.
                    myColumnNames = GetColumnNames(value);
                    // Anschließend die Spaltentitel setzen...
                    SetupColumns();
                    // ...und die Liste mit Einträgen füllen, die sich aus myIList ergeben
                    SetupEntries();
                }
                EndUpdate();
            }
        }

        // Spaltentitel einsetzen
        private void SetupColumns()
        {
            {
                var withBlock = Columns;
                // TODO: Das Alignment könnte auch in Attributen untergebracht werden
                foreach (KeyValuePair<int, ADAutoReportColumn> kvp in myColumnNames)
                    withBlock.Add(kvp.Value.DisplayName, kvp.Value.ColumnWidth, HorizontalAlignment.Left);
            }
        }

        // Einträge in die Liste schreiben
        private void SetupEntries()
        {
            foreach (object obj in myIList)
            {
                {
                    var withBlock = Items;
                    var locLvi = new ListViewItem();
                    locLvi.Tag = obj;
                    bool locFirstHandled = false;
                    // Erste darzustellende Eigenschaft erfährt Sonderbehandlung,
                    // da sie nicht durch SubItems dargestellt wird
                    // Mit GetPropValue wird die Stringumwandlung der Eigenschaft
                    // eines Objektes ermittelt.
                    foreach (KeyValuePair<int, ADAutoReportColumn> locColumn in myColumnNames)
                    {
                        if (!locFirstHandled)
                        {
                            locLvi.Text = GetPropValue(obj, locColumn.Value.PropertyName);
                            locFirstHandled = true;
                        }
                        else
                        {
                            locLvi.SubItems.Add(GetPropValue(obj, locColumn.Value.PropertyName));
                        }
                    }
                    withBlock.Add(locLvi);
                }
            }

            // Spaltenbreiten anpassen
            int ccount = 0;
            foreach (KeyValuePair<int, ADAutoReportColumn> kvp in myColumnNames)
            {
                Columns[ccount].Width = kvp.Value.ColumnWidth;
                ccount += 1;
            }
        }

        // Ermittelt den Inhalt der Eigenschaft eines Objektes als String
        private string GetPropValue(object @object, string PropertyName)
        {

            var locPI = @object.GetType().GetProperty(PropertyName);
            return locPI.GetValue(@object, null).ToString();
        }

        // Ermittelt die durch die Objekteigenschaften vorgegebenen dazustellenden
        // Spalten, wenn keine Attribute verwendet werden. Werden Attribute verwendet,
        // ermittelt die Funktion nur die Eigenschaften eines Objektes, die mit einem
        // entsprechenden Attribut versehen sind.
        private SortedList<int, ADAutoReportColumn> GetColumnNames(IList List)
        {

            Type locTypeToExamine;
            var locARCs = new SortedList<int, ADAutoReportColumn>();
            bool locExplicitlyDefined = false;

            if (List is null)
            {
                // Soweit dürfte es eigentlich gar nicht kommen, aber wir gehen auf No. sicher.
                var Up = new NullReferenceException("Die Übergebende Liste ist leer!");
                throw Up;
            }

            // Das erste Objekt ist maßgeblich für die Typen aller anderen Objekte.
            // Die Liste muss also homogen (Objektableitungen ausgenommen) sein, damit 
            // die automatische Element-Zuweisung reibungslos funktioniert.
            locTypeToExamine = List[0].GetType();

            // Alle Eigenschaften des Objektes durchforsten
            foreach (PropertyInfo pi in locTypeToExamine.GetProperties())
            {
                // Nach Attributen Ausschau halten
                foreach (Attribute a in pi.GetCustomAttributes(true))
                {
                    // Nur reagieren, wenn es sich um unseren speziellen Typ handelt
                    if (a is ADAutoReportColumnAttribute)
                    {
                        var locARC = new ADAutoReportColumn(pi.Name, pi.Name);
                        // Parameter aus dem Attribute-Objekt übernehmen
                        locARC.DisplayName = a.GetType().GetProperty("DisplayName").GetValue(a, null).ToString();
                        locARC.ColumnWidth = Conversions.ToInteger(a.GetType().GetProperty("ColumnWidth").GetValue(a, null));
                        locARC.OrderNo = Conversions.ToInteger(a.GetType().GetProperty("OrderNo").GetValue(a, null));
                        locARC.Purpose = (AutoReportPurpose)Conversions.ToInteger(a.GetType().GetProperty("Purpose").GetValue(a, null));
                        if (locARC.OrderNo == 0)
                        {
                            locARC.OrderNo = myHelperOrderNo;
                            myHelperOrderNo += 1;
                        }
                        if ((locARC.Purpose & AutoReportPurpose.ShowInDetailsTable) == AutoReportPurpose.ShowInDetailsTable & ListViewMode == AutoReportMode.Details | (locARC.Purpose & AutoReportPurpose.ShowInVerboseTable) == AutoReportPurpose.ShowInVerboseTable & ListViewMode == AutoReportMode.Verbose)


                        {
                            locARCs.Add(locARC.OrderNo, locARC);
                            break;
                        }
                    }
                }
                // Zur Spaltenkopf-Parameterliste hinzufügen
            }
            return locARCs;
        }
    }

    public enum AutoReportMode
    {
        Details,
        Verbose
    }

    public enum AutoReportPurpose
    {
        None = 0,
        ShowInDetailsTable = 1,
        ShowInVerboseTable = 2,
        PrintInDetailsList = 4,
        PrintInVerboseList = 8
    }

    // Dieses Attribut kann nur auf Eigenschaften angewendet werden
    [AttributeUsage(AttributeTargets.Property)]
    public class ADAutoReportColumnAttribute : Attribute
    {

        private string myDisplayName;
        private AutoReportPurpose myPurpose;
        private int myColumnWidth;
        private int myOrderNo;
        // Vorgabe-Reihenfolgenr. für den Fall, dass diese nicht mit angegeben wurde
        private static int myDefaultOrderNo;

        static ADAutoReportColumnAttribute()
        {
            myDefaultOrderNo = 1;
        }

        // Konstruktoren, die den Darstellungsnamen...
        public ADAutoReportColumnAttribute(string DisplayName)
        {
            myPurpose = AutoReportPurpose.PrintInDetailsList | AutoReportPurpose.ShowInDetailsTable;
            myDisplayName = DisplayName;
            myColumnWidth = -2;
            myOrderNo = myDefaultOrderNo;
            myDefaultOrderNo += 1;
        }

        // ...und optional die Breite der Tabellenspalte bestimmen...
        public ADAutoReportColumnAttribute(string displayName, int colomnWidth)
        {
            myPurpose = AutoReportPurpose.PrintInDetailsList | AutoReportPurpose.ShowInDetailsTable;
            myDisplayName = displayName;
            myColumnWidth = colomnWidth;
            myOrderNo = myDefaultOrderNo;
            myDefaultOrderNo += 1;
        }

        public ADAutoReportColumnAttribute(string displayName, int colomnWidth, AutoReportPurpose purpose)
        {
            myPurpose = purpose;
            myDisplayName = displayName;
            myColumnWidth = colomnWidth;
            myOrderNo = myDefaultOrderNo;
            myDefaultOrderNo += 1;
        }

        // ...sowie die Reihenfolge der Spalte.
        public ADAutoReportColumnAttribute(string displayName, int columnWidth, int orderNo)
        {
            myPurpose = AutoReportPurpose.PrintInDetailsList | AutoReportPurpose.ShowInDetailsTable;
            myDisplayName = displayName;
            myColumnWidth = columnWidth;
            myOrderNo = orderNo;
            if (orderNo > myDefaultOrderNo)
            {
                myDefaultOrderNo = orderNo + 1;
            }
        }

        // ...sowie die Reihenfolge der Spalte.
        public ADAutoReportColumnAttribute(string displayName, int columnWidth, int orderNo, AutoReportPurpose purpose)
        {
            myPurpose = purpose;
            myPurpose = AutoReportPurpose.PrintInDetailsList | AutoReportPurpose.ShowInDetailsTable;
            myDisplayName = displayName;
            myColumnWidth = columnWidth;
            myOrderNo = orderNo;
            if (orderNo > myDefaultOrderNo)
            {
                myDefaultOrderNo = orderNo + 1;
            }
        }

        // Steuert die Ausgabe
        public AutoReportPurpose Purpose
        {
            get
            {
                return myPurpose;
            }
            set
            {
                myPurpose = value;
            }
        }

        // Name des Spaltenkopfs
        public string DisplayName
        {
            get
            {
                return myDisplayName;
            }
            set
            {
                myDisplayName = value;
            }
        }

        // Spaltenbreite
        public int ColumnWidth
        {
            get
            {
                return myColumnWidth;
            }
            set
            {
                myColumnWidth = value;
            }
        }

        // Sortierschlüssel
        public int OrderNo
        {
            get
            {
                return myOrderNo;
            }
            set
            {
                myOrderNo = value;
            }
        }
    }
}
using ActiveDev;
using Facesso.Data;
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
    public class LegatroTimeDataTransformation
    {
        private System.DateTime myProductionDate;
        private int myShift;
        private LegatroTimeDataImport myLegatroTaskItem;
        private TimeDataTable myResultTable;
        private string myConnectionString;
        private System.DateTime myEarliestTime;
        private System.DateTime myLatestTime;
        private List<ViewTimeLogNativeVerbatim> myLegatroTimeData;
        private FacessoConversionItemsBase myConversionItems;
        public LegatroTimeDataTransformation(System.DateTime ProductionDate, int Shift, LegatroTimeDataImport LegatroTaskItem)
        {
            myProductionDate = ProductionDate;
            myShift = Shift;
            myLegatroTaskItem = LegatroTaskItem;
            myConversionItems = LegatroTaskItem.ConversionItems;
        }

        public void Convert()
        {
            //Neue Resulttabelle anlegen
            myResultTable = new TimeDataTable();
            //ConnectionString setzen
            myConnectionString = myLegatroTaskItem.LegatroSQLConnectionString;
            //Die Zeitrahmendaten ermitteln
            myLegatroTimeData = GetLegatroData();
            //Gab keine Zeitdaten für den Zeitbereich, dann und Tschüss.
            if (myLegatroTimeData == null || myLegatroTimeData.Count == 0)
            {
                return;
            }

            //Build Table
            myResultTable = new TimeDataTable();
            BuildTableFromLegatroTimeData();
        }

        private void BuildTableFromLegatroTimeData()
        {
            TimeDataBuilder tdb = new TimeDataBuilder();
            tdb.CurrentEmployeeNo = -1;
            foreach (var tItem in myLegatroTimeData)
            {
                //Employee-Wechsel erkennen
                if (tdb.CurrentEmployeeNo != tItem.PersonnelNumber)
                {
                    //Ist der nunmehr vorherige Mitarbeiter immer noch da?
                    if (tdb.IsPresent)
                    {
                        tdb.HasDiscrepancies = true;
                        tdb.DiscrepanciesText = "Die 'Geht'-Buchung dieses Mitarbeiters für die entsprechende Periode scheint zu fehlen.";
                    }

                    //Wenn es nicht der erste Mitarbeiter der gesamtverarbeitung war (-1 als Kennzeichen) war, dann diesen speichern.
                    if (tdb.CurrentEmployeeNo != -1)
                    {
                        if (tdb.LastWorkgroup != -1)
                        {
                            var resultRow = NewBookingEntry(tdb, tdb.LastWorksiteChange);
                            myResultTable.Rows.Add(resultRow);
                        }
                    }

                    //Das setzt alle inneren Daten auch zurück!
                    tdb.CurrentEmployeeNo = tItem.PersonnelNumber;
                }

                //Und interessieren nur die Arbeitsgruppenwechsel - Startbuchungen sind wurscht.
                if (tItem.IsWorksiteChange)
                {
                    var tmpWorkgroup = GetWorkgroup(tItem.WorkEntityNumber.Value);
                    if (!(tdb.IsPresent))
                    {
                        if (tmpWorkgroup.HasValue)
                        {
                            tdb.IsPresent = true;
                            tdb.LastWorksiteChange = tItem.EventTime.Value;
                            tdb.LastWorkgroup = tmpWorkgroup.Value;
                        }
                    }
                    else
                    {
                        //Arbeitsgruppenwechsel komplett - jetzt müssen wir den Buchungseintrag vornehmen
                        var resultRow = NewBookingEntry(tdb, tItem.EventTime.Value);
                        myResultTable.Rows.Add(resultRow);
                        tdb.ResetValues();
                        if (tmpWorkgroup.HasValue)
                        {
                            //Alter Endwert ist neuer Startwert!
                            tdb.LastWorksiteChange = tItem.EventTime.Value;
                            tdb.LastWorkgroup = tmpWorkgroup.Value;
                            tdb.IsPresent = true;
                        }
                    }
                }

                //Mitarbeiter bucht sich von einer Arbeitsgruppe zurück an die Heimatkostenstelle (über Zwischenbuchung Pause oder Ausfallzeit),
                //das wird wie ein "Geht" behandelt aus Facesso-Sicht.
                if (tItem.BookingType == 1 & !(tItem.WorkEntityNumber.HasValue) & tdb.IsPresent)
                {
                    //Arbeitszeitabschnitt komplett - jetzt müssen wir den Buchungseintrag vornehmen
                    var resultRow = NewBookingEntry(tdb, tItem.EventTime.Value);
                    myResultTable.Rows.Add(resultRow);
                    tdb.ResetValues();
                }

                //Mitarbeiter bucht sich wech, durch "Dienstgang" oder "Geht".
                if ((Facesso.Interfaces.BookingTypes)(tItem.BookingType) == BookingTypes.Leave | (Facesso.Interfaces.BookingTypes)(tItem.BookingType) == BookingTypes.OffSiteWork)
                {
                    if (tdb.LastWorkgroup > -1)
                    {
                        if (!(tdb.IsPresent))
                        {
                            tdb.HasDiscrepancies = true;
                            tdb.DiscrepanciesText = "Die 'Kommt'-Buchung dieses Mitarbeiters für die entsprechende Periode scheint zu fehlen.";
                        }

                        //Arbeitszeitabschnitt komplett - jetzt müssen wir den Buchungseintrag vornehmen
                        var resultRow = NewBookingEntry(tdb, tItem.EventTime.Value);
                        myResultTable.Rows.Add(resultRow);
                        tdb.ResetValues();
                    }
                }

                //Ausfallzeitbuchung:
                if ((Facesso.Interfaces.BookingTypes)(tItem.BookingType) == BookingTypes.DownTime)
                {
                    //Mitarbeiter ist nicht angemeldet, dann darf er keine Ausfallzeit buchen.
                    if (!(tdb.IsPresent))
                    {
                        //Ausfallzeit ohne Anbuchung is nich.
                        goto SkipDownTimeProcessing;
                    }

                    //Ausfallzeit unterbricht eine vorhandene Pause.
                    if (tdb.IsWorkBreak)
                    {
                        tdb.CurrentWorkBreakDuration += System.Convert.ToInt32(Math.Round((tItem.EventTime.Value - tdb.LastWorkbreakEvent.Value).TotalMinutes, 0));
                        tdb.LastWorkbreakEvent = null;
                    }

                    //Nur merken, wenn nicht schon eine Ausfallzeit im Gang war,
                    //sonst, also bei zwei AUsfallzeitbuchungen, bleibt die erste
                    //Buchung bestehen - die zweite wird ignoriert.
                    if (!(tdb.IsDownTime))
                    {
                        tdb.LastDowntimeEvent = tItem.EventTime;
                    }

                    SkipDownTimeProcessing:
                        ;
                }

                //Pausenbuchung:
                if ((Facesso.Interfaces.BookingTypes)(tItem.BookingType) == BookingTypes.WorkBreak)
                {
                    //Mitarbeiter ist nicht angemeldet, dann darf er keine Pause buchen.
                    if (!(tdb.IsPresent))
                    {
                        //Pause ohne dasein iss nich.
                        goto SkipWorkBreakProcessing;
                    }

                    //Pause unterbricht eine fortlaufende Ausfallzeit.
                    if (tdb.IsDownTime)
                    {
                        tdb.CurrentDownTimeDuration += System.Convert.ToInt32(Math.Round((tItem.EventTime.Value - tdb.LastDowntimeEvent.Value).TotalMinutes, 0));
                        tdb.LastDowntimeEvent = null;
                    }

                    if (!(tdb.IsWorkBreak))
                    {
                        tdb.LastWorkbreakEvent = tItem.EventTime;
                    }
                }

                SkipWorkBreakProcessing:
                    ;
            }
        }

        private TimeDataRow NewBookingEntry(TimeDataBuilder tdBuilder, System.DateTime LastEventTime)
        {
            //Etwaige Ausfallzeit abschließen
            if (tdBuilder.IsDownTime)
            {
                tdBuilder.CurrentDownTimeDuration += System.Convert.ToInt32(Math.Round((LastEventTime - tdBuilder.LastDowntimeEvent.Value).TotalMinutes, 0));
                tdBuilder.LastDowntimeEvent = null;
            }

            //Etwaige Pause abschließen
            if (tdBuilder.IsWorkBreak)
            {
                tdBuilder.CurrentWorkBreakDuration += System.Convert.ToInt32(Math.Round((LastEventTime - tdBuilder.LastWorkbreakEvent.Value).TotalMinutes, 0));
                tdBuilder.LastWorkbreakEvent = null;
            }

            //Ansonsten liefern wir die Ereignisfolge als Buchungssatz zurück.
            var tdr = myResultTable.NewTimeDataRow();
            {
                var __with0 = tdr;
                __with0.WorkgroupNo = tdBuilder.LastWorkgroup;
                __with0.AlienID = tdBuilder.LastWorkgroup;
                __with0.AlienEmployeeNo = tdBuilder.CurrentEmployeeNo;
                __with0.EmployeeNo = tdBuilder.CurrentEmployeeNo;
                __with0.StartTime = tdBuilder.LastWorksiteChange;
                __with0.EndTime = LastEventTime;
                __with0.Shift = 0;
                __with0.WorkBreak = tdBuilder.CurrentWorkBreakDuration;
                __with0.DownTime = tdBuilder.CurrentDownTimeDuration;
                __with0.HasDiscrepancies = tdBuilder.HasDiscrepancies;
                __with0.DiscrepanciesText = tdBuilder.DiscrepanciesText;
            }

            return tdr;
        }

        private List<ViewTimeLogNativeVerbatim> GetLegatroData()
        {
            myEarliestTime = System.DateTime.MaxValue;
            myLatestTime = System.DateTime.MinValue;
            //Durch alle betroffenen Produktiv-Sites iterieren und die entsprechenden Schichtdefinitionen dafür finden.
            foreach (var item in myLegatroTaskItem.ConversionItems)
            {
                if (item.HomeElementID > -1)
                {
                    var currentFacWorkgroup = WorkGroupInfo.FromWorkGroupNumber(FacessoGeneric.LoginInfo.IDSubsidiary, item.HomeElementID);
                    //Rausfinden, ob durch fehlerhafte Definitionen irgendwelche Zeiten später oder früher sind.
                    for (int tmpShift = 1; tmpShift <= 4; tmpShift++)
                    {
                        var shiftStart = currentFacWorkgroup.TimeSettingDetails.GetTimeSettingDetail(myProductionDate, tmpShift, true).ImportShiftStart;
                        if (shiftStart.HasValue)
                        {
                            if (shiftStart.TypedValue < myEarliestTime)
                            {
                                myEarliestTime = shiftStart.TypedValue;
                            }
                        }

                        var shiftEnd = currentFacWorkgroup.TimeSettingDetails.GetTimeSettingDetail(myProductionDate, tmpShift, true).ImportShiftEnd;
                        if (shiftEnd.HasValue)
                        {
                            if (shiftEnd.TypedValue > myLatestTime)
                            {
                                myLatestTime = shiftEnd.TypedValue;
                            }
                        }
                    }
                }
            }

            //Jetzt 12 Stunden vorher und nachher draufpacken, dann haben wir den Zeitbereich, den wir betrachten müssen
            //und falls es in diesem Zeitraum unvollständige Buchungssätze gibt, die innerhalb des Schichtbereichs und
            //deren Schwellwerten fallen, dann handelt es sich wirklich um Buchungsfehler.
            myEarliestTime = myEarliestTime.AddHours(-12);
            myLatestTime = myLatestTime.AddHours(12);
            if (myLatestTime > System.DateTime.Now)
            {
                myLatestTime = System.DateTime.Now;
            }

            //Jetzt holen wir alle Zeitdaten aus Legatro innerhalb dieses Zeitraums.
            LegatroDataContext ldc = new LegatroDataContext(myConnectionString);
            var myLegatroTimeData = ((
                from items in ldc.ViewTimeLogNativeVerbatim
                where items.EventTime >= myEarliestTime & items.EventTime <= myLatestTime
                orderby items.PersonnelNumber, items.EventTime
                select items)).ToList();
            return myLegatroTimeData;
        }

        /// <summary>
        /// Konvertiert eine Workentity aus Legatro in eine Produktiv-Site in Facesso.
        /// </summary>
        /// <param name = "lastWorkEntity"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private int? GetWorkgroup(int lastWorkEntity)
        {
            foreach (var eItem in myConversionItems)
            {
                if (eItem.HomeElementID > -1)
                {
                    if (eItem.AlienElementID == lastWorkEntity)
                    {
                        return eItem.HomeElementID;
                        break;
                    }
                }
            }

            return null;
        }

        public IImportResultTable ResultTable()
        {
            return myResultTable;
        }
    }

    public struct TimeDataBuilder
    {
        private int myCurrentEmployeeNo;
        public int CurrentEmployeeNo
        {
            get
            {
                return myCurrentEmployeeNo;
            }

            set
            {
                ResetValues();
                myCurrentEmployeeNo = value;
            }
        }

        private int myLastWorkEntity;
        public int LastWorkgroup
        {
            get
            {
                return myLastWorkEntity;
            }

            set
            {
                myLastWorkEntity = value;
            }
        }

        private bool myIsPresent;
        public bool IsPresent
        {
            get
            {
                return myIsPresent;
            }

            set
            {
                myIsPresent = value;
            }
        }

        public bool IsDownTime
        {
            get
            {
                return LastDowntimeEvent.HasValue;
            }
        }

        public bool IsWorkBreak
        {
            get
            {
                return LastWorkbreakEvent.HasValue;
            }
        }

        private System.DateTime myLastWorksiteChange;
        public System.DateTime LastWorksiteChange
        {
            get
            {
                return myLastWorksiteChange;
            }

            set
            {
                myLastWorksiteChange = value;
            }
        }

        private System.DateTime? myLastWorkbreakEvent;
        public System.DateTime? LastWorkbreakEvent
        {
            get
            {
                return myLastWorkbreakEvent;
            }

            set
            {
                myLastWorkbreakEvent = value;
            }
        }

        private System.DateTime? myLastDownTimeEvent;
        public System.DateTime? LastDowntimeEvent
        {
            get
            {
                return myLastDownTimeEvent;
            }

            set
            {
                myLastDownTimeEvent = value;
            }
        }

        private int myCurrentWorkBreakDuration;
        public int CurrentWorkBreakDuration
        {
            get
            {
                return myCurrentWorkBreakDuration;
            }

            set
            {
                myCurrentWorkBreakDuration = value;
            }
        }

        private int myCurrentDownTimeDuration;
        public int CurrentDownTimeDuration
        {
            get
            {
                return myCurrentDownTimeDuration;
            }

            set
            {
                myCurrentDownTimeDuration = value;
            }
        }

        private bool myHasDiscrepancies;
        public bool HasDiscrepancies
        {
            get
            {
                return myHasDiscrepancies;
            }

            set
            {
                myHasDiscrepancies = value;
            }
        }

        private string myDiscrepanciesText;
        public string DiscrepanciesText
        {
            get
            {
                return myDiscrepanciesText;
            }

            set
            {
                myDiscrepanciesText = value;
            }
        }

        public void ResetValues()
        {
            IsPresent = false;
            LastDowntimeEvent = null;
            LastWorkbreakEvent = null;
            LastWorkgroup = -1;
            LastWorksiteChange = System.DateTime.MinValue;
            DiscrepanciesText = null;
            HasDiscrepancies = false;
        }
    }
}
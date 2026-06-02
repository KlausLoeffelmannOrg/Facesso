using ActiveDev;
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class frmImport
    {
        private EmployeeInfoItems myEmployees;
        private void AlignTimeData(TimeDataTable timeData, System.DateTime ProductionDate)
        {
            //Als erstes benötigen wir die Workgroup-Infos.
            WorkGroupInfo currentWorkgroup = null;
            var timeDataRowCount = 0;
            int firstShift = default(int);
            int lastShift = default(int);
            //Keine Datenzeilen, dann raus.
            if (timeData.Rows.Count == 0)
            {
                return;
            }

            myEmployees = new EmployeeInfoItems(0);
            TimeSettingDetail tsdFirstShift = new TimeSettingDetail();
            TimeSettingDetail tsdLastShift = new TimeSettingDetail();
            while (true)
            {
                if (timeDataRowCount > (timeData.Rows.Count - 1))
                {
                    break;
                }

                var timeRow = ((TimeDataRow)timeData.Rows[timeDataRowCount]);
                //Workgroupinfo ermitteln
                try
                {
                    currentWorkgroup = myWorkgroups.GetByWorkGroupNumber(timeRow.WorkgroupNo);
                }
                catch (Exception ex)
                {
                    ((TimeDataRow)timeData.Rows[timeDataRowCount]).HasDiscrepancies = true;
                    ((TimeDataRow)timeData.Rows[timeDataRowCount]).DiscrepanciesText = "Der Produktiv-Site mit dieser Nummer ist in Facesso nicht vorhanden und muss nachgepflegt werden.";
                    timeDataRowCount += 1;
                    continue;
                }

                //Die Textfelder in der Tabelle füllen, damit sie im Report richtig angezeigt werden können.
                ((TimeDataRow)timeData.Rows[timeDataRowCount]).WorkgroupDescription = currentWorkgroup.DisplayName;
                try
                {
                    ((TimeDataRow)timeData.Rows[timeDataRowCount]).EmployeeDescription = myEmployees.GetByPersonnelNumber(((TimeDataRow)timeData.Rows[timeDataRowCount]).EmployeeNo).DisplayName;
                }
                catch (Exception ex)
                {
                    ((TimeDataRow)timeData.Rows[timeDataRowCount]).HasDiscrepancies = true;
                    ((TimeDataRow)timeData.Rows[timeDataRowCount]).DiscrepanciesText = "Der Mitarbeiter mit dieser Personalnummer ist in Facesso nicht vorhanden und muss nachgepflegt werden.";
                    timeDataRowCount += 1;
                    continue;
                }

                //Erste und letzte Schicht ermitteln für diese Arbeitsgruppe ermitteln
                firstShift = 0;
                lastShift = 0;
                tsdFirstShift = new TimeSettingDetail();
                tsdLastShift = new TimeSettingDetail();
                for (int sCount = 1; sCount <= 4; sCount++)
                {
                    var currShift = currentWorkgroup.TimeSettingDetails.GetTimeSettingDetail(ProductionDate, sCount, true);
                    if (currShift.ImportShiftStart.HasValue)
                    {
                        if (firstShift == 0)
                        {
                            firstShift = sCount;
                            tsdFirstShift = currShift;
                        }
                    }

                    currShift = currentWorkgroup.TimeSettingDetails.GetTimeSettingDetail(ProductionDate, 5 - sCount, true);
                    if (currShift.ImportShiftEnd.HasValue)
                    {
                        if (lastShift == 0)
                        {
                            lastShift = 5 - sCount;
                            tsdLastShift = currShift;
                        }
                    }

                    if (firstShift != 0 && lastShift != 0)
                    {
                        break;
                    }
                }

                //Wir haben GAR KEINE Schichtdefinitionen gefunden, so können wir nicht arbeiten...
                if (firstShift == 0 && lastShift == 0)
                {
                    throw new ArgumentException("Das Schichtmodell ist nicht korrekt definiert - es gibt für die Arbeitsgruppe " + currentWorkgroup.DisplayName + " für " + ProductionDate.ToString("dddd, dd.MM.yy") + " keine Schichtdefinition.");
                }

                TimePeriodComparer shiftTimes = new TimePeriodComparer(tsdFirstShift.ImportShiftStart, tsdLastShift.ImportShiftEnd);
                TimePeriodComparer currTimes = new TimePeriodComparer(timeRow.StartTime, timeRow.EndTime);
                OverlappingTimeInfo oltInfo = default(OverlappingTimeInfo);
                try
                {
                    oltInfo = shiftTimes.OverlappingTimeInfo(currTimes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bei der Zeitverteilung auf das Schichtmodell ist ein Fehler aufgetreten." + System.Environment.NewLine + "Möglicherweise ist im Schichtmodell ein Zeitbereich fehlerhaft eingestellt." + System.Environment.NewLine + "Überprüfen Sie das Schichtmodell für den Wochentag " + ProductionDate.ToString("dddd") + " sowie " + "für die Produktiv-Site " + currentWorkgroup.DisplayName + System.Environment.NewLine + System.Environment.NewLine, "Fehler im Schichtmodell", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Wenn der aktuelle Zeitpunkt außerhalb des gesamten Schichtmodell ist, dann raus damit.
                if (oltInfo.TimeSpanOverlappingType == TimeSpanOverlappingTypes.EndsBefore | oltInfo.TimeSpanOverlappingType == TimeSpanOverlappingTypes.StartsAfter)
                {
                    timeData.Rows.RemoveAt(timeDataRowCount);
                    continue;
                }

                //Schicht der Startzeit ermitteln
                var foundShift = currentWorkgroup.TimeSettingDetails.FindShiftForPeriod(ProductionDate, currTimes.StartTime.Value, currTimes.EndTime.Value);
                if (foundShift == null)
                {
                    ((TimeDataRow)timeData.Rows[timeDataRowCount]).HasDiscrepancies = true;
                    ((TimeDataRow)timeData.Rows[timeDataRowCount]).DiscrepanciesText = "Dieser Buchungszeitspanne konnte keine Schicht zugewiesen werden.";
                }
                else
                {
                    ((TimeDataRow)timeData.Rows[timeDataRowCount]).Shift = foundShift.ShiftNo;
                }

                timeDataRowCount += 1;
            }

            var hasDistributedTimes = false;
            var loopCount = 0;
            do
            {
                timeDataRowCount = 0;
                hasDistributedTimes = false;
                while (true)
                {
                    if (timeDataRowCount > (timeData.Rows.Count - 1))
                    {
                        break;
                    }

                    //Aktuelle typisierte Datenzeile
                    var timeRow = ((TimeDataRow)timeData.Rows[timeDataRowCount]);
                    //Nicht verarbeiten, wenn es bereits Ungereimtheiten gab
                    if (timeRow.HasDiscrepancies)
                    {
                        timeDataRowCount += 1;
                        continue;
                    }

                    //Workgroupinfo ermitteln
                    try
                    {
                        currentWorkgroup = myWorkgroups.GetByWorkGroupNumber(timeRow.WorkgroupNo);
                    }
                    catch (Exception ex)
                    {
                        //TODO: Fehler werfen?
                        throw ex;
                        continue;
                    }

                    //Handycap zuordnen
                    try
                    {
                        timeRow.Handicap = GetHandicapFromDate(myEmployees.GetByPersonnelNumber(timeRow.EmployeeNo), ProductionDate);
                    }
                    catch (Exception ex)
                    {
                        timeRow.Handicap = 0;
                    }

                    //Schichtrahmendaten holen
                    var currShift = currentWorkgroup.TimeSettingDetails.GetTimeSettingDetail(ProductionDate, timeRow.Shift, true);
                    if (currShift.ForShift == 0)
                    {
                        timeDataRowCount += 1;
                        continue;
                    }

                    //Schwellwert ermitteln
                    var threshold = 0;
                    if (currShift.Threshold.HasValue)
                    {
                        threshold = currShift.Threshold.TypedValue;
                    }

                    TimePeriodComparer lastShiftTimes = new TimePeriodComparer(tsdLastShift.ImportShiftStart, tsdLastShift.ImportShiftEnd);
                    TimePeriodComparer currTimes = new TimePeriodComparer(timeRow.StartTime, timeRow.EndTime);
                    //Feststellen, ob der Datensatz nach vorne aufgespalten werden muss
                    if (timeRow.StartTime < currShift.ImportShiftStart.TypedValue.AddMinutes(-threshold))
                    {
                        //Zwei Buchungssätze daraus machen
                        var additionalRow = timeData.NewTimeDataRow();
                        additionalRow.StartTime = timeRow.StartTime;
                        additionalRow.EndTime = currShift.ImportShiftStart;
                        additionalRow.Shift = System.Convert.ToByte(timeRow.Shift - 1);
                        additionalRow.WorkgroupNo = timeRow.WorkgroupNo;
                        //TODO: Überprüfen, ob Pause+Ausfallzeit größer als die Restspanne werden, und falls ja, entsprechend kürzen und Fehler schreiben.
                        //TODO: Ausfallzeit und Pausenzeit zu gleichen Anteilen verteilen.
                        additionalRow.WorkBreak = 0;
                        additionalRow.DownTime = 0;
                        additionalRow.AlienEmployeeNo = timeRow.AlienEmployeeNo;
                        additionalRow.AlienID = timeRow.AlienID;
                        additionalRow.EmployeeNo = timeRow.EmployeeNo;
                        additionalRow.ID = timeRow.ID;
                        additionalRow.HasDiscrepancies = false;
                        additionalRow.EmployeeDescription = timeRow.EmployeeDescription;
                        additionalRow.WorkgroupDescription = timeRow.WorkgroupDescription;
                        if (loopCount > 0)
                        {
                            additionalRow.HasDiscrepancies = true;
                            additionalRow.DiscrepanciesText = "Dieser Buchungssatz wurde über mehr als zwei Schichten verteilt. Fehlt evnt. eine Geht-Buchung?";
                        }

                        if (additionalRow.Shift == 0)
                        {
                            additionalRow.HasDiscrepancies = true;
                            additionalRow.DiscrepanciesText += "Beim Aufteilen eines Buchungssatzes der 1. Schicht, ist diese Buchungszeitanteil aus dem Buchungstag gefallen.";
                        }

                        timeData.Rows.InsertAt(additionalRow, timeDataRowCount);
                        //Bestehenden Datensatz angleichen
                        timeRow.StartTime = currShift.ImportShiftStart;
                        hasDistributedTimes = true;
                    }

                    if ((timeRow.EndTime - timeRow.StartTime).TotalHours > 16)
                    {
                        timeRow.HasDiscrepancies = true;
                        timeRow.DiscrepanciesText = "Die ursprünglichen Anfangs- und die Endzeit lagen vor Splittung dieses Buchungssatzes mehr als 16 Stunden auseinander - fehlt eine Geht-Buchung?";
                    }

                    //Feststellen, ob der Datensatz nach hinten aufgespalten werden muss
                    if (timeRow.EndTime > currShift.ImportShiftEnd.TypedValue.AddMinutes(threshold))
                    {
                        //Aber nur, wenn es nicht die letzte Schicht ist, und nur ein Anteil kleinergleich threashold in der aktuellen Schicht ist.
                        var oti = lastShiftTimes.OverlappingTimeInfo(currTimes);
                        if (currShift.ForShift < lastShift | (currShift.ForShift == lastShift & oti.NonOverlappingMinutes < threshold))
                        {
                            //Zwei Buchungssätze daraus machen
                            var additionalRow = timeData.NewTimeDataRow();
                            additionalRow.StartTime = currShift.ImportShiftEnd;
                            additionalRow.EndTime = timeRow.EndTime;
                            additionalRow.Shift = System.Convert.ToByte(timeRow.Shift + 1);
                            additionalRow.WorkgroupNo = timeRow.WorkgroupNo;
                            //TODO: Überprüfen, ob Pause+Ausfallzeit größer als die Restspanne werden, und falls ja, entsprechend kürzen und Fehler schreiben.
                            //TODO: Ausfallzeit und Pausenzeit zu gleichen Anteilen verteilen.
                            additionalRow.WorkBreak = 0;
                            additionalRow.DownTime = 0;
                            additionalRow.AlienEmployeeNo = timeRow.AlienEmployeeNo;
                            additionalRow.AlienID = timeRow.AlienID;
                            additionalRow.EmployeeNo = timeRow.EmployeeNo;
                            additionalRow.ID = timeRow.ID;
                            additionalRow.HasDiscrepancies = false;
                            additionalRow.EmployeeDescription = timeRow.EmployeeDescription;
                            additionalRow.WorkgroupDescription = timeRow.WorkgroupDescription;
                            if (loopCount > 0)
                            {
                                additionalRow.HasDiscrepancies = true;
                                additionalRow.DiscrepanciesText = "Dieser Buchungssatz wurde über mehr als zwei Schichten verteilt. Fehlt evnt. eine Geht-Buchung?";
                            }

                            if (additionalRow.Shift > lastShift)
                            {
                                additionalRow.Shift = 0;
                                additionalRow.HasDiscrepancies = true;
                                additionalRow.DiscrepanciesText += "Beim Aufteilen eines Buchungssatzes der letzten Schicht des Buchungstages, ist diese Buchungszeitanteil aus dem Buchungstag gefallen.";
                            }

                            if (timeDataRowCount < (timeData.Rows.Count - 1))
                            {
                                timeData.Rows.InsertAt(additionalRow, timeDataRowCount + 1);
                            }
                            else
                            {
                                timeData.Rows.Add(additionalRow);
                            }

                            //Bestehenden Datensatz angleichen
                            timeRow.EndTime = currShift.ImportShiftEnd;
                            hasDistributedTimes = true;
                        }
                        else
                        {
                            //Datensatz fliegt raus
                            timeRow.HasDiscrepancies = true;
                            timeRow.DiscrepanciesText = "Wird in der nächsten Version rausgeschmissen";
                        }
                    }

                    timeDataRowCount += 1;
                }

                loopCount += 1;
            }
            while (hasDistributedTimes);
            //Nochmal final alle (vielleicht geplitteten) Buchungen rausschmeißen, die nicht ins Buchungsmodell passen
            timeDataRowCount = 0;
            while (true)
            {
                if (timeDataRowCount > (timeData.Rows.Count - 1))
                {
                    break;
                }

                var timeRow = ((TimeDataRow)timeData.Rows[timeDataRowCount]);
                TimePeriodComparer shiftTimes = new TimePeriodComparer(tsdFirstShift.ImportShiftStart, tsdLastShift.ImportShiftEnd);
                TimePeriodComparer currTimes = new TimePeriodComparer(timeRow.StartTime, timeRow.EndTime);
                var oltInfo = shiftTimes.OverlappingTimeInfo(currTimes);
                //Wenn der aktuelle Zeitpunkt außerhalb des gesamten Schichtmodell ist, dann raus damit.
                if (oltInfo.TimeSpanOverlappingType == TimeSpanOverlappingTypes.EndsBefore | oltInfo.TimeSpanOverlappingType == TimeSpanOverlappingTypes.StartsAfter)
                {
                    timeData.Rows.RemoveAt(timeDataRowCount);
                    continue;
                }

                //'Schicht der Startzeit ermitteln
                //Dim foundShift = currentWorkgroup.TimeSettingDetails.FindShiftForPeriod(ProductionDate, currTimes.StartTime.Value, currTimes.EndTime.Value)
                //If foundShift Is Nothing Then
                //    DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).HasDiscrepancies = True
                //    DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).DiscrepanciesText = "Dieser Buchungszeitspanne konnte keine Schicht zugewiesen werden."
                //Else
                //    DirectCast(timeData.Rows(timeDataRowCount), TimeDataRow).Shift = foundShift.ShiftNo
                //End If
                timeDataRowCount += 1;
            }
        }

        private void ProcessTimeData(TimeDataTable TimeData, System.DateTime ProductionDate, int shift)
        {
            var fdc = new FacessoDataContext(FacessoGeneric.SQLConnectionString);
            try
            {
                System.DateTime? currentTicket = DateTime.Now;
                //Die Daten löschen, die Importiert wurden für diese Schicht
                var timesToDelete = ((
                    from delItem in fdc.TimeLog
                    where delItem.InsertedByInterface & delItem.ProductionDate == ProductionDate.Date & delItem.Shift == shift
                    select delItem)).ToList();
                var timesToDeleteFiltered = ((
                    from delItem in timesToDelete
                    join sourceItem in ucWorkGroups.CheckedWorkGroups on delItem.IDWorkGroup equals sourceItem.IDWorkGroup
                    select delItem)).ToList();
                foreach (var logEntry in timesToDeleteFiltered)
                {
                    fdc.ExecuteCommand("DELETE FROM [TimeLog] WHERE [IDTimeLog]=@p0", new object[] { logEntry.IDTimeLog });
                }

                foreach (TimeDataRow timeLogItem in TimeData)
                {
                    //Daten umschaufeln nur für die Schicht und nur wenn es keine Probleme mit diesem Datensatz gab!
                    if (timeLogItem.Shift == shift & !(timeLogItem.HasDiscrepancies))
                    {
                        fdc.TimeLog_AddItemsForAddEdit(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary, 0, FacessoGeneric.LoginInfo.IDUser, myWorkgroups.GetByWorkGroupNumber(timeLogItem.WorkgroupNo).IDWorkGroup, myEmployees.GetByPersonnelNumber(timeLogItem.EmployeeNo).IDEmployee, ProductionDate, System.Convert.ToByte(shift), timeLogItem.StartTime, timeLogItem.EndTime, timeLogItem.WorkBreak, timeLogItem.DownTime, (timeLogItem.Handicap.HasValue ? timeLogItem.Handicap : 0), true, false, FacessoGeneric.LoginInfo.IDUser, currentTicket, false);
                    }
                }

                //Bisherige Änderungen abspeichern
                fdc.TimeLog_HandleAddEdit(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary, FacessoGeneric.LoginInfo.IDUser, currentTicket);
            }
            catch (Exception ex)
            {
                var ret = (fdc.ChangeConflicts).ToList();
                foreach (var item in ret)
                {
                    Debug.Print(item.Object.ToString());
                    Debug.Print(new string ('=', 40));
                    foreach (var item2 in item.MemberConflicts)
                    {
                        Debug.Print("Member:" + item2.Member.ToString() + "OV:" + item2.OriginalValue.ToString() + "; " + "CV:" + item2.CurrentValue.ToString());
                    }
                }

                MessageBox.Show("Beim Übernehmen der Daten ist ein Fehler aufgetreten." + System.Environment.NewLine + ex.Message + System.Environment.NewLine + System.Environment.NewLine + ex.StackTrace, "Datenimport:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessProductionData(ProductionDataTable ProdData, CombinedParametersInfo CombinedParameters)
        {
            //Die Daten für den Tag und die Arbeitsgruppe ermitteln - falls vorhanden,
            //sonst neue Strukur erzeugen
            ProductionData locProdInfo = new ProductionData(CombinedParameters);
            bool locDataChanged = default(bool);
            //und nun die neuen Daten konvertiert dort hineinschreiben,
            //dabei darauf achten, dass Daten, deren Originalwerte noch dieselben sind,
            //NICHT überschrieben werden, und dass nur die entsprechende Schicht verarbeitet wird.
            //Default View erstellen, die die Schicht selektiert.
            ProdData.DefaultView.RowFilter = "Shift=" + CombinedParameters.Shift;
            foreach (DataRowView locRow in ProdData.DefaultView)
            {
                ProductionDataItem locProdDataItem = null;
                try
                {
                    locProdDataItem = locProdInfo.GetItemFromIDLabourValue(System.Convert.ToInt32(locRow["IDLabourValue"]));
                }
                catch (Exception ex)
                {
                    ResultMessage += "Für Produktiv-Site " + CombinedParameters.WorkGroup.ListItemText + " konnte am " + CombinedParameters.ProductionDate.ToShortDateString() + " in Schicht " + CombinedParameters.Shift + " die Geräte-ID " + -System.Convert.ToInt32(locRow["IDLabourValue"]) + " nicht dem entsprechenden Arbeitswert zugewiesen werden." + System.Environment.NewLine;
                    continue;
                }

                locProdDataItem.AccumulatedAmount += System.Convert.ToDouble(locRow["TotalAmount"]);
            }

            foreach (ProductionDataItem locItem in locProdInfo)
            {
                //Daten nicht übernehmen, wenn manuell nachgearbeitet wurde,
                //und der ursprünglich gelesene Wert dem jetzigen Wert entspricht.
                if (locItem.ManuallyEdited && (locItem.AmountViaInterface == locItem.AccumulatedAmount))
                {
                    continue;
                }

                locItem.AmountViaInterface = locItem.AccumulatedAmount;
                locItem.Amount = locItem.AmountViaInterface;
                Debug.Print(locItem.LabourValue.DisplayName + ": " + locItem.Amount);
                locItem.ManuallyEdited = false;
                locDataChanged = locDataChanged | true;
            }

            //Nur speichern, wenn sich überhaupt was geändert hat!
            if (locDataChanged)
            {
                locProdInfo.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, false);
            }
        }

        public static double GetHandicapFromDate(EmployeeInfo empInfo, System.DateTime workday)
        {
            var selCmd = "select h1.Handicap" + " from EmployeeHandicaps h1" + " where h1.ValidFrom=(select MAX(s1.ValidFrom)" + " from EmployeeHandicaps s1" + " where s1.ValidFrom<=@Workday" + " and\th1.IDSubsidiary=s1.IDSubsidiary" + " and h1.IDEmployee=s1.IDEmployee" + " )" + " and h1.IDEmployee=@EMPID" + " and h1.IDSubsidiary=@SUBSID";
            SqlConnection con = new SqlConnection(FacessoGeneric.SQLConnectionString);
            using (con)
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = selCmd;
                cmd.CommandType = CommandType.Text;
                SqlParameter p = new SqlParameter("@SUBSID", empInfo.IDSubsidiary);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@EMPID", empInfo.IDEmployee);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@Workday", workday.Date);
                cmd.Parameters.Add(p);
                var res = cmd.ExecuteScalar();
                if (res == null)
                {
                    // Keine Daten für den MA gefunden
                    // also Handicap 0
                    return 0;
                }
                else
                {
                    return System.Convert.ToDouble(res);
                }
            }

            return default(double);
        }
    }
}
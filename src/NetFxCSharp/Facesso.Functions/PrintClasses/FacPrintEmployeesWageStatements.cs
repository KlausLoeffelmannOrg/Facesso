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
using System.Xml.Linq;

namespace Facesso.Functions
{
    public class FacPrintEmployeesWageStatements : FacessoPrintBase
    {
        private EmployeeAnalysisInfoItems myEmployeeWages;
        public FacPrintEmployeesWageStatements(EmployeeAnalysisInfoItems EmployeeWages, string Username) : base("Pr�mienlohnaufstellung", EmployeeWages.PeriodText, Username)
        {
            myEmployeeWages = EmployeeWages;
        }

        protected override void PrepareDocument()
        {
            base.PrepareDocument(true);
            {
                var __with0 = PrintDocument;
                __with0.CurrentFont = LayoutAndNumberFormats.U1Font.ToFont();
                __with0.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                foreach (EmployeeAnalysisInfoItem locItem in myEmployeeWages)
                {
                    if (!(locItem.Selected))
                    {
                        continue;
                    }

                    PrintEmployeeStatement(locItem);
                    __with0.PageBreak();
                }
            }
        }

        private void PrintEmployeeStatement(EmployeeAnalysisInfoItem WageItem)
        {
            {
                var __with1 = PrintDocument;
                EmployeeTimeLogInfoCollection locTimeLogInfoCollection = new EmployeeTimeLogInfoCollection();
                __with1.CurrentFont = LayoutAndNumberFormats.U1Font.ToFont();
                __with1.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                //TODO: Begriff durch Kostenstelle anpassen
                __with1.WriteLine("Pr�mienberechnung  f�r " + WageItem.EmployeeWage.FirstName + " " + WageItem.EmployeeWage.LastName);
                __with1.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with1.WriteLine("Abrechnungszeitraum:  " + WageItem.Period.StartDateMonthDescription);
                __with1.WriteLine().DistanceToNext = 5;
                //Mengentabelle der Produktiv-Site
                __with1.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with1.BeginTable(BorderStyle, 80, 100, 100, 100, 115, 100, 115);
                __with1.BuildTableHeader();
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with1.WriteCells("Tag-Nr.:", "Gesamt-" + System.Environment.NewLine + "pr�senz", "Pausen", "Ausfall", "(eigentliche) Effektivzeit", "Referenzzeit", "(eigentlicher) ang. Zeitgrad");
                __with1.BuildTableBody();
                __with1.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                for (int locDaysCount = WageItem.Period.StartDate.Day; locDaysCount <= WageItem.Period.EndDate.Day; locDaysCount++)
                {
                    //Alle TimeLogItems dieser Tage zusammensuchen
                    EmployeeTimeLogInfo locTimeLogItems = new EmployeeTimeLogInfo();
                    locTimeLogItems.RecalculateTotalReferenceIWT = true;
                    foreach (EmployeeTimeLogInfoItem locItem in WageItem.TimeLogItems)
                    {
                        if (locItem.ProductionDate == new System.DateTime(WageItem.Period.StartDate.Year, WageItem.Period.StartDate.Month, locDaysCount))
                        {
                            locTimeLogItems.Add(locItem);
                        }
                    }

                    locTimeLogInfoCollection.Add(locTimeLogItems);
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    //Wochentagsabk�rzung und Namen drucken
                    __with1.WriteCell(new DateTime(WageItem.Period.StartDate.Year, WageItem.Period.StartDate.Month, locDaysCount).ToString("(ddd) ") + locDaysCount.ToString("00"));
                    if (locTimeLogItems.Count > 0)
                    {
                        //Daten am Tag vorhanden --> drucken
                        __with1.WriteCell(locTimeLogItems.TotalAttendanceTime.ToString("#,##0.00"));
                        __with1.WriteCell(locTimeLogItems.TotalWorkBreakTime.ToString("#,##0.00"));
                        __with1.WriteCell(locTimeLogItems.TotalDownTime.ToString("#,##0.00"));
                        __with1.WriteCell("(" + locTimeLogItems.TotalEffectiveIWTAct.ToString("#,##0.00") + ")  " + locTimeLogItems.TotalEffectiveIWT.ToString("#,##0.00"));
                        __with1.WriteCell(locTimeLogItems.TotalReferenceIWT.ToString("#,##0.00"));
                        __with1.WriteCell("(" + locTimeLogItems.DegreeOfTimeAct.ToString("#,##0") + ")  " + locTimeLogItems.DegreeOfTime.ToString("#,##0"));
                    }
                    else
                    {
                        __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                        __with1.WriteCells("- - -", "- - -", "- - -", "- - -", "- - -", "- - -");
                    }
                }

                //Zusammenfassung
                __with1.CurrentFont = new Font(LayoutAndNumberFormats.SmallTableFont.ToFont(), FontStyle.Bold);
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                __with1.WriteCell("Gesamt:");
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                __with1.WriteCell(locTimeLogInfoCollection.TotalAttendanceTime.ToString("#,##0.00"));
                __with1.WriteCell(locTimeLogInfoCollection.TotalWorkBreakTime.ToString("#,##0.00"));
                __with1.WriteCell(locTimeLogInfoCollection.TotalDownTime.ToString("#,##0.00"));
                __with1.WriteCell(" (" + locTimeLogInfoCollection.TotalEffectiveIWTAct.ToString("#,##0.00") + ") " + locTimeLogInfoCollection.TotalEffectiveIWT.ToString("#,##0.00"));
                __with1.WriteCell(locTimeLogInfoCollection.TotalReferenceIWT.ToString("#,##0.00"));
                __with1.WriteCell("(" + locTimeLogInfoCollection.DegreeOfTimeAct.ToString("#,##0") + ") " + locTimeLogInfoCollection.DegreeOfTime.ToString("#,##0"));
                __with1.EndTable();
                __with1.WriteLine().DistanceToNext = 8;
                __with1.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                __with1.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with1.WriteLine("Berechnung der Pr�mie").DistanceToNext = 10;
                __with1.BeginTable(ActiveDev.Printing.ADFrameCellBorderStyle.None, 170, 170, 170, 170);
                __with1.BuildTableHeader();
                __with1.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with1.WriteCells("angepasster Zeitgrad", "Grundlohn", "Effektivstunden", "Pr�mie");
                __with1.BuildTableBody();
                __with1.CurrentFont = new Font(LayoutAndNumberFormats.TextAndTableBodyFont.ToFont(), FontStyle.Bold);
                __with1.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                __with1.WriteCell(locTimeLogInfoCollection.DegreeOfTime.ToString("#,##0") + " " + WageItem.EmployeeWage.PercentageDescription);
                __with1.WriteCell(WageItem.EmployeeWage.BaseWage.ToString("#,##0.00 �"));
                __with1.WriteCell((WageItem.EmployeeWage.IncentiveWageTime / 60).ToString("#,##0.00 \\h"));
                __with1.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                __with1.WriteCell(WageItem.EmployeeWage.TotalIncentiveWage.ToString("#,##0.00 �"));
                __with1.EndTable();
            }
        }
    }
}
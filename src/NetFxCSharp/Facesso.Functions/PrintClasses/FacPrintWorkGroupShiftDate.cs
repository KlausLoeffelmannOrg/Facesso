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

namespace Facesso.Functions
{
    public class FacPrintWorkGroupShiftDate : FacessoPrintBase
    {
        private ShiftDateWorkResultInfo mySdwResult;
        public FacPrintWorkGroupShiftDate(ShiftDateWorkResultInfo sdwResult, string Username) : base("Schichtanalyse Produktiv-Site", sdwResult.CombinedParameters.WorkGroup.ListItemText + ", Schicht " + sdwResult.CombinedParameters.Shift + "  -  " + sdwResult.CombinedParameters.ProductionDate.ToLongDateString(), Username)
        {
            mySdwResult = sdwResult;
        }

        protected override void PrepareDocument()
        {
            base.PrepareDocument();
            {
                var __with0 = PrintDocument;
                __with0.WriteLine("Produktionsergebnis:").DistanceToNext = 10;
                //Mengentabelle der Produktiv-Site
                __with0.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with0.BeginTable(BorderStyle, 100, 300, 80, 100, 80, 80);
                __with0.BuildTableHeader();
                __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with0.WriteCells("AW-Nr.:", "REFA-Arbeitswert", "Menge", "Einheit", mySdwResult.ProductionData.WorkGroup.BaseValueSynonym, "Summe");
                __with0.BuildTableBody();
                __with0.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                foreach (ProductionDataItem locItem in mySdwResult.ProductionData)
                {
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.LabourValue.LabourValueNumber.ToString());
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with0.WriteCell(locItem.LabourValue.LabourValueName);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.Amount.ToString());
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with0.WriteCell(locItem.LabourValue.Dimension.ToString());
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.LabourValue.TeHMin.ToString());
                    __with0.WriteCell(locItem.SubTotal.ToString());
                }

                __with0.EndTable();
                __with0.WriteLine().DistanceToNext = 20;
                __with0.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                __with0.WriteLine("Beteiligte Mitarbeiter:").DistanceToNext = 10;
                __with0.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with0.BeginTable(BorderStyle, 80, 150, 85, 85, 70, 75, 75, 160);
                __with0.BuildTableHeader();
                __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with0.WriteCells("Pers.-Nr.:", "Name, Vorname", "Start", "Ende", "Pause", "Ausfall", "Handic.", "Zeitendelta");
                __with0.BuildTableBody();
                __with0.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                foreach (EmployeeTimeLogInfoItem locItem in mySdwResult.EmployeeTimeLogItems)
                {
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.EmployeeInfo.PersonnelNumber.ToString());
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with0.WriteCell(locItem.EmployeeInfo.LastName + ", " + locItem.EmployeeInfo.FirstName);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell(locItem.ShiftStart.ToString("(ddd) HH:mm"));
                    __with0.WriteCell(locItem.ShiftEnd.ToString("(ddd) HH:mm"));
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.WorkBreak.ToString());
                    __with0.WriteCell(locItem.DownTime.ToString());
                    __with0.WriteCell(locItem.Handicap.ToString() + " %");
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell(locItem.TimeDeltaStrings);
                }

                __with0.EndTable();
                __with0.WriteLine();
                __with0.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with0.WriteLine("Zusammenfassung").DistanceToNext = 10;
                __with0.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with0.BeginTable(ActiveDev.Printing.ADFrameCellBorderStyle.None, 200, 400);
                __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.MiddleLeft;
                __with0.WriteCell("Produktiv-Site:");
                __with0.WriteCell(mySdwResult.CombinedParameters.WorkGroup.ListItemText);
                __with0.WriteCell("Datum:");
                __with0.WriteCell(mySdwResult.CombinedParameters.ProductionDate.ToLongDateString());
                __with0.WriteCell("Schicht:");
                __with0.WriteCell(mySdwResult.CombinedParameters.Shift.ToString());
                __with0.WriteCell("Minuten Referenz:");
                __with0.WriteCell(mySdwResult.TotalReferenceIWT.ToString("#,##0.00"));
                __with0.WriteCell("Minuten effektiv:");
                __with0.WriteCell(mySdwResult.TotalEffectiveIWT.ToString("#,##0.00"));
                __with0.WriteCell("Minuten effektiv (angepasst):");
                __with0.WriteCell(mySdwResult.TotalEffectiveIWTAdj.ToString("#,##0.00"));
                __with0.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                __with0.WriteCell(mySdwResult.CombinedParameters.WorkGroup.IncentiveIndicatorSynonym);
                __with0.WriteCell(mySdwResult.DegreeOfTime.ToString(mySdwResult.CombinedParameters.WorkGroup.IncentiveFormatString));
                __with0.WriteCell(mySdwResult.CombinedParameters.WorkGroup.IncentiveIndicatorSynonym + " (angp.)");
                __with0.WriteCell(mySdwResult.DegreeOfTimeAdj.ToString(mySdwResult.CombinedParameters.WorkGroup.IncentiveFormatString));
                __with0.EndTable();
            }
        }
    }
}
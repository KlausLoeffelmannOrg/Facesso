using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public class FacPrintWorkGroupShiftDateBatch : FacessoPrintBase
    {
        private ProductionPeriod myProductionPeriod;
        private Collection<WorkGroupInfo> myWorkGroupList;
        public FacPrintWorkGroupShiftDateBatch(Collection<WorkGroupInfo> WorkGroupList, ProductionPeriod Period, string Username) : base("Schichtanalyse Produktiv-Site", "Detailaufstellung", Username)
        {
            myProductionPeriod = Period;
            myWorkGroupList = WorkGroupList;
        }

        protected override void PrepareDocument()
        {
            base.PrepareDocument(true);
            {
                var __with0 = PrintDocument;
                //Mengentabelle der Produktiv-Site
                foreach (WorkGroupInfo locWorkGroup in myWorkGroupList)
                {
                    foreach (ProductionPeriodItem locItem in myProductionPeriod)
                    {
                        ShiftDateWorkResultInfo locSdwr = new ShiftDateWorkResultInfo(new CombinedParametersInfo(locWorkGroup, locItem.ProductionDate, locItem.Shift));
                        PrintWorkGroupStatement(locSdwr);
                        __with0.PageBreak();
                    }
                }
            }
        }

        protected virtual void PrintWorkGroupStatement(ShiftDateWorkResultInfo sdwResult)
        {
            {
                var __with1 = PrintDocument;
                __with1.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                __with1.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with1.WriteLine("Schichtanalyse Produktiv-Site");
                __with1.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with1.WriteLine(sdwResult.CombinedParameters.WorkGroup.ListItemText);
                __with1.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                __with1.WriteLine("Schicht: " + sdwResult.CombinedParameters.Shift + "  -  " + sdwResult.CombinedParameters.ProductionDate.ToLongDateString()).DistanceToNext = 20;
                __with1.WriteLine("Produktionsergebnis:").DistanceToNext = 10;
                //Mengentabelle der Produktiv-Site
                __with1.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with1.BeginTable(BorderStyle, 100, 300, 80, 100, 80, 80);
                __with1.BuildTableHeader();
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with1.WriteCells("AW-Nr.:", "REFA-Arbeitswert", "Menge", "Einheit", sdwResult.ProductionData.WorkGroup.BaseValueSynonym, "Summe");
                __with1.BuildTableBody();
                __with1.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                foreach (ProductionDataItem locItem in sdwResult.ProductionData)
                {
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with1.WriteCell(locItem.LabourValue.LabourValueNumber.ToString());
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with1.WriteCell(locItem.LabourValue.LabourValueName);
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with1.WriteCell(locItem.Amount.ToString());
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with1.WriteCell(locItem.LabourValue.Dimension.ToString());
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with1.WriteCell(locItem.LabourValue.TeHMin.ToString());
                    __with1.WriteCell(locItem.SubTotal.ToString());
                }

                __with1.EndTable();
                __with1.WriteLine().DistanceToNext = 20;
                __with1.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                __with1.WriteLine("Beteiligte Mitarbeiter:").DistanceToNext = 10;
                __with1.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with1.BeginTable(BorderStyle, 80, 150, 85, 85, 70, 75, 75, 160);
                __with1.BuildTableHeader();
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with1.WriteCells("Pers.-Nr.:", "Name, Vorname", "Start", "Ende", "Pause", "Ausfall", "Handicap", "Zeitendelta");
                __with1.BuildTableBody();
                __with1.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                foreach (EmployeeTimeLogInfoItem locItem in sdwResult.EmployeeTimeLogItems)
                {
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with1.WriteCell(locItem.EmployeeInfo.PersonnelNumber.ToString());
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with1.WriteCell(locItem.EmployeeInfo.LastName + ", " + locItem.EmployeeInfo.FirstName);
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with1.WriteCell(locItem.ShiftStart.ToString("(ddd) HH:mm"));
                    __with1.WriteCell(locItem.ShiftEnd.ToString("(ddd) HH:mm"));
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with1.WriteCell(locItem.WorkBreak.ToString());
                    __with1.WriteCell(locItem.DownTime.ToString());
                    __with1.WriteCell(locItem.Handicap.ToString() + " %");
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with1.WriteCell(locItem.TimeDeltaStrings);
                }

                __with1.EndTable();
                __with1.WriteLine();
                __with1.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with1.WriteLine("Zusammenfassung").DistanceToNext = 10;
                __with1.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with1.BeginTable(ActiveDev.Printing.ADFrameCellBorderStyle.None, 200, 400);
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.MiddleLeft;
                __with1.WriteCell("Produktiv-Site:");
                __with1.WriteCell(sdwResult.CombinedParameters.WorkGroup.ListItemText);
                __with1.WriteCell("Datum:");
                __with1.WriteCell(sdwResult.CombinedParameters.ProductionDate.ToLongDateString());
                __with1.WriteCell("Schicht:");
                __with1.WriteCell(sdwResult.CombinedParameters.Shift.ToString());
                __with1.WriteCell("Minuten Referenz:");
                __with1.WriteCell(sdwResult.TotalReferenceIWT.ToString("#,##0.00"));
                __with1.WriteCell("Minuten effektiv:");
                __with1.WriteCell(sdwResult.TotalEffectiveIWT.ToString("#,##0.00"));
                __with1.WriteCell("Minuten effektiv (angepasst):");
                __with1.WriteCell(sdwResult.TotalEffectiveIWTAdj.ToString("#,##0.00"));
                __with1.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                __with1.WriteCell(sdwResult.CombinedParameters.WorkGroup.IncentiveIndicatorSynonym);
                __with1.WriteCell(sdwResult.DegreeOfTime.ToString(sdwResult.CombinedParameters.WorkGroup.IncentiveFormatString));
                __with1.EndTable();
            }
        }
    }
}
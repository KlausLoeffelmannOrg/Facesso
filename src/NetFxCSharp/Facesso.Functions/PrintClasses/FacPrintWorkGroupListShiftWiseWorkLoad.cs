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
    public class FacPrintWorkGroupListShiftWiseWorkLoad : FacessoPrintBase
    {
        private WorkGroupAnalysisInfoItems myWorkGroupAnalysis;
        private ProductionPeriod myProductionPeriod;
        public FacPrintWorkGroupListShiftWiseWorkLoad(WorkGroupAnalysisInfoItems WorkGroupAnalysis, ProductionPeriod Period, string Username) : base("Produktiv-Site-Auswertung", WorkGroupAnalysis.Period.RangeDescription, Username)
        {
            myWorkGroupAnalysis = WorkGroupAnalysis;
            myProductionPeriod = Period;
        }

        protected override void PrepareDocument()
        {
            base.PrepareDocument();
            bool locDoPrint = default(bool);
            double locDownTimeTotal = default(double);
            double locBreakTimeTotal = default(double);
            double locTotalAttendanceTime = default(double);
            double locTotalEffectiveIWT = default(double);
            double locTotalEffectiveIWTAdj = default(double);
            double locTotalReferenceIWT = default(double);
            double locTotalWorkingTime = default(double);
            {
                var __with0 = PrintDocument;
                __with0.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                __with0.WriteLine(myProductionPeriod.ShiftParameters.ToString()).DistanceToNext = 10;
                //Mengentabelle der Produktiv-Site
                __with0.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with0.BeginTable(BorderStyle, 65, 85, 150, 120, 145, 135, 90);
                __with0.BuildTableHeader();
                __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with0.WriteCells("Schicht", "Site-Nr.:", "Site-Name", "Unterbr.-" + System.Environment.NewLine + "zeiten", "Netto-" + System.Environment.NewLine + "zeiten", "Kennzahlen", "Auslastung");
                __with0.BuildTableBody();
                __with0.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                foreach (WorkGroupAnalysisInfo locAnalysisInfo in myWorkGroupAnalysis)
                {
                    for (int locShift = 1; locShift <= 4; locShift++)
                    {
                        WorkGroupAnalysisInfoItem locItem = null;
                        foreach (var _vbForEach_0 in locAnalysisInfo)
                        {
                            locItem = _vbForEach_0;
                            {
                                if (locItem.Shift == locShift)
                                {
                                    if (locItem.DegreeOfTime > -1)
                                    {
                                        locDoPrint = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (locDoPrint & locItem != null)
                        {
                            locDoPrint = !(locDoPrint);
                            //Leerzeiten nicht drucken!
                            __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                            __with0.WriteCell(locShift.ToString());
                            __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                            __with0.WriteCell(locAnalysisInfo.WorkGroupInfo.WorkGroupNumber.ToString());
                            __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                            __with0.WriteCell(locAnalysisInfo.WorkGroupInfo.WorkGroupName);
                            __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                            __with0.WriteCell(locItem.GeneralBreakTimeStrings);
                            __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                            __with0.WriteCell(locItem.IncentiveTimeDeltaStrings);
                            __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                            __with0.WriteCell("Zeitgrad: " + locItem.DegreeOfTime.ToString("##0") + System.Environment.NewLine + "Zeitgrad (angp.): " + locItem.DegreeOfTimeAdj.ToString("##0"));
                            __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                            __with0.WriteCell(locAnalysisInfo.PercentageWorkload.ToString("#,##0.00 " + "%"));
                            locDownTimeTotal += locItem.TotalDownTime;
                            locBreakTimeTotal += locItem.TotalWorkBreakTime;
                            locTotalAttendanceTime += locItem.TotalAttendanceTime;
                            locTotalEffectiveIWT += locItem.TotalEffectiveIWT;
                            locTotalEffectiveIWTAdj += locItem.TotalEffectiveIWTAdj;
                            locTotalReferenceIWT += locItem.TotalReferenceIWT;
                            locTotalWorkingTime += locItem.TotalWorkingTime;
                        }
                    }
                }

                __with0.EndTable();
                __with0.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                __with0.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Left;
                __with0.WriteLine();
                __with0.WriteLine("Zusammenfassung:");
                __with0.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                __with0.WriteLine("Gesamt-Ausfallzeit: " + locDownTimeTotal.ToString("#,##0"));
                __with0.WriteLine("Gesamt-Pausenzeit: " + locBreakTimeTotal.ToString("#,##0"));
                __with0.WriteLine("Gesamt-Anwesenheitszeit: " + locTotalAttendanceTime.ToString("#,##0"));
                __with0.WriteLine("Effektive Pr�mienlohnzeit: " + locTotalEffectiveIWT.ToString("#,##0"));
                __with0.WriteLine("Effektive angepasste Pr�mienlohnzeit: " + locTotalEffectiveIWTAdj.ToString("#,##0"));
                __with0.WriteLine("Gesamt-Referenzzeit: " + locTotalReferenceIWT.ToString("#,##0"));
                __with0.WriteLine("Gesamt-Arbeitszeit (ohne Pausen und Ausf�lle): " + locTotalWorkingTime.ToString("#,##0"));
            }
        }
    }
}
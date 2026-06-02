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
    public class FacPrintWorkGroupAnalysisBatch : FacessoPrintBase
    {
        private WorkGroupAnalysisInfoItems myWorkGroupAnalysis;
        private ProductionPeriod myProductionPeriod;
        public FacPrintWorkGroupAnalysisBatch(WorkGroupAnalysisInfoItems WorkGroupAnalysis, ProductionPeriod Period, string Username) : base("Produktiv-Site-Auswertung", WorkGroupAnalysis.Period.RangeDescription, Username)
        {
            myWorkGroupAnalysis = WorkGroupAnalysis;
            myProductionPeriod = Period;
        }

        protected override void PrepareDocument()
        {
            base.PrepareDocument(true);
            {
                var __with0 = PrintDocument;
                __with0.WriteLine().DistanceToNext = 10;
                //Mengentabelle der Produktiv-Site
                foreach (WorkGroupAnalysisInfo locItem in myWorkGroupAnalysis)
                {
                    PrintWorkGroupStatement(locItem);
                    __with0.PageBreak();
                }
            }
        }

        protected virtual void PrintWorkGroupStatement(WorkGroupAnalysisInfo AnalysisInfo)
        {
            bool locFound = default(bool);
            {
                var __with1 = PrintDocument;
                __with1.CurrentFont = LayoutAndNumberFormats.U1Font.ToFont();
                __with1.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                //TODO: Begriff durch Kostenstelle anpassen
                __with1.WriteLine("Site-Analyse f�r " + AnalysisInfo.WorkGroupInfo.WorkGroupNumber + " " + AnalysisInfo.WorkGroupInfo.WorkGroupName);
                __with1.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with1.WriteLine("Zeitraum: " + myProductionPeriod.StartDate.ToString("ddd, dd.MM.yyyy") + " bis " + myProductionPeriod.EndDate.ToString("ddd, dd.MM.yyyy"));
                if (myProductionPeriod.ShiftParameters != null)
                {
                    __with1.WriteLine(myProductionPeriod.ShiftParameters.ToString());
                }

                __with1.WriteLine().DistanceToNext = 5;
                //Mengentabelle der Produktiv-Site
                __with1.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with1.BeginTable(BorderStyle, 70, 100, 100, 100, 115, 100, 115);
                __with1.BuildTableHeader();
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                //Todo: Zeitgrad durch Kostenstellendefinitiontext f�r Leistungsindikator ersetzen
                __with1.WriteCells("Tag", "Pausen", "Ausfall", "(angepasste) Effektivzeit", "Referenzzeit", "Auslastung", "(angepasster) Zeitgrad");
                __with1.BuildTableBody();
                __with1.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                for (int locDaysCount = Convert.ToInt32(myProductionPeriod.StartDate.ToOADate()); locDaysCount <= Convert.ToInt32(myProductionPeriod.EndDate.ToOADate()); locDaysCount++)
                {
                    //rausfinden, ob's Daten an diesem Tag gibt
                    WorkGroupAnalysisInfoItem locItem = null;
                    locFound = false;
                    foreach (var _vbForEach_0 in AnalysisInfo)
                    {
                        locItem = _vbForEach_0;
                        {
                            if (locItem.ProductionDate == System.DateTime.FromOADate(locDaysCount))
                            {
                                locFound = true;
                                break;
                            }
                        }
                    }

                    if (locFound == false)
                    {
                        locItem = null;
                    }

                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    //Wochentagsabk�rzung und Namen drucken
                    __with1.WriteCell(System.DateTime.FromOADate(locDaysCount).ToString("(ddd) dd"));
                    if (locItem == null)
                    {
                        __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                        __with1.WriteCells("- - -", "- - -", "- - -", "- - -", "- - -", "- - -");
                    }
                    else
                    {
                        __with1.WriteCell(locItem.TotalWorkBreakTime.ToString());
                        __with1.WriteCell(locItem.TotalDownTime.ToString());
                        __with1.WriteCell("(" + locItem.TotalEffectiveIWTAdj.ToString() + ") " + locItem.TotalEffectiveIWT.ToString());
                        __with1.WriteCell(locItem.TotalReferenceIWT.ToString());
                        __with1.WriteCell("- n.i.p. -");
                        __with1.WriteCell("(" + locItem.DegreeOfTimeAdj.ToString("##0") + ") " + locItem.DegreeOfTime.ToString("##0"));
                    }
                }

                //Zusammenfassung
                __with1.CurrentFont = new Font(LayoutAndNumberFormats.SmallTableFont.ToFont(), FontStyle.Bold);
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                __with1.WriteCell("Gesamt:");
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                __with1.WriteCell(AnalysisInfo.TotalWorkBreakTime.ToString());
                __with1.WriteCell(AnalysisInfo.TotalDownTime.ToString());
                __with1.WriteCell("(" + AnalysisInfo.TotalEffectiveIWTAdj.ToString() + ") " + AnalysisInfo.TotalEffectiveIWTAdj.ToString());
                __with1.WriteCell(AnalysisInfo.TotalReferenceIWT.ToString());
                __with1.WriteCell(AnalysisInfo.PercentageWorkload.ToString("##0.00") + " %");
                __with1.WriteCell("(" + AnalysisInfo.DegreeOfTimeAdj.ToString("##0") + ") " + AnalysisInfo.DegreeOfTime.ToString("##0"));
                __with1.EndTable();
            }
        }
    }
}
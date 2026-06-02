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
    public class FacPrintWorkGroupListShiftCondensed : FacessoPrintBase
    {
        private WorkGroupAnalysisInfoItems myWorkGroupAnalysis;
        private ProductionPeriod myProductionPeriod;
        public FacPrintWorkGroupListShiftCondensed(WorkGroupAnalysisInfoItems WorkGroupAnalysis, ProductionPeriod Period, string Username) : base("Produktiv-Site-Auswertung", WorkGroupAnalysis.Period.RangeDescription, Username)
        {
            myWorkGroupAnalysis = WorkGroupAnalysis;
            myProductionPeriod = Period;
        }

        protected override void PrepareDocument()
        {
            base.PrepareDocument();
            {
                var __with0 = PrintDocument;
                __with0.WriteLine(myProductionPeriod.ShiftParameters.ToString()).DistanceToNext = 10;
                //Mengentabelle der Produktiv-Site
                __with0.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with0.BeginTable(BorderStyle, 65, 175, 135, 110, 135, 125);
                __with0.BuildTableHeader();
                __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with0.WriteCells("Nr.:", "Site-Name", "Brutto-" + System.Environment.NewLine + "zeiten", "Unterbr.-" + System.Environment.NewLine + "zeiten", "Netto-" + System.Environment.NewLine + "zeiten", "Kennzahlen");
                __with0.BuildTableBody();
                __with0.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                foreach (WorkGroupAnalysisInfo locItem in myWorkGroupAnalysis)
                {
                    //Leerzeiten nicht drucken!
                    if (locItem.DegreeOfTime == -1)
                    {
                        continue;
                    }

                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.WorkGroupInfo.WorkGroupNumber.ToString());
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with0.WriteCell(locItem.WorkGroupInfo.WorkGroupName);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell(locItem.AttendanceTimeDeltaStrings);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.GeneralBreakTimeStrings);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell(locItem.IncentiveTimeDeltaStrings);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell("Zeitgrad: " + locItem.DegreeOfTime.ToString("##0") + System.Environment.NewLine + "Zeitgrad (angp.): " + locItem.DegreeOfTimeAdj.ToString("##0") + System.Environment.NewLine + "Auslastung:" + locItem.PercentageWorkload.ToString("#,##0.00") + " %");
                }

                __with0.EndTable();
            }
        }
    }
}
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public class FacPrintEmployeesWageList : FacessoPrintBase
    {
        private EmployeeAnalysisInfoItems myEmployeeWages;
        public FacPrintEmployeesWageList(EmployeeAnalysisInfoItems EmployeeWages, string Username) : base("Pr�mienlohnliste", EmployeeWages.PeriodText, Username)
        {
            myEmployeeWages = EmployeeWages;
        }

        public override bool HasExcelExport
        {
            get
            {
                return true;
            }
        }

        protected override void ExcelExport(string Filename)
        {
            StreamWriter locSW = (new Microsoft.VisualBasic.Devices.Computer()).FileSystem.OpenTextFileWriter(Filename, false, System.Text.Encoding.Default);
            locSW.Write("Pers-Nr.;");
            locSW.Write("Name;");
            locSW.Write("Vorname;");
            locSW.Write("Arbeitszeit;");
            locSW.Write("Pausenzeit;");
            locSW.Write("Referenzzeit;");
            locSW.Write("Effektivzeit;");
            locSW.Write("angep. Effektivzeit;");
            locSW.Write("Zeitgrad;");
            locSW.Write("angep. Zeitgrad;");
            locSW.Write("Grundlohn;");
            locSW.Write("Effektivstunden;");
            locSW.WriteLine("Pr�mie");
            foreach (EmployeeAnalysisInfoItem locItem in myEmployeeWages)
            {
                //Leerzeiten nicht drucken!
                if (!(locItem.Selected))
                {
                    continue;
                }

                locSW.Write(locItem.EmployeeWage.PersonnelNumber.ToString() + ";");
                locSW.Write(locItem.EmployeeWage.LastName + "; " + locItem.EmployeeWage.FirstName + ";");
                locSW.Write(locItem.TimeLogItems.TotalAttendanceTime.ToString() + ";");
                locSW.Write(locItem.TimeLogItems.TotalWorkBreakTime.ToString() + ";");
                locSW.Write(locItem.TimeLogItems.TotalReferenceIWT.ToString() + ";");
                locSW.Write(locItem.TimeLogItems.TotalEffectiveIWT.ToString() + ";");
                locSW.Write(locItem.TimeLogItems.TotalEffectiveIWTAdj.ToString() + ";");
                locSW.Write(locItem.TimeLogItems.DegreeOfTime.ToString() + ";");
                locSW.Write(locItem.TimeLogItems.DegreeOfTimeAdj.ToString() + ";");
                locSW.Write(locItem.EmployeeWage.BaseWage.ToString() + ";");
                locSW.Write((locItem.EmployeeWage.IncentiveWageTime / 60).ToString() + ";");
                locSW.WriteLine(locItem.EmployeeWage.TotalIncentiveWage.ToString());
            }

            locSW.Flush();
            locSW.Close();
        }

        protected override void PrepareDocument()
        {
            base.PrepareDocument();
            {
                var __with0 = PrintDocument;
                __with0.WriteLine().DistanceToNext = 10;
                //Mengentabelle der Produktiv-Site
                __with0.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with0.BeginTable(BorderStyle, 55, 135, 135, 135, 90, 60, 80, 80);
                __with0.BuildTableHeader();
                __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with0.WriteCells("P.-Nr.:", "Name, Vorname", "Anwesenheits-" + System.Environment.NewLine + "zeiten", "Bonus-" + System.Environment.NewLine + "zeiten", "Zeitgrad", "Grund- lohn", "Effektiv- stunden", "Pr�mie");
                __with0.BuildTableBody();
                __with0.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                foreach (EmployeeAnalysisInfoItem locItem in myEmployeeWages)
                {
                    //Leerzeiten nicht drucken!
                    if (!(locItem.Selected))
                    {
                        continue;
                    }

                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.EmployeeWage.PersonnelNumber.ToString());
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with0.WriteCell(locItem.EmployeeWage.LastName + ", " + locItem.EmployeeWage.FirstName);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell(locItem.TimeLogItems.AttendanceTimeDeltaStrings);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell(locItem.TimeLogItems.IncentiveTimeDeltaStrings);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell("Zeitgrad: " + locItem.EmployeeWage.DegreeOfTime.ToString("##0") + System.Environment.NewLine + locItem.EmployeeWage.PercentageDescription);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.EmployeeWage.BaseWage.ToString("#,##0.00 �"));
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell((locItem.EmployeeWage.IncentiveWageTime / 60).ToString("#,##0.00 \\h"));
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.EmployeeWage.TotalIncentiveWage.ToString("#,##0.00 �"));
                }

                __with0.EndTable();
            }
        }
    }
}
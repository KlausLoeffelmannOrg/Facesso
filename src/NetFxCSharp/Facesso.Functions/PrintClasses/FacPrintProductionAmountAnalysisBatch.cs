using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public class FacPrintProductionAmountAnalysisBatch : FacessoPrintBase
    {
        private WorkgroupsProductionDataAmounts myWorkgroupsAmounts;
        public FacPrintProductionAmountAnalysisBatch(WorkgroupsProductionDataAmounts WorkgroupsAmounts, string Username) : base("Mengenanalyse", "", Username)
        {
            myWorkgroupsAmounts = WorkgroupsAmounts;
        }

        protected override void PrepareDocument()
        {
            if (myWorkgroupsAmounts.CategorisedBy == ProductionDataAmountsCategory.None)
            {
                base.PrepareDocument(true);
                {
                    var __with0 = PrintDocument;
                    __with0.WriteLine().DistanceToNext = 10;
                    //Mengentabelle der Produktiv-Site
                    foreach (WorkgroupProductionDataAmounts locItem in myWorkgroupsAmounts)
                    {
                        PrintWorkGroupStatement(locItem);
                        __with0.PageBreak();
                    }
                }
            }
            else if (myWorkgroupsAmounts.CategorisedBy == ProductionDataAmountsCategory.LabourValues)
            {
                PrintWorkgroupStatementCategorisedByLabourValues();
            }
            else
            {
                PrintWorkgroupStatementCategorisedByCostCenters();
            }
        }

        protected virtual void PrintWorkgroupStatementCategorisedByCostCenters()
        {
            double locSum = default(double);
            {
                var __with1 = PrintDocument;
                __with1.CurrentFont = LayoutAndNumberFormats.U1Font.ToFont();
                __with1.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                __with1.WriteLine("Kostenstellenanalyse  auf Produktionsmengen und Vorgabezeitbasis");
                __with1.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with1.WriteLine("Zeitraum: " + myWorkgroupsAmounts.Startdate.ToString("ddd, dd.MM.yyyy") + " bis " + myWorkgroupsAmounts.EndDate.ToString("ddd, dd.MM.yyyy"));
                __with1.WriteLine().DistanceToNext = 5;
                //Mengentabelle der Produktiv-Site
                __with1.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with1.BeginTable(BorderStyle, 70, 300, 150, 150);
                __with1.BuildTableHeader();
                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with1.WriteCells("Nr.", "Kostenstellenname", "Produktionszeit (Soll) in HMin", "... in Stunden");
                __with1.BuildTableBody();
                __with1.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                DataView locDataView = new DataView(myWorkgroupsAmounts.CategorisationTable);
                locDataView.Sort = "CostCenterNo";
                foreach (DataRowView locDataRow in locDataView)
                {
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with1.WriteCell(locDataRow["CostCenterNo"].ToString());
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with1.WriteCell(locDataRow["CostCenterName"].ToString());
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with1.WriteCell(System.Convert.ToDouble(locDataRow["AmountIncentiveWageProductionTime"]).ToString("#,##0.00"));
                    locSum += System.Convert.ToDouble(locDataRow["AmountIncentiveWageProductionTime"]);
                    __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with1.WriteCell((System.Convert.ToDouble(locDataRow["AmountIncentiveWageProductionTime"]) / 60).ToString("#,##0.00"));
                }

                __with1.EndTable();
                __with1.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                __with1.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Left;
                __with1.WriteLine();
                __with1.WriteLine("Zusammenfassung:");
                __with1.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                __with1.WriteLine("Gesamtaufwand  im Zeitraum in Hmin/Stunden: " + locSum.ToString("#,##0.00") + " / " + (locSum / 60).ToString("#,##0.00"));
                __with1.WriteLine("Ausfallzeiten  im Zeitraum in HMin/Stunden: ");
            }
        }

        protected virtual void PrintWorkgroupStatementCategorisedByLabourValues()
        {
            {
                var __with2 = PrintDocument;
                __with2.CurrentFont = LayoutAndNumberFormats.U1Font.ToFont();
                __with2.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                __with2.WriteLine("Mengenanalyse f�r ausgew�hlte Produktiv-Sites, kategorisiert nach Arbeitswert-Nummern");
                __with2.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with2.WriteLine("Zeitraum: " + myWorkgroupsAmounts.Startdate.ToString("ddd, dd.MM.yyyy") + " bis " + myWorkgroupsAmounts.EndDate.ToString("ddd, dd.MM.yyyy"));
                __with2.WriteLine().DistanceToNext = 5;
                //Mengentabelle der Produktiv-Site
                __with2.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with2.BeginTable(BorderStyle, 70, 350, 70, 80, 80, 80);
                __with2.BuildTableHeader();
                __with2.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with2.WriteCells("Nr.", "Beschreibung", "Kst.-Nr.", "Summe", "Einheit", "te in HMin");
                __with2.BuildTableBody();
                __with2.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                DataView locDataView = new DataView(myWorkgroupsAmounts.CategorisationTable);
                locDataView.Sort = "LabourValueNumber";
                foreach (DataRowView locDataRow in locDataView)
                {
                    __with2.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with2.WriteCell(locDataRow["LabourValueNumber"].ToString());
                    __with2.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with2.WriteCell(locDataRow["LabourValueDescription"].ToString());
                    __with2.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with2.WriteCell(locDataRow["CostCenterNo"].ToString());
                    __with2.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with2.WriteCell(System.Convert.ToDouble(locDataRow["TotalAmount"]).ToString("#,##0.00"));
                    __with2.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with2.WriteCell(locDataRow["LabourValueDimension"].ToString());
                    __with2.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with2.WriteCell(System.Convert.ToDouble(locDataRow["LabourValueTeHMin"]).ToString("#,##0.000"));
                    __with2.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                }

                __with2.EndTable();
            }
        }

        protected virtual void PrintWorkGroupStatement(WorkgroupProductionDataAmounts WorkgroupAmounts)
        {
            double locDegreeOfTimeFaktor = WorkgroupAmounts.Workgroup.CurrentDegreeOfTime / 100;
            double locTotalHours = default(double);
            double locHours = default(double);
            double locUnitPerHour = default(double);
            {
                var __with3 = PrintDocument;
                __with3.CurrentFont = LayoutAndNumberFormats.U1Font.ToFont();
                __with3.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                __with3.WriteLine("Mengenanalyse  f�r " + WorkgroupAmounts.Workgroup.WorkGroupNumber + " " + WorkgroupAmounts.Workgroup.WorkGroupName);
                __with3.CurrentFont = LayoutAndNumberFormats.U2Font.ToFont();
                __with3.WriteLine("Zeitraum: " + WorkgroupAmounts.Startdate.ToString("ddd, dd.MM.yyyy") + " bis " + WorkgroupAmounts.EndDate.ToString("ddd, dd.MM.yyyy"));
                __with3.WriteLine().DistanceToNext = 5;
                //Mengentabelle der Produktiv-Site
                __with3.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with3.BeginTable(BorderStyle, 70, 220, 70, 80, 80, 80, 80, 80);
                __with3.BuildTableHeader();
                __with3.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with3.WriteCells("Nr.", "Beschreibung", "Kst.-Nr.", "Summe", "Einheit", "te in HMin", "Aufwand in Std.", "St�ck pro Std.");
                __with3.BuildTableBody();
                __with3.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                //TODO: Nachkommastellen und Texte in Abh�ngigkeit vom Arbeitswert anpassen
                foreach (WorkgroupProductionDataAmount locItem in WorkgroupAmounts)
                {
                    __with3.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with3.WriteCell(locItem.LabourValue.LabourValueNumber.ToString());
                    __with3.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with3.WriteCell(locItem.LabourValue.LabourValueName);
                    __with3.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with3.WriteCell(locItem.LabourValue.CostCenterNo.ToString());
                    __with3.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with3.WriteCell(locItem.TotalAmount.ToString("#,##0.00"));
                    __with3.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with3.WriteCell(locItem.LabourValue.Dimension);
                    __with3.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with3.WriteCell(locItem.LabourValue.TeHMin.ToString("#,##0.000"));
                    __with3.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    locHours = locItem.LabourValue.TeHMin * locItem.TotalAmount / locDegreeOfTimeFaktor / 60;
                    __with3.WriteCell((locHours).ToString("#,##0.00"));
                    locUnitPerHour = locItem.TotalAmount / locHours;
                    __with3.WriteCell((locUnitPerHour).ToString("#,##0.00"));
                    locTotalHours += locHours;
                }

                __with3.EndTable();
                __with3.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                __with3.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Left;
                __with3.WriteLine();
                __with3.WriteLine("Zusammenfassung:");
                __with3.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                __with3.WriteLine("Zeitgrad dieser Gruppe: " + WorkgroupAmounts.Workgroup.CurrentDegreeOfTime.ToString("#,##0"));
                __with3.WriteLine("Gesamtstundenaufwand: " + locTotalHours.ToString("#,##0.00") + "  Stunden");
            }
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
            locSW.Write("PS-Nr.;");
            locSW.Write("Produktiv-Site;");
            locSW.Write("Zeitgrad;");
            locSW.Write("AW-Nr.;");
            locSW.Write("Beschreibung;");
            locSW.Write("te-hMin;");
            locSW.Write("Kst.-Nr.;");
            locSW.Write("Kostenstellenname;");
            locSW.Write("Summe;");
            locSW.WriteLine("Einheit;");
            foreach (WorkgroupProductionDataAmounts locWorkgroupAmounts in myWorkgroupsAmounts)
            {
                double locDegreeOfTime = locWorkgroupAmounts.Workgroup.CurrentDegreeOfTime;
                foreach (WorkgroupProductionDataAmount locItem in locWorkgroupAmounts)
                {
                    locSW.Write(locWorkgroupAmounts.Workgroup.WorkGroupNumber.ToString() + ";");
                    locSW.Write(locWorkgroupAmounts.Workgroup.WorkGroupName + ";");
                    locSW.Write(locDegreeOfTime + ";");
                    locSW.Write(locItem.LabourValue.LabourValueNumber.ToString() + ";");
                    locSW.Write(locItem.LabourValue.LabourValueName + ";");
                    locSW.Write(locItem.LabourValue.TeHMin + ";");
                    locSW.Write(locItem.LabourValue.CostCenterNo.ToString() + ";");
                    locSW.Write(locItem.LabourValue.CostCenterName + ";");
                    locSW.Write(locItem.TotalAmount.ToString("#,##0.00") + ";");
                    locSW.WriteLine(locItem.LabourValue.Dimension + ";");
                }
            }

            locSW.Flush();
            locSW.Close();
        }
    }
}
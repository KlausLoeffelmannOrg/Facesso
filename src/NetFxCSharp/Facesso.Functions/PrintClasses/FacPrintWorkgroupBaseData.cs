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
    public class FacPrintWorkgroupBaseData : FacessoPrintBase
    {
        private WorkgroupBaseDataPrintParameters myParameters;
        public FacPrintWorkgroupBaseData(WorkgroupBaseDataPrintParameters PrintParameters, string Username) : base("Stammdatenliste", "Stand:" + System.DateTime.Now.ToLongDateString() + " - " + System.DateTime.Now.ToShortTimeString(), Username)
        {
            myParameters = PrintParameters;
        }

        protected override void PrepareDocument()
        {
            base.PrepareDocument(true);
            if (myParameters.OnlyPrintListOfLabourValues)
            {
                PrintListOfLabourValues();
            }
            else
            {
                PrintWorkGroups();
            }
        }

        public void PrintListOfLabourValues()
        {
            //Daten ermitteln
            dsLabourValues.dtLabourValuesDataTable locLabourValues = default(dsLabourValues.dtLabourValuesDataTable);
            Facesso.Functions.dsLabourValuesTableAdapters.dtLabourValuesTableAdapter locTALabourValues = new Facesso.Functions.dsLabourValuesTableAdapters.dtLabourValuesTableAdapter();
            locTALabourValues.Connection = new System.Data.SqlClient.SqlConnection(FacessoGeneric.SQLConnectionString);
            locLabourValues = locTALabourValues.GetDataByIDSubsidiary(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary);
            {
                var __with0 = PrintDocument;
                __with0.CurrentFont = LayoutAndNumberFormats.U1Font.ToFont();
                __with0.WriteLine("Liste der REFA-Arbeitswerte:").DistanceToNext = 10;
                //Mengentabelle der Produktiv-Site
                __with0.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with0.BeginTable(BorderStyle, 70, 250, 75, 100, 70, 70, 150);
                __with0.BuildTableHeader();
                __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with0.WriteCells("AW-Nr.:", "REFA-Arbeitswert", "Einheit", "Perf.-Ind.", "Wert", "Kstnr.:", "Kostenstellenname:");
                __with0.BuildTableBody();
                __with0.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                foreach (dsLabourValues.dtLabourValuesRow locItem in locLabourValues)
                {
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.LabourValueNumber.ToString());
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with0.WriteCell(locItem.LabourValueName);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.Dimension.ToString());
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with0.WriteCell(locItem.BaseValueSynonym);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    //TODO: Richtiges Format einbauen!
                    __with0.WriteCell(locItem.TeHMin.ToString("#,##0.000"));
                    __with0.WriteCell(locItem.CostCenterNo.ToString());
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with0.WriteCell(locItem.CostCenterName);
                }

                __with0.EndTable();
            }
        }

        public void PrintWorkGroups()
        {
            //Daten ermitteln
            dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsDataTable locAssignments = default(dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsDataTable);
            dsWorkgroupAssignments.dtWorkGroupsDataTable locWorkGroups = default(dsWorkgroupAssignments.dtWorkGroupsDataTable);
            Facesso.Functions.dsWorkgroupAssignmentsTableAdapters.dtLabourValuesToWorkGroupAssignmentsTableAdapter locTaAssignments = new Facesso.Functions.dsWorkgroupAssignmentsTableAdapters.dtLabourValuesToWorkGroupAssignmentsTableAdapter();
            Facesso.Functions.dsWorkgroupAssignmentsTableAdapters.dtWorkGroupsTableAdapter locTaWorkgroups = new Facesso.Functions.dsWorkgroupAssignmentsTableAdapters.dtWorkGroupsTableAdapter();
            locTaAssignments.Connection = new System.Data.SqlClient.SqlConnection(FacessoGeneric.SQLConnectionString);
            locTaWorkgroups.Connection = locTaAssignments.Connection;
            locAssignments = locTaAssignments.GetDataByIDSubsidiary(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary);
            locWorkGroups = locTaWorkgroups.GetDataByIDSubsidiary(FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary);
            DataView locAssignmentView = new DataView(locAssignments);
            foreach (dsWorkgroupAssignments.dtWorkGroupsRow locWorkgroupItem in locWorkGroups)
            {
                {
                    var __with1 = PrintDocument;
                    __with1.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Center;
                    __with1.CurrentFont = LayoutAndNumberFormats.U1Font.ToFont();
                    __with1.WriteLine("Produktiv-Site-Info f�r");
                    __with1.WriteLine(locWorkgroupItem.WorkGroupNumber.ToString() + ": " + locWorkgroupItem.WorkgroupName).DistanceToNext = 5;
                    __with1.WriteLine();
                    __with1.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                    __with1.CurrentAlignment = ActiveDev.Printing.ADTextAlignment.Left;
                    __with1.WriteLine("Zugeordnete Kostenstelle:  " + locWorkgroupItem.CostCenterNo + ": " + locWorkgroupItem.CostCenterName);
                    __with1.WriteLine("Aktiviert:  " + Microsoft.VisualBasic.Interaction.IIf(locWorkgroupItem.IsActive, "Ja", "Nein").ToString());
                    if ((locWorkgroupItem.IsWorkGroupDescriptionNull()))
                    {
                        __with1.WriteLine("Beschreibung:  - Es wurde keine Beschreibung hinterlegt -");
                    }
                    else
                    {
                        __with1.WriteLine("Beschreibung:  " + locWorkgroupItem.WorkGroupDescription).DistanceToNext = 20;
                    }

                    __with1.WriteLine();
                    __with1.WriteLine();
                    if (myParameters.PrintShiftTimes)
                    {
                        __with1.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                        __with1.WriteLine("Schichtzeit-Definitionen f�r manuelle Eingabe:").DistanceToNext = 10;
                        __with1.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                        __with1.BeginTable(BorderStyle, 120, 100, 100, 100, 100);
                        __with1.BuildTableHeader();
                        __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                        __with1.WriteCells("Tag", "Schicht", "Startzeit", "Endzeit", "Pausen");
                        __with1.BuildTableBody();
                        TimeSettingDetails locTimeDetails = TimeSettingDetails.FromXmlString(locWorkgroupItem.TimeSettingDetails);
                        System.DateTime locDate = new System.DateTime(2001, 1, 1);
                        for (int locDay = 0; locDay <= 6; locDay++)
                        {
                            for (int locShift = 1; locShift <= 4; locShift++)
                            {
                                TimeSettingDetail locTD = locTimeDetails.GetTimeSettingDetail(locDate, locShift);
                                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                                __with1.WriteCell(locDate.ToString("dddd"));
                                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                                __with1.WriteCell(locShift.ToString());
                                __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                                if (locTD.ShiftStart.IsNull)
                                {
                                    __with1.WriteCell("n.d.");
                                }
                                else
                                {
                                    __with1.WriteCell(locTD.ShiftStart.TypedValue.ToString("ddd, HH:mm"));
                                }

                                if (locTD.ShiftEnd.IsNull)
                                {
                                    __with1.WriteCell("n.d.");
                                }
                                else
                                {
                                    __with1.WriteCell(locTD.ShiftEnd.TypedValue.ToString("ddd, HH:mm"));
                                }

                                if (locTD.WorkBreak.IsNull)
                                {
                                    __with1.WriteCell("n.d.");
                                }
                                else
                                {
                                    __with1.WriteCell(locTD.WorkBreak.TypedValue.ToString());
                                }
                            }

                            locDate = locDate.AddDays(1);
                        }

                        __with1.EndTable();
                        if (myParameters.PrintAssignedLabourValues)
                        {
                            PrintDocument.PageBreak();
                        }
                    }

                    locAssignmentView.RowFilter = "IDWorkGroupInternal=" + locWorkgroupItem.IDWorkGroupInternal;
                    if (myParameters.PrintAssignedLabourValues)
                    {
                        __with1.CurrentFont = LayoutAndNumberFormats.U3Font.ToFont();
                        __with1.WriteLine("Liste der zugeordneten REFA-Arbeitswerte f�r " + locWorkgroupItem.WorkGroupNumber + ": " + locWorkgroupItem.WorkgroupName).DistanceToNext = 10;
                        __with1.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                        __with1.BeginTable(BorderStyle, 70, 250, 75, 70, 70, 150);
                        __with1.BuildTableHeader();
                        __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                        __with1.WriteCells("AW-Nr.:", "REFA-Arbeitswert", "Einheit", "Wert", "Kstnr.:", "Kostenstellenname:");
                        __with1.BuildTableBody();
                        __with1.CurrentFont = LayoutAndNumberFormats.TextAndTableBodyFont.ToFont();
                        foreach (DataRowView locLabourValueViewItem in locAssignmentView)
                        {
                            dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsRow locLabourValueItem = default(dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsRow);
                            locLabourValueItem = ((dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsRow)locLabourValueViewItem.Row);
                            __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                            __with1.WriteCell(locLabourValueItem.LabourValueNumber.ToString());
                            __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                            __with1.WriteCell(locLabourValueItem.LabourValueName);
                            __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                            __with1.WriteCell(locLabourValueItem.Dimension.ToString());
                            __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                            //TODO: Richtiges Format einbauen!
                            __with1.WriteCell(locLabourValueItem.TeHMin.ToString("#,##0.000"));
                            __with1.WriteCell(locLabourValueItem.CostCenterNo.ToString());
                            __with1.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                            __with1.WriteCell(locLabourValueItem.CostCenterName);
                        }

                        __with1.EndTable();
                    }
                }

                PrintDocument.PageBreak();
            }

            return;
        }
    }
}
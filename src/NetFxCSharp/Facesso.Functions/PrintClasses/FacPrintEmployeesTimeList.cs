using ActiveDev;
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
    public class FacPrintEmployeesTimeList : FacessoPrintBase
    {
        private EmployeeTimeLogInfo myTimeList;
        private WorkGroupInfoItems myWorkGroups;
        public FacPrintEmployeesTimeList(EmployeeTimeLogInfo TimeList, string Username) : base("Zeitenaufstellung f�r " + TimeList.Employee.DisplayName, "von " + TimeList.StartDate.ToShortDateString() + " bis " + TimeList.EndDate.ToShortDateString(), Username)
        {
            myTimeList = TimeList;
            if (myWorkGroups == null)
            {
                myWorkGroups = new WorkGroupInfoItems(true);
            }
        }

        protected override void PrepareDocument()
        {
            base.PrepareDocument();
            {
                var __with0 = PrintDocument;
                __with0.WriteLine().DistanceToNext = 10;
                //Mengentabelle der Produktiv-Site
                __with0.CurrentFont = LayoutAndNumberFormats.TableHeaderFont.ToFont();
                __with0.BeginTable(BorderStyle, 60, 65, 180, 100, 100, 100, 85, 87);
                __with0.BuildTableHeader();
                __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                __with0.WriteCells("Datum", "Schicht", "Produktiv-Site", "von", "bis", "Anwesen- heitszeit", "Pausen- zeit", "Ausfallzeit");
                __with0.BuildTableBody();
                __with0.CurrentFont = LayoutAndNumberFormats.SmallTableFont.ToFont();
                foreach (EmployeeTimeLogInfoItem locItem in myTimeList)
                {
                    //Leerzeiten nicht drucken!
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.ProductionDate.ToString("dd.MM."));
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.Shift.ToString("0"));
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopLeft;
                    __with0.WriteCell(myWorkGroups[new IntKey(locItem.IDWorkGroup)].ListItemText);
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell(locItem.ShiftStart.ToString("(dd:)  HH:mm"));
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell(locItem.ShiftEnd.ToString("(dd:)  HH:mm"));
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopCenter;
                    __with0.WriteCell(locItem.AttendanceTime.ToString("#,##0.00") + " min.");
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.WorkBreak.ToString("##0.00") + " min.");
                    __with0.CurrentCellAlignment = ActiveDev.Printing.ADTextCellAlignment.TopRight;
                    __with0.WriteCell(locItem.DownTime.ToString("##0.00") + " min.");
                }

                __with0.EndTable();
            }
        }
    }
}
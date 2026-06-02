using ActiveDev;
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class ucConfigurableWorkgroupChart
    {
        private WorkGroupAnalysisParameters myAnalysisParameters;
        private Action myEnsureWorkgroups;
        private List<WorkGroupAnalysisInfo> myResultList;
        public ucConfigurableWorkgroupChart()
        {
            myAnalysisParameters = new WorkGroupAnalysisParameters()
            {
                AnalysisTarget = AnalysisTarget.DirectlyToPrinter,
                AnalysisType = WorkgroupAnalysisType.Batch,
                AutomaticChartDeltaRange = true,
                ChartDeltaFromValue = 80,
                ChartDeltaToValue = 140,
                ChartTitel = "Arbeitsgruppenauswertung",
                ChartType = ChartType.Chart2DLine,
                DateRange = new DateRangeParameter(DateRangePresets.LastWeek),
                IncludeSuspended = false,
                IncludeWorkLoad = true,
                ShiftParameters = new ShiftParameters()
                {
                    ConsiderShift1 = true
                },
                WorkgroupAnalysisBehaviour = WorkgroupAnalysisBehaviours.Best,
                WorkgroupAnalysisCount = 3
            };
            // This call is required by the designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            myEnsureWorkgroups = () =>
            {
                if (this.AnalysisParameters.WorkGroups == null)
                {
                    this.AnalysisParameters.WorkGroups = new WorkGroupInfoItems(true);
                    if (this.AnalysisParameters.SelectedWorkgroups == null)
                    {
                        this.AnalysisParameters.SelectedWorkgroups = new System.Collections.ObjectModel.Collection<int>();
                        this.AnalysisParameters.WorkGroups.ToList().ForEach((item) =>
                        {
                            this.AnalysisParameters.SelectedWorkgroups.Add(item.WorkGroupNumber);
                        });
                    }
                }
            };
        }

        public void RecalculateChartData()
        {
            ProductionPeriod prodPeriod = new ProductionPeriod(this.AnalysisParameters.DateRange, this.AnalysisParameters.ShiftParameters);
            bool compressShifts = default(bool);
            //Dafür sorgen, dass die Collections, die die Workgroups beschreiben, auch vorhanden sind.
            myEnsureWorkgroups();
            if (this.AnalysisParameters.SelectedWorkgroups != null && this.AnalysisParameters.SelectedWorkgroups.Count > 1)
            {
                compressShifts = true;
            }
            else
            {
                compressShifts = false;
            }

            WorkGroupAnalysisInfoItems wgAnalysis = new WorkGroupAnalysisInfoItems(prodPeriod, this.AnalysisParameters.WorkGroups, null, false, compressShifts);
            wgAnalysis.ExecuteQuery();
            //Wir brauchen entweder die alle, die x besten oder die x schlechtesten in der Ergebnisliste
            if (this.AnalysisParameters.WorkgroupAnalysisBehaviour == WorkgroupAnalysisBehaviours.Best)
            {
                //Nur die x besten verwenden,
                myResultList = ((
                    from item in wgAnalysis
                    where item.HasData
                    orderby item.DegreeOfTime
                    select item).Take(this.AnalysisParameters.WorkgroupAnalysisCount.Value)).ToList();
            }
            else if (this.AnalysisParameters.WorkgroupAnalysisBehaviour == WorkgroupAnalysisBehaviours.Worst)
            {
                //oder nur die X schlechtesten verwenden,
                myResultList = ((
                    from item in wgAnalysis
                    where item.HasData
                    orderby item.DegreeOfTime descending
                    select item).Take(this.AnalysisParameters.WorkgroupAnalysisCount.Value)).ToList();
            }
            else
            {
                //oder die selektierten nehmen, die aber aufsteigend sortieren.
                //Und auch die nehmen, die keine Daten haben.
                myResultList = ((
                    from item in wgAnalysis
                    where AnalysisParameters.SelectedWorkgroups.Contains(item.WorkGroupInfo.WorkGroupNumber)orderby item.DegreeOfTime
                    select item)).ToList();
            }

            //Die Produktiv-Sites - so vorhanden - aus der Drop-Downliste entfernen.
            foreach (ToolStripItem item in WorkgroupsDropDownItems.DropDownItems)
            {
                item.Click -= WorkgroupDropDownItemClickHandler;
            }

            WorkgroupsDropDownItems.DropDownItems.Clear();
            //Die Produktiv-Sites wieder aufnahmen, und die Eventhandler für die Auswahl neu verdrahten.
            foreach (var item in myResultList)
            {
                var tb = new ToolStripMenuItem()
                {
                    Text = item.WorkGroupInfo.DisplayName,
                    Checked = true,
                    CheckOnClick = true,
                    DisplayStyle = ToolStripItemDisplayStyle.Text,
                    Tag = item
                };
                tb.CheckedChanged += WorkgroupDropDownItemClickHandler;
                WorkgroupsDropDownItems.DropDownItems.Add(tb);
            }

            RefreshChart();
        }

        private void WorkgroupDropDownItemClickHandler(object sender, EventArgs e)
        {
            RefreshChart();
        }

        public void RefreshChart()
        {
            bool compressShifts = default(bool);
            if (this.AnalysisParameters.SelectedWorkgroups != null && this.AnalysisParameters.SelectedWorkgroups.Count > 1)
            {
                compressShifts = true;
            }
            else
            {
                compressShifts = false;
            }

            this.mainChart.Titles["MainTitle"].Text = this.AnalysisParameters.ChartTitel;
            //Interaktives Chart auf beiden Achsen aktivieren
            mainChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            mainChart.ChartAreas[0].CursorY.IsUserEnabled = true;
            //Selektionsfähigkeit aktivieren
            mainChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            mainChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            //Zoomen aktivieren
            mainChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            mainChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            //Scrollbar innendrin positionieren
            mainChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            mainChart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            if (myResultList.Count == 0)
            {
                this.mainChart.Titles["SubTitle"].Text = "Die Abfrage brachte keine Ergebnisse!";
                //Die vorhandenen Serien löschen
                mainChart.Series.Clear();
                return;
            }
            else
            {
                this.mainChart.Titles["SubTitle"].Text = this.AnalysisParameters.DateRange.ToString();
            }

            var count = 1;
            if (compressShifts)
            {
                //Die vorhandenen Serien löschen
                mainChart.Series.Clear();
                foreach (var wgItem in myResultList)
                {
                    //Neue Serie hinzufügen
                    var tmpItem = wgItem;
                    var menueItem = ((
                        from object dItem in WorkgroupsDropDownItems.DropDownItems
                        where ((ToolStripMenuItem)dItem).Tag == tmpItem
                        select dItem)).Single();
                    if (!(((ToolStripMenuItem)menueItem).Checked))
                    {
                        continue;
                    }

                    var wgDescription = wgItem.WorkGroupInfo.WorkGroupNumber + ": " + wgItem.WorkGroupInfo.WorkGroupName;
                    Series series = mainChart.Series.Add(wgDescription);
                    series.Legend = mainChart.Legends[0].Name;
                    series.LegendText = count.ToString() + ". - " + wgDescription;
                    series.ToolTip = wgItem.AttendanceTimeDeltaStrings + System.Environment.NewLine + wgItem.IncentiveTimeDeltaStrings + System.Environment.NewLine + wgItem.GeneralBreakTimeStrings;
                    //Chart-Area festlegen, in das diese Serie gezeichnet werden soll
                    series.ChartArea = mainChart.ChartAreas[0].Name;
                    //Legende formatieren
                    //Chart-Type definieren
                    series.ChartType = SeriesChartType.Spline;
                    series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                    //MessageBox.Show("Es folgen Daten für" & wgItem.WorkGroupInfo.WorkGroupName)
                    Debug.Print("-------- Daten " + wgItem.WorkGroupInfo.WorkGroupName + "--------------");
                    //Daten aufjedenfall nach Datum sortieren, sonst knallt es!
                    var valuesForChart = ((
                        from vItem in wgItem
                        orderby vItem.ProductionDate
                        select vItem)).ToList();
                    foreach (var valueItem in valuesForChart)
                    {
                        Debug.Print("Datum:" + valueItem.ProductionDate.ToString() + "Wert:" + valueItem.DegreeOfTime);
                        series.Points.Add(new DataPoint(valueItem.ProductionDate.ToOADate(), valueItem.DegreeOfTime) { ToolTip = wgDescription + System.Environment.NewLine + valueItem.ProductionDate.ToShortDateString() + " - Schicht:" + System.Environment.NewLine + valueItem.Shift + "Zeitgrad: " + valueItem.DegreeOfTime.ToString("##0") + System.Environment.NewLine + System.Environment.NewLine + valueItem.IncentiveTimeDeltaStrings, Label = (ShowValuesInChartToolStripButton.Checked ? valueItem.DegreeOfTime.ToString("##0") : ""), IsValueShownAsLabel = ShowValuesInChartToolStripButton.Checked });
                    }

                    Debug.Print("----------------------");
                    count += 1;
                }
            }
        }

        private WorkGroupInfoItems WorkgroupsInner { get; set; }

        private void EditToolStripButton_Click(System.Object sender, System.EventArgs e)
        {
            frmWorkgroupChartParametersPicker frmGetChartParameters = new frmWorkgroupChartParametersPicker();
            myEnsureWorkgroups();
            var anaparams = frmGetChartParameters.GetAnalysisParameters(myAnalysisParameters);
            if (anaparams != null)
            {
                this.AnalysisParameters = anaparams;
                RecalculateChartData();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WorkGroupAnalysisParameters AnalysisParameters
        {
            set
            {
                if (value != myAnalysisParameters)
                {
                    myAnalysisParameters = value;
                    RecalculateChartData();
                }
            }

            get
            {
                return myAnalysisParameters;
            }
        }

        private void NewToolStripButton_Click(System.Object sender, System.EventArgs e)
        {
            mainChart.Printing.PrintDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(100, 100, 100, 100);
            mainChart.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
            mainChart.Printing.PrintPreview();
        }

        private void PrintToolStripButton_Click(System.Object sender, System.EventArgs e)
        {
            mainChart.Printing.PrintDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(100, 100, 100, 100);
            mainChart.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
            mainChart.Printing.Print(true);
        }

        private void Chart3DToolStripButton_Click(System.Object sender, System.EventArgs e)
        {
            Chart3DToolStripButton.Checked = !(Chart3DToolStripButton.Checked);
            mainChart.ChartAreas[0].Area3DStyle.Enable3D = Chart3DToolStripButton.Checked;
        }

        private void ShowValuesInChartToolStripButton_Click(System.Object sender, System.EventArgs e)
        {
            RefreshChart();
        }

        private void SaveToolStripButton_Click(System.Object sender, System.EventArgs e)
        {
            MessageBox.Show("Export-Fuznktionalität ist nur in der Enterprise-Version implementiert!");
        }

        private void CopyToolStripButton_Click(System.Object sender, System.EventArgs e)
        {
            MessageBox.Show("Export-Funktionalität ist nur in der Enterprise-Version implementiert!");
        }
    }

    public enum SeriesSourceType
    {
        TopCount,
        LastCount,
        Given,
    }
}
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
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso
{
    public partial class frmFacessoShell
    {
        private const string CHART_ANALYSIS_PATH = "\\ChartAnalysisInfo";
        private const string CHART_ANALYSIS_FILENAME = "\\FacessoAnalyses.Xml";
        private void AssignChartAnalysises()
        {
            FileInfo analysisFile = new FileInfo(FacessoGeneric.SharedFolder + CHART_ANALYSIS_PATH + CHART_ANALYSIS_FILENAME);
            if (!(analysisFile.Exists))
            {
                //Neue Collection mit den Default-Einstellungen anlegen
                //Gestern, letzte Woche, Seit Anfang des Monats
                {
                    var __with0 = mainChartOne.AnalysisParameters;
                    __with0.ChartTitel = "Beste Arbeitsgruppen gestern";
                    __with0.DateRange = new DateRangeParameter(DateRangePresets.YesterdayOrLastWorkingDay, LastFacessoWorkingDay());
                    __with0.ShiftParameters = new ShiftParameters()
                    {
                        ConsiderShift1 = true,
                        ConsiderShift2 = true,
                        ConsiderShift3 = true,
                        ConsiderShift4 = true
                    };
                    __with0.Name = "mainChartOne";
                }

                mainChartOne.RecalculateChartData();
                {
                    var __with1 = mainChartTwo.AnalysisParameters;
                    __with1.ChartTitel = "Beste Arbeitsgruppen diese Woche";
                    __with1.DateRange = new DateRangeParameter(DateRangePresets.FromStartOfCurrentWeekToNow, LastFacessoWorkingDay());
                    __with1.ShiftParameters = new ShiftParameters()
                    {
                        ConsiderShift1 = true,
                        ConsiderShift2 = true,
                        ConsiderShift3 = true,
                        ConsiderShift4 = true
                    };
                    __with1.Name = "mainChartTwo";
                }

                mainChartTwo.RecalculateChartData();
                {
                    var __with2 = mainChartThree.AnalysisParameters;
                    __with2.ChartTitel = "Beste Arbeitsgruppen letzter Monat";
                    __with2.DateRange = new DateRangeParameter(DateRangePresets.FromStartToEndOfSpecifiedMonth, 1);
                    __with2.ShiftParameters = new ShiftParameters()
                    {
                        ConsiderShift1 = true,
                        ConsiderShift2 = true,
                        ConsiderShift3 = true,
                        ConsiderShift4 = true
                    };
                    __with2.Name = "mainChartThree";
                }

                mainChartThree.RecalculateChartData();
                SaveChartAnalysisChanges();
            }
            else
            {
                var myAnalysises = WorkGroupAnalysisParametersCollection.FromFile(new FileInfo(FacessoGeneric.SharedFolder + CHART_ANALYSIS_PATH + CHART_ANALYSIS_FILENAME));
                mainChartOne.AnalysisParameters = myAnalysises[0];
                mainChartTwo.AnalysisParameters = myAnalysises[1];
                mainChartThree.AnalysisParameters = myAnalysises[2];
            }
        }

        private void SaveChartAnalysisChanges()
        {
            FileInfo locFi = new FileInfo(FacessoGeneric.SharedFolder + CHART_ANALYSIS_PATH + CHART_ANALYSIS_FILENAME);
            WorkGroupAnalysisParametersCollection myAnalysises = new WorkGroupAnalysisParametersCollection();
            myAnalysises.Add(mainChartOne.AnalysisParameters);
            myAnalysises.Add(mainChartTwo.AnalysisParameters);
            myAnalysises.Add(mainChartThree.AnalysisParameters);
            myAnalysises.ToFile(locFi);
        }

        private LastWorkingdays LastFacessoWorkingDay()
        {
            if (!((myFacessoGeneralOptions.SaturdayIsWorkday & myFacessoGeneralOptions.SundayIsWorkday)))
            {
                return LastWorkingdays.Friday;
            }
            else if (myFacessoGeneralOptions.SundayIsWorkday)
            {
                return LastWorkingdays.Sunday;
            }
            else
            {
                return LastWorkingdays.Saturday;
            }

            return default(LastWorkingdays);
        }
    }
}
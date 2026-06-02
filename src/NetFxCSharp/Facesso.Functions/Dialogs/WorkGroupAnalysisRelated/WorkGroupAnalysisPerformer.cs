using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public class WorkGroupAnalysisPerformer
    {
        private WorkGroupAnalysisParameters myAnalysisParameters;
        public WorkGroupAnalysisPerformer(WorkGroupAnalysisParameters AnalysisParameters)
        {
            myAnalysisParameters = AnalysisParameters;
            //�berpr�fen, ob die Workgroup-Infos neu abgerufen werden m�ssen, da
            //die bei einer Auswertung nicht mitserialisiert werden.
            if (myAnalysisParameters.WorkGroups == null & myAnalysisParameters.SelectedWorkgroups != null)
            {
                WorkGroupInfoItems locWorkGroups = new WorkGroupInfoItems(true);
                WorkGroupInfoItems locSelectedWorkgroups = new WorkGroupInfoItems();
                foreach (int locInt in myAnalysisParameters.SelectedWorkgroups)
                {
                    locSelectedWorkgroups.Add(locWorkGroups[new ActiveDev.IntKey(locInt)]);
                }

                myAnalysisParameters.WorkGroups = locSelectedWorkgroups;
            }
        }

        public void PerformAnalysis()
        {
            {
                var __select0 = (int)(myAnalysisParameters.AnalysisType);
                if (__select0 == (int)(WorkgroupAnalysisType.Detailed))
                {
                    PerformDetailed();
                }
                else if (__select0 == (int)(WorkgroupAnalysisType.WorkGroupListShiftCondensed))
                {
                    PerformWorkGroupListShiftCondensed();
                }
                else if (__select0 == (int)(WorkgroupAnalysisType.WorkGroupListShiftwise))
                {
                    PerformWorkGroupListShiftWise();
                }
                else if (__select0 == (int)(WorkgroupAnalysisType.WorkGroupListShiftwiseCompressed))
                {
                    PerformWorkGroupListShiftWiseCompressed();
                }
                else if (__select0 == (int)(WorkgroupAnalysisType.Batch))
                {
                    PerformBatch();
                }
                else if (__select0 == (int)(WorkgroupAnalysisType.WorkGroupListShiftwiseWorkLoad))
                {
                    //TODO: Richtige Auswertung einbauen
                    PerformWorkGroupListShiftWiseWorkLoad();
                }
            }
        }

        public void PerformWorkGroupListShiftCondensed()
        {
            ProductionPeriod locProductionPeriod = new ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters);
            WorkGroupAnalysisInfoItems locAnalysises = new WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, null, false, false);
            locAnalysises.ExecuteQuery();
            FacPrintWorkGroupListShiftCondensed locPrintAnalysis = new FacPrintWorkGroupListShiftCondensed(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username);
            locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget);
        }

        public void PerformWorkGroupListShiftWise()
        {
            ProductionPeriod locProductionPeriod = new ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters);
            WorkGroupAnalysisInfoItems locAnalysises = new WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, null, true, false);
            locAnalysises.ExecuteQuery();
            FacPrintWorkGroupListShiftWise locPrintAnalysis = new FacPrintWorkGroupListShiftWise(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username);
            locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget);
        }

        public void PerformWorkGroupListShiftWiseWorkLoad()
        {
            ProductionPeriod locProductionPeriod = new ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters);
            WorkGroupAnalysisInfoItems locAnalysises = new WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, null, true, false);
            locAnalysises.ExecuteQuery();
            FacPrintWorkGroupListShiftWiseWorkLoad locPrintAnalysis = new FacPrintWorkGroupListShiftWiseWorkLoad(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username);
            locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget);
        }

        public void PerformWorkGroupListShiftWiseCompressed()
        {
            ProductionPeriod locProductionPeriod = new ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters);
            WorkGroupAnalysisInfoItems locAnalysises = new WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, null, true, false);
            locAnalysises.ExecuteQuery();
            FacPrintWorkGroupListShiftWiseCompressed locPrintAnalysis = new FacPrintWorkGroupListShiftWiseCompressed(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username);
            locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget);
        }

        public void PerformBatch()
        {
            ProductionPeriod locProductionPeriod = new ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters);
            WorkGroupAnalysisInfoItems locAnalysises = new WorkGroupAnalysisInfoItems(locProductionPeriod, myAnalysisParameters.WorkGroups, null, false, true);
            locAnalysises.ExecuteQuery();
            FacPrintWorkGroupAnalysisBatch locPrintAnalysis = new FacPrintWorkGroupAnalysisBatch(locAnalysises, locProductionPeriod, FacessoGeneric.LoginInfo.Username);
            locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget);
        }

        public void PerformDetailed()
        {
            ProductionPeriod locProductionPeriod = new ProductionPeriod(myAnalysisParameters.DateRange, myAnalysisParameters.ShiftParameters);
            FacPrintWorkGroupShiftDateBatch locPrintAnalysis = new FacPrintWorkGroupShiftDateBatch(myAnalysisParameters.WorkGroups, locProductionPeriod, FacessoGeneric.LoginInfo.Username);
            locPrintAnalysis.ProcessDocument(myAnalysisParameters.AnalysisTarget);
        }
    }
}
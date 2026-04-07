using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using ActiveDev;

namespace Facesso.Data
{
    public enum ProductionDataAmountsCategory
    {
        None,
        LabourValues,
        CostCenters
    }

    public class WorkgroupsProductionDataAmounts : KeyedCollection<IntKey, WorkgroupProductionDataAmounts>
    {
        public delegate void WorkgroupsProductionDataAmountProgressDelegate(WorkGroupInfo currentWorkgroup, int processedWorkgroups);

        private int myIDSubsidiary;
        private WorkGroupInfoItems myWorkgroups;
        private DateTime myStartDate;
        private DateTime myEndDate;
        private WorkgroupsProductionDataAmountProgressDelegate myProcessDelegate;
        private DataTable myCategorisationTable;
        private ProductionDataAmountsCategory myCategorisedBy = ProductionDataAmountsCategory.None;
        private CostcenterInfoItems myCostCenterItems;

        public WorkgroupsProductionDataAmounts(int idSubsidiary, WorkGroupInfoItems workgroups,
            DateTime startDate, DateTime endDate,
            WorkgroupsProductionDataAmountProgressDelegate processDelegate)
        {
            myIDSubsidiary = idSubsidiary;
            myWorkgroups = workgroups;
            myStartDate = startDate;
            myEndDate = endDate;
            myProcessDelegate = processDelegate;
        }

        protected override IntKey GetKeyForItem(WorkgroupProductionDataAmounts item)
        {
            return new IntKey(item.Workgroup.IDWorkGroup);
        }

        public void ExecuteQuery()
        {
            int locCount = 0;
            foreach (WorkGroupInfo locWorkgroupItem in Workgroups)
            {
                myProcessDelegate?.Invoke(locWorkgroupItem, locCount);
                locCount++;
                this.Add(new WorkgroupProductionDataAmounts(IDSubsidiary, locWorkgroupItem, Startdate, EndDate));
            }
        }

        public int IDSubsidiary => myIDSubsidiary;

        public WorkGroupInfoItems Workgroups => myWorkgroups;

        public CostcenterInfoItems CostCenters
        {
            get { return myCostCenterItems; }
            set { myCostCenterItems = value; }
        }

        public DateTime Startdate => myStartDate;

        public DateTime EndDate => myEndDate;

        public void CategoriseByWorkvalues()
        {
            myCategorisationTable = new DataTable();

            myCategorisationTable.Columns.Add("IDLabourValue", typeof(int));
            myCategorisationTable.Columns.Add("LabourValueNumber", typeof(int));
            myCategorisationTable.Columns.Add("LabourValueDescription", typeof(string));
            myCategorisationTable.Columns.Add("LabourValueDimension", typeof(string));
            myCategorisationTable.Columns.Add("LabourValueTeHMin", typeof(double));
            myCategorisationTable.Columns.Add("IDCostCenter", typeof(int));
            myCategorisationTable.Columns.Add("CostCenterName", typeof(string));
            myCategorisationTable.Columns.Add("CostCenterNo", typeof(string));
            myCategorisationTable.Columns.Add("TotalAmount", typeof(double));

            foreach (WorkgroupProductionDataAmounts locWorkGroupItems in this)
            {
                foreach (WorkgroupProductionDataAmount locProductionDataAmount in locWorkGroupItems)
                {
                    DataRow[] locDataRows = myCategorisationTable.Select("IDLabourValue=" + locProductionDataAmount.LabourValue.IDLabourValue);
                    if (locDataRows.Length == 0)
                    {
                        DataRow locDataRow = myCategorisationTable.NewRow();
                        locDataRow["IDLabourValue"] = locProductionDataAmount.LabourValue.IDLabourValue;
                        locDataRow["LabourValueNumber"] = locProductionDataAmount.LabourValue.LabourValueNumber;
                        locDataRow["LabourValueDescription"] = locProductionDataAmount.LabourValue.LabourValueDescription;
                        locDataRow["LabourValueDimension"] = locProductionDataAmount.LabourValue.Dimension;
                        locDataRow["LabourValueTeHMin"] = locProductionDataAmount.LabourValue.TeHMin;
                        locDataRow["IDCostCenter"] = locProductionDataAmount.LabourValue.IDCostCenter;
                        locDataRow["CostCenterName"] = locProductionDataAmount.LabourValue.CostCenterName;
                        locDataRow["CostCenterNo"] = locProductionDataAmount.LabourValue.CostCenterNo;
                        locDataRow["TotalAmount"] = locProductionDataAmount.TotalAmount;
                        myCategorisationTable.Rows.Add(locDataRow);
                    }
                    else
                    {
                        locDataRows[0]["TotalAmount"] = (double)locDataRows[0]["TotalAmount"] + locProductionDataAmount.TotalAmount;
                    }
                }
            }
            myCategorisedBy = ProductionDataAmountsCategory.LabourValues;
        }

        public void CategoriseByCostCenters()
        {
            myCategorisationTable = new DataTable();

            myCategorisationTable.Columns.Add("IDCostCenter", typeof(int));
            myCategorisationTable.Columns.Add("CostCenterName", typeof(string));
            myCategorisationTable.Columns.Add("CostCenterNo", typeof(int));
            myCategorisationTable.Columns.Add("AmountIncentiveWageProductionTime", typeof(double));

            foreach (WorkgroupProductionDataAmounts locWorkGroupItems in this)
            {
                foreach (WorkgroupProductionDataAmount locProductionDataAmount in locWorkGroupItems)
                {
                    DataRow[] locDataRows = myCategorisationTable.Select("IDCostCenter=" + locProductionDataAmount.LabourValue.IDCostCenter);
                    if (locDataRows.Length == 0)
                    {
                        DataRow locDataRow = myCategorisationTable.NewRow();
                        locDataRow["IDCostCenter"] = locProductionDataAmount.LabourValue.IDCostCenter;
                        locDataRow["CostCenterName"] = locProductionDataAmount.LabourValue.CostCenterName;
                        locDataRow["CostCenterNo"] = locProductionDataAmount.LabourValue.CostCenterNo;
                        locDataRow["AmountIncentiveWageProductionTime"] = locProductionDataAmount.TotalAmount * locProductionDataAmount.LabourValue.TeHMin;
                        myCategorisationTable.Rows.Add(locDataRow);
                    }
                    else
                    {
                        locDataRows[0]["AmountIncentiveWageProductionTime"] =
                            (double)locDataRows[0]["AmountIncentiveWageProductionTime"] +
                                locProductionDataAmount.TotalAmount * locProductionDataAmount.LabourValue.TeHMin;
                    }
                }
            }
            myCategorisedBy = ProductionDataAmountsCategory.CostCenters;
        }

        public DataTable CategorisationTable => myCategorisationTable;

        public ProductionDataAmountsCategory CategorisedBy => myCategorisedBy;
    }

    public class WorkgroupProductionDataAmounts : KeyedCollection<IntKey, WorkgroupProductionDataAmount>
    {
        private int myIDSubsidiary;
        private WorkGroupInfo myWorkgroup;
        private DateTime myStartDate;
        private DateTime myEndDate;

        public WorkgroupProductionDataAmounts() : base() { }

        public WorkgroupProductionDataAmounts(int idSubsidiary, WorkGroupInfo workgroup,
            DateTime startDate, DateTime endDate)
        {
            myIDSubsidiary = idSubsidiary;
            myWorkgroup = workgroup;
            myStartDate = startDate;
            myEndDate = endDate;
            SPAccess.GetInstance().ProductionData_CollectAmounts(idSubsidiary, workgroup.IDWorkGroup, startDate, endDate, this);
        }

        protected override IntKey GetKeyForItem(WorkgroupProductionDataAmount item)
        {
            return new IntKey(item.LabourValue.IDLabourValue);
        }

        public int IDSubsidiary => myIDSubsidiary;

        public WorkGroupInfo Workgroup => myWorkgroup;

        public DateTime Startdate => myStartDate;

        public DateTime EndDate => myEndDate;
    }

    public class WorkgroupProductionDataAmount
    {
        private LabourValueInfo myLabourValue;
        private double myTotalAmount;

        public WorkgroupProductionDataAmount(double totalAmount, LabourValueInfo labourValue)
        {
            myTotalAmount = totalAmount;
            myLabourValue = labourValue;
        }

        public LabourValueInfo LabourValue
        {
            get { return myLabourValue; }
            set { myLabourValue = value; }
        }

        public double TotalAmount
        {
            get { return myTotalAmount; }
            set { myTotalAmount = value; }
        }
    }
}

namespace Facesso.Data
{
    public class WorkgroupBaseDataPrintParameters
    {
        private bool myPrintWorkgroups;
        private bool myPrintAssignedLabourValues;
        private bool myPrintShiftTimes;
        private int myPrintProductivityHistory;
        private bool myOnlyPrintListOfLabourValues;

        public bool PrintWorkgroups
        {
            get { return myPrintWorkgroups; }
            set { myPrintWorkgroups = value; }
        }

        public bool PrintAssignedLabourValues
        {
            get { return myPrintAssignedLabourValues; }
            set { myPrintAssignedLabourValues = value; }
        }

        public bool PrintShiftTimes
        {
            get { return myPrintShiftTimes; }
            set { myPrintShiftTimes = value; }
        }

        public int VisualizeProductivityHistory
        {
            get { return myPrintProductivityHistory; }
            set { myPrintProductivityHistory = value; }
        }

        public bool OnlyPrintListOfLabourValues
        {
            get { return myOnlyPrintListOfLabourValues; }
            set { myOnlyPrintListOfLabourValues = value; }
        }
    }
}

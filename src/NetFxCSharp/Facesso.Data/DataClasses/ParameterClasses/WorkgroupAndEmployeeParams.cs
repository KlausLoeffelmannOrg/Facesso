namespace Facesso.Data
{
    public class ParamsWorkGroups
    {
        private WorkGroupInfoItems _WorkGroups;
        private ProductionPeriod _ProductionPeriod;

        public ParamsWorkGroups(WorkGroupInfoItems workGroups, ProductionPeriod period)
        {
            _WorkGroups = workGroups;
            _ProductionPeriod = period;
        }

        public WorkGroupInfoItems WorkGroups
        {
            get { return _WorkGroups; }
            set { _WorkGroups = value; }
        }

        public ProductionPeriod ProductionPeriod
        {
            get { return _ProductionPeriod; }
            set { _ProductionPeriod = value; }
        }
    }

    public class ParamsEmployees
    {
        private EmployeeInfoItems _Employees;
        private ProductionPeriod _ProductionPeriod;

        public ParamsEmployees(EmployeeInfoItems employees, ProductionPeriod period)
        {
            _Employees = employees;
            _ProductionPeriod = period;
        }

        public EmployeeInfoItems Employees
        {
            get { return _Employees; }
            set { _Employees = value; }
        }

        public ProductionPeriod ProductionPeriod
        {
            get { return _ProductionPeriod; }
            set { _ProductionPeriod = value; }
        }
    }
}

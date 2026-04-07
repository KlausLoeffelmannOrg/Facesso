using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ActiveDev;
using Facesso;

namespace Facesso.Data
{
    /// <summary>
    /// Dient zur Durchführung einer Mitarbeiterauswertung oder Mitarbeiter-Prämienlohnberechnung.
    /// </summary>
    public class EmployeeAnalysisInfoItem
    {
        private ProductionPeriod _Period;
        private EmployeeWageInfo _EmployeeWage;
        private EmployeeInfo _Employee;
        private EmployeeTimeLogInfo _TimeLogItems;
        private DateTime _UsedTicket;
        private int _IDSubsidiary;
        private int _IDUser;
        private bool _Selected;

        public EmployeeAnalysisInfoItem(int idSubsidiary, int idUser, EmployeeInfo employee, ProductionPeriod period)
        {
            DateTime locTicket = DateTime.Now;
            _IDSubsidiary = idSubsidiary;
            _IDUser = idUser;
            _Employee = employee;
            _Period = period;
            _TimeLogItems = new EmployeeTimeLogInfo();
            _TimeLogItems.RecalculateTotalReferenceIWT = true;
            period.PrepareProductionDates(idSubsidiary, idUser, locTicket);
            SPAccess.GetInstance().TimeLog_GetEmployeeResult(idSubsidiary, idUser, locTicket, employee, _TimeLogItems);
            SPAccess.GetInstance().ProductionData_DeleteProductionDateItems(idSubsidiary, idUser, locTicket);
            _EmployeeWage = new EmployeeWageInfo(_Employee, _TimeLogItems.DegreeOfTime, _TimeLogItems.TotalEffectiveIWT);
        }

        public EmployeeAnalysisInfoItem(int idSubsidiary, int idUser, EmployeeInfo employee, ProductionPeriod period, bool keepTicketAndPeriod)
        {
            DateTime locTicket = DateTime.Now;
            _IDSubsidiary = idSubsidiary;
            _IDUser = idUser;
            _Employee = employee;
            _Period = period;
            _TimeLogItems = new EmployeeTimeLogInfo();
            _TimeLogItems.RecalculateTotalReferenceIWT = true;
            period.PrepareProductionDates(idSubsidiary, idUser, locTicket);
            SPAccess.GetInstance().TimeLog_GetEmployeeResult(idSubsidiary, idUser, locTicket, employee, _TimeLogItems);
            _EmployeeWage = new EmployeeWageInfo(_Employee, _TimeLogItems.DegreeOfTime, _TimeLogItems.TotalEffectiveIWT);
            _UsedTicket = locTicket;
        }

        public EmployeeAnalysisInfoItem(int idSubsidiary, int idUser, EmployeeInfo employee, ProductionPeriod period, DateTime useTicket, bool cleanUpAfter)
        {
            _IDSubsidiary = idSubsidiary;
            _IDUser = idUser;
            _Employee = employee;
            _Period = period;
            _TimeLogItems = new EmployeeTimeLogInfo();
            _TimeLogItems.RecalculateTotalReferenceIWT = true;
            SPAccess.GetInstance().TimeLog_GetEmployeeResult(idSubsidiary, idUser, useTicket, employee, _TimeLogItems);
            _EmployeeWage = new EmployeeWageInfo(_Employee, _TimeLogItems.DegreeOfTime, _TimeLogItems.TotalEffectiveIWT);
            _UsedTicket = useTicket;
            if (cleanUpAfter)
                SPAccess.GetInstance().ProductionData_DeleteProductionDateItems(idSubsidiary, idUser, useTicket);
        }

        public void CleanUp()
        {
            SPAccess.GetInstance().ProductionData_DeleteProductionDateItems(_IDSubsidiary, _IDUser, _UsedTicket);
        }

        public ProductionPeriod Period => _Period;

        public EmployeeWageInfo EmployeeWage => _EmployeeWage;

        public bool Selected
        {
            get { return _Selected; }
            set { _Selected = value; }
        }

        public EmployeeTimeLogInfo TimeLogItems => _TimeLogItems;

        public DateTime UsedTicket => _UsedTicket;
    }

    /// <summary>
    /// Stellt Auflistung von Leistungs- bzw. Prämienlohnauswertungen verschiedener Mitarbeiter dar.
    /// </summary>
    public class EmployeeAnalysisInfoItems : KeyedCollection<IntKey, EmployeeAnalysisInfoItem>
    {
        private string myPeriodText;

        public EmployeeAnalysisInfoItems(string periodText) : base()
        {
            myPeriodText = periodText;
        }

        protected override IntKey GetKeyForItem(EmployeeAnalysisInfoItem item)
        {
            return new IntKey(item.EmployeeWage.IDEmployee);
        }

        public void SortByPersonnelNumber()
        {
            var locList = new List<EmployeeAnalysisInfoItem>();
            foreach (EmployeeAnalysisInfoItem locItem in this) locList.Add(locItem);
            locList.Sort(new Comparison<EmployeeAnalysisInfoItem>(EmployeeAnalysisInfoItem_PersonnelNumberComparer));
            this.Clear();
            foreach (EmployeeAnalysisInfoItem locItem in locList) this.Add(locItem);
        }

        public void SortByDegreeOfTime()
        {
            var locList = new List<EmployeeAnalysisInfoItem>();
            foreach (EmployeeAnalysisInfoItem locItem in this) locList.Add(locItem);
            locList.Sort(new Comparison<EmployeeAnalysisInfoItem>(EmployeeAnalysisInfoItem_TimeOfDegreeComparer));
            this.Clear();
            foreach (EmployeeAnalysisInfoItem locItem in locList) this.Add(locItem);
        }

        public void SortByLastname()
        {
            var locList = new List<EmployeeAnalysisInfoItem>();
            foreach (EmployeeAnalysisInfoItem locItem in this) locList.Add(locItem);
            locList.Sort(new Comparison<EmployeeAnalysisInfoItem>(EmployeeAnalysisInfoItem_LastnameComparer));
            this.Clear();
            foreach (EmployeeAnalysisInfoItem locItem in locList) this.Add(locItem);
        }

        private int EmployeeAnalysisInfoItem_TimeOfDegreeComparer(EmployeeAnalysisInfoItem first, EmployeeAnalysisInfoItem second)
        {
            if (first.EmployeeWage.DegreeOfTime > second.EmployeeWage.DegreeOfTime) return 1;
            else if (first.EmployeeWage.DegreeOfTime < second.EmployeeWage.DegreeOfTime) return -1;
            else return 0;
        }

        private int EmployeeAnalysisInfoItem_LastnameComparer(EmployeeAnalysisInfoItem first, EmployeeAnalysisInfoItem second)
        {
            int cmp = string.Compare(first.EmployeeWage.LastName, second.EmployeeWage.LastName, StringComparison.Ordinal);
            return cmp > 0 ? 1 : cmp < 0 ? -1 : 0;
        }

        private int EmployeeAnalysisInfoItem_PersonnelNumberComparer(EmployeeAnalysisInfoItem first, EmployeeAnalysisInfoItem second)
        {
            if (first.EmployeeWage.PersonnelNumber > second.EmployeeWage.PersonnelNumber) return 1;
            else if (first.EmployeeWage.PersonnelNumber < second.EmployeeWage.PersonnelNumber) return -1;
            else return 0;
        }

        public string PeriodText
        {
            get { return myPeriodText; }
            set { myPeriodText = value; }
        }
    }
}

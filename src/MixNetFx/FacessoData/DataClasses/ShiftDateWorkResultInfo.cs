using System;
using System.Xml.Serialization;
using System.IO;
using Facesso;

namespace Facesso.Data
{
    [Serializable, XmlInclude(typeof(ProductionData)), XmlInclude(typeof(EmployeeTimeLogInfo))]
    public class ShiftDateWorkResultInfo
    {
        private CombinedParametersInfo _CombinedParameters;
        private ProductionData _ProductionData;
        private EmployeeTimeLogInfo _EmployeeTimeLogItems;
        private double _TotalReferenceIWT;
        private double _TotalEffectiveIWT;
        private double _TotalEffectiveIWTAdj;
        private double _DegreeOfTime;
        private double _DegreeOfTimeAdj;

        private CombinedSavingStateChangedEventArgs _CombinedSavingState;

        public event EventHandler<CombinedSavingStateChangedEventArgs> CombinedSavingStateChanged;
        public event EventHandler ResultsChanged;

        public ShiftDateWorkResultInfo()
        {
            CombinedSavingState = new CombinedSavingStateChangedEventArgs();
        }

        public ShiftDateWorkResultInfo(CombinedParametersInfo combinedParameters) : this()
        {
            _CombinedParameters = combinedParameters;
            ProductionData = new ProductionData(combinedParameters);
            EmployeeTimeLogItems = new EmployeeTimeLogInfo(combinedParameters);
            _ProductionData.Recalculate(true);
            _EmployeeTimeLogItems.Recalculate();
        }

        public CombinedParametersInfo CombinedParameters
        {
            get { return _CombinedParameters; }
            set { _CombinedParameters = value; }
        }

        public ProductionData ProductionData
        {
            get { return _ProductionData; }
            set
            {
                if (_ProductionData != null)
                {
                    _ProductionData.SavingStateChanged -= _ProductionData_SavingStateChanged;
                    _ProductionData.TotalReferenceIWTChanged -= _ProductionData_TotalReferenceIWTChanged;
                }
                _ProductionData = value;
                if (_ProductionData != null)
                {
                    _ProductionData.SavingStateChanged += _ProductionData_SavingStateChanged;
                    _ProductionData.TotalReferenceIWTChanged += _ProductionData_TotalReferenceIWTChanged;
                }
            }
        }

        public EmployeeTimeLogInfo EmployeeTimeLogItems
        {
            get { return _EmployeeTimeLogItems; }
            set
            {
                if (_EmployeeTimeLogItems != null)
                    _EmployeeTimeLogItems.EmployeeTimeLogItemsResultsChangedChanged -= _EmployeeTimeLogItems_EmployeeTimeLogItemsResultsChangedChanged;
                _EmployeeTimeLogItems = value;
                if (_EmployeeTimeLogItems != null)
                    _EmployeeTimeLogItems.EmployeeTimeLogItemsResultsChangedChanged += _EmployeeTimeLogItems_EmployeeTimeLogItemsResultsChangedChanged;
            }
        }

        public double TotalReferenceIWT => _TotalReferenceIWT;

        public double TotalEffectiveIWT => _TotalEffectiveIWT;

        public double TotalEffectiveIWTAdj => _TotalEffectiveIWTAdj;

        public double DegreeOfTime => _DegreeOfTime;

        public double DegreeOfTimeAdj => _DegreeOfTimeAdj;

        public CombinedSavingStateChangedEventArgs CombinedSavingState
        {
            get { return _CombinedSavingState; }
            set { _CombinedSavingState = value; }
        }

        private void _ProductionData_SavingStateChanged(object sender, ProductionDataSavingStateChangedEventArgs e)
        {
            CombinedSavingState.ForProductionDataSavingState = e.SavingState;
            CombinedSavingStateChanged?.Invoke(this, CombinedSavingState);
        }

        private void _ProductionData_TotalReferenceIWTChanged(object sender, ProductionDataTotalReferenceIWTChangedEventArgs e)
        {
            _TotalReferenceIWT = e.NewTotalReferenceIWT;
            EmployeeTimeLogItems.TotalReferenceIWT = e.NewTotalReferenceIWT;
        }

        private void _EmployeeTimeLogItems_EmployeeTimeLogItemsResultsChangedChanged(object sender, EmployeeTimeLogItemsResultsChangedEventArgs e)
        {
            Recalculate();
        }

        private void Recalculate()
        {
            _DegreeOfTime = EmployeeTimeLogItems.DegreeOfTime;
            _DegreeOfTimeAdj = EmployeeTimeLogItems.DegreeOfTimeAdj;
            _TotalEffectiveIWT = EmployeeTimeLogItems.TotalEffectiveIWT;
            _TotalEffectiveIWTAdj = EmployeeTimeLogItems.TotalEffectiveIWTAdj;
            ResultsChanged?.Invoke(this, EventArgs.Empty);
        }

        public void SaveToDatabase()
        {
            SPAccess.GetInstance().ProductionData_AddEditShiftDateWorkResults(this);
        }

        public bool DeleteProductionDataItems()
        {
            return SPAccess.GetInstance().ProductionData_DeleteItems(
                FacessoGeneric.LoginInfo.IDSubsidiary,
                CombinedParameters.WorkGroup,
                CombinedParameters.ProductionDate,
                CombinedParameters.Shift);
        }
    }

    public class CombinedSavingStateChangedEventArgs : EventArgs
    {
        private bool myForProductionDataSavingState = false;
        private bool myForTimeDataSavingState = false;

        public bool ForBothSavingState => myForProductionDataSavingState && myForTimeDataSavingState;

        public bool ForOneSavingState => myForProductionDataSavingState || myForTimeDataSavingState;

        public bool ForProductionDataSavingState
        {
            get { return myForProductionDataSavingState; }
            set { myForProductionDataSavingState = value; }
        }

        public bool ForTimeDataSavingState
        {
            get { return myForTimeDataSavingState; }
            set { myForTimeDataSavingState = value; }
        }
    }
}

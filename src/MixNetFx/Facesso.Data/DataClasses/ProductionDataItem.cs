using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Xml.Serialization;
using ActiveDev;

namespace Facesso.Data
{
    [Serializable]
    public class ProductionDataItem
    {
        private long myIDProductionDataItem;
        private int myIDArticle;
        private LabourValueInfo myLabourValue;
        private double myAmount;
        private double myAmountViaInterface;
        private double myAmountOriginal;
        private int myOrdinalNo;
        private bool myManuallyEdited;
        private double myAccumulatedAmount;

        private ProductionData myParentProductionData;

        public ProductionDataItem() { }

        public ProductionDataItem(SqlDataReader dr)
        {
            IDProductionDataItem = dr.GetInt64(dr.GetOrdinal("IDProductionDataItem"));
            IDArticle = dr.GetInt32(dr.GetOrdinal("IDArticle"));
            LabourValue = new LabourValueInfo(dr, true);
            OrdinalNo = dr.GetInt32(dr.GetOrdinal("OrdinalNumber"));
            ManuallyEdited = dr.GetBoolean(dr.GetOrdinal("ManuallyEdited"));
            Amount = dr.GetDouble(dr.GetOrdinal("Amount"));
            AmountViaInterface = dr.GetDouble(dr.GetOrdinal("AmountViaInterface"));
            myAmountOriginal = Amount;
        }

        internal ProductionData ParentProductionData
        {
            set { myParentProductionData = value; }
        }

        public long IDProductionDataItem
        {
            get { return myIDProductionDataItem; }
            set { myIDProductionDataItem = value; }
        }

        public long IDProductionData
        {
            get { return myIDProductionDataItem; }
            set { myIDProductionDataItem = value; }
        }

        public int IDArticle
        {
            get { return myIDArticle; }
            set { myIDArticle = value; }
        }

        public LabourValueInfo LabourValue
        {
            get { return myLabourValue; }
            set { myLabourValue = value; }
        }

        /// <summary>
        /// Wert, der als Berechnungsgrundlage für die Produktionsmenge in die Datenbank geschrieben wird.
        /// </summary>
        public double Amount
        {
            get { return myAmount; }
            set
            {
                myAmount = value;
                if (myParentProductionData != null)
                    myParentProductionData.Recalculate();
            }
        }

        /// <summary>
        /// Der Originalwert, der durch eine Schnittstelle in die Datenbank geschrieben wurde.
        /// </summary>
        public double AmountViaInterface
        {
            get { return myAmountViaInterface; }
            set { myAmountViaInterface = value; }
        }

        /// <summary>
        /// Vergleichswert, um festzustellen, ob die Mengen dieser Klasse geändert wurden.
        /// </summary>
        /// <remarks>Datenbankun abhängig, kann deshalb auch nicht geschrieben werden.</remarks>
        public double AmountOriginal
        {
            get { return AmountOriginal; } // recursive bug preserved from original VB
            internal set { myAmountOriginal = value; }
        }

        /// <summary>
        /// Stellt fest, ob Menge in dieser Klasse seit der Instanzierung verändert wurde.
        /// </summary>
        public bool AmountChangedSinceInstatiation => Amount != myAmountOriginal;

        public int OrdinalNo
        {
            get { return myOrdinalNo; }
            set { myOrdinalNo = value; }
        }

        /// <summary>
        /// Ermittelt oder bestimmt, ob der Wert durch eine manuelle (true) Eingabe oder durch eine Schnittstelle (false) zustande kam.
        /// </summary>
        public bool ManuallyEdited
        {
            get { return myManuallyEdited; }
            set { myManuallyEdited = value; }
        }

        /// <summary>
        /// Die Gesamtsumme, die sich durch Arbeitsbasiswert und Menge ergibt.
        /// </summary>
        public double SubTotal => Amount * LabourValue.TeHMin;

        /// <summary>
        /// Hilfsregister, das es ermöglicht, dass ein Arbeitswert seine Daten kummuliert aus verschiedenen Artikeln bei der automatischen Datenübernahme bekommt.
        /// </summary>
        /// <remarks>Wird nicht in Datenbank gespeichert.</remarks>
        public double AccumulatedAmount
        {
            get { return myAccumulatedAmount; }
            set { myAccumulatedAmount = value; }
        }
    }

    [System.CLSCompliant(true), Serializable]
    public class ProductionData : KeyedCollection<long, ProductionDataItem>
    {
        private long myIDProductionData;
        private WorkGroupInfo myWorkGroup;
        private DateTime myProductionDate;
        private byte myShift;
        private double myTotalReferenceIWT;
        private double myDegreeOfTime;
        private double myDegreeOfTimeAdj;
        private bool myInsertedByInterface;
        private bool myIsSuspended;
        private bool myDoDataExist;
        private DateTime myLastEdited;
        private int myLastEditedByIDUser;

        private double myOldTotalReferenceIWT = double.NaN;
        private ProductionDataSavingStateChangedEventArgs mySavingState;
        private long myCurrentIndex;

        public event EventHandler<ProductionDataTotalReferenceIWTChangedEventArgs> TotalReferenceIWTChanged;
        public event EventHandler<ProductionDataSavingStateChangedEventArgs> SavingStateChanged;

        public ProductionData() : base()
        {
            myCurrentIndex = -1;
            mySavingState = new ProductionDataSavingStateChangedEventArgs(false);
            mySavingState.SavingStateChanged += mySavingState_SavingStateChanged;
        }

        public ProductionData(CombinedParametersInfo combinedParameters) : this()
        {
            myWorkGroup = combinedParameters.WorkGroup;
            myProductionDate = combinedParameters.ProductionDate;
            myShift = combinedParameters.Shift;
            SPAccess.GetInstance().ProductionData_GetProductionData(this, 1);
        }

        private void mySavingState_SavingStateChanged(object sender, EventArgs e)
        {
            SavingStateChanged?.Invoke(this, mySavingState);
        }

        public ProductionDataItem GetItemFromIDLabourValue(int idLabourValue)
        {
            foreach (ProductionDataItem locItem in this)
            {
                if (locItem.LabourValue.IDLabourValue == idLabourValue)
                    return locItem;
            }
            throw new IndexOutOfRangeException("The Item with the specified LabourValueID could not be found!");
        }

        protected override long GetKeyForItem(ProductionDataItem item)
        {
            return item.IDProductionData;
        }

        protected override void InsertItem(int index, ProductionDataItem item)
        {
            if (item.IDProductionDataItem == 0)
            {
                item.IDProductionDataItem = myCurrentIndex;
                myCurrentIndex -= 1;
            }
            base.InsertItem(index, item);
            item.ParentProductionData = this;
            Recalculate();
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Recalculate();
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            Recalculate();
        }

        protected override void SetItem(int index, ProductionDataItem item)
        {
            item.ParentProductionData = this;
            base.SetItem(index, item);
            Recalculate();
        }

        internal void Recalculate()
        {
            Recalculate(false);
        }

        internal void Recalculate(bool raiseEventInAnyCase)
        {
            bool locFlag = false;

            myTotalReferenceIWT = 0;
            foreach (ProductionDataItem locItem in this)
            {
                myTotalReferenceIWT += locItem.SubTotal;
                locFlag = locFlag | locItem.AmountChangedSinceInstatiation;
            }
            if ((myOldTotalReferenceIWT != myTotalReferenceIWT) || raiseEventInAnyCase)
            {
                TotalReferenceIWTChanged?.Invoke(this, new ProductionDataTotalReferenceIWTChangedEventArgs(myTotalReferenceIWT));
            }
            myOldTotalReferenceIWT = myTotalReferenceIWT;
            mySavingState.SavingState = locFlag;
        }

        public void ResetSavingState()
        {
            mySavingState.SavingState = false;
        }

        public void SaveToDatabase(int idUser, bool updateResultSet)
        {
            if (updateResultSet)
            {
                this.Clear();
                foreach (ProductionDataItem locItem in SPAccess.GetInstance().ProductionData_AddEditProductionData(this, idUser, true))
                    this.Add(locItem);
            }
            else
            {
                SPAccess.GetInstance().ProductionData_AddEditProductionData(this, idUser, false);
            }
        }

        public long IDProductionData
        {
            get { return myIDProductionData; }
            set { myIDProductionData = value; }
        }

        public WorkGroupInfo WorkGroup
        {
            get { return myWorkGroup; }
            set { myWorkGroup = value; }
        }

        public DateTime ProductionDate
        {
            get { return myProductionDate; }
            set { myProductionDate = value; }
        }

        public byte Shift
        {
            get { return myShift; }
            set { myShift = value; }
        }

        public bool DoDataExist
        {
            get { return myDoDataExist; }
            set { myDoDataExist = value; }
        }

        public double TotalReferenceIWT => myTotalReferenceIWT;

        public double DegreeOfTime
        {
            get { return myDegreeOfTime; }
            set { myDegreeOfTime = value; }
        }

        public double DegreeOfTimeAdj
        {
            get { return myDegreeOfTimeAdj; }
            set { myDegreeOfTimeAdj = value; }
        }

        public bool InsertedByInterface
        {
            get { return myInsertedByInterface; }
            set { myInsertedByInterface = value; }
        }

        public bool IsSuspended
        {
            get { return myIsSuspended; }
            set { myIsSuspended = value; }
        }

        public DateTime LastEdited
        {
            get { return myLastEdited; }
            set { myLastEdited = value; }
        }

        public int LastEditedByIDUser
        {
            get { return myLastEditedByIDUser; }
            set { myLastEditedByIDUser = value; }
        }
    }

    public class ProductionDataTotalReferenceIWTChangedEventArgs : EventArgs
    {
        private double myNewTotalReferenceIWT;

        public ProductionDataTotalReferenceIWTChangedEventArgs() { }

        public ProductionDataTotalReferenceIWTChangedEventArgs(double newTotalReferenceIWT)
        {
            myNewTotalReferenceIWT = newTotalReferenceIWT;
        }

        public double NewTotalReferenceIWT
        {
            get { return myNewTotalReferenceIWT; }
            set { myNewTotalReferenceIWT = value; }
        }
    }

    public class ProductionDataSavingStateChangedEventArgs : EventArgs
    {
        private bool mySavingState;
        internal event EventHandler SavingStateChanged;

        public ProductionDataSavingStateChangedEventArgs() { }

        public ProductionDataSavingStateChangedEventArgs(bool savingState)
        {
            mySavingState = savingState;
        }

        /// <summary>
        /// Zeigt an, ob die Daten gespeichert werden müssen (true) oder nicht (false).
        /// </summary>
        public bool SavingState
        {
            get { return mySavingState; }
            set
            {
                if (value != SavingState)
                {
                    mySavingState = value;
                    SavingStateChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}

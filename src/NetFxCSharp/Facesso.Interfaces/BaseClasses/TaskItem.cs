using Facesso;
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

namespace Facesso.Interfaces
{
    [Serializable()]
    public class FacessoTaskItems : System.Collections.ObjectModel.KeyedCollection<long, FacessoTaskItemBase>
    {
        public int NextPriorityLevel()
        {
            int locPriority = -1;
            foreach (IFacessoImportTaskItem locItem in this)
            {
                if (locItem.Priority > locPriority)
                {
                    locPriority = locItem.Priority;
                }
            }

            return locPriority + 1;
        }

        public long NextTaskID()
        {
            long locTaskID = -1;
            foreach (IFacessoImportTaskItem locItem in this)
            {
                if (locItem.TaskID > locTaskID)
                {
                    locTaskID = locItem.TaskID;
                }
            }

            return locTaskID + 1;
        }

        protected override long GetKeyForItem(FacessoTaskItemBase item)
        {
            return item.TaskID;
        }
    }

    [Serializable()]
    public abstract class FacessoTaskItemBase : IFacessoImportTaskItem
    {
        private FacessoConversionItemsBase myConversionItems;
        private long myTaskID;
        private WorkGroupInfo myWorkgroup;
        private WorkGroupInfo myForWorkgroup;
        private string myName;
        private int myPriority;
        public abstract IImportResultTable GetData(System.DateTime ProductionDate, ShiftCombination Shift);
        public abstract FacessoImportType ImportType { get; }
        public abstract FacessoInterfaceBrand InterfaceBrand { get; }

        public abstract System.Windows.Forms.DialogResult ConfigureGenericInterface();
        public abstract bool IsGenericInterfaceConfigured { get; }

        public abstract DialogResult ConfigureImportFilter();
        public abstract IFacessoImportTaskItem.GetConversionItemsDelegate ConversionItemsDelegate { get; }

        public FacessoTaskItemBase() : base()
        {
        }

        public virtual FacessoConversionItemsBase ConversionItems
        {
            get
            {
                return myConversionItems;
            }

            set
            {
                myConversionItems = value;
            }
        }

        public virtual long TaskID
        {
            get
            {
                return myTaskID;
            }

            set
            {
                myTaskID = value;
            }
        }

        public virtual int IDWorkgroup
        {
            get
            {
                if (ForWorkgroup != null)
                {
                    return ForWorkgroup.IDWorkGroup;
                }
                else
                {
                    return -1;
                }
            }

            set
            {
                if (value > -1)
                {
                    myForWorkgroup = WorkGroupInfo.FromID(FacessoGeneric.LoginInfo.IDSubsidiary, System.Convert.ToInt32(value));
                }
            }
        }

        public WorkGroupInfo ForWorkgroup
        {
            get
            {
                return myForWorkgroup;
            }
        }

        public string Name
        {
            get
            {
                return myName;
            }

            set
            {
                myName = value;
            }
        }

        public int Priority
        {
            get
            {
                return myPriority;
            }

            set
            {
                myPriority = value;
            }
        }

        public override string ToString()
        {
            return TaskID.ToString();
        }
    }

    [Serializable()]
    public abstract class FacessoProductionDataImportTaskItemBase : FacessoTaskItemBase
    {
        public override System.Windows.Forms.DialogResult ConfigureImportFilter()
        {
            frmProductionDataConfigureDialogBase locFrm = new frmProductionDataConfigureDialogBase();
            return locFrm.HandleDialog(this);
        }

        /// <summary>
        /// Erstellt eine generische Konvertierungstabelle,
        /// die in den jeweiligen Ableitungen für die Zuordnungen FremdID-->Produktiv-Site verantwortlich ist.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Diese wird Indirekt über den Delegaten ConversionItemsDelegate aufgerufen.</remarks>
        public virtual FacessoConversionItemsBase AssembleConversionItems()
        {
            FacessoConversionItemsBase locConversionItems = default(FacessoConversionItemsBase);
            locConversionItems = new FacessoConversionItemsBase();
            for (int c = 0; c <= 100; c++)
            {
                locConversionItems.Add(new FacessoConversionItemBase(c, "Programm Nr. " + c.ToString("000")));
            }

            return locConversionItems;
        }

        /// <summary>
        /// Ermittelt den Delegaten, der die Funktion zur Verfügung stellt, die die Konvertierungstabelle aufbaut.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public override IFacessoImportTaskItem.GetConversionItemsDelegate ConversionItemsDelegate
        {
            get
            {
                return AssembleConversionItems;
            }
        }

        public override FacessoImportType ImportType
        {
            get
            {
                return FacessoImportType.WorkGroupData;
            }
        }
    }

    [Serializable()]
    public class FacessoTaskItemTemplate : IFacessoImportTaskItem
    {
        private WorkGroupInfo myWorkgroup;
        private string myName;
        private FacessoInterfaceBrand myInterfaceBrand;
        private FacessoImportType myImportType;
        private long myTaskID;
        private int myPriority;
        public FacessoTaskItemTemplate(long TaskID, string Name, FacessoImportType ImportType) : this(TaskID, Name, ImportType, -1)
        {
        }

        public FacessoTaskItemTemplate(long TaskID, string Name, FacessoImportType ImportType, long IDWorkgroup)
        {
            myTaskID = TaskID;
            myName = Name;
            myImportType = ImportType;
            if (IDWorkgroup == -1)
            {
                myWorkgroup = null;
            }
            else
            {
                myWorkgroup = WorkGroupInfo.FromID(FacessoGeneric.LoginInfo.IDSubsidiary, System.Convert.ToInt32(IDWorkgroup));
            }
        }

        public System.Windows.Forms.DialogResult ConfigureImportFilter()
        {
            return DialogResult.Ignore;
        }

        public FacessoConversionItemsBase ConversionItems
        {
            get
            {
                return null;
            }

            set
            {
            }
        }

        public IFacessoImportTaskItem.GetConversionItemsDelegate ConversionItemsDelegate
        {
            get
            {
                return null;
            }
        }

        public Facesso.Data.WorkGroupInfo ForWorkgroup
        {
            get
            {
                return myWorkgroup;
            }
        }

        public IImportResultTable GetData(System.DateTime ProductionDate, ShiftCombination Shift)
        {
            return null;
        }

        public int IDWorkgroup
        {
            get
            {
                if (myWorkgroup == null)
                {
                    return -1;
                }

                return myWorkgroup.IDWorkGroup;
            }

            set
            {
                if (value == -1)
                {
                    myWorkgroup = null;
                    return;
                }

                myWorkgroup = WorkGroupInfo.FromID(FacessoGeneric.LoginInfo.IDSubsidiary, IDWorkgroup);
            }
        }

        public FacessoImportType ImportType
        {
            get
            {
                return myImportType;
            }
        }

        public FacessoInterfaceBrand InterfaceBrand
        {
            get
            {
                return myInterfaceBrand;
            }
        }

        public void SetInterfaceBrand(FacessoInterfaceBrand InterfaceBrand)
        {
            myInterfaceBrand = InterfaceBrand;
        }

        public string Name
        {
            get
            {
                return myName;
            }

            set
            {
                myName = value;
            }
        }

        public long TaskID
        {
            get
            {
                return myTaskID;
            }

            set
            {
                myTaskID = value;
            }
        }

        public override string ToString()
        {
            return myName;
        }

        public int Priority
        {
            get
            {
                return myPriority;
            }

            set
            {
                myPriority = value;
            }
        }

        public System.Windows.Forms.DialogResult ConfigureGenericInterface()
        {
            return DialogResult.OK;
        }

        public bool IsGenericInterfaceConfigured
        {
            get
            {
                return true;
            }
        }
    }
}
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    [System.Data.Linq.Mapping.DatabaseAttribute(Name = "Legatro")]
    public partial class LegatroDataContext : System.Data.Linq.DataContext
    {
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
        partial void OnCreated();
        partial void InsertWorksitesOrProjects(WorksitesOrProjects instance);
        partial void UpdateWorksitesOrProjects(WorksitesOrProjects instance);
        partial void DeleteWorksitesOrProjects(WorksitesOrProjects instance);
        public LegatroDataContext() : base(global::Facesso.Interfaces.My.MySettings.Default.LegatroConnectionString, mappingSource)
        {
            OnCreated();
        }

        public LegatroDataContext(string connection) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public LegatroDataContext(System.Data.IDbConnection connection) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public LegatroDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public LegatroDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public System.Data.Linq.Table<ViewFlatTimes> ViewFlatTimes
        {
            get
            {
                return this.GetTable<ViewFlatTimes>();
            }
        }

        public System.Data.Linq.Table<ViewTimeLogNativeVerbatim> ViewTimeLogNativeVerbatim
        {
            get
            {
                return this.GetTable<ViewTimeLogNativeVerbatim>();
            }
        }

        public System.Data.Linq.Table<WorksitesOrProjects> WorksitesOrProjects
        {
            get
            {
                return this.GetTable<WorksitesOrProjects>();
            }
        }
    }

    [System.Data.Linq.Mapping.TableAttribute(Name = "dbo.ViewFlatTimes")]
    public partial class ViewFlatTimes
    {
        private System.Nullable<System.DateTime> _StartTime;
        private System.Nullable<System.DateTime> _EndTime;
        private System.Nullable<int> _Duration;
        private System.Nullable<int> _PersonnelNumber;
        private string _LastName;
        private string _FirstName;
        private string _MiddleName;
        private string _WorkEntityName;
        private System.Nullable<int> _WorkEntityNumber;
        private System.Nullable<int> _CostCenterNo;
        private string _CostCenterName;
        private string _TimeLogEventName;
        private System.Guid _IDTimeLogFlat;
        public ViewFlatTimes() : base()
        {
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_StartTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> StartTime
        {
            get
            {
                return this._StartTime;
            }

            set
            {
                if ((this._StartTime.Equals(value) == false))
                {
                    this._StartTime = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EndTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> EndTime
        {
            get
            {
                return this._EndTime;
            }

            set
            {
                if ((this._EndTime.Equals(value) == false))
                {
                    this._EndTime = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Duration", DbType = "Int")]
        public System.Nullable<int> Duration
        {
            get
            {
                return this._Duration;
            }

            set
            {
                if ((this._Duration.Equals(value) == false))
                {
                    this._Duration = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PersonnelNumber", DbType = "Int")]
        public System.Nullable<int> PersonnelNumber
        {
            get
            {
                return this._PersonnelNumber;
            }

            set
            {
                if ((this._PersonnelNumber.Equals(value) == false))
                {
                    this._PersonnelNumber = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LastName", DbType = "NVarChar(100)")]
        public string LastName
        {
            get
            {
                return this._LastName;
            }

            set
            {
                if ((string.Equals(this._LastName, value) == false))
                {
                    this._LastName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FirstName", DbType = "NVarChar(100)")]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }

            set
            {
                if ((string.Equals(this._FirstName, value) == false))
                {
                    this._FirstName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MiddleName", DbType = "NVarChar(100)")]
        public string MiddleName
        {
            get
            {
                return this._MiddleName;
            }

            set
            {
                if ((string.Equals(this._MiddleName, value) == false))
                {
                    this._MiddleName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WorkEntityName", DbType = "NVarChar(255)")]
        public string WorkEntityName
        {
            get
            {
                return this._WorkEntityName;
            }

            set
            {
                if ((string.Equals(this._WorkEntityName, value) == false))
                {
                    this._WorkEntityName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WorkEntityNumber", DbType = "Int")]
        public System.Nullable<int> WorkEntityNumber
        {
            get
            {
                return this._WorkEntityNumber;
            }

            set
            {
                if ((this._WorkEntityNumber.Equals(value) == false))
                {
                    this._WorkEntityNumber = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CostCenterNo", DbType = "Int")]
        public System.Nullable<int> CostCenterNo
        {
            get
            {
                return this._CostCenterNo;
            }

            set
            {
                if ((this._CostCenterNo.Equals(value) == false))
                {
                    this._CostCenterNo = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CostCenterName", DbType = "NVarChar(100)")]
        public string CostCenterName
        {
            get
            {
                return this._CostCenterName;
            }

            set
            {
                if ((string.Equals(this._CostCenterName, value) == false))
                {
                    this._CostCenterName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TimeLogEventName", DbType = "NVarChar(50)")]
        public string TimeLogEventName
        {
            get
            {
                return this._TimeLogEventName;
            }

            set
            {
                if ((string.Equals(this._TimeLogEventName, value) == false))
                {
                    this._TimeLogEventName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDTimeLogFlat", DbType = "UniqueIdentifier NOT NULL")]
        public System.Guid IDTimeLogFlat
        {
            get
            {
                return this._IDTimeLogFlat;
            }

            set
            {
                if (((this._IDTimeLogFlat == value) == false))
                {
                    this._IDTimeLogFlat = value;
                }
            }
        }
    }

    [System.Data.Linq.Mapping.TableAttribute(Name = "dbo.ViewTimeLogNativeVerbatim")]
    public partial class ViewTimeLogNativeVerbatim
    {
        private System.Nullable<System.Guid> _IDTimeLogNative;
        private int _PersonnelNumber;
        private string _LastName;
        private string _FirstName;
        private string _MiddleName;
        private string _Matchcode;
        private string _CombinedName;
        private short _BookingType;
        private string _TimeLogEventName;
        private string _WorkEntityName;
        private System.Nullable<int> _WorkEntityNumber;
        private System.Nullable<System.Guid> _IDTimeLogNativeEditable;
        private System.Nullable<System.Guid> _IDTimeLogEventType;
        private System.Nullable<System.Guid> _IDWorksiteOrProject;
        private System.Nullable<System.Guid> _IDEmployee;
        private System.Nullable<System.Guid> _IDOrder;
        private System.Nullable<System.Guid> _IDTimeLogDevice;
        private System.Nullable<System.DateTime> _EventTime;
        private System.Nullable<System.Guid> _IDTimeLogFlat;
        public ViewTimeLogNativeVerbatim() : base()
        {
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDTimeLogNative", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDTimeLogNative
        {
            get
            {
                return this._IDTimeLogNative;
            }

            set
            {
                if ((this._IDTimeLogNative.Equals(value) == false))
                {
                    this._IDTimeLogNative = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PersonnelNumber", DbType = "Int NOT NULL")]
        public int PersonnelNumber
        {
            get
            {
                return this._PersonnelNumber;
            }

            set
            {
                if (((this._PersonnelNumber == value) == false))
                {
                    this._PersonnelNumber = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LastName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string LastName
        {
            get
            {
                return this._LastName;
            }

            set
            {
                if ((string.Equals(this._LastName, value) == false))
                {
                    this._LastName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FirstName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }

            set
            {
                if ((string.Equals(this._FirstName, value) == false))
                {
                    this._FirstName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MiddleName", DbType = "NVarChar(100)")]
        public string MiddleName
        {
            get
            {
                return this._MiddleName;
            }

            set
            {
                if ((string.Equals(this._MiddleName, value) == false))
                {
                    this._MiddleName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Matchcode", DbType = "NVarChar(50)")]
        public string Matchcode
        {
            get
            {
                return this._Matchcode;
            }

            set
            {
                if ((string.Equals(this._Matchcode, value) == false))
                {
                    this._Matchcode = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CombinedName", DbType = "NVarChar(202) NOT NULL", CanBeNull = false)]
        public string CombinedName
        {
            get
            {
                return this._CombinedName;
            }

            set
            {
                if ((string.Equals(this._CombinedName, value) == false))
                {
                    this._CombinedName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingType", DbType = "SmallInt NOT NULL")]
        public short BookingType
        {
            get
            {
                return this._BookingType;
            }

            set
            {
                if (((this._BookingType == value) == false))
                {
                    this._BookingType = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TimeLogEventName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string TimeLogEventName
        {
            get
            {
                return this._TimeLogEventName;
            }

            set
            {
                if ((string.Equals(this._TimeLogEventName, value) == false))
                {
                    this._TimeLogEventName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WorkEntityName", DbType = "NVarChar(255)")]
        public string WorkEntityName
        {
            get
            {
                return this._WorkEntityName;
            }

            set
            {
                if ((string.Equals(this._WorkEntityName, value) == false))
                {
                    this._WorkEntityName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WorkEntityNumber", DbType = "Int")]
        public System.Nullable<int> WorkEntityNumber
        {
            get
            {
                return this._WorkEntityNumber;
            }

            set
            {
                if ((this._WorkEntityNumber.Equals(value) == false))
                {
                    this._WorkEntityNumber = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDTimeLogNativeEditable", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDTimeLogNativeEditable
        {
            get
            {
                return this._IDTimeLogNativeEditable;
            }

            set
            {
                if ((this._IDTimeLogNativeEditable.Equals(value) == false))
                {
                    this._IDTimeLogNativeEditable = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDTimeLogEventType", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDTimeLogEventType
        {
            get
            {
                return this._IDTimeLogEventType;
            }

            set
            {
                if ((this._IDTimeLogEventType.Equals(value) == false))
                {
                    this._IDTimeLogEventType = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDWorksiteOrProject", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDWorksiteOrProject
        {
            get
            {
                return this._IDWorksiteOrProject;
            }

            set
            {
                if ((this._IDWorksiteOrProject.Equals(value) == false))
                {
                    this._IDWorksiteOrProject = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDEmployee", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDEmployee
        {
            get
            {
                return this._IDEmployee;
            }

            set
            {
                if ((this._IDEmployee.Equals(value) == false))
                {
                    this._IDEmployee = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDOrder", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDOrder
        {
            get
            {
                return this._IDOrder;
            }

            set
            {
                if ((this._IDOrder.Equals(value) == false))
                {
                    this._IDOrder = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDTimeLogDevice", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDTimeLogDevice
        {
            get
            {
                return this._IDTimeLogDevice;
            }

            set
            {
                if ((this._IDTimeLogDevice.Equals(value) == false))
                {
                    this._IDTimeLogDevice = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EventTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> EventTime
        {
            get
            {
                return this._EventTime;
            }

            set
            {
                if ((this._EventTime.Equals(value) == false))
                {
                    this._EventTime = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDTimeLogFlat", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDTimeLogFlat
        {
            get
            {
                return this._IDTimeLogFlat;
            }

            set
            {
                if ((this._IDTimeLogFlat.Equals(value) == false))
                {
                    this._IDTimeLogFlat = value;
                }
            }
        }
    }

    [System.Data.Linq.Mapping.TableAttribute(Name = "dbo.WorksitesOrProjects")]
    public partial class WorksitesOrProjects : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private System.Guid _IDWorksiteOrProject;
        private System.Guid _IDCostCenter;
        private System.Nullable<System.Guid> _IDUserAsOwner;
        private System.Nullable<System.Guid> _IDCustomer;
        private System.Nullable<System.Guid> _IDContactForWorksiteOrProject;
        private System.Guid _IDCostObjects;
        private int _WorkEntityNumber;
        private string _WorkEntityName;
        private string _ShortWorkEntityName;
        private bool _IsProject;
        private bool _IsActive;
        private string _Description;
        private System.Nullable<bool> _MonitorTimeCapacity;
        private System.Nullable<int> _MonthlyTargetTimeCapacity;
        private System.Nullable<System.DateTime> _MonitorStartdate;
        private System.Nullable<System.DateTime> _MonitorEnddate;
        private System.Nullable<int> _TotalTargetTimeCapacity;
        private bool _CollectProductionUnits;
        private bool _CollectProductionUnitsDescription;
        private System.DateTime _LastEditDate;
        private System.DateTime _CreationDate;
        private System.Guid _SyncGuid;
        private bool _IsDeleted;
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDWorksiteOrProjectChanging(System.Guid value);
        partial void OnIDWorksiteOrProjectChanged();
        partial void OnIDCostCenterChanging(System.Guid value);
        partial void OnIDCostCenterChanged();
        partial void OnIDUserAsOwnerChanging(System.Nullable<System.Guid> value);
        partial void OnIDUserAsOwnerChanged();
        partial void OnIDCustomerChanging(System.Nullable<System.Guid> value);
        partial void OnIDCustomerChanged();
        partial void OnIDContactForWorksiteOrProjectChanging(System.Nullable<System.Guid> value);
        partial void OnIDContactForWorksiteOrProjectChanged();
        partial void OnIDCostObjectsChanging(System.Guid value);
        partial void OnIDCostObjectsChanged();
        partial void OnWorkEntityNumberChanging(int value);
        partial void OnWorkEntityNumberChanged();
        partial void OnWorkEntityNameChanging(string value);
        partial void OnWorkEntityNameChanged();
        partial void OnShortWorkEntityNameChanging(string value);
        partial void OnShortWorkEntityNameChanged();
        partial void OnIsProjectChanging(bool value);
        partial void OnIsProjectChanged();
        partial void OnIsActiveChanging(bool value);
        partial void OnIsActiveChanged();
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        partial void OnMonitorTimeCapacityChanging(System.Nullable<bool> value);
        partial void OnMonitorTimeCapacityChanged();
        partial void OnMonthlyTargetTimeCapacityChanging(System.Nullable<int> value);
        partial void OnMonthlyTargetTimeCapacityChanged();
        partial void OnMonitorStartdateChanging(System.Nullable<System.DateTime> value);
        partial void OnMonitorStartdateChanged();
        partial void OnMonitorEnddateChanging(System.Nullable<System.DateTime> value);
        partial void OnMonitorEnddateChanged();
        partial void OnTotalTargetTimeCapacityChanging(System.Nullable<int> value);
        partial void OnTotalTargetTimeCapacityChanged();
        partial void OnCollectProductionUnitsChanging(bool value);
        partial void OnCollectProductionUnitsChanged();
        partial void OnCollectProductionUnitsDescriptionChanging(bool value);
        partial void OnCollectProductionUnitsDescriptionChanged();
        partial void OnLastEditDateChanging(System.DateTime value);
        partial void OnLastEditDateChanged();
        partial void OnCreationDateChanging(System.DateTime value);
        partial void OnCreationDateChanged();
        partial void OnSyncGuidChanging(System.Guid value);
        partial void OnSyncGuidChanged();
        partial void OnIsDeletedChanging(bool value);
        partial void OnIsDeletedChanged();
        public WorksitesOrProjects() : base()
        {
            OnCreated();
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDWorksiteOrProject", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
        public System.Guid IDWorksiteOrProject
        {
            get
            {
                return this._IDWorksiteOrProject;
            }

            set
            {
                if (((this._IDWorksiteOrProject == value) == false))
                {
                    this.OnIDWorksiteOrProjectChanging(value);
                    this.SendPropertyChanging();
                    this._IDWorksiteOrProject = value;
                    this.SendPropertyChanged("IDWorksiteOrProject");
                    this.OnIDWorksiteOrProjectChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDCostCenter", DbType = "UniqueIdentifier NOT NULL")]
        public System.Guid IDCostCenter
        {
            get
            {
                return this._IDCostCenter;
            }

            set
            {
                if (((this._IDCostCenter == value) == false))
                {
                    this.OnIDCostCenterChanging(value);
                    this.SendPropertyChanging();
                    this._IDCostCenter = value;
                    this.SendPropertyChanged("IDCostCenter");
                    this.OnIDCostCenterChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDUserAsOwner", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDUserAsOwner
        {
            get
            {
                return this._IDUserAsOwner;
            }

            set
            {
                if ((this._IDUserAsOwner.Equals(value) == false))
                {
                    this.OnIDUserAsOwnerChanging(value);
                    this.SendPropertyChanging();
                    this._IDUserAsOwner = value;
                    this.SendPropertyChanged("IDUserAsOwner");
                    this.OnIDUserAsOwnerChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDCustomer", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDCustomer
        {
            get
            {
                return this._IDCustomer;
            }

            set
            {
                if ((this._IDCustomer.Equals(value) == false))
                {
                    this.OnIDCustomerChanging(value);
                    this.SendPropertyChanging();
                    this._IDCustomer = value;
                    this.SendPropertyChanged("IDCustomer");
                    this.OnIDCustomerChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDContactForWorksiteOrProject", DbType = "UniqueIdentifier")]
        public System.Nullable<System.Guid> IDContactForWorksiteOrProject
        {
            get
            {
                return this._IDContactForWorksiteOrProject;
            }

            set
            {
                if ((this._IDContactForWorksiteOrProject.Equals(value) == false))
                {
                    this.OnIDContactForWorksiteOrProjectChanging(value);
                    this.SendPropertyChanging();
                    this._IDContactForWorksiteOrProject = value;
                    this.SendPropertyChanged("IDContactForWorksiteOrProject");
                    this.OnIDContactForWorksiteOrProjectChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDCostObjects", DbType = "UniqueIdentifier NOT NULL")]
        public System.Guid IDCostObjects
        {
            get
            {
                return this._IDCostObjects;
            }

            set
            {
                if (((this._IDCostObjects == value) == false))
                {
                    this.OnIDCostObjectsChanging(value);
                    this.SendPropertyChanging();
                    this._IDCostObjects = value;
                    this.SendPropertyChanged("IDCostObjects");
                    this.OnIDCostObjectsChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WorkEntityNumber", DbType = "Int NOT NULL")]
        public int WorkEntityNumber
        {
            get
            {
                return this._WorkEntityNumber;
            }

            set
            {
                if (((this._WorkEntityNumber == value) == false))
                {
                    this.OnWorkEntityNumberChanging(value);
                    this.SendPropertyChanging();
                    this._WorkEntityNumber = value;
                    this.SendPropertyChanged("WorkEntityNumber");
                    this.OnWorkEntityNumberChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WorkEntityName", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string WorkEntityName
        {
            get
            {
                return this._WorkEntityName;
            }

            set
            {
                if ((string.Equals(this._WorkEntityName, value) == false))
                {
                    this.OnWorkEntityNameChanging(value);
                    this.SendPropertyChanging();
                    this._WorkEntityName = value;
                    this.SendPropertyChanged("WorkEntityName");
                    this.OnWorkEntityNameChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ShortWorkEntityName", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
        public string ShortWorkEntityName
        {
            get
            {
                return this._ShortWorkEntityName;
            }

            set
            {
                if ((string.Equals(this._ShortWorkEntityName, value) == false))
                {
                    this.OnShortWorkEntityNameChanging(value);
                    this.SendPropertyChanging();
                    this._ShortWorkEntityName = value;
                    this.SendPropertyChanged("ShortWorkEntityName");
                    this.OnShortWorkEntityNameChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsProject", DbType = "Bit NOT NULL")]
        public bool IsProject
        {
            get
            {
                return this._IsProject;
            }

            set
            {
                if (((this._IsProject == value) == false))
                {
                    this.OnIsProjectChanging(value);
                    this.SendPropertyChanging();
                    this._IsProject = value;
                    this.SendPropertyChanged("IsProject");
                    this.OnIsProjectChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsActive", DbType = "Bit NOT NULL")]
        public bool IsActive
        {
            get
            {
                return this._IsActive;
            }

            set
            {
                if (((this._IsActive == value) == false))
                {
                    this.OnIsActiveChanging(value);
                    this.SendPropertyChanging();
                    this._IsActive = value;
                    this.SendPropertyChanged("IsActive");
                    this.OnIsActiveChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Description", DbType = "NVarChar(3000)")]
        public string Description
        {
            get
            {
                return this._Description;
            }

            set
            {
                if ((string.Equals(this._Description, value) == false))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._Description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MonitorTimeCapacity", DbType = "Bit")]
        public System.Nullable<bool> MonitorTimeCapacity
        {
            get
            {
                return this._MonitorTimeCapacity;
            }

            set
            {
                if ((this._MonitorTimeCapacity.Equals(value) == false))
                {
                    this.OnMonitorTimeCapacityChanging(value);
                    this.SendPropertyChanging();
                    this._MonitorTimeCapacity = value;
                    this.SendPropertyChanged("MonitorTimeCapacity");
                    this.OnMonitorTimeCapacityChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MonthlyTargetTimeCapacity", DbType = "Int")]
        public System.Nullable<int> MonthlyTargetTimeCapacity
        {
            get
            {
                return this._MonthlyTargetTimeCapacity;
            }

            set
            {
                if ((this._MonthlyTargetTimeCapacity.Equals(value) == false))
                {
                    this.OnMonthlyTargetTimeCapacityChanging(value);
                    this.SendPropertyChanging();
                    this._MonthlyTargetTimeCapacity = value;
                    this.SendPropertyChanged("MonthlyTargetTimeCapacity");
                    this.OnMonthlyTargetTimeCapacityChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MonitorStartdate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> MonitorStartdate
        {
            get
            {
                return this._MonitorStartdate;
            }

            set
            {
                if ((this._MonitorStartdate.Equals(value) == false))
                {
                    this.OnMonitorStartdateChanging(value);
                    this.SendPropertyChanging();
                    this._MonitorStartdate = value;
                    this.SendPropertyChanged("MonitorStartdate");
                    this.OnMonitorStartdateChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MonitorEnddate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> MonitorEnddate
        {
            get
            {
                return this._MonitorEnddate;
            }

            set
            {
                if ((this._MonitorEnddate.Equals(value) == false))
                {
                    this.OnMonitorEnddateChanging(value);
                    this.SendPropertyChanging();
                    this._MonitorEnddate = value;
                    this.SendPropertyChanged("MonitorEnddate");
                    this.OnMonitorEnddateChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TotalTargetTimeCapacity", DbType = "Int")]
        public System.Nullable<int> TotalTargetTimeCapacity
        {
            get
            {
                return this._TotalTargetTimeCapacity;
            }

            set
            {
                if ((this._TotalTargetTimeCapacity.Equals(value) == false))
                {
                    this.OnTotalTargetTimeCapacityChanging(value);
                    this.SendPropertyChanging();
                    this._TotalTargetTimeCapacity = value;
                    this.SendPropertyChanged("TotalTargetTimeCapacity");
                    this.OnTotalTargetTimeCapacityChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CollectProductionUnits", DbType = "Bit NOT NULL")]
        public bool CollectProductionUnits
        {
            get
            {
                return this._CollectProductionUnits;
            }

            set
            {
                if (((this._CollectProductionUnits == value) == false))
                {
                    this.OnCollectProductionUnitsChanging(value);
                    this.SendPropertyChanging();
                    this._CollectProductionUnits = value;
                    this.SendPropertyChanged("CollectProductionUnits");
                    this.OnCollectProductionUnitsChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CollectProductionUnitsDescription", DbType = "Bit NOT NULL")]
        public bool CollectProductionUnitsDescription
        {
            get
            {
                return this._CollectProductionUnitsDescription;
            }

            set
            {
                if (((this._CollectProductionUnitsDescription == value) == false))
                {
                    this.OnCollectProductionUnitsDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._CollectProductionUnitsDescription = value;
                    this.SendPropertyChanged("CollectProductionUnitsDescription");
                    this.OnCollectProductionUnitsDescriptionChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LastEditDate", DbType = "DateTime NOT NULL")]
        public System.DateTime LastEditDate
        {
            get
            {
                return this._LastEditDate;
            }

            set
            {
                if (((this._LastEditDate == value) == false))
                {
                    this.OnLastEditDateChanging(value);
                    this.SendPropertyChanging();
                    this._LastEditDate = value;
                    this.SendPropertyChanged("LastEditDate");
                    this.OnLastEditDateChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CreationDate", DbType = "DateTime NOT NULL")]
        public System.DateTime CreationDate
        {
            get
            {
                return this._CreationDate;
            }

            set
            {
                if (((this._CreationDate == value) == false))
                {
                    this.OnCreationDateChanging(value);
                    this.SendPropertyChanging();
                    this._CreationDate = value;
                    this.SendPropertyChanged("CreationDate");
                    this.OnCreationDateChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SyncGuid", DbType = "UniqueIdentifier NOT NULL")]
        public System.Guid SyncGuid
        {
            get
            {
                return this._SyncGuid;
            }

            set
            {
                if (((this._SyncGuid == value) == false))
                {
                    this.OnSyncGuidChanging(value);
                    this.SendPropertyChanging();
                    this._SyncGuid = value;
                    this.SendPropertyChanged("SyncGuid");
                    this.OnSyncGuidChanged();
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsDeleted", DbType = "Bit NOT NULL")]
        public bool IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }

            set
            {
                if (((this._IsDeleted == value) == false))
                {
                    this.OnIsDeletedChanging(value);
                    this.SendPropertyChanging();
                    this._IsDeleted = value;
                    this.SendPropertyChanged("IsDeleted");
                    this.OnIsDeletedChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging()
        {
            if (((this.PropertyChanging == null) == false))
            {
                PropertyChanging?.Invoke(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if (((this.PropertyChanged == null) == false))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
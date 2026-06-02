using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Facesso.EntityModel
{
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class FacessoEntities : ObjectContext
    {
        /// <summary>
        /// Initializes a new FacessoEntities object using the connection string found in the 'FacessoEntities' section of the application configuration file.
        /// </summary>
        public FacessoEntities() : base("name=FacessoEntities", "FacessoEntities")
        {
            base.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }

        /// <summary>
        /// Initialize a new FacessoEntities object.
        /// </summary>
        public FacessoEntities(string connectionString) : base(connectionString, "FacessoEntities")
        {
            base.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }

        /// <summary>
        /// Initialize a new FacessoEntities object.
        /// </summary>
        public FacessoEntities(EntityConnection connection) : base(connection, "FacessoEntities")
        {
            base.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }

        partial void OnContextCreated();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<AddressDetail> AddressDetails
        {
            get
            {
                if ((_AddressDetails == null))
                {
                    _AddressDetails = base.CreateObjectSet<AddressDetail>("AddressDetails");
                }

                return _AddressDetails;
            }
        }

        private ObjectSet<AddressDetail> _AddressDetails;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ApplicationSetting> ApplicationSettings
        {
            get
            {
                if ((_ApplicationSettings == null))
                {
                    _ApplicationSettings = base.CreateObjectSet<ApplicationSetting>("ApplicationSettings");
                }

                return _ApplicationSettings;
            }
        }

        private ObjectSet<ApplicationSetting> _ApplicationSettings;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Article> Articles
        {
            get
            {
                if ((_Articles == null))
                {
                    _Articles = base.CreateObjectSet<Article>("Articles");
                }

                return _Articles;
            }
        }

        private ObjectSet<Article> _Articles;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BonusList> BonusLists
        {
            get
            {
                if ((_BonusLists == null))
                {
                    _BonusLists = base.CreateObjectSet<BonusList>("BonusLists");
                }

                return _BonusLists;
            }
        }

        private ObjectSet<BonusList> _BonusLists;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BonusList1> BonusLists1
        {
            get
            {
                if ((_BonusLists1 == null))
                {
                    _BonusLists1 = base.CreateObjectSet<BonusList1>("BonusLists1");
                }

                return _BonusLists1;
            }
        }

        private ObjectSet<BonusList1> _BonusLists1;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CostCenter> CostCenters
        {
            get
            {
                if ((_CostCenters == null))
                {
                    _CostCenters = base.CreateObjectSet<CostCenter>("CostCenters");
                }

                return _CostCenters;
            }
        }

        private ObjectSet<CostCenter> _CostCenters;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Currency> Currencies
        {
            get
            {
                if ((_Currencies == null))
                {
                    _Currencies = base.CreateObjectSet<Currency>("Currencies");
                }

                return _Currencies;
            }
        }

        private ObjectSet<Currency> _Currencies;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<EmployeeHandicap> EmployeeHandicaps
        {
            get
            {
                if ((_EmployeeHandicaps == null))
                {
                    _EmployeeHandicaps = base.CreateObjectSet<EmployeeHandicap>("EmployeeHandicaps");
                }

                return _EmployeeHandicaps;
            }
        }

        private ObjectSet<EmployeeHandicap> _EmployeeHandicaps;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Employee> Employees
        {
            get
            {
                if ((_Employees == null))
                {
                    _Employees = base.CreateObjectSet<Employee>("Employees");
                }

                return _Employees;
            }
        }

        private ObjectSet<Employee> _Employees;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<FunctionLog> FunctionLogs
        {
            get
            {
                if ((_FunctionLogs == null))
                {
                    _FunctionLogs = base.CreateObjectSet<FunctionLog>("FunctionLogs");
                }

                return _FunctionLogs;
            }
        }

        private ObjectSet<FunctionLog> _FunctionLogs;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<LabourValue> LabourValues
        {
            get
            {
                if ((_LabourValues == null))
                {
                    _LabourValues = base.CreateObjectSet<LabourValue>("LabourValues");
                }

                return _LabourValues;
            }
        }

        private ObjectSet<LabourValue> _LabourValues;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<NotificationRecipient> NotificationRecipients
        {
            get
            {
                if ((_NotificationRecipients == null))
                {
                    _NotificationRecipients = base.CreateObjectSet<NotificationRecipient>("NotificationRecipients");
                }

                return _NotificationRecipients;
            }
        }

        private ObjectSet<NotificationRecipient> _NotificationRecipients;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ParamsEmployee> ParamsEmployees
        {
            get
            {
                if ((_ParamsEmployees == null))
                {
                    _ParamsEmployees = base.CreateObjectSet<ParamsEmployee>("ParamsEmployees");
                }

                return _ParamsEmployees;
            }
        }

        private ObjectSet<ParamsEmployee> _ParamsEmployees;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ParamsProductionDate> ParamsProductionDates
        {
            get
            {
                if ((_ParamsProductionDates == null))
                {
                    _ParamsProductionDates = base.CreateObjectSet<ParamsProductionDate>("ParamsProductionDates");
                }

                return _ParamsProductionDates;
            }
        }

        private ObjectSet<ParamsProductionDate> _ParamsProductionDates;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ParamsWorkGroup> ParamsWorkGroups
        {
            get
            {
                if ((_ParamsWorkGroups == null))
                {
                    _ParamsWorkGroups = base.CreateObjectSet<ParamsWorkGroup>("ParamsWorkGroups");
                }

                return _ParamsWorkGroups;
            }
        }

        private ObjectSet<ParamsWorkGroup> _ParamsWorkGroups;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ProductionData> ProductionDatas
        {
            get
            {
                if ((_ProductionDatas == null))
                {
                    _ProductionDatas = base.CreateObjectSet<ProductionData>("ProductionDatas");
                }

                return _ProductionDatas;
            }
        }

        private ObjectSet<ProductionData> _ProductionDatas;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ProductionDataItem> ProductionDataItems
        {
            get
            {
                if ((_ProductionDataItems == null))
                {
                    _ProductionDataItems = base.CreateObjectSet<ProductionDataItem>("ProductionDataItems");
                }

                return _ProductionDataItems;
            }
        }

        private ObjectSet<ProductionDataItem> _ProductionDataItems;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ProductionDataItemsForInsert> ProductionDataItemsForInserts
        {
            get
            {
                if ((_ProductionDataItemsForInserts == null))
                {
                    _ProductionDataItemsForInserts = base.CreateObjectSet<ProductionDataItemsForInsert>("ProductionDataItemsForInserts");
                }

                return _ProductionDataItemsForInserts;
            }
        }

        private ObjectSet<ProductionDataItemsForInsert> _ProductionDataItemsForInserts;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<SkillNeeded> SkillNeededs
        {
            get
            {
                if ((_SkillNeededs == null))
                {
                    _SkillNeededs = base.CreateObjectSet<SkillNeeded>("SkillNeededs");
                }

                return _SkillNeededs;
            }
        }

        private ObjectSet<SkillNeeded> _SkillNeededs;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<SkillProvided> SkillProvideds
        {
            get
            {
                if ((_SkillProvideds == null))
                {
                    _SkillProvideds = base.CreateObjectSet<SkillProvided>("SkillProvideds");
                }

                return _SkillProvideds;
            }
        }

        private ObjectSet<SkillProvided> _SkillProvideds;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Skill> Skills
        {
            get
            {
                if ((_Skills == null))
                {
                    _Skills = base.CreateObjectSet<Skill>("Skills");
                }

                return _Skills;
            }
        }

        private ObjectSet<Skill> _Skills;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Subsidiary> Subsidiaries
        {
            get
            {
                if ((_Subsidiaries == null))
                {
                    _Subsidiaries = base.CreateObjectSet<Subsidiary>("Subsidiaries");
                }

                return _Subsidiaries;
            }
        }

        private ObjectSet<Subsidiary> _Subsidiaries;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TimeLog> TimeLogs
        {
            get
            {
                if ((_TimeLogs == null))
                {
                    _TimeLogs = base.CreateObjectSet<TimeLog>("TimeLogs");
                }

                return _TimeLogs;
            }
        }

        private ObjectSet<TimeLog> _TimeLogs;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TimeLogForInsert> TimeLogForInserts
        {
            get
            {
                if ((_TimeLogForInserts == null))
                {
                    _TimeLogForInserts = base.CreateObjectSet<TimeLogForInsert>("TimeLogForInserts");
                }

                return _TimeLogForInserts;
            }
        }

        private ObjectSet<TimeLogForInsert> _TimeLogForInserts;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }

                return _Users;
            }
        }

        private ObjectSet<User> _Users;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<WageGroup> WageGroups
        {
            get
            {
                if ((_WageGroups == null))
                {
                    _WageGroups = base.CreateObjectSet<WageGroup>("WageGroups");
                }

                return _WageGroups;
            }
        }

        private ObjectSet<WageGroup> _WageGroups;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<WorkGroupAssignment> WorkGroupAssignments
        {
            get
            {
                if ((_WorkGroupAssignments == null))
                {
                    _WorkGroupAssignments = base.CreateObjectSet<WorkGroupAssignment>("WorkGroupAssignments");
                }

                return _WorkGroupAssignments;
            }
        }

        private ObjectSet<WorkGroupAssignment> _WorkGroupAssignments;
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<WorkGroup> WorkGroups
        {
            get
            {
                if ((_WorkGroups == null))
                {
                    _WorkGroups = base.CreateObjectSet<WorkGroup>("WorkGroups");
                }

                return _WorkGroups;
            }
        }

        private ObjectSet<WorkGroup> _WorkGroups;
        /// <summary>
        /// Deprecated Method for adding a new object to the AddressDetails EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToAddressDetails(AddressDetail addressDetail)
        {
            base.AddObject("AddressDetails", addressDetail);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the ApplicationSettings EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToApplicationSettings(ApplicationSetting applicationSetting)
        {
            base.AddObject("ApplicationSettings", applicationSetting);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the Articles EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToArticles(Article article)
        {
            base.AddObject("Articles", article);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the BonusLists EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToBonusLists(BonusList bonusList)
        {
            base.AddObject("BonusLists", bonusList);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the BonusLists1 EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToBonusLists1(BonusList1 bonusList1)
        {
            base.AddObject("BonusLists1", bonusList1);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the CostCenters EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToCostCenters(CostCenter costCenter)
        {
            base.AddObject("CostCenters", costCenter);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the Currencies EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToCurrencies(Currency currency)
        {
            base.AddObject("Currencies", currency);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the EmployeeHandicaps EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToEmployeeHandicaps(EmployeeHandicap employeeHandicap)
        {
            base.AddObject("EmployeeHandicaps", employeeHandicap);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the Employees EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToEmployees(Employee employee)
        {
            base.AddObject("Employees", employee);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the FunctionLogs EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToFunctionLogs(FunctionLog functionLog)
        {
            base.AddObject("FunctionLogs", functionLog);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the LabourValues EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToLabourValues(LabourValue labourValue)
        {
            base.AddObject("LabourValues", labourValue);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the NotificationRecipients EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToNotificationRecipients(NotificationRecipient notificationRecipient)
        {
            base.AddObject("NotificationRecipients", notificationRecipient);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the ParamsEmployees EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToParamsEmployees(ParamsEmployee paramsEmployee)
        {
            base.AddObject("ParamsEmployees", paramsEmployee);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the ParamsProductionDates EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToParamsProductionDates(ParamsProductionDate paramsProductionDate)
        {
            base.AddObject("ParamsProductionDates", paramsProductionDate);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the ParamsWorkGroups EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToParamsWorkGroups(ParamsWorkGroup paramsWorkGroup)
        {
            base.AddObject("ParamsWorkGroups", paramsWorkGroup);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the ProductionDatas EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToProductionDatas(ProductionData productionData)
        {
            base.AddObject("ProductionDatas", productionData);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the ProductionDataItems EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToProductionDataItems(ProductionDataItem productionDataItem)
        {
            base.AddObject("ProductionDataItems", productionDataItem);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the ProductionDataItemsForInserts EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToProductionDataItemsForInserts(ProductionDataItemsForInsert productionDataItemsForInsert)
        {
            base.AddObject("ProductionDataItemsForInserts", productionDataItemsForInsert);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the SkillNeededs EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToSkillNeededs(SkillNeeded skillNeeded)
        {
            base.AddObject("SkillNeededs", skillNeeded);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the SkillProvideds EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToSkillProvideds(SkillProvided skillProvided)
        {
            base.AddObject("SkillProvideds", skillProvided);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the Skills EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToSkills(Skill skill)
        {
            base.AddObject("Skills", skill);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the Subsidiaries EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToSubsidiaries(Subsidiary subsidiary)
        {
            base.AddObject("Subsidiaries", subsidiary);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the TimeLogs EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToTimeLogs(TimeLog timeLog)
        {
            base.AddObject("TimeLogs", timeLog);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the TimeLogForInserts EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToTimeLogForInserts(TimeLogForInsert timeLogForInsert)
        {
            base.AddObject("TimeLogForInserts", timeLogForInsert);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the WageGroups EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToWageGroups(WageGroup wageGroup)
        {
            base.AddObject("WageGroups", wageGroup);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the WorkGroupAssignments EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToWorkGroupAssignments(WorkGroupAssignment workGroupAssignment)
        {
            base.AddObject("WorkGroupAssignments", workGroupAssignment);
        }

        /// <summary>
        /// Deprecated Method for adding a new object to the WorkGroups EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        /// </summary>
        public void AddToWorkGroups(WorkGroup workGroup)
        {
            base.AddObject("WorkGroups", workGroup);
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "AddressDetail")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AddressDetail : EntityObject
    {
        /// <summary>
        /// Create a new AddressDetail object.
        /// </summary>
        /// <param name = "iDAddressDetail">Initial value of the IDAddressDetail property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "lastName">Initial value of the LastName property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static AddressDetail CreateAddressDetail(System.Int32 iDAddressDetail, System.Int32 iDSubsidiary, System.String lastName, System.DateTime lastEdited)
        {
            AddressDetail addressDetail = new AddressDetail();
            addressDetail.IDAddressDetail = iDAddressDetail;
            addressDetail.IDSubsidiary = iDSubsidiary;
            addressDetail.LastName = lastName;
            addressDetail.LastEdited = lastEdited;
            return addressDetail;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDAddressDetail
        {
            get
            {
                return _IDAddressDetail;
            }

            set
            {
                if ((_IDAddressDetail != value))
                {
                    OnIDAddressDetailChanging(value);
                    ReportPropertyChanging("IDAddressDetail");
                    _IDAddressDetail = StructuralObject.SetValidValue(value, "IDAddressDetail");
                    ReportPropertyChanged("IDAddressDetail");
                    OnIDAddressDetailChanged();
                }
            }
        }

        private System.Int32 _IDAddressDetail;
        partial void OnIDAddressDetailChanging(System.Int32 value);
        partial void OnIDAddressDetailChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.Int32> PersonnelNo
        {
            get
            {
                return _PersonnelNo;
            }

            set
            {
                OnPersonnelNoChanging(value);
                ReportPropertyChanging("PersonnelNo");
                _PersonnelNo = StructuralObject.SetValidValue(value, "PersonnelNo");
                ReportPropertyChanged("PersonnelNo");
                OnPersonnelNoChanged();
            }
        }

        private Nullable<System.Int32> _PersonnelNo;
        partial void OnPersonnelNoChanging(Nullable<System.Int32> value);
        partial void OnPersonnelNoChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String LastName
        {
            get
            {
                return _LastName;
            }

            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false, "LastName");
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }

        private System.String _LastName;
        partial void OnLastNameChanging(System.String value);
        partial void OnLastNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String MiddleName
        {
            get
            {
                return _MiddleName;
            }

            set
            {
                OnMiddleNameChanging(value);
                ReportPropertyChanging("MiddleName");
                _MiddleName = StructuralObject.SetValidValue(value, true, "MiddleName");
                ReportPropertyChanged("MiddleName");
                OnMiddleNameChanged();
            }
        }

        private System.String _MiddleName;
        partial void OnMiddleNameChanging(System.String value);
        partial void OnMiddleNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, true, "FirstName");
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }

        private System.String _FirstName;
        partial void OnFirstNameChanging(System.String value);
        partial void OnFirstNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Title
        {
            get
            {
                return _Title;
            }

            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, true, "Title");
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }

        private System.String _Title;
        partial void OnTitleChanging(System.String value);
        partial void OnTitleChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Street
        {
            get
            {
                return _Street;
            }

            set
            {
                OnStreetChanging(value);
                ReportPropertyChanging("Street");
                _Street = StructuralObject.SetValidValue(value, true, "Street");
                ReportPropertyChanged("Street");
                OnStreetChanged();
            }
        }

        private System.String _Street;
        partial void OnStreetChanging(System.String value);
        partial void OnStreetChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Zip
        {
            get
            {
                return _Zip;
            }

            set
            {
                OnZipChanging(value);
                ReportPropertyChanging("Zip");
                _Zip = StructuralObject.SetValidValue(value, true, "Zip");
                ReportPropertyChanged("Zip");
                OnZipChanged();
            }
        }

        private System.String _Zip;
        partial void OnZipChanging(System.String value);
        partial void OnZipChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String City
        {
            get
            {
                return _City;
            }

            set
            {
                OnCityChanging(value);
                ReportPropertyChanging("City");
                _City = StructuralObject.SetValidValue(value, true, "City");
                ReportPropertyChanged("City");
                OnCityChanged();
            }
        }

        private System.String _City;
        partial void OnCityChanging(System.String value);
        partial void OnCityChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String CountryCode
        {
            get
            {
                return _CountryCode;
            }

            set
            {
                OnCountryCodeChanging(value);
                ReportPropertyChanging("CountryCode");
                _CountryCode = StructuralObject.SetValidValue(value, true, "CountryCode");
                ReportPropertyChanged("CountryCode");
                OnCountryCodeChanged();
            }
        }

        private System.String _CountryCode;
        partial void OnCountryCodeChanging(System.String value);
        partial void OnCountryCodeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Country
        {
            get
            {
                return _Country;
            }

            set
            {
                OnCountryChanging(value);
                ReportPropertyChanging("Country");
                _Country = StructuralObject.SetValidValue(value, true, "Country");
                ReportPropertyChanged("Country");
                OnCountryChanged();
            }
        }

        private System.String _Country;
        partial void OnCountryChanging(System.String value);
        partial void OnCountryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String CompanyPhone
        {
            get
            {
                return _CompanyPhone;
            }

            set
            {
                OnCompanyPhoneChanging(value);
                ReportPropertyChanging("CompanyPhone");
                _CompanyPhone = StructuralObject.SetValidValue(value, true, "CompanyPhone");
                ReportPropertyChanged("CompanyPhone");
                OnCompanyPhoneChanged();
            }
        }

        private System.String _CompanyPhone;
        partial void OnCompanyPhoneChanging(System.String value);
        partial void OnCompanyPhoneChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String PrivatePhone
        {
            get
            {
                return _PrivatePhone;
            }

            set
            {
                OnPrivatePhoneChanging(value);
                ReportPropertyChanging("PrivatePhone");
                _PrivatePhone = StructuralObject.SetValidValue(value, true, "PrivatePhone");
                ReportPropertyChanged("PrivatePhone");
                OnPrivatePhoneChanged();
            }
        }

        private System.String _PrivatePhone;
        partial void OnPrivatePhoneChanging(System.String value);
        partial void OnPrivatePhoneChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String CompanyEmail
        {
            get
            {
                return _CompanyEmail;
            }

            set
            {
                OnCompanyEmailChanging(value);
                ReportPropertyChanging("CompanyEmail");
                _CompanyEmail = StructuralObject.SetValidValue(value, true, "CompanyEmail");
                ReportPropertyChanged("CompanyEmail");
                OnCompanyEmailChanged();
            }
        }

        private System.String _CompanyEmail;
        partial void OnCompanyEmailChanging(System.String value);
        partial void OnCompanyEmailChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String PrivateEmail
        {
            get
            {
                return _PrivateEmail;
            }

            set
            {
                OnPrivateEmailChanging(value);
                ReportPropertyChanging("PrivateEmail");
                _PrivateEmail = StructuralObject.SetValidValue(value, true, "PrivateEmail");
                ReportPropertyChanged("PrivateEmail");
                OnPrivateEmailChanged();
            }
        }

        private System.String _PrivateEmail;
        partial void OnPrivateEmailChanging(System.String value);
        partial void OnPrivateEmailChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String CompanyMobile
        {
            get
            {
                return _CompanyMobile;
            }

            set
            {
                OnCompanyMobileChanging(value);
                ReportPropertyChanging("CompanyMobile");
                _CompanyMobile = StructuralObject.SetValidValue(value, true, "CompanyMobile");
                ReportPropertyChanged("CompanyMobile");
                OnCompanyMobileChanged();
            }
        }

        private System.String _CompanyMobile;
        partial void OnCompanyMobileChanging(System.String value);
        partial void OnCompanyMobileChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String PrivateMobile
        {
            get
            {
                return _PrivateMobile;
            }

            set
            {
                OnPrivateMobileChanging(value);
                ReportPropertyChanging("PrivateMobile");
                _PrivateMobile = StructuralObject.SetValidValue(value, true, "PrivateMobile");
                ReportPropertyChanged("PrivateMobile");
                OnPrivateMobileChanged();
            }
        }

        private System.String _PrivateMobile;
        partial void OnPrivateMobileChanging(System.String value);
        partial void OnPrivateMobileChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String URL
        {
            get
            {
                return _URL;
            }

            set
            {
                OnURLChanging(value);
                ReportPropertyChanging("URL");
                _URL = StructuralObject.SetValidValue(value, true, "URL");
                ReportPropertyChanged("URL");
                OnURLChanged();
            }
        }

        private System.String _URL;
        partial void OnURLChanging(System.String value);
        partial void OnURLChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_AddressDetails_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_AddressDetails_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_AddressDetails_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_AddressDetails_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_AddressDetails_Subsidiaries", "Subsidiaries", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Employees_AddressDetails", "Employees")]
        public EntityCollection<Employee> Employees
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("FacessoModel.FK_Employees_AddressDetails", "Employees");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("FacessoModel.FK_Employees_AddressDetails", "Employees", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Users_AddressDetails", "Users")]
        public EntityCollection<User> Users
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<User>("FacessoModel.FK_Users_AddressDetails", "Users");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<User>("FacessoModel.FK_Users_AddressDetails", "Users", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "ApplicationSetting")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class ApplicationSetting : EntityObject
    {
        /// <summary>
        /// Create a new ApplicationSetting object.
        /// </summary>
        /// <param name = "iDApplicationSettings">Initial value of the IDApplicationSettings property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "isGlobal">Initial value of the IsGlobal property.</param>
        /// <param name = "iDUser">Initial value of the IDUser property.</param>
        /// <param name = "settings">Initial value of the Settings property.</param>
        public static ApplicationSetting CreateApplicationSetting(System.Int32 iDApplicationSettings, System.Int32 iDSubsidiary, System.Boolean isGlobal, System.Int32 iDUser, System.String settings)
        {
            ApplicationSetting applicationSetting = new ApplicationSetting();
            applicationSetting.IDApplicationSettings = iDApplicationSettings;
            applicationSetting.IDSubsidiary = iDSubsidiary;
            applicationSetting.IsGlobal = isGlobal;
            applicationSetting.IDUser = iDUser;
            applicationSetting.Settings = settings;
            return applicationSetting;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDApplicationSettings
        {
            get
            {
                return _IDApplicationSettings;
            }

            set
            {
                if ((_IDApplicationSettings != value))
                {
                    OnIDApplicationSettingsChanging(value);
                    ReportPropertyChanging("IDApplicationSettings");
                    _IDApplicationSettings = StructuralObject.SetValidValue(value, "IDApplicationSettings");
                    ReportPropertyChanged("IDApplicationSettings");
                    OnIDApplicationSettingsChanged();
                }
            }
        }

        private System.Int32 _IDApplicationSettings;
        partial void OnIDApplicationSettingsChanging(System.Int32 value);
        partial void OnIDApplicationSettingsChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsGlobal
        {
            get
            {
                return _IsGlobal;
            }

            set
            {
                OnIsGlobalChanging(value);
                ReportPropertyChanging("IsGlobal");
                _IsGlobal = StructuralObject.SetValidValue(value, "IsGlobal");
                ReportPropertyChanged("IsGlobal");
                OnIsGlobalChanged();
            }
        }

        private System.Boolean _IsGlobal;
        partial void OnIsGlobalChanging(System.Boolean value);
        partial void OnIsGlobalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDUser
        {
            get
            {
                return _IDUser;
            }

            set
            {
                OnIDUserChanging(value);
                ReportPropertyChanging("IDUser");
                _IDUser = StructuralObject.SetValidValue(value, "IDUser");
                ReportPropertyChanged("IDUser");
                OnIDUserChanged();
            }
        }

        private System.Int32 _IDUser;
        partial void OnIDUserChanging(System.Int32 value);
        partial void OnIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String Settings
        {
            get
            {
                return _Settings;
            }

            set
            {
                OnSettingsChanging(value);
                ReportPropertyChanging("Settings");
                _Settings = StructuralObject.SetValidValue(value, false, "Settings");
                ReportPropertyChanged("Settings");
                OnSettingsChanged();
            }
        }

        private System.String _Settings;
        partial void OnSettingsChanging(System.String value);
        partial void OnSettingsChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ApplicationSettings_Users", "Users")]
        public User User
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("FacessoModel.FK_ApplicationSettings_Users", "Users").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("FacessoModel.FK_ApplicationSettings_Users", "Users").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UserReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("FacessoModel.FK_ApplicationSettings_Users", "Users");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("FacessoModel.FK_ApplicationSettings_Users", "Users", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "Article")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class Article : EntityObject
    {
        /// <summary>
        /// Create a new Article object.
        /// </summary>
        /// <param name = "iDArticle">Initial value of the IDArticle property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDMachine">Initial value of the IDMachine property.</param>
        /// <param name = "iDCostCenter">Initial value of the IDCostCenter property.</param>
        /// <param name = "iDLabourValue">Initial value of the IDLabourValue property.</param>
        /// <param name = "itemNumber">Initial value of the ItemNumber property.</param>
        /// <param name = "itemName">Initial value of the ItemName property.</param>
        /// <param name = "itemDescription">Initial value of the ItemDescription property.</param>
        /// <param name = "isActive">Initial value of the IsActive property.</param>
        /// <param name = "isCurrent">Initial value of the IsCurrent property.</param>
        /// <param name = "wasCurrentFrom">Initial value of the WasCurrentFrom property.</param>
        /// <param name = "wasCurrentTo">Initial value of the WasCurrentTo property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static Article CreateArticle(System.Int32 iDArticle, System.Int32 iDSubsidiary, System.Int32 iDMachine, System.Int32 iDCostCenter, System.Int32 iDLabourValue, System.String itemNumber, System.String itemName, System.String itemDescription, System.Boolean isActive, System.Boolean isCurrent, System.DateTime wasCurrentFrom, System.DateTime wasCurrentTo, System.DateTime lastEdited)
        {
            Article article = new Article();
            article.IDArticle = iDArticle;
            article.IDSubsidiary = iDSubsidiary;
            article.IDMachine = iDMachine;
            article.IDCostCenter = iDCostCenter;
            article.IDLabourValue = iDLabourValue;
            article.ItemNumber = itemNumber;
            article.ItemName = itemName;
            article.ItemDescription = itemDescription;
            article.IsActive = isActive;
            article.IsCurrent = isCurrent;
            article.WasCurrentFrom = wasCurrentFrom;
            article.WasCurrentTo = wasCurrentTo;
            article.LastEdited = lastEdited;
            return article;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDArticle
        {
            get
            {
                return _IDArticle;
            }

            set
            {
                if ((_IDArticle != value))
                {
                    OnIDArticleChanging(value);
                    ReportPropertyChanging("IDArticle");
                    _IDArticle = StructuralObject.SetValidValue(value, "IDArticle");
                    ReportPropertyChanged("IDArticle");
                    OnIDArticleChanged();
                }
            }
        }

        private System.Int32 _IDArticle;
        partial void OnIDArticleChanging(System.Int32 value);
        partial void OnIDArticleChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDMachine
        {
            get
            {
                return _IDMachine;
            }

            set
            {
                OnIDMachineChanging(value);
                ReportPropertyChanging("IDMachine");
                _IDMachine = StructuralObject.SetValidValue(value, "IDMachine");
                ReportPropertyChanged("IDMachine");
                OnIDMachineChanged();
            }
        }

        private System.Int32 _IDMachine;
        partial void OnIDMachineChanging(System.Int32 value);
        partial void OnIDMachineChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCostCenter
        {
            get
            {
                return _IDCostCenter;
            }

            set
            {
                OnIDCostCenterChanging(value);
                ReportPropertyChanging("IDCostCenter");
                _IDCostCenter = StructuralObject.SetValidValue(value, "IDCostCenter");
                ReportPropertyChanged("IDCostCenter");
                OnIDCostCenterChanged();
            }
        }

        private System.Int32 _IDCostCenter;
        partial void OnIDCostCenterChanging(System.Int32 value);
        partial void OnIDCostCenterChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDLabourValue
        {
            get
            {
                return _IDLabourValue;
            }

            set
            {
                OnIDLabourValueChanging(value);
                ReportPropertyChanging("IDLabourValue");
                _IDLabourValue = StructuralObject.SetValidValue(value, "IDLabourValue");
                ReportPropertyChanged("IDLabourValue");
                OnIDLabourValueChanged();
            }
        }

        private System.Int32 _IDLabourValue;
        partial void OnIDLabourValueChanging(System.Int32 value);
        partial void OnIDLabourValueChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String ItemNumber
        {
            get
            {
                return _ItemNumber;
            }

            set
            {
                OnItemNumberChanging(value);
                ReportPropertyChanging("ItemNumber");
                _ItemNumber = StructuralObject.SetValidValue(value, false, "ItemNumber");
                ReportPropertyChanged("ItemNumber");
                OnItemNumberChanged();
            }
        }

        private System.String _ItemNumber;
        partial void OnItemNumberChanging(System.String value);
        partial void OnItemNumberChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String ItemName
        {
            get
            {
                return _ItemName;
            }

            set
            {
                OnItemNameChanging(value);
                ReportPropertyChanging("ItemName");
                _ItemName = StructuralObject.SetValidValue(value, false, "ItemName");
                ReportPropertyChanged("ItemName");
                OnItemNameChanged();
            }
        }

        private System.String _ItemName;
        partial void OnItemNameChanging(System.String value);
        partial void OnItemNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String ItemDescription
        {
            get
            {
                return _ItemDescription;
            }

            set
            {
                OnItemDescriptionChanging(value);
                ReportPropertyChanging("ItemDescription");
                _ItemDescription = StructuralObject.SetValidValue(value, false, "ItemDescription");
                ReportPropertyChanged("ItemDescription");
                OnItemDescriptionChanged();
            }
        }

        private System.String _ItemDescription;
        partial void OnItemDescriptionChanging(System.String value);
        partial void OnItemDescriptionChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsActive
        {
            get
            {
                return _IsActive;
            }

            set
            {
                OnIsActiveChanging(value);
                ReportPropertyChanging("IsActive");
                _IsActive = StructuralObject.SetValidValue(value, "IsActive");
                ReportPropertyChanged("IsActive");
                OnIsActiveChanged();
            }
        }

        private System.Boolean _IsActive;
        partial void OnIsActiveChanging(System.Boolean value);
        partial void OnIsActiveChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsCurrent
        {
            get
            {
                return _IsCurrent;
            }

            set
            {
                OnIsCurrentChanging(value);
                ReportPropertyChanging("IsCurrent");
                _IsCurrent = StructuralObject.SetValidValue(value, "IsCurrent");
                ReportPropertyChanged("IsCurrent");
                OnIsCurrentChanged();
            }
        }

        private System.Boolean _IsCurrent;
        partial void OnIsCurrentChanging(System.Boolean value);
        partial void OnIsCurrentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentFrom
        {
            get
            {
                return _WasCurrentFrom;
            }

            set
            {
                OnWasCurrentFromChanging(value);
                ReportPropertyChanging("WasCurrentFrom");
                _WasCurrentFrom = StructuralObject.SetValidValue(value, "WasCurrentFrom");
                ReportPropertyChanged("WasCurrentFrom");
                OnWasCurrentFromChanged();
            }
        }

        private System.DateTime _WasCurrentFrom;
        partial void OnWasCurrentFromChanging(System.DateTime value);
        partial void OnWasCurrentFromChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentTo
        {
            get
            {
                return _WasCurrentTo;
            }

            set
            {
                OnWasCurrentToChanging(value);
                ReportPropertyChanging("WasCurrentTo");
                _WasCurrentTo = StructuralObject.SetValidValue(value, "WasCurrentTo");
                ReportPropertyChanged("WasCurrentTo");
                OnWasCurrentToChanged();
            }
        }

        private System.DateTime _WasCurrentTo;
        partial void OnWasCurrentToChanging(System.DateTime value);
        partial void OnWasCurrentToChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Articles_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Articles_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Articles_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Articles_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_Articles_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "BonusList")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class BonusList : EntityObject
    {
        /// <summary>
        /// Create a new BonusList object.
        /// </summary>
        /// <param name = "iDBonusList">Initial value of the IDBonusList property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDBonusLists">Initial value of the IDBonusLists property.</param>
        /// <param name = "degreeOfTime">Initial value of the DegreeOfTime property.</param>
        /// <param name = "percentage">Initial value of the Percentage property.</param>
        /// <param name = "absoluteValue">Initial value of the AbsoluteValue property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static BonusList CreateBonusList(System.Int32 iDBonusList, System.Int32 iDSubsidiary, System.Int32 iDBonusLists, System.Decimal degreeOfTime, System.Decimal percentage, System.Decimal absoluteValue, System.DateTime lastEdited)
        {
            BonusList bonusList = new BonusList();
            bonusList.IDBonusList = iDBonusList;
            bonusList.IDSubsidiary = iDSubsidiary;
            bonusList.IDBonusLists = iDBonusLists;
            bonusList.DegreeOfTime = degreeOfTime;
            bonusList.Percentage = percentage;
            bonusList.AbsoluteValue = absoluteValue;
            bonusList.LastEdited = lastEdited;
            return bonusList;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDBonusList
        {
            get
            {
                return _IDBonusList;
            }

            set
            {
                if ((_IDBonusList != value))
                {
                    OnIDBonusListChanging(value);
                    ReportPropertyChanging("IDBonusList");
                    _IDBonusList = StructuralObject.SetValidValue(value, "IDBonusList");
                    ReportPropertyChanged("IDBonusList");
                    OnIDBonusListChanged();
                }
            }
        }

        private System.Int32 _IDBonusList;
        partial void OnIDBonusListChanging(System.Int32 value);
        partial void OnIDBonusListChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDBonusLists
        {
            get
            {
                return _IDBonusLists;
            }

            set
            {
                OnIDBonusListsChanging(value);
                ReportPropertyChanging("IDBonusLists");
                _IDBonusLists = StructuralObject.SetValidValue(value, "IDBonusLists");
                ReportPropertyChanged("IDBonusLists");
                OnIDBonusListsChanged();
            }
        }

        private System.Int32 _IDBonusLists;
        partial void OnIDBonusListsChanging(System.Int32 value);
        partial void OnIDBonusListsChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Decimal DegreeOfTime
        {
            get
            {
                return _DegreeOfTime;
            }

            set
            {
                OnDegreeOfTimeChanging(value);
                ReportPropertyChanging("DegreeOfTime");
                _DegreeOfTime = StructuralObject.SetValidValue(value, "DegreeOfTime");
                ReportPropertyChanged("DegreeOfTime");
                OnDegreeOfTimeChanged();
            }
        }

        private System.Decimal _DegreeOfTime;
        partial void OnDegreeOfTimeChanging(System.Decimal value);
        partial void OnDegreeOfTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Decimal Percentage
        {
            get
            {
                return _Percentage;
            }

            set
            {
                OnPercentageChanging(value);
                ReportPropertyChanging("Percentage");
                _Percentage = StructuralObject.SetValidValue(value, "Percentage");
                ReportPropertyChanged("Percentage");
                OnPercentageChanged();
            }
        }

        private System.Decimal _Percentage;
        partial void OnPercentageChanging(System.Decimal value);
        partial void OnPercentageChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Decimal AbsoluteValue
        {
            get
            {
                return _AbsoluteValue;
            }

            set
            {
                OnAbsoluteValueChanging(value);
                ReportPropertyChanging("AbsoluteValue");
                _AbsoluteValue = StructuralObject.SetValidValue(value, "AbsoluteValue");
                ReportPropertyChanged("AbsoluteValue");
                OnAbsoluteValueChanged();
            }
        }

        private System.Decimal _AbsoluteValue;
        partial void OnAbsoluteValueChanging(System.Decimal value);
        partial void OnAbsoluteValueChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_BonusList_BonusLists", "BonusLists")]
        public BonusList1 BonusList1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<BonusList1>("FacessoModel.FK_BonusList_BonusLists", "BonusLists").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<BonusList1>("FacessoModel.FK_BonusList_BonusLists", "BonusLists").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<BonusList1> BonusList1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<BonusList1>("FacessoModel.FK_BonusList_BonusLists", "BonusLists");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<BonusList1>("FacessoModel.FK_BonusList_BonusLists", "BonusLists", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "BonusList1")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class BonusList1 : EntityObject
    {
        /// <summary>
        /// Create a new BonusList1 object.
        /// </summary>
        /// <param name = "iDBonusLists">Initial value of the IDBonusLists property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDCostCenter">Initial value of the IDCostCenter property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static BonusList1 CreateBonusList1(System.Int32 iDBonusLists, System.Int32 iDSubsidiary, System.Int32 iDCostCenter, System.DateTime lastEdited)
        {
            BonusList1 bonusList1 = new BonusList1();
            bonusList1.IDBonusLists = iDBonusLists;
            bonusList1.IDSubsidiary = iDSubsidiary;
            bonusList1.IDCostCenter = iDCostCenter;
            bonusList1.LastEdited = lastEdited;
            return bonusList1;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDBonusLists
        {
            get
            {
                return _IDBonusLists;
            }

            set
            {
                if ((_IDBonusLists != value))
                {
                    OnIDBonusListsChanging(value);
                    ReportPropertyChanging("IDBonusLists");
                    _IDBonusLists = StructuralObject.SetValidValue(value, "IDBonusLists");
                    ReportPropertyChanged("IDBonusLists");
                    OnIDBonusListsChanged();
                }
            }
        }

        private System.Int32 _IDBonusLists;
        partial void OnIDBonusListsChanging(System.Int32 value);
        partial void OnIDBonusListsChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCostCenter
        {
            get
            {
                return _IDCostCenter;
            }

            set
            {
                OnIDCostCenterChanging(value);
                ReportPropertyChanging("IDCostCenter");
                _IDCostCenter = StructuralObject.SetValidValue(value, "IDCostCenter");
                ReportPropertyChanged("IDCostCenter");
                OnIDCostCenterChanged();
            }
        }

        private System.Int32 _IDCostCenter;
        partial void OnIDCostCenterChanging(System.Int32 value);
        partial void OnIDCostCenterChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> WasCurrentFrom
        {
            get
            {
                return _WasCurrentFrom;
            }

            set
            {
                OnWasCurrentFromChanging(value);
                ReportPropertyChanging("WasCurrentFrom");
                _WasCurrentFrom = StructuralObject.SetValidValue(value, "WasCurrentFrom");
                ReportPropertyChanged("WasCurrentFrom");
                OnWasCurrentFromChanged();
            }
        }

        private Nullable<System.DateTime> _WasCurrentFrom;
        partial void OnWasCurrentFromChanging(Nullable<System.DateTime> value);
        partial void OnWasCurrentFromChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> WasCurrentTo
        {
            get
            {
                return _WasCurrentTo;
            }

            set
            {
                OnWasCurrentToChanging(value);
                ReportPropertyChanging("WasCurrentTo");
                _WasCurrentTo = StructuralObject.SetValidValue(value, "WasCurrentTo");
                ReportPropertyChanged("WasCurrentTo");
                OnWasCurrentToChanged();
            }
        }

        private Nullable<System.DateTime> _WasCurrentTo;
        partial void OnWasCurrentToChanging(Nullable<System.DateTime> value);
        partial void OnWasCurrentToChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.Boolean> IsCurrent
        {
            get
            {
                return _IsCurrent;
            }

            set
            {
                OnIsCurrentChanging(value);
                ReportPropertyChanging("IsCurrent");
                _IsCurrent = StructuralObject.SetValidValue(value, "IsCurrent");
                ReportPropertyChanged("IsCurrent");
                OnIsCurrentChanged();
            }
        }

        private Nullable<System.Boolean> _IsCurrent;
        partial void OnIsCurrentChanging(Nullable<System.Boolean> value);
        partial void OnIsCurrentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_BonusList_BonusLists", "BonusList")]
        public EntityCollection<BonusList> BonusLists
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<BonusList>("FacessoModel.FK_BonusList_BonusLists", "BonusList");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<BonusList>("FacessoModel.FK_BonusList_BonusLists", "BonusList", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_BonusLists_CostCenter", "CostCenters")]
        public CostCenter CostCenter
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_BonusLists_CostCenter", "CostCenters").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_BonusLists_CostCenter", "CostCenters").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<CostCenter> CostCenterReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_BonusLists_CostCenter", "CostCenters");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<CostCenter>("FacessoModel.FK_BonusLists_CostCenter", "CostCenters", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "CostCenter")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class CostCenter : EntityObject
    {
        /// <summary>
        /// Create a new CostCenter object.
        /// </summary>
        /// <param name = "iDCostCenter">Initial value of the IDCostCenter property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDCostCenterInternal">Initial value of the IDCostCenterInternal property.</param>
        /// <param name = "isCurrent">Initial value of the IsCurrent property.</param>
        /// <param name = "costCenterNo">Initial value of the CostCenterNo property.</param>
        /// <param name = "costCenterName">Initial value of the CostCenterName property.</param>
        /// <param name = "iDCurrency">Initial value of the IDCurrency property.</param>
        /// <param name = "incentiveIndicatorSynonym">Initial value of the IncentiveIndicatorSynonym property.</param>
        /// <param name = "incentiveWageSynonym">Initial value of the IncentiveWageSynonym property.</param>
        /// <param name = "incentiveIndicatorDimension">Initial value of the IncentiveIndicatorDimension property.</param>
        /// <param name = "incentiveIndicatorPrecision">Initial value of the IncentiveIndicatorPrecision property.</param>
        /// <param name = "useFixValuedBonus">Initial value of the UseFixValuedBonus property.</param>
        /// <param name = "incentiveIndicatorFactor">Initial value of the IncentiveIndicatorFactor property.</param>
        /// <param name = "baseValuePrecision">Initial value of the BaseValuePrecision property.</param>
        /// <param name = "baseValueSynonym">Initial value of the BaseValueSynonym property.</param>
        /// <param name = "wasCurrentFrom">Initial value of the WasCurrentFrom property.</param>
        /// <param name = "wasCurrentTo">Initial value of the WasCurrentTo property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static CostCenter CreateCostCenter(System.Int32 iDCostCenter, System.Int32 iDSubsidiary, System.Int32 iDCostCenterInternal, System.Boolean isCurrent, System.Int32 costCenterNo, System.String costCenterName, System.Int32 iDCurrency, System.String incentiveIndicatorSynonym, System.String incentiveWageSynonym, System.String incentiveIndicatorDimension, System.Byte incentiveIndicatorPrecision, System.Boolean useFixValuedBonus, System.Double incentiveIndicatorFactor, System.Byte baseValuePrecision, System.String baseValueSynonym, System.DateTime wasCurrentFrom, System.DateTime wasCurrentTo, System.DateTime lastEdited)
        {
            CostCenter costCenter = new CostCenter();
            costCenter.IDCostCenter = iDCostCenter;
            costCenter.IDSubsidiary = iDSubsidiary;
            costCenter.IDCostCenterInternal = iDCostCenterInternal;
            costCenter.IsCurrent = isCurrent;
            costCenter.CostCenterNo = costCenterNo;
            costCenter.CostCenterName = costCenterName;
            costCenter.IDCurrency = iDCurrency;
            costCenter.IncentiveIndicatorSynonym = incentiveIndicatorSynonym;
            costCenter.IncentiveWageSynonym = incentiveWageSynonym;
            costCenter.IncentiveIndicatorDimension = incentiveIndicatorDimension;
            costCenter.IncentiveIndicatorPrecision = incentiveIndicatorPrecision;
            costCenter.UseFixValuedBonus = useFixValuedBonus;
            costCenter.IncentiveIndicatorFactor = incentiveIndicatorFactor;
            costCenter.BaseValuePrecision = baseValuePrecision;
            costCenter.BaseValueSynonym = baseValueSynonym;
            costCenter.WasCurrentFrom = wasCurrentFrom;
            costCenter.WasCurrentTo = wasCurrentTo;
            costCenter.LastEdited = lastEdited;
            return costCenter;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCostCenter
        {
            get
            {
                return _IDCostCenter;
            }

            set
            {
                if ((_IDCostCenter != value))
                {
                    OnIDCostCenterChanging(value);
                    ReportPropertyChanging("IDCostCenter");
                    _IDCostCenter = StructuralObject.SetValidValue(value, "IDCostCenter");
                    ReportPropertyChanged("IDCostCenter");
                    OnIDCostCenterChanged();
                }
            }
        }

        private System.Int32 _IDCostCenter;
        partial void OnIDCostCenterChanging(System.Int32 value);
        partial void OnIDCostCenterChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCostCenterInternal
        {
            get
            {
                return _IDCostCenterInternal;
            }

            set
            {
                OnIDCostCenterInternalChanging(value);
                ReportPropertyChanging("IDCostCenterInternal");
                _IDCostCenterInternal = StructuralObject.SetValidValue(value, "IDCostCenterInternal");
                ReportPropertyChanged("IDCostCenterInternal");
                OnIDCostCenterInternalChanged();
            }
        }

        private System.Int32 _IDCostCenterInternal;
        partial void OnIDCostCenterInternalChanging(System.Int32 value);
        partial void OnIDCostCenterInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsCurrent
        {
            get
            {
                return _IsCurrent;
            }

            set
            {
                OnIsCurrentChanging(value);
                ReportPropertyChanging("IsCurrent");
                _IsCurrent = StructuralObject.SetValidValue(value, "IsCurrent");
                ReportPropertyChanged("IsCurrent");
                OnIsCurrentChanged();
            }
        }

        private System.Boolean _IsCurrent;
        partial void OnIsCurrentChanging(System.Boolean value);
        partial void OnIsCurrentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 CostCenterNo
        {
            get
            {
                return _CostCenterNo;
            }

            set
            {
                OnCostCenterNoChanging(value);
                ReportPropertyChanging("CostCenterNo");
                _CostCenterNo = StructuralObject.SetValidValue(value, "CostCenterNo");
                ReportPropertyChanged("CostCenterNo");
                OnCostCenterNoChanged();
            }
        }

        private System.Int32 _CostCenterNo;
        partial void OnCostCenterNoChanging(System.Int32 value);
        partial void OnCostCenterNoChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String CostCenterName
        {
            get
            {
                return _CostCenterName;
            }

            set
            {
                OnCostCenterNameChanging(value);
                ReportPropertyChanging("CostCenterName");
                _CostCenterName = StructuralObject.SetValidValue(value, false, "CostCenterName");
                ReportPropertyChanged("CostCenterName");
                OnCostCenterNameChanged();
            }
        }

        private System.String _CostCenterName;
        partial void OnCostCenterNameChanging(System.String value);
        partial void OnCostCenterNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String CostCenterDescription
        {
            get
            {
                return _CostCenterDescription;
            }

            set
            {
                OnCostCenterDescriptionChanging(value);
                ReportPropertyChanging("CostCenterDescription");
                _CostCenterDescription = StructuralObject.SetValidValue(value, true, "CostCenterDescription");
                ReportPropertyChanged("CostCenterDescription");
                OnCostCenterDescriptionChanged();
            }
        }

        private System.String _CostCenterDescription;
        partial void OnCostCenterDescriptionChanging(System.String value);
        partial void OnCostCenterDescriptionChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCurrency
        {
            get
            {
                return _IDCurrency;
            }

            set
            {
                OnIDCurrencyChanging(value);
                ReportPropertyChanging("IDCurrency");
                _IDCurrency = StructuralObject.SetValidValue(value, "IDCurrency");
                ReportPropertyChanged("IDCurrency");
                OnIDCurrencyChanged();
            }
        }

        private System.Int32 _IDCurrency;
        partial void OnIDCurrencyChanging(System.Int32 value);
        partial void OnIDCurrencyChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String IncentiveIndicatorSynonym
        {
            get
            {
                return _IncentiveIndicatorSynonym;
            }

            set
            {
                OnIncentiveIndicatorSynonymChanging(value);
                ReportPropertyChanging("IncentiveIndicatorSynonym");
                _IncentiveIndicatorSynonym = StructuralObject.SetValidValue(value, false, "IncentiveIndicatorSynonym");
                ReportPropertyChanged("IncentiveIndicatorSynonym");
                OnIncentiveIndicatorSynonymChanged();
            }
        }

        private System.String _IncentiveIndicatorSynonym;
        partial void OnIncentiveIndicatorSynonymChanging(System.String value);
        partial void OnIncentiveIndicatorSynonymChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String IncentiveWageSynonym
        {
            get
            {
                return _IncentiveWageSynonym;
            }

            set
            {
                OnIncentiveWageSynonymChanging(value);
                ReportPropertyChanging("IncentiveWageSynonym");
                _IncentiveWageSynonym = StructuralObject.SetValidValue(value, false, "IncentiveWageSynonym");
                ReportPropertyChanged("IncentiveWageSynonym");
                OnIncentiveWageSynonymChanged();
            }
        }

        private System.String _IncentiveWageSynonym;
        partial void OnIncentiveWageSynonymChanging(System.String value);
        partial void OnIncentiveWageSynonymChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String IncentiveIndicatorDimension
        {
            get
            {
                return _IncentiveIndicatorDimension;
            }

            set
            {
                OnIncentiveIndicatorDimensionChanging(value);
                ReportPropertyChanging("IncentiveIndicatorDimension");
                _IncentiveIndicatorDimension = StructuralObject.SetValidValue(value, false, "IncentiveIndicatorDimension");
                ReportPropertyChanged("IncentiveIndicatorDimension");
                OnIncentiveIndicatorDimensionChanged();
            }
        }

        private System.String _IncentiveIndicatorDimension;
        partial void OnIncentiveIndicatorDimensionChanging(System.String value);
        partial void OnIncentiveIndicatorDimensionChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Byte IncentiveIndicatorPrecision
        {
            get
            {
                return _IncentiveIndicatorPrecision;
            }

            set
            {
                OnIncentiveIndicatorPrecisionChanging(value);
                ReportPropertyChanging("IncentiveIndicatorPrecision");
                _IncentiveIndicatorPrecision = StructuralObject.SetValidValue(value, "IncentiveIndicatorPrecision");
                ReportPropertyChanged("IncentiveIndicatorPrecision");
                OnIncentiveIndicatorPrecisionChanged();
            }
        }

        private System.Byte _IncentiveIndicatorPrecision;
        partial void OnIncentiveIndicatorPrecisionChanging(System.Byte value);
        partial void OnIncentiveIndicatorPrecisionChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean UseFixValuedBonus
        {
            get
            {
                return _UseFixValuedBonus;
            }

            set
            {
                OnUseFixValuedBonusChanging(value);
                ReportPropertyChanging("UseFixValuedBonus");
                _UseFixValuedBonus = StructuralObject.SetValidValue(value, "UseFixValuedBonus");
                ReportPropertyChanged("UseFixValuedBonus");
                OnUseFixValuedBonusChanged();
            }
        }

        private System.Boolean _UseFixValuedBonus;
        partial void OnUseFixValuedBonusChanging(System.Boolean value);
        partial void OnUseFixValuedBonusChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double IncentiveIndicatorFactor
        {
            get
            {
                return _IncentiveIndicatorFactor;
            }

            set
            {
                OnIncentiveIndicatorFactorChanging(value);
                ReportPropertyChanging("IncentiveIndicatorFactor");
                _IncentiveIndicatorFactor = StructuralObject.SetValidValue(value, "IncentiveIndicatorFactor");
                ReportPropertyChanged("IncentiveIndicatorFactor");
                OnIncentiveIndicatorFactorChanged();
            }
        }

        private System.Double _IncentiveIndicatorFactor;
        partial void OnIncentiveIndicatorFactorChanging(System.Double value);
        partial void OnIncentiveIndicatorFactorChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Byte BaseValuePrecision
        {
            get
            {
                return _BaseValuePrecision;
            }

            set
            {
                OnBaseValuePrecisionChanging(value);
                ReportPropertyChanging("BaseValuePrecision");
                _BaseValuePrecision = StructuralObject.SetValidValue(value, "BaseValuePrecision");
                ReportPropertyChanged("BaseValuePrecision");
                OnBaseValuePrecisionChanged();
            }
        }

        private System.Byte _BaseValuePrecision;
        partial void OnBaseValuePrecisionChanging(System.Byte value);
        partial void OnBaseValuePrecisionChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String BaseValueSynonym
        {
            get
            {
                return _BaseValueSynonym;
            }

            set
            {
                OnBaseValueSynonymChanging(value);
                ReportPropertyChanging("BaseValueSynonym");
                _BaseValueSynonym = StructuralObject.SetValidValue(value, false, "BaseValueSynonym");
                ReportPropertyChanged("BaseValueSynonym");
                OnBaseValueSynonymChanged();
            }
        }

        private System.String _BaseValueSynonym;
        partial void OnBaseValueSynonymChanging(System.String value);
        partial void OnBaseValueSynonymChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentFrom
        {
            get
            {
                return _WasCurrentFrom;
            }

            set
            {
                OnWasCurrentFromChanging(value);
                ReportPropertyChanging("WasCurrentFrom");
                _WasCurrentFrom = StructuralObject.SetValidValue(value, "WasCurrentFrom");
                ReportPropertyChanged("WasCurrentFrom");
                OnWasCurrentFromChanged();
            }
        }

        private System.DateTime _WasCurrentFrom;
        partial void OnWasCurrentFromChanging(System.DateTime value);
        partial void OnWasCurrentFromChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentTo
        {
            get
            {
                return _WasCurrentTo;
            }

            set
            {
                OnWasCurrentToChanging(value);
                ReportPropertyChanging("WasCurrentTo");
                _WasCurrentTo = StructuralObject.SetValidValue(value, "WasCurrentTo");
                ReportPropertyChanged("WasCurrentTo");
                OnWasCurrentToChanged();
            }
        }

        private System.DateTime _WasCurrentTo;
        partial void OnWasCurrentToChanging(System.DateTime value);
        partial void OnWasCurrentToChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_BonusLists_CostCenter", "BonusLists")]
        public EntityCollection<BonusList1> BonusLists
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<BonusList1>("FacessoModel.FK_BonusLists_CostCenter", "BonusLists");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<BonusList1>("FacessoModel.FK_BonusLists_CostCenter", "BonusLists", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_CostCenters_Currencies", "Currencies")]
        public Currency Currency
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Currency>("FacessoModel.FK_CostCenters_Currencies", "Currencies").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Currency>("FacessoModel.FK_CostCenters_Currencies", "Currencies").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Currency> CurrencyReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Currency>("FacessoModel.FK_CostCenters_Currencies", "Currencies");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Currency>("FacessoModel.FK_CostCenters_Currencies", "Currencies", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Employees_CostCenter", "Employees")]
        public EntityCollection<Employee> Employees
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("FacessoModel.FK_Employees_CostCenter", "Employees");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("FacessoModel.FK_Employees_CostCenter", "Employees", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Users_CostCenters", "Users")]
        public EntityCollection<User> Users
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<User>("FacessoModel.FK_Users_CostCenters", "Users");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<User>("FacessoModel.FK_Users_CostCenters", "Users", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WorkGroups_CostCenter", "WorkGroups")]
        public EntityCollection<WorkGroup> WorkGroups
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<WorkGroup>("FacessoModel.FK_WorkGroups_CostCenter", "WorkGroups");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<WorkGroup>("FacessoModel.FK_WorkGroups_CostCenter", "WorkGroups", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "Currency")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class Currency : EntityObject
    {
        /// <summary>
        /// Create a new Currency object.
        /// </summary>
        /// <param name = "iDCurrency">Initial value of the IDCurrency property.</param>
        /// <param name = "currencyToken">Initial value of the CurrencyToken property.</param>
        /// <param name = "currencyCode">Initial value of the CurrencyCode property.</param>
        /// <param name = "factorToEuroAverage">Initial value of the FactorToEuroAverage property.</param>
        /// <param name = "currencyPlainText">Initial value of the CurrencyPlainText property.</param>
        public static Currency CreateCurrency(System.Int32 iDCurrency, System.String currencyToken, System.String currencyCode, System.Decimal factorToEuroAverage, System.String currencyPlainText)
        {
            Currency currency = new Currency();
            currency.IDCurrency = iDCurrency;
            currency.CurrencyToken = currencyToken;
            currency.CurrencyCode = currencyCode;
            currency.FactorToEuroAverage = factorToEuroAverage;
            currency.CurrencyPlainText = currencyPlainText;
            return currency;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCurrency
        {
            get
            {
                return _IDCurrency;
            }

            set
            {
                if ((_IDCurrency != value))
                {
                    OnIDCurrencyChanging(value);
                    ReportPropertyChanging("IDCurrency");
                    _IDCurrency = StructuralObject.SetValidValue(value, "IDCurrency");
                    ReportPropertyChanged("IDCurrency");
                    OnIDCurrencyChanged();
                }
            }
        }

        private System.Int32 _IDCurrency;
        partial void OnIDCurrencyChanging(System.Int32 value);
        partial void OnIDCurrencyChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String CurrencyToken
        {
            get
            {
                return _CurrencyToken;
            }

            set
            {
                OnCurrencyTokenChanging(value);
                ReportPropertyChanging("CurrencyToken");
                _CurrencyToken = StructuralObject.SetValidValue(value, false, "CurrencyToken");
                ReportPropertyChanged("CurrencyToken");
                OnCurrencyTokenChanged();
            }
        }

        private System.String _CurrencyToken;
        partial void OnCurrencyTokenChanging(System.String value);
        partial void OnCurrencyTokenChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String CurrencyCode
        {
            get
            {
                return _CurrencyCode;
            }

            set
            {
                OnCurrencyCodeChanging(value);
                ReportPropertyChanging("CurrencyCode");
                _CurrencyCode = StructuralObject.SetValidValue(value, false, "CurrencyCode");
                ReportPropertyChanged("CurrencyCode");
                OnCurrencyCodeChanged();
            }
        }

        private System.String _CurrencyCode;
        partial void OnCurrencyCodeChanging(System.String value);
        partial void OnCurrencyCodeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Decimal FactorToEuroAverage
        {
            get
            {
                return _FactorToEuroAverage;
            }

            set
            {
                OnFactorToEuroAverageChanging(value);
                ReportPropertyChanging("FactorToEuroAverage");
                _FactorToEuroAverage = StructuralObject.SetValidValue(value, "FactorToEuroAverage");
                ReportPropertyChanged("FactorToEuroAverage");
                OnFactorToEuroAverageChanged();
            }
        }

        private System.Decimal _FactorToEuroAverage;
        partial void OnFactorToEuroAverageChanging(System.Decimal value);
        partial void OnFactorToEuroAverageChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String CurrencyPlainText
        {
            get
            {
                return _CurrencyPlainText;
            }

            set
            {
                OnCurrencyPlainTextChanging(value);
                ReportPropertyChanging("CurrencyPlainText");
                _CurrencyPlainText = StructuralObject.SetValidValue(value, false, "CurrencyPlainText");
                ReportPropertyChanged("CurrencyPlainText");
                OnCurrencyPlainTextChanged();
            }
        }

        private System.String _CurrencyPlainText;
        partial void OnCurrencyPlainTextChanging(System.String value);
        partial void OnCurrencyPlainTextChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_CostCenters_Currencies", "CostCenters")]
        public EntityCollection<CostCenter> CostCenters
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<CostCenter>("FacessoModel.FK_CostCenters_Currencies", "CostCenters");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<CostCenter>("FacessoModel.FK_CostCenters_Currencies", "CostCenters", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WageGroups_Currencies", "WageGroups")]
        public EntityCollection<WageGroup> WageGroups
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<WageGroup>("FacessoModel.FK_WageGroups_Currencies", "WageGroups");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<WageGroup>("FacessoModel.FK_WageGroups_Currencies", "WageGroups", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "Employee")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class Employee : EntityObject
    {
        /// <summary>
        /// Create a new Employee object.
        /// </summary>
        /// <param name = "iDEmployee">Initial value of the IDEmployee property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDEmployeeInternal">Initial value of the IDEmployeeInternal property.</param>
        /// <param name = "iDCostCenter">Initial value of the IDCostCenter property.</param>
        /// <param name = "useFixedWage">Initial value of the UseFixedWage property.</param>
        /// <param name = "iDAddressDetails">Initial value of the IDAddressDetails property.</param>
        /// <param name = "lastName">Initial value of the LastName property.</param>
        /// <param name = "firstName">Initial value of the FirstName property.</param>
        /// <param name = "personnelNumber">Initial value of the PersonnelNumber property.</param>
        /// <param name = "isCurrent">Initial value of the IsCurrent property.</param>
        /// <param name = "isActive">Initial value of the IsActive property.</param>
        /// <param name = "isIncentive">Initial value of the IsIncentive property.</param>
        /// <param name = "wasCurrentFrom">Initial value of the WasCurrentFrom property.</param>
        /// <param name = "wasCurrentTo">Initial value of the WasCurrentTo property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static Employee CreateEmployee(System.Int32 iDEmployee, System.Int32 iDSubsidiary, System.Int32 iDEmployeeInternal, System.Int32 iDCostCenter, System.Boolean useFixedWage, System.Int32 iDAddressDetails, System.String lastName, System.String firstName, System.Int32 personnelNumber, System.Boolean isCurrent, System.Boolean isActive, System.Boolean isIncentive, System.DateTime wasCurrentFrom, System.DateTime wasCurrentTo, System.DateTime lastEdited)
        {
            Employee employee = new Employee();
            employee.IDEmployee = iDEmployee;
            employee.IDSubsidiary = iDSubsidiary;
            employee.IDEmployeeInternal = iDEmployeeInternal;
            employee.IDCostCenter = iDCostCenter;
            employee.UseFixedWage = useFixedWage;
            employee.IDAddressDetails = iDAddressDetails;
            employee.LastName = lastName;
            employee.FirstName = firstName;
            employee.PersonnelNumber = personnelNumber;
            employee.IsCurrent = isCurrent;
            employee.IsActive = isActive;
            employee.IsIncentive = isIncentive;
            employee.WasCurrentFrom = wasCurrentFrom;
            employee.WasCurrentTo = wasCurrentTo;
            employee.LastEdited = lastEdited;
            return employee;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDEmployee
        {
            get
            {
                return _IDEmployee;
            }

            set
            {
                if ((_IDEmployee != value))
                {
                    OnIDEmployeeChanging(value);
                    ReportPropertyChanging("IDEmployee");
                    _IDEmployee = StructuralObject.SetValidValue(value, "IDEmployee");
                    ReportPropertyChanged("IDEmployee");
                    OnIDEmployeeChanged();
                }
            }
        }

        private System.Int32 _IDEmployee;
        partial void OnIDEmployeeChanging(System.Int32 value);
        partial void OnIDEmployeeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDEmployeeInternal
        {
            get
            {
                return _IDEmployeeInternal;
            }

            set
            {
                OnIDEmployeeInternalChanging(value);
                ReportPropertyChanging("IDEmployeeInternal");
                _IDEmployeeInternal = StructuralObject.SetValidValue(value, "IDEmployeeInternal");
                ReportPropertyChanged("IDEmployeeInternal");
                OnIDEmployeeInternalChanged();
            }
        }

        private System.Int32 _IDEmployeeInternal;
        partial void OnIDEmployeeInternalChanging(System.Int32 value);
        partial void OnIDEmployeeInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCostCenter
        {
            get
            {
                return _IDCostCenter;
            }

            set
            {
                OnIDCostCenterChanging(value);
                ReportPropertyChanging("IDCostCenter");
                _IDCostCenter = StructuralObject.SetValidValue(value, "IDCostCenter");
                ReportPropertyChanged("IDCostCenter");
                OnIDCostCenterChanged();
            }
        }

        private System.Int32 _IDCostCenter;
        partial void OnIDCostCenterChanging(System.Int32 value);
        partial void OnIDCostCenterChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.Int32> IDWageGroup
        {
            get
            {
                return _IDWageGroup;
            }

            set
            {
                OnIDWageGroupChanging(value);
                ReportPropertyChanging("IDWageGroup");
                _IDWageGroup = StructuralObject.SetValidValue(value, "IDWageGroup");
                ReportPropertyChanged("IDWageGroup");
                OnIDWageGroupChanged();
            }
        }

        private Nullable<System.Int32> _IDWageGroup;
        partial void OnIDWageGroupChanging(Nullable<System.Int32> value);
        partial void OnIDWageGroupChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean UseFixedWage
        {
            get
            {
                return _UseFixedWage;
            }

            set
            {
                OnUseFixedWageChanging(value);
                ReportPropertyChanging("UseFixedWage");
                _UseFixedWage = StructuralObject.SetValidValue(value, "UseFixedWage");
                ReportPropertyChanged("UseFixedWage");
                OnUseFixedWageChanged();
            }
        }

        private System.Boolean _UseFixedWage;
        partial void OnUseFixedWageChanging(System.Boolean value);
        partial void OnUseFixedWageChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.Decimal> FixedWage
        {
            get
            {
                return _FixedWage;
            }

            set
            {
                OnFixedWageChanging(value);
                ReportPropertyChanging("FixedWage");
                _FixedWage = StructuralObject.SetValidValue(value, "FixedWage");
                ReportPropertyChanged("FixedWage");
                OnFixedWageChanged();
            }
        }

        private Nullable<System.Decimal> _FixedWage;
        partial void OnFixedWageChanging(Nullable<System.Decimal> value);
        partial void OnFixedWageChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDAddressDetails
        {
            get
            {
                return _IDAddressDetails;
            }

            set
            {
                OnIDAddressDetailsChanging(value);
                ReportPropertyChanging("IDAddressDetails");
                _IDAddressDetails = StructuralObject.SetValidValue(value, "IDAddressDetails");
                ReportPropertyChanged("IDAddressDetails");
                OnIDAddressDetailsChanged();
            }
        }

        private System.Int32 _IDAddressDetails;
        partial void OnIDAddressDetailsChanging(System.Int32 value);
        partial void OnIDAddressDetailsChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String LastName
        {
            get
            {
                return _LastName;
            }

            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false, "LastName");
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }

        private System.String _LastName;
        partial void OnLastNameChanging(System.String value);
        partial void OnLastNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false, "FirstName");
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }

        private System.String _FirstName;
        partial void OnFirstNameChanging(System.String value);
        partial void OnFirstNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Matchcode
        {
            get
            {
                return _Matchcode;
            }

            set
            {
                OnMatchcodeChanging(value);
                ReportPropertyChanging("Matchcode");
                _Matchcode = StructuralObject.SetValidValue(value, true, "Matchcode");
                ReportPropertyChanged("Matchcode");
                OnMatchcodeChanged();
            }
        }

        private System.String _Matchcode;
        partial void OnMatchcodeChanging(System.String value);
        partial void OnMatchcodeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 PersonnelNumber
        {
            get
            {
                return _PersonnelNumber;
            }

            set
            {
                OnPersonnelNumberChanging(value);
                ReportPropertyChanging("PersonnelNumber");
                _PersonnelNumber = StructuralObject.SetValidValue(value, "PersonnelNumber");
                ReportPropertyChanged("PersonnelNumber");
                OnPersonnelNumberChanged();
            }
        }

        private System.Int32 _PersonnelNumber;
        partial void OnPersonnelNumberChanging(System.Int32 value);
        partial void OnPersonnelNumberChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsCurrent
        {
            get
            {
                return _IsCurrent;
            }

            set
            {
                OnIsCurrentChanging(value);
                ReportPropertyChanging("IsCurrent");
                _IsCurrent = StructuralObject.SetValidValue(value, "IsCurrent");
                ReportPropertyChanged("IsCurrent");
                OnIsCurrentChanged();
            }
        }

        private System.Boolean _IsCurrent;
        partial void OnIsCurrentChanging(System.Boolean value);
        partial void OnIsCurrentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsActive
        {
            get
            {
                return _IsActive;
            }

            set
            {
                OnIsActiveChanging(value);
                ReportPropertyChanging("IsActive");
                _IsActive = StructuralObject.SetValidValue(value, "IsActive");
                ReportPropertyChanged("IsActive");
                OnIsActiveChanged();
            }
        }

        private System.Boolean _IsActive;
        partial void OnIsActiveChanging(System.Boolean value);
        partial void OnIsActiveChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsIncentive
        {
            get
            {
                return _IsIncentive;
            }

            set
            {
                OnIsIncentiveChanging(value);
                ReportPropertyChanging("IsIncentive");
                _IsIncentive = StructuralObject.SetValidValue(value, "IsIncentive");
                ReportPropertyChanged("IsIncentive");
                OnIsIncentiveChanged();
            }
        }

        private System.Boolean _IsIncentive;
        partial void OnIsIncentiveChanging(System.Boolean value);
        partial void OnIsIncentiveChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentFrom
        {
            get
            {
                return _WasCurrentFrom;
            }

            set
            {
                OnWasCurrentFromChanging(value);
                ReportPropertyChanging("WasCurrentFrom");
                _WasCurrentFrom = StructuralObject.SetValidValue(value, "WasCurrentFrom");
                ReportPropertyChanged("WasCurrentFrom");
                OnWasCurrentFromChanged();
            }
        }

        private System.DateTime _WasCurrentFrom;
        partial void OnWasCurrentFromChanging(System.DateTime value);
        partial void OnWasCurrentFromChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentTo
        {
            get
            {
                return _WasCurrentTo;
            }

            set
            {
                OnWasCurrentToChanging(value);
                ReportPropertyChanging("WasCurrentTo");
                _WasCurrentTo = StructuralObject.SetValidValue(value, "WasCurrentTo");
                ReportPropertyChanged("WasCurrentTo");
                OnWasCurrentToChanged();
            }
        }

        private System.DateTime _WasCurrentTo;
        partial void OnWasCurrentToChanging(System.DateTime value);
        partial void OnWasCurrentToChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }

            set
            {
                OnDateOfBirthChanging(value);
                ReportPropertyChanging("DateOfBirth");
                _DateOfBirth = StructuralObject.SetValidValue(value, "DateOfBirth");
                ReportPropertyChanged("DateOfBirth");
                OnDateOfBirthChanged();
            }
        }

        private Nullable<System.DateTime> _DateOfBirth;
        partial void OnDateOfBirthChanging(Nullable<System.DateTime> value);
        partial void OnDateOfBirthChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> DateOfJoining
        {
            get
            {
                return _DateOfJoining;
            }

            set
            {
                OnDateOfJoiningChanging(value);
                ReportPropertyChanging("DateOfJoining");
                _DateOfJoining = StructuralObject.SetValidValue(value, "DateOfJoining");
                ReportPropertyChanged("DateOfJoining");
                OnDateOfJoiningChanged();
            }
        }

        private Nullable<System.DateTime> _DateOfJoining;
        partial void OnDateOfJoiningChanging(Nullable<System.DateTime> value);
        partial void OnDateOfJoiningChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> DateOfSeparation
        {
            get
            {
                return _DateOfSeparation;
            }

            set
            {
                OnDateOfSeparationChanging(value);
                ReportPropertyChanging("DateOfSeparation");
                _DateOfSeparation = StructuralObject.SetValidValue(value, "DateOfSeparation");
                ReportPropertyChanged("DateOfSeparation");
                OnDateOfSeparationChanged();
            }
        }

        private Nullable<System.DateTime> _DateOfSeparation;
        partial void OnDateOfSeparationChanging(Nullable<System.DateTime> value);
        partial void OnDateOfSeparationChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String TimeCardNo
        {
            get
            {
                return _TimeCardNo;
            }

            set
            {
                OnTimeCardNoChanging(value);
                ReportPropertyChanging("TimeCardNo");
                _TimeCardNo = StructuralObject.SetValidValue(value, true, "TimeCardNo");
                ReportPropertyChanged("TimeCardNo");
                OnTimeCardNoChanged();
            }
        }

        private System.String _TimeCardNo;
        partial void OnTimeCardNoChanging(System.String value);
        partial void OnTimeCardNoChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Comment
        {
            get
            {
                return _Comment;
            }

            set
            {
                OnCommentChanging(value);
                ReportPropertyChanging("Comment");
                _Comment = StructuralObject.SetValidValue(value, true, "Comment");
                ReportPropertyChanged("Comment");
                OnCommentChanged();
            }
        }

        private System.String _Comment;
        partial void OnCommentChanging(System.String value);
        partial void OnCommentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Employees_AddressDetails", "AddressDetails")]
        public AddressDetail AddressDetail
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AddressDetail>("FacessoModel.FK_Employees_AddressDetails", "AddressDetails").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AddressDetail>("FacessoModel.FK_Employees_AddressDetails", "AddressDetails").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AddressDetail> AddressDetailReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AddressDetail>("FacessoModel.FK_Employees_AddressDetails", "AddressDetails");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AddressDetail>("FacessoModel.FK_Employees_AddressDetails", "AddressDetails", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Employees_CostCenter", "CostCenters")]
        public CostCenter CostCenter
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_Employees_CostCenter", "CostCenters").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_Employees_CostCenter", "CostCenters").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<CostCenter> CostCenterReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_Employees_CostCenter", "CostCenters");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<CostCenter>("FacessoModel.FK_Employees_CostCenter", "CostCenters", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_EmployeeHandicap_Employees", "EmployeeHandicaps")]
        public EntityCollection<EmployeeHandicap> EmployeeHandicaps
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<EmployeeHandicap>("FacessoModel.FK_EmployeeHandicap_Employees", "EmployeeHandicaps");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<EmployeeHandicap>("FacessoModel.FK_EmployeeHandicap_Employees", "EmployeeHandicaps", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Employees_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Employees_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Employees_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Employees_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_Employees_Subsidiaries", "Subsidiaries", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Employees_WageGroups", "WageGroups")]
        public WageGroup WageGroup
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WageGroup>("FacessoModel.FK_Employees_WageGroups", "WageGroups").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WageGroup>("FacessoModel.FK_Employees_WageGroups", "WageGroups").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<WageGroup> WageGroupReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WageGroup>("FacessoModel.FK_Employees_WageGroups", "WageGroups");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<WageGroup>("FacessoModel.FK_Employees_WageGroups", "WageGroups", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_SkillProvided_Employees", "SkillProvided")]
        public EntityCollection<SkillProvided> SkillProvideds
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SkillProvided>("FacessoModel.FK_SkillProvided_Employees", "SkillProvided");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SkillProvided>("FacessoModel.FK_SkillProvided_Employees", "SkillProvided", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_TimeLog_Employee", "TimeLog")]
        public EntityCollection<TimeLog> TimeLogs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TimeLog>("FacessoModel.FK_TimeLog_Employee", "TimeLog");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TimeLog>("FacessoModel.FK_TimeLog_Employee", "TimeLog", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "EmployeeHandicap")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class EmployeeHandicap : EntityObject
    {
        /// <summary>
        /// Create a new EmployeeHandicap object.
        /// </summary>
        /// <param name = "iDEmployee">Initial value of the IDEmployee property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "handicap">Initial value of the Handicap property.</param>
        /// <param name = "validFrom">Initial value of the ValidFrom property.</param>
        public static EmployeeHandicap CreateEmployeeHandicap(System.Int32 iDEmployee, System.Int32 iDSubsidiary, System.Double handicap, System.DateTime validFrom)
        {
            EmployeeHandicap employeeHandicap = new EmployeeHandicap();
            employeeHandicap.IDEmployee = iDEmployee;
            employeeHandicap.IDSubsidiary = iDSubsidiary;
            employeeHandicap.Handicap = handicap;
            employeeHandicap.ValidFrom = validFrom;
            return employeeHandicap;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDEmployee
        {
            get
            {
                return _IDEmployee;
            }

            set
            {
                if ((_IDEmployee != value))
                {
                    OnIDEmployeeChanging(value);
                    ReportPropertyChanging("IDEmployee");
                    _IDEmployee = StructuralObject.SetValidValue(value, "IDEmployee");
                    ReportPropertyChanged("IDEmployee");
                    OnIDEmployeeChanged();
                }
            }
        }

        private System.Int32 _IDEmployee;
        partial void OnIDEmployeeChanging(System.Int32 value);
        partial void OnIDEmployeeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double Handicap
        {
            get
            {
                return _Handicap;
            }

            set
            {
                if ((_Handicap != value))
                {
                    OnHandicapChanging(value);
                    ReportPropertyChanging("Handicap");
                    _Handicap = StructuralObject.SetValidValue(value, "Handicap");
                    ReportPropertyChanged("Handicap");
                    OnHandicapChanged();
                }
            }
        }

        private System.Double _Handicap;
        partial void OnHandicapChanging(System.Double value);
        partial void OnHandicapChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ValidFrom
        {
            get
            {
                return _ValidFrom;
            }

            set
            {
                if ((_ValidFrom != value))
                {
                    OnValidFromChanging(value);
                    ReportPropertyChanging("ValidFrom");
                    _ValidFrom = StructuralObject.SetValidValue(value, "ValidFrom");
                    ReportPropertyChanged("ValidFrom");
                    OnValidFromChanged();
                }
            }
        }

        private System.DateTime _ValidFrom;
        partial void OnValidFromChanging(System.DateTime value);
        partial void OnValidFromChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_EmployeeHandicap_Employees", "Employees")]
        public Employee Employee
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("FacessoModel.FK_EmployeeHandicap_Employees", "Employees").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("FacessoModel.FK_EmployeeHandicap_Employees", "Employees").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> EmployeeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("FacessoModel.FK_EmployeeHandicap_Employees", "Employees");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("FacessoModel.FK_EmployeeHandicap_Employees", "Employees", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "FunctionLog")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class FunctionLog : EntityObject
    {
        /// <summary>
        /// Create a new FunctionLog object.
        /// </summary>
        /// <param name = "iDFunctionLog">Initial value of the IDFunctionLog property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "functionText">Initial value of the FunctionText property.</param>
        /// <param name = "calledByIDUser">Initial value of the CalledByIDUser property.</param>
        /// <param name = "dateCalled">Initial value of the DateCalled property.</param>
        public static FunctionLog CreateFunctionLog(System.Int32 iDFunctionLog, System.Int32 iDSubsidiary, System.String functionText, System.Int32 calledByIDUser, System.DateTime dateCalled)
        {
            FunctionLog functionLog = new FunctionLog();
            functionLog.IDFunctionLog = iDFunctionLog;
            functionLog.IDSubsidiary = iDSubsidiary;
            functionLog.FunctionText = functionText;
            functionLog.CalledByIDUser = calledByIDUser;
            functionLog.DateCalled = dateCalled;
            return functionLog;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDFunctionLog
        {
            get
            {
                return _IDFunctionLog;
            }

            set
            {
                if ((_IDFunctionLog != value))
                {
                    OnIDFunctionLogChanging(value);
                    ReportPropertyChanging("IDFunctionLog");
                    _IDFunctionLog = StructuralObject.SetValidValue(value, "IDFunctionLog");
                    ReportPropertyChanged("IDFunctionLog");
                    OnIDFunctionLogChanged();
                }
            }
        }

        private System.Int32 _IDFunctionLog;
        partial void OnIDFunctionLogChanging(System.Int32 value);
        partial void OnIDFunctionLogChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String FunctionText
        {
            get
            {
                return _FunctionText;
            }

            set
            {
                OnFunctionTextChanging(value);
                ReportPropertyChanging("FunctionText");
                _FunctionText = StructuralObject.SetValidValue(value, false, "FunctionText");
                ReportPropertyChanged("FunctionText");
                OnFunctionTextChanged();
            }
        }

        private System.String _FunctionText;
        partial void OnFunctionTextChanging(System.String value);
        partial void OnFunctionTextChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 CalledByIDUser
        {
            get
            {
                return _CalledByIDUser;
            }

            set
            {
                OnCalledByIDUserChanging(value);
                ReportPropertyChanging("CalledByIDUser");
                _CalledByIDUser = StructuralObject.SetValidValue(value, "CalledByIDUser");
                ReportPropertyChanged("CalledByIDUser");
                OnCalledByIDUserChanged();
            }
        }

        private System.Int32 _CalledByIDUser;
        partial void OnCalledByIDUserChanging(System.Int32 value);
        partial void OnCalledByIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime DateCalled
        {
            get
            {
                return _DateCalled;
            }

            set
            {
                OnDateCalledChanging(value);
                ReportPropertyChanging("DateCalled");
                _DateCalled = StructuralObject.SetValidValue(value, "DateCalled");
                ReportPropertyChanged("DateCalled");
                OnDateCalledChanged();
            }
        }

        private System.DateTime _DateCalled;
        partial void OnDateCalledChanging(System.DateTime value);
        partial void OnDateCalledChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String OnComputer
        {
            get
            {
                return _OnComputer;
            }

            set
            {
                OnOnComputerChanging(value);
                ReportPropertyChanging("OnComputer");
                _OnComputer = StructuralObject.SetValidValue(value, true, "OnComputer");
                ReportPropertyChanged("OnComputer");
                OnOnComputerChanged();
            }
        }

        private System.String _OnComputer;
        partial void OnOnComputerChanging(System.String value);
        partial void OnOnComputerChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_FunctionLog_Users", "Users")]
        public User User
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("FacessoModel.FK_FunctionLog_Users", "Users").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("FacessoModel.FK_FunctionLog_Users", "Users").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UserReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("FacessoModel.FK_FunctionLog_Users", "Users");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("FacessoModel.FK_FunctionLog_Users", "Users", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "LabourValue")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class LabourValue : EntityObject
    {
        /// <summary>
        /// Create a new LabourValue object.
        /// </summary>
        /// <param name = "iDLabourValue">Initial value of the IDLabourValue property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDLabourValueInternal">Initial value of the IDLabourValueInternal property.</param>
        /// <param name = "iDCostCenter">Initial value of the IDCostCenter property.</param>
        /// <param name = "labourValueNumber">Initial value of the LabourValueNumber property.</param>
        /// <param name = "labourValueName">Initial value of the LabourValueName property.</param>
        /// <param name = "teHMin">Initial value of the TeHMin property.</param>
        /// <param name = "dimension">Initial value of the Dimension property.</param>
        /// <param name = "isActive">Initial value of the IsActive property.</param>
        /// <param name = "isCurrent">Initial value of the IsCurrent property.</param>
        /// <param name = "wasCurrentFrom">Initial value of the WasCurrentFrom property.</param>
        /// <param name = "wasCurrentTo">Initial value of the WasCurrentTo property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static LabourValue CreateLabourValue(System.Int32 iDLabourValue, System.Int32 iDSubsidiary, System.Int32 iDLabourValueInternal, System.Int32 iDCostCenter, System.Int32 labourValueNumber, System.String labourValueName, System.Double teHMin, System.String dimension, System.Boolean isActive, System.Boolean isCurrent, System.DateTime wasCurrentFrom, System.DateTime wasCurrentTo, System.DateTime lastEdited)
        {
            LabourValue labourValue = new LabourValue();
            labourValue.IDLabourValue = iDLabourValue;
            labourValue.IDSubsidiary = iDSubsidiary;
            labourValue.IDLabourValueInternal = iDLabourValueInternal;
            labourValue.IDCostCenter = iDCostCenter;
            labourValue.LabourValueNumber = labourValueNumber;
            labourValue.LabourValueName = labourValueName;
            labourValue.TeHMin = teHMin;
            labourValue.Dimension = dimension;
            labourValue.IsActive = isActive;
            labourValue.IsCurrent = isCurrent;
            labourValue.WasCurrentFrom = wasCurrentFrom;
            labourValue.WasCurrentTo = wasCurrentTo;
            labourValue.LastEdited = lastEdited;
            return labourValue;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDLabourValue
        {
            get
            {
                return _IDLabourValue;
            }

            set
            {
                if ((_IDLabourValue != value))
                {
                    OnIDLabourValueChanging(value);
                    ReportPropertyChanging("IDLabourValue");
                    _IDLabourValue = StructuralObject.SetValidValue(value, "IDLabourValue");
                    ReportPropertyChanged("IDLabourValue");
                    OnIDLabourValueChanged();
                }
            }
        }

        private System.Int32 _IDLabourValue;
        partial void OnIDLabourValueChanging(System.Int32 value);
        partial void OnIDLabourValueChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDLabourValueInternal
        {
            get
            {
                return _IDLabourValueInternal;
            }

            set
            {
                OnIDLabourValueInternalChanging(value);
                ReportPropertyChanging("IDLabourValueInternal");
                _IDLabourValueInternal = StructuralObject.SetValidValue(value, "IDLabourValueInternal");
                ReportPropertyChanged("IDLabourValueInternal");
                OnIDLabourValueInternalChanged();
            }
        }

        private System.Int32 _IDLabourValueInternal;
        partial void OnIDLabourValueInternalChanging(System.Int32 value);
        partial void OnIDLabourValueInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCostCenter
        {
            get
            {
                return _IDCostCenter;
            }

            set
            {
                OnIDCostCenterChanging(value);
                ReportPropertyChanging("IDCostCenter");
                _IDCostCenter = StructuralObject.SetValidValue(value, "IDCostCenter");
                ReportPropertyChanged("IDCostCenter");
                OnIDCostCenterChanged();
            }
        }

        private System.Int32 _IDCostCenter;
        partial void OnIDCostCenterChanging(System.Int32 value);
        partial void OnIDCostCenterChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 LabourValueNumber
        {
            get
            {
                return _LabourValueNumber;
            }

            set
            {
                OnLabourValueNumberChanging(value);
                ReportPropertyChanging("LabourValueNumber");
                _LabourValueNumber = StructuralObject.SetValidValue(value, "LabourValueNumber");
                ReportPropertyChanged("LabourValueNumber");
                OnLabourValueNumberChanged();
            }
        }

        private System.Int32 _LabourValueNumber;
        partial void OnLabourValueNumberChanging(System.Int32 value);
        partial void OnLabourValueNumberChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String LabourValueName
        {
            get
            {
                return _LabourValueName;
            }

            set
            {
                OnLabourValueNameChanging(value);
                ReportPropertyChanging("LabourValueName");
                _LabourValueName = StructuralObject.SetValidValue(value, false, "LabourValueName");
                ReportPropertyChanged("LabourValueName");
                OnLabourValueNameChanged();
            }
        }

        private System.String _LabourValueName;
        partial void OnLabourValueNameChanging(System.String value);
        partial void OnLabourValueNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String LabourValueDescription
        {
            get
            {
                return _LabourValueDescription;
            }

            set
            {
                OnLabourValueDescriptionChanging(value);
                ReportPropertyChanging("LabourValueDescription");
                _LabourValueDescription = StructuralObject.SetValidValue(value, true, "LabourValueDescription");
                ReportPropertyChanged("LabourValueDescription");
                OnLabourValueDescriptionChanged();
            }
        }

        private System.String _LabourValueDescription;
        partial void OnLabourValueDescriptionChanging(System.String value);
        partial void OnLabourValueDescriptionChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double TeHMin
        {
            get
            {
                return _TeHMin;
            }

            set
            {
                OnTeHMinChanging(value);
                ReportPropertyChanging("TeHMin");
                _TeHMin = StructuralObject.SetValidValue(value, "TeHMin");
                ReportPropertyChanged("TeHMin");
                OnTeHMinChanged();
            }
        }

        private System.Double _TeHMin;
        partial void OnTeHMinChanging(System.Double value);
        partial void OnTeHMinChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String Dimension
        {
            get
            {
                return _Dimension;
            }

            set
            {
                OnDimensionChanging(value);
                ReportPropertyChanging("Dimension");
                _Dimension = StructuralObject.SetValidValue(value, false, "Dimension");
                ReportPropertyChanged("Dimension");
                OnDimensionChanged();
            }
        }

        private System.String _Dimension;
        partial void OnDimensionChanging(System.String value);
        partial void OnDimensionChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsActive
        {
            get
            {
                return _IsActive;
            }

            set
            {
                OnIsActiveChanging(value);
                ReportPropertyChanging("IsActive");
                _IsActive = StructuralObject.SetValidValue(value, "IsActive");
                ReportPropertyChanged("IsActive");
                OnIsActiveChanged();
            }
        }

        private System.Boolean _IsActive;
        partial void OnIsActiveChanging(System.Boolean value);
        partial void OnIsActiveChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsCurrent
        {
            get
            {
                return _IsCurrent;
            }

            set
            {
                OnIsCurrentChanging(value);
                ReportPropertyChanging("IsCurrent");
                _IsCurrent = StructuralObject.SetValidValue(value, "IsCurrent");
                ReportPropertyChanged("IsCurrent");
                OnIsCurrentChanged();
            }
        }

        private System.Boolean _IsCurrent;
        partial void OnIsCurrentChanging(System.Boolean value);
        partial void OnIsCurrentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentFrom
        {
            get
            {
                return _WasCurrentFrom;
            }

            set
            {
                OnWasCurrentFromChanging(value);
                ReportPropertyChanging("WasCurrentFrom");
                _WasCurrentFrom = StructuralObject.SetValidValue(value, "WasCurrentFrom");
                ReportPropertyChanged("WasCurrentFrom");
                OnWasCurrentFromChanged();
            }
        }

        private System.DateTime _WasCurrentFrom;
        partial void OnWasCurrentFromChanging(System.DateTime value);
        partial void OnWasCurrentFromChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentTo
        {
            get
            {
                return _WasCurrentTo;
            }

            set
            {
                OnWasCurrentToChanging(value);
                ReportPropertyChanging("WasCurrentTo");
                _WasCurrentTo = StructuralObject.SetValidValue(value, "WasCurrentTo");
                ReportPropertyChanged("WasCurrentTo");
                OnWasCurrentToChanged();
            }
        }

        private System.DateTime _WasCurrentTo;
        partial void OnWasCurrentToChanging(System.DateTime value);
        partial void OnWasCurrentToChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_LabourValues_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_LabourValues_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_LabourValues_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_LabourValues_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_LabourValues_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "NotificationRecipient")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class NotificationRecipient : EntityObject
    {
        /// <summary>
        /// Create a new NotificationRecipient object.
        /// </summary>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDNotificationRecipient">Initial value of the IDNotificationRecipient property.</param>
        /// <param name = "firstName">Initial value of the FirstName property.</param>
        /// <param name = "lastName">Initial value of the LastName property.</param>
        /// <param name = "sMTPAddress">Initial value of the SMTPAddress property.</param>
        /// <param name = "isGlobal">Initial value of the IsGlobal property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static NotificationRecipient CreateNotificationRecipient(System.Int32 iDSubsidiary, System.Int32 iDNotificationRecipient, System.String firstName, System.String lastName, System.String sMTPAddress, System.Boolean isGlobal, System.DateTime lastEdited)
        {
            NotificationRecipient notificationRecipient = new NotificationRecipient();
            notificationRecipient.IDSubsidiary = iDSubsidiary;
            notificationRecipient.IDNotificationRecipient = iDNotificationRecipient;
            notificationRecipient.FirstName = firstName;
            notificationRecipient.LastName = lastName;
            notificationRecipient.SMTPAddress = sMTPAddress;
            notificationRecipient.IsGlobal = isGlobal;
            notificationRecipient.LastEdited = lastEdited;
            return notificationRecipient;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDNotificationRecipient
        {
            get
            {
                return _IDNotificationRecipient;
            }

            set
            {
                if ((_IDNotificationRecipient != value))
                {
                    OnIDNotificationRecipientChanging(value);
                    ReportPropertyChanging("IDNotificationRecipient");
                    _IDNotificationRecipient = StructuralObject.SetValidValue(value, "IDNotificationRecipient");
                    ReportPropertyChanged("IDNotificationRecipient");
                    OnIDNotificationRecipientChanged();
                }
            }
        }

        private System.Int32 _IDNotificationRecipient;
        partial void OnIDNotificationRecipientChanging(System.Int32 value);
        partial void OnIDNotificationRecipientChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Title
        {
            get
            {
                return _Title;
            }

            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, true, "Title");
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }

        private System.String _Title;
        partial void OnTitleChanging(System.String value);
        partial void OnTitleChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false, "FirstName");
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }

        private System.String _FirstName;
        partial void OnFirstNameChanging(System.String value);
        partial void OnFirstNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String LastName
        {
            get
            {
                return _LastName;
            }

            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false, "LastName");
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }

        private System.String _LastName;
        partial void OnLastNameChanging(System.String value);
        partial void OnLastNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String SMTPAddress
        {
            get
            {
                return _SMTPAddress;
            }

            set
            {
                OnSMTPAddressChanging(value);
                ReportPropertyChanging("SMTPAddress");
                _SMTPAddress = StructuralObject.SetValidValue(value, false, "SMTPAddress");
                ReportPropertyChanged("SMTPAddress");
                OnSMTPAddressChanged();
            }
        }

        private System.String _SMTPAddress;
        partial void OnSMTPAddressChanging(System.String value);
        partial void OnSMTPAddressChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String SMTPAddressFallOver
        {
            get
            {
                return _SMTPAddressFallOver;
            }

            set
            {
                OnSMTPAddressFallOverChanging(value);
                ReportPropertyChanging("SMTPAddressFallOver");
                _SMTPAddressFallOver = StructuralObject.SetValidValue(value, true, "SMTPAddressFallOver");
                ReportPropertyChanged("SMTPAddressFallOver");
                OnSMTPAddressFallOverChanged();
            }
        }

        private System.String _SMTPAddressFallOver;
        partial void OnSMTPAddressFallOverChanging(System.String value);
        partial void OnSMTPAddressFallOverChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsGlobal
        {
            get
            {
                return _IsGlobal;
            }

            set
            {
                OnIsGlobalChanging(value);
                ReportPropertyChanging("IsGlobal");
                _IsGlobal = StructuralObject.SetValidValue(value, "IsGlobal");
                ReportPropertyChanged("IsGlobal");
                OnIsGlobalChanged();
            }
        }

        private System.Boolean _IsGlobal;
        partial void OnIsGlobalChanging(System.Boolean value);
        partial void OnIsGlobalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Tag
        {
            get
            {
                return _Tag;
            }

            set
            {
                OnTagChanging(value);
                ReportPropertyChanging("Tag");
                _Tag = StructuralObject.SetValidValue(value, true, "Tag");
                ReportPropertyChanged("Tag");
                OnTagChanged();
            }
        }

        private System.String _Tag;
        partial void OnTagChanging(System.String value);
        partial void OnTagChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_NotificationRecepients_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_NotificationRecepients_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_NotificationRecepients_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_NotificationRecepients_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_NotificationRecepients_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "ParamsEmployee")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class ParamsEmployee : EntityObject
    {
        /// <summary>
        /// Create a new ParamsEmployee object.
        /// </summary>
        /// <param name = "iDParamsEmployees">Initial value of the IDParamsEmployees property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDUser">Initial value of the IDUser property.</param>
        /// <param name = "ticket">Initial value of the Ticket property.</param>
        /// <param name = "iDEmployee">Initial value of the IDEmployee property.</param>
        public static ParamsEmployee CreateParamsEmployee(System.Int32 iDParamsEmployees, System.Int32 iDSubsidiary, System.Int32 iDUser, System.DateTime ticket, System.Int32 iDEmployee)
        {
            ParamsEmployee paramsEmployee = new ParamsEmployee();
            paramsEmployee.IDParamsEmployees = iDParamsEmployees;
            paramsEmployee.IDSubsidiary = iDSubsidiary;
            paramsEmployee.IDUser = iDUser;
            paramsEmployee.Ticket = ticket;
            paramsEmployee.IDEmployee = iDEmployee;
            return paramsEmployee;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDParamsEmployees
        {
            get
            {
                return _IDParamsEmployees;
            }

            set
            {
                if ((_IDParamsEmployees != value))
                {
                    OnIDParamsEmployeesChanging(value);
                    ReportPropertyChanging("IDParamsEmployees");
                    _IDParamsEmployees = StructuralObject.SetValidValue(value, "IDParamsEmployees");
                    ReportPropertyChanged("IDParamsEmployees");
                    OnIDParamsEmployeesChanged();
                }
            }
        }

        private System.Int32 _IDParamsEmployees;
        partial void OnIDParamsEmployeesChanging(System.Int32 value);
        partial void OnIDParamsEmployeesChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDUser
        {
            get
            {
                return _IDUser;
            }

            set
            {
                if ((_IDUser != value))
                {
                    OnIDUserChanging(value);
                    ReportPropertyChanging("IDUser");
                    _IDUser = StructuralObject.SetValidValue(value, "IDUser");
                    ReportPropertyChanged("IDUser");
                    OnIDUserChanged();
                }
            }
        }

        private System.Int32 _IDUser;
        partial void OnIDUserChanging(System.Int32 value);
        partial void OnIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime Ticket
        {
            get
            {
                return _Ticket;
            }

            set
            {
                if ((_Ticket != value))
                {
                    OnTicketChanging(value);
                    ReportPropertyChanging("Ticket");
                    _Ticket = StructuralObject.SetValidValue(value, "Ticket");
                    ReportPropertyChanged("Ticket");
                    OnTicketChanged();
                }
            }
        }

        private System.DateTime _Ticket;
        partial void OnTicketChanging(System.DateTime value);
        partial void OnTicketChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDEmployee
        {
            get
            {
                return _IDEmployee;
            }

            set
            {
                OnIDEmployeeChanging(value);
                ReportPropertyChanging("IDEmployee");
                _IDEmployee = StructuralObject.SetValidValue(value, "IDEmployee");
                ReportPropertyChanged("IDEmployee");
                OnIDEmployeeChanged();
            }
        }

        private System.Int32 _IDEmployee;
        partial void OnIDEmployeeChanging(System.Int32 value);
        partial void OnIDEmployeeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ParamsEmployees_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ParamsEmployees_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ParamsEmployees_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ParamsEmployees_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_ParamsEmployees_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "ParamsProductionDate")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class ParamsProductionDate : EntityObject
    {
        /// <summary>
        /// Create a new ParamsProductionDate object.
        /// </summary>
        /// <param name = "iDParamsProductionDates">Initial value of the IDParamsProductionDates property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDUser">Initial value of the IDUser property.</param>
        /// <param name = "ticket">Initial value of the Ticket property.</param>
        /// <param name = "productionDate">Initial value of the ProductionDate property.</param>
        /// <param name = "shift">Initial value of the Shift property.</param>
        public static ParamsProductionDate CreateParamsProductionDate(System.Int32 iDParamsProductionDates, System.Int32 iDSubsidiary, System.Int32 iDUser, System.DateTime ticket, System.DateTime productionDate, System.Byte shift)
        {
            ParamsProductionDate paramsProductionDate = new ParamsProductionDate();
            paramsProductionDate.IDParamsProductionDates = iDParamsProductionDates;
            paramsProductionDate.IDSubsidiary = iDSubsidiary;
            paramsProductionDate.IDUser = iDUser;
            paramsProductionDate.Ticket = ticket;
            paramsProductionDate.ProductionDate = productionDate;
            paramsProductionDate.Shift = shift;
            return paramsProductionDate;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDParamsProductionDates
        {
            get
            {
                return _IDParamsProductionDates;
            }

            set
            {
                if ((_IDParamsProductionDates != value))
                {
                    OnIDParamsProductionDatesChanging(value);
                    ReportPropertyChanging("IDParamsProductionDates");
                    _IDParamsProductionDates = StructuralObject.SetValidValue(value, "IDParamsProductionDates");
                    ReportPropertyChanged("IDParamsProductionDates");
                    OnIDParamsProductionDatesChanged();
                }
            }
        }

        private System.Int32 _IDParamsProductionDates;
        partial void OnIDParamsProductionDatesChanging(System.Int32 value);
        partial void OnIDParamsProductionDatesChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDUser
        {
            get
            {
                return _IDUser;
            }

            set
            {
                if ((_IDUser != value))
                {
                    OnIDUserChanging(value);
                    ReportPropertyChanging("IDUser");
                    _IDUser = StructuralObject.SetValidValue(value, "IDUser");
                    ReportPropertyChanged("IDUser");
                    OnIDUserChanged();
                }
            }
        }

        private System.Int32 _IDUser;
        partial void OnIDUserChanging(System.Int32 value);
        partial void OnIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime Ticket
        {
            get
            {
                return _Ticket;
            }

            set
            {
                if ((_Ticket != value))
                {
                    OnTicketChanging(value);
                    ReportPropertyChanging("Ticket");
                    _Ticket = StructuralObject.SetValidValue(value, "Ticket");
                    ReportPropertyChanged("Ticket");
                    OnTicketChanged();
                }
            }
        }

        private System.DateTime _Ticket;
        partial void OnTicketChanging(System.DateTime value);
        partial void OnTicketChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ProductionDate
        {
            get
            {
                return _ProductionDate;
            }

            set
            {
                OnProductionDateChanging(value);
                ReportPropertyChanging("ProductionDate");
                _ProductionDate = StructuralObject.SetValidValue(value, "ProductionDate");
                ReportPropertyChanged("ProductionDate");
                OnProductionDateChanged();
            }
        }

        private System.DateTime _ProductionDate;
        partial void OnProductionDateChanging(System.DateTime value);
        partial void OnProductionDateChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Byte Shift
        {
            get
            {
                return _Shift;
            }

            set
            {
                OnShiftChanging(value);
                ReportPropertyChanging("Shift");
                _Shift = StructuralObject.SetValidValue(value, "Shift");
                ReportPropertyChanged("Shift");
                OnShiftChanged();
            }
        }

        private System.Byte _Shift;
        partial void OnShiftChanging(System.Byte value);
        partial void OnShiftChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.Int64> Tag
        {
            get
            {
                return _Tag;
            }

            set
            {
                OnTagChanging(value);
                ReportPropertyChanging("Tag");
                _Tag = StructuralObject.SetValidValue(value, "Tag");
                ReportPropertyChanged("Tag");
                OnTagChanged();
            }
        }

        private Nullable<System.Int64> _Tag;
        partial void OnTagChanging(Nullable<System.Int64> value);
        partial void OnTagChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ParamsProductionDates_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ParamsProductionDates_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ParamsProductionDates_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ParamsProductionDates_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_ParamsProductionDates_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "ParamsWorkGroup")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class ParamsWorkGroup : EntityObject
    {
        /// <summary>
        /// Create a new ParamsWorkGroup object.
        /// </summary>
        /// <param name = "iDParamsWorkGroups">Initial value of the IDParamsWorkGroups property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDUser">Initial value of the IDUser property.</param>
        /// <param name = "ticket">Initial value of the Ticket property.</param>
        /// <param name = "iDWorkGroup">Initial value of the IDWorkGroup property.</param>
        public static ParamsWorkGroup CreateParamsWorkGroup(System.Int32 iDParamsWorkGroups, System.Int32 iDSubsidiary, System.Int32 iDUser, System.DateTime ticket, System.Int32 iDWorkGroup)
        {
            ParamsWorkGroup paramsWorkGroup = new ParamsWorkGroup();
            paramsWorkGroup.IDParamsWorkGroups = iDParamsWorkGroups;
            paramsWorkGroup.IDSubsidiary = iDSubsidiary;
            paramsWorkGroup.IDUser = iDUser;
            paramsWorkGroup.Ticket = ticket;
            paramsWorkGroup.IDWorkGroup = iDWorkGroup;
            return paramsWorkGroup;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDParamsWorkGroups
        {
            get
            {
                return _IDParamsWorkGroups;
            }

            set
            {
                if ((_IDParamsWorkGroups != value))
                {
                    OnIDParamsWorkGroupsChanging(value);
                    ReportPropertyChanging("IDParamsWorkGroups");
                    _IDParamsWorkGroups = StructuralObject.SetValidValue(value, "IDParamsWorkGroups");
                    ReportPropertyChanged("IDParamsWorkGroups");
                    OnIDParamsWorkGroupsChanged();
                }
            }
        }

        private System.Int32 _IDParamsWorkGroups;
        partial void OnIDParamsWorkGroupsChanging(System.Int32 value);
        partial void OnIDParamsWorkGroupsChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDUser
        {
            get
            {
                return _IDUser;
            }

            set
            {
                if ((_IDUser != value))
                {
                    OnIDUserChanging(value);
                    ReportPropertyChanging("IDUser");
                    _IDUser = StructuralObject.SetValidValue(value, "IDUser");
                    ReportPropertyChanged("IDUser");
                    OnIDUserChanged();
                }
            }
        }

        private System.Int32 _IDUser;
        partial void OnIDUserChanging(System.Int32 value);
        partial void OnIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime Ticket
        {
            get
            {
                return _Ticket;
            }

            set
            {
                if ((_Ticket != value))
                {
                    OnTicketChanging(value);
                    ReportPropertyChanging("Ticket");
                    _Ticket = StructuralObject.SetValidValue(value, "Ticket");
                    ReportPropertyChanged("Ticket");
                    OnTicketChanged();
                }
            }
        }

        private System.DateTime _Ticket;
        partial void OnTicketChanging(System.DateTime value);
        partial void OnTicketChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroup
        {
            get
            {
                return _IDWorkGroup;
            }

            set
            {
                OnIDWorkGroupChanging(value);
                ReportPropertyChanging("IDWorkGroup");
                _IDWorkGroup = StructuralObject.SetValidValue(value, "IDWorkGroup");
                ReportPropertyChanged("IDWorkGroup");
                OnIDWorkGroupChanged();
            }
        }

        private System.Int32 _IDWorkGroup;
        partial void OnIDWorkGroupChanging(System.Int32 value);
        partial void OnIDWorkGroupChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ParamsWorkGroups_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ParamsWorkGroups_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ParamsWorkGroups_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ParamsWorkGroups_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_ParamsWorkGroups_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "ProductionData")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class ProductionData : EntityObject
    {
        /// <summary>
        /// Create a new ProductionData object.
        /// </summary>
        /// <param name = "iDProductionData">Initial value of the IDProductionData property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDWorkGroup">Initial value of the IDWorkGroup property.</param>
        /// <param name = "iDWorkGroupInternal">Initial value of the IDWorkGroupInternal property.</param>
        /// <param name = "iDEmployee">Initial value of the IDEmployee property.</param>
        /// <param name = "productionDate">Initial value of the ProductionDate property.</param>
        /// <param name = "shift">Initial value of the Shift property.</param>
        /// <param name = "totalReferenceIWT">Initial value of the TotalReferenceIWT property.</param>
        /// <param name = "totalEffectiveIWT">Initial value of the TotalEffectiveIWT property.</param>
        /// <param name = "totalEffectiveIWTAdj">Initial value of the TotalEffectiveIWTAdj property.</param>
        /// <param name = "totalDownTime">Initial value of the TotalDownTime property.</param>
        /// <param name = "totalWorkBreakTime">Initial value of the TotalWorkBreakTime property.</param>
        /// <param name = "degreeOfTime">Initial value of the DegreeOfTime property.</param>
        /// <param name = "degreeOfTimeAdj">Initial value of the DegreeOfTimeAdj property.</param>
        /// <param name = "insertedByInterface">Initial value of the InsertedByInterface property.</param>
        /// <param name = "isSuspended">Initial value of the IsSuspended property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        /// <param name = "lastEditedByIDUser">Initial value of the LastEditedByIDUser property.</param>
        public static ProductionData CreateProductionData(System.Int64 iDProductionData, System.Int32 iDSubsidiary, System.Int32 iDWorkGroup, System.Int32 iDWorkGroupInternal, System.Int32 iDEmployee, System.DateTime productionDate, System.Byte shift, System.Double totalReferenceIWT, System.Double totalEffectiveIWT, System.Double totalEffectiveIWTAdj, System.Double totalDownTime, System.Double totalWorkBreakTime, System.Double degreeOfTime, System.Double degreeOfTimeAdj, System.Boolean insertedByInterface, System.Boolean isSuspended, System.DateTime lastEdited, System.Int32 lastEditedByIDUser)
        {
            ProductionData productionData = new ProductionData();
            productionData.IDProductionData = iDProductionData;
            productionData.IDSubsidiary = iDSubsidiary;
            productionData.IDWorkGroup = iDWorkGroup;
            productionData.IDWorkGroupInternal = iDWorkGroupInternal;
            productionData.IDEmployee = iDEmployee;
            productionData.ProductionDate = productionDate;
            productionData.Shift = shift;
            productionData.TotalReferenceIWT = totalReferenceIWT;
            productionData.TotalEffectiveIWT = totalEffectiveIWT;
            productionData.TotalEffectiveIWTAdj = totalEffectiveIWTAdj;
            productionData.TotalDownTime = totalDownTime;
            productionData.TotalWorkBreakTime = totalWorkBreakTime;
            productionData.DegreeOfTime = degreeOfTime;
            productionData.DegreeOfTimeAdj = degreeOfTimeAdj;
            productionData.InsertedByInterface = insertedByInterface;
            productionData.IsSuspended = isSuspended;
            productionData.LastEdited = lastEdited;
            productionData.LastEditedByIDUser = lastEditedByIDUser;
            return productionData;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 IDProductionData
        {
            get
            {
                return _IDProductionData;
            }

            set
            {
                if ((_IDProductionData != value))
                {
                    OnIDProductionDataChanging(value);
                    ReportPropertyChanging("IDProductionData");
                    _IDProductionData = StructuralObject.SetValidValue(value, "IDProductionData");
                    ReportPropertyChanged("IDProductionData");
                    OnIDProductionDataChanged();
                }
            }
        }

        private System.Int64 _IDProductionData;
        partial void OnIDProductionDataChanging(System.Int64 value);
        partial void OnIDProductionDataChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroup
        {
            get
            {
                return _IDWorkGroup;
            }

            set
            {
                OnIDWorkGroupChanging(value);
                ReportPropertyChanging("IDWorkGroup");
                _IDWorkGroup = StructuralObject.SetValidValue(value, "IDWorkGroup");
                ReportPropertyChanged("IDWorkGroup");
                OnIDWorkGroupChanged();
            }
        }

        private System.Int32 _IDWorkGroup;
        partial void OnIDWorkGroupChanging(System.Int32 value);
        partial void OnIDWorkGroupChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroupInternal
        {
            get
            {
                return _IDWorkGroupInternal;
            }

            set
            {
                OnIDWorkGroupInternalChanging(value);
                ReportPropertyChanging("IDWorkGroupInternal");
                _IDWorkGroupInternal = StructuralObject.SetValidValue(value, "IDWorkGroupInternal");
                ReportPropertyChanged("IDWorkGroupInternal");
                OnIDWorkGroupInternalChanged();
            }
        }

        private System.Int32 _IDWorkGroupInternal;
        partial void OnIDWorkGroupInternalChanging(System.Int32 value);
        partial void OnIDWorkGroupInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDEmployee
        {
            get
            {
                return _IDEmployee;
            }

            set
            {
                OnIDEmployeeChanging(value);
                ReportPropertyChanging("IDEmployee");
                _IDEmployee = StructuralObject.SetValidValue(value, "IDEmployee");
                ReportPropertyChanged("IDEmployee");
                OnIDEmployeeChanged();
            }
        }

        private System.Int32 _IDEmployee;
        partial void OnIDEmployeeChanging(System.Int32 value);
        partial void OnIDEmployeeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ProductionDate
        {
            get
            {
                return _ProductionDate;
            }

            set
            {
                OnProductionDateChanging(value);
                ReportPropertyChanging("ProductionDate");
                _ProductionDate = StructuralObject.SetValidValue(value, "ProductionDate");
                ReportPropertyChanged("ProductionDate");
                OnProductionDateChanged();
            }
        }

        private System.DateTime _ProductionDate;
        partial void OnProductionDateChanging(System.DateTime value);
        partial void OnProductionDateChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Byte Shift
        {
            get
            {
                return _Shift;
            }

            set
            {
                OnShiftChanging(value);
                ReportPropertyChanging("Shift");
                _Shift = StructuralObject.SetValidValue(value, "Shift");
                ReportPropertyChanged("Shift");
                OnShiftChanged();
            }
        }

        private System.Byte _Shift;
        partial void OnShiftChanging(System.Byte value);
        partial void OnShiftChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double TotalReferenceIWT
        {
            get
            {
                return _TotalReferenceIWT;
            }

            set
            {
                OnTotalReferenceIWTChanging(value);
                ReportPropertyChanging("TotalReferenceIWT");
                _TotalReferenceIWT = StructuralObject.SetValidValue(value, "TotalReferenceIWT");
                ReportPropertyChanged("TotalReferenceIWT");
                OnTotalReferenceIWTChanged();
            }
        }

        private System.Double _TotalReferenceIWT;
        partial void OnTotalReferenceIWTChanging(System.Double value);
        partial void OnTotalReferenceIWTChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double TotalEffectiveIWT
        {
            get
            {
                return _TotalEffectiveIWT;
            }

            set
            {
                OnTotalEffectiveIWTChanging(value);
                ReportPropertyChanging("TotalEffectiveIWT");
                _TotalEffectiveIWT = StructuralObject.SetValidValue(value, "TotalEffectiveIWT");
                ReportPropertyChanged("TotalEffectiveIWT");
                OnTotalEffectiveIWTChanged();
            }
        }

        private System.Double _TotalEffectiveIWT;
        partial void OnTotalEffectiveIWTChanging(System.Double value);
        partial void OnTotalEffectiveIWTChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double TotalEffectiveIWTAdj
        {
            get
            {
                return _TotalEffectiveIWTAdj;
            }

            set
            {
                OnTotalEffectiveIWTAdjChanging(value);
                ReportPropertyChanging("TotalEffectiveIWTAdj");
                _TotalEffectiveIWTAdj = StructuralObject.SetValidValue(value, "TotalEffectiveIWTAdj");
                ReportPropertyChanged("TotalEffectiveIWTAdj");
                OnTotalEffectiveIWTAdjChanged();
            }
        }

        private System.Double _TotalEffectiveIWTAdj;
        partial void OnTotalEffectiveIWTAdjChanging(System.Double value);
        partial void OnTotalEffectiveIWTAdjChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double TotalDownTime
        {
            get
            {
                return _TotalDownTime;
            }

            set
            {
                OnTotalDownTimeChanging(value);
                ReportPropertyChanging("TotalDownTime");
                _TotalDownTime = StructuralObject.SetValidValue(value, "TotalDownTime");
                ReportPropertyChanged("TotalDownTime");
                OnTotalDownTimeChanged();
            }
        }

        private System.Double _TotalDownTime;
        partial void OnTotalDownTimeChanging(System.Double value);
        partial void OnTotalDownTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double TotalWorkBreakTime
        {
            get
            {
                return _TotalWorkBreakTime;
            }

            set
            {
                OnTotalWorkBreakTimeChanging(value);
                ReportPropertyChanging("TotalWorkBreakTime");
                _TotalWorkBreakTime = StructuralObject.SetValidValue(value, "TotalWorkBreakTime");
                ReportPropertyChanged("TotalWorkBreakTime");
                OnTotalWorkBreakTimeChanged();
            }
        }

        private System.Double _TotalWorkBreakTime;
        partial void OnTotalWorkBreakTimeChanging(System.Double value);
        partial void OnTotalWorkBreakTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double DegreeOfTime
        {
            get
            {
                return _DegreeOfTime;
            }

            set
            {
                OnDegreeOfTimeChanging(value);
                ReportPropertyChanging("DegreeOfTime");
                _DegreeOfTime = StructuralObject.SetValidValue(value, "DegreeOfTime");
                ReportPropertyChanged("DegreeOfTime");
                OnDegreeOfTimeChanged();
            }
        }

        private System.Double _DegreeOfTime;
        partial void OnDegreeOfTimeChanging(System.Double value);
        partial void OnDegreeOfTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double DegreeOfTimeAdj
        {
            get
            {
                return _DegreeOfTimeAdj;
            }

            set
            {
                OnDegreeOfTimeAdjChanging(value);
                ReportPropertyChanging("DegreeOfTimeAdj");
                _DegreeOfTimeAdj = StructuralObject.SetValidValue(value, "DegreeOfTimeAdj");
                ReportPropertyChanged("DegreeOfTimeAdj");
                OnDegreeOfTimeAdjChanged();
            }
        }

        private System.Double _DegreeOfTimeAdj;
        partial void OnDegreeOfTimeAdjChanging(System.Double value);
        partial void OnDegreeOfTimeAdjChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean InsertedByInterface
        {
            get
            {
                return _InsertedByInterface;
            }

            set
            {
                OnInsertedByInterfaceChanging(value);
                ReportPropertyChanging("InsertedByInterface");
                _InsertedByInterface = StructuralObject.SetValidValue(value, "InsertedByInterface");
                ReportPropertyChanged("InsertedByInterface");
                OnInsertedByInterfaceChanged();
            }
        }

        private System.Boolean _InsertedByInterface;
        partial void OnInsertedByInterfaceChanging(System.Boolean value);
        partial void OnInsertedByInterfaceChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsSuspended
        {
            get
            {
                return _IsSuspended;
            }

            set
            {
                OnIsSuspendedChanging(value);
                ReportPropertyChanging("IsSuspended");
                _IsSuspended = StructuralObject.SetValidValue(value, "IsSuspended");
                ReportPropertyChanged("IsSuspended");
                OnIsSuspendedChanged();
            }
        }

        private System.Boolean _IsSuspended;
        partial void OnIsSuspendedChanging(System.Boolean value);
        partial void OnIsSuspendedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 LastEditedByIDUser
        {
            get
            {
                return _LastEditedByIDUser;
            }

            set
            {
                OnLastEditedByIDUserChanging(value);
                ReportPropertyChanging("LastEditedByIDUser");
                _LastEditedByIDUser = StructuralObject.SetValidValue(value, "LastEditedByIDUser");
                ReportPropertyChanged("LastEditedByIDUser");
                OnLastEditedByIDUserChanged();
            }
        }

        private System.Int32 _LastEditedByIDUser;
        partial void OnLastEditedByIDUserChanging(System.Int32 value);
        partial void OnLastEditedByIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ProductionData_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ProductionData_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ProductionData_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_ProductionData_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_ProductionData_Subsidiaries", "Subsidiaries", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ProductionData_WorkGroups", "WorkGroups")]
        public WorkGroup WorkGroup
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("FacessoModel.FK_ProductionData_WorkGroups", "WorkGroups").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("FacessoModel.FK_ProductionData_WorkGroups", "WorkGroups").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<WorkGroup> WorkGroupReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("FacessoModel.FK_ProductionData_WorkGroups", "WorkGroups");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<WorkGroup>("FacessoModel.FK_ProductionData_WorkGroups", "WorkGroups", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ProductionDataItems_ProductionData", "ProductionDataItems")]
        public EntityCollection<ProductionDataItem> ProductionDataItems
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ProductionDataItem>("FacessoModel.FK_ProductionDataItems_ProductionData", "ProductionDataItems");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ProductionDataItem>("FacessoModel.FK_ProductionDataItems_ProductionData", "ProductionDataItems", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ProductionDataItemsForInsert_ProductionData", "ProductionDataItemsForInsert")]
        public EntityCollection<ProductionDataItemsForInsert> ProductionDataItemsForInserts
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ProductionDataItemsForInsert>("FacessoModel.FK_ProductionDataItemsForInsert_ProductionData", "ProductionDataItemsForInsert");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ProductionDataItemsForInsert>("FacessoModel.FK_ProductionDataItemsForInsert_ProductionData", "ProductionDataItemsForInsert", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "ProductionDataItem")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class ProductionDataItem : EntityObject
    {
        /// <summary>
        /// Create a new ProductionDataItem object.
        /// </summary>
        /// <param name = "iDProductionDataItem">Initial value of the IDProductionDataItem property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDProductionData">Initial value of the IDProductionData property.</param>
        /// <param name = "iDLabourValue">Initial value of the IDLabourValue property.</param>
        /// <param name = "iDArticle">Initial value of the IDArticle property.</param>
        /// <param name = "amount">Initial value of the Amount property.</param>
        /// <param name = "amountViaInterface">Initial value of the AmountViaInterface property.</param>
        /// <param name = "ordinalNumber">Initial value of the OrdinalNumber property.</param>
        /// <param name = "manuallyEdited">Initial value of the ManuallyEdited property.</param>
        public static ProductionDataItem CreateProductionDataItem(System.Int64 iDProductionDataItem, System.Int32 iDSubsidiary, System.Int64 iDProductionData, System.Int32 iDLabourValue, System.Int32 iDArticle, System.Double amount, System.Double amountViaInterface, System.Int32 ordinalNumber, System.Boolean manuallyEdited)
        {
            ProductionDataItem productionDataItem = new ProductionDataItem();
            productionDataItem.IDProductionDataItem = iDProductionDataItem;
            productionDataItem.IDSubsidiary = iDSubsidiary;
            productionDataItem.IDProductionData = iDProductionData;
            productionDataItem.IDLabourValue = iDLabourValue;
            productionDataItem.IDArticle = iDArticle;
            productionDataItem.Amount = amount;
            productionDataItem.AmountViaInterface = amountViaInterface;
            productionDataItem.OrdinalNumber = ordinalNumber;
            productionDataItem.ManuallyEdited = manuallyEdited;
            return productionDataItem;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 IDProductionDataItem
        {
            get
            {
                return _IDProductionDataItem;
            }

            set
            {
                if ((_IDProductionDataItem != value))
                {
                    OnIDProductionDataItemChanging(value);
                    ReportPropertyChanging("IDProductionDataItem");
                    _IDProductionDataItem = StructuralObject.SetValidValue(value, "IDProductionDataItem");
                    ReportPropertyChanged("IDProductionDataItem");
                    OnIDProductionDataItemChanged();
                }
            }
        }

        private System.Int64 _IDProductionDataItem;
        partial void OnIDProductionDataItemChanging(System.Int64 value);
        partial void OnIDProductionDataItemChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 IDProductionData
        {
            get
            {
                return _IDProductionData;
            }

            set
            {
                OnIDProductionDataChanging(value);
                ReportPropertyChanging("IDProductionData");
                _IDProductionData = StructuralObject.SetValidValue(value, "IDProductionData");
                ReportPropertyChanged("IDProductionData");
                OnIDProductionDataChanged();
            }
        }

        private System.Int64 _IDProductionData;
        partial void OnIDProductionDataChanging(System.Int64 value);
        partial void OnIDProductionDataChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDLabourValue
        {
            get
            {
                return _IDLabourValue;
            }

            set
            {
                OnIDLabourValueChanging(value);
                ReportPropertyChanging("IDLabourValue");
                _IDLabourValue = StructuralObject.SetValidValue(value, "IDLabourValue");
                ReportPropertyChanged("IDLabourValue");
                OnIDLabourValueChanged();
            }
        }

        private System.Int32 _IDLabourValue;
        partial void OnIDLabourValueChanging(System.Int32 value);
        partial void OnIDLabourValueChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDArticle
        {
            get
            {
                return _IDArticle;
            }

            set
            {
                OnIDArticleChanging(value);
                ReportPropertyChanging("IDArticle");
                _IDArticle = StructuralObject.SetValidValue(value, "IDArticle");
                ReportPropertyChanged("IDArticle");
                OnIDArticleChanged();
            }
        }

        private System.Int32 _IDArticle;
        partial void OnIDArticleChanging(System.Int32 value);
        partial void OnIDArticleChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double Amount
        {
            get
            {
                return _Amount;
            }

            set
            {
                OnAmountChanging(value);
                ReportPropertyChanging("Amount");
                _Amount = StructuralObject.SetValidValue(value, "Amount");
                ReportPropertyChanged("Amount");
                OnAmountChanged();
            }
        }

        private System.Double _Amount;
        partial void OnAmountChanging(System.Double value);
        partial void OnAmountChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double AmountViaInterface
        {
            get
            {
                return _AmountViaInterface;
            }

            set
            {
                OnAmountViaInterfaceChanging(value);
                ReportPropertyChanging("AmountViaInterface");
                _AmountViaInterface = StructuralObject.SetValidValue(value, "AmountViaInterface");
                ReportPropertyChanged("AmountViaInterface");
                OnAmountViaInterfaceChanged();
            }
        }

        private System.Double _AmountViaInterface;
        partial void OnAmountViaInterfaceChanging(System.Double value);
        partial void OnAmountViaInterfaceChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 OrdinalNumber
        {
            get
            {
                return _OrdinalNumber;
            }

            set
            {
                OnOrdinalNumberChanging(value);
                ReportPropertyChanging("OrdinalNumber");
                _OrdinalNumber = StructuralObject.SetValidValue(value, "OrdinalNumber");
                ReportPropertyChanged("OrdinalNumber");
                OnOrdinalNumberChanged();
            }
        }

        private System.Int32 _OrdinalNumber;
        partial void OnOrdinalNumberChanging(System.Int32 value);
        partial void OnOrdinalNumberChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean ManuallyEdited
        {
            get
            {
                return _ManuallyEdited;
            }

            set
            {
                OnManuallyEditedChanging(value);
                ReportPropertyChanging("ManuallyEdited");
                _ManuallyEdited = StructuralObject.SetValidValue(value, "ManuallyEdited");
                ReportPropertyChanged("ManuallyEdited");
                OnManuallyEditedChanged();
            }
        }

        private System.Boolean _ManuallyEdited;
        partial void OnManuallyEditedChanging(System.Boolean value);
        partial void OnManuallyEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ProductionDataItems_ProductionData", "ProductionData")]
        public ProductionData ProductionData
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ProductionData>("FacessoModel.FK_ProductionDataItems_ProductionData", "ProductionData").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ProductionData>("FacessoModel.FK_ProductionDataItems_ProductionData", "ProductionData").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<ProductionData> ProductionDataReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ProductionData>("FacessoModel.FK_ProductionDataItems_ProductionData", "ProductionData");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<ProductionData>("FacessoModel.FK_ProductionDataItems_ProductionData", "ProductionData", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "ProductionDataItemsForInsert")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class ProductionDataItemsForInsert : EntityObject
    {
        /// <summary>
        /// Create a new ProductionDataItemsForInsert object.
        /// </summary>
        /// <param name = "iDProductionDataItemForInsert">Initial value of the IDProductionDataItemForInsert property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDProductionDataItem">Initial value of the IDProductionDataItem property.</param>
        /// <param name = "iDUser">Initial value of the IDUser property.</param>
        /// <param name = "iDProductionData">Initial value of the IDProductionData property.</param>
        /// <param name = "iDLabourValue">Initial value of the IDLabourValue property.</param>
        /// <param name = "iDArticle">Initial value of the IDArticle property.</param>
        /// <param name = "amount">Initial value of the Amount property.</param>
        /// <param name = "amountViaInterface">Initial value of the AmountViaInterface property.</param>
        /// <param name = "ordinalNumber">Initial value of the OrdinalNumber property.</param>
        /// <param name = "manuallyEdited">Initial value of the ManuallyEdited property.</param>
        public static ProductionDataItemsForInsert CreateProductionDataItemsForInsert(System.Int64 iDProductionDataItemForInsert, System.Int32 iDSubsidiary, System.Int64 iDProductionDataItem, System.Int32 iDUser, System.Int64 iDProductionData, System.Int32 iDLabourValue, System.Int32 iDArticle, System.Double amount, System.Double amountViaInterface, System.Int32 ordinalNumber, System.Boolean manuallyEdited)
        {
            ProductionDataItemsForInsert productionDataItemsForInsert = new ProductionDataItemsForInsert();
            productionDataItemsForInsert.IDProductionDataItemForInsert = iDProductionDataItemForInsert;
            productionDataItemsForInsert.IDSubsidiary = iDSubsidiary;
            productionDataItemsForInsert.IDProductionDataItem = iDProductionDataItem;
            productionDataItemsForInsert.IDUser = iDUser;
            productionDataItemsForInsert.IDProductionData = iDProductionData;
            productionDataItemsForInsert.IDLabourValue = iDLabourValue;
            productionDataItemsForInsert.IDArticle = iDArticle;
            productionDataItemsForInsert.Amount = amount;
            productionDataItemsForInsert.AmountViaInterface = amountViaInterface;
            productionDataItemsForInsert.OrdinalNumber = ordinalNumber;
            productionDataItemsForInsert.ManuallyEdited = manuallyEdited;
            return productionDataItemsForInsert;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 IDProductionDataItemForInsert
        {
            get
            {
                return _IDProductionDataItemForInsert;
            }

            set
            {
                if ((_IDProductionDataItemForInsert != value))
                {
                    OnIDProductionDataItemForInsertChanging(value);
                    ReportPropertyChanging("IDProductionDataItemForInsert");
                    _IDProductionDataItemForInsert = StructuralObject.SetValidValue(value, "IDProductionDataItemForInsert");
                    ReportPropertyChanged("IDProductionDataItemForInsert");
                    OnIDProductionDataItemForInsertChanged();
                }
            }
        }

        private System.Int64 _IDProductionDataItemForInsert;
        partial void OnIDProductionDataItemForInsertChanging(System.Int64 value);
        partial void OnIDProductionDataItemForInsertChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 IDProductionDataItem
        {
            get
            {
                return _IDProductionDataItem;
            }

            set
            {
                OnIDProductionDataItemChanging(value);
                ReportPropertyChanging("IDProductionDataItem");
                _IDProductionDataItem = StructuralObject.SetValidValue(value, "IDProductionDataItem");
                ReportPropertyChanged("IDProductionDataItem");
                OnIDProductionDataItemChanged();
            }
        }

        private System.Int64 _IDProductionDataItem;
        partial void OnIDProductionDataItemChanging(System.Int64 value);
        partial void OnIDProductionDataItemChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDUser
        {
            get
            {
                return _IDUser;
            }

            set
            {
                OnIDUserChanging(value);
                ReportPropertyChanging("IDUser");
                _IDUser = StructuralObject.SetValidValue(value, "IDUser");
                ReportPropertyChanged("IDUser");
                OnIDUserChanged();
            }
        }

        private System.Int32 _IDUser;
        partial void OnIDUserChanging(System.Int32 value);
        partial void OnIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 IDProductionData
        {
            get
            {
                return _IDProductionData;
            }

            set
            {
                OnIDProductionDataChanging(value);
                ReportPropertyChanging("IDProductionData");
                _IDProductionData = StructuralObject.SetValidValue(value, "IDProductionData");
                ReportPropertyChanged("IDProductionData");
                OnIDProductionDataChanged();
            }
        }

        private System.Int64 _IDProductionData;
        partial void OnIDProductionDataChanging(System.Int64 value);
        partial void OnIDProductionDataChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDLabourValue
        {
            get
            {
                return _IDLabourValue;
            }

            set
            {
                OnIDLabourValueChanging(value);
                ReportPropertyChanging("IDLabourValue");
                _IDLabourValue = StructuralObject.SetValidValue(value, "IDLabourValue");
                ReportPropertyChanged("IDLabourValue");
                OnIDLabourValueChanged();
            }
        }

        private System.Int32 _IDLabourValue;
        partial void OnIDLabourValueChanging(System.Int32 value);
        partial void OnIDLabourValueChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDArticle
        {
            get
            {
                return _IDArticle;
            }

            set
            {
                OnIDArticleChanging(value);
                ReportPropertyChanging("IDArticle");
                _IDArticle = StructuralObject.SetValidValue(value, "IDArticle");
                ReportPropertyChanged("IDArticle");
                OnIDArticleChanged();
            }
        }

        private System.Int32 _IDArticle;
        partial void OnIDArticleChanging(System.Int32 value);
        partial void OnIDArticleChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double Amount
        {
            get
            {
                return _Amount;
            }

            set
            {
                OnAmountChanging(value);
                ReportPropertyChanging("Amount");
                _Amount = StructuralObject.SetValidValue(value, "Amount");
                ReportPropertyChanged("Amount");
                OnAmountChanged();
            }
        }

        private System.Double _Amount;
        partial void OnAmountChanging(System.Double value);
        partial void OnAmountChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double AmountViaInterface
        {
            get
            {
                return _AmountViaInterface;
            }

            set
            {
                OnAmountViaInterfaceChanging(value);
                ReportPropertyChanging("AmountViaInterface");
                _AmountViaInterface = StructuralObject.SetValidValue(value, "AmountViaInterface");
                ReportPropertyChanged("AmountViaInterface");
                OnAmountViaInterfaceChanged();
            }
        }

        private System.Double _AmountViaInterface;
        partial void OnAmountViaInterfaceChanging(System.Double value);
        partial void OnAmountViaInterfaceChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 OrdinalNumber
        {
            get
            {
                return _OrdinalNumber;
            }

            set
            {
                OnOrdinalNumberChanging(value);
                ReportPropertyChanging("OrdinalNumber");
                _OrdinalNumber = StructuralObject.SetValidValue(value, "OrdinalNumber");
                ReportPropertyChanged("OrdinalNumber");
                OnOrdinalNumberChanged();
            }
        }

        private System.Int32 _OrdinalNumber;
        partial void OnOrdinalNumberChanging(System.Int32 value);
        partial void OnOrdinalNumberChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean ManuallyEdited
        {
            get
            {
                return _ManuallyEdited;
            }

            set
            {
                OnManuallyEditedChanging(value);
                ReportPropertyChanging("ManuallyEdited");
                _ManuallyEdited = StructuralObject.SetValidValue(value, "ManuallyEdited");
                ReportPropertyChanged("ManuallyEdited");
                OnManuallyEditedChanged();
            }
        }

        private System.Boolean _ManuallyEdited;
        partial void OnManuallyEditedChanging(System.Boolean value);
        partial void OnManuallyEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> Ticket
        {
            get
            {
                return _Ticket;
            }

            set
            {
                OnTicketChanging(value);
                ReportPropertyChanging("Ticket");
                _Ticket = StructuralObject.SetValidValue(value, "Ticket");
                ReportPropertyChanged("Ticket");
                OnTicketChanged();
            }
        }

        private Nullable<System.DateTime> _Ticket;
        partial void OnTicketChanging(Nullable<System.DateTime> value);
        partial void OnTicketChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ProductionDataItemsForInsert_ProductionData", "ProductionData")]
        public ProductionData ProductionData
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ProductionData>("FacessoModel.FK_ProductionDataItemsForInsert_ProductionData", "ProductionData").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ProductionData>("FacessoModel.FK_ProductionDataItemsForInsert_ProductionData", "ProductionData").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<ProductionData> ProductionDataReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ProductionData>("FacessoModel.FK_ProductionDataItemsForInsert_ProductionData", "ProductionData");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<ProductionData>("FacessoModel.FK_ProductionDataItemsForInsert_ProductionData", "ProductionData", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "Skill")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class Skill : EntityObject
    {
        /// <summary>
        /// Create a new Skill object.
        /// </summary>
        /// <param name = "iDSkill">Initial value of the IDSkill property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "skillDescription">Initial value of the SkillDescription property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static Skill CreateSkill(System.Int32 iDSkill, System.Int32 iDSubsidiary, System.String skillDescription, System.DateTime lastEdited)
        {
            Skill skill = new Skill();
            skill.IDSkill = iDSkill;
            skill.IDSubsidiary = iDSubsidiary;
            skill.SkillDescription = skillDescription;
            skill.LastEdited = lastEdited;
            return skill;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSkill
        {
            get
            {
                return _IDSkill;
            }

            set
            {
                if ((_IDSkill != value))
                {
                    OnIDSkillChanging(value);
                    ReportPropertyChanging("IDSkill");
                    _IDSkill = StructuralObject.SetValidValue(value, "IDSkill");
                    ReportPropertyChanged("IDSkill");
                    OnIDSkillChanged();
                }
            }
        }

        private System.Int32 _IDSkill;
        partial void OnIDSkillChanging(System.Int32 value);
        partial void OnIDSkillChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String SkillDescription
        {
            get
            {
                return _SkillDescription;
            }

            set
            {
                OnSkillDescriptionChanging(value);
                ReportPropertyChanging("SkillDescription");
                _SkillDescription = StructuralObject.SetValidValue(value, false, "SkillDescription");
                ReportPropertyChanged("SkillDescription");
                OnSkillDescriptionChanged();
            }
        }

        private System.String _SkillDescription;
        partial void OnSkillDescriptionChanging(System.String value);
        partial void OnSkillDescriptionChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_SkillNeeded_Skill", "SkillNeeded")]
        public EntityCollection<SkillNeeded> SkillNeededs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SkillNeeded>("FacessoModel.FK_SkillNeeded_Skill", "SkillNeeded");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SkillNeeded>("FacessoModel.FK_SkillNeeded_Skill", "SkillNeeded", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_SkillProvided_Skill", "SkillProvided")]
        public EntityCollection<SkillProvided> SkillProvideds
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SkillProvided>("FacessoModel.FK_SkillProvided_Skill", "SkillProvided");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SkillProvided>("FacessoModel.FK_SkillProvided_Skill", "SkillProvided", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Skills_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Skills_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Skills_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Skills_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_Skills_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "SkillNeeded")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class SkillNeeded : EntityObject
    {
        /// <summary>
        /// Create a new SkillNeeded object.
        /// </summary>
        /// <param name = "iDSkillNeeded">Initial value of the IDSkillNeeded property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDSkill">Initial value of the IDSkill property.</param>
        /// <param name = "iDWorkGroup">Initial value of the IDWorkGroup property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static SkillNeeded CreateSkillNeeded(System.Int32 iDSkillNeeded, System.Int32 iDSubsidiary, System.Int32 iDSkill, System.Int32 iDWorkGroup, System.DateTime lastEdited)
        {
            SkillNeeded skillNeeded = new SkillNeeded();
            skillNeeded.IDSkillNeeded = iDSkillNeeded;
            skillNeeded.IDSubsidiary = iDSubsidiary;
            skillNeeded.IDSkill = iDSkill;
            skillNeeded.IDWorkGroup = iDWorkGroup;
            skillNeeded.LastEdited = lastEdited;
            return skillNeeded;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSkillNeeded
        {
            get
            {
                return _IDSkillNeeded;
            }

            set
            {
                if ((_IDSkillNeeded != value))
                {
                    OnIDSkillNeededChanging(value);
                    ReportPropertyChanging("IDSkillNeeded");
                    _IDSkillNeeded = StructuralObject.SetValidValue(value, "IDSkillNeeded");
                    ReportPropertyChanged("IDSkillNeeded");
                    OnIDSkillNeededChanged();
                }
            }
        }

        private System.Int32 _IDSkillNeeded;
        partial void OnIDSkillNeededChanging(System.Int32 value);
        partial void OnIDSkillNeededChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSkill
        {
            get
            {
                return _IDSkill;
            }

            set
            {
                OnIDSkillChanging(value);
                ReportPropertyChanging("IDSkill");
                _IDSkill = StructuralObject.SetValidValue(value, "IDSkill");
                ReportPropertyChanged("IDSkill");
                OnIDSkillChanged();
            }
        }

        private System.Int32 _IDSkill;
        partial void OnIDSkillChanging(System.Int32 value);
        partial void OnIDSkillChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroup
        {
            get
            {
                return _IDWorkGroup;
            }

            set
            {
                OnIDWorkGroupChanging(value);
                ReportPropertyChanging("IDWorkGroup");
                _IDWorkGroup = StructuralObject.SetValidValue(value, "IDWorkGroup");
                ReportPropertyChanged("IDWorkGroup");
                OnIDWorkGroupChanged();
            }
        }

        private System.Int32 _IDWorkGroup;
        partial void OnIDWorkGroupChanging(System.Int32 value);
        partial void OnIDWorkGroupChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_SkillNeeded_Skill", "Skills")]
        public Skill Skill
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Skill>("FacessoModel.FK_SkillNeeded_Skill", "Skills").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Skill>("FacessoModel.FK_SkillNeeded_Skill", "Skills").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Skill> SkillReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Skill>("FacessoModel.FK_SkillNeeded_Skill", "Skills");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Skill>("FacessoModel.FK_SkillNeeded_Skill", "Skills", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_SkillNeeded_WorkGroups", "WorkGroups")]
        public WorkGroup WorkGroup
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("FacessoModel.FK_SkillNeeded_WorkGroups", "WorkGroups").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("FacessoModel.FK_SkillNeeded_WorkGroups", "WorkGroups").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<WorkGroup> WorkGroupReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("FacessoModel.FK_SkillNeeded_WorkGroups", "WorkGroups");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<WorkGroup>("FacessoModel.FK_SkillNeeded_WorkGroups", "WorkGroups", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "SkillProvided")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class SkillProvided : EntityObject
    {
        /// <summary>
        /// Create a new SkillProvided object.
        /// </summary>
        /// <param name = "iDSkillProvided">Initial value of the IDSkillProvided property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDEmployee">Initial value of the IDEmployee property.</param>
        /// <param name = "iDSkill">Initial value of the IDSkill property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static SkillProvided CreateSkillProvided(System.Int32 iDSkillProvided, System.Int32 iDSubsidiary, System.Int32 iDEmployee, System.Int32 iDSkill, System.DateTime lastEdited)
        {
            SkillProvided skillProvided = new SkillProvided();
            skillProvided.IDSkillProvided = iDSkillProvided;
            skillProvided.IDSubsidiary = iDSubsidiary;
            skillProvided.IDEmployee = iDEmployee;
            skillProvided.IDSkill = iDSkill;
            skillProvided.LastEdited = lastEdited;
            return skillProvided;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSkillProvided
        {
            get
            {
                return _IDSkillProvided;
            }

            set
            {
                if ((_IDSkillProvided != value))
                {
                    OnIDSkillProvidedChanging(value);
                    ReportPropertyChanging("IDSkillProvided");
                    _IDSkillProvided = StructuralObject.SetValidValue(value, "IDSkillProvided");
                    ReportPropertyChanged("IDSkillProvided");
                    OnIDSkillProvidedChanged();
                }
            }
        }

        private System.Int32 _IDSkillProvided;
        partial void OnIDSkillProvidedChanging(System.Int32 value);
        partial void OnIDSkillProvidedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDEmployee
        {
            get
            {
                return _IDEmployee;
            }

            set
            {
                OnIDEmployeeChanging(value);
                ReportPropertyChanging("IDEmployee");
                _IDEmployee = StructuralObject.SetValidValue(value, "IDEmployee");
                ReportPropertyChanged("IDEmployee");
                OnIDEmployeeChanged();
            }
        }

        private System.Int32 _IDEmployee;
        partial void OnIDEmployeeChanging(System.Int32 value);
        partial void OnIDEmployeeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSkill
        {
            get
            {
                return _IDSkill;
            }

            set
            {
                OnIDSkillChanging(value);
                ReportPropertyChanging("IDSkill");
                _IDSkill = StructuralObject.SetValidValue(value, "IDSkill");
                ReportPropertyChanged("IDSkill");
                OnIDSkillChanged();
            }
        }

        private System.Int32 _IDSkill;
        partial void OnIDSkillChanging(System.Int32 value);
        partial void OnIDSkillChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_SkillProvided_Employees", "Employees")]
        public Employee Employee
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("FacessoModel.FK_SkillProvided_Employees", "Employees").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("FacessoModel.FK_SkillProvided_Employees", "Employees").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> EmployeeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("FacessoModel.FK_SkillProvided_Employees", "Employees");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("FacessoModel.FK_SkillProvided_Employees", "Employees", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_SkillProvided_Skill", "Skills")]
        public Skill Skill
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Skill>("FacessoModel.FK_SkillProvided_Skill", "Skills").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Skill>("FacessoModel.FK_SkillProvided_Skill", "Skills").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Skill> SkillReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Skill>("FacessoModel.FK_SkillProvided_Skill", "Skills");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Skill>("FacessoModel.FK_SkillProvided_Skill", "Skills", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "Subsidiary")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class Subsidiary : EntityObject
    {
        /// <summary>
        /// Create a new Subsidiary object.
        /// </summary>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "subsidiaryName">Initial value of the SubsidiaryName property.</param>
        /// <param name = "street">Initial value of the Street property.</param>
        /// <param name = "zip">Initial value of the Zip property.</param>
        /// <param name = "city">Initial value of the City property.</param>
        /// <param name = "countryCode">Initial value of the CountryCode property.</param>
        /// <param name = "country">Initial value of the Country property.</param>
        /// <param name = "primaryPhone">Initial value of the PrimaryPhone property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static Subsidiary CreateSubsidiary(System.Int32 iDSubsidiary, System.String subsidiaryName, System.String street, System.String zip, System.String city, System.String countryCode, System.String country, System.String primaryPhone, System.DateTime lastEdited)
        {
            Subsidiary subsidiary = new Subsidiary();
            subsidiary.IDSubsidiary = iDSubsidiary;
            subsidiary.SubsidiaryName = subsidiaryName;
            subsidiary.Street = street;
            subsidiary.Zip = zip;
            subsidiary.City = city;
            subsidiary.CountryCode = countryCode;
            subsidiary.Country = country;
            subsidiary.PrimaryPhone = primaryPhone;
            subsidiary.LastEdited = lastEdited;
            return subsidiary;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String SubsidiaryName
        {
            get
            {
                return _SubsidiaryName;
            }

            set
            {
                OnSubsidiaryNameChanging(value);
                ReportPropertyChanging("SubsidiaryName");
                _SubsidiaryName = StructuralObject.SetValidValue(value, false, "SubsidiaryName");
                ReportPropertyChanged("SubsidiaryName");
                OnSubsidiaryNameChanged();
            }
        }

        private System.String _SubsidiaryName;
        partial void OnSubsidiaryNameChanging(System.String value);
        partial void OnSubsidiaryNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String Street
        {
            get
            {
                return _Street;
            }

            set
            {
                OnStreetChanging(value);
                ReportPropertyChanging("Street");
                _Street = StructuralObject.SetValidValue(value, false, "Street");
                ReportPropertyChanged("Street");
                OnStreetChanged();
            }
        }

        private System.String _Street;
        partial void OnStreetChanging(System.String value);
        partial void OnStreetChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String Zip
        {
            get
            {
                return _Zip;
            }

            set
            {
                OnZipChanging(value);
                ReportPropertyChanging("Zip");
                _Zip = StructuralObject.SetValidValue(value, false, "Zip");
                ReportPropertyChanged("Zip");
                OnZipChanged();
            }
        }

        private System.String _Zip;
        partial void OnZipChanging(System.String value);
        partial void OnZipChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String City
        {
            get
            {
                return _City;
            }

            set
            {
                OnCityChanging(value);
                ReportPropertyChanging("City");
                _City = StructuralObject.SetValidValue(value, false, "City");
                ReportPropertyChanged("City");
                OnCityChanged();
            }
        }

        private System.String _City;
        partial void OnCityChanging(System.String value);
        partial void OnCityChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String CountryCode
        {
            get
            {
                return _CountryCode;
            }

            set
            {
                OnCountryCodeChanging(value);
                ReportPropertyChanging("CountryCode");
                _CountryCode = StructuralObject.SetValidValue(value, false, "CountryCode");
                ReportPropertyChanged("CountryCode");
                OnCountryCodeChanged();
            }
        }

        private System.String _CountryCode;
        partial void OnCountryCodeChanging(System.String value);
        partial void OnCountryCodeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String Country
        {
            get
            {
                return _Country;
            }

            set
            {
                OnCountryChanging(value);
                ReportPropertyChanging("Country");
                _Country = StructuralObject.SetValidValue(value, false, "Country");
                ReportPropertyChanged("Country");
                OnCountryChanged();
            }
        }

        private System.String _Country;
        partial void OnCountryChanging(System.String value);
        partial void OnCountryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String PrimaryPhone
        {
            get
            {
                return _PrimaryPhone;
            }

            set
            {
                OnPrimaryPhoneChanging(value);
                ReportPropertyChanging("PrimaryPhone");
                _PrimaryPhone = StructuralObject.SetValidValue(value, false, "PrimaryPhone");
                ReportPropertyChanged("PrimaryPhone");
                OnPrimaryPhoneChanged();
            }
        }

        private System.String _PrimaryPhone;
        partial void OnPrimaryPhoneChanging(System.String value);
        partial void OnPrimaryPhoneChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_AddressDetails_Subsidiaries", "AddressDetails")]
        public EntityCollection<AddressDetail> AddressDetails
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AddressDetail>("FacessoModel.FK_AddressDetails_Subsidiaries", "AddressDetails");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AddressDetail>("FacessoModel.FK_AddressDetails_Subsidiaries", "AddressDetails", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Articles_Subsidiaries", "Articles")]
        public EntityCollection<Article> Articles
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Article>("FacessoModel.FK_Articles_Subsidiaries", "Articles");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Article>("FacessoModel.FK_Articles_Subsidiaries", "Articles", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Employees_Subsidiaries", "Employees")]
        public EntityCollection<Employee> Employees
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("FacessoModel.FK_Employees_Subsidiaries", "Employees");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("FacessoModel.FK_Employees_Subsidiaries", "Employees", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_LabourValues_Subsidiaries", "LabourValues")]
        public EntityCollection<LabourValue> LabourValues
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<LabourValue>("FacessoModel.FK_LabourValues_Subsidiaries", "LabourValues");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<LabourValue>("FacessoModel.FK_LabourValues_Subsidiaries", "LabourValues", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_NotificationRecepients_Subsidiaries", "NotificationRecipients")]
        public EntityCollection<NotificationRecipient> NotificationRecipients
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<NotificationRecipient>("FacessoModel.FK_NotificationRecepients_Subsidiaries", "NotificationRecipients");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<NotificationRecipient>("FacessoModel.FK_NotificationRecepients_Subsidiaries", "NotificationRecipients", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ParamsEmployees_Subsidiaries", "ParamsEmployees")]
        public EntityCollection<ParamsEmployee> ParamsEmployees
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ParamsEmployee>("FacessoModel.FK_ParamsEmployees_Subsidiaries", "ParamsEmployees");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ParamsEmployee>("FacessoModel.FK_ParamsEmployees_Subsidiaries", "ParamsEmployees", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ParamsProductionDates_Subsidiaries", "ParamsProductionDates")]
        public EntityCollection<ParamsProductionDate> ParamsProductionDates
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ParamsProductionDate>("FacessoModel.FK_ParamsProductionDates_Subsidiaries", "ParamsProductionDates");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ParamsProductionDate>("FacessoModel.FK_ParamsProductionDates_Subsidiaries", "ParamsProductionDates", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ParamsWorkGroups_Subsidiaries", "ParamsWorkGroups")]
        public EntityCollection<ParamsWorkGroup> ParamsWorkGroups
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ParamsWorkGroup>("FacessoModel.FK_ParamsWorkGroups_Subsidiaries", "ParamsWorkGroups");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ParamsWorkGroup>("FacessoModel.FK_ParamsWorkGroups_Subsidiaries", "ParamsWorkGroups", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ProductionData_Subsidiaries", "ProductionData")]
        public EntityCollection<ProductionData> ProductionDatas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ProductionData>("FacessoModel.FK_ProductionData_Subsidiaries", "ProductionData");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ProductionData>("FacessoModel.FK_ProductionData_Subsidiaries", "ProductionData", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Skills_Subsidiaries", "Skills")]
        public EntityCollection<Skill> Skills
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Skill>("FacessoModel.FK_Skills_Subsidiaries", "Skills");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Skill>("FacessoModel.FK_Skills_Subsidiaries", "Skills", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_TimeLog_Subsidiaries", "TimeLog")]
        public EntityCollection<TimeLog> TimeLogs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TimeLog>("FacessoModel.FK_TimeLog_Subsidiaries", "TimeLog");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TimeLog>("FacessoModel.FK_TimeLog_Subsidiaries", "TimeLog", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_TimeLogForInsert_Subsidiaries", "TimeLogForInsert")]
        public EntityCollection<TimeLogForInsert> TimeLogForInserts
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TimeLogForInsert>("FacessoModel.FK_TimeLogForInsert_Subsidiaries", "TimeLogForInsert");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TimeLogForInsert>("FacessoModel.FK_TimeLogForInsert_Subsidiaries", "TimeLogForInsert", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Users_Subsidiaries", "Users")]
        public EntityCollection<User> Users
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<User>("FacessoModel.FK_Users_Subsidiaries", "Users");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<User>("FacessoModel.FK_Users_Subsidiaries", "Users", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WageGroups_Subsidiaries", "WageGroups")]
        public EntityCollection<WageGroup> WageGroups
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<WageGroup>("FacessoModel.FK_WageGroups_Subsidiaries", "WageGroups");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<WageGroup>("FacessoModel.FK_WageGroups_Subsidiaries", "WageGroups", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WorkGroupAssignments_Subsidiaries", "WorkGroupAssignments")]
        public EntityCollection<WorkGroupAssignment> WorkGroupAssignments
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<WorkGroupAssignment>("FacessoModel.FK_WorkGroupAssignments_Subsidiaries", "WorkGroupAssignments");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<WorkGroupAssignment>("FacessoModel.FK_WorkGroupAssignments_Subsidiaries", "WorkGroupAssignments", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WorkGroups_Subsidiaries", "WorkGroups")]
        public EntityCollection<WorkGroup> WorkGroups
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<WorkGroup>("FacessoModel.FK_WorkGroups_Subsidiaries", "WorkGroups");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<WorkGroup>("FacessoModel.FK_WorkGroups_Subsidiaries", "WorkGroups", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "TimeLog")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class TimeLog : EntityObject
    {
        /// <summary>
        /// Create a new TimeLog object.
        /// </summary>
        /// <param name = "iDTimeLog">Initial value of the IDTimeLog property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDWorkGroup">Initial value of the IDWorkGroup property.</param>
        /// <param name = "iDWorkGroupInternal">Initial value of the IDWorkGroupInternal property.</param>
        /// <param name = "iDEmployee">Initial value of the IDEmployee property.</param>
        /// <param name = "iDEmployeeInternal">Initial value of the IDEmployeeInternal property.</param>
        /// <param name = "iDBonusLists">Initial value of the IDBonusLists property.</param>
        /// <param name = "iDWageGroup">Initial value of the IDWageGroup property.</param>
        /// <param name = "shift">Initial value of the Shift property.</param>
        /// <param name = "productionDate">Initial value of the ProductionDate property.</param>
        /// <param name = "shiftStart">Initial value of the ShiftStart property.</param>
        /// <param name = "shiftEnd">Initial value of the ShiftEnd property.</param>
        /// <param name = "workBreak">Initial value of the WorkBreak property.</param>
        /// <param name = "downTime">Initial value of the DownTime property.</param>
        /// <param name = "handicap">Initial value of the Handicap property.</param>
        /// <param name = "attendanceTime">Initial value of the AttendanceTime property.</param>
        /// <param name = "workingTime">Initial value of the WorkingTime property.</param>
        /// <param name = "incentiveWageTime">Initial value of the IncentiveWageTime property.</param>
        /// <param name = "incentiveWageTimeAdj">Initial value of the IncentiveWageTimeAdj property.</param>
        /// <param name = "degreeOfTime">Initial value of the DegreeOfTime property.</param>
        /// <param name = "degreeOfTimeAdj">Initial value of the DegreeOfTimeAdj property.</param>
        /// <param name = "referenceWageTimeProRata">Initial value of the ReferenceWageTimeProRata property.</param>
        /// <param name = "insertedByInterface">Initial value of the InsertedByInterface property.</param>
        /// <param name = "manuallyEdited">Initial value of the ManuallyEdited property.</param>
        /// <param name = "isSuspended">Initial value of the IsSuspended property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        /// <param name = "editedByIDUser">Initial value of the EditedByIDUser property.</param>
        public static TimeLog CreateTimeLog(System.Int64 iDTimeLog, System.Int32 iDSubsidiary, System.Int32 iDWorkGroup, System.Int32 iDWorkGroupInternal, System.Int32 iDEmployee, System.Int32 iDEmployeeInternal, System.Int32 iDBonusLists, System.Int32 iDWageGroup, System.Byte shift, System.DateTime productionDate, System.DateTime shiftStart, System.DateTime shiftEnd, System.Int32 workBreak, System.Int32 downTime, System.Double handicap, System.Int32 attendanceTime, System.Int32 workingTime, System.Double incentiveWageTime, System.Double incentiveWageTimeAdj, System.Double degreeOfTime, System.Double degreeOfTimeAdj, System.Double referenceWageTimeProRata, System.Boolean insertedByInterface, System.Boolean manuallyEdited, System.Boolean isSuspended, System.DateTime lastEdited, System.Int32 editedByIDUser)
        {
            TimeLog timeLog = new TimeLog();
            timeLog.IDTimeLog = iDTimeLog;
            timeLog.IDSubsidiary = iDSubsidiary;
            timeLog.IDWorkGroup = iDWorkGroup;
            timeLog.IDWorkGroupInternal = iDWorkGroupInternal;
            timeLog.IDEmployee = iDEmployee;
            timeLog.IDEmployeeInternal = iDEmployeeInternal;
            timeLog.IDBonusLists = iDBonusLists;
            timeLog.IDWageGroup = iDWageGroup;
            timeLog.Shift = shift;
            timeLog.ProductionDate = productionDate;
            timeLog.ShiftStart = shiftStart;
            timeLog.ShiftEnd = shiftEnd;
            timeLog.WorkBreak = workBreak;
            timeLog.DownTime = downTime;
            timeLog.Handicap = handicap;
            timeLog.AttendanceTime = attendanceTime;
            timeLog.WorkingTime = workingTime;
            timeLog.IncentiveWageTime = incentiveWageTime;
            timeLog.IncentiveWageTimeAdj = incentiveWageTimeAdj;
            timeLog.DegreeOfTime = degreeOfTime;
            timeLog.DegreeOfTimeAdj = degreeOfTimeAdj;
            timeLog.ReferenceWageTimeProRata = referenceWageTimeProRata;
            timeLog.InsertedByInterface = insertedByInterface;
            timeLog.ManuallyEdited = manuallyEdited;
            timeLog.IsSuspended = isSuspended;
            timeLog.LastEdited = lastEdited;
            timeLog.EditedByIDUser = editedByIDUser;
            return timeLog;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 IDTimeLog
        {
            get
            {
                return _IDTimeLog;
            }

            set
            {
                if ((_IDTimeLog != value))
                {
                    OnIDTimeLogChanging(value);
                    ReportPropertyChanging("IDTimeLog");
                    _IDTimeLog = StructuralObject.SetValidValue(value, "IDTimeLog");
                    ReportPropertyChanged("IDTimeLog");
                    OnIDTimeLogChanged();
                }
            }
        }

        private System.Int64 _IDTimeLog;
        partial void OnIDTimeLogChanging(System.Int64 value);
        partial void OnIDTimeLogChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroup
        {
            get
            {
                return _IDWorkGroup;
            }

            set
            {
                OnIDWorkGroupChanging(value);
                ReportPropertyChanging("IDWorkGroup");
                _IDWorkGroup = StructuralObject.SetValidValue(value, "IDWorkGroup");
                ReportPropertyChanged("IDWorkGroup");
                OnIDWorkGroupChanged();
            }
        }

        private System.Int32 _IDWorkGroup;
        partial void OnIDWorkGroupChanging(System.Int32 value);
        partial void OnIDWorkGroupChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroupInternal
        {
            get
            {
                return _IDWorkGroupInternal;
            }

            set
            {
                OnIDWorkGroupInternalChanging(value);
                ReportPropertyChanging("IDWorkGroupInternal");
                _IDWorkGroupInternal = StructuralObject.SetValidValue(value, "IDWorkGroupInternal");
                ReportPropertyChanged("IDWorkGroupInternal");
                OnIDWorkGroupInternalChanged();
            }
        }

        private System.Int32 _IDWorkGroupInternal;
        partial void OnIDWorkGroupInternalChanging(System.Int32 value);
        partial void OnIDWorkGroupInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDEmployee
        {
            get
            {
                return _IDEmployee;
            }

            set
            {
                OnIDEmployeeChanging(value);
                ReportPropertyChanging("IDEmployee");
                _IDEmployee = StructuralObject.SetValidValue(value, "IDEmployee");
                ReportPropertyChanged("IDEmployee");
                OnIDEmployeeChanged();
            }
        }

        private System.Int32 _IDEmployee;
        partial void OnIDEmployeeChanging(System.Int32 value);
        partial void OnIDEmployeeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDEmployeeInternal
        {
            get
            {
                return _IDEmployeeInternal;
            }

            set
            {
                OnIDEmployeeInternalChanging(value);
                ReportPropertyChanging("IDEmployeeInternal");
                _IDEmployeeInternal = StructuralObject.SetValidValue(value, "IDEmployeeInternal");
                ReportPropertyChanged("IDEmployeeInternal");
                OnIDEmployeeInternalChanged();
            }
        }

        private System.Int32 _IDEmployeeInternal;
        partial void OnIDEmployeeInternalChanging(System.Int32 value);
        partial void OnIDEmployeeInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDBonusLists
        {
            get
            {
                return _IDBonusLists;
            }

            set
            {
                OnIDBonusListsChanging(value);
                ReportPropertyChanging("IDBonusLists");
                _IDBonusLists = StructuralObject.SetValidValue(value, "IDBonusLists");
                ReportPropertyChanged("IDBonusLists");
                OnIDBonusListsChanged();
            }
        }

        private System.Int32 _IDBonusLists;
        partial void OnIDBonusListsChanging(System.Int32 value);
        partial void OnIDBonusListsChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWageGroup
        {
            get
            {
                return _IDWageGroup;
            }

            set
            {
                OnIDWageGroupChanging(value);
                ReportPropertyChanging("IDWageGroup");
                _IDWageGroup = StructuralObject.SetValidValue(value, "IDWageGroup");
                ReportPropertyChanged("IDWageGroup");
                OnIDWageGroupChanged();
            }
        }

        private System.Int32 _IDWageGroup;
        partial void OnIDWageGroupChanging(System.Int32 value);
        partial void OnIDWageGroupChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Byte Shift
        {
            get
            {
                return _Shift;
            }

            set
            {
                OnShiftChanging(value);
                ReportPropertyChanging("Shift");
                _Shift = StructuralObject.SetValidValue(value, "Shift");
                ReportPropertyChanged("Shift");
                OnShiftChanged();
            }
        }

        private System.Byte _Shift;
        partial void OnShiftChanging(System.Byte value);
        partial void OnShiftChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ProductionDate
        {
            get
            {
                return _ProductionDate;
            }

            set
            {
                OnProductionDateChanging(value);
                ReportPropertyChanging("ProductionDate");
                _ProductionDate = StructuralObject.SetValidValue(value, "ProductionDate");
                ReportPropertyChanged("ProductionDate");
                OnProductionDateChanged();
            }
        }

        private System.DateTime _ProductionDate;
        partial void OnProductionDateChanging(System.DateTime value);
        partial void OnProductionDateChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ShiftStart
        {
            get
            {
                return _ShiftStart;
            }

            set
            {
                OnShiftStartChanging(value);
                ReportPropertyChanging("ShiftStart");
                _ShiftStart = StructuralObject.SetValidValue(value, "ShiftStart");
                ReportPropertyChanged("ShiftStart");
                OnShiftStartChanged();
            }
        }

        private System.DateTime _ShiftStart;
        partial void OnShiftStartChanging(System.DateTime value);
        partial void OnShiftStartChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> ShiftStartViaInterface
        {
            get
            {
                return _ShiftStartViaInterface;
            }

            set
            {
                OnShiftStartViaInterfaceChanging(value);
                ReportPropertyChanging("ShiftStartViaInterface");
                _ShiftStartViaInterface = StructuralObject.SetValidValue(value, "ShiftStartViaInterface");
                ReportPropertyChanged("ShiftStartViaInterface");
                OnShiftStartViaInterfaceChanged();
            }
        }

        private Nullable<System.DateTime> _ShiftStartViaInterface;
        partial void OnShiftStartViaInterfaceChanging(Nullable<System.DateTime> value);
        partial void OnShiftStartViaInterfaceChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ShiftEnd
        {
            get
            {
                return _ShiftEnd;
            }

            set
            {
                OnShiftEndChanging(value);
                ReportPropertyChanging("ShiftEnd");
                _ShiftEnd = StructuralObject.SetValidValue(value, "ShiftEnd");
                ReportPropertyChanged("ShiftEnd");
                OnShiftEndChanged();
            }
        }

        private System.DateTime _ShiftEnd;
        partial void OnShiftEndChanging(System.DateTime value);
        partial void OnShiftEndChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> ShiftEndViaInterface
        {
            get
            {
                return _ShiftEndViaInterface;
            }

            set
            {
                OnShiftEndViaInterfaceChanging(value);
                ReportPropertyChanging("ShiftEndViaInterface");
                _ShiftEndViaInterface = StructuralObject.SetValidValue(value, "ShiftEndViaInterface");
                ReportPropertyChanged("ShiftEndViaInterface");
                OnShiftEndViaInterfaceChanged();
            }
        }

        private Nullable<System.DateTime> _ShiftEndViaInterface;
        partial void OnShiftEndViaInterfaceChanging(Nullable<System.DateTime> value);
        partial void OnShiftEndViaInterfaceChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 WorkBreak
        {
            get
            {
                return _WorkBreak;
            }

            set
            {
                OnWorkBreakChanging(value);
                ReportPropertyChanging("WorkBreak");
                _WorkBreak = StructuralObject.SetValidValue(value, "WorkBreak");
                ReportPropertyChanged("WorkBreak");
                OnWorkBreakChanged();
            }
        }

        private System.Int32 _WorkBreak;
        partial void OnWorkBreakChanging(System.Int32 value);
        partial void OnWorkBreakChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.Int32> WorkBreakViaInterface
        {
            get
            {
                return _WorkBreakViaInterface;
            }

            set
            {
                OnWorkBreakViaInterfaceChanging(value);
                ReportPropertyChanging("WorkBreakViaInterface");
                _WorkBreakViaInterface = StructuralObject.SetValidValue(value, "WorkBreakViaInterface");
                ReportPropertyChanged("WorkBreakViaInterface");
                OnWorkBreakViaInterfaceChanged();
            }
        }

        private Nullable<System.Int32> _WorkBreakViaInterface;
        partial void OnWorkBreakViaInterfaceChanging(Nullable<System.Int32> value);
        partial void OnWorkBreakViaInterfaceChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 DownTime
        {
            get
            {
                return _DownTime;
            }

            set
            {
                OnDownTimeChanging(value);
                ReportPropertyChanging("DownTime");
                _DownTime = StructuralObject.SetValidValue(value, "DownTime");
                ReportPropertyChanged("DownTime");
                OnDownTimeChanged();
            }
        }

        private System.Int32 _DownTime;
        partial void OnDownTimeChanging(System.Int32 value);
        partial void OnDownTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.Int32> DownTimeViaInterface
        {
            get
            {
                return _DownTimeViaInterface;
            }

            set
            {
                OnDownTimeViaInterfaceChanging(value);
                ReportPropertyChanging("DownTimeViaInterface");
                _DownTimeViaInterface = StructuralObject.SetValidValue(value, "DownTimeViaInterface");
                ReportPropertyChanged("DownTimeViaInterface");
                OnDownTimeViaInterfaceChanged();
            }
        }

        private Nullable<System.Int32> _DownTimeViaInterface;
        partial void OnDownTimeViaInterfaceChanging(Nullable<System.Int32> value);
        partial void OnDownTimeViaInterfaceChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double Handicap
        {
            get
            {
                return _Handicap;
            }

            set
            {
                OnHandicapChanging(value);
                ReportPropertyChanging("Handicap");
                _Handicap = StructuralObject.SetValidValue(value, "Handicap");
                ReportPropertyChanged("Handicap");
                OnHandicapChanged();
            }
        }

        private System.Double _Handicap;
        partial void OnHandicapChanging(System.Double value);
        partial void OnHandicapChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 AttendanceTime
        {
            get
            {
                return _AttendanceTime;
            }

            set
            {
                OnAttendanceTimeChanging(value);
                ReportPropertyChanging("AttendanceTime");
                _AttendanceTime = StructuralObject.SetValidValue(value, "AttendanceTime");
                ReportPropertyChanged("AttendanceTime");
                OnAttendanceTimeChanged();
            }
        }

        private System.Int32 _AttendanceTime;
        partial void OnAttendanceTimeChanging(System.Int32 value);
        partial void OnAttendanceTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 WorkingTime
        {
            get
            {
                return _WorkingTime;
            }

            set
            {
                OnWorkingTimeChanging(value);
                ReportPropertyChanging("WorkingTime");
                _WorkingTime = StructuralObject.SetValidValue(value, "WorkingTime");
                ReportPropertyChanged("WorkingTime");
                OnWorkingTimeChanged();
            }
        }

        private System.Int32 _WorkingTime;
        partial void OnWorkingTimeChanging(System.Int32 value);
        partial void OnWorkingTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double IncentiveWageTime
        {
            get
            {
                return _IncentiveWageTime;
            }

            set
            {
                OnIncentiveWageTimeChanging(value);
                ReportPropertyChanging("IncentiveWageTime");
                _IncentiveWageTime = StructuralObject.SetValidValue(value, "IncentiveWageTime");
                ReportPropertyChanged("IncentiveWageTime");
                OnIncentiveWageTimeChanged();
            }
        }

        private System.Double _IncentiveWageTime;
        partial void OnIncentiveWageTimeChanging(System.Double value);
        partial void OnIncentiveWageTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double IncentiveWageTimeAdj
        {
            get
            {
                return _IncentiveWageTimeAdj;
            }

            set
            {
                OnIncentiveWageTimeAdjChanging(value);
                ReportPropertyChanging("IncentiveWageTimeAdj");
                _IncentiveWageTimeAdj = StructuralObject.SetValidValue(value, "IncentiveWageTimeAdj");
                ReportPropertyChanged("IncentiveWageTimeAdj");
                OnIncentiveWageTimeAdjChanged();
            }
        }

        private System.Double _IncentiveWageTimeAdj;
        partial void OnIncentiveWageTimeAdjChanging(System.Double value);
        partial void OnIncentiveWageTimeAdjChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double DegreeOfTime
        {
            get
            {
                return _DegreeOfTime;
            }

            set
            {
                OnDegreeOfTimeChanging(value);
                ReportPropertyChanging("DegreeOfTime");
                _DegreeOfTime = StructuralObject.SetValidValue(value, "DegreeOfTime");
                ReportPropertyChanged("DegreeOfTime");
                OnDegreeOfTimeChanged();
            }
        }

        private System.Double _DegreeOfTime;
        partial void OnDegreeOfTimeChanging(System.Double value);
        partial void OnDegreeOfTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double DegreeOfTimeAdj
        {
            get
            {
                return _DegreeOfTimeAdj;
            }

            set
            {
                OnDegreeOfTimeAdjChanging(value);
                ReportPropertyChanging("DegreeOfTimeAdj");
                _DegreeOfTimeAdj = StructuralObject.SetValidValue(value, "DegreeOfTimeAdj");
                ReportPropertyChanged("DegreeOfTimeAdj");
                OnDegreeOfTimeAdjChanged();
            }
        }

        private System.Double _DegreeOfTimeAdj;
        partial void OnDegreeOfTimeAdjChanging(System.Double value);
        partial void OnDegreeOfTimeAdjChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double ReferenceWageTimeProRata
        {
            get
            {
                return _ReferenceWageTimeProRata;
            }

            set
            {
                OnReferenceWageTimeProRataChanging(value);
                ReportPropertyChanging("ReferenceWageTimeProRata");
                _ReferenceWageTimeProRata = StructuralObject.SetValidValue(value, "ReferenceWageTimeProRata");
                ReportPropertyChanged("ReferenceWageTimeProRata");
                OnReferenceWageTimeProRataChanged();
            }
        }

        private System.Double _ReferenceWageTimeProRata;
        partial void OnReferenceWageTimeProRataChanging(System.Double value);
        partial void OnReferenceWageTimeProRataChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean InsertedByInterface
        {
            get
            {
                return _InsertedByInterface;
            }

            set
            {
                OnInsertedByInterfaceChanging(value);
                ReportPropertyChanging("InsertedByInterface");
                _InsertedByInterface = StructuralObject.SetValidValue(value, "InsertedByInterface");
                ReportPropertyChanged("InsertedByInterface");
                OnInsertedByInterfaceChanged();
            }
        }

        private System.Boolean _InsertedByInterface;
        partial void OnInsertedByInterfaceChanging(System.Boolean value);
        partial void OnInsertedByInterfaceChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean ManuallyEdited
        {
            get
            {
                return _ManuallyEdited;
            }

            set
            {
                OnManuallyEditedChanging(value);
                ReportPropertyChanging("ManuallyEdited");
                _ManuallyEdited = StructuralObject.SetValidValue(value, "ManuallyEdited");
                ReportPropertyChanged("ManuallyEdited");
                OnManuallyEditedChanged();
            }
        }

        private System.Boolean _ManuallyEdited;
        partial void OnManuallyEditedChanging(System.Boolean value);
        partial void OnManuallyEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsSuspended
        {
            get
            {
                return _IsSuspended;
            }

            set
            {
                OnIsSuspendedChanging(value);
                ReportPropertyChanging("IsSuspended");
                _IsSuspended = StructuralObject.SetValidValue(value, "IsSuspended");
                ReportPropertyChanged("IsSuspended");
                OnIsSuspendedChanged();
            }
        }

        private System.Boolean _IsSuspended;
        partial void OnIsSuspendedChanging(System.Boolean value);
        partial void OnIsSuspendedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 EditedByIDUser
        {
            get
            {
                return _EditedByIDUser;
            }

            set
            {
                OnEditedByIDUserChanging(value);
                ReportPropertyChanging("EditedByIDUser");
                _EditedByIDUser = StructuralObject.SetValidValue(value, "EditedByIDUser");
                ReportPropertyChanged("EditedByIDUser");
                OnEditedByIDUserChanged();
            }
        }

        private System.Int32 _EditedByIDUser;
        partial void OnEditedByIDUserChanging(System.Int32 value);
        partial void OnEditedByIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_TimeLog_Employee", "Employees")]
        public Employee Employee
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("FacessoModel.FK_TimeLog_Employee", "Employees").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("FacessoModel.FK_TimeLog_Employee", "Employees").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> EmployeeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("FacessoModel.FK_TimeLog_Employee", "Employees");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("FacessoModel.FK_TimeLog_Employee", "Employees", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_TimeLog_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_TimeLog_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_TimeLog_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_TimeLog_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_TimeLog_Subsidiaries", "Subsidiaries", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_TimeLog_WorkGroup", "WorkGroups")]
        public WorkGroup WorkGroup
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("FacessoModel.FK_TimeLog_WorkGroup", "WorkGroups").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("FacessoModel.FK_TimeLog_WorkGroup", "WorkGroups").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<WorkGroup> WorkGroupReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("FacessoModel.FK_TimeLog_WorkGroup", "WorkGroups");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<WorkGroup>("FacessoModel.FK_TimeLog_WorkGroup", "WorkGroups", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "TimeLogForInsert")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class TimeLogForInsert : EntityObject
    {
        /// <summary>
        /// Create a new TimeLogForInsert object.
        /// </summary>
        /// <param name = "iDTimeLogForInsert">Initial value of the IDTimeLogForInsert property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDTimeLog">Initial value of the IDTimeLog property.</param>
        /// <param name = "iDUser">Initial value of the IDUser property.</param>
        /// <param name = "iDWorkGroup">Initial value of the IDWorkGroup property.</param>
        /// <param name = "iDEmployee">Initial value of the IDEmployee property.</param>
        /// <param name = "shift">Initial value of the Shift property.</param>
        /// <param name = "productionDate">Initial value of the ProductionDate property.</param>
        /// <param name = "shiftStart">Initial value of the ShiftStart property.</param>
        /// <param name = "shiftEnd">Initial value of the ShiftEnd property.</param>
        /// <param name = "workBreak">Initial value of the WorkBreak property.</param>
        /// <param name = "downTime">Initial value of the DownTime property.</param>
        /// <param name = "handicap">Initial value of the Handicap property.</param>
        /// <param name = "insertedByInterface">Initial value of the InsertedByInterface property.</param>
        /// <param name = "manuallyEdited">Initial value of the ManuallyEdited property.</param>
        /// <param name = "editedByIDUser">Initial value of the EditedByIDUser property.</param>
        /// <param name = "deleted">Initial value of the Deleted property.</param>
        /// <param name = "ticket">Initial value of the Ticket property.</param>
        public static TimeLogForInsert CreateTimeLogForInsert(System.Int64 iDTimeLogForInsert, System.Int32 iDSubsidiary, System.Int64 iDTimeLog, System.Int32 iDUser, System.Int32 iDWorkGroup, System.Int32 iDEmployee, System.Byte shift, System.DateTime productionDate, System.DateTime shiftStart, System.DateTime shiftEnd, System.Int32 workBreak, System.Int32 downTime, System.Double handicap, System.Boolean insertedByInterface, System.Boolean manuallyEdited, System.Int32 editedByIDUser, System.Boolean deleted, System.DateTime ticket)
        {
            TimeLogForInsert timeLogForInsert = new TimeLogForInsert();
            timeLogForInsert.IDTimeLogForInsert = iDTimeLogForInsert;
            timeLogForInsert.IDSubsidiary = iDSubsidiary;
            timeLogForInsert.IDTimeLog = iDTimeLog;
            timeLogForInsert.IDUser = iDUser;
            timeLogForInsert.IDWorkGroup = iDWorkGroup;
            timeLogForInsert.IDEmployee = iDEmployee;
            timeLogForInsert.Shift = shift;
            timeLogForInsert.ProductionDate = productionDate;
            timeLogForInsert.ShiftStart = shiftStart;
            timeLogForInsert.ShiftEnd = shiftEnd;
            timeLogForInsert.WorkBreak = workBreak;
            timeLogForInsert.DownTime = downTime;
            timeLogForInsert.Handicap = handicap;
            timeLogForInsert.InsertedByInterface = insertedByInterface;
            timeLogForInsert.ManuallyEdited = manuallyEdited;
            timeLogForInsert.EditedByIDUser = editedByIDUser;
            timeLogForInsert.Deleted = deleted;
            timeLogForInsert.Ticket = ticket;
            return timeLogForInsert;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 IDTimeLogForInsert
        {
            get
            {
                return _IDTimeLogForInsert;
            }

            set
            {
                if ((_IDTimeLogForInsert != value))
                {
                    OnIDTimeLogForInsertChanging(value);
                    ReportPropertyChanging("IDTimeLogForInsert");
                    _IDTimeLogForInsert = StructuralObject.SetValidValue(value, "IDTimeLogForInsert");
                    ReportPropertyChanged("IDTimeLogForInsert");
                    OnIDTimeLogForInsertChanged();
                }
            }
        }

        private System.Int64 _IDTimeLogForInsert;
        partial void OnIDTimeLogForInsertChanging(System.Int64 value);
        partial void OnIDTimeLogForInsertChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 IDTimeLog
        {
            get
            {
                return _IDTimeLog;
            }

            set
            {
                OnIDTimeLogChanging(value);
                ReportPropertyChanging("IDTimeLog");
                _IDTimeLog = StructuralObject.SetValidValue(value, "IDTimeLog");
                ReportPropertyChanged("IDTimeLog");
                OnIDTimeLogChanged();
            }
        }

        private System.Int64 _IDTimeLog;
        partial void OnIDTimeLogChanging(System.Int64 value);
        partial void OnIDTimeLogChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDUser
        {
            get
            {
                return _IDUser;
            }

            set
            {
                OnIDUserChanging(value);
                ReportPropertyChanging("IDUser");
                _IDUser = StructuralObject.SetValidValue(value, "IDUser");
                ReportPropertyChanged("IDUser");
                OnIDUserChanged();
            }
        }

        private System.Int32 _IDUser;
        partial void OnIDUserChanging(System.Int32 value);
        partial void OnIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroup
        {
            get
            {
                return _IDWorkGroup;
            }

            set
            {
                OnIDWorkGroupChanging(value);
                ReportPropertyChanging("IDWorkGroup");
                _IDWorkGroup = StructuralObject.SetValidValue(value, "IDWorkGroup");
                ReportPropertyChanged("IDWorkGroup");
                OnIDWorkGroupChanged();
            }
        }

        private System.Int32 _IDWorkGroup;
        partial void OnIDWorkGroupChanging(System.Int32 value);
        partial void OnIDWorkGroupChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDEmployee
        {
            get
            {
                return _IDEmployee;
            }

            set
            {
                OnIDEmployeeChanging(value);
                ReportPropertyChanging("IDEmployee");
                _IDEmployee = StructuralObject.SetValidValue(value, "IDEmployee");
                ReportPropertyChanged("IDEmployee");
                OnIDEmployeeChanged();
            }
        }

        private System.Int32 _IDEmployee;
        partial void OnIDEmployeeChanging(System.Int32 value);
        partial void OnIDEmployeeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Byte Shift
        {
            get
            {
                return _Shift;
            }

            set
            {
                OnShiftChanging(value);
                ReportPropertyChanging("Shift");
                _Shift = StructuralObject.SetValidValue(value, "Shift");
                ReportPropertyChanged("Shift");
                OnShiftChanged();
            }
        }

        private System.Byte _Shift;
        partial void OnShiftChanging(System.Byte value);
        partial void OnShiftChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ProductionDate
        {
            get
            {
                return _ProductionDate;
            }

            set
            {
                OnProductionDateChanging(value);
                ReportPropertyChanging("ProductionDate");
                _ProductionDate = StructuralObject.SetValidValue(value, "ProductionDate");
                ReportPropertyChanged("ProductionDate");
                OnProductionDateChanged();
            }
        }

        private System.DateTime _ProductionDate;
        partial void OnProductionDateChanging(System.DateTime value);
        partial void OnProductionDateChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ShiftStart
        {
            get
            {
                return _ShiftStart;
            }

            set
            {
                OnShiftStartChanging(value);
                ReportPropertyChanging("ShiftStart");
                _ShiftStart = StructuralObject.SetValidValue(value, "ShiftStart");
                ReportPropertyChanged("ShiftStart");
                OnShiftStartChanged();
            }
        }

        private System.DateTime _ShiftStart;
        partial void OnShiftStartChanging(System.DateTime value);
        partial void OnShiftStartChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ShiftEnd
        {
            get
            {
                return _ShiftEnd;
            }

            set
            {
                OnShiftEndChanging(value);
                ReportPropertyChanging("ShiftEnd");
                _ShiftEnd = StructuralObject.SetValidValue(value, "ShiftEnd");
                ReportPropertyChanged("ShiftEnd");
                OnShiftEndChanged();
            }
        }

        private System.DateTime _ShiftEnd;
        partial void OnShiftEndChanging(System.DateTime value);
        partial void OnShiftEndChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 WorkBreak
        {
            get
            {
                return _WorkBreak;
            }

            set
            {
                OnWorkBreakChanging(value);
                ReportPropertyChanging("WorkBreak");
                _WorkBreak = StructuralObject.SetValidValue(value, "WorkBreak");
                ReportPropertyChanged("WorkBreak");
                OnWorkBreakChanged();
            }
        }

        private System.Int32 _WorkBreak;
        partial void OnWorkBreakChanging(System.Int32 value);
        partial void OnWorkBreakChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 DownTime
        {
            get
            {
                return _DownTime;
            }

            set
            {
                OnDownTimeChanging(value);
                ReportPropertyChanging("DownTime");
                _DownTime = StructuralObject.SetValidValue(value, "DownTime");
                ReportPropertyChanged("DownTime");
                OnDownTimeChanged();
            }
        }

        private System.Int32 _DownTime;
        partial void OnDownTimeChanging(System.Int32 value);
        partial void OnDownTimeChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double Handicap
        {
            get
            {
                return _Handicap;
            }

            set
            {
                OnHandicapChanging(value);
                ReportPropertyChanging("Handicap");
                _Handicap = StructuralObject.SetValidValue(value, "Handicap");
                ReportPropertyChanged("Handicap");
                OnHandicapChanged();
            }
        }

        private System.Double _Handicap;
        partial void OnHandicapChanging(System.Double value);
        partial void OnHandicapChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean InsertedByInterface
        {
            get
            {
                return _InsertedByInterface;
            }

            set
            {
                OnInsertedByInterfaceChanging(value);
                ReportPropertyChanging("InsertedByInterface");
                _InsertedByInterface = StructuralObject.SetValidValue(value, "InsertedByInterface");
                ReportPropertyChanged("InsertedByInterface");
                OnInsertedByInterfaceChanged();
            }
        }

        private System.Boolean _InsertedByInterface;
        partial void OnInsertedByInterfaceChanging(System.Boolean value);
        partial void OnInsertedByInterfaceChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean ManuallyEdited
        {
            get
            {
                return _ManuallyEdited;
            }

            set
            {
                OnManuallyEditedChanging(value);
                ReportPropertyChanging("ManuallyEdited");
                _ManuallyEdited = StructuralObject.SetValidValue(value, "ManuallyEdited");
                ReportPropertyChanged("ManuallyEdited");
                OnManuallyEditedChanged();
            }
        }

        private System.Boolean _ManuallyEdited;
        partial void OnManuallyEditedChanging(System.Boolean value);
        partial void OnManuallyEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 EditedByIDUser
        {
            get
            {
                return _EditedByIDUser;
            }

            set
            {
                OnEditedByIDUserChanging(value);
                ReportPropertyChanging("EditedByIDUser");
                _EditedByIDUser = StructuralObject.SetValidValue(value, "EditedByIDUser");
                ReportPropertyChanged("EditedByIDUser");
                OnEditedByIDUserChanged();
            }
        }

        private System.Int32 _EditedByIDUser;
        partial void OnEditedByIDUserChanging(System.Int32 value);
        partial void OnEditedByIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean Deleted
        {
            get
            {
                return _Deleted;
            }

            set
            {
                OnDeletedChanging(value);
                ReportPropertyChanging("Deleted");
                _Deleted = StructuralObject.SetValidValue(value, "Deleted");
                ReportPropertyChanged("Deleted");
                OnDeletedChanged();
            }
        }

        private System.Boolean _Deleted;
        partial void OnDeletedChanging(System.Boolean value);
        partial void OnDeletedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime Ticket
        {
            get
            {
                return _Ticket;
            }

            set
            {
                OnTicketChanging(value);
                ReportPropertyChanging("Ticket");
                _Ticket = StructuralObject.SetValidValue(value, "Ticket");
                ReportPropertyChanged("Ticket");
                OnTicketChanged();
            }
        }

        private System.DateTime _Ticket;
        partial void OnTicketChanging(System.DateTime value);
        partial void OnTicketChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_TimeLogForInsert_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_TimeLogForInsert_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_TimeLogForInsert_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_TimeLogForInsert_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_TimeLogForInsert_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "User")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class User : EntityObject
    {
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name = "iDUser">Initial value of the IDUser property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDUserInternal">Initial value of the IDUserInternal property.</param>
        /// <param name = "iDCostCenter">Initial value of the IDCostCenter property.</param>
        /// <param name = "firstName">Initial value of the FirstName property.</param>
        /// <param name = "lastName">Initial value of the LastName property.</param>
        /// <param name = "username">Initial value of the Username property.</param>
        /// <param name = "password">Initial value of the Password property.</param>
        /// <param name = "clearanceLevel">Initial value of the ClearanceLevel property.</param>
        /// <param name = "hasWorkstationAccess">Initial value of the HasWorkstationAccess property.</param>
        /// <param name = "hasInternetAccess">Initial value of the HasInternetAccess property.</param>
        /// <param name = "isActivated">Initial value of the IsActivated property.</param>
        /// <param name = "doesExpire">Initial value of the DoesExpire property.</param>
        /// <param name = "expireDate">Initial value of the ExpireDate property.</param>
        /// <param name = "isSystemAccount">Initial value of the IsSystemAccount property.</param>
        /// <param name = "wasCurrentFrom">Initial value of the WasCurrentFrom property.</param>
        /// <param name = "wasCurrentTo">Initial value of the WasCurrentTo property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static User CreateUser(System.Int32 iDUser, System.Int32 iDSubsidiary, System.Int32 iDUserInternal, System.Int32 iDCostCenter, System.String firstName, System.String lastName, System.String username, System.Byte[] password, System.Int64 clearanceLevel, System.Boolean hasWorkstationAccess, System.Boolean hasInternetAccess, System.Boolean isActivated, System.Boolean doesExpire, System.DateTime expireDate, System.Boolean isSystemAccount, System.DateTime wasCurrentFrom, System.DateTime wasCurrentTo, System.DateTime lastEdited)
        {
            User user = new User();
            user.IDUser = iDUser;
            user.IDSubsidiary = iDSubsidiary;
            user.IDUserInternal = iDUserInternal;
            user.IDCostCenter = iDCostCenter;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Username = username;
            user.Password = password;
            user.ClearanceLevel = clearanceLevel;
            user.HasWorkstationAccess = hasWorkstationAccess;
            user.HasInternetAccess = hasInternetAccess;
            user.IsActivated = isActivated;
            user.DoesExpire = doesExpire;
            user.ExpireDate = expireDate;
            user.IsSystemAccount = isSystemAccount;
            user.WasCurrentFrom = wasCurrentFrom;
            user.WasCurrentTo = wasCurrentTo;
            user.LastEdited = lastEdited;
            return user;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDUser
        {
            get
            {
                return _IDUser;
            }

            set
            {
                if ((_IDUser != value))
                {
                    OnIDUserChanging(value);
                    ReportPropertyChanging("IDUser");
                    _IDUser = StructuralObject.SetValidValue(value, "IDUser");
                    ReportPropertyChanged("IDUser");
                    OnIDUserChanged();
                }
            }
        }

        private System.Int32 _IDUser;
        partial void OnIDUserChanging(System.Int32 value);
        partial void OnIDUserChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDUserInternal
        {
            get
            {
                return _IDUserInternal;
            }

            set
            {
                OnIDUserInternalChanging(value);
                ReportPropertyChanging("IDUserInternal");
                _IDUserInternal = StructuralObject.SetValidValue(value, "IDUserInternal");
                ReportPropertyChanged("IDUserInternal");
                OnIDUserInternalChanged();
            }
        }

        private System.Int32 _IDUserInternal;
        partial void OnIDUserInternalChanging(System.Int32 value);
        partial void OnIDUserInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCostCenter
        {
            get
            {
                return _IDCostCenter;
            }

            set
            {
                OnIDCostCenterChanging(value);
                ReportPropertyChanging("IDCostCenter");
                _IDCostCenter = StructuralObject.SetValidValue(value, "IDCostCenter");
                ReportPropertyChanged("IDCostCenter");
                OnIDCostCenterChanged();
            }
        }

        private System.Int32 _IDCostCenter;
        partial void OnIDCostCenterChanging(System.Int32 value);
        partial void OnIDCostCenterChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false, "FirstName");
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }

        private System.String _FirstName;
        partial void OnFirstNameChanging(System.String value);
        partial void OnFirstNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String LastName
        {
            get
            {
                return _LastName;
            }

            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false, "LastName");
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }

        private System.String _LastName;
        partial void OnLastNameChanging(System.String value);
        partial void OnLastNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.Int32> IDAddressDetails
        {
            get
            {
                return _IDAddressDetails;
            }

            set
            {
                OnIDAddressDetailsChanging(value);
                ReportPropertyChanging("IDAddressDetails");
                _IDAddressDetails = StructuralObject.SetValidValue(value, "IDAddressDetails");
                ReportPropertyChanged("IDAddressDetails");
                OnIDAddressDetailsChanged();
            }
        }

        private Nullable<System.Int32> _IDAddressDetails;
        partial void OnIDAddressDetailsChanging(Nullable<System.Int32> value);
        partial void OnIDAddressDetailsChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String Username
        {
            get
            {
                return _Username;
            }

            set
            {
                OnUsernameChanging(value);
                ReportPropertyChanging("Username");
                _Username = StructuralObject.SetValidValue(value, false, "Username");
                ReportPropertyChanged("Username");
                OnUsernameChanged();
            }
        }

        private System.String _Username;
        partial void OnUsernameChanging(System.String value);
        partial void OnUsernameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Byte[] Password
        {
            get
            {
                return StructuralObject.GetValidValue(_Password);
            }

            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false, "Password");
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }

        private System.Byte[] _Password;
        partial void OnPasswordChanging(System.Byte[] value);
        partial void OnPasswordChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int64 ClearanceLevel
        {
            get
            {
                return _ClearanceLevel;
            }

            set
            {
                OnClearanceLevelChanging(value);
                ReportPropertyChanging("ClearanceLevel");
                _ClearanceLevel = StructuralObject.SetValidValue(value, "ClearanceLevel");
                ReportPropertyChanged("ClearanceLevel");
                OnClearanceLevelChanged();
            }
        }

        private System.Int64 _ClearanceLevel;
        partial void OnClearanceLevelChanging(System.Int64 value);
        partial void OnClearanceLevelChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean HasWorkstationAccess
        {
            get
            {
                return _HasWorkstationAccess;
            }

            set
            {
                OnHasWorkstationAccessChanging(value);
                ReportPropertyChanging("HasWorkstationAccess");
                _HasWorkstationAccess = StructuralObject.SetValidValue(value, "HasWorkstationAccess");
                ReportPropertyChanged("HasWorkstationAccess");
                OnHasWorkstationAccessChanged();
            }
        }

        private System.Boolean _HasWorkstationAccess;
        partial void OnHasWorkstationAccessChanging(System.Boolean value);
        partial void OnHasWorkstationAccessChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean HasInternetAccess
        {
            get
            {
                return _HasInternetAccess;
            }

            set
            {
                OnHasInternetAccessChanging(value);
                ReportPropertyChanging("HasInternetAccess");
                _HasInternetAccess = StructuralObject.SetValidValue(value, "HasInternetAccess");
                ReportPropertyChanged("HasInternetAccess");
                OnHasInternetAccessChanged();
            }
        }

        private System.Boolean _HasInternetAccess;
        partial void OnHasInternetAccessChanging(System.Boolean value);
        partial void OnHasInternetAccessChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsActivated
        {
            get
            {
                return _IsActivated;
            }

            set
            {
                OnIsActivatedChanging(value);
                ReportPropertyChanging("IsActivated");
                _IsActivated = StructuralObject.SetValidValue(value, "IsActivated");
                ReportPropertyChanged("IsActivated");
                OnIsActivatedChanged();
            }
        }

        private System.Boolean _IsActivated;
        partial void OnIsActivatedChanging(System.Boolean value);
        partial void OnIsActivatedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<System.Boolean> IsCurrent
        {
            get
            {
                return _IsCurrent;
            }

            set
            {
                OnIsCurrentChanging(value);
                ReportPropertyChanging("IsCurrent");
                _IsCurrent = StructuralObject.SetValidValue(value, "IsCurrent");
                ReportPropertyChanged("IsCurrent");
                OnIsCurrentChanged();
            }
        }

        private Nullable<System.Boolean> _IsCurrent;
        partial void OnIsCurrentChanging(Nullable<System.Boolean> value);
        partial void OnIsCurrentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean DoesExpire
        {
            get
            {
                return _DoesExpire;
            }

            set
            {
                OnDoesExpireChanging(value);
                ReportPropertyChanging("DoesExpire");
                _DoesExpire = StructuralObject.SetValidValue(value, "DoesExpire");
                ReportPropertyChanged("DoesExpire");
                OnDoesExpireChanged();
            }
        }

        private System.Boolean _DoesExpire;
        partial void OnDoesExpireChanging(System.Boolean value);
        partial void OnDoesExpireChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime ExpireDate
        {
            get
            {
                return _ExpireDate;
            }

            set
            {
                OnExpireDateChanging(value);
                ReportPropertyChanging("ExpireDate");
                _ExpireDate = StructuralObject.SetValidValue(value, "ExpireDate");
                ReportPropertyChanged("ExpireDate");
                OnExpireDateChanged();
            }
        }

        private System.DateTime _ExpireDate;
        partial void OnExpireDateChanging(System.DateTime value);
        partial void OnExpireDateChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsSystemAccount
        {
            get
            {
                return _IsSystemAccount;
            }

            set
            {
                OnIsSystemAccountChanging(value);
                ReportPropertyChanging("IsSystemAccount");
                _IsSystemAccount = StructuralObject.SetValidValue(value, "IsSystemAccount");
                ReportPropertyChanged("IsSystemAccount");
                OnIsSystemAccountChanged();
            }
        }

        private System.Boolean _IsSystemAccount;
        partial void OnIsSystemAccountChanging(System.Boolean value);
        partial void OnIsSystemAccountChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentFrom
        {
            get
            {
                return _WasCurrentFrom;
            }

            set
            {
                OnWasCurrentFromChanging(value);
                ReportPropertyChanging("WasCurrentFrom");
                _WasCurrentFrom = StructuralObject.SetValidValue(value, "WasCurrentFrom");
                ReportPropertyChanged("WasCurrentFrom");
                OnWasCurrentFromChanged();
            }
        }

        private System.DateTime _WasCurrentFrom;
        partial void OnWasCurrentFromChanging(System.DateTime value);
        partial void OnWasCurrentFromChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentTo
        {
            get
            {
                return _WasCurrentTo;
            }

            set
            {
                OnWasCurrentToChanging(value);
                ReportPropertyChanging("WasCurrentTo");
                _WasCurrentTo = StructuralObject.SetValidValue(value, "WasCurrentTo");
                ReportPropertyChanged("WasCurrentTo");
                OnWasCurrentToChanged();
            }
        }

        private System.DateTime _WasCurrentTo;
        partial void OnWasCurrentToChanging(System.DateTime value);
        partial void OnWasCurrentToChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Comment
        {
            get
            {
                return _Comment;
            }

            set
            {
                OnCommentChanging(value);
                ReportPropertyChanging("Comment");
                _Comment = StructuralObject.SetValidValue(value, true, "Comment");
                ReportPropertyChanged("Comment");
                OnCommentChanged();
            }
        }

        private System.String _Comment;
        partial void OnCommentChanging(System.String value);
        partial void OnCommentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Users_AddressDetails", "AddressDetails")]
        public AddressDetail AddressDetail
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AddressDetail>("FacessoModel.FK_Users_AddressDetails", "AddressDetails").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AddressDetail>("FacessoModel.FK_Users_AddressDetails", "AddressDetails").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AddressDetail> AddressDetailReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AddressDetail>("FacessoModel.FK_Users_AddressDetails", "AddressDetails");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AddressDetail>("FacessoModel.FK_Users_AddressDetails", "AddressDetails", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ApplicationSettings_Users", "ApplicationSettings")]
        public EntityCollection<ApplicationSetting> ApplicationSettings
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ApplicationSetting>("FacessoModel.FK_ApplicationSettings_Users", "ApplicationSettings");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ApplicationSetting>("FacessoModel.FK_ApplicationSettings_Users", "ApplicationSettings", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Users_CostCenters", "CostCenters")]
        public CostCenter CostCenter
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_Users_CostCenters", "CostCenters").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_Users_CostCenters", "CostCenters").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<CostCenter> CostCenterReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_Users_CostCenters", "CostCenters");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<CostCenter>("FacessoModel.FK_Users_CostCenters", "CostCenters", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_FunctionLog_Users", "FunctionLog")]
        public EntityCollection<FunctionLog> FunctionLogs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<FunctionLog>("FacessoModel.FK_FunctionLog_Users", "FunctionLog");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<FunctionLog>("FacessoModel.FK_FunctionLog_Users", "FunctionLog", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Users_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Users_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Users_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_Users_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_Users_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "WageGroup")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class WageGroup : EntityObject
    {
        /// <summary>
        /// Create a new WageGroup object.
        /// </summary>
        /// <param name = "iDWageGroup">Initial value of the IDWageGroup property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDWageGroupInternal">Initial value of the IDWageGroupInternal property.</param>
        /// <param name = "iDCurrency">Initial value of the IDCurrency property.</param>
        /// <param name = "isTemplate">Initial value of the IsTemplate property.</param>
        /// <param name = "wageGroupToken">Initial value of the WageGroupToken property.</param>
        /// <param name = "hourlyRate">Initial value of the HourlyRate property.</param>
        /// <param name = "wasCurrentFrom">Initial value of the WasCurrentFrom property.</param>
        /// <param name = "wasCurrentTo">Initial value of the WasCurrentTo property.</param>
        /// <param name = "isCurrent">Initial value of the IsCurrent property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static WageGroup CreateWageGroup(System.Int32 iDWageGroup, System.Int32 iDSubsidiary, System.Int32 iDWageGroupInternal, System.Int32 iDCurrency, System.Boolean isTemplate, System.String wageGroupToken, System.Decimal hourlyRate, System.DateTime wasCurrentFrom, System.DateTime wasCurrentTo, System.Boolean isCurrent, System.DateTime lastEdited)
        {
            WageGroup wageGroup = new WageGroup();
            wageGroup.IDWageGroup = iDWageGroup;
            wageGroup.IDSubsidiary = iDSubsidiary;
            wageGroup.IDWageGroupInternal = iDWageGroupInternal;
            wageGroup.IDCurrency = iDCurrency;
            wageGroup.IsTemplate = isTemplate;
            wageGroup.WageGroupToken = wageGroupToken;
            wageGroup.HourlyRate = hourlyRate;
            wageGroup.WasCurrentFrom = wasCurrentFrom;
            wageGroup.WasCurrentTo = wasCurrentTo;
            wageGroup.IsCurrent = isCurrent;
            wageGroup.LastEdited = lastEdited;
            return wageGroup;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWageGroup
        {
            get
            {
                return _IDWageGroup;
            }

            set
            {
                if ((_IDWageGroup != value))
                {
                    OnIDWageGroupChanging(value);
                    ReportPropertyChanging("IDWageGroup");
                    _IDWageGroup = StructuralObject.SetValidValue(value, "IDWageGroup");
                    ReportPropertyChanged("IDWageGroup");
                    OnIDWageGroupChanged();
                }
            }
        }

        private System.Int32 _IDWageGroup;
        partial void OnIDWageGroupChanging(System.Int32 value);
        partial void OnIDWageGroupChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWageGroupInternal
        {
            get
            {
                return _IDWageGroupInternal;
            }

            set
            {
                OnIDWageGroupInternalChanging(value);
                ReportPropertyChanging("IDWageGroupInternal");
                _IDWageGroupInternal = StructuralObject.SetValidValue(value, "IDWageGroupInternal");
                ReportPropertyChanged("IDWageGroupInternal");
                OnIDWageGroupInternalChanged();
            }
        }

        private System.Int32 _IDWageGroupInternal;
        partial void OnIDWageGroupInternalChanging(System.Int32 value);
        partial void OnIDWageGroupInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCurrency
        {
            get
            {
                return _IDCurrency;
            }

            set
            {
                OnIDCurrencyChanging(value);
                ReportPropertyChanging("IDCurrency");
                _IDCurrency = StructuralObject.SetValidValue(value, "IDCurrency");
                ReportPropertyChanged("IDCurrency");
                OnIDCurrencyChanged();
            }
        }

        private System.Int32 _IDCurrency;
        partial void OnIDCurrencyChanging(System.Int32 value);
        partial void OnIDCurrencyChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsTemplate
        {
            get
            {
                return _IsTemplate;
            }

            set
            {
                OnIsTemplateChanging(value);
                ReportPropertyChanging("IsTemplate");
                _IsTemplate = StructuralObject.SetValidValue(value, "IsTemplate");
                ReportPropertyChanged("IsTemplate");
                OnIsTemplateChanged();
            }
        }

        private System.Boolean _IsTemplate;
        partial void OnIsTemplateChanging(System.Boolean value);
        partial void OnIsTemplateChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String WageGroupToken
        {
            get
            {
                return _WageGroupToken;
            }

            set
            {
                OnWageGroupTokenChanging(value);
                ReportPropertyChanging("WageGroupToken");
                _WageGroupToken = StructuralObject.SetValidValue(value, false, "WageGroupToken");
                ReportPropertyChanged("WageGroupToken");
                OnWageGroupTokenChanged();
            }
        }

        private System.String _WageGroupToken;
        partial void OnWageGroupTokenChanging(System.String value);
        partial void OnWageGroupTokenChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String Comment
        {
            get
            {
                return _Comment;
            }

            set
            {
                OnCommentChanging(value);
                ReportPropertyChanging("Comment");
                _Comment = StructuralObject.SetValidValue(value, true, "Comment");
                ReportPropertyChanged("Comment");
                OnCommentChanged();
            }
        }

        private System.String _Comment;
        partial void OnCommentChanging(System.String value);
        partial void OnCommentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Decimal HourlyRate
        {
            get
            {
                return _HourlyRate;
            }

            set
            {
                OnHourlyRateChanging(value);
                ReportPropertyChanging("HourlyRate");
                _HourlyRate = StructuralObject.SetValidValue(value, "HourlyRate");
                ReportPropertyChanged("HourlyRate");
                OnHourlyRateChanged();
            }
        }

        private System.Decimal _HourlyRate;
        partial void OnHourlyRateChanging(System.Decimal value);
        partial void OnHourlyRateChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentFrom
        {
            get
            {
                return _WasCurrentFrom;
            }

            set
            {
                OnWasCurrentFromChanging(value);
                ReportPropertyChanging("WasCurrentFrom");
                _WasCurrentFrom = StructuralObject.SetValidValue(value, "WasCurrentFrom");
                ReportPropertyChanged("WasCurrentFrom");
                OnWasCurrentFromChanged();
            }
        }

        private System.DateTime _WasCurrentFrom;
        partial void OnWasCurrentFromChanging(System.DateTime value);
        partial void OnWasCurrentFromChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentTo
        {
            get
            {
                return _WasCurrentTo;
            }

            set
            {
                OnWasCurrentToChanging(value);
                ReportPropertyChanging("WasCurrentTo");
                _WasCurrentTo = StructuralObject.SetValidValue(value, "WasCurrentTo");
                ReportPropertyChanged("WasCurrentTo");
                OnWasCurrentToChanged();
            }
        }

        private System.DateTime _WasCurrentTo;
        partial void OnWasCurrentToChanging(System.DateTime value);
        partial void OnWasCurrentToChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsCurrent
        {
            get
            {
                return _IsCurrent;
            }

            set
            {
                OnIsCurrentChanging(value);
                ReportPropertyChanging("IsCurrent");
                _IsCurrent = StructuralObject.SetValidValue(value, "IsCurrent");
                ReportPropertyChanged("IsCurrent");
                OnIsCurrentChanged();
            }
        }

        private System.Boolean _IsCurrent;
        partial void OnIsCurrentChanging(System.Boolean value);
        partial void OnIsCurrentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WageGroups_Currencies", "Currencies")]
        public Currency Currency
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Currency>("FacessoModel.FK_WageGroups_Currencies", "Currencies").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Currency>("FacessoModel.FK_WageGroups_Currencies", "Currencies").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Currency> CurrencyReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Currency>("FacessoModel.FK_WageGroups_Currencies", "Currencies");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Currency>("FacessoModel.FK_WageGroups_Currencies", "Currencies", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_Employees_WageGroups", "Employees")]
        public EntityCollection<Employee> Employees
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("FacessoModel.FK_Employees_WageGroups", "Employees");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("FacessoModel.FK_Employees_WageGroups", "Employees", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WageGroups_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_WageGroups_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_WageGroups_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_WageGroups_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_WageGroups_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "WorkGroup")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class WorkGroup : EntityObject
    {
        /// <summary>
        /// Create a new WorkGroup object.
        /// </summary>
        /// <param name = "iDWorkGroup">Initial value of the IDWorkGroup property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDWorkGroupInternal">Initial value of the IDWorkGroupInternal property.</param>
        /// <param name = "iDCostCenter">Initial value of the IDCostCenter property.</param>
        /// <param name = "workGroupNumber">Initial value of the WorkGroupNumber property.</param>
        /// <param name = "workgroupName">Initial value of the WorkgroupName property.</param>
        /// <param name = "workloadIWT">Initial value of the WorkloadIWT property.</param>
        /// <param name = "isActive">Initial value of the IsActive property.</param>
        /// <param name = "isCurrent">Initial value of the IsCurrent property.</param>
        /// <param name = "isPeaceWork">Initial value of the IsPeaceWork property.</param>
        /// <param name = "isConceptional">Initial value of the IsConceptional property.</param>
        /// <param name = "ordinalNo">Initial value of the OrdinalNo property.</param>
        /// <param name = "timeSettingDetails">Initial value of the TimeSettingDetails property.</param>
        /// <param name = "wasCurrentFrom">Initial value of the WasCurrentFrom property.</param>
        /// <param name = "wasCurrentTo">Initial value of the WasCurrentTo property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static WorkGroup CreateWorkGroup(System.Int32 iDWorkGroup, System.Int32 iDSubsidiary, System.Int32 iDWorkGroupInternal, System.Int32 iDCostCenter, System.Int32 workGroupNumber, System.String workgroupName, System.Double workloadIWT, System.Boolean isActive, System.Boolean isCurrent, System.Boolean isPeaceWork, System.Boolean isConceptional, System.Int32 ordinalNo, System.String timeSettingDetails, System.DateTime wasCurrentFrom, System.DateTime wasCurrentTo, System.DateTime lastEdited)
        {
            WorkGroup workGroup = new WorkGroup();
            workGroup.IDWorkGroup = iDWorkGroup;
            workGroup.IDSubsidiary = iDSubsidiary;
            workGroup.IDWorkGroupInternal = iDWorkGroupInternal;
            workGroup.IDCostCenter = iDCostCenter;
            workGroup.WorkGroupNumber = workGroupNumber;
            workGroup.WorkgroupName = workgroupName;
            workGroup.WorkloadIWT = workloadIWT;
            workGroup.IsActive = isActive;
            workGroup.IsCurrent = isCurrent;
            workGroup.IsPeaceWork = isPeaceWork;
            workGroup.IsConceptional = isConceptional;
            workGroup.OrdinalNo = ordinalNo;
            workGroup.TimeSettingDetails = timeSettingDetails;
            workGroup.WasCurrentFrom = wasCurrentFrom;
            workGroup.WasCurrentTo = wasCurrentTo;
            workGroup.LastEdited = lastEdited;
            return workGroup;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroup
        {
            get
            {
                return _IDWorkGroup;
            }

            set
            {
                if ((_IDWorkGroup != value))
                {
                    OnIDWorkGroupChanging(value);
                    ReportPropertyChanging("IDWorkGroup");
                    _IDWorkGroup = StructuralObject.SetValidValue(value, "IDWorkGroup");
                    ReportPropertyChanged("IDWorkGroup");
                    OnIDWorkGroupChanged();
                }
            }
        }

        private System.Int32 _IDWorkGroup;
        partial void OnIDWorkGroupChanging(System.Int32 value);
        partial void OnIDWorkGroupChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroupInternal
        {
            get
            {
                return _IDWorkGroupInternal;
            }

            set
            {
                OnIDWorkGroupInternalChanging(value);
                ReportPropertyChanging("IDWorkGroupInternal");
                _IDWorkGroupInternal = StructuralObject.SetValidValue(value, "IDWorkGroupInternal");
                ReportPropertyChanged("IDWorkGroupInternal");
                OnIDWorkGroupInternalChanged();
            }
        }

        private System.Int32 _IDWorkGroupInternal;
        partial void OnIDWorkGroupInternalChanging(System.Int32 value);
        partial void OnIDWorkGroupInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDCostCenter
        {
            get
            {
                return _IDCostCenter;
            }

            set
            {
                OnIDCostCenterChanging(value);
                ReportPropertyChanging("IDCostCenter");
                _IDCostCenter = StructuralObject.SetValidValue(value, "IDCostCenter");
                ReportPropertyChanged("IDCostCenter");
                OnIDCostCenterChanged();
            }
        }

        private System.Int32 _IDCostCenter;
        partial void OnIDCostCenterChanging(System.Int32 value);
        partial void OnIDCostCenterChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 WorkGroupNumber
        {
            get
            {
                return _WorkGroupNumber;
            }

            set
            {
                OnWorkGroupNumberChanging(value);
                ReportPropertyChanging("WorkGroupNumber");
                _WorkGroupNumber = StructuralObject.SetValidValue(value, "WorkGroupNumber");
                ReportPropertyChanged("WorkGroupNumber");
                OnWorkGroupNumberChanged();
            }
        }

        private System.Int32 _WorkGroupNumber;
        partial void OnWorkGroupNumberChanging(System.Int32 value);
        partial void OnWorkGroupNumberChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String WorkgroupName
        {
            get
            {
                return _WorkgroupName;
            }

            set
            {
                OnWorkgroupNameChanging(value);
                ReportPropertyChanging("WorkgroupName");
                _WorkgroupName = StructuralObject.SetValidValue(value, false, "WorkgroupName");
                ReportPropertyChanged("WorkgroupName");
                OnWorkgroupNameChanged();
            }
        }

        private System.String _WorkgroupName;
        partial void OnWorkgroupNameChanging(System.String value);
        partial void OnWorkgroupNameChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public System.String WorkGroupDescription
        {
            get
            {
                return _WorkGroupDescription;
            }

            set
            {
                OnWorkGroupDescriptionChanging(value);
                ReportPropertyChanging("WorkGroupDescription");
                _WorkGroupDescription = StructuralObject.SetValidValue(value, true, "WorkGroupDescription");
                ReportPropertyChanged("WorkGroupDescription");
                OnWorkGroupDescriptionChanged();
            }
        }

        private System.String _WorkGroupDescription;
        partial void OnWorkGroupDescriptionChanging(System.String value);
        partial void OnWorkGroupDescriptionChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Double WorkloadIWT
        {
            get
            {
                return _WorkloadIWT;
            }

            set
            {
                OnWorkloadIWTChanging(value);
                ReportPropertyChanging("WorkloadIWT");
                _WorkloadIWT = StructuralObject.SetValidValue(value, "WorkloadIWT");
                ReportPropertyChanged("WorkloadIWT");
                OnWorkloadIWTChanged();
            }
        }

        private System.Double _WorkloadIWT;
        partial void OnWorkloadIWTChanging(System.Double value);
        partial void OnWorkloadIWTChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsActive
        {
            get
            {
                return _IsActive;
            }

            set
            {
                OnIsActiveChanging(value);
                ReportPropertyChanging("IsActive");
                _IsActive = StructuralObject.SetValidValue(value, "IsActive");
                ReportPropertyChanged("IsActive");
                OnIsActiveChanged();
            }
        }

        private System.Boolean _IsActive;
        partial void OnIsActiveChanging(System.Boolean value);
        partial void OnIsActiveChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsCurrent
        {
            get
            {
                return _IsCurrent;
            }

            set
            {
                OnIsCurrentChanging(value);
                ReportPropertyChanging("IsCurrent");
                _IsCurrent = StructuralObject.SetValidValue(value, "IsCurrent");
                ReportPropertyChanged("IsCurrent");
                OnIsCurrentChanged();
            }
        }

        private System.Boolean _IsCurrent;
        partial void OnIsCurrentChanging(System.Boolean value);
        partial void OnIsCurrentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsPeaceWork
        {
            get
            {
                return _IsPeaceWork;
            }

            set
            {
                OnIsPeaceWorkChanging(value);
                ReportPropertyChanging("IsPeaceWork");
                _IsPeaceWork = StructuralObject.SetValidValue(value, "IsPeaceWork");
                ReportPropertyChanged("IsPeaceWork");
                OnIsPeaceWorkChanged();
            }
        }

        private System.Boolean _IsPeaceWork;
        partial void OnIsPeaceWorkChanging(System.Boolean value);
        partial void OnIsPeaceWorkChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Boolean IsConceptional
        {
            get
            {
                return _IsConceptional;
            }

            set
            {
                OnIsConceptionalChanging(value);
                ReportPropertyChanging("IsConceptional");
                _IsConceptional = StructuralObject.SetValidValue(value, "IsConceptional");
                ReportPropertyChanged("IsConceptional");
                OnIsConceptionalChanged();
            }
        }

        private System.Boolean _IsConceptional;
        partial void OnIsConceptionalChanging(System.Boolean value);
        partial void OnIsConceptionalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 OrdinalNo
        {
            get
            {
                return _OrdinalNo;
            }

            set
            {
                OnOrdinalNoChanging(value);
                ReportPropertyChanging("OrdinalNo");
                _OrdinalNo = StructuralObject.SetValidValue(value, "OrdinalNo");
                ReportPropertyChanged("OrdinalNo");
                OnOrdinalNoChanged();
            }
        }

        private System.Int32 _OrdinalNo;
        partial void OnOrdinalNoChanging(System.Int32 value);
        partial void OnOrdinalNoChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.String TimeSettingDetails
        {
            get
            {
                return _TimeSettingDetails;
            }

            set
            {
                OnTimeSettingDetailsChanging(value);
                ReportPropertyChanging("TimeSettingDetails");
                _TimeSettingDetails = StructuralObject.SetValidValue(value, false, "TimeSettingDetails");
                ReportPropertyChanged("TimeSettingDetails");
                OnTimeSettingDetailsChanged();
            }
        }

        private System.String _TimeSettingDetails;
        partial void OnTimeSettingDetailsChanging(System.String value);
        partial void OnTimeSettingDetailsChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentFrom
        {
            get
            {
                return _WasCurrentFrom;
            }

            set
            {
                OnWasCurrentFromChanging(value);
                ReportPropertyChanging("WasCurrentFrom");
                _WasCurrentFrom = StructuralObject.SetValidValue(value, "WasCurrentFrom");
                ReportPropertyChanged("WasCurrentFrom");
                OnWasCurrentFromChanged();
            }
        }

        private System.DateTime _WasCurrentFrom;
        partial void OnWasCurrentFromChanging(System.DateTime value);
        partial void OnWasCurrentFromChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime WasCurrentTo
        {
            get
            {
                return _WasCurrentTo;
            }

            set
            {
                OnWasCurrentToChanging(value);
                ReportPropertyChanging("WasCurrentTo");
                _WasCurrentTo = StructuralObject.SetValidValue(value, "WasCurrentTo");
                ReportPropertyChanged("WasCurrentTo");
                OnWasCurrentToChanged();
            }
        }

        private System.DateTime _WasCurrentTo;
        partial void OnWasCurrentToChanging(System.DateTime value);
        partial void OnWasCurrentToChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WorkGroups_CostCenter", "CostCenters")]
        public CostCenter CostCenter
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_WorkGroups_CostCenter", "CostCenters").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_WorkGroups_CostCenter", "CostCenters").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<CostCenter> CostCenterReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CostCenter>("FacessoModel.FK_WorkGroups_CostCenter", "CostCenters");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<CostCenter>("FacessoModel.FK_WorkGroups_CostCenter", "CostCenters", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_ProductionData_WorkGroups", "ProductionData")]
        public EntityCollection<ProductionData> ProductionDatas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ProductionData>("FacessoModel.FK_ProductionData_WorkGroups", "ProductionData");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ProductionData>("FacessoModel.FK_ProductionData_WorkGroups", "ProductionData", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_SkillNeeded_WorkGroups", "SkillNeeded")]
        public EntityCollection<SkillNeeded> SkillNeededs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SkillNeeded>("FacessoModel.FK_SkillNeeded_WorkGroups", "SkillNeeded");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SkillNeeded>("FacessoModel.FK_SkillNeeded_WorkGroups", "SkillNeeded", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WorkGroups_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_WorkGroups_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_WorkGroups_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_WorkGroups_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_WorkGroups_Subsidiaries", "Subsidiaries", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_TimeLog_WorkGroup", "TimeLog")]
        public EntityCollection<TimeLog> TimeLogs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TimeLog>("FacessoModel.FK_TimeLog_WorkGroup", "TimeLog");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TimeLog>("FacessoModel.FK_TimeLog_WorkGroup", "TimeLog", value);
                }
            }
        }
    }

    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName = "FacessoModel", Name = "WorkGroupAssignment")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class WorkGroupAssignment : EntityObject
    {
        /// <summary>
        /// Create a new WorkGroupAssignment object.
        /// </summary>
        /// <param name = "iDWorkGroupAssignment">Initial value of the IDWorkGroupAssignment property.</param>
        /// <param name = "iDSubsidiary">Initial value of the IDSubsidiary property.</param>
        /// <param name = "iDLabourValueInternal">Initial value of the IDLabourValueInternal property.</param>
        /// <param name = "iDWorkGroupInternal">Initial value of the IDWorkGroupInternal property.</param>
        /// <param name = "ordinalNumber">Initial value of the OrdinalNumber property.</param>
        /// <param name = "lastEdited">Initial value of the LastEdited property.</param>
        public static WorkGroupAssignment CreateWorkGroupAssignment(System.Int32 iDWorkGroupAssignment, System.Int32 iDSubsidiary, System.Int32 iDLabourValueInternal, System.Int32 iDWorkGroupInternal, System.Int32 ordinalNumber, System.DateTime lastEdited)
        {
            WorkGroupAssignment workGroupAssignment = new WorkGroupAssignment();
            workGroupAssignment.IDWorkGroupAssignment = iDWorkGroupAssignment;
            workGroupAssignment.IDSubsidiary = iDSubsidiary;
            workGroupAssignment.IDLabourValueInternal = iDLabourValueInternal;
            workGroupAssignment.IDWorkGroupInternal = iDWorkGroupInternal;
            workGroupAssignment.OrdinalNumber = ordinalNumber;
            workGroupAssignment.LastEdited = lastEdited;
            return workGroupAssignment;
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroupAssignment
        {
            get
            {
                return _IDWorkGroupAssignment;
            }

            set
            {
                if ((_IDWorkGroupAssignment != value))
                {
                    OnIDWorkGroupAssignmentChanging(value);
                    ReportPropertyChanging("IDWorkGroupAssignment");
                    _IDWorkGroupAssignment = StructuralObject.SetValidValue(value, "IDWorkGroupAssignment");
                    ReportPropertyChanged("IDWorkGroupAssignment");
                    OnIDWorkGroupAssignmentChanged();
                }
            }
        }

        private System.Int32 _IDWorkGroupAssignment;
        partial void OnIDWorkGroupAssignmentChanging(System.Int32 value);
        partial void OnIDWorkGroupAssignmentChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDSubsidiary
        {
            get
            {
                return _IDSubsidiary;
            }

            set
            {
                if ((_IDSubsidiary != value))
                {
                    OnIDSubsidiaryChanging(value);
                    ReportPropertyChanging("IDSubsidiary");
                    _IDSubsidiary = StructuralObject.SetValidValue(value, "IDSubsidiary");
                    ReportPropertyChanged("IDSubsidiary");
                    OnIDSubsidiaryChanged();
                }
            }
        }

        private System.Int32 _IDSubsidiary;
        partial void OnIDSubsidiaryChanging(System.Int32 value);
        partial void OnIDSubsidiaryChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDLabourValueInternal
        {
            get
            {
                return _IDLabourValueInternal;
            }

            set
            {
                OnIDLabourValueInternalChanging(value);
                ReportPropertyChanging("IDLabourValueInternal");
                _IDLabourValueInternal = StructuralObject.SetValidValue(value, "IDLabourValueInternal");
                ReportPropertyChanged("IDLabourValueInternal");
                OnIDLabourValueInternalChanged();
            }
        }

        private System.Int32 _IDLabourValueInternal;
        partial void OnIDLabourValueInternalChanging(System.Int32 value);
        partial void OnIDLabourValueInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 IDWorkGroupInternal
        {
            get
            {
                return _IDWorkGroupInternal;
            }

            set
            {
                OnIDWorkGroupInternalChanging(value);
                ReportPropertyChanging("IDWorkGroupInternal");
                _IDWorkGroupInternal = StructuralObject.SetValidValue(value, "IDWorkGroupInternal");
                ReportPropertyChanged("IDWorkGroupInternal");
                OnIDWorkGroupInternalChanged();
            }
        }

        private System.Int32 _IDWorkGroupInternal;
        partial void OnIDWorkGroupInternalChanging(System.Int32 value);
        partial void OnIDWorkGroupInternalChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.Int32 OrdinalNumber
        {
            get
            {
                return _OrdinalNumber;
            }

            set
            {
                OnOrdinalNumberChanging(value);
                ReportPropertyChanging("OrdinalNumber");
                _OrdinalNumber = StructuralObject.SetValidValue(value, "OrdinalNumber");
                ReportPropertyChanged("OrdinalNumber");
                OnOrdinalNumberChanged();
            }
        }

        private System.Int32 _OrdinalNumber;
        partial void OnOrdinalNumberChanging(System.Int32 value);
        partial void OnOrdinalNumberChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public System.DateTime LastEdited
        {
            get
            {
                return _LastEdited;
            }

            set
            {
                OnLastEditedChanging(value);
                ReportPropertyChanging("LastEdited");
                _LastEdited = StructuralObject.SetValidValue(value, "LastEdited");
                ReportPropertyChanged("LastEdited");
                OnLastEditedChanged();
            }
        }

        private System.DateTime _LastEdited;
        partial void OnLastEditedChanging(System.DateTime value);
        partial void OnLastEditedChanged();
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("FacessoModel", "FK_WorkGroupAssignments_Subsidiaries", "Subsidiaries")]
        public Subsidiary Subsidiary
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_WorkGroupAssignments_Subsidiaries", "Subsidiaries").Value;
            }

            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_WorkGroupAssignments_Subsidiaries", "Subsidiaries").Value = value;
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Subsidiary> SubsidiaryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Subsidiary>("FacessoModel.FK_WorkGroupAssignments_Subsidiaries", "Subsidiaries");
            }

            set
            {
                if ((!(value == null)))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Subsidiary>("FacessoModel.FK_WorkGroupAssignments_Subsidiaries", "Subsidiaries", value);
                }
            }
        }
    }
}
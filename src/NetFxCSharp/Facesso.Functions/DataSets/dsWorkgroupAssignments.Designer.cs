using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions.dsWorkgroupAssignmentsTableAdapters
{
    /// <summary>
    ///Represents the connection and commands used to retrieve and save data.
    ///</summary>
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.ComponentModel.DataObjectAttribute(true)]
    [System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" + ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
    public partial class dtWorkGroupsTableAdapter : System.ComponentModel.Component
    {
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        private System.Data.SqlClient.SqlConnection _connection;
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public dtWorkGroupsTableAdapter() : base()
        {
            this.ClearBeforeFill = true;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private System.Data.SqlClient.SqlDataAdapter Adapter
        {
            get
            {
                if ((this._adapter == null))
                {
                    this.InitAdapter();
                }

                return this._adapter;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        internal System.Data.SqlClient.SqlConnection Connection
        {
            get
            {
                if ((this._connection == null))
                {
                    this.InitConnection();
                }

                return this._connection;
            }

            set
            {
                this._connection = value;
                if ((!((this.Adapter.InsertCommand) == null)))
                {
                    this.Adapter.InsertCommand.Connection = value;
                }

                if ((!((this.Adapter.DeleteCommand) == null)))
                {
                    this.Adapter.DeleteCommand.Connection = value;
                }

                if ((!((this.Adapter.UpdateCommand) == null)))
                {
                    this.Adapter.UpdateCommand.Connection = value;
                }

                int i = 0;
                while ((i < this.CommandCollection.Length))
                {
                    if ((!((this.CommandCollection[i]) == null)))
                    {
                        ((System.Data.SqlClient.SqlCommand)this.CommandCollection[i]).Connection = value;
                    }

                    i = (i + 1);
                }
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        protected System.Data.SqlClient.SqlCommand[] CommandCollection
        {
            get
            {
                if ((this._commandCollection == null))
                {
                    this.InitCommandCollection();
                }

                return this._commandCollection;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public bool ClearBeforeFill
        {
            get
            {
                return this._clearBeforeFill;
            }

            set
            {
                this._clearBeforeFill = value;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitAdapter()
        {
            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "dtWorkGroups";
            tableMapping.ColumnMappings.Add("IDWorkGroup", "IDWorkGroup");
            tableMapping.ColumnMappings.Add("IDSubsidiary", "IDSubsidiary");
            tableMapping.ColumnMappings.Add("IDWorkGroupInternal", "IDWorkGroupInternal");
            tableMapping.ColumnMappings.Add("IDCostCenter", "IDCostCenter");
            tableMapping.ColumnMappings.Add("WorkGroupNumber", "WorkGroupNumber");
            tableMapping.ColumnMappings.Add("WorkgroupName", "WorkgroupName");
            tableMapping.ColumnMappings.Add("WorkGroupDescription", "WorkGroupDescription");
            tableMapping.ColumnMappings.Add("WorkloadIWT", "WorkloadIWT");
            tableMapping.ColumnMappings.Add("IsActive", "IsActive");
            tableMapping.ColumnMappings.Add("IsCurrent", "IsCurrent");
            tableMapping.ColumnMappings.Add("IsPeaceWork", "IsPeaceWork");
            tableMapping.ColumnMappings.Add("IsConceptional", "IsConceptional");
            tableMapping.ColumnMappings.Add("OrdinalNo", "OrdinalNo");
            tableMapping.ColumnMappings.Add("TimeSettingDetails", "TimeSettingDetails");
            tableMapping.ColumnMappings.Add("WasCurrentFrom", "WasCurrentFrom");
            tableMapping.ColumnMappings.Add("WasCurrentTo", "WasCurrentTo");
            tableMapping.ColumnMappings.Add("LastEdited", "LastEdited");
            tableMapping.ColumnMappings.Add("IDCostCenterInternal", "IDCostCenterInternal");
            tableMapping.ColumnMappings.Add("CC_IsCurrent", "CC_IsCurrent");
            tableMapping.ColumnMappings.Add("CostCenterNo", "CostCenterNo");
            tableMapping.ColumnMappings.Add("CostCenterName", "CostCenterName");
            tableMapping.ColumnMappings.Add("CostCenterDescription", "CostCenterDescription");
            tableMapping.ColumnMappings.Add("IDCurrency", "IDCurrency");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorSynonym", "IncentiveIndicatorSynonym");
            tableMapping.ColumnMappings.Add("IncentiveWageSynonym", "IncentiveWageSynonym");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorDimension", "IncentiveIndicatorDimension");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorPrecision", "IncentiveIndicatorPrecision");
            tableMapping.ColumnMappings.Add("UseFixValuedBonus", "UseFixValuedBonus");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorFactor", "IncentiveIndicatorFactor");
            tableMapping.ColumnMappings.Add("BaseValuePrecision", "BaseValuePrecision");
            tableMapping.ColumnMappings.Add("BaseValueSynonym", "BaseValueSynonym");
            tableMapping.ColumnMappings.Add("CC_WasCurrentFrom", "CC_WasCurrentFrom");
            tableMapping.ColumnMappings.Add("CC_WasCurrentTo", "CC_WasCurrentTo");
            tableMapping.ColumnMappings.Add("CC_LastEdited", "CC_LastEdited");
            this._adapter.TableMappings.Add(tableMapping);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitConnection()
        {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = "Data Source=.;Initial Catalog=Facesso;Integrated Security=True";
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new System.Data.SqlClient.SqlCommand[1];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT     WorkGroups.IDWorkGroup, WorkGroups.IDSubsidiary, WorkGroups.IDWorkGrou" + "pInternal, WorkGroups.IDCostCenter, WorkGroups.WorkGroupNumber, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "              " + "        WorkGroups.WorkgroupName, WorkGroups.WorkGroupDescription, WorkGroups.Wo" + "rkloadIWT, WorkGroups.IsActive, WorkGroups.IsCurrent, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      Wo" + "rkGroups.IsPeaceWork, WorkGroups.IsConceptional, WorkGroups.OrdinalNo, WorkGroup" + "s.TimeSettingDetails, WorkGroups.WasCurrentFrom, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      WorkGro" + "ups.WasCurrentTo, WorkGroups.LastEdited, CostCenters.IDCostCenterInternal, CostC" + "enters.IsCurrent AS CC_IsCurrent, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.CostCenter" + "No, CostCenters.CostCenterName, CostCenters.CostCenterDescription, CostCenters.I" + "DCurrency, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.IncentiveIndicatorSynonym, CostCe" + "nters.IncentiveWageSynonym, CostCenters.IncentiveIndicatorDimension, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "         " + "             CostCenters.IncentiveIndicatorPrecision, CostCenters.UseFixValuedBo" + "nus, CostCenters.IncentiveIndicatorFactor, CostCenters.BaseValuePrecision, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "   " + "                   CostCenters.BaseValueSynonym, CostCenters.WasCurrentFrom AS C" + "C_WasCurrentFrom, CostCenters.WasCurrentTo AS CC_WasCurrentTo, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "               " + "       CostCenters.LastEdited AS CC_LastEdited" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "FROM         WorkGroups INNER JO" + "IN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters ON WorkGroups.IDSubsidiary = CostCenters.I" + "DSubsidiary AND WorkGroups.IDCostCenter = CostCenters.IDCostCenter" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "WHERE     (W" + "orkGroups.IDSubsidiary = @IDSubsidiary)" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "ORDER BY WorkGroups.WorkGroupNumber";
            this._commandCollection[0].CommandType = global::System.Data.CommandType.Text;
            this._commandCollection[0].Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDSubsidiary", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "IDSubsidiary", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int FillByIDSubsidiary(dsWorkgroupAssignments.dtWorkGroupsDataTable dataTable, int IDSubsidiary)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            this.Adapter.SelectCommand.Parameters[0].Value = ((int)IDSubsidiary);
            if ((this.ClearBeforeFill == true))
            {
                dataTable.Clear();
            }

            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Select, true)]
        public virtual dsWorkgroupAssignments.dtWorkGroupsDataTable GetDataByIDSubsidiary(int IDSubsidiary)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            this.Adapter.SelectCommand.Parameters[0].Value = ((int)IDSubsidiary);
            dsWorkgroupAssignments.dtWorkGroupsDataTable dataTable = new dsWorkgroupAssignments.dtWorkGroupsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }

    /// <summary>
    ///Represents the connection and commands used to retrieve and save data.
    ///</summary>
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.ComponentModel.DataObjectAttribute(true)]
    [System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" + ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
    public partial class dtLabourValuesToWorkGroupAssignmentsTableAdapter : System.ComponentModel.Component
    {
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        private System.Data.SqlClient.SqlConnection _connection;
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public dtLabourValuesToWorkGroupAssignmentsTableAdapter() : base()
        {
            this.ClearBeforeFill = true;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private System.Data.SqlClient.SqlDataAdapter Adapter
        {
            get
            {
                if ((this._adapter == null))
                {
                    this.InitAdapter();
                }

                return this._adapter;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        internal System.Data.SqlClient.SqlConnection Connection
        {
            get
            {
                if ((this._connection == null))
                {
                    this.InitConnection();
                }

                return this._connection;
            }

            set
            {
                this._connection = value;
                if ((!((this.Adapter.InsertCommand) == null)))
                {
                    this.Adapter.InsertCommand.Connection = value;
                }

                if ((!((this.Adapter.DeleteCommand) == null)))
                {
                    this.Adapter.DeleteCommand.Connection = value;
                }

                if ((!((this.Adapter.UpdateCommand) == null)))
                {
                    this.Adapter.UpdateCommand.Connection = value;
                }

                int i = 0;
                while ((i < this.CommandCollection.Length))
                {
                    if ((!((this.CommandCollection[i]) == null)))
                    {
                        ((System.Data.SqlClient.SqlCommand)this.CommandCollection[i]).Connection = value;
                    }

                    i = (i + 1);
                }
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        protected System.Data.SqlClient.SqlCommand[] CommandCollection
        {
            get
            {
                if ((this._commandCollection == null))
                {
                    this.InitCommandCollection();
                }

                return this._commandCollection;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public bool ClearBeforeFill
        {
            get
            {
                return this._clearBeforeFill;
            }

            set
            {
                this._clearBeforeFill = value;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitAdapter()
        {
            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "dtLabourValuesToWorkGroupAssignments";
            tableMapping.ColumnMappings.Add("IDWorkGroupAssignment", "IDWorkGroupAssignment");
            tableMapping.ColumnMappings.Add("IDSubsidiary", "IDSubsidiary");
            tableMapping.ColumnMappings.Add("IDLabourValueInternal", "IDLabourValueInternal");
            tableMapping.ColumnMappings.Add("IDWorkGroupInternal", "IDWorkGroupInternal");
            tableMapping.ColumnMappings.Add("OrdinalNumber", "OrdinalNumber");
            tableMapping.ColumnMappings.Add("LastEdited", "LastEdited");
            tableMapping.ColumnMappings.Add("LabourValueNumber", "LabourValueNumber");
            tableMapping.ColumnMappings.Add("IDCostCenter", "IDCostCenter");
            tableMapping.ColumnMappings.Add("LabourValueName", "LabourValueName");
            tableMapping.ColumnMappings.Add("LabourValueDescription", "LabourValueDescription");
            tableMapping.ColumnMappings.Add("TeHMin", "TeHMin");
            tableMapping.ColumnMappings.Add("Dimension", "Dimension");
            tableMapping.ColumnMappings.Add("IsActive", "IsActive");
            tableMapping.ColumnMappings.Add("IsCurrent", "IsCurrent");
            tableMapping.ColumnMappings.Add("CostCenterNo", "CostCenterNo");
            tableMapping.ColumnMappings.Add("CostCenterName", "CostCenterName");
            tableMapping.ColumnMappings.Add("CostCenterDescription", "CostCenterDescription");
            tableMapping.ColumnMappings.Add("IncentiveWageSynonym", "IncentiveWageSynonym");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorSynonym", "IncentiveIndicatorSynonym");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorDimension", "IncentiveIndicatorDimension");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorPrecision", "IncentiveIndicatorPrecision");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorFactor", "IncentiveIndicatorFactor");
            this._adapter.TableMappings.Add(tableMapping);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitConnection()
        {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = "Data Source=.;Initial Catalog=Facesso;Integrated Security=True";
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new System.Data.SqlClient.SqlCommand[1];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT     WorkGroupAssignments.IDWorkGroupAssignment, WorkGroupAssignments.IDSub" + "sidiary, WorkGroupAssignments.IDLabourValueInternal, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      Wor" + "kGroupAssignments.IDWorkGroupInternal, WorkGroupAssignments.OrdinalNumber, WorkG" + "roupAssignments.LastEdited, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourValues.LabourValueNumb" + "er, LabourValues.IDCostCenter, LabourValues.LabourValueName, LabourValues.Labour" + "ValueDescription, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourValues.TeHMin, LabourValues.Dime" + "nsion, LabourValues.IsActive, LabourValues.IsCurrent, CostCenters.CostCenterNo, " + "" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.CostCenterName, CostCenters.CostCenterDescri" + "ption, CostCenters.IncentiveWageSynonym, CostCenters.IncentiveIndicatorSynonym, " + "" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.IncentiveIndicatorDimension, CostCenters.Inc" + "entiveIndicatorPrecision, CostCenters.IncentiveIndicatorFactor" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "FROM         Wor" + "kGroupAssignments INNER JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourValues ON WorkGroupAss" + "ignments.IDSubsidiary = LabourValues.IDSubsidiary AND " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      Wo" + "rkGroupAssignments.IDLabourValueInternal = LabourValues.IDLabourValueInternal IN" + "NER JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters ON LabourValues.IDCostCenter = CostC" + "enters.IDCostCenter AND LabourValues.IDSubsidiary = CostCenters.IDSubsidiary" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "WH" + "ERE     (WorkGroupAssignments.IDSubsidiary = @IDSubsidiary)";
            this._commandCollection[0].CommandType = global::System.Data.CommandType.Text;
            this._commandCollection[0].Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDSubsidiary", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "IDSubsidiary", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int FillByIDSubsidiary(dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsDataTable dataTable, int IDSubsidiary)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            this.Adapter.SelectCommand.Parameters[0].Value = ((int)IDSubsidiary);
            if ((this.ClearBeforeFill == true))
            {
                dataTable.Clear();
            }

            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Select, true)]
        public virtual dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsDataTable GetDataByIDSubsidiary(int IDSubsidiary)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            this.Adapter.SelectCommand.Parameters[0].Value = ((int)IDSubsidiary);
            dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsDataTable dataTable = new dsWorkgroupAssignments.dtLabourValuesToWorkGroupAssignmentsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
    }
}

namespace Facesso.Functions
{
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [System.Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [System.Xml.Serialization.XmlRootAttribute("dsWorkgroupAssignments")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class dsWorkgroupAssignments : System.Data.DataSet
    {
        private dtWorkGroupsDataTable tabledtWorkGroups;
        private dtLabourValuesToWorkGroupAssignmentsDataTable tabledtLabourValuesToWorkGroupAssignments;
        private System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public dsWorkgroupAssignments() : base()
        {
            this.BeginInit();
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = this.SchemaChanged;
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        protected dsWorkgroupAssignments(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context, false)
        {
            if ((this.IsBinarySerialized(info, context) == true))
            {
                this.InitVars(false);
                System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = this.SchemaChanged;
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }

            string strSchema = ((string)info.GetValue("XmlSchema", typeof(string)));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema))
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((!((ds.Tables["dtWorkGroups"]) == null)))
                {
                    base.Tables.Add(new dtWorkGroupsDataTable(ds.Tables["dtWorkGroups"]));
                }

                if ((!((ds.Tables["dtLabourValuesToWorkGroupAssignments"]) == null)))
                {
                    base.Tables.Add(new dtLabourValuesToWorkGroupAssignmentsDataTable(ds.Tables["dtLabourValuesToWorkGroupAssignments"]));
                }

                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
            }

            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = this.SchemaChanged;
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public dtWorkGroupsDataTable dtWorkGroups
        {
            get
            {
                return this.tabledtWorkGroups;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public dtLabourValuesToWorkGroupAssignmentsDataTable dtLabourValuesToWorkGroupAssignments
        {
            get
            {
                return this.tabledtLabourValuesToWorkGroupAssignments;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(true)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }

            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        protected override void InitializeDerivedDataSet()
        {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public override System.Data.DataSet Clone()
        {
            dsWorkgroupAssignments cln = ((dsWorkgroupAssignments)base.Clone());
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        protected override void ReadXmlSerializable(System.Xml.XmlReader reader)
        {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema))
            {
                this.Reset();
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(reader);
                if ((!((ds.Tables["dtWorkGroups"]) == null)))
                {
                    base.Tables.Add(new dtWorkGroupsDataTable(ds.Tables["dtWorkGroups"]));
                }

                if ((!((ds.Tables["dtLabourValuesToWorkGroupAssignments"]) == null)))
                {
                    base.Tables.Add(new dtLabourValuesToWorkGroupAssignmentsDataTable(ds.Tables["dtLabourValuesToWorkGroupAssignments"]));
                }

                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.ReadXml(reader);
                this.InitVars();
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable()
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        internal void InitVars(bool initTable)
        {
            this.tabledtWorkGroups = ((dtWorkGroupsDataTable)base.Tables["dtWorkGroups"]);
            if ((initTable == true))
            {
                if ((!((this.tabledtWorkGroups) == null)))
                {
                    this.tabledtWorkGroups.InitVars();
                }
            }

            this.tabledtLabourValuesToWorkGroupAssignments = ((dtLabourValuesToWorkGroupAssignmentsDataTable)base.Tables["dtLabourValuesToWorkGroupAssignments"]);
            if ((initTable == true))
            {
                if ((!((this.tabledtLabourValuesToWorkGroupAssignments) == null)))
                {
                    this.tabledtLabourValuesToWorkGroupAssignments.InitVars();
                }
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitClass()
        {
            this.DataSetName = "dsWorkgroupAssignments";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/dsWorkgroupAssignments.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tabledtWorkGroups = new dtWorkGroupsDataTable();
            base.Tables.Add(this.tabledtWorkGroups);
            this.tabledtLabourValuesToWorkGroupAssignments = new dtLabourValuesToWorkGroupAssignmentsDataTable();
            base.Tables.Add(this.tabledtLabourValuesToWorkGroupAssignments);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private bool ShouldSerializedtWorkGroups()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private bool ShouldSerializedtLabourValuesToWorkGroupAssignments()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove))
            {
                this.InitVars();
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs)
        {
            dsWorkgroupAssignments ds = new dsWorkgroupAssignments();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace))
            {
                System.IO.MemoryStream s1 = new System.IO.MemoryStream();
                System.IO.MemoryStream s2 = new System.IO.MemoryStream();
                try
                {
                    System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator();
                    while (schemas.MoveNext())
                    {
                        schema = ((System.Xml.Schema.XmlSchema)schemas.Current);
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length))
                        {
                            s1.Position = 0;
                            s2.Position = 0;
                            while (((s1.Position != s1.Length) && (s1.ReadByte() == s2.ReadByte())))
                            {
                            }

                            if ((s1.Position == s1.Length))
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if ((!((s1) == null)))
                    {
                        s1.Close();
                    }

                    if ((!((s2) == null)))
                    {
                        s2.Close();
                    }
                }
            }

            xs.Add(dsSchema);
            return type;
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public delegate void dtWorkGroupsRowChangeEventHandler(object sender, dtWorkGroupsRowChangeEvent e);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public delegate void dtLabourValuesToWorkGroupAssignmentsRowChangeEventHandler(object sender, dtLabourValuesToWorkGroupAssignmentsRowChangeEvent e);
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class dtWorkGroupsDataTable : System.Data.TypedTableBase<dtWorkGroupsRow>
        {
            private System.Data.DataColumn columnIDWorkGroup;
            private System.Data.DataColumn columnIDSubsidiary;
            private System.Data.DataColumn columnIDWorkGroupInternal;
            private System.Data.DataColumn columnIDCostCenter;
            private System.Data.DataColumn columnWorkGroupNumber;
            private System.Data.DataColumn columnWorkgroupName;
            private System.Data.DataColumn columnWorkGroupDescription;
            private System.Data.DataColumn columnWorkloadIWT;
            private System.Data.DataColumn columnIsActive;
            private System.Data.DataColumn columnIsCurrent;
            private System.Data.DataColumn columnIsPeaceWork;
            private System.Data.DataColumn columnIsConceptional;
            private System.Data.DataColumn columnOrdinalNo;
            private System.Data.DataColumn columnTimeSettingDetails;
            private System.Data.DataColumn columnWasCurrentFrom;
            private System.Data.DataColumn columnWasCurrentTo;
            private System.Data.DataColumn columnLastEdited;
            private System.Data.DataColumn columnIDCostCenterInternal;
            private System.Data.DataColumn columnCC_IsCurrent;
            private System.Data.DataColumn columnCostCenterNo;
            private System.Data.DataColumn columnCostCenterName;
            private System.Data.DataColumn columnCostCenterDescription;
            private System.Data.DataColumn columnIDCurrency;
            private System.Data.DataColumn columnIncentiveIndicatorSynonym;
            private System.Data.DataColumn columnIncentiveWageSynonym;
            private System.Data.DataColumn columnIncentiveIndicatorDimension;
            private System.Data.DataColumn columnIncentiveIndicatorPrecision;
            private System.Data.DataColumn columnUseFixValuedBonus;
            private System.Data.DataColumn columnIncentiveIndicatorFactor;
            private System.Data.DataColumn columnBaseValuePrecision;
            private System.Data.DataColumn columnBaseValueSynonym;
            private System.Data.DataColumn columnCC_WasCurrentFrom;
            private System.Data.DataColumn columnCC_WasCurrentTo;
            private System.Data.DataColumn columnCC_LastEdited;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtWorkGroupsDataTable() : base()
            {
                this.TableName = "dtWorkGroups";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal dtWorkGroupsDataTable(System.Data.DataTable table) : base()
            {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive))
                {
                    this.CaseSensitive = table.CaseSensitive;
                }

                if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
                {
                    this.Locale = table.Locale;
                }

                if ((table.Namespace != table.DataSet.Namespace))
                {
                    this.Namespace = table.Namespace;
                }

                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected dtWorkGroupsDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDWorkGroupColumn
            {
                get
                {
                    return this.columnIDWorkGroup;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDSubsidiaryColumn
            {
                get
                {
                    return this.columnIDSubsidiary;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDWorkGroupInternalColumn
            {
                get
                {
                    return this.columnIDWorkGroupInternal;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDCostCenterColumn
            {
                get
                {
                    return this.columnIDCostCenter;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn WorkGroupNumberColumn
            {
                get
                {
                    return this.columnWorkGroupNumber;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn WorkgroupNameColumn
            {
                get
                {
                    return this.columnWorkgroupName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn WorkGroupDescriptionColumn
            {
                get
                {
                    return this.columnWorkGroupDescription;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn WorkloadIWTColumn
            {
                get
                {
                    return this.columnWorkloadIWT;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IsActiveColumn
            {
                get
                {
                    return this.columnIsActive;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IsCurrentColumn
            {
                get
                {
                    return this.columnIsCurrent;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IsPeaceWorkColumn
            {
                get
                {
                    return this.columnIsPeaceWork;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IsConceptionalColumn
            {
                get
                {
                    return this.columnIsConceptional;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn OrdinalNoColumn
            {
                get
                {
                    return this.columnOrdinalNo;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn TimeSettingDetailsColumn
            {
                get
                {
                    return this.columnTimeSettingDetails;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn WasCurrentFromColumn
            {
                get
                {
                    return this.columnWasCurrentFrom;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn WasCurrentToColumn
            {
                get
                {
                    return this.columnWasCurrentTo;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn LastEditedColumn
            {
                get
                {
                    return this.columnLastEdited;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDCostCenterInternalColumn
            {
                get
                {
                    return this.columnIDCostCenterInternal;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CC_IsCurrentColumn
            {
                get
                {
                    return this.columnCC_IsCurrent;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CostCenterNoColumn
            {
                get
                {
                    return this.columnCostCenterNo;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CostCenterNameColumn
            {
                get
                {
                    return this.columnCostCenterName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CostCenterDescriptionColumn
            {
                get
                {
                    return this.columnCostCenterDescription;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDCurrencyColumn
            {
                get
                {
                    return this.columnIDCurrency;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveIndicatorSynonymColumn
            {
                get
                {
                    return this.columnIncentiveIndicatorSynonym;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveWageSynonymColumn
            {
                get
                {
                    return this.columnIncentiveWageSynonym;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveIndicatorDimensionColumn
            {
                get
                {
                    return this.columnIncentiveIndicatorDimension;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveIndicatorPrecisionColumn
            {
                get
                {
                    return this.columnIncentiveIndicatorPrecision;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn UseFixValuedBonusColumn
            {
                get
                {
                    return this.columnUseFixValuedBonus;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveIndicatorFactorColumn
            {
                get
                {
                    return this.columnIncentiveIndicatorFactor;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn BaseValuePrecisionColumn
            {
                get
                {
                    return this.columnBaseValuePrecision;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn BaseValueSynonymColumn
            {
                get
                {
                    return this.columnBaseValueSynonym;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CC_WasCurrentFromColumn
            {
                get
                {
                    return this.columnCC_WasCurrentFrom;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CC_WasCurrentToColumn
            {
                get
                {
                    return this.columnCC_WasCurrentTo;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CC_LastEditedColumn
            {
                get
                {
                    return this.columnCC_LastEdited;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtWorkGroupsRow this[int index]
            {
                get
                {
                    return ((dtWorkGroupsRow)this.Rows[index]);
                }
            }

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtWorkGroupsRowChangeEventHandler dtWorkGroupsRowChanging;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtWorkGroupsRowChangeEventHandler dtWorkGroupsRowChanged;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtWorkGroupsRowChangeEventHandler dtWorkGroupsRowDeleting;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtWorkGroupsRowChangeEventHandler dtWorkGroupsRowDeleted;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void AdddtWorkGroupsRow(dtWorkGroupsRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtWorkGroupsRow AdddtWorkGroupsRow(int IDSubsidiary, int IDWorkGroupInternal, int IDCostCenter, int WorkGroupNumber, string WorkgroupName, string WorkGroupDescription, double WorkloadIWT, bool IsActive, bool IsCurrent, bool IsPeaceWork, bool IsConceptional, int OrdinalNo, string TimeSettingDetails, System.DateTime WasCurrentFrom, System.DateTime WasCurrentTo, System.DateTime LastEdited, int IDCostCenterInternal, bool CC_IsCurrent, int CostCenterNo, string CostCenterName, string CostCenterDescription, int IDCurrency, string IncentiveIndicatorSynonym, string IncentiveWageSynonym, string IncentiveIndicatorDimension, byte IncentiveIndicatorPrecision, bool UseFixValuedBonus, double IncentiveIndicatorFactor, byte BaseValuePrecision, string BaseValueSynonym, System.DateTime CC_WasCurrentFrom, System.DateTime CC_WasCurrentTo, System.DateTime CC_LastEdited)
            {
                dtWorkGroupsRow rowdtWorkGroupsRow = ((dtWorkGroupsRow)this.NewRow());
                object[] columnValuesArray = new object[]
                {
                    null,
                    IDSubsidiary,
                    IDWorkGroupInternal,
                    IDCostCenter,
                    WorkGroupNumber,
                    WorkgroupName,
                    WorkGroupDescription,
                    WorkloadIWT,
                    IsActive,
                    IsCurrent,
                    IsPeaceWork,
                    IsConceptional,
                    OrdinalNo,
                    TimeSettingDetails,
                    WasCurrentFrom,
                    WasCurrentTo,
                    LastEdited,
                    IDCostCenterInternal,
                    CC_IsCurrent,
                    CostCenterNo,
                    CostCenterName,
                    CostCenterDescription,
                    IDCurrency,
                    IncentiveIndicatorSynonym,
                    IncentiveWageSynonym,
                    IncentiveIndicatorDimension,
                    IncentiveIndicatorPrecision,
                    UseFixValuedBonus,
                    IncentiveIndicatorFactor,
                    BaseValuePrecision,
                    BaseValueSynonym,
                    CC_WasCurrentFrom,
                    CC_WasCurrentTo,
                    CC_LastEdited
                };
                rowdtWorkGroupsRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowdtWorkGroupsRow);
                return rowdtWorkGroupsRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtWorkGroupsRow FindByIDWorkGroupIDSubsidiary(int IDWorkGroup, int IDSubsidiary)
            {
                return ((dtWorkGroupsRow)this.Rows.Find(new object[] { IDWorkGroup, IDSubsidiary }));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public override System.Data.DataTable Clone()
            {
                dtWorkGroupsDataTable cln = ((dtWorkGroupsDataTable)base.Clone());
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataTable CreateInstance()
            {
                return new dtWorkGroupsDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal void InitVars()
            {
                this.columnIDWorkGroup = base.Columns["IDWorkGroup"];
                this.columnIDSubsidiary = base.Columns["IDSubsidiary"];
                this.columnIDWorkGroupInternal = base.Columns["IDWorkGroupInternal"];
                this.columnIDCostCenter = base.Columns["IDCostCenter"];
                this.columnWorkGroupNumber = base.Columns["WorkGroupNumber"];
                this.columnWorkgroupName = base.Columns["WorkgroupName"];
                this.columnWorkGroupDescription = base.Columns["WorkGroupDescription"];
                this.columnWorkloadIWT = base.Columns["WorkloadIWT"];
                this.columnIsActive = base.Columns["IsActive"];
                this.columnIsCurrent = base.Columns["IsCurrent"];
                this.columnIsPeaceWork = base.Columns["IsPeaceWork"];
                this.columnIsConceptional = base.Columns["IsConceptional"];
                this.columnOrdinalNo = base.Columns["OrdinalNo"];
                this.columnTimeSettingDetails = base.Columns["TimeSettingDetails"];
                this.columnWasCurrentFrom = base.Columns["WasCurrentFrom"];
                this.columnWasCurrentTo = base.Columns["WasCurrentTo"];
                this.columnLastEdited = base.Columns["LastEdited"];
                this.columnIDCostCenterInternal = base.Columns["IDCostCenterInternal"];
                this.columnCC_IsCurrent = base.Columns["CC_IsCurrent"];
                this.columnCostCenterNo = base.Columns["CostCenterNo"];
                this.columnCostCenterName = base.Columns["CostCenterName"];
                this.columnCostCenterDescription = base.Columns["CostCenterDescription"];
                this.columnIDCurrency = base.Columns["IDCurrency"];
                this.columnIncentiveIndicatorSynonym = base.Columns["IncentiveIndicatorSynonym"];
                this.columnIncentiveWageSynonym = base.Columns["IncentiveWageSynonym"];
                this.columnIncentiveIndicatorDimension = base.Columns["IncentiveIndicatorDimension"];
                this.columnIncentiveIndicatorPrecision = base.Columns["IncentiveIndicatorPrecision"];
                this.columnUseFixValuedBonus = base.Columns["UseFixValuedBonus"];
                this.columnIncentiveIndicatorFactor = base.Columns["IncentiveIndicatorFactor"];
                this.columnBaseValuePrecision = base.Columns["BaseValuePrecision"];
                this.columnBaseValueSynonym = base.Columns["BaseValueSynonym"];
                this.columnCC_WasCurrentFrom = base.Columns["CC_WasCurrentFrom"];
                this.columnCC_WasCurrentTo = base.Columns["CC_WasCurrentTo"];
                this.columnCC_LastEdited = base.Columns["CC_LastEdited"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            private void InitClass()
            {
                this.columnIDWorkGroup = new System.Data.DataColumn("IDWorkGroup", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDWorkGroup);
                this.columnIDSubsidiary = new System.Data.DataColumn("IDSubsidiary", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDSubsidiary);
                this.columnIDWorkGroupInternal = new System.Data.DataColumn("IDWorkGroupInternal", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDWorkGroupInternal);
                this.columnIDCostCenter = new System.Data.DataColumn("IDCostCenter", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDCostCenter);
                this.columnWorkGroupNumber = new System.Data.DataColumn("WorkGroupNumber", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkGroupNumber);
                this.columnWorkgroupName = new System.Data.DataColumn("WorkgroupName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkgroupName);
                this.columnWorkGroupDescription = new System.Data.DataColumn("WorkGroupDescription", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkGroupDescription);
                this.columnWorkloadIWT = new System.Data.DataColumn("WorkloadIWT", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkloadIWT);
                this.columnIsActive = new System.Data.DataColumn("IsActive", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsActive);
                this.columnIsCurrent = new System.Data.DataColumn("IsCurrent", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsCurrent);
                this.columnIsPeaceWork = new System.Data.DataColumn("IsPeaceWork", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsPeaceWork);
                this.columnIsConceptional = new System.Data.DataColumn("IsConceptional", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsConceptional);
                this.columnOrdinalNo = new System.Data.DataColumn("OrdinalNo", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnOrdinalNo);
                this.columnTimeSettingDetails = new System.Data.DataColumn("TimeSettingDetails", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTimeSettingDetails);
                this.columnWasCurrentFrom = new System.Data.DataColumn("WasCurrentFrom", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWasCurrentFrom);
                this.columnWasCurrentTo = new System.Data.DataColumn("WasCurrentTo", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWasCurrentTo);
                this.columnLastEdited = new System.Data.DataColumn("LastEdited", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLastEdited);
                this.columnIDCostCenterInternal = new System.Data.DataColumn("IDCostCenterInternal", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDCostCenterInternal);
                this.columnCC_IsCurrent = new System.Data.DataColumn("CC_IsCurrent", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCC_IsCurrent);
                this.columnCostCenterNo = new System.Data.DataColumn("CostCenterNo", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterNo);
                this.columnCostCenterName = new System.Data.DataColumn("CostCenterName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterName);
                this.columnCostCenterDescription = new System.Data.DataColumn("CostCenterDescription", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterDescription);
                this.columnIDCurrency = new System.Data.DataColumn("IDCurrency", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDCurrency);
                this.columnIncentiveIndicatorSynonym = new System.Data.DataColumn("IncentiveIndicatorSynonym", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorSynonym);
                this.columnIncentiveWageSynonym = new System.Data.DataColumn("IncentiveWageSynonym", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveWageSynonym);
                this.columnIncentiveIndicatorDimension = new System.Data.DataColumn("IncentiveIndicatorDimension", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorDimension);
                this.columnIncentiveIndicatorPrecision = new System.Data.DataColumn("IncentiveIndicatorPrecision", typeof(byte), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorPrecision);
                this.columnUseFixValuedBonus = new System.Data.DataColumn("UseFixValuedBonus", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnUseFixValuedBonus);
                this.columnIncentiveIndicatorFactor = new System.Data.DataColumn("IncentiveIndicatorFactor", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorFactor);
                this.columnBaseValuePrecision = new System.Data.DataColumn("BaseValuePrecision", typeof(byte), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnBaseValuePrecision);
                this.columnBaseValueSynonym = new System.Data.DataColumn("BaseValueSynonym", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnBaseValueSynonym);
                this.columnCC_WasCurrentFrom = new System.Data.DataColumn("CC_WasCurrentFrom", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCC_WasCurrentFrom);
                this.columnCC_WasCurrentTo = new System.Data.DataColumn("CC_WasCurrentTo", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCC_WasCurrentTo);
                this.columnCC_LastEdited = new System.Data.DataColumn("CC_LastEdited", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCC_LastEdited);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] { this.columnIDWorkGroup, this.columnIDSubsidiary }, true));
                this.columnIDWorkGroup.AutoIncrement = true;
                this.columnIDWorkGroup.AllowDBNull = false;
                this.columnIDWorkGroup.ReadOnly = true;
                this.columnIDSubsidiary.AllowDBNull = false;
                this.columnIDWorkGroupInternal.AllowDBNull = false;
                this.columnIDCostCenter.AllowDBNull = false;
                this.columnWorkGroupNumber.AllowDBNull = false;
                this.columnWorkgroupName.AllowDBNull = false;
                this.columnWorkgroupName.MaxLength = 100;
                this.columnWorkGroupDescription.MaxLength = 4000;
                this.columnWorkloadIWT.AllowDBNull = false;
                this.columnIsActive.AllowDBNull = false;
                this.columnIsCurrent.AllowDBNull = false;
                this.columnIsPeaceWork.AllowDBNull = false;
                this.columnIsConceptional.AllowDBNull = false;
                this.columnOrdinalNo.AllowDBNull = false;
                this.columnTimeSettingDetails.AllowDBNull = false;
                this.columnTimeSettingDetails.MaxLength = 2147483647;
                this.columnWasCurrentFrom.AllowDBNull = false;
                this.columnWasCurrentTo.AllowDBNull = false;
                this.columnLastEdited.AllowDBNull = false;
                this.columnIDCostCenterInternal.AllowDBNull = false;
                this.columnCC_IsCurrent.AllowDBNull = false;
                this.columnCostCenterNo.AllowDBNull = false;
                this.columnCostCenterName.AllowDBNull = false;
                this.columnCostCenterName.MaxLength = 100;
                this.columnCostCenterDescription.MaxLength = 4000;
                this.columnIDCurrency.AllowDBNull = false;
                this.columnIncentiveIndicatorSynonym.AllowDBNull = false;
                this.columnIncentiveIndicatorSynonym.MaxLength = 50;
                this.columnIncentiveWageSynonym.AllowDBNull = false;
                this.columnIncentiveWageSynonym.MaxLength = 50;
                this.columnIncentiveIndicatorDimension.AllowDBNull = false;
                this.columnIncentiveIndicatorDimension.MaxLength = 10;
                this.columnIncentiveIndicatorPrecision.AllowDBNull = false;
                this.columnUseFixValuedBonus.AllowDBNull = false;
                this.columnIncentiveIndicatorFactor.AllowDBNull = false;
                this.columnBaseValuePrecision.AllowDBNull = false;
                this.columnBaseValueSynonym.AllowDBNull = false;
                this.columnBaseValueSynonym.MaxLength = 50;
                this.columnCC_WasCurrentFrom.AllowDBNull = false;
                this.columnCC_WasCurrentTo.AllowDBNull = false;
                this.columnCC_LastEdited.AllowDBNull = false;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtWorkGroupsRow NewdtWorkGroupsRow()
            {
                return ((dtWorkGroupsRow)this.NewRow());
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new dtWorkGroupsRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Type GetRowType()
            {
                return typeof(dtWorkGroupsRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((!((this.dtWorkGroupsRowChanged) == null)))
                {
                    dtWorkGroupsRowChanged?.Invoke(this, new dtWorkGroupsRowChangeEvent(((dtWorkGroupsRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((!((this.dtWorkGroupsRowChanging) == null)))
                {
                    dtWorkGroupsRowChanging?.Invoke(this, new dtWorkGroupsRowChangeEvent(((dtWorkGroupsRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((!((this.dtWorkGroupsRowDeleted) == null)))
                {
                    dtWorkGroupsRowDeleted?.Invoke(this, new dtWorkGroupsRowChangeEvent(((dtWorkGroupsRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((!((this.dtWorkGroupsRowDeleting) == null)))
                {
                    dtWorkGroupsRowDeleting?.Invoke(this, new dtWorkGroupsRowChangeEvent(((dtWorkGroupsRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void RemovedtWorkGroupsRow(dtWorkGroupsRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                dsWorkgroupAssignments ds = new dsWorkgroupAssignments();
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal (0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal (1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "dtWorkGroupsDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace))
                {
                    System.IO.MemoryStream s1 = new System.IO.MemoryStream();
                    System.IO.MemoryStream s2 = new System.IO.MemoryStream();
                    try
                    {
                        System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator();
                        while (schemas.MoveNext())
                        {
                            schema = ((System.Xml.Schema.XmlSchema)schemas.Current);
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length))
                            {
                                s1.Position = 0;
                                s2.Position = 0;
                                while (((s1.Position != s1.Length) && (s1.ReadByte() == s2.ReadByte())))
                                {
                                }

                                if ((s1.Position == s1.Length))
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if ((!((s1) == null)))
                        {
                            s1.Close();
                        }

                        if ((!((s2) == null)))
                        {
                            s2.Close();
                        }
                    }
                }

                xs.Add(dsSchema);
                return type;
            }
        }

        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class dtLabourValuesToWorkGroupAssignmentsDataTable : System.Data.TypedTableBase<dtLabourValuesToWorkGroupAssignmentsRow>
        {
            private System.Data.DataColumn columnIDWorkGroupAssignment;
            private System.Data.DataColumn columnIDSubsidiary;
            private System.Data.DataColumn columnIDLabourValueInternal;
            private System.Data.DataColumn columnIDWorkGroupInternal;
            private System.Data.DataColumn columnOrdinalNumber;
            private System.Data.DataColumn columnLastEdited;
            private System.Data.DataColumn columnLabourValueNumber;
            private System.Data.DataColumn columnIDCostCenter;
            private System.Data.DataColumn columnLabourValueName;
            private System.Data.DataColumn columnLabourValueDescription;
            private System.Data.DataColumn columnTeHMin;
            private System.Data.DataColumn columnDimension;
            private System.Data.DataColumn columnIsActive;
            private System.Data.DataColumn columnIsCurrent;
            private System.Data.DataColumn columnCostCenterNo;
            private System.Data.DataColumn columnCostCenterName;
            private System.Data.DataColumn columnCostCenterDescription;
            private System.Data.DataColumn columnIncentiveWageSynonym;
            private System.Data.DataColumn columnIncentiveIndicatorSynonym;
            private System.Data.DataColumn columnIncentiveIndicatorDimension;
            private System.Data.DataColumn columnIncentiveIndicatorPrecision;
            private System.Data.DataColumn columnIncentiveIndicatorFactor;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesToWorkGroupAssignmentsDataTable() : base()
            {
                this.TableName = "dtLabourValuesToWorkGroupAssignments";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal dtLabourValuesToWorkGroupAssignmentsDataTable(System.Data.DataTable table) : base()
            {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive))
                {
                    this.CaseSensitive = table.CaseSensitive;
                }

                if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
                {
                    this.Locale = table.Locale;
                }

                if ((table.Namespace != table.DataSet.Namespace))
                {
                    this.Namespace = table.Namespace;
                }

                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected dtLabourValuesToWorkGroupAssignmentsDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDWorkGroupAssignmentColumn
            {
                get
                {
                    return this.columnIDWorkGroupAssignment;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDSubsidiaryColumn
            {
                get
                {
                    return this.columnIDSubsidiary;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDLabourValueInternalColumn
            {
                get
                {
                    return this.columnIDLabourValueInternal;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDWorkGroupInternalColumn
            {
                get
                {
                    return this.columnIDWorkGroupInternal;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn OrdinalNumberColumn
            {
                get
                {
                    return this.columnOrdinalNumber;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn LastEditedColumn
            {
                get
                {
                    return this.columnLastEdited;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn LabourValueNumberColumn
            {
                get
                {
                    return this.columnLabourValueNumber;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDCostCenterColumn
            {
                get
                {
                    return this.columnIDCostCenter;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn LabourValueNameColumn
            {
                get
                {
                    return this.columnLabourValueName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn LabourValueDescriptionColumn
            {
                get
                {
                    return this.columnLabourValueDescription;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn TeHMinColumn
            {
                get
                {
                    return this.columnTeHMin;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn DimensionColumn
            {
                get
                {
                    return this.columnDimension;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IsActiveColumn
            {
                get
                {
                    return this.columnIsActive;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IsCurrentColumn
            {
                get
                {
                    return this.columnIsCurrent;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CostCenterNoColumn
            {
                get
                {
                    return this.columnCostCenterNo;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CostCenterNameColumn
            {
                get
                {
                    return this.columnCostCenterName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CostCenterDescriptionColumn
            {
                get
                {
                    return this.columnCostCenterDescription;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveWageSynonymColumn
            {
                get
                {
                    return this.columnIncentiveWageSynonym;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveIndicatorSynonymColumn
            {
                get
                {
                    return this.columnIncentiveIndicatorSynonym;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveIndicatorDimensionColumn
            {
                get
                {
                    return this.columnIncentiveIndicatorDimension;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveIndicatorPrecisionColumn
            {
                get
                {
                    return this.columnIncentiveIndicatorPrecision;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IncentiveIndicatorFactorColumn
            {
                get
                {
                    return this.columnIncentiveIndicatorFactor;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesToWorkGroupAssignmentsRow this[int index]
            {
                get
                {
                    return ((dtLabourValuesToWorkGroupAssignmentsRow)this.Rows[index]);
                }
            }

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtLabourValuesToWorkGroupAssignmentsRowChangeEventHandler dtLabourValuesToWorkGroupAssignmentsRowChanging;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtLabourValuesToWorkGroupAssignmentsRowChangeEventHandler dtLabourValuesToWorkGroupAssignmentsRowChanged;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtLabourValuesToWorkGroupAssignmentsRowChangeEventHandler dtLabourValuesToWorkGroupAssignmentsRowDeleting;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtLabourValuesToWorkGroupAssignmentsRowChangeEventHandler dtLabourValuesToWorkGroupAssignmentsRowDeleted;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void AdddtLabourValuesToWorkGroupAssignmentsRow(dtLabourValuesToWorkGroupAssignmentsRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesToWorkGroupAssignmentsRow AdddtLabourValuesToWorkGroupAssignmentsRow(int IDSubsidiary, int IDLabourValueInternal, int IDWorkGroupInternal, int OrdinalNumber, System.DateTime LastEdited, int LabourValueNumber, int IDCostCenter, string LabourValueName, string LabourValueDescription, double TeHMin, string Dimension, bool IsActive, bool IsCurrent, int CostCenterNo, string CostCenterName, string CostCenterDescription, string IncentiveWageSynonym, string IncentiveIndicatorSynonym, string IncentiveIndicatorDimension, byte IncentiveIndicatorPrecision, double IncentiveIndicatorFactor)
            {
                dtLabourValuesToWorkGroupAssignmentsRow rowdtLabourValuesToWorkGroupAssignmentsRow = ((dtLabourValuesToWorkGroupAssignmentsRow)this.NewRow());
                object[] columnValuesArray = new object[]
                {
                    null,
                    IDSubsidiary,
                    IDLabourValueInternal,
                    IDWorkGroupInternal,
                    OrdinalNumber,
                    LastEdited,
                    LabourValueNumber,
                    IDCostCenter,
                    LabourValueName,
                    LabourValueDescription,
                    TeHMin,
                    Dimension,
                    IsActive,
                    IsCurrent,
                    CostCenterNo,
                    CostCenterName,
                    CostCenterDescription,
                    IncentiveWageSynonym,
                    IncentiveIndicatorSynonym,
                    IncentiveIndicatorDimension,
                    IncentiveIndicatorPrecision,
                    IncentiveIndicatorFactor
                };
                rowdtLabourValuesToWorkGroupAssignmentsRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowdtLabourValuesToWorkGroupAssignmentsRow);
                return rowdtLabourValuesToWorkGroupAssignmentsRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesToWorkGroupAssignmentsRow FindByIDWorkGroupAssignmentIDSubsidiary(int IDWorkGroupAssignment, int IDSubsidiary)
            {
                return ((dtLabourValuesToWorkGroupAssignmentsRow)this.Rows.Find(new object[] { IDWorkGroupAssignment, IDSubsidiary }));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public override System.Data.DataTable Clone()
            {
                dtLabourValuesToWorkGroupAssignmentsDataTable cln = ((dtLabourValuesToWorkGroupAssignmentsDataTable)base.Clone());
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataTable CreateInstance()
            {
                return new dtLabourValuesToWorkGroupAssignmentsDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal void InitVars()
            {
                this.columnIDWorkGroupAssignment = base.Columns["IDWorkGroupAssignment"];
                this.columnIDSubsidiary = base.Columns["IDSubsidiary"];
                this.columnIDLabourValueInternal = base.Columns["IDLabourValueInternal"];
                this.columnIDWorkGroupInternal = base.Columns["IDWorkGroupInternal"];
                this.columnOrdinalNumber = base.Columns["OrdinalNumber"];
                this.columnLastEdited = base.Columns["LastEdited"];
                this.columnLabourValueNumber = base.Columns["LabourValueNumber"];
                this.columnIDCostCenter = base.Columns["IDCostCenter"];
                this.columnLabourValueName = base.Columns["LabourValueName"];
                this.columnLabourValueDescription = base.Columns["LabourValueDescription"];
                this.columnTeHMin = base.Columns["TeHMin"];
                this.columnDimension = base.Columns["Dimension"];
                this.columnIsActive = base.Columns["IsActive"];
                this.columnIsCurrent = base.Columns["IsCurrent"];
                this.columnCostCenterNo = base.Columns["CostCenterNo"];
                this.columnCostCenterName = base.Columns["CostCenterName"];
                this.columnCostCenterDescription = base.Columns["CostCenterDescription"];
                this.columnIncentiveWageSynonym = base.Columns["IncentiveWageSynonym"];
                this.columnIncentiveIndicatorSynonym = base.Columns["IncentiveIndicatorSynonym"];
                this.columnIncentiveIndicatorDimension = base.Columns["IncentiveIndicatorDimension"];
                this.columnIncentiveIndicatorPrecision = base.Columns["IncentiveIndicatorPrecision"];
                this.columnIncentiveIndicatorFactor = base.Columns["IncentiveIndicatorFactor"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            private void InitClass()
            {
                this.columnIDWorkGroupAssignment = new System.Data.DataColumn("IDWorkGroupAssignment", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDWorkGroupAssignment);
                this.columnIDSubsidiary = new System.Data.DataColumn("IDSubsidiary", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDSubsidiary);
                this.columnIDLabourValueInternal = new System.Data.DataColumn("IDLabourValueInternal", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDLabourValueInternal);
                this.columnIDWorkGroupInternal = new System.Data.DataColumn("IDWorkGroupInternal", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDWorkGroupInternal);
                this.columnOrdinalNumber = new System.Data.DataColumn("OrdinalNumber", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnOrdinalNumber);
                this.columnLastEdited = new System.Data.DataColumn("LastEdited", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLastEdited);
                this.columnLabourValueNumber = new System.Data.DataColumn("LabourValueNumber", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLabourValueNumber);
                this.columnIDCostCenter = new System.Data.DataColumn("IDCostCenter", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDCostCenter);
                this.columnLabourValueName = new System.Data.DataColumn("LabourValueName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLabourValueName);
                this.columnLabourValueDescription = new System.Data.DataColumn("LabourValueDescription", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLabourValueDescription);
                this.columnTeHMin = new System.Data.DataColumn("TeHMin", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTeHMin);
                this.columnDimension = new System.Data.DataColumn("Dimension", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnDimension);
                this.columnIsActive = new System.Data.DataColumn("IsActive", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsActive);
                this.columnIsCurrent = new System.Data.DataColumn("IsCurrent", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsCurrent);
                this.columnCostCenterNo = new System.Data.DataColumn("CostCenterNo", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterNo);
                this.columnCostCenterName = new System.Data.DataColumn("CostCenterName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterName);
                this.columnCostCenterDescription = new System.Data.DataColumn("CostCenterDescription", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterDescription);
                this.columnIncentiveWageSynonym = new System.Data.DataColumn("IncentiveWageSynonym", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveWageSynonym);
                this.columnIncentiveIndicatorSynonym = new System.Data.DataColumn("IncentiveIndicatorSynonym", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorSynonym);
                this.columnIncentiveIndicatorDimension = new System.Data.DataColumn("IncentiveIndicatorDimension", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorDimension);
                this.columnIncentiveIndicatorPrecision = new System.Data.DataColumn("IncentiveIndicatorPrecision", typeof(byte), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorPrecision);
                this.columnIncentiveIndicatorFactor = new System.Data.DataColumn("IncentiveIndicatorFactor", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorFactor);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] { this.columnIDWorkGroupAssignment, this.columnIDSubsidiary }, true));
                this.columnIDWorkGroupAssignment.AutoIncrement = true;
                this.columnIDWorkGroupAssignment.AllowDBNull = false;
                this.columnIDWorkGroupAssignment.ReadOnly = true;
                this.columnIDSubsidiary.AllowDBNull = false;
                this.columnIDLabourValueInternal.AllowDBNull = false;
                this.columnIDWorkGroupInternal.AllowDBNull = false;
                this.columnOrdinalNumber.AllowDBNull = false;
                this.columnLastEdited.AllowDBNull = false;
                this.columnLabourValueNumber.AllowDBNull = false;
                this.columnIDCostCenter.AllowDBNull = false;
                this.columnLabourValueName.AllowDBNull = false;
                this.columnLabourValueName.MaxLength = 100;
                this.columnLabourValueDescription.MaxLength = 2147483647;
                this.columnTeHMin.AllowDBNull = false;
                this.columnDimension.AllowDBNull = false;
                this.columnDimension.MaxLength = 100;
                this.columnIsActive.AllowDBNull = false;
                this.columnIsCurrent.AllowDBNull = false;
                this.columnCostCenterNo.AllowDBNull = false;
                this.columnCostCenterName.AllowDBNull = false;
                this.columnCostCenterName.MaxLength = 100;
                this.columnCostCenterDescription.MaxLength = 4000;
                this.columnIncentiveWageSynonym.AllowDBNull = false;
                this.columnIncentiveWageSynonym.MaxLength = 50;
                this.columnIncentiveIndicatorSynonym.AllowDBNull = false;
                this.columnIncentiveIndicatorSynonym.MaxLength = 50;
                this.columnIncentiveIndicatorDimension.AllowDBNull = false;
                this.columnIncentiveIndicatorDimension.MaxLength = 10;
                this.columnIncentiveIndicatorPrecision.AllowDBNull = false;
                this.columnIncentiveIndicatorFactor.AllowDBNull = false;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesToWorkGroupAssignmentsRow NewdtLabourValuesToWorkGroupAssignmentsRow()
            {
                return ((dtLabourValuesToWorkGroupAssignmentsRow)this.NewRow());
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new dtLabourValuesToWorkGroupAssignmentsRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Type GetRowType()
            {
                return typeof(dtLabourValuesToWorkGroupAssignmentsRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((!((this.dtLabourValuesToWorkGroupAssignmentsRowChanged) == null)))
                {
                    dtLabourValuesToWorkGroupAssignmentsRowChanged?.Invoke(this, new dtLabourValuesToWorkGroupAssignmentsRowChangeEvent(((dtLabourValuesToWorkGroupAssignmentsRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((!((this.dtLabourValuesToWorkGroupAssignmentsRowChanging) == null)))
                {
                    dtLabourValuesToWorkGroupAssignmentsRowChanging?.Invoke(this, new dtLabourValuesToWorkGroupAssignmentsRowChangeEvent(((dtLabourValuesToWorkGroupAssignmentsRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((!((this.dtLabourValuesToWorkGroupAssignmentsRowDeleted) == null)))
                {
                    dtLabourValuesToWorkGroupAssignmentsRowDeleted?.Invoke(this, new dtLabourValuesToWorkGroupAssignmentsRowChangeEvent(((dtLabourValuesToWorkGroupAssignmentsRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((!((this.dtLabourValuesToWorkGroupAssignmentsRowDeleting) == null)))
                {
                    dtLabourValuesToWorkGroupAssignmentsRowDeleting?.Invoke(this, new dtLabourValuesToWorkGroupAssignmentsRowChangeEvent(((dtLabourValuesToWorkGroupAssignmentsRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void RemovedtLabourValuesToWorkGroupAssignmentsRow(dtLabourValuesToWorkGroupAssignmentsRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                dsWorkgroupAssignments ds = new dsWorkgroupAssignments();
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal (0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal (1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "dtLabourValuesToWorkGroupAssignmentsDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace))
                {
                    System.IO.MemoryStream s1 = new System.IO.MemoryStream();
                    System.IO.MemoryStream s2 = new System.IO.MemoryStream();
                    try
                    {
                        System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator();
                        while (schemas.MoveNext())
                        {
                            schema = ((System.Xml.Schema.XmlSchema)schemas.Current);
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length))
                            {
                                s1.Position = 0;
                                s2.Position = 0;
                                while (((s1.Position != s1.Length) && (s1.ReadByte() == s2.ReadByte())))
                                {
                                }

                                if ((s1.Position == s1.Length))
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if ((!((s1) == null)))
                        {
                            s1.Close();
                        }

                        if ((!((s2) == null)))
                        {
                            s2.Close();
                        }
                    }
                }

                xs.Add(dsSchema);
                return type;
            }
        }

        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        public partial class dtWorkGroupsRow : System.Data.DataRow
        {
            private dtWorkGroupsDataTable tabledtWorkGroups;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal dtWorkGroupsRow(System.Data.DataRowBuilder rb) : base(rb)
            {
                this.tabledtWorkGroups = ((dtWorkGroupsDataTable)this.Table);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDWorkGroup
            {
                get
                {
                    return ((int)this[this.tabledtWorkGroups.IDWorkGroupColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IDWorkGroupColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDSubsidiary
            {
                get
                {
                    return ((int)this[this.tabledtWorkGroups.IDSubsidiaryColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IDSubsidiaryColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDWorkGroupInternal
            {
                get
                {
                    return ((int)this[this.tabledtWorkGroups.IDWorkGroupInternalColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IDWorkGroupInternalColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDCostCenter
            {
                get
                {
                    return ((int)this[this.tabledtWorkGroups.IDCostCenterColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IDCostCenterColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int WorkGroupNumber
            {
                get
                {
                    return ((int)this[this.tabledtWorkGroups.WorkGroupNumberColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.WorkGroupNumberColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string WorkgroupName
            {
                get
                {
                    return ((string)this[this.tabledtWorkGroups.WorkgroupNameColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.WorkgroupNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string WorkGroupDescription
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tabledtWorkGroups.WorkGroupDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'WorkGroupDescription' in table 'dtWorkGroups' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tabledtWorkGroups.WorkGroupDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double WorkloadIWT
            {
                get
                {
                    return ((double)this[this.tabledtWorkGroups.WorkloadIWTColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.WorkloadIWTColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsActive
            {
                get
                {
                    return ((bool)this[this.tabledtWorkGroups.IsActiveColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IsActiveColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCurrent
            {
                get
                {
                    return ((bool)this[this.tabledtWorkGroups.IsCurrentColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IsCurrentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsPeaceWork
            {
                get
                {
                    return ((bool)this[this.tabledtWorkGroups.IsPeaceWorkColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IsPeaceWorkColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsConceptional
            {
                get
                {
                    return ((bool)this[this.tabledtWorkGroups.IsConceptionalColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IsConceptionalColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int OrdinalNo
            {
                get
                {
                    return ((int)this[this.tabledtWorkGroups.OrdinalNoColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.OrdinalNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string TimeSettingDetails
            {
                get
                {
                    return ((string)this[this.tabledtWorkGroups.TimeSettingDetailsColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.TimeSettingDetailsColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime WasCurrentFrom
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtWorkGroups.WasCurrentFromColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.WasCurrentFromColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime WasCurrentTo
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtWorkGroups.WasCurrentToColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.WasCurrentToColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime LastEdited
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtWorkGroups.LastEditedColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.LastEditedColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDCostCenterInternal
            {
                get
                {
                    return ((int)this[this.tabledtWorkGroups.IDCostCenterInternalColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IDCostCenterInternalColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool CC_IsCurrent
            {
                get
                {
                    return ((bool)this[this.tabledtWorkGroups.CC_IsCurrentColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.CC_IsCurrentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int CostCenterNo
            {
                get
                {
                    return ((int)this[this.tabledtWorkGroups.CostCenterNoColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.CostCenterNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string CostCenterName
            {
                get
                {
                    return ((string)this[this.tabledtWorkGroups.CostCenterNameColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.CostCenterNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string CostCenterDescription
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tabledtWorkGroups.CostCenterDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'CostCenterDescription' in table 'dtWorkGroups' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tabledtWorkGroups.CostCenterDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDCurrency
            {
                get
                {
                    return ((int)this[this.tabledtWorkGroups.IDCurrencyColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IDCurrencyColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorSynonym
            {
                get
                {
                    return ((string)this[this.tabledtWorkGroups.IncentiveIndicatorSynonymColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IncentiveIndicatorSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveWageSynonym
            {
                get
                {
                    return ((string)this[this.tabledtWorkGroups.IncentiveWageSynonymColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IncentiveWageSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorDimension
            {
                get
                {
                    return ((string)this[this.tabledtWorkGroups.IncentiveIndicatorDimensionColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IncentiveIndicatorDimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte IncentiveIndicatorPrecision
            {
                get
                {
                    return ((byte)this[this.tabledtWorkGroups.IncentiveIndicatorPrecisionColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IncentiveIndicatorPrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool UseFixValuedBonus
            {
                get
                {
                    return ((bool)this[this.tabledtWorkGroups.UseFixValuedBonusColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.UseFixValuedBonusColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double IncentiveIndicatorFactor
            {
                get
                {
                    return ((double)this[this.tabledtWorkGroups.IncentiveIndicatorFactorColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.IncentiveIndicatorFactorColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte BaseValuePrecision
            {
                get
                {
                    return ((byte)this[this.tabledtWorkGroups.BaseValuePrecisionColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.BaseValuePrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string BaseValueSynonym
            {
                get
                {
                    return ((string)this[this.tabledtWorkGroups.BaseValueSynonymColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.BaseValueSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime CC_WasCurrentFrom
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtWorkGroups.CC_WasCurrentFromColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.CC_WasCurrentFromColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime CC_WasCurrentTo
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtWorkGroups.CC_WasCurrentToColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.CC_WasCurrentToColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime CC_LastEdited
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtWorkGroups.CC_LastEditedColumn]);
                }

                set
                {
                    this[this.tabledtWorkGroups.CC_LastEditedColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsWorkGroupDescriptionNull()
            {
                return this.IsNull(this.tabledtWorkGroups.WorkGroupDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetWorkGroupDescriptionNull()
            {
                this[this.tabledtWorkGroups.WorkGroupDescriptionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCostCenterDescriptionNull()
            {
                return this.IsNull(this.tabledtWorkGroups.CostCenterDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetCostCenterDescriptionNull()
            {
                this[this.tabledtWorkGroups.CostCenterDescriptionColumn] = global::System.Convert.DBNull;
            }
        }

        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        public partial class dtLabourValuesToWorkGroupAssignmentsRow : System.Data.DataRow
        {
            private dtLabourValuesToWorkGroupAssignmentsDataTable tabledtLabourValuesToWorkGroupAssignments;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal dtLabourValuesToWorkGroupAssignmentsRow(System.Data.DataRowBuilder rb) : base(rb)
            {
                this.tabledtLabourValuesToWorkGroupAssignments = ((dtLabourValuesToWorkGroupAssignmentsDataTable)this.Table);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDWorkGroupAssignment
            {
                get
                {
                    return ((int)this[this.tabledtLabourValuesToWorkGroupAssignments.IDWorkGroupAssignmentColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IDWorkGroupAssignmentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDSubsidiary
            {
                get
                {
                    return ((int)this[this.tabledtLabourValuesToWorkGroupAssignments.IDSubsidiaryColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IDSubsidiaryColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDLabourValueInternal
            {
                get
                {
                    return ((int)this[this.tabledtLabourValuesToWorkGroupAssignments.IDLabourValueInternalColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IDLabourValueInternalColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDWorkGroupInternal
            {
                get
                {
                    return ((int)this[this.tabledtLabourValuesToWorkGroupAssignments.IDWorkGroupInternalColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IDWorkGroupInternalColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int OrdinalNumber
            {
                get
                {
                    return ((int)this[this.tabledtLabourValuesToWorkGroupAssignments.OrdinalNumberColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.OrdinalNumberColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime LastEdited
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtLabourValuesToWorkGroupAssignments.LastEditedColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.LastEditedColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int LabourValueNumber
            {
                get
                {
                    return ((int)this[this.tabledtLabourValuesToWorkGroupAssignments.LabourValueNumberColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.LabourValueNumberColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDCostCenter
            {
                get
                {
                    return ((int)this[this.tabledtLabourValuesToWorkGroupAssignments.IDCostCenterColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IDCostCenterColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string LabourValueName
            {
                get
                {
                    return ((string)this[this.tabledtLabourValuesToWorkGroupAssignments.LabourValueNameColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.LabourValueNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string LabourValueDescription
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tabledtLabourValuesToWorkGroupAssignments.LabourValueDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LabourValueDescription' in table 'dtLabourValuesToWorkGroup" + "Assignments' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.LabourValueDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double TeHMin
            {
                get
                {
                    return ((double)this[this.tabledtLabourValuesToWorkGroupAssignments.TeHMinColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.TeHMinColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string Dimension
            {
                get
                {
                    return ((string)this[this.tabledtLabourValuesToWorkGroupAssignments.DimensionColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.DimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsActive
            {
                get
                {
                    return ((bool)this[this.tabledtLabourValuesToWorkGroupAssignments.IsActiveColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IsActiveColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCurrent
            {
                get
                {
                    return ((bool)this[this.tabledtLabourValuesToWorkGroupAssignments.IsCurrentColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IsCurrentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int CostCenterNo
            {
                get
                {
                    return ((int)this[this.tabledtLabourValuesToWorkGroupAssignments.CostCenterNoColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.CostCenterNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string CostCenterName
            {
                get
                {
                    return ((string)this[this.tabledtLabourValuesToWorkGroupAssignments.CostCenterNameColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.CostCenterNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string CostCenterDescription
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tabledtLabourValuesToWorkGroupAssignments.CostCenterDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'CostCenterDescription' in table 'dtLabourValuesToWorkGroupA" + "ssignments' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.CostCenterDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveWageSynonym
            {
                get
                {
                    return ((string)this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveWageSynonymColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveWageSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorSynonym
            {
                get
                {
                    return ((string)this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveIndicatorSynonymColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveIndicatorSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorDimension
            {
                get
                {
                    return ((string)this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveIndicatorDimensionColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveIndicatorDimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte IncentiveIndicatorPrecision
            {
                get
                {
                    return ((byte)this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveIndicatorPrecisionColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveIndicatorPrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double IncentiveIndicatorFactor
            {
                get
                {
                    return ((double)this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveIndicatorFactorColumn]);
                }

                set
                {
                    this[this.tabledtLabourValuesToWorkGroupAssignments.IncentiveIndicatorFactorColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLabourValueDescriptionNull()
            {
                return this.IsNull(this.tabledtLabourValuesToWorkGroupAssignments.LabourValueDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLabourValueDescriptionNull()
            {
                this[this.tabledtLabourValuesToWorkGroupAssignments.LabourValueDescriptionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCostCenterDescriptionNull()
            {
                return this.IsNull(this.tabledtLabourValuesToWorkGroupAssignments.CostCenterDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetCostCenterDescriptionNull()
            {
                this[this.tabledtLabourValuesToWorkGroupAssignments.CostCenterDescriptionColumn] = global::System.Convert.DBNull;
            }
        }

        /// <summary>
        ///Row event argument class
        ///</summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public class dtWorkGroupsRowChangeEvent : System.EventArgs
        {
            private dtWorkGroupsRow eventRow;
            private System.Data.DataRowAction eventAction;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtWorkGroupsRowChangeEvent(dtWorkGroupsRow row, System.Data.DataRowAction action) : base()
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtWorkGroupsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }
        }

        /// <summary>
        ///Row event argument class
        ///</summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public class dtLabourValuesToWorkGroupAssignmentsRowChangeEvent : System.EventArgs
        {
            private dtLabourValuesToWorkGroupAssignmentsRow eventRow;
            private System.Data.DataRowAction eventAction;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesToWorkGroupAssignmentsRowChangeEvent(dtLabourValuesToWorkGroupAssignmentsRow row, System.Data.DataRowAction action) : base()
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesToWorkGroupAssignmentsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }
        }
    }
}
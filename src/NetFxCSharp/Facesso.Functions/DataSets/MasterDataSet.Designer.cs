using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions.MasterDataSetTableAdapters
{
    /// <summary>
    ///Represents the connection and commands used to retrieve and save data.
    ///</summary>
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.ComponentModel.DataObjectAttribute(true)]
    [System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" + ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
    public partial class EmployeesWithCostCentersTableAdapter : System.ComponentModel.Component
    {
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        private System.Data.SqlClient.SqlConnection _connection;
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public EmployeesWithCostCentersTableAdapter() : base()
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
            tableMapping.DataSetTable = "EmployeesWithCostCenters";
            tableMapping.ColumnMappings.Add("Matchcode", "Matchcode");
            tableMapping.ColumnMappings.Add("PersonnelNumber", "PersonnelNumber");
            tableMapping.ColumnMappings.Add("LastName", "LastName");
            tableMapping.ColumnMappings.Add("FirstName", "FirstName");
            tableMapping.ColumnMappings.Add("UseFixedWage", "UseFixedWage");
            tableMapping.ColumnMappings.Add("DateOfBirth", "DateOfBirth");
            tableMapping.ColumnMappings.Add("DateOfJoining", "DateOfJoining");
            tableMapping.ColumnMappings.Add("IsActive", "IsActive");
            tableMapping.ColumnMappings.Add("IsIncentive", "IsIncentive");
            tableMapping.ColumnMappings.Add("FixedWage", "FixedWage");
            tableMapping.ColumnMappings.Add("CostCenterNo", "CostCenterNo");
            tableMapping.ColumnMappings.Add("CostCenterName", "CostCenterName");
            tableMapping.ColumnMappings.Add("CostCenterDescription", "CostCenterDescription");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorSynonym", "IncentiveIndicatorSynonym");
            tableMapping.ColumnMappings.Add("IncentiveWageSynonym", "IncentiveWageSynonym");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorDimension", "IncentiveIndicatorDimension");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorPrecision", "IncentiveIndicatorPrecision");
            tableMapping.ColumnMappings.Add("TimeCardNo", "TimeCardNo");
            tableMapping.ColumnMappings.Add("DateOfSeparation", "DateOfSeparation");
            tableMapping.ColumnMappings.Add("IsCurrent", "IsCurrent");
            this._adapter.TableMappings.Add(tableMapping);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitConnection()
        {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = global::Facesso.Functions.Settings.Default.FacessoConnectionString;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new System.Data.SqlClient.SqlCommand[1];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT     Employees.Matchcode, Employees.PersonnelNumber, Employees.LastName, Em" + "ployees.FirstName, Employees.UseFixedWage, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      Employees.Dat" + "eOfBirth, Employees.DateOfJoining, Employees.IsActive, Employees.IsIncentive, Em" + "ployees.FixedWage, CostCenters.CostCenterNo, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters" + ".CostCenterName, CostCenters.CostCenterDescription, CostCenters.IncentiveIndicat" + "orSynonym, CostCenters.IncentiveWageSynonym, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters" + ".IncentiveIndicatorDimension, CostCenters.IncentiveIndicatorPrecision, Employees" + ".TimeCardNo, Employees.DateOfSeparation, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      Employees.IsCur" + "rent" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "FROM         Employees INNER JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters ON Em" + "ployees.IDSubsidiary = CostCenters.IDSubsidiary AND Employees.IDCostCenter = Cos" + "tCenters.IDCostCenter";
            this._commandCollection[0].CommandType = global::System.Data.CommandType.Text;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int Fill(MasterDataSet.EmployeesWithCostCentersDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
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
        public virtual MasterDataSet.EmployeesWithCostCentersDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            MasterDataSet.EmployeesWithCostCentersDataTable dataTable = new MasterDataSet.EmployeesWithCostCentersDataTable();
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
    public partial class LabourValuesWithCostCentersTableAdapter : System.ComponentModel.Component
    {
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        private System.Data.SqlClient.SqlConnection _connection;
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public LabourValuesWithCostCentersTableAdapter() : base()
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
            tableMapping.DataSetTable = "LabourValuesWithCostCenters";
            tableMapping.ColumnMappings.Add("LabourValueNumber", "LabourValueNumber");
            tableMapping.ColumnMappings.Add("LabourValueName", "LabourValueName");
            tableMapping.ColumnMappings.Add("LabourValueDescription", "LabourValueDescription");
            tableMapping.ColumnMappings.Add("TeHMin", "TeHMin");
            tableMapping.ColumnMappings.Add("Dimension", "Dimension");
            tableMapping.ColumnMappings.Add("IsActive", "IsActive");
            tableMapping.ColumnMappings.Add("IsCurrent", "IsCurrent");
            tableMapping.ColumnMappings.Add("CostCenterNo", "CostCenterNo");
            tableMapping.ColumnMappings.Add("CostCenterName", "CostCenterName");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorSynonym", "IncentiveIndicatorSynonym");
            tableMapping.ColumnMappings.Add("IncentiveWageSynonym", "IncentiveWageSynonym");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorDimension", "IncentiveIndicatorDimension");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorPrecision", "IncentiveIndicatorPrecision");
            tableMapping.ColumnMappings.Add("UseFixValuedBonus", "UseFixValuedBonus");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorFactor", "IncentiveIndicatorFactor");
            tableMapping.ColumnMappings.Add("BaseValuePrecision", "BaseValuePrecision");
            tableMapping.ColumnMappings.Add("BaseValueSynonym", "BaseValueSynonym");
            tableMapping.ColumnMappings.Add("CostCenterDescription", "CostCenterDescription");
            this._adapter.TableMappings.Add(tableMapping);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitConnection()
        {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = global::Facesso.Functions.Settings.Default.FacessoConnectionString;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new System.Data.SqlClient.SqlCommand[1];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT     LabourValues.LabourValueNumber, LabourValues.LabourValueName, LabourVa" + "lues.LabourValueDescription, LabourValues.TeHMin, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      Labour" + "Values.Dimension, LabourValues.IsActive, LabourValues.IsCurrent, CostCenters.Cos" + "tCenterNo, CostCenters.CostCenterName, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.Incen" + "tiveIndicatorSynonym, CostCenters.IncentiveWageSynonym, CostCenters.IncentiveInd" + "icatorDimension, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.IncentiveIndicatorPrecision" + ", CostCenters.UseFixValuedBonus, CostCenters.IncentiveIndicatorFactor, CostCente" + "rs.BaseValuePrecision, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.BaseValueSynonym, Cos" + "tCenters.CostCenterDescription" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "FROM         LabourValues INNER JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "          " + "            CostCenters ON LabourValues.IDCostCenter = CostCenters.IDCostCenter";
            this._commandCollection[0].CommandType = global::System.Data.CommandType.Text;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int Fill(MasterDataSet.LabourValuesWithCostCentersDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
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
        public virtual MasterDataSet.LabourValuesWithCostCentersDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            MasterDataSet.LabourValuesWithCostCentersDataTable dataTable = new MasterDataSet.LabourValuesWithCostCentersDataTable();
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
    public partial class WorkgroupsWithLabourValuesAndCostCentersTableAdapter : System.ComponentModel.Component
    {
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        private System.Data.SqlClient.SqlConnection _connection;
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public WorkgroupsWithLabourValuesAndCostCentersTableAdapter() : base()
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
            tableMapping.DataSetTable = "WorkgroupsWithLabourValuesAndCostCenters";
            tableMapping.ColumnMappings.Add("WorkGroupNumber", "WorkGroupNumber");
            tableMapping.ColumnMappings.Add("WorkgroupName", "WorkgroupName");
            tableMapping.ColumnMappings.Add("WorkGroupDescription", "WorkGroupDescription");
            tableMapping.ColumnMappings.Add("LabourValueNumber", "LabourValueNumber");
            tableMapping.ColumnMappings.Add("LabourValueName", "LabourValueName");
            tableMapping.ColumnMappings.Add("LabourValueDescription", "LabourValueDescription");
            tableMapping.ColumnMappings.Add("TeHMin", "TeHMin");
            tableMapping.ColumnMappings.Add("Dimension", "Dimension");
            tableMapping.ColumnMappings.Add("IsCurrent", "IsCurrent");
            tableMapping.ColumnMappings.Add("LvIsCurrent", "LvIsCurrent");
            tableMapping.ColumnMappings.Add("IsPeaceWork", "IsPeaceWork");
            tableMapping.ColumnMappings.Add("IsConceptional", "IsConceptional");
            tableMapping.ColumnMappings.Add("OrdinalNo", "OrdinalNo");
            tableMapping.ColumnMappings.Add("WgaOrdinalNumber", "WgaOrdinalNumber");
            tableMapping.ColumnMappings.Add("CostCenterNo", "CostCenterNo");
            tableMapping.ColumnMappings.Add("CostCenterName", "CostCenterName");
            tableMapping.ColumnMappings.Add("LvCostCenterNo", "LvCostCenterNo");
            tableMapping.ColumnMappings.Add("LvCostCenterName", "LvCostCenterName");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorSynonym", "IncentiveIndicatorSynonym");
            tableMapping.ColumnMappings.Add("IncentiveWageSynonym", "IncentiveWageSynonym");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorDimension", "IncentiveIndicatorDimension");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorPrecision", "IncentiveIndicatorPrecision");
            tableMapping.ColumnMappings.Add("UseFixValuedBonus", "UseFixValuedBonus");
            tableMapping.ColumnMappings.Add("IncentiveIndicatorFactor", "IncentiveIndicatorFactor");
            tableMapping.ColumnMappings.Add("BaseValuePrecision", "BaseValuePrecision");
            tableMapping.ColumnMappings.Add("BaseValueSynonym", "BaseValueSynonym");
            tableMapping.ColumnMappings.Add("WorkloadIWT", "WorkloadIWT");
            tableMapping.ColumnMappings.Add("IsActive", "IsActive");
            tableMapping.ColumnMappings.Add("TimeSettingDetails", "TimeSettingDetails");
            tableMapping.ColumnMappings.Add("LastEdited", "LastEdited");
            tableMapping.ColumnMappings.Add("WgaLastEdited", "WgaLastEdited");
            tableMapping.ColumnMappings.Add("LvLastEdited", "LvLastEdited");
            this._adapter.TableMappings.Add(tableMapping);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitConnection()
        {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = global::Facesso.Functions.Settings.Default.FacessoConnectionString;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new System.Data.SqlClient.SqlCommand[1];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT     WorkGroups.WorkGroupNumber, WorkGroups.WorkgroupName, WorkGroups.WorkG" + "roupDescription, LabourValues.LabourValueNumber, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourV" + "alues.LabourValueName, LabourValues.LabourValueDescription, LabourValues.TeHMin," + " LabourValues.Dimension, LabourValues.IsCurrent, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      WorkGro" + "ups.IsCurrent AS LvIsCurrent, WorkGroups.IsPeaceWork, WorkGroups.IsConceptional," + " WorkGroups.OrdinalNo, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      WorkGroupAssignments.OrdinalNumbe" + "r AS WgaOrdinalNumber, CostCenters_1.CostCenterNo, CostCenters_1.CostCenterName," + " " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.CostCenterNo AS LvCostCenterNo, CostCenters" + ".CostCenterName AS LvCostCenterName, CostCenters_1.IncentiveIndicatorSynonym, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters_1.IncentiveWageSynonym, CostCenters_1.Incentiv" + "eIndicatorDimension, CostCenters_1.IncentiveIndicatorPrecision, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "              " + "        CostCenters_1.UseFixValuedBonus, CostCenters_1.IncentiveIndicatorFactor," + " CostCenters_1.BaseValuePrecision, CostCenters_1.BaseValueSynonym, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "           " + "           WorkGroups.WorkloadIWT, WorkGroups.IsActive, WorkGroups.TimeSettingDe" + "tails, WorkGroups.LastEdited, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      WorkGroupAssignments.LastE" + "dited AS WgaLastEdited, LabourValues.LastEdited AS LvLastEdited" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "FROM         Wo" + "rkGroupAssignments LEFT OUTER JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters RIGHT OUTE" + "R JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourValues ON CostCenters.IDCostCenter = LabourV" + "alues.IDCostCenter AND CostCenters.IDSubsidiary = LabourValues.IDSubsidiary ON " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      WorkGroupAssignments.IDSubsidiary = LabourValues.IDSubsid" + "iary AND " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      WorkGroupAssignments.IDLabourValueInternal = La" + "bourValues.IDLabourValueInternal LEFT OUTER JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCent" + "ers AS CostCenters_1 RIGHT OUTER JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      WorkGroups ON CostC" + "enters_1.IDSubsidiary = WorkGroups.IDSubsidiary AND CostCenters_1.IDCostCenter =" + " WorkGroups.IDCostCenter ON " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      WorkGroupAssignments.IDSubsi" + "diary = WorkGroups.IDSubsidiary AND " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      WorkGroupAssignments" + ".IDWorkGroupInternal = WorkGroups.IDWorkGroupInternal" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "WHERE     (WorkGroups.IsC" + "urrent = 1) AND (LabourValues.IsCurrent = 1)";
            this._commandCollection[0].CommandType = global::System.Data.CommandType.Text;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int Fill(MasterDataSet.WorkgroupsWithLabourValuesAndCostCentersDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
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
        public virtual MasterDataSet.WorkgroupsWithLabourValuesAndCostCentersDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            MasterDataSet.WorkgroupsWithLabourValuesAndCostCentersDataTable dataTable = new MasterDataSet.WorkgroupsWithLabourValuesAndCostCentersDataTable();
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
    [System.Xml.Serialization.XmlRootAttribute("MasterDataSet")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class MasterDataSet : System.Data.DataSet
    {
        private EmployeesWithCostCentersDataTable tableEmployeesWithCostCenters;
        private LabourValuesWithCostCentersDataTable tableLabourValuesWithCostCenters;
        private WorkgroupsWithLabourValuesAndCostCentersDataTable tableWorkgroupsWithLabourValuesAndCostCenters;
        private System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public MasterDataSet() : base()
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
        protected MasterDataSet(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context, false)
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
                if ((!((ds.Tables["EmployeesWithCostCenters"]) == null)))
                {
                    base.Tables.Add(new EmployeesWithCostCentersDataTable(ds.Tables["EmployeesWithCostCenters"]));
                }

                if ((!((ds.Tables["LabourValuesWithCostCenters"]) == null)))
                {
                    base.Tables.Add(new LabourValuesWithCostCentersDataTable(ds.Tables["LabourValuesWithCostCenters"]));
                }

                if ((!((ds.Tables["WorkgroupsWithLabourValuesAndCostCenters"]) == null)))
                {
                    base.Tables.Add(new WorkgroupsWithLabourValuesAndCostCentersDataTable(ds.Tables["WorkgroupsWithLabourValuesAndCostCenters"]));
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
        public EmployeesWithCostCentersDataTable EmployeesWithCostCenters
        {
            get
            {
                return this.tableEmployeesWithCostCenters;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public LabourValuesWithCostCentersDataTable LabourValuesWithCostCenters
        {
            get
            {
                return this.tableLabourValuesWithCostCenters;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public WorkgroupsWithLabourValuesAndCostCentersDataTable WorkgroupsWithLabourValuesAndCostCenters
        {
            get
            {
                return this.tableWorkgroupsWithLabourValuesAndCostCenters;
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
            MasterDataSet cln = ((MasterDataSet)base.Clone());
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
                if ((!((ds.Tables["EmployeesWithCostCenters"]) == null)))
                {
                    base.Tables.Add(new EmployeesWithCostCentersDataTable(ds.Tables["EmployeesWithCostCenters"]));
                }

                if ((!((ds.Tables["LabourValuesWithCostCenters"]) == null)))
                {
                    base.Tables.Add(new LabourValuesWithCostCentersDataTable(ds.Tables["LabourValuesWithCostCenters"]));
                }

                if ((!((ds.Tables["WorkgroupsWithLabourValuesAndCostCenters"]) == null)))
                {
                    base.Tables.Add(new WorkgroupsWithLabourValuesAndCostCentersDataTable(ds.Tables["WorkgroupsWithLabourValuesAndCostCenters"]));
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
            this.tableEmployeesWithCostCenters = ((EmployeesWithCostCentersDataTable)base.Tables["EmployeesWithCostCenters"]);
            if ((initTable == true))
            {
                if ((!((this.tableEmployeesWithCostCenters) == null)))
                {
                    this.tableEmployeesWithCostCenters.InitVars();
                }
            }

            this.tableLabourValuesWithCostCenters = ((LabourValuesWithCostCentersDataTable)base.Tables["LabourValuesWithCostCenters"]);
            if ((initTable == true))
            {
                if ((!((this.tableLabourValuesWithCostCenters) == null)))
                {
                    this.tableLabourValuesWithCostCenters.InitVars();
                }
            }

            this.tableWorkgroupsWithLabourValuesAndCostCenters = ((WorkgroupsWithLabourValuesAndCostCentersDataTable)base.Tables["WorkgroupsWithLabourValuesAndCostCenters"]);
            if ((initTable == true))
            {
                if ((!((this.tableWorkgroupsWithLabourValuesAndCostCenters) == null)))
                {
                    this.tableWorkgroupsWithLabourValuesAndCostCenters.InitVars();
                }
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitClass()
        {
            this.DataSetName = "MasterDataSet";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/MasterDataSet.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableEmployeesWithCostCenters = new EmployeesWithCostCentersDataTable();
            base.Tables.Add(this.tableEmployeesWithCostCenters);
            this.tableLabourValuesWithCostCenters = new LabourValuesWithCostCentersDataTable();
            base.Tables.Add(this.tableLabourValuesWithCostCenters);
            this.tableWorkgroupsWithLabourValuesAndCostCenters = new WorkgroupsWithLabourValuesAndCostCentersDataTable();
            base.Tables.Add(this.tableWorkgroupsWithLabourValuesAndCostCenters);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private bool ShouldSerializeEmployeesWithCostCenters()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private bool ShouldSerializeLabourValuesWithCostCenters()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private bool ShouldSerializeWorkgroupsWithLabourValuesAndCostCenters()
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
            MasterDataSet ds = new MasterDataSet();
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
        public delegate void EmployeesWithCostCentersRowChangeEventHandler(object sender, EmployeesWithCostCentersRowChangeEvent e);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public delegate void LabourValuesWithCostCentersRowChangeEventHandler(object sender, LabourValuesWithCostCentersRowChangeEvent e);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public delegate void WorkgroupsWithLabourValuesAndCostCentersRowChangeEventHandler(object sender, WorkgroupsWithLabourValuesAndCostCentersRowChangeEvent e);
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class EmployeesWithCostCentersDataTable : System.Data.TypedTableBase<EmployeesWithCostCentersRow>
        {
            private System.Data.DataColumn columnMatchcode;
            private System.Data.DataColumn columnPersonnelNumber;
            private System.Data.DataColumn columnLastName;
            private System.Data.DataColumn columnFirstName;
            private System.Data.DataColumn columnUseFixedWage;
            private System.Data.DataColumn columnDateOfBirth;
            private System.Data.DataColumn columnDateOfJoining;
            private System.Data.DataColumn columnIsActive;
            private System.Data.DataColumn columnIsIncentive;
            private System.Data.DataColumn columnFixedWage;
            private System.Data.DataColumn columnCostCenterNo;
            private System.Data.DataColumn columnCostCenterName;
            private System.Data.DataColumn columnCostCenterDescription;
            private System.Data.DataColumn columnIncentiveIndicatorSynonym;
            private System.Data.DataColumn columnIncentiveWageSynonym;
            private System.Data.DataColumn columnIncentiveIndicatorDimension;
            private System.Data.DataColumn columnIncentiveIndicatorPrecision;
            private System.Data.DataColumn columnTimeCardNo;
            private System.Data.DataColumn columnDateOfSeparation;
            private System.Data.DataColumn columnIsCurrent;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public EmployeesWithCostCentersDataTable() : base()
            {
                this.TableName = "EmployeesWithCostCenters";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal EmployeesWithCostCentersDataTable(System.Data.DataTable table) : base()
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
            protected EmployeesWithCostCentersDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn MatchcodeColumn
            {
                get
                {
                    return this.columnMatchcode;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn PersonnelNumberColumn
            {
                get
                {
                    return this.columnPersonnelNumber;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn LastNameColumn
            {
                get
                {
                    return this.columnLastName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn FirstNameColumn
            {
                get
                {
                    return this.columnFirstName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn UseFixedWageColumn
            {
                get
                {
                    return this.columnUseFixedWage;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn DateOfBirthColumn
            {
                get
                {
                    return this.columnDateOfBirth;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn DateOfJoiningColumn
            {
                get
                {
                    return this.columnDateOfJoining;
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
            public System.Data.DataColumn IsIncentiveColumn
            {
                get
                {
                    return this.columnIsIncentive;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn FixedWageColumn
            {
                get
                {
                    return this.columnFixedWage;
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
            public System.Data.DataColumn TimeCardNoColumn
            {
                get
                {
                    return this.columnTimeCardNo;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn DateOfSeparationColumn
            {
                get
                {
                    return this.columnDateOfSeparation;
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
            public EmployeesWithCostCentersRow this[int index]
            {
                get
                {
                    return ((EmployeesWithCostCentersRow)this.Rows[index]);
                }
            }

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event EmployeesWithCostCentersRowChangeEventHandler EmployeesWithCostCentersRowChanging;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event EmployeesWithCostCentersRowChangeEventHandler EmployeesWithCostCentersRowChanged;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event EmployeesWithCostCentersRowChangeEventHandler EmployeesWithCostCentersRowDeleting;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event EmployeesWithCostCentersRowChangeEventHandler EmployeesWithCostCentersRowDeleted;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void AddEmployeesWithCostCentersRow(EmployeesWithCostCentersRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public EmployeesWithCostCentersRow AddEmployeesWithCostCentersRow(string Matchcode, int PersonnelNumber, string LastName, string FirstName, bool UseFixedWage, System.DateTime DateOfBirth, System.DateTime DateOfJoining, bool IsActive, bool IsIncentive, decimal FixedWage, int CostCenterNo, string CostCenterName, string CostCenterDescription, string IncentiveIndicatorSynonym, string IncentiveWageSynonym, string IncentiveIndicatorDimension, byte IncentiveIndicatorPrecision, string TimeCardNo, System.DateTime DateOfSeparation, bool IsCurrent)
            {
                EmployeesWithCostCentersRow rowEmployeesWithCostCentersRow = ((EmployeesWithCostCentersRow)this.NewRow());
                object[] columnValuesArray = new object[]
                {
                    Matchcode,
                    PersonnelNumber,
                    LastName,
                    FirstName,
                    UseFixedWage,
                    DateOfBirth,
                    DateOfJoining,
                    IsActive,
                    IsIncentive,
                    FixedWage,
                    CostCenterNo,
                    CostCenterName,
                    CostCenterDescription,
                    IncentiveIndicatorSynonym,
                    IncentiveWageSynonym,
                    IncentiveIndicatorDimension,
                    IncentiveIndicatorPrecision,
                    TimeCardNo,
                    DateOfSeparation,
                    IsCurrent
                };
                rowEmployeesWithCostCentersRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowEmployeesWithCostCentersRow);
                return rowEmployeesWithCostCentersRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public override System.Data.DataTable Clone()
            {
                EmployeesWithCostCentersDataTable cln = ((EmployeesWithCostCentersDataTable)base.Clone());
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataTable CreateInstance()
            {
                return new EmployeesWithCostCentersDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal void InitVars()
            {
                this.columnMatchcode = base.Columns["Matchcode"];
                this.columnPersonnelNumber = base.Columns["PersonnelNumber"];
                this.columnLastName = base.Columns["LastName"];
                this.columnFirstName = base.Columns["FirstName"];
                this.columnUseFixedWage = base.Columns["UseFixedWage"];
                this.columnDateOfBirth = base.Columns["DateOfBirth"];
                this.columnDateOfJoining = base.Columns["DateOfJoining"];
                this.columnIsActive = base.Columns["IsActive"];
                this.columnIsIncentive = base.Columns["IsIncentive"];
                this.columnFixedWage = base.Columns["FixedWage"];
                this.columnCostCenterNo = base.Columns["CostCenterNo"];
                this.columnCostCenterName = base.Columns["CostCenterName"];
                this.columnCostCenterDescription = base.Columns["CostCenterDescription"];
                this.columnIncentiveIndicatorSynonym = base.Columns["IncentiveIndicatorSynonym"];
                this.columnIncentiveWageSynonym = base.Columns["IncentiveWageSynonym"];
                this.columnIncentiveIndicatorDimension = base.Columns["IncentiveIndicatorDimension"];
                this.columnIncentiveIndicatorPrecision = base.Columns["IncentiveIndicatorPrecision"];
                this.columnTimeCardNo = base.Columns["TimeCardNo"];
                this.columnDateOfSeparation = base.Columns["DateOfSeparation"];
                this.columnIsCurrent = base.Columns["IsCurrent"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            private void InitClass()
            {
                this.columnMatchcode = new System.Data.DataColumn("Matchcode", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnMatchcode);
                this.columnPersonnelNumber = new System.Data.DataColumn("PersonnelNumber", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnPersonnelNumber);
                this.columnLastName = new System.Data.DataColumn("LastName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLastName);
                this.columnFirstName = new System.Data.DataColumn("FirstName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnFirstName);
                this.columnUseFixedWage = new System.Data.DataColumn("UseFixedWage", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnUseFixedWage);
                this.columnDateOfBirth = new System.Data.DataColumn("DateOfBirth", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnDateOfBirth);
                this.columnDateOfJoining = new System.Data.DataColumn("DateOfJoining", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnDateOfJoining);
                this.columnIsActive = new System.Data.DataColumn("IsActive", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsActive);
                this.columnIsIncentive = new System.Data.DataColumn("IsIncentive", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsIncentive);
                this.columnFixedWage = new System.Data.DataColumn("FixedWage", typeof(decimal), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnFixedWage);
                this.columnCostCenterNo = new System.Data.DataColumn("CostCenterNo", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterNo);
                this.columnCostCenterName = new System.Data.DataColumn("CostCenterName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterName);
                this.columnCostCenterDescription = new System.Data.DataColumn("CostCenterDescription", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterDescription);
                this.columnIncentiveIndicatorSynonym = new System.Data.DataColumn("IncentiveIndicatorSynonym", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorSynonym);
                this.columnIncentiveWageSynonym = new System.Data.DataColumn("IncentiveWageSynonym", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveWageSynonym);
                this.columnIncentiveIndicatorDimension = new System.Data.DataColumn("IncentiveIndicatorDimension", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorDimension);
                this.columnIncentiveIndicatorPrecision = new System.Data.DataColumn("IncentiveIndicatorPrecision", typeof(byte), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIncentiveIndicatorPrecision);
                this.columnTimeCardNo = new System.Data.DataColumn("TimeCardNo", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTimeCardNo);
                this.columnDateOfSeparation = new System.Data.DataColumn("DateOfSeparation", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnDateOfSeparation);
                this.columnIsCurrent = new System.Data.DataColumn("IsCurrent", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsCurrent);
                this.columnMatchcode.MaxLength = 50;
                this.columnPersonnelNumber.AllowDBNull = false;
                this.columnLastName.AllowDBNull = false;
                this.columnLastName.MaxLength = 100;
                this.columnFirstName.AllowDBNull = false;
                this.columnFirstName.MaxLength = 100;
                this.columnUseFixedWage.AllowDBNull = false;
                this.columnIsActive.AllowDBNull = false;
                this.columnIsIncentive.AllowDBNull = false;
                this.columnCostCenterNo.AllowDBNull = false;
                this.columnCostCenterName.AllowDBNull = false;
                this.columnCostCenterName.MaxLength = 100;
                this.columnCostCenterDescription.MaxLength = 4000;
                this.columnIncentiveIndicatorSynonym.AllowDBNull = false;
                this.columnIncentiveIndicatorSynonym.MaxLength = 50;
                this.columnIncentiveWageSynonym.AllowDBNull = false;
                this.columnIncentiveWageSynonym.MaxLength = 50;
                this.columnIncentiveIndicatorDimension.AllowDBNull = false;
                this.columnIncentiveIndicatorDimension.MaxLength = 10;
                this.columnIncentiveIndicatorPrecision.AllowDBNull = false;
                this.columnTimeCardNo.MaxLength = 50;
                this.columnIsCurrent.AllowDBNull = false;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public EmployeesWithCostCentersRow NewEmployeesWithCostCentersRow()
            {
                return ((EmployeesWithCostCentersRow)this.NewRow());
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new EmployeesWithCostCentersRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Type GetRowType()
            {
                return typeof(EmployeesWithCostCentersRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((!((this.EmployeesWithCostCentersRowChanged) == null)))
                {
                    EmployeesWithCostCentersRowChanged?.Invoke(this, new EmployeesWithCostCentersRowChangeEvent(((EmployeesWithCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((!((this.EmployeesWithCostCentersRowChanging) == null)))
                {
                    EmployeesWithCostCentersRowChanging?.Invoke(this, new EmployeesWithCostCentersRowChangeEvent(((EmployeesWithCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((!((this.EmployeesWithCostCentersRowDeleted) == null)))
                {
                    EmployeesWithCostCentersRowDeleted?.Invoke(this, new EmployeesWithCostCentersRowChangeEvent(((EmployeesWithCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((!((this.EmployeesWithCostCentersRowDeleting) == null)))
                {
                    EmployeesWithCostCentersRowDeleting?.Invoke(this, new EmployeesWithCostCentersRowChangeEvent(((EmployeesWithCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void RemoveEmployeesWithCostCentersRow(EmployeesWithCostCentersRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                MasterDataSet ds = new MasterDataSet();
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
                attribute2.FixedValue = "EmployeesWithCostCentersDataTable";
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
        public partial class LabourValuesWithCostCentersDataTable : System.Data.TypedTableBase<LabourValuesWithCostCentersRow>
        {
            private System.Data.DataColumn columnLabourValueNumber;
            private System.Data.DataColumn columnLabourValueName;
            private System.Data.DataColumn columnLabourValueDescription;
            private System.Data.DataColumn columnTeHMin;
            private System.Data.DataColumn columnDimension;
            private System.Data.DataColumn columnIsActive;
            private System.Data.DataColumn columnIsCurrent;
            private System.Data.DataColumn columnCostCenterNo;
            private System.Data.DataColumn columnCostCenterName;
            private System.Data.DataColumn columnIncentiveIndicatorSynonym;
            private System.Data.DataColumn columnIncentiveWageSynonym;
            private System.Data.DataColumn columnIncentiveIndicatorDimension;
            private System.Data.DataColumn columnIncentiveIndicatorPrecision;
            private System.Data.DataColumn columnUseFixValuedBonus;
            private System.Data.DataColumn columnIncentiveIndicatorFactor;
            private System.Data.DataColumn columnBaseValuePrecision;
            private System.Data.DataColumn columnBaseValueSynonym;
            private System.Data.DataColumn columnCostCenterDescription;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public LabourValuesWithCostCentersDataTable() : base()
            {
                this.TableName = "LabourValuesWithCostCenters";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal LabourValuesWithCostCentersDataTable(System.Data.DataTable table) : base()
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
            protected LabourValuesWithCostCentersDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
            {
                this.InitVars();
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
            public System.Data.DataColumn CostCenterDescriptionColumn
            {
                get
                {
                    return this.columnCostCenterDescription;
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
            public LabourValuesWithCostCentersRow this[int index]
            {
                get
                {
                    return ((LabourValuesWithCostCentersRow)this.Rows[index]);
                }
            }

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event LabourValuesWithCostCentersRowChangeEventHandler LabourValuesWithCostCentersRowChanging;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event LabourValuesWithCostCentersRowChangeEventHandler LabourValuesWithCostCentersRowChanged;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event LabourValuesWithCostCentersRowChangeEventHandler LabourValuesWithCostCentersRowDeleting;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event LabourValuesWithCostCentersRowChangeEventHandler LabourValuesWithCostCentersRowDeleted;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void AddLabourValuesWithCostCentersRow(LabourValuesWithCostCentersRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public LabourValuesWithCostCentersRow AddLabourValuesWithCostCentersRow(int LabourValueNumber, string LabourValueName, string LabourValueDescription, double TeHMin, string Dimension, bool IsActive, bool IsCurrent, int CostCenterNo, string CostCenterName, string IncentiveIndicatorSynonym, string IncentiveWageSynonym, string IncentiveIndicatorDimension, byte IncentiveIndicatorPrecision, bool UseFixValuedBonus, double IncentiveIndicatorFactor, byte BaseValuePrecision, string BaseValueSynonym, string CostCenterDescription)
            {
                LabourValuesWithCostCentersRow rowLabourValuesWithCostCentersRow = ((LabourValuesWithCostCentersRow)this.NewRow());
                object[] columnValuesArray = new object[]
                {
                    LabourValueNumber,
                    LabourValueName,
                    LabourValueDescription,
                    TeHMin,
                    Dimension,
                    IsActive,
                    IsCurrent,
                    CostCenterNo,
                    CostCenterName,
                    IncentiveIndicatorSynonym,
                    IncentiveWageSynonym,
                    IncentiveIndicatorDimension,
                    IncentiveIndicatorPrecision,
                    UseFixValuedBonus,
                    IncentiveIndicatorFactor,
                    BaseValuePrecision,
                    BaseValueSynonym,
                    CostCenterDescription
                };
                rowLabourValuesWithCostCentersRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowLabourValuesWithCostCentersRow);
                return rowLabourValuesWithCostCentersRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public override System.Data.DataTable Clone()
            {
                LabourValuesWithCostCentersDataTable cln = ((LabourValuesWithCostCentersDataTable)base.Clone());
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataTable CreateInstance()
            {
                return new LabourValuesWithCostCentersDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal void InitVars()
            {
                this.columnLabourValueNumber = base.Columns["LabourValueNumber"];
                this.columnLabourValueName = base.Columns["LabourValueName"];
                this.columnLabourValueDescription = base.Columns["LabourValueDescription"];
                this.columnTeHMin = base.Columns["TeHMin"];
                this.columnDimension = base.Columns["Dimension"];
                this.columnIsActive = base.Columns["IsActive"];
                this.columnIsCurrent = base.Columns["IsCurrent"];
                this.columnCostCenterNo = base.Columns["CostCenterNo"];
                this.columnCostCenterName = base.Columns["CostCenterName"];
                this.columnIncentiveIndicatorSynonym = base.Columns["IncentiveIndicatorSynonym"];
                this.columnIncentiveWageSynonym = base.Columns["IncentiveWageSynonym"];
                this.columnIncentiveIndicatorDimension = base.Columns["IncentiveIndicatorDimension"];
                this.columnIncentiveIndicatorPrecision = base.Columns["IncentiveIndicatorPrecision"];
                this.columnUseFixValuedBonus = base.Columns["UseFixValuedBonus"];
                this.columnIncentiveIndicatorFactor = base.Columns["IncentiveIndicatorFactor"];
                this.columnBaseValuePrecision = base.Columns["BaseValuePrecision"];
                this.columnBaseValueSynonym = base.Columns["BaseValueSynonym"];
                this.columnCostCenterDescription = base.Columns["CostCenterDescription"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            private void InitClass()
            {
                this.columnLabourValueNumber = new System.Data.DataColumn("LabourValueNumber", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLabourValueNumber);
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
                this.columnCostCenterDescription = new System.Data.DataColumn("CostCenterDescription", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterDescription);
                this.columnLabourValueNumber.AllowDBNull = false;
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
                this.columnCostCenterDescription.MaxLength = 4000;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public LabourValuesWithCostCentersRow NewLabourValuesWithCostCentersRow()
            {
                return ((LabourValuesWithCostCentersRow)this.NewRow());
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new LabourValuesWithCostCentersRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Type GetRowType()
            {
                return typeof(LabourValuesWithCostCentersRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((!((this.LabourValuesWithCostCentersRowChanged) == null)))
                {
                    LabourValuesWithCostCentersRowChanged?.Invoke(this, new LabourValuesWithCostCentersRowChangeEvent(((LabourValuesWithCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((!((this.LabourValuesWithCostCentersRowChanging) == null)))
                {
                    LabourValuesWithCostCentersRowChanging?.Invoke(this, new LabourValuesWithCostCentersRowChangeEvent(((LabourValuesWithCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((!((this.LabourValuesWithCostCentersRowDeleted) == null)))
                {
                    LabourValuesWithCostCentersRowDeleted?.Invoke(this, new LabourValuesWithCostCentersRowChangeEvent(((LabourValuesWithCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((!((this.LabourValuesWithCostCentersRowDeleting) == null)))
                {
                    LabourValuesWithCostCentersRowDeleting?.Invoke(this, new LabourValuesWithCostCentersRowChangeEvent(((LabourValuesWithCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void RemoveLabourValuesWithCostCentersRow(LabourValuesWithCostCentersRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                MasterDataSet ds = new MasterDataSet();
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
                attribute2.FixedValue = "LabourValuesWithCostCentersDataTable";
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
        public partial class WorkgroupsWithLabourValuesAndCostCentersDataTable : System.Data.TypedTableBase<WorkgroupsWithLabourValuesAndCostCentersRow>
        {
            private System.Data.DataColumn columnWorkGroupNumber;
            private System.Data.DataColumn columnWorkgroupName;
            private System.Data.DataColumn columnWorkGroupDescription;
            private System.Data.DataColumn columnLabourValueNumber;
            private System.Data.DataColumn columnLabourValueName;
            private System.Data.DataColumn columnLabourValueDescription;
            private System.Data.DataColumn columnTeHMin;
            private System.Data.DataColumn columnDimension;
            private System.Data.DataColumn columnIsCurrent;
            private System.Data.DataColumn columnLvIsCurrent;
            private System.Data.DataColumn columnIsPeaceWork;
            private System.Data.DataColumn columnIsConceptional;
            private System.Data.DataColumn columnOrdinalNo;
            private System.Data.DataColumn columnWgaOrdinalNumber;
            private System.Data.DataColumn columnCostCenterNo;
            private System.Data.DataColumn columnCostCenterName;
            private System.Data.DataColumn columnLvCostCenterNo;
            private System.Data.DataColumn columnLvCostCenterName;
            private System.Data.DataColumn columnIncentiveIndicatorSynonym;
            private System.Data.DataColumn columnIncentiveWageSynonym;
            private System.Data.DataColumn columnIncentiveIndicatorDimension;
            private System.Data.DataColumn columnIncentiveIndicatorPrecision;
            private System.Data.DataColumn columnUseFixValuedBonus;
            private System.Data.DataColumn columnIncentiveIndicatorFactor;
            private System.Data.DataColumn columnBaseValuePrecision;
            private System.Data.DataColumn columnBaseValueSynonym;
            private System.Data.DataColumn columnWorkloadIWT;
            private System.Data.DataColumn columnIsActive;
            private System.Data.DataColumn columnTimeSettingDetails;
            private System.Data.DataColumn columnLastEdited;
            private System.Data.DataColumn columnWgaLastEdited;
            private System.Data.DataColumn columnLvLastEdited;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public WorkgroupsWithLabourValuesAndCostCentersDataTable() : base()
            {
                this.TableName = "WorkgroupsWithLabourValuesAndCostCenters";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal WorkgroupsWithLabourValuesAndCostCentersDataTable(System.Data.DataTable table) : base()
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
            protected WorkgroupsWithLabourValuesAndCostCentersDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
            {
                this.InitVars();
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
            public System.Data.DataColumn LabourValueNumberColumn
            {
                get
                {
                    return this.columnLabourValueNumber;
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
            public System.Data.DataColumn IsCurrentColumn
            {
                get
                {
                    return this.columnIsCurrent;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn LvIsCurrentColumn
            {
                get
                {
                    return this.columnLvIsCurrent;
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
            public System.Data.DataColumn WgaOrdinalNumberColumn
            {
                get
                {
                    return this.columnWgaOrdinalNumber;
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
            public System.Data.DataColumn LvCostCenterNoColumn
            {
                get
                {
                    return this.columnLvCostCenterNo;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn LvCostCenterNameColumn
            {
                get
                {
                    return this.columnLvCostCenterName;
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
            public System.Data.DataColumn TimeSettingDetailsColumn
            {
                get
                {
                    return this.columnTimeSettingDetails;
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
            public System.Data.DataColumn WgaLastEditedColumn
            {
                get
                {
                    return this.columnWgaLastEdited;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn LvLastEditedColumn
            {
                get
                {
                    return this.columnLvLastEdited;
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
            public WorkgroupsWithLabourValuesAndCostCentersRow this[int index]
            {
                get
                {
                    return ((WorkgroupsWithLabourValuesAndCostCentersRow)this.Rows[index]);
                }
            }

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event WorkgroupsWithLabourValuesAndCostCentersRowChangeEventHandler WorkgroupsWithLabourValuesAndCostCentersRowChanging;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event WorkgroupsWithLabourValuesAndCostCentersRowChangeEventHandler WorkgroupsWithLabourValuesAndCostCentersRowChanged;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event WorkgroupsWithLabourValuesAndCostCentersRowChangeEventHandler WorkgroupsWithLabourValuesAndCostCentersRowDeleting;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event WorkgroupsWithLabourValuesAndCostCentersRowChangeEventHandler WorkgroupsWithLabourValuesAndCostCentersRowDeleted;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void AddWorkgroupsWithLabourValuesAndCostCentersRow(WorkgroupsWithLabourValuesAndCostCentersRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public WorkgroupsWithLabourValuesAndCostCentersRow AddWorkgroupsWithLabourValuesAndCostCentersRow(int WorkGroupNumber, string WorkgroupName, string WorkGroupDescription, int LabourValueNumber, string LabourValueName, string LabourValueDescription, double TeHMin, string Dimension, bool IsCurrent, bool LvIsCurrent, bool IsPeaceWork, bool IsConceptional, int OrdinalNo, int WgaOrdinalNumber, int CostCenterNo, string CostCenterName, int LvCostCenterNo, string LvCostCenterName, string IncentiveIndicatorSynonym, string IncentiveWageSynonym, string IncentiveIndicatorDimension, byte IncentiveIndicatorPrecision, bool UseFixValuedBonus, double IncentiveIndicatorFactor, byte BaseValuePrecision, string BaseValueSynonym, double WorkloadIWT, bool IsActive, string TimeSettingDetails, System.DateTime LastEdited, System.DateTime WgaLastEdited, System.DateTime LvLastEdited)
            {
                WorkgroupsWithLabourValuesAndCostCentersRow rowWorkgroupsWithLabourValuesAndCostCentersRow = ((WorkgroupsWithLabourValuesAndCostCentersRow)this.NewRow());
                object[] columnValuesArray = new object[]
                {
                    WorkGroupNumber,
                    WorkgroupName,
                    WorkGroupDescription,
                    LabourValueNumber,
                    LabourValueName,
                    LabourValueDescription,
                    TeHMin,
                    Dimension,
                    IsCurrent,
                    LvIsCurrent,
                    IsPeaceWork,
                    IsConceptional,
                    OrdinalNo,
                    WgaOrdinalNumber,
                    CostCenterNo,
                    CostCenterName,
                    LvCostCenterNo,
                    LvCostCenterName,
                    IncentiveIndicatorSynonym,
                    IncentiveWageSynonym,
                    IncentiveIndicatorDimension,
                    IncentiveIndicatorPrecision,
                    UseFixValuedBonus,
                    IncentiveIndicatorFactor,
                    BaseValuePrecision,
                    BaseValueSynonym,
                    WorkloadIWT,
                    IsActive,
                    TimeSettingDetails,
                    LastEdited,
                    WgaLastEdited,
                    LvLastEdited
                };
                rowWorkgroupsWithLabourValuesAndCostCentersRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowWorkgroupsWithLabourValuesAndCostCentersRow);
                return rowWorkgroupsWithLabourValuesAndCostCentersRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public override System.Data.DataTable Clone()
            {
                WorkgroupsWithLabourValuesAndCostCentersDataTable cln = ((WorkgroupsWithLabourValuesAndCostCentersDataTable)base.Clone());
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataTable CreateInstance()
            {
                return new WorkgroupsWithLabourValuesAndCostCentersDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal void InitVars()
            {
                this.columnWorkGroupNumber = base.Columns["WorkGroupNumber"];
                this.columnWorkgroupName = base.Columns["WorkgroupName"];
                this.columnWorkGroupDescription = base.Columns["WorkGroupDescription"];
                this.columnLabourValueNumber = base.Columns["LabourValueNumber"];
                this.columnLabourValueName = base.Columns["LabourValueName"];
                this.columnLabourValueDescription = base.Columns["LabourValueDescription"];
                this.columnTeHMin = base.Columns["TeHMin"];
                this.columnDimension = base.Columns["Dimension"];
                this.columnIsCurrent = base.Columns["IsCurrent"];
                this.columnLvIsCurrent = base.Columns["LvIsCurrent"];
                this.columnIsPeaceWork = base.Columns["IsPeaceWork"];
                this.columnIsConceptional = base.Columns["IsConceptional"];
                this.columnOrdinalNo = base.Columns["OrdinalNo"];
                this.columnWgaOrdinalNumber = base.Columns["WgaOrdinalNumber"];
                this.columnCostCenterNo = base.Columns["CostCenterNo"];
                this.columnCostCenterName = base.Columns["CostCenterName"];
                this.columnLvCostCenterNo = base.Columns["LvCostCenterNo"];
                this.columnLvCostCenterName = base.Columns["LvCostCenterName"];
                this.columnIncentiveIndicatorSynonym = base.Columns["IncentiveIndicatorSynonym"];
                this.columnIncentiveWageSynonym = base.Columns["IncentiveWageSynonym"];
                this.columnIncentiveIndicatorDimension = base.Columns["IncentiveIndicatorDimension"];
                this.columnIncentiveIndicatorPrecision = base.Columns["IncentiveIndicatorPrecision"];
                this.columnUseFixValuedBonus = base.Columns["UseFixValuedBonus"];
                this.columnIncentiveIndicatorFactor = base.Columns["IncentiveIndicatorFactor"];
                this.columnBaseValuePrecision = base.Columns["BaseValuePrecision"];
                this.columnBaseValueSynonym = base.Columns["BaseValueSynonym"];
                this.columnWorkloadIWT = base.Columns["WorkloadIWT"];
                this.columnIsActive = base.Columns["IsActive"];
                this.columnTimeSettingDetails = base.Columns["TimeSettingDetails"];
                this.columnLastEdited = base.Columns["LastEdited"];
                this.columnWgaLastEdited = base.Columns["WgaLastEdited"];
                this.columnLvLastEdited = base.Columns["LvLastEdited"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            private void InitClass()
            {
                this.columnWorkGroupNumber = new System.Data.DataColumn("WorkGroupNumber", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkGroupNumber);
                this.columnWorkgroupName = new System.Data.DataColumn("WorkgroupName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkgroupName);
                this.columnWorkGroupDescription = new System.Data.DataColumn("WorkGroupDescription", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkGroupDescription);
                this.columnLabourValueNumber = new System.Data.DataColumn("LabourValueNumber", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLabourValueNumber);
                this.columnLabourValueName = new System.Data.DataColumn("LabourValueName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLabourValueName);
                this.columnLabourValueDescription = new System.Data.DataColumn("LabourValueDescription", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLabourValueDescription);
                this.columnTeHMin = new System.Data.DataColumn("TeHMin", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTeHMin);
                this.columnDimension = new System.Data.DataColumn("Dimension", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnDimension);
                this.columnIsCurrent = new System.Data.DataColumn("IsCurrent", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsCurrent);
                this.columnLvIsCurrent = new System.Data.DataColumn("LvIsCurrent", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLvIsCurrent);
                this.columnIsPeaceWork = new System.Data.DataColumn("IsPeaceWork", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsPeaceWork);
                this.columnIsConceptional = new System.Data.DataColumn("IsConceptional", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsConceptional);
                this.columnOrdinalNo = new System.Data.DataColumn("OrdinalNo", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnOrdinalNo);
                this.columnWgaOrdinalNumber = new System.Data.DataColumn("WgaOrdinalNumber", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWgaOrdinalNumber);
                this.columnCostCenterNo = new System.Data.DataColumn("CostCenterNo", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterNo);
                this.columnCostCenterName = new System.Data.DataColumn("CostCenterName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterName);
                this.columnLvCostCenterNo = new System.Data.DataColumn("LvCostCenterNo", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLvCostCenterNo);
                this.columnLvCostCenterName = new System.Data.DataColumn("LvCostCenterName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLvCostCenterName);
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
                this.columnWorkloadIWT = new System.Data.DataColumn("WorkloadIWT", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkloadIWT);
                this.columnIsActive = new System.Data.DataColumn("IsActive", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsActive);
                this.columnTimeSettingDetails = new System.Data.DataColumn("TimeSettingDetails", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTimeSettingDetails);
                this.columnLastEdited = new System.Data.DataColumn("LastEdited", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLastEdited);
                this.columnWgaLastEdited = new System.Data.DataColumn("WgaLastEdited", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWgaLastEdited);
                this.columnLvLastEdited = new System.Data.DataColumn("LvLastEdited", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLvLastEdited);
                this.columnWorkgroupName.MaxLength = 100;
                this.columnWorkGroupDescription.MaxLength = 4000;
                this.columnLabourValueName.MaxLength = 100;
                this.columnLabourValueDescription.MaxLength = 2147483647;
                this.columnDimension.MaxLength = 100;
                this.columnWgaOrdinalNumber.AllowDBNull = false;
                this.columnCostCenterName.MaxLength = 100;
                this.columnLvCostCenterName.MaxLength = 100;
                this.columnIncentiveIndicatorSynonym.MaxLength = 50;
                this.columnIncentiveWageSynonym.MaxLength = 50;
                this.columnIncentiveIndicatorDimension.MaxLength = 10;
                this.columnBaseValueSynonym.MaxLength = 50;
                this.columnTimeSettingDetails.MaxLength = 2147483647;
                this.columnWgaLastEdited.AllowDBNull = false;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public WorkgroupsWithLabourValuesAndCostCentersRow NewWorkgroupsWithLabourValuesAndCostCentersRow()
            {
                return ((WorkgroupsWithLabourValuesAndCostCentersRow)this.NewRow());
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new WorkgroupsWithLabourValuesAndCostCentersRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Type GetRowType()
            {
                return typeof(WorkgroupsWithLabourValuesAndCostCentersRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((!((this.WorkgroupsWithLabourValuesAndCostCentersRowChanged) == null)))
                {
                    WorkgroupsWithLabourValuesAndCostCentersRowChanged?.Invoke(this, new WorkgroupsWithLabourValuesAndCostCentersRowChangeEvent(((WorkgroupsWithLabourValuesAndCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((!((this.WorkgroupsWithLabourValuesAndCostCentersRowChanging) == null)))
                {
                    WorkgroupsWithLabourValuesAndCostCentersRowChanging?.Invoke(this, new WorkgroupsWithLabourValuesAndCostCentersRowChangeEvent(((WorkgroupsWithLabourValuesAndCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((!((this.WorkgroupsWithLabourValuesAndCostCentersRowDeleted) == null)))
                {
                    WorkgroupsWithLabourValuesAndCostCentersRowDeleted?.Invoke(this, new WorkgroupsWithLabourValuesAndCostCentersRowChangeEvent(((WorkgroupsWithLabourValuesAndCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((!((this.WorkgroupsWithLabourValuesAndCostCentersRowDeleting) == null)))
                {
                    WorkgroupsWithLabourValuesAndCostCentersRowDeleting?.Invoke(this, new WorkgroupsWithLabourValuesAndCostCentersRowChangeEvent(((WorkgroupsWithLabourValuesAndCostCentersRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void RemoveWorkgroupsWithLabourValuesAndCostCentersRow(WorkgroupsWithLabourValuesAndCostCentersRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                MasterDataSet ds = new MasterDataSet();
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
                attribute2.FixedValue = "WorkgroupsWithLabourValuesAndCostCentersDataTable";
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
        public partial class EmployeesWithCostCentersRow : System.Data.DataRow
        {
            private EmployeesWithCostCentersDataTable tableEmployeesWithCostCenters;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal EmployeesWithCostCentersRow(System.Data.DataRowBuilder rb) : base(rb)
            {
                this.tableEmployeesWithCostCenters = ((EmployeesWithCostCentersDataTable)this.Table);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string Matchcode
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableEmployeesWithCostCenters.MatchcodeColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'Matchcode' in table 'EmployeesWithCostCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.MatchcodeColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int PersonnelNumber
            {
                get
                {
                    return ((int)this[this.tableEmployeesWithCostCenters.PersonnelNumberColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.PersonnelNumberColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string LastName
            {
                get
                {
                    return ((string)this[this.tableEmployeesWithCostCenters.LastNameColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.LastNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string FirstName
            {
                get
                {
                    return ((string)this[this.tableEmployeesWithCostCenters.FirstNameColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.FirstNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool UseFixedWage
            {
                get
                {
                    return ((bool)this[this.tableEmployeesWithCostCenters.UseFixedWageColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.UseFixedWageColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime DateOfBirth
            {
                get
                {
                    try
                    {
                        return ((System.DateTime)this[this.tableEmployeesWithCostCenters.DateOfBirthColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'DateOfBirth' in table 'EmployeesWithCostCenters' is DBNull." + "", e);
                    }

                    return default(System.DateTime);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.DateOfBirthColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime DateOfJoining
            {
                get
                {
                    try
                    {
                        return ((System.DateTime)this[this.tableEmployeesWithCostCenters.DateOfJoiningColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'DateOfJoining' in table 'EmployeesWithCostCenters' is DBNul" + "l.", e);
                    }

                    return default(System.DateTime);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.DateOfJoiningColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsActive
            {
                get
                {
                    return ((bool)this[this.tableEmployeesWithCostCenters.IsActiveColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.IsActiveColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIncentive
            {
                get
                {
                    return ((bool)this[this.tableEmployeesWithCostCenters.IsIncentiveColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.IsIncentiveColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public decimal FixedWage
            {
                get
                {
                    try
                    {
                        return ((decimal)this[this.tableEmployeesWithCostCenters.FixedWageColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'FixedWage' in table 'EmployeesWithCostCenters' is DBNull.", e);
                    }

                    return default(decimal);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.FixedWageColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int CostCenterNo
            {
                get
                {
                    return ((int)this[this.tableEmployeesWithCostCenters.CostCenterNoColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.CostCenterNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string CostCenterName
            {
                get
                {
                    return ((string)this[this.tableEmployeesWithCostCenters.CostCenterNameColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.CostCenterNameColumn] = value;
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
                        return ((string)this[this.tableEmployeesWithCostCenters.CostCenterDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'CostCenterDescription' in table 'EmployeesWithCostCenters' " + "is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.CostCenterDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorSynonym
            {
                get
                {
                    return ((string)this[this.tableEmployeesWithCostCenters.IncentiveIndicatorSynonymColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.IncentiveIndicatorSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveWageSynonym
            {
                get
                {
                    return ((string)this[this.tableEmployeesWithCostCenters.IncentiveWageSynonymColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.IncentiveWageSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorDimension
            {
                get
                {
                    return ((string)this[this.tableEmployeesWithCostCenters.IncentiveIndicatorDimensionColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.IncentiveIndicatorDimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte IncentiveIndicatorPrecision
            {
                get
                {
                    return ((byte)this[this.tableEmployeesWithCostCenters.IncentiveIndicatorPrecisionColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.IncentiveIndicatorPrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string TimeCardNo
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableEmployeesWithCostCenters.TimeCardNoColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'TimeCardNo' in table 'EmployeesWithCostCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.TimeCardNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime DateOfSeparation
            {
                get
                {
                    try
                    {
                        return ((System.DateTime)this[this.tableEmployeesWithCostCenters.DateOfSeparationColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'DateOfSeparation' in table 'EmployeesWithCostCenters' is DB" + "Null.", e);
                    }

                    return default(System.DateTime);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.DateOfSeparationColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCurrent
            {
                get
                {
                    return ((bool)this[this.tableEmployeesWithCostCenters.IsCurrentColumn]);
                }

                set
                {
                    this[this.tableEmployeesWithCostCenters.IsCurrentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsMatchcodeNull()
            {
                return this.IsNull(this.tableEmployeesWithCostCenters.MatchcodeColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetMatchcodeNull()
            {
                this[this.tableEmployeesWithCostCenters.MatchcodeColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsDateOfBirthNull()
            {
                return this.IsNull(this.tableEmployeesWithCostCenters.DateOfBirthColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetDateOfBirthNull()
            {
                this[this.tableEmployeesWithCostCenters.DateOfBirthColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsDateOfJoiningNull()
            {
                return this.IsNull(this.tableEmployeesWithCostCenters.DateOfJoiningColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetDateOfJoiningNull()
            {
                this[this.tableEmployeesWithCostCenters.DateOfJoiningColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsFixedWageNull()
            {
                return this.IsNull(this.tableEmployeesWithCostCenters.FixedWageColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetFixedWageNull()
            {
                this[this.tableEmployeesWithCostCenters.FixedWageColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCostCenterDescriptionNull()
            {
                return this.IsNull(this.tableEmployeesWithCostCenters.CostCenterDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetCostCenterDescriptionNull()
            {
                this[this.tableEmployeesWithCostCenters.CostCenterDescriptionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsTimeCardNoNull()
            {
                return this.IsNull(this.tableEmployeesWithCostCenters.TimeCardNoColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetTimeCardNoNull()
            {
                this[this.tableEmployeesWithCostCenters.TimeCardNoColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsDateOfSeparationNull()
            {
                return this.IsNull(this.tableEmployeesWithCostCenters.DateOfSeparationColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetDateOfSeparationNull()
            {
                this[this.tableEmployeesWithCostCenters.DateOfSeparationColumn] = global::System.Convert.DBNull;
            }
        }

        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        public partial class LabourValuesWithCostCentersRow : System.Data.DataRow
        {
            private LabourValuesWithCostCentersDataTable tableLabourValuesWithCostCenters;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal LabourValuesWithCostCentersRow(System.Data.DataRowBuilder rb) : base(rb)
            {
                this.tableLabourValuesWithCostCenters = ((LabourValuesWithCostCentersDataTable)this.Table);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int LabourValueNumber
            {
                get
                {
                    return ((int)this[this.tableLabourValuesWithCostCenters.LabourValueNumberColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.LabourValueNumberColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string LabourValueName
            {
                get
                {
                    return ((string)this[this.tableLabourValuesWithCostCenters.LabourValueNameColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.LabourValueNameColumn] = value;
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
                        return ((string)this[this.tableLabourValuesWithCostCenters.LabourValueDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LabourValueDescription' in table 'LabourValuesWithCostCente" + "rs' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.LabourValueDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double TeHMin
            {
                get
                {
                    return ((double)this[this.tableLabourValuesWithCostCenters.TeHMinColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.TeHMinColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string Dimension
            {
                get
                {
                    return ((string)this[this.tableLabourValuesWithCostCenters.DimensionColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.DimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsActive
            {
                get
                {
                    return ((bool)this[this.tableLabourValuesWithCostCenters.IsActiveColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.IsActiveColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCurrent
            {
                get
                {
                    return ((bool)this[this.tableLabourValuesWithCostCenters.IsCurrentColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.IsCurrentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int CostCenterNo
            {
                get
                {
                    return ((int)this[this.tableLabourValuesWithCostCenters.CostCenterNoColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.CostCenterNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string CostCenterName
            {
                get
                {
                    return ((string)this[this.tableLabourValuesWithCostCenters.CostCenterNameColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.CostCenterNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorSynonym
            {
                get
                {
                    return ((string)this[this.tableLabourValuesWithCostCenters.IncentiveIndicatorSynonymColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.IncentiveIndicatorSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveWageSynonym
            {
                get
                {
                    return ((string)this[this.tableLabourValuesWithCostCenters.IncentiveWageSynonymColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.IncentiveWageSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorDimension
            {
                get
                {
                    return ((string)this[this.tableLabourValuesWithCostCenters.IncentiveIndicatorDimensionColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.IncentiveIndicatorDimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte IncentiveIndicatorPrecision
            {
                get
                {
                    return ((byte)this[this.tableLabourValuesWithCostCenters.IncentiveIndicatorPrecisionColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.IncentiveIndicatorPrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool UseFixValuedBonus
            {
                get
                {
                    return ((bool)this[this.tableLabourValuesWithCostCenters.UseFixValuedBonusColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.UseFixValuedBonusColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double IncentiveIndicatorFactor
            {
                get
                {
                    return ((double)this[this.tableLabourValuesWithCostCenters.IncentiveIndicatorFactorColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.IncentiveIndicatorFactorColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte BaseValuePrecision
            {
                get
                {
                    return ((byte)this[this.tableLabourValuesWithCostCenters.BaseValuePrecisionColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.BaseValuePrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string BaseValueSynonym
            {
                get
                {
                    return ((string)this[this.tableLabourValuesWithCostCenters.BaseValueSynonymColumn]);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.BaseValueSynonymColumn] = value;
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
                        return ((string)this[this.tableLabourValuesWithCostCenters.CostCenterDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'CostCenterDescription' in table 'LabourValuesWithCostCenter" + "s' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableLabourValuesWithCostCenters.CostCenterDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLabourValueDescriptionNull()
            {
                return this.IsNull(this.tableLabourValuesWithCostCenters.LabourValueDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLabourValueDescriptionNull()
            {
                this[this.tableLabourValuesWithCostCenters.LabourValueDescriptionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCostCenterDescriptionNull()
            {
                return this.IsNull(this.tableLabourValuesWithCostCenters.CostCenterDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetCostCenterDescriptionNull()
            {
                this[this.tableLabourValuesWithCostCenters.CostCenterDescriptionColumn] = global::System.Convert.DBNull;
            }
        }

        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        public partial class WorkgroupsWithLabourValuesAndCostCentersRow : System.Data.DataRow
        {
            private WorkgroupsWithLabourValuesAndCostCentersDataTable tableWorkgroupsWithLabourValuesAndCostCenters;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal WorkgroupsWithLabourValuesAndCostCentersRow(System.Data.DataRowBuilder rb) : base(rb)
            {
                this.tableWorkgroupsWithLabourValuesAndCostCenters = ((WorkgroupsWithLabourValuesAndCostCentersDataTable)this.Table);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int WorkGroupNumber
            {
                get
                {
                    try
                    {
                        return ((int)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkGroupNumberColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'WorkGroupNumber' in table 'WorkgroupsWithLabourValuesAndCos" + "tCenters' is DBNull.", e);
                    }

                    return default(int);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkGroupNumberColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string WorkgroupName
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkgroupNameColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'WorkgroupName' in table 'WorkgroupsWithLabourValuesAndCostC" + "enters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkgroupNameColumn] = value;
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
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkGroupDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'WorkGroupDescription' in table 'WorkgroupsWithLabourValuesA" + "ndCostCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkGroupDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int LabourValueNumber
            {
                get
                {
                    try
                    {
                        return ((int)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueNumberColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LabourValueNumber' in table 'WorkgroupsWithLabourValuesAndC" + "ostCenters' is DBNull.", e);
                    }

                    return default(int);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueNumberColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string LabourValueName
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueNameColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LabourValueName' in table 'WorkgroupsWithLabourValuesAndCos" + "tCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueNameColumn] = value;
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
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LabourValueDescription' in table 'WorkgroupsWithLabourValue" + "sAndCostCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double TeHMin
            {
                get
                {
                    try
                    {
                        return ((double)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.TeHMinColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'TeHMin' in table 'WorkgroupsWithLabourValuesAndCostCenters'" + " is DBNull.", e);
                    }

                    return default(double);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.TeHMinColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string Dimension
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.DimensionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'Dimension' in table 'WorkgroupsWithLabourValuesAndCostCente" + "rs' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.DimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCurrent
            {
                get
                {
                    try
                    {
                        return ((bool)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsCurrentColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'IsCurrent' in table 'WorkgroupsWithLabourValuesAndCostCente" + "rs' is DBNull.", e);
                    }

                    return default(bool);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsCurrentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool LvIsCurrent
            {
                get
                {
                    try
                    {
                        return ((bool)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvIsCurrentColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LvIsCurrent' in table 'WorkgroupsWithLabourValuesAndCostCen" + "ters' is DBNull.", e);
                    }

                    return default(bool);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvIsCurrentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsPeaceWork
            {
                get
                {
                    try
                    {
                        return ((bool)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsPeaceWorkColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'IsPeaceWork' in table 'WorkgroupsWithLabourValuesAndCostCen" + "ters' is DBNull.", e);
                    }

                    return default(bool);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsPeaceWorkColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsConceptional
            {
                get
                {
                    try
                    {
                        return ((bool)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsConceptionalColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'IsConceptional' in table 'WorkgroupsWithLabourValuesAndCost" + "Centers' is DBNull.", e);
                    }

                    return default(bool);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsConceptionalColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int OrdinalNo
            {
                get
                {
                    try
                    {
                        return ((int)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.OrdinalNoColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'OrdinalNo' in table 'WorkgroupsWithLabourValuesAndCostCente" + "rs' is DBNull.", e);
                    }

                    return default(int);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.OrdinalNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int WgaOrdinalNumber
            {
                get
                {
                    return ((int)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WgaOrdinalNumberColumn]);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WgaOrdinalNumberColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int CostCenterNo
            {
                get
                {
                    try
                    {
                        return ((int)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.CostCenterNoColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'CostCenterNo' in table 'WorkgroupsWithLabourValuesAndCostCe" + "nters' is DBNull.", e);
                    }

                    return default(int);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.CostCenterNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string CostCenterName
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.CostCenterNameColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'CostCenterName' in table 'WorkgroupsWithLabourValuesAndCost" + "Centers' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.CostCenterNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int LvCostCenterNo
            {
                get
                {
                    try
                    {
                        return ((int)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvCostCenterNoColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LvCostCenterNo' in table 'WorkgroupsWithLabourValuesAndCost" + "Centers' is DBNull.", e);
                    }

                    return default(int);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvCostCenterNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string LvCostCenterName
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvCostCenterNameColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LvCostCenterName' in table 'WorkgroupsWithLabourValuesAndCo" + "stCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvCostCenterNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorSynonym
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorSynonymColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'IncentiveIndicatorSynonym' in table 'WorkgroupsWithLabourVa" + "luesAndCostCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveWageSynonym
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveWageSynonymColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'IncentiveWageSynonym' in table 'WorkgroupsWithLabourValuesA" + "ndCostCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveWageSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorDimension
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorDimensionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'IncentiveIndicatorDimension' in table 'WorkgroupsWithLabour" + "ValuesAndCostCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorDimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte IncentiveIndicatorPrecision
            {
                get
                {
                    try
                    {
                        return ((byte)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorPrecisionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'IncentiveIndicatorPrecision' in table 'WorkgroupsWithLabour" + "ValuesAndCostCenters' is DBNull.", e);
                    }

                    return default(byte);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorPrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool UseFixValuedBonus
            {
                get
                {
                    try
                    {
                        return ((bool)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.UseFixValuedBonusColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'UseFixValuedBonus' in table 'WorkgroupsWithLabourValuesAndC" + "ostCenters' is DBNull.", e);
                    }

                    return default(bool);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.UseFixValuedBonusColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double IncentiveIndicatorFactor
            {
                get
                {
                    try
                    {
                        return ((double)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorFactorColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'IncentiveIndicatorFactor' in table 'WorkgroupsWithLabourVal" + "uesAndCostCenters' is DBNull.", e);
                    }

                    return default(double);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorFactorColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte BaseValuePrecision
            {
                get
                {
                    try
                    {
                        return ((byte)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.BaseValuePrecisionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'BaseValuePrecision' in table 'WorkgroupsWithLabourValuesAnd" + "CostCenters' is DBNull.", e);
                    }

                    return default(byte);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.BaseValuePrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string BaseValueSynonym
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.BaseValueSynonymColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'BaseValueSynonym' in table 'WorkgroupsWithLabourValuesAndCo" + "stCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.BaseValueSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double WorkloadIWT
            {
                get
                {
                    try
                    {
                        return ((double)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkloadIWTColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'WorkloadIWT' in table 'WorkgroupsWithLabourValuesAndCostCen" + "ters' is DBNull.", e);
                    }

                    return default(double);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkloadIWTColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsActive
            {
                get
                {
                    try
                    {
                        return ((bool)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsActiveColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'IsActive' in table 'WorkgroupsWithLabourValuesAndCostCenter" + "s' is DBNull.", e);
                    }

                    return default(bool);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsActiveColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string TimeSettingDetails
            {
                get
                {
                    try
                    {
                        return ((string)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.TimeSettingDetailsColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'TimeSettingDetails' in table 'WorkgroupsWithLabourValuesAnd" + "CostCenters' is DBNull.", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.TimeSettingDetailsColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime LastEdited
            {
                get
                {
                    try
                    {
                        return ((System.DateTime)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LastEditedColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LastEdited' in table 'WorkgroupsWithLabourValuesAndCostCent" + "ers' is DBNull.", e);
                    }

                    return default(System.DateTime);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LastEditedColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime WgaLastEdited
            {
                get
                {
                    return ((System.DateTime)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WgaLastEditedColumn]);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WgaLastEditedColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime LvLastEdited
            {
                get
                {
                    try
                    {
                        return ((System.DateTime)this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvLastEditedColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LvLastEdited' in table 'WorkgroupsWithLabourValuesAndCostCe" + "nters' is DBNull.", e);
                    }

                    return default(System.DateTime);
                }

                set
                {
                    this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvLastEditedColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsWorkGroupNumberNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkGroupNumberColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetWorkGroupNumberNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkGroupNumberColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsWorkgroupNameNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkgroupNameColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetWorkgroupNameNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkgroupNameColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsWorkGroupDescriptionNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkGroupDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetWorkGroupDescriptionNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkGroupDescriptionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLabourValueNumberNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueNumberColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLabourValueNumberNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueNumberColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLabourValueNameNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueNameColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLabourValueNameNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueNameColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLabourValueDescriptionNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLabourValueDescriptionNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LabourValueDescriptionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsTeHMinNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.TeHMinColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetTeHMinNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.TeHMinColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsDimensionNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.DimensionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetDimensionNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.DimensionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIsCurrentNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.IsCurrentColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetIsCurrentNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsCurrentColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLvIsCurrentNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.LvIsCurrentColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLvIsCurrentNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvIsCurrentColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIsPeaceWorkNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.IsPeaceWorkColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetIsPeaceWorkNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsPeaceWorkColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIsConceptionalNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.IsConceptionalColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetIsConceptionalNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsConceptionalColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsOrdinalNoNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.OrdinalNoColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetOrdinalNoNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.OrdinalNoColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCostCenterNoNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.CostCenterNoColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetCostCenterNoNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.CostCenterNoColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCostCenterNameNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.CostCenterNameColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetCostCenterNameNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.CostCenterNameColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLvCostCenterNoNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.LvCostCenterNoColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLvCostCenterNoNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvCostCenterNoColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLvCostCenterNameNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.LvCostCenterNameColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLvCostCenterNameNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvCostCenterNameColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIncentiveIndicatorSynonymNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorSynonymColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetIncentiveIndicatorSynonymNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorSynonymColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIncentiveWageSynonymNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveWageSynonymColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetIncentiveWageSynonymNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveWageSynonymColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIncentiveIndicatorDimensionNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorDimensionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetIncentiveIndicatorDimensionNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorDimensionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIncentiveIndicatorPrecisionNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorPrecisionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetIncentiveIndicatorPrecisionNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorPrecisionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsUseFixValuedBonusNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.UseFixValuedBonusColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetUseFixValuedBonusNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.UseFixValuedBonusColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIncentiveIndicatorFactorNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorFactorColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetIncentiveIndicatorFactorNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IncentiveIndicatorFactorColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsBaseValuePrecisionNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.BaseValuePrecisionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetBaseValuePrecisionNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.BaseValuePrecisionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsBaseValueSynonymNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.BaseValueSynonymColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetBaseValueSynonymNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.BaseValueSynonymColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsWorkloadIWTNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkloadIWTColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetWorkloadIWTNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.WorkloadIWTColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsIsActiveNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.IsActiveColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetIsActiveNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.IsActiveColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsTimeSettingDetailsNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.TimeSettingDetailsColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetTimeSettingDetailsNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.TimeSettingDetailsColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLastEditedNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.LastEditedColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLastEditedNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LastEditedColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLvLastEditedNull()
            {
                return this.IsNull(this.tableWorkgroupsWithLabourValuesAndCostCenters.LvLastEditedColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLvLastEditedNull()
            {
                this[this.tableWorkgroupsWithLabourValuesAndCostCenters.LvLastEditedColumn] = global::System.Convert.DBNull;
            }
        }

        /// <summary>
        ///Row event argument class
        ///</summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public class EmployeesWithCostCentersRowChangeEvent : System.EventArgs
        {
            private EmployeesWithCostCentersRow eventRow;
            private System.Data.DataRowAction eventAction;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public EmployeesWithCostCentersRowChangeEvent(EmployeesWithCostCentersRow row, System.Data.DataRowAction action) : base()
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public EmployeesWithCostCentersRow Row
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
        public class LabourValuesWithCostCentersRowChangeEvent : System.EventArgs
        {
            private LabourValuesWithCostCentersRow eventRow;
            private System.Data.DataRowAction eventAction;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public LabourValuesWithCostCentersRowChangeEvent(LabourValuesWithCostCentersRow row, System.Data.DataRowAction action) : base()
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public LabourValuesWithCostCentersRow Row
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
        public class WorkgroupsWithLabourValuesAndCostCentersRowChangeEvent : System.EventArgs
        {
            private WorkgroupsWithLabourValuesAndCostCentersRow eventRow;
            private System.Data.DataRowAction eventAction;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public WorkgroupsWithLabourValuesAndCostCentersRowChangeEvent(WorkgroupsWithLabourValuesAndCostCentersRow row, System.Data.DataRowAction action) : base()
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public WorkgroupsWithLabourValuesAndCostCentersRow Row
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
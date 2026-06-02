using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions.dsLabourValuesTableAdapters
{
    /// <summary>
    ///Represents the connection and commands used to retrieve and save data.
    ///</summary>
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.ComponentModel.DataObjectAttribute(true)]
    [System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" + ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
    public partial class dtLabourValuesTableAdapter : System.ComponentModel.Component
    {
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        private System.Data.SqlClient.SqlConnection _connection;
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public dtLabourValuesTableAdapter() : base()
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
            tableMapping.DataSetTable = "dtLabourValues";
            tableMapping.ColumnMappings.Add("IDLabourValue", "IDLabourValue");
            tableMapping.ColumnMappings.Add("IDSubsidiary", "IDSubsidiary");
            tableMapping.ColumnMappings.Add("IDLabourValueInternal", "IDLabourValueInternal");
            tableMapping.ColumnMappings.Add("IDCostCenter", "IDCostCenter");
            tableMapping.ColumnMappings.Add("LabourValueNumber", "LabourValueNumber");
            tableMapping.ColumnMappings.Add("LabourValueName", "LabourValueName");
            tableMapping.ColumnMappings.Add("LabourValueDescription", "LabourValueDescription");
            tableMapping.ColumnMappings.Add("TeHMin", "TeHMin");
            tableMapping.ColumnMappings.Add("Dimension", "Dimension");
            tableMapping.ColumnMappings.Add("IsActive", "IsActive");
            tableMapping.ColumnMappings.Add("IsCurrent", "IsCurrent");
            tableMapping.ColumnMappings.Add("WasCurrentFrom", "WasCurrentFrom");
            tableMapping.ColumnMappings.Add("WasCurrentTo", "WasCurrentTo");
            tableMapping.ColumnMappings.Add("LastEdited", "LastEdited");
            tableMapping.ColumnMappings.Add("IDCostCenterInternal", "IDCostCenterInternal");
            tableMapping.ColumnMappings.Add("IsCostCenterCurrent", "IsCostCenterCurrent");
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
            tableMapping.ColumnMappings.Add("CostCenterWasCurrentFrom", "CostCenterWasCurrentFrom");
            tableMapping.ColumnMappings.Add("CostCenterWasCurrentTo", "CostCenterWasCurrentTo");
            tableMapping.ColumnMappings.Add("CostCenterLastEdited", "CostCenterLastEdited");
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
            this._commandCollection = new System.Data.SqlClient.SqlCommand[2];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT     LabourValues.IDLabourValue, LabourValues.IDSubsidiary, LabourValues.ID" + "LabourValueInternal, LabourValues.IDCostCenter, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourVa" + "lues.LabourValueNumber, LabourValues.LabourValueName, LabourValues.LabourValueDe" + "scription, LabourValues.TeHMin, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourValues.Dimension, " + "LabourValues.IsActive, LabourValues.IsCurrent, LabourValues.WasCurrentFrom, Labo" + "urValues.WasCurrentTo, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourValues.LastEdited, CostCent" + "ers.IDCostCenterInternal, CostCenters.IsCurrent AS IsCostCenterCurrent, CostCent" + "ers.CostCenterNo, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.CostCenterName, CostCenter" + "s.CostCenterDescription, CostCenters.IDCurrency, CostCenters.IncentiveIndicatorS" + "ynonym, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.IncentiveWageSynonym, CostCenters.In" + "centiveIndicatorDimension, CostCenters.IncentiveIndicatorPrecision, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "          " + "            CostCenters.UseFixValuedBonus, CostCenters.IncentiveIndicatorFactor," + " CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "               " + "       CostCenters.WasCurrentFrom AS CostCenterWasCurrentFrom, CostCenters.WasCu" + "rrentTo AS CostCenterWasCurrentTo, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.LastEdite" + "d AS CostCenterLastEdited" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "FROM         LabourValues INNER JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "               " + "       CostCenters ON LabourValues.IDCostCenter = CostCenters.IDCostCenter";
            this._commandCollection[0].CommandType = global::System.Data.CommandType.Text;
            this._commandCollection[1] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "SELECT     LabourValues.IDLabourValue, LabourValues.IDSubsidiary, LabourValues.ID" + "LabourValueInternal, LabourValues.IDCostCenter, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourVa" + "lues.LabourValueNumber, LabourValues.LabourValueName, LabourValues.LabourValueDe" + "scription, LabourValues.TeHMin, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourValues.Dimension, " + "LabourValues.IsActive, LabourValues.IsCurrent, LabourValues.WasCurrentFrom, Labo" + "urValues.WasCurrentTo, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      LabourValues.LastEdited, CostCent" + "ers.IDCostCenterInternal, CostCenters.IsCurrent AS IsCostCenterCurrent, CostCent" + "ers.CostCenterNo, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.CostCenterName, CostCenter" + "s.CostCenterDescription, CostCenters.IDCurrency, CostCenters.IncentiveIndicatorS" + "ynonym, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.IncentiveWageSynonym, CostCenters.In" + "centiveIndicatorDimension, CostCenters.IncentiveIndicatorPrecision, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "          " + "            CostCenters.UseFixValuedBonus, CostCenters.IncentiveIndicatorFactor," + " CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "               " + "       CostCenters.WasCurrentFrom AS CostCenterWasCurrentFrom, CostCenters.WasCu" + "rrentTo AS CostCenterWasCurrentTo, " + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "                      CostCenters.LastEdite" + "d AS CostCenterLastEdited" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "FROM         LabourValues INNER JOIN" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "               " + "       CostCenters ON LabourValues.IDCostCenter = CostCenters.IDCostCenter" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "WHER" + "E     (LabourValues.IDSubsidiary = @IDSubsidiary)" + Microsoft.VisualBasic.Strings.ChrW(13) + Microsoft.VisualBasic.Strings.ChrW(10) + "ORDER BY LabourValues.LabourV" + "alueNumber";
            this._commandCollection[1].CommandType = global::System.Data.CommandType.Text;
            this._commandCollection[1].Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDSubsidiary", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "IDSubsidiary", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int Fill(dsLabourValues.dtLabourValuesDataTable dataTable)
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
        public virtual dsLabourValues.dtLabourValuesDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            dsLabourValues.dtLabourValuesDataTable dataTable = new dsLabourValues.dtLabourValuesDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Fill, false)]
        public virtual int FillByIDSubsidiary(dsLabourValues.dtLabourValuesDataTable dataTable, int IDSubsidiary)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
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
        [System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Select, false)]
        public virtual dsLabourValues.dtLabourValuesDataTable GetDataByIDSubsidiary(int IDSubsidiary)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            this.Adapter.SelectCommand.Parameters[0].Value = ((int)IDSubsidiary);
            dsLabourValues.dtLabourValuesDataTable dataTable = new dsLabourValues.dtLabourValuesDataTable();
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
    [System.Xml.Serialization.XmlRootAttribute("dsLabourValues")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class dsLabourValues : System.Data.DataSet
    {
        private dtLabourValuesDataTable tabledtLabourValues;
        private System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public dsLabourValues() : base()
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
        protected dsLabourValues(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context, false)
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
                if ((!((ds.Tables["dtLabourValues"]) == null)))
                {
                    base.Tables.Add(new dtLabourValuesDataTable(ds.Tables["dtLabourValues"]));
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
        public dtLabourValuesDataTable dtLabourValues
        {
            get
            {
                return this.tabledtLabourValues;
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
            dsLabourValues cln = ((dsLabourValues)base.Clone());
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
                if ((!((ds.Tables["dtLabourValues"]) == null)))
                {
                    base.Tables.Add(new dtLabourValuesDataTable(ds.Tables["dtLabourValues"]));
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
            this.tabledtLabourValues = ((dtLabourValuesDataTable)base.Tables["dtLabourValues"]);
            if ((initTable == true))
            {
                if ((!((this.tabledtLabourValues) == null)))
                {
                    this.tabledtLabourValues.InitVars();
                }
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private void InitClass()
        {
            this.DataSetName = "dsLabourValues";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/dsLabourValues.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tabledtLabourValues = new dtLabourValuesDataTable();
            base.Tables.Add(this.tabledtLabourValues);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        private bool ShouldSerializedtLabourValues()
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
            dsLabourValues ds = new dsLabourValues();
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
        public delegate void dtLabourValuesRowChangeEventHandler(object sender, dtLabourValuesRowChangeEvent e);
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class dtLabourValuesDataTable : System.Data.TypedTableBase<dtLabourValuesRow>
        {
            private System.Data.DataColumn columnIDLabourValue;
            private System.Data.DataColumn columnIDSubsidiary;
            private System.Data.DataColumn columnIDLabourValueInternal;
            private System.Data.DataColumn columnIDCostCenter;
            private System.Data.DataColumn columnLabourValueNumber;
            private System.Data.DataColumn columnLabourValueName;
            private System.Data.DataColumn columnLabourValueDescription;
            private System.Data.DataColumn columnTeHMin;
            private System.Data.DataColumn columnDimension;
            private System.Data.DataColumn columnIsActive;
            private System.Data.DataColumn columnIsCurrent;
            private System.Data.DataColumn columnWasCurrentFrom;
            private System.Data.DataColumn columnWasCurrentTo;
            private System.Data.DataColumn columnLastEdited;
            private System.Data.DataColumn columnIDCostCenterInternal;
            private System.Data.DataColumn columnIsCostCenterCurrent;
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
            private System.Data.DataColumn columnCostCenterWasCurrentFrom;
            private System.Data.DataColumn columnCostCenterWasCurrentTo;
            private System.Data.DataColumn columnCostCenterLastEdited;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesDataTable() : base()
            {
                this.TableName = "dtLabourValues";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal dtLabourValuesDataTable(System.Data.DataTable table) : base()
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
            protected dtLabourValuesDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn IDLabourValueColumn
            {
                get
                {
                    return this.columnIDLabourValue;
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
            public System.Data.DataColumn IDCostCenterColumn
            {
                get
                {
                    return this.columnIDCostCenter;
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
            public System.Data.DataColumn IsCostCenterCurrentColumn
            {
                get
                {
                    return this.columnIsCostCenterCurrent;
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
            public System.Data.DataColumn CostCenterWasCurrentFromColumn
            {
                get
                {
                    return this.columnCostCenterWasCurrentFrom;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CostCenterWasCurrentToColumn
            {
                get
                {
                    return this.columnCostCenterWasCurrentTo;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.Data.DataColumn CostCenterLastEditedColumn
            {
                get
                {
                    return this.columnCostCenterLastEdited;
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
            public dtLabourValuesRow this[int index]
            {
                get
                {
                    return ((dtLabourValuesRow)this.Rows[index]);
                }
            }

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtLabourValuesRowChangeEventHandler dtLabourValuesRowChanging;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtLabourValuesRowChangeEventHandler dtLabourValuesRowChanged;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtLabourValuesRowChangeEventHandler dtLabourValuesRowDeleting;
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public event dtLabourValuesRowChangeEventHandler dtLabourValuesRowDeleted;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void AdddtLabourValuesRow(dtLabourValuesRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesRow AdddtLabourValuesRow(int IDSubsidiary, int IDLabourValueInternal, int IDCostCenter, int LabourValueNumber, string LabourValueName, string LabourValueDescription, double TeHMin, string Dimension, bool IsActive, bool IsCurrent, System.DateTime WasCurrentFrom, System.DateTime WasCurrentTo, System.DateTime LastEdited, int IDCostCenterInternal, bool IsCostCenterCurrent, int CostCenterNo, string CostCenterName, string CostCenterDescription, int IDCurrency, string IncentiveIndicatorSynonym, string IncentiveWageSynonym, string IncentiveIndicatorDimension, byte IncentiveIndicatorPrecision, bool UseFixValuedBonus, double IncentiveIndicatorFactor, byte BaseValuePrecision, string BaseValueSynonym, System.DateTime CostCenterWasCurrentFrom, System.DateTime CostCenterWasCurrentTo, System.DateTime CostCenterLastEdited)
            {
                dtLabourValuesRow rowdtLabourValuesRow = ((dtLabourValuesRow)this.NewRow());
                object[] columnValuesArray = new object[]
                {
                    null,
                    IDSubsidiary,
                    IDLabourValueInternal,
                    IDCostCenter,
                    LabourValueNumber,
                    LabourValueName,
                    LabourValueDescription,
                    TeHMin,
                    Dimension,
                    IsActive,
                    IsCurrent,
                    WasCurrentFrom,
                    WasCurrentTo,
                    LastEdited,
                    IDCostCenterInternal,
                    IsCostCenterCurrent,
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
                    CostCenterWasCurrentFrom,
                    CostCenterWasCurrentTo,
                    CostCenterLastEdited
                };
                rowdtLabourValuesRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowdtLabourValuesRow);
                return rowdtLabourValuesRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesRow FindByIDLabourValueIDSubsidiary(int IDLabourValue, int IDSubsidiary)
            {
                return ((dtLabourValuesRow)this.Rows.Find(new object[] { IDLabourValue, IDSubsidiary }));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public override System.Data.DataTable Clone()
            {
                dtLabourValuesDataTable cln = ((dtLabourValuesDataTable)base.Clone());
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataTable CreateInstance()
            {
                return new dtLabourValuesDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal void InitVars()
            {
                this.columnIDLabourValue = base.Columns["IDLabourValue"];
                this.columnIDSubsidiary = base.Columns["IDSubsidiary"];
                this.columnIDLabourValueInternal = base.Columns["IDLabourValueInternal"];
                this.columnIDCostCenter = base.Columns["IDCostCenter"];
                this.columnLabourValueNumber = base.Columns["LabourValueNumber"];
                this.columnLabourValueName = base.Columns["LabourValueName"];
                this.columnLabourValueDescription = base.Columns["LabourValueDescription"];
                this.columnTeHMin = base.Columns["TeHMin"];
                this.columnDimension = base.Columns["Dimension"];
                this.columnIsActive = base.Columns["IsActive"];
                this.columnIsCurrent = base.Columns["IsCurrent"];
                this.columnWasCurrentFrom = base.Columns["WasCurrentFrom"];
                this.columnWasCurrentTo = base.Columns["WasCurrentTo"];
                this.columnLastEdited = base.Columns["LastEdited"];
                this.columnIDCostCenterInternal = base.Columns["IDCostCenterInternal"];
                this.columnIsCostCenterCurrent = base.Columns["IsCostCenterCurrent"];
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
                this.columnCostCenterWasCurrentFrom = base.Columns["CostCenterWasCurrentFrom"];
                this.columnCostCenterWasCurrentTo = base.Columns["CostCenterWasCurrentTo"];
                this.columnCostCenterLastEdited = base.Columns["CostCenterLastEdited"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            private void InitClass()
            {
                this.columnIDLabourValue = new System.Data.DataColumn("IDLabourValue", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDLabourValue);
                this.columnIDSubsidiary = new System.Data.DataColumn("IDSubsidiary", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDSubsidiary);
                this.columnIDLabourValueInternal = new System.Data.DataColumn("IDLabourValueInternal", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDLabourValueInternal);
                this.columnIDCostCenter = new System.Data.DataColumn("IDCostCenter", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDCostCenter);
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
                this.columnWasCurrentFrom = new System.Data.DataColumn("WasCurrentFrom", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWasCurrentFrom);
                this.columnWasCurrentTo = new System.Data.DataColumn("WasCurrentTo", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnWasCurrentTo);
                this.columnLastEdited = new System.Data.DataColumn("LastEdited", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnLastEdited);
                this.columnIDCostCenterInternal = new System.Data.DataColumn("IDCostCenterInternal", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIDCostCenterInternal);
                this.columnIsCostCenterCurrent = new System.Data.DataColumn("IsCostCenterCurrent", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsCostCenterCurrent);
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
                this.columnCostCenterWasCurrentFrom = new System.Data.DataColumn("CostCenterWasCurrentFrom", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterWasCurrentFrom);
                this.columnCostCenterWasCurrentTo = new System.Data.DataColumn("CostCenterWasCurrentTo", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterWasCurrentTo);
                this.columnCostCenterLastEdited = new System.Data.DataColumn("CostCenterLastEdited", typeof(System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCostCenterLastEdited);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] { this.columnIDLabourValue, this.columnIDSubsidiary }, true));
                this.columnIDLabourValue.AutoIncrement = true;
                this.columnIDLabourValue.AllowDBNull = false;
                this.columnIDLabourValue.ReadOnly = true;
                this.columnIDSubsidiary.AllowDBNull = false;
                this.columnIDLabourValueInternal.AllowDBNull = false;
                this.columnIDCostCenter.AllowDBNull = false;
                this.columnLabourValueNumber.AllowDBNull = false;
                this.columnLabourValueName.AllowDBNull = false;
                this.columnLabourValueName.MaxLength = 100;
                this.columnLabourValueDescription.MaxLength = 2147483647;
                this.columnTeHMin.AllowDBNull = false;
                this.columnDimension.AllowDBNull = false;
                this.columnDimension.MaxLength = 100;
                this.columnIsActive.AllowDBNull = false;
                this.columnIsCurrent.AllowDBNull = false;
                this.columnWasCurrentFrom.AllowDBNull = false;
                this.columnWasCurrentTo.AllowDBNull = false;
                this.columnLastEdited.AllowDBNull = false;
                this.columnIDCostCenterInternal.AllowDBNull = false;
                this.columnIsCostCenterCurrent.AllowDBNull = false;
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
                this.columnCostCenterWasCurrentFrom.AllowDBNull = false;
                this.columnCostCenterWasCurrentTo.AllowDBNull = false;
                this.columnCostCenterLastEdited.AllowDBNull = false;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesRow NewdtLabourValuesRow()
            {
                return ((dtLabourValuesRow)this.NewRow());
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new dtLabourValuesRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override System.Type GetRowType()
            {
                return typeof(dtLabourValuesRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((!((this.dtLabourValuesRowChanged) == null)))
                {
                    dtLabourValuesRowChanged?.Invoke(this, new dtLabourValuesRowChangeEvent(((dtLabourValuesRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((!((this.dtLabourValuesRowChanging) == null)))
                {
                    dtLabourValuesRowChanging?.Invoke(this, new dtLabourValuesRowChangeEvent(((dtLabourValuesRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((!((this.dtLabourValuesRowDeleted) == null)))
                {
                    dtLabourValuesRowDeleted?.Invoke(this, new dtLabourValuesRowChangeEvent(((dtLabourValuesRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((!((this.dtLabourValuesRowDeleting) == null)))
                {
                    dtLabourValuesRowDeleting?.Invoke(this, new dtLabourValuesRowChangeEvent(((dtLabourValuesRow)e.Row), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void RemovedtLabourValuesRow(dtLabourValuesRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                dsLabourValues ds = new dsLabourValues();
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
                attribute2.FixedValue = "dtLabourValuesDataTable";
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
        public partial class dtLabourValuesRow : System.Data.DataRow
        {
            private dtLabourValuesDataTable tabledtLabourValues;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            internal dtLabourValuesRow(System.Data.DataRowBuilder rb) : base(rb)
            {
                this.tabledtLabourValues = ((dtLabourValuesDataTable)this.Table);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDLabourValue
            {
                get
                {
                    return ((int)this[this.tabledtLabourValues.IDLabourValueColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IDLabourValueColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDSubsidiary
            {
                get
                {
                    return ((int)this[this.tabledtLabourValues.IDSubsidiaryColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IDSubsidiaryColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDLabourValueInternal
            {
                get
                {
                    return ((int)this[this.tabledtLabourValues.IDLabourValueInternalColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IDLabourValueInternalColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDCostCenter
            {
                get
                {
                    return ((int)this[this.tabledtLabourValues.IDCostCenterColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IDCostCenterColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int LabourValueNumber
            {
                get
                {
                    return ((int)this[this.tabledtLabourValues.LabourValueNumberColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.LabourValueNumberColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string LabourValueName
            {
                get
                {
                    return ((string)this[this.tabledtLabourValues.LabourValueNameColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.LabourValueNameColumn] = value;
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
                        return ((string)this[this.tabledtLabourValues.LabourValueDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'LabourValueDescription' in table 'dtLabourValues' is DBNull" + ".", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tabledtLabourValues.LabourValueDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double TeHMin
            {
                get
                {
                    return ((double)this[this.tabledtLabourValues.TeHMinColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.TeHMinColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string Dimension
            {
                get
                {
                    return ((string)this[this.tabledtLabourValues.DimensionColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.DimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsActive
            {
                get
                {
                    return ((bool)this[this.tabledtLabourValues.IsActiveColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IsActiveColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCurrent
            {
                get
                {
                    return ((bool)this[this.tabledtLabourValues.IsCurrentColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IsCurrentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime WasCurrentFrom
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtLabourValues.WasCurrentFromColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.WasCurrentFromColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime WasCurrentTo
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtLabourValues.WasCurrentToColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.WasCurrentToColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime LastEdited
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtLabourValues.LastEditedColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.LastEditedColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDCostCenterInternal
            {
                get
                {
                    return ((int)this[this.tabledtLabourValues.IDCostCenterInternalColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IDCostCenterInternalColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCostCenterCurrent
            {
                get
                {
                    return ((bool)this[this.tabledtLabourValues.IsCostCenterCurrentColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IsCostCenterCurrentColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int CostCenterNo
            {
                get
                {
                    return ((int)this[this.tabledtLabourValues.CostCenterNoColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.CostCenterNoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string CostCenterName
            {
                get
                {
                    return ((string)this[this.tabledtLabourValues.CostCenterNameColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.CostCenterNameColumn] = value;
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
                        return ((string)this[this.tabledtLabourValues.CostCenterDescriptionColumn]);
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column 'CostCenterDescription' in table 'dtLabourValues' is DBNull." + "", e);
                    }

                    return default(string);
                }

                set
                {
                    this[this.tabledtLabourValues.CostCenterDescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public int IDCurrency
            {
                get
                {
                    return ((int)this[this.tabledtLabourValues.IDCurrencyColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IDCurrencyColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorSynonym
            {
                get
                {
                    return ((string)this[this.tabledtLabourValues.IncentiveIndicatorSynonymColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IncentiveIndicatorSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveWageSynonym
            {
                get
                {
                    return ((string)this[this.tabledtLabourValues.IncentiveWageSynonymColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IncentiveWageSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string IncentiveIndicatorDimension
            {
                get
                {
                    return ((string)this[this.tabledtLabourValues.IncentiveIndicatorDimensionColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IncentiveIndicatorDimensionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte IncentiveIndicatorPrecision
            {
                get
                {
                    return ((byte)this[this.tabledtLabourValues.IncentiveIndicatorPrecisionColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IncentiveIndicatorPrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool UseFixValuedBonus
            {
                get
                {
                    return ((bool)this[this.tabledtLabourValues.UseFixValuedBonusColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.UseFixValuedBonusColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public double IncentiveIndicatorFactor
            {
                get
                {
                    return ((double)this[this.tabledtLabourValues.IncentiveIndicatorFactorColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.IncentiveIndicatorFactorColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public byte BaseValuePrecision
            {
                get
                {
                    return ((byte)this[this.tabledtLabourValues.BaseValuePrecisionColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.BaseValuePrecisionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public string BaseValueSynonym
            {
                get
                {
                    return ((string)this[this.tabledtLabourValues.BaseValueSynonymColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.BaseValueSynonymColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime CostCenterWasCurrentFrom
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtLabourValues.CostCenterWasCurrentFromColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.CostCenterWasCurrentFromColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime CostCenterWasCurrentTo
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtLabourValues.CostCenterWasCurrentToColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.CostCenterWasCurrentToColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public System.DateTime CostCenterLastEdited
            {
                get
                {
                    return ((System.DateTime)this[this.tabledtLabourValues.CostCenterLastEditedColumn]);
                }

                set
                {
                    this[this.tabledtLabourValues.CostCenterLastEditedColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsLabourValueDescriptionNull()
            {
                return this.IsNull(this.tabledtLabourValues.LabourValueDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetLabourValueDescriptionNull()
            {
                this[this.tabledtLabourValues.LabourValueDescriptionColumn] = global::System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public bool IsCostCenterDescriptionNull()
            {
                return this.IsNull(this.tabledtLabourValues.CostCenterDescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public void SetCostCenterDescriptionNull()
            {
                this[this.tabledtLabourValues.CostCenterDescriptionColumn] = global::System.Convert.DBNull;
            }
        }

        /// <summary>
        ///Row event argument class
        ///</summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
        public class dtLabourValuesRowChangeEvent : System.EventArgs
        {
            private dtLabourValuesRow eventRow;
            private System.Data.DataRowAction eventAction;
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesRowChangeEvent(dtLabourValuesRow row, System.Data.DataRowAction action) : base()
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "18.0.0.0")]
            public dtLabourValuesRow Row
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
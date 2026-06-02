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
    [System.Data.Linq.Mapping.DatabaseAttribute(Name = "MISDB")]
    public partial class KannegiesserDataContext : System.Data.Linq.DataContext
    {
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
        partial void OnCreated();
        public KannegiesserDataContext() : base(global::Facesso.Interfaces.My.MySettings.Default.MISDBConnectionString, mappingSource)
        {
            OnCreated();
        }

        public KannegiesserDataContext(string connection) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public KannegiesserDataContext(System.Data.IDbConnection connection) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public KannegiesserDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
        {
            OnCreated();
        }

        public KannegiesserDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource)
        {
            OnCreated();
        }

        [System.Data.Linq.Mapping.FunctionAttribute(Name = "PROGHIST.GetMachines")]
        public ISingleResult<GetMachinesResult> GetMachines()
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()));
            return ((ISingleResult<GetMachinesResult>)result.ReturnValue);
        }

        [System.Data.Linq.Mapping.FunctionAttribute(Name = "PROGHIST.GetProgHist")]
        public ISingleResult<GetProgHistResult> GetProgHist(System.Nullable<int> machineID, System.Nullable<int> iD)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), machineID, iD);
            return ((ISingleResult<GetProgHistResult>)result.ReturnValue);
        }

        [System.Data.Linq.Mapping.FunctionAttribute(Name = "PROGHIST.GetPrograms")]
        public ISingleResult<GetProgramsResult> GetPrograms()
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()));
            return ((ISingleResult<GetProgramsResult>)result.ReturnValue);
        }

        [System.Data.Linq.Mapping.FunctionAttribute(Name = "PROGHIST.GetArticles")]
        public ISingleResult<GetArticlesResult> GetArticles()
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()));
            return ((ISingleResult<GetArticlesResult>)result.ReturnValue);
        }

        [System.Data.Linq.Mapping.FunctionAttribute(Name = "PROGHIST.GetArtHist")]
        public ISingleResult<GetArtHistResult> GetArtHist(System.Nullable<int> machineID, System.Nullable<System.DateTime> startTime, System.Nullable<System.DateTime> endTime)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), machineID, startTime, endTime);
            return ((ISingleResult<GetArtHistResult>)result.ReturnValue);
        }
    }

    public partial class GetMachinesResult
    {
        private int _MachineID;
        private string _MachineName;
        public GetMachinesResult() : base()
        {
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MachineID", DbType = "Int NOT NULL")]
        public int MachineID
        {
            get
            {
                return this._MachineID;
            }

            set
            {
                if (((this._MachineID == value) == false))
                {
                    this._MachineID = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MachineName", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string MachineName
        {
            get
            {
                return this._MachineName;
            }

            set
            {
                if ((string.Equals(this._MachineName, value) == false))
                {
                    this._MachineName = value;
                }
            }
        }
    }

    public partial class GetProgHistResult
    {
        private long _ID;
        private System.Nullable<System.DateTime> _DATUM;
        private System.Nullable<int> _TYP;
        private System.Nullable<int> _ARTNR;
        private System.Nullable<System.DateTime> _STARTZEIT;
        private System.Nullable<double> _DAUER;
        private System.Nullable<double> _ZAEHLER;
        public GetProgHistResult() : base()
        {
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "BigInt NOT NULL")]
        public long ID
        {
            get
            {
                return this._ID;
            }

            set
            {
                if (((this._ID == value) == false))
                {
                    this._ID = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DATUM", DbType = "DateTime")]
        public System.Nullable<System.DateTime> DATUM
        {
            get
            {
                return this._DATUM;
            }

            set
            {
                if ((this._DATUM.Equals(value) == false))
                {
                    this._DATUM = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TYP", DbType = "Int")]
        public System.Nullable<int> TYP
        {
            get
            {
                return this._TYP;
            }

            set
            {
                if ((this._TYP.Equals(value) == false))
                {
                    this._TYP = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ARTNR", DbType = "Int")]
        public System.Nullable<int> ARTNR
        {
            get
            {
                return this._ARTNR;
            }

            set
            {
                if ((this._ARTNR.Equals(value) == false))
                {
                    this._ARTNR = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_STARTZEIT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> STARTZEIT
        {
            get
            {
                return this._STARTZEIT;
            }

            set
            {
                if ((this._STARTZEIT.Equals(value) == false))
                {
                    this._STARTZEIT = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DAUER", DbType = "Float")]
        public System.Nullable<double> DAUER
        {
            get
            {
                return this._DAUER;
            }

            set
            {
                if ((this._DAUER.Equals(value) == false))
                {
                    this._DAUER = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ZAEHLER", DbType = "Float")]
        public System.Nullable<double> ZAEHLER
        {
            get
            {
                return this._ZAEHLER;
            }

            set
            {
                if ((this._ZAEHLER.Equals(value) == false))
                {
                    this._ZAEHLER = value;
                }
            }
        }
    }

    public partial class GetProgramsResult
    {
        private int _MachineID;
        private short _ProgramID;
        private string _ProgramName;
        public GetProgramsResult() : base()
        {
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MachineID", DbType = "Int NOT NULL")]
        public int MachineID
        {
            get
            {
                return this._MachineID;
            }

            set
            {
                if (((this._MachineID == value) == false))
                {
                    this._MachineID = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ProgramID", DbType = "SmallInt NOT NULL")]
        public short ProgramID
        {
            get
            {
                return this._ProgramID;
            }

            set
            {
                if (((this._ProgramID == value) == false))
                {
                    this._ProgramID = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ProgramName", DbType = "NVarChar(27) NOT NULL", CanBeNull = false)]
        public string ProgramName
        {
            get
            {
                return this._ProgramName;
            }

            set
            {
                if ((string.Equals(this._ProgramName, value) == false))
                {
                    this._ProgramName = value;
                }
            }
        }
    }

    public partial class GetArticlesResult
    {
        private int _ArticleID;
        private string _ArticleName;
        public GetArticlesResult() : base()
        {
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ArticleID", DbType = "Int NOT NULL")]
        public int ArticleID
        {
            get
            {
                return this._ArticleID;
            }

            set
            {
                if (((this._ArticleID == value) == false))
                {
                    this._ArticleID = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ArticleName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ArticleName
        {
            get
            {
                return this._ArticleName;
            }

            set
            {
                if ((string.Equals(this._ArticleName, value) == false))
                {
                    this._ArticleName = value;
                }
            }
        }
    }

    public partial class GetArtHistResult
    {
        private System.Nullable<System.DateTime> _StartTime;
        private System.Nullable<System.DateTime> _EndTime;
        private int _SysID;
        private string _SysShortName;
        private bool _SystemMaster;
        private int _MachID;
        private string _MachShortName;
        private System.Nullable<double> _ProdDur;
        private string _ArticleName;
        private int _ArticleID;
        private System.Nullable<double> _Counter;
        private System.Nullable<double> _TargetDur1;
        private string _UnitName;
        public GetArtHistResult() : base()
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

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SysID", DbType = "Int NOT NULL")]
        public int SysID
        {
            get
            {
                return this._SysID;
            }

            set
            {
                if (((this._SysID == value) == false))
                {
                    this._SysID = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SysShortName", DbType = "NVarChar(10)")]
        public string SysShortName
        {
            get
            {
                return this._SysShortName;
            }

            set
            {
                if ((string.Equals(this._SysShortName, value) == false))
                {
                    this._SysShortName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SystemMaster", DbType = "Bit NOT NULL")]
        public bool SystemMaster
        {
            get
            {
                return this._SystemMaster;
            }

            set
            {
                if (((this._SystemMaster == value) == false))
                {
                    this._SystemMaster = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MachID", DbType = "Int NOT NULL")]
        public int MachID
        {
            get
            {
                return this._MachID;
            }

            set
            {
                if (((this._MachID == value) == false))
                {
                    this._MachID = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MachShortName", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string MachShortName
        {
            get
            {
                return this._MachShortName;
            }

            set
            {
                if ((string.Equals(this._MachShortName, value) == false))
                {
                    this._MachShortName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ProdDur", DbType = "Float")]
        public System.Nullable<double> ProdDur
        {
            get
            {
                return this._ProdDur;
            }

            set
            {
                if ((this._ProdDur.Equals(value) == false))
                {
                    this._ProdDur = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ArticleName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ArticleName
        {
            get
            {
                return this._ArticleName;
            }

            set
            {
                if ((string.Equals(this._ArticleName, value) == false))
                {
                    this._ArticleName = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ArticleID", DbType = "Int NOT NULL")]
        public int ArticleID
        {
            get
            {
                return this._ArticleID;
            }

            set
            {
                if (((this._ArticleID == value) == false))
                {
                    this._ArticleID = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Counter", DbType = "Float")]
        public System.Nullable<double> Counter
        {
            get
            {
                return this._Counter;
            }

            set
            {
                if ((this._Counter.Equals(value) == false))
                {
                    this._Counter = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TargetDur1", DbType = "Float")]
        public System.Nullable<double> TargetDur1
        {
            get
            {
                return this._TargetDur1;
            }

            set
            {
                if ((this._TargetDur1.Equals(value) == false))
                {
                    this._TargetDur1 = value;
                }
            }
        }

        [System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UnitName", DbType = "NVarChar(10)")]
        public string UnitName
        {
            get
            {
                return this._UnitName;
            }

            set
            {
                if ((string.Equals(this._UnitName, value) == false))
                {
                    this._UnitName = value;
                }
            }
        }
    }
}
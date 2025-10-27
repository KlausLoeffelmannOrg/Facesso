using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Dynamic;

namespace Facesso_Datalayer
{
    public static class RelationalQueryableExtensions
    {
        private static Dictionary<string, List<ParamInfo>> _cachedProceduresParams = new Dictionary<string, List<ParamInfo>>(); //Die zwischengespeicerten Parameter der Prozedur
        /// <summary>
        /// Mapping der Datenbank-Datentypen von Strings nach .net-Typen
        /// </summary>
        private static Dictionary<string, DbType> _dbTypeMap = new Dictionary<string, DbType>() { { "uniqueidentifier", DbType.Guid },
                                                                                              { "datetime", DbType.DateTime},
                                                                                              { "tinyint",DbType.Byte},
                                                                                              { "bit",DbType.Boolean}};

        /// <summary>
        /// Führt die angegebene Stored Procedure in der Datenbank unter Angabe der übergebenen Parameter aus und gibt das ResultSet als Dynmaic-Auflistung zurück
        /// </summary>
        /// <param name="oc"></param>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<dynamic> FromStoredProcedure(this DbContext oc, string sp, params object[] parameters)
        {
            var result = new List<dynamic>();
            var sp_params = InitializeParams(sp, oc, parameters);

            using (var spCommand = oc.Database.GetDbConnection().CreateCommand())
            {
                var resultReader = CallStoredProcedure(sp, parameters, sp_params, spCommand);

                //Ergebis parsen und in generischen Typ überführen
                List<ColumnInfo> columns = GetResultColumns(resultReader);

                //var props = typeof(TEntity).GetProperties();
                while (resultReader.Read())
                {
                    dynamic expando = new ExpandoObject();
                    var row = expando as IDictionary<string, object>;

                    foreach (var column in columns)
                    {
                        var value = resultReader.GetValue(resultReader.GetOrdinal(column.Name));
                        row[column.Name] = value;
                    }
                    result.Add(row);
                }
            }
            return result;
        }

        /// <summary>
        /// Führt die angegebene Stored Procedure in der Datenbank unter Angabe der übergebenen Parameter aus und gibt das ResultSet als generische Auflistung zurück
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="oc"></param>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> FromStoredProcedure<TEntity>(this DbContext oc, string sp, params object[] parameters) where TEntity : class
        {
            var result = new List<TEntity>();
            var sp_params = InitializeParams(sp, oc, parameters);

            using (var spCommand = oc.Database.GetDbConnection().CreateCommand())
            {
                var resultReader = CallStoredProcedure(sp, parameters, sp_params, spCommand);

                //Ergebis parsen und in generischen Typ überführen
                List<ColumnInfo> columns = GetResultColumns(resultReader);

                var props = typeof(TEntity).GetProperties();
                while (resultReader.Read())
                {
                    //Elemente lesen
                    var resultIni = Activator.CreateInstance<TEntity>();

                    foreach (var prop in props)
                    {
                        //Schauen ob es ein Gegenstück gibt und dieses kompatibel ist
                        var column = columns.Where(c => c.Name.ToLower() == prop.Name.ToLower()).SingleOrDefault();

                        if (column != null)
                        {
                            var value = resultReader.GetValue(resultReader.GetOrdinal(column.Name));

                            //Gibt Gegenstück
                            prop.SetValue(resultIni, value);
                        }
                    }

                    result.Add(resultIni);
                }

                resultReader.Dispose();
            }

            return result.AsQueryable();
        }

        /// <summary>
        /// Liefert die Informationen der Ergebnis-Spalten vom DbDataReader zurück
        /// </summary>
        /// <param name="resultReader"></param>
        /// <returns></returns>
        private static List<ColumnInfo> GetResultColumns(System.Data.Common.DbDataReader resultReader)
        {
            var columns = new List<ColumnInfo>();

            for (int j = 0; j < resultReader.FieldCount; j++)
            {
                columns.Add(new ColumnInfo() { Name = resultReader.GetName(j), Type = resultReader.GetFieldType(j) });
            }

            return columns;
        }

        /// <summary>
        /// Erzeugt die Parameter und ruft die Prozedur auf
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <param name="sp_params"></param>
        /// <param name="spCommand"></param>
        /// <returns></returns>
        private static System.Data.Common.DbDataReader CallStoredProcedure(string sp, object[] parameters, List<ParamInfo> sp_params, System.Data.Common.DbCommand spCommand)
        {
            spCommand.CommandText = "dbo." + sp;
            spCommand.CommandType = CommandType.StoredProcedure;

            var i = 0;
            foreach (var p in sp_params)
            {
                var paramValue = parameters[i];
                //Neuen Parameter erstellen
                var param = spCommand.CreateParameter();
                param.ParameterName = p.Name;

                if (paramValue == null)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = paramValue;
                }

                param.DbType = p.Type;
                param.Direction = ParameterDirection.Input;
                spCommand.Parameters.Add(param);

                i++;
            }

            var resultReader = spCommand.ExecuteReader();
            return resultReader;
        }

        /// <summary>
        /// Erstellt im _cachedProceduresParams einen Eintrag für Infos der Parameter zum Aufrufen der SP
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="oc"></param>
        /// <param name="parameters"></param>
        private static List<ParamInfo> InitializeParams(string sp, DbContext oc, params object[] parameters)
        {
            if (_cachedProceduresParams.ContainsKey(sp))
            {
                return _cachedProceduresParams[sp];
            }

            var sp_params = new List<ParamInfo>();

            //Read param names from sp
            using (var getColumnsCommand = oc.Database.GetDbConnection().CreateCommand())
            {
                if (getColumnsCommand.Connection.State != ConnectionState.Open)
                    getColumnsCommand.Connection.Open();

                //Noch SPName als Param (Injection übergeben...)
                getColumnsCommand.CommandText = @"select ap.name, TYPE_NAME(system_type_id) from sys.all_objects ao, sys.all_parameters ap where ao.object_id = ap.object_id and ao.name = '" + sp + "' and is_output = 0 order by ap.parameter_id";

                getColumnsCommand.CommandType = CommandType.Text;
                var param = getColumnsCommand.CreateParameter();
                param.Direction = ParameterDirection.ReturnValue;
                //param.DbType = DbType.Object; ;

                var reader = getColumnsCommand.ExecuteReader();

                while (reader.Read())
                {
                    sp_params.Add(new ParamInfo() { Name = reader.GetString(0), Type = _dbTypeMap[reader.GetString(1)] });

                    //Typvergleich implementieren..
                }

                if (sp_params.Count != parameters.Count())
                {
                    throw new ArgumentException("Parameteranzahl der Stored Procedure stimmt nicht mit den übergebenen Parametern überein!");
                }

                reader.Dispose();
            }

            _cachedProceduresParams.Add(sp, sp_params);
            return _cachedProceduresParams[sp];
        }
    }
}

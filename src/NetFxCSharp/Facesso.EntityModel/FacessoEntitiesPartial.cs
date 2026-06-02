using Facesso;
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
    public partial class FacessoEntities
    {
        public static string GetFacessoEntityString()
        {
            var sqlString = FacessoGeneric.SQLConnectionString;
            var providerString = "System.Data.SqlClient";
            if (sqlString.IndexOf("MultipleActiveResultSets") < 0)
            {
                sqlString += ";MultipleActiveResultSets=True";
            }

            EntityConnectionStringBuilder eb = new EntityConnectionStringBuilder(sqlString);
            eb.Provider = providerString;
            eb.Metadata = "metadata=res://*/FacessoModel.csdl|res://*/FacessoModel.ssdl|res://*/FacessoModel.msl";
            return eb.ToString();
        }
    }
}
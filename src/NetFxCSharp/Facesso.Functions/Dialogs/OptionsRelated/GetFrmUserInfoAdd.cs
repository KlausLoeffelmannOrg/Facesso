using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public class GetFrmOptions : FacessoFunctionBase
    {
        public override IRolePermissionInfo RolePermission
        {
            get
            {
                return new FacessoRolePermissionInfo(ClearanceLevel.ChangeSystemData);
            }
        }

        public override string RolePermissionViolationMessage
        {
            get
            {
                //TODO: Meldung anpassen
                return Facesso.Functions.My.Resources.UserInfoAdd_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Zeigt - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks></remarks>
        public DialogResult ShowDialog()
        {
            GetFrmOptions locFH = FunctionHandler<GetFrmOptions>.GetFunctionInstance();
            if (locFH == null)
            {
                return default(System.Windows.Forms.DialogResult);
            }

            frmOptions locFrmOptions = new frmOptions();
            return locFrmOptions.HandleDialog();
        }
    }
}
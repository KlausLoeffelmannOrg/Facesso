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
    public class GetFrmUserInfoAdd : FacessoFunctionBase
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
                return Facesso.Functions.My.Resources.UserInfoAdd_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Zeigt - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks></remarks>
        public InfoItemMaintenanceDialogResult ShowDialog()
        {
            GetFrmUserInfoAdd locFH = FunctionHandler<GetFrmUserInfoAdd>.GetFunctionInstance();
            if (locFH == null)
            {
                return null;
            }

            frmUserInfoAddEditView locFrmUserInfoAdd = new frmUserInfoAddEditView();
            return locFrmUserInfoAdd.Fac_HandleDialogAsAdd(Facesso.Functions.My.Resources.UserInfoAdd_FormCaption, typeof(UserInfo));
        }
    }
}
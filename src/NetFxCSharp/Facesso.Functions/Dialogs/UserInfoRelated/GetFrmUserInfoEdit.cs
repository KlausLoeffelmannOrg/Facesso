using ActiveDev;
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
    public class GetFrmUserInfoEdit : FacessoFunctionBase
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
                return Facesso.Functions.My.Resources.UserInfoEdit_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Zeigt - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks></remarks>
        public InfoItemMaintenanceDialogResult ShowDialog(IInfoItem InfoItem)
        {
            GetFrmUserInfoEdit locFH = FunctionHandler<GetFrmUserInfoEdit>.GetFunctionInstance();
            if (locFH == null)
            {
                return null;
            }

            frmUserInfoAddEditView locFrmUserInfoEdit = new frmUserInfoAddEditView();
            return locFrmUserInfoEdit.Fac_HandleDialogAsEdit(Facesso.Functions.My.Resources.UserInfoEdit_FormCaption, InfoItem);
        }
    }
}
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
    public class GetFrmWageGroupInfoEdit : FacessoFunctionBase
    {
        public override IRolePermissionInfo RolePermission
        {
            get
            {
                return new FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting);
            }
        }

        public override string RolePermissionViolationMessage
        {
            get
            {
                return Facesso.Functions.My.Resources.WageGroupInfoEdit_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Zeigt - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks></remarks>
        public InfoItemMaintenanceDialogResult ShowDialog(IInfoItem InfoItem)
        {
            GetFrmWageGroupInfoEdit locFH = FunctionHandler<GetFrmWageGroupInfoEdit>.GetFunctionInstance();
            if (locFH == null)
            {
                return null;
            }

            frmWageGroupInfoAddEditView locFrmWageGroupInfoEdit = new frmWageGroupInfoAddEditView();
            return locFrmWageGroupInfoEdit.Fac_HandleDialogAsEdit(Facesso.Functions.My.Resources.WageGroupInfoEdit_FormCaption, InfoItem);
        }
    }
}
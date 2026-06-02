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
    public class GetFrmLabourValueInfoAdd : FacessoFunctionBase
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
                return Facesso.Functions.My.Resources.LabourValueInfoAdd_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Zeigt - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks></remarks>
        public InfoItemMaintenanceDialogResult ShowDialog()
        {
            GetFrmLabourValueInfoAdd locFH = FunctionHandler<GetFrmLabourValueInfoAdd>.GetFunctionInstance();
            if (locFH == null)
            {
                return null;
            }

            frmLabourValueInfoAddEditView locFrmLabourValueInfoAdd = new frmLabourValueInfoAddEditView();
            return locFrmLabourValueInfoAdd.Fac_HandleDialogAsAdd(Facesso.Functions.My.Resources.LabourValueInfoAdd_FormCaption, typeof(LabourValueInfo));
        }
    }
}
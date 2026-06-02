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
    public class GetFrmSubsidiaryManager : FacessoFunctionBase
    {
        public override IRolePermissionInfo RolePermission
        {
            get
            {
                return new FacessoRolePermissionInfo(ClearanceLevel.Admin);
            }
        }

        public override string RolePermissionViolationMessage
        {
            get
            {
                return Facesso.Functions.My.Resources.SubsidiaryInfoAddEditDelete_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Zeigt - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks></remarks>
        public void ShowDialog()
        {
            GetFrmSubsidiaryManager locFH = FunctionHandler<GetFrmSubsidiaryManager>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            frmSubsidiaryManager locFrmSubidiaryManager = new frmSubsidiaryManager();
            locFrmSubidiaryManager.HandleDialog();
        }
    }
}
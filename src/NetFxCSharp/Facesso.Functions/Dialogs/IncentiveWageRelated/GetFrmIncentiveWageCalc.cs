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
    public class GetFrmIncentiveWageCalc : FacessoFunctionBase
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
                return Facesso.Functions.My.Resources.IncentiveWageCalculation_DeniedDueToRole;
            }
        }

        public DialogResult ShowDialog()
        {
            GetFrmIncentiveWageCalc locFH = FunctionHandler<GetFrmIncentiveWageCalc>.GetFunctionInstance();
            if (locFH == null)
            {
                return default(System.Windows.Forms.DialogResult);
            }

            frmIncentiveWageCalc locFrmIncentiveWageCalc = new frmIncentiveWageCalc();
            return locFrmIncentiveWageCalc.ShowDialog();
        }
    }
}
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
    public class GetFrmWorkGroupAnalysis : FacessoFunctionBase
    {
        public override IRolePermissionInfo RolePermission
        {
            get
            {
                return new FacessoRolePermissionInfo(ClearanceLevel.PrintReportsOnProductionData);
            }
        }

        public override string RolePermissionViolationMessage
        {
            get
            {
                return Facesso.Functions.My.Resources.WorkGroupAnalysis_DeniedDueToRole;
            }
        }

        public DialogResult ShowDialog()
        {
            GetFrmWorkGroupAnalysis locFH = FunctionHandler<GetFrmWorkGroupAnalysis>.GetFunctionInstance();
            if (locFH == null)
            {
                return DialogResult.None;
            }

            frmWorkGroupAnalysis locFrmWorkGroupAnalysis = new frmWorkGroupAnalysis();
            return locFrmWorkGroupAnalysis.ShowDialog();
        }
    }
}
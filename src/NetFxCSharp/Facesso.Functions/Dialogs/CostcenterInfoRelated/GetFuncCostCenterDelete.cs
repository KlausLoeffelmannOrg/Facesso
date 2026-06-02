using ActiveDev;
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
    public class GetFuncCostCenterDelete : FacessoFunctionBase
    {
        public override IRolePermissionInfo RolePermission
        {
            get
            {
                return new FacessoRolePermissionInfo(ClearanceLevel.SystemMaintenance);
            }
        }

        public override string RolePermissionViolationMessage
        {
            get
            {
                return Facesso.Functions.My.Resources.CostCenterInfoDelete_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Zeigt - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks></remarks>
        public bool DeleteItem(IInfoItem InfoItem)
        {
            CostcenterInfo locCostCenterInfo = ((CostcenterInfo)InfoItem);
            if (SPAccess.GetInstance().CostCenters_IsInUse(locCostCenterInfo))
            {
                MessageBox.Show("Da diese Kostenstelle bereits in Verwendung ist," + System.Environment.NewLine + "kann sie nicht gel�scht werden.", "Bereits in Verwendung!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return default;
            }

            DialogResult locDr = MessageBox.Show("Sind Sie sicher, die Kostenstelle" + System.Environment.NewLine + System.Environment.NewLine + locCostCenterInfo.DisplayName + System.Environment.NewLine + System.Environment.NewLine + "l�schen zu wollen?", "L�schen best�tigen:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (locDr == DialogResult.Yes)
            {
                try
                {
                    SPAccess.GetInstance().CostCenters_Delete(locCostCenterInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beim L�schen der Kostenstelle ist ein Fehler aufgetreten!" + System.Environment.NewLine + System.Environment.NewLine + ex.StackTrace, "Fehler bei Ausf�hrung!");
                }
            }

            return default(bool);
        }
    }
}
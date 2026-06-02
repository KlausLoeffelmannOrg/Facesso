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
    public class GetFuncEmployeeDelete : FacessoFunctionBase
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
                return Facesso.Functions.My.Resources.EmployeeInfoDelete_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Zeigt - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks></remarks>
        public bool DeleteItem(IInfoItem InfoItem)
        {
            EmployeeInfo locEmployeeInfo = ((EmployeeInfo)InfoItem);
            if (SPAccess.GetInstance().Employees_IsInUse(locEmployeeInfo))
            {
                MessageBox.Show("Da es zu diesem Mitarbeiter bereits Daten gibt," + System.Environment.NewLine + "kann er nicht gel�scht werden.", "Bereits in Verwendung!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return default;
            }

            DialogResult locDr = MessageBox.Show("Sind Sie sicher, den Mitarbeiter" + System.Environment.NewLine + System.Environment.NewLine + locEmployeeInfo.DisplayName + System.Environment.NewLine + System.Environment.NewLine + "l�schen zu wollen?", "L�schen best�tigen:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (locDr == DialogResult.Yes)
            {
                try
                {
                    SPAccess.GetInstance().Employees_Delete(locEmployeeInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beim L�schen des Mitarbeiters ist ein Fehler aufgetreten!" + System.Environment.NewLine + System.Environment.NewLine + ex.StackTrace, "Fehler bei Ausf�hrung!");
                }
            }

            return default(bool);
        }
    }
}
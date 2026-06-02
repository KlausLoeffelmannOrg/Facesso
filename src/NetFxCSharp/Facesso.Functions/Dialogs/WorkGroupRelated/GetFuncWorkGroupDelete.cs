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
    public class GetFuncWorkGroupDelete : FacessoFunctionBase
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
                return Facesso.Functions.My.Resources.WorkGroupInfoDelete_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Zeigt - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks></remarks>
        public bool DeleteItem(IInfoItem InfoItem)
        {
            WorkGroupInfo locWorkGroupInfo = ((WorkGroupInfo)InfoItem);
            if (SPAccess.GetInstance().WorkGroups_IsInUse(locWorkGroupInfo))
            {
                MessageBox.Show("Da diese Produktiv-Site bereits verwendet wird," + System.Environment.NewLine + "kann sie nicht gel�scht werden.", "Bereits in Verwendung!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return default;
            }

            DialogResult locDr = MessageBox.Show("Sind Sie sicher, die Produktiv-Site" + System.Environment.NewLine + System.Environment.NewLine + locWorkGroupInfo.ListItemText + System.Environment.NewLine + System.Environment.NewLine + "l�schen zu wollen?", "L�schen best�tigen:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (locDr == DialogResult.Yes)
            {
                try
                {
                    SPAccess.GetInstance().WorkGroups_Delete(locWorkGroupInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beim L�schen der Produktiv-Site ist ein Fehler aufgetreten!" + System.Environment.NewLine + System.Environment.NewLine + ex.Message + System.Environment.NewLine + System.Environment.NewLine + ex.StackTrace, "Fehler bei Ausf�hrung!");
                }
            }

            return default(bool);
        }
    }
}
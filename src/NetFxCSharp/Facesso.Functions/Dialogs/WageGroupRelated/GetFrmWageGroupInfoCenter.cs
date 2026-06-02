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
    public class GetFrmWageGroupInfoCenter : FacessoFunctionBase
    {
        private frmInfoItemsManagerGeneric<WageGroupInfo> myFrmInfoItemsManagerGeneric;
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
                return Facesso.Functions.My.Resources.WageGroupInfoCollectionGet_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Liefert - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars zur�ck,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks>R�ckgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
        public void ShowDialog()
        {
            WageGroupInfoCollection locWageGroupInfoCollection = SPAccess.GetInstance().WageGroupInfoCollection;
            myFrmInfoItemsManagerGeneric = new frmInfoItemsManagerGeneric<WageGroupInfo>(Facesso.Functions.My.Resources.WageGroupInfoCenter_LocalizedTypeName);
            myFrmInfoItemsManagerGeneric.InfoItems = locWageGroupInfoCollection;
            myFrmInfoItemsManagerGeneric.InfoItemAddDelegate = WageGroupInfoAdd;
            myFrmInfoItemsManagerGeneric.InfoItemEditDelegate = WageGroupInfoEdit;
            myFrmInfoItemsManagerGeneric.RefreshItemsDelegate = RefreshItems;
            myFrmInfoItemsManagerGeneric.ShowDialog();
        }

        internal void WageGroupInfoAdd()
        {
            GetFrmWageGroupInfoAdd locFH = FunctionHandler<GetFrmWageGroupInfoAdd>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
        }

        internal void WageGroupInfoEdit()
        {
            GetFrmWageGroupInfoEdit locFH = FunctionHandler<GetFrmWageGroupInfoEdit>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            if (myFrmInfoItemsManagerGeneric.SelectedInfoItem == null)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.WageGroupInfoCenter_NoSelectedWageGroup_MB_Body, Facesso.Functions.My.Resources.WageGroupInfoCenter_NoSelectedWageGroup_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem);
        }

        internal void RefreshItems()
        {
            WageGroupInfoCollection locWageGroupInfoCollection = SPAccess.GetInstance().WageGroupInfoCollection;
            myFrmInfoItemsManagerGeneric.InfoItems = locWageGroupInfoCollection;
        }
    }
}
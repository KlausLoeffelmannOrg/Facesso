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
    public class GetFrmUserInfoCenter : FacessoFunctionBase
    {
        private frmInfoItemsManagerGeneric<UserInfo> myFrmInfoItemsManagerGeneric;
        public override IRolePermissionInfo RolePermission
        {
            get
            {
                return new FacessoRolePermissionInfo(ClearanceLevel.ViewSystemData);
            }
        }

        public override string RolePermissionViolationMessage
        {
            get
            {
                return Facesso.Functions.My.Resources.UserInfoCollectionGet_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Liefert - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars zur�ck,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks>R�ckgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
        public void ShowDialog()
        {
            UserInfoCollection locUserInfoCollection = SPAccess.GetInstance().UserInfoCollection;
            myFrmInfoItemsManagerGeneric = new frmInfoItemsManagerGeneric<UserInfo>(Facesso.Functions.My.Resources.UserInfoCenter_LocalizedTypeName);
            myFrmInfoItemsManagerGeneric.InfoItems = locUserInfoCollection;
            myFrmInfoItemsManagerGeneric.InfoItemAddDelegate = UserInfoAdd;
            myFrmInfoItemsManagerGeneric.InfoItemEditDelegate = UserInfoEdit;
            myFrmInfoItemsManagerGeneric.RefreshItemsDelegate = RefreshItems;
            myFrmInfoItemsManagerGeneric.ShowDialog();
        }

        internal void UserInfoAdd()
        {
            GetFrmUserInfoAdd locFH = FunctionHandler<GetFrmUserInfoAdd>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
        }

        internal void UserInfoEdit()
        {
            GetFrmUserInfoEdit locFH = FunctionHandler<GetFrmUserInfoEdit>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            if (myFrmInfoItemsManagerGeneric.SelectedInfoItem == null)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.UserInfoCenter_NoSelectedUser_MB_Body, Facesso.Functions.My.Resources.UserInfoCenter_NoSelectedUser_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem);
        }

        internal void RefreshItems()
        {
            UserInfoCollection locUserInfoCollection = SPAccess.GetInstance().UserInfoCollection;
            myFrmInfoItemsManagerGeneric.InfoItems = locUserInfoCollection;
        }
    }
}
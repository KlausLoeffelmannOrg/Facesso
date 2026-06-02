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
    public class GetFrmCostcenterInfoCenter : FacessoFunctionBase
    {
        private frmInfoItemsManagerGeneric<CostcenterInfo> myFrmInfoItemsManagerGeneric;
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
                return Facesso.Functions.My.Resources.CostCenterInfoCollectionGet_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Liefert - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars zur�ck,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks>R�ckgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
        public void ShowDialog()
        {
            CostcenterInfoItems locCostcenterInfoCollection = SPAccess.GetInstance().CostCenterInfoItems;
            myFrmInfoItemsManagerGeneric = new frmInfoItemsManagerGeneric<CostcenterInfo>(Facesso.Functions.My.Resources.CostCenterInfoCenter_LocalizedTypeName);
            myFrmInfoItemsManagerGeneric.InfoItems = locCostcenterInfoCollection;
            myFrmInfoItemsManagerGeneric.InfoItemAddDelegate = CostcenterInfoAdd;
            myFrmInfoItemsManagerGeneric.InfoItemEditDelegate = CostCenterInfoEdit;
            myFrmInfoItemsManagerGeneric.InfoItemDeleteDelegate = CostCenterInfoDelete;
            myFrmInfoItemsManagerGeneric.RefreshItemsDelegate = RefreshItems;
            myFrmInfoItemsManagerGeneric.ShowDialog();
        }

        internal void CostcenterInfoAdd()
        {
            GetFrmCostcenterInfoAdd locFH = FunctionHandler<GetFrmCostcenterInfoAdd>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
        }

        internal void CostCenterInfoEdit()
        {
            GetFrmCostcenterInfoEdit locFH = FunctionHandler<GetFrmCostcenterInfoEdit>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            if (myFrmInfoItemsManagerGeneric.SelectedInfoItem == null)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Body, Facesso.Functions.My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem);
        }

        internal void CostCenterInfoDelete()
        {
            GetFuncCostCenterDelete locFH = FunctionHandler<GetFuncCostCenterDelete>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            if (myFrmInfoItemsManagerGeneric.SelectedInfoItem == null)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Body, Facesso.Functions.My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (CostcenterInfo locItem in myFrmInfoItemsManagerGeneric.SelectedInfoItems)
            {
                locFH.DeleteItem(locItem);
            }
        }

        internal void RefreshItems()
        {
            CostcenterInfoItems locCostcenterInfoCollection = SPAccess.GetInstance().CostCenterInfoItems;
            myFrmInfoItemsManagerGeneric.InfoItems = locCostcenterInfoCollection;
        }
    }
}
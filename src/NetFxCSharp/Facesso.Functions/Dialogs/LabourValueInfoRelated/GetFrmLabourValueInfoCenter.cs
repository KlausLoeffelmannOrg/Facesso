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
    public class GetFrmLabourValueInfoCenter : FacessoFunctionBase
    {
        private frmInfoItemsManagerGeneric<LabourValueInfo> myFrmInfoItemsManagerGeneric;
        private string myCurrentSortOrderString = "LabourValueNumber";
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
                return Facesso.Functions.My.Resources.LabourValueInfoCollectionGet_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Liefert - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars zur�ck,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks>R�ckgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
        public void ShowDialog()
        {
            LabourValueInfoCollection locLabourValueInfoCollection = SPAccess.GetInstance().GetLabourValueInfoCollection();
            myFrmInfoItemsManagerGeneric = new frmInfoItemsManagerGeneric<LabourValueInfo>(Facesso.Functions.My.Resources.LabourValueInfoCenter_LocalizedTypeName)
            {
                InfoItems = locLabourValueInfoCollection,
                InfoItemAddDelegate = LabourValueInfoAdd,
                InfoItemEditDelegate = LabourValueInfoEdit,
                RefreshItemsDelegate = RefreshItems,
                InfoItemDeleteDelegate = LabourValueInfoDelete,
                InfoItemColumnClickDelegate = ColumnClick,
                Costcenters = SPAccess.GetInstance().CostCenterInfoItems,
                AssignCostcenterDelegate = AssignCostCenter
            };
            myFrmInfoItemsManagerGeneric.ShowDialog();
        }

        internal void AssignCostCenter(CostcenterInfo Costcenter)
        {
            if (Costcenter == null)
            {
                MessageBox.Show("Bitte w�hlen Sie zun�chst eine Kostenstelle aus der Liste aus!", "Kostenstelle ausw�hlen:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<LabourValueInfo> locSelectedItems = default(List<LabourValueInfo>);
            locSelectedItems = myFrmInfoItemsManagerGeneric.SelectedInfoItems;
            if (locSelectedItems != null)
            {
                DialogResult locDr = MessageBox.Show("Sind Sie sicher, dass Sie die Kostenstellen der markierten Arbeitswerte neu zuordnen wollen?", "Kostenstellen neu zuordnen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (locDr == DialogResult.Yes)
                {
                    foreach (LabourValueInfo locLabourValue in locSelectedItems)
                    {
                        locLabourValue.IDCostCenter = Costcenter.IDCostCenter;
                        SPAccess.GetInstance().LabourValues_Edit(locLabourValue, FacessoGeneric.LoginInfo.IDUser);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte w�hlen Sie die Arbeitswerte aus, denen Sie eine neue Kostenstelle zuordnen wollen!", "Kostenstelle ausw�hlen:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            RefreshItems();
        }

        internal void LabourValueInfoAdd()
        {
            GetFrmLabourValueInfoAdd locFH = FunctionHandler<GetFrmLabourValueInfoAdd>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
        }

        internal void LabourValueInfoEdit()
        {
            GetFrmLabourValueInfoEdit locFH = FunctionHandler<GetFrmLabourValueInfoEdit>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            if (myFrmInfoItemsManagerGeneric.SelectedInfoItem == null)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.LabourValueInfoCenter_NoSelectedLabourValue_MB_Body, Facesso.Functions.My.Resources.LabourValueInfoCenter_NoSelectedLabourValue_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem);
        }

        internal void LabourValueInfoDelete()
        {
            GetFuncLabourValueDelete locFH = FunctionHandler<GetFuncLabourValueDelete>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            if (myFrmInfoItemsManagerGeneric.SelectedInfoItem == null)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.LabourValueInfoCenter_NoSelectedLabourValue_MB_Body, Facesso.Functions.My.Resources.LabourValueInfoCenter_NoSelectedLabourValue_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            locFH.DeleteItem(myFrmInfoItemsManagerGeneric.SelectedInfoItem);
        }

        internal void RefreshItems()
        {
            LabourValueInfoCollection locLabourValueInfoCollection = SPAccess.GetInstance().GetLabourValueInfoCollection(myCurrentSortOrderString);
            myFrmInfoItemsManagerGeneric.InfoItems = locLabourValueInfoCollection;
        }

        internal void ColumnClick()
        {
            {
                var __select0 = myFrmInfoItemsManagerGeneric.LastColumnClickEventArgs.Column;
                if (__select0 == 0)
                {
                    myCurrentSortOrderString = "LabourValueNumber";
                }
                else if (__select0 == 1)
                {
                    myCurrentSortOrderString = "LabourValueName";
                }
                else
                {
                    myCurrentSortOrderString = "LabourValueNumber";
                }
            }
        }
    }
}
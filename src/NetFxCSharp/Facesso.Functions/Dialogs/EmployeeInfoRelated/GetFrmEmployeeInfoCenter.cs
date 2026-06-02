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
    public class GetFrmEmployeeInfoCenter : FacessoFunctionBase
    {
        private frmInfoItemsManagerGeneric<EmployeeInfo> myFrmInfoItemsManagerGeneric;
        private string myCurrentSortOrderString = "PersonnelNumber";
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
                return Facesso.Functions.My.Resources.EmployeeInfoCollectionGet_DeniedDueToRole;
            }
        }

        /// <summary>
        /// Liefert - nach Rollenpr�fung - eine Instanz eines UserInfoManagers-Formulars zur�ck,
        /// das als Ausgangspunkt und Funktionsanbieter f�r die Pflege von Benutzerkonten dient.
        /// </summary>
        /// <remarks>R�ckgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
        public void ShowDialog()
        {
            EmployeeInfoItems locEmployeeInfoCollection = new EmployeeInfoItems(0);
            myFrmInfoItemsManagerGeneric = new frmInfoItemsManagerGeneric<EmployeeInfo>(Facesso.Functions.My.Resources.EmployeeInfoCenter_LocalizedTypeName);
            myFrmInfoItemsManagerGeneric.InfoItems = locEmployeeInfoCollection;
            myFrmInfoItemsManagerGeneric.InfoItemAddDelegate = EmployeeInfoAdd;
            myFrmInfoItemsManagerGeneric.InfoItemEditDelegate = EmployeeInfoEdit;
            myFrmInfoItemsManagerGeneric.InfoItemDeleteDelegate = EmployeeInfoDelete;
            myFrmInfoItemsManagerGeneric.RefreshItemsDelegate = RefreshItems;
            myFrmInfoItemsManagerGeneric.InfoItemColumnClickDelegate = ColumnClick;
            myFrmInfoItemsManagerGeneric.PrintListDelegate = PrintList;
            myFrmInfoItemsManagerGeneric.ShowDialog();
        }

        internal void EmployeeInfoAdd()
        {
            GetFrmEmployeeInfoAdd locFH = FunctionHandler<GetFrmEmployeeInfoAdd>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            locFH.ShowDialog();
        }

        internal void EmployeeInfoEdit()
        {
            GetFrmEmployeeInfoEdit locFH = FunctionHandler<GetFrmEmployeeInfoEdit>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            if (myFrmInfoItemsManagerGeneric.SelectedInfoItem == null)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.EmployeeInfoCenter_NoSelectedEmployee_MB_Body, Facesso.Functions.My.Resources.EmployeeInfoCenter_NoSelectedEmployee_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem);
        }

        internal void EmployeeInfoDelete()
        {
            GetFuncEmployeeDelete locFH = FunctionHandler<GetFuncEmployeeDelete>.GetFunctionInstance();
            if (locFH == null)
            {
                return;
            }

            if (myFrmInfoItemsManagerGeneric.SelectedInfoItem == null)
            {
                MessageBox.Show(Facesso.Functions.My.Resources.EmployeeInfoCenter_NoSelectedEmployee_MB_Body, Facesso.Functions.My.Resources.EmployeeInfoCenter_NoSelectedEmployee_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            locFH.DeleteItem(myFrmInfoItemsManagerGeneric.SelectedInfoItem);
        }

        internal void RefreshItems()
        {
            EmployeeInfoItems locEmployeeInfoCollection = new EmployeeInfoItems(myCurrentSortOrderString);
            myFrmInfoItemsManagerGeneric.InfoItems = locEmployeeInfoCollection;
        }

        internal void PrintList()
        {
            ReportEmployeeMasterData reportForm = new ReportEmployeeMasterData();
            reportForm.ShowDialog();
        }

        internal void ColumnClick()
        {
            {
                var __select0 = myFrmInfoItemsManagerGeneric.LastColumnClickEventArgs.Column;
                if (__select0 == 0)
                {
                    myCurrentSortOrderString = "PersonnelNumber";
                }
                else if (__select0 == 1)
                {
                    myCurrentSortOrderString = "LastName";
                }
                else if (__select0 == 2)
                {
                    myCurrentSortOrderString = "FirstName";
                }
                else if (__select0 == 3)
                {
                    myCurrentSortOrderString = "TimeCardNo";
                }
                else
                {
                    myCurrentSortOrderString = "PersonnelNumber";
                }
            }
        }
    }
}
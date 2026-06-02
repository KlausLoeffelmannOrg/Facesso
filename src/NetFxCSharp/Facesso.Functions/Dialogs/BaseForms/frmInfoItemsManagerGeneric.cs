using ActiveDev;
using Facesso;
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    internal class frmInfoItemsManagerGeneric<ItemType> : frmInfoItemsManagerBase where ItemType : IInfoItem
    {
        internal delegate void HandleInfoItemAddDelegate();
        internal delegate void HandleInfoItemEditDelegate();
        internal delegate void HandleRefreshItemsDelegate();
        internal delegate void HandleInfoItemColumnClickDelegate();
        internal delegate void HandleInfoItemDeleteDelegate();
        internal delegate void HandleAssignCostcenterDelegate(CostcenterInfo Costcenter);
        internal delegate void HandlePrintListDelegate();
        private InfoItems<ItemType> myInfoItems;
        private ColumnClickEventArgs myLastColumnClickEventArgs;
        private HandleInfoItemAddDelegate myInfoItemAddDelegate;
        private HandleInfoItemEditDelegate myInfoItemEditDelegate;
        private HandleRefreshItemsDelegate myRefreshItemsDelegate;
        private HandleInfoItemColumnClickDelegate myInfoItemColumnClickDelegate;
        private HandleInfoItemDeleteDelegate myInfoItemDeleteDelegate;
        private HandleAssignCostcenterDelegate myAssignCostcenterDelegate;
        private HandlePrintListDelegate myHandlePrintListDelegate;
        private CostcenterInfoItems myCostCenters;
        public frmInfoItemsManagerGeneric(string InfoItemLocalizedTypeName) : base()
        {
            this.Text = InfoItemLocalizedTypeName + " - Stammdaten verwalten";
            foreach (ToolStripItem tsi in base.EditToolStripMenuItem.DropDownItems)
            {
                if (tsi.Text.Contains("%1"))
                {
                    tsi.Text = tsi.Text.Replace("%1", InfoItemLocalizedTypeName);
                }
            }

            this.Costcenters = null;
        }

        protected override void OnLayout(System.Windows.Forms.LayoutEventArgs levent)
        {
            base.OnLayout(levent);
        }

        protected override void OnFormClosed(System.Windows.Forms.FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }

        internal override void OnInfoItemDoubleClick(object sender, System.EventArgs e)
        {
            myInfoItemEditDelegate.Invoke();
            RefreshItemsManager();
        }

        internal ColumnClickEventArgs LastColumnClickEventArgs
        {
            get
            {
                return myLastColumnClickEventArgs;
            }
        }

        internal InfoItems<ItemType> InfoItems
        {
            get
            {
                return myInfoItems;
            }

            set
            {
                myInfoItems = value;
                if (myInfoItems != null)
                {
                    if (myInfoItems.Count > 0)
                    {
                        arvInfoItems.List = value;
                    }
                }
            }
        }

        internal CostcenterInfoItems Costcenters
        {
            get
            {
                return myCostCenters;
            }

            set
            {
                myCostCenters = value;
                if (value != null)
                {
                    tslCostcenters.Enabled = true;
                    tscCostCenters.Enabled = true;
                    tsbAssignCostcenter.Enabled = true;
                    tscCostCenters.Items.Clear();
                    foreach (CostcenterInfo locCcItem in value)
                    {
                        tscCostCenters.Items.Add(locCcItem);
                    }
                }
                else
                {
                    tscCostCenters.Items.Clear();
                    tslCostcenters.Enabled = false;
                    tscCostCenters.Enabled = false;
                    tsbAssignCostcenter.Enabled = false;
                }
            }
        }

        public ItemType SelectedInfoItem
        {
            get
            {
                if (arvInfoItems.SelectedItems.Count == 0)
                {
                    return default(ItemType);
                }
                else
                {
                    return ((ItemType)arvInfoItems.SelectedItems[0].Tag);
                }
            }
        }

        public List<ItemType> SelectedInfoItems
        {
            get
            {
                if (arvInfoItems.SelectedItems.Count == 0)
                {
                    return null;
                }
                else
                {
                    List<ItemType> locSelectedItems = new List<ItemType>();
                    foreach (ListViewItem locItem in arvInfoItems.SelectedItems)
                    {
                        locSelectedItems.Add(((ItemType)locItem.Tag));
                    }

                    return locSelectedItems;
                }
            }
        }

        internal HandleInfoItemAddDelegate InfoItemAddDelegate
        {
            set
            {
                myInfoItemAddDelegate = value;
                if (value != null)
                {
                    ItemAddToolStripMenuItem.Click += UICaused_ItemAdd;
                    ItemAddToolStripButton.Click += UICaused_ItemAdd;
                }
            }
        }

        internal HandleInfoItemDeleteDelegate InfoItemDeleteDelegate
        {
            set
            {
                myInfoItemDeleteDelegate = value;
                if (value != null)
                {
                    ItemDeleteToolStripMenuItem.Click += UICaused_ItemDelete;
                    ItemDeleteToolStripButton.Click += UICaused_ItemDelete;
                }
            }
        }

        internal HandleInfoItemEditDelegate InfoItemEditDelegate
        {
            set
            {
                myInfoItemEditDelegate = value;
                if (value != null)
                {
                    ItemEditToolStripMenuItem.Click += UICaused_ItemEdit;
                    ItemEditToolStripButton.Click += UICaused_ItemEdit;
                }
            }
        }

        internal HandlePrintListDelegate PrintListDelegate
        {
            set
            {
                myHandlePrintListDelegate = value;
                if (value != null)
                {
                    ItemPrintToolStripButton.Click += UICaused_PrintList;
                    PrintToolStripMenuItem.Click += UICaused_PrintList;
                }
            }
        }

        internal HandleRefreshItemsDelegate RefreshItemsDelegate
        {
            set
            {
                myRefreshItemsDelegate = value;
            }
        }

        internal HandleInfoItemColumnClickDelegate InfoItemColumnClickDelegate
        {
            set
            {
                myInfoItemColumnClickDelegate = value;
                if (value != null)
                {
                    base.InfoItemsColumnClick += UICaused_InfoItemClicked;
                }
            }
        }

        internal HandleAssignCostcenterDelegate AssignCostcenterDelegate
        {
            set
            {
                myAssignCostcenterDelegate = value;
                if (value != null)
                {
                    tsbAssignCostcenter.Click += UICaused_AssignCostcenterClicked;
                }
            }
        }

        private void UICaused_ItemAdd(object sender, EventArgs e)
        {
            myInfoItemAddDelegate.Invoke();
            RefreshItemsManager();
        }

        private void UICaused_ItemEdit(object sender, EventArgs e)
        {
            myInfoItemEditDelegate.Invoke();
            RefreshItemsManager();
        }

        private void UICaused_PrintList(object sender, EventArgs e)
        {
            myHandlePrintListDelegate.Invoke();
        }

        private void UICaused_InfoItemClicked(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            myLastColumnClickEventArgs = e;
            myInfoItemColumnClickDelegate.Invoke();
            RefreshItemsManager();
        }

        private void UICaused_ItemDelete(object sender, EventArgs e)
        {
            myInfoItemDeleteDelegate.Invoke();
            RefreshItemsManager();
        }

        private void UICaused_AssignCostcenterClicked(object sender, EventArgs e)
        {
            myAssignCostcenterDelegate.Invoke(((CostcenterInfo)tscCostCenters.SelectedItem));
        }

        private void RefreshItemsManager()
        {
            IInfoItem locIItem = null;
            if (arvInfoItems.SelectedItems.Count > 0)
            {
                locIItem = ((IInfoItem)arvInfoItems.SelectedItems[0].Tag);
            }

            myRefreshItemsDelegate.Invoke();
            //Durch die Liste galoppieren, und schauen, ob wir es wiederfinden.
            //Wenn ja, dann selektieren!
            if (locIItem != null)
            {
                foreach (ListViewItem locLvi in arvInfoItems.Items)
                {
                    if (((IInfoItem)locLvi.Tag).DataID == locIItem.DataID)
                    {
                        locLvi.Selected = true;
                        locLvi.EnsureVisible();
                        return;
                    }
                }
            }
        }
    }
}
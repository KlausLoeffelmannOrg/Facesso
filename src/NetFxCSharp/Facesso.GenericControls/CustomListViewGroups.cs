using ActiveDev;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.GenericControls
{
    public class CustomListViewGroup<InfoItemType>
        where InfoItemType : IInfoItem
    {
        private InfoItems<InfoItemType> _InfoItems;
        private string _GroupName;
        public CustomListViewGroup(string Groupname, InfoItems<InfoItemType> InfoItems)
        {
            _InfoItems = InfoItems;
            _GroupName = Groupname;
        }

        public InfoItems<InfoItemType> InfoItems
        {
            get
            {
                return _InfoItems;
            }

            set
            {
                _InfoItems = value;
            }
        }

        public string GroupName
        {
            get
            {
                return _GroupName;
            }

            set
            {
                _GroupName = value;
            }
        }
    }

    public class CustomListViewGroups<InfoItemType> : KeyedCollection<string, CustomListViewGroup<InfoItemType>> where InfoItemType : IInfoItem
    {
        private string myKeyProvidedThroughAdd = null;
        protected override string GetKeyForItem(CustomListViewGroup<InfoItemType> item)
        {
            return item.GroupName;
        }

        public int GroupSortIndexOfID(int ID)
        {
            int locCount = this.Count;
            foreach (CustomListViewGroup<InfoItemType> item in this)
            {
                if (item.InfoItems.Contains(new IntKey(ID)))
                {
                    return this.Count - locCount + 1;
                }

                locCount -= 1;
            }

            return 0;
        }
    }
}
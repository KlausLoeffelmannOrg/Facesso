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

namespace Facesso.Interfaces
{
    [Serializable()]
    public class FacessoConversionItemsBase : System.Collections.ObjectModel.KeyedCollection<ActiveDev.IntKey, FacessoConversionItemBase>
    {
        protected override ActiveDev.IntKey GetKeyForItem(FacessoConversionItemBase item)
        {
            return new ActiveDev.IntKey(item.AlienElementID);
        }
    }

    [Serializable()]
    public class FacessoConversionItemBase : IFacessoConversionItem
    {
        private int myAlienElementID;
        private int myHomeElementID;
        private string myHomeElementName;
        private string myItemname;
        public FacessoConversionItemBase() : base()
        {
        }

        public FacessoConversionItemBase(int ID, string Itemname)
        {
            myAlienElementID = ID;
            myHomeElementID = -1;
            myItemname = Itemname;
        }

        public int AlienElementID
        {
            get
            {
                return myAlienElementID;
            }

            set
            {
                myAlienElementID = value;
            }
        }

        public string Itemname
        {
            get
            {
                return myItemname;
            }

            set
            {
                myItemname = value;
            }
        }

        public int HomeElementID
        {
            get
            {
                return myHomeElementID;
            }

            set
            {
                myHomeElementID = value;
            }
        }

        public override string ToString()
        {
            return myItemname;
        }

        public string HomeElementName
        {
            get
            {
                return myHomeElementName;
            }

            set
            {
                myHomeElementName = value;
            }
        }
    }
}
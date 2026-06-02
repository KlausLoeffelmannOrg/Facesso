using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ActiveDev.Controls
{
    public class ADNullableIdOrIndexComboBox : ADNullableValueControlTemplate<int>
    {
        private ADComboBoxedValueForNullableValueControl myComboBox;
        protected override void CreateControls()
        {
            myComboBox = new ADComboBoxedValueForNullableValueControl();
            this.EditableValueControl = myComboBox;
            this.CaptionControl = new ADCaptionForNullableValueControl();
        }

        public ADNullableIdOrIndexComboBox() : base()
        {
            myDontConditionForDisplay = true;
            ConsiderFixedSize = true;
            this.Value = new ADDBNullable<IComparable>();
        }

        public ADNullableComboBoxValueType ComboBoxValueType
        {
            get
            {
                return myComboBox.ComboBoxValueType;
            }

            set
            {
                if (value == ADNullableComboBoxValueType.Content_As_String)
                {
                    ADTypeMismatchException up = new ADTypeMismatchException("ValueType nicht möglich. Setzen Sie stattdessen 'ADNullableContentComboBox' ein, um die Auswahl über den Steuerelemente-Inhalt zu setzen oder diesen direkt aufzufragen!", "This ValueType can't be set in this circumstance. Choose 'AdNullableContentComboBox' instead for setting or getting the selected item via the actual content.");
                    throw up;
                }

                myComboBox.ComboBoxValueType = value;
            }
        }

        public int DropDownHeight
        {
            get
            {
                return myComboBox.DropDownHeight;
            }

            set
            {
                myComboBox.DropDownHeight = value;
            }
        }

        public int DropDownWidth
        {
            get
            {
                return myComboBox.DropDownWidth;
            }

            set
            {
                myComboBox.DropDownWidth = value;
            }
        }

        public int MaxDropDownItems
        {
            get
            {
                return myComboBox.MaxDropDownItems;
            }

            set
            {
                myComboBox.MaxDropDownItems = value;
            }
        }

        public ADComboBoxItemCollection Items
        {
            get
            {
                return ((ADComboBoxedValueForNullableValueControl)EditableValueControl).Items;
            }
        }

        internal ComboBox UnderlyingComboBoxControl
        {
            get
            {
                return ((ADComboBoxedValueForNullableValueControl)this.EditableValueControl).ComboBoxInstance;
            }
        }

        //Nicht gebraucht für dieses Steuerelement, da die Anzeigedarstellung immer der Editierdarstellung entspricht
        protected override object ToObjectForDisplaying(IADDBNullableValue Value, bool ForSetValue)
        {
            return NullString;
        }

        protected override ADDBNullable<int> ToNullableValue(object Object)
        {
            //Case ADNullableComboBoxValueType.Content_As_String
            //    Return New ADDBNullable(Of IComparable)(DirectCast([Object], ADDBNullable(Of String)))
            return new ADDBNullable<int>(((ADDBNullable<int>)Object));
        }

        protected override IADDBNullableValue GetCurrentControlValue()
        {
            return new ADDBNullable<int>(((ADDBNullable<int>)myValueControl.Value));
        }
    }

    public enum ADNullableComboBoxValueType
    {
        Content_As_String,
        ID_As_Int32,
        Index_As_Int32,
    }

    public class ADComboBoxItemCollection
    {
        private ComboBox.ObjectCollection myComboBoxObjectCollection;
        public ADComboBoxItemCollection(ADNullableIdOrIndexComboBox owner)
        {
            myComboBoxObjectCollection = new ComboBox.ObjectCollection(owner.UnderlyingComboBoxControl);
        }

        public ADComboBoxItemCollection(ComboBox.ObjectCollection ObjCollection)
        {
            myComboBoxObjectCollection = ObjCollection;
        }

        public int Add(ADComboBoxItem Item)
        {
            return myComboBoxObjectCollection.Add(Item);
        }

        public void RemoveByID(int ID)
        {
            int locIndex = IndexFromID(ID);
            if (locIndex > -1)
            {
                myComboBoxObjectCollection.RemoveAt(locIndex);
            }
            else
            {
                //Todo: Translate
                ADArgumentException up = new ADArgumentException("Ein Wert mit der angegebenen ID konnte in der Objektliste der ComboBox nicht gefunden werden!", "A value with the ID could not be found in the object list of the ComboBox!", "ID");
                throw up;
            }
        }

        public void RemoveAt(int Index)
        {
            myComboBoxObjectCollection.RemoveAt(Index);
        }

        public object this[int Index]
        {
            get
            {
                return myComboBoxObjectCollection[Index];
            }

            set
            {
                myComboBoxObjectCollection[Index] = value;
            }
        }

        public int IndexFromID(int ID)
        {
            int locIndex = 0;
            foreach (ADComboBoxItem myItem in myComboBoxObjectCollection)
            {
                if (myItem.ID == ID)
                {
                    return locIndex;
                }

                locIndex += 1;
            }

            return -1;
        }

        public int IndexFromString(string Item)
        {
            int locIndex = 0;
            foreach (ADComboBoxItem myItem in myComboBoxObjectCollection)
            {
                if (myItem.Item.ToString() == Item)
                {
                    return locIndex;
                }

                locIndex += 1;
            }

            return -1;
        }
    }

    public struct ADComboBoxItem : IComparable
    {
        private int myID;
        private object myItem;
        public ADComboBoxItem(int ID, object Item)
        {
            myID = ID;
            myItem = Item;
        }

        public int ID
        {
            get
            {
                return myID;
            }

            set
            {
                myID = value;
            }
        }

        public object Item
        {
            get
            {
                return myItem;
            }

            set
            {
                myItem = value;
            }
        }

        public override string ToString()
        {
            return Item.ToString();
        }

        public int CompareTo(object obj)
        {
            ADComboBoxItem locCTItem = ((ADComboBoxItem)obj);
            return this.Item.ToString().CompareTo(locCTItem.Item.ToString());
        }
    }
}
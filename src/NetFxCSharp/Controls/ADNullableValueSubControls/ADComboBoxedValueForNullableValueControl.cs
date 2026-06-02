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

namespace ActiveDev.Controls
{
    internal class ADComboBoxedValueForNullableValueControl : ADEditableValueForNullableValueControlTemplate<IComparable>
    {
        private ComboBox _myComboBox;
        protected ComboBox myComboBox
        {
            get
            {
                return _myComboBox;
            }

            set
            {
                if (_myComboBox != null)
                {
                    _myComboBox.SelectedIndexChanged -= myComboBox_SelectedIndexChanged;
                }

                _myComboBox = value;
                if (_myComboBox != null)
                {
                    _myComboBox.SelectedIndexChanged += myComboBox_SelectedIndexChanged;
                }
            }
        }

        protected ADComboBoxItemCollection myComboBoxItemCollection;
        protected ADNullableComboBoxValueType myComboBoxValueType;
        public ADComboBoxedValueForNullableValueControl() : base()
        {
            myComboBoxValueType = ADNullableComboBoxValueType.ID_As_Int32;
            myComboBox = new ComboBox();
            myControl = myComboBox;
            myControl.Name = "ADComboBoxedValueForUVTControl" + myInstanceCounter;
            myComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            myComboBoxItemCollection = new ADComboBoxItemCollection(myComboBox.Items);
        }

        public override System.Drawing.Size Size
        {
            get
            {
                return myControl.Size;
            }

            set
            {
                System.Drawing.Size Value = value;
                myControl.Size = Value;
            }
        }

        public override int MeasureHeight()
        {
            return (myControl.Height) * -1;
        }

        public override object Value
        {
            get
            {
                if (myComboBox.SelectedIndex == -1)
                {
                    {
                        var __select0 = (int)(ComboBoxValueType);
                        if (__select0 == (int)(ADNullableComboBoxValueType.Content_As_String))
                        {
                            return new ADDBNullable<string>();
                        }
                        else
                        {
                            ADDBNullable<int> locNullableInt = new ADDBNullable<int>();
                            return locNullableInt;
                        }
                    }
                }

                {
                    var __select1 = (int)(ComboBoxValueType);
                    if (__select1 == (int)(ADNullableComboBoxValueType.Content_As_String))
                    {
                        return new ADDBNullable<string>(((ADComboBoxItem)myComboBox.Items[myComboBox.SelectedIndex]).ToString());
                    }
                    else if (__select1 == (int)(ADNullableComboBoxValueType.Index_As_Int32))
                    {
                        return new ADDBNullable<int>(myComboBox.SelectedIndex);
                    }
                    else
                    {
                        return new ADDBNullable<int>(((ADComboBoxItem)myComboBox.Items[myComboBox.SelectedIndex]).ID);
                    }
                }
            }

            set
            {
                object Value = value;
                if ((Value == null))
                {
                    myComboBox.SelectedIndex = -1;
                }
                else if (Value is ADDBNullable<int>)
                {
                    if (!(((ADDBNullable<int>)Value).HasValue))
                    {
                        myComboBox.SelectedIndex = -1;
                    }
                    else
                    {
                        int locInt = System.Convert.ToInt32(((ADDBNullable<int>)Value).Value);
                        {
                            var __select2 = (int)(ComboBoxValueType);
                            if (__select2 == (int)(ADNullableComboBoxValueType.Index_As_Int32))
                            {
                                myComboBox.SelectedIndex = locInt;
                            }
                            else if (__select2 == (int)(ADNullableComboBoxValueType.ID_As_Int32))
                            {
                                myComboBox.SelectedIndex = myComboBoxItemCollection.IndexFromID(locInt);
                            }
                            else
                            {
                                InvalidCastException Up = new InvalidCastException("ADDBNullable(Of Integer) expected as Value");
                                throw Up;
                            }
                        }
                    }
                }
                else if (Value is ADDBNullable<string>)
                {
                    if (!(((ADDBNullable<string>)Value).HasValue))
                    {
                        myComboBox.SelectedIndex = -1;
                    }
                    else
                    {
                        if (ComboBoxValueType == ADNullableComboBoxValueType.Content_As_String)
                        {
                            myComboBox.SelectedIndex = myComboBoxItemCollection.IndexFromString(((ADDBNullable<string>)Value).Value.ToString());
                        }
                        else
                        {
                            InvalidCastException Up = new InvalidCastException("ADDBNullable(Of String) expected as Value");
                            throw Up;
                        }
                    }
                }
            }
        }

        public ADNullableComboBoxValueType ComboBoxValueType
        {
            get
            {
                return myComboBoxValueType;
            }

            set
            {
                myComboBoxValueType = value;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return myComboBox.SelectedIndex;
            }

            set
            {
                myComboBox.SelectedIndex = value;
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

        public virtual ADComboBoxItemCollection Items
        {
            get
            {
                return myComboBoxItemCollection;
            }
        }

        internal ComboBox ComboBoxInstance
        {
            get
            {
                return myComboBox;
            }
        }

        private void myComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            OnValueChanged(e);
        }
    }
}
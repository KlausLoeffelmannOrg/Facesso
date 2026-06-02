using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ActiveDev.Controls
{
    internal class ADCheckBoxedValueForNullableValueControl : ADEditableValueForNullableValueControlTemplate<bool>
    {
        private CheckBox _myCheckBox;
        // TODO(vb-convert): WithEvents member is reassigned outside InitializeComponent; re-wiring retained.
        protected CheckBox myCheckBox
        {
            get
            {
                return _myCheckBox;
            }

            set
            {
                if (_myCheckBox != null)
                {
                    _myCheckBox.CheckedChanged -= myComboBox_SelectedIndexChanged;
                }

                _myCheckBox = value;
                if (_myCheckBox != null)
                {
                    _myCheckBox.CheckedChanged += myComboBox_SelectedIndexChanged;
                }
            }
        }

        public ADCheckBoxedValueForNullableValueControl() : base()
        {
            myCheckBox = new CheckBox();
            myControl = myCheckBox;
            myControl.Name = "ADCheckBoxedValueForUVTControl" + myInstanceCounter;
            myCheckBox.ThreeState = true;
            myCheckBox.CheckState = CheckState.Indeterminate;
            myCheckBox.Text = "";
            myCheckBox.BackColor = BackColor;
            PaddingToCaption = 0;
            CheckAlignment = ContentAlignment.MiddleCenter;
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

        public int PaddingToCaption
        {
            get
            {
                return myCheckBox.Padding.Left;
            }

            set
            {
                myCheckBox.Padding = new System.Windows.Forms.Padding(value, myCheckBox.Padding.Top, myCheckBox.Padding.Right, myCheckBox.Padding.Bottom);
            }
        }

        public ContentAlignment CheckAlignment
        {
            get
            {
                return myCheckBox.CheckAlign;
            }

            set
            {
                myCheckBox.CheckAlign = value;
            }
        }

        public override object Value
        {
            get
            {
                if (myCheckBox.CheckState == CheckState.Indeterminate)
                {
                    return null;
                }

                return myCheckBox.Checked;
            }

            set
            {
                object Value = value;
                ADDBNullable<bool> locTOB = ((ADDBNullable<bool>)Value);
                if (!(locTOB.HasValue))
                {
                    myCheckBox.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    if (System.Convert.ToBoolean(((ADDBNullable<bool>)Value).Value))
                    {
                        myCheckBox.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        myCheckBox.CheckState = CheckState.Unchecked;
                    }
                }
            }
        }

        private void myComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            OnValueChanged(e);
        }
    }
}
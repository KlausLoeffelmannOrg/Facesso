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
    internal class ADEditableUpDownValueForNullableValueControl : ADEditableValueForNullableValueControlTemplate<int>
    {
        private NumericUpDown _myNumericUpDown;
        protected NumericUpDown myNumericUpDown
        {
            get
            {
                return _myNumericUpDown;
            }

            set
            {
                if (_myNumericUpDown != null)
                {
                    _myNumericUpDown.TextChanged -= myNumericUpDown_TextChanged;
                    _myNumericUpDown.Validated -= myNumericUpDown_Validated;
                    _myNumericUpDown.Validating -= myNumericUpDown_Validating;
                }

                _myNumericUpDown = value;
                if (_myNumericUpDown != null)
                {
                    _myNumericUpDown.TextChanged += myNumericUpDown_TextChanged;
                    _myNumericUpDown.Validated += myNumericUpDown_Validated;
                    _myNumericUpDown.Validating += myNumericUpDown_Validating;
                }
            }
        }

        public ADEditableUpDownValueForNullableValueControl() : base()
        {
            myNumericUpDown = new NumericUpDown();
            myControl = myNumericUpDown;
            myControl.Name = "ADVariantTextControl" + myInstanceCounter;
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
                return ((NumericUpDown)myControl).Text;
            }

            set
            {
                object Value = value;
                if (Value == null)
                {
                    ((NumericUpDown)myControl).Text = "";
                }
                else
                {
                    ((NumericUpDown)myControl).Text = Value.ToString();
                }
            }
        }

        private void myNumericUpDown_TextChanged(object sender, System.EventArgs e)
        {
            OnValueChanged(e);
        }

        private void myNumericUpDown_Validated(object sender, System.EventArgs e)
        {
            OnValidated(e);
        }

        private void myNumericUpDown_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnValidating(e);
        }
    }
}
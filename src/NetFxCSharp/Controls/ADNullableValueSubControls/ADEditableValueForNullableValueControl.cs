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
    internal class ADEditableValueForNullableValueControl : ADEditableValueForNullableValueControlTemplate<string>
    {
        private TextBox _myTextBox;
        protected TextBox myTextBox
        {
            get
            {
                return _myTextBox;
            }

            set
            {
                if (_myTextBox != null)
                {
                    _myTextBox.TextChanged -= myTextBox_TextChanged;
                    _myTextBox.Validated -= myTextBox_Validated;
                    _myTextBox.Validating -= myTextBox_Validating;
                }

                _myTextBox = value;
                if (_myTextBox != null)
                {
                    _myTextBox.TextChanged += myTextBox_TextChanged;
                    _myTextBox.Validated += myTextBox_Validated;
                    _myTextBox.Validating += myTextBox_Validating;
                }
            }
        }

        public ADEditableValueForNullableValueControl() : base()
        {
            myTextBox = new TextBox();
            myControl = myTextBox;
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
            if (((TextBox)myControl).Multiline)
            {
                return this.Font.Height;
            }
            else
            {
                return (myControl.Height) * -1;
            }
        }

        public virtual bool Multiline
        {
            get
            {
                return ((TextBox)myControl).Multiline;
            }

            set
            {
                bool Value = value;
                ((TextBox)myControl).Multiline = Value;
            }
        }

        public override object Value
        {
            get
            {
                return ((TextBox)myControl).Text;
            }

            set
            {
                object Value = value;
                if (Value == null)
                {
                    ((TextBox)myControl).Text = "";
                }
                else
                {
                    ((TextBox)myControl).Text = Value.ToString();
                }
            }
        }

        public virtual ScrollBars ScrollBars
        {
            get
            {
                return ((TextBox)myControl).ScrollBars;
            }

            set
            {
                ScrollBars Value = value;
                ((TextBox)myControl).ScrollBars = Value;
            }
        }

        public virtual int MaxLength
        {
            get
            {
                return ((TextBox)myControl).MaxLength;
            }

            set
            {
                int Value = value;
                ((TextBox)myControl).MaxLength = Value;
            }
        }

        public virtual bool Readonly
        {
            get
            {
                return ((TextBox)myControl).ReadOnly;
            }

            set
            {
                ((TextBox)myControl).ReadOnly = value;
            }
        }

        private void myTextBox_TextChanged(object sender, System.EventArgs e)
        {
            OnValueChanged(e);
        }

        private void myTextBox_Validated(object sender, System.EventArgs e)
        {
            OnValidated(e);
        }

        private void myTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnValidating(e);
        }
    }
}
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
    public class ADNullableTextBox : ADNullableValueControlTemplate<string>
    {
        protected bool myReturnNullOnEmptyString;
        protected override void CreateControls()
        {
            this.EditableValueControl = new ADEditableValueForNullableValueControl();
            this.CaptionControl = new ADCaptionForNullableValueControl();
        }

        public ADNullableTextBox() : base()
        {
            ConsiderFixedSize = true;
            this.NullString = "* --- *";
            this.Value = new ADDBNullable<string>();
            this.ReturnNullOnEmptyString = true;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Steuert, ob der Text im Datenerfassungsbereich mehr als eine Zeile umfassen darf.", "Controls, if the text in the data input area can contain more than one line.")]
        public bool Multiline
        {
            get
            {
                return ((ADEditableValueForNullableValueControl)this.EditableValueControl).Multiline;
            }

            set
            {
                bool Value = value;
                ((ADEditableValueForNullableValueControl)this.EditableValueControl).Multiline = Value;
                if (Value)
                {
                    ConsiderFixedSize = false;
                    myControlHeight = myRequestedlHeight;
                }
                else
                {
                    ConsiderFixedSize = true;
                }

                UpdateLayout();
            }
        }

        [ADCategory("Darstellung", "Display")]
        [ADDescription("Bestimmt oder ermittelt, welche Scrollbalken der Datenerfassungsbereich aufweisen soll.", "Sets or gets, which scrollbars should be available for scrolling in the data input area.")]
        public ScrollBars Scrollbars
        {
            get
            {
                return ((ADEditableValueForNullableValueControl)this.EditableValueControl).ScrollBars;
            }

            set
            {
                ScrollBars Value = value;
                ((ADEditableValueForNullableValueControl)this.EditableValueControl).ScrollBars = Value;
                UpdateLayout();
            }
        }

        public bool ShouldSerializeScrollbars()
        {
            return !((Scrollbars == ScrollBars.None));
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt, wieviele Zeichen im Datenerfassungsbereich maximal eingegeben werden dürfen.", "Determines the amount of characters the user can enter in the data input area.")]
        [DefaultValue(32767)]
        public int MaxLength
        {
            get
            {
                return ((ADEditableValueForNullableValueControl)this.EditableValueControl).MaxLength;
            }

            set
            {
                int Value = value;
                ((ADEditableValueForNullableValueControl)this.EditableValueControl).MaxLength = Value;
                UpdateLayout();
            }
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt, ob der dargestellte Wert/Text nicht verändert werden darf.", "Determines, wether the displayed value can be changed or not.")]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get
            {
                return ((ADEditableValueForNullableValueControl)this.EditableValueControl).Readonly;
            }

            set
            {
                bool Value = value;
                ((ADEditableValueForNullableValueControl)this.EditableValueControl).Readonly = Value;
                UpdateLayout();
            }
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt, ob NULL zurückgeliefert werden soll, wenn keine Eingabe im Datenerfassungsbereich vorgenommen wurde.", "Determines, if NULL is returned, when no data has been entered in the data input area.")]
        [DefaultValue(true)]
        public bool ReturnNullOnEmptyString
        {
            get
            {
                return myReturnNullOnEmptyString;
            }

            set
            {
                bool Value = value;
                myReturnNullOnEmptyString = Value;
            }
        }

        protected override object ToObjectForDisplaying(IADDBNullableValue Value, bool ForSetValue)
        {
            if (!(Value.HasValue))
            {
                return NullString;
            }
            else
            {
                return Value.Value.ToString();
            }
        }

        protected override ADDBNullable<string> ToNullableValue(object Object)
        {
            if (ReturnNullOnEmptyString)
            {
                if (Object.ToString() == "" | Object == null)
                {
                    return default(ActiveDev.ADDBNullable<string>);
                }
            }

            return ADDBNullable.FromObject<string>(Object);
        }
    }
}
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ActiveDev.Controls
{
    public class ADNullableCheckBox : ADNullableValueControlTemplate<bool>
    {
        protected override void CreateControls()
        {
            this.EditableValueControl = new ADCheckBoxedValueForNullableValueControl();
            this.CaptionControl = new ADCaptionForNullableValueControl();
        }

        public ADNullableCheckBox() : base()
        {
            ADDBNullable<bool> locNullable = new ADDBNullable<bool>();
            locNullable = default(ActiveDev.ADDBNullable<bool>);
            ConsiderFixedSize = true;
            myDontConditionForDisplay = true;
            this.Value = locNullable;
        }

        protected override System.Drawing.Color GetInitialValueControlColor()
        {
            return SystemColors.Control;
        }

        //Vorgegebene Breite der Controls
        //Aus ihnen ergibt sich das anfängliche Verhältnis für
        //Captionlänge und Wertebereichlänge
        protected override int InitialCaptionControlLength
        {
            get
            {
                return 400;
            }
        }

        protected override int InitialValueControlLength
        {
            get
            {
                return 100;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(true)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Steuert, ob der Text im Datenerfassungsbereich mehr als eine Zeile umfassen darf.", "Controls, if the text in the data input area can contain more than one line.")]
        public bool AutoHeight
        {
            get
            {
                return ConsiderFixedSize;
            }

            set
            {
                bool Value = value;
                ConsiderFixedSize = Value;
                UpdateLayout();
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

        protected override object ToObjectForEditing(IADDBNullableValue Value)
        {
            return Value;
        }

        protected override ADDBNullable<bool> ToNullableValue(object Object)
        {
            if (Object == null)
            {
                return default(ActiveDev.ADDBNullable<bool>);
            }

            return System.Convert.ToBoolean(Object);
        }
    }
}
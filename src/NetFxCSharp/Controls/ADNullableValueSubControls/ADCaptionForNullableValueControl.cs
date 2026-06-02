using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ActiveDev.Controls
{
    internal partial class ADCaptionForNullableValueControl : ADCaptionForNullableValueControlTemplate
    {
        //Um die Mindesthöhe einer Zeile zu lesen, benötigen wir die Größe
        //des verwendeten Fonts, so wie ihn das Control intern selbst misst.
        //Da "FontHeight" protected ist, kommen wir da so nicht dran -
        //bevor wir es selber programmieren, legen wir die Eigenschaft einfach frei;
        //dazu definieren wir eine neue Labelklasse basierend auf dem alten Label-Control
        public ADCaptionForNullableValueControl()
        {
            myControl = new ADLabelExInternal();
            myControl.Name = "ADLabelExInternal" + myInstanceCounter;
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
            //Nur eine Zeile für die Fontgröße!
            //Mit ein bisschen Abstand oben und unten (+3 Pixel)
            return ((ADLabelExInternal)myControl).FontHeightInternal + 6;
        }

        public override System.Drawing.ContentAlignment Alignment
        {
            get
            {
                return ((ADLabelExInternal)myControl).TextAlign;
            }

            set
            {
                System.Drawing.ContentAlignment Value = value;
                ((ADLabelExInternal)myControl).TextAlign = Value;
            }
        }

        public override BorderStyle BorderStyle
        {
            get
            {
                return ((ADLabelExInternal)myControl).BorderStyle;
            }

            set
            {
                BorderStyle Value = value;
                ((ADLabelExInternal)myControl).BorderStyle = Value;
            }
        }
    }
}
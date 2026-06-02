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
    public interface IADCaptionForNullableValueControl
    {
        ContentAlignment Alignment { get; set; }

        BorderStyle BorderStyle { get; set; }

        Font Font { get; set; }

        Color BackColor { get; set; }

        Color ForeColor { get; set; }

        string Text { get; set; }

        //Liefert ein Control-Array zurück, dass dem umgebenden
        //Steuerelement hinzugefügt wird. Damit kann das Beschriftungs-Control
        //durchaus auch aus mehreren Controls bestehen
        Control[] Controls { get; }

        Point Location { get; set; }

        Size Size { get; set; }

        //Definiert die Größenreglementierung der Beschriftung
        //Positiver Wert: Mindesthöhe
        //Negativer Wert: Fixe Höhe
        int MeasureHeight();
        Control Parent { get; set; }

        void Invalidate();
    }

    public interface IADEditableValueForNullableValueControl
    {
        Font Font { get; set; }

        Color BackColor { get; set; }

        Color ForeColor { get; set; }

        //Der aktuelle Wert als Object, damit
        //ihn jedes belibige Control darstellen kann
        object Value { get; set; }

        //Liefert ein Control-Array zurück, dass dem umgebenden
        //Steuerelement hinzugefügt wird. Damit kann das Werte-Control
        //durchaus auch aus mehreren Controls bestehen
        Control[] Controls { get; }

        Point Location { get; set; }

        Size Size { get; set; }

        Control Parent { get; set; }

        //Definiert die Größenreglementierung der Beschriftung
        //Positiver Wert: Mindesthöhe
        //Negativer Wert: Fixe Höhe
        int MeasureHeight();
        //Wird durch Chance getriggert, während Modified und Modified Changed
        //durch den Entwickler ausschließlich über Modified getriggert wird!
        bool OnceModified { get; set; }

        void ResetOnceModified();
        delegate void ValueChangedEventHandler(object sender, System.EventArgs e);
        event ValueChangedEventHandler ValueChanged;
        delegate void ValidatedEventHandler(object sender, System.EventArgs e);
        event ValidatedEventHandler Validated;
        delegate void ValidatingEventHandler(object sender, System.ComponentModel.CancelEventArgs e);
        event ValidatingEventHandler Validating;
        delegate void OnceModifiedChangedEventHandler(object sender, System.EventArgs e);
        event OnceModifiedChangedEventHandler OnceModifiedChanged;
        void OnValueChanged(System.EventArgs e);
        void OnValidated(System.EventArgs e);
        void OnValidating(System.ComponentModel.CancelEventArgs e);
        void OnOnceModifiedChanged(System.EventArgs e);
        void Invalidate();
    }

    public abstract class ADCaptionForNullableValueControlTemplate : IADCaptionForNullableValueControl
    {
        protected Control myControl;
        protected static int myInstanceCounter;
        public ADCaptionForNullableValueControlTemplate()
        {
            //Wird in abgeleiteten Controls zur Namensbestimmung herangezoegen
            myInstanceCounter += 1;
        }

        public virtual System.Drawing.Color BackColor
        {
            get
            {
                return myControl.BackColor;
            }

            set
            {
                System.Drawing.Color Value = value;
                myControl.BackColor = Value;
            }
        }

        public virtual System.Drawing.Font Font
        {
            get
            {
                return myControl.Font;
            }

            set
            {
                System.Drawing.Font Value = value;
                myControl.Font = Value;
            }
        }

        public virtual System.Drawing.Color ForeColor
        {
            get
            {
                return myControl.ForeColor;
            }

            set
            {
                System.Drawing.Color Value = value;
                myControl.ForeColor = Value;
            }
        }

        public virtual System.Drawing.Point Location
        {
            get
            {
                return myControl.Location;
            }

            set
            {
                System.Drawing.Point Value = value;
                myControl.Location = Value;
            }
        }

        public virtual System.Drawing.Size Size
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

        public virtual string Text
        {
            get
            {
                return myControl.Text;
            }

            set
            {
                string Value = value;
                myControl.Text = Value;
            }
        }

        public virtual System.Windows.Forms.Control[] Controls
        {
            get
            {
                Control[] locControl = new Control[1];
                locControl[0] = myControl;
                return locControl;
            }
        }

        public virtual int MeasureHeight()
        {
            return 0;
        }

        public abstract System.Drawing.ContentAlignment Alignment { get; set; }
        public abstract System.Windows.Forms.BorderStyle BorderStyle { get; set; }

        public System.Windows.Forms.Control Parent
        {
            get
            {
                return myControl.Parent;
            }

            set
            {
                myControl.Parent = value;
            }
        }

        public void Invalidate()
        {
            myControl.Invalidate();
        }
    }

    public abstract class ADEditableValueForNullableValueControlTemplate<ValType> : IADEditableValueForNullableValueControl where ValType : IComparable
    {
        protected Control myControl;
        protected ADDBNullable<ValType> myValue;
        protected ADDBNullable<ValType> myAssignedValue;
        protected static int myInstanceCounter;
        protected bool myOnceModified;
        public event ActiveDev.Controls.IADEditableValueForNullableValueControl.ValueChangedEventHandler ValueChanged;
        public event ActiveDev.Controls.IADEditableValueForNullableValueControl.ValidatedEventHandler Validated;
        public event ActiveDev.Controls.IADEditableValueForNullableValueControl.ValidatingEventHandler Validating;
        public event ActiveDev.Controls.IADEditableValueForNullableValueControl.OnceModifiedChangedEventHandler OnceModifiedChanged;
        public ADEditableValueForNullableValueControlTemplate()
        {
            //Alte Überlegung
            myInstanceCounter += 1;
        }

        public virtual System.Drawing.Color BackColor
        {
            get
            {
                return myControl.BackColor;
            }

            set
            {
                System.Drawing.Color Value = value;
                myControl.BackColor = Value;
            }
        }

        public virtual System.Drawing.Font Font
        {
            get
            {
                return myControl.Font;
            }

            set
            {
                System.Drawing.Font Value = value;
                myControl.Font = Value;
            }
        }

        public virtual System.Drawing.Color ForeColor
        {
            get
            {
                return myControl.ForeColor;
            }

            set
            {
                System.Drawing.Color Value = value;
                myControl.ForeColor = Value;
            }
        }

        public virtual System.Drawing.Point Location
        {
            get
            {
                return myControl.Location;
            }

            set
            {
                System.Drawing.Point Value = value;
                myControl.Location = Value;
            }
        }

        public virtual System.Drawing.Size Size
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

        public virtual bool OnceModified
        {
            get
            {
                return myOnceModified;
            }

            set
            {
                bool Value = value;
                if (Value != myOnceModified & Value == true)
                {
                    OnOnceModifiedChanged(EventArgs.Empty);
                }

                myOnceModified = Value;
            }
        }

        public abstract object Value { get; set; }

        public virtual System.Windows.Forms.Control[] Controls
        {
            get
            {
                Control[] locControl = new Control[1];
                locControl[0] = myControl;
                return locControl;
            }
        }

        //Bestimmt die Höhe eines Controls
        //negativer Wert: Fixe Höhe
        //positivert Wert: Mindesthöhe
        //0: keine Festlegung
        public virtual int MeasureHeight()
        {
            return 0;
        }

        public virtual void OnValueChanged(System.EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
            OnceModified = OnceModified | true;
        }

        public virtual void OnValidated(System.EventArgs e)
        {
            Validated?.Invoke(this, e);
        }

        public virtual void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            Validating?.Invoke(this, e);
        }

        public virtual void OnOnceModifiedChanged(System.EventArgs e)
        {
            OnceModifiedChanged?.Invoke(this, e);
        }

        public virtual void ResetOnceModified()
        {
            //Löst kein Ereignis aus! Sie können aber OnceModified überschreiben,
            //falls Sie dieses Ereignis dennoch in einen Event umwandeln möchten
            OnceModified = false;
        }

        public System.Windows.Forms.Control Parent
        {
            get
            {
                return myControl.Parent;
            }

            set
            {
                myControl.Parent = value;
            }
        }

        public void Invalidate()
        {
            myControl.Invalidate();
        }
    }
}
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ActiveDev.Controls
{
    public class ADNullableIntBox : ADNullableValueControlTemplate<int>
    {
        protected bool myReturnNullOnEmptyString;
        protected string myAssignFormatString;
        protected string myDisplayCustomFormatString;
        protected ADUVNumFormat myDisplayFormat;
        protected ADUVNumFormat myPreferredDisplayFormat;
        protected string myCurrencyText;
        protected string myFormularText;
        protected int myMaxValue;
        protected int myMinValue;
        protected string myExpressionError;
        protected string myValueTooHighError;
        protected string myValueTooLowError;
        protected static string mySharedDefaultExpressionError;
        protected static string mySharedDefaultTooHighError;
        protected static string mySharedDefaultTooLowError;
        static ADNullableIntBox()
        {
            CultureInfo locCi;
            locCi = CultureInfo.CurrentCulture;
            if (locCi.Name.StartsWith("de"))
            {
                mySharedDefaultExpressionError = "Formelfehler|Der eingegebene Ausdruck konnte auf Grund eines Syntaxfehlers nicht ausgewertet werden." + System.Environment.NewLine + "Vielleicht fehlt eine Klammer oder sind doppelte Rechenzeichen in der Formel vorhanden.";
                mySharedDefaultTooHighError = "Eingabefehler|Der eingegebe Wert ist zu hoch. Bitte überprüfen Sie den Wert.";
                mySharedDefaultTooLowError = "Eingabefehler|Der eingegebene Wert ist zu niedrig. Bitte überprüfen Sie den Wert.";
            }
            else
            {
                mySharedDefaultExpressionError = "Error in formular|The expression you have entered caused a syntax error. Maybe a parenthesis is missing or the formular contains mistyped operators.";
                mySharedDefaultTooHighError = "Input error|The value you have entered is too high. Please check the value.";
                mySharedDefaultTooLowError = "Input error|The value you have entered is too low. Please check the value.";
            }
        }

        public ADNullableIntBox() : base()
        {
            ADDBNullable<int> locNullable = new ADDBNullable<int>();
            ConsiderFixedSize = true;
            NullString = "* --- *";
            Value = locNullable;
            myAssignFormatString = "###0";
            myDisplayFormat = ADUVNumFormat.UseProperties;
            myPreferredDisplayFormat = ADUVNumFormat.UseProperties;
            myDisplayCustomFormatString = "000000";
            myFormularText = "";
            myMaxValue = 0;
            myMinValue = 0;
            myExpressionError = mySharedDefaultExpressionError;
            myValueTooHighError = mySharedDefaultTooHighError;
            myValueTooLowError = mySharedDefaultTooLowError;
        }

        protected override void CreateControls()
        {
            this.EditableValueControl = new ADEditableValueForNullableValueControl();
            this.CaptionControl = new ADCaptionForNullableValueControl();
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt das Format des Zahlenwertes bei der Zuweisung durch die Value-Eigenschaft.", "Sets or gets the format of the number value which results out of the value property assignment.")]
        public string AssignFormatString
        {
            get
            {
                return myAssignFormatString;
            }

            set
            {
                string Value = value;
                myAssignFormatString = Value;
            }
        }

        public bool ShouldSerializeAssignFormatString()
        {
            return !((AssignFormatString == "###0"));
        }

        public void ResetAssignFormatString()
        {
            AssignFormatString = "###0";
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt das Format, mit dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", "Gets or sets the format, with which the value is formatted, when the control looses its focus.")]
        public ADUVNumFormat DisplayFormat
        {
            get
            {
                return myDisplayFormat;
            }

            set
            {
                ADUVNumFormat Value = value;
                myDisplayFormat = Value;
            }
        }

        public bool ShouldSerializeDisplayFormat()
        {
            return !((DisplayFormat == ADUVNumFormat.UseProperties));
        }

        public void ResetDisplayFormat()
        {
            DisplayFormat = ADUVNumFormat.UseProperties;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Ermittelt den DisplayFormatString.", "Gets the DisplayFormatString.")]
        public string DisplayFormatString
        {
            get
            {
                if (DisplayFormat == ADUVNumFormat.UseCustomString)
                {
                    return DisplayCustomFormatString;
                }
                else
                {
                    return "###0";
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt das benutzerdefinierte Format, mit dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", "Gets or sets the custom format, with which the value is formatted, when the control looses its focus.")]
        public string DisplayCustomFormatString
        {
            get
            {
                return myDisplayCustomFormatString;
            }

            set
            {
                string Value = value;
                if ((Value == "") | (Value == null))
                {
                    DisplayFormat = myPreferredDisplayFormat;
                    Value = "";
                }
                else
                {
                    myPreferredDisplayFormat = DisplayFormat;
                    DisplayFormat = ADUVNumFormat.UseCustomString;
                }

                myDisplayCustomFormatString = Value;
            }
        }

        public bool ShouldSerializeDisplayCustomFormatString()
        {
            return !((DisplayCustomFormatString == "000000"));
        }

        public void ResetDisplayCustomFormatString()
        {
            DisplayCustomFormatString = "000000";
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt, ob bei der Formatierung die Tausendergruppierung berücksichtigt werden soll.", "Gets or sets, wether digits before the decimal seperator should be grouped.")]
        public string FormularText
        {
            get
            {
                return myFormularText;
            }

            set
            {
                string Value = value;
                myFormularText = Value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt das benutzerdefinierte Format, mit dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", "Gets or sets the custom format, with which the value is formatted, when the control looses its focus.")]
        [DefaultValue(typeof(decimal), "0")]
        public int MaxValue
        {
            get
            {
                return myMaxValue;
            }

            set
            {
                int Value = value;
                myMaxValue = Value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt das benutzerdefinierte Format, mit dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", "Gets or sets the custom format, with which the value is formatted, when the control looses its focus.")]
        [DefaultValue(typeof(decimal), "0")]
        public int MinValue
        {
            get
            {
                return myMinValue;
            }

            set
            {
                int Value = value;
                myMinValue = Value;
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

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt, ob bei der Formatierung die Tausendergruppierung berücksichtigt werden soll.", "Gets or sets, wether digits before the decimal seperator should be grouped.")]
        public string ExpressionErrorText
        {
            get
            {
                return myExpressionError;
            }

            set
            {
                string Value = value;
                myExpressionError = Value;
            }
        }

        public bool ShouldSerializeExpressionErrorText()
        {
            return !((ExpressionErrorText == mySharedDefaultExpressionError));
        }

        public void ResetExpressionErrorText()
        {
            ExpressionErrorText = mySharedDefaultExpressionError;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt, ob bei der Formatierung die Tausendergruppierung berücksichtigt werden soll.", "Gets or sets, wether digits before the decimal seperator should be grouped.")]
        public string ValueTooHighErrorText
        {
            get
            {
                return myValueTooHighError;
            }

            set
            {
                string Value = value;
                myValueTooHighError = Value;
            }
        }

        public bool ShouldSerializeValueTooHighErrorText()
        {
            return !((ValueTooHighErrorText == mySharedDefaultTooHighError));
        }

        public void ResetValueTooHighErrorText()
        {
            ValueTooHighErrorText = mySharedDefaultTooHighError;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt, ob bei der Formatierung die Tausendergruppierung berücksichtigt werden soll.", "Gets or sets, wether digits before the decimal seperator should be grouped.")]
        public string ValueTooLowErrorText
        {
            get
            {
                return myValueTooLowError;
            }

            set
            {
                string Value = value;
                myValueTooLowError = Value;
            }
        }

        public bool ShouldSerializeValueTooLowErrorText()
        {
            return !((ValueTooLowErrorText == mySharedDefaultTooLowError));
        }

        public void ResetValueTooLowErrorText()
        {
            ValueTooLowErrorText = mySharedDefaultTooLowError;
        }

        protected override object ToObjectForEditing(IADDBNullableValue Value)
        {
            if (!(Value.HasValue))
            {
                return "";
            }

            return string.Format("{0:" + AssignFormatString + "}", Value.Value);
        }

        protected override object ToObjectForDisplaying(IADDBNullableValue Value, bool ForSetValue)
        {
            if (!(Value.HasValue))
            {
                return NullString;
            }
            else
            {
                return string.Format("{0:" + DisplayFormatString + "}", Value.Value);
            }
        }

        protected override ADDBNullable<int> ToNullableValue(object Object)
        {
            if (Object.ToString() == "" | Object == null)
            {
                return default(ActiveDev.ADDBNullable<int>);
            }

            ADFormularParser locFormParse = new ADFormularParser(Object.ToString());
            return System.Convert.ToInt32(locFormParse.Result);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            string locMessageString = null;
            try
            {
                myObjectForEditing = myValueControl.Value;
                myValue = ToNullableValue(myObjectForEditing);
            }
            catch (SyntaxErrorException synEx)
            {
                locMessageString = mySharedDefaultExpressionError;
            }
            catch (Exception ex)
            {
                if (FireExceptionOnFailedValidation)
                {
                    InvalidCastException up = new InvalidCastException("Die Eingabe konnte nicht in den Zieltyp umgewandelt werden.");
                    throw up;
                }
                else
                {
                    if (FailedValidationErrorMessage == null | FailedValidationErrorMessage == "")
                    {
                        locMessageString = mySharedFailedValidationErrorDefaultMessage;
                    }
                    else
                    {
                        locMessageString = FailedValidationErrorMessage;
                    }
                }
            }

            if (locMessageString != "")
            {
                //Auseinanderdröseln und als Messagebox ausgeben
                string[] locStringArray = locMessageString.Split(new char[] { '|' });
                try
                {
                    MessageBox.Show(locStringArray[1], locStringArray[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    CultureInfo locCi;
                    string locError;
                    locCi = CultureInfo.CurrentCulture;
                    if (locCi.Name.StartsWith("de"))
                    {
                        locError = "Eine vordefinierte Fehlermeldung sollte ausgegeben werden, allerdings entsprach der Fehlermeldungstext nicht dem korrekten Format. Möglicherweise fehlt das Pipe-Zeichen (|).";
                    }
                    else
                    {
                        locError = "A predefined error message was supposed to be shown, but the message format didn't match the correct format. Probebly the pipe sign (|) is missing.";
                    }

                    locError += System.Environment.NewLine + System.Environment.NewLine;
                    locError += "Error causing control: " + this.Name + System.Environment.NewLine;
                    locError += "Error caused while validating.";
                    SyntaxErrorException up = new SyntaxErrorException(locError);
                    throw up;
                }

                e.Cancel = true;
            }
        }
    }
}
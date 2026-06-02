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
using System.Xml.Linq;

namespace ActiveDev.Controls
{
    public class ADNullableDateTimeBox : ADNullableValueControlTemplate<DateTime>
    {
        protected bool myReturnNullOnEmptyString;
        protected ADUVDateTimeFormat myAssignFormat;
        protected ADUVDateTimeFormat myPreferredAssignFormat;
        protected string myAssignCustomFormatString;
        protected ADUVDateTimeFormat myDisplayFormat;
        protected ADUVDateTimeFormat myPreferredDisplayFormat;
        protected string myDisplayCustomFormatString;
        protected string[] myParseFormatStrings;
        protected string[] myPreferredParseFormatStrings;
        protected System.DateTime myReferenceDate;
        private static string[] mySharedTimeParseFormatStrings;
        private static string[] mySharedDateParseFormatStrings;
        private static string[] mySharedCombinedParseFormatStrings;
        private static string[] mySharedAssignFormatStrings;
        private static string[] mySharedDisplayFormatStrings;
        static ADNullableDateTimeBox()
        {
            CultureInfo locCi;
            locCi = CultureInfo.CurrentCulture;
            if (locCi.Name.StartsWith("de"))
            {
                //Deutsches Format
                mySharedCombinedParseFormatStrings = new string[]
                {
                    "ddM",
                    "ddMM",
                    "ddMMyy",
                    "ddMMyyyy",
                    "d.M.y",
                    "dd.M.y",
                    "d.MM.y",
                    "d.M.yy",
                    "dd.M.yy",
                    "dd.MM.yy",
                    "d.M.yyyy",
                    "dd.M.yyyy",
                    "d.MM.yyyy",
                    "dd.MM.yyyy",
                    "d,M,y",
                    "dd,M,y",
                    "d,MM,y",
                    "d,M,yy",
                    "dd,M,yy",
                    "dd,MM,yy",
                    "d,M,yyyy",
                    "dd,M,yyyy",
                    "d,MM,yyyy",
                    "dd,MM,yyyy",
                    "dddd, dd.MM.yyyy",
                    "dd.MM.yy HH:mm",
                    "dd.MM.yyyy HH:mm",
                    "ddMMyy HHmm",
                    "ddMMyyyy HHmm",
                    "dd.MM.yy HH:mm:ss",
                    "dd.MM.yyyy HH:mm:ss",
                    "HH",
                    "HHmm",
                    "HHmmss",
                    "H.m",
                    "H.mm",
                    "HH.m",
                    "HH.mm",
                    "HH.mm.ss",
                    "H:m",
                    "H:mm",
                    "HH:m",
                    "HH:mm",
                    "HH:mm:ss",
                    "H,m",
                    "H,mm",
                    "HH,m",
                    "HH,mm",
                    "HH,mm,ss"
                };
                mySharedDateParseFormatStrings = new string[]
                {
                    "ddM",
                    "ddMM",
                    "ddMMyy",
                    "ddMMyyyy",
                    "dddd, dd.MM.yyyy",
                    "d.M.y",
                    "dd.M.y",
                    "d.MM.y",
                    "d.M.yy",
                    "dd.M.yy",
                    "dd.MM.yy",
                    "d.M.yyyy",
                    "dd.M.yyyy",
                    "d.MM.yyyy",
                    "dd.MM.yyyy",
                    "d,M,y",
                    "dd,M,y",
                    "d,MM,y",
                    "d,M,yy",
                    "dd,M,yy",
                    "dd,MM,yy",
                    "d,M,yyyy",
                    "dd,M,yyyy",
                    "d,MM,yyyy",
                    "dd,MM,yyyy"
                };
                mySharedTimeParseFormatStrings = new string[]
                {
                    "HH",
                    "HHmm",
                    "HHmmss",
                    "H.m",
                    "H.mm",
                    "HH.m",
                    "HH.mm",
                    "HH.mm.ss",
                    "H:m",
                    "H:mm",
                    "HH:m",
                    "HH:mm",
                    "HH:mm:ss",
                    "H,m",
                    "H,mm",
                    "HH,m",
                    "HH,mm",
                    "HH,mm,ss"
                };
                mySharedDisplayFormatStrings = new string[]
                {
                    "HH:mm",
                    "HH:mm:ss",
                    "dd.MM.yy",
                    "dddd, dd.MM.yyyy",
                    "dd.MM.yy - HH:mm",
                    "dddd, dd.MM.yyyy HH:mm:ss",
                    "dddd, \\der dd. MMM yyyy"
                };
                mySharedAssignFormatStrings = new string[]
                {
                    "HH:mm",
                    "HH:mm:ss",
                    "dd.MM.yy",
                    "dd.MM.yyyy",
                    "dd.MM.yy HH:mm",
                    "dd.MM.yyyy HH:mm:ss",
                    "dd.MM.yy HH:mm:ss"
                };
            }
        }

        public ADNullableDateTimeBox() : base()
        {
            ADDBNullable<DateTime> locNullable = new ADDBNullable<DateTime>();
            ConsiderFixedSize = true;
            NullString = "* --- *";
            Value = locNullable;
            myAssignFormat = ADUVDateTimeFormat.ShortDate;
            myDisplayFormat = ADUVDateTimeFormat.LongDate;
            myPreferredAssignFormat = myAssignFormat;
            myPreferredDisplayFormat = myDisplayFormat;
            myAssignCustomFormatString = "";
            myDisplayCustomFormatString = "";
            myParseFormatStrings = null;
            myReferenceDate = DateTime.Now.Date;
        }

        protected override void CreateControls()
        {
            this.EditableValueControl = new ADEditableValueForNullableValueControl();
            this.CaptionControl = new ADCaptionForNullableValueControl();
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt das Format des Datumswertes bei der Zuweisung durch die Value-Eigenschaft.", "Sets or gets the format of the date value which results out of the value property assignment.")]
        public ADUVDateTimeFormat AssignFormat
        {
            get
            {
                return myAssignFormat;
            }

            set
            {
                ADUVDateTimeFormat Value = value;
                myAssignFormat = Value;
            }
        }

        public bool ShouldSerializeAssignFormat()
        {
            return !((AssignFormat == ADUVDateTimeFormat.ShortDate));
        }

        public void ResetAssignFormat()
        {
            AssignFormat = ADUVDateTimeFormat.ShortDate;
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Ermittelt den AssignFormatString.", "Gets the AssignFormatString.")]
        public string AssignFormatString
        {
            get
            {
                if (AssignFormat == ADUVDateTimeFormat.Custom)
                {
                    return AssignCustomFormatString;
                }
                else
                {
                    return mySharedAssignFormatStrings[(int)(AssignFormat)];
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt den benutzerdefinierten AssignFormatString, der verwendet wird, wenn für AssignFormat 'Custom' eingestellt wurde.", "Gets or sets the custom AssignFormatString, which is used, when AssignFormat has been set to 'Custom'.")]
        public string AssignCustomFormatString
        {
            get
            {
                return myAssignCustomFormatString;
            }

            set
            {
                string Value = value;
                if ((Value == "") | (Value == null))
                {
                    AssignFormat = myPreferredAssignFormat;
                    Value = "";
                }
                else
                {
                    myPreferredAssignFormat = AssignFormat;
                    AssignFormat = ADUVDateTimeFormat.Custom;
                }

                myAssignCustomFormatString = Value;
            }
        }

        public bool ShouldSerializeAssignCustomFormatString()
        {
            return !((AssignCustomFormatString == ""));
        }

        public void ResetAssignCustomFormatString()
        {
            AssignCustomFormatString = "";
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt das Format, in dem der Datumswert formatiert wird, wenn das Steuerelement den Fokus verliert.", "Gets or sets the format, with which the value is formatted, when the control looses its focus.")]
        public ADUVDateTimeFormat DisplayFormat
        {
            get
            {
                return myDisplayFormat;
            }

            set
            {
                ADUVDateTimeFormat Value = value;
                myDisplayFormat = Value;
            }
        }

        public bool ShouldSerializeDisplayFormat()
        {
            return !((DisplayFormat == ADUVDateTimeFormat.LongDate));
        }

        public void ResetDisplayFormat()
        {
            DisplayFormat = ADUVDateTimeFormat.LongDate;
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Ermittelt den DisplayFormatString.", "Gets the DisplayFormatString.")]
        public string DisplayFormatString
        {
            get
            {
                if (DisplayFormat == ADUVDateTimeFormat.Custom)
                {
                    return DisplayCustomFormatString;
                }
                else
                {
                    return mySharedDisplayFormatStrings[(int)(DisplayFormat)];
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Verhalten")]
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
                    DisplayFormat = ADUVDateTimeFormat.Custom;
                }

                myDisplayCustomFormatString = Value;
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Sonstiges")]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DateTimeValue
        {
            get
            {
                return this.Value.Value;
            }

            set
            {
                object Value = value;
                this.Value = ADDBNullable.FromObject<DateTime>(Value);
            }
        }

        public bool ShouldSerializeDisplayCustomFormatString()
        {
            return !((DisplayCustomFormatString == ""));
        }

        public void ResetDisplayCustomFormatString()
        {
            DisplayCustomFormatString = "";
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime ReferenceDate
        {
            get
            {
                return myReferenceDate;
            }

            set
            {
                myReferenceDate = value.Date;
            }
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt ein Array aus Strings, das die Formate festlegt, die beim Parsen und Konvertieren des eingegebenen Texts in den gewünschten Datums-/Zeittyp berücksichtigt werden.", "Sets or gets an array of strings, which determines the formats that are being used for parsing and converting the input string into the desired date/time type.")]
        public string[] ParseFormatStrings
        {
            get
            {
                if (myParseFormatStrings == null)
                {
                    if (DateTimeType == ADDateTimeType.DateOnly)
                    {
                        return mySharedDateParseFormatStrings;
                    }
                    else if (DateTimeType == ADDateTimeType.TimeOnly)
                    {
                        return mySharedTimeParseFormatStrings;
                    }
                    else
                    {
                        return mySharedCombinedParseFormatStrings;
                    }
                }
                else
                {
                    return myParseFormatStrings;
                }
            }

            set
            {
                string[] Value = value;
                myParseFormatStrings = Value;
            }
        }

        public bool ShouldSerializeParseFormatStrings()
        {
            return !((myParseFormatStrings == null));
        }

        public void ResetParseFormatStrings()
        {
            myParseFormatStrings = null;
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Spiegelt den DateTimeType wieder, der sich durch AssignFormat ergibt. Nur lesen.", "Reflects the DateTimeType, which is determined through AssignFormat. Read only.")]
        public ADDateTimeType DateTimeType
        {
            get
            {
                {
                    var __select0 = (int)(AssignFormat);
                    if (__select0 == (int)(ADUVDateTimeFormat.CombinedLong) || __select0 == (int)(ADUVDateTimeFormat.CombinedShort) || __select0 == (int)(ADUVDateTimeFormat.Custom))
                    {
                        return ADDateTimeType.BothTimeAndDate;
                    }
                    else if (__select0 == (int)(ADUVDateTimeFormat.LongDate) || __select0 == (int)(ADUVDateTimeFormat.ShortDate))
                    {
                        return ADDateTimeType.DateOnly;
                    }
                    else if (__select0 == (int)(ADUVDateTimeFormat.LongTime) || __select0 == (int)(ADUVDateTimeFormat.ShortTime))
                    {
                        return ADDateTimeType.TimeOnly;
                    }
                }

                return default(ADDateTimeType);
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

        protected override object ToObjectForEditing(IADDBNullableValue Value)
        {
            if (!(Value.HasValue))
            {
                myReferenceDate = System.DateTime.Now.Date;
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

        protected override ADDBNullable<DateTime> ToNullableValue(object Object)
        {
            if (Object.ToString() == "")
            {
                return default(ActiveDev.ADDBNullable<System.DateTime>);
            }

            ADDBNullable<DateTime> locDate;
            locDate = new ADDBNullable<DateTime>(DateTime.ParseExact(Object.ToString(), ParseFormatStrings, new DateTimeFormatInfo(), DateTimeStyles.AllowWhiteSpaces));
            if (DisplayFormat == ADUVDateTimeFormat.LongTime | DisplayFormat == ADUVDateTimeFormat.ShortTime)
            {
                if (locDate.HasValue)
                {
                    locDate = ReferenceDate.Add(locDate.TypedValue.TimeOfDay);
                }
            }

            return locDate;
        }

        protected override void UpdateValue(IADDBNullableValue Value)
        {
            base.UpdateValue(Value);
            if (DisplayFormat == ADUVDateTimeFormat.LongTime | DisplayFormat == ADUVDateTimeFormat.ShortTime)
            {
                if (Value.HasValue)
                {
                    myReferenceDate = ((ADDBNullable<System.DateTime>)Value).TypedValue.Date;
                }
            }
        }
    }

    public enum ADDateTimeType
    {
        DateOnly,
        TimeOnly,
        BothTimeAndDate,
    }

    public enum ADUVDateTimeFormat
    {
        ShortTime = 0,
        LongTime = 1,
        ShortDate = 2,
        LongDate = 3,
        CombinedShort = 4,
        CombinedLong = 5,
        Custom = 6,
    }
}
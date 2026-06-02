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
    public class ADDescriptionAttribute : DescriptionAttribute
    {
        private string myDescriptionGerman;
        private string myDescriptionEnglish;
        public ADDescriptionAttribute() : base()
        {
        }

        public ADDescriptionAttribute(string description) : base()
        {
            myDescriptionGerman = description;
            myDescriptionEnglish = description;
        }

        public ADDescriptionAttribute(string descriptionGerman, string descriptionEnglish) : base()
        {
            myDescriptionGerman = descriptionGerman;
            myDescriptionEnglish = descriptionEnglish;
        }

        public override string Description
        {
            get
            {
                if (CultureInfo.CurrentCulture.Name.StartsWith("de"))
                {
                    return myDescriptionGerman;
                }
                else
                {
                    return myDescriptionEnglish;
                }
            }
        }
    }

    public class ADCategoryAttribute : CategoryAttribute
    {
        private string myCategoryGerman;
        private string myCategoryEnglish;
        public ADCategoryAttribute() : base()
        {
        }

        public ADCategoryAttribute(string category) : base()
        {
            myCategoryGerman = category;
            myCategoryEnglish = category;
        }

        public ADCategoryAttribute(string categoryGerman, string categoryEnglish) : base()
        {
            myCategoryGerman = categoryGerman;
            myCategoryEnglish = categoryEnglish;
        }

        protected override string GetLocalizedString(string value)
        {
            if (CultureInfo.CurrentCulture.Name.StartsWith("de"))
            {
                return myCategoryGerman;
            }
            else
            {
                return myCategoryEnglish;
            }
        }
    }

    //Localizable Exceptions
    public class ADArgumentException : ArgumentException
    {
        private string myMessage;
        public ADArgumentException(string GermanMessage, string EnglishMessage, string Parameter) : base(EnglishMessage, Parameter)
        {
            if (CultureInfo.CurrentCulture.Name.StartsWith("de"))
            {
                myMessage = GermanMessage;
            }
            else
            {
                myMessage = EnglishMessage;
            }
        }

        public override string Message
        {
            get
            {
                return myMessage;
            }
        }
    }

    public class ADTypeMismatchException : ArithmeticException
    {
        private string myMessage;
        public ADTypeMismatchException(string GermanMessage, string EnglishMessage) : base(EnglishMessage)
        {
            if (CultureInfo.CurrentCulture.Name.StartsWith("de"))
            {
                myMessage = GermanMessage;
            }
            else
            {
                myMessage = EnglishMessage;
            }
        }

        public override string Message
        {
            get
            {
                return myMessage;
            }
        }
    }
}
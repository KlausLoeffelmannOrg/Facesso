using ActiveDev;
using Facesso.Data;
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

namespace Facesso.Functions
{
    internal class frmAddressDetailsInfoAddEditView : Facesso.Functions.frmInfoItemAddEditViewBase
    {
        public frmAddressDetailsInfoAddEditView() : base()
        {
            //This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        //Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!((components == null)))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        internal ActiveDev.Controls.ADNullableTextBox ntbMiddleName;
        internal ActiveDev.Controls.ADNullableTextBox ntbURL;
        internal ActiveDev.Controls.ADNullableTextBox ntbPrivateEmail;
        internal ActiveDev.Controls.ADNullableTextBox ntbPrivateMobile;
        internal ActiveDev.Controls.ADNullableTextBox ntbPrivatePhone;
        internal ActiveDev.Controls.ADNullableTextBox ntbCompanyEmail;
        internal ActiveDev.Controls.ADNullableTextBox ntbCompanyMobile;
        internal ActiveDev.Controls.ADNullableTextBox ntbCompanyPhone;
        internal ActiveDev.Controls.ADNullableTextBox ntbCountry;
        internal ActiveDev.Controls.ADNullableTextBox ntbCountryCode;
        internal ActiveDev.Controls.ADNullableTextBox ntbCity;
        internal ActiveDev.Controls.ADNullableTextBox ntbZip;
        internal ActiveDev.Controls.ADNullableTextBox ntbStreet;
        internal ActiveDev.Controls.ADNullableTextBox ntbTitel;
        internal ActiveDev.Controls.ADNullableTextBox ntbFirstName;
        internal ActiveDev.Controls.ADNullableTextBox ntbLastName;
        internal ActiveDev.Controls.ADNullableIntBox nibPersonnelNo;
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.ntbMiddleName = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbURL = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbPrivateEmail = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbPrivateMobile = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbPrivatePhone = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbCompanyEmail = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbCompanyMobile = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbCompanyPhone = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbCountry = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbCountryCode = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbCity = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbZip = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbStreet = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbTitel = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbFirstName = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbLastName = new ActiveDev.Controls.ADNullableTextBox();
            this.nibPersonnelNo = new ActiveDev.Controls.ADNullableIntBox();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(569, 13);
            this.btnOK.TabIndex = 17;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(569, 58);
            this.btnCancel.TabIndex = 18;
            //
            //ntbMiddleName
            //
            this.ntbMiddleName.BackColor = System.Drawing.SystemColors.Window;
            this.ntbMiddleName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbMiddleName.CaptionToValueRatio = 343.75;
            this.ntbMiddleName.ColorOnFocus = true;
            this.ntbMiddleName.FailedValidationErrorMessage = null;
            this.ntbMiddleName.HasCaption = true;
            this.ntbMiddleName.IndependentDatafieldName = "MiddleName";
            this.ntbMiddleName.Location = new System.Drawing.Point(13, 137);
            this.ntbMiddleName.Margin = new System.Windows.Forms.Padding(4);
            this.ntbMiddleName.MaxLength = 100;
            this.ntbMiddleName.Multiline = false;
            this.ntbMiddleName.Name = "ntbMiddleName";
            this.ntbMiddleName.NullString = "* --- *";
            this.ntbMiddleName.NullValueMessage = null;
            this.ntbMiddleName.Size = new System.Drawing.Size(544, 23);
            this.ntbMiddleName.TabIndex = 4;
            this.ntbMiddleName.Text = "Zweiter Vor-/Zusatzname:";
            this.ntbMiddleName.ValueAreaLength = 357;
            //
            //ntbURL
            //
            this.ntbURL.BackColor = System.Drawing.SystemColors.Window;
            this.ntbURL.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbURL.CaptionToValueRatio = 343.75;
            this.ntbURL.ColorOnFocus = true;
            this.ntbURL.FailedValidationErrorMessage = null;
            this.ntbURL.HasCaption = true;
            this.ntbURL.IndependentDatafieldName = "URL";
            this.ntbURL.Location = new System.Drawing.Point(13, 489);
            this.ntbURL.Margin = new System.Windows.Forms.Padding(4);
            this.ntbURL.MaxLength = 255;
            this.ntbURL.Multiline = false;
            this.ntbURL.Name = "ntbURL";
            this.ntbURL.NullString = "* --- *";
            this.ntbURL.NullValueMessage = null;
            this.ntbURL.Size = new System.Drawing.Size(544, 23);
            this.ntbURL.TabIndex = 16;
            this.ntbURL.Text = "URL: ";
            this.ntbURL.ValueAreaLength = 357;
            //
            //ntbPrivateEmail
            //
            this.ntbPrivateEmail.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPrivateEmail.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbPrivateEmail.CaptionToValueRatio = 343.75;
            this.ntbPrivateEmail.ColorOnFocus = true;
            this.ntbPrivateEmail.FailedValidationErrorMessage = null;
            this.ntbPrivateEmail.HasCaption = true;
            this.ntbPrivateEmail.IndependentDatafieldName = "PrivateEmail";
            this.ntbPrivateEmail.Location = new System.Drawing.Point(13, 458);
            this.ntbPrivateEmail.Margin = new System.Windows.Forms.Padding(4);
            this.ntbPrivateEmail.MaxLength = 255;
            this.ntbPrivateEmail.Multiline = false;
            this.ntbPrivateEmail.Name = "ntbPrivateEmail";
            this.ntbPrivateEmail.NullString = "* --- *";
            this.ntbPrivateEmail.NullValueMessage = null;
            this.ntbPrivateEmail.Size = new System.Drawing.Size(544, 23);
            this.ntbPrivateEmail.TabIndex = 15;
            this.ntbPrivateEmail.Text = "Private E-Mail: ";
            this.ntbPrivateEmail.ValueAreaLength = 357;
            //
            //ntbPrivateMobile
            //
            this.ntbPrivateMobile.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPrivateMobile.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbPrivateMobile.CaptionToValueRatio = 343.75;
            this.ntbPrivateMobile.ColorOnFocus = true;
            this.ntbPrivateMobile.FailedValidationErrorMessage = null;
            this.ntbPrivateMobile.HasCaption = true;
            this.ntbPrivateMobile.IndependentDatafieldName = "PrivateMobile";
            this.ntbPrivateMobile.Location = new System.Drawing.Point(13, 427);
            this.ntbPrivateMobile.Margin = new System.Windows.Forms.Padding(4);
            this.ntbPrivateMobile.MaxLength = 100;
            this.ntbPrivateMobile.Multiline = false;
            this.ntbPrivateMobile.Name = "ntbPrivateMobile";
            this.ntbPrivateMobile.NullString = "* --- *";
            this.ntbPrivateMobile.NullValueMessage = null;
            this.ntbPrivateMobile.Size = new System.Drawing.Size(544, 23);
            this.ntbPrivateMobile.TabIndex = 14;
            this.ntbPrivateMobile.Text = "Privat-Mobiltelefon: ";
            this.ntbPrivateMobile.ValueAreaLength = 357;
            //
            //ntbPrivatePhone
            //
            this.ntbPrivatePhone.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPrivatePhone.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbPrivatePhone.CaptionToValueRatio = 343.75;
            this.ntbPrivatePhone.ColorOnFocus = true;
            this.ntbPrivatePhone.FailedValidationErrorMessage = null;
            this.ntbPrivatePhone.HasCaption = true;
            this.ntbPrivatePhone.IndependentDatafieldName = "PrivatePhone";
            this.ntbPrivatePhone.Location = new System.Drawing.Point(13, 396);
            this.ntbPrivatePhone.Margin = new System.Windows.Forms.Padding(4);
            this.ntbPrivatePhone.MaxLength = 100;
            this.ntbPrivatePhone.Multiline = false;
            this.ntbPrivatePhone.Name = "ntbPrivatePhone";
            this.ntbPrivatePhone.NullString = "* --- *";
            this.ntbPrivatePhone.NullValueMessage = null;
            this.ntbPrivatePhone.Size = new System.Drawing.Size(544, 23);
            this.ntbPrivatePhone.TabIndex = 13;
            this.ntbPrivatePhone.Text = "Privattelefon: ";
            this.ntbPrivatePhone.ValueAreaLength = 357;
            //
            //ntbCompanyEmail
            //
            this.ntbCompanyEmail.BackColor = System.Drawing.SystemColors.Window;
            this.ntbCompanyEmail.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbCompanyEmail.CaptionToValueRatio = 343.75;
            this.ntbCompanyEmail.ColorOnFocus = true;
            this.ntbCompanyEmail.FailedValidationErrorMessage = null;
            this.ntbCompanyEmail.HasCaption = true;
            this.ntbCompanyEmail.IndependentDatafieldName = "CompanyEmail";
            this.ntbCompanyEmail.Location = new System.Drawing.Point(13, 350);
            this.ntbCompanyEmail.Margin = new System.Windows.Forms.Padding(4);
            this.ntbCompanyEmail.MaxLength = 255;
            this.ntbCompanyEmail.Multiline = false;
            this.ntbCompanyEmail.Name = "ntbCompanyEmail";
            this.ntbCompanyEmail.NullString = "* --- *";
            this.ntbCompanyEmail.NullValueMessage = null;
            this.ntbCompanyEmail.Size = new System.Drawing.Size(544, 23);
            this.ntbCompanyEmail.TabIndex = 12;
            this.ntbCompanyEmail.Text = "Firmen-E-Mail: ";
            this.ntbCompanyEmail.ValueAreaLength = 357;
            //
            //ntbCompanyMobile
            //
            this.ntbCompanyMobile.BackColor = System.Drawing.SystemColors.Window;
            this.ntbCompanyMobile.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbCompanyMobile.CaptionToValueRatio = 343.75;
            this.ntbCompanyMobile.ColorOnFocus = true;
            this.ntbCompanyMobile.FailedValidationErrorMessage = null;
            this.ntbCompanyMobile.HasCaption = true;
            this.ntbCompanyMobile.IndependentDatafieldName = "CompanyMobile";
            this.ntbCompanyMobile.Location = new System.Drawing.Point(13, 319);
            this.ntbCompanyMobile.Margin = new System.Windows.Forms.Padding(4);
            this.ntbCompanyMobile.MaxLength = 100;
            this.ntbCompanyMobile.Multiline = false;
            this.ntbCompanyMobile.Name = "ntbCompanyMobile";
            this.ntbCompanyMobile.NullString = "* --- *";
            this.ntbCompanyMobile.NullValueMessage = null;
            this.ntbCompanyMobile.Size = new System.Drawing.Size(544, 23);
            this.ntbCompanyMobile.TabIndex = 11;
            this.ntbCompanyMobile.Text = "Firmen-Mobiltelefon: ";
            this.ntbCompanyMobile.ValueAreaLength = 357;
            //
            //ntbCompanyPhone
            //
            this.ntbCompanyPhone.BackColor = System.Drawing.SystemColors.Window;
            this.ntbCompanyPhone.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbCompanyPhone.CaptionToValueRatio = 343.75;
            this.ntbCompanyPhone.ColorOnFocus = true;
            this.ntbCompanyPhone.FailedValidationErrorMessage = null;
            this.ntbCompanyPhone.HasCaption = true;
            this.ntbCompanyPhone.IndependentDatafieldName = "CompanyPhone";
            this.ntbCompanyPhone.Location = new System.Drawing.Point(13, 288);
            this.ntbCompanyPhone.Margin = new System.Windows.Forms.Padding(4);
            this.ntbCompanyPhone.MaxLength = 100;
            this.ntbCompanyPhone.Multiline = false;
            this.ntbCompanyPhone.Name = "ntbCompanyPhone";
            this.ntbCompanyPhone.NullString = "* --- *";
            this.ntbCompanyPhone.NullValueMessage = null;
            this.ntbCompanyPhone.Size = new System.Drawing.Size(544, 23);
            this.ntbCompanyPhone.TabIndex = 10;
            this.ntbCompanyPhone.Text = "Firmen-Telefon: ";
            this.ntbCompanyPhone.ValueAreaLength = 357;
            //
            //ntbCountry
            //
            this.ntbCountry.BackColor = System.Drawing.SystemColors.Window;
            this.ntbCountry.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbCountry.CaptionToValueRatio = 0;
            this.ntbCountry.ColorOnFocus = true;
            this.ntbCountry.FailedValidationErrorMessage = null;
            this.ntbCountry.HasCaption = false;
            this.ntbCountry.IndependentDatafieldName = "Country";
            this.ntbCountry.Location = new System.Drawing.Point(292, 243);
            this.ntbCountry.Margin = new System.Windows.Forms.Padding(4);
            this.ntbCountry.MaxLength = 100;
            this.ntbCountry.Multiline = false;
            this.ntbCountry.Name = "ntbCountry";
            this.ntbCountry.NullString = "* --- *";
            this.ntbCountry.NullValueMessage = null;
            this.ntbCountry.Size = new System.Drawing.Size(265, 23);
            this.ntbCountry.TabIndex = 9;
            this.ntbCountry.Text = "PLZ/Ort:";
            this.ntbCountry.ValueAreaLength = 265;
            //
            //ntbCountryCode
            //
            this.ntbCountryCode.BackColor = System.Drawing.SystemColors.Window;
            this.ntbCountryCode.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbCountryCode.CaptionToValueRatio = 703.01;
            this.ntbCountryCode.ColorOnFocus = true;
            this.ntbCountryCode.FailedValidationErrorMessage = null;
            this.ntbCountryCode.HasCaption = true;
            this.ntbCountryCode.IndependentDatafieldName = "CountryCode";
            this.ntbCountryCode.Location = new System.Drawing.Point(13, 243);
            this.ntbCountryCode.Margin = new System.Windows.Forms.Padding(4);
            this.ntbCountryCode.MaxLength = 10;
            this.ntbCountryCode.Multiline = false;
            this.ntbCountryCode.Name = "ntbCountryCode";
            this.ntbCountryCode.NullString = "* --- *";
            this.ntbCountryCode.NullValueMessage = null;
            this.ntbCountryCode.Size = new System.Drawing.Size(266, 23);
            this.ntbCountryCode.TabIndex = 8;
            this.ntbCountryCode.Text = "L�nderkennung/Land: ";
            this.ntbCountryCode.ValueAreaLength = 79;
            //
            //ntbCity
            //
            this.ntbCity.BackColor = System.Drawing.SystemColors.Window;
            this.ntbCity.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbCity.CaptionToValueRatio = 0;
            this.ntbCity.ColorOnFocus = true;
            this.ntbCity.FailedValidationErrorMessage = null;
            this.ntbCity.HasCaption = false;
            this.ntbCity.IndependentDatafieldName = "City";
            this.ntbCity.Location = new System.Drawing.Point(292, 212);
            this.ntbCity.Margin = new System.Windows.Forms.Padding(4);
            this.ntbCity.MaxLength = 100;
            this.ntbCity.Multiline = false;
            this.ntbCity.Name = "ntbCity";
            this.ntbCity.NullString = "* --- *";
            this.ntbCity.NullValueMessage = null;
            this.ntbCity.Size = new System.Drawing.Size(265, 23);
            this.ntbCity.TabIndex = 7;
            this.ntbCity.Text = "PLZ/Ort:";
            this.ntbCity.ValueAreaLength = 265;
            //
            //ntbZip
            //
            this.ntbZip.BackColor = System.Drawing.SystemColors.Window;
            this.ntbZip.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbZip.CaptionToValueRatio = 703.01;
            this.ntbZip.ColorOnFocus = true;
            this.ntbZip.FailedValidationErrorMessage = null;
            this.ntbZip.HasCaption = true;
            this.ntbZip.IndependentDatafieldName = "Zip";
            this.ntbZip.Location = new System.Drawing.Point(13, 212);
            this.ntbZip.Margin = new System.Windows.Forms.Padding(4);
            this.ntbZip.MaxLength = 10;
            this.ntbZip.Multiline = false;
            this.ntbZip.Name = "ntbZip";
            this.ntbZip.NullString = "* --- *";
            this.ntbZip.NullValueMessage = null;
            this.ntbZip.Size = new System.Drawing.Size(266, 23);
            this.ntbZip.TabIndex = 6;
            this.ntbZip.Text = "PLZ/Ort:";
            this.ntbZip.ValueAreaLength = 79;
            //
            //ntbStreet
            //
            this.ntbStreet.BackColor = System.Drawing.SystemColors.Window;
            this.ntbStreet.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbStreet.CaptionToValueRatio = 343.75;
            this.ntbStreet.ColorOnFocus = true;
            this.ntbStreet.FailedValidationErrorMessage = null;
            this.ntbStreet.HasCaption = true;
            this.ntbStreet.IndependentDatafieldName = "Street";
            this.ntbStreet.Location = new System.Drawing.Point(13, 181);
            this.ntbStreet.Margin = new System.Windows.Forms.Padding(4);
            this.ntbStreet.MaxLength = 100;
            this.ntbStreet.Multiline = false;
            this.ntbStreet.Name = "ntbStreet";
            this.ntbStreet.NullString = "* --- *";
            this.ntbStreet.NullValueMessage = null;
            this.ntbStreet.Size = new System.Drawing.Size(544, 23);
            this.ntbStreet.TabIndex = 5;
            this.ntbStreet.Text = "Stra�e: ";
            this.ntbStreet.ValueAreaLength = 357;
            //
            //ntbTitel
            //
            this.ntbTitel.BackColor = System.Drawing.SystemColors.Window;
            this.ntbTitel.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbTitel.CaptionToValueRatio = 343.75;
            this.ntbTitel.ColorOnFocus = true;
            this.ntbTitel.FailedValidationErrorMessage = null;
            this.ntbTitel.HasCaption = true;
            this.ntbTitel.IndependentDatafieldName = "Titel";
            this.ntbTitel.Location = new System.Drawing.Point(13, 44);
            this.ntbTitel.Margin = new System.Windows.Forms.Padding(4);
            this.ntbTitel.MaxLength = 100;
            this.ntbTitel.Multiline = false;
            this.ntbTitel.Name = "ntbTitel";
            this.ntbTitel.NullString = "* --- *";
            this.ntbTitel.NullValueMessage = null;
            this.ntbTitel.Size = new System.Drawing.Size(544, 23);
            this.ntbTitel.TabIndex = 1;
            this.ntbTitel.Text = "Titel: ";
            this.ntbTitel.ValueAreaLength = 357;
            //
            //ntbFirstName
            //
            this.ntbFirstName.BackColor = System.Drawing.SystemColors.Window;
            this.ntbFirstName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbFirstName.CaptionToValueRatio = 343.75;
            this.ntbFirstName.ColorOnFocus = true;
            this.ntbFirstName.FailedValidationErrorMessage = null;
            this.ntbFirstName.HasCaption = true;
            this.ntbFirstName.IndependentDatafieldName = "FirstName";
            this.ntbFirstName.Location = new System.Drawing.Point(13, 106);
            this.ntbFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.ntbFirstName.MaxLength = 100;
            this.ntbFirstName.Multiline = false;
            this.ntbFirstName.Name = "ntbFirstName";
            this.ntbFirstName.NullString = "* --- *";
            this.ntbFirstName.NullValueMessage = null;
            this.ntbFirstName.Size = new System.Drawing.Size(544, 23);
            this.ntbFirstName.TabIndex = 3;
            this.ntbFirstName.Text = "Vorname:";
            this.ntbFirstName.ValueAreaLength = 357;
            //
            //ntbLastName
            //
            this.ntbLastName.BackColor = System.Drawing.SystemColors.Window;
            this.ntbLastName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbLastName.CaptionToValueRatio = 343.75;
            this.ntbLastName.ColorOnFocus = true;
            this.ntbLastName.FailedValidationErrorMessage = null;
            this.ntbLastName.HasCaption = true;
            this.ntbLastName.IndependentDatafieldName = "LastName";
            this.ntbLastName.Location = new System.Drawing.Point(13, 75);
            this.ntbLastName.Margin = new System.Windows.Forms.Padding(4);
            this.ntbLastName.MaxLength = 100;
            this.ntbLastName.Multiline = false;
            this.ntbLastName.Name = "ntbLastName";
            this.ntbLastName.NullString = "* --- *";
            this.ntbLastName.NullValueMessage = null;
            this.ntbLastName.Size = new System.Drawing.Size(544, 23);
            this.ntbLastName.TabIndex = 2;
            this.ntbLastName.Text = "Nachname: ";
            this.ntbLastName.ValueAreaLength = 357;
            //
            //nibPersonnelNo
            //
            this.nibPersonnelNo.BackColor = System.Drawing.SystemColors.Window;
            this.nibPersonnelNo.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.nibPersonnelNo.CaptionToValueRatio = 343.75;
            this.nibPersonnelNo.ColorOnFocus = true;
            this.nibPersonnelNo.FailedValidationErrorMessage = null;
            this.nibPersonnelNo.FormularText = "";
            this.nibPersonnelNo.HasCaption = true;
            this.nibPersonnelNo.IndependentDatafieldName = "PersonnelNo";
            this.nibPersonnelNo.Location = new System.Drawing.Point(13, 14);
            this.nibPersonnelNo.MaxValue = 0;
            this.nibPersonnelNo.MinValue = 0;
            this.nibPersonnelNo.Name = "nibPersonnelNo";
            this.nibPersonnelNo.NullString = "* --- *";
            this.nibPersonnelNo.NullValueMessage = null;
            this.nibPersonnelNo.Size = new System.Drawing.Size(544, 23);
            this.nibPersonnelNo.TabIndex = 0;
            this.nibPersonnelNo.Text = "Personal-Nummer:";
            this.nibPersonnelNo.ValueAreaLength = 357;
            //
            //frmAddressDetailsInfoAddEditView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.ClientSize = new System.Drawing.Size(699, 530);
            this.Controls.Add(this.nibPersonnelNo);
            this.Controls.Add(this.ntbMiddleName);
            this.Controls.Add(this.ntbURL);
            this.Controls.Add(this.ntbPrivateEmail);
            this.Controls.Add(this.ntbPrivateMobile);
            this.Controls.Add(this.ntbPrivatePhone);
            this.Controls.Add(this.ntbCompanyEmail);
            this.Controls.Add(this.ntbCompanyMobile);
            this.Controls.Add(this.ntbCompanyPhone);
            this.Controls.Add(this.ntbCountry);
            this.Controls.Add(this.ntbCountryCode);
            this.Controls.Add(this.ntbCity);
            this.Controls.Add(this.ntbZip);
            this.Controls.Add(this.ntbStreet);
            this.Controls.Add(this.ntbTitel);
            this.Controls.Add(this.ntbFirstName);
            this.Controls.Add(this.ntbLastName);
            this.Name = "frmAddressDetailsInfoAddEditView";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.ntbLastName, 0);
            this.Controls.SetChildIndex(this.ntbFirstName, 0);
            this.Controls.SetChildIndex(this.ntbTitel, 0);
            this.Controls.SetChildIndex(this.ntbStreet, 0);
            this.Controls.SetChildIndex(this.ntbZip, 0);
            this.Controls.SetChildIndex(this.ntbCity, 0);
            this.Controls.SetChildIndex(this.ntbCountryCode, 0);
            this.Controls.SetChildIndex(this.ntbCountry, 0);
            this.Controls.SetChildIndex(this.ntbCompanyPhone, 0);
            this.Controls.SetChildIndex(this.ntbCompanyMobile, 0);
            this.Controls.SetChildIndex(this.ntbCompanyEmail, 0);
            this.Controls.SetChildIndex(this.ntbPrivatePhone, 0);
            this.Controls.SetChildIndex(this.ntbPrivateMobile, 0);
            this.Controls.SetChildIndex(this.ntbPrivateEmail, 0);
            this.Controls.SetChildIndex(this.ntbURL, 0);
            this.Controls.SetChildIndex(this.ntbMiddleName, 0);
            this.Controls.SetChildIndex(this.nibPersonnelNo, 0);
            this.ResumeLayout(false);
        }

        public void ForceToHaveLastNameAndFirstname()
        {
            ntbFirstName.NullValueMessage = Facesso.Functions.My.Resources.AddressDetails_FirstNameNullMessage;
            ntbLastName.NullValueMessage = Facesso.Functions.My.Resources.AddressDetails_LastNameNullMessage;
        }
    }
}
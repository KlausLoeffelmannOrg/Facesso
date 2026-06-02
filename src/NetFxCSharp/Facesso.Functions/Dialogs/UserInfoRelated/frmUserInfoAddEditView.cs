using ActiveDev;
using ActiveDev.Controls;
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public class frmUserInfoAddEditView : Facesso.Functions.frmInfoItemAddEditViewBase
    {
        public frmUserInfoAddEditView() : base()
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

        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtPasswordRepetition;
        internal System.Windows.Forms.TextBox txtPassword;

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblRoles;
        internal Facesso.GenericControls.ucClearanceLevelCheckListBox clbClearanceLevel;

        internal System.Windows.Forms.Button btnAddressDetails;

        internal ActiveDev.Controls.ADNullableTextBox ntbComment;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbExpireDate;
        internal ActiveDev.Controls.ADNullableCheckBox ncbIsActivated;
        internal ActiveDev.Controls.ADNullableTextBox ntbFirstname;
        internal ActiveDev.Controls.ADNullableTextBox ntbLastName;
        internal ActiveDev.Controls.ADNullableTextBox ntbUsername;
        internal ActiveDev.Controls.ADNullableCheckBox ncbHasInternetAccess;
        internal ActiveDev.Controls.ADNullableCheckBox ncbHasWorkstationAccess;
        internal ActiveDev.Controls.ADNullableIdOrIndexComboBox ncombCostCenter;
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPasswordRepetition = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPassword.TextChanged += txtPassword_TextChanged;
            this.Label2 = new System.Windows.Forms.Label();
            this.lblRoles = new System.Windows.Forms.Label();
            this.clbClearanceLevel = new Facesso.GenericControls.ucClearanceLevelCheckListBox();
            this.clbClearanceLevel.ValueChanged += clbClearanceLevel_ValueChanged;
            this.btnAddressDetails = new System.Windows.Forms.Button();
            this.btnAddressDetails.Click += btnAddressDetails_Click;
            this.ntbComment = new ActiveDev.Controls.ADNullableTextBox();
            this.ndbExpireDate = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.ncbIsActivated = new ActiveDev.Controls.ADNullableCheckBox();
            this.ntbFirstname = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbLastName = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbUsername = new ActiveDev.Controls.ADNullableTextBox();
            this.ncbHasInternetAccess = new ActiveDev.Controls.ADNullableCheckBox();
            this.ncbHasWorkstationAccess = new ActiveDev.Controls.ADNullableCheckBox();
            this.ncombCostCenter = new ActiveDev.Controls.ADNullableIdOrIndexComboBox();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(527, 13);
            this.btnOK.TabIndex = 14;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(527, 58);
            this.btnCancel.TabIndex = 15;
            //
            //Label3
            //
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(244, 161);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(201, 16);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Passwort/Passwortwiederholung:";
            //
            //txtPasswordRepetition
            //
            this.txtPasswordRepetition.Location = new System.Drawing.Point(245, 209);
            this.txtPasswordRepetition.MaxLength = 64;
            this.txtPasswordRepetition.Name = "txtPasswordRepetition";
            this.txtPasswordRepetition.PasswordChar = Microsoft.VisualBasic.Strings.ChrW(42);
            this.txtPasswordRepetition.Size = new System.Drawing.Size(253, 22);
            this.txtPasswordRepetition.TabIndex = 5;
            //
            //txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(245, 180);
            this.txtPassword.MaxLength = 64;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = Microsoft.VisualBasic.Strings.ChrW(42);
            this.txtPassword.Size = new System.Drawing.Size(253, 22);
            this.txtPassword.TabIndex = 4;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(17, 287);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(78, 16);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Kontorechte:";
            //
            //lblRoles
            //
            this.lblRoles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRoles.Location = new System.Drawing.Point(15, 307);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(212, 98);
            this.lblRoles.TabIndex = 17;
            //
            //clbClearanceLevel
            //
            this.clbClearanceLevel.CheckOnClick = true;
            this.clbClearanceLevel.DeselectCombinedFlagsItemBehaviour = Facesso.GenericControls.CombinedFlagsSelectionBehaviour.IgnoreSingleFlag;
            this.clbClearanceLevel.FormattingEnabled = true;
            this.clbClearanceLevel.IndependentDatafieldName = "ClearanceLevel";
            this.clbClearanceLevel.Location = new System.Drawing.Point(245, 287);
            this.clbClearanceLevel.Margin = new System.Windows.Forms.Padding(6);
            this.clbClearanceLevel.Name = "clbClearanceLevel";
            this.clbClearanceLevel.NullValueMessage = null;
            this.clbClearanceLevel.SelectCombinedFlagsItemBehaviour = Facesso.GenericControls.CombinedFlagsSelectionBehaviour.SelectSingelFlag;
            this.clbClearanceLevel.Size = new System.Drawing.Size(254, 118);
            this.clbClearanceLevel.TabIndex = 11;
            //
            //btnAddressDetails
            //
            this.btnAddressDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnAddressDetails.Location = new System.Drawing.Point(527, 152);
            this.btnAddressDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddressDetails.Name = "btnAddressDetails";
            this.btnAddressDetails.Size = new System.Drawing.Size(117, 35);
            this.btnAddressDetails.TabIndex = 13;
            this.btnAddressDetails.Text = "Adressdetails...";
            //
            //ntbComment
            //
            this.ntbComment.BackColor = System.Drawing.SystemColors.Window;
            this.ntbComment.CaptionBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ntbComment.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.Above;
            this.ntbComment.CaptionToValueRatio = 1000;
            this.ntbComment.ColorOnFocus = true;
            this.ntbComment.FailedValidationErrorMessage = null;
            this.ntbComment.HasCaption = true;
            this.ntbComment.IndependentDatafieldName = "Comment";
            this.ntbComment.Location = new System.Drawing.Point(14, 417);
            this.ntbComment.Margin = new System.Windows.Forms.Padding(6);
            this.ntbComment.Multiline = true;
            this.ntbComment.Name = "ntbComment";
            this.ntbComment.NullString = "";
            this.ntbComment.NullValueMessage = null;
            this.ntbComment.Size = new System.Drawing.Size(484, 122);
            this.ntbComment.TabIndex = 12;
            this.ntbComment.Text = "Kommentar:";
            this.ntbComment.ValueAreaLength = 484;
            //
            //ndbExpireDate
            //
            this.ndbExpireDate.BackColor = System.Drawing.SystemColors.Window;
            this.ndbExpireDate.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ndbExpireDate.CaptionToValueRatio = 349.17;
            this.ndbExpireDate.ColorOnFocus = true;
            this.ndbExpireDate.FailedValidationErrorMessage = "Falsches Datumsformat|Bitte geben Sie in dieses Feld entweder gar nichts oder ein" + "en g�ltigen Datumswert ein!";
            this.ndbExpireDate.HasCaption = true;
            this.ndbExpireDate.IndependentDatafieldName = "";
            this.ndbExpireDate.Location = new System.Drawing.Point(15, 249);
            this.ndbExpireDate.Margin = new System.Windows.Forms.Padding(6);
            this.ndbExpireDate.Name = "ndbExpireDate";
            this.ndbExpireDate.NullString = "* Konto l�uft nie ab *";
            this.ndbExpireDate.NullValueMessage = null;
            this.ndbExpireDate.Size = new System.Drawing.Size(484, 23);
            this.ndbExpireDate.TabIndex = 9;
            this.ndbExpireDate.Text = "Kontoablaufdatum:";
            this.ndbExpireDate.ValueAreaLength = 315;
            //
            //ncbIsActivated
            //
            this.ncbIsActivated.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbIsActivated.CaptionToValueRatio = 801.89;
            this.ncbIsActivated.ColorOnFocus = true;
            this.ncbIsActivated.FailedValidationErrorMessage = null;
            this.ncbIsActivated.HasCaption = true;
            this.ncbIsActivated.IndependentDatafieldName = "IsActivated";
            this.ncbIsActivated.Location = new System.Drawing.Point(15, 218);
            this.ncbIsActivated.Margin = new System.Windows.Forms.Padding(6);
            this.ncbIsActivated.Name = "ncbIsActivated";
            this.ncbIsActivated.NullString = null;
            this.ncbIsActivated.NullValueMessage = "Bitte bestimmen Sie, ob das Konto aktiviert sein soll!";
            this.ncbIsActivated.Size = new System.Drawing.Size(212, 19);
            this.ncbIsActivated.TabIndex = 8;
            this.ncbIsActivated.Text = "Konto aktiviert:";
            this.ncbIsActivated.ValueAreaLength = 42;
            //
            //ntbFirstname
            //
            this.ntbFirstname.BackColor = System.Drawing.SystemColors.Window;
            this.ntbFirstname.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbFirstname.CaptionToValueRatio = 349.17;
            this.ntbFirstname.ColorOnFocus = true;
            this.ntbFirstname.FailedValidationErrorMessage = null;
            this.ntbFirstname.HasCaption = true;
            this.ntbFirstname.IndependentDatafieldName = "FirstName";
            this.ntbFirstname.Location = new System.Drawing.Point(15, 51);
            this.ntbFirstname.Margin = new System.Windows.Forms.Padding(6);
            this.ntbFirstname.Multiline = false;
            this.ntbFirstname.Name = "ntbFirstname";
            this.ntbFirstname.NullString = "* --- *";
            this.ntbFirstname.NullValueMessage = "Bitte bestimmen Sie den Vornamen";
            this.ntbFirstname.Size = new System.Drawing.Size(484, 23);
            this.ntbFirstname.TabIndex = 0;
            this.ntbFirstname.Text = "Vorname:";
            this.ntbFirstname.ValueAreaLength = 315;
            //
            //ntbLastName
            //
            this.ntbLastName.BackColor = System.Drawing.SystemColors.Window;
            this.ntbLastName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbLastName.CaptionToValueRatio = 349.17;
            this.ntbLastName.ColorOnFocus = true;
            this.ntbLastName.FailedValidationErrorMessage = null;
            this.ntbLastName.HasCaption = true;
            this.ntbLastName.IndependentDatafieldName = "LastName";
            this.ntbLastName.Location = new System.Drawing.Point(15, 86);
            this.ntbLastName.Margin = new System.Windows.Forms.Padding(6);
            this.ntbLastName.Multiline = false;
            this.ntbLastName.Name = "ntbLastName";
            this.ntbLastName.NullString = "* --- *";
            this.ntbLastName.NullValueMessage = "Bitte bestimmen Sie den Nachnamen des Benutzers!";
            this.ntbLastName.Size = new System.Drawing.Size(484, 23);
            this.ntbLastName.TabIndex = 1;
            this.ntbLastName.Text = "Nachname:";
            this.ntbLastName.ValueAreaLength = 315;
            //
            //ntbUsername
            //
            this.ntbUsername.BackColor = System.Drawing.SystemColors.Window;
            this.ntbUsername.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbUsername.CaptionToValueRatio = 349.17;
            this.ntbUsername.ColorOnFocus = true;
            this.ntbUsername.FailedValidationErrorMessage = null;
            this.ntbUsername.HasCaption = true;
            this.ntbUsername.IndependentDatafieldName = "Username";
            this.ntbUsername.Location = new System.Drawing.Point(15, 121);
            this.ntbUsername.Margin = new System.Windows.Forms.Padding(6);
            this.ntbUsername.Multiline = false;
            this.ntbUsername.Name = "ntbUsername";
            this.ntbUsername.NullString = "* --- *";
            this.ntbUsername.NullValueMessage = "Bitte geben Sie den Benutzernamen ein, mit dem sich der Benutzer sp�ter anmeldet!" + "";
            this.ntbUsername.Size = new System.Drawing.Size(484, 23);
            this.ntbUsername.TabIndex = 2;
            this.ntbUsername.Text = "Benutzername:";
            this.ntbUsername.ValueAreaLength = 315;
            //
            //ncbHasInternetAccess
            //
            this.ncbHasInternetAccess.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbHasInternetAccess.CaptionToValueRatio = 801.89;
            this.ncbHasInternetAccess.ColorOnFocus = true;
            this.ncbHasInternetAccess.FailedValidationErrorMessage = null;
            this.ncbHasInternetAccess.HasCaption = true;
            this.ncbHasInternetAccess.IndependentDatafieldName = "HasInternetAccess";
            this.ncbHasInternetAccess.Location = new System.Drawing.Point(15, 187);
            this.ncbHasInternetAccess.Margin = new System.Windows.Forms.Padding(6);
            this.ncbHasInternetAccess.Name = "ncbHasInternetAccess";
            this.ncbHasInternetAccess.NullString = null;
            this.ncbHasInternetAccess.NullValueMessage = "Bitte bestimmen Sie, ob der Benutzer Internet-Zugriff erhalten soll.";
            this.ncbHasInternetAccess.Size = new System.Drawing.Size(212, 19);
            this.ncbHasInternetAccess.TabIndex = 7;
            this.ncbHasInternetAccess.Text = "Inter-/Intranet-Zugriff:";
            this.ncbHasInternetAccess.ValueAreaLength = 42;
            //
            //ncbHasWorkstationAccess
            //
            this.ncbHasWorkstationAccess.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbHasWorkstationAccess.CaptionToValueRatio = 801.89;
            this.ncbHasWorkstationAccess.ColorOnFocus = true;
            this.ncbHasWorkstationAccess.FailedValidationErrorMessage = null;
            this.ncbHasWorkstationAccess.HasCaption = true;
            this.ncbHasWorkstationAccess.IndependentDatafieldName = "HasWorkstationAccess";
            this.ncbHasWorkstationAccess.Location = new System.Drawing.Point(15, 156);
            this.ncbHasWorkstationAccess.Margin = new System.Windows.Forms.Padding(6);
            this.ncbHasWorkstationAccess.Name = "ncbHasWorkstationAccess";
            this.ncbHasWorkstationAccess.NullString = null;
            this.ncbHasWorkstationAccess.NullValueMessage = "Bitte bestimmen Sie, ob der Benutzer Workstation-Zugriff erhalten soll!";
            this.ncbHasWorkstationAccess.Size = new System.Drawing.Size(212, 19);
            this.ncbHasWorkstationAccess.TabIndex = 6;
            this.ncbHasWorkstationAccess.Text = "Workstation-Zugriff:";
            this.ncbHasWorkstationAccess.ValueAreaLength = 42;
            //
            //ncombCostCenter
            //
            this.ncombCostCenter.BackColor = System.Drawing.SystemColors.Window;
            this.ncombCostCenter.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncombCostCenter.CaptionToValueRatio = 349.17;
            this.ncombCostCenter.ColorOnFocus = true;
            this.ncombCostCenter.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32;
            this.ncombCostCenter.DropDownHeight = 106;
            this.ncombCostCenter.DropDownWidth = 315;
            this.ncombCostCenter.FailedValidationErrorMessage = null;
            this.ncombCostCenter.HasCaption = true;
            this.ncombCostCenter.IndependentDatafieldName = "IDCostCenter";
            this.ncombCostCenter.Location = new System.Drawing.Point(15, 16);
            this.ncombCostCenter.MaxDropDownItems = 8;
            this.ncombCostCenter.Name = "ncombCostCenter";
            this.ncombCostCenter.NullString = null;
            this.ncombCostCenter.NullValueMessage = null;
            this.ncombCostCenter.Size = new System.Drawing.Size(484, 24);
            this.ncombCostCenter.TabIndex = 16;
            this.ncombCostCenter.Text = "Kostenstellen-Nummer: ";
            this.ncombCostCenter.ValueAreaLength = 315;
            //
            //frmUserInfoAddEditView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.ClientSize = new System.Drawing.Size(657, 558);
            this.Controls.Add(this.ncombCostCenter);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtPasswordRepetition);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.clbClearanceLevel);
            this.Controls.Add(this.btnAddressDetails);
            this.Controls.Add(this.ntbComment);
            this.Controls.Add(this.ndbExpireDate);
            this.Controls.Add(this.ncbIsActivated);
            this.Controls.Add(this.ntbFirstname);
            this.Controls.Add(this.ntbLastName);
            this.Controls.Add(this.ntbUsername);
            this.Controls.Add(this.ncbHasInternetAccess);
            this.Controls.Add(this.ncbHasWorkstationAccess);
            this.Name = "frmUserInfoAddEditView";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.ncbHasWorkstationAccess, 0);
            this.Controls.SetChildIndex(this.ncbHasInternetAccess, 0);
            this.Controls.SetChildIndex(this.ntbUsername, 0);
            this.Controls.SetChildIndex(this.ntbLastName, 0);
            this.Controls.SetChildIndex(this.ntbFirstname, 0);
            this.Controls.SetChildIndex(this.ncbIsActivated, 0);
            this.Controls.SetChildIndex(this.ndbExpireDate, 0);
            this.Controls.SetChildIndex(this.ntbComment, 0);
            this.Controls.SetChildIndex(this.btnAddressDetails, 0);
            this.Controls.SetChildIndex(this.clbClearanceLevel, 0);
            this.Controls.SetChildIndex(this.lblRoles, 0);
            this.Controls.SetChildIndex(this.Label2, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.txtPasswordRepetition, 0);
            this.Controls.SetChildIndex(this.Label3, 0);
            this.Controls.SetChildIndex(this.ncombCostCenter, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private AddressDetailsInfo myAddressDetails;
        private bool myPasswordChanged;
        //Wird aufgerufen bei "Neuer Datensatz"
        protected override void Fac_OnInitializeFormControls()
        {
            base.Fac_OnInitializeFormControls();
            Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncombCostCenter);
            this.ncbIsActivated.TypeSafeValue = true;
            this.ncbHasWorkstationAccess.TypeSafeValue = true;
            this.ncbHasInternetAccess.TypeSafeValue = false;
        }

        //Wird aufgerufen bei "Datensatz editieren"
        protected override void Fac_OnAssigningToControls(IInfoItem InfoItem)
        {
            Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncombCostCenter);
            base.Fac_OnAssigningToControls(InfoItem);
            if (((UserInfo)InfoItem).DoesExpire == true)
            {
                ndbExpireDate.TypeSafeValue = ((UserInfo)InfoItem).ExpireDate;
            }
            else
            {
                ndbExpireDate.TypeSafeValue = default(ActiveDev.ADDBNullable<System.DateTime>);
            }

            ADDBNullable<int> locIDAddressDetails = ((UserInfo)InfoItem).IDAddressDetails;
            if (!(locIDAddressDetails.IsNull))
            {
                if (Fac_EditMode == InfoItemFormEditMode.Edit)
                {
                    myAddressDetails = new AddressDetailsInfo();
                    SqlConnection locConn = SPAccess.GetInstance().GetOpenedConnectionSafely();
                    using (locConn)
                    {
                        SqlCommand locCommand = new SqlCommand("SELECT * FROM AddressDetails WHERE IDSubsidiary=" + FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary.ToString() + " AND [IDAddressDetail]=" + locIDAddressDetails.ToString(), locConn);
                        SqlDataReader locDR = locCommand.ExecuteReader();
                    }
                }
            }
        }

        public AddressDetailsInfo AddressDetails
        {
            get
            {
                return myAddressDetails;
            }

            set
            {
                myAddressDetails = value;
            }
        }

        //Wird aufgerufen zum �berpr�fen eines Datensatzes bei der Neueingabe
        protected override void Fac_OnValidatingNew(System.ComponentModel.CancelEventArgs e)
        {
            base.Fac_OnValidatingNew(e);
            if (e.Cancel)
            {
                return;
            }

            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob der Benutzername schon existiert
            if (locSPA.Users_DoesUsernameExist(FacessoGeneric.LoginInfo.IDSubsidiary, ntbUsername.TypeSafeValue, default(ActiveDev.ADDBNullable<int>)))
            {
                string locErr = Facesso.Functions.My.Resources.UserInfoAdd_UsernameAlreadyExist_MB_Body;
                locErr = string.Format(locErr, ntbUsername.TypeSafeValue, FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.UserInfoAdd_UsernameAlreadyExist_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }

            //Passwort �berpr�fen
            if (!(CheckPasswordConcurrency()))
            {
                e.Cancel = true;
            }
        }

        //Wird aufgerufen zum �berpr�fen eines Datensatzes beim Editieren
        protected override void Fac_OnValidatingEdit(InfoItemValidatingEventArgs e)
        {
            base.Fac_OnValidatingEdit(e);
            if (e.Cancel)
            {
                return;
            }

            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob der Benutzername schon existiert
            if (locSPA.Users_DoesUsernameExist(FacessoGeneric.LoginInfo.IDSubsidiary, ntbUsername.TypeSafeValue, ((UserInfo)e.InfoItem).IDUser))
            {
                string locErr = Facesso.Functions.My.Resources.UserInfoAdd_UsernameAlreadyExist_MB_Body;
                locErr = string.Format(locErr, ntbUsername.TypeSafeValue, FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.UserInfoAdd_UsernameAlreadyExist_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }

            //Passwort �berpr�fen
            if (!(CheckPasswordConcurrency()))
            {
                e.Cancel = true;
            }
        }

        protected override void Fac_OnAssigningToInfoItem(IInfoItem InfoItem)
        {
            base.Fac_OnAssigningToInfoItem(InfoItem);
            SPAccess locSPA = SPAccess.GetInstance();
            ((UserInfo)InfoItem).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
            //AddressDetails sind noch nicht erfasst -> Erzeugen und Vor- und Nachnamen eintragen!
            if (myAddressDetails == null)
            {
                myAddressDetails = new AddressDetailsInfo();
                myAddressDetails.FirstName = ntbFirstname.TypeSafeValue;
                myAddressDetails.LastName = ntbLastName.TypeSafeValue;
            }

            //Passwort-Hash erzeugen, wenn das Passwort ge�ndert wurde
            if (myPasswordChanged)
            {
                ((UserInfo)InfoItem).Password = new ADCryptedPassword(txtPassword.Text).CryptedPassword;
            }

            //Datums-Regelung
            if (ndbExpireDate.Value.IsNull)
            {
                ((UserInfo)InfoItem).ExpireDate = FacessoGeneric.OpenCurrentToDate;
                ((UserInfo)InfoItem).DoesExpire = false;
            }
            else
            {
                ((UserInfo)InfoItem).ExpireDate = ndbExpireDate.TypeSafeValue;
                ((UserInfo)InfoItem).DoesExpire = true;
            }

            if (Fac_EditMode == InfoItemFormEditMode.AddNew)
            {
                locSPA.Users_Add(((UserInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser, myAddressDetails);
            }
            else if (Fac_EditMode == InfoItemFormEditMode.Edit)
            {
                locSPA.Users_Edit(((UserInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser, myAddressDetails);
            }
        }

        private void btnAddressDetails_Click(System.Object sender, System.EventArgs e)
        {
            frmAddressDetailsInfoAddEditView frmAdrDetails = new frmAddressDetailsInfoAddEditView();
            //AddressDetails sind noch nicht erfasst -> Erzeugen und Vor- und Nachnamen eintragen!
            if (myAddressDetails == null)
            {
                myAddressDetails = new AddressDetailsInfo();
            }

            //Die m�ssen im Haupt- und Adresseninfo-Dialog identisch sein!
            myAddressDetails.FirstName = ntbFirstname.TypeSafeValue;
            myAddressDetails.LastName = ntbLastName.TypeSafeValue;
            InfoItemMaintenanceDialogResult locBack = default(InfoItemMaintenanceDialogResult);
            //F�r den Benutzereintrag d�rfen Vor- und Nachname nicht DBNull sein!
            frmAdrDetails.ForceToHaveLastNameAndFirstname();
            locBack = frmAdrDetails.Fac_HandleDialogAsEdit(Facesso.Functions.My.Resources.UserInfoAddOrEdit_AddressDetailsDialogTitle, myAddressDetails);
            if (locBack.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                myAddressDetails = ((AddressDetailsInfo)locBack.InfoItem);
                ntbFirstname.Value = myAddressDetails.FirstName;
                ntbLastName.Value = myAddressDetails.LastName;
            }
        }

        private bool CheckPasswordConcurrency()
        {
            if (Fac_EditMode == InfoItemFormEditMode.AddNew & txtPassword.Text == "")
            {
                MessageBox.Show(Facesso.Functions.My.Resources.UserInfoAddOrEdit_NoPassword_MB_Body, Facesso.Functions.My.Resources.UserInfoAddOrEdit_NoPassword_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (myPasswordChanged)
            {
                if (!((txtPassword.Text == txtPasswordRepetition.Text)))
                {
                    MessageBox.Show(Facesso.Functions.My.Resources.UserInfoAddOrEdit_PasswordRepetitionFailed_MB_Body, Facesso.Functions.My.Resources.UserInfoAddOrEdit_PasswordRepetitionFailed_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            return true;
        }

        private void txtPassword_TextChanged(System.Object sender, System.EventArgs e)
        {
            myPasswordChanged = true;
        }

        private void clbClearanceLevel_ValueChanged(System.Object sender, System.EventArgs e)
        {
            Debug.Print(clbClearanceLevel.Value.Value.ToString());
            lblRoles.Text = clbClearanceLevel.ToString();
        }
    }
}
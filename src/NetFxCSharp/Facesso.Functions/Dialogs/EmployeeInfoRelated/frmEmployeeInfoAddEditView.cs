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
    public class frmEmployeeInfoAddEditView : Facesso.Functions.frmInfoItemAddEditViewBase
    {
        private AddressDetailsInfo myAddressDetails;
        private System.Windows.Forms.Button _btnHandicapManager;
        internal System.Windows.Forms.Button btnHandicapManager
        {
            get
            {
                return _btnHandicapManager;
            }

            set
            {
                if (_btnHandicapManager != null)
                {
                    _btnHandicapManager.Click -= btnHandicapManager_Click;
                }

                _btnHandicapManager = value;
                if (_btnHandicapManager != null)
                {
                    _btnHandicapManager.Click += btnHandicapManager_Click;
                }
            }
        }

        private bool myDoNothing;
        private IInfoItem myCurrentInfoItem;
        public frmEmployeeInfoAddEditView() : base()
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

        private ActiveDev.Controls.ADNullableIdOrIndexComboBox _ncombCostCenter;
        internal ActiveDev.Controls.ADNullableIdOrIndexComboBox ncombCostCenter
        {
            get
            {
                return _ncombCostCenter;
            }

            set
            {
                if (_ncombCostCenter != null)
                {
                    _ncombCostCenter.ValueChanged -= ncombCostCenter_ValueChanged;
                }

                _ncombCostCenter = value;
                if (_ncombCostCenter != null)
                {
                    _ncombCostCenter.ValueChanged += ncombCostCenter_ValueChanged;
                }
            }
        }

        internal ActiveDev.Controls.ADNullableTextBox ntbFirstName;
        internal ActiveDev.Controls.ADNullableIntBox nibPersonnelNumber;
        internal ActiveDev.Controls.ADNullableTextBox ntbLastName;
        internal ActiveDev.Controls.ADNullableIdOrIndexComboBox ncbWageGroup;
        internal ActiveDev.Controls.ADNullableCheckBox ncbUseFixedWage;
        internal ActiveDev.Controls.ADNullableDoubleBox ndbFixedWage;
        internal ActiveDev.Controls.ADNullableCheckBox ncbIsIncentive;
        internal ActiveDev.Controls.ADNullableCheckBox ncbIsActive;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbDateOfBirth;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbDateOfJoining;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbDateOfSeparation;
        internal ActiveDev.Controls.ADNullableTextBox ntbTimeCardNo;
        private System.Windows.Forms.Button _btnAddressDetails;
        internal System.Windows.Forms.Button btnAddressDetails
        {
            get
            {
                return _btnAddressDetails;
            }

            set
            {
                if (_btnAddressDetails != null)
                {
                    _btnAddressDetails.Click -= btnAddressDetails_Click;
                }

                _btnAddressDetails = value;
                if (_btnAddressDetails != null)
                {
                    _btnAddressDetails.Click += btnAddressDetails_Click;
                }
            }
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.ncombCostCenter = new ActiveDev.Controls.ADNullableIdOrIndexComboBox();
            this.ntbFirstName = new ActiveDev.Controls.ADNullableTextBox();
            this.nibPersonnelNumber = new ActiveDev.Controls.ADNullableIntBox();
            this.ntbLastName = new ActiveDev.Controls.ADNullableTextBox();
            this.ncbWageGroup = new ActiveDev.Controls.ADNullableIdOrIndexComboBox();
            this.ncbUseFixedWage = new ActiveDev.Controls.ADNullableCheckBox();
            this.ndbFixedWage = new ActiveDev.Controls.ADNullableDoubleBox();
            this.ncbIsIncentive = new ActiveDev.Controls.ADNullableCheckBox();
            this.ncbIsActive = new ActiveDev.Controls.ADNullableCheckBox();
            this.ndbDateOfBirth = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.ndbDateOfJoining = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.ndbDateOfSeparation = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.ntbTimeCardNo = new ActiveDev.Controls.ADNullableTextBox();
            this.btnAddressDetails = new System.Windows.Forms.Button();
            this.btnHandicapManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(566, 13);
            this.btnOK.TabIndex = 13;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(566, 58);
            this.btnCancel.TabIndex = 14;
            //
            //ncombCostCenter
            //
            this.ncombCostCenter.BackColor = System.Drawing.SystemColors.Window;
            this.ncombCostCenter.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncombCostCenter.CaptionToValueRatio = 426.64;
            this.ncombCostCenter.ColorOnFocus = true;
            this.ncombCostCenter.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32;
            this.ncombCostCenter.DropDownHeight = 106;
            this.ncombCostCenter.DropDownWidth = 315;
            this.ncombCostCenter.FailedValidationErrorMessage = null;
            this.ncombCostCenter.HasCaption = true;
            this.ncombCostCenter.IndependentDatafieldName = "IDCostCenter";
            this.ncombCostCenter.Location = new System.Drawing.Point(12, 44);
            this.ncombCostCenter.MaxDropDownItems = 8;
            this.ncombCostCenter.Name = "ncombCostCenter";
            this.ncombCostCenter.NullString = null;
            this.ncombCostCenter.NullValueMessage = null;
            this.ncombCostCenter.Size = new System.Drawing.Size(518, 24);
            this.ncombCostCenter.TabIndex = 1;
            this.ncombCostCenter.Text = "Kostenstellen-Nummer: ";
            this.ncombCostCenter.ValueAreaLength = 297;
            //
            //ntbFirstName
            //
            this.ntbFirstName.BackColor = System.Drawing.SystemColors.Window;
            this.ntbFirstName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbFirstName.CaptionToValueRatio = 426.64;
            this.ntbFirstName.ColorOnFocus = true;
            this.ntbFirstName.FailedValidationErrorMessage = null;
            this.ntbFirstName.HasCaption = true;
            this.ntbFirstName.IndependentDatafieldName = "FirstName";
            this.ntbFirstName.Location = new System.Drawing.Point(12, 118);
            this.ntbFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.ntbFirstName.MaxLength = 100;
            this.ntbFirstName.Multiline = false;
            this.ntbFirstName.Name = "ntbFirstName";
            this.ntbFirstName.NullString = "* --- *";
            this.ntbFirstName.NullValueMessage = "Bitte geben Sie den Vornamen ein!";
            this.ntbFirstName.Size = new System.Drawing.Size(518, 22);
            this.ntbFirstName.TabIndex = 3;
            this.ntbFirstName.Text = "Vorname: ";
            this.ntbFirstName.ValueAreaLength = 297;
            //
            //nibPersonnelNumber
            //
            this.nibPersonnelNumber.BackColor = System.Drawing.SystemColors.Window;
            this.nibPersonnelNumber.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.nibPersonnelNumber.CaptionToValueRatio = 426.64;
            this.nibPersonnelNumber.ColorOnFocus = true;
            this.nibPersonnelNumber.FailedValidationErrorMessage = null;
            this.nibPersonnelNumber.FormularText = "";
            this.nibPersonnelNumber.HasCaption = true;
            this.nibPersonnelNumber.IndependentDatafieldName = "PersonnelNumber";
            this.nibPersonnelNumber.Location = new System.Drawing.Point(12, 13);
            this.nibPersonnelNumber.MaxValue = 0;
            this.nibPersonnelNumber.MinValue = 0;
            this.nibPersonnelNumber.Name = "nibPersonnelNumber";
            this.nibPersonnelNumber.NullString = "* --- *";
            this.nibPersonnelNumber.NullValueMessage = "Bitte bestimmen Sie die Personal-Nummer!";
            this.nibPersonnelNumber.Size = new System.Drawing.Size(518, 22);
            this.nibPersonnelNumber.TabIndex = 0;
            this.nibPersonnelNumber.Text = "Personal-Nr.:";
            this.nibPersonnelNumber.ValueAreaLength = 297;
            //
            //ntbLastName
            //
            this.ntbLastName.BackColor = System.Drawing.SystemColors.Window;
            this.ntbLastName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbLastName.CaptionToValueRatio = 426.64;
            this.ntbLastName.ColorOnFocus = true;
            this.ntbLastName.FailedValidationErrorMessage = null;
            this.ntbLastName.HasCaption = true;
            this.ntbLastName.IndependentDatafieldName = "LastName";
            this.ntbLastName.Location = new System.Drawing.Point(12, 87);
            this.ntbLastName.Margin = new System.Windows.Forms.Padding(4);
            this.ntbLastName.MaxLength = 100;
            this.ntbLastName.Multiline = false;
            this.ntbLastName.Name = "ntbLastName";
            this.ntbLastName.NullString = "* --- *";
            this.ntbLastName.NullValueMessage = "Bitte geben Sie den Nachnamen ein:";
            this.ntbLastName.Size = new System.Drawing.Size(518, 22);
            this.ntbLastName.TabIndex = 2;
            this.ntbLastName.Text = "Nachname: ";
            this.ntbLastName.ValueAreaLength = 297;
            //
            //ncbWageGroup
            //
            this.ncbWageGroup.BackColor = System.Drawing.SystemColors.Window;
            this.ncbWageGroup.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbWageGroup.CaptionToValueRatio = 426.64;
            this.ncbWageGroup.ColorOnFocus = true;
            this.ncbWageGroup.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32;
            this.ncbWageGroup.DropDownHeight = 106;
            this.ncbWageGroup.DropDownWidth = 315;
            this.ncbWageGroup.FailedValidationErrorMessage = null;
            this.ncbWageGroup.HasCaption = true;
            this.ncbWageGroup.IndependentDatafieldName = "IDWageGroup";
            this.ncbWageGroup.Location = new System.Drawing.Point(11, 169);
            this.ncbWageGroup.MaxDropDownItems = 8;
            this.ncbWageGroup.Name = "ncbWageGroup";
            this.ncbWageGroup.NullString = null;
            this.ncbWageGroup.NullValueMessage = null;
            this.ncbWageGroup.Size = new System.Drawing.Size(518, 24);
            this.ncbWageGroup.TabIndex = 4;
            this.ncbWageGroup.Text = "Lohngruppe: ";
            this.ncbWageGroup.ValueAreaLength = 297;
            //
            //ncbUseFixedWage
            //
            this.ncbUseFixedWage.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbUseFixedWage.CaptionToValueRatio = 741.61;
            this.ncbUseFixedWage.ColorOnFocus = true;
            this.ncbUseFixedWage.FailedValidationErrorMessage = null;
            this.ncbUseFixedWage.HasCaption = true;
            this.ncbUseFixedWage.IndependentDatafieldName = "UseFixedWage";
            this.ncbUseFixedWage.Location = new System.Drawing.Point(11, 204);
            this.ncbUseFixedWage.Name = "ncbUseFixedWage";
            this.ncbUseFixedWage.NullString = null;
            this.ncbUseFixedWage.NullValueMessage = "Bitte bestimmen Sie, ob fixe Betr�ge verwendet werden sollen oder nicht!";
            this.ncbUseFixedWage.Size = new System.Drawing.Size(298, 19);
            this.ncbUseFixedWage.TabIndex = 6;
            this.ncbUseFixedWage.Text = "Fixen Betrag verwenden: ";
            this.ncbUseFixedWage.ValueAreaLength = 77;
            //
            //ndbFixedWage
            //
            this.ndbFixedWage.BackColor = System.Drawing.SystemColors.Window;
            this.ndbFixedWage.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.RightSide;
            this.ndbFixedWage.CaptionToValueRatio = 349.06;
            this.ndbFixedWage.ColorOnFocus = true;
            this.ndbFixedWage.CurrencyText = "";
            this.ndbFixedWage.FailedValidationErrorMessage = null;
            this.ndbFixedWage.FormularText = "";
            this.ndbFixedWage.HasCaption = true;
            this.ndbFixedWage.IndependentDatafieldName = "FixedWage";
            this.ndbFixedWage.Location = new System.Drawing.Point(316, 204);
            this.ndbFixedWage.MaxValue = 0;
            this.ndbFixedWage.MinValue = 0;
            this.ndbFixedWage.Name = "ndbFixedWage";
            this.ndbFixedWage.NullString = "* --- *";
            this.ndbFixedWage.NullValueMessage = null;
            this.ndbFixedWage.Size = new System.Drawing.Size(212, 22);
            this.ndbFixedWage.TabIndex = 5;
            this.ndbFixedWage.Text = " Euro";
            this.ndbFixedWage.ValueAreaLength = 138;
            //
            //ncbIsIncentive
            //
            this.ncbIsIncentive.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbIsIncentive.CaptionToValueRatio = 741.61;
            this.ncbIsIncentive.ColorOnFocus = true;
            this.ncbIsIncentive.FailedValidationErrorMessage = null;
            this.ncbIsIncentive.HasCaption = true;
            this.ncbIsIncentive.IndependentDatafieldName = "IsIncentive";
            this.ncbIsIncentive.Location = new System.Drawing.Point(11, 245);
            this.ncbIsIncentive.Name = "ncbIsIncentive";
            this.ncbIsIncentive.NullString = null;
            this.ncbIsIncentive.NullValueMessage = "Bitte bestimmen Sie, ob {%1} ber�cksichtigt werden soll!";
            this.ncbIsIncentive.Size = new System.Drawing.Size(298, 19);
            this.ncbIsIncentive.TabIndex = 7;
            this.ncbIsIncentive.Text = "F�r {%1} verwenden:";
            this.ncbIsIncentive.ValueAreaLength = 77;
            //
            //ncbIsActive
            //
            this.ncbIsActive.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbIsActive.CaptionToValueRatio = 741.61;
            this.ncbIsActive.ColorOnFocus = true;
            this.ncbIsActive.FailedValidationErrorMessage = null;
            this.ncbIsActive.HasCaption = true;
            this.ncbIsActive.IndependentDatafieldName = "IsActive";
            this.ncbIsActive.Location = new System.Drawing.Point(11, 281);
            this.ncbIsActive.Name = "ncbIsActive";
            this.ncbIsActive.NullString = null;
            this.ncbIsActive.NullValueMessage = "Bitte bestimmen Sie, ob dieser Mitarbeiter-Datensatz aktiv sein soll!";
            this.ncbIsActive.Size = new System.Drawing.Size(298, 19);
            this.ncbIsActive.TabIndex = 8;
            this.ncbIsActive.Text = "Ist aktiviert:";
            this.ncbIsActive.ValueAreaLength = 77;
            //
            //ndbDateOfBirth
            //
            this.ndbDateOfBirth.BackColor = System.Drawing.SystemColors.Window;
            this.ndbDateOfBirth.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ndbDateOfBirth.CaptionToValueRatio = 423.3;
            this.ndbDateOfBirth.ColorOnFocus = true;
            this.ndbDateOfBirth.FailedValidationErrorMessage = null;
            this.ndbDateOfBirth.HasCaption = true;
            this.ndbDateOfBirth.IndependentDatafieldName = "DateOfBirth";
            this.ndbDateOfBirth.Location = new System.Drawing.Point(11, 323);
            this.ndbDateOfBirth.Name = "ndbDateOfBirth";
            this.ndbDateOfBirth.NullString = "* --- *";
            this.ndbDateOfBirth.NullValueMessage = null;
            this.ndbDateOfBirth.Size = new System.Drawing.Size(515, 22);
            this.ndbDateOfBirth.TabIndex = 9;
            this.ndbDateOfBirth.Text = "Geburtsdatum:";
            this.ndbDateOfBirth.ValueAreaLength = 297;
            //
            //ndbDateOfJoining
            //
            this.ndbDateOfJoining.BackColor = System.Drawing.SystemColors.Window;
            this.ndbDateOfJoining.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ndbDateOfJoining.CaptionToValueRatio = 423.3;
            this.ndbDateOfJoining.ColorOnFocus = true;
            this.ndbDateOfJoining.FailedValidationErrorMessage = null;
            this.ndbDateOfJoining.HasCaption = true;
            this.ndbDateOfJoining.IndependentDatafieldName = "DateOfJoining";
            this.ndbDateOfJoining.Location = new System.Drawing.Point(11, 352);
            this.ndbDateOfJoining.Name = "ndbDateOfJoining";
            this.ndbDateOfJoining.NullString = "* --- *";
            this.ndbDateOfJoining.NullValueMessage = null;
            this.ndbDateOfJoining.Size = new System.Drawing.Size(515, 22);
            this.ndbDateOfJoining.TabIndex = 10;
            this.ndbDateOfJoining.Text = "Eintrittsdatum: ";
            this.ndbDateOfJoining.ValueAreaLength = 297;
            //
            //ndbDateOfSeparation
            //
            this.ndbDateOfSeparation.BackColor = System.Drawing.SystemColors.Window;
            this.ndbDateOfSeparation.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ndbDateOfSeparation.CaptionToValueRatio = 423.3;
            this.ndbDateOfSeparation.ColorOnFocus = true;
            this.ndbDateOfSeparation.FailedValidationErrorMessage = null;
            this.ndbDateOfSeparation.HasCaption = true;
            this.ndbDateOfSeparation.IndependentDatafieldName = "DateOfSeparation";
            this.ndbDateOfSeparation.Location = new System.Drawing.Point(11, 381);
            this.ndbDateOfSeparation.Name = "ndbDateOfSeparation";
            this.ndbDateOfSeparation.NullString = "* --- *";
            this.ndbDateOfSeparation.NullValueMessage = null;
            this.ndbDateOfSeparation.Size = new System.Drawing.Size(515, 22);
            this.ndbDateOfSeparation.TabIndex = 11;
            this.ndbDateOfSeparation.Text = "Datum Besch�ftigungsende: ";
            this.ndbDateOfSeparation.ValueAreaLength = 297;
            //
            //ntbTimeCardNo
            //
            this.ntbTimeCardNo.BackColor = System.Drawing.SystemColors.Window;
            this.ntbTimeCardNo.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbTimeCardNo.CaptionToValueRatio = 426.64;
            this.ntbTimeCardNo.ColorOnFocus = true;
            this.ntbTimeCardNo.FailedValidationErrorMessage = null;
            this.ntbTimeCardNo.HasCaption = true;
            this.ntbTimeCardNo.IndependentDatafieldName = "TimeCardNo";
            this.ntbTimeCardNo.Location = new System.Drawing.Point(11, 426);
            this.ntbTimeCardNo.Margin = new System.Windows.Forms.Padding(4);
            this.ntbTimeCardNo.MaxLength = 100;
            this.ntbTimeCardNo.Multiline = false;
            this.ntbTimeCardNo.Name = "ntbTimeCardNo";
            this.ntbTimeCardNo.NullString = "* --- *";
            this.ntbTimeCardNo.NullValueMessage = "";
            this.ntbTimeCardNo.Size = new System.Drawing.Size(518, 22);
            this.ntbTimeCardNo.TabIndex = 12;
            this.ntbTimeCardNo.Text = "Kartennummer/externe Personalnr:";
            this.ntbTimeCardNo.ValueAreaLength = 297;
            //
            //btnAddressDetails
            //
            this.btnAddressDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnAddressDetails.Location = new System.Drawing.Point(566, 133);
            this.btnAddressDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddressDetails.Name = "btnAddressDetails";
            this.btnAddressDetails.Size = new System.Drawing.Size(117, 35);
            this.btnAddressDetails.TabIndex = 15;
            this.btnAddressDetails.Text = "Adressdetails...";
            //
            //btnHandicapManager
            //
            this.btnHandicapManager.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnHandicapManager.Location = new System.Drawing.Point(566, 176);
            this.btnHandicapManager.Margin = new System.Windows.Forms.Padding(4);
            this.btnHandicapManager.Name = "btnHandicapManager";
            this.btnHandicapManager.Size = new System.Drawing.Size(117, 47);
            this.btnHandicapManager.TabIndex = 16;
            this.btnHandicapManager.Text = "Handicap- Manager...";
            //
            //frmEmployeeInfoAddEditView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.ClientSize = new System.Drawing.Size(696, 476);
            this.Controls.Add(this.btnHandicapManager);
            this.Controls.Add(this.btnAddressDetails);
            this.Controls.Add(this.ntbTimeCardNo);
            this.Controls.Add(this.ndbDateOfSeparation);
            this.Controls.Add(this.ndbDateOfJoining);
            this.Controls.Add(this.ndbDateOfBirth);
            this.Controls.Add(this.ncbIsActive);
            this.Controls.Add(this.ncbIsIncentive);
            this.Controls.Add(this.ndbFixedWage);
            this.Controls.Add(this.ncbUseFixedWage);
            this.Controls.Add(this.ncbWageGroup);
            this.Controls.Add(this.ncombCostCenter);
            this.Controls.Add(this.ntbFirstName);
            this.Controls.Add(this.nibPersonnelNumber);
            this.Controls.Add(this.ntbLastName);
            this.Name = "frmEmployeeInfoAddEditView";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.ntbLastName, 0);
            this.Controls.SetChildIndex(this.nibPersonnelNumber, 0);
            this.Controls.SetChildIndex(this.ntbFirstName, 0);
            this.Controls.SetChildIndex(this.ncombCostCenter, 0);
            this.Controls.SetChildIndex(this.ncbWageGroup, 0);
            this.Controls.SetChildIndex(this.ncbUseFixedWage, 0);
            this.Controls.SetChildIndex(this.ndbFixedWage, 0);
            this.Controls.SetChildIndex(this.ncbIsIncentive, 0);
            this.Controls.SetChildIndex(this.ncbIsActive, 0);
            this.Controls.SetChildIndex(this.ndbDateOfBirth, 0);
            this.Controls.SetChildIndex(this.ndbDateOfJoining, 0);
            this.Controls.SetChildIndex(this.ndbDateOfSeparation, 0);
            this.Controls.SetChildIndex(this.ntbTimeCardNo, 0);
            this.Controls.SetChildIndex(this.btnAddressDetails, 0);
            this.Controls.SetChildIndex(this.btnHandicapManager, 0);
            this.ResumeLayout(false);
        }

        protected override void Fac_OnInitializeFormControls()
        {
            base.Fac_OnInitializeFormControls();
            myDoNothing = true;
            Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncombCostCenter);
            Fac_FunctionsInternal.AddWageGroupsToADNullableIdOrIndexComboBox(ncbWageGroup);
            myDoNothing = false;
            AlignIncentiveSynonym();
            ncbIsIncentive.TypeSafeValue = true;
            ncbIsActive.TypeSafeValue = true;
            ncbUseFixedWage.TypeSafeValue = false;
            btnHandicapManager.Enabled = false;
        }

        protected override void Fac_OnAssigningToControls(ActiveDev.IInfoItem InfoItem)
        {
            myCurrentInfoItem = InfoItem;
            if (myCurrentInfoItem != null)
            {
                btnHandicapManager.Enabled = true;
            }

            myDoNothing = true;
            Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncombCostCenter);
            Fac_FunctionsInternal.AddWageGroupsToADNullableIdOrIndexComboBox(ncbWageGroup);
            myDoNothing = false;
            base.Fac_OnAssigningToControls(InfoItem);
            AlignIncentiveSynonym();
            ADDBNullable<int> locIDAddressDetails = ((EmployeeInfo)InfoItem).IDAddressDetails;
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

        protected override void Fac_OnValidatingNew(System.ComponentModel.CancelEventArgs e)
        {
            base.Fac_OnValidatingNew(e);
            if (e.Cancel)
            {
                return;
            }

            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Personalnummer schon existiert
            if (locSPA.Employees_DoesPersonnelNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, nibPersonnelNumber.TypeSafeValue, default(ActiveDev.ADDBNullable<int>)))
            {
                string locErr = Facesso.Functions.My.Resources.EmployeeInfoAdd_PersonnelNoAlreadyExist_MB_Body;
                locErr = string.Format(locErr, nibPersonnelNumber.TypeSafeValue, FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.EmployeeInfoAdd_PersonnelNoAlreadyExist_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnValidatingEdit(InfoItemValidatingEventArgs e)
        {
            base.Fac_OnValidatingEdit(e);
            if (e.Cancel)
            {
                return;
            }

            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Kostenstellennr. schon existiert
            if (locSPA.Employees_DoesPersonnelNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, nibPersonnelNumber.TypeSafeValue, ((EmployeeInfo)e.InfoItem).IDEmployee))
            {
                string locErr = Facesso.Functions.My.Resources.EmployeeInfoAdd_PersonnelNoAlreadyExist_MB_Body;
                locErr = string.Format(locErr, nibPersonnelNumber.TypeSafeValue, FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.EmployeeInfoAdd_PersonnelNoAlreadyExist_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnAssigningToInfoItem(IInfoItem InfoItem)
        {
            base.Fac_OnAssigningToInfoItem(InfoItem);
            SPAccess locSPA = SPAccess.GetInstance();
            ((EmployeeInfo)InfoItem).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
            //AddressDetails sind noch nicht erfasst -> Erzeugen und Vor- und Nachnamen eintragen!
            if (myAddressDetails == null)
            {
                myAddressDetails = new AddressDetailsInfo();
                myAddressDetails.FirstName = ntbFirstName.TypeSafeValue;
                myAddressDetails.LastName = ntbLastName.TypeSafeValue;
            }

            ((EmployeeInfo)InfoItem).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
            if (Fac_EditMode == InfoItemFormEditMode.AddNew)
            {
                locSPA.Employees_Add(((EmployeeInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser, myAddressDetails);
            }
            else if (Fac_EditMode == InfoItemFormEditMode.Edit)
            {
                locSPA.Employees_Edit(((EmployeeInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser, myAddressDetails);
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
            myAddressDetails.FirstName = ntbFirstName.TypeSafeValue;
            myAddressDetails.LastName = ntbLastName.TypeSafeValue;
            InfoItemMaintenanceDialogResult locBack = default(InfoItemMaintenanceDialogResult);
            //F�r den Benutzereintrag d�rfen Vor- und Nachname nicht DBNull sein!
            frmAdrDetails.ForceToHaveLastNameAndFirstname();
            locBack = frmAdrDetails.Fac_HandleDialogAsEdit(Facesso.Functions.My.Resources.UserInfoAddOrEdit_AddressDetailsDialogTitle, myAddressDetails);
            if (locBack.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                myAddressDetails = ((AddressDetailsInfo)locBack.InfoItem);
                ntbFirstName.Value = myAddressDetails.FirstName;
                ntbLastName.Value = myAddressDetails.LastName;
            }
        }

        private void ncombCostCenter_ValueChanged(System.Object sender, System.EventArgs e)
        {
            if (myDoNothing)
            {
                return;
            }

            AlignIncentiveSynonym();
        }

        private void AlignIncentiveSynonym()
        {
            string locString = string.Format(Facesso.Functions.My.Resources.EmployeeInfoAddEditView_Dialog_IncentiveSynonym, SPAccess.GetInstance().GetCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary, ncombCostCenter.TypeSafeValue).IncentiveIndicatorSynonym);
            ncbIsIncentive.Text = locString;
        }

        private void btnHandicapManager_Click(System.Object sender, System.EventArgs e)
        {
            frmHandicapRangeManager frmInstance = new frmHandicapRangeManager();
            //Hack: Speichern bei Neuanlegen ber�cksichtigen
            frmInstance.ShowDialog(((EmployeeInfo)myCurrentInfoItem));
        }
    }
}
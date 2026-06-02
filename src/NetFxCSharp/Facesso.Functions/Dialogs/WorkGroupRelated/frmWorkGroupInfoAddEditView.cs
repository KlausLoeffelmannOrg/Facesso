using ActiveDev;
using ActiveDev.Controls;
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
    public class frmWorkGroupInfoAddEditView : Facesso.Functions.frmInfoItemAddEditViewBase
    {
        public frmWorkGroupInfoAddEditView() : base()
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

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TabControl tcTimeSettings;
        internal System.Windows.Forms.TabPage TabPage1;
        internal ActiveDev.Controls.ADNullableCheckBox ncbIsPeaceWork;
        internal ActiveDev.Controls.ADNullableCheckBox ncbIsActive;
        internal ActiveDev.Controls.ADNullableIdOrIndexComboBox ncbCostCenter;
        internal ActiveDev.Controls.ADNullableIntBox nibWorkGroupNumber;
        internal ActiveDev.Controls.ADNullableTextBox ntbWorkGroupDescription;
        internal ActiveDev.Controls.ADNullableTextBox ntbWorkGroupName;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal Facesso.GenericControls.ucTimeDetailsSettings UcTimeDetailsSettings;
        internal ActiveDev.Controls.ADNullableDoubleBox ndbWorkloadIWT;
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkGroupInfoAddEditView));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.tcTimeSettings = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.ndbWorkloadIWT = new ActiveDev.Controls.ADNullableDoubleBox();
            this.ncbIsPeaceWork = new ActiveDev.Controls.ADNullableCheckBox();
            this.ncbIsActive = new ActiveDev.Controls.ADNullableCheckBox();
            this.ncbCostCenter = new ActiveDev.Controls.ADNullableIdOrIndexComboBox();
            this.nibWorkGroupNumber = new ActiveDev.Controls.ADNullableIntBox();
            this.ntbWorkGroupDescription = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbWorkGroupName = new ActiveDev.Controls.ADNullableTextBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.UcTimeDetailsSettings = new Facesso.GenericControls.ucTimeDetailsSettings();
            this.Label1 = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tcTimeSettings.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(660, 13);
            this.btnOK.TabIndex = 1;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(660, 58);
            this.btnCancel.TabIndex = 2;
            //
            //TabControl1
            //
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(200, 100);
            this.TabControl1.TabIndex = 0;
            //
            //Panel1
            //
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(200, 100);
            this.Panel1.TabIndex = 0;
            //
            //tcTimeSettings
            //
            this.tcTimeSettings.Controls.Add(this.TabPage1);
            this.tcTimeSettings.Controls.Add(this.TabPage2);
            this.tcTimeSettings.Location = new System.Drawing.Point(12, 13);
            this.tcTimeSettings.Name = "tcTimeSettings";
            this.tcTimeSettings.SelectedIndex = 0;
            this.tcTimeSettings.Size = new System.Drawing.Size(616, 593);
            this.tcTimeSettings.TabIndex = 0;
            //
            //TabPage1
            //
            this.TabPage1.Controls.Add(this.ndbWorkloadIWT);
            this.TabPage1.Controls.Add(this.ncbIsPeaceWork);
            this.TabPage1.Controls.Add(this.ncbIsActive);
            this.TabPage1.Controls.Add(this.ncbCostCenter);
            this.TabPage1.Controls.Add(this.nibWorkGroupNumber);
            this.TabPage1.Controls.Add(this.ntbWorkGroupDescription);
            this.TabPage1.Controls.Add(this.ntbWorkGroupName);
            this.TabPage1.Location = new System.Drawing.Point(4, 25);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(608, 531);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Produktiv-Site Stammdaten";
            //
            //ndbWorkloadIWT
            //
            this.ndbWorkloadIWT.BackColor = System.Drawing.SystemColors.Window;
            this.ndbWorkloadIWT.CaptionToValueRatio = 373.52;
            this.ndbWorkloadIWT.ColorOnFocus = true;
            this.ndbWorkloadIWT.CurrencyText = "";
            this.ndbWorkloadIWT.FailedValidationErrorMessage = null;
            this.ndbWorkloadIWT.FormularText = "";
            this.ndbWorkloadIWT.HasCaption = true;
            this.ndbWorkloadIWT.IndependentDatafieldName = "WorkloadIWT";
            this.ndbWorkloadIWT.Location = new System.Drawing.Point(17, 436);
            this.ndbWorkloadIWT.MaxValue = 0;
            this.ndbWorkloadIWT.MinValue = 0;
            this.ndbWorkloadIWT.Name = "ndbWorkloadIWT";
            this.ndbWorkloadIWT.NullString = "* --- *";
            this.ndbWorkloadIWT.NullValueMessage = "Bitte erfassen Sie unter 'Vollauslastung', wie vielen gearbeiteten Arbeitsminuten" + " eine Vollauslastung in dieser Produktiv-Site entspricht.";
            this.ndbWorkloadIWT.Size = new System.Drawing.Size(506, 22);
            this.ndbWorkloadIWT.TabIndex = 4;
            this.ndbWorkloadIWT.Text = "Vollauslastung bei (min.):";
            this.ndbWorkloadIWT.ValueAreaLength = 317;
            //
            //ncbIsPeaceWork
            //
            this.ncbIsPeaceWork.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbIsPeaceWork.CaptionToValueRatio = 735.18;
            this.ncbIsPeaceWork.ColorOnFocus = true;
            this.ncbIsPeaceWork.FailedValidationErrorMessage = null;
            this.ncbIsPeaceWork.HasCaption = true;
            this.ncbIsPeaceWork.IndependentDatafieldName = "IsPeaceWork";
            this.ncbIsPeaceWork.Location = new System.Drawing.Point(17, 496);
            this.ncbIsPeaceWork.Name = "ncbIsPeaceWork";
            this.ncbIsPeaceWork.NullString = null;
            this.ncbIsPeaceWork.NullValueMessage = "Bitte bestimmen Sie, ob dieser Mitarbeiter-Datensatz aktiv sein soll!";
            this.ncbIsPeaceWork.Size = new System.Drawing.Size(506, 19);
            this.ncbIsPeaceWork.TabIndex = 6;
            this.ncbIsPeaceWork.Text = "Ist Einzelarbeitsplatz: ";
            this.ncbIsPeaceWork.ValueAreaLength = 134;
            //
            //ncbIsActive
            //
            this.ncbIsActive.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbIsActive.CaptionToValueRatio = 735.18;
            this.ncbIsActive.ColorOnFocus = true;
            this.ncbIsActive.FailedValidationErrorMessage = null;
            this.ncbIsActive.HasCaption = true;
            this.ncbIsActive.IndependentDatafieldName = "IsActive";
            this.ncbIsActive.Location = new System.Drawing.Point(17, 471);
            this.ncbIsActive.Name = "ncbIsActive";
            this.ncbIsActive.NullString = null;
            this.ncbIsActive.NullValueMessage = "Bitte bestimmen Sie, ob dieser Mitarbeiter-Datensatz aktiv sein soll!";
            this.ncbIsActive.Size = new System.Drawing.Size(506, 19);
            this.ncbIsActive.TabIndex = 5;
            this.ncbIsActive.Text = "Ist aktiviert:";
            this.ncbIsActive.ValueAreaLength = 134;
            //
            //ncbCostCenter
            //
            this.ncbCostCenter.BackColor = System.Drawing.SystemColors.Window;
            this.ncbCostCenter.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbCostCenter.CaptionToValueRatio = 373.52;
            this.ncbCostCenter.ColorOnFocus = true;
            this.ncbCostCenter.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32;
            this.ncbCostCenter.DropDownHeight = 106;
            this.ncbCostCenter.DropDownWidth = 315;
            this.ncbCostCenter.FailedValidationErrorMessage = null;
            this.ncbCostCenter.HasCaption = true;
            this.ncbCostCenter.IndependentDatafieldName = "IDCostCenter";
            this.ncbCostCenter.Location = new System.Drawing.Point(17, 80);
            this.ncbCostCenter.MaxDropDownItems = 8;
            this.ncbCostCenter.Name = "ncbCostCenter";
            this.ncbCostCenter.NullString = null;
            this.ncbCostCenter.NullValueMessage = "Bitte bestimmen Sie die Kostenstelle zu diesem Arbeitswert!";
            this.ncbCostCenter.Size = new System.Drawing.Size(506, 24);
            this.ncbCostCenter.TabIndex = 2;
            this.ncbCostCenter.Text = "Kostenstellen-Nummer: ";
            this.ncbCostCenter.ValueAreaLength = 317;
            //
            //nibWorkGroupNumber
            //
            this.nibWorkGroupNumber.BackColor = System.Drawing.SystemColors.Window;
            this.nibWorkGroupNumber.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.nibWorkGroupNumber.CaptionToValueRatio = 372.78;
            this.nibWorkGroupNumber.ColorOnFocus = true;
            this.nibWorkGroupNumber.FailedValidationErrorMessage = null;
            this.nibWorkGroupNumber.FormularText = "";
            this.nibWorkGroupNumber.HasCaption = true;
            this.nibWorkGroupNumber.IndependentDatafieldName = "WorkGroupNumber";
            this.nibWorkGroupNumber.Location = new System.Drawing.Point(16, 20);
            this.nibWorkGroupNumber.MaxValue = 0;
            this.nibWorkGroupNumber.MinValue = 0;
            this.nibWorkGroupNumber.Name = "nibWorkGroupNumber";
            this.nibWorkGroupNumber.NullString = "* --- *";
            this.nibWorkGroupNumber.NullValueMessage = "Bitte bestimmen Sie die Arbeitswertnummer!";
            this.nibWorkGroupNumber.Size = new System.Drawing.Size(507, 22);
            this.nibWorkGroupNumber.TabIndex = 0;
            this.nibWorkGroupNumber.Text = "Produktiv-Site-Nr.: ";
            this.nibWorkGroupNumber.ValueAreaLength = 318;
            //
            //ntbWorkGroupDescription
            //
            this.ntbWorkGroupDescription.BackColor = System.Drawing.SystemColors.Window;
            this.ntbWorkGroupDescription.CaptionBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ntbWorkGroupDescription.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.Above;
            this.ntbWorkGroupDescription.CaptionToValueRatio = 1000;
            this.ntbWorkGroupDescription.ColorOnFocus = true;
            this.ntbWorkGroupDescription.FailedValidationErrorMessage = null;
            this.ntbWorkGroupDescription.HasCaption = true;
            this.ntbWorkGroupDescription.IndependentDatafieldName = "WorkGroupDescription";
            this.ntbWorkGroupDescription.Location = new System.Drawing.Point(17, 120);
            this.ntbWorkGroupDescription.Margin = new System.Windows.Forms.Padding(4);
            this.ntbWorkGroupDescription.Multiline = true;
            this.ntbWorkGroupDescription.Name = "ntbWorkGroupDescription";
            this.ntbWorkGroupDescription.NullString = "* --- *";
            this.ntbWorkGroupDescription.NullValueMessage = null;
            this.ntbWorkGroupDescription.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.ntbWorkGroupDescription.Size = new System.Drawing.Size(506, 296);
            this.ntbWorkGroupDescription.TabIndex = 3;
            this.ntbWorkGroupDescription.Text = "Produktiv-Site-Beschreibung:";
            this.ntbWorkGroupDescription.ValueAreaLength = 506;
            //
            //ntbWorkGroupName
            //
            this.ntbWorkGroupName.BackColor = System.Drawing.SystemColors.Window;
            this.ntbWorkGroupName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbWorkGroupName.CaptionToValueRatio = 373.52;
            this.ntbWorkGroupName.ColorOnFocus = true;
            this.ntbWorkGroupName.FailedValidationErrorMessage = null;
            this.ntbWorkGroupName.HasCaption = true;
            this.ntbWorkGroupName.IndependentDatafieldName = "WorkGroupName";
            this.ntbWorkGroupName.Location = new System.Drawing.Point(17, 50);
            this.ntbWorkGroupName.Margin = new System.Windows.Forms.Padding(4);
            this.ntbWorkGroupName.MaxLength = 100;
            this.ntbWorkGroupName.Multiline = false;
            this.ntbWorkGroupName.Name = "ntbWorkGroupName";
            this.ntbWorkGroupName.NullString = "* --- *";
            this.ntbWorkGroupName.NullValueMessage = "Bitte bestimmen Sie einen Arbeitswertnamen !";
            this.ntbWorkGroupName.Size = new System.Drawing.Size(506, 22);
            this.ntbWorkGroupName.TabIndex = 1;
            this.ntbWorkGroupName.Text = "Produktiv-Site-Name: ";
            this.ntbWorkGroupName.ValueAreaLength = 317;
            //
            //TabPage2
            //
            this.TabPage2.AutoScroll = true;
            this.TabPage2.Controls.Add(this.UcTimeDetailsSettings);
            this.TabPage2.Controls.Add(this.Label1);
            this.TabPage2.Location = new System.Drawing.Point(4, 25);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(608, 564);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Einstellungen Zeiterfassung";
            //
            //UcTimeDetailsSettings
            //
            this.UcTimeDetailsSettings.CurrentlyDisplayedShift = 1;
            this.UcTimeDetailsSettings.CurrentlyDisplayedWeekday = Facesso.TimeSettingDetailsWeekdays.ForAll;
            this.UcTimeDetailsSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.UcTimeDetailsSettings.Location = new System.Drawing.Point(20, 72);
            this.UcTimeDetailsSettings.Margin = new System.Windows.Forms.Padding(4);
            this.UcTimeDetailsSettings.Name = "UcTimeDetailsSettings";
            this.UcTimeDetailsSettings.Size = new System.Drawing.Size(574, 477);
            this.UcTimeDetailsSettings.TabIndex = 1;
            //
            //Label1
            //
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label1.Location = new System.Drawing.Point(15, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(508, 40);
            this.Label1.TabIndex = 0;
            this.Label1.Text = resources.GetString("Label1.Text");
            //
            //frmWorkGroupInfoAddEditView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.ClientSize = new System.Drawing.Size(790, 618);
            this.Controls.Add(this.tcTimeSettings);
            this.Name = "frmWorkGroupInfoAddEditView";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.tcTimeSettings, 0);
            this.tcTimeSettings.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        protected override void Fac_OnInitializeFormControls()
        {
            Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncbCostCenter);
            Fac_InfoItem = new WorkGroupInfo(true);
            Fac_OnAssigningToControls(Fac_InfoItem);
            UcTimeDetailsSettings.TSDetails = ((WorkGroupInfo)Fac_InfoItem).TimeSettingDetails;
        }

        protected override void Fac_OnAssigningToControls(ActiveDev.IInfoItem InfoItem)
        {
            Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncbCostCenter);
            base.Fac_OnAssigningToControls(InfoItem);
            UcTimeDetailsSettings.TSDetails = ((WorkGroupInfo)InfoItem).TimeSettingDetails;
        }

        protected override void Fac_OnValidatingNew(System.ComponentModel.CancelEventArgs e)
        {
            base.Fac_OnValidatingNew(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Kostenstellennr. schon existiert
            if (locSPA.WorkGroups_DoesWorkGroupNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, nibWorkGroupNumber.TypeSafeValue, default(ActiveDev.ADDBNullable<int>)))
            {
                string locErr = Facesso.Functions.My.Resources.WorkGroupInfoAdd_WorkGroupNumberAlreadyExists_MB_Body;
                locErr = string.Format(locErr, nibWorkGroupNumber.TypeSafeValue, FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.WorkGroupInfoAdd_WorkGroupNumberAlreadyExists_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnValidatingEdit(InfoItemValidatingEventArgs e)
        {
            base.Fac_OnValidatingEdit(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Kostenstellennr. schon existiert
            if (locSPA.WorkGroups_DoesWorkGroupNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, nibWorkGroupNumber.TypeSafeValue, ((WorkGroupInfo)e.InfoItem).IDWorkGroup))
            {
                string locErr = Facesso.Functions.My.Resources.WorkGroupInfoAdd_WorkGroupNumberAlreadyExists_MB_Body;
                locErr = string.Format(locErr, nibWorkGroupNumber.TypeSafeValue, FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.WorkGroupInfoAdd_WorkGroupNumberAlreadyExists_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnAssigningToInfoItem(IInfoItem InfoItem)
        {
            base.Fac_OnAssigningToInfoItem(InfoItem);
            // Abspeichern der Kostenstelle
            SPAccess locSPA = SPAccess.GetInstance();
            ((WorkGroupInfo)InfoItem).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
            if (Fac_EditMode == InfoItemFormEditMode.AddNew)
            {
                locSPA.WorkGroups_Add(((WorkGroupInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
            else if (Fac_EditMode == InfoItemFormEditMode.Edit)
            {
                locSPA.WorkGroups_Edit(((WorkGroupInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
        }

        private void AdNullableDateTimeBox3_Click(System.Object sender, System.EventArgs e)
        {
        }
    }
}
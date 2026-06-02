using Facesso.Data;
using Microsoft.VisualBasic;
using Microsoft.Win32;
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

namespace Facesso.Functions
{
    public partial class frmOptions
    {
        private LayoutAndNumberformats myLayout;
        public DialogResult HandleDialog()
        {
            return this.ShowDialog();
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            SaveParameters();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmOptions_Load(System.Object sender, System.EventArgs e)
        {
            TimeSettingDetails locTsd = ((TimeSettingDetails)FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("GlobalTimeSettingDetailsTemplate", new TimeSettingDetails(new System.DateTime(2003, 1, 1, 6, 0, 0), new System.DateTime(2003, 1, 1, 14, 0, 0), new System.DateTime(2003, 1, 1, 22, 0, 0), new System.DateTime(2003, 1, 2, 5, 0, 0), default(ActiveDev.ADDBNullable<System.DateTime>), default(ActiveDev.ADDBNullable<System.DateTime>), 30)));
            UcTimeDetailsSettings.TSDetails = locTsd;
            SetupLayoutParameters();
            SetupFacessoGeneralOptions();
        }

        public void SetupLayoutParameters()
        {
            myLayout = ((LayoutAndNumberformats)FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("LayoutAndNumberFormats", new LayoutAndNumberformats()));
            lblFontU1.Text = myLayout.U1Font.FontSettingsDescription;
            lblFontU2.Text = myLayout.U2Font.FontSettingsDescription;
            lblFontU3.Text = myLayout.U3Font.FontSettingsDescription;
            lblTableHeaderFont.Text = myLayout.TableHeaderFont.FontSettingsDescription;
            lblTextAndTableBodyFont.Text = myLayout.TextAndTableBodyFont.FontSettingsDescription;
            //pbxLogo.Image = locLayout.LogoBitmap
            cmbGridStyle.SelectedIndex = (int)(myLayout.Gridstyle);
            cmbHMinutesPrecision.SelectedIndex = myLayout.HMinPrecision;
        }

        public void SetupFacessoGeneralOptions()
        {
            FacessoGeneralOptions locFacessoGeneralOptions = ((FacessoGeneralOptions)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", new FacessoGeneralOptions(false, false, true, false, 60)));
            chkAutomateMainFormUpdate.Checked = locFacessoGeneralOptions.AutomateMainFormUpdate;
            chkSaturdayIsWorkday.Checked = locFacessoGeneralOptions.SaturdayIsWorkday;
            chkSundayIsWorkday.Checked = locFacessoGeneralOptions.SundayIsWorkday;
            txtSQLLoginString.Text = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\ActiveDev\\Facesso\\Classes", "ConnectionString", null).ToString();
            FacessoPathSettings.InstallationFolder = FacessoGeneric.InstallationFolder;
            FacessoPathSettings.UpdateFolder = FacessoGeneric.UpdateFolder;
            FacessoPathSettings.UpdateUrl = FacessoGeneric.UpdateUrl;
            FacessoPathSettings.SharedFolder = FacessoGeneric.SharedFolder;
            nibThresholdFirstShift.TypeSafeValue = FacessoGeneric.FirstShiftThresholdInMin;
            if (FacessoGeneric.FallbackStartTime < new System.DateTime(2003, 1, 1))
            {
                FacessoGeneric.FallbackStartTime = FacessoGeneric.FallbackStartTime.AddYears(2003);
            }

            if (FacessoGeneric.FallbackEndTime < new System.DateTime(2003, 1, 1))
            {
                FacessoGeneric.FallbackEndTime = FacessoGeneric.FallbackEndTime.AddYears(2003);
            }

            dtbFallBackTimeStart.TypeSafeValue = FacessoGeneric.FallbackStartTime;
            dtbFallBackTimeEnd.TypeSafeValue = FacessoGeneric.FallbackEndTime;
            chkShowIssueListPriorToImport.Checked = locFacessoGeneralOptions.ShowIssueListPriorToImport;
            chkShowTimeLogPriorToImport.Checked = locFacessoGeneralOptions.ShowTimeLogPriorToImport;
        }

        public void SaveGeneralOptions()
        {
            FacessoGeneralOptions locFacessoGeneralOptions = new FacessoGeneralOptions(chkSaturdayIsWorkday.Checked, chkSundayIsWorkday.Checked, true, chkAutomateMainFormUpdate.Checked, 60);
            FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoGeneralOptions", locFacessoGeneralOptions);
            try
            {
                //Verzeichnisse und Urls speichern
                FacessoGeneric.UpdateFolder = FacessoPathSettings.UpdateFolder;
                FacessoGeneric.UpdateUrl = FacessoPathSettings.UpdateUrl;
                FacessoGeneric.SharedFolder = FacessoPathSettings.SharedFolder;
                FacessoGeneric.InstallationFolder = FacessoPathSettings.InstallationFolder;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sie k�nnen alle Einstellungen nur �ndern, wenn Sie als Administrator angemeldet sind.");
            }

            locFacessoGeneralOptions.ShowIssueListPriorToImport = chkShowIssueListPriorToImport.Checked;
            locFacessoGeneralOptions.ShowTimeLogPriorToImport = chkShowTimeLogPriorToImport.Checked;
        }

        public void SaveParameters()
        {
            SaveGeneralOptions();
            FacessoGeneric.SaveGlobalSettings();
            FacessoGeneric.SaveUserSettings();
            FacessoGeneric.FallbackStartTime = dtbFallBackTimeStart.TypeSafeValue;
            FacessoGeneric.FallbackEndTime = dtbFallBackTimeEnd.TypeSafeValue;
            FacessoGeneric.FirstShiftThresholdInMin = nibThresholdFirstShift.TypeSafeValue;
        }

        private void HandleFontButtons(System.Object sender, System.EventArgs e)
        {
            FontDialog locFontDialog = new FontDialog();
            locFontDialog.ShowEffects = true;
            DialogResult locDR = locFontDialog.ShowDialog();
            if (locDR == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            if (sender == this.btnU1Font)
            {
                myLayout.U1Font = new SerializableFontSetting(locFontDialog.Font);
                lblFontU1.Text = myLayout.U1Font.FontSettingsDescription;
            }
            else if (sender == this.btnU2Font)
            {
                myLayout.U2Font = new SerializableFontSetting(locFontDialog.Font);
                lblFontU2.Text = myLayout.U2Font.FontSettingsDescription;
            }
            else if (sender == this.btnU3Font)
            {
                myLayout.U3Font = new SerializableFontSetting(locFontDialog.Font);
                lblFontU3.Text = myLayout.U3Font.FontSettingsDescription;
            }
            else if (sender == this.btnTableHeaderFont)
            {
                myLayout.TableHeaderFont = new SerializableFontSetting(locFontDialog.Font);
                lblTableHeaderFont.Text = myLayout.TableHeaderFont.FontSettingsDescription;
            }
            else if (sender == this.btnTextBodyAndTableBodyFont)
            {
                myLayout.TextAndTableBodyFont = new SerializableFontSetting(locFontDialog.Font);
                lblTextAndTableBodyFont.Text = myLayout.TextAndTableBodyFont.FontSettingsDescription;
            }
        }

        private void cmbGridStyle_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            myLayout.Gridstyle = ((FacessoLayoutGridstyle)cmbGridStyle.SelectedIndex);
        }

        private void cmbHMinutesPrecision_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            myLayout.HMinPrecision = System.Convert.ToByte(cmbHMinutesPrecision.SelectedIndex);
        }

        private void btnSetSqlLoginString_Click(System.Object sender, System.EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\ActiveDev\\Facesso\\Classes", "ConnectionString", txtSQLLoginString.Text);
            MessageBox.Show("Ein Neustart ist erforderlich, damit die �nderungen wirksam werden!", "Neustart erforderlich!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnAssignToWorkgroups_Click(System.Object sender, System.EventArgs e)
        {
            frmAssignTimeSettingsToWorkgroups locFrm = new frmAssignTimeSettingsToWorkgroups();
            TimeSettingDetails locTsd = ((TimeSettingDetails)FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("GlobalTimeSettingDetailsTemplate", new TimeSettingDetails(new System.DateTime(2003, 1, 1, 6, 0, 0), new System.DateTime(2003, 1, 1, 14, 0, 0), new System.DateTime(2003, 1, 1, 22, 0, 0), new System.DateTime(2003, 1, 2, 5, 0, 0), default(ActiveDev.ADDBNullable<System.DateTime>), default(ActiveDev.ADDBNullable<System.DateTime>), 30)));
            locFrm.AssignToSelected(locTsd);
        }

        public frmOptions()
        {
            this.Load += frmOptions_Load;
            InitializeComponent();
        }
    }
}
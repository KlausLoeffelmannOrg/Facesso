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
    public partial class frmOptions : Form
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.chkAutomateMainFormUpdate = new System.Windows.Forms.CheckBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.FacessoPathSettings = new Facesso.ucFacessoPathSettings();
            this.Label17 = new System.Windows.Forms.Label();
            this.btnChooseSqlConnectionString = new System.Windows.Forms.Button();
            this.txtSQLLoginString = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.chkSundayIsWorkday = new System.Windows.Forms.CheckBox();
            this.chkSaturdayIsWorkday = new System.Windows.Forms.CheckBox();
            this.tpTimeSettingDefaults = new System.Windows.Forms.TabPage();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnAssignToWorkgroups = new System.Windows.Forms.Button();
            this.UcTimeDetailsSettings = new Facesso.GenericControls.ucTimeDetailsSettings();
            this.tpLayoutAndNumberformats = new System.Windows.Forms.TabPage();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPreView = new System.Windows.Forms.Button();
            this.cmbGridStyle = new System.Windows.Forms.ComboBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.cmbHMinutesPrecision = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.btnLogo = new System.Windows.Forms.Button();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.btnTextBodyAndTableBodyFont = new System.Windows.Forms.Button();
            this.lblTextAndTableBodyFont = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.btnTableHeaderFont = new System.Windows.Forms.Button();
            this.lblTableHeaderFont = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.btnU3Font = new System.Windows.Forms.Button();
            this.lblFontU3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnU2Font = new System.Windows.Forms.Button();
            this.lblFontU2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnU1Font = new System.Windows.Forms.Button();
            this.lblFontU1 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.tpThresholdValues = new System.Windows.Forms.TabPage();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.nibThresholdFirstShift = new ActiveDev.Controls.ADNullableIntBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.dtbFallBackTimeEnd = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.dtbFallBackTimeStart = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.chkShowTimeLogPriorToImport = new System.Windows.Forms.CheckBox();
            this.chkShowIssueListPriorToImport = new System.Windows.Forms.CheckBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.tcMain.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.tpTimeSettingDefaults.SuspendLayout();
            this.tpLayoutAndNumberformats.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbxLogo).BeginInit();
            this.tpThresholdValues.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.SuspendLayout();
            //
            //tcMain
            //
            this.tcMain.Controls.Add(this.tpGeneral);
            this.tcMain.Controls.Add(this.tpTimeSettingDefaults);
            this.tcMain.Controls.Add(this.tpLayoutAndNumberformats);
            this.tcMain.Controls.Add(this.tpThresholdValues);
            this.tcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.tcMain.Location = new System.Drawing.Point(15, 19);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(614, 555);
            this.tcMain.TabIndex = 0;
            //
            //tpGeneral
            //
            this.tpGeneral.Controls.Add(this.GroupBox6);
            this.tpGeneral.Controls.Add(this.GroupBox5);
            this.tpGeneral.Controls.Add(this.GroupBox4);
            this.tpGeneral.Location = new System.Drawing.Point(4, 25);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(606, 526);
            this.tpGeneral.TabIndex = 2;
            this.tpGeneral.Text = "Allgemein";
            this.tpGeneral.UseVisualStyleBackColor = true;
            //
            //GroupBox6
            //
            this.GroupBox6.Controls.Add(this.Label6);
            this.GroupBox6.Controls.Add(this.chkAutomateMainFormUpdate);
            this.GroupBox6.Location = new System.Drawing.Point(15, 381);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(546, 97);
            this.GroupBox6.TabIndex = 2;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Automatische Datenaktualisierung";
            //
            //Label6
            //
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label6.Location = new System.Drawing.Point(35, 60);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(485, 29);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "HINWEIS: Aktivieren Sie dieses Kontrollk�stchen, wenn die \"Daten-vorhanden-Anzeig" + "e\" der Hauptmaske im Minutentakt eingeschaltet werden soll.";
            //
            //chkAutomateMainFormUpdate
            //
            this.chkAutomateMainFormUpdate.AutoSize = true;
            this.chkAutomateMainFormUpdate.Location = new System.Drawing.Point(17, 29);
            this.chkAutomateMainFormUpdate.Name = "chkAutomateMainFormUpdate";
            this.chkAutomateMainFormUpdate.Size = new System.Drawing.Size(417, 20);
            this.chkAutomateMainFormUpdate.TabIndex = 0;
            this.chkAutomateMainFormUpdate.Text = "Auf dieser Workstation die Hauptmaske automatisch aktualisieren";
            this.chkAutomateMainFormUpdate.UseVisualStyleBackColor = true;
            //
            //GroupBox5
            //
            this.GroupBox5.Controls.Add(this.FacessoPathSettings);
            this.GroupBox5.Controls.Add(this.Label17);
            this.GroupBox5.Controls.Add(this.btnChooseSqlConnectionString);
            this.GroupBox5.Controls.Add(this.txtSQLLoginString);
            this.GroupBox5.Location = new System.Drawing.Point(15, 122);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(546, 240);
            this.GroupBox5.TabIndex = 1;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Pfade, URLs und SQL-Verbindungszeichenfolgen";
            //
            //FacessoPathSettings
            //
            this.FacessoPathSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.FacessoPathSettings.InstallationFolder = "";
            this.FacessoPathSettings.Location = new System.Drawing.Point(17, 21);
            this.FacessoPathSettings.Margin = new System.Windows.Forms.Padding(4);
            this.FacessoPathSettings.Name = "FacessoPathSettings";
            this.FacessoPathSettings.SharedFolder = "";
            this.FacessoPathSettings.Size = new System.Drawing.Size(525, 120);
            this.FacessoPathSettings.TabIndex = 13;
            this.FacessoPathSettings.UpdateFolder = "";
            this.FacessoPathSettings.UpdateUrl = "";
            //
            //Label17
            //
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(6, 149);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(163, 16);
            this.Label17.TabIndex = 10;
            this.Label17.Text = "Verbindungszeichenfolge:";
            //
            //btnChooseSqlConnectionString
            //
            this.btnChooseSqlConnectionString.Location = new System.Drawing.Point(512, 148);
            this.btnChooseSqlConnectionString.Name = "btnChooseSqlConnectionString";
            this.btnChooseSqlConnectionString.Size = new System.Drawing.Size(28, 24);
            this.btnChooseSqlConnectionString.TabIndex = 12;
            this.btnChooseSqlConnectionString.Text = "...";
            this.btnChooseSqlConnectionString.UseVisualStyleBackColor = true;
            //
            //txtSQLLoginString
            //
            this.txtSQLLoginString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.txtSQLLoginString.Location = new System.Drawing.Point(175, 148);
            this.txtSQLLoginString.Multiline = true;
            this.txtSQLLoginString.Name = "txtSQLLoginString";
            this.txtSQLLoginString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQLLoginString.Size = new System.Drawing.Size(331, 86);
            this.txtSQLLoginString.TabIndex = 11;
            //
            //GroupBox4
            //
            this.GroupBox4.Controls.Add(this.Label2);
            this.GroupBox4.Controls.Add(this.chkSundayIsWorkday);
            this.GroupBox4.Controls.Add(this.chkSaturdayIsWorkday);
            this.GroupBox4.Location = new System.Drawing.Point(15, 21);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(546, 95);
            this.GroupBox4.TabIndex = 0;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Arbeitstage am Wochenende:";
            //
            //Label2
            //
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label2.Location = new System.Drawing.Point(279, 25);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(241, 70);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "HINWEIS: Diese Einstellungen beziehen sich ausschlie�lich auf das 'Bl�ttern' des " + "Datums in der Hauptmaske und dem Datenmanager von Facesso.NET.";
            //
            //chkSundayIsWorkday
            //
            this.chkSundayIsWorkday.AutoSize = true;
            this.chkSundayIsWorkday.Location = new System.Drawing.Point(17, 55);
            this.chkSundayIsWorkday.Name = "chkSundayIsWorkday";
            this.chkSundayIsWorkday.Size = new System.Drawing.Size(157, 20);
            this.chkSundayIsWorkday.TabIndex = 1;
            this.chkSundayIsWorkday.Text = "Sonntag ist Arbeitstag";
            this.chkSundayIsWorkday.UseVisualStyleBackColor = true;
            //
            //chkSaturdayIsWorkday
            //
            this.chkSaturdayIsWorkday.AutoSize = true;
            this.chkSaturdayIsWorkday.Location = new System.Drawing.Point(17, 29);
            this.chkSaturdayIsWorkday.Name = "chkSaturdayIsWorkday";
            this.chkSaturdayIsWorkday.Size = new System.Drawing.Size(161, 20);
            this.chkSaturdayIsWorkday.TabIndex = 0;
            this.chkSaturdayIsWorkday.Text = "Samstag ist Arbeitstag";
            this.chkSaturdayIsWorkday.UseVisualStyleBackColor = true;
            //
            //tpTimeSettingDefaults
            //
            this.tpTimeSettingDefaults.Controls.Add(this.Label4);
            this.tpTimeSettingDefaults.Controls.Add(this.btnAssignToWorkgroups);
            this.tpTimeSettingDefaults.Controls.Add(this.UcTimeDetailsSettings);
            this.tpTimeSettingDefaults.Location = new System.Drawing.Point(4, 25);
            this.tpTimeSettingDefaults.Name = "tpTimeSettingDefaults";
            this.tpTimeSettingDefaults.Padding = new System.Windows.Forms.Padding(3);
            this.tpTimeSettingDefaults.Size = new System.Drawing.Size(606, 526);
            this.tpTimeSettingDefaults.TabIndex = 0;
            this.tpTimeSettingDefaults.Text = "Schichtmodell";
            this.tpTimeSettingDefaults.UseVisualStyleBackColor = true;
            //
            //Label4
            //
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label4.Location = new System.Drawing.Point(16, 488);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(338, 28);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Hinweis: Verwenden Sie 'An Produktiv-Sites zuweisen', wenn Sie diese Einstellunge" + "n anderen Produktiv-Sites zuweisen wollen.";
            //
            //btnAssignToWorkgroups
            //
            this.btnAssignToWorkgroups.Location = new System.Drawing.Point(374, 487);
            this.btnAssignToWorkgroups.Name = "btnAssignToWorkgroups";
            this.btnAssignToWorkgroups.Size = new System.Drawing.Size(201, 33);
            this.btnAssignToWorkgroups.TabIndex = 1;
            this.btnAssignToWorkgroups.Text = "An Produktiv-Sites zuweisen...";
            this.btnAssignToWorkgroups.UseVisualStyleBackColor = true;
            //
            //UcTimeDetailsSettings
            //
            this.UcTimeDetailsSettings.CurrentlyDisplayedShift = 1;
            this.UcTimeDetailsSettings.CurrentlyDisplayedWeekday = Facesso.TimeSettingDetailsWeekdays.ForAll;
            this.UcTimeDetailsSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.UcTimeDetailsSettings.Location = new System.Drawing.Point(12, 7);
            this.UcTimeDetailsSettings.Margin = new System.Windows.Forms.Padding(4);
            this.UcTimeDetailsSettings.Name = "UcTimeDetailsSettings";
            this.UcTimeDetailsSettings.Size = new System.Drawing.Size(572, 477);
            this.UcTimeDetailsSettings.TabIndex = 0;
            //
            //tpLayoutAndNumberformats
            //
            this.tpLayoutAndNumberformats.Controls.Add(this.GroupBox3);
            this.tpLayoutAndNumberformats.Controls.Add(this.GroupBox2);
            this.tpLayoutAndNumberformats.Controls.Add(this.GroupBox1);
            this.tpLayoutAndNumberformats.Location = new System.Drawing.Point(4, 25);
            this.tpLayoutAndNumberformats.Name = "tpLayoutAndNumberformats";
            this.tpLayoutAndNumberformats.Padding = new System.Windows.Forms.Padding(3);
            this.tpLayoutAndNumberformats.Size = new System.Drawing.Size(606, 526);
            this.tpLayoutAndNumberformats.TabIndex = 1;
            this.tpLayoutAndNumberformats.Text = "Drucklayout und Zahlenformate";
            this.tpLayoutAndNumberformats.UseVisualStyleBackColor = true;
            //
            //GroupBox3
            //
            this.GroupBox3.Controls.Add(this.btnPreView);
            this.GroupBox3.Controls.Add(this.cmbGridStyle);
            this.GroupBox3.Controls.Add(this.Label16);
            this.GroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.GroupBox3.Location = new System.Drawing.Point(8, 307);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(568, 69);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Tabellenstil:";
            //
            //btnPreView
            //
            this.btnPreView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnPreView.Location = new System.Drawing.Point(472, 23);
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.Size = new System.Drawing.Size(85, 25);
            this.btnPreView.TabIndex = 2;
            this.btnPreView.Text = "Vorschau...";
            //
            //cmbGridStyle
            //
            this.cmbGridStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.cmbGridStyle.FormattingEnabled = true;
            this.cmbGridStyle.Items.AddRange(new object[] { "Kein Gitternetz", "einfaches Gitternetz, schmal", "einfaches Gitternetz, dick", "Gitternetz 3D-Effekt 1", "Gitternetz 3D-Effekt 2" });
            this.cmbGridStyle.Location = new System.Drawing.Point(175, 25);
            this.cmbGridStyle.Name = "cmbGridStyle";
            this.cmbGridStyle.Size = new System.Drawing.Size(282, 24);
            this.cmbGridStyle.TabIndex = 1;
            //
            //Label16
            //
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label16.Location = new System.Drawing.Point(12, 27);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(156, 19);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "Gitternetz:";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //GroupBox2
            //
            this.GroupBox2.Controls.Add(this.Label13);
            this.GroupBox2.Controls.Add(this.Label12);
            this.GroupBox2.Controls.Add(this.cmbHMinutesPrecision);
            this.GroupBox2.Controls.Add(this.Label11);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.GroupBox2.Location = new System.Drawing.Point(7, 393);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(568, 86);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Zahlenformate:";
            //
            //Label13
            //
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label13.Location = new System.Drawing.Point(174, 47);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(368, 32);
            this.Label13.TabIndex = 3;
            this.Label13.Text = "Hinweis: Die Anzahl dargestellter Stellen der Leistungsindikatoren ergibt sich au" + "s der in den jeweiligen Kostenstellen hinterlegten Pr�zisionsdefinition.";
            //
            //Label12
            //
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label12.Location = new System.Drawing.Point(245, 20);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(108, 16);
            this.Label12.TabIndex = 2;
            this.Label12.Text = "Stellen gerundet.";
            //
            //cmbHMinutesPrecision
            //
            this.cmbHMinutesPrecision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.cmbHMinutesPrecision.FormattingEnabled = true;
            this.cmbHMinutesPrecision.Items.AddRange(new object[] { "0", "1", "2", "3", "4" });
            this.cmbHMinutesPrecision.Location = new System.Drawing.Point(175, 16);
            this.cmbHMinutesPrecision.Name = "cmbHMinutesPrecision";
            this.cmbHMinutesPrecision.Size = new System.Drawing.Size(57, 24);
            this.cmbHMinutesPrecision.TabIndex = 1;
            //
            //Label11
            //
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label11.Location = new System.Drawing.Point(10, 19);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(158, 19);
            this.Label11.TabIndex = 0;
            this.Label11.Text = "hnd. Minutenangaben: auf ";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.Label14);
            this.GroupBox1.Controls.Add(this.btnLogo);
            this.GroupBox1.Controls.Add(this.pbxLogo);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.btnTextBodyAndTableBodyFont);
            this.GroupBox1.Controls.Add(this.lblTextAndTableBodyFont);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.btnTableHeaderFont);
            this.GroupBox1.Controls.Add(this.lblTableHeaderFont);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.btnU3Font);
            this.GroupBox1.Controls.Add(this.lblFontU3);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.btnU2Font);
            this.GroupBox1.Controls.Add(this.lblFontU2);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.btnU1Font);
            this.GroupBox1.Controls.Add(this.lblFontU1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.GroupBox1.Location = new System.Drawing.Point(7, 11);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(569, 278);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Schriftarten und Logos:";
            //
            //Label14
            //
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label14.Location = new System.Drawing.Point(11, 208);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(157, 43);
            this.Label14.TabIndex = 18;
            this.Label14.Text = "Hinweis: Wird proportional auf 1,5 cm-H�he verkleinert bzw. vergr��ert.";
            //
            //btnLogo
            //
            this.btnLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnLogo.Location = new System.Drawing.Point(521, 180);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(22, 19);
            this.btnLogo.TabIndex = 17;
            this.btnLogo.Text = "...";
            //
            //pbxLogo
            //
            this.pbxLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxLogo.Location = new System.Drawing.Point(175, 183);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(340, 87);
            this.pbxLogo.TabIndex = 16;
            this.pbxLogo.TabStop = false;
            //
            //Label10
            //
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label10.Location = new System.Drawing.Point(10, 183);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(141, 16);
            this.Label10.TabIndex = 15;
            this.Label10.Text = "Logo (nur Ent.-Edition):";
            //
            //btnTextBodyAndTableBodyFont
            //
            this.btnTextBodyAndTableBodyFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnTextBodyAndTableBodyFont.Location = new System.Drawing.Point(521, 146);
            this.btnTextBodyAndTableBodyFont.Name = "btnTextBodyAndTableBodyFont";
            this.btnTextBodyAndTableBodyFont.Size = new System.Drawing.Size(22, 19);
            this.btnTextBodyAndTableBodyFont.TabIndex = 14;
            this.btnTextBodyAndTableBodyFont.Text = "...";
            //
            //lblTextAndTableBodyFont
            //
            this.lblTextAndTableBodyFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTextAndTableBodyFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblTextAndTableBodyFont.Location = new System.Drawing.Point(175, 147);
            this.lblTextAndTableBodyFont.Name = "lblTextAndTableBodyFont";
            this.lblTextAndTableBodyFont.Size = new System.Drawing.Size(340, 20);
            this.lblTextAndTableBodyFont.TabIndex = 13;
            this.lblTextAndTableBodyFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label9
            //
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label9.Location = new System.Drawing.Point(10, 149);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(162, 16);
            this.Label9.TabIndex = 12;
            this.Label9.Text = "Text- und Tabellenk�rper:";
            //
            //btnTableHeaderFont
            //
            this.btnTableHeaderFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnTableHeaderFont.Location = new System.Drawing.Point(521, 117);
            this.btnTableHeaderFont.Name = "btnTableHeaderFont";
            this.btnTableHeaderFont.Size = new System.Drawing.Size(22, 19);
            this.btnTableHeaderFont.TabIndex = 11;
            this.btnTableHeaderFont.Text = "...";
            //
            //lblTableHeaderFont
            //
            this.lblTableHeaderFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTableHeaderFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblTableHeaderFont.Location = new System.Drawing.Point(175, 116);
            this.lblTableHeaderFont.Name = "lblTableHeaderFont";
            this.lblTableHeaderFont.Size = new System.Drawing.Size(340, 20);
            this.lblTableHeaderFont.TabIndex = 10;
            this.lblTableHeaderFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label7
            //
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label7.Location = new System.Drawing.Point(10, 118);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(99, 16);
            this.Label7.TabIndex = 9;
            this.Label7.Text = "Tabellenk�pfe:";
            //
            //btnU3Font
            //
            this.btnU3Font.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnU3Font.Location = new System.Drawing.Point(521, 88);
            this.btnU3Font.Name = "btnU3Font";
            this.btnU3Font.Size = new System.Drawing.Size(22, 19);
            this.btnU3Font.TabIndex = 8;
            this.btnU3Font.Text = "...";
            //
            //lblFontU3
            //
            this.lblFontU3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFontU3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblFontU3.Location = new System.Drawing.Point(175, 88);
            this.lblFontU3.Name = "lblFontU3";
            this.lblFontU3.Size = new System.Drawing.Size(340, 20);
            this.lblFontU3.TabIndex = 7;
            this.lblFontU3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label5
            //
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label5.Location = new System.Drawing.Point(10, 90);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(128, 16);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "�berschrift Ebene &3:";
            //
            //btnU2Font
            //
            this.btnU2Font.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnU2Font.Location = new System.Drawing.Point(521, 58);
            this.btnU2Font.Name = "btnU2Font";
            this.btnU2Font.Size = new System.Drawing.Size(22, 19);
            this.btnU2Font.TabIndex = 5;
            this.btnU2Font.Text = "...";
            //
            //lblFontU2
            //
            this.lblFontU2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFontU2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblFontU2.Location = new System.Drawing.Point(175, 58);
            this.lblFontU2.Name = "lblFontU2";
            this.lblFontU2.Size = new System.Drawing.Size(340, 20);
            this.lblFontU2.TabIndex = 4;
            this.lblFontU2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label3
            //
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label3.Location = new System.Drawing.Point(10, 60);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(128, 16);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "�berschrift Ebene &2:";
            //
            //btnU1Font
            //
            this.btnU1Font.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnU1Font.Location = new System.Drawing.Point(521, 29);
            this.btnU1Font.Name = "btnU1Font";
            this.btnU1Font.Size = new System.Drawing.Size(22, 19);
            this.btnU1Font.TabIndex = 2;
            this.btnU1Font.Text = "...";
            //
            //lblFontU1
            //
            this.lblFontU1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFontU1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblFontU1.Location = new System.Drawing.Point(175, 29);
            this.lblFontU1.Name = "lblFontU1";
            this.lblFontU1.Size = new System.Drawing.Size(340, 20);
            this.lblFontU1.TabIndex = 1;
            this.lblFontU1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label1.Location = new System.Drawing.Point(10, 31);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(128, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "�berschrift Ebene 1:";
            //
            //tpThresholdValues
            //
            this.tpThresholdValues.Controls.Add(this.GroupBox8);
            this.tpThresholdValues.Controls.Add(this.GroupBox7);
            this.tpThresholdValues.Location = new System.Drawing.Point(4, 25);
            this.tpThresholdValues.Name = "tpThresholdValues";
            this.tpThresholdValues.Padding = new System.Windows.Forms.Padding(3);
            this.tpThresholdValues.Size = new System.Drawing.Size(606, 526);
            this.tpThresholdValues.TabIndex = 3;
            this.tpThresholdValues.Text = "Daten�bernahme-Optionen";
            this.tpThresholdValues.UseVisualStyleBackColor = true;
            //
            //GroupBox7
            //
            this.GroupBox7.Controls.Add(this.nibThresholdFirstShift);
            this.GroupBox7.Controls.Add(this.Label8);
            this.GroupBox7.Controls.Add(this.dtbFallBackTimeEnd);
            this.GroupBox7.Controls.Add(this.dtbFallBackTimeStart);
            this.GroupBox7.Location = new System.Drawing.Point(23, 28);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(546, 169);
            this.GroupBox7.TabIndex = 1;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Fallback-Times (f�r die Schichtzuweisung von Zeit�bernahmedaten)";
            //
            //nibThresholdFirstShift
            //
            this.nibThresholdFirstShift.BackColor = System.Drawing.SystemColors.Window;
            this.nibThresholdFirstShift.CaptionToValueRatio = 700.35;
            this.nibThresholdFirstShift.ColorOnFocus = true;
            this.nibThresholdFirstShift.FailedValidationErrorMessage = null;
            this.nibThresholdFirstShift.FormularText = "";
            this.nibThresholdFirstShift.HasCaption = true;
            this.nibThresholdFirstShift.IndependentDatafieldName = null;
            this.nibThresholdFirstShift.Location = new System.Drawing.Point(16, 112);
            this.nibThresholdFirstShift.MaxValue = 0;
            this.nibThresholdFirstShift.MinValue = 0;
            this.nibThresholdFirstShift.Name = "nibThresholdFirstShift";
            this.nibThresholdFirstShift.NullString = "* --- *";
            this.nibThresholdFirstShift.NullValueMessage = "Bitte geben Sie einen Wert f�r die Schwelle zur ersten Schicht in Minuten ein.";
            this.nibThresholdFirstShift.Size = new System.Drawing.Size(287, 22);
            this.nibThresholdFirstShift.TabIndex = 4;
            this.nibThresholdFirstShift.Text = "Schwellwert 1. Schicht (min):";
            this.nibThresholdFirstShift.ValueAreaLength = 86;
            //
            //Label8
            //
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label8.Location = new System.Drawing.Point(339, 29);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(181, 88);
            this.Label8.TabIndex = 3;
            this.Label8.Text = "HINWEIS: Diese Werte bestimmen Sie f�r die Unter-/Obergrenze der ersten Schicht, " + "damit beim Rauslaufen von �bernahmedaten aus einem Schichtmodell eine Zuweisung " + "dennoch m�glich wird.";
            //
            //dtbFallBackTimeEnd
            //
            this.dtbFallBackTimeEnd.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.dtbFallBackTimeEnd.BackColor = System.Drawing.SystemColors.Window;
            this.dtbFallBackTimeEnd.CaptionToValueRatio = 700.35;
            this.dtbFallBackTimeEnd.ColorOnFocus = true;
            this.dtbFallBackTimeEnd.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.dtbFallBackTimeEnd.FailedValidationErrorMessage = null;
            this.dtbFallBackTimeEnd.HasCaption = true;
            this.dtbFallBackTimeEnd.IndependentDatafieldName = null;
            this.dtbFallBackTimeEnd.Location = new System.Drawing.Point(16, 70);
            this.dtbFallBackTimeEnd.Name = "dtbFallBackTimeEnd";
            this.dtbFallBackTimeEnd.NullString = "* --- *";
            this.dtbFallBackTimeEnd.NullValueMessage = "Bitte bestimmen Sie die Fallback-Ende-Zeit.";
            this.dtbFallBackTimeEnd.Size = new System.Drawing.Size(287, 22);
            this.dtbFallBackTimeEnd.TabIndex = 1;
            this.dtbFallBackTimeEnd.Text = "Fallback Time (Ende):";
            this.dtbFallBackTimeEnd.ValueAreaLength = 86;
            //
            //dtbFallBackTimeStart
            //
            this.dtbFallBackTimeStart.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.dtbFallBackTimeStart.BackColor = System.Drawing.SystemColors.Window;
            this.dtbFallBackTimeStart.CaptionToValueRatio = 700.35;
            this.dtbFallBackTimeStart.ColorOnFocus = true;
            this.dtbFallBackTimeStart.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.dtbFallBackTimeStart.FailedValidationErrorMessage = null;
            this.dtbFallBackTimeStart.HasCaption = true;
            this.dtbFallBackTimeStart.IndependentDatafieldName = null;
            this.dtbFallBackTimeStart.Location = new System.Drawing.Point(16, 29);
            this.dtbFallBackTimeStart.Name = "dtbFallBackTimeStart";
            this.dtbFallBackTimeStart.NullString = "* --- *";
            this.dtbFallBackTimeStart.NullValueMessage = "Bitte bestimmen Sie die Fallback-Start-Zeit.";
            this.dtbFallBackTimeStart.Size = new System.Drawing.Size(287, 22);
            this.dtbFallBackTimeStart.TabIndex = 0;
            this.dtbFallBackTimeStart.Text = "Fallback Time (Start):";
            this.dtbFallBackTimeStart.ValueAreaLength = 86;
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(401, 580);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(109, 33);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(516, 580);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            //
            //GroupBox8
            //
            this.GroupBox8.Controls.Add(this.Label15);
            this.GroupBox8.Controls.Add(this.chkShowIssueListPriorToImport);
            this.GroupBox8.Controls.Add(this.chkShowTimeLogPriorToImport);
            this.GroupBox8.Location = new System.Drawing.Point(23, 218);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(546, 169);
            this.GroupBox8.TabIndex = 2;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Optionen bei der Zeiten�bernahme:";
            //
            //chkShowTimeLogPriorToImport
            //
            this.chkShowTimeLogPriorToImport.AutoSize = true;
            this.chkShowTimeLogPriorToImport.Location = new System.Drawing.Point(16, 41);
            this.chkShowTimeLogPriorToImport.Name = "chkShowTimeLogPriorToImport";
            this.chkShowTimeLogPriorToImport.Size = new System.Drawing.Size(299, 20);
            this.chkShowTimeLogPriorToImport.TabIndex = 4;
            this.chkShowTimeLogPriorToImport.Text = "Ergebnistabelle vor der �bernahme anzeigen";
            this.chkShowTimeLogPriorToImport.UseVisualStyleBackColor = true;
            //
            //chkShowIssueListPriorToImport
            //
            this.chkShowIssueListPriorToImport.AutoSize = true;
            this.chkShowIssueListPriorToImport.Location = new System.Drawing.Point(16, 67);
            this.chkShowIssueListPriorToImport.Name = "chkShowIssueListPriorToImport";
            this.chkShowIssueListPriorToImport.Size = new System.Drawing.Size(266, 20);
            this.chkShowIssueListPriorToImport.TabIndex = 5;
            this.chkShowIssueListPriorToImport.Text = "Fehlerliste vor der �bernahme anzeigen";
            this.chkShowIssueListPriorToImport.UseVisualStyleBackColor = true;
            //
            //Label15
            //
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label15.Location = new System.Drawing.Point(339, 29);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(181, 88);
            this.Label15.TabIndex = 6;
            this.Label15.Text = "HINWEIS: Diese Einstellungen beziehen sich nur auf die �bernahme von Zeitdaten au" + "s Fremdsystemen (Legatro, Interflex, etc.)";
            //
            //frmOptions
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 636);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Optionen";
            this.tcMain.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.tpTimeSettingDefaults.ResumeLayout(false);
            this.tpLayoutAndNumberformats.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbxLogo).EndInit();
            this.tpThresholdValues.ResumeLayout(false);
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.TabControl tcMain;
        internal System.Windows.Forms.TabPage tpTimeSettingDefaults;
        internal System.Windows.Forms.TabPage tpLayoutAndNumberformats;
        private System.Windows.Forms.Button _btnOK;
        internal System.Windows.Forms.Button btnOK
        {
            get
            {
                return _btnOK;
            }

            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnCancel;
        internal System.Windows.Forms.Button btnCancel
        {
            get
            {
                return _btnCancel;
            }

            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        internal Facesso.GenericControls.ucTimeDetailsSettings UcTimeDetailsSettings;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button _btnU1Font;
        internal System.Windows.Forms.Button btnU1Font
        {
            get
            {
                return _btnU1Font;
            }

            set
            {
                if (_btnU1Font != null)
                {
                    _btnU1Font.Click -= HandleFontButtons;
                }

                _btnU1Font = value;
                if (_btnU1Font != null)
                {
                    _btnU1Font.Click += HandleFontButtons;
                }
            }
        }

        internal System.Windows.Forms.Label lblFontU1;
        private System.Windows.Forms.Button _btnTextBodyAndTableBodyFont;
        internal System.Windows.Forms.Button btnTextBodyAndTableBodyFont
        {
            get
            {
                return _btnTextBodyAndTableBodyFont;
            }

            set
            {
                if (_btnTextBodyAndTableBodyFont != null)
                {
                    _btnTextBodyAndTableBodyFont.Click -= HandleFontButtons;
                }

                _btnTextBodyAndTableBodyFont = value;
                if (_btnTextBodyAndTableBodyFont != null)
                {
                    _btnTextBodyAndTableBodyFont.Click += HandleFontButtons;
                }
            }
        }

        internal System.Windows.Forms.Label lblTextAndTableBodyFont;
        internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Button _btnTableHeaderFont;
        internal System.Windows.Forms.Button btnTableHeaderFont
        {
            get
            {
                return _btnTableHeaderFont;
            }

            set
            {
                if (_btnTableHeaderFont != null)
                {
                    _btnTableHeaderFont.Click -= HandleFontButtons;
                }

                _btnTableHeaderFont = value;
                if (_btnTableHeaderFont != null)
                {
                    _btnTableHeaderFont.Click += HandleFontButtons;
                }
            }
        }

        internal System.Windows.Forms.Label lblTableHeaderFont;
        internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Button _btnU3Font;
        internal System.Windows.Forms.Button btnU3Font
        {
            get
            {
                return _btnU3Font;
            }

            set
            {
                if (_btnU3Font != null)
                {
                    _btnU3Font.Click -= HandleFontButtons;
                }

                _btnU3Font = value;
                if (_btnU3Font != null)
                {
                    _btnU3Font.Click += HandleFontButtons;
                }
            }
        }

        internal System.Windows.Forms.Label lblFontU3;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Button _btnU2Font;
        internal System.Windows.Forms.Button btnU2Font
        {
            get
            {
                return _btnU2Font;
            }

            set
            {
                if (_btnU2Font != null)
                {
                    _btnU2Font.Click -= HandleFontButtons;
                }

                _btnU2Font = value;
                if (_btnU2Font != null)
                {
                    _btnU2Font.Click += HandleFontButtons;
                }
            }
        }

        internal System.Windows.Forms.Label lblFontU2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Button btnLogo;
        internal System.Windows.Forms.PictureBox pbxLogo;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label12;
        private System.Windows.Forms.ComboBox _cmbHMinutesPrecision;
        internal System.Windows.Forms.ComboBox cmbHMinutesPrecision
        {
            get
            {
                return _cmbHMinutesPrecision;
            }

            set
            {
                if (_cmbHMinutesPrecision != null)
                {
                    _cmbHMinutesPrecision.SelectedIndexChanged -= cmbHMinutesPrecision_SelectedIndexChanged;
                }

                _cmbHMinutesPrecision = value;
                if (_cmbHMinutesPrecision != null)
                {
                    _cmbHMinutesPrecision.SelectedIndexChanged += cmbHMinutesPrecision_SelectedIndexChanged;
                }
            }
        }

        internal System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.ComboBox _cmbGridStyle;
        internal System.Windows.Forms.ComboBox cmbGridStyle
        {
            get
            {
                return _cmbGridStyle;
            }

            set
            {
                if (_cmbGridStyle != null)
                {
                    _cmbGridStyle.SelectedIndexChanged -= cmbGridStyle_SelectedIndexChanged;
                }

                _cmbGridStyle = value;
                if (_cmbGridStyle != null)
                {
                    _cmbGridStyle.SelectedIndexChanged += cmbGridStyle_SelectedIndexChanged;
                }
            }
        }

        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Button btnPreView;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TabPage tpGeneral;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.CheckBox chkSundayIsWorkday;
        internal System.Windows.Forms.CheckBox chkSaturdayIsWorkday;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.CheckBox chkAutomateMainFormUpdate;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Button btnChooseSqlConnectionString;
        internal System.Windows.Forms.TextBox txtSQLLoginString;
        internal System.Windows.Forms.Label Label17;
        internal Facesso.ucFacessoPathSettings FacessoPathSettings;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Button _btnAssignToWorkgroups;
        internal System.Windows.Forms.Button btnAssignToWorkgroups
        {
            get
            {
                return _btnAssignToWorkgroups;
            }

            set
            {
                if (_btnAssignToWorkgroups != null)
                {
                    _btnAssignToWorkgroups.Click -= btnAssignToWorkgroups_Click;
                }

                _btnAssignToWorkgroups = value;
                if (_btnAssignToWorkgroups != null)
                {
                    _btnAssignToWorkgroups.Click += btnAssignToWorkgroups_Click;
                }
            }
        }

        internal System.Windows.Forms.TabPage tpThresholdValues;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal ActiveDev.Controls.ADNullableDateTimeBox dtbFallBackTimeStart;
        internal ActiveDev.Controls.ADNullableDateTimeBox dtbFallBackTimeEnd;
        internal System.Windows.Forms.Label Label8;
        internal ActiveDev.Controls.ADNullableIntBox nibThresholdFirstShift;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.CheckBox chkShowIssueListPriorToImport;
        internal System.Windows.Forms.CheckBox chkShowTimeLogPriorToImport;
        internal System.Windows.Forms.Label Label15;
    }
}
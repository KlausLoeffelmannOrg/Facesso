namespace Facesso
{
    partial class frmSetupWizard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupWizard));
            this.tcWizard = new System.Windows.Forms.TabControl();
            this.TabBase = new System.Windows.Forms.TabPage();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Tab2SerialNo = new System.Windows.Forms.TabPage();
            this.imgCheckSerialNo = new System.Windows.Forms.PictureBox();
            this.lblSerialNoValid = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.mtbSerialNo = new System.Windows.Forms.MaskedTextBox();
            this.Label39 = new System.Windows.Forms.Label();
            this.lblPreSerialNo = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Tab3DBConn = new System.Windows.Forms.TabPage();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.btnPickConnection = new System.Windows.Forms.Button();
            this.optNamedInstance = new System.Windows.Forms.RadioButton();
            this.optDefaultInstance = new System.Windows.Forms.RadioButton();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.Label24 = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.Tab4CompanyData = new System.Windows.Forms.TabPage();
            this.txtPrimaryPhone = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnTData = new System.Windows.Forms.Button();
            this.txtCountryCode = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.Label42 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.Label41 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.Label40 = new System.Windows.Forms.Label();
            this.txtSubsidiaryName = new System.Windows.Forms.TextBox();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Tab5AdminPassword = new System.Windows.Forms.TabPage();
            this.txtPasswordRepetition = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Tab6DataConversion = new System.Windows.Forms.TabPage();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label26 = new System.Windows.Forms.Label();
            this.Label27 = new System.Windows.Forms.Label();
            this.Tab8Finalize = new System.Windows.Forms.TabPage();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label34 = new System.Windows.Forms.Label();
            this.Label33 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SerialDialogTooltips = new System.Windows.Forms.ToolTip(this.components);
            this.FacessoPathSettings = new Facesso.ucFacessoPathSettings();
            this.tcWizard.SuspendLayout();
            this.TabBase.SuspendLayout();
            this.Tab2SerialNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCheckSerialNo)).BeginInit();
            this.Tab3DBConn.SuspendLayout();
            this.Tab4CompanyData.SuspendLayout();
            this.Tab5AdminPassword.SuspendLayout();
            this.Tab6DataConversion.SuspendLayout();
            this.Tab8Finalize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();

            this.tcWizard.Controls.Add(this.TabBase);
            this.tcWizard.Controls.Add(this.Tab2SerialNo);
            this.tcWizard.Controls.Add(this.Tab3DBConn);
            this.tcWizard.Controls.Add(this.Tab4CompanyData);
            this.tcWizard.Controls.Add(this.Tab5AdminPassword);
            this.tcWizard.Controls.Add(this.Tab6DataConversion);
            this.tcWizard.Controls.Add(this.Tab8Finalize);
            this.tcWizard.Location = new System.Drawing.Point(151, -23);
            this.tcWizard.Name = "tcWizard";
            this.tcWizard.SelectedIndex = 0;
            this.tcWizard.Size = new System.Drawing.Size(570, 400);
            this.tcWizard.TabIndex = 0;

            this.TabBase.Controls.Add(this.Label14);
            this.TabBase.Controls.Add(this.Label12);
            this.TabBase.Controls.Add(this.Label11);
            this.TabBase.Controls.Add(this.Label10);
            this.TabBase.Controls.Add(this.Label9);
            this.TabBase.Controls.Add(this.Label8);
            this.TabBase.Controls.Add(this.Label4);
            this.TabBase.Controls.Add(this.Label3);
            this.TabBase.Controls.Add(this.Label2);
            this.TabBase.Location = new System.Drawing.Point(4, 22);
            this.TabBase.Name = "TabBase";
            this.TabBase.Padding = new System.Windows.Forms.Padding(3);
            this.TabBase.Size = new System.Drawing.Size(562, 374);
            this.TabBase.TabIndex = 0;
            this.TabBase.Text = "Basis";

            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(47, 120);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(175, 13);
            this.Label14.TabIndex = 3;
            this.Label14.Text = "* Die Seriennummer des Programms";

            this.Label12.Location = new System.Drawing.Point(47, 281);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(438, 32);
            this.Label12.TabIndex = 8;
            this.Label12.Text = "Klicken Sie jeweils auf die Schaltfläche [Weiter >], wenn Sie einen Schritt des Assistenten abgeschlossen haben.";

            this.Label11.Location = new System.Drawing.Point(50, 211);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(403, 70);
            this.Label11.TabIndex = 7;
            this.Label11.Text = "(Falls Sie bereits Prämienlohnabrechnungen mit Mitbewerberprodukten ermittelt haben, versucht Facesso das Datenformat zu erkennen und die Daten in die Facesso-Datenbank zu importieren.)";

            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(50, 187);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(331, 13);
            this.Label10.TabIndex = 6;
            this.Label10.Text = "* Den Speicherort einer bereits vorhandenen Access-Datei (Optional)";

            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(47, 143);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(136, 13);
            this.Label9.TabIndex = 4;
            this.Label9.Text = "* Ein Administratorkennwort";

            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(47, 165);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(349, 13);
            this.Label8.TabIndex = 5;
            this.Label8.Text = "* Die Adresse der Hauptfilliale Ihres Unternehmens oder des Stammsitzes";

            this.Label4.Location = new System.Drawing.Point(50, 82);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(441, 51);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Während der nächsten Schritte, fragt Sie dieser Assistent bestimmte Informationen ab, die Facesso als Mindestvoraussetzung zum Funktionieren benötigt. Dazu gehören:";

            this.Label3.Location = new System.Drawing.Point(50, 43);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(438, 39);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Dieser Assistent hilft Ihnen, Facesso für den aller ersten Start auf diesem System vorzubereiten und das Datenbanksystem zu konfigurieren.";

            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label2.Location = new System.Drawing.Point(50, 15);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(393, 16);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Willkommen zum Einrichtungs-Assistenten von Facesso!";

            this.Tab2SerialNo.Controls.Add(this.imgCheckSerialNo);
            this.Tab2SerialNo.Controls.Add(this.lblSerialNoValid);
            this.Tab2SerialNo.Controls.Add(this.Label1);
            this.Tab2SerialNo.Controls.Add(this.Label5);
            this.Tab2SerialNo.Controls.Add(this.mtbSerialNo);
            this.Tab2SerialNo.Controls.Add(this.Label39);
            this.Tab2SerialNo.Controls.Add(this.lblPreSerialNo);
            this.Tab2SerialNo.Controls.Add(this.Label17);
            this.Tab2SerialNo.Controls.Add(this.Label13);
            this.Tab2SerialNo.Controls.Add(this.Label15);
            this.Tab2SerialNo.Controls.Add(this.Label16);
            this.Tab2SerialNo.Location = new System.Drawing.Point(4, 22);
            this.Tab2SerialNo.Name = "Tab2SerialNo";
            this.Tab2SerialNo.Padding = new System.Windows.Forms.Padding(3);
            this.Tab2SerialNo.Size = new System.Drawing.Size(562, 374);
            this.Tab2SerialNo.TabIndex = 1;
            this.Tab2SerialNo.Text = "SerialNo";

            this.imgCheckSerialNo.Image = global::Facesso.My.Resources.Resources.Keyboard_Error;
            this.imgCheckSerialNo.Location = new System.Drawing.Point(462, 256);
            this.imgCheckSerialNo.Name = "imgCheckSerialNo";
            this.imgCheckSerialNo.Size = new System.Drawing.Size(84, 77);
            this.imgCheckSerialNo.TabIndex = 11;
            this.imgCheckSerialNo.TabStop = false;

            this.lblSerialNoValid.Location = new System.Drawing.Point(28, 237);
            this.lblSerialNoValid.Name = "lblSerialNoValid";
            this.lblSerialNoValid.Size = new System.Drawing.Size(514, 16);
            this.lblSerialNoValid.TabIndex = 10;
            this.lblSerialNoValid.Text = "Die eingegebene Seriennummer ist nicht gültig; eine Demo-Version wird - so noch möglich - freigeschaltet.";

            this.Label1.AutoSize = true;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label1.Location = new System.Drawing.Point(309, 137);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(228, 26);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "(+49 | 0) 29 41/91 09 07";

            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label5.Location = new System.Drawing.Point(307, 117);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(199, 16);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Telefonische Registrierung:";

            this.mtbSerialNo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbSerialNo.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.mtbSerialNo.HideSelection = false;
            this.mtbSerialNo.Location = new System.Drawing.Point(31, 208);
            this.mtbSerialNo.Mask = ">AAAAA - AAAAA - AAAAA - AAAAA - AAAAA - AAAAA";
            this.mtbSerialNo.Name = "mtbSerialNo";
            this.mtbSerialNo.Size = new System.Drawing.Size(518, 26);
            this.mtbSerialNo.TabIndex = 5;
            this.mtbSerialNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbSerialNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbSerialNo.TextChanged += new System.EventHandler(this.mtbSerialNo_TextChanged);

            this.Label39.AutoSize = true;
            this.Label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label39.Location = new System.Drawing.Point(29, 186);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(277, 16);
            this.Label39.TabIndex = 4;
            this.Label39.Text = "Geben Sie hier den Freischaltcode ein:";

            this.lblPreSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreSerialNo.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblPreSerialNo.Location = new System.Drawing.Point(34, 140);
            this.lblPreSerialNo.Name = "lblPreSerialNo";
            this.lblPreSerialNo.Size = new System.Drawing.Size(263, 23);
            this.lblPreSerialNo.TabIndex = 3;
            this.lblPreSerialNo.Text = "12345 - 12345 - 12345";
            this.lblPreSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label17.Location = new System.Drawing.Point(32, 117);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(254, 16);
            this.Label17.TabIndex = 2;
            this.Label17.Text = "Die individuelle Kennnummer lautet:";

            this.Label13.Location = new System.Drawing.Point(29, 268);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(390, 69);
            this.Label13.TabIndex = 6;
            this.Label13.Text = resources.GetString("Label13.Text");

            this.Label15.Location = new System.Drawing.Point(28, 39);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(480, 60);
            this.Label15.TabIndex = 1;
            this.Label15.Text = resources.GetString("Label15.Text");

            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label16.Location = new System.Drawing.Point(28, 15);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(278, 16);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "Schritt 1: Eingabe des Freischaltcodes:";

            this.Tab3DBConn.Controls.Add(this.txtConnectionString);
            this.Tab3DBConn.Controls.Add(this.Label7);
            this.Tab3DBConn.Controls.Add(this.btnPickConnection);
            this.Tab3DBConn.Controls.Add(this.optNamedInstance);
            this.Tab3DBConn.Controls.Add(this.optDefaultInstance);
            this.Tab3DBConn.Controls.Add(this.btnTestConnection);
            this.Tab3DBConn.Controls.Add(this.Label24);
            this.Tab3DBConn.Controls.Add(this.Label25);
            this.Tab3DBConn.Location = new System.Drawing.Point(4, 22);
            this.Tab3DBConn.Name = "Tab3DBConn";
            this.Tab3DBConn.Padding = new System.Windows.Forms.Padding(3);
            this.Tab3DBConn.Size = new System.Drawing.Size(562, 374);
            this.Tab3DBConn.TabIndex = 2;
            this.Tab3DBConn.Text = "DBConn";

            this.txtConnectionString.Location = new System.Drawing.Point(74, 273);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ReadOnly = true;
            this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnectionString.Size = new System.Drawing.Size(339, 88);
            this.txtConnectionString.TabIndex = 8;

            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(71, 257);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(284, 13);
            this.Label7.TabIndex = 7;
            this.Label7.Text = "&Verbindungszeichenfolge für SQL-Datenbank-Verbindung::";

            this.btnPickConnection.Enabled = false;
            this.btnPickConnection.Location = new System.Drawing.Point(429, 218);
            this.btnPickConnection.Name = "btnPickConnection";
            this.btnPickConnection.Size = new System.Drawing.Size(120, 32);
            this.btnPickConnection.TabIndex = 6;
            this.btnPickConnection.Text = "&Verbindung wählen...";
            this.btnPickConnection.UseVisualStyleBackColor = true;
            this.btnPickConnection.Click += new System.EventHandler(this.btnPickConnection_Click);

            this.optNamedInstance.AutoSize = true;
            this.optNamedInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.optNamedInstance.Location = new System.Drawing.Point(54, 224);
            this.optNamedInstance.Name = "optNamedInstance";
            this.optNamedInstance.Size = new System.Drawing.Size(301, 20);
            this.optNamedInstance.TabIndex = 5;
            this.optNamedInstance.Text = "SQL-Serverinstanz und &Datenbank auswählen:";
            this.optNamedInstance.CheckedChanged += new System.EventHandler(this.optNamedInstance_CheckedChanged);

            this.optDefaultInstance.AutoSize = true;
            this.optDefaultInstance.Checked = true;
            this.optDefaultInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.optDefaultInstance.Location = new System.Drawing.Point(54, 192);
            this.optDefaultInstance.Name = "optDefaultInstance";
            this.optDefaultInstance.Size = new System.Drawing.Size(291, 20);
            this.optDefaultInstance.TabIndex = 4;
            this.optDefaultInstance.TabStop = true;
            this.optDefaultInstance.Text = @"&Standardinstanz: (.\SQLEXPRESS; Facesso)";

            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnTestConnection.Location = new System.Drawing.Point(429, 333);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(120, 29);
            this.btnTestConnection.TabIndex = 3;
            this.btnTestConnection.Text = "Verbindung &testen...";
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);

            this.Label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label24.Location = new System.Drawing.Point(53, 42);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(496, 137);
            this.Label24.TabIndex = 1;
            this.Label24.Text = resources.GetString("Label24.Text");

            this.Label25.AutoSize = true;
            this.Label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label25.Location = new System.Drawing.Point(50, 15);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(245, 16);
            this.Label25.TabIndex = 0;
            this.Label25.Text = "Schritt 2: Verbinden zur Datenbank";

            this.Tab4CompanyData.Controls.Add(this.txtPrimaryPhone);
            this.Tab4CompanyData.Controls.Add(this.Label6);
            this.Tab4CompanyData.Controls.Add(this.btnTData);
            this.Tab4CompanyData.Controls.Add(this.txtCountryCode);
            this.Tab4CompanyData.Controls.Add(this.txtCountry);
            this.Tab4CompanyData.Controls.Add(this.Label42);
            this.Tab4CompanyData.Controls.Add(this.txtZip);
            this.Tab4CompanyData.Controls.Add(this.txtCity);
            this.Tab4CompanyData.Controls.Add(this.Label41);
            this.Tab4CompanyData.Controls.Add(this.txtStreet);
            this.Tab4CompanyData.Controls.Add(this.Label40);
            this.Tab4CompanyData.Controls.Add(this.txtSubsidiaryName);
            this.Tab4CompanyData.Controls.Add(this.Label38);
            this.Tab4CompanyData.Controls.Add(this.Label36);
            this.Tab4CompanyData.Controls.Add(this.Label37);
            this.Tab4CompanyData.Location = new System.Drawing.Point(4, 22);
            this.Tab4CompanyData.Name = "Tab4CompanyData";
            this.Tab4CompanyData.Padding = new System.Windows.Forms.Padding(3);
            this.Tab4CompanyData.Size = new System.Drawing.Size(562, 374);
            this.Tab4CompanyData.TabIndex = 7;
            this.Tab4CompanyData.Text = "CompData";

            this.txtPrimaryPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtPrimaryPhone.Location = new System.Drawing.Point(220, 275);
            this.txtPrimaryPhone.MaxLength = 100;
            this.txtPrimaryPhone.Name = "txtPrimaryPhone";
            this.txtPrimaryPhone.Size = new System.Drawing.Size(314, 22);
            this.txtPrimaryPhone.TabIndex = 13;
            this.txtPrimaryPhone.TextChanged += new System.EventHandler(this.txtSS_Name_TextChanged);

            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label6.Location = new System.Drawing.Point(51, 278);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(155, 16);
            this.Label6.TabIndex = 12;
            this.Label6.Text = "Primäre Telefonnummer:";

            this.btnTData.Location = new System.Drawing.Point(432, 142);
            this.btnTData.Name = "btnTData";
            this.btnTData.Size = new System.Drawing.Size(102, 19);
            this.btnTData.TabIndex = 14;
            this.btnTData.Text = "Testdaten";
            this.btnTData.Click += new System.EventHandler(this.btnTData_Click);

            this.txtCountryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtCountryCode.Location = new System.Drawing.Point(220, 247);
            this.txtCountryCode.MaxLength = 10;
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.Size = new System.Drawing.Size(85, 22);
            this.txtCountryCode.TabIndex = 10;
            this.txtCountryCode.TextChanged += new System.EventHandler(this.txtSS_Name_TextChanged);

            this.txtCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtCountry.Location = new System.Drawing.Point(312, 247);
            this.txtCountry.MaxLength = 100;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(222, 22);
            this.txtCountry.TabIndex = 11;
            this.txtCountry.TextChanged += new System.EventHandler(this.txtSS_Name_TextChanged);

            this.Label42.AutoSize = true;
            this.Label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label42.Location = new System.Drawing.Point(68, 250);
            this.Label42.Name = "Label42";
            this.Label42.Size = new System.Drawing.Size(138, 16);
            this.Label42.TabIndex = 9;
            this.Label42.Text = "Länderkennung/Land:";

            this.txtZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtZip.Location = new System.Drawing.Point(220, 221);
            this.txtZip.MaxLength = 10;
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(85, 22);
            this.txtZip.TabIndex = 7;
            this.txtZip.TextChanged += new System.EventHandler(this.txtSS_Name_TextChanged);

            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtCity.Location = new System.Drawing.Point(312, 221);
            this.txtCity.MaxLength = 100;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(222, 22);
            this.txtCity.TabIndex = 8;
            this.txtCity.TextChanged += new System.EventHandler(this.txtSS_Name_TextChanged);

            this.Label41.AutoSize = true;
            this.Label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label41.Location = new System.Drawing.Point(150, 221);
            this.Label41.Name = "Label41";
            this.Label41.Size = new System.Drawing.Size(56, 16);
            this.Label41.TabIndex = 6;
            this.Label41.Text = "PLZ/Ort:";

            this.txtStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtStreet.Location = new System.Drawing.Point(220, 195);
            this.txtStreet.MaxLength = 100;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(314, 22);
            this.txtStreet.TabIndex = 5;
            this.txtStreet.TextChanged += new System.EventHandler(this.txtSS_Name_TextChanged);

            this.Label40.AutoSize = true;
            this.Label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label40.Location = new System.Drawing.Point(155, 198);
            this.Label40.Name = "Label40";
            this.Label40.Size = new System.Drawing.Size(51, 16);
            this.Label40.TabIndex = 4;
            this.Label40.Text = "Straße:";

            this.txtSubsidiaryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtSubsidiaryName.Location = new System.Drawing.Point(220, 167);
            this.txtSubsidiaryName.MaxLength = 100;
            this.txtSubsidiaryName.Name = "txtSubsidiaryName";
            this.txtSubsidiaryName.Size = new System.Drawing.Size(314, 22);
            this.txtSubsidiaryName.TabIndex = 3;
            this.txtSubsidiaryName.TextChanged += new System.EventHandler(this.txtSS_Name_TextChanged);

            this.Label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label38.Location = new System.Drawing.Point(54, 152);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(148, 36);
            this.Label38.TabIndex = 2;
            this.Label38.Text = "Unternehmensname (Hauptsitz/Hauptfiliale):";
            this.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label36.Location = new System.Drawing.Point(50, 41);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(504, 70);
            this.Label36.TabIndex = 1;
            this.Label36.Text = resources.GetString("Label36.Text");

            this.Label37.AutoSize = true;
            this.Label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label37.Location = new System.Drawing.Point(50, 15);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(298, 16);
            this.Label37.TabIndex = 0;
            this.Label37.Text = "Schritt 3: Eingabe der Unternehmensdaten";

            this.Tab5AdminPassword.Controls.Add(this.txtPasswordRepetition);
            this.Tab5AdminPassword.Controls.Add(this.txtPassword);
            this.Tab5AdminPassword.Controls.Add(this.Label23);
            this.Tab5AdminPassword.Controls.Add(this.Label22);
            this.Tab5AdminPassword.Controls.Add(this.Label21);
            this.Tab5AdminPassword.Controls.Add(this.Label19);
            this.Tab5AdminPassword.Controls.Add(this.Label20);
            this.Tab5AdminPassword.Location = new System.Drawing.Point(4, 22);
            this.Tab5AdminPassword.Name = "Tab5AdminPassword";
            this.Tab5AdminPassword.Padding = new System.Windows.Forms.Padding(3);
            this.Tab5AdminPassword.Size = new System.Drawing.Size(562, 374);
            this.Tab5AdminPassword.TabIndex = 3;
            this.Tab5AdminPassword.Text = "AdminPassword";

            this.txtPasswordRepetition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtPasswordRepetition.Location = new System.Drawing.Point(243, 209);
            this.txtPasswordRepetition.MaxLength = 25;
            this.txtPasswordRepetition.Name = "txtPasswordRepetition";
            this.txtPasswordRepetition.PasswordChar = (char)42;
            this.txtPasswordRepetition.Size = new System.Drawing.Size(192, 22);
            this.txtPasswordRepetition.TabIndex = 5;
            this.txtPasswordRepetition.TextChanged += new System.EventHandler(this.txtPasswordRepetition_TextChanged);

            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtPassword.Location = new System.Drawing.Point(243, 180);
            this.txtPassword.MaxLength = 25;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = (char)42;
            this.txtPassword.Size = new System.Drawing.Size(192, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPasswordRepetition_TextChanged);

            this.Label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label23.Location = new System.Drawing.Point(50, 257);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(489, 51);
            this.Label23.TabIndex = 6;
            this.Label23.Text = resources.GetString("Label23.Text");

            this.Label22.AutoSize = true;
            this.Label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label22.Location = new System.Drawing.Point(79, 212);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(146, 16);
            this.Label22.TabIndex = 4;
            this.Label22.Text = "Passwortwiederholung:";

            this.Label21.AutoSize = true;
            this.Label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label21.Location = new System.Drawing.Point(79, 183);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(66, 16);
            this.Label21.TabIndex = 2;
            this.Label21.Text = "Passwort:";

            this.Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label19.Location = new System.Drawing.Point(50, 41);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(504, 117);
            this.Label19.TabIndex = 1;
            this.Label19.Text = resources.GetString("Label19.Text");

            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label20.Location = new System.Drawing.Point(50, 15);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(354, 16);
            this.Label20.TabIndex = 0;
            this.Label20.Text = "Schritt 4: Bestimmen des Administratorkennwortes:";

            this.Tab6DataConversion.Controls.Add(this.Label18);
            this.Tab6DataConversion.Controls.Add(this.Label26);
            this.Tab6DataConversion.Controls.Add(this.Label27);
            this.Tab6DataConversion.Controls.Add(this.FacessoPathSettings);
            this.Tab6DataConversion.Location = new System.Drawing.Point(4, 22);
            this.Tab6DataConversion.Name = "Tab6DataConversion";
            this.Tab6DataConversion.Padding = new System.Windows.Forms.Padding(3);
            this.Tab6DataConversion.Size = new System.Drawing.Size(562, 374);
            this.Tab6DataConversion.TabIndex = 4;
            this.Tab6DataConversion.Text = "DataConversion";

            this.Label18.Location = new System.Drawing.Point(50, 293);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(432, 59);
            this.Label18.TabIndex = 3;
            this.Label18.Text = resources.GetString("Label18.Text");

            this.Label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label26.Location = new System.Drawing.Point(50, 40);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(504, 81);
            this.Label26.TabIndex = 1;
            this.Label26.Text = resources.GetString("Label26.Text");

            this.Label27.AutoSize = true;
            this.Label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label27.Location = new System.Drawing.Point(50, 15);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(297, 16);
            this.Label27.TabIndex = 0;
            this.Label27.Text = "Schritt 5: Festlegen von Pfaden und URLs ";

            this.Tab8Finalize.Controls.Add(this.Label35);
            this.Tab8Finalize.Controls.Add(this.Label34);
            this.Tab8Finalize.Controls.Add(this.Label33);
            this.Tab8Finalize.Location = new System.Drawing.Point(4, 22);
            this.Tab8Finalize.Name = "Tab8Finalize";
            this.Tab8Finalize.Padding = new System.Windows.Forms.Padding(3);
            this.Tab8Finalize.Size = new System.Drawing.Size(562, 374);
            this.Tab8Finalize.TabIndex = 6;
            this.Tab8Finalize.Text = "Fertig";

            this.Label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label35.Location = new System.Drawing.Point(50, 104);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(441, 37);
            this.Label35.TabIndex = 2;
            this.Label35.Text = "Klicken Sie auf [Fertig], um mit der Programm- und Datenbankeinrichtung zu beginnen.";

            this.Label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label34.Location = new System.Drawing.Point(50, 53);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(441, 37);
            this.Label34.TabIndex = 1;
            this.Label34.Text = "Der Assistent ist nun bereit, die geforderten Arbeiten durchzuführen. Sie können anschließend beginnen, mit Facesso zu arbeiten.";

            this.Label33.AutoSize = true;
            this.Label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label33.Location = new System.Drawing.Point(50, 15);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(156, 16);
            this.Label33.TabIndex = 0;
            this.Label33.Text = "Assistent fertigstellen";

            this.PictureBox1.BackColor = System.Drawing.Color.Blue;
            this.PictureBox1.Location = new System.Drawing.Point(0, -2);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(154, 377);
            this.PictureBox1.TabIndex = 24;
            this.PictureBox1.TabStop = false;

            this.btnBack.Location = new System.Drawing.Point(409, 397);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(95, 27);
            this.btnBack.TabIndex = 25;
            this.btnBack.Text = "< Zurück";

            this.btnNext.Location = new System.Drawing.Point(510, 397);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(95, 27);
            this.btnNext.TabIndex = 26;
            this.btnNext.Text = "Weiter >";

            this.btnCancel.Location = new System.Drawing.Point(617, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Abbrechen";

            this.FacessoPathSettings.InstallationFolder = "";
            this.FacessoPathSettings.Location = new System.Drawing.Point(53, 143);
            this.FacessoPathSettings.Name = "FacessoPathSettings";
            this.FacessoPathSettings.SharedFolder = "";
            this.FacessoPathSettings.Size = new System.Drawing.Size(467, 127);
            this.FacessoPathSettings.TabIndex = 2;
            this.FacessoPathSettings.UpdateFolder = "";
            this.FacessoPathSettings.UpdateUrl = "";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 441);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.tcWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MaximizeBox = false;
            this.Name = "frmSetupWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facesso Einrichtung";
            this.tcWizard.ResumeLayout(false);
            this.TabBase.ResumeLayout(false);
            this.TabBase.PerformLayout();
            this.Tab2SerialNo.ResumeLayout(false);
            this.Tab2SerialNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCheckSerialNo)).EndInit();
            this.Tab3DBConn.ResumeLayout(false);
            this.Tab3DBConn.PerformLayout();
            this.Tab4CompanyData.ResumeLayout(false);
            this.Tab4CompanyData.PerformLayout();
            this.Tab5AdminPassword.ResumeLayout(false);
            this.Tab5AdminPassword.PerformLayout();
            this.Tab6DataConversion.ResumeLayout(false);
            this.Tab6DataConversion.PerformLayout();
            this.Tab8Finalize.ResumeLayout(false);
            this.Tab8Finalize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.TabControl tcWizard;
        internal System.Windows.Forms.TabPage TabBase;
        internal System.Windows.Forms.TabPage Tab2SerialNo;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Button btnBack;
        internal System.Windows.Forms.Button btnNext;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TabPage Tab3DBConn;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.TabPage Tab5AdminPassword;
        internal System.Windows.Forms.TextBox txtPasswordRepetition;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Button btnTestConnection;
        internal System.Windows.Forms.TabPage Tab6DataConversion;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.TabPage Tab8Finalize;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.TabPage Tab4CompanyData;
        internal System.Windows.Forms.Label Label36;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.Label Label39;
        internal System.Windows.Forms.Label lblPreSerialNo;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.MaskedTextBox mtbSerialNo;
        internal System.Windows.Forms.TextBox txtZip;
        internal System.Windows.Forms.TextBox txtCity;
        internal System.Windows.Forms.Label Label41;
        internal System.Windows.Forms.TextBox txtStreet;
        internal System.Windows.Forms.Label Label40;
        internal System.Windows.Forms.TextBox txtSubsidiaryName;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.TextBox txtCountryCode;
        internal System.Windows.Forms.TextBox txtCountry;
        internal System.Windows.Forms.Label Label42;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnTData;
        internal System.Windows.Forms.RadioButton optNamedInstance;
        internal System.Windows.Forms.RadioButton optDefaultInstance;
        internal System.Windows.Forms.TextBox txtPrimaryPhone;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnPickConnection;
        internal System.Windows.Forms.TextBox txtConnectionString;
        internal System.Windows.Forms.Label Label7;
        internal ucFacessoPathSettings FacessoPathSettings;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.PictureBox imgCheckSerialNo;
        internal System.Windows.Forms.Label lblSerialNoValid;
        internal System.Windows.Forms.ToolTip SerialDialogTooltips;
    }
}

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmSetupWizard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetupWizard))
        Me.tcWizard = New System.Windows.Forms.TabControl()
        Me.TabBase = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tab2SerialNo = New System.Windows.Forms.TabPage()
        Me.imgCheckSerialNo = New System.Windows.Forms.PictureBox()
        Me.lblSerialNoValid = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mtbSerialNo = New System.Windows.Forms.MaskedTextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lblPreSerialNo = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Tab3DBConn = New System.Windows.Forms.TabPage()
        Me.txtConnectionString = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnPickConnection = New System.Windows.Forms.Button()
        Me.optNamedInstance = New System.Windows.Forms.RadioButton()
        Me.optDefaultInstance = New System.Windows.Forms.RadioButton()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Tab4CompanyData = New System.Windows.Forms.TabPage()
        Me.txtPrimaryPhone = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnTData = New System.Windows.Forms.Button()
        Me.txtCountryCode = New System.Windows.Forms.TextBox()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtSubsidiaryName = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Tab5AdminPassword = New System.Windows.Forms.TabPage()
        Me.txtPasswordRepetition = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Tab6DataConversion = New System.Windows.Forms.TabPage()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Tab8Finalize = New System.Windows.Forms.TabPage()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SerialDialogTooltips = New System.Windows.Forms.ToolTip(Me.components)
        Me.FacessoPathSettings = New Facesso.ucFacessoPathSettings()
        Me.tcWizard.SuspendLayout()
        Me.TabBase.SuspendLayout()
        Me.Tab2SerialNo.SuspendLayout()
        CType(Me.imgCheckSerialNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3DBConn.SuspendLayout()
        Me.Tab4CompanyData.SuspendLayout()
        Me.Tab5AdminPassword.SuspendLayout()
        Me.Tab6DataConversion.SuspendLayout()
        Me.Tab8Finalize.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcWizard
        '
        Me.tcWizard.Controls.Add(Me.TabBase)
        Me.tcWizard.Controls.Add(Me.Tab2SerialNo)
        Me.tcWizard.Controls.Add(Me.Tab3DBConn)
        Me.tcWizard.Controls.Add(Me.Tab4CompanyData)
        Me.tcWizard.Controls.Add(Me.Tab5AdminPassword)
        Me.tcWizard.Controls.Add(Me.Tab6DataConversion)
        Me.tcWizard.Controls.Add(Me.Tab8Finalize)
        Me.tcWizard.Location = New System.Drawing.Point(151, -23)
        Me.tcWizard.Name = "tcWizard"
        Me.tcWizard.SelectedIndex = 0
        Me.tcWizard.Size = New System.Drawing.Size(570, 400)
        Me.tcWizard.TabIndex = 0
        '
        'TabBase
        '
        Me.TabBase.Controls.Add(Me.Label14)
        Me.TabBase.Controls.Add(Me.Label12)
        Me.TabBase.Controls.Add(Me.Label11)
        Me.TabBase.Controls.Add(Me.Label10)
        Me.TabBase.Controls.Add(Me.Label9)
        Me.TabBase.Controls.Add(Me.Label8)
        Me.TabBase.Controls.Add(Me.Label4)
        Me.TabBase.Controls.Add(Me.Label3)
        Me.TabBase.Controls.Add(Me.Label2)
        Me.TabBase.Location = New System.Drawing.Point(4, 22)
        Me.TabBase.Name = "TabBase"
        Me.TabBase.Padding = New System.Windows.Forms.Padding(3)
        Me.TabBase.Size = New System.Drawing.Size(562, 374)
        Me.TabBase.TabIndex = 0
        Me.TabBase.Text = "Basis"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(47, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(175, 13)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "* Die Seriennummer des Programms"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(47, 281)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(438, 32)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Klicken Sie jeweils auf die Schaltfläche [Weiter >], wenn Sie einen Schritt des A" & _
            "ssistenten abgeschlossen haben."
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(50, 211)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(403, 70)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "(Falls Sie bereits Prämienlohnabrechnungen mit Mitbewerberprodukten ermittelt hab" & _
            "en, versucht Facesso das Datenformat zu erkennen und die Daten in die Facesso-Da" & _
            "tenbank zu importieren.)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(50, 187)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(331, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "* Den Speicherort einer bereits vorhandenen Access-Datei (Optional)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(47, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "* Ein Administratorkennwort"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(349, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "* Die Adresse der Hauptfilliale Ihres Unternehmens oder des Stammsitzes"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(50, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(441, 51)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Während der nächsten Schritte, fragt Sie dieser Assistent bestimmte Informationen" & _
            " ab, die Facesso als Mindestvoraussetzung zum Funktionieren benötigt. Dazu gehör" & _
            "en:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(50, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(438, 39)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Dieser Assistent hilft Ihnen, Facesso für den aller ersten Start auf diesem Syste" & _
            "m vorzubereiten und das Datenbanksystem zu konfigurieren."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(393, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Willkommen zum Einrichtungs-Assistenten von Facesso!"
        '
        'Tab2SerialNo
        '
        Me.Tab2SerialNo.Controls.Add(Me.imgCheckSerialNo)
        Me.Tab2SerialNo.Controls.Add(Me.lblSerialNoValid)
        Me.Tab2SerialNo.Controls.Add(Me.Label1)
        Me.Tab2SerialNo.Controls.Add(Me.Label5)
        Me.Tab2SerialNo.Controls.Add(Me.mtbSerialNo)
        Me.Tab2SerialNo.Controls.Add(Me.Label39)
        Me.Tab2SerialNo.Controls.Add(Me.lblPreSerialNo)
        Me.Tab2SerialNo.Controls.Add(Me.Label17)
        Me.Tab2SerialNo.Controls.Add(Me.Label13)
        Me.Tab2SerialNo.Controls.Add(Me.Label15)
        Me.Tab2SerialNo.Controls.Add(Me.Label16)
        Me.Tab2SerialNo.Location = New System.Drawing.Point(4, 22)
        Me.Tab2SerialNo.Name = "Tab2SerialNo"
        Me.Tab2SerialNo.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2SerialNo.Size = New System.Drawing.Size(562, 374)
        Me.Tab2SerialNo.TabIndex = 1
        Me.Tab2SerialNo.Text = "SerialNo"
        '
        'imgCheckSerialNo
        '
        Me.imgCheckSerialNo.Image = Global.Facesso.My.Resources.Resources.Keyboard_Error
        Me.imgCheckSerialNo.Location = New System.Drawing.Point(462, 256)
        Me.imgCheckSerialNo.Name = "imgCheckSerialNo"
        Me.imgCheckSerialNo.Size = New System.Drawing.Size(84, 77)
        Me.imgCheckSerialNo.TabIndex = 11
        Me.imgCheckSerialNo.TabStop = False
        '
        'lblSerialNoValid
        '
        Me.lblSerialNoValid.Location = New System.Drawing.Point(28, 237)
        Me.lblSerialNoValid.Name = "lblSerialNoValid"
        Me.lblSerialNoValid.Size = New System.Drawing.Size(514, 16)
        Me.lblSerialNoValid.TabIndex = 10
        Me.lblSerialNoValid.Text = "Die eingegebene Seriennummer ist nicht gültig; eine Demo-Version wird - so noch m" & _
            "öglich - freigeschaltet."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(309, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 26)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "(+49 | 0) 29 41/91 09 07"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(307, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(199, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Telefonische Registrierung:"
        '
        'mtbSerialNo
        '
        Me.mtbSerialNo.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.mtbSerialNo.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbSerialNo.HideSelection = False
        Me.mtbSerialNo.Location = New System.Drawing.Point(31, 208)
        Me.mtbSerialNo.Mask = ">AAAAA - AAAAA - AAAAA - AAAAA - AAAAA - AAAAA"
        Me.mtbSerialNo.Name = "mtbSerialNo"
        Me.mtbSerialNo.Size = New System.Drawing.Size(518, 26)
        Me.mtbSerialNo.TabIndex = 5
        Me.mtbSerialNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mtbSerialNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(29, 186)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(277, 16)
        Me.Label39.TabIndex = 4
        Me.Label39.Text = "Geben Sie hier den Freischaltcode ein:"
        '
        'lblPreSerialNo
        '
        Me.lblPreSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreSerialNo.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreSerialNo.Location = New System.Drawing.Point(34, 140)
        Me.lblPreSerialNo.Name = "lblPreSerialNo"
        Me.lblPreSerialNo.Size = New System.Drawing.Size(263, 23)
        Me.lblPreSerialNo.TabIndex = 3
        Me.lblPreSerialNo.Text = "12345 - 12345 - 12345"
        Me.lblPreSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(32, 117)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(254, 16)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Die individuelle Kennnummer lautet:"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(29, 268)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(390, 69)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = resources.GetString("Label13.Text")
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(28, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(480, 60)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = resources.GetString("Label15.Text")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(28, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(278, 16)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Schritt 1: Eingabe des Freischaltcodes:"
        '
        'Tab3DBConn
        '
        Me.Tab3DBConn.Controls.Add(Me.txtConnectionString)
        Me.Tab3DBConn.Controls.Add(Me.Label7)
        Me.Tab3DBConn.Controls.Add(Me.btnPickConnection)
        Me.Tab3DBConn.Controls.Add(Me.optNamedInstance)
        Me.Tab3DBConn.Controls.Add(Me.optDefaultInstance)
        Me.Tab3DBConn.Controls.Add(Me.btnTestConnection)
        Me.Tab3DBConn.Controls.Add(Me.Label24)
        Me.Tab3DBConn.Controls.Add(Me.Label25)
        Me.Tab3DBConn.Location = New System.Drawing.Point(4, 22)
        Me.Tab3DBConn.Name = "Tab3DBConn"
        Me.Tab3DBConn.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab3DBConn.Size = New System.Drawing.Size(562, 374)
        Me.Tab3DBConn.TabIndex = 2
        Me.Tab3DBConn.Text = "DBConn"
        '
        'txtConnectionString
        '
        Me.txtConnectionString.Location = New System.Drawing.Point(74, 273)
        Me.txtConnectionString.Multiline = True
        Me.txtConnectionString.Name = "txtConnectionString"
        Me.txtConnectionString.ReadOnly = True
        Me.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConnectionString.Size = New System.Drawing.Size(339, 88)
        Me.txtConnectionString.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(71, 257)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(284, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "&Verbindungszeichenfolge für SQL-Datenbank-Verbindung::"
        '
        'btnPickConnection
        '
        Me.btnPickConnection.Enabled = False
        Me.btnPickConnection.Location = New System.Drawing.Point(429, 218)
        Me.btnPickConnection.Name = "btnPickConnection"
        Me.btnPickConnection.Size = New System.Drawing.Size(120, 32)
        Me.btnPickConnection.TabIndex = 6
        Me.btnPickConnection.Text = "&Verbindung wählen..."
        Me.btnPickConnection.UseVisualStyleBackColor = True
        '
        'optNamedInstance
        '
        Me.optNamedInstance.AutoSize = True
        Me.optNamedInstance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optNamedInstance.Location = New System.Drawing.Point(54, 224)
        Me.optNamedInstance.Name = "optNamedInstance"
        Me.optNamedInstance.Size = New System.Drawing.Size(301, 20)
        Me.optNamedInstance.TabIndex = 5
        Me.optNamedInstance.Text = "SQL-Serverinstanz und &Datenbank auswählen:"
        '
        'optDefaultInstance
        '
        Me.optDefaultInstance.AutoSize = True
        Me.optDefaultInstance.Checked = True
        Me.optDefaultInstance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDefaultInstance.Location = New System.Drawing.Point(54, 192)
        Me.optDefaultInstance.Name = "optDefaultInstance"
        Me.optDefaultInstance.Size = New System.Drawing.Size(291, 20)
        Me.optDefaultInstance.TabIndex = 4
        Me.optDefaultInstance.TabStop = True
        Me.optDefaultInstance.Text = "&Standardinstanz: (.\SQLEXPRESS; Facesso)"
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestConnection.Location = New System.Drawing.Point(429, 333)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(120, 29)
        Me.btnTestConnection.TabIndex = 3
        Me.btnTestConnection.Text = "Verbindung &testen..."
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(53, 42)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(496, 137)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = resources.GetString("Label24.Text")
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(50, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(245, 16)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Schritt 2: Verbinden zur Datenbank"
        '
        'Tab4CompanyData
        '
        Me.Tab4CompanyData.Controls.Add(Me.txtPrimaryPhone)
        Me.Tab4CompanyData.Controls.Add(Me.Label6)
        Me.Tab4CompanyData.Controls.Add(Me.btnTData)
        Me.Tab4CompanyData.Controls.Add(Me.txtCountryCode)
        Me.Tab4CompanyData.Controls.Add(Me.txtCountry)
        Me.Tab4CompanyData.Controls.Add(Me.Label42)
        Me.Tab4CompanyData.Controls.Add(Me.txtZip)
        Me.Tab4CompanyData.Controls.Add(Me.txtCity)
        Me.Tab4CompanyData.Controls.Add(Me.Label41)
        Me.Tab4CompanyData.Controls.Add(Me.txtStreet)
        Me.Tab4CompanyData.Controls.Add(Me.Label40)
        Me.Tab4CompanyData.Controls.Add(Me.txtSubsidiaryName)
        Me.Tab4CompanyData.Controls.Add(Me.Label38)
        Me.Tab4CompanyData.Controls.Add(Me.Label36)
        Me.Tab4CompanyData.Controls.Add(Me.Label37)
        Me.Tab4CompanyData.Location = New System.Drawing.Point(4, 22)
        Me.Tab4CompanyData.Name = "Tab4CompanyData"
        Me.Tab4CompanyData.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab4CompanyData.Size = New System.Drawing.Size(562, 374)
        Me.Tab4CompanyData.TabIndex = 7
        Me.Tab4CompanyData.Text = "CompData"
        '
        'txtPrimaryPhone
        '
        Me.txtPrimaryPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrimaryPhone.Location = New System.Drawing.Point(220, 275)
        Me.txtPrimaryPhone.MaxLength = 100
        Me.txtPrimaryPhone.Name = "txtPrimaryPhone"
        Me.txtPrimaryPhone.Size = New System.Drawing.Size(314, 22)
        Me.txtPrimaryPhone.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Primäre Telefonnummer:"
        '
        'btnTData
        '
        Me.btnTData.Location = New System.Drawing.Point(432, 142)
        Me.btnTData.Name = "btnTData"
        Me.btnTData.Size = New System.Drawing.Size(102, 19)
        Me.btnTData.TabIndex = 14
        Me.btnTData.Text = "Testdaten"
        '
        'txtCountryCode
        '
        Me.txtCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountryCode.Location = New System.Drawing.Point(220, 247)
        Me.txtCountryCode.MaxLength = 10
        Me.txtCountryCode.Name = "txtCountryCode"
        Me.txtCountryCode.Size = New System.Drawing.Size(85, 22)
        Me.txtCountryCode.TabIndex = 10
        '
        'txtCountry
        '
        Me.txtCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountry.Location = New System.Drawing.Point(312, 247)
        Me.txtCountry.MaxLength = 100
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(222, 22)
        Me.txtCountry.TabIndex = 11
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(68, 250)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(138, 16)
        Me.Label42.TabIndex = 9
        Me.Label42.Text = "Länderkennung/Land:"
        '
        'txtZip
        '
        Me.txtZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZip.Location = New System.Drawing.Point(220, 221)
        Me.txtZip.MaxLength = 10
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(85, 22)
        Me.txtZip.TabIndex = 7
        '
        'txtCity
        '
        Me.txtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Location = New System.Drawing.Point(312, 221)
        Me.txtCity.MaxLength = 100
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(222, 22)
        Me.txtCity.TabIndex = 8
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(150, 221)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(56, 16)
        Me.Label41.TabIndex = 6
        Me.Label41.Text = "PLZ/Ort:"
        '
        'txtStreet
        '
        Me.txtStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreet.Location = New System.Drawing.Point(220, 195)
        Me.txtStreet.MaxLength = 100
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(314, 22)
        Me.txtStreet.TabIndex = 5
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(155, 198)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(51, 16)
        Me.Label40.TabIndex = 4
        Me.Label40.Text = "Straße:"
        '
        'txtSubsidiaryName
        '
        Me.txtSubsidiaryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubsidiaryName.Location = New System.Drawing.Point(220, 167)
        Me.txtSubsidiaryName.MaxLength = 100
        Me.txtSubsidiaryName.Name = "txtSubsidiaryName"
        Me.txtSubsidiaryName.Size = New System.Drawing.Size(314, 22)
        Me.txtSubsidiaryName.TabIndex = 3
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(54, 152)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(148, 36)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "Unternehmensname (Hauptsitz/Hauptfiliale):"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(50, 41)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(504, 70)
        Me.Label36.TabIndex = 1
        Me.Label36.Text = resources.GetString("Label36.Text")
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(50, 15)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(298, 16)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "Schritt 3: Eingabe der Unternehmensdaten"
        '
        'Tab5AdminPassword
        '
        Me.Tab5AdminPassword.Controls.Add(Me.txtPasswordRepetition)
        Me.Tab5AdminPassword.Controls.Add(Me.txtPassword)
        Me.Tab5AdminPassword.Controls.Add(Me.Label23)
        Me.Tab5AdminPassword.Controls.Add(Me.Label22)
        Me.Tab5AdminPassword.Controls.Add(Me.Label21)
        Me.Tab5AdminPassword.Controls.Add(Me.Label19)
        Me.Tab5AdminPassword.Controls.Add(Me.Label20)
        Me.Tab5AdminPassword.Location = New System.Drawing.Point(4, 22)
        Me.Tab5AdminPassword.Name = "Tab5AdminPassword"
        Me.Tab5AdminPassword.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab5AdminPassword.Size = New System.Drawing.Size(562, 374)
        Me.Tab5AdminPassword.TabIndex = 3
        Me.Tab5AdminPassword.Text = "AdminPassword"
        '
        'txtPasswordRepetition
        '
        Me.txtPasswordRepetition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordRepetition.Location = New System.Drawing.Point(243, 209)
        Me.txtPasswordRepetition.MaxLength = 25
        Me.txtPasswordRepetition.Name = "txtPasswordRepetition"
        Me.txtPasswordRepetition.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordRepetition.Size = New System.Drawing.Size(192, 22)
        Me.txtPasswordRepetition.TabIndex = 5
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(243, 180)
        Me.txtPassword.MaxLength = 25
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(192, 22)
        Me.txtPassword.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(50, 257)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(489, 51)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = resources.GetString("Label23.Text")
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(79, 212)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(146, 16)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "Passwortwiederholung:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(79, 183)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 16)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Passwort:"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(50, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(504, 117)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = resources.GetString("Label19.Text")
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(50, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(354, 16)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Schritt 4: Bestimmen des Administratorkennwortes:"
        '
        'Tab6DataConversion
        '
        Me.Tab6DataConversion.Controls.Add(Me.Label18)
        Me.Tab6DataConversion.Controls.Add(Me.Label26)
        Me.Tab6DataConversion.Controls.Add(Me.Label27)
        Me.Tab6DataConversion.Controls.Add(Me.FacessoPathSettings)
        Me.Tab6DataConversion.Location = New System.Drawing.Point(4, 22)
        Me.Tab6DataConversion.Name = "Tab6DataConversion"
        Me.Tab6DataConversion.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab6DataConversion.Size = New System.Drawing.Size(562, 374)
        Me.Tab6DataConversion.TabIndex = 4
        Me.Tab6DataConversion.Text = "DataConversion"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(50, 293)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(432, 59)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = resources.GetString("Label18.Text")
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(50, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(504, 81)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = resources.GetString("Label26.Text")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(50, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(297, 16)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Schritt 5: Festlegen von Pfaden und URLs "
        '
        'Tab8Finalize
        '
        Me.Tab8Finalize.Controls.Add(Me.Label35)
        Me.Tab8Finalize.Controls.Add(Me.Label34)
        Me.Tab8Finalize.Controls.Add(Me.Label33)
        Me.Tab8Finalize.Location = New System.Drawing.Point(4, 22)
        Me.Tab8Finalize.Name = "Tab8Finalize"
        Me.Tab8Finalize.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab8Finalize.Size = New System.Drawing.Size(562, 374)
        Me.Tab8Finalize.TabIndex = 6
        Me.Tab8Finalize.Text = "Fertig"
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(50, 104)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(441, 37)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Klicken Sie auf [Fertig], um mit der Programm- und Datenbankeinrichtung zu beginn" & _
            "en."
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(50, 53)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(441, 37)
        Me.Label34.TabIndex = 1
        Me.Label34.Text = "Der Assistent ist nun bereit, die geforderten Arbeiten durchzuführen. Sie können " & _
            "anschließend beginnen, mit Facesso zu arbeiten."
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(50, 15)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(156, 16)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Assistent fertigstellen"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Blue
        Me.PictureBox1.Location = New System.Drawing.Point(0, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 377)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(409, 397)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(95, 27)
        Me.btnBack.TabIndex = 25
        Me.btnBack.Text = "< Zurück"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(510, 397)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(95, 27)
        Me.btnNext.TabIndex = 26
        Me.btnNext.Text = "Weiter >"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(617, 397)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "Abbrechen"
        '
        'FacessoPathSettings
        '
        Me.FacessoPathSettings.InstallationFolder = ""
        Me.FacessoPathSettings.Location = New System.Drawing.Point(53, 143)
        Me.FacessoPathSettings.Name = "FacessoPathSettings"
        Me.FacessoPathSettings.SharedFolder = ""
        Me.FacessoPathSettings.Size = New System.Drawing.Size(467, 127)
        Me.FacessoPathSettings.TabIndex = 2
        Me.FacessoPathSettings.UpdateFolder = ""
        Me.FacessoPathSettings.UpdateUrl = ""
        '
        'frmSetupWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 441)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.tcWizard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.Name = "frmSetupWizard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facesso Einrichtung"
        Me.tcWizard.ResumeLayout(False)
        Me.TabBase.ResumeLayout(False)
        Me.TabBase.PerformLayout()
        Me.Tab2SerialNo.ResumeLayout(False)
        Me.Tab2SerialNo.PerformLayout()
        CType(Me.imgCheckSerialNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3DBConn.ResumeLayout(False)
        Me.Tab3DBConn.PerformLayout()
        Me.Tab4CompanyData.ResumeLayout(False)
        Me.Tab4CompanyData.PerformLayout()
        Me.Tab5AdminPassword.ResumeLayout(False)
        Me.Tab5AdminPassword.PerformLayout()
        Me.Tab6DataConversion.ResumeLayout(False)
        Me.Tab6DataConversion.PerformLayout()
        Me.Tab8Finalize.ResumeLayout(False)
        Me.Tab8Finalize.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcWizard As System.Windows.Forms.TabControl
    Friend WithEvents TabBase As System.Windows.Forms.TabPage
    Friend WithEvents Tab2SerialNo As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Tab3DBConn As System.Windows.Forms.TabPage
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Tab5AdminPassword As System.Windows.Forms.TabPage
    Friend WithEvents txtPasswordRepetition As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents Tab6DataConversion As System.Windows.Forms.TabPage
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Tab8Finalize As System.Windows.Forms.TabPage
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Tab4CompanyData As System.Windows.Forms.TabPage
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lblPreSerialNo As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents mtbSerialNo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtStreet As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtSubsidiaryName As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtCountryCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnTData As System.Windows.Forms.Button
    Friend WithEvents optNamedInstance As System.Windows.Forms.RadioButton
    Friend WithEvents optDefaultInstance As System.Windows.Forms.RadioButton
    Friend WithEvents txtPrimaryPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnPickConnection As System.Windows.Forms.Button
    Friend WithEvents txtConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FacessoPathSettings As Facesso.ucFacessoPathSettings
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents imgCheckSerialNo As System.Windows.Forms.PictureBox
    Friend WithEvents lblSerialNoValid As System.Windows.Forms.Label
    Friend WithEvents SerialDialogTooltips As System.Windows.Forms.ToolTip

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDbSetupWizard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDbSetupWizard))
        Me.tcWizard = New System.Windows.Forms.TabControl
        Me.TabBase = New System.Windows.Forms.TabPage
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Tab4CompanyData = New System.Windows.Forms.TabPage
        Me.txtPrimaryPhone = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnTData = New System.Windows.Forms.Button
        Me.txtCountryCode = New System.Windows.Forms.TextBox
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtStreet = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.txtSubsidiaryName = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Tab5AdminPassword = New System.Windows.Forms.TabPage
        Me.txtPasswordRepetition = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Tab8Finalize = New System.Windows.Forms.TabPage
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnBack = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.tcWizard.SuspendLayout()
        Me.TabBase.SuspendLayout()
        Me.Tab4CompanyData.SuspendLayout()
        Me.Tab5AdminPassword.SuspendLayout()
        Me.Tab8Finalize.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcWizard
        '
        Me.tcWizard.Controls.Add(Me.TabBase)
        Me.tcWizard.Controls.Add(Me.Tab4CompanyData)
        Me.tcWizard.Controls.Add(Me.Tab5AdminPassword)
        Me.tcWizard.Controls.Add(Me.Tab8Finalize)
        Me.tcWizard.Location = New System.Drawing.Point(151, -23)
        Me.tcWizard.Name = "tcWizard"
        Me.tcWizard.SelectedIndex = 0
        Me.tcWizard.Size = New System.Drawing.Size(570, 400)
        Me.tcWizard.TabIndex = 0
        '
        'TabBase
        '
        Me.TabBase.Controls.Add(Me.Label12)
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
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(47, 285)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(438, 32)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Klicken Sie jeweils auf die Schaltfläche [Weiter >], wenn Sie einen Schritt des A" & _
            "ssistenten abgeschlossen haben."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(47, 219)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(417, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "* Den Speicherort einer bereits vorhandenen Access-Datei (Optional)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(47, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "* Ein Administratorkennwort"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(47, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(445, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "* Die Adresse der Hauptfilliale Ihres Unternehmens oder des Stammsitzes"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(441, 51)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Während der nächsten Schritte, fragt Sie dieser Assistent bestimmte Informationen" & _
            " ab, die Facesso als Mindestvoraussetzung zum Funktionieren benötigt. Dazu gehör" & _
            "en:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(438, 39)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Dieser Assistent hilft Ihnen, eine neue Facesso-Datenbank für den ersten Gebrauch" & _
            " vorzubereiten und das Datenbanksystem zu konfigurieren."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(467, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Willkommen zum Datenbankeinrichtungs-Assistenten von Facesso!"
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
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(409, 397)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(95, 27)
        Me.btnBack.TabIndex = 25
        Me.btnBack.Text = "< Zurück"
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(510, 397)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(95, 27)
        Me.btnNext.TabIndex = 26
        Me.btnNext.Text = "Weiter >"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(617, 397)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "Abbrechen"
        '
        'frmDbSetupWizard
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
        Me.Name = "frmDbSetupWizard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facesso Datenbank-Setup"
        Me.tcWizard.ResumeLayout(False)
        Me.TabBase.ResumeLayout(False)
        Me.TabBase.PerformLayout()
        Me.Tab4CompanyData.ResumeLayout(False)
        Me.Tab4CompanyData.PerformLayout()
        Me.Tab5AdminPassword.ResumeLayout(False)
        Me.Tab5AdminPassword.PerformLayout()
        Me.Tab8Finalize.ResumeLayout(False)
        Me.Tab8Finalize.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcWizard As System.Windows.Forms.TabControl
    Friend WithEvents TabBase As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Tab5AdminPassword As System.Windows.Forms.TabPage
    Friend WithEvents txtPasswordRepetition As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Tab8Finalize As System.Windows.Forms.TabPage
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Tab4CompanyData As System.Windows.Forms.TabPage
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
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
    Friend WithEvents btnTData As System.Windows.Forms.Button
    Friend WithEvents txtPrimaryPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class

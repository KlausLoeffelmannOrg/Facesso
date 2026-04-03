Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class frmOptions
    Inherits Form

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
        Me.tcMain = New System.Windows.Forms.TabControl
        Me.tpGeneral = New System.Windows.Forms.TabPage
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkAutomateMainFormUpdate = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.FacessoPathSettings = New Facesso.ucFacessoPathSettings
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnChooseSqlConnectionString = New System.Windows.Forms.Button
        Me.txtSQLLoginString = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkSundayIsWorkday = New System.Windows.Forms.CheckBox
        Me.chkSaturdayIsWorkday = New System.Windows.Forms.CheckBox
        Me.tpTimeSettingDefaults = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnAssignToWorkgroups = New System.Windows.Forms.Button
        Me.UcTimeDetailsSettings = New Facesso.FrontEnd.ucTimeDetailsSettings
        Me.tpLayoutAndNumberformats = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnPreView = New System.Windows.Forms.Button
        Me.cmbGridStyle = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbHMinutesPrecision = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnLogo = New System.Windows.Forms.Button
        Me.pbxLogo = New System.Windows.Forms.PictureBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnTextBodyAndTableBodyFont = New System.Windows.Forms.Button
        Me.lblTextAndTableBodyFont = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnTableHeaderFont = New System.Windows.Forms.Button
        Me.lblTableHeaderFont = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnU3Font = New System.Windows.Forms.Button
        Me.lblFontU3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnU2Font = New System.Windows.Forms.Button
        Me.lblFontU2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnU1Font = New System.Windows.Forms.Button
        Me.lblFontU1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tpThresholdValues = New System.Windows.Forms.TabPage
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.nibThresholdFirstShift = New ActiveDev.Controls.ADNullableIntBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtbFallBackTimeEnd = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.dtbFallBackTimeStart = New ActiveDev.Controls.ADNullableDateTimeBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.chkShowTimeLogPriorToImport = New System.Windows.Forms.CheckBox
        Me.chkShowIssueListPriorToImport = New System.Windows.Forms.CheckBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.tcMain.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tpTimeSettingDefaults.SuspendLayout()
        Me.tpLayoutAndNumberformats.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpThresholdValues.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tpGeneral)
        Me.tcMain.Controls.Add(Me.tpTimeSettingDefaults)
        Me.tcMain.Controls.Add(Me.tpLayoutAndNumberformats)
        Me.tcMain.Controls.Add(Me.tpThresholdValues)
        Me.tcMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcMain.Location = New System.Drawing.Point(15, 19)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(614, 555)
        Me.tcMain.TabIndex = 0
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.GroupBox6)
        Me.tpGeneral.Controls.Add(Me.GroupBox5)
        Me.tpGeneral.Controls.Add(Me.GroupBox4)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 25)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(606, 526)
        Me.tpGeneral.TabIndex = 2
        Me.tpGeneral.Text = "Allgemein"
        Me.tpGeneral.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.chkAutomateMainFormUpdate)
        Me.GroupBox6.Location = New System.Drawing.Point(15, 381)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(546, 97)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Automatische Datenaktualisierung"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(35, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(485, 29)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "HINWEIS: Aktivieren Sie dieses Kontrollkästchen, wenn die ""Daten-vorhanden-Anzeig" & _
            "e"" der Hauptmaske im Minutentakt eingeschaltet werden soll."
        '
        'chkAutomateMainFormUpdate
        '
        Me.chkAutomateMainFormUpdate.AutoSize = True
        Me.chkAutomateMainFormUpdate.Location = New System.Drawing.Point(17, 29)
        Me.chkAutomateMainFormUpdate.Name = "chkAutomateMainFormUpdate"
        Me.chkAutomateMainFormUpdate.Size = New System.Drawing.Size(417, 20)
        Me.chkAutomateMainFormUpdate.TabIndex = 0
        Me.chkAutomateMainFormUpdate.Text = "Auf dieser Workstation die Hauptmaske automatisch aktualisieren"
        Me.chkAutomateMainFormUpdate.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.FacessoPathSettings)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.btnChooseSqlConnectionString)
        Me.GroupBox5.Controls.Add(Me.txtSQLLoginString)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 122)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(546, 240)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Pfade, URLs und SQL-Verbindungszeichenfolgen"
        '
        'FacessoPathSettings
        '
        Me.FacessoPathSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FacessoPathSettings.InstallationFolder = ""
        Me.FacessoPathSettings.Location = New System.Drawing.Point(17, 21)
        Me.FacessoPathSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.FacessoPathSettings.Name = "FacessoPathSettings"
        Me.FacessoPathSettings.SharedFolder = ""
        Me.FacessoPathSettings.Size = New System.Drawing.Size(525, 120)
        Me.FacessoPathSettings.TabIndex = 13
        Me.FacessoPathSettings.UpdateFolder = ""
        Me.FacessoPathSettings.UpdateUrl = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 149)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(163, 16)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Verbindungszeichenfolge:"
        '
        'btnChooseSqlConnectionString
        '
        Me.btnChooseSqlConnectionString.Location = New System.Drawing.Point(512, 148)
        Me.btnChooseSqlConnectionString.Name = "btnChooseSqlConnectionString"
        Me.btnChooseSqlConnectionString.Size = New System.Drawing.Size(28, 24)
        Me.btnChooseSqlConnectionString.TabIndex = 12
        Me.btnChooseSqlConnectionString.Text = "..."
        Me.btnChooseSqlConnectionString.UseVisualStyleBackColor = True
        '
        'txtSQLLoginString
        '
        Me.txtSQLLoginString.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSQLLoginString.Location = New System.Drawing.Point(175, 148)
        Me.txtSQLLoginString.Multiline = True
        Me.txtSQLLoginString.Name = "txtSQLLoginString"
        Me.txtSQLLoginString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQLLoginString.Size = New System.Drawing.Size(331, 86)
        Me.txtSQLLoginString.TabIndex = 11
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.chkSundayIsWorkday)
        Me.GroupBox4.Controls.Add(Me.chkSaturdayIsWorkday)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 21)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(546, 95)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Arbeitstage am Wochenende:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(279, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(241, 70)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "HINWEIS: Diese Einstellungen beziehen sich ausschließlich auf das 'Blättern' des " & _
            "Datums in der Hauptmaske und dem Datenmanager von Facesso.NET."
        '
        'chkSundayIsWorkday
        '
        Me.chkSundayIsWorkday.AutoSize = True
        Me.chkSundayIsWorkday.Location = New System.Drawing.Point(17, 55)
        Me.chkSundayIsWorkday.Name = "chkSundayIsWorkday"
        Me.chkSundayIsWorkday.Size = New System.Drawing.Size(157, 20)
        Me.chkSundayIsWorkday.TabIndex = 1
        Me.chkSundayIsWorkday.Text = "Sonntag ist Arbeitstag"
        Me.chkSundayIsWorkday.UseVisualStyleBackColor = True
        '
        'chkSaturdayIsWorkday
        '
        Me.chkSaturdayIsWorkday.AutoSize = True
        Me.chkSaturdayIsWorkday.Location = New System.Drawing.Point(17, 29)
        Me.chkSaturdayIsWorkday.Name = "chkSaturdayIsWorkday"
        Me.chkSaturdayIsWorkday.Size = New System.Drawing.Size(161, 20)
        Me.chkSaturdayIsWorkday.TabIndex = 0
        Me.chkSaturdayIsWorkday.Text = "Samstag ist Arbeitstag"
        Me.chkSaturdayIsWorkday.UseVisualStyleBackColor = True
        '
        'tpTimeSettingDefaults
        '
        Me.tpTimeSettingDefaults.Controls.Add(Me.Label4)
        Me.tpTimeSettingDefaults.Controls.Add(Me.btnAssignToWorkgroups)
        Me.tpTimeSettingDefaults.Controls.Add(Me.UcTimeDetailsSettings)
        Me.tpTimeSettingDefaults.Location = New System.Drawing.Point(4, 25)
        Me.tpTimeSettingDefaults.Name = "tpTimeSettingDefaults"
        Me.tpTimeSettingDefaults.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTimeSettingDefaults.Size = New System.Drawing.Size(606, 526)
        Me.tpTimeSettingDefaults.TabIndex = 0
        Me.tpTimeSettingDefaults.Text = "Schichtmodell"
        Me.tpTimeSettingDefaults.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 488)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(338, 28)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Hinweis: Verwenden Sie 'An Produktiv-Sites zuweisen', wenn Sie diese Einstellunge" & _
            "n anderen Produktiv-Sites zuweisen wollen."
        '
        'btnAssignToWorkgroups
        '
        Me.btnAssignToWorkgroups.Location = New System.Drawing.Point(374, 487)
        Me.btnAssignToWorkgroups.Name = "btnAssignToWorkgroups"
        Me.btnAssignToWorkgroups.Size = New System.Drawing.Size(201, 33)
        Me.btnAssignToWorkgroups.TabIndex = 1
        Me.btnAssignToWorkgroups.Text = "An Produktiv-Sites zuweisen..."
        Me.btnAssignToWorkgroups.UseVisualStyleBackColor = True
        '
        'UcTimeDetailsSettings
        '
        Me.UcTimeDetailsSettings.CurrentlyDisplayedShift = 1
        Me.UcTimeDetailsSettings.CurrentlyDisplayedWeekday = Facesso.TimeSettingDetailsWeekdays.ForAll
        Me.UcTimeDetailsSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcTimeDetailsSettings.Location = New System.Drawing.Point(12, 7)
        Me.UcTimeDetailsSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.UcTimeDetailsSettings.Name = "UcTimeDetailsSettings"
        Me.UcTimeDetailsSettings.Size = New System.Drawing.Size(572, 477)
        Me.UcTimeDetailsSettings.TabIndex = 0
        '
        'tpLayoutAndNumberformats
        '
        Me.tpLayoutAndNumberformats.Controls.Add(Me.GroupBox3)
        Me.tpLayoutAndNumberformats.Controls.Add(Me.GroupBox2)
        Me.tpLayoutAndNumberformats.Controls.Add(Me.GroupBox1)
        Me.tpLayoutAndNumberformats.Location = New System.Drawing.Point(4, 25)
        Me.tpLayoutAndNumberformats.Name = "tpLayoutAndNumberformats"
        Me.tpLayoutAndNumberformats.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLayoutAndNumberformats.Size = New System.Drawing.Size(606, 526)
        Me.tpLayoutAndNumberformats.TabIndex = 1
        Me.tpLayoutAndNumberformats.Text = "Drucklayout und Zahlenformate"
        Me.tpLayoutAndNumberformats.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnPreView)
        Me.GroupBox3.Controls.Add(Me.cmbGridStyle)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(8, 307)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(568, 69)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tabellenstil:"
        '
        'btnPreView
        '
        Me.btnPreView.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreView.Location = New System.Drawing.Point(472, 23)
        Me.btnPreView.Name = "btnPreView"
        Me.btnPreView.Size = New System.Drawing.Size(85, 25)
        Me.btnPreView.TabIndex = 2
        Me.btnPreView.Text = "Vorschau..."
        '
        'cmbGridStyle
        '
        Me.cmbGridStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGridStyle.FormattingEnabled = True
        Me.cmbGridStyle.Items.AddRange(New Object() {"Kein Gitternetz", "einfaches Gitternetz, schmal", "einfaches Gitternetz, dick", "Gitternetz 3D-Effekt 1", "Gitternetz 3D-Effekt 2"})
        Me.cmbGridStyle.Location = New System.Drawing.Point(175, 25)
        Me.cmbGridStyle.Name = "cmbGridStyle"
        Me.cmbGridStyle.Size = New System.Drawing.Size(282, 24)
        Me.cmbGridStyle.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(156, 19)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Gitternetz:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cmbHMinutesPrecision)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 393)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 86)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Zahlenformate:"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(174, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(368, 32)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Hinweis: Die Anzahl dargestellter Stellen der Leistungsindikatoren ergibt sich au" & _
            "s der in den jeweiligen Kostenstellen hinterlegten Präzisionsdefinition."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(245, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 16)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Stellen gerundet."
        '
        'cmbHMinutesPrecision
        '
        Me.cmbHMinutesPrecision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbHMinutesPrecision.FormattingEnabled = True
        Me.cmbHMinutesPrecision.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.cmbHMinutesPrecision.Location = New System.Drawing.Point(175, 16)
        Me.cmbHMinutesPrecision.Name = "cmbHMinutesPrecision"
        Me.cmbHMinutesPrecision.Size = New System.Drawing.Size(57, 24)
        Me.cmbHMinutesPrecision.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(158, 19)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "hnd. Minutenangaben: auf "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.btnLogo)
        Me.GroupBox1.Controls.Add(Me.pbxLogo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.btnTextBodyAndTableBodyFont)
        Me.GroupBox1.Controls.Add(Me.lblTextAndTableBodyFont)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btnTableHeaderFont)
        Me.GroupBox1.Controls.Add(Me.lblTableHeaderFont)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnU3Font)
        Me.GroupBox1.Controls.Add(Me.lblFontU3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnU2Font)
        Me.GroupBox1.Controls.Add(Me.lblFontU2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnU1Font)
        Me.GroupBox1.Controls.Add(Me.lblFontU1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(569, 278)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Schriftarten und Logos:"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(11, 208)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(157, 43)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Hinweis: Wird proportional auf 1,5 cm-Höhe verkleinert bzw. vergrößert."
        '
        'btnLogo
        '
        Me.btnLogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogo.Location = New System.Drawing.Point(521, 180)
        Me.btnLogo.Name = "btnLogo"
        Me.btnLogo.Size = New System.Drawing.Size(22, 19)
        Me.btnLogo.TabIndex = 17
        Me.btnLogo.Text = "..."
        '
        'pbxLogo
        '
        Me.pbxLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbxLogo.Location = New System.Drawing.Point(175, 183)
        Me.pbxLogo.Name = "pbxLogo"
        Me.pbxLogo.Size = New System.Drawing.Size(340, 87)
        Me.pbxLogo.TabIndex = 16
        Me.pbxLogo.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 183)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 16)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Logo (nur Ent.-Edition):"
        '
        'btnTextBodyAndTableBodyFont
        '
        Me.btnTextBodyAndTableBodyFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTextBodyAndTableBodyFont.Location = New System.Drawing.Point(521, 146)
        Me.btnTextBodyAndTableBodyFont.Name = "btnTextBodyAndTableBodyFont"
        Me.btnTextBodyAndTableBodyFont.Size = New System.Drawing.Size(22, 19)
        Me.btnTextBodyAndTableBodyFont.TabIndex = 14
        Me.btnTextBodyAndTableBodyFont.Text = "..."
        '
        'lblTextAndTableBodyFont
        '
        Me.lblTextAndTableBodyFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTextAndTableBodyFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextAndTableBodyFont.Location = New System.Drawing.Point(175, 147)
        Me.lblTextAndTableBodyFont.Name = "lblTextAndTableBodyFont"
        Me.lblTextAndTableBodyFont.Size = New System.Drawing.Size(340, 20)
        Me.lblTextAndTableBodyFont.TabIndex = 13
        Me.lblTextAndTableBodyFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(162, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Text- und Tabellenkörper:"
        '
        'btnTableHeaderFont
        '
        Me.btnTableHeaderFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTableHeaderFont.Location = New System.Drawing.Point(521, 117)
        Me.btnTableHeaderFont.Name = "btnTableHeaderFont"
        Me.btnTableHeaderFont.Size = New System.Drawing.Size(22, 19)
        Me.btnTableHeaderFont.TabIndex = 11
        Me.btnTableHeaderFont.Text = "..."
        '
        'lblTableHeaderFont
        '
        Me.lblTableHeaderFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTableHeaderFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableHeaderFont.Location = New System.Drawing.Point(175, 116)
        Me.lblTableHeaderFont.Name = "lblTableHeaderFont"
        Me.lblTableHeaderFont.Size = New System.Drawing.Size(340, 20)
        Me.lblTableHeaderFont.TabIndex = 10
        Me.lblTableHeaderFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Tabellenköpfe:"
        '
        'btnU3Font
        '
        Me.btnU3Font.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnU3Font.Location = New System.Drawing.Point(521, 88)
        Me.btnU3Font.Name = "btnU3Font"
        Me.btnU3Font.Size = New System.Drawing.Size(22, 19)
        Me.btnU3Font.TabIndex = 8
        Me.btnU3Font.Text = "..."
        '
        'lblFontU3
        '
        Me.lblFontU3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFontU3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFontU3.Location = New System.Drawing.Point(175, 88)
        Me.lblFontU3.Name = "lblFontU3"
        Me.lblFontU3.Size = New System.Drawing.Size(340, 20)
        Me.lblFontU3.TabIndex = 7
        Me.lblFontU3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Überschrift Ebene &3:"
        '
        'btnU2Font
        '
        Me.btnU2Font.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnU2Font.Location = New System.Drawing.Point(521, 58)
        Me.btnU2Font.Name = "btnU2Font"
        Me.btnU2Font.Size = New System.Drawing.Size(22, 19)
        Me.btnU2Font.TabIndex = 5
        Me.btnU2Font.Text = "..."
        '
        'lblFontU2
        '
        Me.lblFontU2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFontU2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFontU2.Location = New System.Drawing.Point(175, 58)
        Me.lblFontU2.Name = "lblFontU2"
        Me.lblFontU2.Size = New System.Drawing.Size(340, 20)
        Me.lblFontU2.TabIndex = 4
        Me.lblFontU2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Überschrift Ebene &2:"
        '
        'btnU1Font
        '
        Me.btnU1Font.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnU1Font.Location = New System.Drawing.Point(521, 29)
        Me.btnU1Font.Name = "btnU1Font"
        Me.btnU1Font.Size = New System.Drawing.Size(22, 19)
        Me.btnU1Font.TabIndex = 2
        Me.btnU1Font.Text = "..."
        '
        'lblFontU1
        '
        Me.lblFontU1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFontU1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFontU1.Location = New System.Drawing.Point(175, 29)
        Me.lblFontU1.Name = "lblFontU1"
        Me.lblFontU1.Size = New System.Drawing.Size(340, 20)
        Me.lblFontU1.TabIndex = 1
        Me.lblFontU1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Überschrift Ebene 1:"
        '
        'tpThresholdValues
        '
        Me.tpThresholdValues.Controls.Add(Me.GroupBox8)
        Me.tpThresholdValues.Controls.Add(Me.GroupBox7)
        Me.tpThresholdValues.Location = New System.Drawing.Point(4, 25)
        Me.tpThresholdValues.Name = "tpThresholdValues"
        Me.tpThresholdValues.Padding = New System.Windows.Forms.Padding(3)
        Me.tpThresholdValues.Size = New System.Drawing.Size(606, 526)
        Me.tpThresholdValues.TabIndex = 3
        Me.tpThresholdValues.Text = "Datenübernahme-Optionen"
        Me.tpThresholdValues.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.nibThresholdFirstShift)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.dtbFallBackTimeEnd)
        Me.GroupBox7.Controls.Add(Me.dtbFallBackTimeStart)
        Me.GroupBox7.Location = New System.Drawing.Point(23, 28)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(546, 169)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Fallback-Times (für die Schichtzuweisung von Zeitübernahmedaten)"
        '
        'nibThresholdFirstShift
        '
        Me.nibThresholdFirstShift.BackColor = System.Drawing.SystemColors.Window
        Me.nibThresholdFirstShift.CaptionToValueRatio = 700.35
        Me.nibThresholdFirstShift.ColorOnFocus = True
        Me.nibThresholdFirstShift.FailedValidationErrorMessage = Nothing
        Me.nibThresholdFirstShift.FormularText = ""
        Me.nibThresholdFirstShift.HasCaption = True
        Me.nibThresholdFirstShift.IndependentDatafieldName = Nothing
        Me.nibThresholdFirstShift.Location = New System.Drawing.Point(16, 112)
        Me.nibThresholdFirstShift.MaxValue = 0
        Me.nibThresholdFirstShift.MinValue = 0
        Me.nibThresholdFirstShift.Name = "nibThresholdFirstShift"
        Me.nibThresholdFirstShift.NullString = "* --- *"
        Me.nibThresholdFirstShift.NullValueMessage = "Bitte geben Sie einen Wert für die Schwelle zur ersten Schicht in Minuten ein."
        Me.nibThresholdFirstShift.Size = New System.Drawing.Size(287, 22)
        Me.nibThresholdFirstShift.TabIndex = 4
        Me.nibThresholdFirstShift.Text = "Schwellwert 1. Schicht (min):"
        Me.nibThresholdFirstShift.ValueAreaLength = 86
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(339, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(181, 88)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "HINWEIS: Diese Werte bestimmen Sie für die Unter-/Obergrenze der ersten Schicht, " & _
            "damit beim Rauslaufen von Übernahmedaten aus einem Schichtmodell eine Zuweisung " & _
            "dennoch möglich wird."
        '
        'dtbFallBackTimeEnd
        '
        Me.dtbFallBackTimeEnd.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.dtbFallBackTimeEnd.BackColor = System.Drawing.SystemColors.Window
        Me.dtbFallBackTimeEnd.CaptionToValueRatio = 700.35
        Me.dtbFallBackTimeEnd.ColorOnFocus = True
        Me.dtbFallBackTimeEnd.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.dtbFallBackTimeEnd.FailedValidationErrorMessage = Nothing
        Me.dtbFallBackTimeEnd.HasCaption = True
        Me.dtbFallBackTimeEnd.IndependentDatafieldName = Nothing
        Me.dtbFallBackTimeEnd.Location = New System.Drawing.Point(16, 70)
        Me.dtbFallBackTimeEnd.Name = "dtbFallBackTimeEnd"
        Me.dtbFallBackTimeEnd.NullString = "* --- *"
        Me.dtbFallBackTimeEnd.NullValueMessage = "Bitte bestimmen Sie die Fallback-Ende-Zeit."
        Me.dtbFallBackTimeEnd.Size = New System.Drawing.Size(287, 22)
        Me.dtbFallBackTimeEnd.TabIndex = 1
        Me.dtbFallBackTimeEnd.Text = "Fallback Time (Ende):"
        Me.dtbFallBackTimeEnd.ValueAreaLength = 86
        '
        'dtbFallBackTimeStart
        '
        Me.dtbFallBackTimeStart.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.dtbFallBackTimeStart.BackColor = System.Drawing.SystemColors.Window
        Me.dtbFallBackTimeStart.CaptionToValueRatio = 700.35
        Me.dtbFallBackTimeStart.ColorOnFocus = True
        Me.dtbFallBackTimeStart.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime
        Me.dtbFallBackTimeStart.FailedValidationErrorMessage = Nothing
        Me.dtbFallBackTimeStart.HasCaption = True
        Me.dtbFallBackTimeStart.IndependentDatafieldName = Nothing
        Me.dtbFallBackTimeStart.Location = New System.Drawing.Point(16, 29)
        Me.dtbFallBackTimeStart.Name = "dtbFallBackTimeStart"
        Me.dtbFallBackTimeStart.NullString = "* --- *"
        Me.dtbFallBackTimeStart.NullValueMessage = "Bitte bestimmen Sie die Fallback-Start-Zeit."
        Me.dtbFallBackTimeStart.Size = New System.Drawing.Size(287, 22)
        Me.dtbFallBackTimeStart.TabIndex = 0
        Me.dtbFallBackTimeStart.Text = "Fallback Time (Start):"
        Me.dtbFallBackTimeStart.ValueAreaLength = 86
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(401, 580)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(109, 33)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(516, 580)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(109, 33)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Abbrechen"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label15)
        Me.GroupBox8.Controls.Add(Me.chkShowIssueListPriorToImport)
        Me.GroupBox8.Controls.Add(Me.chkShowTimeLogPriorToImport)
        Me.GroupBox8.Location = New System.Drawing.Point(23, 218)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(546, 169)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Optionen bei der Zeitenübernahme:"
        '
        'chkShowTimeLogPriorToImport
        '
        Me.chkShowTimeLogPriorToImport.AutoSize = True
        Me.chkShowTimeLogPriorToImport.Location = New System.Drawing.Point(16, 41)
        Me.chkShowTimeLogPriorToImport.Name = "chkShowTimeLogPriorToImport"
        Me.chkShowTimeLogPriorToImport.Size = New System.Drawing.Size(299, 20)
        Me.chkShowTimeLogPriorToImport.TabIndex = 4
        Me.chkShowTimeLogPriorToImport.Text = "Ergebnistabelle vor der Übernahme anzeigen"
        Me.chkShowTimeLogPriorToImport.UseVisualStyleBackColor = True
        '
        'chkShowIssueListPriorToImport
        '
        Me.chkShowIssueListPriorToImport.AutoSize = True
        Me.chkShowIssueListPriorToImport.Location = New System.Drawing.Point(16, 67)
        Me.chkShowIssueListPriorToImport.Name = "chkShowIssueListPriorToImport"
        Me.chkShowIssueListPriorToImport.Size = New System.Drawing.Size(266, 20)
        Me.chkShowIssueListPriorToImport.TabIndex = 5
        Me.chkShowIssueListPriorToImport.Text = "Fehlerliste vor der Übernahme anzeigen"
        Me.chkShowIssueListPriorToImport.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(339, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(181, 88)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "HINWEIS: Diese Einstellungen beziehen sich nur auf die Übernahme von Zeitdaten au" & _
            "s Fremdsystemen (Legatro, Interflex, etc.)"
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 636)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tcMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Optionen"
        Me.tcMain.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.tpTimeSettingDefaults.ResumeLayout(False)
        Me.tpLayoutAndNumberformats.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpThresholdValues.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tpTimeSettingDefaults As System.Windows.Forms.TabPage
    Friend WithEvents tpLayoutAndNumberformats As System.Windows.Forms.TabPage
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents UcTimeDetailsSettings As Facesso.FrontEnd.ucTimeDetailsSettings
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnU1Font As System.Windows.Forms.Button
    Friend WithEvents lblFontU1 As System.Windows.Forms.Label
    Friend WithEvents btnTextBodyAndTableBodyFont As System.Windows.Forms.Button
    Friend WithEvents lblTextAndTableBodyFont As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnTableHeaderFont As System.Windows.Forms.Button
    Friend WithEvents lblTableHeaderFont As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnU3Font As System.Windows.Forms.Button
    Friend WithEvents lblFontU3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnU2Font As System.Windows.Forms.Button
    Friend WithEvents lblFontU2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnLogo As System.Windows.Forms.Button
    Friend WithEvents pbxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbHMinutesPrecision As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbGridStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnPreView As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tpGeneral As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSundayIsWorkday As System.Windows.Forms.CheckBox
    Friend WithEvents chkSaturdayIsWorkday As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkAutomateMainFormUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnChooseSqlConnectionString As System.Windows.Forms.Button
    Friend WithEvents txtSQLLoginString As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents FacessoPathSettings As Facesso.ucFacessoPathSettings
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAssignToWorkgroups As System.Windows.Forms.Button
    Friend WithEvents tpThresholdValues As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents dtbFallBackTimeStart As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents dtbFallBackTimeEnd As ActiveDev.Controls.ADNullableDateTimeBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nibThresholdFirstShift As ActiveDev.Controls.ADNullableIntBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowIssueListPriorToImport As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowTimeLogPriorToImport As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class

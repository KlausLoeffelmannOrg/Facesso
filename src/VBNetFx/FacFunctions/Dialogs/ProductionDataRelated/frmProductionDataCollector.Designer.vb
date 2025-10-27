<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmProductionDataCollector
    Inherits frmBaseFacesso

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductionDataCollector))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmProductionData = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmSaveChanges = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlleEingabenzurücksetzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DialogbeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MitarbeiterdatenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmEmployeeTime = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmDeleteTimeEntries = New System.Windows.Forms.ToolStripMenuItem()
        Me.NavigationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmNextWorkgroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmPrevWorkgroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmNextWorkDay = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmMyTodoList = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmPrevWorkday = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmShift1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmShift2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmShift3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmShift4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmView = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmShowEmployees = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmOnlyShowActiveLabourValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslSaveImage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslSaveState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslCurrentDateInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.splitProductionData_Employees = New System.Windows.Forms.SplitContainer()
        Me.gbProductionData = New System.Windows.Forms.GroupBox()
        Me.dgvProductionData = New Facesso.FrontEnd.ucProductionDataGridView()
        Me.gbEmployees = New System.Windows.Forms.GroupBox()
        Me.dgvTimeLogItems = New Facesso.FrontEnd.ucTimeLogItemsDataGridView()
        Me.layoutAreaLowerLevel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDegreeOfTime = New System.Windows.Forms.Label()
        Me.lblMinutesEffective = New System.Windows.Forms.Label()
        Me.lblMinutesEffectiveAdj = New System.Windows.Forms.Label()
        Me.upperPanel = New System.Windows.Forms.Panel()
        Me.layoutPanelUpperArea = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMinutesReference = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtpProductionDate = New System.Windows.Forms.DateTimePicker()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkgroup = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNewEmployeeTimes = New System.Windows.Forms.ToolStripButton()
        Me.tsmDeleteShiftData = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsbDeleteTimeDataOnly = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDeleteProductionDataOnly = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tssbPrint = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsmOnlyPrintEmployees = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmOnlyPrintProductionData = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbSaveChanges = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbNullData = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreviousWorkday = New System.Windows.Forms.ToolStripButton()
        Me.tsbMyTodoList = New System.Windows.Forms.ToolStripButton()
        Me.tsbNextWorkDay = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreviousWorkgroup = New System.Windows.Forms.ToolStripButton()
        Me.tsbNextWorkgroup = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbShift1 = New System.Windows.Forms.ToolStripButton()
        Me.tsbShift2 = New System.Windows.Forms.ToolStripButton()
        Me.tsbShift3 = New System.Windows.Forms.ToolStripButton()
        Me.tsbShift4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslSites = New System.Windows.Forms.ToolStripLabel()
        Me.tscWorkGroup = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.mainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.splitProductionData_Employees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitProductionData_Employees.Panel1.SuspendLayout()
        Me.splitProductionData_Employees.Panel2.SuspendLayout()
        Me.splitProductionData_Employees.SuspendLayout()
        Me.gbProductionData.SuspendLayout()
        CType(Me.dgvProductionData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEmployees.SuspendLayout()
        CType(Me.dgvTimeLogItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutAreaLowerLevel.SuspendLayout()
        Me.upperPanel.SuspendLayout()
        Me.layoutPanelUpperArea.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmProductionData, Me.MitarbeiterdatenToolStripMenuItem, Me.NavigationToolStripMenuItem, Me.tsmView})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(772, 22)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmProductionData
        '
        Me.tsmProductionData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSaveChanges, Me.AlleEingabenzurücksetzenToolStripMenuItem, Me.ToolStripSeparator1, Me.DialogbeendenToolStripMenuItem})
        Me.tsmProductionData.Name = "tsmProductionData"
        Me.tsmProductionData.Size = New System.Drawing.Size(115, 18)
        Me.tsmProductionData.Text = "&Produktionsdaten"
        '
        'tsmSaveChanges
        '
        Me.tsmSaveChanges.Image = CType(resources.GetObject("tsmSaveChanges.Image"), System.Drawing.Image)
        Me.tsmSaveChanges.Name = "tsmSaveChanges"
        Me.tsmSaveChanges.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.tsmSaveChanges.Size = New System.Drawing.Size(243, 22)
        Me.tsmSaveChanges.Text = "Änderungen speichern"
        '
        'AlleEingabenzurücksetzenToolStripMenuItem
        '
        Me.AlleEingabenzurücksetzenToolStripMenuItem.Image = CType(resources.GetObject("AlleEingabenzurücksetzenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AlleEingabenzurücksetzenToolStripMenuItem.Name = "AlleEingabenzurücksetzenToolStripMenuItem"
        Me.AlleEingabenzurücksetzenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.AlleEingabenzurücksetzenToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.AlleEingabenzurücksetzenToolStripMenuItem.Text = "Alle Eingaben nullen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(240, 6)
        '
        'DialogbeendenToolStripMenuItem
        '
        Me.DialogbeendenToolStripMenuItem.Name = "DialogbeendenToolStripMenuItem"
        Me.DialogbeendenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.DialogbeendenToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.DialogbeendenToolStripMenuItem.Text = "Dialog be&enden"
        '
        'MitarbeiterdatenToolStripMenuItem
        '
        Me.MitarbeiterdatenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmEmployeeTime, Me.ToolStripSeparator10, Me.tsmDeleteTimeEntries})
        Me.MitarbeiterdatenToolStripMenuItem.Name = "MitarbeiterdatenToolStripMenuItem"
        Me.MitarbeiterdatenToolStripMenuItem.Size = New System.Drawing.Size(109, 18)
        Me.MitarbeiterdatenToolStripMenuItem.Text = "&Mitarbeiterdaten"
        '
        'tsmEmployeeTime
        '
        Me.tsmEmployeeTime.Image = CType(resources.GetObject("tsmEmployeeTime.Image"), System.Drawing.Image)
        Me.tsmEmployeeTime.Name = "tsmEmployeeTime"
        Me.tsmEmployeeTime.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.tsmEmployeeTime.Size = New System.Drawing.Size(275, 22)
        Me.tsmEmployeeTime.Text = "Mitarbeiterzeiten hinzufügen..."
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(272, 6)
        '
        'tsmDeleteTimeEntries
        '
        Me.tsmDeleteTimeEntries.Name = "tsmDeleteTimeEntries"
        Me.tsmDeleteTimeEntries.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.tsmDeleteTimeEntries.Size = New System.Drawing.Size(275, 22)
        Me.tsmDeleteTimeEntries.Text = "Markierte Mitarbeiter entfernen"
        '
        'NavigationToolStripMenuItem
        '
        Me.NavigationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmNextWorkgroup, Me.tsmPrevWorkgroup, Me.ToolStripSeparator8, Me.tsmNextWorkDay, Me.tsmMyTodoList, Me.tsmPrevWorkday, Me.ToolStripSeparator9, Me.tsmShift1, Me.tsmShift2, Me.tsmShift3, Me.tsmShift4})
        Me.NavigationToolStripMenuItem.Name = "NavigationToolStripMenuItem"
        Me.NavigationToolStripMenuItem.Size = New System.Drawing.Size(75, 18)
        Me.NavigationToolStripMenuItem.Text = "&Navigation"
        '
        'tsmNextWorkgroup
        '
        Me.tsmNextWorkgroup.Image = CType(resources.GetObject("tsmNextWorkgroup.Image"), System.Drawing.Image)
        Me.tsmNextWorkgroup.Name = "tsmNextWorkgroup"
        Me.tsmNextWorkgroup.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)
        Me.tsmNextWorkgroup.Size = New System.Drawing.Size(267, 22)
        Me.tsmNextWorkgroup.Text = "Nächste Produktiv-Site"
        '
        'tsmPrevWorkgroup
        '
        Me.tsmPrevWorkgroup.Image = CType(resources.GetObject("tsmPrevWorkgroup.Image"), System.Drawing.Image)
        Me.tsmPrevWorkgroup.Name = "tsmPrevWorkgroup"
        Me.tsmPrevWorkgroup.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)
        Me.tsmPrevWorkgroup.Size = New System.Drawing.Size(267, 22)
        Me.tsmPrevWorkgroup.Text = "Vorherige Produktiv-Site"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(264, 6)
        '
        'tsmNextWorkDay
        '
        Me.tsmNextWorkDay.Image = CType(resources.GetObject("tsmNextWorkDay.Image"), System.Drawing.Image)
        Me.tsmNextWorkDay.Name = "tsmNextWorkDay"
        Me.tsmNextWorkDay.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Right), System.Windows.Forms.Keys)
        Me.tsmNextWorkDay.Size = New System.Drawing.Size(267, 22)
        Me.tsmNextWorkDay.Text = "Nächster Arbeitstag"
        '
        'tsmMyTodoList
        '
        Me.tsmMyTodoList.Image = CType(resources.GetObject("tsmMyTodoList.Image"), System.Drawing.Image)
        Me.tsmMyTodoList.Name = "tsmMyTodoList"
        Me.tsmMyTodoList.Size = New System.Drawing.Size(267, 22)
        Me.tsmMyTodoList.Text = "Meine To-Do-Liste..."
        '
        'tsmPrevWorkday
        '
        Me.tsmPrevWorkday.Image = CType(resources.GetObject("tsmPrevWorkday.Image"), System.Drawing.Image)
        Me.tsmPrevWorkday.Name = "tsmPrevWorkday"
        Me.tsmPrevWorkday.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Left), System.Windows.Forms.Keys)
        Me.tsmPrevWorkday.Size = New System.Drawing.Size(267, 22)
        Me.tsmPrevWorkday.Text = "Vorheriger Arbeitstag"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(264, 6)
        '
        'tsmShift1
        '
        Me.tsmShift1.Image = CType(resources.GetObject("tsmShift1.Image"), System.Drawing.Image)
        Me.tsmShift1.Name = "tsmShift1"
        Me.tsmShift1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.tsmShift1.Size = New System.Drawing.Size(267, 22)
        Me.tsmShift1.Text = "Schicht 1"
        '
        'tsmShift2
        '
        Me.tsmShift2.Image = CType(resources.GetObject("tsmShift2.Image"), System.Drawing.Image)
        Me.tsmShift2.Name = "tsmShift2"
        Me.tsmShift2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.tsmShift2.Size = New System.Drawing.Size(267, 22)
        Me.tsmShift2.Text = "Schicht 2"
        '
        'tsmShift3
        '
        Me.tsmShift3.Image = CType(resources.GetObject("tsmShift3.Image"), System.Drawing.Image)
        Me.tsmShift3.Name = "tsmShift3"
        Me.tsmShift3.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D3), System.Windows.Forms.Keys)
        Me.tsmShift3.Size = New System.Drawing.Size(267, 22)
        Me.tsmShift3.Text = "Schicht 3"
        '
        'tsmShift4
        '
        Me.tsmShift4.Image = CType(resources.GetObject("tsmShift4.Image"), System.Drawing.Image)
        Me.tsmShift4.Name = "tsmShift4"
        Me.tsmShift4.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)
        Me.tsmShift4.Size = New System.Drawing.Size(267, 22)
        Me.tsmShift4.Text = "Sonderschicht"
        '
        'tsmView
        '
        Me.tsmView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmShowEmployees, Me.ToolStripMenuItem1, Me.tsmOnlyShowActiveLabourValues})
        Me.tsmView.Name = "tsmView"
        Me.tsmView.Size = New System.Drawing.Size(59, 18)
        Me.tsmView.Text = "&Ansicht"
        '
        'tsmShowEmployees
        '
        Me.tsmShowEmployees.Name = "tsmShowEmployees"
        Me.tsmShowEmployees.Size = New System.Drawing.Size(256, 22)
        Me.tsmShowEmployees.Text = "Beteiligte Mitarbeiter"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(253, 6)
        '
        'tsmOnlyShowActiveLabourValues
        '
        Me.tsmOnlyShowActiveLabourValues.Checked = True
        Me.tsmOnlyShowActiveLabourValues.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmOnlyShowActiveLabourValues.Name = "tsmOnlyShowActiveLabourValues"
        Me.tsmOnlyShowActiveLabourValues.Size = New System.Drawing.Size(256, 22)
        Me.tsmOnlyShowActiveLabourValues.Text = "Nur aktive Arbeitswerte anzeigen"
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.StatusStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.splitProductionData_Employees)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.upperPanel)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(772, 454)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(772, 526)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslSaveImage, Me.tslSaveState, Me.tslCurrentDateInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(772, 25)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslSaveImage
        '
        Me.tslSaveImage.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslSaveImage.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tslSaveImage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslSaveImage.Image = CType(resources.GetObject("tslSaveImage.Image"), System.Drawing.Image)
        Me.tslSaveImage.Name = "tslSaveImage"
        Me.tslSaveImage.Size = New System.Drawing.Size(48, 20)
        Me.tslSaveImage.Text = "         "
        Me.tslSaveImage.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'tslSaveState
        '
        Me.tslSaveState.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslSaveState.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tslSaveState.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslSaveState.Name = "tslSaveState"
        Me.tslSaveState.Size = New System.Drawing.Size(263, 20)
        Me.tslSaveState.Text = "Es wurden keine Mengenänderungen vorgenommen."
        '
        'tslCurrentDateInfo
        '
        Me.tslCurrentDateInfo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslCurrentDateInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tslCurrentDateInfo.Name = "tslCurrentDateInfo"
        Me.tslCurrentDateInfo.Size = New System.Drawing.Size(446, 20)
        Me.tslCurrentDateInfo.Spring = True
        Me.tslCurrentDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'splitProductionData_Employees
        '
        Me.splitProductionData_Employees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitProductionData_Employees.Location = New System.Drawing.Point(0, 65)
        Me.splitProductionData_Employees.Name = "splitProductionData_Employees"
        Me.splitProductionData_Employees.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitProductionData_Employees.Panel1
        '
        Me.splitProductionData_Employees.Panel1.Controls.Add(Me.gbProductionData)
        '
        'splitProductionData_Employees.Panel2
        '
        Me.splitProductionData_Employees.Panel2.Controls.Add(Me.gbEmployees)
        Me.splitProductionData_Employees.Size = New System.Drawing.Size(772, 389)
        Me.splitProductionData_Employees.SplitterDistance = 212
        Me.splitProductionData_Employees.TabIndex = 4
        Me.splitProductionData_Employees.Text = "SplitContainer1"
        '
        'gbProductionData
        '
        Me.gbProductionData.Controls.Add(Me.dgvProductionData)
        Me.gbProductionData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbProductionData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProductionData.Location = New System.Drawing.Point(0, 0)
        Me.gbProductionData.Name = "gbProductionData"
        Me.gbProductionData.Size = New System.Drawing.Size(772, 212)
        Me.gbProductionData.TabIndex = 0
        Me.gbProductionData.TabStop = False
        Me.gbProductionData.Text = "Produktionsdaten:"
        '
        'dgvProductionData
        '
        Me.dgvProductionData.AllowUserToAddRows = False
        Me.dgvProductionData.AllowUserToDeleteRows = False
        Me.dgvProductionData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgvProductionData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductionData.Location = New System.Drawing.Point(3, 18)
        Me.dgvProductionData.Name = "dgvProductionData"
        Me.dgvProductionData.OnlyShowActivatedLabourValues = False
        Me.dgvProductionData.ProductionData = Nothing
        Me.dgvProductionData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductionData.Size = New System.Drawing.Size(766, 191)
        Me.dgvProductionData.TabIndex = 0
        Me.dgvProductionData.Text = "DataGridView1"
        '
        'gbEmployees
        '
        Me.gbEmployees.Controls.Add(Me.dgvTimeLogItems)
        Me.gbEmployees.Controls.Add(Me.layoutAreaLowerLevel)
        Me.gbEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEmployees.Location = New System.Drawing.Point(0, 0)
        Me.gbEmployees.Name = "gbEmployees"
        Me.gbEmployees.Size = New System.Drawing.Size(772, 173)
        Me.gbEmployees.TabIndex = 0
        Me.gbEmployees.TabStop = False
        Me.gbEmployees.Text = "Beteiligte Mitarbeiter"
        '
        'dgvTimeLogItems
        '
        Me.dgvTimeLogItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTimeLogItems.EmployeeTimeLogItems = Nothing
        Me.dgvTimeLogItems.Location = New System.Drawing.Point(3, 18)
        Me.dgvTimeLogItems.Name = "dgvTimeLogItems"
        Me.dgvTimeLogItems.SingleEmployeeList = False
        Me.dgvTimeLogItems.Size = New System.Drawing.Size(766, 128)
        Me.dgvTimeLogItems.TabIndex = 3
        Me.dgvTimeLogItems.Text = "UcTimeLogItemsDataGridView1"
        '
        'layoutAreaLowerLevel
        '
        Me.layoutAreaLowerLevel.ColumnCount = 3
        Me.layoutAreaLowerLevel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.layoutAreaLowerLevel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.layoutAreaLowerLevel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.layoutAreaLowerLevel.Controls.Add(Me.lblDegreeOfTime, 2, 0)
        Me.layoutAreaLowerLevel.Controls.Add(Me.lblMinutesEffective, 0, 0)
        Me.layoutAreaLowerLevel.Controls.Add(Me.lblMinutesEffectiveAdj, 1, 0)
        Me.layoutAreaLowerLevel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.layoutAreaLowerLevel.Location = New System.Drawing.Point(3, 146)
        Me.layoutAreaLowerLevel.Name = "layoutAreaLowerLevel"
        Me.layoutAreaLowerLevel.RowCount = 1
        Me.layoutAreaLowerLevel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutAreaLowerLevel.Size = New System.Drawing.Size(766, 24)
        Me.layoutAreaLowerLevel.TabIndex = 2
        '
        'lblDegreeOfTime
        '
        Me.lblDegreeOfTime.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblDegreeOfTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDegreeOfTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDegreeOfTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDegreeOfTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDegreeOfTime.Location = New System.Drawing.Point(510, 0)
        Me.lblDegreeOfTime.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDegreeOfTime.Name = "lblDegreeOfTime"
        Me.lblDegreeOfTime.Size = New System.Drawing.Size(256, 24)
        Me.lblDegreeOfTime.TabIndex = 3
        Me.lblDegreeOfTime.Text = "Zeitgrad:"
        Me.lblDegreeOfTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMinutesEffective
        '
        Me.lblMinutesEffective.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblMinutesEffective.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinutesEffective.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMinutesEffective.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinutesEffective.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMinutesEffective.Location = New System.Drawing.Point(0, 0)
        Me.lblMinutesEffective.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMinutesEffective.Name = "lblMinutesEffective"
        Me.lblMinutesEffective.Size = New System.Drawing.Size(255, 24)
        Me.lblMinutesEffective.TabIndex = 1
        Me.lblMinutesEffective.Text = "Min. Effektiv:"
        Me.lblMinutesEffective.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMinutesEffectiveAdj
        '
        Me.lblMinutesEffectiveAdj.AutoSize = True
        Me.lblMinutesEffectiveAdj.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblMinutesEffectiveAdj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinutesEffectiveAdj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMinutesEffectiveAdj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinutesEffectiveAdj.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMinutesEffectiveAdj.Location = New System.Drawing.Point(255, 0)
        Me.lblMinutesEffectiveAdj.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMinutesEffectiveAdj.Name = "lblMinutesEffectiveAdj"
        Me.lblMinutesEffectiveAdj.Size = New System.Drawing.Size(255, 24)
        Me.lblMinutesEffectiveAdj.TabIndex = 2
        Me.lblMinutesEffectiveAdj.Text = "Min. Effektiv (ang.):"
        Me.lblMinutesEffectiveAdj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'upperPanel
        '
        Me.upperPanel.Controls.Add(Me.layoutPanelUpperArea)
        Me.upperPanel.Controls.Add(Me.lblWorkgroup)
        Me.upperPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.upperPanel.Location = New System.Drawing.Point(0, 0)
        Me.upperPanel.Name = "upperPanel"
        Me.upperPanel.Size = New System.Drawing.Size(772, 65)
        Me.upperPanel.TabIndex = 5
        '
        'layoutPanelUpperArea
        '
        Me.layoutPanelUpperArea.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.layoutPanelUpperArea.ColumnCount = 2
        Me.layoutPanelUpperArea.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.layoutPanelUpperArea.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.layoutPanelUpperArea.Controls.Add(Me.lblMinutesReference, 1, 0)
        Me.layoutPanelUpperArea.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.layoutPanelUpperArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutPanelUpperArea.Location = New System.Drawing.Point(0, 34)
        Me.layoutPanelUpperArea.Margin = New System.Windows.Forms.Padding(0)
        Me.layoutPanelUpperArea.Name = "layoutPanelUpperArea"
        Me.layoutPanelUpperArea.RowCount = 1
        Me.layoutPanelUpperArea.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutPanelUpperArea.Size = New System.Drawing.Size(772, 31)
        Me.layoutPanelUpperArea.TabIndex = 3
        '
        'lblMinutesReference
        '
        Me.lblMinutesReference.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblMinutesReference.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMinutesReference.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinutesReference.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMinutesReference.Location = New System.Drawing.Point(501, 0)
        Me.lblMinutesReference.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMinutesReference.Name = "lblMinutesReference"
        Me.lblMinutesReference.Size = New System.Drawing.Size(271, 31)
        Me.lblMinutesReference.TabIndex = 2
        Me.lblMinutesReference.Text = "Min. Referenz:"
        Me.lblMinutesReference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dtpProductionDate, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShift, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(501, 31)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dtpProductionDate
        '
        Me.dtpProductionDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpProductionDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpProductionDate.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.dtpProductionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpProductionDate.Location = New System.Drawing.Point(0, 4)
        Me.dtpProductionDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpProductionDate.Name = "dtpProductionDate"
        Me.dtpProductionDate.Size = New System.Drawing.Size(220, 22)
        Me.dtpProductionDate.TabIndex = 5
        '
        'lblShift
        '
        Me.lblShift.AutoEllipsis = True
        Me.lblShift.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblShift.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblShift.Location = New System.Drawing.Point(225, 0)
        Me.lblShift.Margin = New System.Windows.Forms.Padding(0)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(276, 31)
        Me.lblShift.TabIndex = 6
        Me.lblShift.Text = "Schicht 1"
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWorkgroup
        '
        Me.lblWorkgroup.AutoEllipsis = True
        Me.lblWorkgroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblWorkgroup.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblWorkgroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkgroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblWorkgroup.Location = New System.Drawing.Point(0, 0)
        Me.lblWorkgroup.Margin = New System.Windows.Forms.Padding(0)
        Me.lblWorkgroup.Name = "lblWorkgroup"
        Me.lblWorkgroup.Size = New System.Drawing.Size(772, 34)
        Me.lblWorkgroup.TabIndex = 2
        Me.lblWorkgroup.Text = "Datenerfassung für:"
        Me.lblWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNewEmployeeTimes, Me.tsmDeleteShiftData, Me.ToolStripSeparator3, Me.tssbPrint, Me.tsbSaveChanges, Me.ToolStripSeparator4, Me.tsbNullData, Me.ToolStripSeparator2, Me.tsbPreviousWorkday, Me.tsbMyTodoList, Me.tsbNextWorkDay, Me.ToolStripSeparator7, Me.tsbPreviousWorkgroup, Me.tsbNextWorkgroup, Me.ToolStripSeparator6, Me.tsbShift1, Me.tsbShift2, Me.tsbShift3, Me.tsbShift4, Me.ToolStripSeparator11, Me.tslSites, Me.tscWorkGroup, Me.ToolStripSeparator5, Me.tsbBack})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 22)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(772, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNewEmployeeTimes
        '
        Me.tsbNewEmployeeTimes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNewEmployeeTimes.Image = CType(resources.GetObject("tsbNewEmployeeTimes.Image"), System.Drawing.Image)
        Me.tsbNewEmployeeTimes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewEmployeeTimes.Name = "tsbNewEmployeeTimes"
        Me.tsbNewEmployeeTimes.Size = New System.Drawing.Size(23, 22)
        Me.tsbNewEmployeeTimes.Text = "Neuer Mitarbeiter in Zeiterfassung"
        '
        'tsmDeleteShiftData
        '
        Me.tsmDeleteShiftData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsmDeleteShiftData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDeleteTimeDataOnly, Me.tsmDeleteProductionDataOnly})
        Me.tsmDeleteShiftData.Image = CType(resources.GetObject("tsmDeleteShiftData.Image"), System.Drawing.Image)
        Me.tsmDeleteShiftData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsmDeleteShiftData.Name = "tsmDeleteShiftData"
        Me.tsmDeleteShiftData.Size = New System.Drawing.Size(32, 22)
        Me.tsmDeleteShiftData.Text = "ToolStripSplitButton1"
        Me.tsmDeleteShiftData.ToolTipText = "Zeit- und Produktionsdaten dieser Schicht löschen"
        '
        'tsbDeleteTimeDataOnly
        '
        Me.tsbDeleteTimeDataOnly.Name = "tsbDeleteTimeDataOnly"
        Me.tsbDeleteTimeDataOnly.Size = New System.Drawing.Size(311, 22)
        Me.tsbDeleteTimeDataOnly.Text = "Nur Zeitdaten dieser Schicht löschen..."
        '
        'tsmDeleteProductionDataOnly
        '
        Me.tsmDeleteProductionDataOnly.Name = "tsmDeleteProductionDataOnly"
        Me.tsmDeleteProductionDataOnly.Size = New System.Drawing.Size(311, 22)
        Me.tsmDeleteProductionDataOnly.Text = "Nur Produktionsdaten dieser Schicht löschen"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tssbPrint
        '
        Me.tssbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tssbPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmOnlyPrintEmployees, Me.tsmOnlyPrintProductionData})
        Me.tssbPrint.Image = CType(resources.GetObject("tssbPrint.Image"), System.Drawing.Image)
        Me.tssbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tssbPrint.Name = "tssbPrint"
        Me.tssbPrint.Size = New System.Drawing.Size(32, 22)
        Me.tssbPrint.Text = "Diese Schichtbetrachtung drucken"
        '
        'tsmOnlyPrintEmployees
        '
        Me.tsmOnlyPrintEmployees.Name = "tsmOnlyPrintEmployees"
        Me.tsmOnlyPrintEmployees.Size = New System.Drawing.Size(237, 22)
        Me.tsmOnlyPrintEmployees.Text = "Nur Mitarbeiter drucken"
        '
        'tsmOnlyPrintProductionData
        '
        Me.tsmOnlyPrintProductionData.Name = "tsmOnlyPrintProductionData"
        Me.tsmOnlyPrintProductionData.Size = New System.Drawing.Size(237, 22)
        Me.tsmOnlyPrintProductionData.Text = "Nur Produktionsdaten drucken"
        '
        'tsbSaveChanges
        '
        Me.tsbSaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSaveChanges.Image = CType(resources.GetObject("tsbSaveChanges.Image"), System.Drawing.Image)
        Me.tsbSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSaveChanges.Name = "tsbSaveChanges"
        Me.tsbSaveChanges.Size = New System.Drawing.Size(23, 22)
        Me.tsbSaveChanges.Text = "Änderungen speichern"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbNullData
        '
        Me.tsbNullData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNullData.Image = CType(resources.GetObject("tsbNullData.Image"), System.Drawing.Image)
        Me.tsbNullData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNullData.Name = "tsbNullData"
        Me.tsbNullData.Size = New System.Drawing.Size(23, 22)
        Me.tsbNullData.Text = "Alle Daten Nullen"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPreviousWorkday
        '
        Me.tsbPreviousWorkday.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPreviousWorkday.Image = CType(resources.GetObject("tsbPreviousWorkday.Image"), System.Drawing.Image)
        Me.tsbPreviousWorkday.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreviousWorkday.Name = "tsbPreviousWorkday"
        Me.tsbPreviousWorkday.Size = New System.Drawing.Size(23, 22)
        Me.tsbPreviousWorkday.Text = "Vorheriger Arbeitstag"
        '
        'tsbMyTodoList
        '
        Me.tsbMyTodoList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMyTodoList.Image = CType(resources.GetObject("tsbMyTodoList.Image"), System.Drawing.Image)
        Me.tsbMyTodoList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMyTodoList.Name = "tsbMyTodoList"
        Me.tsbMyTodoList.Size = New System.Drawing.Size(23, 22)
        Me.tsbMyTodoList.Text = "Meine To-Do-List"
        '
        'tsbNextWorkDay
        '
        Me.tsbNextWorkDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNextWorkDay.Image = CType(resources.GetObject("tsbNextWorkDay.Image"), System.Drawing.Image)
        Me.tsbNextWorkDay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNextWorkDay.Name = "tsbNextWorkDay"
        Me.tsbNextWorkDay.Size = New System.Drawing.Size(23, 22)
        Me.tsbNextWorkDay.Text = "Nächster Arbeitstag"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPreviousWorkgroup
        '
        Me.tsbPreviousWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPreviousWorkgroup.Image = CType(resources.GetObject("tsbPreviousWorkgroup.Image"), System.Drawing.Image)
        Me.tsbPreviousWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreviousWorkgroup.Name = "tsbPreviousWorkgroup"
        Me.tsbPreviousWorkgroup.Size = New System.Drawing.Size(23, 22)
        Me.tsbPreviousWorkgroup.Text = "Vorherige Produktiv-Site"
        '
        'tsbNextWorkgroup
        '
        Me.tsbNextWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNextWorkgroup.Image = CType(resources.GetObject("tsbNextWorkgroup.Image"), System.Drawing.Image)
        Me.tsbNextWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNextWorkgroup.Name = "tsbNextWorkgroup"
        Me.tsbNextWorkgroup.Size = New System.Drawing.Size(23, 22)
        Me.tsbNextWorkgroup.Text = "Nächste Produktiv-Site"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbShift1
        '
        Me.tsbShift1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbShift1.Image = CType(resources.GetObject("tsbShift1.Image"), System.Drawing.Image)
        Me.tsbShift1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShift1.Name = "tsbShift1"
        Me.tsbShift1.Size = New System.Drawing.Size(23, 22)
        Me.tsbShift1.Text = "1. Schicht"
        '
        'tsbShift2
        '
        Me.tsbShift2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbShift2.Image = CType(resources.GetObject("tsbShift2.Image"), System.Drawing.Image)
        Me.tsbShift2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShift2.Name = "tsbShift2"
        Me.tsbShift2.Size = New System.Drawing.Size(23, 22)
        Me.tsbShift2.Text = "ToolStripButton2"
        Me.tsbShift2.ToolTipText = "2. Schicht"
        '
        'tsbShift3
        '
        Me.tsbShift3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbShift3.Image = CType(resources.GetObject("tsbShift3.Image"), System.Drawing.Image)
        Me.tsbShift3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShift3.Name = "tsbShift3"
        Me.tsbShift3.Size = New System.Drawing.Size(23, 22)
        Me.tsbShift3.Text = "ToolStripButton3"
        Me.tsbShift3.ToolTipText = "3. Schicht"
        '
        'tsbShift4
        '
        Me.tsbShift4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbShift4.Image = CType(resources.GetObject("tsbShift4.Image"), System.Drawing.Image)
        Me.tsbShift4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShift4.Name = "tsbShift4"
        Me.tsbShift4.Size = New System.Drawing.Size(23, 22)
        Me.tsbShift4.Text = "ToolStripButton1"
        Me.tsbShift4.ToolTipText = "Sonderschicht"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'tslSites
        '
        Me.tslSites.Name = "tslSites"
        Me.tslSites.Size = New System.Drawing.Size(34, 22)
        Me.tslSites.Text = "&Sites:"
        '
        'tscWorkGroup
        '
        Me.tscWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscWorkGroup.Name = "tscWorkGroup"
        Me.tscWorkGroup.Size = New System.Drawing.Size(300, 25)
        Me.tscWorkGroup.ToolTipText = "Produktiv-Sites"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbBack
        '
        Me.tsbBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBack.Image = CType(resources.GetObject("tsbBack.Image"), System.Drawing.Image)
        Me.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBack.Name = "tsbBack"
        Me.tsbBack.Size = New System.Drawing.Size(23, 22)
        Me.tsbBack.Text = "Dialog beenden"
        '
        'ToolStrip
        '
        Me.ToolStrip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Location = New System.Drawing.Point(174, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(555, 25)
        Me.ToolStrip.Stretch = True
        Me.ToolStrip.TabIndex = 1
        Me.ToolStrip.Text = "Übernehmen"
        '
        'mainTimer
        '
        Me.mainTimer.Enabled = True
        Me.mainTimer.Interval = 250
        '
        'frmProductionDataCollector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 526)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(780, 560)
        Me.Name = "frmProductionDataCollector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facesso-Datenmanager - Erfassung von Betriebsdaten und Personalzeiten"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.splitProductionData_Employees.Panel1.ResumeLayout(False)
        Me.splitProductionData_Employees.Panel2.ResumeLayout(False)
        CType(Me.splitProductionData_Employees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitProductionData_Employees.ResumeLayout(False)
        Me.gbProductionData.ResumeLayout(False)
        CType(Me.dgvProductionData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEmployees.ResumeLayout(False)
        CType(Me.dgvTimeLogItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutAreaLowerLevel.ResumeLayout(False)
        Me.layoutAreaLowerLevel.PerformLayout()
        Me.upperPanel.ResumeLayout(False)
        Me.layoutPanelUpperArea.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmProductionData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents splitProductionData_Employees As System.Windows.Forms.SplitContainer
    Friend WithEvents upperPanel As System.Windows.Forms.Panel
    Friend WithEvents gbProductionData As System.Windows.Forms.GroupBox
    Friend WithEvents gbEmployees As System.Windows.Forms.GroupBox
    Friend WithEvents tsmView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmShowEmployees As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlleEingabenzurücksetzenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents layoutPanelUpperArea As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblWorkgroup As System.Windows.Forms.Label
    Friend WithEvents layoutAreaLowerLevel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMinutesEffectiveAdj As System.Windows.Forms.Label
    Friend WithEvents lblMinutesEffective As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents DialogbeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSaveChanges As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNullData As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbNextWorkDay As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbMyTodoList As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPreviousWorkday As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPreviousWorkgroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNewEmployeeTimes As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbNextWorkgroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents tssbPrint As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsmOnlyPrintEmployees As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmOnlyPrintProductionData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbShift1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbShift2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbShift3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbShift4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tscWorkGroup As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tslSites As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsmSaveChanges As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NavigationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmNextWorkgroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPrevWorkgroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmNextWorkDay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmMyTodoList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPrevWorkday As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmShift1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmShift2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmShift3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmShift4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MitarbeiterdatenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEmployeeTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmDeleteTimeEntries As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvProductionData As Facesso.FrontEnd.ucProductionDataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtpProductionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblDegreeOfTime As System.Windows.Forms.Label
    Friend WithEvents dgvTimeLogItems As Facesso.FrontEnd.ucTimeLogItemsDataGridView
    Friend WithEvents lblMinutesReference As System.Windows.Forms.Label
    Friend WithEvents tslSaveImage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslSaveState As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslCurrentDateInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mainTimer As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmOnlyShowActiveLabourValues As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDeleteShiftData As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsbDeleteTimeDataOnly As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDeleteProductionDataOnly As System.Windows.Forms.ToolStripMenuItem
End Class

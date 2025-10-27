<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmWorkGroupManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWorkGroupManager))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ProduktivSitesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmNewWorkgroup = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEditWorkgroupData = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDeleteWorkgroup = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmPrintWorkGroup = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmAssignLabourValues = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmUnAssignLabourValues = New System.Windows.Forms.ToolStripMenuItem
        Me.AnsichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmShowQuickStartButtons = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmGroupLabourValues = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmGreyUsedLabourValues = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmOK = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.splitLabourValuesQuickButtons = New System.Windows.Forms.SplitContainer
        Me.lvlToAssign = New Facesso.FrontEnd.ucLabourValueListView
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnDeleteFromAssignment = New System.Windows.Forms.Button
        Me.btnNewWorkGroup = New System.Windows.Forms.Button
        Me.btnAssignToWorkGroup = New System.Windows.Forms.Button
        Me.splitWorkGroupsAssignments = New System.Windows.Forms.SplitContainer
        Me.wglSetup = New Facesso.FrontEnd.ucWorkGroupListView
        Me.Label2 = New System.Windows.Forms.Label
        Me.lvlAssigned = New Facesso.FrontEnd.ucLabourValueListView
        Me.lblSelectedWorkgroup = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbNewWorkgroup = New System.Windows.Forms.ToolStripButton
        Me.tsbEditWorkgroup = New System.Windows.Forms.ToolStripButton
        Me.tsbDeleteWorkgroup = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbPrintWorkGroupList = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbAssignLabourValues = New System.Windows.Forms.ToolStripButton
        Me.tsbUnassignLabourValues = New System.Windows.Forms.ToolStripButton
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.splitLabourValuesQuickButtons.Panel1.SuspendLayout()
        Me.splitLabourValuesQuickButtons.Panel2.SuspendLayout()
        Me.splitLabourValuesQuickButtons.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.splitWorkGroupsAssignments.Panel1.SuspendLayout()
        Me.splitWorkGroupsAssignments.Panel2.SuspendLayout()
        Me.splitWorkGroupsAssignments.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProduktivSitesToolStripMenuItem, Me.AnsichtToolStripMenuItem, Me.tsmOK})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(865, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProduktivSitesToolStripMenuItem
        '
        Me.ProduktivSitesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmNewWorkgroup, Me.tsmEditWorkgroupData, Me.tsmDeleteWorkgroup, Me.ToolStripMenuItem3, Me.tsmPrintWorkGroup, Me.ToolStripSeparator1, Me.tsmAssignLabourValues, Me.tsmUnAssignLabourValues})
        Me.ProduktivSitesToolStripMenuItem.Name = "ProduktivSitesToolStripMenuItem"
        Me.ProduktivSitesToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.ProduktivSitesToolStripMenuItem.Text = "&Produktiv-Sites"
        '
        'tsmNewWorkgroup
        '
        Me.tsmNewWorkgroup.Image = CType(resources.GetObject("tsmNewWorkgroup.Image"), System.Drawing.Image)
        Me.tsmNewWorkgroup.Name = "tsmNewWorkgroup"
        Me.tsmNewWorkgroup.Size = New System.Drawing.Size(327, 22)
        Me.tsmNewWorkgroup.Text = "Neue Produktiv-Site anlegen..."
        '
        'tsmEditWorkgroupData
        '
        Me.tsmEditWorkgroupData.Image = CType(resources.GetObject("tsmEditWorkgroupData.Image"), System.Drawing.Image)
        Me.tsmEditWorkgroupData.Name = "tsmEditWorkgroupData"
        Me.tsmEditWorkgroupData.Size = New System.Drawing.Size(288, 22)
        Me.tsmEditWorkgroupData.Text = "Produktiv-Site-Daten bearbeiten..."
        '
        'tsmDeleteWorkgroup
        '
        Me.tsmDeleteWorkgroup.Image = CType(resources.GetObject("tsmDeleteWorkgroup.Image"), System.Drawing.Image)
        Me.tsmDeleteWorkgroup.Name = "tsmDeleteWorkgroup"
        Me.tsmDeleteWorkgroup.Size = New System.Drawing.Size(288, 22)
        Me.tsmDeleteWorkgroup.Text = "Produktiv-Site löschen..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(285, 6)
        '
        'tsmPrintWorkGroup
        '
        Me.tsmPrintWorkGroup.Image = CType(resources.GetObject("tsmPrintWorkGroup.Image"), System.Drawing.Image)
        Me.tsmPrintWorkGroup.Name = "tsmPrintWorkGroup"
        Me.tsmPrintWorkGroup.Size = New System.Drawing.Size(327, 22)
        Me.tsmPrintWorkGroup.Text = "Produktiv-Site-Liste/REFA-Arbeitswerte drucken..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(285, 6)
        '
        'tsmAssignLabourValues
        '
        Me.tsmAssignLabourValues.Image = CType(resources.GetObject("tsmAssignLabourValues.Image"), System.Drawing.Image)
        Me.tsmAssignLabourValues.Name = "tsmAssignLabourValues"
        Me.tsmAssignLabourValues.Size = New System.Drawing.Size(288, 22)
        Me.tsmAssignLabourValues.Text = "Selektierte Arbeitswerte hinzufügen"
        '
        'tsmUnAssignLabourValues
        '
        Me.tsmUnAssignLabourValues.Image = CType(resources.GetObject("tsmUnAssignLabourValues.Image"), System.Drawing.Image)
        Me.tsmUnAssignLabourValues.Name = "tsmUnAssignLabourValues"
        Me.tsmUnAssignLabourValues.Size = New System.Drawing.Size(288, 22)
        Me.tsmUnAssignLabourValues.Text = "Arbeitswerte aus Produktiv-Site entfernen"
        '
        'AnsichtToolStripMenuItem
        '
        Me.AnsichtToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmShowQuickStartButtons, Me.tsmGroupLabourValues, Me.ToolStripSeparator2, Me.tsmGreyUsedLabourValues})
        Me.AnsichtToolStripMenuItem.Name = "AnsichtToolStripMenuItem"
        Me.AnsichtToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.AnsichtToolStripMenuItem.Text = "&Ansicht"
        '
        'tsmShowQuickStartButtons
        '
        Me.tsmShowQuickStartButtons.Checked = True
        Me.tsmShowQuickStartButtons.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmShowQuickStartButtons.Name = "tsmShowQuickStartButtons"
        Me.tsmShowQuickStartButtons.Size = New System.Drawing.Size(262, 22)
        Me.tsmShowQuickStartButtons.Text = "Schnellschaltflächen"
        '
        'tsmGroupLabourValues
        '
        Me.tsmGroupLabourValues.Checked = True
        Me.tsmGroupLabourValues.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmGroupLabourValues.Name = "tsmGroupLabourValues"
        Me.tsmGroupLabourValues.Size = New System.Drawing.Size(262, 22)
        Me.tsmGroupLabourValues.Text = "Arbeitswerte gruppieren"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(259, 6)
        '
        'tsmGreyUsedLabourValues
        '
        Me.tsmGreyUsedLabourValues.Name = "tsmGreyUsedLabourValues"
        Me.tsmGreyUsedLabourValues.Size = New System.Drawing.Size(262, 22)
        Me.tsmGreyUsedLabourValues.Text = "Verwendete Arbeitswerte ausgrauen"
        '
        'tsmOK
        '
        Me.tsmOK.Name = "tsmOK"
        Me.tsmOK.Size = New System.Drawing.Size(33, 20)
        Me.tsmOK.Text = "&OK"
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(865, 555)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(865, 626)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(865, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.splitLabourValuesQuickButtons)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.splitWorkGroupsAssignments)
        Me.SplitContainer1.Size = New System.Drawing.Size(865, 555)
        Me.SplitContainer1.SplitterDistance = 251
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.Text = "SplitContainer1"
        '
        'splitLabourValuesQuickButtons
        '
        Me.splitLabourValuesQuickButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitLabourValuesQuickButtons.Location = New System.Drawing.Point(0, 0)
        Me.splitLabourValuesQuickButtons.Name = "splitLabourValuesQuickButtons"
        '
        'splitLabourValuesQuickButtons.Panel1
        '
        Me.splitLabourValuesQuickButtons.Panel1.Controls.Add(Me.lvlToAssign)
        Me.splitLabourValuesQuickButtons.Panel1.Controls.Add(Me.Label1)
        '
        'splitLabourValuesQuickButtons.Panel2
        '
        Me.splitLabourValuesQuickButtons.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.splitLabourValuesQuickButtons.Size = New System.Drawing.Size(865, 251)
        Me.splitLabourValuesQuickButtons.SplitterDistance = 613
        Me.splitLabourValuesQuickButtons.TabIndex = 0
        Me.splitLabourValuesQuickButtons.Text = "SplitContainer3"
        '
        'lvlToAssign
        '
        Me.lvlToAssign.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvlToAssign.AutoGroup = True
        Me.lvlToAssign.FullRowSelect = True
        Me.lvlToAssign.HideSelection = False
        Me.lvlToAssign.LabourValues = Nothing
        Me.lvlToAssign.LabourValueSortOrder = Facesso.FrontEnd.LabourValuesSortOrder.LabourValueNumber
        Me.lvlToAssign.Location = New System.Drawing.Point(0, 21)
        Me.lvlToAssign.Name = "lvlToAssign"
        Me.lvlToAssign.Size = New System.Drawing.Size(611, 228)
        Me.lvlToAssign.TabIndex = 10
        Me.lvlToAssign.UseCompatibleStateImageBehavior = False
        Me.lvlToAssign.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(330, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "REFA-Arbeitswerte für die Zuordnung an Produktiv-Sites:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnDeleteFromAssignment, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnNewWorkGroup, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAssignToWorkGroup, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(248, 251)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnDeleteFromAssignment
        '
        Me.btnDeleteFromAssignment.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDeleteFromAssignment.Enabled = False
        Me.btnDeleteFromAssignment.Location = New System.Drawing.Point(22, 183)
        Me.btnDeleteFromAssignment.Name = "btnDeleteFromAssignment"
        Me.btnDeleteFromAssignment.Size = New System.Drawing.Size(204, 49)
        Me.btnDeleteFromAssignment.TabIndex = 12
        Me.btnDeleteFromAssignment.Text = "zugeordnete REFA-Arbeitswerte aus Produktiv-Site löschen"
        '
        'btnNewWorkGroup
        '
        Me.btnNewWorkGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnNewWorkGroup.Location = New System.Drawing.Point(22, 18)
        Me.btnNewWorkGroup.Name = "btnNewWorkGroup"
        Me.btnNewWorkGroup.Size = New System.Drawing.Size(204, 49)
        Me.btnNewWorkGroup.TabIndex = 13
        Me.btnNewWorkGroup.Text = "Neue Produktiv-Site erstellen..."
        '
        'btnAssignToWorkGroup
        '
        Me.btnAssignToWorkGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAssignToWorkGroup.Enabled = False
        Me.btnAssignToWorkGroup.Location = New System.Drawing.Point(22, 100)
        Me.btnAssignToWorkGroup.Name = "btnAssignToWorkGroup"
        Me.btnAssignToWorkGroup.Size = New System.Drawing.Size(204, 49)
        Me.btnAssignToWorkGroup.TabIndex = 11
        Me.btnAssignToWorkGroup.Text = "ausgewählte REFA-Arbeitswerte zur selektierten Produktiv-Site hinzufügen"
        '
        'splitWorkGroupsAssignments
        '
        Me.splitWorkGroupsAssignments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitWorkGroupsAssignments.Location = New System.Drawing.Point(0, 0)
        Me.splitWorkGroupsAssignments.Name = "splitWorkGroupsAssignments"
        '
        'splitWorkGroupsAssignments.Panel1
        '
        Me.splitWorkGroupsAssignments.Panel1.Controls.Add(Me.wglSetup)
        Me.splitWorkGroupsAssignments.Panel1.Controls.Add(Me.Label2)
        '
        'splitWorkGroupsAssignments.Panel2
        '
        Me.splitWorkGroupsAssignments.Panel2.Controls.Add(Me.lvlAssigned)
        Me.splitWorkGroupsAssignments.Panel2.Controls.Add(Me.lblSelectedWorkgroup)
        Me.splitWorkGroupsAssignments.Panel2.Controls.Add(Me.Label3)
        Me.splitWorkGroupsAssignments.Size = New System.Drawing.Size(865, 300)
        Me.splitWorkGroupsAssignments.SplitterDistance = 351
        Me.splitWorkGroupsAssignments.TabIndex = 0
        Me.splitWorkGroupsAssignments.Text = "SplitContainer2"
        '
        'wglSetup
        '
        Me.wglSetup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wglSetup.AutoGroup = False
        Me.wglSetup.FullRowSelect = True
        Me.wglSetup.HideSelection = False
        Me.wglSetup.Location = New System.Drawing.Point(4, 21)
        Me.wglSetup.Name = "wglSetup"
        Me.wglSetup.OnlyActiveWorkgroups = False
        Me.wglSetup.Size = New System.Drawing.Size(344, 273)
        Me.wglSetup.TabIndex = 2
        Me.wglSetup.UseCompatibleStateImageBehavior = False
        Me.wglSetup.View = System.Windows.Forms.View.Details
        Me.wglSetup.WorkGroupInfoItems = Nothing
        Me.wglSetup.WorkGroupSortOrder = Facesso.FrontEnd.WorkGroupSortOrder.WorkGroupNumber
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Eingerichtete Produktiv-Sites:"
        '
        'lvlAssigned
        '
        Me.lvlAssigned.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvlAssigned.AutoGroup = False
        Me.lvlAssigned.FullRowSelect = True
        Me.lvlAssigned.HideSelection = False
        Me.lvlAssigned.LabourValues = Nothing
        Me.lvlAssigned.LabourValueSortOrder = Facesso.FrontEnd.LabourValuesSortOrder.LabourValueNumber
        Me.lvlAssigned.Location = New System.Drawing.Point(3, 48)
        Me.lvlAssigned.Name = "lvlAssigned"
        Me.lvlAssigned.Size = New System.Drawing.Size(504, 247)
        Me.lvlAssigned.TabIndex = 4
        Me.lvlAssigned.UseCompatibleStateImageBehavior = False
        Me.lvlAssigned.View = System.Windows.Forms.View.Details
        '
        'lblSelectedWorkgroup
        '
        Me.lblSelectedWorkgroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSelectedWorkgroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblSelectedWorkgroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedWorkgroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSelectedWorkgroup.Location = New System.Drawing.Point(3, 22)
        Me.lblSelectedWorkgroup.Name = "lblSelectedWorkgroup"
        Me.lblSelectedWorkgroup.Size = New System.Drawing.Size(504, 25)
        Me.lblSelectedWorkgroup.TabIndex = 3
        Me.lblSelectedWorkgroup.Text = "- keine Produktiv-Site ausgewählt -"
        Me.lblSelectedWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Der Produktiv-Site zugeordnete Arbeitswerte:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNewWorkgroup, Me.tsbEditWorkgroup, Me.tsbDeleteWorkgroup, Me.ToolStripSeparator3, Me.tsbPrintWorkGroupList, Me.ToolStripSeparator4, Me.tsbAssignLabourValues, Me.tsbUnassignLabourValues})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(162, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNewWorkgroup
        '
        Me.tsbNewWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNewWorkgroup.Image = CType(resources.GetObject("tsbNewWorkgroup.Image"), System.Drawing.Image)
        Me.tsbNewWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewWorkgroup.Name = "tsbNewWorkgroup"
        Me.tsbNewWorkgroup.Size = New System.Drawing.Size(23, 22)
        Me.tsbNewWorkgroup.Text = "Neue Produktiv-Site"
        '
        'tsbEditWorkgroup
        '
        Me.tsbEditWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEditWorkgroup.Image = CType(resources.GetObject("tsbEditWorkgroup.Image"), System.Drawing.Image)
        Me.tsbEditWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditWorkgroup.Name = "tsbEditWorkgroup"
        Me.tsbEditWorkgroup.Size = New System.Drawing.Size(23, 22)
        Me.tsbEditWorkgroup.Text = "Produktiv-Site-Daten bearbeiten"
        '
        'tsbDeleteWorkgroup
        '
        Me.tsbDeleteWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDeleteWorkgroup.Image = CType(resources.GetObject("tsbDeleteWorkgroup.Image"), System.Drawing.Image)
        Me.tsbDeleteWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleteWorkgroup.Name = "tsbDeleteWorkgroup"
        Me.tsbDeleteWorkgroup.Size = New System.Drawing.Size(23, 22)
        Me.tsbDeleteWorkgroup.Text = "Produktiv-Site löschen"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPrintWorkGroupList
        '
        Me.tsbPrintWorkGroupList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrintWorkGroupList.Image = CType(resources.GetObject("tsbPrintWorkGroupList.Image"), System.Drawing.Image)
        Me.tsbPrintWorkGroupList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrintWorkGroupList.Name = "tsbPrintWorkGroupList"
        Me.tsbPrintWorkGroupList.Size = New System.Drawing.Size(23, 22)
        Me.tsbPrintWorkGroupList.Text = "Print Workgroup List"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbAssignLabourValues
        '
        Me.tsbAssignLabourValues.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAssignLabourValues.Image = CType(resources.GetObject("tsbAssignLabourValues.Image"), System.Drawing.Image)
        Me.tsbAssignLabourValues.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAssignLabourValues.Name = "tsbAssignLabourValues"
        Me.tsbAssignLabourValues.Size = New System.Drawing.Size(23, 22)
        Me.tsbAssignLabourValues.Text = "Arbeitswerte zuordnen"
        '
        'tsbUnassignLabourValues
        '
        Me.tsbUnassignLabourValues.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbUnassignLabourValues.Image = CType(resources.GetObject("tsbUnassignLabourValues.Image"), System.Drawing.Image)
        Me.tsbUnassignLabourValues.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbUnassignLabourValues.Name = "tsbUnassignLabourValues"
        Me.tsbUnassignLabourValues.Size = New System.Drawing.Size(23, 22)
        Me.tsbUnassignLabourValues.Text = "Arbeitswertzuordnung aufheben"
        '
        'frmWorkGroupManager
        '
        Me.ClientSize = New System.Drawing.Size(865, 626)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(630, 440)
        Me.Name = "frmWorkGroupManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Produktiv-Sites-Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.splitLabourValuesQuickButtons.Panel1.ResumeLayout(False)
        Me.splitLabourValuesQuickButtons.Panel1.PerformLayout()
        Me.splitLabourValuesQuickButtons.Panel2.ResumeLayout(False)
        Me.splitLabourValuesQuickButtons.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.splitWorkGroupsAssignments.Panel1.ResumeLayout(False)
        Me.splitWorkGroupsAssignments.Panel1.PerformLayout()
        Me.splitWorkGroupsAssignments.Panel2.ResumeLayout(False)
        Me.splitWorkGroupsAssignments.Panel2.PerformLayout()
        Me.splitWorkGroupsAssignments.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProduktivSitesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmNewWorkgroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDeleteWorkgroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmOK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents splitWorkGroupsAssignments As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSelectedWorkgroup As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents splitLabourValuesQuickButtons As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnDeleteFromAssignment As System.Windows.Forms.Button
    Friend WithEvents btnNewWorkGroup As System.Windows.Forms.Button
    Friend WithEvents btnAssignToWorkGroup As System.Windows.Forms.Button
    Friend WithEvents lvlToAssign As Facesso.FrontEnd.ucLabourValueListView
    Friend WithEvents wglSetup As Facesso.FrontEnd.ucWorkGroupListView
    Friend WithEvents lvlAssigned As Facesso.FrontEnd.ucLabourValueListView
    Friend WithEvents tsbNewWorkgroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditWorkgroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents AnsichtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmShowQuickStartButtons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmGroupLabourValues As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEditWorkgroupData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmAssignLabourValues As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmUnAssignLabourValues As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmGreyUsedLabourValues As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmPrintWorkGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrintWorkGroupList As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbAssignLabourValues As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbUnassignLabourValues As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDeleteWorkgroup As System.Windows.Forms.ToolStripButton
End Class

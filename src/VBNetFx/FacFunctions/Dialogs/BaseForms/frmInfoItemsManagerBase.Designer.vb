<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoItemsManagerBase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoItemsManagerBase))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.arvInfoItems = New ActiveDev.ADAutoReportView
        Me.MenuStripMainMenu = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToXmlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportFromXmlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemAddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemEditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemDeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ItemAddToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ItemEditToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ItemDeleteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ItemPrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ItemXmlExportStripButton = New System.Windows.Forms.ToolStripButton
        Me.ItemXmlImportStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tslCostcenters = New System.Windows.Forms.ToolStripLabel
        Me.tscCostCenters = New System.Windows.Forms.ToolStripComboBox
        Me.tsbAssignCostcenter = New System.Windows.Forms.ToolStripButton
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.MenuStripMainMenu.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.arvInfoItems)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(626, 368)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(626, 417)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStripMainMenu)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'arvInfoItems
        '
        Me.arvInfoItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.arvInfoItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arvInfoItems.FullRowSelect = True
        Me.arvInfoItems.GridLines = True
        Me.arvInfoItems.HideSelection = False
        Me.arvInfoItems.List = Nothing
        Me.arvInfoItems.ListViewMode = ActiveDev.AutoReportMode.Details
        Me.arvInfoItems.Location = New System.Drawing.Point(0, 0)
        Me.arvInfoItems.Name = "arvInfoItems"
        Me.arvInfoItems.Size = New System.Drawing.Size(626, 368)
        Me.arvInfoItems.TabIndex = 0
        Me.arvInfoItems.UseCompatibleStateImageBehavior = False
        Me.arvInfoItems.View = System.Windows.Forms.View.Details
        '
        'MenuStripMainMenu
        '
        Me.MenuStripMainMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStripMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.OKToolStripMenuItem})
        Me.MenuStripMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMainMenu.Name = "MenuStripMainMenu"
        Me.MenuStripMainMenu.Size = New System.Drawing.Size(626, 24)
        Me.MenuStripMainMenu.TabIndex = 0
        Me.MenuStripMainMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToXmlToolStripMenuItem, Me.ImportFromXmlToolStripMenuItem, Me.ToolStripSeparator1, Me.PrintToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.FileToolStripMenuItem.Text = "&Datei"
        '
        'ExportToXmlToolStripMenuItem
        '
        Me.ExportToXmlToolStripMenuItem.Name = "ExportToXmlToolStripMenuItem"
        Me.ExportToXmlToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ExportToXmlToolStripMenuItem.Text = "&Export in XML..."
        '
        'ImportFromXmlToolStripMenuItem
        '
        Me.ImportFromXmlToolStripMenuItem.Name = "ImportFromXmlToolStripMenuItem"
        Me.ImportFromXmlToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ImportFromXmlToolStripMenuItem.Text = "&Import von XML..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(169, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.PrintToolStripMenuItem.Text = "Liste &drucken..."
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemAddToolStripMenuItem, Me.ItemEditToolStripMenuItem, Me.ItemDeleteToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.EditToolStripMenuItem.Text = "&Bearbeiten"
        '
        'ItemAddToolStripMenuItem
        '
        Me.ItemAddToolStripMenuItem.Name = "ItemAddToolStripMenuItem"
        Me.ItemAddToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ItemAddToolStripMenuItem.Text = "%1 &hinzufügen"
        '
        'ItemEditToolStripMenuItem
        '
        Me.ItemEditToolStripMenuItem.Name = "ItemEditToolStripMenuItem"
        Me.ItemEditToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ItemEditToolStripMenuItem.Text = "%1 &bearbeiten"
        '
        'ItemDeleteToolStripMenuItem
        '
        Me.ItemDeleteToolStripMenuItem.Name = "ItemDeleteToolStripMenuItem"
        Me.ItemDeleteToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ItemDeleteToolStripMenuItem.Text = "%1 löschen"
        '
        'OKToolStripMenuItem
        '
        Me.OKToolStripMenuItem.Name = "OKToolStripMenuItem"
        Me.OKToolStripMenuItem.Size = New System.Drawing.Size(33, 20)
        Me.OKToolStripMenuItem.Text = "&OK"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemAddToolStripButton, Me.ItemEditToolStripButton, Me.ItemDeleteToolStripButton, Me.toolStripSeparator, Me.ItemPrintToolStripButton, Me.ToolStripSeparator3, Me.ItemXmlExportStripButton, Me.ItemXmlImportStripButton, Me.ToolStripSeparator4, Me.HelpToolStripButton, Me.ToolStripSeparator5, Me.tslCostcenters, Me.tscCostCenters, Me.tsbAssignCostcenter})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(578, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ItemAddToolStripButton
        '
        Me.ItemAddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ItemAddToolStripButton.Image = CType(resources.GetObject("ItemAddToolStripButton.Image"), System.Drawing.Image)
        Me.ItemAddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItemAddToolStripButton.Name = "ItemAddToolStripButton"
        Me.ItemAddToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ItemAddToolStripButton.Text = "Neuer Datensatz"
        '
        'ItemEditToolStripButton
        '
        Me.ItemEditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ItemEditToolStripButton.Image = CType(resources.GetObject("ItemEditToolStripButton.Image"), System.Drawing.Image)
        Me.ItemEditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItemEditToolStripButton.Name = "ItemEditToolStripButton"
        Me.ItemEditToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ItemEditToolStripButton.Text = "Datensatz bearbeiten"
        '
        'ItemDeleteToolStripButton
        '
        Me.ItemDeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ItemDeleteToolStripButton.Image = CType(resources.GetObject("ItemDeleteToolStripButton.Image"), System.Drawing.Image)
        Me.ItemDeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItemDeleteToolStripButton.Name = "ItemDeleteToolStripButton"
        Me.ItemDeleteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ItemDeleteToolStripButton.Text = "Datensatz löschen"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ItemPrintToolStripButton
        '
        Me.ItemPrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ItemPrintToolStripButton.Image = CType(resources.GetObject("ItemPrintToolStripButton.Image"), System.Drawing.Image)
        Me.ItemPrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItemPrintToolStripButton.Name = "ItemPrintToolStripButton"
        Me.ItemPrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ItemPrintToolStripButton.Text = "Liste drucken"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ItemXmlExportStripButton
        '
        Me.ItemXmlExportStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ItemXmlExportStripButton.Image = CType(resources.GetObject("ItemXmlExportStripButton.Image"), System.Drawing.Image)
        Me.ItemXmlExportStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItemXmlExportStripButton.Name = "ItemXmlExportStripButton"
        Me.ItemXmlExportStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ItemXmlExportStripButton.Text = "XmlExportStripButton"
        Me.ItemXmlExportStripButton.ToolTipText = "XML-Export (nur Enterprise)"
        '
        'ItemXmlImportStripButton
        '
        Me.ItemXmlImportStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ItemXmlImportStripButton.Image = CType(resources.GetObject("ItemXmlImportStripButton.Image"), System.Drawing.Image)
        Me.ItemXmlImportStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItemXmlImportStripButton.Name = "ItemXmlImportStripButton"
        Me.ItemXmlImportStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ItemXmlImportStripButton.Text = "ToolStripButton2"
        Me.ItemXmlImportStripButton.ToolTipText = "XML-Import (nur Enterprise)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "He&lp"
        Me.HelpToolStripButton.ToolTipText = "Hilfe"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tslCostcenters
        '
        Me.tslCostcenters.Name = "tslCostcenters"
        Me.tslCostcenters.Size = New System.Drawing.Size(75, 22)
        Me.tslCostcenters.Text = "Kostenstellen:"
        Me.tslCostcenters.ToolTipText = "Kostenstellen, die den ausgewählten Elementen zugeordnet werden sollen."
        '
        'tscCostCenters
        '
        Me.tscCostCenters.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscCostCenters.Name = "tscCostCenters"
        Me.tscCostCenters.Size = New System.Drawing.Size(200, 25)
        '
        'tsbAssignCostcenter
        '
        Me.tsbAssignCostcenter.Image = CType(resources.GetObject("tsbAssignCostcenter.Image"), System.Drawing.Image)
        Me.tsbAssignCostcenter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAssignCostcenter.Name = "tsbAssignCostcenter"
        Me.tsbAssignCostcenter.Size = New System.Drawing.Size(73, 22)
        Me.tsbAssignCostcenter.Text = "Zuordnen"
        Me.tsbAssignCostcenter.ToolTipText = "Kostenstelle zuordnen"
        '
        'frmInfoItemsManagerBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 417)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStripMainMenu
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmInfoItemsManagerBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmInfoItemsManagerBase"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.MenuStripMainMenu.ResumeLayout(False)
        Me.MenuStripMainMenu.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToXmlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportFromXmlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemAddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemEditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemDeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemAddToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ItemEditToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ItemDeleteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ItemPrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ItemXmlExportStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ItemXmlImportStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OKToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents MenuStripMainMenu As System.Windows.Forms.MenuStrip
    Protected WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tslCostcenters As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscCostCenters As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents arvInfoItems As ActiveDev.ADAutoReportView
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbAssignCostcenter As System.Windows.Forms.ToolStripButton
End Class

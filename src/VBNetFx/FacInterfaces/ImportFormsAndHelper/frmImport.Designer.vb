<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImport))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lvwTaskList = New System.Windows.Forms.ListView
        Me.ListViewImages = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnImportNow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.chkShift1 = New System.Windows.Forms.CheckBox
        Me.chkShift2 = New System.Windows.Forms.CheckBox
        Me.chkShift3 = New System.Windows.Forms.CheckBox
        Me.chkShift4 = New System.Windows.Forms.CheckBox
        Me.lblImportStatus = New System.Windows.Forms.Label
        Me.pbImportProgress = New System.Windows.Forms.ProgressBar
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmFileImportImportSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmFileExportShiftmodel = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmQuitDialog = New System.Windows.Forms.ToolStripMenuItem
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEditNewImportTask = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEditImportTask = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEditDeleteImportTask = New System.Windows.Forms.ToolStripMenuItem
        Me.btnOK = New System.Windows.Forms.Button
        Me.ucWorkGroups = New Facesso.FrontEnd.ucWorkGroupListView
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btnDeselectAll = New System.Windows.Forms.Button
        Me.lblWorkgroups = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lvwTaskList)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 224)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Import-Tasks: "
        '
        'lvwTaskList
        '
        Me.lvwTaskList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwTaskList.FullRowSelect = True
        Me.lvwTaskList.GridLines = True
        Me.lvwTaskList.Location = New System.Drawing.Point(12, 23)
        Me.lvwTaskList.Name = "lvwTaskList"
        Me.lvwTaskList.Size = New System.Drawing.Size(414, 194)
        Me.lvwTaskList.SmallImageList = Me.ListViewImages
        Me.lvwTaskList.TabIndex = 5
        Me.lvwTaskList.UseCompatibleStateImageBehavior = False
        Me.lvwTaskList.View = System.Windows.Forms.View.Details
        '
        'ListViewImages
        '
        Me.ListViewImages.ImageStream = CType(resources.GetObject("ListViewImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListViewImages.TransparentColor = System.Drawing.Color.Transparent
        Me.ListViewImages.Images.SetKeyName(0, "CheckBox")
        Me.ListViewImages.Images.SetKeyName(1, "UnCheckBox")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "von:"
        '
        'btnImportNow
        '
        Me.btnImportNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportNow.Location = New System.Drawing.Point(470, 32)
        Me.btnImportNow.Name = "btnImportNow"
        Me.btnImportNow.Size = New System.Drawing.Size(114, 47)
        Me.btnImportNow.TabIndex = 4
        Me.btnImportNow.Text = "Import starten!"
        Me.btnImportNow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "bis:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(61, 32)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(203, 20)
        Me.dtpFrom.TabIndex = 7
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(61, 58)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(203, 20)
        Me.dtpTo.TabIndex = 8
        '
        'chkShift1
        '
        Me.chkShift1.AutoSize = True
        Me.chkShift1.Checked = True
        Me.chkShift1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShift1.Location = New System.Drawing.Point(292, 38)
        Me.chkShift1.Name = "chkShift1"
        Me.chkShift1.Size = New System.Drawing.Size(71, 17)
        Me.chkShift1.TabIndex = 9
        Me.chkShift1.Text = "Schicht 1"
        Me.chkShift1.UseVisualStyleBackColor = True
        '
        'chkShift2
        '
        Me.chkShift2.AutoSize = True
        Me.chkShift2.Checked = True
        Me.chkShift2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShift2.Location = New System.Drawing.Point(380, 38)
        Me.chkShift2.Name = "chkShift2"
        Me.chkShift2.Size = New System.Drawing.Size(71, 17)
        Me.chkShift2.TabIndex = 10
        Me.chkShift2.Text = "Schicht 2"
        Me.chkShift2.UseVisualStyleBackColor = True
        '
        'chkShift3
        '
        Me.chkShift3.AutoSize = True
        Me.chkShift3.Checked = True
        Me.chkShift3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShift3.Location = New System.Drawing.Point(292, 62)
        Me.chkShift3.Name = "chkShift3"
        Me.chkShift3.Size = New System.Drawing.Size(71, 17)
        Me.chkShift3.TabIndex = 11
        Me.chkShift3.Text = "Schicht 3"
        Me.chkShift3.UseVisualStyleBackColor = True
        '
        'chkShift4
        '
        Me.chkShift4.AutoSize = True
        Me.chkShift4.Checked = True
        Me.chkShift4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShift4.Location = New System.Drawing.Point(380, 62)
        Me.chkShift4.Name = "chkShift4"
        Me.chkShift4.Size = New System.Drawing.Size(71, 17)
        Me.chkShift4.TabIndex = 12
        Me.chkShift4.Text = "Schicht 4"
        Me.chkShift4.UseVisualStyleBackColor = True
        '
        'lblImportStatus
        '
        Me.lblImportStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImportStatus.AutoEllipsis = True
        Me.lblImportStatus.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblImportStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblImportStatus.Location = New System.Drawing.Point(20, 310)
        Me.lblImportStatus.Name = "lblImportStatus"
        Me.lblImportStatus.Size = New System.Drawing.Size(423, 54)
        Me.lblImportStatus.TabIndex = 14
        Me.lblImportStatus.Text = "Status: Wählen Sie den Datumsbereich und anschließend 'Import starten!'"
        Me.lblImportStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbImportProgress
        '
        Me.pbImportProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImportProgress.Location = New System.Drawing.Point(20, 370)
        Me.pbImportProgress.Name = "pbImportProgress"
        Me.pbImportProgress.Size = New System.Drawing.Size(423, 25)
        Me.pbImportProgress.TabIndex = 13
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.BearbeitenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(697, 24)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFileImportImportSettings, Me.tsmFileExportShiftmodel, Me.ToolStripMenuItem1, Me.tsmQuitDialog})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'tsmFileImportImportSettings
        '
        Me.tsmFileImportImportSettings.Name = "tsmFileImportImportSettings"
        Me.tsmFileImportImportSettings.Size = New System.Drawing.Size(295, 22)
        Me.tsmFileImportImportSettings.Text = "Datemimport-Einstellungen &importieren..."
        '
        'tsmFileExportShiftmodel
        '
        Me.tsmFileExportShiftmodel.Name = "tsmFileExportShiftmodel"
        Me.tsmFileExportShiftmodel.Size = New System.Drawing.Size(295, 22)
        Me.tsmFileExportShiftmodel.Text = "Datenimport-Einstellungen &exportieren..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(292, 6)
        '
        'tsmQuitDialog
        '
        Me.tsmQuitDialog.Name = "tsmQuitDialog"
        Me.tsmQuitDialog.Size = New System.Drawing.Size(295, 22)
        Me.tsmQuitDialog.Text = "Dialog &beenden"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmEditNewImportTask, Me.tsmEditImportTask, Me.tsmEditDeleteImportTask})
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.BearbeitenToolStripMenuItem.Text = "&Bearbeiten"
        '
        'tsmEditNewImportTask
        '
        Me.tsmEditNewImportTask.Name = "tsmEditNewImportTask"
        Me.tsmEditNewImportTask.Size = New System.Drawing.Size(207, 22)
        Me.tsmEditNewImportTask.Text = "Neuer Import-Task..."
        '
        'tsmEditImportTask
        '
        Me.tsmEditImportTask.Name = "tsmEditImportTask"
        Me.tsmEditImportTask.Size = New System.Drawing.Size(207, 22)
        Me.tsmEditImportTask.Text = "Import-Task bearbeiten..."
        '
        'tsmEditDeleteImportTask
        '
        Me.tsmEditDeleteImportTask.Name = "tsmEditDeleteImportTask"
        Me.tsmEditDeleteImportTask.Size = New System.Drawing.Size(207, 22)
        Me.tsmEditDeleteImportTask.Text = "Import-Task löschen..."
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(590, 32)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(101, 47)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ucWorkGroups
        '
        Me.ucWorkGroups.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucWorkGroups.AutoGroup = True
        Me.ucWorkGroups.CheckBoxes = True
        Me.ucWorkGroups.FullRowSelect = True
        Me.ucWorkGroups.HideSelection = False
        Me.ucWorkGroups.Location = New System.Drawing.Point(450, 106)
        Me.ucWorkGroups.Name = "ucWorkGroups"
        Me.ucWorkGroups.OnlyActiveWorkgroups = True
        Me.ucWorkGroups.Size = New System.Drawing.Size(235, 258)
        Me.ucWorkGroups.TabIndex = 17
        Me.ucWorkGroups.UseCompatibleStateImageBehavior = False
        Me.ucWorkGroups.View = System.Windows.Forms.View.Details
        Me.ucWorkGroups.WorkGroupInfoItems = Nothing
        Me.ucWorkGroups.WorkGroupSortOrder = Facesso.FrontEnd.WorkGroupSortOrder.WorkGroupNumber
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Location = New System.Drawing.Point(449, 370)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(115, 25)
        Me.btnSelectAll.TabIndex = 18
        Me.btnSelectAll.Text = "Alle selektieren"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeselectAll.Location = New System.Drawing.Point(570, 370)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(115, 25)
        Me.btnDeselectAll.TabIndex = 19
        Me.btnDeselectAll.Text = "Alle de-selektieren"
        Me.btnDeselectAll.UseVisualStyleBackColor = True
        '
        'lblWorkgroups
        '
        Me.lblWorkgroups.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWorkgroups.AutoSize = True
        Me.lblWorkgroups.Location = New System.Drawing.Point(449, 90)
        Me.lblWorkgroups.Name = "lblWorkgroups"
        Me.lblWorkgroups.Size = New System.Drawing.Size(234, 13)
        Me.lblWorkgroups.TabIndex = 20
        Me.lblWorkgroups.Text = "Zeitdaten für diese Produktiv-Sites übernehmen:"
        '
        'frmImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 407)
        Me.Controls.Add(Me.lblWorkgroups)
        Me.Controls.Add(Me.btnDeselectAll)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.ucWorkGroups)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblImportStatus)
        Me.Controls.Add(Me.pbImportProgress)
        Me.Controls.Add(Me.chkShift4)
        Me.Controls.Add(Me.chkShift3)
        Me.Controls.Add(Me.chkShift2)
        Me.Controls.Add(Me.chkShift1)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnImportNow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(713, 445)
        Me.Name = "frmImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Datenimport"
        Me.GroupBox1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImportNow As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkShift1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShift2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShift3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShift4 As System.Windows.Forms.CheckBox
    Friend WithEvents lvwTaskList As System.Windows.Forms.ListView
    Friend WithEvents ListViewImages As System.Windows.Forms.ImageList
    Friend WithEvents lblImportStatus As System.Windows.Forms.Label
    Friend WithEvents pbImportProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFileImportImportSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFileExportShiftmodel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmQuitDialog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEditNewImportTask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEditImportTask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEditDeleteImportTask As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ucWorkGroups As Facesso.FrontEnd.ucWorkGroupListView
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button
    Friend WithEvents lblWorkgroups As System.Windows.Forms.Label
End Class

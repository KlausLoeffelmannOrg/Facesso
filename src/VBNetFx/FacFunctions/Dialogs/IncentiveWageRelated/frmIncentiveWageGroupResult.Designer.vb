<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class frmIncentiveWageGroupResult
    Inherits frmBaseFacesso

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
        Me.dgvEmployeeWages = New System.Windows.Forms.DataGridView
        Me.lblIncentiveWageForMonth = New System.Windows.Forms.Label
        Me.lblIncentiveWageSum = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmPrintWageList = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmPrintEmployeeWagesDetailed = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.TsmCsvExport = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmQuit = New System.Windows.Forms.ToolStripMenuItem
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TsmSelectWithIncentiveWage = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSelectWithData = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDeselectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.SortierungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSortPersonellNo = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSortAlphabetically = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSortDegreeOfTime = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgvEmployeeWages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvEmployeeWages
        '
        Me.dgvEmployeeWages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmployeeWages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployeeWages.Location = New System.Drawing.Point(5, 32)
        Me.dgvEmployeeWages.Name = "dgvEmployeeWages"
        Me.dgvEmployeeWages.Size = New System.Drawing.Size(708, 352)
        Me.dgvEmployeeWages.TabIndex = 0
        '
        'lblIncentiveWageForMonth
        '
        Me.lblIncentiveWageForMonth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIncentiveWageForMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIncentiveWageForMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncentiveWageForMonth.Location = New System.Drawing.Point(5, 388)
        Me.lblIncentiveWageForMonth.Name = "lblIncentiveWageForMonth"
        Me.lblIncentiveWageForMonth.Size = New System.Drawing.Size(528, 28)
        Me.lblIncentiveWageForMonth.TabIndex = 8
        Me.lblIncentiveWageForMonth.Text = "Anfallende Gesamtprämien im Monat"
        Me.lblIncentiveWageForMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIncentiveWageSum
        '
        Me.lblIncentiveWageSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIncentiveWageSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIncentiveWageSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncentiveWageSum.Location = New System.Drawing.Point(535, 388)
        Me.lblIncentiveWageSum.Name = "lblIncentiveWageSum"
        Me.lblIncentiveWageSum.Size = New System.Drawing.Size(179, 28)
        Me.lblIncentiveWageSum.TabIndex = 9
        Me.lblIncentiveWageSum.Text = "0,00 €"
        Me.lblIncentiveWageSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.BearbeitenToolStripMenuItem, Me.SortierungToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(719, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmPrintWageList, Me.tsmPrintEmployeeWagesDetailed, Me.ToolStripMenuItem1, Me.TsmCsvExport, Me.ToolStripMenuItem2, Me.tsmQuit})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'tsmPrintWageList
        '
        Me.tsmPrintWageList.Name = "tsmPrintWageList"
        Me.tsmPrintWageList.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.tsmPrintWageList.Size = New System.Drawing.Size(360, 22)
        Me.tsmPrintWageList.Text = "&Lohnliste drucken..."
        '
        'tsmPrintEmployeeWagesDetailed
        '
        Me.tsmPrintEmployeeWagesDetailed.Name = "tsmPrintEmployeeWagesDetailed"
        Me.tsmPrintEmployeeWagesDetailed.Size = New System.Drawing.Size(360, 22)
        Me.tsmPrintEmployeeWagesDetailed.Text = "Tageseinzelaufstellung der &Mitarbeiterlöhne drucken..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(357, 6)
        '
        'TsmCsvExport
        '
        Me.TsmCsvExport.Name = "TsmCsvExport"
        Me.TsmCsvExport.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.TsmCsvExport.Size = New System.Drawing.Size(360, 22)
        Me.TsmCsvExport.Text = "CSV-&Export (für Excel)..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(357, 6)
        '
        'tsmQuit
        '
        Me.tsmQuit.Name = "tsmQuit"
        Me.tsmQuit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.tsmQuit.Size = New System.Drawing.Size(360, 22)
        Me.tsmQuit.Text = "Berechnungsdialog &verlassen"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmSelectWithIncentiveWage, Me.tsmSelectWithData, Me.tsmSelectAll, Me.tsmDeselectAll})
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.BearbeitenToolStripMenuItem.Text = "&Bearbeiten"
        '
        'TsmSelectWithIncentiveWage
        '
        Me.TsmSelectWithIncentiveWage.Name = "TsmSelectWithIncentiveWage"
        Me.TsmSelectWithIncentiveWage.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.TsmSelectWithIncentiveWage.Size = New System.Drawing.Size(337, 22)
        Me.TsmSelectWithIncentiveWage.Text = "Alle Mitarbeiter mit Prämie selektieren"
        '
        'tsmSelectWithData
        '
        Me.tsmSelectWithData.Name = "tsmSelectWithData"
        Me.tsmSelectWithData.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.tsmSelectWithData.Size = New System.Drawing.Size(337, 22)
        Me.tsmSelectWithData.Text = "Alle Mitarbeiter mit Lohndaten selektieren"
        '
        'tsmSelectAll
        '
        Me.tsmSelectAll.Name = "tsmSelectAll"
        Me.tsmSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.tsmSelectAll.Size = New System.Drawing.Size(337, 22)
        Me.tsmSelectAll.Text = "Alle Mitarbeiter selektieren"
        '
        'tsmDeselectAll
        '
        Me.tsmDeselectAll.Name = "tsmDeselectAll"
        Me.tsmDeselectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.tsmDeselectAll.Size = New System.Drawing.Size(337, 22)
        Me.tsmDeselectAll.Text = "Selektierung aufheben"
        '
        'SortierungToolStripMenuItem
        '
        Me.SortierungToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSortPersonellNo, Me.tsmSortAlphabetically, Me.tsmSortDegreeOfTime})
        Me.SortierungToolStripMenuItem.Name = "SortierungToolStripMenuItem"
        Me.SortierungToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.SortierungToolStripMenuItem.Text = "&Sortierung"
        Me.SortierungToolStripMenuItem.Visible = False
        '
        'tsmSortPersonellNo
        '
        Me.tsmSortPersonellNo.Name = "tsmSortPersonellNo"
        Me.tsmSortPersonellNo.Size = New System.Drawing.Size(196, 22)
        Me.tsmSortPersonellNo.Text = "Nach Personalnummer"
        '
        'tsmSortAlphabetically
        '
        Me.tsmSortAlphabetically.Name = "tsmSortAlphabetically"
        Me.tsmSortAlphabetically.Size = New System.Drawing.Size(196, 22)
        Me.tsmSortAlphabetically.Text = "Alphabetisch"
        '
        'tsmSortDegreeOfTime
        '
        Me.tsmSortDegreeOfTime.Name = "tsmSortDegreeOfTime"
        Me.tsmSortDegreeOfTime.Size = New System.Drawing.Size(196, 22)
        Me.tsmSortDegreeOfTime.Text = "Nach Zeitgrad"
        '
        'frmIncentiveWageGroupResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 428)
        Me.Controls.Add(Me.lblIncentiveWageSum)
        Me.Controls.Add(Me.lblIncentiveWageForMonth)
        Me.Controls.Add(Me.dgvEmployeeWages)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(727, 462)
        Me.Name = "frmIncentiveWageGroupResult"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Prämienlohnberechnung"
        CType(Me.dgvEmployeeWages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvEmployeeWages As System.Windows.Forms.DataGridView
    Friend WithEvents lblIncentiveWageForMonth As System.Windows.Forms.Label
    Friend WithEvents lblIncentiveWageSum As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPrintWageList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPrintEmployeeWagesDetailed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsmCsvExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmQuit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsmSelectWithIncentiveWage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSelectWithData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDeselectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SortierungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSortPersonellNo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSortAlphabetically As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSortDegreeOfTime As System.Windows.Forms.ToolStripMenuItem
End Class

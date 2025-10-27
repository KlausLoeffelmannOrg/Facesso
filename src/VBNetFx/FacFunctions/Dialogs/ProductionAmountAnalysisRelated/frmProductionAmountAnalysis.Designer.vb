<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductionAmountAnalysis
    Inherits frmBaseFacesso

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpWorkgroups = New System.Windows.Forms.TabPage
        Me.lvwWorkgroups = New Facesso.FrontEnd.ucWorkGroupListView
        Me.tpCostCenters = New System.Windows.Forms.TabPage
        Me.lvwCostCenter = New Facesso.FrontEnd.ucCostCenterListView
        Me.btnDeselectAll = New System.Windows.Forms.Button
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblPass = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optGroupWorkvalues = New System.Windows.Forms.RadioButton
        Me.optGroupCostcenters = New System.Windows.Forms.RadioButton
        Me.optStandardAnalysis = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateRangePicker = New Facesso.FrontEnd.ucAnalysisDateRangePicker
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpWorkgroups.SuspendLayout()
        Me.tpCostCenters.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Controls.Add(Me.btnDeselectAll)
        Me.GroupBox2.Controls.Add(Me.btnSelectAll)
        Me.GroupBox2.Location = New System.Drawing.Point(393, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(454, 338)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpWorkgroups)
        Me.TabControl1.Controls.Add(Me.tpCostCenters)
        Me.TabControl1.Location = New System.Drawing.Point(11, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(427, 288)
        Me.TabControl1.TabIndex = 3
        '
        'tpWorkgroups
        '
        Me.tpWorkgroups.Controls.Add(Me.lvwWorkgroups)
        Me.tpWorkgroups.Location = New System.Drawing.Point(4, 22)
        Me.tpWorkgroups.Name = "tpWorkgroups"
        Me.tpWorkgroups.Padding = New System.Windows.Forms.Padding(3)
        Me.tpWorkgroups.Size = New System.Drawing.Size(419, 262)
        Me.tpWorkgroups.TabIndex = 0
        Me.tpWorkgroups.Text = "Produktiv-Sites"
        Me.tpWorkgroups.UseVisualStyleBackColor = True
        '
        'lvwWorkgroups
        '
        Me.lvwWorkgroups.AutoGroup = True
        Me.lvwWorkgroups.FullRowSelect = True
        Me.lvwWorkgroups.HideSelection = False
        Me.lvwWorkgroups.Location = New System.Drawing.Point(6, 6)
        Me.lvwWorkgroups.Name = "lvwWorkgroups"
        Me.lvwWorkgroups.OnlyActiveWorkgroups = True
        Me.lvwWorkgroups.Size = New System.Drawing.Size(407, 250)
        Me.lvwWorkgroups.TabIndex = 1
        Me.lvwWorkgroups.UseCompatibleStateImageBehavior = False
        Me.lvwWorkgroups.View = System.Windows.Forms.View.Details
        Me.lvwWorkgroups.WorkGroupInfoItems = Nothing
        Me.lvwWorkgroups.WorkGroupSortOrder = Facesso.FrontEnd.WorkGroupSortOrder.WorkGroupNumber
        '
        'tpCostCenters
        '
        Me.tpCostCenters.Controls.Add(Me.lvwCostCenter)
        Me.tpCostCenters.Location = New System.Drawing.Point(4, 22)
        Me.tpCostCenters.Name = "tpCostCenters"
        Me.tpCostCenters.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCostCenters.Size = New System.Drawing.Size(419, 262)
        Me.tpCostCenters.TabIndex = 1
        Me.tpCostCenters.Text = "Kostenstellen"
        Me.tpCostCenters.UseVisualStyleBackColor = True
        '
        'lvwCostCenter
        '
        Me.lvwCostCenter.AutoGroup = True
        Me.lvwCostCenter.CostCenterInfoCollection = Nothing
        Me.lvwCostCenter.CostCenterSortOrder = Facesso.FrontEnd.CostCenterSortOrder.CostCenterNumber
        Me.lvwCostCenter.FullRowSelect = True
        Me.lvwCostCenter.HideSelection = False
        Me.lvwCostCenter.Location = New System.Drawing.Point(6, 6)
        Me.lvwCostCenter.Name = "lvwCostCenter"
        Me.lvwCostCenter.Size = New System.Drawing.Size(407, 250)
        Me.lvwCostCenter.TabIndex = 0
        Me.lvwCostCenter.UseCompatibleStateImageBehavior = False
        Me.lvwCostCenter.View = System.Windows.Forms.View.Details
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Location = New System.Drawing.Point(178, 313)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(179, 21)
        Me.btnDeselectAll.TabIndex = 2
        Me.btnDeselectAll.Text = "Alle Produktiv-Sites deselektieren"
        Me.btnDeselectAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(6, 313)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(166, 21)
        Me.btnSelectAll.TabIndex = 1
        Me.btnSelectAll.Text = "Alle Produktiv-Sites markieren"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(393, 454)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(103, 27)
        Me.btnPreview.TabIndex = 2
        Me.btnPreview.Text = "Vorschau..."
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(502, 454)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(103, 27)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Drucken..."
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(611, 454)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(103, 27)
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "Export..."
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(730, 454)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(117, 27)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPass)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Location = New System.Drawing.Point(396, 360)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(450, 88)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Berechnungsstatus:"
        '
        'lblPass
        '
        Me.lblPass.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPass.Location = New System.Drawing.Point(5, 23)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(440, 21)
        Me.lblPass.TabIndex = 10
        Me.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Berechnungsfortschritt:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(130, 52)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(315, 22)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 8
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optGroupWorkvalues)
        Me.GroupBox3.Controls.Add(Me.optGroupCostcenters)
        Me.GroupBox3.Controls.Add(Me.optStandardAnalysis)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 359)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(373, 125)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Auswertungstyp"
        '
        'optGroupWorkvalues
        '
        Me.optGroupWorkvalues.AutoSize = True
        Me.optGroupWorkvalues.Location = New System.Drawing.Point(9, 97)
        Me.optGroupWorkvalues.Name = "optGroupWorkvalues"
        Me.optGroupWorkvalues.Size = New System.Drawing.Size(164, 17)
        Me.optGroupWorkvalues.TabIndex = 7
        Me.optGroupWorkvalues.TabStop = True
        Me.optGroupWorkvalues.Text = "Arbeitswertzusammenfassung"
        Me.optGroupWorkvalues.UseVisualStyleBackColor = True
        '
        'optGroupCostcenters
        '
        Me.optGroupCostcenters.AutoSize = True
        Me.optGroupCostcenters.Location = New System.Drawing.Point(9, 42)
        Me.optGroupCostcenters.Name = "optGroupCostcenters"
        Me.optGroupCostcenters.Size = New System.Drawing.Size(175, 17)
        Me.optGroupCostcenters.TabIndex = 6
        Me.optGroupCostcenters.TabStop = True
        Me.optGroupCostcenters.Text = "Kostenstellenzusammenfassung"
        Me.optGroupCostcenters.UseVisualStyleBackColor = True
        '
        'optStandardAnalysis
        '
        Me.optStandardAnalysis.AutoSize = True
        Me.optStandardAnalysis.Checked = True
        Me.optStandardAnalysis.Location = New System.Drawing.Point(9, 19)
        Me.optStandardAnalysis.Name = "optStandardAnalysis"
        Me.optStandardAnalysis.Size = New System.Drawing.Size(329, 17)
        Me.optStandardAnalysis.TabIndex = 5
        Me.optStandardAnalysis.TabStop = True
        Me.optStandardAnalysis.Text = "Standardauswertung (pro ausgewählte Produktiv-Site eine Seite)"
        Me.optStandardAnalysis.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(322, 28)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Wichtig: Die Maßeinheiten der Arbeitswerte gleicher Kostenstellen müssen einheitl" & _
            "ich sein, es findet keine Überprüfung statt."
        '
        'DateRangePicker
        '
        Me.DateRangePicker.LastWorkingday = Facesso.Data.LastWorkingdays.Friday
        Me.DateRangePicker.Location = New System.Drawing.Point(9, 14)
        Me.DateRangePicker.Name = "DateRangePicker"
        Me.DateRangePicker.Size = New System.Drawing.Size(378, 344)
        Me.DateRangePicker.TabIndex = 8
        '
        'frmProductionAmountAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 496)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DateRangePicker)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmProductionAmountAnalysis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Produktionsergebnis-Analyse"
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpWorkgroups.ResumeLayout(False)
        Me.tpCostCenters.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents DateRangePicker As Facesso.FrontEnd.ucAnalysisDateRangePicker
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optGroupWorkvalues As System.Windows.Forms.RadioButton
    Friend WithEvents optGroupCostcenters As System.Windows.Forms.RadioButton
    Friend WithEvents optStandardAnalysis As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpWorkgroups As System.Windows.Forms.TabPage
    Friend WithEvents lvwWorkgroups As Facesso.FrontEnd.ucWorkGroupListView
    Friend WithEvents tpCostCenters As System.Windows.Forms.TabPage
    Friend WithEvents lvwCostCenter As Facesso.FrontEnd.ucCostCenterListView
End Class

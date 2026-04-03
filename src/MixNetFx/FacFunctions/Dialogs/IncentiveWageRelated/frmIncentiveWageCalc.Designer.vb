<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmIncentiveWageCalc
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
        Dim MonthRangePickerResult1 As Facesso.MonthRangePickerResult = New Facesso.MonthRangePickerResult
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.elvEmployees = New Facesso.FrontEnd.ucEmployeeListView
        Me.btnUnselectAll = New System.Windows.Forms.Button
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btnPerformCalculation = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.pbEmployeesToAnalyse = New System.Windows.Forms.ProgressBar
        Me.lblCurrentEmployee = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.MonthRangePicker = New Facesso.FrontEnd.ucMonthRangePicker
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.elvEmployees)
        Me.GroupBox1.Controls.Add(Me.btnUnselectAll)
        Me.GroupBox1.Controls.Add(Me.pbEmployeesToAnalyse)
        Me.GroupBox1.Controls.Add(Me.btnSelectAll)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 337)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mitarbeiter, die in Aufstellung einbezogen werden sollen:"
        '
        'elvEmployees
        '
        Me.elvEmployees.AutoGroup = True
        Me.elvEmployees.EmployeeInfoCollection = Nothing
        Me.elvEmployees.EmployeeSortOrder = Facesso.FrontEnd.EmployeeSortOrder.PersonnelNumber
        Me.elvEmployees.FullRowSelect = True
        Me.elvEmployees.HideSelection = False
        Me.elvEmployees.Location = New System.Drawing.Point(6, 19)
        Me.elvEmployees.Name = "elvEmployees"
        Me.elvEmployees.OnlyActiveEmployees = True
        Me.elvEmployees.OnlyIncentiveEmployees = False
        Me.elvEmployees.Size = New System.Drawing.Size(454, 225)
        Me.elvEmployees.TabIndex = 3
        Me.elvEmployees.UseCompatibleStateImageBehavior = False
        Me.elvEmployees.View = System.Windows.Forms.View.Details
        '
        'btnUnselectAll
        '
        Me.btnUnselectAll.Location = New System.Drawing.Point(6, 250)
        Me.btnUnselectAll.Name = "btnUnselectAll"
        Me.btnUnselectAll.Size = New System.Drawing.Size(124, 23)
        Me.btnUnselectAll.TabIndex = 2
        Me.btnUnselectAll.Text = "Markierung aufheben"
        Me.btnUnselectAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(136, 250)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(124, 23)
        Me.btnSelectAll.TabIndex = 1
        Me.btnSelectAll.Text = "Alle markieren"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnPerformCalculation
        '
        Me.btnPerformCalculation.Location = New System.Drawing.Point(497, 317)
        Me.btnPerformCalculation.Name = "btnPerformCalculation"
        Me.btnPerformCalculation.Size = New System.Drawing.Size(155, 32)
        Me.btnPerformCalculation.TabIndex = 3
        Me.btnPerformCalculation.Text = "Auswertung durchführen..."
        Me.btnPerformCalculation.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(658, 317)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(111, 32)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Noch zu berechnende Mitarbeiter:"
        '
        'pbEmployeesToAnalyse
        '
        Me.pbEmployeesToAnalyse.Location = New System.Drawing.Point(6, 310)
        Me.pbEmployeesToAnalyse.Name = "pbEmployeesToAnalyse"
        Me.pbEmployeesToAnalyse.Size = New System.Drawing.Size(454, 21)
        Me.pbEmployeesToAnalyse.TabIndex = 6
        '
        'lblCurrentEmployee
        '
        Me.lblCurrentEmployee.AutoSize = True
        Me.lblCurrentEmployee.Location = New System.Drawing.Point(188, 358)
        Me.lblCurrentEmployee.Name = "lblCurrentEmployee"
        Me.lblCurrentEmployee.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentEmployee.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.MonthRangePicker)
        Me.GroupBox2.Location = New System.Drawing.Point(491, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(295, 278)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Abrechnungszeitraumparameter"
        '
        'UcMonthRangePicker1
        '
        Me.MonthRangePicker.Location = New System.Drawing.Point(6, 21)
        Me.MonthRangePicker.MaximumSize = New System.Drawing.Size(280, 290)
        Me.MonthRangePicker.MinimumSize = New System.Drawing.Size(280, 250)
        MonthRangePickerResult1.MonthRangeBase = Facesso.MonthRangeBase.FirstToLastPrevious
        MonthRangePickerResult1.RelatedMonth = Facesso.RelatedMonth.PreviousMonth
        Me.MonthRangePicker.Name = "UcMonthRangePicker1"
        Me.MonthRangePicker.Size = New System.Drawing.Size(280, 250)
        Me.MonthRangePicker.TabIndex = 5
        '
        'frmIncentiveWageCalc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 359)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblCurrentEmployee)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnPerformCalculation)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmIncentiveWageCalc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Prämienlohnabrechnung Mitarbeiter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnUnselectAll As System.Windows.Forms.Button
    Friend WithEvents btnPerformCalculation As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbEmployeesToAnalyse As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCurrentEmployee As System.Windows.Forms.Label
    Friend WithEvents elvEmployees As Facesso.FrontEnd.ucEmployeeListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MonthRangePicker As Facesso.FrontEnd.ucMonthRangePicker
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeTimeList
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnCurrentMonth = New System.Windows.Forms.Button
        Me.btnLastMonth = New System.Windows.Forms.Button
        Me.btnSecondLastMonth = New System.Windows.Forms.Button
        Me.dgvTimeList = New Facesso.FrontEnd.ucTimeLogItemsDataGridView
        CType(Me.dgvTimeList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(549, 458)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(120, 31)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(15, 65)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(203, 20)
        Me.dtpTo.TabIndex = 12
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(15, 26)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(203, 20)
        Me.dtpFrom.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "bis:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "von:"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(541, 24)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 25)
        Me.btnRefresh.TabIndex = 14
        Me.btnRefresh.Text = "Aktualisieren"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(423, 458)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(120, 31)
        Me.btnPrint.TabIndex = 15
        Me.btnPrint.Text = "Drucken..."
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCurrentMonth
        '
        Me.btnCurrentMonth.Location = New System.Drawing.Point(252, 24)
        Me.btnCurrentMonth.Name = "btnCurrentMonth"
        Me.btnCurrentMonth.Size = New System.Drawing.Size(129, 21)
        Me.btnCurrentMonth.TabIndex = 16
        Me.btnCurrentMonth.Text = "laufender Monat"
        Me.btnCurrentMonth.UseVisualStyleBackColor = True
        '
        'btnLastMonth
        '
        Me.btnLastMonth.Location = New System.Drawing.Point(252, 45)
        Me.btnLastMonth.Name = "btnLastMonth"
        Me.btnLastMonth.Size = New System.Drawing.Size(129, 21)
        Me.btnLastMonth.TabIndex = 17
        Me.btnLastMonth.Text = "letzter Monat"
        Me.btnLastMonth.UseVisualStyleBackColor = True
        '
        'btnSecondLastMonth
        '
        Me.btnSecondLastMonth.Location = New System.Drawing.Point(252, 65)
        Me.btnSecondLastMonth.Name = "btnSecondLastMonth"
        Me.btnSecondLastMonth.Size = New System.Drawing.Size(129, 21)
        Me.btnSecondLastMonth.TabIndex = 18
        Me.btnSecondLastMonth.Text = "vorletzter Monat"
        Me.btnSecondLastMonth.UseVisualStyleBackColor = True
        '
        'dgvTimeList
        '
        Me.dgvTimeList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTimeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimeList.EmployeeTimeLogItems = Nothing
        Me.dgvTimeList.Location = New System.Drawing.Point(3, 101)
        Me.dgvTimeList.Name = "dgvTimeList"
        Me.dgvTimeList.SingleEmployeeList = False
        Me.dgvTimeList.Size = New System.Drawing.Size(666, 345)
        Me.dgvTimeList.TabIndex = 13
        '
        'frmEmployeeTimeList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 501)
        Me.Controls.Add(Me.btnSecondLastMonth)
        Me.Controls.Add(Me.btnLastMonth)
        Me.Controls.Add(Me.btnCurrentMonth)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvTimeList)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmEmployeeTimeList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Zeitenliste für:"
        CType(Me.dgvTimeList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvTimeList As Facesso.FrontEnd.ucTimeLogItemsDataGridView
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCurrentMonth As System.Windows.Forms.Button
    Friend WithEvents btnLastMonth As System.Windows.Forms.Button
    Friend WithEvents btnSecondLastMonth As System.Windows.Forms.Button
End Class

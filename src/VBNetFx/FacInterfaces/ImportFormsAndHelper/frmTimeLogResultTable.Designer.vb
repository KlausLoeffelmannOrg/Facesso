<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimeLogResultTable
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.btnOK = New System.Windows.Forms.Button
        Me.rvEmployeeTimeLogResult = New Microsoft.Reporting.WinForms.ReportViewer
        Me.btnCancel = New System.Windows.Forms.Button
        Me.tcReports = New System.Windows.Forms.TabControl
        Me.tpEmployeeReport = New System.Windows.Forms.TabPage
        Me.tpWorksiteReport = New System.Windows.Forms.TabPage
        Me.rvWorksiteTimeLogResult = New Microsoft.Reporting.WinForms.ReportViewer
        Me.TimeDataRowBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tcReports.SuspendLayout()
        Me.tpEmployeeReport.SuspendLayout()
        Me.tpWorksiteReport.SuspendLayout()
        CType(Me.TimeDataRowBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(590, 613)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(115, 38)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "So übernehmen"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'rvEmployeeTimeLogResult
        '
        Me.rvEmployeeTimeLogResult.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "Facesso_Interfaces_TimeDataRow"
        ReportDataSource1.Value = Me.TimeDataRowBindingSource
        Me.rvEmployeeTimeLogResult.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvEmployeeTimeLogResult.LocalReport.ReportEmbeddedResource = "Facesso.Interfaces.rptTimeLogImportResults.rdlc"
        Me.rvEmployeeTimeLogResult.Location = New System.Drawing.Point(3, 3)
        Me.rvEmployeeTimeLogResult.Name = "rvEmployeeTimeLogResult"
        Me.rvEmployeeTimeLogResult.Size = New System.Drawing.Size(800, 565)
        Me.rvEmployeeTimeLogResult.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btnCancel.Location = New System.Drawing.Point(711, 613)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(115, 38)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Nicht übernehmen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tcReports
        '
        Me.tcReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcReports.Controls.Add(Me.tpEmployeeReport)
        Me.tcReports.Controls.Add(Me.tpWorksiteReport)
        Me.tcReports.Location = New System.Drawing.Point(12, 12)
        Me.tcReports.Name = "tcReports"
        Me.tcReports.SelectedIndex = 0
        Me.tcReports.Size = New System.Drawing.Size(814, 597)
        Me.tcReports.TabIndex = 4
        '
        'tpEmployeeReport
        '
        Me.tpEmployeeReport.Controls.Add(Me.rvEmployeeTimeLogResult)
        Me.tpEmployeeReport.Location = New System.Drawing.Point(4, 22)
        Me.tpEmployeeReport.Name = "tpEmployeeReport"
        Me.tpEmployeeReport.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEmployeeReport.Size = New System.Drawing.Size(806, 571)
        Me.tpEmployeeReport.TabIndex = 0
        Me.tpEmployeeReport.Text = "Mitarbeiter"
        Me.tpEmployeeReport.UseVisualStyleBackColor = True
        '
        'tpWorksiteReport
        '
        Me.tpWorksiteReport.Controls.Add(Me.rvWorksiteTimeLogResult)
        Me.tpWorksiteReport.Location = New System.Drawing.Point(4, 22)
        Me.tpWorksiteReport.Name = "tpWorksiteReport"
        Me.tpWorksiteReport.Padding = New System.Windows.Forms.Padding(3)
        Me.tpWorksiteReport.Size = New System.Drawing.Size(806, 571)
        Me.tpWorksiteReport.TabIndex = 1
        Me.tpWorksiteReport.Text = "Arbeitsgruppen"
        Me.tpWorksiteReport.UseVisualStyleBackColor = True
        '
        'rvWorksiteTimeLogResult
        '
        Me.rvWorksiteTimeLogResult.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "TimeDataRow"
        ReportDataSource2.Value = Me.TimeDataRowBindingSource
        Me.rvWorksiteTimeLogResult.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvWorksiteTimeLogResult.LocalReport.ReportEmbeddedResource = "Facesso.Interfaces.rptWorksiteTimeLogImportResult.rdlc"
        Me.rvWorksiteTimeLogResult.Location = New System.Drawing.Point(3, 3)
        Me.rvWorksiteTimeLogResult.Name = "rvWorksiteTimeLogResult"
        Me.rvWorksiteTimeLogResult.Size = New System.Drawing.Size(800, 565)
        Me.rvWorksiteTimeLogResult.TabIndex = 0
        '
        'TimeDataRowBindingSource
        '
        Me.TimeDataRowBindingSource.DataSource = GetType(Facesso.Interfaces.TimeDataRow)
        '
        'frmTimeLogResultTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 663)
        Me.Controls.Add(Me.tcReports)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmTimeLogResultTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Zeitübernahmeergebnisse:"
        Me.tcReports.ResumeLayout(False)
        Me.tpEmployeeReport.ResumeLayout(False)
        Me.tpWorksiteReport.ResumeLayout(False)
        CType(Me.TimeDataRowBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents rvEmployeeTimeLogResult As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TimeDataRowBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tcReports As System.Windows.Forms.TabControl
    Friend WithEvents tpEmployeeReport As System.Windows.Forms.TabPage
    Friend WithEvents tpWorksiteReport As System.Windows.Forms.TabPage
    Friend WithEvents rvWorksiteTimeLogResult As Microsoft.Reporting.WinForms.ReportViewer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportEmployeeMasterData
    Inherits frmBaseFacesso

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
        Me.rvEmployees = New Microsoft.Reporting.WinForms.ReportViewer
        Me.MasterDataSet = New Facesso.Functions.MasterDataSet
        Me.EmployeesWithCostCentersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeesWithCostCentersTableAdapter = New Facesso.Functions.MasterDataSetTableAdapters.EmployeesWithCostCentersTableAdapter
        CType(Me.MasterDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesWithCostCentersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvEmployees
        '
        Me.rvEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "MasterDataSet_EmployeesWithCostCenters"
        ReportDataSource1.Value = Me.EmployeesWithCostCentersBindingSource
        Me.rvEmployees.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvEmployees.LocalReport.ReportEmbeddedResource = "Facesso.Functions.ReportsEmployeeMasterData.rdlc"
        Me.rvEmployees.Location = New System.Drawing.Point(12, 12)
        Me.rvEmployees.Name = "rvEmployees"
        Me.rvEmployees.Size = New System.Drawing.Size(510, 411)
        Me.rvEmployees.TabIndex = 0
        '
        'MasterDataSet
        '
        Me.MasterDataSet.DataSetName = "MasterDataSet"
        Me.MasterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmployeesWithCostCentersBindingSource
        '
        Me.EmployeesWithCostCentersBindingSource.DataMember = "EmployeesWithCostCenters"
        Me.EmployeesWithCostCentersBindingSource.DataSource = Me.MasterDataSet
        '
        'EmployeesWithCostCentersTableAdapter
        '
        Me.EmployeesWithCostCentersTableAdapter.ClearBeforeFill = True
        '
        'ReportEmployeeMasterData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 435)
        Me.Controls.Add(Me.rvEmployees)
        Me.Name = "ReportEmployeeMasterData"
        Me.Text = "Mitarbeiterstammdaten"
        CType(Me.MasterDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesWithCostCentersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvEmployees As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents EmployeesWithCostCentersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MasterDataSet As Facesso.Functions.MasterDataSet
    Friend WithEvents EmployeesWithCostCentersTableAdapter As Facesso.Functions.MasterDataSetTableAdapters.EmployeesWithCostCentersTableAdapter
End Class

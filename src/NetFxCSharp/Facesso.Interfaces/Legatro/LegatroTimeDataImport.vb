Imports System.Windows.Forms

<FacessoImportFilterName("Legato-Zeitdatenimport", FacessoImportType.TimeKeepingData, FacessoInterfaceBrand.LegatroTimeKeeping)> _
Public Class LegatroTimeDataImport
    Inherits TimeDataImportBase

    Private myLegatroSQLConnectionString As String

    Public Overrides Function ConfigureGenericInterface() As System.Windows.Forms.DialogResult
        Return MessageBox.Show("Configure Inport Filter")
    End Function

    Public Overrides Function ConfigureImportFilter() As System.Windows.Forms.DialogResult
        Dim frm As New frmLegatroTimeDataConfigDialog
        Return frm.HandleDialog(Me)
    End Function

    Public Overrides Function GetData(ByVal ProductionDate As Date, ByVal Shift As ShiftCombination) As IImportResultTable
        Dim ltdt As New LegatroTimeDataTransformation(ProductionDate, Shift, Me)
        ltdt.Convert()
        Return ltdt.ResultTable
    End Function

    Public Overrides ReadOnly Property InterfaceBrand() As FacessoInterfaceBrand
        Get
            Return FacessoInterfaceBrand.LegatroTimeKeeping
        End Get
    End Property

    Public Property LegatroSQLConnectionString() As String
        Get
            Return myLegatroSQLConnectionString
        End Get
        Set(ByVal value As String)
            myLegatroSQLConnectionString = value
        End Set
    End Property

    Public Overrides Function AssembleConversionItems() As FacessoConversionItemsBase
        If String.IsNullOrEmpty(LegatroSQLConnectionString) Then
            Return Nothing
        End If

        Dim locConversionItems As New FacessoConversionItemsBase

        Dim dc As New LegatroDataContext(LegatroSQLConnectionString)
        Dim wg = From wgItems In dc.WorksitesOrProjects _
               Order By wgItems.WorkEntityNumber
        For Each wgItem In wg
            locConversionItems.Add(New FacessoConversionItemBase(wgItem.WorkEntityNumber, wgItem.WorkEntityName))
        Next
        Return locConversionItems
    End Function

    Public Overrides ReadOnly Property IsGenericInterfaceConfigured() As Boolean
        Get
            Return True
        End Get
    End Property


End Class

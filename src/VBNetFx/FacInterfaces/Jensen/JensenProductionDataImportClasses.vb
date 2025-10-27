Imports System.Data.OleDb

<FacessoImportFilterName("Jensen Produktionsdatenimport", FacessoImportType.WorkGroupData, FacessoInterfaceBrand.KannegiesserProductionData)> _
Public Class JensenProductionDataImportTaskElement
    Inherits FacessoProductionDataImportTaskItemBase

    Private myJensenSQLConnectionString As String
    Private myJensenDeviceID As String
    Private myCurrDate As Date
    Private myCurrOrgData As DataTable
    Private myCurrFacData As ProductionDataTable

    Public Property JensenSQLConnectionString() As String
        Get
            Return myJensenSQLConnectionString
        End Get
        Set(ByVal value As String)
            myJensenSQLConnectionString = value
        End Set
    End Property

    Public Property JensenDeviceID() As String
        Get
            Return myJensenDeviceID
        End Get
        Set(ByVal value As String)
            myJensenDeviceID = value
        End Set
    End Property

    Public Overrides Function ConfigureImportFilter() As System.Windows.Forms.DialogResult
        Dim locFrm As New frmJensenProdDataConfigDialog
        Return locFrm.HandleDialog(Me)
    End Function

    Public Overrides Function GetData(ByVal ProductionDate As Date, ByVal Shift As ShiftCombination) As IImportResultTable
        retrieveDataForDate(ProductionDate)
        Return myCurrFacData
    End Function

    Public Overrides ReadOnly Property ImportType() As FacessoImportType
        Get
            Return FacessoImportType.WorkGroupData
        End Get
    End Property

    Public Overrides ReadOnly Property InterfaceBrand() As FacessoInterfaceBrand
        Get
            Return FacessoInterfaceBrand.JensenProductionData
        End Get
    End Property

    Public Overrides Function ConfigureGenericInterface() As System.Windows.Forms.DialogResult
        Return Windows.Forms.DialogResult.OK
    End Function

    Public Overrides ReadOnly Property IsGenericInterfaceConfigured() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Function AssembleConversionItems() As FacessoConversionItemsBase
        Return MyBase.AssembleConversionItems
    End Function
End Class

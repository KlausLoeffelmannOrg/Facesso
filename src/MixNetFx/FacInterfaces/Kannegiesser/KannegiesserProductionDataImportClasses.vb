Imports System.Data.OleDb

<FacessoImportFilterName("Kannegiesser Produktionsdatenimport", FacessoImportType.WorkGroupData, FacessoInterfaceBrand.KannegiesserProductionData)> _
Public Class KannegiesserProductionDataImportTaskElement
    Inherits FacessoProductionDataImportTaskItemBase

    Private myPathToDeviceData As String
    Private myCurrDate As Date
    Private myCurrOrgData As DataTable
    Private myCurrFacData As ProductionDataTable

    Public Property PathToDeviceData() As String
        Get
            Return myPathToDeviceData
        End Get
        Set(ByVal value As String)
            myPathToDeviceData = value
        End Set
    End Property

    Public Overrides Function ConfigureImportFilter() As System.Windows.Forms.DialogResult
        Dim locFrm As New frmKannegiesserProdDataConfigDialog
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
            Return FacessoInterfaceBrand.KannegiesserProductionData
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
        If PathToDeviceData Is Nothing Then
            Return Nothing
        End If

        Dim locConversionItems As FacessoConversionItemsBase
        locConversionItems = New FacessoConversionItemsBase

        Dim locConnection As New OleDbConnection(ConnectionString)
        Using locConnection
            Dim locAdapter As New OleDbDataAdapter("SELECT * FROM ARTPAR", locConnection)
            Dim locTable As New DataTable()
            Dim locIntBack As Integer = locAdapter.Fill(locTable)
            For Each locRow As DataRow In locTable.Rows
                locConversionItems.Add(New FacessoConversionItemBase(CInt(locRow("INDEX")), locRow("NAME").ToString))
            Next
        End Using
        Return locConversionItems
    End Function

    Public ReadOnly Property ConnectionString() As String
        Get
            Dim locConnString As String

            If myPathToDeviceData Is Nothing Then
                Return Nothing
            End If
            locConnString = "Jet OLEDB:Database Password=;"
            locConnString += "Data Source=" + myPathToDeviceData & ";Password=;"
            locConnString += "Provider=""Microsoft.Jet.OLEDB.4.0"";"
            locConnString += "Extended Properties=dBASE IV;"
            locConnString += "Jet OLEDB:SFP=False;"
            locConnString += "Mode=Share Deny None;"
            locConnString += "User ID=Admin;"
            Return locConnString
        End Get
    End Property

End Class

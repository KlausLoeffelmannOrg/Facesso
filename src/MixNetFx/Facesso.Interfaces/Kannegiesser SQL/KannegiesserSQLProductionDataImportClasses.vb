Imports System.Data.OleDb
Imports System.Data.SqlClient

<FacessoImportFilterName("Kannegiesser SQL Produktionsdatenimport", FacessoImportType.WorkGroupData, FacessoInterfaceBrand.KannegiesserSQLProductionData)> _
Public Class KannegiesserSQLProductionDataImportTaskElement
    Inherits FacessoProductionDataImportTaskItemBase

    Private myKannegiesserSQLConnectionString As String
    Private myCurrDate As Date
    Private myCurrOrgData As DataTable
    Private myCurrFacData As ProductionDataTable

    Public Property KannegiesserDeviceID As String

    Public Overrides Function ConfigureImportFilter() As System.Windows.Forms.DialogResult
        Dim locFrm As New frmKannegiesserSQLProdDataConfigDialog
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
            Return FacessoInterfaceBrand.KannegiesserSQLProductionData
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
        If KannegiesserSQLConnectionString Is Nothing Then
            Return Nothing
        End If

        Dim locConversionItems As FacessoConversionItemsBase
        locConversionItems = New FacessoConversionItemsBase


        Dim oc = New KannegiesserDataContext()
        Dim artpar = From prgItems In oc.GetArticles

        For Each artItems In artpar
            locConversionItems.Add(New FacessoConversionItemBase(artItems.ArticleID, artItems.ArticleName))
        Next
        Return locConversionItems
    End Function

    'Dass es hier zwei Eigenschaften gibt, die den SQL-Connection-String zurückliefern, hat historische Gründe.
    Public ReadOnly Property ConnectionString() As String
        Get
            Return myKannegiesserSQLConnectionString
        End Get
    End Property

    Public Property KannegiesserSQLConnectionString() As String
        Get
            Return myKannegiesserSQLConnectionString
        End Get
        Set(ByVal value As String)
            myKannegiesserSQLConnectionString = value
        End Set
    End Property

End Class

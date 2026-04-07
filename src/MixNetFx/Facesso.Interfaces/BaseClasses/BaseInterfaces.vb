Imports System.Windows.Forms
Imports Facesso.Data

Public Interface IFacessoImportTaskItem

    Delegate Function GetConversionItemsDelegate() As FacessoConversionItemsBase

    Property TaskID() As Long
    Property Priority() As Integer
    ReadOnly Property InterfaceBrand() As FacessoInterfaceBrand
    ReadOnly Property ImportType() As FacessoImportType
    ReadOnly Property ForWorkgroup() As WorkGroupInfo
    ReadOnly Property IsGenericInterfaceConfigured() As Boolean
    Property IDWorkgroup() As Integer
    Property ConversionItems() As FacessoConversionItemsBase
    Property Name() As String
    Function ConfigureImportFilter() As DialogResult
    Function ConfigureGenericInterface() As DialogResult
    Function GetData(ByVal ProductionDate As Date, ByVal Shift As ShiftCombination) As IImportResultTable
    Function ToString() As String
    ReadOnly Property ConversionItemsDelegate() As GetConversionItemsDelegate
End Interface

Public Interface IFacessoConversionItem
    Property AlienElementID() As Integer
    Property HomeElementID() As Integer
    Property HomeElementName() As String
    Property Itemname() As String
    Function ToString() As String
End Interface

Public Enum FacessoInterfaceBrand
    BaseClass = 0
    KannegiesserTimeKeeping = 1
    KannegiesserProductionData = 2
    JensenProductionData = 4
    ZI_Timekeeping = 8
    InterflexTimeKeeping = 16
    LegatroTimeKeeping = 32
    KannegiesserSQLProductionData = 64
End Enum

Public Enum TimeKeepingEntryType
    TimeKeeping = 0
    DownTime = -1
    WorkBreak = -2
End Enum

Public Enum FacessoImportType
    NotDefined
    WorkGroupData
    TimeKeepingData
End Enum

Public Enum ShiftCombination
    None = 0
    Shift1 = 1
    Shift2 = 2
    Shift3 = 4
    Shift4 = 8
    All = 15
End Enum

''' <summary>
'''     Attribut, mit der man eine TaskItemKlasse kennzeichnet, damit sie als solche erkannt wird.
''' </summary>
''' <remarks>
'''     Zum Beispiel:
'''     "FacessoImportFilterName("Jensen Produktionsdatenimport", FacessoImportType.WorkGroupData, FacessoInterfaceBrand.KannegiesserProductionData)" _
''' </remarks>
Public Class FacessoImportFilterNameAttribute
    Inherits Attribute

    Private myImportFiltername As String
    Private myImportType As FacessoImportType
    Private myInterfaceBrand As FacessoInterfaceBrand

    Sub New(ByVal ImportFilterName As String, ByVal Importtype As FacessoImportType, ByVal Interfacebrand As FacessoInterfaceBrand)
        myImportFiltername = ImportFilterName
        myImportType = Importtype
        myInterfaceBrand = Interfacebrand
    End Sub

    Public Property ImportFiltername() As String
        Get
            Return myImportFiltername
        End Get
        Set(ByVal value As String)
            myImportFiltername = value
        End Set
    End Property

    Public Property ImportType() As FacessoImportType
        Get
            Return myImportType
        End Get
        Set(ByVal value As FacessoImportType)
            myImportType = value
        End Set
    End Property

    Public Property InterfaceBrand() As FacessoInterfaceBrand
        Get
            Return myInterfaceBrand
        End Get
        Set(ByVal value As FacessoInterfaceBrand)
            myInterfaceBrand = value
        End Set
    End Property

    Public ReadOnly Property DeviceTypeID() As Long
        Get
            Return CLng(InterfaceBrand)
        End Get
    End Property
End Class

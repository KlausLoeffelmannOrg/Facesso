Imports System.Windows.Forms
Imports Facesso
Imports Facesso.Data

<Serializable()> _
Public Class FacessoTaskItems
    Inherits System.Collections.ObjectModel.KeyedCollection(Of Long, FacessoTaskItemBase)

    Public Function NextPriorityLevel() As Integer
        Dim locPriority As Integer = -1
        For Each locItem As IFacessoImportTaskItem In Me
            If locItem.Priority > locPriority Then
                locPriority = locItem.Priority
            End If
        Next
        Return locPriority + 1
    End Function

    Public Function NextTaskID() As Long
        Dim locTaskID As Long = -1
        For Each locItem As IFacessoImportTaskItem In Me
            If locItem.TaskID > locTaskID Then
                locTaskID = locItem.TaskID
            End If
        Next
        Return locTaskID + 1
    End Function

    Protected Overrides Function GetKeyForItem(ByVal item As FacessoTaskItemBase) As Long
        Return item.TaskID
    End Function
End Class

<Serializable()> _
Public MustInherit Class FacessoTaskItemBase
    Implements IFacessoImportTaskItem

    Private myConversionItems As FacessoConversionItemsBase
    Private myTaskID As Long
    Private myWorkgroup As WorkGroupInfo
    Private myForWorkgroup As WorkGroupInfo
    Private myName As String
    Private myPriority As Integer

    Public MustOverride Function GetData(ByVal ProductionDate As Date, ByVal Shift As ShiftCombination) As IImportResultTable Implements IFacessoImportTaskItem.GetData
    Public MustOverride ReadOnly Property ImportType() As FacessoImportType Implements IFacessoImportTaskItem.ImportType
    Public MustOverride ReadOnly Property InterfaceBrand() As FacessoInterfaceBrand Implements IFacessoImportTaskItem.InterfaceBrand
    Public MustOverride Function ConfigureGenericInterface() As System.Windows.Forms.DialogResult Implements IFacessoImportTaskItem.ConfigureGenericInterface
    Public MustOverride ReadOnly Property IsGenericInterfaceConfigured() As Boolean Implements IFacessoImportTaskItem.IsGenericInterfaceConfigured
    Public MustOverride Function ConfigureImportFilter() As DialogResult Implements IFacessoImportTaskItem.ConfigureImportFilter
    Public MustOverride ReadOnly Property ConversionItemsDelegate() As IFacessoImportTaskItem.GetConversionItemsDelegate Implements IFacessoImportTaskItem.ConversionItemsDelegate

    Sub New()
        MyBase.New()
    End Sub

    Public Overridable Property ConversionItems() As FacessoConversionItemsBase Implements IFacessoImportTaskItem.ConversionItems
        Get
            Return myConversionItems
        End Get
        Set(ByVal value As FacessoConversionItemsBase)
            myConversionItems = value
        End Set
    End Property

    Public Overridable Property TaskID() As Long Implements IFacessoImportTaskItem.TaskID
        Get
            Return myTaskID
        End Get
        Set(ByVal value As Long)
            myTaskID = value
        End Set
    End Property

    Public Overridable Property IDWorkgroup() As Integer Implements IFacessoImportTaskItem.IDWorkgroup
        Get
            If ForWorkgroup IsNot Nothing Then
                Return ForWorkgroup.IDWorkGroup
            Else
                Return -1
            End If
        End Get
        Set(ByVal value As Integer)
            If value > -1 Then
                myForWorkgroup = WorkGroupInfo.FromID(FacessoGeneric.LoginInfo.IDSubsidiary, CInt(value))
            End If
        End Set
    End Property

    Public ReadOnly Property ForWorkgroup() As WorkGroupInfo Implements IFacessoImportTaskItem.ForWorkgroup
        Get
            Return myForWorkgroup
        End Get
    End Property

    Public Property Name() As String Implements IFacessoImportTaskItem.Name
        Get
            Return myName
        End Get
        Set(ByVal value As String)
            myName = value
        End Set
    End Property

    Public Property Priority() As Integer Implements IFacessoImportTaskItem.Priority
        Get
            Return myPriority
        End Get
        Set(ByVal value As Integer)
            myPriority = value
        End Set
    End Property

    Public Overrides Function ToString() As String Implements IFacessoImportTaskItem.ToString
        Return TaskID.ToString
    End Function
End Class

<Serializable()> _
Public MustInherit Class FacessoProductionDataImportTaskItemBase
    Inherits FacessoTaskItemBase

    Public Overrides Function ConfigureImportFilter() As System.Windows.Forms.DialogResult
        Dim locFrm As New frmProductionDataConfigureDialogBase
        Return locFrm.HandleDialog(Me)
    End Function

    ''' <summary>
    ''' Erstellt eine generische Konvertierungstabelle, 
    ''' die in den jeweiligen Ableitungen für die Zuordnungen FremdID-->Produktiv-Site verantwortlich ist.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Diese wird Indirekt über den Delegaten ConversionItemsDelegate aufgerufen.</remarks>
    Public Overridable Function AssembleConversionItems() As FacessoConversionItemsBase

        Dim locConversionItems As FacessoConversionItemsBase

        locConversionItems = New FacessoConversionItemsBase
        For c As Integer = 0 To 100
            locConversionItems.Add(New FacessoConversionItemBase(c, "Programm Nr. " & c.ToString("000")))
        Next
        Return locConversionItems
    End Function

    ''' <summary>
    ''' Ermittelt den Delegaten, der die Funktion zur Verfügung stellt, die die Konvertierungstabelle aufbaut.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property ConversionItemsDelegate() As IFacessoImportTaskItem.GetConversionItemsDelegate
        Get
            Return AddressOf AssembleConversionItems
        End Get
    End Property

    Public Overrides ReadOnly Property ImportType() As FacessoImportType
        Get
            Return FacessoImportType.WorkGroupData
        End Get
    End Property
End Class

<Serializable()> _
Public Class FacessoTaskItemTemplate
    Implements IFacessoImportTaskItem

    Private myWorkgroup As WorkGroupInfo
    Private myName As String
    Private myInterfaceBrand As FacessoInterfaceBrand
    Private myImportType As FacessoImportType
    Private myTaskID As Long
    Private myPriority As Integer

    Sub New(ByVal TaskID As Long, ByVal Name As String, ByVal ImportType As FacessoImportType)
        Me.New(TaskID, Name, ImportType, -1)
    End Sub

    Sub New(ByVal TaskID As Long, ByVal Name As String, ByVal ImportType As FacessoImportType, ByVal IDWorkgroup As Long)

        myTaskID = TaskID
        myName = Name
        myImportType = ImportType
        If IDWorkgroup = -1 Then
            myWorkgroup = Nothing
        Else
            myWorkgroup = WorkGroupInfo.FromID(FacessoGeneric.LoginInfo.IDSubsidiary, CInt(IDWorkgroup))
        End If
    End Sub

    Public Function ConfigureImportFilter() As System.Windows.Forms.DialogResult Implements IFacessoImportTaskItem.ConfigureImportFilter
        Return DialogResult.Ignore
    End Function

    Public Property ConversionItems() As FacessoConversionItemsBase Implements IFacessoImportTaskItem.ConversionItems
        Get
            Return Nothing
        End Get
        Set(ByVal value As FacessoConversionItemsBase)
        End Set
    End Property

    Public ReadOnly Property ConversionItemsDelegate() As IFacessoImportTaskItem.GetConversionItemsDelegate Implements IFacessoImportTaskItem.ConversionItemsDelegate
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property ForWorkgroup() As Data.WorkGroupInfo Implements IFacessoImportTaskItem.ForWorkgroup
        Get
            Return myWorkgroup
        End Get
    End Property

    Public Function GetData(ByVal ProductionDate As Date, ByVal Shift As ShiftCombination) As IImportResultTable Implements IFacessoImportTaskItem.GetData
        Return Nothing
    End Function

    Public Property IDWorkgroup() As Integer Implements IFacessoImportTaskItem.IDWorkgroup
        Get
            If myWorkgroup Is Nothing Then
                Return -1
            End If
            Return myWorkgroup.IDWorkGroup
        End Get
        Set(ByVal value As Integer)
            If value = -1 Then
                myWorkgroup = Nothing
                Return
            End If
            myWorkgroup = WorkGroupInfo.FromID(FacessoGeneric.LoginInfo.IDSubsidiary, IDWorkgroup)
        End Set
    End Property

    Public ReadOnly Property ImportType() As FacessoImportType Implements IFacessoImportTaskItem.ImportType
        Get
            Return myImportType
        End Get
    End Property

    Public ReadOnly Property InterfaceBrand() As FacessoInterfaceBrand Implements IFacessoImportTaskItem.InterfaceBrand
        Get
            Return myInterfaceBrand
        End Get
    End Property

    Public Sub SetInterfaceBrand(ByVal InterfaceBrand As FacessoInterfaceBrand)
        myInterfaceBrand = InterfaceBrand
    End Sub

    Public Property Name() As String Implements IFacessoImportTaskItem.Name
        Get
            Return myName
        End Get
        Set(ByVal value As String)
            myName = value
        End Set
    End Property

    Public Property TaskID() As Long Implements IFacessoImportTaskItem.TaskID
        Get
            Return myTaskID
        End Get
        Set(ByVal value As Long)
            myTaskID = value
        End Set
    End Property

    Public Overrides Function ToString() As String Implements IFacessoImportTaskItem.ToString
        Return myName
    End Function

    Public Property Priority() As Integer Implements IFacessoImportTaskItem.Priority
        Get
            Return myPriority
        End Get
        Set(ByVal value As Integer)
            myPriority = value
        End Set
    End Property

    Public Function ConfigureGenericInterface() As System.Windows.Forms.DialogResult Implements IFacessoImportTaskItem.ConfigureGenericInterface
        Return DialogResult.OK
    End Function

    Public ReadOnly Property IsGenericInterfaceConfigured() As Boolean Implements IFacessoImportTaskItem.IsGenericInterfaceConfigured
        Get
            Return True
        End Get
    End Property
End Class


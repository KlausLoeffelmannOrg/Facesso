Imports Facesso
Imports System.Data.SqlClient
Imports ActiveDev

<CLSCompliant(True)> _
Public Class WorkGroupInfo
    Inherits InfoItemBase

    Private myIDWorkGroup As Integer
    Private myIDSubsidiary As Integer
    Private myIDCostCenter As Integer
    Private myIDWorkGroupInternal As Integer
    Private myIsCurrent As Boolean
    Private myWorkGroupNumber As Integer
    Private myWorkGroupName As String
    Private myWorkGroupDescription As ADDBNullable(Of String)
    Private myIsActive As Boolean
    Private myIsPeaceWork As Boolean
    Private myIsConceptional As Boolean
    Private myOrdinalNo As Integer
    Private myTimeSettingDetails As TimeSettingDetails
    Private myWorkloadIWT As Double
    Private myWasCurrentFrom As Date
    Private myWasCurrentTo As Date

    Private myCostCenterNo As Integer
    Private myCostCenterName As String
    Private myIncentiveIndicatorSynonym As String
    Private myIncentiveIndicatorDimension As String
    Private myIncentiveIndicatorPrecision As Byte
    Private myIncentiveIndicatorFactor As Double
    Private myBaseValuePrecision As Byte
    Private myBaseValueSynonym As String

    Private myHasProductionData As Boolean

    Private myCurrentDegreeOfTime As Double

    Sub New()
    End Sub

    Sub New(ByVal dr As SqlDataReader)
        With Me
            .IDWorkGroup = dr.GetInt32(dr.GetOrdinal("IDWorkGroup"))
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDWorkGroupInternal = dr.GetInt32(dr.GetOrdinal("IDWorkGroupInternal"))
            .IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"))
            .WorkGroupNumber = dr.GetInt32(dr.GetOrdinal("WorkGroupNumber"))
            .WorkGroupName = dr.GetString(dr.GetOrdinal("WorkGroupName"))
            .WorkGroupDescription = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("WorkGroupDescription")))
            .IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .IsPeaceWork = dr.GetBoolean(dr.GetOrdinal("IsPeaceWork"))
            .IsConceptional = dr.GetBoolean(dr.GetOrdinal("IsConceptional"))
            .OrdinalNo = dr.GetInt32(dr.GetOrdinal("OrdinalNo"))
            .TimeSettingDetails = Facesso.TimeSettingDetails.FromXmlString(dr.GetString(dr.GetOrdinal("TimeSettingDetails")))
            .WorkloadIWT = dr.GetDouble(dr.GetOrdinal("WorkloadIWT"))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))
        End With
    End Sub

    Sub New(ByVal InitializeDefaultsOnly As Boolean)
        With Me
            .IDCostCenter = SPAccess.GetInstance.GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary).IDCostCenter
            .IsActive = True
            .IsPeaceWork = False
            myTimeSettingDetails = DirectCast( _
                FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("GlobalTimeSettingDetailsTemplate", _
                    New TimeSettingDetails(#1/1/2003 6:00:00 AM#, #1/1/2003 2:00:00 PM#, _
                            #1/1/2003 10:00:00 PM#, #1/2/2003 5:00:00 AM#, _
                            Nothing, Nothing, 30)), _
                            TimeSettingDetails)
            'TODO: Konfigurierbar machen durch Subsidiary-INI
            '(was auch immer ich damit gemeint habe...)
        End With
    End Sub

    Sub New(ByVal dr As SqlDataReader, ByVal wgiGetType As WorkGroupInfoItemsGetType)
        With Me
            .IDWorkGroup = dr.GetInt32(dr.GetOrdinal("IDWorkGroup"))
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDWorkGroupInternal = dr.GetInt32(dr.GetOrdinal("IDWorkGroupInternal"))
            .IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"))
            .WorkGroupNumber = dr.GetInt32(dr.GetOrdinal("WorkGroupNumber"))
            .WorkGroupName = dr.GetString(dr.GetOrdinal("WorkGroupName"))
            .WorkGroupDescription = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("WorkGroupDescription")))
            .IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .IsPeaceWork = dr.GetBoolean(dr.GetOrdinal("IsPeaceWork"))
            .IsConceptional = dr.GetBoolean(dr.GetOrdinal("IsConceptional"))
            .WorkloadIWT = dr.GetDouble(dr.GetOrdinal("WorkloadIWT"))
            .OrdinalNo = dr.GetInt32(dr.GetOrdinal("OrdinalNo"))
            .TimeSettingDetails = Facesso.TimeSettingDetails.FromXmlString(dr.GetString(dr.GetOrdinal("TimeSettingDetails")))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))

            If (wgiGetType And WorkGroupInfoItemsGetType.JoinedWithCostCenter) = WorkGroupInfoItemsGetType.JoinedWithCostCenter Then
                myCostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"))
                myCostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"))
                myIncentiveIndicatorSynonym = dr.GetString(dr.GetOrdinal("IncentiveIndicatorSynonym"))
                myIncentiveIndicatorDimension = dr.GetString(dr.GetOrdinal("IncentiveIndicatorDimension"))
                myIncentiveIndicatorPrecision = dr.GetByte(dr.GetOrdinal("IncentiveIndicatorPrecision"))
                myIncentiveIndicatorFactor = dr.GetDouble(dr.GetOrdinal("IncentiveIndicatorFactor"))
                myBaseValuePrecision = dr.GetByte(dr.GetOrdinal("BaseValuePrecision"))
                myBaseValueSynonym = dr.GetString(dr.GetOrdinal("BaseValueSynonym"))
            End If

            If (wgiGetType And WorkGroupInfoItemsGetType.IncludeProductionDataStatus) = WorkGroupInfoItemsGetType.IncludeProductionDataStatus Then
                myHasProductionData = dr.GetBoolean(dr.GetOrdinal("HasProductionData"))
            End If
        End With
    End Sub

    Public Shared Operator =(ByVal val1 As WorkGroupInfo, ByVal Val2 As WorkGroupInfo) As Boolean
        Return (val1.IDWorkGroup = Val2.IDWorkGroup)
    End Operator

    Public Shared Operator <>(ByVal val1 As WorkGroupInfo, ByVal Val2 As WorkGroupInfo) As Boolean
        Return (val1.IDWorkGroup <> Val2.IDWorkGroup)
    End Operator

    Public Shared Function FromID(ByVal IDSubsidiary As Integer, ByVal IDWorkgroup As Integer) As WorkGroupInfo
        Return SPAccess.GetInstance.GetWorkGroup(IDSubsidiary, IDWorkgroup)
    End Function

    Public Shared Function FromWorkGroupNumber(ByVal IDSubsidiary As Integer, ByVal WorkGroupNumber As Integer) As WorkGroupInfo
        Return SPAccess.GetInstance.GetWorkGroupByWorkGroupNumber(IDSubsidiary, WorkGroupNumber)
    End Function

    Public Overridable Property IDWorkGroup() As Integer
        Get
            Return Me.myIDWorkGroup
        End Get
        Set(ByVal value As Integer)
            Me.myIDWorkGroup = value
        End Set
    End Property

    Public Overridable Property IDSubsidiary() As Integer
        Get
            Return Me.myIDSubsidiary
        End Get
        Set(ByVal value As Integer)
            Me.myIDSubsidiary = value
        End Set
    End Property

    Public Overridable Property IDWorkGroupInternal() As Integer
        Get
            Return Me.myIDWorkGroupInternal
        End Get
        Set(ByVal value As Integer)
            Me.myIDWorkGroupInternal = value
        End Set
    End Property

    Public Overridable Property IDCostCenter() As Integer
        Get
            Return Me.myIDCostCenter
        End Get
        Set(ByVal value As Integer)
            Me.myIDCostCenter = value
        End Set
    End Property

    Public Overridable ReadOnly Property HasProductionData() As Boolean
        Get
            Return myHasProductionData
        End Get
    End Property

    <ADAutoReportColumn("Produktiv-Site-Nr.", -2, 1)> _
    Public Overridable Property WorkGroupNumber() As Integer
        Get
            Return Me.myWorkGroupNumber
        End Get
        Set(ByVal value As Integer)
            Me.myWorkGroupNumber = value
        End Set
    End Property

    <ADAutoReportColumn("Produktiv-Site-Name:", -1, 2)> _
    Public Overridable Property WorkGroupName() As String
        Get
            Return Me.myWorkGroupName
        End Get
        Set(ByVal value As String)
            Me.myWorkGroupName = value
        End Set
    End Property

    Public Overridable Property WorkGroupDescription() As ADDBNullable(Of String)
        Get
            Return Me.myWorkGroupDescription
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            Me.myWorkGroupDescription = value
        End Set
    End Property

    Public Overridable Property IsCurrent() As Boolean
        Get
            Return Me.myIsCurrent
        End Get
        Set(ByVal value As Boolean)
            Me.myIsCurrent = value
        End Set
    End Property

    Public Overridable Property IsActive() As Boolean
        Get
            Return Me.myIsActive
        End Get
        Set(ByVal value As Boolean)
            Me.myIsActive = value
        End Set
    End Property

    Public Overridable Property IsPeaceWork() As Boolean
        Get
            Return Me.myIsPeaceWork
        End Get
        Set(ByVal value As Boolean)
            Me.myIsPeaceWork = value
        End Set
    End Property

    Public Overridable Property IsConceptional() As Boolean
        Get
            Return Me.myIsConceptional
        End Get
        Set(ByVal value As Boolean)
            Me.myIsConceptional = value
        End Set
    End Property

    Public Overridable Property OrdinalNo() As Integer
        Get
            Return Me.myOrdinalNo
        End Get
        Set(ByVal value As Integer)
            Me.myOrdinalNo = value
        End Set
    End Property

    Public Overridable Property WorkloadIWT() As Double
        Get
            Return myWorkloadIWT
        End Get
        Set(ByVal value As Double)
            myWorkloadIWT = value
        End Set
    End Property

    Public Overridable Property TimeSettingDetails() As TimeSettingDetails
        Get
            Return myTimeSettingDetails
        End Get
        Set(ByVal value As TimeSettingDetails)
            myTimeSettingDetails = value
        End Set
    End Property

    Public Overridable Property WasCurrentFrom() As Date
        Get
            Return Me.myWasCurrentFrom
        End Get
        Set(ByVal value As Date)
            Me.myWasCurrentFrom = value
        End Set
    End Property

    Public Overridable Property WasCurrentTo() As Date
        Get
            Return Me.myWasCurrentTo
        End Get
        Set(ByVal value As Date)
            Me.myWasCurrentTo = value
        End Set
    End Property

    Public Overrides ReadOnly Property DataID() As Integer
        Get
            Return myIDWorkGroup
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return WorkGroupName
        End Get
    End Property

    Public ReadOnly Property ListItemText() As String
        Get
            Return WorkGroupNumber.ToString("000000") & ": " & WorkGroupName
        End Get
    End Property

    Public Overridable ReadOnly Property CostCenterNo() As Integer
        Get
            Return Me.myCostCenterNo
        End Get
    End Property

    Public Overridable ReadOnly Property CostCenterName() As String
        Get
            Return Me.myCostCenterName
        End Get
    End Property

    Public ReadOnly Property IncentiveIndicatorSynonym() As String
        Get
            Return myIncentiveIndicatorSynonym
        End Get
    End Property

    Public ReadOnly Property IncentiveIndicatorDimension() As String
        Get
            Return myIncentiveIndicatorDimension
        End Get
    End Property

    Public ReadOnly Property IncentiveIndicatorPrecision() As Byte
        Get
            Return myIncentiveIndicatorPrecision
        End Get
    End Property

    Public Overridable ReadOnly Property IncentiveFormatString() As String
        Get
            Dim locFormat As String = "#,##0"
            If IncentiveIndicatorPrecision > 0 Then
                locFormat &= "." & New String("0"c, IncentiveIndicatorPrecision)
            End If
            Return locFormat
        End Get
    End Property

    Public ReadOnly Property BaseValueSynonym() As String
        Get
            Return myBaseValueSynonym
        End Get
    End Property

    Public ReadOnly Property BaseValuePrecision() As Byte
        Get
            Return myBaseValuePrecision
        End Get
    End Property

    Public Overridable ReadOnly Property BaseValueFormatString() As String
        Get
            Dim locFormat As String = "#,##0"
            If BaseValuePrecision > 0 Then
                locFormat &= "." & New String("0"c, BaseValuePrecision)
            End If
            Return locFormat
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.WorkGroupNumber & ": " & Me.WorkGroupName & IIf(Me.HasProductionData, " (D)", "").ToString
    End Function

    ''' <summary>
    ''' Bestimmt oder ermittelt nur zu Info- bzw. Zwischenspeicher- oder Parameterübergabezwecken den Zeitgrad dieser Gruppe.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentDegreeOfTime() As Double
        Get
            Return myCurrentDegreeOfTime
        End Get
        Set(ByVal value As Double)
            myCurrentDegreeOfTime = value
        End Set
    End Property
End Class

<CLSCompliant(True)> _
Public Class WorkGroupInfoItems
    Inherits InfoItems(Of WorkGroupInfo)

    Sub New()
        MyBase.new()
    End Sub

    Sub New(ByVal JoinedWithCostCenter As Boolean)
        MyBase.new()
        If JoinedWithCostCenter Then
            SPAccess.GetInstance.GetWorkGroupInfoCollection(Nothing, Me, WorkGroupInfoItemsGetType.JoinedWithCostCenter)
        Else
            SPAccess.GetInstance.GetWorkGroupInfoCollection(Nothing, Me, WorkGroupInfoItemsGetType.None)
        End If
    End Sub

    Sub New(ByVal CombinedParameters As CombinedParametersInfo)
        SPAccess.GetInstance.GetWorkGroupInfoCollection(CombinedParameters, Me, WorkGroupInfoItemsGetType.IncludeProductionDataStatus Or WorkGroupInfoItemsGetType.JoinedWithCostCenter)
    End Sub

    Public Function GetByWorkGroupNumber(ByVal WorkGroupNumber As Integer) As WorkGroupInfo
        For Each locItem As WorkGroupInfo In Me
            If locItem.WorkGroupNumber = WorkGroupNumber Then
                Return locItem
            End If
        Next
        Dim up As New FacessoGenericApplicationException("The requested WorkGroupNumber could not be found in the WorkGroupCollection!", Nothing)
        Throw up
    End Function
End Class

Public Enum WorkGroupInfoItemsGetType
    None = 0
    JoinedWithCostCenter = 1
    IncludeProductionDataStatus = 2
End Enum

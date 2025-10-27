Imports System.Data.SqlClient
Imports ActiveDev

<CLSCompliant(True)> _
Public Class LabourValueInfo
    Inherits InfoItemBase

    Private myIDLabourValue As Integer
    Private myIDSubsidiary As Integer
    Private myIDCostCenter As Integer
    Private myIDLabourValueInternal As Integer
    Private myLabourValueNumber As Integer
    Private myLabourValueName As String
    Private myLabourValueDescription As ADDBNullable(Of String)
    Private myTe As Double
    Private myDimension As String
    Private myIsActive As Boolean
    Private myIsCurrent As Boolean
    Private myWasCurrentFrom As Date
    Private myWasCurrentTo As Date

    Private myCostCenterNo As Integer
    Private myCostCenterName As String
    Private myBaseValueSynonym As String
    Private myBaseValuePrecision As Byte

    Sub New()
    End Sub

    Sub New(ByVal dr As SqlDataReader)
        With Me
            .IDLabourValue = dr.GetInt32(dr.GetOrdinal("IDLabourValue"))
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"))
            .IDLabourValueInternal = dr.GetInt32(dr.GetOrdinal("IDLabourValueInternal"))
            .LabourValueNumber = dr.GetInt32(dr.GetOrdinal("LabourValueNumber"))
            .LabourValueName = dr.GetString(dr.GetOrdinal("LabourValueName"))
            .LabourValueDescription = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("LabourValueDescription")))
            .TeHMin = dr.GetDouble(dr.GetOrdinal("TeHMin"))
            .Dimension = dr.GetString(dr.GetOrdinal("Dimension"))
            .IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))
        End With
    End Sub

    Sub New(ByVal dr As SqlDataReader, ByVal JoinedWithCostCenter As Boolean)
        With Me
            .IDLabourValue = dr.GetInt32(dr.GetOrdinal("IDLabourValue"))
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"))
            .IDLabourValueInternal = dr.GetInt32(dr.GetOrdinal("IDLabourValueInternal"))
            .LabourValueNumber = dr.GetInt32(dr.GetOrdinal("LabourValueNumber"))
            .LabourValueName = dr.GetString(dr.GetOrdinal("LabourValueName"))
            .LabourValueDescription = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("LabourValueDescription")))
            .TeHMin = dr.GetDouble(dr.GetOrdinal("TeHMin"))
            .Dimension = dr.GetString(dr.GetOrdinal("Dimension"))
            .IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))

            myBaseValuePrecision = dr.GetByte(dr.GetOrdinal("BaseValuePrecision"))
            myBaseValueSynonym = dr.GetString(dr.GetOrdinal("BaseValueSynonym"))
            myCostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"))
            myCostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"))
        End With
    End Sub

    Public Overridable Property IDLabourValue() As Integer
        Get
            Return Me.myIDLabourValue
        End Get
        Set(ByVal value As Integer)
            Me.myIDLabourValue = value
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

    Public Overridable Property IDCostCenter() As Integer
        Get
            Return Me.myIDCostCenter
        End Get
        Set(ByVal value As Integer)
            Me.myIDCostCenter = value
        End Set
    End Property

    Public Overridable Property IDLabourValueInternal() As Integer
        Get
            Return Me.myIDLabourValueInternal
        End Get
        Set(ByVal value As Integer)
            Me.myIDLabourValueInternal = value
        End Set
    End Property

    <ADAutoReportColumn("Arbeitswert-Nr.", -2, 1)> _
    Public Overridable Property LabourValueNumber() As Integer
        Get
            Return Me.myLabourValueNumber
        End Get
        Set(ByVal value As Integer)
            Me.myLabourValueNumber = value
        End Set
    End Property

    <ADAutoReportColumn("Arbeitswertname", -1, 2)> _
    Public Overridable Property LabourValueName() As String
        Get
            Return Me.myLabourValueName
        End Get
        Set(ByVal value As String)
            Me.myLabourValueName = value
        End Set
    End Property

    Public Overridable Property LabourValueDescription() As ADDBNullable(Of String)
        Get
            Return Me.myLabourValueDescription
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            Me.myLabourValueDescription = value
        End Set
    End Property

    <ADAutoReportColumn("te (in H/Min)", -2, 3)> _
    Public Overridable Property TeHMin() As Double
        Get
            Return myTe
        End Get
        Set(ByVal value As Double)
            myTe = value
        End Set
    End Property

    <ADAutoReportColumn("Einheit (Dimension):", -2, 4)> _
    Public Overridable Property Dimension() As String
        Get
            Return myDimension
        End Get
        Set(ByVal value As String)
            myDimension = value
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

    Public Overridable Property IsCurrent() As Boolean
        Get
            Return Me.myIsCurrent
        End Get
        Set(ByVal value As Boolean)
            Me.myIsCurrent = value
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
            Return myIDLabourValue
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return LabourValueName
        End Get
    End Property

    Public ReadOnly Property ListItemText() As String
        Get
            Return LabourValueNumber.ToString("000000") & ": " & LabourValueName
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

    Public Overridable ReadOnly Property BaseValuePrecision() As Byte
        Get
            Return myBaseValuePrecision
        End Get
    End Property

    Public Overridable ReadOnly Property BaseValueSynonym() As String
        Get
            Return myBaseValueSynonym
        End Get
    End Property

End Class

<CLSCompliant(True)> _
Public Class LabourValueInfoCollection
    Inherits InfoItems(Of LabourValueInfo)

    Public Function GetByLabourValueNumber(ByVal LabourValueNumber As Integer) As LabourValueInfo
        For Each locItem As LabourValueInfo In Me
            If locItem.LabourValueNumber = LabourValueNumber Then
                Return locItem
            End If
        Next
        Dim up As New FacessoGenericApplicationException("The requested LabourValueNumber could not be found in the LabourValueInfoCollection!", Nothing)
        Throw up
    End Function

    Public Shared Function GetWorkGroupAssignedLabourValues(ByVal IDSubsidiary As Integer, ByVal Workgroup As WorkGroupInfo) As LabourValueInfoCollection
        Return SPAccess.GetInstance.WorkGroups_GetAssignedLabourValues(IDSubsidiary, Workgroup.IDWorkGroup)
    End Function
End Class

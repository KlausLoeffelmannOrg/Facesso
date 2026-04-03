Imports System.Data.SqlClient
Imports ActiveDev

<CLSCompliant(True)> _
Public Class CostcenterInfo
    Inherits InfoItemBase

    Private myIDCostCenter As Integer
    Private myIDSubsidiary As Integer
    Private myIDCostCenterInternal As Integer
    Private myIsCurrent As Boolean
    Private myCostCenterNo As Integer
    Private myCostCenterName As String
    Private myCostCenterDescription As ADDBNullable(Of String)
    Private myIDCurrency As Integer
    Private myCurrencyToken As String
    Private myIncentiveIndicatorSynonym As String
    Private myIncentiveWageSynonym As String
    Private myIncentiveIndicatorDimension As String
    Private myIncentiveIndicatorPrecision As Byte
    Private myBaseValuePrecision As Byte
    Private myBaseValueSynonym As String
    Private myUseFixValuedBonus As Boolean
    Private myIncentiveIndicatorFactor As Double
    Private myWasCurrentFrom As Date
    Private myWasCurrentTo As Date

    Sub New()
    End Sub

    Sub New(ByVal dr As SqlDataReader)
        With Me
            .IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"))
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDCostCenterInternal = dr.GetInt32(dr.GetOrdinal("IDCostcenterInternal"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .CostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"))
            .CostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"))
            .CostCenterDescription = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("CostcenterDescription")))
            .IDCurrency = dr.GetInt32(dr.GetOrdinal("IDCurrency"))
            .IncentiveIndicatorSynonym = dr.GetString(dr.GetOrdinal("IncentiveIndicatorSynonym"))
            .IncentiveWageSynonym = dr.GetString(dr.GetOrdinal("IncentiveWageSynonym"))
            .IncentiveIndicatorDimension = dr.GetString(dr.GetOrdinal("IncentiveIndicatorDimension"))
            .IncentiveIndicatorPrecision = dr.GetByte(dr.GetOrdinal("IncentiveIndicatorPrecision"))
            .UseFixValuedBonus = dr.GetBoolean(dr.GetOrdinal("UseFixValuedBonus"))
            .IncentiveIndicatorFactor = dr.GetDouble(dr.GetOrdinal("IncentiveIndicatorFactor"))
            .BaseValuePrecision = dr.GetByte(dr.GetOrdinal("BaseValuePrecision"))
            .BaseValueSynonym = dr.GetString(dr.GetOrdinal("BaseValueSynonym"))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))
        End With
    End Sub

    Sub New(ByVal dr As SqlDataReader, ByVal JoinedWithCurrency As Boolean)
        With Me
            .IDCostCenter = ADDBNullable.FromObject(Of Integer)(dr.GetValue(dr.GetOrdinal("IDCostCenter")))
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDCostCenterInternal = dr.GetInt32(dr.GetOrdinal("IDCostcenterInternal"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .CostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"))
            .CostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"))
            .CostCenterDescription = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("CostcenterDescription")))
            .IDCurrency = dr.GetInt32(dr.GetOrdinal("IDCurrency"))
            .CurrencyToken = dr.GetString(dr.GetOrdinal("CurrencyToken"))
            .IncentiveIndicatorSynonym = dr.GetString(dr.GetOrdinal("IncentiveIndicatorSynonym"))
            .IncentiveWageSynonym = dr.GetString(dr.GetOrdinal("IncentiveWageSynonym"))
            .IncentiveIndicatorDimension = dr.GetString(dr.GetOrdinal("IncentiveIndicatorDimension"))
            .IncentiveIndicatorPrecision = dr.GetByte(dr.GetOrdinal("IncentiveIndicatorPrecision"))
            .UseFixValuedBonus = dr.GetBoolean(dr.GetOrdinal("UseFixValuedBonus"))
            .IncentiveIndicatorFactor = dr.GetDouble(dr.GetOrdinal("IncentiveIndicatorFactor"))
            .BaseValuePrecision = dr.GetByte(dr.GetOrdinal("BaseValuePrecision"))
            .BaseValueSynonym = dr.GetString(dr.GetOrdinal("BaseValueSynonym"))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))
        End With
    End Sub

    Public Overridable Property IDCostCenter() As Integer
        Get
            Return Me.myIDCostCenter
        End Get
        Set(ByVal value As Integer)
            Me.myIDCostCenter = value
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

    Public Overridable Property IDCostCenterInternal() As Integer
        Get
            Return Me.myIDCostCenterInternal
        End Get
        Set(ByVal value As Integer)
            Me.myIDCostCenterInternal = value
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

    <ADAutoReportColumn("Kostenstellen-Nr.", -2, 1)> _
    Public Overridable Property CostCenterNo() As Integer
        Get
            Return Me.myCostCenterNo
        End Get
        Set(ByVal value As Integer)
            Me.myCostCenterNo = value
        End Set
    End Property

    <ADAutoReportColumn("Kostenstellenname", -1, 2)> _
    Public Overridable Property CostCenterName() As String
        Get
            Return Me.myCostCenterName
        End Get
        Set(ByVal value As String)
            Me.myCostCenterName = value
        End Set
    End Property

    Public Overridable Property CostCenterDescription() As ADDBNullable(Of String)
        Get
            Return Me.myCostCenterDescription
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            Me.myCostCenterDescription = value
        End Set
    End Property

    Public Overridable Property IDCurrency() As Integer
        Get
            Return myIDCurrency
        End Get
        Set(ByVal value As Integer)
            myIDCurrency = value
        End Set
    End Property

    <ADAutoReportColumn("Währung", -2, 4)> _
    Public Overridable Property CurrencyToken() As String
        Get
            Return myCurrencyToken
        End Get
        Set(ByVal value As String)
            myCurrencyToken = value
        End Set
    End Property

    <ADAutoReportColumn("Leistungsbezeichnung", -2, 5)> _
    Public Overridable Property IncentiveIndicatorSynonym() As String
        Get
            Return myIncentiveIndicatorSynonym
        End Get
        Set(ByVal value As String)
            myIncentiveIndicatorSynonym = value
        End Set
    End Property

    <ADAutoReportColumn("Vergütungsbezeichnung", -2, 3)> _
    Public Overridable Property IncentiveWageSynonym() As String
        Get
            Return myIncentiveWageSynonym
        End Get
        Set(ByVal value As String)
            myIncentiveWageSynonym = value
        End Set
    End Property

    <ADAutoReportColumn("Einht.", -2, 6)> _
    Public Overridable Property IncentiveIndicatorDimension() As String
        Get
            Return myIncentiveIndicatorDimension
        End Get
        Set(ByVal value As String)
            myIncentiveIndicatorDimension = value
        End Set
    End Property

    Public Overridable Property IncentiveIndicatorPrecision() As Byte
        Get
            Return myIncentiveIndicatorPrecision
        End Get
        Set(ByVal value As Byte)
            myIncentiveIndicatorPrecision = value
        End Set
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

    Public Overridable Property UseFixValuedBonus() As Boolean
        Get
            Return myUseFixValuedBonus
        End Get
        Set(ByVal value As Boolean)
            myUseFixValuedBonus = value
        End Set
    End Property

    Public Overridable Property IncentiveIndicatorFactor() As Double
        Get
            Return myIncentiveIndicatorFactor
        End Get
        Set(ByVal value As Double)
            myIncentiveIndicatorFactor = value
        End Set
    End Property

    Public Overridable Property BaseValuePrecision() As Byte
        Get
            Return myBaseValuePrecision
        End Get
        Set(ByVal value As Byte)
            myBaseValuePrecision = value
        End Set
    End Property

    Public Overridable Property BaseValueSynonym() As String
        Get
            Return myBaseValueSynonym
        End Get
        Set(ByVal value As String)
            myBaseValueSynonym = value
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
            Return myIDCostCenter
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return CostCenterName
        End Get
    End Property

    Public ReadOnly Property ListItemText() As String
        Get
            Return CostCenterNo.ToString("000000") & ": " & CostCenterName
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return ListItemText
    End Function
End Class

<CLSCompliant(True)> _
Public Class CostcenterInfoItems
    Inherits InfoItems(Of CostcenterInfo)

    Sub New()
        MyBase.new()
    End Sub

    Public Shared Function GetCostCenterInfoItems() As CostcenterInfoItems
        Return SPAccess.GetInstance.CostCenterInfoItems
    End Function
End Class

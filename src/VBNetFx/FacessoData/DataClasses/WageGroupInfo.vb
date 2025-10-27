Imports System.Data.SqlClient
Imports ActiveDev

<CLSCompliant(True)> _
Public Class WageGroupInfo
    Inherits InfoItemBase

    Private myIDWageGroup As Integer
    Private myIDSubsidiary As Integer
    Private myIDWageGroupInternal As Integer
    Private myIsTemplate As ADDBNullable(Of Boolean)
    Private myIDCurrency As Integer
    Private myCurrencyToken As String
    Private myWageGroupToken As String
    Private myComment As String
    Private myIsCurrent As Boolean
    Private myHourlyRate As Decimal
    Private myWasCurrentFrom As Date
    Private myWasCurrentTo As Date

    Sub New()
    End Sub

    Sub New(ByVal dr As SqlDataReader)
        With Me
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDWageGroup = dr.GetInt32(dr.GetOrdinal("IDWageGroup"))
            .IDWageGroupInternal = dr.GetInt32(dr.GetOrdinal("IDWageGroupInternal"))
            .IDCurrency = dr.GetInt32(dr.GetOrdinal("IDCurrency"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .IsTemplate = dr.GetBoolean(dr.GetOrdinal("IsTemplate"))
            .WageGroupToken = dr.GetString(dr.GetOrdinal("WageGroupToken"))
            .Comment = New ADDBNullable(Of String)(dr.GetString(dr.GetOrdinal("Comment")))
            .HourlyRate = dr.GetDecimal(dr.GetOrdinal("HourlyRate"))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))
        End With
    End Sub

    Sub New(ByVal dr As SqlDataReader, ByVal JoinedWithCurrency As Boolean)
        With Me
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDWageGroup = dr.GetInt32(dr.GetOrdinal("IDWageGroup"))
            .IDWageGroupInternal = dr.GetInt32(dr.GetOrdinal("IDWageGroupInternal"))
            .IDCurrency = dr.GetInt32(dr.GetOrdinal("IDCurrency"))
            .CurrencyToken = dr.GetString(dr.GetOrdinal("CurrencyToken"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .IsTemplate = dr.GetBoolean(dr.GetOrdinal("IsTemplate"))
            .WageGroupToken = dr.GetString(dr.GetOrdinal("WageGroupToken"))
            .Comment = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("Comment")))
            .HourlyRate = dr.GetDecimal(dr.GetOrdinal("HourlyRate"))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))
        End With
    End Sub

    Public Overridable Property IDWageGroup() As Integer
        Get
            Return Me.myIDWageGroup
        End Get
        Set(ByVal value As Integer)
            Me.myIDWageGroup = value
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

    Public Overridable Property IDWageGroupInternal() As Integer
        Get
            Return Me.myIDWageGroupInternal
        End Get
        Set(ByVal value As Integer)
            Me.myIDWageGroupInternal = value
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

    <ADAutoReportColumn("Lohngruppennr./Kürzel:", -2, 1)> _
    Public Overridable Property WageGroupToken() As String
        Get
            Return Me.myWageGroupToken
        End Get
        Set(ByVal value As String)
            Me.myWageGroupToken = value
        End Set
    End Property

    Public Overridable Property Comment() As ADDBNullable(Of String)
        Get
            Return Me.myComment
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            Me.myComment = value
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

    Public Overridable Property IsTemplate() As Boolean
        Get
            Return Me.myIsTemplate
        End Get
        Set(ByVal value As Boolean)
            Me.myIsTemplate = value
        End Set
    End Property

    <ADAutoReportColumn("Stundengrundlohn:", -2, 2)> _
    Public Overridable Property HourlyRate() As Decimal
        Get
            Return Me.myHourlyRate
        End Get
        Set(ByVal value As Decimal)
            Me.myHourlyRate = value
        End Set
    End Property

    <ADAutoReportColumn("Währung", -2, 3)> _
    Public Overridable Property CurrencyToken() As String
        Get
            Return myCurrencyToken
        End Get
        Set(ByVal value As String)
            myCurrencyToken = value
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
            Return myIDWageGroup
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return WageGroupToken
        End Get
    End Property

    Public ReadOnly Property ListItemText() As String
        Get
            Return WageGroupToken
        End Get
    End Property
End Class

<CLSCompliant(True)> _
Public Class WageGroupInfoCollection
    Inherits InfoItems(Of WageGroupInfo)
End Class

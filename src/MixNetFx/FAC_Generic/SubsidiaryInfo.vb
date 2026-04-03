Imports ActiveDev
Imports System.Collections.ObjectModel
Imports System.Data.SQLCLient

Public Class SubsidiaryInfo
    Inherits InfoItemBase

    Private myIDSubsidiary As Integer
    Private mySubsidiaryName As String
    Private myStreet As String
    Private myCity As String
    Private myZip As String
    Private myCountryCode As String
    Private myCountry As String
    Private myPrimaryPhone As String

    Private Shared sharedSName As String

    Shared Sub New()
        sharedSName = RegistryHelper.SubsidiarySubstitutionName
    End Sub

    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return mySubsidiaryName
        End Get
    End Property

    Public Overridable Property IDSubsidiary() As Integer
        Get
            Return Me.myIDSubsidiary
        End Get
        Set(ByVal value As Integer)
            Me.myIDSubsidiary = value
        End Set
    End Property

    <ADAutoReportColumn("Name Subsidiarität", -2, 0)> _
    Public Overridable Property SubsidiaryName() As String
        Get
            Return Me.mySubsidiaryName
        End Get
        Set(ByVal value As String)
            Me.mySubsidiaryName = value
        End Set
    End Property

    <ADAutoReportColumn("Straße", -2, 1)> _
    Public Overridable Property Street() As String
        Get
            Return myStreet
        End Get
        Set(ByVal value As String)
            myStreet = value
        End Set
    End Property

    <ADAutoReportColumn("Ort", -2, 3)> _
    Public Overridable Property City() As String
        Get
            Return myCity
        End Get
        Set(ByVal value As String)
            myCity = value
        End Set
    End Property

    <ADAutoReportColumn("PLZ", -2, 2)> _
    Public Overridable Property Zip() As String
        Get
            Return myZip
        End Get
        Set(ByVal value As String)
            myZip = value
        End Set
    End Property

    Public Overridable Property CountryCode() As String
        Get
            Return myCountryCode
        End Get
        Set(ByVal value As String)
            myCountryCode = value
        End Set
    End Property

    <ADAutoReportColumn("Land", -2, 4)> _
    Public Overridable Property Country() As String
        Get
            Return myCountry
        End Get
        Set(ByVal value As String)
            myCountry = value
        End Set
    End Property

    Public Overridable Property PrimaryPhone() As String
        Get
            Return myPrimaryPhone
        End Get
        Set(ByVal value As String)
            myPrimaryPhone = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return Me.SubsidiaryName
    End Function

    Public Overrides ReadOnly Property DataID() As Integer
        Get
            Return IDSubsidiary
        End Get
    End Property
End Class

Public Class SubsidiaryInfoCollection
    Inherits KeyedCollection(Of Integer, SubsidiaryInfo)

    Sub New(ByVal ConnectionString As String)
        MyBase.New()
        Dim locConnection As New SqlConnection(FacessoGeneric.SQLConnectionString)
        Using locConnection
            locConnection.Open()
            Dim locCommand As New SqlCommand("SELECT * FROM [Subsidiaries] ORDER by [SubsidiaryName]", locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            Do While locDR.Read()
                Dim locSi As New SubsidiaryInfo()
                locSi.IDSubsidiary = locDR.GetInt32(locDR.GetOrdinal("IDSubsidiary"))
                locSi.SubsidiaryName = locDR.GetString(locDR.GetOrdinal("SubsidiaryName"))
                locSi.Street = locDR.GetString(locDR.GetOrdinal("Street"))
                locSi.Zip = locDR.GetString(locDR.GetOrdinal("Zip"))
                locSi.City = locDR.GetString(locDR.GetOrdinal("City"))
                locSi.CountryCode = locDR.GetString(locDR.GetOrdinal("CountryCode"))
                locSi.Country = locDR.GetString(locDR.GetOrdinal("Country"))
                locSi.PrimaryPhone = locDR.GetString(locDR.GetOrdinal("PrimaryPhone"))
                Me.Add(locSi)
            Loop
        End Using
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As SubsidiaryInfo) As Integer
        Return item.IDSubsidiary
    End Function
End Class

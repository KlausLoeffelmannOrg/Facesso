Imports ActiveDev
Imports System.Data.SqlClient

<CLSCompliant(True)> _
    Public Class AddressDetailsInfo
    Inherits InfoItemBase

    Protected myIDAddressDetail As Integer
    Protected myIDSubsidiary As Integer
    Protected myPersonnelNo As ADDBNullable(Of Integer)
    Protected myLastName As ADDBNullable(Of String)
    Protected myMiddleName As ADDBNullable(Of String)
    Protected myFirstName As ADDBNullable(Of String)
    Protected myTitle As ADDBNullable(Of String)
    Protected myStreet As ADDBNullable(Of String)
    Protected myZip As ADDBNullable(Of String)
    Protected myCity As ADDBNullable(Of String)
    Protected myCountryCode As ADDBNullable(Of String)
    Protected myCountry As ADDBNullable(Of String)
    Protected myCompanyEmail As ADDBNullable(Of String)
    Protected myPrivateEmail As ADDBNullable(Of String)
    Protected myCompanyPhone As ADDBNullable(Of String)
    Protected myPrivatePhone As ADDBNullable(Of String)
    Protected myCompanyMobile As ADDBNullable(Of String)
    Protected myPrivateMobile As ADDBNullable(Of String)
    Protected myURL As ADDBNullable(Of String)

    Sub New()
    End Sub

    Sub New(ByVal IDAddressDetail As Integer, ByVal IDSubsidiary As Integer, _
            ByVal PersonnelNo As ADDBNullable(Of Integer), ByVal LastName As ADDBNullable(Of String), _
            ByVal MiddleName As ADDBNullable(Of String), ByVal FirstName As ADDBNullable(Of String), _
            ByVal Titel As ADDBNullable(Of String), ByVal Street As ADDBNullable(Of String), _
            ByVal Zip As ADDBNullable(Of String), ByVal City As ADDBNullable(Of String), _
            ByVal CountryCode As ADDBNullable(Of String), ByVal Country As ADDBNullable(Of String), _
            ByVal CompanyTel As ADDBNullable(Of String), ByVal CompanyEmail As ADDBNullable(Of String), ByVal PrivateTel As ADDBNullable(Of String), _
            ByVal CompanyMobile As ADDBNullable(Of String), ByVal PrivateMobile As ADDBNullable(Of String), _
            ByVal PrivateEmail As ADDBNullable(Of String), ByVal URL As ADDBNullable(Of String))
        myIDAddressDetail = IDAddressDetail
        myIDSubsidiary = IDSubsidiary
        myPersonnelNo = PersonnelNo
        myLastName = LastName
        myMiddleName = MiddleName
        myFirstName = FirstName
        myTitle = Titel
        myStreet = Street
        myZip = Zip
        myCity = City
        myCountry = Country
        myCountryCode = CountryCode
        myCompanyPhone = CompanyTel
        myPrivatePhone = PrivateTel
        myCompanyMobile = CompanyMobile
        myCompanyEmail = CompanyEmail
        myPrivateMobile = PrivateMobile
        myPrivateEmail = PrivateEmail
        myURL = URL
    End Sub

    Public Property IDAddressDetail() As Integer
        Get
            Return myIDAddressDetail
        End Get
        Set(ByVal value As Integer)
            myIDAddressDetail = value
        End Set
    End Property

    Public Property IDSubsidiary() As Integer
        Get
            Return myIDSubsidiary
        End Get
        Set(ByVal value As Integer)
            myIDSubsidiary = value
        End Set
    End Property

    Public Property PersonnelNo() As ADDBNullable(Of Integer)
        Get
            Return myPersonnelNo
        End Get
        Set(ByVal value As ADDBNullable(Of Integer))
            myPersonnelNo = value
        End Set
    End Property

    Public Property LastName() As ADDBNullable(Of String)
        Get
            Return myLastName
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myLastName = value
        End Set
    End Property

    Public Property MiddleName() As ADDBNullable(Of String)
        Get
            Return myMiddleName
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myMiddleName = value
        End Set
    End Property

    Public Property FirstName() As ADDBNullable(Of String)
        Get
            Return myFirstName
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myFirstName = value
        End Set
    End Property

    Public Property Titel() As ADDBNullable(Of String)
        Get
            Return myTitle
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myTitle = value
        End Set
    End Property

    Public Property Street() As ADDBNullable(Of String)
        Get
            Return myStreet
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myStreet = value
        End Set
    End Property

    Public Property Zip() As ADDBNullable(Of String)
        Get
            Return myZip
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myZip = value
        End Set
    End Property

    Public Property City() As ADDBNullable(Of String)
        Get
            Return myCity
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myCity = value
        End Set
    End Property

    Public Property CountryCode() As ADDBNullable(Of String)
        Get
            Return myCountryCode
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myCountryCode = value
        End Set
    End Property

    Public Property Country() As ADDBNullable(Of String)
        Get
            Return myCountry
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myCountry = value
        End Set
    End Property

    Public Property CompanyPhone() As ADDBNullable(Of String)
        Get
            Return myCompanyPhone
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myCompanyPhone = value
        End Set
    End Property

    Public Property PrivatePhone() As ADDBNullable(Of String)
        Get
            Return myPrivatePhone
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myPrivatePhone = value
        End Set
    End Property

    Public Property CompanyMobile() As ADDBNullable(Of String)
        Get
            Return myCompanyMobile
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myCompanyMobile = value
        End Set
    End Property

    Public Property CompanyEmail() As ADDBNullable(Of String)
        Get
            Return myCompanyEmail
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myCompanyEmail = value
        End Set
    End Property

    Public Property PrivateMobile() As ADDBNullable(Of String)
        Get
            Return myPrivateMobile
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myPrivateMobile = value
        End Set
    End Property

    Public Property PrivateEmail() As ADDBNullable(Of String)
        Get
            Return myPrivateEmail
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myPrivateEmail = value
        End Set
    End Property

    Public Property URL() As ADDBNullable(Of String)
        Get
            Return myURL
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            myURL = value
        End Set
    End Property

    Public Overrides ReadOnly Property DataID() As Integer
        Get
            Return myIDAddressDetail
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return LastName
        End Get
    End Property
End Class

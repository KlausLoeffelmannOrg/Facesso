Imports ActiveDev
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Data.SQLClient

<CLSCompliant(True)> _
Public NotInheritable Class UserInfo
    Inherits InfoItemBase

    Private myIDUser As Integer
    Private myIDSubsidiary As Integer
    Private myIDUserInternal As Integer
    Private myIDCostCenter As Integer
    Private myFirstName As String
    Private myLastname As String
    Private myIDAddressDetails As ADDBNullable(Of Integer)
    Private myUsername As String
    Private myPassword As Byte()
    Private myClearanceLevel As ClearanceLevel
    Private myHasWorkstationAccess As Boolean
    Private myHasInternetAccess As Boolean
    Private myIsActivated As Boolean
    Private myIsCurrent As Boolean
    Private myDoesExpire As Boolean
    Private myExpireDate As Date
    Private myWasCurrentFrom As Date
    Private myWasCurrentTo As Date
    Private myComment As ADDBNullable(Of String)
    Private myIsSystemAccount As Boolean

    Private myAuthenticated As Boolean
    Private myLoggedIn As Date
    Private myPermissionInfo As FacessoRolePermissionInfo
    Private mySubsidiaryInfo As SubsidiaryInfo
    Private myLoggedInFailedReason As ADDBNullable(Of String)

    Public Sub New()
    End Sub

    ''' <summary>
    ''' Instanziert ein neues UserInfo-Objekt und führt die Legitimation durch.
    ''' </summary>
    ''' <param name="IDSubsidiary">Datensatz-ID der Subsidiary, für die der Benutzer gilt.</param>
    ''' <param name="Username">Der Benutzername.</param>
    ''' <param name="Password">Das Kennwort.</param>
    ''' <param name="ConnectionString">Die Verbindungszeichenfolge zur Datenbank mit den Benutzerdaten.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal IDSubsidiary As Integer, ByVal Username As String, ByVal Password As String, ByVal ConnectionString As String)
        Dim locConnection As New SqlConnection(ConnectionString)

        Using locConnection
            locConnection.Open()
            Dim locCommand As New SqlCommand("SELECT * FROM [Users] WHERE [IDSubsidiary]=" & IDSubsidiary.ToString & _
                                             " AND [Username] = '" & Username & "'" & " AND [IsCurrent]=1", locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If Not locDR.Read() Then
                myAuthenticated = False
                myLoggedInFailedReason = My.Resources.UserInfo_UserNotExisting
                Return
            Else
                With Me
                    .IDUser = locDR.GetInt32(locDR.GetOrdinal("IDUser"))
                    .IDSubsidiary = IDSubsidiary
                    .IDUserInternal = locDR.GetInt32(locDR.GetOrdinal("IDUserInternal"))
                    .IDCostCenter = ADDBNullable.FromObject(Of Integer)(locDR.GetValue(locDR.GetOrdinal("IDCostCenter")))
                    .FirstName = locDR.GetString(locDR.GetOrdinal("FirstName"))
                    .LastName = locDR.GetString(locDR.GetOrdinal("LastName"))
                    .IDAddressDetails = ADDBNullable.FromObject(Of Integer)(locDR.GetValue(locDR.GetOrdinal("IDAddressDetails")))
                    .Username = locDR.GetString(locDR.GetOrdinal("Username"))
                    .Password = CType(locDR.GetValue(locDR.GetOrdinal("Password")), Byte())
                    .ClearanceLevel = CType(locDR.GetInt64(locDR.GetOrdinal("ClearanceLevel")), ClearanceLevel)
                    .HasWorkstationAccess = locDR.GetBoolean(locDR.GetOrdinal("HasWorkstationAccess"))
                    .HasInternetAccess = locDR.GetBoolean(locDR.GetOrdinal("HasInternetAccess"))
                    .IsActivated = locDR.GetBoolean(locDR.GetOrdinal("IsActivated"))
                    .DoesExpire = locDR.GetBoolean(locDR.GetOrdinal("DoesExpire"))
                    .ExpireDate = locDR.GetDateTime(locDR.GetOrdinal("ExpireDate"))
                    .WasCurrentFrom = locDR.GetDateTime(locDR.GetOrdinal("WasCurrentFrom"))
                    .WasCurrentTo = locDR.GetDateTime(locDR.GetOrdinal("WasCurrentTo"))
                    .Comment = ADDBNullable.FromObject(Of String)(locDR.GetValue(locDR.GetOrdinal("Comment")))
                End With
            End If

            Dim locDBPassword As New ADCryptedPassword(Me.Password)
            If locDBPassword = Password Then
                myAuthenticated = True
            Else
                myAuthenticated = True
                myLoggedInFailedReason = My.Resources.UserInfo_WrongPassword
            End If
        End Using
    End Sub

    Public Property IDUser() As Integer
        Get
            Return Me.myIDUser
        End Get
        Set(ByVal value As Integer)
            Me.myIDUser = value
        End Set
    End Property

    Public Property IDSubsidiary() As Integer
        Get
            Return Me.myIDSubsidiary
        End Get
        Set(ByVal value As Integer)
            Me.myIDSubsidiary = value
        End Set
    End Property

    Public Property IDUserInternal() As Integer
        Get
            Return Me.myIDUserInternal
        End Get
        Set(ByVal value As Integer)
            Me.myIDUserInternal = value
        End Set
    End Property

    Public Property IDCostCenter() As Integer
        Get
            Return Me.myIDCostCenter
        End Get
        Set(ByVal value As Integer)
            Me.myIDCostCenter = value
        End Set
    End Property

    <ADAutoReportColumn("Vorname", -2, 2)> _
    Public Property FirstName() As String
        Get
            Return Me.myFirstName
        End Get
        Set(ByVal value As String)
            Me.myFirstName = value
        End Set
    End Property

    <ADAutoReportColumn("Nachname", -2, 3)> _
    Public Property LastName() As String
        Get
            Return Me.myLastname
        End Get
        Set(ByVal value As String)
            Me.myLastname = value
        End Set
    End Property

    Public Property IDAddressDetails() As ADDBNullable(Of Integer)
        Get
            Return Me.myIDAddressDetails
        End Get
        Set(ByVal value As ADDBNullable(Of Integer))
            Me.myIDAddressDetails = value
        End Set
    End Property

    <ADAutoReportColumn("Benutzername", -2, 1)> _
    Public Property Username() As String
        Get
            Return Me.myUsername
        End Get
        Set(ByVal value As String)
            Me.myUsername = value
        End Set
    End Property

    Public Property Password() As Byte()
        Get
            Return myPassword
        End Get
        Set(ByVal value As Byte())
            myPassword = value
        End Set
    End Property

    Public Property ClearanceLevel() As ClearanceLevel
        Get
            Return Me.myClearanceLevel
        End Get
        Set(ByVal value As ClearanceLevel)
            Me.myClearanceLevel = value
        End Set
    End Property

    Public Property HasWorkstationAccess() As Boolean
        Get
            Return Me.myHasWorkstationAccess
        End Get
        Set(ByVal value As Boolean)
            Me.myHasWorkstationAccess = value
        End Set
    End Property

    Public Property HasInternetAccess() As Boolean
        Get
            Return Me.myHasInternetAccess
        End Get
        Set(ByVal value As Boolean)
            Me.myHasInternetAccess = value
        End Set
    End Property

    Public Property IsActivated() As Boolean
        Get
            Return myIsActivated
        End Get
        Set(ByVal value As Boolean)
            myIsActivated = True
        End Set
    End Property

    Public Property IsCurrent() As Boolean
        Get
            Return myIsCurrent
        End Get
        Set(ByVal value As Boolean)
            myIsCurrent = True
        End Set
    End Property

    Public Property DoesExpire() As Boolean
        Get
            Return Me.myDoesExpire
        End Get
        Set(ByVal value As Boolean)
            Me.myDoesExpire = value
        End Set
    End Property

    Public Property ExpireDate() As Date
        Get
            Return Me.myExpireDate
        End Get
        Set(ByVal value As Date)
            Me.myExpireDate = value
        End Set
    End Property

    Public Property IsSystemAccount() As Boolean
        Get
            Return myIsSystemAccount
        End Get
        Set(ByVal value As Boolean)
            myIsSystemAccount = value
        End Set
    End Property

    Public Property WasCurrentFrom() As Date
        Get
            Return Me.myWasCurrentFrom
        End Get
        Set(ByVal value As Date)
            Me.myWasCurrentFrom = value
        End Set
    End Property

    Public Property WasCurrentTo() As Date
        Get
            Return Me.myWasCurrentTo
        End Get
        Set(ByVal value As Date)
            Me.myWasCurrentTo = value
        End Set
    End Property

    Public Property Comment() As ADDBNullable(Of String)
        Get
            Return Me.myComment
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            Me.myComment = value
        End Set
    End Property

    ''' <summary>
    ''' Ermitteln die Rollen-Berechtigungs-Info für den entsprechenden Benutzer
    ''' </summary>
    ''' <value>FacessoRolePermissionInfo, die die Berechtigungs-Info enthält.</value>
    ''' <remarks></remarks>
    Public ReadOnly Property RolePermissionInfo() As FacessoRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(myClearanceLevel)
        End Get
    End Property

    Public ReadOnly Property SubsidiaryInfo() As SubsidiaryInfo
        Get
            Return FacessoGeneric.Subsidiaries(IDSubsidiary)
        End Get
    End Property

    Public Property LoggedInFailedReason() As ADDBNullable(Of String)
        Get
            Return Me.myLoggedInFailedReason
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            Me.myLoggedInFailedReason = value
        End Set
    End Property

    ''' <summary>
    ''' Der Zeitpunkt des Logins.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public ReadOnly Property LoggedIn() As Date
        Get
            Return Me.myLoggedIn
        End Get
    End Property

    Public ReadOnly Property Authenticated() As Boolean
        Get
            Return Me.myAuthenticated
        End Get
    End Property

    Public Overrides ReadOnly Property DataID() As Integer
        Get
            Return IDUser
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return Username & " (" & LastName & ", " & FirstName & ")"
        End Get
    End Property
End Class

<CLSCompliant(True)> _
Public Class UserInfoCollection
    Inherits InfoItems(Of UserInfo)
End Class

<Serializable()> _
Public Class LoginHistory
    Inherits System.Collections.ObjectModel.Collection(Of String)

    Private myLastLoginName As String
    Private myLastLoginIDSubsidiary As Integer
    Private myLastLoginDate As Date

    Public Property LastLoginName() As String
        Get
            Return myLastLoginName
        End Get
        Set(ByVal value As String)
            myLastLoginName = value
        End Set
    End Property

    Public Property LastLoginIDSubsidiary() As Integer
        Get
            Return myLastLoginIDSubsidiary
        End Get
        Set(ByVal value As Integer)
            myLastLoginIDSubsidiary = value
        End Set
    End Property

    Public Property LastLoginDate() As Date
        Get
            Return myLastLoginDate
        End Get
        Set(ByVal value As Date)
            myLastLoginDate = myLastLoginDate
        End Set
    End Property

    Shadows Sub Add(ByVal Item As String)
        'Determine, if String already exist
        If Me.Contains(Item) Then
            Exit Sub
        End If
        MyBase.Add(Item)
    End Sub
End Class

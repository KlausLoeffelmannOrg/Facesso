Imports System.Drawing
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Collections.ObjectModel
Imports System.Data.EntityClient

<CLSCompliant(False)> _
Public Module FacessoGeneric

    Private Const ENTITY_CONNSTRING_METADATA As String = "res://*/FacessoModel.csdl|res://*/FacessoModel.ssdl|res://*/FacessoModel.msl"

    Private myFacessoLicense As FacessoLicenseManager
    Private mySqlConnectionString As String
    Private myEntityConnectionString As String
    Private myLoginInfo As UserInfo
    Private mySubsidiaries As SubsidiaryInfoCollection
    Private mySettings As FacessoApplicationSettings
    Private myFacessoGlobalSettings As XmlFacessoApplicationSettings
    Private myFacessoUserSettings As XmlFacessoApplicationSettings

    Sub New()
    End Sub

    Sub InitializeComponent()
        mySqlConnectionString = RegistryHelper.ConnectionString
        RebuildSubsidiaries()
        mySettings = New FacessoApplicationSettings()
        myFacessoGlobalSettings = XmlFacessoApplicationSettings.FromFacessoDatabase(0, 0)
    End Sub

    Public Sub RebuildSubsidiaries()
        mySubsidiaries = New SubsidiaryInfoCollection(mySqlConnectionString)
    End Sub

    Public Sub SaveGlobalSettings()
        SaveXMLSettingsToDB(FacessoGlobalSettings)
    End Sub

    Public Sub SaveAllSettings()
        SaveGlobalSettings()
        SaveUserSettings()
    End Sub

    Public Sub SaveUserSettings()
        SaveXMLSettingsToDB(FacessoUserSettings)
    End Sub

    Private Sub SaveXMLSettingsToDB(ByVal Settings As XmlFacessoApplicationSettings)
        Dim locConnection As New SqlConnection(FacessoGeneric.SQLConnectionString)
        locConnection.Open()
        Using locConnection
            Dim locCmd As New SqlCommand()
            locCmd.Connection = locConnection
            locCmd.CommandType = CommandType.StoredProcedure

            locCmd.CommandText = "ApplicationSettings_Set"
            With locCmd.Parameters
                .Add("@IDApplicationSettings", SqlDbType.Int).Value = Settings.IDApplicationSettings
                If Settings.IsGlobal = True Then
                    .Add("@IDSubsidiary", SqlDbType.Int).Value = 0
                    .Add("@IDUser", SqlDbType.Int).Value = 0
                Else
                    .Add("@IDSubsidiary", SqlDbType.Int).Value = LoginInfo.IDSubsidiary
                    .Add("@IDUser", SqlDbType.Int).Value = LoginInfo.IDUser
                End If
                .Add("@IsGlobal", SqlDbType.Bit).Value = Settings.IsGlobal
                .Add("@Settings", SqlDbType.Xml).Value = Settings.ToXml(GetType(XmlFacessoApplicationSettings))
                .Add("@IDAppSettingsNew", SqlDbType.Int)
                .Item("@IDAppSettingsNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()
            Settings.IDApplicationSettings = CInt(locCmd.Parameters("@IDAppSettingsNew").Value)
        End Using
    End Sub

    ''' <summary>
    ''' Überprüft, ob diese Kopie von Facesso jemals schon den Installationspozess durchlaufen hat.
    ''' </summary>
    ''' <returns>True, wenn es bereits GUID-Einträge für diese Version in der Registrierungsdatenbank 
    ''' gibt, anderenfalls false.</returns>
    ''' <remarks>Der Unterschied zu <see cref="RegistryHelper.IsRegistered">RegistryHelper.IsRegistered</see> besteht darin, dass
    ''' diese Kopie der Software zwar schon den Einrichtungsprozess durchlaufen haben kann, aber 
    ''' dennoch eine ungültige Seriennummer trägt und damit als nicht registriert gilt. Das würde 
    ''' dann einen erneuten Registrierungs (mit entsprechenden Hinweis darauf) erforderlich 
    ''' machen.</remarks>
    Public Function IsSetup() As Boolean
        Dim locGuid As String = RegistryHelper.ProgramGUID
        If locGuid Is Nothing Then
            Return False
        End If
        Return RegistryHelper.IsRegistered
    End Function

    Public Function IsDatabaseSetup() As Boolean
        If mySubsidiaries.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub SetupLicenseInfoAndLogin()
        myFacessoLicense = New FacessoLicenseManager(New Guid(RegistryHelper.ProgramGUID), _
                                           RegistryHelper.InstallationDate, _
                                           RegistryHelper.LastRunDate, _
                                           RegistryHelper.LastRegisteredDate, _
                                           RegistryHelper.SerialNumber)
        If myLoginInfo Is Nothing Then
            Login()
        End If
    End Sub

    Public ReadOnly Property OpenCurrentToDate() As Date
        Get
            Return New Date(2199, 12, 31)
        End Get
    End Property

    ''' <summary>
    ''' Liefert die herunterzurechnende Schwellzeit für die 1. Schicht bei der automatischen Datenübername
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FirstShiftThresholdInMin() As Integer
        Get
            Return RegistryHelper.FirstShiftThresholdInMin
        End Get
        Set(ByVal value As Integer)
            RegistryHelper.FirstShiftThresholdInMin = value
        End Set
    End Property

    ''' <summary>
    ''' Liefert eine Fallback-Startzeit für nicht definierte Schichtabschnitte bei der automatischen Datenübernahme
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FallbackStartTime() As Date
        Get
            Return RegistryHelper.FallbackStartTime
        End Get
        Set(ByVal value As Date)
            RegistryHelper.FallbackStartTime = value
        End Set
    End Property

    ''' <summary>
    ''' Liefert eine Fallback-Endzeit für nicht definierte Schichtabschnitte bei der automatischen Datenübernahme
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FallbackEndTime() As Date
        Get
            Return RegistryHelper.FallbackEndTime
        End Get
        Set(ByVal value As Date)
            RegistryHelper.FallbackEndTime = value
        End Set
    End Property

    Public ReadOnly Property FacessoLicenseInfo() As FacessoLicenseManager
        Get
            If myFacessoLicense Is Nothing Then
                SetupLicenseInfoAndLogin()
            End If
            Return myFacessoLicense
        End Get
    End Property

    Public ReadOnly Property SQLConnectionString() As String
        Get
            Return mySqlConnectionString
        End Get
    End Property

    Public ReadOnly Property SqlEntityConnectionString As String
        Get
            Dim entityConn As New EntityConnectionStringBuilder()
            entityConn.ProviderConnectionString = SQLConnectionString
            entityConn.Metadata = ENTITY_CONNSTRING_METADATA
            entityConn.Provider = "System.Data.SqlClient"
            Return entityConn.ConnectionString
        End Get
    End Property

    Public ReadOnly Property SerialNumber() As String
        Get
            Return RegistryHelper.SerialNumber
        End Get
    End Property

    Public Property InstallationFolder() As String
        Get
            Return RegistryHelper.InstallationFolder
        End Get
        Set(ByVal value As String)
            RegistryHelper.InstallationFolder = value
        End Set
    End Property

    Public Property UpdateUrl() As String
        Get
            Return RegistryHelper.UpdateUrl
        End Get
        Set(ByVal value As String)
            RegistryHelper.UpdateUrl = value
        End Set
    End Property

    Public Property UpdateFolder() As String
        Get
            Return RegistryHelper.UpdateFolder
        End Get
        Set(ByVal value As String)
            RegistryHelper.UpdateFolder = value
        End Set
    End Property

    Public Property SharedFolder() As String
        Get
            Return RegistryHelper.SharedFolder
        End Get
        Set(ByVal value As String)
            RegistryHelper.SharedFolder = value
        End Set
    End Property

    Public ReadOnly Property Subsidiaries() As SubsidiaryInfoCollection
        Get
            Return mySubsidiaries
        End Get
    End Property

    Public Property SubsidiarySynonym() As String
        Get
            Return FacessoGlobalSettings.Settings.GetItem("SubsidiarySynonym", My.Resources.SubsidiaryDefaultSynonym).ToString
        End Get
        Set(ByVal value As String)
            FacessoGlobalSettings.Settings.SetItem("SubsidiarySynonym", value)
        End Set
    End Property

    ''' <summary>
    ''' Stellt das Login-Info-Objekt für den aktuell angemeldeten Benutzer zur Verfügung.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LoginInfo() As UserInfo
        Get
            Return myLoginInfo
        End Get
    End Property

    Public ReadOnly Property AppSettings() As FacessoApplicationSettings
        Get
            Return mySettings
        End Get
    End Property

    Public Property FacessoUserSettings() As XmlFacessoApplicationSettings
        Get
            Return myFacessoUserSettings
        End Get
        Set(ByVal value As XmlFacessoApplicationSettings)
            myFacessoUserSettings = value
        End Set
    End Property

    Public Property FacessoGlobalSettings() As XmlFacessoApplicationSettings
        Get
            Return myFacessoGlobalSettings
        End Get
        Set(ByVal value As XmlFacessoApplicationSettings)
            myFacessoGlobalSettings = value
        End Set
    End Property

    Public ReadOnly Property ConsiderHistoryMaintenance() As Boolean
        Get
            'Todo: Datenbank verwaltung hieran anpassen,
            'wenn die Enterprise in die Mache kommt!
            'Return FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion = FacessoVersion.FacessoEnterprise
            'Solange: Keine Versionspflege der Datensätze betreiben
            Return False
        End Get
    End Property

    Public Function PermitFunctionForVersion(ByVal VersionPI As IVersionPermissionInfo) As Boolean
        Dim locVpi As FacessoVersionPermissionInfo
        locVpi = DirectCast(VersionPI, FacessoVersionPermissionInfo)
        If locVpi.FacessoVersion <= FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function PermitFunctionForRole(ByVal RolePI As IRolePermissionInfo) As Boolean
        Dim locRpi As FacessoRolePermissionInfo
        locRpi = DirectCast(RolePI, FacessoRolePermissionInfo)
        If (FacessoGeneric.LoginInfo.ClearanceLevel And locRpi.ClearanceLevel) = locRpi.ClearanceLevel Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Login()
        Dim locLoginHistory As LoginHistory = AppSettings.LoginHistory
        If locLoginHistory Is Nothing Then
            locLoginHistory = New LoginHistory()
            locLoginHistory.Add("Administrator")
            locLoginHistory.LastLoginName = "Administrator"
            FacessoGeneric.FacessoGlobalSettings.Settings.SetItem("LoginHistory", locLoginHistory)
            AppSettings.LoginHistory = locLoginHistory
        Else
            locLoginHistory.LastLoginName = AppSettings.LastLoginName
        End If
        Dim locLoginForm As New frmLogin
        Dim locLoginInfo As UserInfo = locLoginForm.Login(Subsidiaries, AppSettings.LastSubsidiaryID, locLoginHistory)
        If locLoginInfo Is Nothing Then
            Dim up As New FacessoLoginException("Login-Abbruch führte zu Ausnahme (kein kritischer Fehler).", Nothing)
            Throw up
        End If
        myLoginInfo = locLoginInfo
        FacessoUserSettings = XmlFacessoApplicationSettings.FromFacessoDatabase(LoginInfo.IDUser, LoginInfo.IDSubsidiary)
        AppSettings.LoginHistory.LastLoginDate = DateTime.Now()
        AppSettings.LoginHistory.Add(myLoginInfo.Username)
        AppSettings.LastLoginName = myLoginInfo.Username
        AppSettings.LastSubsidiaryID = myLoginInfo.IDSubsidiary
    End Sub

#Region "Ressourcen-Werte"
    ''' <summary>
    ''' Liefert eine Pipe-getrennte Liste der lokalisierten Rollennamen zurück.
    ''' </summary>
    ''' <remarks>Die Reihenfolge der Texte muss der ClearanceLevel-Enum entsprechen</remarks>
    Public ReadOnly Property RoleList() As String
        Get
            Return My.Resources.RolesList
        End Get
    End Property
#End Region

End Module

<Serializable(), XmlInclude(GetType(MonthRangePickerResult)), XmlInclude(GetType(LoginHistory)), XmlInclude(GetType(TimeSettingDetail)), _
 XmlInclude(GetType(TimeSettingDetails)), XmlInclude(GetType(LayoutAndNumberformats)), _
 XmlInclude(GetType(FacessoShellWindowsControl)), XmlInclude(GetType(FacessoGeneralOptions))> _
Public Class XmlFacessoApplicationSettings
    Inherits ADXmlSettings

    Private myIDApplicationSettings As Integer
    Private myIsGlobal As Boolean
    Private myIDUser As Integer

    Public Property IDApplicationSettings() As Integer
        Get
            Return myIDApplicationSettings
        End Get
        Set(ByVal value As Integer)
            myIDApplicationSettings = value
        End Set
    End Property

    Public Property IsGlobal() As Boolean
        Get
            Return myIsGlobal
        End Get
        Set(ByVal value As Boolean)
            myIsGlobal = value
        End Set
    End Property

    Public Property IDUser() As Integer
        Get
            Return myIDUser
        End Get
        Set(ByVal value As Integer)
            myIDUser = value
        End Set
    End Property

    Public Shared Function FromXML(ByVal XmlString As String, ByVal XMLType As Type) As XmlFacessoApplicationSettings
        Dim locXml As New XmlSerializer(XMLType)
        Dim locSr As New StringReader(XmlString)
        Return DirectCast(locXml.Deserialize(locSr), XmlFacessoApplicationSettings)
    End Function

    Public Shared Function FromFacessoDatabase(ByVal IDUser As Integer, ByVal IDSubsidiary As Integer) As XmlFacessoApplicationSettings
        Dim locSettings As XmlFacessoApplicationSettings
        Dim locConnection As New SqlConnection(FacessoGeneric.SQLConnectionString)
        locConnection.Open()
        Using locConnection
            Dim locCmd As New SqlCommand()
            locCmd.Connection = locConnection
            locCmd.CommandType = CommandType.StoredProcedure

            locCmd.CommandText = "ApplicationSettings_Get"
            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IsGlobal", SqlDbType.Bit).Value = (IDUser = 0)
                .Add("@IDUser", SqlDbType.Int).Value = IDUser
                .Add("@Settings", SqlDbType.Xml, -1)
                .Item("@Settings").Direction = ParameterDirection.Output
                .Add("@IDApplicationSettings", SqlDbType.Int)
                .Item("@IDApplicationSettings").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()
            If locCmd.Parameters("@IDApplicationSettings").Value IsNot DBNull.Value Then
                Dim locXML As String = locCmd.Parameters("@Settings").Value.ToString
                locSettings = FromXML(locXML, GetType(XmlFacessoApplicationSettings))
                locSettings.IDApplicationSettings = CInt(locCmd.Parameters("@IDApplicationSettings").Value)
                Return locSettings
            Else
                locSettings = New XmlFacessoApplicationSettings()
                locSettings.IsGlobal = (IDUser = 0)
                Return locSettings
            End If
        End Using
    End Function
End Class

<Serializable(), XmlRoot("ActiveDev.ADXmlSettings"), XmlInclude(GetType(Point)), XmlInclude(GetType(Size))> _
Public Class ADXmlSettings

    Private mySettings As ADXmlSettingsValues

    Sub New()
        mySettings = New ADXmlSettingsValues()
    End Sub

    Public Property Settings() As ADXmlSettingsValues
        Get
            Return mySettings
        End Get
        Set(ByVal value As ADXmlSettingsValues)
            mySettings = value
        End Set
    End Property

    Public Function ToXml(ByVal XMLType As Type) As String
        Dim locXml As New XmlSerializer(XMLType)
        Dim locSw As New StringWriter()
        locXml.Serialize(locSw, Me)
        Return locSw.ToString
    End Function
End Class

Public Class ADXmlSettingsValue

    Private myUniqueKey As String
    Private myValue As Object

    Sub New()
    End Sub

    Sub New(ByVal UniqueKey As String, ByVal Value As Object)
        Me.myUniqueKey = UniqueKey
        Me.myValue = Value
    End Sub

    Public Property UniqueKey() As String
        Get
            Return myUniqueKey
        End Get
        Set(ByVal value As String)
            myUniqueKey = value
        End Set
    End Property

    Public Property Value() As Object
        Get
            Return myValue
        End Get
        Set(ByVal value As Object)
            myValue = value
        End Set
    End Property
End Class

<Serializable()> _
Public Class ADXmlSettingsValues
    Inherits KeyedCollection(Of String, ADXmlSettingsValue)

    Public Function GetItem(ByVal Key As String) As Object
        If Me.Contains(Key) Then
            Return Me(Key).Value
        End If
        Return Nothing
    End Function

    Public Function GetItem(ByVal Index As Integer) As Object
        Return Me(Index).Value
    End Function

    Public Function GetItem(ByVal Key As String, ByVal DefaultValue As Object) As Object
        If Me.Contains(Key) Then
            Return Me(Key).Value
        End If
        SetItem(Key, DefaultValue)
        Return DefaultValue
    End Function

    Public Overloads Sub SetItem(ByVal key As String, ByVal Value As Object)
        If Me.Contains(key) Then
            Me.Item(key).Value = Value
            Return
        End If
        Me.Add(New ADXmlSettingsValue(key, Value))
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As ADXmlSettingsValue) As String
        Return item.UniqueKey
    End Function
End Class

<Serializable()> _
Public Class FacessoShellWindowsControl

    Private myOnlyShowActiveEmployees As Boolean
    Private myOnlyShowActiveWorkGroups As Boolean
    Private myShowEmployees As Boolean
    Private myShowWorkGroupInfo As Boolean
    Private myEmpWorkgroupSplitterDistance As Integer
    Private myWorkgroupSplitterDistance As Integer

    Public Event WindowsControlSettingsChange(ByVal sender As Object, ByVal e As EventArgs)

    Sub New()
        MyBase.new()
    End Sub

    Sub New(ByVal OnlyShowActiveEmployees As Boolean, ByVal onlyShowActiveWorkGroups As Boolean, _
            ByVal ShowEmployees As Boolean, ByVal ShowWorkGroups As Boolean, ByVal ShowWorkGroupInfo As Boolean)
        MyBase.New()
        myOnlyShowActiveEmployees = OnlyShowActiveEmployees
        myOnlyShowActiveWorkGroups = onlyShowActiveWorkGroups
        myShowEmployees = ShowEmployees
        myShowWorkGroupInfo = ShowWorkGroupInfo
    End Sub

    Protected Sub OnSettingsChange()
        RaiseEvent WindowsControlSettingsChange(Me, EventArgs.Empty)
    End Sub

    Public Property OnlyShowActiveEmployees() As Boolean
        Get
            Return myOnlyShowActiveEmployees
        End Get
        Set(ByVal value As Boolean)
            If value <> myOnlyShowActiveEmployees Then
                myOnlyShowActiveEmployees = value
                OnSettingsChange()
                Return
            End If
        End Set
    End Property

    Public Property OnlyShowActiveWorkGroups() As Boolean
        Get
            Return myOnlyShowActiveWorkGroups
        End Get
        Set(ByVal value As Boolean)
            If value <> myOnlyShowActiveWorkGroups Then
                myOnlyShowActiveWorkGroups = value
                OnSettingsChange()
                Return
            End If
        End Set
    End Property

    Public Property ShowEmployees() As Boolean
        Get
            Return myShowEmployees
        End Get
        Set(ByVal value As Boolean)
            If value <> myShowEmployees Then
                myShowEmployees = value
                OnSettingsChange()
                Return
            End If
        End Set
    End Property

    Public Property ShowWorkGroupInfo() As Boolean
        Get
            Return myShowWorkGroupInfo
        End Get
        Set(ByVal value As Boolean)
            If value <> myShowWorkGroupInfo Then
                myShowWorkGroupInfo = value
                OnSettingsChange()
                Return
            End If
        End Set
    End Property

    Public Property EmpWorkgroupSplitterDistance() As Integer
        Get
            Return myEmpWorkgroupSplitterDistance
        End Get
        Set(ByVal value As Integer)
            myEmpWorkgroupSplitterDistance = value
        End Set
    End Property

    Public Property WorkgroupSplitterDistance() As Integer
        Get
            Return myWorkgroupSplitterDistance
        End Get
        Set(ByVal value As Integer)
            myWorkgroupSplitterDistance = value
        End Set
    End Property

    Public Function EmployeeStateDisplayString() As String
        If OnlyShowActiveEmployees Then
            Return "Aktive bzw. beteiligte Mitarbeiter"
        Else
            Return "Alle bzw. beteiligte Mitarbeiter"
        End If
    End Function

    Public Function WorkGroupStateDisplayString() As String
        If OnlyShowActiveEmployees Then
            Return "Aktive Produktiv-Sites"
        Else
            Return "Alle Produktiv-Sites"
        End If
    End Function
End Class

Imports System.Globalization
Imports System.Windows.Forms
Imports Microsoft.Win32

Public Module RegistryHelper

    Friend Const VERSION_GUID As String = "{face2470-bae0-20cd-b579-08002b30bfeb}"
    Friend Const CLASS_VERSION_GUID As String = "{face0100-bae0-20cd-b579-08002b30bfeb}"

    Friend Const EARLIEST_DEFAULT_DATE As Date = #1/1/2011#

    Friend Function IsRegistered() As Boolean
        Dim locIsRegistered As Boolean = CBool(Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes",
                                    "RegObject", False))
        If locIsRegistered Then
            If CBool(Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                                        "ForceReapplication", False)) Or
                                CBool(Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                                        "ForceReapplication", False)) Then
                Try
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                            "ForceReapplication", False)
                    Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                            "ForceReapplication", False)
                Catch ex As Exception

                End Try
                Return False
            End If
        End If
        Return locIsRegistered
    End Function

    Friend Sub Register(ByVal DoUnDo As Boolean)
        Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes",
                                    "RegObject", DoUnDo)
        Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                            "Registered", DoUnDo)
        Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                "ForceReapplication", False)
        Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso\Classes",
                                    "RegObject", DoUnDo)
        Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                            "Registered", DoUnDo)
        Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                "ForceReapplication", False)
    End Sub

    Friend Property InstallationDate() As Date
        Get
            'Vorkommateil ermitteln
            Dim locObject As Object = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                                        "SUD_Intel_Private", Nothing)
            If locObject Is Nothing Then
                Return EARLIEST_DEFAULT_DATE
            End If

            Dim returnValue As Date

            Try
                returnValue = Date.FromOADate(Double.Parse(locObject.ToString))
            Catch ex As Exception
                returnValue = Date.FromOADate(Double.Parse(locObject.ToString, CultureInfo.InvariantCulture))
            End Try

            Return returnValue
        End Get
        Set(ByVal value As Date)
            If value < EARLIEST_DEFAULT_DATE Then
                value = EARLIEST_DEFAULT_DATE
            End If

            If InstallationDate > EARLIEST_DEFAULT_DATE Then
                Return
            End If
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                                        "SUD_Intel_Private", value.ToOADate.ToString)
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                            "InstallationDate", value.ToString)
        End Set
    End Property

    Friend Property FirstShiftThresholdInMin() As Integer
        Get
            Return TryGetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "FirstShiftThresholdInMin", 0)
        End Get
        Set(ByVal value As Integer)
            TrySetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "FirstShiftThresholdInMin", value)
        End Set
    End Property

    Friend Property FallbackStartTime() As Date
        Get
            Return TryGetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "FallbackStartTime", #1/1/2003 4:00:00 AM#)
        End Get
        Set(ByVal value As Date)
            TrySetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "FallbackStartTime", value)
        End Set
    End Property

    Friend Property FallbackEndTime() As Date
        Get
            Return TryGetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "FallbackEndTime", #1/1/2003 2:00:00 PM#)
        End Get
        Set(ByVal value As Date)
            TrySetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "FallbackEndTime", value)
        End Set
    End Property

    Friend Property LastRunDate() As Date
        Get
            'Vorkommateil ermitteln
            Dim locObject As Object = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                                        "DRL_Intel_Private", Nothing)
            If locObject Is Nothing Then
                Return EARLIEST_DEFAULT_DATE
            End If

            Dim returnValue As Date

            Try
                returnValue = Date.FromOADate(Double.Parse(locObject.ToString))
            Catch ex As Exception
                returnValue = Date.FromOADate(Double.Parse(locObject.ToString, CultureInfo.InvariantCulture))
            End Try

            Return returnValue
        End Get
        Set(ByVal value As Date)
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                            "LastRunDate", value.ToString)
            Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                "LastRunDate", value.ToString)


            If value < EARLIEST_DEFAULT_DATE Then
                value = EARLIEST_DEFAULT_DATE
            End If
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                                        "DRL_Intel_Private", value.ToOADate.ToString)
            Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                                        "DRL_Intel_Private", value.ToOADate.ToString)
        End Set
    End Property

    Friend Property LastRegisteredDate() As Date
        Get
            'Vorkommateil ermitteln
            Dim locObject As Object = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                                        "DgeRL_Intel_Private", Nothing)
            If locObject Is Nothing Then
                Return EARLIEST_DEFAULT_DATE
            End If

            Dim returnValue As Date

            Try
                returnValue = Date.FromOADate(Double.Parse(locObject.ToString))
            Catch ex As Exception
                returnValue = Date.FromOADate(Double.Parse(locObject.ToString, CultureInfo.InvariantCulture))
            End Try

            Return returnValue
        End Get
        Set(ByVal value As Date)
            If value < EARLIEST_DEFAULT_DATE Then
                value = EARLIEST_DEFAULT_DATE
            End If
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Intel_lAD\Classes\" + CLASS_VERSION_GUID,
                                        "DgeRL_Intel_Private", value.ToOADate.ToString)
        End Set
    End Property

    Friend Property ProgramGUID() As String
        Get
            Dim locObject As Object = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes",
                                        VERSION_GUID, Nothing)
            If locObject Is Nothing Then
                Return Nothing
            End If
            Return locObject.ToString
        End Get
        Set(ByVal value As String)
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes",
                VERSION_GUID, value)
            Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso\Classes",
                VERSION_GUID, value)
        End Set
    End Property

    Friend Property ConnectionString() As String
        Get
            Dim locObject As Object = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes",
                                        "ConnectionString", Nothing)
            Return locObject.ToString
        End Get
        Set(ByVal value As String)
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes",
                "ConnectionString", value)
            Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso\Classes",
                "ConnectionString", value)
        End Set
    End Property

    Friend Property SerialNumber() As String
        Get
            Dim locSerial As String = CStr(Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes",
                                        "SerialNumber", Nothing))
            If locSerial Is Nothing Then
                locSerial = "000000000000000000000000000000"
            End If
            Return locSerial
        End Get
        Set(ByVal value As String)
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes",
                "SerialNumber", value)
            Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso\Classes",
                "SerialNumber", value)
        End Set
    End Property

    Friend ReadOnly Property SubsidiarySubstitutionName() As String
        Get
            Dim locRetString As String = CStr(Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                "SubsidiarySubstitutionName", Nothing))
            If String.IsNullOrWhiteSpace(locRetString) Then
                locRetString = CStr(Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                                "SubsidiarySubstitutionName", Nothing))
                If Not String.IsNullOrWhiteSpace(locRetString) Then
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                    "SubsidiarySubstitutionName", locRetString)
                    Return locRetString
                End If
            End If

            If locRetString Is Nothing Then
                'Mit 2.0 als Anpassung für Windows Vista/Windows 7 gelöscht:
                Try
                    locRetString = "Filiale"
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                    "SubsidiarySubstitutionName", locRetString)
                    Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                                    "SubsidiarySubstitutionName", locRetString)
                Catch ex As Exception
                End Try
            End If
            Return locRetString
        End Get
    End Property

    Friend Property SharedFolder() As String
        Get
            Return TryGetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "SharedFolder",
                                                     My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Shared")
        End Get
        Set(ByVal value As String)
            TrySetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "SharedFolder", value)
        End Set
    End Property

    Friend Property UpdateFolder() As String
        Get
            Dim notDefined = "- not defined -"
            Dim tempReturn = TryGetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "UpdateFolder",
                                                               notDefined)
            If tempReturn = notDefined Then
                Return Nothing
            Else
                Return tempReturn
            End If
        End Get
        Set(ByVal value As String)
            If String.IsNullOrWhiteSpace(value) Then
                TrySetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "UpdateFolder", "- not defined -")
            Else
                TrySetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "UpdateFolder", value)
            End If
        End Set
    End Property

    Friend Property UpdateUrl() As String
        Get
            Return TryGetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "UpdateUrl", "http://facesso.de\update")
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                value = "http://facesso.de\update"
            End If
            TrySetReplicatedLocalMachineValue("SOFTWARE\ActiveDev\Facesso\Classes", "UpdateUrl", value)
        End Set
    End Property

    Friend Property InstallationFolder() As String
        Get
            Dim locRetString As String = CStr(Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                            "InstallationFolder", Nothing))
            If locRetString Is Nothing Then
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso",
                                "InstallationFolder", My.Application.Info.DirectoryPath)
                Try
                    Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                                "InstallationFolder", My.Application.Info.DirectoryPath)
                Catch ex As Exception
                End Try
                locRetString = My.Application.Info.DirectoryPath
            End If
            Return locRetString
        End Get
        Set(ByVal value As String)
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso",
                            "InstallationFolder", value.ToString)
        End Set
    End Property

    Public Sub SetConnectionString(ByVal connString As String)
        ConnectionString = connString
    End Sub

    Friend Function TryGetReplicatedLocalMachineValue(Of t)(keyName As String, valueName As String, DefaultValue As t) As t
        Dim returnValue As Object = Registry.GetValue("HKEY_CURRENT_USER\" & keyName, valueName, Nothing)
        If returnValue Is Nothing Then
            returnValue = Registry.GetValue("HKEY_LOCAL_MACHINE\" & keyName, valueName, Nothing)
            If returnValue Is Nothing Then
                returnValue = DefaultValue
                Registry.SetValue("HKEY_CURRENT_USER\" & keyName, valueName, DefaultValue)
            End If
        End If

        Return CType(returnValue, t)
    End Function

    Friend Function TrySetReplicatedLocalMachineValue(Of t)(keyName As String, valueName As String, DefaultValue As t) As String
        Registry.SetValue("HKEY_CURRENT_USER\" & keyName, valueName, DefaultValue)
        Try
            Registry.SetValue("HKEY_LOCAL_MACHINE\" & keyName, valueName, DefaultValue)
            Return "OK"
        Catch ex As Exception
            Return $"'{keyName}' could not be written - access denied. Login as Administrator and try again."
        End Try
    End Function
End Module

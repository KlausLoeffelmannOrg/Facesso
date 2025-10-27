Imports ActiveDev
Imports Microsoft.Win32

''' <summary>
''' Übernimmt das komplette Licencing der Facesso-Software. Von AdLicenseManager abgeleitet.
''' </summary>
''' <remarks></remarks>
<CLSCompliant(False)> _
Public NotInheritable Class FacessoLicenseManager
    Inherits ADLicenseManager

    Sub New(ByVal prgGuid As Guid, ByVal InstallDate As Date, ByVal LastRunDate As Date, ByVal LastRegisteredDate As Date, ByVal SerialNumber As String)
        MyBase.New(prgGuid, InstallDate, LastRunDate, LastRegisteredDate, SerialNumber)
        If Not HasValidSerialNo() Then
            myLicenseInfo.Fallback(1, 2)
        End If
    End Sub

    Public Overrides Function IsLicensed() As Boolean
        If Date.Now < myInstallDate Then
            Try
                'Wir müssen auf CURRENT_USER auf jeden Fall setzen, und...
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", _
                        "ForceReapplication", True)

                '...LOCAL_MACHINE in jedem Fall versuchen (klappt unter 64Bit nur als Admin).
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", _
                        "ForceReapplication", True)

            Catch ex As Exception
            End Try
            Dim up As New ADLicenseUnvalidException(Date.Now, ADLicenseUnvalidReason.SystemDateManipulated, _
                "Das aktuelle Datum liegt vor dem Installationsdatum. Facesso kann daher die korrekten Lizenzinformationen nicht überprüfen und wird deswegen nun beendet. Beim nächsten Start von Facesso können Sie einen neuen Freischaltcode eingeben!")
            Throw up
            Return False
        End If

        If Date.Now < myLastRunDate Then
            Try
                'Wir müssen auf CURRENT_USER auf jeden Fall setzen, und...
                Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", _
                        "ForceReapplication", True)

                '...LOCAL_MACHINE in jedem Fall versuchen (klappt unter 64Bit nur als Admin).
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", _
                        "ForceReapplication", True)

            Catch ex As Exception
            End Try
            Dim up As New ADLicenseUnvalidException(Date.Now, ADLicenseUnvalidReason.SystemDateManipulated, _
                "Das aktuelle Datum liegt vor dem letzten Startdatum von Facesso. Eine Überprüfung der korrekten Lizenzinformationen ist daher nicht möglich. Beim nächsten Start von Facesso können Sie einen neuen Freischaltcode eingeben.")
            Throw up
            Return False
        End If

        If myLicenseInfo.MonthsLimited <> 0 Then
            If Date.Now > BestBefore Then
                Try
                    'Wir müssen auf CURRENT_USER auf jeden Fall setzen, und...
                    Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", _
                            "ForceReapplication", True)

                    '...LOCAL_MACHINE in jedem Fall versuchen (klappt unter 64Bit nur als Admin).
                    Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", _
                            "ForceReapplication", True)

                Catch ex As Exception
                End Try
                Dim up As New ADLicenseUnvalidException(Date.Now, ADLicenseUnvalidReason.Expired, _
                    "Die Probe-Frist ist abgelaufen! Beim nächsten Start von Facesso können Sie einen neuen Freischaltcode eingeben!")
                Throw up
                Return False
            End If
        End If

        If myLicenseInfo.SoftwareID > 10 Then
            Dim up As New ADLicenseUnvalidException(Date.Now, ADLicenseUnvalidReason.WrongSoftware, _
                "Der Freischaltcode ist nicht für diese Softwareversion gültig! Beim nächsten Start von Facesso können Sie einen neuen Freischaltcode eingeben.")
            Throw up
            Return False
        End If

        If myLicenseInfo.HasFallenBack Then
            Return True
        Else
            Return MyBase.IsLicensed
        End If
    End Function

    Public ReadOnly Property VersionPermissionInfo() As FacessoVersionPermissionInfo
        Get
            Return New FacessoVersionPermissionInfo(CType(myLicenseInfo.SoftwareID, FacessoVersion))
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim tmpIsLicenced As Boolean
        Dim retText As String = "Ist Lizensiert: " & If(IsLicensed, "Ja", "Nein") & vbNewLine
        tmpIsLicenced = tmpIsLicenced Or IsLicensed()
        retText &= "Has Fallen Back: " & If(myLicenseInfo.HasFallenBack, "Ja", "Nein") & vbNewLine
        retText &= "Beschränkt auf Monate: " & myLicenseInfo.MonthsLimited
        tmpIsLicenced = tmpIsLicenced Or myLicenseInfo.HasFallenBack

        If Not tmpIsLicenced Then Return retText

        retText &= vbNewLine & "Software-ID: " & myLicenseInfo.SoftwareID.ToString & vbNewLine
        retText &= "Für Nutzer: " & myLicenseInfo.Limit1.ToString & vbNewLine
        retText &= "Für Internet-Nutzer: " & myLicenseInfo.Limit2.ToString & vbNewLine
        retText &= "Für Mitarbeiter: " & myLicenseInfo.Limit3.ToString & vbNewLine
        retText &= "Schnittstellenausbau : " & myLicenseInfo.Limit4.ToString & vbNewLine
        Return retText
    End Function
End Class

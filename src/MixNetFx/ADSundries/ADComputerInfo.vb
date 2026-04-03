Imports System.Management

Public Module ADComputerInfo

    ''' <summary>
    ''' Ermittelt einen Identifier als String aus der Seriennummer der Hauptplatine. 
    ''' HINWEIS: Nicht alle Hauptplatinen unterstützen diese Funktion, und liefern keinen eindeutigen String zurück!
    ''' </summary>
    ''' <returns>String mit eindeutigen Identifier der Hauptplatine.</returns>
    ''' <remarks></remarks>
    Public Function GetBoardInfoString() As String
        Dim locQuery As New WqlObjectQuery("select * from Win32_BaseBoard")
        Dim locSearcher As New ManagementObjectSearcher(locQuery)
        Dim locBaseBoardID As String = ""
        For Each locBaseBoardObj As ManagementObject In locSearcher.Get()
            Try
                locBaseBoardID = locBaseBoardObj("Product").ToString
            Catch ex As Exception
                locBaseBoardID = "XdFeR45"
            End Try

            Try
                locBaseBoardID &= locBaseBoardObj("Version").ToString
            Catch ex As Exception
                locBaseBoardID = "5GhzU87"
            End Try
            Exit For
        Next
        Return locBaseBoardID
    End Function

    ''' <summary>
    ''' Ermittelt einen Typnamen der Hauptplatine als String, der sich aus dem Herstellertyp des verwendeten 
    ''' Mother-Boards ergibt. HINWEIS: Erfahrungsgemäß unterstützen alle Hauptplatinen diese Funktion, 
    ''' und liefern eindeutige Strings zurück, die sich bei gleichen Boards natürlich ähneln.
    ''' </summary>
    ''' <returns>String mit dem Brand-Namen des Mother-Boards.</returns>
    ''' <remarks></remarks>
    Public Function GetBiosInfoString() As String
        Dim locQuery As New WqlObjectQuery("select * from Win32_DiskDrive")
        Dim locSearcher As New ManagementObjectSearcher(locQuery)
        Dim locBIOSID As String = ""
        For Each locBIOSObj As ManagementObject In locSearcher.Get()
            Try
                locBIOSID = locBIOSObj("Model").ToString
            Catch ex As Exception
                locBIOSID = "JeDF59KK"
            End Try

            Try
                locBIOSID &= locBIOSObj("Signature").ToString
            Catch ex As Exception
                locBIOSID = "SdFFg3Ed"
            End Try
            Exit For
        Next
        Return locBIOSID
    End Function

    ''' <summary>
    ''' Ermittelt, ob es sich bei der verwendeten Hardware um einen virtuellen PC vom Typ Microsoft Virtual PC handelt.
    ''' </summary>
    ''' <returns>True, wenn es Microsoft Virtual PC ist.</returns>
    ''' <remarks></remarks>
    Public Function IsVPC() As Boolean
        If GetBoardInfoString.IndexOf("VirtualPC") > -1 Then
            Return True
        Else
            Return False
        End If
    End Function
End Module



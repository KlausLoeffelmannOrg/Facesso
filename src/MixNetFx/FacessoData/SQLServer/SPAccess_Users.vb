Imports Activedev
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    ''' <summary>
    ''' Überprüft, ob der angegebene Benutzername für die Subsidiary schon existiert.
    ''' </summary>
    ''' <param name="IDSubsidiary">ID der verwendeten Subsidiary</param>
    ''' <param name="Username">Benutzername</param>
    ''' <param name="ExcludeIDUser">Benutzername</param>
    ''' <returns>True, wenn die Kostenstelle schon vorhanden war.</returns>
    ''' <remarks></remarks>
    Public Function Users_DoesUsernameExist(ByVal IDSubsidiary As Integer, _
                                                   ByVal Username As String, _
                                                   ByVal ExcludeIDUser As ADDBNullable(Of Integer)) _
                                                   As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Users_DoesUsernameExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@Username", SqlDbType.nvarchar, 100).Value = Username
                .Add("@ExcludeIDUser", SqlDbType.Int).Value = ExcludeIDUser.Value
                .Add("@DoesExist", SqlDbType.Bit)
                .Item("@DoesExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CBool(locCmd.Parameters("@DoesExist").Value)
        End Using
    End Function

    ''' <summary>
    ''' Fügt den in UserInfo und AddressDetails gespeicherten Benutzer der Datenbank hinzu.
    ''' </summary>
    ''' <param name="ui">UserInfo mit den Hauptdaten für den Benutzer.</param>
    ''' <param name="addrDet">AddressDetailsInfo mit den Adressendaten für den Benutzer.</param>
    ''' <returns>Neue ID des Users.</returns>
    ''' <remarks>Die korrelierende Stored Procedure handelt die Versionskontrolle und schließt doppelte Benutzernamen aus.</remarks>
    Public Function Users_Add(ByVal ui As UserInfo, ByVal CreatedByIDUser As Integer, ByVal addrDet As AddressDetailsInfo) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Users_Add", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = ui.IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = ui.IDCostCenter
                .Add("@FirstName", SqlDbType.NVarChar, 100).Value = ui.FirstName
                .Add("@LastName", SqlDbType.NVarChar, 100).Value = ui.LastName
                .Add("@UserName", SqlDbType.NVarChar, 100).Value = ui.Username
                .Add("@Password", SqlDbType.VarBinary, 128).Value = ui.Password
                .Add("@ClearanceLevel", SqlDbType.BigInt).Value = ui.ClearanceLevel
                .Add("@HasWorkstationAccess", SqlDbType.Bit).Value = ui.HasWorkstationAccess
                .Add("@HasInternetAccess", SqlDbType.Bit).Value = ui.HasInternetAccess
                .Add("@IsActivated", SqlDbType.Bit).Value = ui.IsActivated
                .Add("@DoesExpire", SqlDbType.Bit).Value = ui.DoesExpire
                .Add("@ExpireDate", SqlDbType.DateTime).Value = ui.ExpireDate
                .Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate
                .Add("@CreatedByIDUser", SqlDbType.Int).Value = CreatedByIDUser
                .Add("@Comment", SqlDbType.NText).Value = ui.Comment.Value

                'Adressen-Details
                .Add("@PersonnelNo", SqlDbType.Int).Value = addrDet.PersonnelNo.Value
                .Add("@MiddleName", SqlDbType.NVarChar, 100).Value = addrDet.MiddleName.Value
                .Add("@Title", SqlDbType.NVarChar, 100).Value = addrDet.Titel.Value
                .Add("@Street", SqlDbType.NVarChar, 100).Value = addrDet.Street.Value
                .Add("@Zip", SqlDbType.NVarChar, 10).Value = addrDet.Zip.Value
                .Add("@City", SqlDbType.NVarChar, 100).Value = addrDet.City.Value
                .Add("@CountryCode", SqlDbType.NVarChar, 10).Value = addrDet.CountryCode.Value
                .Add("@Country", SqlDbType.NVarChar, 100).Value = addrDet.Country.Value
                .Add("@CompanyPhone", SqlDbType.NVarChar, 100).Value = addrDet.CompanyPhone.Value
                .Add("@PrivatePhone", SqlDbType.NVarChar, 100).Value = addrDet.PrivatePhone.Value
                .Add("@CompanyEmail", SqlDbType.NVarChar, 255).Value = addrDet.CompanyEmail.Value
                .Add("@PrivateEmail", SqlDbType.NVarChar, 255).Value = addrDet.PrivateEmail.Value
                .Add("@CompanyMobile", SqlDbType.NVarChar, 100).Value = addrDet.CompanyMobile.Value
                .Add("@PrivateMobile", SqlDbType.NVarChar, 100).Value = addrDet.PrivateMobile.Value
                .Add("@URL", SqlDbType.NVarChar, 100).Value = addrDet.URL.Value
                .Add("@IDUserNew", SqlDbType.Int)
                .Item("@IDUserNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDUserNew").Value)
        End Using

    End Function

    ''' <summary>
    ''' Editiert den in UserInfo und AddressDetails gespeicherten Benutzer.
    ''' </summary>
    ''' <param name="ui">UserInfo mit den Hauptdaten für den Benutzer.</param>
    ''' <param name="addrDet">AddressDetailsInfo mit den Adressendaten für den Benutzer.</param>
    ''' <returns>Neue (bei Versionshandling) bzw. alte ID des Users.</returns>
    ''' <remarks>Die korrelierende Stored Procedure handelt die Versionskontrolle und schließt doppelte Benutzernamen aus.</remarks>
    Public Function Users_Edit(ByVal ui As UserInfo, ByVal LastEditedByIDUser As Integer, ByVal addrDet As AddressDetailsInfo) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Users_Edit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = ui.IDSubsidiary
                .Add("@IDUser", SqlDbType.Int).Value = ui.IDUser
                .Add("@IDCostCenter", SqlDbType.Int).Value = ui.IDCostCenter
                .Add("@FirstName", SqlDbType.NVarChar, 100).Value = ui.FirstName
                .Add("@LastName", SqlDbType.NVarChar, 100).Value = ui.LastName
                .Add("@UserName", SqlDbType.NVarChar, 100).Value = ui.Username
                .Add("@Password", SqlDbType.VarBinary, 128).Value = ui.Password
                .Add("@ClearanceLevel", SqlDbType.BigInt).Value = ui.ClearanceLevel
                .Add("@HasWorkstationAccess", SqlDbType.Bit).Value = ui.HasWorkstationAccess
                .Add("@HasInternetAccess", SqlDbType.Bit).Value = ui.HasInternetAccess
                .Add("@IsActivated", SqlDbType.Bit).Value = ui.IsActivated
                .Add("@DoesExpire", SqlDbType.Bit).Value = ui.DoesExpire
                .Add("@ExpireDate", SqlDbType.DateTime).Value = ui.ExpireDate
                .Add("@Comment", SqlDbType.NText).Value = ui.Comment.Value
                .Add("@LastEditedByIDUser", SqlDbType.Int).Value = LastEditedByIDUser

                'Adressen-Details
                .Add("@PersonnelNo", SqlDbType.Int).Value = addrDet.PersonnelNo.Value
                .Add("@MiddleName", SqlDbType.NVarChar, 100).Value = addrDet.MiddleName.Value
                .Add("@Title", SqlDbType.NVarChar, 100).Value = addrDet.Titel.Value
                .Add("@Street", SqlDbType.NVarChar, 100).Value = addrDet.Street.Value
                .Add("@Zip", SqlDbType.NVarChar, 10).Value = addrDet.Zip.Value
                .Add("@City", SqlDbType.NVarChar, 100).Value = addrDet.City.Value
                .Add("@CountryCode", SqlDbType.NVarChar, 10).Value = addrDet.CountryCode.Value
                .Add("@Country", SqlDbType.NVarChar, 100).Value = addrDet.Country.Value
                .Add("@CompanyPhone", SqlDbType.NVarChar, 100).Value = addrDet.CompanyPhone.Value
                .Add("@PrivatePhone", SqlDbType.NVarChar, 100).Value = addrDet.PrivatePhone.Value
                .Add("@CompanyEmail", SqlDbType.NVarChar, 255).Value = addrDet.CompanyEmail.Value
                .Add("@PrivateEmail", SqlDbType.NVarChar, 255).Value = addrDet.PrivateEmail.Value
                .Add("@CompanyMobile", SqlDbType.NVarChar, 100).Value = addrDet.CompanyMobile.Value
                .Add("@PrivateMobile", SqlDbType.NVarChar, 100).Value = addrDet.PrivateMobile.Value
                .Add("@URL", SqlDbType.NVarChar, 100).Value = addrDet.URL.Value
                .Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = ConsiderHistoryMaintenance
                .Add("@IDUserNew", SqlDbType.Int)
                .Item("@IDUserNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDUserNew").Value)
        End Using
    End Function

    Public ReadOnly Property UserInfoCollection() As UserInfoCollection
        Get
            Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
            If locConnection Is Nothing Then
                Return Nothing
            End If
            Using locConnection
                Dim locCommand As New SqlCommand("SELECT * From [Users] WHERE [IDSubsidiary]=" & _
                    FacessoGeneric.LoginInfo.IDSubsidiary & " AND [IsSystemAccount]=0", locConnection)
                Dim locDR As SqlDataReader = locCommand.ExecuteReader()
                If locDR.HasRows Then
                    Dim locUIC As New UserInfoCollection
                    Do While locDR.Read
                        Dim locUserInfo As New UserInfo()
                        locUserInfo.AssignFieldsFromDataReader(locDR)
                        locUIC.Add(locUserInfo)
                    Loop
                    Return locUIC
                Else
                    Return Nothing
                End If
            End Using
        End Get
    End Property

End Class

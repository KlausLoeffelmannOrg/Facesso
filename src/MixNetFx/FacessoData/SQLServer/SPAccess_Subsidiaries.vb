Imports ActiveDev
Imports Facesso
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    Public Function Subsidiaries_DoesNameExist(ByVal SubsidiaryName As String, _
                                               ByVal ExcludeIDSubsidiary As ADDBNullable(Of Integer)) _
                                               As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Subsidiaries_DoesNameExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@SubsidiaryName", SqlDbType.NVarChar, 100).Value = SubsidiaryName
                .Add("@ExcludeIDSubsidiary", SqlDbType.Int).Value = ExcludeIDSubsidiary.Value
                .Add("@DoesExist", SqlDbType.Bit)
                .Item("@DoesExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CBool(locCmd.Parameters("@DoesExist").Value)
        End Using
    End Function

    Public Function Subsidiaries_Add(ByVal si As SubsidiaryInfo, ByVal CreatedByIDUser As Integer) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Subsidiaries_Add", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@SubsidiaryName", SqlDbType.NVarChar, 100).Value = si.SubsidiaryName
                .Add("@SubsidiaryStreet", SqlDbType.NVarChar, 100).Value = si.Street
                .Add("@SubsidiaryZip", SqlDbType.NVarChar, 10).Value = si.Zip
                .Add("@SubsidiaryCity", SqlDbType.NVarChar, 100).Value = si.City
                .Add("@SubsidiaryCountryCode", SqlDbType.NVarChar, 10).Value = si.CountryCode
                .Add("@SubsidiaryCountry", SqlDbType.NVarChar, 100).Value = si.Country
                .Add("@SubsidiaryPrimaryPhone", SqlDbType.NVarChar, 100).Value = si.PrimaryPhone
                .Add("@CreatedByIDUser", SqlDbType.Int).Value = CreatedByIDUser
                .Add("@IDSubsidiaryCreated", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary
                .Add("@IDSubsidiaryNew", SqlDbType.Int) : .Item("@IDSubsidiaryNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDSubsidiaryNew").Value)
        End Using
    End Function

    Public Sub Subsidiaries_Edit(ByVal si As SubsidiaryInfo, ByVal LastEditedByIDUser As Integer)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Subsidiaries_Edit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = si.IDSubsidiary
                .Add("@SubsidiaryName", SqlDbType.NVarChar, 100).Value = si.SubsidiaryName
                .Add("@SubsidiaryStreet", SqlDbType.NVarChar, 100).Value = si.Street
                .Add("@SubsidiaryZip", SqlDbType.NVarChar, 10).Value = si.Zip
                .Add("@SubsidiaryCity", SqlDbType.NVarChar, 100).Value = si.City
                .Add("@SubsidiaryCountryCode", SqlDbType.NVarChar, 10).Value = si.CountryCode
                .Add("@SubsidiaryCountry", SqlDbType.NVarChar, 100).Value = si.Country
                .Add("@SubsidiaryPrimaryPhone", SqlDbType.NVarChar, 100).Value = si.PrimaryPhone
                .Add("@LastEditedByIDUser", SqlDbType.Int).Value = LastEditedByIDUser
                .Add("@IDSubsidiaryEdited", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.SubsidiaryInfo.IDSubsidiary
            End With
            locCmd.ExecuteReader()
        End Using
    End Sub

    Public Sub Subsidiaries_Delete(ByVal si As SubsidiaryInfo, ByVal LastEditedByIDUser As UserInfo)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Subsidiaries_Delete", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = si.IDSubsidiary
                .Add("@DeletedByIDUser", SqlDbType.Int).Value = LastEditedByIDUser.IDUser
                .Add("@IDSubsidiaryContainingUser", SqlDbType.Int).Value = LastEditedByIDUser.IDSubsidiary
            End With
            locCmd.ExecuteReader()
        End Using
    End Sub


End Class

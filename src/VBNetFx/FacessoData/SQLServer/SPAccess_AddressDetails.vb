Imports ActiveDev
Imports Facesso
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    ''' <summary>
    ''' Überprüft, ob die angegebene Kostenstelle für die Subsidiary schon existiert.
    ''' </summary>
    ''' <param name="AddressDetails">AddressDetailsInfo, die die Adressendetails enthält.</param>
    ''' <returns>Liefert IDAddressDetails zurück</returns>
    ''' <remarks></remarks>
    Public Function SP_CostCenters_AddAddressDetails(ByVal AddressDetails As AddressDetailsInfo) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("sp_AddressDetails_Add", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = AddressDetails.IDSubsidiary
                .Add("@LastName", SqlDbType.NVarChar, 100).Value = AddressDetails.LastName.Value
                .Add("@MiddleName", SqlDbType.NVarChar, 100).Value = AddressDetails.MiddleName.Value
                .Add("@FirstName", SqlDbType.NVarChar, 100).Value = AddressDetails.FirstName.Value
                .Add("@Titel", SqlDbType.NVarChar, 100).Value = AddressDetails.Titel.Value
                .Add("@Street", SqlDbType.NVarChar, 100).Value = AddressDetails.Street.Value
                .Add("@Zip", SqlDbType.NVarChar, 10).Value = AddressDetails.Zip.Value
                .Add("@City", SqlDbType.NVarChar, 100).Value = AddressDetails.City.Value
                .Add("@CountryCode", SqlDbType.NVarChar, 10).Value = AddressDetails.CountryCode.Value
                .Add("@Country", SqlDbType.NVarChar, 100).Value = AddressDetails.Country.Value
                .Add("@CompanyTel", SqlDbType.NVarChar, 100).Value = AddressDetails.CompanyPhone.Value
                .Add("@PrivateTel", SqlDbType.NVarChar, 100).Value = AddressDetails.PrivatePhone.Value
                .Add("@CompanyEmail", SqlDbType.NVarChar, 255).Value = AddressDetails.CompanyEmail.Value
                .Add("@PrivateEmail", SqlDbType.NVarChar, 255).Value = AddressDetails.PrivateEmail.Value
                .Add("@CompanyMobile", SqlDbType.NVarChar, 100).Value = AddressDetails.CompanyMobile.Value
                .Add("@PrivateMobile", SqlDbType.NVarChar, 100).Value = AddressDetails.PrivateMobile.Value
                .Add("@URL", SqlDbType.NVarChar, 255).Value = AddressDetails.URL.Value
                .Item(18).Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters(18).Value)
        End Using
    End Function
End Class

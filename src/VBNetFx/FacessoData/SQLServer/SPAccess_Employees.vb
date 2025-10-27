Imports Activedev
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms

Partial Public NotInheritable Class SPAccess

    Public Function Employees_DoesPersonnelNumberExist(ByVal IDSubsidiary As Integer, _
                                                       ByVal PersonnelNumber As Integer, _
                                                       ByVal ExcludeIDEmployee As ADDBNullable(Of Integer)) _
                                                       As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Employees_DoesPersonnelNumberExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@PersonnelNumber", SqlDbType.Int).Value = PersonnelNumber
                .Add("@ExcludeIDEmployee", SqlDbType.Int).Value = ExcludeIDEmployee.Value
                .Add("@DoesExist", SqlDbType.Bit)
                .Item("@DoesExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteScalar()
            Return CBool(locCmd.Parameters("@DoesExist").Value)
        End Using
    End Function

    Public Function Employees_DoesMatchcodeExist(ByVal IDSubsidiary As Integer, _
                                                 ByVal Matchcode As ADDBNullable(Of String), _
                                                 ByVal ExcludeIDEmployee As ADDBNullable(Of Integer)) _
                                                 As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Employees_DoesMatchcodeExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@Matchcode", SqlDbType.Int).Value = Matchcode
                .Add("@ExcludeIDEmployee", SqlDbType.Int).Value = ExcludeIDEmployee.Value
                .Add("@DoesExist", SqlDbType.Bit)
                .Item("@DoesExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CBool(locCmd.Parameters("@DoesExist").Value)
        End Using
    End Function

    Public Function Employees_Add(ByVal ei As EmployeeInfo, ByVal CreatedByIDUser As Integer, ByVal addrDet As AddressDetailsInfo) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Employees_Add", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = ei.IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = ei.IDCostCenter
                .Add("@IDWageGroup", SqlDbType.Int).Value = ei.IDWageGroup.Value
                .Add("@UseFixedWage", SqlDbType.Bit).Value = ei.UseFixedWage
                .Add("@FixedWage", SqlDbType.Money).Value = ei.FixedWage.Value
                .Add("@FirstName", SqlDbType.NVarChar, 100).Value = ei.FirstName
                .Add("@LastName", SqlDbType.NVarChar, 100).Value = ei.LastName
                .Add("@MatchCode", SqlDbType.NVarChar, 20).Value = ei.Matchcode.Value
                .Add("@PersonnelNumber", SqlDbType.Int).Value = ei.PersonnelNumber
                .Add("@IsActive", SqlDbType.Bit).Value = ei.IsActive
                .Add("@IsIncentive", SqlDbType.Bit).Value = ei.IsIncentive
                .Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate
                .Add("@DateOfBirth", SqlDbType.DateTime).Value = ei.DateOfBirth.Value
                .Add("@DateOfJoining", SqlDbType.DateTime).Value = ei.DateOfJoining.Value
                .Add("@DateOfSeparation", SqlDbType.DateTime).Value = ei.DateOfSeparation.Value
                .Add("@TimeCardNo", SqlDbType.NText).Value = ei.TimeCardNo.Value
                .Add("@Comment", SqlDbType.NText).Value = ei.Comment.Value
                .Add("@CreatedByIDUser", SqlDbType.Int).Value = CreatedByIDUser

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
                .Add("@IDEmployeeNew", SqlDbType.Int)
                .Item("@IDEmployeeNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDEmployeeNew").Value)
        End Using

    End Function

    Public Function Employees_IsInUse(ByVal lvi As EmployeeInfo) As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Employees_IsInUse", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDEmployee", SqlDbType.Int).Value = lvi.IDEmployee
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
                .Add("@IsInUse", SqlDbType.Bit)
                .Item("@IsInUse").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()
            Return CBool(locCmd.Parameters("@IsInUse").Value)
        End Using

    End Function

    Public Sub Employees_Delete(ByVal lvi As EmployeeInfo)
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Employees_Delete", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDEmployee", SqlDbType.Int).Value = lvi.IDEmployee
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
            End With
            locCmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Function Employees_Edit(ByVal ei As EmployeeInfo, ByVal LastEditedByIDUser As Integer, ByVal addrDet As AddressDetailsInfo) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Employees_Edit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = ei.IDSubsidiary
                .Add("@IDEmployee", SqlDbType.Int).Value = ei.IDEmployee
                .Add("@IDCostCenter", SqlDbType.Int).Value = ei.IDCostCenter
                .Add("@IDWageGroup", SqlDbType.Int).Value = ei.IDWageGroup.Value
                .Add("@UseFixedWage", SqlDbType.Bit).Value = ei.UseFixedWage
                .Add("@FixedWage", SqlDbType.Money).Value = ei.FixedWage.Value
                .Add("@FirstName", SqlDbType.NVarChar, 100).Value = ei.FirstName
                .Add("@LastName", SqlDbType.NVarChar, 100).Value = ei.LastName
                .Add("@MatchCode", SqlDbType.NVarChar, 20).Value = ei.Matchcode.Value
                .Add("@PersonnelNumber", SqlDbType.Int).Value = ei.PersonnelNumber
                .Add("@IsActive", SqlDbType.Bit).Value = ei.IsActive
                .Add("@IsIncentive", SqlDbType.Bit).Value = ei.IsIncentive
                .Add("@DateOfBirth", SqlDbType.DateTime).Value = ei.DateOfBirth.Value
                .Add("@DateOfJoining", SqlDbType.DateTime).Value = ei.DateOfJoining.Value
                .Add("@DateOfSeparation", SqlDbType.DateTime).Value = ei.DateOfSeparation.Value
                .Add("@TimeCardNo", SqlDbType.NText).Value = ei.TimeCardNo.Value
                .Add("@Comment", SqlDbType.NText).Value = ei.Comment.Value
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
                .Add("@IDEmployeeNew", SqlDbType.Int)
                .Item("@IDEmployeeNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDEmployeeNew").Value)
        End Using
    End Function

    Public Sub Employees_GetInWorkGroupOnShiftDate(ByVal cp As CombinedParametersInfo, ByVal eic As EmployeeInfoItems)
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Employees_GetInWorkGroupOnShiftDate", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = cp.WorkGroup.IDWorkGroup
                .Add("@ProductionDate", SqlDbType.DateTime).Value = cp.ProductionDate
                .Add("@Shift", SqlDbType.TinyInt).Value = cp.Shift
            End With
            Dim locDR As SqlDataReader = locCmd.ExecuteReader()
            If locDR.HasRows Then
                Do While locDR.Read
                    Dim locEmployeeInfo As New EmployeeInfo(locDR, True)
                    eic.Add(locEmployeeInfo)
                Loop
            End If
        End Using
    End Sub

    Public Function EmployeeInfoCollectionCommandString() As String
        Return "SELECT [Employees].*,[CostCenters].[CostCenterNo], [CostCenters].[CostCenterName] FROM [Employees] " & _
            "[Employees] INNER JOIN [CostCenters] ON " & _
            "[Employees].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " & _
            "[Employees].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
            " AND [Employees].[IsCurrent]='true'"
    End Function

    Public Function EmployeeInfoCollectionCommandString(ByVal OrderByString As String) As String
        Return "SELECT [Employees].*,[CostCenters].[CostCenterNo], [CostCenters].[CostCenterName] FROM [Employees] " & _
                    "[Employees] INNER JOIN [CostCenters] ON " & _
                    "[Employees].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " & _
                    "[Employees].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
                    " AND [Employees].[IsCurrent]='true'" & _
                    " ORDER BY [" & OrderByString & "]"
    End Function

    Friend Sub Employees_LookUpWageData(ByVal Employee As EmployeeWageInfo)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("Employees_LookUpWageData", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = Employee.IDSubsidiary
                .Add("@IDEmployee", SqlDbType.Int).Value = Employee.IDEmployee
                .Add("@IDCostCenter", SqlDbType.Int).Value = Employee.IDCostCenter
                .Add("@DegreeOfTime", SqlDbType.Float).Value = Employee.DegreeOfTime
                .Add("@UseFixValuedBonus", SqlDbType.Bit) : .Item("@UseFixValuedBonus").Direction = ParameterDirection.Output
                .Add("@BaseWage", SqlDbType.Float) : .Item("@BaseWage").Direction = ParameterDirection.Output
                .Add("@Percentage", SqlDbType.Float) : .Item("@Percentage").Direction = ParameterDirection.Output
                .Add("@AbsoluteValue", SqlDbType.Float) : .Item("@AbsoluteValue").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteScalar()
            Employee.UseFixValuedBonus = CBool(locCmd.Parameters("@UseFixValuedBonus").Value)
            Try
                Employee.BaseWage = CDbl(locCmd.Parameters("@BaseWage").Value)
            Catch ex As Exception
                MessageBox.Show("Basislohn für Mitarbeiter " & Employee.LastName & " (" & Employee.PersonnelNumber.ToString & _
                ") wurde nicht richtig zugeordnet." & vbNewLine & _
                "Bitte überprüfen Sie daher die durchgeführten Berechnungen für die Facesso keine Richtigkeit garantieren kann!", _
                "Fehler in Mitarbeiterstammdaten", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End Try
            Employee.Percentage = CDbl(locCmd.Parameters("@Percentage").Value)
            Employee.AbsoluteValue = CDbl(locCmd.Parameters("@AbsoluteValue").Value)
        End Using
    End Sub
End Class

Imports Activedev
Imports Facesso
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    Public Function WorkGroups_DoesWorkGroupNumberExist(ByVal IDSubsidiary As Integer, _
                                                        ByVal WorkGroupNumber As Integer, _
                                                        ByVal ExcludeIDWorkGroup As ADDBNullable(Of Integer)) _
                                                        As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WorkGroups_DoesWorkGroupNumberExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@WorkGroupNumber", SqlDbType.Int).Value = WorkGroupNumber
                .Add("@ExcludeIDWorkGroup", SqlDbType.Int).Value = ExcludeIDWorkGroup.Value
                .Add("@DoesExist", SqlDbType.Bit)
                .Item("@DoesExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CBool(locCmd.Parameters("@DoesExist").Value)
        End Using
    End Function

    Public Function WorkGroups_DoesWorkGroupNameExist(ByVal IDSubsidiary As Integer, _
                                                    ByVal WorkGroupName As String, _
                                                    ByVal ExcludeIDWorkGroup As ADDBNullable(Of Integer)) _
                                                    As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WorkGroups_DoesWorkGroupNameExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@WorkGroupName", SqlDbType.NVarChar, 20).Value = WorkGroupName
                .Add("@ExcludeIDWorkGroup", SqlDbType.Int).Value = ExcludeIDWorkGroup.Value
                .Add("@DoesExist", SqlDbType.Bit)
                .Item("@DoesExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CBool(locCmd.Parameters("@DoesExist").Value)
        End Using
    End Function

    Public Function WorkGroups_Add(ByVal wgi As WorkGroupInfo, ByVal CreatedByIDUser As Integer) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WorkGroups_Add", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = wgi.IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = wgi.IDCostCenter
                .Add("@WorkGroupNumber", SqlDbType.Int).Value = wgi.WorkGroupNumber
                .Add("@WorkGroupName", SqlDbType.NVarChar, 100).Value = wgi.WorkGroupName
                .Add("@WorkGroupDescription", SqlDbType.NVarChar, 4000).Value = wgi.WorkGroupDescription.Value
                .Add("@IsActive", SqlDbType.Bit).Value = wgi.IsActive
                .Add("@IsPeaceWork", SqlDbType.Bit).Value = wgi.IsPeaceWork
                .Add("@IsConceptional", SqlDbType.Bit).Value = wgi.IsConceptional
                .Add("@OrdinalNo", SqlDbType.Int).Value = wgi.OrdinalNo
                .Add("@TimeSettingDetails", SqlDbType.Xml).Value = wgi.TimeSettingDetails.XMLString
                .Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate
                .Add("@CreatedByIDUser", SqlDbType.Int).Value = CreatedByIDUser
                .Add("@IDWorkGroupNew", SqlDbType.Int)
                .Item("@IDWorkGroupNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDWorkGroupNew").Value)
        End Using
    End Function

    Public Function WorkGroups_IsInUse(ByVal lvi As WorkGroupInfo) As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WorkGroups_IsInUse", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDWorkGroup", SqlDbType.Int).Value = lvi.IDWorkGroup
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
                .Add("@IsInUse", SqlDbType.Bit)
                .Item("@IsInUse").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()
            Return CBool(locCmd.Parameters("@IsInUse").Value)
        End Using

    End Function

    Public Sub WorkGroups_Delete(ByVal lvi As WorkGroupInfo)
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection

            'Assignments aufheben
            Dim locCmd As New SqlCommand("WorkGroups_DeleteAssignment", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = lvi.IDWorkGroup
            End With
            locCmd.ExecuteNonQuery()

            'Workgroup löschen
            locCmd = New SqlCommand("WorkGroups_Delete", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDWorkGroup", SqlDbType.Int).Value = lvi.IDWorkGroup
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
            End With
            locCmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Function WorkGroups_Edit(ByVal wgi As WorkGroupInfo, ByVal LastEditedByIDUser As Integer) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WorkGroups_Edit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDWorkGroup", SqlDbType.Int).Value = wgi.IDWorkGroup
                .Add("@IDSubsidiary", SqlDbType.Int).Value = wgi.IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = wgi.IDCostCenter
                .Add("@WorkGroupNumber", SqlDbType.Int).Value = wgi.WorkGroupNumber
                .Add("@WorkGroupName", SqlDbType.NVarChar, 100).Value = wgi.WorkGroupName
                .Add("@WorkGroupDescription", SqlDbType.NVarChar, 4000).Value = wgi.WorkGroupDescription.Value
                .Add("@IsActive", SqlDbType.Bit).Value = wgi.IsActive
                .Add("@IsPeaceWork", SqlDbType.Bit).Value = wgi.IsPeaceWork
                .Add("@OrdinalNo", SqlDbType.Int).Value = wgi.OrdinalNo
                .Add("@IsConceptional", SqlDbType.Bit).Value = wgi.IsConceptional
                .Add("@TimeSettingDetails", SqlDbType.Xml).Value = wgi.TimeSettingDetails.XMLString
                .Add("@LastEditedByIDUser", SqlDbType.Int).Value = LastEditedByIDUser
                .Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = ConsiderHistoryMaintenance
                .Add("@IDWorkGroupNew", SqlDbType.Int)
                .Item("@IDWorkGroupNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDWorkGroupNew").Value)
        End Using
    End Function

    Friend Sub GetWorkGroupInfoCollection(ByVal CPInfo As CombinedParametersInfo, ByVal Wgi As WorkGroupInfoItems, ByVal WgiGetType As WorkGroupInfoItemsGetType)
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WorkGroups_GetItems", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary
                If CPInfo Is Nothing Then
                    .Add("@Shift", SqlDbType.Int).Value = DBNull.Value
                    .Add("@ProductionDate", SqlDbType.DateTime).Value = DBNull.Value
                Else
                    .Add("@Shift", SqlDbType.Int).Value = CPInfo.Shift
                    .Add("@ProductionDate", SqlDbType.DateTime).Value = CPInfo.ProductionDate
                End If
                If (WgiGetType And WorkGroupInfoItemsGetType.JoinedWithCostCenter) = WorkGroupInfoItemsGetType.JoinedWithCostCenter Then
                    .Add("@JoinedWithCostCenter", SqlDbType.Bit).Value = True
                Else
                    .Add("@JoinedWithCostCenter", SqlDbType.Bit).Value = False
                End If
            End With

            Dim locDr As SqlDataReader = locCmd.ExecuteReader()
            If locDr.HasRows Then
                Do While locDr.Read
                    Dim locWorkGroupInfo As New WorkGroupInfo(locDr, WgiGetType)
                    Wgi.Add(locWorkGroupInfo)
                Loop
            End If
        End Using
    End Sub

    Public Sub AssignLabourValuesToWorkGroup(ByVal IDSubsidiary As Integer, ByVal IDWorkGroup As Integer, ByVal LabourValues As LabourValueInfoCollection)
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        Dim locCount As Integer = 1
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WorkGroups_DeleteAssignment", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = IDWorkGroup
            End With
            locCmd.ExecuteNonQuery()

            For Each locLvi As LabourValueInfo In LabourValues
                locCmd = New SqlCommand("WorkGroups_AddAssignmentRecord", locConnection)
                locCmd.CommandType = CommandType.StoredProcedure

                With locCmd.Parameters
                    .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                    .Add("@IDLabourValueInternal", SqlDbType.Int).Value = locLvi.IDLabourValueInternal
                    .Add("@IDWorkGroup", SqlDbType.Int).Value = IDWorkGroup
                    .Add("@OrdinalNumber", SqlDbType.Int).Value = locCount
                End With
                locCmd.ExecuteNonQuery()
                locCount += 1
            Next
        End Using
    End Sub

    Friend Function WorkGroups_GetAssignedLabourValues(ByVal IDSubsidiary As Integer, ByVal IDWorkGroup As Integer) As LabourValueInfoCollection
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WorkGroups_GetAssignedLabourValues", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = IDWorkGroup
            End With
            Dim locDr As SqlDataReader = locCmd.ExecuteReader()
            If locDr.HasRows Then
                Dim locLic As New LabourValueInfoCollection
                Do While locDr.Read
                    Dim locLabourValueInfo As New LabourValueInfo(locDr, True)
                    locLic.Add(locLabourValueInfo)
                Loop
                Return locLic
            Else
                Return Nothing
            End If
        End Using
    End Function

    Friend Function GetWorkGroup(ByVal IDSubsidiary As Integer, ByVal IDWorkGroup As Integer) As WorkGroupInfo
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCommand As New SqlCommand( _
                "SELECT [WorkGroups].*,CostCenters.CostCenterNo, CostCenters.CostCenterName, CostCenters.IncentiveIndicatorSynonym, CostCenters.IncentiveIndicatorDimension," & _
                "CostCenters.IncentiveIndicatorPrecision, CostCenters.IncentiveIndicatorFactor, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym FROM [WorkGroups] " & _
                "[WorkGroups] INNER JOIN [CostCenters] ON " & _
                "[WorkGroups].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " & _
                "[WorkGroups].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
                " AND [WorkGroups].[IsCurrent]='true' AND" & _
                "[WorkGroups].[IDWorkGroup]=" & IDWorkGroup, locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                locDR.Read()
                Return New WorkGroupInfo(locDR, WorkGroupInfoItemsGetType.JoinedWithCostCenter)
            Else
                Return Nothing
            End If
        End Using
    End Function

    Friend Function GetWorkGroupByWorkGroupNumber(ByVal IDSubsidiary As Integer, ByVal WorkGroupNumber As Integer) As WorkGroupInfo
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCommand As New SqlCommand( _
                "SELECT [WorkGroups].*,CostCenters.CostCenterNo, CostCenters.CostCenterName, CostCenters.IncentiveIndicatorSynonym, CostCenters.IncentiveIndicatorDimension," & _
                "CostCenters.IncentiveIndicatorPrecision, CostCenters.IncentiveIndicatorFactor, CostCenters.BaseValuePrecision, CostCenters.BaseValueSynonym FROM [WorkGroups] " & _
                "[WorkGroups] INNER JOIN [CostCenters] ON " & _
                "[WorkGroups].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " & _
                "[WorkGroups].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
                " AND [WorkGroups].[IsCurrent]=1 AND" & _
                "[WorkGroups].[WorkGroupNumber]=" & WorkGroupNumber, locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                locDR.Read()
                Return New WorkGroupInfo(locDR, WorkGroupInfoItemsGetType.JoinedWithCostCenter)
            Else
                Return Nothing
            End If
        End Using
    End Function



End Class

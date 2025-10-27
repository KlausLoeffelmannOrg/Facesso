Imports Activedev
Imports Facesso
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    Public Function LabourValues_DoesNumberExist(ByVal IDSubsidiary As Integer, _
                                                ByVal LabourValueNumber As Integer, _
                                                ByVal ExcludeIDLabourValue As ADDBNullable(Of Integer)) _
                                                As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("LabourValues_DoesNumberExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@LabourValueNumber", SqlDbType.Int).Value = LabourValueNumber
                .Add("@ExcludeIDLabourValue", SqlDbType.Int).Value = ExcludeIDLabourValue.Value
                .Add("@DoesExist", SqlDbType.Bit)
                .Item("@DoesExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CBool(locCmd.Parameters("@DoesExist").Value)
        End Using
    End Function

    Public Function LabourValues_Add(ByVal lvi As LabourValueInfo, ByVal CreatedByIDUser As Integer) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("LabourValues_Add", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = lvi.IDCostCenter
                .Add("@LabourValueNumber", SqlDbType.Int).Value = lvi.LabourValueNumber
                .Add("@LabourValueName", SqlDbType.NVarChar, 100).Value = lvi.LabourValueName
                .Add("@LabourValueDescription", SqlDbType.NVarChar, 4000).Value = lvi.LabourValueDescription.Value
                .Add("@TeHMin", SqlDbType.Float).Value = lvi.TeHMin
                .Add("@Dimension", SqlDbType.NVarChar, 100).Value = lvi.Dimension
                .Add("@IsActive", SqlDbType.Bit).Value = lvi.IsActive
                .Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate
                .Add("@CreatedByIDUser", SqlDbType.Int).Value = CreatedByIDUser
                .Add("@IDLabourValueNew", SqlDbType.Int)
                .Item("@IDLabourValueNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDLabourValueNew").Value)
        End Using

    End Function

    Public Function LabourValues_IsInUse(ByVal lvi As LabourValueInfo) As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("LabourValues_IsInUse", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDLabourValue", SqlDbType.Int).Value = lvi.IDLabourValue
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
                .Add("@IsInUse", SqlDbType.Bit)
                .Item("@IsInUse").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()
            Return CBool(locCmd.Parameters("@IsInUse").Value)
        End Using

    End Function

    Public Sub LabourValues_Delete(ByVal lvi As LabourValueInfo)
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("LabourValues_Delete", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDLabourValue", SqlDbType.Int).Value = lvi.IDLabourValue
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
            End With
            locCmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Function LabourValues_Edit(ByVal lvi As LabourValueInfo, ByVal LastEditedByIDUser As Integer) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("LabourValues_Edit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
                .Add("@IDLabourValue", SqlDbType.Int).Value = lvi.IDLabourValue
                .Add("@IDCostCenter", SqlDbType.Int).Value = lvi.IDCostCenter
                .Add("@LabourValueNumber", SqlDbType.Int).Value = lvi.LabourValueNumber
                .Add("@LabourValueName", SqlDbType.NVarChar, 100).Value = lvi.LabourValueName
                .Add("@LabourValueDescription", SqlDbType.NVarChar, 4000).Value = lvi.LabourValueDescription.Value
                .Add("@TeHMin", SqlDbType.Float).Value = lvi.TeHMin
                .Add("@Dimension", SqlDbType.NVarChar, 100).Value = lvi.Dimension
                .Add("@IsActive", SqlDbType.Bit).Value = lvi.IsActive
                .Add("@LastEditedByIDUser", SqlDbType.Int).Value = LastEditedByIDUser
                .Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = ConsiderHistoryMaintenance
                .Add("@IDLabourValueNew", SqlDbType.Int)
                .Item("@IDLabourValueNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDLabourValueNew").Value)
        End Using
    End Function

    Public ReadOnly Property LabourValueInfoCollection() As LabourValueInfoCollection
        Get
            Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
            If locConnection Is Nothing Then
                Return Nothing
            End If
            Using locConnection
                Dim locCommand As New SqlCommand( _
                "SELECT [LabourValues].*,[CostCenters].[CostCenterNo], [CostCenters].[CostCenterName], [CostCenters].[BaseValuePrecision], [CostCenters].[BaseValueSynonym] From [LabourValues] " & _
                "[LabourValues] INNER JOIN [CostCenters] ON " & _
                "[LabourValues].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " & _
                "[LabourValues].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
                " AND [LabourValues].[IsCurrent]='true'", locConnection)
                Dim locDR As SqlDataReader = locCommand.ExecuteReader()
                If locDR.HasRows Then
                    Dim locLic As New LabourValueInfoCollection
                    Do While locDR.Read
                        Dim locLabourValueInfo As New LabourValueInfo(locDR, True)
                        locLic.Add(locLabourValueInfo)
                    Loop
                    Return locLic
                Else
                    Return Nothing
                End If
            End Using
        End Get
    End Property

    Public ReadOnly Property LabourValueInfoCollection(ByVal OrderByString As String) As LabourValueInfoCollection
        Get
            Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
            If locConnection Is Nothing Then
                Return Nothing
            End If
            Using locConnection
                Dim locCommand As New SqlCommand( _
                "SELECT [LabourValues].*,[CostCenters].[CostCenterNo], [CostCenters].[CostCenterName], [CostCenters].[BaseValuePrecision], [CostCenters].[BaseValueSynonym] From [LabourValues] " & _
                "[LabourValues] INNER JOIN [CostCenters] ON " & _
                "[LabourValues].[IDCostCenter] = [CostCenters].[IDCostCenter] WHERE " & _
                "[LabourValues].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
                " AND [LabourValues].[IsCurrent]='true'" & _
                " ORDER BY [" & OrderByString & "]", locConnection)
                Dim locDR As SqlDataReader = locCommand.ExecuteReader()
                If locDR.HasRows Then
                    Dim locLic As New LabourValueInfoCollection
                    Do While locDR.Read
                        Dim locLabourValueInfo As New LabourValueInfo(locDR, True)
                        locLic.Add(locLabourValueInfo)
                    Loop
                    Return locLic
                Else
                    Return Nothing
                End If
            End Using
        End Get
    End Property

    Public Function GetLabourValueByID(ByVal IDSubsidiary As Integer, ByVal IDLabourValue As Integer) As LabourValueInfo
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCommand As New SqlCommand( _
                "SELECT * From [LabourValues] " & _
                " WHERE [IDSubsidiary]=" & IDSubsidiary & _
                " AND [IDLabourValue]=" & IDLabourValue & _
                " AND [IsCurrent]='true'", locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                locDR.Read()
                Return New LabourValueInfo(locDR)
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Function GetLabourValueByNumber(ByVal IDSubsidiary As Integer, ByVal LabourValueNumber As Integer) As LabourValueInfo
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCommand As New SqlCommand( _
                "SELECT * From [LabourValues] " & _
                " WHERE [IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
                " AND [LabourValueNumber]=" & LabourValueNumber & _
                " AND [IsCurrent]='true'", locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                locDR.Read()
                Return New LabourValueInfo(locDR)
            Else
                Return Nothing
            End If
        End Using
    End Function

End Class

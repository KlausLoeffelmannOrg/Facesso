Imports Activedev
Imports Facesso
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    Public Function WageGroups_DoesTokenExist(ByVal IDSubsidiary As Integer, _
                                              ByVal WageGroupToken As String, _
                                              ByVal ExcludeIDWageGroup As ADDBNullable(Of Integer)) _
                                              As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WageGroups_DoesTokenExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@WageGroupToken", SqlDbType.NVarChar, 20).Value = WageGroupToken
                .Add("@ExcludeIDWageGroup", SqlDbType.Int).Value = ExcludeIDWageGroup.Value
                .Add("@DoesExist", SqlDbType.Bit)
                .Item("@DoesExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CBool(locCmd.Parameters("@DoesExist").Value)
        End Using
    End Function

    Public Function WageGroups_Add(ByVal wgi As WageGroupInfo, ByVal CreatedByIDUser As Integer) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WageGroups_Add", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = wgi.IDSubsidiary
                .Add("@IDCurrency", SqlDbType.Int).Value = wgi.IDCurrency
                .Add("@IsTemplate", SqlDbType.Bit).Value = wgi.IsTemplate
                .Add("@WageGroupToken", SqlDbType.NVarChar, 20).Value = wgi.WageGroupToken
                .Add("@Comment", SqlDbType.NVarChar, 4000).Value = wgi.Comment.Value
                .Add("@HourlyRate", SqlDbType.Money).Value = wgi.HourlyRate
                .Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate
                .Add("@CreatedByIDUser", SqlDbType.Int).Value = CreatedByIDUser
                .Add("@IDWageGroupNew", SqlDbType.Int)
                .Item("@IDWageGroupNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDWageGroupNew").Value)
        End Using
    End Function

    Public Function WageGroups_Edit(ByVal wgi As WageGroupInfo, ByVal LastEditedByIDUser As Integer) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("WageGroups_Edit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = wgi.IDSubsidiary
                .Add("@IDCurrency", SqlDbType.Int).Value = wgi.IDCurrency
                .Add("@IDWageGroup", SqlDbType.Int).Value = wgi.IDWageGroup
                .Add("@IsTemplate", SqlDbType.Bit).Value = wgi.IsTemplate
                .Add("@WageGroupToken", SqlDbType.NVarChar, 20).Value = wgi.WageGroupToken
                .Add("@Comment", SqlDbType.NVarChar, 4000).Value = wgi.Comment.Value
                .Add("@HourlyRate", SqlDbType.Money).Value = wgi.HourlyRate
                .Add("@LastEditedByIDUser", SqlDbType.Int).Value = LastEditedByIDUser
                .Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = ConsiderHistoryMaintenance
                .Add("@IDWageGroupNew", SqlDbType.Int)
                .Item("@IDWageGroupNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDWageGroupNew").Value)
        End Using
    End Function

    Public ReadOnly Property WageGroupInfoCollection() As WageGroupInfoCollection
        Get
            Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
            If locConnection Is Nothing Then
                Return Nothing
            End If
            Using locConnection
                Dim locCommand As New SqlCommand( _
                "SELECT [WageGroups].*,[Currencies].[CurrencyToken] From [WageGroups] " & _
                "[WageGroups] INNER JOIN [Currencies] ON " & _
                "[WageGroups].[IDCurrency] = [Currencies].[IDCurrency] WHERE " & _
                "[WageGroups].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
                " AND [WageGroups].[IsCurrent]='true'", locConnection)
                Dim locDR As SqlDataReader = locCommand.ExecuteReader()
                If locDR.HasRows Then
                    Dim locWic As New WageGroupInfoCollection
                    Do While locDR.Read
                        Dim locWageGroupInfo As New WageGroupInfo(locDR, True)
                        locWic.Add(locWageGroupInfo)
                    Loop
                    Return locWic
                Else
                    Return Nothing
                End If
            End Using
        End Get
    End Property

    Public Function GetWageGroup(ByVal IDSubsidiary As Integer, ByVal IDWageGroup As Integer) As WageGroupInfo
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCommand As New SqlCommand( _
            "SELECT [WageGroups].*,[WageGroups].[CurrencyToken] From [WageGroups] " & _
            "[WageGroups] INNER JOIN [Currencies] ON " & _
            "[WageGroups].[IDCurrency] = [Currencies].[IDCurrency] WHERE " & _
            "[WageGroups].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
            " AND [WageGroups].[IDWageGroups]=" & IDWageGroup, locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                locDR.Read()
                Return New WageGroupInfo(locDR, True)
            Else
                Return Nothing
            End If
        End Using
    End Function
End Class

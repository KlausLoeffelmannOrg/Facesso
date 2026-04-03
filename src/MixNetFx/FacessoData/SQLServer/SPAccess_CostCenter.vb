Imports Activedev
Imports Facesso
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    ''' <summary>
    ''' Überprüft, ob die angegebene Kostenstelle für die Subsidiary schon existiert.
    ''' </summary>
    ''' <param name="IDSubsidiary">ID der verwendeten Subsidiary</param>
    ''' <param name="CostCenterNo">Kostenstellennr.</param>
    ''' <returns>True, wenn die Kostenstelle schon vorhanden war.</returns>
    ''' <remarks></remarks>
    Public Function CostCenters_DoesNumberExist(ByVal IDSubsidiary As Integer, _
                                                   ByVal CostCenterNo As Integer, _
                                                   ByVal ExcludeIDCostCenter As ADDBNullable(Of Integer)) _
                                                   As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("CostCenters_DoesNumberExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@CostCenterNo", SqlDbType.Int).Value = CostCenterNo
                .Add("@ExcludeIDCostCenter", SqlDbType.Int).Value = ExcludeIDCostCenter.Value
                .Add("@DoesExist", SqlDbType.Bit)
                .Item(3).Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CBool(locCmd.Parameters(3).Value)
        End Using
    End Function

    ''' <summary>
    ''' Fügt die in CostcenterInfo gespeicherte Kostenstelle der Datenbank hinzu.
    ''' </summary>
    ''' <param name="cci">CostcenterInfo mit den Daten für die Kostenstelle.</param>
    ''' <returns>ErrCode von der Datenbank.</returns>
    ''' <remarks>Die korrelierende Stored Procedure handelt die Versionskontrolle und schließt doppelte Kostenstellennr. aus.</remarks>
    Public Function CostCenters_Add(ByVal cci As CostcenterInfo, ByVal CreatedByIDUser As Integer) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("CostCenters_Add", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = cci.IDSubsidiary
                .Add("@CostCenterNo", SqlDbType.Int).Value = cci.CostCenterNo
                .Add("@CostCenterName", SqlDbType.NVarChar, 100).Value = cci.CostCenterName
                .Add("@CostCenterDescription", SqlDbType.NVarChar, 4000).Value = cci.CostCenterDescription.Value
                .Add("@IDCurrency", SqlDbType.NVarChar, 50).Value = cci.IDCurrency
                .Add("@IncentiveIndicatorSynonym", SqlDbType.NVarChar, 50).Value = cci.IncentiveIndicatorSynonym
                .Add("@IncentiveWageSynonym", SqlDbType.NVarChar, 50).Value = cci.IncentiveWageSynonym
                .Add("@IncentiveIndicatorDimension", SqlDbType.NVarChar, 50).Value = cci.IncentiveIndicatorDimension
                .Add("@IncentiveIndicatorPrecision", SqlDbType.TinyInt).Value = cci.IncentiveIndicatorPrecision
                .Add("@UseFixValuedBonus", SqlDbType.Bit).Value = cci.UseFixValuedBonus
                .Add("@IncentiveIndicatorFactor", SqlDbType.Decimal).Value = cci.IncentiveIndicatorFactor
                .Add("@BaseValuePrecision", SqlDbType.TinyInt).Value = cci.BaseValuePrecision
                .Add("@BaseValueSynonym", SqlDbType.NVarChar, 50).Value = cci.BaseValueSynonym
                .Add("@WasCurrentTo", SqlDbType.DateTime).Value = FacessoGeneric.OpenCurrentToDate
                .Add("@CreatedByIDUser", SqlDbType.Int).Value = CreatedByIDUser
                .Add("@IDCostCenterNew", SqlDbType.Int)
                .Item("@IDCostCenterNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDCostCenterNew").Value)
        End Using

    End Function

    Public Function CostCenters_Edit(ByVal cci As CostcenterInfo, ByVal LastEditedByIDUser As Integer) As Integer

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("CostCenters_Edit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = cci.IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = cci.IDCostCenter
                .Add("@CostCenterNo", SqlDbType.Int).Value = cci.CostCenterNo
                .Add("@CostCenterName", SqlDbType.NVarChar, 100).Value = cci.CostCenterName
                .Add("@CostCenterDescription", SqlDbType.NVarChar, 4000).Value = cci.CostCenterDescription.Value
                .Add("@IDCurrency", SqlDbType.NVarChar, 50).Value = cci.IDCurrency
                .Add("@IncentiveIndicatorSynonym", SqlDbType.NVarChar, 50).Value = cci.IncentiveIndicatorSynonym
                .Add("@IncentiveWageSynonym", SqlDbType.NVarChar, 50).Value = cci.IncentiveWageSynonym
                .Add("@IncentiveIndicatorDimension", SqlDbType.NVarChar, 50).Value = cci.IncentiveIndicatorDimension
                .Add("@IncentiveIndicatorPrecision", SqlDbType.TinyInt).Value = cci.IncentiveIndicatorPrecision
                .Add("@UseFixValuedBonus", SqlDbType.Bit).Value = cci.UseFixValuedBonus
                .Add("@IncentiveIndicatorFactor", SqlDbType.Decimal).Value = cci.IncentiveIndicatorFactor
                .Add("@BaseValuePrecision", SqlDbType.TinyInt).Value = cci.BaseValuePrecision
                .Add("@BaseValueSynonym", SqlDbType.NVarChar, 50).Value = cci.BaseValueSynonym
                .Add("@LastEditedByIDUser", SqlDbType.Int).Value = LastEditedByIDUser
                .Add("@ConsiderHistoryMaintenance", SqlDbType.Bit).Value = ConsiderHistoryMaintenance
                .Add("@IDCostCenterNew", SqlDbType.Int)
                .Item("@IDCostCenterNew").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteReader()
            Return CInt(locCmd.Parameters("@IDCostCenterNew").Value)
        End Using
    End Function

    Public Function CostCenters_IsInUse(ByVal lvi As CostcenterInfo) As Boolean

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("CostCenters_IsInUse", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDCostCenter", SqlDbType.Int).Value = lvi.IDCostCenter
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
                .Add("@IsInUse", SqlDbType.Bit)
                .Item("@IsInUse").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()
            Return CBool(locCmd.Parameters("@IsInUse").Value)
        End Using

    End Function

    Public Sub CostCenters_Delete(ByVal lvi As CostcenterInfo)
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("CostCenters_Delete", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDCostCenter", SqlDbType.Int).Value = lvi.IDCostCenter
                .Add("@IDSubsidiary", SqlDbType.Int).Value = lvi.IDSubsidiary
            End With
            locCmd.ExecuteNonQuery()
        End Using
    End Sub

    Public ReadOnly Property CostCenterInfoItems() As CostcenterInfoItems
        Get
            Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
            If locConnection Is Nothing Then
                Return Nothing
            End If
            Using locConnection
                Dim locCommand As New SqlCommand( _
                "SELECT [CostCenters].*,[Currencies].[CurrencyToken] From [CostCenters] " & _
                "[CostCenters] INNER JOIN [Currencies] ON " & _
                "[CostCenters].[IDCurrency] = [Currencies].[IDCurrency] WHERE " & _
                "[CostCenters].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
                " AND [CostCenters].[IsCurrent]='true'", locConnection)
                Dim locDR As SqlDataReader = locCommand.ExecuteReader()
                If locDR.HasRows Then
                    Dim locUIC As New CostcenterInfoItems
                    Do While locDR.Read
                        Dim locCostcenterInfo As New CostcenterInfo(locDR, True)
                        locUIC.Add(locCostcenterInfo)
                    Loop
                    Return locUIC
                Else
                    Return Nothing
                End If
            End Using
        End Get
    End Property

    Public Function GetCostCenter(ByVal IDSubsidiary As Integer, ByVal IDCostCenter As Integer) As CostcenterInfo
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCommand As New SqlCommand( _
            "SELECT [CostCenters].*,[Currencies].[CurrencyToken] From [CostCenters] " & _
            "[CostCenters] INNER JOIN [Currencies] ON " & _
            "[CostCenters].[IDCurrency] = [Currencies].[IDCurrency] WHERE " & _
            "[CostCenters].[IDSubsidiary]=" & FacessoGeneric.LoginInfo.IDSubsidiary & _
            " AND [CostCenters].[IDCostCenter]=" & IDCostCenter, locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                locDR.Read()
                Return New CostcenterInfo(locDR, True)
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Function GetCurrentBaseCostCenter(ByVal IDSubsidiary As Integer) As CostcenterInfo
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCommand As New SqlCommand( _
            "SELECT [CostCenters].*,[Currencies].[CurrencyToken] From [CostCenters] " & _
            "[CostCenters] INNER JOIN [Currencies] ON " & _
            "[CostCenters].[IDCurrency] = [Currencies].[IDCurrency] WHERE " & _
            "[CostCenters].[IDSubsidiary]=" & IDSubsidiary & _
            " AND [CostCenters].[IDCostCenterInternal]=" & 0, locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            locDR.Read()
            Return New CostcenterInfo(locDR, True)
        End Using
    End Function
End Class

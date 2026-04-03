Imports Activedev
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    Public Sub BonusList_AddEntry(ByVal bli As BonusListItem, ByVal IDUserCreated As Integer)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("BonusList_AddEntry", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = bli.IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = bli.CostCenterInfo.IDCostCenter
                .Add("@DegreeOfTime", SqlDbType.Float).Value = bli.DegreeOfTime
                .Add("@Percentage", SqlDbType.Float).Value = bli.Percentage
                .Add("@AbsoluteValue", SqlDbType.Float).Value = bli.AbsoluteValue
                .Add("@IDUserCreated", SqlDbType.Int).Value = IDUserCreated
            End With
            locCmd.ExecuteReader()
        End Using
    End Sub

    Public Sub BonusList_CreateBaseList(ByVal IDSubsidiary As Integer, _
                                       ByVal IDCostCenter As Integer, _
                                       ByVal IDUserCreated As Integer)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("BonusList_CreateBaseList", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = IDCostCenter
                .Add("@IDUserCreated", SqlDbType.Int).Value = IDUserCreated
            End With
            locCmd.ExecuteReader()
        End Using
    End Sub

    Public Sub BonusList_DeleteList(ByVal IDSubsidiary As Integer, _
                                       ByVal IDCostCenter As Integer, _
                                       ByVal IDUserCalled As Integer)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("BonusList_DeleteList", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = IDCostCenter
                .Add("@IDUserCalled", SqlDbType.Int).Value = IDUserCalled
            End With
            locCmd.ExecuteReader()
        End Using
    End Sub

    Public Sub BonusList_FromBaseCostCenter(ByVal IDSubsidiary As Integer, _
                                               ByVal IDBaseCostCenter As Integer, _
                                               ByVal ForIDCostCenter As Integer, _
                                               ByVal IDUserCalled As Integer)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("BonusList_FromBaseCostCenter", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDBaseCostCenter", SqlDbType.Int).Value = IDBaseCostCenter
                .Add("@IDCostCenter", SqlDbType.Int).Value = ForIDCostCenter
                .Add("@IDUserCalled", SqlDbType.Int).Value = IDUserCalled
            End With
            locCmd.ExecuteReader()
        End Using
    End Sub

    Public Sub BonusList_ReplaceEntry(ByVal bli As BonusListItem, ByVal IDUserCalled As Integer)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("BonusList_ReplaceEntry", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = bli.IDSubsidiary
                .Add("@IDCostCenter", SqlDbType.Int).Value = bli.CostCenterInfo.IDCostCenter
                .Add("@DegreeOfTime", SqlDbType.Float).Value = bli.DegreeOfTime
                .Add("@Percentage", SqlDbType.Float).Value = bli.Percentage
                .Add("@AbsoluteValue", SqlDbType.Float).Value = bli.AbsoluteValue
                .Add("@IDUserCalled", SqlDbType.Int).Value = IDUserCalled
            End With
            locCmd.ExecuteReader()
        End Using
    End Sub

    Public Function BonusList_GetCostCenterInfoCollection(ByVal IDSubsidiary As Integer, ByVal Invert As Boolean) As CostcenterInfoItems
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCommandString As String = "SELECT DISTINCT CostCenters.*" & _
                    "FROM CostCenters INNER JOIN " & _
                     "BonusLists ON BonusLists.IDSubsidiary = CostCenters.IDSubsidiary "
            If Invert Then
                locCommandString &= "AND BonusLists.IDCostCenter <> CostCenters.IDCostCenter WHERE CostCenters.IDSubsidiary=" & IDSubsidiary
            Else
                locCommandString &= "AND BonusLists.IDCostCenter = CostCenters.IDCostCenter WHERE CostCenters.IDSubsidiary=" & IDSubsidiary
            End If

            Dim locCommand As New SqlCommand(locCommandString, locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                Dim locUIC As New CostcenterInfoItems
                Do While locDR.Read
                    Dim locCostcenterInfo As New CostcenterInfo(locDR)
                    locUIC.Add(locCostcenterInfo)
                Loop
                Return locUIC
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Function BonusList_GetBonusListItems(ByVal IDSubsidiary As Integer, ByVal IDCostCenter As Integer) As BonusListItems
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return Nothing
        End If
        Using locConnection
            Dim locCommandString As String = "SELECT [BonusList].* FROM [BonusList] INNER JOIN [BonusLists] " & _
                      "ON BonusList.IDBonusLists = BonusLists.IDBonusLists AND BonusList.IDSubsidiary = BonusLists.IDSubsidiary " & _
                      " WHERE [BonusLists].[IDSubsidiary]=" & IDSubsidiary & " AND [BonusLists].[IDCostCenter]=" & IDCostCenter & _
                      " ORDER BY [DegreeOfTime]"

            Dim locCommand As New SqlCommand(locCommandString, locConnection)
            Dim locCci As CostcenterInfo = SPAccess.GetInstance.GetCostCenter(IDSubsidiary, IDCostCenter)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                Dim locBlis As New BonusListItems
                Do While locDR.Read
                    Dim locBli As New BonusListItem(locDR, locCci)
                    locBlis.Add(locBli)
                Loop
                Return locBlis
            Else
                Return Nothing
            End If
        End Using
    End Function
End Class

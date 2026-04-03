Imports Activedev
Imports Facesso.Data
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    Friend Sub TimeLog_DeleteItemFromDatabase(ByVal WorkGroup As WorkGroupInfo, ByVal EmpTimeLogItem As EmployeeTimeLogInfoItem)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("TimeLog_DeleteItem", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = WorkGroup.IDSubsidiary
                .Add("@IDTimeLog", SqlDbType.BigInt).Value = EmpTimeLogItem.IDTimeLog
            End With
            locCmd.ExecuteNonQuery()
        End Using
    End Sub

    Friend Sub GetEmployeeTimeLog(ByVal TimeLogItems As EmployeeTimeLogInfo)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        TimeLogItems.Clear()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("TimeLog_GetLogItemsForShiftDate", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = TimeLogItems.WorkGroup.IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = TimeLogItems.WorkGroup.IDWorkGroup
                .Add("@ProductionDate", SqlDbType.DateTime).Value = TimeLogItems.ProductionDate
                .Add("@Shift", SqlDbType.TinyInt).Value = TimeLogItems.Shift
            End With
            Dim locDR As SqlDataReader = locCmd.ExecuteReader()

            Do While locDR.Read
                Dim locTimeLogItem As New EmployeeTimeLogInfoItem(locDR, True)
                TimeLogItems.Add(locTimeLogItem)
            Loop
        End Using
    End Sub

    Friend Sub GetEmployeeTimelog(ByVal Employee As EmployeeInfo, ByVal Startdate As Date, ByVal Enddate As Date, ByVal TimeLogItems As EmployeeTimeLogInfo)
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        TimeLogItems.Clear()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("TimeLog_GetLogItemsForRange", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = Employee.IDSubsidiary
                .Add("@IDEmployee", SqlDbType.Int).Value = Employee.IDEmployee
                .Add("@StartDate", SqlDbType.DateTime).Value = Startdate
                .Add("@EndDate", SqlDbType.DateTime).Value = Enddate
            End With
            Dim locDR As SqlDataReader = locCmd.ExecuteReader()

            Do While locDR.Read
                Dim locTimeLogItem As New EmployeeTimeLogInfoItem(locDR, True)
                TimeLogItems.Add(locTimeLogItem)
            Loop
        End Using
    End Sub

    Friend Sub TimeLog_GetOverlappingLogItems(ByVal EmployeeInfo As EmployeeInfo, _
                                             ByVal ShiftStart As Date, _
                                             ByVal ShiftEnd As Date, _
                                             ByVal OverlapsInfo As OverlapsInfo, _
                                             ByVal ExcludeIDTimelog As ADDBNullable(Of Long))


        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("TimeLog_GetOverlappingLogItems", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = EmployeeInfo.IDSubsidiary
                .Add("@IDEmployee", SqlDbType.Int).Value = EmployeeInfo.IDEmployee
                .Add("@ShiftStart", SqlDbType.DateTime).Value = ShiftStart
                .Add("@ShiftEnd", SqlDbType.DateTime).Value = ShiftEnd
                .Add("@ExcludeIDTimeLog", SqlDbType.BigInt).Value = ExcludeIDTimelog.Value
            End With
            Dim locDR As SqlDataReader = locCmd.ExecuteReader()

            Do While locDR.Read
                Dim locItem As New OverlapsInfoItem(EmployeeInfo, locDR)
                OverlapsInfo.Add(locItem)
            Loop
        End Using
    End Sub

    Friend Function TimeLog_AddEditEmployeeTimeLogItems(ByVal TimeLogItems As EmployeeTimeLogInfo, ByVal IDUser As Integer, ByVal ReturnResultSet As Boolean) As EmployeeTimeLogInfo
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection
            Dim locCmd As SqlCommand
            Dim locTicket As DateTime = Date.Now

            For Each locItem As EmployeeTimeLogInfoItem In TimeLogItems
                locCmd = New SqlCommand("TimeLog_AddItemsForAddEdit", locConnection)
                locCmd.CommandType = CommandType.StoredProcedure
                If locItem.Deleted And locItem.IDTimeLog < 1 Then Continue For

                With locCmd.Parameters
                    .Add("@IDSubsidiary", SqlDbType.Int).Value = TimeLogItems.WorkGroup.IDSubsidiary
                    .Add("@IDTimeLog", SqlDbType.BigInt).Value = locItem.IDTimeLog
                    .Add("@IDUser", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDUser
                    .Add("@IDWorkGroup", SqlDbType.Int).Value = locItem.IDWorkGroup
                    .Add("@IDEmployee", SqlDbType.Int).Value = locItem.EmployeeInfo.IDEmployee
                    .Add("@ProductionDate", SqlDbType.DateTime).Value = locItem.ProductionDate
                    .Add("@Shift", SqlDbType.TinyInt).Value = locItem.Shift
                    .Add("@ShiftStart", SqlDbType.DateTime).Value = locItem.ShiftStart
                    .Add("@ShiftEnd", SqlDbType.DateTime).Value = locItem.ShiftEnd
                    .Add("@WorkBreak", SqlDbType.Int).Value = locItem.WorkBreak
                    .Add("@DownTime", SqlDbType.Int).Value = locItem.DownTime
                    .Add("@Handicap", SqlDbType.Int).Value = locItem.Handicap
                    .Add("@InsertedByInterface", SqlDbType.Bit).Value = locItem.InsertedByInterface
                    .Add("@ManuallyEdited", SqlDbType.Bit).Value = locItem.ManuallyEdited
                    .Add("@LastEditedByIDUser", SqlDbType.Int).Value = IDUser
                    .Add("@Deleted", SqlDbType.Bit).Value = locItem.Deleted
                    .Add("@Ticket", SqlDbType.DateTime).Value = locTicket
                End With
                locCmd.ExecuteNonQuery()
            Next

            locCmd = New SqlCommand("TimeLog_HandleAddEdit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = TimeLogItems.WorkGroup.IDSubsidiary
                .Add("@IDUser", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDUser
                .Add("@Ticket", SqlDbType.DateTime).Value = locTicket
            End With
            locCmd.CommandTimeout = 300
            locCmd.ExecuteNonQuery()

            If ReturnResultSet Then
                locCmd = New SqlCommand("TimeLog_GetLogItemsForShiftDate", locConnection)
                locCmd.CommandType = CommandType.StoredProcedure
                TimeLogItems.Clear()

                With locCmd.Parameters
                    .Add("@IDSubsidiary", SqlDbType.Int).Value = TimeLogItems.WorkGroup.IDSubsidiary
                    .Add("@IDWorkGroup", SqlDbType.Int).Value = TimeLogItems.WorkGroup.IDWorkGroup
                    .Add("@ProductionDate", SqlDbType.DateTime).Value = TimeLogItems.ProductionDate
                    .Add("@Shift", SqlDbType.TinyInt).Value = TimeLogItems.Shift
                End With
                Dim locDR As SqlDataReader = locCmd.ExecuteReader()

                Do While locDR.Read
                    Dim locTimeLogItem As New EmployeeTimeLogInfoItem(locDR, True)
                    TimeLogItems.Add(locTimeLogItem)
                Loop
                Return TimeLogItems
            Else
                Return Nothing
            End If
        End Using
    End Function

    Friend Sub TimeLog_GetEmployeeResult(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
                    ByVal Ticket As Date, ByVal Employee As EmployeeInfo, ByVal TimeLogItems As EmployeeTimeLogInfo)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        TimeLogItems.Clear()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("TimeLog_Analysis_GetEmployeeResult", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDUser", SqlDbType.Int).Value = IDUser
                .Add("@Ticket", SqlDbType.DateTime).Value = Ticket
                .Add("@IDEmployee", SqlDbType.Int).Value = Employee.IDEmployee
            End With
            Dim locDR As SqlDataReader = locCmd.ExecuteReader()

            Do While locDR.Read
                Dim locTimeLogItem As New EmployeeTimeLogInfoItem(locDR, Employee)
                TimeLogItems.Add(locTimeLogItem)
            Loop
        End Using
    End Sub
End Class

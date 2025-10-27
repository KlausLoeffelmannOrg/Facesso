Imports Activedev
Imports Facesso.Data
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    Friend Sub ProductionData_GetProductionData(ByVal ProductionItems As ProductionData, ByVal OrderBy As Byte)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        ProductionItems.Clear()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("ProductionData_GetProductionData", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = ProductionItems.WorkGroup.IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = ProductionItems.WorkGroup.IDWorkGroup
                .Add("@ProductionDate", SqlDbType.DateTime).Value = ProductionItems.ProductionDate
                .Add("@Shift", SqlDbType.TinyInt).Value = ProductionItems.Shift
                .Add("@IDProductionData", SqlDbType.BigInt) : .Item("@IDProductionData").Direction = ParameterDirection.Output
                .Add("@TotalReferenceIWT", SqlDbType.Float) : .Item("@TotalReferenceIWT").Direction = ParameterDirection.Output
                .Add("@DegreeOfTime", SqlDbType.Float) : .Item("@DegreeOfTime").Direction = ParameterDirection.Output
                .Add("@DegreeOfTimeAdj", SqlDbType.Float) : .Item("@DegreeOfTimeAdj").Direction = ParameterDirection.Output
                .Add("@InsertedByInterface", SqlDbType.Bit) : .Item("@InsertedByInterface").Direction = ParameterDirection.Output
                .Add("@IsSuspended", SqlDbType.Bit) : .Item("@IsSuspended").Direction = ParameterDirection.Output
                .Add("@LastEdited", SqlDbType.DateTime) : .Item("@LastEdited").Direction = ParameterDirection.Output
                .Add("@LastEditedByIDUser", SqlDbType.Int) : .Item("@LastEditedByIDUser").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()

            With ProductionItems
                If locCmd.Parameters("@IDProductionData").Value Is DBNull.Value Then
                    .DoDataExist = False
                Else
                    .DoDataExist = True
                    .IDProductionData = CLng(locCmd.Parameters("@IDProductionData").Value)
                    .DegreeOfTime = CDbl(locCmd.Parameters("@DegreeOfTime").Value)
                    .DegreeOfTimeAdj = CDbl(locCmd.Parameters("@DegreeOfTimeAdj").Value)
                    .InsertedByInterface = CBool(locCmd.Parameters("@InsertedByInterface").Value)
                    .IsSuspended = CBool(locCmd.Parameters("@IsSuspended").Value)
                    .LastEdited = CDate(locCmd.Parameters("@LastEdited").Value)
                    .LastEditedByIDUser = CInt(locCmd.Parameters("@LastEditedByIDUser").Value)
                End If
            End With

            locCmd = New SqlCommand("ProductionData_GetProductionOrTemplateItems", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = ProductionItems.WorkGroup.IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = ProductionItems.WorkGroup.IDWorkGroup
                .Add("@ProductionDate", SqlDbType.DateTime).Value = ProductionItems.ProductionDate
                .Add("@Shift", SqlDbType.TinyInt).Value = ProductionItems.Shift
                .Add("@OrderBy", SqlDbType.TinyInt).Value = OrderBy
                .Add("@DoExist", SqlDbType.Bit) : .Item("@DoExist").Direction = ParameterDirection.Output
                .Add("@IDProductionData", SqlDbType.BigInt) : .Item("@IDProductionData").Direction = ParameterDirection.Output
                .Add("@TotalReferenceIWT", SqlDbType.Float) : .Item("@TotalReferenceIWT").Direction = ParameterDirection.Output
                .Add("@DegreeOfTime", SqlDbType.Float) : .Item("@DegreeOfTime").Direction = ParameterDirection.Output
                .Add("@DegreeOfTimeAdj", SqlDbType.Float) : .Item("@DegreeOfTimeAdj").Direction = ParameterDirection.Output
                .Add("@InsertedByInterface", SqlDbType.Bit) : .Item("@InsertedByInterface").Direction = ParameterDirection.Output
                .Add("@IsSuspended", SqlDbType.Bit) : .Item("@IsSuspended").Direction = ParameterDirection.Output
                .Add("@LastEdited", SqlDbType.DateTime) : .Item("@LastEdited").Direction = ParameterDirection.Output
                .Add("@LastEditedByIDUser", SqlDbType.Int) : .Item("@LastEditedByIDUser").Direction = ParameterDirection.Output
            End With
            locCmd.CommandTimeout = 5 * 60
            Dim locDR As SqlDataReader = locCmd.ExecuteReader()

            Do While locDR.Read
                Dim locProductionItem As New ProductionDataItem(locDR)
                ProductionItems.Add(locProductionItem)
            Loop
        End Using
    End Sub

    Friend Function ProductionData_AddEditShiftDateWorkResults(ByVal SdwResults As ShiftDateWorkResultInfo) As ShiftDateWorkResultInfo
        SdwResults.EmployeeTimeLogItems = TimeLog_AddEditEmployeeTimeLogItems(SdwResults.EmployeeTimeLogItems, _
                                    FacessoGeneric.LoginInfo.IDUser, True)
        SdwResults.ProductionData = ProductionData_AddEditProductionData(SdwResults.ProductionData, _
                                    FacessoGeneric.LoginInfo.IDUser, True)
        SdwResults.ProductionData.ResetSavingState()
        Return SdwResults
    End Function

    Friend Function ProductionData_AddEditProductionData(ByVal ProdData As ProductionData, ByVal IDUser As Integer, ByVal ReturnResultSet As Boolean) As ProductionData
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("ProductionData_AddEdit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = ProdData.WorkGroup.IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = ProdData.WorkGroup.IDWorkGroup
                .Add("@ProductionDate", SqlDbType.DateTime).Value = ProdData.ProductionDate
                .Add("@Shift", SqlDbType.TinyInt).Value = ProdData.Shift
                .Add("@InsertedByInterface", SqlDbType.Bit).Value = False
                .Add("@IsSuspended", SqlDbType.Bit).Value = False
                .Add("@LastEditedByIDUser", SqlDbType.Int).Value = ProdData.LastEditedByIDUser
                .Add("@IDProductionData", SqlDbType.BigInt).Value = ProdData.IDProductionData
                .Item("@IDProductionData").Direction = ParameterDirection.InputOutput
            End With
            locCmd.ExecuteNonQuery()
            ProdData.IDProductionData = CLng(locCmd.Parameters("@IDProductionData").Value)

            For Each locPI As ProductionDataItem In ProdData
                locCmd = New SqlCommand("ProductionData_AddItemsForAddEdit", locConnection)
                locCmd.CommandType = CommandType.StoredProcedure

                With locCmd.Parameters
                    .Add("@IDSubsidiary", SqlDbType.Int).Value = ProdData.WorkGroup.IDSubsidiary
                    .Add("@IDProductionData", SqlDbType.BigInt).Value = ProdData.IDProductionData
                    .Add("@IDProductionDataItem", SqlDbType.BigInt).Value = locPI.IDProductionDataItem
                    .Add("@IDUser", SqlDbType.Int).Value = IDUser
                    .Add("@IDLabourValue", SqlDbType.Int).Value = locPI.LabourValue.IDLabourValue
                    .Add("@IDArticle", SqlDbType.Int).Value = 0
                    .Add("@Amount", SqlDbType.Float).Value = locPI.Amount
                    .Add("@AmountViaInterface", SqlDbType.Float).Value = locPI.AmountViaInterface
                    .Add("@OrdinalNumber", SqlDbType.Int).Value = locPI.OrdinalNo
                    .Add("@ManuallyEdited", SqlDbType.Bit).Value = locPI.ManuallyEdited
                End With
                locCmd.ExecuteNonQuery()
            Next

            locCmd = New SqlCommand("ProductionData_HandleAddEdit", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure
            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = ProdData.WorkGroup.IDSubsidiary
                .Add("@IDProductionData", SqlDbType.BigInt).Value = ProdData.IDProductionData
                .Add("@IDUser", SqlDbType.Int).Value = IDUser
                .Add("@ReturnResultSet", SqlDbType.Bit).Value = ReturnResultSet
            End With
            locCmd.CommandTimeout = 60
            locCmd.ExecuteNonQuery()
            If ReturnResultSet Then
                ProductionData_GetProductionData(ProdData, 1)
                Return ProdData
            Else
                Return Nothing
            End If
        End Using
    End Function

    Friend Sub ProductionData_GetWorkGroupAnalysisItem(ByVal AnalysisItem As WorkGroupAnalysisInfoItem, ByVal IDSubsidiary As Integer, ByVal cp As CombinedParametersInfo)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("ProductionData_Analysis_GetShiftDateResultSet", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = cp.WorkGroup.IDWorkGroup
                .Add("@ProductionDate", SqlDbType.DateTime).Value = cp.ProductionDate
                .Add("@Shift", SqlDbType.TinyInt).Value = cp.Shift
            End With
            Dim locDR As SqlDataReader = locCmd.ExecuteReader
            If locDR.HasRows Then
                locDR.Read()
                WorkGroupAnalysisItem_AssignData(locDR, AnalysisItem)
                AnalysisItem.WorkGroup = New WorkGroupInfo(locDR, WorkGroupInfoItemsGetType.JoinedWithCostCenter)
            Else
                AnalysisItem.HasData = False
            End If
        End Using
    End Sub

    Friend Function ProductionData_GetWorkGroupAnalysisItems(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
                            ByVal Ticket As DateTime, ByVal WorkGroup As WorkGroupInfo, _
                            ByVal AnalysisInfo As WorkGroupAnalysisInfo) As Boolean
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("ProductionData_Analysis_GetPeriodResultSet", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = WorkGroup.IDWorkGroup
                .Add("@IDUser", SqlDbType.Int).Value = IDUser
                .Add("@Ticket", SqlDbType.DateTime).Value = Ticket
            End With
            Dim locDR As SqlDataReader = locCmd.ExecuteReader
            Do While locDR.Read
                Dim locItem As New WorkGroupAnalysisInfoItem()
                WorkGroupAnalysisItem_AssignData(locDR, locItem)
                locItem.WorkGroup = WorkGroup
                AnalysisInfo.Add(locItem)
            Loop
        End Using
        Return AnalysisInfo.Count > 0
    End Function

    Private Sub WorkGroupAnalysisItem_AssignData(ByVal SqlDr As SqlDataReader, ByVal AnalysisItem As WorkGroupAnalysisInfoItem)
        With AnalysisItem
            .HasData = True
            .TotalDownTime = SqlDr.GetDouble(SqlDr.GetOrdinal("TotalDownTime"))
            .TotalReferenceIWT = SqlDr.GetDouble(SqlDr.GetOrdinal("TotalReferenceIWT"))
            .TotalEffectiveIWT = SqlDr.GetDouble(SqlDr.GetOrdinal("TotalEffectiveIWT"))
            .TotalEffectiveIWTAdj = SqlDr.GetDouble(SqlDr.GetOrdinal("TotalEffectiveIWTAdj"))
            .TotalWorkBreakTime = SqlDr.GetDouble(SqlDr.GetOrdinal("TotalWorkBreakTime"))
            .DegreeOfTime = SqlDr.GetDouble(SqlDr.GetOrdinal("DegreeOfTime"))
            .DegreeOfTimeAdj = SqlDr.GetDouble(SqlDr.GetOrdinal("DegreeOfTimeAdj"))
            .IDProductionData = SqlDr.GetInt64(SqlDr.GetOrdinal("IDProductionData"))
            .IsSuspended = SqlDr.GetBoolean(SqlDr.GetOrdinal("IsSuspended"))
            .ProductionDate = SqlDr.GetDateTime(SqlDr.GetOrdinal("ProductionDate"))
            .Shift = SqlDr.GetByte(SqlDr.GetOrdinal("Shift"))
            If .DegreeOfTime = -2 Or .TotalDownTime = -1 Or .TotalWorkBreakTime = -1 Or .TotalEffectiveIWT = -1 Then
                .TotalDownTime = 0
                .TotalReferenceIWT = 0
                .TotalEffectiveIWT = 0
                .TotalEffectiveIWTAdj = 0
                .TotalWorkBreakTime = 0
                .DegreeOfTime = 0
                .DegreeOfTimeAdj = 0
            End If
        End With
    End Sub

    Friend Sub ProductionData_PrepareProductionDates(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
                                                ByVal Ticket As DateTime, ByVal Period As ProductionPeriod)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("ProductionData_Analysis_AddProductionDateItem", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            For Each locItem As ProductionPeriodItem In Period

                With locCmd.Parameters
                    .Clear()
                    .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                    .Add("@IDUser", SqlDbType.Int).Value = IDUser
                    .Add("@Ticket", SqlDbType.DateTime).Value = Ticket
                    .Add("@ProductionDate", SqlDbType.DateTime).Value = locItem.ProductionDate
                    .Add("@Shift", SqlDbType.TinyInt).Value = locItem.Shift
                End With
                locCmd.ExecuteScalar()
            Next
        End Using
    End Sub

    Friend Sub ProductionData_DeleteProductionDateItems(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
                                            ByVal Ticket As DateTime)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("ProductionData_Analysis_DeleteProductionDateItems", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Clear()
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDUser", SqlDbType.Int).Value = IDUser
                .Add("@Ticket", SqlDbType.DateTime).Value = Ticket
            End With
            locCmd.ExecuteScalar()
        End Using
    End Sub

    Friend Function ProductionData_DeleteItems(ByVal IDSubsidiary As Integer, _
        ByVal Workgroup As WorkGroupInfo, ByVal ProductionDate As Date, ByVal Shift As Byte) As Boolean

        'Ermitteln der ID für diesen Tag
        Dim locIDProductionData As Long
        Dim locReader As SqlDataReader

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("SELECT IDProductionData FROM ProductionData WHERE " & _
                "[IDWorkgroup]=" & Workgroup.IDWorkGroup & " AND " & _
                "[ProductionDate]=CONVERT(DateTime,'" & ProductionDate.ToString("dd.MM.yyyy") & "',104) AND " & _
                "[Shift]=" & Shift, locConnection)

            locReader = locCmd.ExecuteReader()
            If Not locReader.HasRows Then
                Return False
            End If

            locReader.Read()
            locIDProductionData = locReader.GetInt64(locReader.GetOrdinal("IDProductionData"))

            locReader.Close()

            locCmd = New SqlCommand("DELETE FROM ProductionDataItems WHERE IDProductionData=" & locIDProductionData, locConnection)
            locCmd.ExecuteScalar()

            locCmd = New SqlCommand("DELETE FROM ProductionData WHERE IDProductionData=" & locIDProductionData, locConnection)
            locCmd.ExecuteScalar()

            Return True

        End Using
    End Function

    ''' <summary>
    ''' Ermittelt die Produktionsdaten für eine Produktiv-Site in einem bestimmten Zeitraum 
    ''' und liefert einen DataReader mit den entsprechenden Daten zurück.
    ''' </summary>
    ''' <param name="IDSubsidiary">Die Subsidarität, auf die sich die Abfrage bezieht.</param>
    ''' <param name="IDWorkGroup">Die Produktiv-Site, auf die sich die Abfrage bezieht.</param>
    ''' <param name="FromDate">Das Startdatum des Zeitraums, in dem die Mengen ermittelt werden sollen.</param>
    ''' <param name="ToDate">Das Enddatum des Zeitraums, in dem die Mengen ermittelt werden sollen.</param>
    ''' <param name="pda">Die Auflistung, der die Ergebnisse dieser Mengenanalyse übergeben werden</param>
    ''' <remarks></remarks>
    Friend Sub ProductionData_CollectAmounts(ByVal IDSubsidiary As Integer, ByVal IDWorkGroup As Integer, _
                                                  ByVal FromDate As Date, ByVal ToDate As Date, ByVal pda As WorkgroupProductionDataAmounts)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection
            Dim locCmd As New SqlCommand(My.Resources.SELECT_ProductionDataAmount, locConnection)

            With locCmd.Parameters
                .Clear()
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
                .Add("@IDWorkGroup", SqlDbType.Int).Value = IDWorkGroup
                .Add("@FromDate", SqlDbType.DateTime).Value = FromDate
                .Add("@ToDate", SqlDbType.DateTime).Value = ToDate
            End With

            Dim locReader As SqlDataReader = locCmd.ExecuteReader
            Do While locReader.Read
                Dim locLabourValue As New LabourValueInfo(locReader, True)
                pda.Add(New WorkgroupProductionDataAmount(locReader.GetDouble(locReader.GetOrdinal("AmountTotal")), New LabourValueInfo(locReader, True)))
            Loop
        End Using
    End Sub
End Class

Imports Activedev
Imports Facesso.Data
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    Public Function Basedata_DoEmployeesExist() As Boolean
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("Basedata_DoEmployeesExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary
                .Add("@DoExist", SqlDbType.Bit) : locCmd.Parameters("@DoExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()
            Return Convert.ToBoolean(locCmd.Parameters("@DoExist").Value)
        End Using

    End Function

    Public Function Basedata_DoWorkGroupsExist() As Boolean
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("Basedata_DoWorkGroupsExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary
                .Add("@DoExist", SqlDbType.Bit) : locCmd.Parameters("@DoExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()
            Return Convert.ToBoolean(locCmd.Parameters("@DoExist").Value)
        End Using

    End Function

    Public Function Basedata_DoLabourValuesExist() As Boolean
        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()

        If locConnection Is Nothing Then
            Dim locUp As New FacessoSqlDbException("Could not reach Facesso-Database while running StoredProcedure GetProductionItems", Nothing)
            Throw locUp
        End If

        Using locConnection

            Dim locCmd As New SqlCommand("Basedata_DoLabourValuesExist", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = FacessoGeneric.LoginInfo.IDSubsidiary
                .Add("@DoExist", SqlDbType.Bit) : locCmd.Parameters("@DoExist").Direction = ParameterDirection.Output
            End With
            locCmd.ExecuteNonQuery()
            Return Convert.ToBoolean(locCmd.Parameters("@DoExist").Value)
        End Using

    End Function
End Class

Imports ActiveDev
Imports ActiveDev.Controls
Imports System.Data.SqlClient
Imports System.Windows.Forms

Friend Class Fac_FunctionsInternal

    Private Sub New()
    End Sub

    Friend Shared Sub AddCostCentersToADNullableIdOrIndexComboBox(ByVal cb As ADNullableIdOrIndexComboBox)

        Dim locSqlConn As New SqlConnection(FacessoGeneric.SQLConnectionString)
        locSqlConn.Open()

        Using locSqlConn
            Dim locCommand As New SqlCommand("SELECT * From [Costcenters] WHERE [IDSubsidiary]=" _
                    & FacessoGeneric.LoginInfo.IDSubsidiary & " AND [IsCurrent]='true'", locSqlConn)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                Do While locDR.Read
                    Dim locItem As New ADComboBoxItem(locDR.GetInt32(locDR.GetOrdinal("IDCostCenter")), _
                    locDR.GetInt32(locDR.GetOrdinal("CostCenterNo")) & ": " & _
                    locDR.GetString(locDR.GetOrdinal("CostCenterName")))
                    cb.Items.Add(locItem)
                Loop
                Dim locT As ADNullableComboBoxValueType = cb.ComboBoxValueType
                cb.ComboBoxValueType = ADNullableComboBoxValueType.Index_As_Int32
                cb.TypeSafeValue = 0
                cb.ComboBoxValueType = locT
            End If
        End Using
    End Sub

    Friend Shared Sub AddCurrencyToADNullableIdOrIndexComboBox(ByVal cb As ADNullableIdOrIndexComboBox)

        Dim locSqlConn As New SqlConnection(FacessoGeneric.SQLConnectionString)
        locSqlConn.Open()

        Using locSqlConn
            Dim locCommand As New SqlCommand("SELECT * From [Currencies] ORDER BY [IDCurrency]", locSqlConn)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                Do While locDR.Read
                    Dim locItem As New ADComboBoxItem(locDR.GetInt32(locDR.GetOrdinal("IDCurrency")), _
                    locDR.GetString(locDR.GetOrdinal("CurrencyToken")) & ":  " & _
                    "(" & locDR.GetString(locDR.GetOrdinal("CurrencyCode")))
                    cb.Items.Add(locItem)
                Loop
                Dim locT As ADNullableComboBoxValueType = cb.ComboBoxValueType
                cb.ComboBoxValueType = ADNullableComboBoxValueType.Index_As_Int32
                cb.TypeSafeValue = 0
                cb.ComboBoxValueType = locT
            End If
        End Using
    End Sub

    Friend Shared Sub AddWageGroupsToADNullableIdOrIndexComboBox(ByVal cb As ADNullableIdOrIndexComboBox)

        Dim locSqlConn As New SqlConnection(FacessoGeneric.SQLConnectionString)
        locSqlConn.Open()

        Using locSqlConn
            Dim locCommand As New SqlCommand("SELECT * From [WageGroups] WHERE [IDSubsidiary]=" _
                    & FacessoGeneric.LoginInfo.IDSubsidiary & " AND [IsCurrent]='true'", locSqlConn)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                Do While locDR.Read
                    Dim locItem As New ADComboBoxItem(locDR.GetInt32(locDR.GetOrdinal("IDWageGroup")), _
                    locDR.GetString(locDR.GetOrdinal("WageGroupToken")) & ": " & _
                    locDR.GetDecimal(locDR.GetOrdinal("HourlyRate")))
                    cb.Items.Add(locItem)
                Loop
                Dim locT As ADNullableComboBoxValueType = cb.ComboBoxValueType
                cb.ComboBoxValueType = ADNullableComboBoxValueType.Index_As_Int32
                cb.TypeSafeValue = 0
                cb.ComboBoxValueType = locT
            End If
        End Using
    End Sub
End Class

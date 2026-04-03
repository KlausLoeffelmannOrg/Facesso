Imports Activedev
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Partial Public NotInheritable Class SPAccess

    Private Shared myInstance As SPAccess

    Private Sub New()
        'myInstance = Nothing
    End Sub

    Public Shared Function GetInstance() As SPAccess
        If myInstance Is Nothing Then
            If FacessoGeneric.FacessoLicenseInfo.IsLicensed Then
                myInstance = New SPAccess()
            Else
                Dim up As New FacessoLicenseViolationException(My.Resources.Sp_Main_FailedInstancingDueToLicence, Nothing)
                Throw up
            End If
        End If
        Return myInstance
    End Function

    Public Function GetOpenedConnectionSafely() As SqlConnection
        Dim locConnection As New SqlConnection(FacessoGeneric.SQLConnectionString)
        Try
            locConnection.Open()
        Catch ex As Exception
            'Anwendungs-Exception auslösen
            Dim locString As String = My.Resources.Sp_Main_OpenFacessoConnectionFailed + vbNewLine + vbNewLine
            locString &= ex.Message
            Dim up As New FacessoSqlDbException(locString, ex)
            Throw up
            Return Nothing
        End Try
        Return locConnection
    End Function

    Public ReadOnly Property SQLConnectionString() As String
        Get
            Return FacessoGeneric.SQLConnectionString
        End Get
    End Property

    Public Sub DeleteDataForOleDbImport(ByVal IDSubsidiary As Integer)

        Dim locConnection As SqlConnection = GetOpenedConnectionSafely()
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCmd As New SqlCommand("DeleteDataForOleDbImport", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure
            With locCmd.Parameters
                .Add("@IDSubsidiary", SqlDbType.Int).Value = IDSubsidiary
            End With
            locCmd.ExecuteReader()
        End Using
    End Sub
End Class


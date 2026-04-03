Imports System.Data.SqlClient

Public Class ADSqlDatabaseManager

    Private mySqlInstanceConnString As String
    Private myDatabaseName As String
    Private myFilenameOnSqlServer As String
    Private myDatabaseExists As Boolean
    Private myLastSqlResult As Boolean
    Private myLastSqlException As Exception

    Sub New(ByVal SqlInstanceConnString As String, ByVal Databasename As String)
        mySqlInstanceConnString = SqlInstanceConnString
        myDatabaseName = Databasename
    End Sub

    Public Sub QueryProperties()
        Dim locConnection As New SqlConnection(mySqlInstanceConnString)
        Dim locCommand As SqlCommand

        Using locConnection
            Try
                locConnection.Open()
                myLastSqlResult = True
            Catch ex As Exception
                myLastSqlException = ex
                myLastSqlResult = False
                Return
            End Try

            locCommand = New SqlCommand("SELECT name FROM sys.databases where name='" & myDatabaseName & "'")
            locCommand.Connection = locConnection
            Dim locReader As SqlDataReader = locCommand.ExecuteReader()
            If locReader.HasRows Then
                myDatabaseExists = True
            Else
                myDatabaseExists = False
            End If
            locReader.Close()
        End Using

        If myDatabaseExists Then
            'Dateinamen ausfindig machen
            locConnection = New SqlConnection(mySqlInstanceConnString & "; Initial Catalog='" & myDatabaseName & "'")
            Using locConnection
                Try
                    locConnection.Open()
                    myLastSqlResult = True
                Catch ex As Exception
                    myLastSqlException = ex
                    myLastSqlResult = False
                    Return
                End Try

                locCommand = New SqlCommand("SELECT name, physical_name FROM sys.database_files where name='" & myDatabaseName & "'")
                locCommand.Connection = locConnection
                Dim locReader As SqlDataReader = locCommand.ExecuteReader()
                If locReader.HasRows Then
                    locReader.Read()
                    myFilenameOnSqlServer = locReader.GetString(locReader.GetOrdinal("physical_name"))
                End If
                locReader.Close()
            End Using
        End If
        myLastSqlResult = True
    End Sub

    Public Shared Function AttachDatabase(ByVal SqlInstanceConnString As String, ByVal Databasename As String, ByVal DatabaseFilename As String) As ADSqlDatabaseManager
        Return AttachDatabase(SqlInstanceConnString, Databasename, DatabaseFilename, Nothing, Nothing)
    End Function

    Public Shared Function AttachDatabase(ByVal SqlInstanceConnString As String, ByVal Databasename As String, ByVal DatabaseFilename As String, ByVal NewDbOwner As String) As ADSqlDatabaseManager
        Return AttachDatabase(SqlInstanceConnString, Databasename, DatabaseFilename, Nothing, NewDbOwner)
    End Function

    Public Shared Function AttachDatabase(ByVal SqlInstanceConnString As String, ByVal Databasename As String, _
                    ByVal DatabaseFilename As String, ByVal LogFilename As String, _
                    ByVal NewDbOwner As String) As ADSqlDatabaseManager

        Dim locConnection As New SqlConnection(SqlInstanceConnString)
        Dim locCommand As SqlCommand

        If String.IsNullOrEmpty(LogFilename) Then
            locCommand = New SqlCommand("CREATE DATABASE [" & Databasename & "] ON " & _
                "( FILENAME = N'" & DatabaseFilename & "' )" & _
                " FOR ATTACH_REBUILD_LOG", locConnection)
        Else
            locCommand = New SqlCommand("CREATE DATABASE [" & Databasename & "] ON " & _
                "( FILENAME = N'" & DatabaseFilename & "' )," & _
                "( FILENAME = N'" & LogFilename & "' )" & _
                " FOR ATTACH", locConnection)
        End If

        Using locConnection
            locConnection.Open()
            locCommand.ExecuteScalar()

            If Not String.IsNullOrEmpty(NewDbOwner) Then
                locCommand = New SqlCommand("if not exists (select name from master.sys.databases sd where name = N'" & Databasename & _
                "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [" & Databasename & "].dbo.sp_changedbowner " & _
                "@loginame=N'" & NewDbOwner & "', @map=false", locConnection)
                locCommand.ExecuteScalar()
            End If
        End Using
        Return New ADSqlDatabaseManager(SqlInstanceConnString, Databasename)
    End Function

    Public Sub DetachDatabase()
        Dim locConnection As New SqlConnection(mySqlInstanceConnString)
        Dim locCommand As New SqlCommand("EXEC master.dbo.sp_detach_db @dbname = N'" & myDatabaseName & "', @keepfulltextindexfile=N'true'")

        Using locConnection
            Try
                locConnection.Open()
                myLastSqlResult = True
            Catch ex As Exception
                myLastSqlException = ex
                myLastSqlResult = False
                Return
            End Try

            locCommand.Connection = locConnection
            locCommand.ExecuteScalar()
            myLastSqlResult = True
        End Using
    End Sub

    Public Sub CutAllConnections()
        'Alle anderen Verbindungen sausen lassen - falls beispielsweise noch
        'der Visual Studio Server Explorer oder der Connection-Pool eine Verbindung auf sie hat.

        Dim locConnection As New SqlConnection(mySqlInstanceConnString)
        Dim locCommand As New SqlCommand("ALTER DATABASE " & myDatabaseName & " SET Single_User WITH ROLLBACK IMMEDIATE")

        Using locConnection
            Try
                locConnection.Open()
                myLastSqlResult = True
            Catch ex As Exception
                myLastSqlException = ex
                myLastSqlResult = False
                Return
            End Try

            locCommand.Connection = locConnection
            locCommand.ExecuteScalar()
            myLastSqlResult = True
        End Using
    End Sub

    Public Sub CreateDatabase(ByVal DbName As String, ByVal FilenameOnSqlServer As String, ByVal DbSizeInKb As Integer, _
                              ByVal DbFileGrowthInKb As Integer, ByVal DbLogname As String, ByVal LogFilenameOnSqlServer As String, _
                              ByVal LogSizeInKb As Integer, ByVal LogFileGrowthInPercent As Integer)

        Dim locConnection As New SqlConnection(mySqlInstanceConnString)
        Dim locCommand As New SqlCommand("CREATE DATABASE  [" & DbName & "] ON  PRIMARY " & _
                    "( NAME = N'" & DbName & "', FILENAME = N'" & FilenameOnSqlServer & _
                    "' , SIZE = " & DbSizeInKb & "KB , FILEGROWTH = " & DbFileGrowthInKb & "KB )" & _
                    " LOG ON ( NAME = N'" & DbLogname & "', FILENAME = N'" & LogFilenameOnSqlServer & _
                    "' , SIZE = " & LogSizeInKb & "KB , FILEGROWTH = " & LogFileGrowthInPercent & "%)")

        Using locConnection
            Try
                locConnection.Open()
                myLastSqlResult = True
            Catch ex As Exception
                myLastSqlException = ex
                myLastSqlResult = False
                Return
            End Try

            locCommand.Connection = locConnection
            locCommand.ExecuteScalar()
            myLastSqlResult = True
        End Using
    End Sub

    ''' <summary>
    ''' Sendet ein T-Sql-Script zur aktuellen Datenbankinstanz (nicht zur Datenbank!)
    ''' </summary>
    ''' <param name="Script">Zeichenkette, die das Skript enthält, das zur Datenbank gesendet werden soll.</param>
    ''' <remarks></remarks>
    Public Sub SendSqlScript(ByVal Script As String)

        Dim locConnection As New SqlConnection(mySqlInstanceConnString)

        Using locConnection
            Try
                locConnection.Open()
                myLastSqlResult = True
            Catch ex As Exception
                myLastSqlException = ex
                myLastSqlResult = False
                Return
            End Try

            myLastSqlResult = True
        End Using
    End Sub

    Public ReadOnly Property DatabaseExists() As Boolean
        Get
            Return myDatabaseExists
        End Get
    End Property

    Public ReadOnly Property FilenameOnSqlServer() As String
        Get
            Return myFilenameOnSqlServer
        End Get
    End Property

    Public ReadOnly Property LastSqlResult() As Boolean
        Get
            Return myLastSqlResult
        End Get
    End Property
End Class
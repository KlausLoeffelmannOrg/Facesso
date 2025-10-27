Imports System.Data.SqlClient
Imports System.IO

''' <summary>
''' Dient zum Versenden eines T-SQL-Skripts an eine SQL-Server-Instanz oder eine SQL-Server-Datenbank. 
''' Die einzelnen T-SQL-Befehle müssen per "GO" (in einer einzelnen Zeile stehend) von einander getrennt sein.
''' HINWEIS: Die einzelnen AdTSqlScriptChunk-Elemente, die diese Auflistung erstellt, können mit der 
''' ExecuteChunk-Methode nacheinander über die angegebenen Verbindung versendet werden.
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class AdTSqlScriptProcessor
    Inherits System.Collections.ObjectModel.Collection(Of AdTSqlScriptChunk)

    Private myConnection As SqlConnection

    ''' <summary>
    ''' Erstellt einer neue Instanz dieser Klasse.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse und erlaubt die Angabe von Skript und SQL-Verbindung. 
    ''' </summary>
    ''' <param name="Script">Skript, aus dem einzelne AdTSqlScriptChunk-Elemente erstellt werden, 
    ''' die dann mit ExecuteChunk einzeln versendet werden können.</param>
    ''' <param name="Connection">Verbindung zur SQL Server-Instanz oder SQL Server-Datenbank.</param>
    ''' <remarks></remarks>
    Sub New(ByVal Script As String, ByVal Connection As SqlConnection)
        myConnection = Connection
        BuildChunks(Script)
    End Sub

    ''' <summary>
    ''' Erstellt aus einem Skript, das als Zeichenkette vorliegt, einzelne AdTSqlScriptChunk-Elemente, 
    ''' die dann mit ExecuteChunk einzeln versendet werden können.
    ''' </summary>
    ''' <param name="Script">T-SQL-Skript, das als Zeichenkette vorliegt.</param>
    ''' <remarks></remarks>
    Public Sub BuildChunks(ByVal Script As String)
        Me.Items.Clear()
        AppendChunks(Script)
    End Sub

    ''' <summary>
    ''' Hängt ein weiteres Skript als verschiedene AdTSqlScriptChunk-Elemente an bestehende Elemente an.
    ''' </summary>
    ''' <param name="Script">Zeichenkette, die das Skript enthält, 
    ''' das als weitere AdTSqlScriptChunk-Elemente an die vorhandene Auflistung angehängt wird.</param>
    ''' <remarks></remarks>
    Public Sub AppendChunks(ByVal Script As String)
        Dim locChunkStrings() As String = Script.Split(New String() {vbNewLine & "GO" & vbNewLine}, StringSplitOptions.RemoveEmptyEntries)
        For Each locItem As String In locChunkStrings
            Dim locChunk As New AdTSqlScriptChunk(locItem, myConnection.ConnectionString, "Facesso")
            Me.Add(locChunk)
        Next
    End Sub

    ''' <summary>
    ''' Erstellt eine Instanz dieser Klasse und füllt die Auflistung mit AdTSqlScriptChunk-Elementen, 
    ''' die sich aus dem Skript, das als Datei vorliegt, ergibt.
    ''' </summary>
    ''' <param name="Filename">Name der T-SQL-Skript-Datei, aus der diese Instanz hervorgeht.</param>
    ''' <param name="Connection">Verbindung zur SQL Server-Instanz oder -Datenbank, 
    ''' an die die Skript-Chunks gesendet werden sollen.</param>
    ''' <returns>Die sich ergebende Instanz dieser Klasse.</returns>
    ''' <remarks></remarks>
    Public Shared Function FromFile(ByVal Filename As String, ByVal Connection As SqlConnection) As AdTSqlScriptProcessor
        Dim locSr As New StreamReader(Filename)
        Dim locString As String = locSr.ReadToEnd()
        locSr.Close()

        Dim locScriptProcessor As New AdTSqlScriptProcessor(locString, Connection)
        Return locScriptProcessor
    End Function
End Class

<Serializable()> _
Public Class AdTSqlScriptChunk

    Private myChunkText As String
    Private myLastResult As String
    Private myLastExecutionSuccessfull As Boolean
    Private myLastExecutionDate As Date
    Private myConnectionString As String
    Private myDatabaseToUse As String

    Private Shared myConnection As SqlConnection

    Sub New()
        myChunkText = Nothing
        myLastResult = Nothing
    End Sub

    Sub New(ByVal ChunkText As String, ByVal ConnectionString As String, ByVal DatabaseToUse As String)
        myChunkText = ChunkText
        myConnectionString = ConnectionString
        myDatabaseToUse = DatabaseToUse
    End Sub

    Public Function ExecuteChunk() As String
        Dim locBack As String = "OK"
        If myConnection Is Nothing Then
            myConnection = New SqlConnection(ConnectionString)
        Else
            If myConnection.ConnectionString <> ConnectionString Then
                myConnection.Dispose()
                myConnection = New SqlConnection(ConnectionString)
            End If
        End If

        If myConnection.State = ConnectionState.Closed Then
            myConnection.Open()
        End If

        Dim locCommand As New SqlCommand(ChunkText, myConnection)
        Try
            Dim locRet As Integer = locCommand.ExecuteNonQuery
        Catch ex As Exception
            locBack = ex.Message
            If ex.InnerException IsNot Nothing Then
                locBack &= vbNewLine & ex.InnerException.Message
            End If
        End Try
        Return locBack
    End Function

    Public Property DatabaseToUse() As String
        Get
            Return myDatabaseToUse
        End Get
        Set(ByVal value As String)
            myDatabaseToUse = value
        End Set
    End Property

    Public Property ChunkText() As String
        Get
            Return myChunkText
        End Get
        Set(ByVal value As String)
            myChunkText = value
        End Set
    End Property

    Public Property LastResult() As String
        Get
            Return myLastResult
        End Get
        Set(ByVal value As String)
            myLastResult = value
        End Set
    End Property

    Public Property LastExecutionSuccessfull() As Boolean
        Get
            Return myLastExecutionSuccessfull
        End Get
        Set(ByVal value As Boolean)
            myLastExecutionSuccessfull = value
        End Set
    End Property

    Public Property LastExecutionDate() As Date
        Get
            Return myLastExecutionDate
        End Get
        Set(ByVal value As Date)
            myLastExecutionDate = value
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            Return myConnectionString
        End Get
        Set(ByVal value As String)
            myConnectionString = value
        End Set
    End Property
End Class


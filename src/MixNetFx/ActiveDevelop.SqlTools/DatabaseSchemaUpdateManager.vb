Imports System.Data.SqlClient

Public Class DatabaseSchemaUpdateManager

    Private myConnectionStr As String
    Private mySilent As Boolean
    Private myConnection As SqlConnection
    Private myTransaction As SqlTransaction

    Public Sub New(ByVal connection As String, ByVal silent As Boolean)

        myConnectionStr = connection
        mySilent = silent
        myConnection = New SqlConnection(myConnectionStr)
        myConnection.Open()

    End Sub

    ''' <summary>
    '''     Prüft, ob eine Tabelle existiert
    ''' </summary>
    ''' <param name="tablename" type="String">
    '''     <para>
    '''         tabellenname: Bsp.   [dbo].[employees]
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     true: Tabelle existiert, false: Tabelle exitstiert nicht
    ''' </returns>
    Public Function CheckTableExists(ByVal tablename As String) As Boolean
        Dim sel As String = "SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'" & tablename & "') AND type in (N'U') "
        Dim reti As Integer = -1
        Using cmd = myConnection.CreateCommand()
            cmd.Transaction = myTransaction
            cmd.CommandText = sel
            cmd.CommandType = CommandType.Text
            reti = CInt(cmd.ExecuteScalar())
        End Using
        Return reti = 1
    End Function

    Public Sub StartTransaction()
        myTransaction = myConnection.BeginTransaction
    End Sub

    Public Sub Rollback()
        If myTransaction Is Nothing Then Throw New InvalidOperationException("There is no Transaction. Please call StartTransaction first.")
        myTransaction.Rollback()
    End Sub

    Public Sub Commit()
        If myTransaction Is Nothing Then Throw New InvalidOperationException("There is no Transaction. Please call StartTransaction first.")
        myTransaction.Commit()
    End Sub

    Public Sub Close()
        If myConnection.State <> ConnectionState.Closed Then
            myConnection.Close()
        End If
    End Sub

    ''' <summary>
    '''     Löscht eine Tabelle
    ''' </summary>
    ''' <param name="tablename" type="String">
    '''     <para>
    '''         tabellenname: Bsp.   [dbo].[employees]
    '''     </para>
    ''' </param>
    Public Sub DeleteTable(ByVal tablename As String)
        Dim sel As String = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'" & tablename & "') AND type in (N'U')) " & _
                    "   DROP TABLE " & tablename
        ' con ist lokal
        ' und muss am ende wieder disposed werden
        ' ggf alternative connection verwenden
        Using cmd = myConnection.CreateCommand()
            cmd.Transaction = myTransaction
            cmd.CommandText = sel
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub ExecDDLStmt(ByVal ddlCmd As String)
        Using cmd = myConnection.CreateCommand()
            cmd.Transaction = myTransaction
            cmd.CommandText = ddlCmd
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Function CheckConstraintExists(ByVal tablename As String, ByVal constraintName As String) As Boolean
        Dim sel As String = "select distinct 1 FROM INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE " & _
                    "where table_name ='" & tablename & "' AND CONSTRAINT_NAME = '" & constraintName & "'"
        Dim reti As Integer = -1
        Using cmd = myConnection.CreateCommand()
            cmd.Transaction = myTransaction
            cmd.CommandText = sel
            cmd.CommandType = CommandType.Text
            reti = CInt(cmd.ExecuteScalar())
        End Using
        Return reti = 1
    End Function

    ''' <summary>
    ''' Legt einen Constraint an, falls er noch nicht existiert
    ''' Bsp.: alter table TimeLogFlat
    '''  add constraint FK_Flat_Customers __Constaint_Body__
    ''' </summary>
    ''' <param name="tablename"></param>
    ''' <param name="contraintName"></param>
    ''' <param name="constraintBody"></param>
    ''' <remarks></remarks>
    Public Sub CreateContraintIfNotExits(ByVal tablename As String, ByVal contraintName As String, ByVal constraintBody As String)
        If Not CheckConstraintExists(tablename, contraintName) Then
            ' Constraint ist nocht nicht vorhanden
            ' also anlegen
            ExecDDLStmt("alter table " & tablename & " add constraint " & contraintName & " " & constraintBody)
        End If
    End Sub


    Public Function CheckColumnExists(ByVal tablename As String, ByVal columnName As String) As Boolean
        Dim sel As String = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS " & _
                    "WHERE TABLE_NAME = '" & tablename & "' AND COLUMN_NAME = '" & columnName & "'"
        Dim reti As Integer = -1
        Using cmd = myConnection.CreateCommand()
            cmd.Transaction = myTransaction
            cmd.CommandText = sel
            cmd.CommandType = CommandType.Text
            reti = CInt(cmd.ExecuteScalar())
        End Using
        Return reti = 1
    End Function




    ''' <summary>
    ''' Erstellt eine Spalte in einer Tabelle 
    ''' </summary>
    ''' <param name="tablename"></param>
    ''' <param name="columnName"></param>
    ''' <param name="datatype">z.b. "uniqueidentifier"  !!!! KEIN NOT NULL angeben!!!!</param>
    ''' <param name="notNull">falls not null, wird ein Update durchgeführt mit nnDefaultValueStr; dannach wird auf not null geändert</param>
    ''' <param name="nnDefaultValueStr"></param>
    ''' <remarks>Bsp: CreateColumnIfNotExists("Contacts","IDOrt","uniqueidentifier",true,"2354234-2342342-2342342345-2342342",con,trans)</remarks>
    Public Sub CreateColumnIfNotExits(ByVal tablename As String, ByVal columnName As String, ByVal datatype As String, ByVal notNull As Boolean, ByVal nnDefaultValueStr As String)
        If Not CheckColumnExists(tablename, columnName) Then
            ' Spalte ist nocht nicht vorhanden
            ' also anlegen
            ExecDDLStmt("alter table " & tablename & " add " & columnName & " " & datatype)
            If notNull Then
                Using updateCmd = myConnection.CreateCommand()
                    updateCmd.Transaction = myTransaction
                    updateCmd.CommandText = "update " & tablename & " set " & columnName & "=" & nnDefaultValueStr
                    updateCmd.CommandType = CommandType.Text
                    updateCmd.ExecuteNonQuery()
                End Using
                Using alterCmd = myConnection.CreateCommand()
                    alterCmd.Transaction = myTransaction
                    alterCmd.CommandText = "alter table " & tablename & " alter column " & columnName & " " & datatype & " not null"
                    alterCmd.CommandType = CommandType.Text
                    alterCmd.ExecuteNonQuery()
                End Using
            End If
        End If
    End Sub

    Public Sub DeleteColumnIfExits(ByVal tablename As String, ByVal columnName As String)
        If Not CheckColumnExists(tablename, columnName) Then
            ' Spalte ist nocht nicht vorhanden
            ' also anlegen
            ExecDDLStmt("alter table " & tablename & " drop column " & columnName)
        End If
    End Sub

End Class

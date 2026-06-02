Imports ActiveDev
Imports System.Windows.Forms

Public Class frmEmpoyeeHandicapAddEditView

    ' TODO: Code zum Durchführen der benutzerdefinierten Authentifizierung mithilfe des angegebenen Benutzernamens und des Kennworts hinzufügen 
    ' (Siehe http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' Der benutzerdefinierte Prinzipal kann anschließend wie folgt an den Prinzipal des aktuellen Threads angefügt werden: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' wobei CustomPrincipal die IPrincipal-Implementierung ist, die für die Durchführung der Authentifizierung verwendet wird. 
    ' Anschließend gibt My.User Identitätsinformationen zurück, die in das CustomPrincipal-Objekt gekapselt sind,
    ' z.B. den Benutzernamen, den Anzeigenamen usw.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Try
            ValidateForm()
        Catch ex As InvalidDataException
            MessageBox.Show(ex.Message, "Hinweis")
            Return
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler")
            Return
        End Try

        myRow2Edit("ValidFrom") = dtpValidFrom.Value
        ' Double - Parsen : Das geht ohne TryParse, da der Wert bereits in ValidateFrom geprüft wurde
        myRow2Edit("Handicap") = Double.Parse(tbHandicap.Text)

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Function GetDateFromRow(ByVal row As DataRow, ByVal column As String) As Date?
        If row(column).GetType Is GetType(DBNull) Then
            Return Nothing
        ElseIf row(column).GetType Is GetType(Date) Then
            Return CDate(row(column))
        End If
    End Function


    Private myRow2Edit As DataRow
    Private myAllRows As DataRowCollection
    Overloads Function ShowDialog(ByVal empDisplayName As String, ByVal row2Edit As DataRow, ByVal allRows As DataRowCollection) As System.Windows.Forms.DialogResult
        lblEmployee.Text = empDisplayName
        myRow2Edit = row2Edit
        myAllRows = allRows
        If GetDateFromRow(myRow2Edit, "ValidFrom").HasValue Then
            dtpValidFrom.Value = GetDateFromRow(myRow2Edit, "ValidFrom").Value
        Else
            ' neuer Datensatz
            dtpValidFrom.Value = Date.Now
        End If

        If row2Edit("Handicap").GetType Is GetType(DBNull) Then
            ' neuer Datensatz
            tbHandicap.Text = "0"
        Else
            tbHandicap.Text = row2Edit("Handicap").ToString
        End If

        Return MyBase.ShowDialog()
    End Function

    Private Sub ValidateForm()
        Dim newHandicap As Double = 0
        Dim handicapError As Boolean = Not Double.TryParse(tbHandicap.Text, newHandicap)
        If Not handicapError Then
            If newHandicap < 0 Then
                handicapError = True
            End If
        End If
        If handicapError Then
            Throw New InvalidDataException("Der angegebene Wert für das Handicap ist ungültig. Er muss numerisch und positiv sein.")
        End If

        Dim newValidFrom As Date = dtpValidFrom.Value.Date
        For Each row As DataRow In myAllRows
            If row IsNot myRow2Edit Then
                If newValidFrom = CDate(row("validfrom")) Then
                    Throw New InvalidDataException("Es existiert bereits ein Handicap Eintrag für den " & newValidFrom.ToString)
                End If
            End If
        Next

    End Sub

    Private Class InvalidDataException
        Inherits Exception
        Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
    End Class
End Class

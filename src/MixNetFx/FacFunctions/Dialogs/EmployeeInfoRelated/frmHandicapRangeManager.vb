Option Infer On

Imports System.Windows.Forms
Imports Facesso.Data
Imports System.Data.SqlClient

'HACK: Hier die Funktionalität für den Handicap-Manager einbauen
Public Class frmHandicapRangeManager

    Private myEmployee As EmployeeInfo
    Private myHandicapDataTable As DataTable

    Overloads Function ShowDialog(ByVal e As EmployeeInfo) As DialogResult
        If e Is Nothing Then
            Throw New ArgumentNullException("Interner Fehler: Es wurde bei frmHandicapRangeManager kein Mitarbeiter angegeben.")
        End If

        myEmployee = e

        lblEmployee.Text = e.DisplayName

        'Demo: Subsidary (Abteilung, Filliale, Mandant. etc.) ermitteln
        Dim si = Facesso.LoginInfo.SubsidiaryInfo
        '(würd aber auch in EmployeeInfo stehen hahahahaha)

        ListView1.MultiSelect = False
        LoadHandicaps()

        Return MyBase.ShowDialog
    End Function

    Private Sub LoadHandicaps()
        Dim selCmd = "Select * from EmployeeHandicaps where IDSubsidiary=@SUBSID and IDEmployee=@EMPID order by validfrom"
        Dim con As New SqlConnection(FacessoGeneric.SQLConnectionString)
        Using con
            con.Open()

            myHandicapDataTable = New DataTable("EmployeeHandicaps")

            Dim cmd = con.CreateCommand
            cmd.CommandText = selCmd
            cmd.CommandType = CommandType.Text
            Dim p As New SqlParameter("@SUBSID", myEmployee.IDSubsidiary)
            cmd.Parameters.Add(p)
            p = New SqlParameter("@EMPID", myEmployee.IDEmployee)
            cmd.Parameters.Add(p)

            Using reader = cmd.ExecuteReader
                myHandicapDataTable.Load(reader)
            End Using

            FillListViewFromDataTable()

        End Using

    End Sub

    Private Sub FillListViewFromDataTable()
        ListView1.Items.Clear()

        'Tabelle neu Sortieren
        Dim sortedvalidFroms(myHandicapDataTable.Rows.Count - 1) As Date
        Dim i As Integer = 0
        For Each row As DataRow In myHandicapDataTable.Rows
            sortedvalidFroms(i) = CDate(row("ValidFrom"))
            i += 1
        Next

        Array.Sort(sortedvalidFroms)

        ' nun sortiert in die Listview einfügen
        For Each vf As Date In sortedvalidFroms
            For Each row As DataRow In myHandicapDataTable.Rows
                If vf = CDate(row("validfrom")) Then
                    ' der aktuelle Datensatz ist der richtige
                    Dim t As String = MapDataTable2ListView(row, "ValidFrom")
                    Dim newLVIitem As New ListViewItem(t)
                    ' row im Tag speichern
                    newLVIitem.Tag = row
                    t = MapDataTable2ListView(row, "Handicap")
                    newLVIitem.SubItems.Add(t)

                    ListView1.Items.Add(newLVIitem)
                End If
            Next
        Next
        SetDeps()

    End Sub

    Private Function MapDataTable2ListView(ByVal row As DataRow, ByVal column As String) As String
        If row(column).GetType Is GetType(DBNull) Then
            Return Nothing
        ElseIf row(column).GetType Is GetType(Date) Then
            Return CDate(row(column)).ToShortDateString
        Else
            Return row(column).ToString
        End If
    End Function

    Private Sub SetDeps()
        Dim enNew As Boolean = False
        Dim enEdit As Boolean = False
        Dim enDel As Boolean = False

        If myEmployee Is Nothing Then
            ' alles auf false lassen
        Else
            enNew = True
            If ListView1.SelectedIndices.Count > 0 Then
                ' es ist etwas ausgewählt
                enDel = True
                enEdit = True
            End If
        End If
        btnNew.Enabled = enNew
        btnEdit.Enabled = enEdit
        btnDelete.Enabled = enDel
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.MultiSelect Then
            Throw New NotSupportedException("interner Fehler: Multiselect wird nicht unterstützt")
        End If
        SetDeps()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim hasZeroHandicap As Boolean = False
        For Each row As DataRow In myHandicapDataTable.Rows
            If CDbl(row("Handicap")) = 0 Then
                hasZeroHandicap = True
            End If
        Next
        If Not hasZeroHandicap And myHandicapDataTable.Rows.Count > 0 Then
            'TODO: Fehlermeldung gemäss Facesso-Fehler ausgeben
            MessageBox.Show("Es muss ein Datensatz mit dem Handicap 0 geben.", "Hinweis")
            Return
        End If

        Dim con As SqlConnection = Nothing
        Dim trans As SqlTransaction = Nothing
        Try
            con = New SqlConnection(FacessoGeneric.SQLConnectionString)
            con.Open()
            trans = con.BeginTransaction

            Dim delCmd = con.CreateCommand()
            delCmd.Transaction = trans
            delCmd.CommandText = "Delete from EmployeeHandicaps where IDSubsidiary=@SUBSID and IDEmployee=@EMPID"
            delCmd.CommandType = CommandType.Text
            Dim p As New SqlParameter("@SUBSID", myEmployee.IDSubsidiary)
            delCmd.Parameters.Add(p)
            p = New SqlParameter("@EMPID", myEmployee.IDEmployee)
            delCmd.Parameters.Add(p)

            delCmd.ExecuteNonQuery()

            delCmd.Dispose()

            Dim insCmd = con.CreateCommand()
            insCmd.Transaction = trans
            insCmd.CommandText = "Insert into EmployeeHandicaps (IDSubsidiary,IDEmployee,ValidFrom,Handicap) Values(@SUBSID,@EMPID,@ValidFrom,@Handicap)"
            insCmd.CommandType = CommandType.Text

            For Each row As DataRow In myHandicapDataTable.Rows
                insCmd.Parameters.Clear()
                p = New SqlParameter("@SUBSID", myEmployee.IDSubsidiary)
                insCmd.Parameters.Add(p)
                p = New SqlParameter("@EMPID", myEmployee.IDEmployee)
                insCmd.Parameters.Add(p)
                Dim valFrom = CDate(row("ValidFrom"))
                p = New SqlParameter("@ValidFrom", valFrom.Date)
                insCmd.Parameters.Add(p)
                Dim handi = CDbl(row("handicap"))
                p = New SqlParameter("@Handicap", handi)
                insCmd.Parameters.Add(p)

                insCmd.ExecuteNonQuery()
            Next

            trans.Commit()
            trans = Nothing
        Catch ex As Exception
            MessageBox.Show("Fehler beim Speichern der Handicaps:" & ex.Message, "Fehler")
            If trans IsNot Nothing Then
                trans.Rollback()
                trans = Nothing
            End If
        Finally
            If trans IsNot Nothing Then
                trans.Rollback()
                trans = Nothing
            End If
            If con IsNot Nothing Then
                con.Close()
            End If
        End Try


        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ShowNewEditDialog(ByVal sender As Object, ByVal e As EventArgs)
        If ListView1.MultiSelect Then
            Throw New NotSupportedException("interner Fehler: Multiselect wird nicht unterstützt")
        End If
        Dim frmNewEdit As New frmEmpoyeeHandicapAddEditView
        Dim emptext As String = lblEmployee.Text
        Dim useRow As DataRow = Nothing
        Dim isNewRow As Boolean = False
        If sender Is btnNew Then
            useRow = myHandicapDataTable.NewRow
            isNewRow = True
        ElseIf sender Is btnEdit Then
            useRow = DirectCast(ListView1.SelectedItems(0).Tag, DataRow)
        End If
        Dim ret = frmNewEdit.ShowDialog(emptext, useRow, myHandicapDataTable.Rows)
        If ret = Windows.Forms.DialogResult.OK Then
            ' Daten übernehmen
            If isNewRow Then
                useRow("IDEmployee") = myEmployee.IDEmployee
                useRow("IDSubsidiary") = myEmployee.IDSubsidiary
                myHandicapDataTable.Rows.Add(useRow)
            End If

            FillListViewFromDataTable()
        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            ShowNewEditDialog(btnEdit, e)
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ShowNewEditDialog(sender, e)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ShowNewEditDialog(sender, e)
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim checkdate As Date = Date.Now
    '    Stop
    '    Dim res = GetHandicapFromDate(myEmployee, checkdate)
    '    Debug.WriteLine("Handicap für " & myEmployee.DisplayName & "; " & checkdate.ToString & "=" & res.ToString)

    'End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ListView1.MultiSelect Then
            Throw New NotSupportedException("interner Fehler: Multiselect wird nicht unterstützt")
        End If
        If ListView1.SelectedItems.Count > 0 Then
            Dim selrow = DirectCast(ListView1.SelectedItems(0).Tag, DataRow)
            myHandicapDataTable.Rows.Remove(selrow)

            FillListViewFromDataTable()
        End If
    End Sub
End Class
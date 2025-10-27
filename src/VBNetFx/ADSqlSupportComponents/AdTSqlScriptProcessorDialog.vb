Imports ActiveDev.Data.SqlClient

Public Class ADTsqlScriptProcessorDialog

    Private myScriptProcessor As ADTsqlScriptProcessor

    Public Sub HandleDialog(ByVal ScriptProcessor As ADTsqlScriptProcessor)
        myScriptProcessor = ScriptProcessor
        InitializeTable()
        BuildTable(False)
        Me.ShowDialog()
    End Sub

    Private Sub BuildTable(ByVal UseUse As Boolean)
        dgvScriptChunks.Rows.Clear()
        Dim locCount As Integer = 1
        For Each locItem As ADTsqlScriptChunk In myScriptProcessor
            Dim locChunk As String = locItem.ChunkText.Replace(vbTab, "   ")
            dgvScriptChunks.Rows.Add(New Object() _
                    {locCount.ToString, _
                     locChunk, _
                     "Noch nicht verarbeitet"})
            dgvScriptChunks.Rows(locCount - 1).Tag = locItem
            locCount += 1
        Next
    End Sub

    Private Sub InitializeTable()

        Dim locColumn As DataGridViewColumn
        Dim locHeaderFont As New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)
        Dim locCellFont As New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular)
        Dim locListingFont As New Font(FontFamily.GenericMonospace, 8, FontStyle.Regular)

        dgvScriptChunks.ColumnHeadersDefaultCellStyle.Font = locHeaderFont
        dgvScriptChunks.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvScriptChunks.AllowUserToAddRows = False
        dgvScriptChunks.AllowUserToDeleteRows = False
        dgvScriptChunks.AllowUserToOrderColumns = False
        dgvScriptChunks.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvScriptChunks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

        With dgvScriptChunks.Columns
            .Clear()

            'Chunk-Nr:
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 60
            locColumn.DisplayIndex = 0
            locColumn.HeaderText = "Chunk-Nr.:"
            locColumn.MinimumWidth = 50
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            locColumn.DefaultCellStyle.Font = locHeaderFont
            locColumn.Name = "ChunkNr"
            .Add(locColumn)

            'Skript-Chunk
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            locColumn.FillWeight = 500
            locColumn.DisplayIndex = 1
            locColumn.HeaderText = "Skript-Chunk:"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            locColumn.DefaultCellStyle.Font = locListingFont
            locColumn.Name = "ScriptChunk"
            .Add(locColumn)

            'Result
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 120
            locColumn.DisplayIndex = 2
            locColumn.HeaderText = "Ausführungsresultat:"
            locColumn.FillWeight = 200
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = False
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "ExecutionResult"
            .Add(locColumn)
        End With

    End Sub

    Private Sub btnSendScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendScript.Click

        Dim locCount As Integer = 0
        pbScriptExecution.Maximum = dgvScriptChunks.Rows.Count - 1

        For Each locRow As DataGridViewRow In dgvScriptChunks.Rows
            Dim locChunk As ADTsqlScriptChunk = DirectCast(locRow.Tag, ADTsqlScriptChunk)
            Dim locMes As String = locChunk.ExecuteChunk
            If locMes = "OK" Then
                locRow.Cells("ExecutionResult").Value = locMes
                locRow.Selected = True
                dgvScriptChunks.FirstDisplayedScrollingRowIndex = locCount
                Application.DoEvents()
            Else
                Dim locDr As DialogResult = MessageBox.Show( _
                    "Bei der Skript-Ausführung ist ein Fehler aufgetreten:" & vbNewLine & _
                    locMes & _
                    "Soll die Ausführung fortgesetzt werden?", "Skriptfehler:", _
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If locDr = Windows.Forms.DialogResult.No Then
                    Exit For
                End If
            End If
            pbScriptExecution.Value = locCount
            locCount += 1
        Next
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class
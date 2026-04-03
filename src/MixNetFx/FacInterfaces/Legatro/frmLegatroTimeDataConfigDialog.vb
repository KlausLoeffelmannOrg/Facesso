Imports System.Windows.Forms
Imports ActiveDev.Data.SqlClient
Imports Facesso.Data

Public Class frmLegatroTimeDataConfigDialog

    Private myTaskItem As LegatroTimeDataImport
    Private mySortedWorkgroupInfoItems As List(Of WorkGroupInfo)
    Private myWorksiteOrProjects As List(Of WorksitesOrProjects)

    Public Function HandleDialog(ByVal TaskItem As IFacessoImportTaskItem) As DialogResult
        myTaskItem = DirectCast(TaskItem, LegatroTimeDataImport)
        InitializeControls()
        If Not String.IsNullOrEmpty(myTaskItem.LegatroSQLConnectionString) Then
            txtSqlConnectionString.Text = myTaskItem.LegatroSQLConnectionString
            RebuildLists()
        End If

        Me.ShowDialog()
        Return Me.DialogResult
    End Function

    Private Sub btnSelectSqlConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSqlConnection.Click
        Dim frm As New ADDatabaseConnectionDialog
        Dim connBuilder = frm.GetConnectionBuilder("Legatro-Datenbankinstanz auswählen:")
        If connBuilder IsNot Nothing Then
            txtSqlConnectionString.Text = connBuilder.ConnectionString
            If myTaskItem IsNot Nothing Then
                myTaskItem.LegatroSQLConnectionString = txtSqlConnectionString.Text
            End If
            InitializeControls()
            RebuildLists()
        End If
    End Sub

    Private Sub InitializeControls()
        With lvwLegatroWorksitesOrProjects
            .Columns.Clear()
            With .Columns
                .Add("Nummer:")
                .Add("Arbeitsplatzname:")
            End With
        End With
    End Sub

    Private Sub RebuildLists()
        lvwLegatroWorksitesOrProjects.Items.Clear()
        tvwAssignments.Nodes.Clear()

        If Not String.IsNullOrEmpty(myTaskItem.LegatroSQLConnectionString) Then
            Dim dc As New LegatroDataContext(myTaskItem.LegatroSQLConnectionString)
            Try
                myWorksiteOrProjects = (From wsItem In dc.WorksitesOrProjects _
                           Where Not wsItem.IsProject _
                           Order By wsItem.WorkEntityNumber).ToList
            Catch ex As Exception
                MessageBox.Show("Beim Abrufen der Daten aus der Legatro-Datenbank ist ein Fehler aufgetreten." & vbNewLine & _
                                "Bitte Überprüfen Sie die Netzwerkverbindung und die Verbindungszeichenfolge zur Datenbank.", _
                                "Verbindungsaufbau zu Legatro nicht möglich!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            For Each wsItem In myWorksiteOrProjects
                Dim lvwItem As New ListViewItem(wsItem.WorkEntityNumber.ToString("000000"))
                lvwItem.SubItems.Add(wsItem.WorkEntityName)
                lvwItem.Tag = wsItem

                'Rausfinden, ob das Item schon zugewiesen wurde
                If myTaskItem.ConversionItems IsNot Nothing Then
                    For Each taskItem In myTaskItem.ConversionItems
                        If taskItem.AlienElementID = wsItem.WorkEntityNumber Then
                            '...dann in Fettschrift anzeigen
                            If taskItem.HomeElementID > -1 Then
                                lvwItem.Font = New Drawing.Font(lvwItem.Font, Drawing.FontStyle.Bold)
                            End If
                        End If
                    Next
                End If
                lvwLegatroWorksitesOrProjects.Items.Add(lvwItem)
            Next
        End If
        For Each colItem As ColumnHeader In lvwLegatroWorksitesOrProjects.Columns
            colItem.Width = -2
        Next

        Dim wgItems As New WorkGroupInfoItems(False)
        mySortedWorkgroupInfoItems = (From wgSortedItem In wgItems _
                      Order By wgSortedItem.WorkGroupNumber).ToList

        For Each item In mySortedWorkgroupInfoItems
            Dim tn = tvwAssignments.Nodes.Add(item.WorkGroupNumber & ": " & item.WorkGroupName)
            tn.Tag = item
            If item.IsActive Then
                tn.ForeColor = Drawing.Color.Blue
                tn.NodeFont = New Drawing.Font(Me.Font, Drawing.FontStyle.Bold)
            Else
                tn.ForeColor = Drawing.Color.Red
            End If
        Next
        Application.DoEvents()

        If myTaskItem.ConversionItems Is Nothing Then
            myTaskItem.ConversionItems = myTaskItem.AssembleConversionItems
        Else
            'Abgleich, ob sich was geändert hat
            Dim tmpItems = myTaskItem.AssembleConversionItems
            Dim itemsToAdd = New List(Of FacessoConversionItemBase)
            For Each tmpItem In tmpItems
                Dim found = False
                For Each taskItem In myTaskItem.ConversionItems
                    If taskItem.AlienElementID = tmpItem.AlienElementID Then
                        found = True
                        Exit For
                    End If
                Next
                If Not found Then
                    itemsToAdd.Add(tmpItem)
                End If
            Next
            For Each itemToAdd In itemsToAdd
                myTaskItem.ConversionItems.Add(itemToAdd)
            Next
        End If

        For Each item In myTaskItem.ConversionItems
            'Ein Facesso-Element (Worksite) ist zugeordnet bei >-1

            If item.HomeElementID > -1 Then
                'Home-Element im Tree suchen
                For Each nodeItem As TreeNode In tvwAssignments.Nodes
                    If DirectCast(nodeItem.Tag, WorkGroupInfo).WorkGroupNumber = item.HomeElementID Then
                        'Gefunden: Alien-Element und Item-Name als Zwei eintragen
                        Dim tmpNode = nodeItem.Nodes.Add(item.AlienElementID.ToString("000000") & ": " & item.Itemname)
                        tmpNode.Tag = item.HomeElementID
                        nodeItem.Expand()
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If lvwLegatroWorksitesOrProjects.SelectedItems.Count = 0 Then
            MessageBox.Show("Bitte wählen Sie einen Legatro-Arbeitsplatz zum Zuweisen aus!", _
                             "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If tvwAssignments.SelectedNode Is Nothing Then
            MessageBox.Show("Bitte wählen Sie eine Facesso-Produktiv-Site aus, der der Legatro-Arbeitsplatz zugewiesen werden soll!", _
                             "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim legItem = DirectCast(lvwLegatroWorksitesOrProjects.SelectedItems(0).Tag, WorksitesOrProjects)
        Dim facItem = DirectCast(tvwAssignments.SelectedNode.Tag, WorkGroupInfo)

        For Each cItem In myTaskItem.ConversionItems
            If cItem.AlienElementID = legItem.WorkEntityNumber Then
                cItem.HomeElementID = facItem.WorkGroupNumber
                cItem.HomeElementName = facItem.WorkGroupName
                Exit For
            End If
        Next

        RebuildLists()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If tvwAssignments.SelectedNode Is Nothing Then
            MessageBox.Show("Bitte wählen Sie eine Facesso-Produktiv-Site aus, deren Zuweisung aufgehoben werden soll!", _
                             "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If tvwAssignments.SelectedNode.Parent Is Nothing And tvwAssignments.SelectedNode.Nodes.Count = 0 Then
            MessageBox.Show("Bitte wählen Sie eine Zweig aus, der ein Legatro-Arbeitsplatz/Kostenstelle zugeordnet ist!", _
                             "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim currentNode As TreeNode

        'Dafür sorgen, dass immer der Hauptzweig ausgewählt ist.
        If tvwAssignments.SelectedNode.Parent IsNot Nothing Then
            currentNode = tvwAssignments.SelectedNode.Parent
        Else
            currentNode = tvwAssignments.SelectedNode
        End If

        'Zugeordnetes WorkgroupInfo-Objekt finden
        Dim workgroupNumber = CInt(currentNode.Nodes(0).Tag)
        Dim facItem = (From fItem In mySortedWorkgroupInfoItems _
                      Where fItem.WorkGroupNumber = workgroupNumber).SingleOrDefault
        If facItem Is Nothing Then
            MessageBox.Show("Interner Zuordnungsfehler - bitte rufen Sie nach Verlassen diesen Dialog erneut auf.", _
                            "Interner Zuordnungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        'Sicherheitsabfrage:
        Dim dr = MessageBox.Show("Sind Sie sicher, dass Sie die Zuordnung zur Produktiv-Site " & facItem.DisplayName & " aufheben wollen?", _
                               "Zuordnung aufheben?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dr = Windows.Forms.DialogResult.Yes Then

            For Each cItem In myTaskItem.ConversionItems
                If cItem.HomeElementID = facItem.WorkGroupNumber Then
                    cItem.HomeElementID = -1
                    cItem.HomeElementName = ""
                    Exit For
                End If
            Next
            RebuildLists()
        End If
    End Sub
End Class
Imports System.Windows.Forms
Imports Facesso.Data
Imports System.IO

Public Class frmWorkGroupAnalysisManager

    Private myAnalyses As WorkGroupAnalysisParametersCollection
    Private myMaxMenuEntries As Integer

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)

        'Von der Version abhängig machen, wie viele Menüeinträge erlaubt sind.
        If FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion = FacessoVersion.FacessoStandard Then
            myMaxMenuEntries = 5
        ElseIf FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion = FacessoVersion.FacessoLight Then
            myMaxMenuEntries = 2
        ElseIf FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion = FacessoVersion.FacessoProfessional Then
            myMaxMenuEntries = 10
        ElseIf FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion = FacessoVersion.FacessoEnterprise Then
            myMaxMenuEntries = 15
        End If

        'Liste laden
        Dim locFi As New FileInfo(FacessoGeneric.SharedFolder & "\AnalysisInfo\FacessoAnalyses.Xml")
        myAnalyses = WorkGroupAnalysisParametersCollection.FromFile(locFi)
        If myAnalyses Is Nothing Then
            myAnalyses = New WorkGroupAnalysisParametersCollection()
        End If
        rebuildList()
    End Sub

    Private Sub rebuildList()
        'Menuitems-Templates aufbauen
        cmbMenuIndex.Items.Clear()
        cmbMenuIndex.Items.Add("- Kein Menüeintrag -")
        For locCount As Integer = 1 To myMaxMenuEntries
            cmbMenuIndex.Items.Add(locCount.ToString("00") & ": - bislang nicht definiert -")
        Next

        'Menu-Item-Liste aktualisieren und gleichzeitig die Analysen-Liste aufbauen
        lstAnalysis.Items.Clear()
        For Each locItem As WorkGroupAnalysisParameters In myAnalyses
            If locItem.MenuIndex > 0 Then
                cmbMenuIndex.Items(locItem.MenuIndex) = locItem.MenuIndex.ToString("00") & ": " & locItem.MenuName
            End If
            lstAnalysis.Items.Add(locItem)
        Next

        'Ersten Punkt vorselektieren
        cmbMenuIndex.SelectedIndex = 0
    End Sub

    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        MyBase.OnClosed(e)
        'List abspeichern, wenn es mehr als ein Element gibt!
        SaveChanges()
    End Sub

    Private Sub SaveChanges()
        Dim locFi As New FileInfo(FacessoGeneric.SharedFolder & "\AnalysisInfo\FacessoAnalyses.Xml")
        If myAnalyses.Count > 0 Then
            myAnalyses.ToFile(locFi)
        Else
            locFi.Delete()
        End If
    End Sub

    Private Sub btnNewAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewAnalysis.Click

        If Not CheckParametersPlausibility(txtAnalysisName.Text, -1, False) Then
            Exit Sub
        End If

        'Todo: Menüzuordnung

        'Assistenten aufrufen
        Dim locFrmWorkgroupAnalysisWizard As New frmWorkGroupAnalysis
        Dim locAnalysisParameters As WorkGroupAnalysisParameters = locFrmWorkgroupAnalysisWizard.GetAnalysisParameters()
        If locAnalysisParameters IsNot Nothing Then
            locAnalysisParameters.Name = txtAnalysisName.Text
            myAnalyses.Add(locAnalysisParameters)
            rebuildList()
        End If
        SaveChanges()
    End Sub

    Private Sub btnEditAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditAnalysis.Click

        If Not CheckParametersPlausibility(txtAnalysisName.Text, lstAnalysis.SelectedIndex, True) Then
            Exit Sub
        End If

        Dim locFrmWorkgroupAnalysisWizard As New frmWorkGroupAnalysis
        Dim locAnalysisParameters As WorkGroupAnalysisParameters = DirectCast(lstAnalysis.SelectedItem, WorkGroupAnalysisParameters)
        locAnalysisParameters.Name = txtAnalysisName.Text
        locAnalysisParameters = locFrmWorkgroupAnalysisWizard.GetAnalysisParameters(locAnalysisParameters)
        If locAnalysisParameters IsNot Nothing Then
            lstAnalysis.SelectedItem = locAnalysisParameters
        End If
        SaveChanges()

        'Todo: Menüzuordnung

    End Sub

    Private Sub btnDeleteAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAnalysis.Click

        Dim locIndex As Integer

        If Not CheckParametersPlausibility(Nothing, -1, True) Then
            Exit Sub
        End If

        For Each locAnalysisParameters As WorkGroupAnalysisParameters In myAnalyses
            If DirectCast(lstAnalysis.SelectedItem, WorkGroupAnalysisParameters).Name = locAnalysisParameters.Name Then
                Exit For
            End If
            locIndex += 1
        Next
        myAnalyses.RemoveAt(locIndex)
        rebuildList()
        SaveChanges()
    End Sub

    Private Function CheckParametersPlausibility(ByVal name As String, ByVal DontCheckThisIndex As Integer, ByVal checkSelection As Boolean) As Boolean
        Dim locIndex As Integer = 0
        Dim locNameExist As Boolean

        If checkSelection Then
            If lstAnalysis.SelectedIndex < 0 Then
                MessageBox.Show("Sie haben keine Analyse zur Bearbeitung ausgewählt!", "Fehlende Auswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        If name IsNot Nothing Then
            If txtAnalysisName.Text = "" Then
                MessageBox.Show("Bitte geben Sie einen Namen für die Analyse ein!", "Fehlender Name!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtAnalysisName.Focus()
                Return False
            End If

            For Each locItem As WorkGroupAnalysisParameters In lstAnalysis.Items
                If locItem.Name = txtAnalysisName.Text And Not DontCheckThisIndex = locIndex Then
                    locNameExist = True
                    Exit For
                End If
                locIndex += 1
            Next

            If locNameExist Then
                MessageBox.Show("Dieser Analysename ist schon vorhanden. Bitte wählen Sie einen anderen Namen für diese Analyse!", "Name schon vorhanden!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtAnalysisName.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub lstAnalysis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAnalysis.SelectedIndexChanged
        If lstAnalysis.SelectedIndex > -1 Then
            txtAnalysisName.Text = lstAnalysis.SelectedItem.ToString
        Else
            txtAnalysisName.Text = ""
        End If
    End Sub

    Private Sub btnUseAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseAnalysis.Click

        If Not CheckParametersPlausibility(Nothing, -1, True) Then
            Return
        End If
        Dim locAnalysisPerformer As WorkGroupAnalysisPerformer
        Try
            locAnalysisPerformer = New WorkGroupAnalysisPerformer(DirectCast(lstAnalysis.SelectedItem, WorkGroupAnalysisParameters))
        Catch ex As Exception
            MessageBox.Show("Seit der letzten Analyse haben sich die Produktiv-Sites geändert," & vbNewLine & _
                "oder die Analyse-Infos stammen von einem anderen System." & vbNewLine & _
                "Löschen Sie die Analyse und erstellen Sie sie erneut!", "Fehler bei Produktiv-Site-Vorauswahl!", _
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        locAnalysisPerformer.PerformAnalysis()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class
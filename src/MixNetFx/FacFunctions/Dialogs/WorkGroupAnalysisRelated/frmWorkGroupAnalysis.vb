Imports ActiveDev
Imports Facesso.Data
Imports System.Windows.Forms

Public Class frmWorkGroupAnalysis

    'Wizard-Handler
    Private WithEvents myWizardController As ADWizardController
    Private myAnalysisParameters As WorkGroupAnalysisParameters
    Private myOnlyGetParameters As Boolean
    Private myFacessoGeneralOptions As FacessoGeneralOptions

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        myFacessoGeneralOptions = DirectCast( _
            FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", _
            New FacessoGeneralOptions(False, False, True, False, 60)), FacessoGeneralOptions)


        With lstDestFields.Items
            .Clear()
            .Add("Arbeitsgruppenname")
            .Add("Gesamt-Referenzzeit")
            .Add("Gesamt-Effektivzeit")
            .Add("Gesamt-Effektivzeit (ang.)")
            .Add("Gesamt-Ausfallzeit")
            .Add("Gesamt-Pausenzeit")
            .Add("Zeitgrad")
            .Add("Zeitgrad (ang.)")
        End With

        wglWorkGroups.WorkGroupInfoItems = New WorkGroupInfoItems(True)
        For Each locItem As ListViewItem In wglWorkGroups.Items
            locItem.Selected = True
        Next

        If myAnalysisParameters IsNot Nothing Then
            FromAnalysisParameters()
        End If

        If myFacessoGeneralOptions.SaturdayIsWorkday Then
            Me.drpMain.LastWorkingday = LastWorkingdays.Saturday
        ElseIf myFacessoGeneralOptions.SundayIsWorkday Then
            Me.drpMain.LastWorkingday = LastWorkingdays.Sunday
        End If

        myWizardController = New ADWizardController(btnBack, btnNext, btnCancel, tcWizard)
        myWizardController.Initialize()
    End Sub

    Public Function GetAnalysisParameters() As WorkGroupAnalysisParameters
        myOnlyGetParameters = True
        Me.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return myAnalysisParameters
        Else
            Return Nothing
        End If
    End Function

    Public Function GetAnalysisParameters(ByVal wgap As WorkGroupAnalysisParameters) As WorkGroupAnalysisParameters
        myOnlyGetParameters = True
        myAnalysisParameters = wgap
        Me.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return myAnalysisParameters
        Else
            Return Nothing
        End If
    End Function

    Private Sub myWizardController_Cancel(ByVal sender As Object, ByVal e As System.EventArgs) Handles myWizardController.Cancel
        Dim locMessage As String = "Sind Sie sicher, dass Sie den Assistenten abbrechen möchten?"
        Dim locdr As DialogResult = MessageBox.Show(locMessage, "Assistenten beenden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If locdr = Windows.Forms.DialogResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub myWizardController_Finished(ByVal sender As Object, ByVal e As System.EventArgs) Handles myWizardController.Finished
        If myOnlyGetParameters Then
            ToAnalysisParameters()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Return
        End If

        Dim locDR As DialogResult = MessageBox.Show("Möchten Sie die Auswertung durchführen (Abbrechen kehrt zurück zum Ausgangsdialog)?", _
                    "Auswertung durchführen?", MessageBoxButtons.YesNoCancel)
        If locDR = Windows.Forms.DialogResult.Cancel Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        ElseIf locDR = Windows.Forms.DialogResult.Yes Then
            ToAnalysisParameters()
            Dim locAnalysisPerformer As New WorkGroupAnalysisPerformer(myAnalysisParameters)
            locAnalysisPerformer.PerformAnalysis()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub myWizardController_StepChanged(ByVal sender As Object, ByVal e As ActiveDev.ADWizardStepChangeEventArgs) Handles myWizardController.StepChanged
        If e.NewStepNo = 4 And _
           e.WizardStepAction = ADWizardStepAction.NextStep And _
           (Not optCSVExport.Checked) Then
            e.WizardStepAction = ADWizardStepAction.SkipAllRemainingSteps
        End If
        e.NextStepAllowed = True
        ToAnalysisParameters()
        txtConclusion.Text = myAnalysisParameters.Description
    End Sub

    Private Sub ToAnalysisParameters()
        If myAnalysisParameters Is Nothing Then
            myAnalysisParameters = New WorkGroupAnalysisParameters()
        End If

        With myAnalysisParameters
            .DateRange = drpMain.DateRangeValue
            .ShiftParameters = New ShiftParameters(chkShift1.Checked, chkShift2.Checked, chkShift3.Checked, _
                                chkShift4.Checked, optUseAlternatingShifts.Checked, CInt(nudAltShiftDays.Value), _
                                CInt(nudAltShift1.Value), CInt(nudAltShift2.Value))
            .WorkGroups = wglWorkGroups.SelectedWorkGroups
            If optDetailed.Checked Then
                .AnalysisType = WorkgroupAnalysisType.Detailed
            ElseIf optBatch.Checked Then
                .AnalysisType = WorkgroupAnalysisType.Batch
            ElseIf optWorkGroupListShiftCondensed.Checked Then
                .AnalysisType = WorkgroupAnalysisType.WorkGroupListShiftCondensed
            ElseIf optWorkGroupListShiftWise.Checked Then
                .AnalysisType = WorkgroupAnalysisType.WorkGroupListShiftwise
            ElseIf optWorkGroupListShiftwiseCompressed.Checked Then
                .AnalysisType = WorkgroupAnalysisType.WorkGroupListShiftwiseCompressed
            ElseIf optAnalysisLine.Checked Then
                .AnalysisType = WorkgroupAnalysisType.WorkGroupListShiftwiseWorkLoad
            End If

            .IncludeSuspended = chkIncludeSuspended.Checked

            'TODO: Hier im Bedarfsfall wieder ein Kontrollkästchen einfügen und abfragen.
            .IncludeWorkLoad = False

            'TODO: Fieldassignments speichern
            If optTargetPrinter.Checked Then
                .AnalysisTarget = AnalysisTarget.DirectlyToPrinter
            ElseIf optPreviewBeforePrint.Checked Then
                .AnalysisTarget = AnalysisTarget.PreviewBeforePrint
            ElseIf optCSVExport.Checked Then
                .AnalysisTarget = AnalysisTarget.CSVExport
            End If
        End With

    End Sub

    Private Sub FromAnalysisParameters()
        With myAnalysisParameters
            drpMain.DateRangeValue = .DateRange
            chkShift1.Checked = .ShiftParameters.ConsiderShift1
            chkShift2.Checked = .ShiftParameters.ConsiderShift2
            chkShift3.Checked = .ShiftParameters.ConsiderShift3
            chkShift4.Checked = .ShiftParameters.ConsiderShift4
            optUseAlternatingShifts.Checked = .ShiftParameters.AlternateShifts
            nudAltShiftDays.Value = .ShiftParameters.DaysAfterToAlternate
            nudAltShift1.Value = .ShiftParameters.AlternatingFirstShift
            nudAltShift2.Value = .ShiftParameters.AlternatingSecondShift

            'Vorselektieren
            For Each locLvw As ListViewItem In wglWorkGroups.Items
                locLvw.Selected = False
            Next

            For Each locItem As Integer In myAnalysisParameters.SelectedWorkgroups
                For Each locLvw As ListViewItem In wglWorkGroups.Items
                    If Integer.Parse(locLvw.Name) = locItem Then
                        locLvw.Selected = True
                    End If
                Next
            Next

            Select Case .AnalysisType
                Case WorkgroupAnalysisType.Batch
                    optBatch.Checked = True
                Case WorkgroupAnalysisType.WorkGroupListShiftCondensed
                    optWorkGroupListShiftCondensed.Checked = True
                Case WorkgroupAnalysisType.Detailed
                    optDetailed.Checked = True
                Case WorkgroupAnalysisType.WorkGroupListShiftwiseWorkLoad
                    optAnalysisLine.Checked = True
                Case WorkgroupAnalysisType.WorkGroupListShiftwise
                    optWorkGroupListShiftWise.Checked = True
                Case WorkgroupAnalysisType.WorkGroupListShiftwiseCompressed
                    optWorkGroupListShiftwiseCompressed.Checked = True
            End Select

            chkIncludeSuspended.Checked = .IncludeSuspended
            'Todo: Das im Bedarfsfall wieder reaktivieren, damit
            'chkIncludeWorkload.Checked = False

            'TODO: Fieldassignments zuordnen
            Select Case .AnalysisTarget
                Case AnalysisTarget.DirectlyToPrinter
                    optTargetPrinter.Checked = True
                Case AnalysisTarget.PreviewBeforePrint
                    optPreviewBeforePrint.Checked = True
                Case AnalysisTarget.CSVExport
                    optCSVExport.Checked = True
            End Select
        End With
    End Sub

    Private Sub btnAllShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllShifts.Click
        chkShift1.Checked = True
        chkShift2.Checked = True
        chkShift3.Checked = True
        chkShift4.Checked = True
    End Sub
End Class
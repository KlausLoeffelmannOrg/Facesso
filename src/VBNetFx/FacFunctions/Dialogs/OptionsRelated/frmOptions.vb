Imports Facesso.Data
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.Win32

Public Class frmOptions

    Private myLayout As LayoutAndNumberformats

    Public Function HandleDialog() As DialogResult
        Return Me.ShowDialog()
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveParameters()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim locTsd As TimeSettingDetails = _
        DirectCast( _
            FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("GlobalTimeSettingDetailsTemplate", _
            New TimeSettingDetails(#1/1/2003 6:00:00 AM#, #1/1/2003 2:00:00 PM#, _
                                #1/1/2003 10:00:00 PM#, #1/2/2003 5:00:00 AM#, _
                                Nothing, Nothing, 30)), _
        TimeSettingDetails)
        UcTimeDetailsSettings.TSDetails = locTsd
        SetupLayoutParameters()
        SetupFacessoGeneralOptions()
    End Sub

    Sub SetupLayoutParameters()
        myLayout = DirectCast(FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("LayoutAndNumberFormats", New LayoutAndNumberformats), LayoutAndNumberformats)
        lblFontU1.Text = myLayout.U1Font.FontSettingsDescription
        lblFontU2.Text = myLayout.U2Font.FontSettingsDescription
        lblFontU3.Text = myLayout.U3Font.FontSettingsDescription
        lblTableHeaderFont.Text = myLayout.TableHeaderFont.FontSettingsDescription
        lblTextAndTableBodyFont.Text = myLayout.TextAndTableBodyFont.FontSettingsDescription
        'pbxLogo.Image = locLayout.LogoBitmap
        cmbGridStyle.SelectedIndex = myLayout.Gridstyle
        cmbHMinutesPrecision.SelectedIndex = myLayout.HMinPrecision

    End Sub

    Sub SetupFacessoGeneralOptions()
        Dim locFacessoGeneralOptions As FacessoGeneralOptions = _
        DirectCast( _
            FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", _
            New FacessoGeneralOptions(False, False, True, False, 60)), FacessoGeneralOptions)
        chkAutomateMainFormUpdate.Checked = locFacessoGeneralOptions.AutomateMainFormUpdate
        chkSaturdayIsWorkday.Checked = locFacessoGeneralOptions.SaturdayIsWorkday
        chkSundayIsWorkday.Checked = locFacessoGeneralOptions.SundayIsWorkday
        txtSQLLoginString.Text = _
                Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", _
                                        "ConnectionString", Nothing).ToString

        FacessoPathSettings.InstallationFolder = FacessoGeneric.InstallationFolder
        FacessoPathSettings.UpdateFolder = FacessoGeneric.UpdateFolder
        FacessoPathSettings.UpdateUrl = FacessoGeneric.UpdateUrl
        FacessoPathSettings.SharedFolder = FacessoGeneric.SharedFolder
        nibThresholdFirstShift.TypeSafeValue = FacessoGeneric.FirstShiftThresholdInMin
        If FacessoGeneric.FallbackStartTime < #1/1/2003# Then
            FacessoGeneric.FallbackStartTime = FacessoGeneric.FallbackStartTime.AddYears(2003)
        End If

        If FacessoGeneric.FallbackEndTime < #1/1/2003# Then
            FacessoGeneric.FallbackEndTime = FacessoGeneric.FallbackEndTime.AddYears(2003)
        End If
        dtbFallBackTimeStart.TypeSafeValue = FacessoGeneric.FallbackStartTime
        dtbFallBackTimeEnd.TypeSafeValue = FacessoGeneric.FallbackEndTime

        chkShowIssueListPriorToImport.Checked = locFacessoGeneralOptions.ShowIssueListPriorToImport
        chkShowTimeLogPriorToImport.Checked = locFacessoGeneralOptions.ShowTimeLogPriorToImport

    End Sub

    Sub SaveGeneralOptions()
        Dim locFacessoGeneralOptions As New FacessoGeneralOptions(
        chkSaturdayIsWorkday.Checked, chkSundayIsWorkday.Checked,
        True, chkAutomateMainFormUpdate.Checked, 60)
        FacessoGeneric.FacessoUserSettings.Settings.SetItem("FacessoGeneralOptions",
        locFacessoGeneralOptions)

        Try
            'Verzeichnisse und Urls speichern
            FacessoGeneric.UpdateFolder = FacessoPathSettings.UpdateFolder
            FacessoGeneric.UpdateUrl = FacessoPathSettings.UpdateUrl
            FacessoGeneric.SharedFolder = FacessoPathSettings.SharedFolder
            FacessoGeneric.InstallationFolder = FacessoPathSettings.InstallationFolder
        Catch ex As Exception
            MessageBox.Show("Sie können alle Einstellungen nur ändern, wenn Sie als Administrator angemeldet sind.")
        End Try

        locFacessoGeneralOptions.ShowIssueListPriorToImport = chkShowIssueListPriorToImport.Checked
        locFacessoGeneralOptions.ShowTimeLogPriorToImport = chkShowTimeLogPriorToImport.Checked
    End Sub

    Sub SaveParameters()
        SaveGeneralOptions()
        FacessoGeneric.SaveGlobalSettings()
        FacessoGeneric.SaveUserSettings()
        FacessoGeneric.FallbackStartTime = dtbFallBackTimeStart.TypeSafeValue
        FacessoGeneric.FallbackEndTime = dtbFallBackTimeEnd.TypeSafeValue
        FacessoGeneric.FirstShiftThresholdInMin = nibThresholdFirstShift.TypeSafeValue
    End Sub

    Private Sub HandleFontButtons(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles btnU1Font.Click, btnU2Font.Click, btnU3Font.Click, _
                        btnTableHeaderFont.Click, btnTextBodyAndTableBodyFont.Click
        Dim locFontDialog As New FontDialog

        locFontDialog.ShowEffects = True
        Dim locDR As DialogResult = locFontDialog.ShowDialog()
        If locDR = Windows.Forms.DialogResult.Cancel Then Exit Sub

        If sender Is Me.btnU1Font Then
            myLayout.U1Font = New SerializableFontSetting(locFontDialog.Font)
            lblFontU1.Text = myLayout.U1Font.FontSettingsDescription
        ElseIf sender Is Me.btnU2Font Then
            myLayout.U2Font = New SerializableFontSetting(locFontDialog.Font)
            lblFontU2.Text = myLayout.U2Font.FontSettingsDescription
        ElseIf sender Is Me.btnU3Font Then
            myLayout.U3Font = New SerializableFontSetting(locFontDialog.Font)
            lblFontU3.Text = myLayout.U3Font.FontSettingsDescription
        ElseIf sender Is Me.btnTableHeaderFont Then
            myLayout.TableHeaderFont = New SerializableFontSetting(locFontDialog.Font)
            lblTableHeaderFont.Text = myLayout.TableHeaderFont.FontSettingsDescription
        ElseIf sender Is Me.btnTextBodyAndTableBodyFont Then
            myLayout.TextAndTableBodyFont = New SerializableFontSetting(locFontDialog.Font)
            lblTextAndTableBodyFont.Text = myLayout.TextAndTableBodyFont.FontSettingsDescription
        End If
    End Sub

    Private Sub cmbGridStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGridStyle.SelectedIndexChanged
        myLayout.Gridstyle = CType(cmbGridStyle.SelectedIndex, FacessoLayoutGridstyle)
    End Sub

    Private Sub cmbHMinutesPrecision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHMinutesPrecision.SelectedIndexChanged
        myLayout.HMinPrecision = CByte(cmbHMinutesPrecision.SelectedIndex)
    End Sub

    Private Sub btnSetSqlLoginString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso\Classes", _
                                "ConnectionString", txtSQLLoginString.Text)
        MessageBox.Show("Ein Neustart ist erforderlich, damit die Änderungen wirksam werden!", "Neustart erforderlich!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAssignToWorkgroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignToWorkgroups.Click
        Dim locFrm As New frmAssignTimeSettingsToWorkGroups
        Dim locTsd As TimeSettingDetails = _
        DirectCast( _
            FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("GlobalTimeSettingDetailsTemplate", _
            New TimeSettingDetails(#1/1/2003 6:00:00 AM#, #1/1/2003 2:00:00 PM#, _
                                #1/1/2003 10:00:00 PM#, #1/2/2003 5:00:00 AM#, _
                                Nothing, Nothing, 30)), _
            TimeSettingDetails)
        locFrm.AssignToSelected(locTsd)
    End Sub
End Class
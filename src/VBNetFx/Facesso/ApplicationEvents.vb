Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            FacessoGeneric.AppSettings.Save()
        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            'Deutsche Kultur erzwingen im Bedarfsfall
            Globalization.CultureInfo.DefaultThreadCurrentCulture = New Globalization.CultureInfo("de-DE")
            Globalization.CultureInfo.DefaultThreadCurrentUICulture = New Globalization.CultureInfo("de-DE")

            'Splash-Dialog
            Dim locSplash As New frmSplash
            locSplash.Show()

            'Queue-Process zum Anzeigen.
            Me.DoEvents()

            'Ist Setup ordnungsgemäß durchgeführt?
            If Not FacessoGeneric.IsSetup Then
                MessageBox.Show("Facesso kann keinen Hinweis darauf finden, dass die Software bereits mit FacessoConfig konfiguriert wurde." & vbNewLine & "Bitte starten Sie FacessoConfig aus dem Start-Menü (ActiveDevelop/Facesso). Sie benötigen für die Konfiguration lokale Administratorrechte.",
                                "Facesso-Konfigurations:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True
            Else

                'Ist Datenbank-Setup ordnungsgemäß durchgeführt?
                FacessoGeneric.InitializeComponent()
                If Not FacessoGeneric.IsDatabaseSetup Then
                    Dim locDbSetupWizard As New frmDbSetupWizard
                    locDbSetupWizard.ShowDialog()
                    e.Cancel = True
                Else

                    'Schema-Update im Bedarfsfall.
                    Dim dmUpdater As New Facesso.Data.DatenModelUpdater(FacessoGeneric.SQLConnectionString, True)
                    If dmUpdater.CheckIfUpdateRequired Then
                        'TODO: An Facesso-Meldungen anpassen
                        MessageBox.Show("Es müssen Änderungen an der Datenbank vorgenommen werden. Alle Facesso-Programme müssen - mit Ausnahme Ihres Programms - beendet werden. Klicken sie auf OK, wenn dieses erfolgt ist.", "WICHTIGER HINWEIS")
                        Try
                            dmUpdater.PerformSchemaUpdate()
                        Catch ex As Exception
                            MessageBox.Show("Das Datenmodell konnte nicht angepasst werden.Grund:" & ex.Message, "Hinweis")
                            e.Cancel = True

                        End Try
                    End If

                    'Wenn wir hier landen, ist alles gut!
                    If Not e.Cancel Then
                        'Checken, ob die Lizenz gültig ist und nur dann das Login durchführen.
                        'Facesso-Generic ist eine Singleton-Klasse, die die Lizenzinformation ermittelt,
                        'überprüft, speichert, die Info hält, welche Benutzer was machen darf,
                        'das Login-durchführt und den angemeldeten Benutzer gegen die Lizenzinfo abgleicht.
                        FacessoGeneric.SetupLicenseInfoAndLogin()
                    End If
                End If
            End If

            'Entsorgen ohne Wenn und Aber!
            locSplash.Dispose()
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            If e.Exception.GetType Is GetType(ActiveDev.ADLicenseUnvalidException) Then
                MessageBox.Show("Facesso hat ein Problem mit den Lizensierungsinformationen festgestellt." & vbNewLine & _
                                "Der genaue Problemtext lautet:" & vbNewLine & vbNewLine & _
                                e.Exception.Message, "Lizenzunstimmigkeiten", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If e.Exception.GetType Is GetType(FacessoLoginException) Then
                MessageBox.Show("Sie haben den Login-Vorgang abgebrochen, und Faccesso.NET wird daher nun beendet!", _
                                "Abbruch des Login-Vorgangs!", MessageBoxButtons.OK, _
                                MessageBoxIcon.Exclamation)
            ElseIf e.Exception.GetType Is GetType(FacessoEndOfSetupException) Then
                MessageBox.Show("Der Abschluss bzw. Abbruch der Installation macht einen Neustart der Anwendung erforderlich.", _
                                "Facesso-Setup beendet.", MessageBoxButtons.OK, _
                                MessageBoxIcon.Exclamation)
            Else
                Dim locError As New frmError()
                locError.HandleDialog(e.Exception)
            End If

        End Sub
    End Class

End Namespace


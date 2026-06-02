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
            'Enable diagnostic file logging when FACESSO_DIAG_LOG is set (e.g. in containers)
            Dim diagLogPath = Environment.GetEnvironmentVariable("FACESSO_DIAG_LOG")
            If Not String.IsNullOrEmpty(diagLogPath) Then
                Try
                    IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(diagLogPath))
                    Diagnostics.Trace.Listeners.Add(New Diagnostics.TextWriterTraceListener(diagLogPath))
                    Diagnostics.Trace.AutoFlush = True
                Catch
                End Try
            End If

            Diagnostics.Trace.TraceInformation("Facesso startup beginning.")
            Diagnostics.Trace.TraceInformation("UserInteractive={0}, CommandLine={1}",
                Environment.UserInteractive, Environment.CommandLine)

            'Deutsche Kultur erzwingen im Bedarfsfall
            Globalization.CultureInfo.DefaultThreadCurrentCulture = New Globalization.CultureInfo("de-DE")
            Globalization.CultureInfo.DefaultThreadCurrentUICulture = New Globalization.CultureInfo("de-DE")

            'Splash-Dialog (skip in non-interactive environments such as containers)
            Dim locSplash As frmSplash = Nothing
            If Environment.UserInteractive Then
                locSplash = New frmSplash
                locSplash.Show()
                Me.DoEvents()
            End If

            'Ist Setup ordnungsgemäß durchgeführt?
            Diagnostics.Trace.TraceInformation("Checking FacessoGeneric.IsSetup...")
            If Not FacessoGeneric.IsSetup Then
                Diagnostics.Trace.TraceWarning("Facesso is not configured.")
                If Environment.UserInteractive Then
                    MessageBox.Show("Facesso kann keinen Hinweis darauf finden, dass die Software bereits mit FacessoConfig konfiguriert wurde." & vbNewLine & "Bitte starten Sie FacessoConfig aus dem Start-Menü (ActiveDevelop/Facesso). Sie benötigen für die Konfiguration lokale Administratorrechte.",
                                    "Facesso-Konfigurations:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Console.Error.WriteLine("Facesso is not configured. Please run FacessoConfig first.")
                End If
                e.Cancel = True
            Else

                'Ist Datenbank-Setup ordnungsgemäß durchgeführt?
                Diagnostics.Trace.TraceInformation("Initializing FacessoGeneric...")
                FacessoGeneric.InitializeComponent()
                Diagnostics.Trace.TraceInformation("Checking IsDatabaseSetup...")
                If Not FacessoGeneric.IsDatabaseSetup Then
                    Diagnostics.Trace.TraceWarning("Database is not configured.")
                    If Environment.UserInteractive Then
                        Dim locDbSetupWizard As New frmDbSetupWizard
                        locDbSetupWizard.ShowDialog()
                    Else
                        Console.Error.WriteLine("Database is not configured. Please run database setup first.")
                    End If
                    e.Cancel = True
                Else

                    'Schema-Update im Bedarfsfall.
                    Diagnostics.Trace.TraceInformation("Checking schema update...")
                    Dim dmUpdater As New Facesso.Data.DatenModelUpdater(FacessoGeneric.SQLConnectionString, True)
                    If dmUpdater.CheckIfUpdateRequired Then
                        Diagnostics.Trace.TraceInformation("Schema update required, performing...")
                        If Environment.UserInteractive Then
                            'TODO: An Facesso-Meldungen anpassen
                            MessageBox.Show("Es müssen Änderungen an der Datenbank vorgenommen werden. Alle Facesso-Programme müssen - mit Ausnahme Ihres Programms - beendet werden. Klicken sie auf OK, wenn dieses erfolgt ist.", "WICHTIGER HINWEIS")
                        End If
                        Try
                            dmUpdater.PerformSchemaUpdate()
                            Diagnostics.Trace.TraceInformation("Schema update completed.")
                        Catch ex As Exception
                            Diagnostics.Trace.TraceError("Schema update failed: " & ex.ToString())
                            If Environment.UserInteractive Then
                                MessageBox.Show("Das Datenmodell konnte nicht angepasst werden.Grund:" & ex.Message, "Hinweis")
                            Else
                                Console.Error.WriteLine("Schema update failed: " & ex.Message)
                            End If
                            e.Cancel = True

                        End Try
                    End If

                    'Wenn wir hier landen, ist alles gut!
                    If Not e.Cancel Then
                        Diagnostics.Trace.TraceInformation("Setup OK. Performing login...")
                        FacessoGeneric.SetupLicenseInfoAndLogin()
                        Diagnostics.Trace.TraceInformation("Login completed successfully.")
                    End If
                End If
            End If

            'Entsorgen ohne Wenn und Aber!
            If locSplash IsNot Nothing Then locSplash.Dispose()
            Diagnostics.Trace.TraceInformation("Facesso startup finished. Cancel={0}", e.Cancel)
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            If Not Environment.UserInteractive Then
                Diagnostics.Trace.TraceError("Unhandled exception (non-interactive): " & e.Exception.ToString())
                Console.Error.WriteLine("Unhandled exception: " & e.Exception.ToString())
                Environment.ExitCode = 1
                e.ExitApplication = True
                Exit Sub
            End If

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


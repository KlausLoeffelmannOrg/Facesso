Imports System.Windows.Forms

''' <summary>
''' Dient zur Implementierung einer Assistenten-Funktionalität (Wizard) auf Basis einer Registerkartengruppe 
''' (TabControl-Steuerelement) innerhalb eines Formulars. 
''' </summary>
''' <remarks>Dieser WizardControler benötigt zum Funktionieren 
''' eine "Zurück"- ("Previous"-) Schaltfläche, eine "Weiter"- ("Next"-Schaltfläche), 
''' eine "Abbrechen"- ("Cancel"-) Schaltfläche sowie ein TabControl-Steuerelement auf einem bereits 
''' instanzierten und dargestellten Formular, damit er seine Arbeit aufnehmen kann.<cr></cr>
''' Mit der Initialize-Methode wird ihm die Steuerung über die Darstellung der Assistenten-Schritte 
''' übergeben.<cr></cr>
''' Das StepChange-Ereignis wird aufgerufen, wenn der Assistent einen Schritt abgeschlossen hat. 
''' Die WizardStepChangeEventArgs erlauben es dabei, in die Steuerung einzugreifen (beispielsweise 
''' den Sprung zum nächsten Schritt zu verbieten) oder Informationen über den aktuellen 
''' Schritt abzurufen.<cr></cr>
''' Das Finished-Ereignis wird beim Abschluss des Assistenten ausgelöst. Das Cancel-Ereignis wird 
''' beim Abbruch des Assistenten ausgelöst.<cr></cr>
''' <b>HINWEIS</b>: Ordnen Sie das Registerkarten-Steuerelement (TabControl) auf dem Formular so an, 
''' dass die Registerzungen komplett aus dem oberen Teil herausragen, sodass das Steuerelement 
''' selbst nicht als Registerkarte erkannt werden kann, aber dennoch auf den einzelnen Registerkarten 
''' die Container für die jeweiligen Assistentenschritte zur Verfügung stellt.</remarks>
Public Class ADWizardController

    Dim WithEvents myPrevButton As Button
    Dim WithEvents myNextButton As Button
    Dim WithEvents myCancelButton As Button
    Dim myTabControl As TabControl
    Dim myMaxSteps As Integer
    Dim myCurrentStep As Integer
    Dim mySkipAllRemainingStepSource As Integer

    ''' <summary>
    ''' Wird ausgelöst, wenn der Anwender durch Anklicken von "Weiter" oder "Zurück" zum nächsten oder
    ''' vorherigen Assistentenschritt gewechselt hat.
    ''' </summary>
    ''' <param name="sender">Die Instanz, die dieses Ereignis ausgelöst hat.</param>
    ''' <param name="e">Eine Instanz der Klasse AdWizardStepChangeEventArgs, die nähere Informationen zum Ereignis bereit hält.</param>
    ''' <remarks></remarks>
    Public Event StepChanged(ByVal sender As Object, ByVal e As ADWizardStepChangeEventArgs)

    ''' <summary>
    ''' Wird ausgelöst, wenn der Anwender den Assistenten beendet hat.
    ''' </summary>
    ''' <param name="sender">Die Instanz, die dieses Ereignis ausgelöst hat.</param>
    ''' <param name="e">Eine Instanz der EventArgs-Klasse, die für dieses Ereignis keine weiteren 
    ''' Informationen liefert, sondern nur aus Ereignis-Konventionsgründen bestandteil dieser 
    ''' Parameterliste ist.</param>
    ''' <remarks></remarks>
    Public Event Finished(ByVal sender As Object, ByVal e As EventArgs)

    ''' <summary>
    ''' Wird ausgelöst, wenn der Anwender den Assistenten abgebrochen hat.
    ''' </summary>
    ''' <param name="sender">Die Instanz, die dieses Ereignis ausgelöst hat.</param>
    ''' <param name="e">Eine Instanz der EventArgs-Klasse, die für dieses Ereignis keine weiteren 
    ''' Informationen liefert, sondern nur aus Ereignis-Konventionsgründen bestandteil dieser 
    ''' Parameterliste ist.</param>
    ''' <remarks></remarks>
    Public Event Cancel(ByVal sender As Object, ByVal e As EventArgs)

    ''' <summary>
    ''' Erstellt eine Instanz dieser Klasse und richtet die notwendigen Steuerelemente ein, die sich 
    ''' auf einem bereits instanzierten Formular befinden müssen.
    ''' </summary>
    ''' <param name="prevButton">Das Button-Steuerelement, das die "Zurück"-Schaltfläche auf dem Formular darstellt.</param>
    ''' <param name="nextButton">Das Button-Steuerelement, das die "Weiter"-Schaltfläche auf dem Formular darstellt.</param>
    ''' <param name="CancelButton">Das Button-Steuerelement, das die "Abbrechen"-Schaltfläche auf dem Formular darstellt.</param>
    ''' <param name="tabControl">Das TabControl-Steuerelement, das die einzelnen Steuerelemente in Form einer Registerkarte enthält.</param>
    ''' <remarks></remarks>
    Sub New(ByVal prevButton As Button, ByVal nextButton As Button, ByVal CancelButton As Button, ByVal tabControl As TabControl)
        myMaxSteps = tabControl.TabCount
        If myMaxSteps < 2 Then
            Dim up As New ArgumentOutOfRangeException(tabControl.Name & ".TabCount", _
            "More than 2 Tabs must be provided on the TabControl to invoke the WizardController properly!")
            Throw up
        End If
        myPrevButton = prevButton
        myNextButton = nextButton
        myCancelButton = CancelButton
        myTabControl = tabControl
        myTabControl.SelectedIndex = 0
        myCurrentStep = 0
    End Sub

    ''' <summary>
    ''' Übergibt nach erfolgreicher Instanzierung die Steuerung des Assistenten an die Instanz dieser Klasse.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()
        Dim locStepChange As New ADWizardStepChangeEventArgs(0, False, ADWizardStepAction.NoChange, False)
        RaiseEvent StepChanged(Me, locStepChange)
        myNextButton.Enabled = locStepChange.NextStepAllowed
        myPrevButton.Enabled = False
    End Sub

    ''' <summary>
    ''' Sollte aufgerufen werden, wenn der nächste Assistentenschritt gezielt erlaubt werden soll.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllowNextStep()
        myNextButton.Enabled = True
    End Sub

    ''' <summary>
    ''' Sollte aufgerufen werden, wenn der nächste Assistentenschritt gezielt verhindert werden soll, 
    ''' da es auf der aktuellen Assistentenseite beispielsweise noch Eingabefehler gibt.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ForbidNextStep()
        myNextButton.Enabled = False
    End Sub

    Private Sub myNextButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles myNextButton.Click

        If myCurrentStep = myMaxSteps - 1 Then
            RaiseEvent Finished(Me, New EventArgs())
            Return
        End If

        Dim locStepChange As New ADWizardStepChangeEventArgs(myCurrentStep, False, ADWizardStepAction.NextStep, False)
        RaiseEvent StepChanged(Me, locStepChange)
        If locStepChange.Cancel Then Exit Sub

        If locStepChange.WizardStepAction = ADWizardStepAction.SkipAllRemainingSteps Then
            mySkipAllRemainingStepSource = myCurrentStep
            myCurrentStep = myMaxSteps - 2
        Else
            mySkipAllRemainingStepSource = 0
        End If

        If locStepChange.WizardStepAction = ADWizardStepAction.SkipToDesiredStep Then
            myCurrentStep = locStepChange.DesiredNextStepNo
        Else
            myCurrentStep += 1
        End If

        myPrevButton.Enabled = True
        If myCurrentStep = myMaxSteps - 1 Then
            myNextButton.Text = "Fertigstellen"
        End If
        myTabControl.SelectTab(myCurrentStep)
        myNextButton.Enabled = locStepChange.NextStepAllowed
    End Sub

    Private Sub myCancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles myCancelButton.Click
        RaiseEvent Cancel(Me, New EventArgs())
    End Sub

    Private Sub myPrevButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles myPrevButton.Click
        Dim locStepChange As New ADWizardStepChangeEventArgs(myCurrentStep, False, ADWizardStepAction.PreviousStep, False)
        RaiseEvent StepChanged(Me, locStepChange)
        If locStepChange.Cancel Then Exit Sub

        myNextButton.Enabled = True

        If locStepChange.WizardStepAction = ADWizardStepAction.SkipToDesiredStep Then
            myCurrentStep = locStepChange.DesiredNextStepNo
            If myCurrentStep = myMaxSteps - 1 Then
                myNextButton.Text = "Weiter >"
            End If
            myTabControl.SelectTab(myCurrentStep)
            Exit Sub
        End If

        If myCurrentStep = 1 Then
            myPrevButton.Enabled = False
        End If

        If myCurrentStep = myMaxSteps - 1 Then
            myNextButton.Text = "Weiter >"
            If mySkipAllRemainingStepSource > 0 Then
                myCurrentStep = mySkipAllRemainingStepSource + 1
            End If
        End If
        myCurrentStep -= 1
        myTabControl.SelectTab(myCurrentStep)
    End Sub
End Class

''' <summary>
''' Ereignisparameter, die die näheren Umstände des AdWizardStepChange-Ereignisses beschreiben.
''' </summary>
''' <remarks></remarks>
Public Class ADWizardStepChangeEventArgs
    Inherits EventArgs

    Private myNewStepNo As Integer
    Private myNextStepAllowed As Boolean
    Private myStepAction As ADWizardStepAction
    Private myCancel As Boolean
    Private myDesiredNextStepNo As Integer

    ''' <summary>
    ''' Erstellt eine Instanz dieser Klasse und legt ihre Parameter fest.
    ''' </summary>
    ''' <param name="NewStepNo">Die Nummer des nächsten auszuführenden Schritt des Assistenten.</param>
    ''' <param name="NextStepAllowed">Bestimmt, ob der nächste Schritt erlaubt ist.</param>
    ''' <param name="stepAction">Ein Wert der AdWizardStepAction-Enumeration, der nähere 
    ''' Auskunft darüber gibt, was zum Wechsel des Schritts geführt hat.</param>
    ''' <param name="cancel">Flag, mit dem der Aufruf des nächsten Schritts abgebrochen werden kann.</param>
    ''' <remarks></remarks>
    Sub New(ByVal NewStepNo As Integer, ByVal NextStepAllowed As Boolean, _
            ByVal stepAction As ADWizardStepAction, ByVal cancel As Boolean)
        myNewStepNo = NewStepNo
        myNextStepAllowed = NextStepAllowed
        myStepAction = stepAction
        myCancel = cancel
    End Sub

    ''' <summary>
    ''' Bestimmt oder ermittelt die nächste Nummer des Assistentenschritts.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NewStepNo() As Integer
        Get
            Return myNewStepNo
        End Get
        Set(ByVal value As Integer)
            myNewStepNo = value
        End Set
    End Property

    ''' <summary>
    ''' Bestimmt oder ermittelt, ob der nächste Assistentenschritt erlaubt ist. Dieser Wert kann verändert 
    ''' werden, um so den Aufruf einer anderen Assistentenseite zu unterbinden, weil beispielsweise die 
    ''' aktuelle Assistentenseite noch Eingabefehler enthält. Die Schaltfläche für 'Weiter' wird dann 
    ''' unanwählbar (Enabled=false).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NextStepAllowed() As Boolean
        Get
            Return myNextStepAllowed
        End Get
        Set(ByVal value As Boolean)
            myNextStepAllowed = value
        End Set
    End Property

    ''' <summary>
    ''' Bestimmt oder ermittelt, welche Aktion zum Wechsel des Assistenschritts geführt hat.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WizardStepAction() As ADWizardStepAction
        Get
            Return myStepAction
        End Get
        Set(ByVal value As ADWizardStepAction)
            myStepAction = value
        End Set
    End Property

    ''' <summary>
    ''' Bestimmt oder ermittelt, ob der Wechsel zum nächsten Assistentenschritt verhindert werden soll.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Cancel() As Boolean
        Get
            Return myCancel
        End Get
        Set(ByVal value As Boolean)
            myCancel = value
        End Set
    End Property

    ''' <summary>
    ''' Bestimmt oder ermittelt, welcher Schritt der nächste Schritt sein soll. Damit ist ein 
    ''' Auslassen bestimmter Assistentenschritte möglich.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DesiredNextStepNo() As Integer
        Get
            Return myDesiredNextStepNo
        End Get
        Set(ByVal value As Integer)
            myDesiredNextStepNo = value
        End Set
    End Property
End Class

''' <summary>
''' Enumeration, die bestimmt, welcher Aktion für einen Wechsel zu einer anderen Assistenseite 
''' verantwortlich war.
''' </summary>
''' <remarks></remarks>
Public Enum ADWizardStepAction
    ''' <summary>
    ''' Es gab keinen Seitenwechsel.
    ''' </summary>
    ''' <remarks></remarks>
    NoChange

    ''' <summary>
    ''' Es soll zum nächsten Schritt gewechselt werden.
    ''' </summary>
    ''' <remarks></remarks>
    NextStep

    ''' <summary>
    ''' Es soll zum vorherigen Schritt gewechselt werden.
    ''' </summary>
    ''' <remarks></remarks>
    PreviousStep

    ''' <summary>
    ''' Alle übrigen Schritte bis zum letzten Schritt sollen übersprungen werden.
    ''' </summary>
    ''' <remarks></remarks>
    SkipAllRemainingSteps

    ''' <summary>
    ''' Es soll gezielt eine bestimmte Registerkarte aufgerufen werden.
    ''' </summary>
    ''' <remarks></remarks>
    SkipToDesiredStep
End Enum

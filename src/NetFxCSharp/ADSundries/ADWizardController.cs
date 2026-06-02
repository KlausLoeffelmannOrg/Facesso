using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ActiveDev
{

    /// <summary>
/// Dient zur Implementierung einer Assistenten-Funktionalität (Wizard) auf Basis einer Registerkartengruppe 
/// (TabControl-Steuerelement) innerhalb eines Formulars. 
/// </summary>
/// <remarks>Dieser WizardControler benötigt zum Funktionieren 
/// eine "Zurück"- ("Previous"-) Schaltfläche, eine "Weiter"- ("Next"-Schaltfläche), 
/// eine "Abbrechen"- ("Cancel"-) Schaltfläche sowie ein TabControl-Steuerelement auf einem bereits 
/// instanzierten und dargestellten Formular, damit er seine Arbeit aufnehmen kann.<cr></cr>
/// Mit der Initialize-Methode wird ihm die Steuerung über die Darstellung der Assistenten-Schritte 
/// übergeben.<cr></cr>
/// Das StepChange-Ereignis wird aufgerufen, wenn der Assistent einen Schritt abgeschlossen hat. 
/// Die WizardStepChangeEventArgs erlauben es dabei, in die Steuerung einzugreifen (beispielsweise 
/// den Sprung zum nächsten Schritt zu verbieten) oder Informationen über den aktuellen 
/// Schritt abzurufen.<cr></cr>
/// Das Finished-Ereignis wird beim Abschluss des Assistenten ausgelöst. Das Cancel-Ereignis wird 
/// beim Abbruch des Assistenten ausgelöst.<cr></cr>
/// <b>HINWEIS</b>: Ordnen Sie das Registerkarten-Steuerelement (TabControl) auf dem Formular so an, 
/// dass die Registerzungen komplett aus dem oberen Teil herausragen, sodass das Steuerelement 
/// selbst nicht als Registerkarte erkannt werden kann, aber dennoch auf den einzelnen Registerkarten 
/// die Container für die jeweiligen Assistentenschritte zur Verfügung stellt.</remarks>
    public class ADWizardController
    {

        private Button _myPrevButton;

        private Button myPrevButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _myPrevButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_myPrevButton != null)
                {
                    _myPrevButton.Click -= myPrevButton_Click;
                }

                _myPrevButton = value;
                if (_myPrevButton != null)
                {
                    _myPrevButton.Click += myPrevButton_Click;
                }
            }
        }
        private Button _myNextButton;

        private Button myNextButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _myNextButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_myNextButton != null)
                {
                    _myNextButton.Click -= myNextButton_Click;
                }

                _myNextButton = value;
                if (_myNextButton != null)
                {
                    _myNextButton.Click += myNextButton_Click;
                }
            }
        }
        private Button _myCancelButton;

        private Button myCancelButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _myCancelButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_myCancelButton != null)
                {
                    _myCancelButton.Click -= myCancelButton_Click;
                }

                _myCancelButton = value;
                if (_myCancelButton != null)
                {
                    _myCancelButton.Click += myCancelButton_Click;
                }
            }
        }
        private TabControl myTabControl;
        private int myMaxSteps;
        private int myCurrentStep;
        private int mySkipAllRemainingStepSource;

        /// <summary>
    /// Wird ausgelöst, wenn der Anwender durch Anklicken von "Weiter" oder "Zurück" zum nächsten oder
    /// vorherigen Assistentenschritt gewechselt hat.
    /// </summary>
    /// <param name="sender">Die Instanz, die dieses Ereignis ausgelöst hat.</param>
    /// <param name="e">Eine Instanz der Klasse AdWizardStepChangeEventArgs, die nähere Informationen zum Ereignis bereit hält.</param>
    /// <remarks></remarks>
        public event StepChangedEventHandler StepChanged;

        public delegate void StepChangedEventHandler(object sender, ADWizardStepChangeEventArgs e);

        /// <summary>
    /// Wird ausgelöst, wenn der Anwender den Assistenten beendet hat.
    /// </summary>
    /// <param name="sender">Die Instanz, die dieses Ereignis ausgelöst hat.</param>
    /// <param name="e">Eine Instanz der EventArgs-Klasse, die für dieses Ereignis keine weiteren 
    /// Informationen liefert, sondern nur aus Ereignis-Konventionsgründen bestandteil dieser 
    /// Parameterliste ist.</param>
    /// <remarks></remarks>
        public event FinishedEventHandler Finished;

        public delegate void FinishedEventHandler(object sender, EventArgs e);

        /// <summary>
    /// Wird ausgelöst, wenn der Anwender den Assistenten abgebrochen hat.
    /// </summary>
    /// <param name="sender">Die Instanz, die dieses Ereignis ausgelöst hat.</param>
    /// <param name="e">Eine Instanz der EventArgs-Klasse, die für dieses Ereignis keine weiteren 
    /// Informationen liefert, sondern nur aus Ereignis-Konventionsgründen bestandteil dieser 
    /// Parameterliste ist.</param>
    /// <remarks></remarks>
        public event CancelEventHandler Cancel;

        public delegate void CancelEventHandler(object sender, EventArgs e);

        /// <summary>
    /// Erstellt eine Instanz dieser Klasse und richtet die notwendigen Steuerelemente ein, die sich 
    /// auf einem bereits instanzierten Formular befinden müssen.
    /// </summary>
    /// <param name="prevButton">Das Button-Steuerelement, das die "Zurück"-Schaltfläche auf dem Formular darstellt.</param>
    /// <param name="nextButton">Das Button-Steuerelement, das die "Weiter"-Schaltfläche auf dem Formular darstellt.</param>
    /// <param name="CancelButton">Das Button-Steuerelement, das die "Abbrechen"-Schaltfläche auf dem Formular darstellt.</param>
    /// <param name="tabControl">Das TabControl-Steuerelement, das die einzelnen Steuerelemente in Form einer Registerkarte enthält.</param>
    /// <remarks></remarks>
        public ADWizardController(Button prevButton, Button nextButton, Button CancelButton, TabControl tabControl)
        {
            myMaxSteps = tabControl.TabCount;
            if (myMaxSteps < 2)
            {
                var up = new ArgumentOutOfRangeException(tabControl.Name + ".TabCount", "More than 2 Tabs must be provided on the TabControl to invoke the WizardController properly!");
                throw up;
            }
            myPrevButton = prevButton;
            myNextButton = nextButton;
            myCancelButton = CancelButton;
            myTabControl = tabControl;
            myTabControl.SelectedIndex = 0;
            myCurrentStep = 0;
        }

        /// <summary>
    /// Übergibt nach erfolgreicher Instanzierung die Steuerung des Assistenten an die Instanz dieser Klasse.
    /// </summary>
    /// <remarks></remarks>
        public void Initialize()
        {
            var locStepChange = new ADWizardStepChangeEventArgs(0, false, ADWizardStepAction.NoChange, false);
            StepChanged?.Invoke(this, locStepChange);
            myNextButton.Enabled = locStepChange.NextStepAllowed;
            myPrevButton.Enabled = false;
        }

        /// <summary>
    /// Sollte aufgerufen werden, wenn der nächste Assistentenschritt gezielt erlaubt werden soll.
    /// </summary>
    /// <remarks></remarks>
        public void AllowNextStep()
        {
            myNextButton.Enabled = true;
        }

        /// <summary>
    /// Sollte aufgerufen werden, wenn der nächste Assistentenschritt gezielt verhindert werden soll, 
    /// da es auf der aktuellen Assistentenseite beispielsweise noch Eingabefehler gibt.
    /// </summary>
    /// <remarks></remarks>
        public void ForbidNextStep()
        {
            myNextButton.Enabled = false;
        }

        private void myNextButton_Click(object sender, EventArgs e)
        {

            if (myCurrentStep == myMaxSteps - 1)
            {
                Finished?.Invoke(this, new EventArgs());
                return;
            }

            var locStepChange = new ADWizardStepChangeEventArgs(myCurrentStep, false, ADWizardStepAction.NextStep, false);
            StepChanged?.Invoke(this, locStepChange);
            if (locStepChange.Cancel)
                return;

            if (locStepChange.WizardStepAction == ADWizardStepAction.SkipAllRemainingSteps)
            {
                mySkipAllRemainingStepSource = myCurrentStep;
                myCurrentStep = myMaxSteps - 2;
            }
            else
            {
                mySkipAllRemainingStepSource = 0;
            }

            if (locStepChange.WizardStepAction == ADWizardStepAction.SkipToDesiredStep)
            {
                myCurrentStep = locStepChange.DesiredNextStepNo;
            }
            else
            {
                myCurrentStep += 1;
            }

            myPrevButton.Enabled = true;
            if (myCurrentStep == myMaxSteps - 1)
            {
                myNextButton.Text = "Fertigstellen";
            }
            myTabControl.SelectTab(myCurrentStep);
            myNextButton.Enabled = locStepChange.NextStepAllowed;
        }

        private void myCancelButton_Click(object sender, EventArgs e)
        {
            Cancel?.Invoke(this, new EventArgs());
        }

        private void myPrevButton_Click(object sender, EventArgs e)
        {
            var locStepChange = new ADWizardStepChangeEventArgs(myCurrentStep, false, ADWizardStepAction.PreviousStep, false);
            StepChanged?.Invoke(this, locStepChange);
            if (locStepChange.Cancel)
                return;

            myNextButton.Enabled = true;

            if (locStepChange.WizardStepAction == ADWizardStepAction.SkipToDesiredStep)
            {
                myCurrentStep = locStepChange.DesiredNextStepNo;
                if (myCurrentStep == myMaxSteps - 1)
                {
                    myNextButton.Text = "Weiter >";
                }
                myTabControl.SelectTab(myCurrentStep);
                return;
            }

            if (myCurrentStep == 1)
            {
                myPrevButton.Enabled = false;
            }

            if (myCurrentStep == myMaxSteps - 1)
            {
                myNextButton.Text = "Weiter >";
                if (mySkipAllRemainingStepSource > 0)
                {
                    myCurrentStep = mySkipAllRemainingStepSource + 1;
                }
            }
            myCurrentStep -= 1;
            myTabControl.SelectTab(myCurrentStep);
        }
    }

    /// <summary>
/// Ereignisparameter, die die näheren Umstände des AdWizardStepChange-Ereignisses beschreiben.
/// </summary>
/// <remarks></remarks>
    public class ADWizardStepChangeEventArgs : EventArgs
    {

        private int myNewStepNo;
        private bool myNextStepAllowed;
        private ADWizardStepAction myStepAction;
        private bool myCancel;
        private int myDesiredNextStepNo;

        /// <summary>
    /// Erstellt eine Instanz dieser Klasse und legt ihre Parameter fest.
    /// </summary>
    /// <param name="NewStepNo">Die Nummer des nächsten auszuführenden Schritt des Assistenten.</param>
    /// <param name="NextStepAllowed">Bestimmt, ob der nächste Schritt erlaubt ist.</param>
    /// <param name="stepAction">Ein Wert der AdWizardStepAction-Enumeration, der nähere 
    /// Auskunft darüber gibt, was zum Wechsel des Schritts geführt hat.</param>
    /// <param name="cancel">Flag, mit dem der Aufruf des nächsten Schritts abgebrochen werden kann.</param>
    /// <remarks></remarks>
        public ADWizardStepChangeEventArgs(int NewStepNo, bool NextStepAllowed, ADWizardStepAction stepAction, bool cancel)
        {
            myNewStepNo = NewStepNo;
            myNextStepAllowed = NextStepAllowed;
            myStepAction = stepAction;
            myCancel = cancel;
        }

        /// <summary>
    /// Bestimmt oder ermittelt die nächste Nummer des Assistentenschritts.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public int NewStepNo
        {
            get
            {
                return myNewStepNo;
            }
            set
            {
                myNewStepNo = value;
            }
        }

        /// <summary>
    /// Bestimmt oder ermittelt, ob der nächste Assistentenschritt erlaubt ist. Dieser Wert kann verändert 
    /// werden, um so den Aufruf einer anderen Assistentenseite zu unterbinden, weil beispielsweise die 
    /// aktuelle Assistentenseite noch Eingabefehler enthält. Die Schaltfläche für 'Weiter' wird dann 
    /// unanwählbar (Enabled=false).
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public bool NextStepAllowed
        {
            get
            {
                return myNextStepAllowed;
            }
            set
            {
                myNextStepAllowed = value;
            }
        }

        /// <summary>
    /// Bestimmt oder ermittelt, welche Aktion zum Wechsel des Assistenschritts geführt hat.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public ADWizardStepAction WizardStepAction
        {
            get
            {
                return myStepAction;
            }
            set
            {
                myStepAction = value;
            }
        }

        /// <summary>
    /// Bestimmt oder ermittelt, ob der Wechsel zum nächsten Assistentenschritt verhindert werden soll.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public bool Cancel
        {
            get
            {
                return myCancel;
            }
            set
            {
                myCancel = value;
            }
        }

        /// <summary>
    /// Bestimmt oder ermittelt, welcher Schritt der nächste Schritt sein soll. Damit ist ein 
    /// Auslassen bestimmter Assistentenschritte möglich.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public int DesiredNextStepNo
        {
            get
            {
                return myDesiredNextStepNo;
            }
            set
            {
                myDesiredNextStepNo = value;
            }
        }
    }

    /// <summary>
/// Enumeration, die bestimmt, welcher Aktion für einen Wechsel zu einer anderen Assistenseite 
/// verantwortlich war.
/// </summary>
/// <remarks></remarks>
    public enum ADWizardStepAction
    {
        /// <summary>
    /// Es gab keinen Seitenwechsel.
    /// </summary>
    /// <remarks></remarks>
        NoChange,

        /// <summary>
    /// Es soll zum nächsten Schritt gewechselt werden.
    /// </summary>
    /// <remarks></remarks>
        NextStep,

        /// <summary>
    /// Es soll zum vorherigen Schritt gewechselt werden.
    /// </summary>
    /// <remarks></remarks>
        PreviousStep,

        /// <summary>
    /// Alle übrigen Schritte bis zum letzten Schritt sollen übersprungen werden.
    /// </summary>
    /// <remarks></remarks>
        SkipAllRemainingSteps,

        /// <summary>
    /// Es soll gezielt eine bestimmte Registerkarte aufgerufen werden.
    /// </summary>
    /// <remarks></remarks>
        SkipToDesiredStep
    }
}
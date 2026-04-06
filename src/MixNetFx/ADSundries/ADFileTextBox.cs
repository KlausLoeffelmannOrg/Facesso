using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ActiveDev
{

    [Designer(typeof(ADFileTextBoxDesigner))]
    public partial class ADFileTextBox
    {

        private ADFileTextBoxAction myFileTextBoxAction;
        private string myInitialDirectory;
        private bool myReadOnly;
        private string myFilter;
        private string myFilename;
        private string myDefaultExt;
        private DialogResult myDialogResult;
        private bool myCheckFileExist;
        private bool myCheckPathExist;
        private bool myOverwritePrompt;

        public event FilenamePickedEventHandler FilenamePicked;

        public delegate void FilenamePickedEventHandler(object sender, ADFileTextBoxEventArgs e);

        private void Ctor2()
        {
            myFileTextBoxAction = ADFileTextBoxAction.LoadDialog;
            myReadOnly = true;
            myFilter = "Alle Dateien (*.*)|*.*";
            myFilename = "";
            myDefaultExt = "*.*";
            myInitialDirectory = "";
            myDialogResult = DialogResult.None;
            myCheckFileExist = false;
            myCheckPathExist = true;
            myOverwritePrompt = true;
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            if (myFileTextBoxAction == ADFileTextBoxAction.LoadDialog)
            {
                var locOFD = new OpenFileDialog();
                locOFD.Filter = Filter;
                locOFD.FileName = Filename;
                locOFD.DefaultExt = DefaultExt;
                locOFD.InitialDirectory = InitialDirectory;
                locOFD.CheckFileExists = CheckFileExist;
                locOFD.CheckPathExists = CheckPathExist;
                myDialogResult = locOFD.ShowDialog();
                if (myDialogResult == DialogResult.OK)
                {
                    txtFilename.Text = locOFD.FileName;
                    Filename = locOFD.FileName;
                }
                FilenamePicked?.Invoke(this, new ADFileTextBoxEventArgs(myDialogResult, Filename));
            }
            else
            {
                var locSFD = new SaveFileDialog();
                locSFD.Filter = Filter;
                locSFD.FileName = Filename;
                locSFD.DefaultExt = DefaultExt;
                locSFD.InitialDirectory = InitialDirectory;
                locSFD.CheckFileExists = CheckFileExist;
                locSFD.CheckPathExists = CheckPathExist;
                locSFD.OverwritePrompt = OverwritePrompt;
                myDialogResult = locSFD.ShowDialog();
                if (myDialogResult == DialogResult.OK)
                {
                    txtFilename.Text = locSFD.FileName;
                    Filename = locSFD.FileName;
                }
                FilenamePicked?.Invoke(this, new ADFileTextBoxEventArgs(DialogResult, Filename));
            }
        }

        public virtual DialogResult DialogResult
        {
            get
            {
                return myDialogResult;
            }
        }

        public virtual ADFileTextBoxAction FileTextBoxAction
        {
            get
            {
                return myFileTextBoxAction;
            }
            set
            {
                myFileTextBoxAction = value;
            }
        }

        public virtual string InitialDirectory
        {
            get
            {
                return myInitialDirectory;
            }
            set
            {
                myInitialDirectory = value;
            }
        }

        public virtual bool ReadOnly
        {
            get
            {
                return myReadOnly;
            }
            set
            {
                myReadOnly = value;
            }
        }

        public virtual string Filter
        {
            get
            {
                return myFilter;
            }
            set
            {
                myFilter = value;
            }
        }

        public virtual string Filename
        {
            get
            {
                return myFilename;
            }
            set
            {
                myFilename = value;
            }
        }

        public virtual string DefaultExt
        {
            get
            {
                return myDefaultExt;
            }
            set
            {
                myDefaultExt = value;
            }
        }

        public virtual bool CheckPathExist
        {
            get
            {
                return myCheckPathExist;
            }
            set
            {
                myCheckPathExist = value;
            }
        }

        public virtual bool CheckFileExist
        {
            get
            {
                return myCheckFileExist;
            }
            set
            {
                myCheckFileExist = value;
            }
        }

        public virtual bool OverwritePrompt
        {
            get
            {
                return myOverwritePrompt;
            }
            set
            {
                myOverwritePrompt = value;
            }
        }

    }

    public enum ADFileTextBoxAction
    {
        LoadDialog,
        SaveDialog
    }

    public class ADFileTextBoxEventArgs : EventArgs
    {

        private DialogResult myDialogResult;
        private string myFilename;

        public ADFileTextBoxEventArgs()
        {
            myDialogResult = DialogResult.None;
            myFilename = "";
        }

        public ADFileTextBoxEventArgs(DialogResult DResult, string Filename)
        {
            myFilename = Filename;
            myDialogResult = DResult;
        }

        public DialogResult DialogResult
        {
            get
            {
                return myDialogResult;
            }
            set
            {
                myDialogResult = value;
            }
        }

        public string Filename
        {
            get
            {
                return myFilename;
            }
            set
            {
                myFilename = value;
            }
        }

    }

    // ################################################
    // ### ControlDesigner Pendant ####################
    // ################################################

    // WICHTIG: Wenn Sie einen ControlDesigner einfügen,
    // müssen Sie den System.Windows.Forms.Design-Namespace einbinden,
    // und SystemDesign.Dll als Verweis dem Projekt hinzufügen!
    public class ADFileTextBoxDesigner : ControlDesigner
    {

        // Diese Eigenschaft müssen Sie erweitern,
        // wenn Sie eigene Initialisierungen vornehmen wollen.
        // An dieser Stelle finden Sie den exakten Code von
        // ControlDesigner.OnSetComponentDefaults, der sich um die
        // Initialisierung der 'Text'-Eigenschaft kümmert.
        // Anstelle der kompletten Implementierung reicht auch der Aufruf
        // von 'MyBase.OnSetComponentDefaults()'

        // Public Overrides Sub OnSetComponentDefaults()

        // 'Das ist hier 'geklaut' von ControlDesigner...
        // Dim locISite As ISite
        // Dim locPropDescriptor As PropertyDescriptor

        // 'ISite abrufen
        // locISite = Me.Component.Site
        // If Not locISite Is Nothing Then
        // 'Text-Property vorhanden?
        // locPropDescriptor = TypeDescriptor.GetProperties(Me.Component)("Text")
        // If Not locPropDescriptor Is Nothing Then
        // 'Ja, dann die Text-Property setzen
        // locPropDescriptor.SetValue(Me.Component, locISite.Name)
        // End If

        // 'Back-Color vorhanden?
        // locPropDescriptor = TypeDescriptor.GetProperties(Me.Component)("BackColor")
        // If Not locPropDescriptor Is Nothing Then
        // 'Ja, dann die BackColor-Property setzen
        // locPropDescriptor.SetValue(Me.Component, SystemColors.Window)
        // End If
        // End If
        // End Sub

        // Muss überschrieben werden, damit bei einem Control mit fixer
        // Größe tatsächlich nur ein vertikale Größenänderung möglich wird.
        // Die vertikalen Anfasspunkte sind dann ausgeblendet
        public override SelectionRules SelectionRules
        {
            get
            {
                object locThisComponent;
                // Dim locSelectionRules As SelectionRules

                locThisComponent = Component;
                Debug.WriteLine("Designermessage: This Component is" + (locThisComponent is null).ToString());

                return SelectionRules.Moveable | SelectionRules.Visible | SelectionRules.LeftSizeable | SelectionRules.RightSizeable;

                // Größenveränderungen von einer Eigenschaft abhängig machen:
                // Try
                // 'In Abhängigkeit von ConsiderFixedSize (die sich beispielsweise durch Multiline ändert) 
                // If Convert.ToBoolean(TypeDescriptor.GetProperties(locThisComponent).Item("ConsiderFixedSizeInternal").GetValue(locThisComponent)) Then
                // 'Nur vertikale Größenveränderungen...
                // locSelectionRules = SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.LeftSizeable Or SelectionRules.RightSizeable
                // Else
                // '...oder komplette Größenveränderungen ermöglichen
                // locSelectionRules = SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.AllSizeable
                // End If
                // Return locSelectionRules
                // Catch ex As Exception
                // Debug.WriteLine("Designermessage:" & ex.Message)
                // Return MyBase.SelectionRules
                // End Try
            }
        }
    }
}
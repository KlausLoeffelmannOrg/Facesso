Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.WIndows.Forms
Imports System.ComponentModel

<Designer(GetType(ADFileTextBoxDesigner))> _
Public Class ADFileTextBox

    Private myFileTextBoxAction As ADFileTextBoxAction
    Private myInitialDirectory As String
    Private myReadOnly As Boolean
    Private myFilter As String
    Private myFilename As String
    Private myDefaultExt As String
    Private myDialogResult As DialogResult
    Private myCheckFileExist As Boolean
    Private myCheckPathExist As Boolean
    Private myOverwritePrompt As Boolean

    Public Event FilenamePicked(ByVal sender As Object, ByVal e As ADFileTextBoxEventArgs)

    Private Sub Ctor2()
        myFileTextBoxAction = ADFileTextBoxAction.LoadDialog
        myReadOnly = True
        myFilter = "Alle Dateien (*.*)|*.*"
        myFilename = ""
        myDefaultExt = "*.*"
        myInitialDirectory = ""
        myDialogResult = DialogResult.None
        myCheckFileExist = False
        myCheckPathExist = True
        myOverwritePrompt = True
    End Sub

    Private Sub btnFileSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileSelect.Click
        If myFileTextBoxAction = ADFileTextBoxAction.LoadDialog Then
            Dim locOFD As New OpenFileDialog
            With locOFD
                .Filter = Filter()
                .FileName = Filename
                .DefaultExt = DefaultExt
                .InitialDirectory = InitialDirectory
                .CheckFileExists = CheckFileExist
                .CheckPathExists = CheckPathExist
                myDialogResult = .ShowDialog()
                If myDialogResult = DialogResult.OK Then
                    txtFilename.Text = .FileName
                    Filename = .FileName
                End If
            End With
            RaiseEvent FilenamePicked(Me, New ADFileTextBoxEventArgs(myDialogResult, Filename))
        Else
            Dim locSFD As New SaveFileDialog
            With locSFD
                .Filter = Filter()
                .FileName = Filename
                .DefaultExt = DefaultExt
                .InitialDirectory = InitialDirectory
                .CheckFileExists = CheckFileExist
                .CheckPathExists = CheckPathExist
                .OverwritePrompt = OverwritePrompt
                myDialogResult = .ShowDialog()
                If myDialogResult = DialogResult.OK Then
                    txtFilename.Text = .FileName
                    Filename = .FileName
                End If
            End With
            RaiseEvent FilenamePicked(Me, New ADFileTextBoxEventArgs(Me.DialogResult, Filename))
        End If
    End Sub

    Public Overridable ReadOnly Property DialogResult() As DialogResult
        Get
            Return myDialogResult
        End Get
    End Property

    Public Overridable Property FileTextBoxAction() As ADFileTextBoxAction
        Get
            Return Me.myFileTextBoxAction
        End Get
        Set(ByVal value As ADFileTextBoxAction)
            Me.myFileTextBoxAction = value
        End Set
    End Property

    Public Overridable Property InitialDirectory() As String
        Get
            Return Me.myInitialDirectory
        End Get
        Set(ByVal value As String)
            Me.myInitialDirectory = value
        End Set
    End Property

    Public Overridable Property [ReadOnly]() As Boolean
        Get
            Return Me.myReadOnly
        End Get
        Set(ByVal value As Boolean)
            Me.myReadOnly = value
        End Set
    End Property

    Public Overridable Property Filter() As String
        Get
            Return Me.myFilter
        End Get
        Set(ByVal value As String)
            Me.myFilter = value
        End Set
    End Property

    Public Overridable Property Filename() As String
        Get
            Return Me.myFilename
        End Get
        Set(ByVal value As String)
            Me.myFilename = value
        End Set
    End Property

    Public Overridable Property DefaultExt() As String
        Get
            Return Me.myDefaultExt
        End Get
        Set(ByVal value As String)
            Me.myDefaultExt = value
        End Set
    End Property

    Public Overridable Property CheckPathExist() As Boolean
        Get
            Return myCheckPathExist
        End Get
        Set(ByVal value As Boolean)
            myCheckPathExist = value
        End Set
    End Property

    Public Overridable Property CheckFileExist() As Boolean
        Get
            Return myCheckFileExist
        End Get
        Set(ByVal value As Boolean)
            myCheckFileExist = value
        End Set
    End Property

    Public Overridable Property OverwritePrompt() As Boolean
        Get
            Return myOverwritePrompt
        End Get
        Set(ByVal value As Boolean)
            myOverwritePrompt = value
        End Set
    End Property

End Class

Public Enum ADFileTextBoxAction
    LoadDialog
    SaveDialog
End Enum

Public Class ADFileTextBoxEventArgs
    Inherits EventArgs

    Private myDialogResult As DialogResult
    Private myFilename As String

    Sub New()
        myDialogResult = DialogResult.None
        myFilename = ""
    End Sub

    Sub New(ByVal DResult As DialogResult, ByVal Filename As String)
        myFilename = Filename
        myDialogResult = DResult
    End Sub

    Public Property DialogResult() As DialogResult
        Get
            Return myDialogResult
        End Get
        Set(ByVal value As DialogResult)
            myDialogResult = value
        End Set
    End Property

    Public Property Filename() As String
        Get
            Return myFilename
        End Get
        Set(ByVal value As String)
            myFilename = value
        End Set
    End Property

End Class

'################################################
'### ControlDesigner Pendant ####################
'################################################

'WICHTIG: Wenn Sie einen ControlDesigner einfügen,
'müssen Sie den System.Windows.Forms.Design-Namespace einbinden,
'und SystemDesign.Dll als Verweis dem Projekt hinzufügen!
Public Class ADFileTextBoxDesigner
    Inherits ControlDesigner

    'Diese Eigenschaft müssen Sie erweitern,
    'wenn Sie eigene Initialisierungen vornehmen wollen.
    'An dieser Stelle finden Sie den exakten Code von
    'ControlDesigner.OnSetComponentDefaults, der sich um die
    'Initialisierung der 'Text'-Eigenschaft kümmert.
    'Anstelle der kompletten Implementierung reicht auch der Aufruf
    'von 'MyBase.OnSetComponentDefaults()'

    'Public Overrides Sub OnSetComponentDefaults()

    '    'Das ist hier 'geklaut' von ControlDesigner...
    '    Dim locISite As ISite
    '    Dim locPropDescriptor As PropertyDescriptor

    '    'ISite abrufen
    '    locISite = Me.Component.Site
    '    If Not locISite Is Nothing Then
    '        'Text-Property vorhanden?
    '        locPropDescriptor = TypeDescriptor.GetProperties(Me.Component)("Text")
    '        If Not locPropDescriptor Is Nothing Then
    '            'Ja, dann die Text-Property setzen
    '            locPropDescriptor.SetValue(Me.Component, locISite.Name)
    '        End If

    '        'Back-Color vorhanden?
    '        locPropDescriptor = TypeDescriptor.GetProperties(Me.Component)("BackColor")
    '        If Not locPropDescriptor Is Nothing Then
    '            'Ja, dann die BackColor-Property setzen
    '            locPropDescriptor.SetValue(Me.Component, SystemColors.Window)
    '        End If
    '    End If
    'End Sub

    'Muss überschrieben werden, damit bei einem Control mit fixer
    'Größe tatsächlich nur ein vertikale Größenänderung möglich wird.
    'Die vertikalen Anfasspunkte sind dann ausgeblendet
    Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
        Get
            Dim locThisComponent As Object
            'Dim locSelectionRules As SelectionRules

            locThisComponent = Me.Component
            Debug.WriteLine("Designermessage: This Component is" & (locThisComponent Is Nothing).ToString)

            Return SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.LeftSizeable Or SelectionRules.RightSizeable

            'Größenveränderungen von einer Eigenschaft abhängig machen:
            'Try
            '    'In Abhängigkeit von ConsiderFixedSize (die sich beispielsweise durch Multiline ändert) 
            '    If Convert.ToBoolean(TypeDescriptor.GetProperties(locThisComponent).Item("ConsiderFixedSizeInternal").GetValue(locThisComponent)) Then
            '        'Nur vertikale Größenveränderungen...
            '        locSelectionRules = SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.LeftSizeable Or SelectionRules.RightSizeable
            '    Else
            '        '...oder komplette Größenveränderungen ermöglichen
            '        locSelectionRules = SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.AllSizeable
            '    End If
            '    Return locSelectionRules
            'Catch ex As Exception
            '    Debug.WriteLine("Designermessage:" & ex.Message)
            '    Return MyBase.SelectionRules
            'End Try
        End Get
    End Property
End Class
Imports System.Globalization
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports ActiveDev

<Designer(GetType(ADNullableValueControlTemplateDesigner)), _
 DefaultPropertyAttribute("Text")> _
Public MustInherit Class ADNullableValueControlTemplate(Of ADUVType As {IComparable})
    Inherits System.Windows.Forms.ContainerControl
    Implements IADNullableValueControl

    'Alle Events
    Event CaptionPlacementChanged(ByVal sender As Object, ByVal e As CaptionPlacementChangedEventArgs)
    Event CaptionAlignmentChanged(ByVal sender As Object, ByVal e As EventArgs)
    Event CaptionBorderStyleChanged(ByVal sender As Object, ByVal e As EventArgs)
    Event CaptionBackColorChanged(ByVal sender As Object, ByVal e As EventArgs)
    Event CaptionForeColorChanged(ByVal sender As Object, ByVal e As EventArgs)
    Event CaptionFontChanged(ByVal sender As Object, ByVal e As EventArgs)
    Public Event OnceModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IADNullableValueControl.OnceModifiedChanged
    Public Event ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IADNullableValueControl.ValueChanged

    '##############################################################
    'Geschützte Membervariablen für's Speichern der Eigenschaften
    '##############################################################

    '### Eigenschaften der Beschriftung ###

    'Ausrichtung der Beschriftung innen
    Protected myCaptionAlignment As Object
    'Ausrichtung der Beschriftung außen
    Protected myCaptionPlacement As Object
    'Rahmen der Beschriftung
    Protected myCaptionBorderstyle As Object
    'Speicher für Hintergrundfarbe (des CaptionControls)
    Protected myCaptionBackColor As Color
    'Speicher für Vordergrundfarbe (des CaptionControls)
    Protected myCaptionForeColor As Color
    'Speicher für Hintergrundfarbe (des ValueControls)
    Protected myBackColor As Color
    'Speicher für Auto-Einfärbe-Farbe (bei Focuserhalt; des ValueControls)
    Protected myFocusAutoColor As Color
    'Bestimmt, ob Steuerelement bei Focuserhalt eingefärbt werden soll.
    Protected myColorOnFocus As Boolean
    'Font der Beschriftung
    Protected myCaptionFont As Font
    'Speicher für den Beschiftungstext
    Protected myText As String
    'Bestimmt, ob eine Beschriftung angezeigt wird, oder nicht
    Protected myHasCaption As Boolean


    '### Eigenschaften des ValueControls ###

    'Angezeigter Wert, nachdem das Control den Focus verloren hat
    Protected myObjectForDisplaying As Object
    'Editierter Wert, der auch wieder angezeigt wird, wenn das Control den Focus bekommt
    Protected myObjectForEditing As Object
    'Der eingentliche Wert der Controls als ADVariant
    Protected myValue As IADDBNullableValue
    'DBNull erlaubt?
    Protected myIsNullAllowed As Boolean
    'Fehlermeldung, wenn Null eingegeben wurde
    Protected myIfNullMessage As String
    'Font des Wertecontrols
    Protected myValueFont As Font

    'Die Höhe des Controls, die es letzten Endes hat
    Protected myFinalHeight As Integer

    '### Eigenschaften, das gesamte Control betreffend ###

    'Länge des Beschriftungcontrols
    Protected myCaptionAreaLength As Integer
    'Länge des Valuecontrols
    Protected myValueAreaLength As Integer
    'Längenverhältnis
    Protected myLengthRatio As Double
    'Ursprünglich gewünschte Länge der Beschriftung, die gespeichert werden muss zur
    'Wiederherstellung, falls eine Einstellung des Controls die Länge nicht zulässt
    Protected myRequestedCaptionAreaLength As Integer
    'Ursprüngliche gewünschte Länge des Wertebereichs
    Protected myRequestedValueAreaLength As Integer
    'Höhe der Beschriftung
    Protected myCaptionAreaHeight As Integer
    'Höhe des Wertebereichs
    Protected myValueAreaHeight As Integer
    'Höhe des Controls
    Protected myControlHeight As Integer
    'Ursprünglich gewünschte Höhe des Controls
    Protected myRequestedlHeight As Integer
    'Flag, das gesetzt wird, wenn das Layout gerade durchgeführt wurde, damit
    'SetBoundsCore nicht in eine Endlosschleife läuft
    Protected myLayoutJustSet As Boolean
    'Benachrichtigung an das Control, dass das Valuecontrol eine Eigenschaft hat,
    'die eine Größenbeschränkung erfordert, die dazu führt, dass beim 
    'Aufheben der Größenbeschränkung das Control
    'seine ursprüngliche Größe automatisch wieder annehmen soll
    Protected myConsiderFixedSize As Boolean

    'Das Control, das zur Beschriftung herangezogen wird
    'Es muss die IADCaptionControl-Schnittstelle einbinden
    Protected myCaptionControl As IADCaptionForNullableValueControl

    'Das Control, das zur Werteermittlung herangezogen wird
    'Es muss die IADUVTControl-Schnittstelle einbinden
    Protected WithEvents myValueControl As IADEditableValueForNullableValueControl

    'Eine Eigenschaft, die eine beliebige Zeichenkette speichern kann,
    'beispielsweise um auf Datenbankfelder zu verweisen, um einfacher
    'Masken lesen/schreiben automatisieren zu können
    Protected myIndependentDatafieldName As String

    'Flag, das festhält, ob die Valueeigenschaft seit der Initialisierung
    'oder dem letzten Zuweisen verändert worden ist
    Protected myModified As Boolean

    'Flag, das bestimmt, ob bei einem falschen Eingabeformat eine Exception ausgelöst,
    'oder ein Dialog angezeigt werden soll.
    Protected myFireExceptionOnFailedValidation As Boolean

    'Text, der bei der Überprüfung durch die statische Funktion CheckForNullValues
    'ausgegeben wird, wenn der Wert Null ist. Wird ignoriert, wenn kein Text zugewiesen ist.
    Protected myNullValueMessage As String

    'Text, der im Eingabefeld erscheint, wenn der Anwender einen "Nullwert" eingegeben hat,
    'und das Eingabefeld den Fokus verliert.
    Protected myNullString As String

    'Text, der beim Auftreten eines falschen Eingabeformates ausgegben wird im Format
    '"Dialogtitel|Nachrichtentext"
    Protected myFailedValidationErrorMessage As String

    'Flag, das bestimmt, ob der Wertebereich beim Verlieren des Fokus
    'aufbereitet werden soll.
    Protected myDontConditionForDisplay As Boolean

    'Vorgabetext, der beim Auftreten eines falschen Eingabeformates ausgegben wird im Format
    '"Dialogtitel|Nachrichtentext"
    Protected Shared mySharedFailedValidationErrorDefaultMessage As String
    Protected Shared mySharedInvalidCastException As String

    Shared Sub New()
        Dim locCi As CultureInfo
        locCi = CultureInfo.CurrentCulture
        If locCi.Name.StartsWith("de") Then
            mySharedFailedValidationErrorDefaultMessage = "Datenformatfehler|Das Eingabeformat der eingegebenen Daten ist falsch. Bitte überprüfen und korrigieren Sie Ihre Eingabe."
            mySharedInvalidCastException = "Die eingegebenen Daten konnten nicht in den Zieltyp umgewandelt werden."
        Else
            mySharedFailedValidationErrorDefaultMessage = "Data format error|The input data has the wrong format. Please check and correct the data input."
            mySharedInvalidCastException = "The input data could not be converted into the destination type."
        End If
    End Sub

    Sub New()
        MyBase.New()
        'Prozedur zum Instanzieren der beiden Controls.
        'Wichtig: Abgeleitete Controls müssen CreateControls
        'unbedingt überschreiben!
        CreateControls()
        myValueControl.Parent = Me
        myCaptionControl.Parent = Me

        'Die eigentlichen Controls dieser Komponente hinzufügen;
        'damit werden sie sichtbar
        Me.Controls.AddRange(myCaptionControl.Controls)
        Me.Controls.AddRange(myValueControl.Controls)

        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.UseTextForAccessibility, True)
        SetStyle(ControlStyles.StandardClick, False)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ContainerControl, True)

        'Eigenschaften initialisieren. Wichtig für die Eigenschaften,
        'die nicht durch den Designer initialisiert werden,
        'damit sich gerade bei Enum-Werte keine "falschen" Werte
        '(nämlich Nullen) anfangs in den Eigenschaften befinden
        CaptionControl.BorderStyle = BorderStyle.Fixed3D
        CaptionAlignment = ContentAlignment.MiddleLeft
        BackColor = GetInitialValueControlColor()
        myCaptionControl.BackColor = SystemColors.Control
        FocusAutoColor = Color.Yellow
        ColorOnFocus = True
        myCaptionAreaLength = InitialCaptionControlLength
        myHasCaption = True

        'Initialwerte für Breite von Beschriftungs- und Wertebereich
        myValueAreaLength = InitialValueControlLength
        myRequestedCaptionAreaLength = InitialCaptionControlLength
        myRequestedValueAreaLength = InitialValueControlLength
        myLengthRatio = myRequestedCaptionAreaLength / (myRequestedCaptionAreaLength + myRequestedValueAreaLength)

    End Sub

    'Muss die Instanz der Controls erstellen
    Protected MustOverride Sub CreateControls()

    Protected Overridable Function GetInitialValueControlColor() As Color
        Return SystemColors.Window
    End Function

    'Vorgegebene Breite der Controls
    'Aus ihnen ergibt sich das anfängliche Verhältnis für
    'Captionlänge und Wertebereichlänge
    Protected Overridable ReadOnly Property InitialCaptionControlLength() As Integer
        Get
            Return 100
        End Get
    End Property

    Protected Overridable ReadOnly Property InitialValueControlLength() As Integer
        Get
            Return 200
        End Get
    End Property

    '######################################################
    '######################################################
    '### Interne Eigenschaften (geschützt) ################
    '######################################################
    '######################################################

    'Abgeleitete Klassen benötigen diese beiden Eigenschaften
    'zum zuweisen der beiden Control-Instanzen beim Aufruf
    'CreateControl
    Protected Property CaptionControl() As IADCaptionForNullableValueControl
        Get
            Return myCaptionControl
        End Get
        Set(ByVal Value As IADCaptionForNullableValueControl)
            myCaptionControl = Value
        End Set
    End Property

    Protected Property EditableValueControl() As IADEditableValueForNullableValueControl
        Get
            Return myValueControl
        End Get
        Set(ByVal Value As IADEditableValueForNullableValueControl)
            myValueControl = Value
        End Set
    End Property

    '##########################################################
    '##########################################################
    '### Eigenschaften zur Layoutsteuerung ####################
    '##########################################################
    '##########################################################

#Region "Eigenschaften Bereich Layout"

    'Kann nur von abgeleiteten Controls gelesen werden
    'Bestimmt oder ermittelt die Fixe-Größe-Eigenschaft des Controls
    'Wird zur Größenwiederherstellung benötigt; die Größe
    'selber wird durch die MeasureHeight und MeasureHeight-Eigenschaften
    'der unterliegenden Controls geregelt.
    <Browsable(False)> _
    Protected Property ConsiderFixedSize() As Boolean
        Get
            Return myConsiderFixedSize
        End Get
        Set(ByVal Value As Boolean)
            'ursprüngliche Größe wiederherstellbar machen
            'If myConsiderFixedSize And Not Value Then
            '    myRequestedControlHeight = ControlHeight
            'End If
            'If Not myConsiderFixedSize And Value Then
            '    myControlHeight = myRequestedControlHeight
            'End If
            myConsiderFixedSize = Value
        End Set
    End Property

    'Wird nur verwendet, um vom Designer gelesen werden zu können.
    <Browsable(False)> _
    Public ReadOnly Property ConsiderFixedSizeInternal() As Boolean
        Get
            Return ConsiderFixedSize
        End Get
    End Property

    'Definiert die Länge der Beschriftung
    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Layout", "Layout"), _
     ADDescription("Bestimmt oder ermittelt die Läge des Beschriftungsbereichs.", _
                   "Sets or gets the length of the caption area.")> _
    Public Property CaptionAreaLength() As Integer
        Get
            Return myCaptionAreaLength
        End Get
        Set(ByVal Value As Integer)
            If myHasCaption = False Then
                myRequestedCaptionAreaLength = Value
            Else
                myCaptionAreaLength = Value
                myRequestedCaptionAreaLength = Value
                If CaptionPlacement = ADCaptionPlacementEnum.Above Or CaptionPlacement = ADCaptionPlacementEnum.Below Then
                    myValueAreaLength = Value
                End If
                SetWidthInternal()
            End If
        End Set
    End Property

    Public Function ShouldSerializeCaptionAreaLength() As Boolean
        Return False
    End Function

    'Bestimmt die Länge des Wertebereichs
    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Layout", "Layout"), _
     ADDescription("Bestimmt oder ermittelt die Läge des Datenerfassungsbereichs.", _
                   "Sets or gets the length of the data input area.")> _
    Public Property ValueAreaLength() As Integer
        Get
            Return myValueAreaLength
        End Get
        Set(ByVal Value As Integer)
            myValueAreaLength = Value
            myRequestedValueAreaLength = Value
            If CaptionPlacement = ADCaptionPlacementEnum.Above Or CaptionPlacement = ADCaptionPlacementEnum.Below Then
                myCaptionAreaLength = Value
            End If
            SetWidthInternal()
        End Set
    End Property

    Public Function ShouldSerializeValueAreaLength() As Boolean
        Return Not False
    End Function

    'Bestimmt die Länge (Breite) des Controls. Diese Eigenschaft wird nur intern verwendet.
    'Diese Eigenschaft steuert den Teil der Layout-Logik für die Breitenberechnung
    Private Property ControlWidth() As Integer

        Get
            If CaptionPlacement = ADCaptionPlacementEnum.Above Or CaptionPlacement = ADCaptionPlacementEnum.Below Then
                Return CaptionAreaLength
            Else
                'Länge ist abhängig vom Vorhandensein der Beschriftung,
                'wenn Beschriftung neben dem Wertebereich ist
                If myHasCaption Then
                    Return CaptionAreaLength + ValueAreaLength
                Else
                    Return ValueAreaLength
                End If
            End If
        End Get

        Set(ByVal Value As Integer)
            If CaptionPlacement = ADCaptionPlacementEnum.Above Or CaptionPlacement = ADCaptionPlacementEnum.Below Then
                myValueAreaLength = Value
                myCaptionAreaLength = Value
            Else
                If myHasCaption Then
                    Dim myLength As Integer = Value
                    myCaptionAreaLength = Convert.ToInt32(myLength * myLengthRatio)
                    myValueAreaLength = Convert.ToInt32(myLength - myLength * myLengthRatio)
                Else
                    myCaptionAreaLength = 0
                    myValueAreaLength = Value
                End If
                SetWidthInternal()
            End If
        End Set
    End Property

    'Bestimmt die Länge (Breite) des Controls. Diese Eigenschaft wird nur intern verwendet.
    'Diese Eigenschaft steuert den Teil der Layout-Logik für die Breitenberechnung
    Private Property ControlHeight() As Integer

        Get
            Return myControlHeight
        End Get

        Set(ByVal Value As Integer)
            If CaptionPlacement = ADCaptionPlacementEnum.Above Or CaptionPlacement = ADCaptionPlacementEnum.Below Then
                'Dieser Teil regelt das Layout, wenn die Controls untereinander stehen
                If myValueControl.MeasureHeight < 0 Then
                    'Fixe Höhe Value
                    If Not myHasCaption Then
                        'Keine Beschriftung; fixe Höhe Value -> Höhe ist Höhe des ValueControls
                        Value = myValueControl.MeasureHeight * -1
                        myCaptionAreaHeight = 0
                        myValueAreaHeight = Value
                    Else
                        'Mit Beschriftung; fixe Höhe Value; fixe Höhe Caption -> Höhe ist Value plus Caption
                        If myCaptionControl.MeasureHeight < 0 Then
                            Value = (myValueControl.MeasureHeight * -1) + (myCaptionControl.MeasureHeight * -1)
                            myCaptionAreaHeight = myCaptionControl.MeasureHeight * -1
                            myValueAreaHeight = myValueControl.MeasureHeight * -1
                            'Mit Beschriftung; Fixe Höhe Value; Mindesthöhe Caption -> Höhe ist Value plus Caption
                        Else
                            If Value < (myValueControl.MeasureHeight * -1 + myCaptionControl.MeasureHeight) Then
                                Value = (myValueControl.MeasureHeight * -1) + myCaptionControl.MeasureHeight
                            End If
                            myValueAreaHeight = myValueControl.MeasureHeight * -1
                            myCaptionAreaHeight = Value - myValueAreaHeight
                        End If
                    End If
                    'Variable Höhe Value:
                Else
                    If Not myHasCaption Then
                        'ohne Beschriftung
                        myCaptionAreaHeight = 0
                        If Value < myValueControl.MeasureHeight Then
                            Value = myValueControl.MeasureHeight
                        End If
                        myValueAreaHeight = Value
                    Else
                        'mit Beschriftung
                        myCaptionAreaHeight = myCaptionControl.MeasureHeight
                        If myCaptionAreaHeight < 0 Then
                            myCaptionAreaHeight *= -1
                        End If

                        If Value < (myValueControl.MeasureHeight + myCaptionAreaHeight) Then
                            Value = myValueControl.MeasureHeight + myCaptionAreaHeight
                        End If
                        myValueAreaHeight = Value - myCaptionAreaHeight
                    End If
                End If
            Else
                'Dieser Teil regelt das Layout, wenn die Controls nebeneinander stehen
                If Not myConsiderFixedSize Then
                    myRequestedlHeight = Value
                End If
                If myValueControl.MeasureHeight < 0 Then
                    'Für feste Texthöhe
                    'Mit oder ohne Beschriftung; Value-Control-höhe regelt
                    myValueAreaHeight = myValueControl.MeasureHeight * -1
                    myCaptionAreaHeight = myValueAreaHeight
                    Value = myValueAreaHeight
                Else
                    'Nur Mindesthöhe des Valuecontrols ist vorgegeben
                    If myHasCaption Then
                        'Wenn es eine Beschriftung gibt
                        If myCaptionControl.MeasureHeight < 0 Then
                            'Feste Größe für Caption ist gewünscht
                            myValueAreaHeight = myValueControl.MeasureHeight
                            myCaptionAreaHeight = myCaptionControl.MeasureHeight * -1
                            If myCaptionAreaHeight < myValueAreaHeight Then
                                'Value-Control gewinnt, wenn es durch geringere Captionhöhe "bezwungen" werden soll
                                myCaptionAreaHeight = myValueAreaHeight
                            Else
                                'Größer kann das Value-Control hier ruhig werden
                                myValueAreaHeight = myCaptionAreaHeight
                            End If
                            Value = myValueAreaHeight
                        Else
                            'Nur Mindesthöhen sind vorgegeben
                            myValueAreaHeight = myValueControl.MeasureHeight
                            myCaptionAreaHeight = myCaptionControl.MeasureHeight
                            If Value < myValueAreaHeight Then
                                Value = myValueAreaHeight
                            End If
                            If Value < myCaptionAreaHeight Then
                                Value = myCaptionAreaHeight
                            End If
                            myCaptionAreaHeight = Value
                            myValueAreaHeight = Value
                        End If
                    Else
                        'Keine Beschriftung
                        'Nur Mindesthöhe Valuecontrol zählt
                        Trace.WriteLine("Least height VariantControl:" & myValueControl.MeasureHeight)
                        If Value < myValueControl.MeasureHeight Then
                            Value = myValueControl.MeasureHeight
                        End If
                        myCaptionAreaHeight = Value
                        myValueAreaHeight = Value
                    End If
                End If
            End If

            'Properties setzen:
            myControlHeight = Value
            myLayoutJustSet = True
            Me.SetBoundsCore(Me.Left, Me.Top, ControlWidth, myControlHeight, BoundsSpecified.Height)
        End Set
    End Property

    'Layoutlogik verbirgt sich in den internen Eigenschaften
    'ControlWidth und ControlHeight
    Protected Overridable Sub UpdateLayout()
        ControlWidth = Me.Width
        ControlHeight = myControlHeight
    End Sub

    'Diese Prozedur setzt die Positionen der internen
    'Controls für Beschriftung und Wertebereich
    Private Sub PlaceControlsInternal()
        If CaptionPlacement = ADCaptionPlacementEnum.Above Then
            myCaptionControl.Location = New Point(0, 0)
            myValueControl.Location = New Point(0, myCaptionAreaHeight)
        ElseIf CaptionPlacement = ADCaptionPlacementEnum.Below Then
            myCaptionControl.Location = New Point(0, myValueAreaHeight)
            myValueControl.Location = New Point(0, 0)
        ElseIf CaptionPlacement = ADCaptionPlacementEnum.LeftSide Then
            myCaptionControl.Location = New Point(0, 0)
            myValueControl.Location = New Point(myCaptionAreaLength)
        Else
            myCaptionControl.Location = New Point(myValueAreaLength, 0)
            myValueControl.Location = New Point(0, 0)
        End If
    End Sub

    'Diese Prozedur setzt die Ausmaße der internen
    'Controls für Beschriftung und Wertebereich
    Private Sub AlignControlWidthInternal()
        myCaptionControl.Size = New Size(myCaptionAreaLength, myCaptionAreaHeight)
        myValueControl.Size = New Size(myValueAreaLength, myValueAreaHeight)
    End Sub

    'Die Eigenschaft bestimmt das Verhältnis zwischen
    'Beschriftung und Wertebereich in Promille
    <RefreshProperties(RefreshProperties.Repaint), _
     ADCategory("Layout", "Layout"), _
     ADDescription("Bestimmt oder ermittelt das Verhältnis zwischen Beschriftungs- und Datenerfassungsbereich.", _
                   "Sets or gets the ratio between caption and data input area.")> _
    Public Property CaptionToValueRatio() As Double
        Get
            Return Math.Round(CaptionToValueControlRatioInternal * 1000, 2)
        End Get
        Set(ByVal Value As Double)
            If Value > 1000 Or Value < 0 Then
                Dim Up As New ArgumentOutOfRangeException("Eigenschaftenwert", "Wert muss >=0 und <=1000 sein!")
                Throw Up
            End If
            CaptionToValueControlRatioInternal = Value / 1000
        End Set
    End Property

    Public Function ShouldSerializeCaptionToValueRatio() As Boolean
        'Wird grundsätzlich serialisiert
        Return True
    End Function

    'Intern wird mit einem Bruch zwischen 0 und 1 gerechnet,
    'der das Verhältnis zwischen Beschriftung und Wertebereich regelt
    Private Property CaptionToValueControlRatioInternal() As Double
        Get
            If CaptionPlacement = ADCaptionPlacementEnum.Above Or CaptionPlacement = ADCaptionPlacementEnum.Below Then
                Return 1
            Else
                Return myLengthRatio
            End If
        End Get
        Set(ByVal Value As Double)
            Dim myLength As Integer = CaptionAreaLength + ValueAreaLength
            myLengthRatio = Value
            If CaptionPlacement = ADCaptionPlacementEnum.Above Or CaptionPlacement = ADCaptionPlacementEnum.Below Then
                'Alte Werte merken
                myRequestedCaptionAreaLength = Convert.ToInt32(myLength * myLengthRatio)
                myRequestedValueAreaLength = Convert.ToInt32(myLength - myLength * myLengthRatio)
            Else
                myCaptionAreaLength = Convert.ToInt32(myLength * myLengthRatio)
                myValueAreaLength = Convert.ToInt32(myLength - myLength * myLengthRatio)
                myRequestedCaptionAreaLength = Convert.ToInt32(myLength * myLengthRatio)
                myRequestedValueAreaLength = Convert.ToInt32(myLength - myLength * myLengthRatio)
            End If
            SetWidthInternal()
        End Set
    End Property

    'Setzt die Ausmaße des Controls
    Private Sub SetWidthInternal()
        If CaptionAreaLength + ValueAreaLength > 0 Then
            myLengthRatio = CaptionAreaLength / (CaptionAreaLength + ValueAreaLength)
        End If
        myLayoutJustSet = True
        Me.SetBoundsCore(Me.Left, Me.Top, ControlWidth, Me.Height, BoundsSpecified.Width)
    End Sub

    'Ermittelt und setzt Position und Ausmaße des Controls
    'Jede Größenveränderung von außen (Designer, Size, Location)
    'und innen (Reglementierung durch feste Höhe) läuft über die Prozedur
    Protected Overrides Sub SetBoundsCore(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal specified As System.Windows.Forms.BoundsSpecified)

        'If (specified And BoundsSpecified.Width) = BoundsSpecified.Width Then
        '    'Rekursion vermeiden
        '    If Not myLayoutJustSet Then
        '        ControlWidth = width
        '    End If
        'End If

        'If (specified And BoundsSpecified.Height) = BoundsSpecified.Height Then
        '    'Hier auch
        '    If Not myLayoutJustSet Then
        '        ControlHeight = height
        '    End If
        'End If

        ''Nächster Aufruf kommt wieder von außen
        'myLayoutJustSet = False

        PlaceControlsInternal()
        AlignControlWidthInternal()
        MyBase.SetBoundsCore(x, y, width, height, specified)

    End Sub

    Protected Overrides Sub OnLayout(ByVal e As System.Windows.Forms.LayoutEventArgs)
        MyBase.OnLayout(e)
        If e.AffectedProperty = "Bounds" Then
            ControlWidth = Me.Size.Width
            ControlHeight = Me.Size.Height
        End If
    End Sub

#End Region

    '##########################################################
    '##########################################################
    '### Eigenschaften zur Darstellungssteuerung ##############
    '##########################################################
    '##########################################################

#Region "Eigenschaften Bereich Darstellung"

    '### HasCaption-Eigenschaft ####################

    'Regelt, ob das Control überhaupt eine Beschriftung hat
    <RefreshProperties(RefreshProperties.Repaint), _
    ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt, ob das Steuerelement über einen Beschriftungsteil verfügt.", _
                   "Sets or gets, wether the control has a caption.")> _
    Public Overridable Property HasCaption() As Boolean
        Get
            Return myHasCaption
        End Get
        Set(ByVal Value As Boolean)
            If (myHasCaption = True) And Not Value Then
                'Werte merken
                If CaptionPlacement = ADCaptionPlacementEnum.LeftSide Or CaptionPlacement = ADCaptionPlacementEnum.RightSide Then
                    myRequestedCaptionAreaLength = myCaptionAreaLength
                    myRequestedValueAreaLength = myValueAreaLength
                Else
                    myRequestedlHeight = myControlHeight
                End If
            ElseIf (myHasCaption = False) And Value Then
                'Werte wiederherstellen
                If CaptionPlacement = ADCaptionPlacementEnum.LeftSide Or CaptionPlacement = ADCaptionPlacementEnum.RightSide Then
                    myLengthRatio = myRequestedCaptionAreaLength / (myRequestedCaptionAreaLength + myRequestedValueAreaLength)
                Else
                    myControlHeight = myRequestedlHeight
                End If
            End If
            myHasCaption = Value
            UpdateLayout()
        End Set
    End Property

    '### CaptionPlacement-Eigenschaft ####################

    'Bestimmt die Anordnung der Beschriftung um den Wertebereich
    <RefreshProperties(RefreshProperties.Repaint), _
    ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt, wie die Beschriftung um das Steuerelement herum angeordnet wird.", _
                   "Sets or gets the placement of the control's caption.")> _
    Public Overridable Property CaptionPlacement() As ADCaptionPlacementEnum

        Get
            'Wenn es keine Zuweisung gab, wird der Voreinstellungswert zurückgegeben
            'Damit ist gewährleistet, dass die Eigenschaft immer einen sinnvollen
            'Wert zurückliefert; selbst wenn (noch) nichts definiert wurde.
            If myCaptionPlacement Is Nothing Then
                Return ADCaptionPlacementEnum.LeftSide
            Else
                Return DirectCast(myCaptionPlacement, ADCaptionPlacementEnum)
            End If
        End Get

        Set(ByVal Value As ADCaptionPlacementEnum)

            Dim e As New CaptionPlacementChangedEventArgs(Value, False)
            If Value <> CaptionPlacement Then
                OnCaptionPlacementChanged(e)
                If e.Prevent Then Exit Property
            End If
            Value = e.NewValue

            If (CaptionPlacement = ADCaptionPlacementEnum.LeftSide Or CaptionPlacement = ADCaptionPlacementEnum.RightSide) And _
                (Value = ADCaptionPlacementEnum.Above Or Value = ADCaptionPlacementEnum.Below) Then
                'Breiten, falls notwendig, für die Wiederherstellung merken
                'Das ist nur notwendig, wenn die Beschriftlich vorher seitlich war,
                'und nun auf drüber oder drunter gesetzt wird
                myRequestedCaptionAreaLength = myCaptionAreaLength
                myRequestedValueAreaLength = myValueAreaLength
            ElseIf (CaptionPlacement = ADCaptionPlacementEnum.Above Or CaptionPlacement = ADCaptionPlacementEnum.Below) Then
                'Höhe, falls notwendig, für die Wiederherstellung merken
                myRequestedlHeight = myControlHeight
            End If

            If (Value = ADCaptionPlacementEnum.Above) Or (Value = ADCaptionPlacementEnum.Below) Then
                'Falls Beschriftung oben oder unten, dann sind alle Längen gleich
                Dim locLength As Integer = ControlWidth
                myCaptionAreaLength = locLength
                myValueAreaLength = locLength
                myControlHeight = myRequestedlHeight
                ConsiderFixedSize = False
            Else
                'Falls nicht, 
                'Länge kann nur über das Verhältnis wiederhergestellt werden
                myLengthRatio = myRequestedCaptionAreaLength / (myRequestedCaptionAreaLength + myRequestedValueAreaLength)
                ConsiderFixedSize = True
            End If
            If Value = ADCaptionPlacementEnum.LeftSide Then
                myCaptionPlacement = Nothing
            Else
                myCaptionPlacement = Value
            End If
            UpdateLayout()
        End Set
    End Property

    Public Overridable Function ShouldSerializeCaptionPlacement() As Boolean
        Return Not (myCaptionPlacement Is Nothing)
    End Function

    Public Sub ResetCaptionPlacement()
        CaptionPlacement = ADCaptionPlacementEnum.LeftSide
    End Sub

    Protected Overridable Sub OnCaptionPlacementChanged(ByVal e As CaptionPlacementChangedEventArgs)
        RaiseEvent CaptionPlacementChanged(Me, e)
    End Sub

    '### CaptionAlignment-Eigenschaft ####################

    <ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt, wie die Beschriftung innerhalb ihres Rahmens angeordnet werden soll.", _
                   "Sets or gets the alignment of the caption in its frame.")> _
    Public Overridable Property CaptionAlignment() As ContentAlignment
        Get
            Return myCaptionControl.Alignment
        End Get
        Set(ByVal Value As ContentAlignment)
            If Not Value.Equals(myCaptionControl.Alignment) Then
                OnCaptionAlignmentChanged(New EventArgs)
            End If
            myCaptionControl.Alignment = Value
        End Set
    End Property

    Public Function ShouldSerializeCaptionAlignment() As Boolean
        Return Not (CaptionAlignment = ContentAlignment.MiddleLeft)
    End Function

    Public Sub ResetCaptionAlignment()
        CaptionAlignment = ContentAlignment.MiddleLeft
    End Sub

    Protected Overridable Sub OnCaptionAlignmentChanged(ByVal e As EventArgs)
        RaiseEvent CaptionAlignmentChanged(Me, e)
    End Sub

    '### CaptionBorderStyle-Eigenschaft ####################

    <ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt den Umrandungstyp der Beschriftung.", _
                   "Sets or gets the border style of the caption.")> _
    Public Overridable Property CaptionBorderStyle() As BorderStyle
        Get
            Return myCaptionControl.BorderStyle
        End Get
        Set(ByVal Value As BorderStyle)
            If Not Value.Equals(myCaptionBorderstyle) Then
                OnCaptionBorderStyleChanged(New EventArgs)
            End If
            myCaptionControl.BorderStyle = Value
        End Set
    End Property

    Public Function ShouldSerializeCaptionBorderStyle() As Boolean
        Return Not (CaptionBorderStyle = BorderStyle.Fixed3D)
    End Function

    Protected Overridable Sub OnCaptionBorderStyleChanged(ByVal e As EventArgs)
        RaiseEvent CaptionBorderStyleChanged(Me, e)
    End Sub

    '### Text-Eigenschaft ####################

    'Diese Attribute müssen "umgestellt" werden; sonst wird die Text-
    'Eigenschaft nicht serialisiert und auch nicht im Eigenschaftenfenster 
    'dargestellt. Liegt daran, dass dieses Benutzersteuerelement von UserControl
    'und nicht von Control abgeleitet wurde...
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Browsable(True)> _
    Public Overrides Property Text() As String Implements IADNullableValueControl.Text
        Get
            Return myCaptionControl.Text
        End Get
        Set(ByVal Value As String)
            myCaptionControl.Text = Value
            MyBase.Text = Value
        End Set
    End Property

    '### CaptionFont-Eigenschaft ####################

    <ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt den Font der Beschrifung.", _
                   "Sets or gets the font of the caption.")> _
    Public Overridable Property CaptionFont() As Font
        Get
            If Not (myCaptionFont Is Nothing) Then Return myCaptionFont
            If Not (Me.Parent Is Nothing) Then Return Me.Parent.Font
            Return Control.DefaultFont
        End Get
        Set(ByVal Value As Font)
            If Not Value.Equals(myCaptionFont) Then
                OnCaptionFontChanged(New EventArgs)
            End If
            myCaptionFont = Value
            myCaptionControl.Font = Me.CaptionFont
            UpdateLayout()
        End Set
    End Property

    Public Overridable Function ShouldSerializeCaptionFont() As Boolean
        Return Not (myCaptionFont Is Nothing)
    End Function

    Protected Overridable Sub OnCaptionFontChanged(ByVal e As EventArgs)
        RaiseEvent CaptionFontChanged(Me, e)
    End Sub

    '### Font-Eigenschaft ####################

    'Wenn die Font-Eigenschaft überschrieben wird, wird Font dummerweise nicht 
    'mehr serialisiert; ShouldSerializeFont kann leider nicht überschrieben werden
    'also hängen wir uns hier 'rein...
    Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
        MyBase.OnFontChanged(e)
        myValueControl.Font = Me.Font
        UpdateLayout()
    End Sub

    '### BackColor-Eigenschaft ####################

    <ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt die Hintergrundfarbe des Datenerfassungsbereichs.", _
                   "Sets or gets the background color of the data input area.")> _
    Public Overrides Property BackColor() As Color
        Get
            If (Me.ShouldSerializeBackColor) Then
                Return myBackColor
            Else
                If (Me.Parent IsNot Nothing) And (GetInitialValueControlColor() = Color.Empty) Then
                    Return Parent.BackColor
                Else
                    Return GetInitialValueControlColor()
                End If
            End If
        End Get
        Set(ByVal Value As Color)
            myBackColor = Value
            myValueControl.BackColor = MyClass.BackColor
        End Set
    End Property

    Public Overridable Function ShouldSerializeBackColor() As Boolean
        Return Not (MyBase.BackColor = GetInitialValueControlColor())
    End Function

    Public Overrides Sub ResetBackColor()
        myBackColor = GetInitialValueControlColor()
        myValueControl.BackColor = MyClass.BackColor
    End Sub

    Protected Overrides Sub OnBackColorChanged(ByVal e As System.EventArgs)
        MyBase.OnBackColorChanged(e)
        BackColor = BackColor
        CaptionBackColor = CaptionBackColor
    End Sub

    '### ForeColor-Eigenschaft ####################

    Protected Overrides Sub OnForeColorChanged(ByVal e As System.EventArgs)
        myValueControl.ForeColor = Me.ForeColor
    End Sub

    '### CaptionBackColor-Eigenschaft ####################

    <ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt die Hintergrundfarbe der Beschriftung.", _
                   "Sets or gets the background color of the caption.")> _
    Public Overridable Property CaptionBackColor() As Color
        Get
            If (MyClass.ShouldSerializeCaptionBackColor) Then
                Return myCaptionBackColor
            Else
                If Me.Parent IsNot Nothing Then
                    Return Me.Parent.BackColor
                Else
                    Return System.Drawing.SystemColors.Control
                End If
            End If
        End Get
        Set(ByVal Value As Color)
            If Me.Parent IsNot Nothing Then
                If Value = Me.Parent.BackColor Then
                    Value = Color.Empty
                End If
            End If
            myCaptionBackColor = Value
            myCaptionControl.BackColor = MyClass.CaptionBackColor
        End Set
    End Property

    Public Overridable Function ShouldSerializeCaptionBackColor() As Boolean
        Return Not (myCaptionBackColor = Color.Empty)
    End Function

    Public Overridable Sub ResetCaptionBackColor()
        myCaptionBackColor = Color.Empty
        myCaptionControl.BackColor = MyClass.CaptionBackColor
    End Sub

    '### CaptionForeColor-Eigenschaft ####################
    <ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt die Vordergrundfarbe der Beschriftung.", _
                   "Sets or gets the foreground color of the caption.")> _
    Public Overridable Property CaptionForeColor() As Color
        Get
            If (Me.ShouldSerializeCaptionForeColor) Then
                Return myCaptionForeColor
            Else
                If Me.Parent IsNot Nothing Then
                    Return Parent.ForeColor
                Else
                    Return System.Drawing.SystemColors.WindowText
                End If
            End If
        End Get
        Set(ByVal Value As Color)
            myCaptionForeColor = Value
            myCaptionControl.ForeColor = CaptionForeColor
        End Set
    End Property

    Public Overridable Function ShouldSerializeCaptionForeColor() As Boolean
        Return Not (myCaptionForeColor = Color.Empty)
    End Function

    Public Overridable Sub ResetCaptionForeColor()
        myCaptionForeColor = Color.Empty
        myCaptionControl.ForeColor = CaptionForeColor
    End Sub

    '### FocusAutoColor-Eigenschaft ####################

    <ADCategory("Darstellung", "Appearance"), _
     ADDescription("Bestimmt oder ermittelt die Farbe, mit der der Eingabebereich bei der Fokussierung des Steuerelementes automatisch  eingefärbt wird.", _
                   "Sets or gets the color, with which the control is colored automatically, if it gets the focus.")> _
    Public Overridable Property FocusAutoColor() As Color
        Get
            Return myFocusAutoColor
        End Get
        Set(ByVal Value As Color)
            myFocusAutoColor = Value
        End Set
    End Property

    Public Overridable Function ShouldSerializeFocusAutoColor() As Boolean
        Return Not FocusAutoColor.ToArgb = Color.Yellow.ToArgb
    End Function

    <ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt, ob das Steuerelement automatisch mit FocusColor eingefärbt werden soll, wenn es den Fokus erhält.", _
                   "Sets or gets the color, if the control should be colored automatically with FocusColor if it gets the focus.")> _
    Public Overridable Property ColorOnFocus() As Boolean
        Get
            Return myColorOnFocus
        End Get
        Set(ByVal Value As Boolean)
            myColorOnFocus = Value
        End Set
    End Property

#End Region

    '##########################################################
    '##########################################################
    '### Sonstige Eigenschaften ###############################
    '##########################################################
    '##########################################################

#Region "Sonstige Eigenschaften"

    <Browsable(False)> _
    Public ReadOnly Property OnceModified() As Boolean Implements IADNullableValueControl.OnceModified
        Get
            Return myValueControl.OnceModified
        End Get
    End Property

    <ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt einen String, der für die Zuweisung des Controls an ein Datenfeld fungieren kann. Der String hat nur informative Funktion.", _
                   "Sets or gets a String, which can act as an assignment of the control to a data field. This property has only an informative effect.")> _
    Public Property IndependentDatafieldName() As String Implements IADNullableValueControl.IndependentDatafieldName
        Get
            Return myIndependentDatafieldName
        End Get
        Set(ByVal Value As String)
            myIndependentDatafieldName = Value
        End Set
    End Property

    <DefaultValue(False), _
     ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Falls eine ungültige Formatierung während der Eingabevalidierung entdeckt wurde, wird bei True für diese Eigenschaft eine Ausnahme ausgelöst, anderenfalls ein Nachrichtenfeld angezeigt.", _
                   "If an unvalid input format is encountered during validation, this property determines if an exception will be fired (True) or if a MessageBox will be shown (False).")> _
    Public Property FireExceptionOnFailedValidation() As Boolean
        Get
            Return myFireExceptionOnFailedValidation
        End Get
        Set(ByVal Value As Boolean)
            myFireExceptionOnFailedValidation = Value
        End Set
    End Property

    <ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt den Text, der bei der Überprüfung durch die statische Funktion 'CheckForNotAllowedNullValues' ausgegeben wird, wenn der Wert der Value-Eigenschaft Null ist. Es findet keine Überprüfung statt, wenn dieser Eigenschaft kein Text zugewiesen wurde.", _
                   "Sets or gets the text that is shown in a MessageBox by the shared function 'CheckForNotAllowedNullValues', if the value property contains Null. The value will not be checked, if no text has been assigned to this property.")> _
    Public Property NullValueMessage() As String Implements IADNullableValueControl.NullValueMessage
        Get
            Return myNullValueMessage
        End Get
        Set(ByVal Value As String)
            myNullValueMessage = Value
        End Set
    End Property

    <ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt oder ermittelt den Text, der in einem Nachrichtenfeld angezeigt wird, wenn die Eingabevalidierung eine ungültige Eingabewertformatierung festgellt hat. Nachrichtenfeldtitel und -Text werden durch das Pipe-Zeichen (|) getrennt. Der Text wird nicht ausgegeben, wenn die FireExceptionOnFailedValidation-Eigenschaft auf True gesetzt wurde.", _
                   "Sets or gets the text that is shown in a MessageBox, if the input validation encountered an unvalid input format. MessageBox Titel and Body are separated by the Pipe-Sign (|). If the FireExceptionOnFailedValidation property has been set to True, the MessageBox will not be shown.")> _
    Public Property FailedValidationErrorMessage() As String
        Get
            Return myFailedValidationErrorMessage
        End Get
        Set(ByVal Value As String)
            myFailedValidationErrorMessage = Value
        End Set
    End Property

    <ADCategory("Verhalten", "Behaviour"), _
     ADDescription("Bestimmt, welcher Text ausgegeben werden soll, wenn der Anwender einen NULL-entsprechenden Wert im Eingabebereich eingegeben hat und das Steuerelement den Fokus verliert.", _
                   "Determines the text which should be shown in the data input area, if the user has entered a NULL-Value, and then the control looses its focus.")> _
    Public Property NullString() As String
        Get
            Return myNullString
        End Get
        Set(ByVal Value As String)
            myNullString = Value
            If myValue IsNot Nothing Then
                UpdateValue(myValue)
            End If
        End Set
    End Property

#End Region

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
    Browsable(False)> _
    Public Overridable Property Value() As IADDBNullableValue Implements IADNullableValueControl.Value
        Get
            If Me.Focused And Not myDontConditionForDisplay Then
                myValue = ToNullableValue(myValueControl.Value)
            Else
                myValue = GetCurrentControlValue()
            End If
            Return myValue
        End Get
        Set(ByVal Value As IADDBNullableValue)
            myValue = Value
            UpdateValue(Value)
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
    Browsable(False)> _
    Public Property TypeSafeValue() As ADDBNullable(Of ADUVType)
        Get
            Return DirectCast(Value, ADDBNullable(Of ADUVType))
        End Get
        Set(ByVal value As ADDBNullable(Of ADUVType))
            Me.Value = value
        End Set
    End Property

    Protected Overridable Sub UpdateValue(ByVal Value As IADDBNullableValue)
        If myDontConditionForDisplay Then
            myValueControl.Value = Value
        Else
            myObjectForDisplaying = ToObjectForDisplaying(Value, True)
            myObjectForEditing = ToObjectForEditing(Value)
            If Me.Focused Then
                myValueControl.Value = myObjectForEditing
            Else
                myValueControl.Value = myObjectForDisplaying
            End If
        End If
    End Sub

    Protected Overridable Function GetCurrentControlValue() As IADDBNullableValue
        Return myValue
    End Function

    <Browsable(False)> _
    Public Overridable ReadOnly Property ObjectValue() As Object
        Get
            Return Value.Value
        End Get
    End Property

    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        MyBase.OnEnter(e)
        If ColorOnFocus And Not DesignMode Then
            myValueControl.BackColor = FocusAutoColor
        End If
        If Not myDontConditionForDisplay Then
            myValueControl.Value = myObjectForEditing
        End If
    End Sub

    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        MyBase.OnLeave(e)
        If ColorOnFocus And Not DesignMode Then
            myValueControl.BackColor = BackColor
        End If
    End Sub

    Protected Overridable Function ToObjectForEditing(ByVal Value As IADDBNullableValue) As Object
        If Not Value.HasValue Then
            Return ""
        Else
            Return Value.Value.ToString
        End If
    End Function

    Protected Overridable Function ToObjectForDisplaying(ByVal Value As IADDBNullableValue, ByVal ForSetValue As Boolean) As Object
        If Not Value.HasValue Then
            Return "- - -"
        Else
            Return Value.Value.ToString
        End If
    End Function

    Protected MustOverride Function ToNullableValue(ByVal [Object] As Object) As ADDBNullable(Of ADUVType)

    '################################################
    '### Ereignissverarbeitung und Weiterreichung ###
    '################################################

    Private Sub myValueControl_OnceModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myValueControl.OnceModifiedChanged
        OnOnceModifiedChanged(e)
    End Sub

    Protected Overridable Sub OnOnceModifiedChanged(ByVal e As System.EventArgs)
        RaiseEvent OnceModifiedChanged(Me, e)
    End Sub

    Private Sub myValueControl_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myValueControl.ValueChanged
        OnValueChanged(e)
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As System.EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Private Sub ADEditableValueControlTemplate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Debug.WriteLine(sender.ToString + ": GotFocus")
    End Sub

    Protected Overrides Sub OnValidating(ByVal e As CancelEventArgs)

        MyBase.OnValidating(e)
        If e.Cancel Then Return

        Dim locMessageString As String = Nothing

        Try
            myObjectForEditing = myValueControl.Value
            myValue = ToNullableValue(myObjectForEditing)
            'Nur auf Umwandlungsmöglichkeit testen:
        Catch ex As Exception

            If FireExceptionOnFailedValidation Then
                Dim up As New InvalidCastException("Die Eingabe konnte nicht in den Zieltyp umgewandelt werden.")
                Throw up
            Else
                If FailedValidationErrorMessage Is Nothing Or FailedValidationErrorMessage = "" Then
                    locMessageString = mySharedFailedValidationErrorDefaultMessage
                Else
                    locMessageString = FailedValidationErrorMessage
                End If
            End If
        End Try

        If locMessageString <> "" Then
            'Auseinanderdröseln und als Messagebox ausgeben
            Dim locStringArray As String() = locMessageString.Split(New Char() {"|"c})
            Try
                MessageBox.Show(locStringArray(1), locStringArray(0), MessageBoxButtons.OK, _
                                 MessageBoxIcon.Error)
            Catch ex As Exception
                Dim locCi As CultureInfo
                Dim locError As String
                locCi = CultureInfo.CurrentCulture
                If locCi.Name.StartsWith("de") Then
                    locError = "Eine vordefinierte Fehlermeldung sollte ausgegeben werden, allerdings entsprach der Fehlermeldungstext nicht dem korrekten Format. Möglicherweise fehlt das Pipe-Zeichen (|)."
                Else
                    locError = "A predefined error message was supposed to be shown, but the message format didn't match the correct format. Probebly the pipe sign (|) is missing."
                End If
                locError += vbNewLine + vbNewLine
                locError += "Error causing control: " + Me.Name + vbNewLine
                locError += "Error caused while validating."
                Dim up As New SyntaxErrorException(locError)
                Throw up
            End Try
            e.Cancel = True
        End If
    End Sub

    Protected Overrides Sub OnValidated(ByVal e As System.EventArgs)
        'Bereits ungewandelten Wert in das Anzeigeformat umwandeln
        If Not myDontConditionForDisplay Then
            myObjectForDisplaying = ToObjectForDisplaying(myValue, False)
            myValueControl.Value = myObjectForDisplaying
        End If
        MyBase.OnValidated(e)
    End Sub
End Class

'################################################
'### ControlDesigner Pendant ####################
'################################################

'TODO: This method became obsolete!!!
'WICHTIG: Wenn Sie einen ControlDesigner einfügen,
'müssen Sie den System.Windows.Forms.Design-Namespace einbinden,
'und SystemDesign.Dll als Verweis dem Projekt hinzufügen!
Public Class ADNullableValueControlTemplateDesigner
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
            Dim locSelectionRules As SelectionRules

            locThisComponent = Me.Component
            Debug.WriteLine("Designermessage: This Component is" & (locThisComponent Is Nothing).ToString)

            Try
                'In Abhängigkeit von ConsiderFixedSize (die sich beispielsweise durch Multiline ändert) 
                If Convert.ToBoolean(TypeDescriptor.GetProperties(locThisComponent).Item("ConsiderFixedSizeInternal").GetValue(locThisComponent)) Then
                    'Nur vertikale Größenveränderungen...
                    locSelectionRules = SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.LeftSizeable Or SelectionRules.RightSizeable
                Else
                    '...oder komplette Größenveränderungen ermöglichen
                    locSelectionRules = SelectionRules.Moveable Or SelectionRules.Visible Or SelectionRules.AllSizeable
                End If
                Return locSelectionRules
            Catch ex As Exception
                Debug.WriteLine("Designermessage:" & ex.Message)
                Return MyBase.SelectionRules
            End Try
        End Get
    End Property
End Class

'################################################
'### EventArguments #############################
'################################################
Public Class CaptionPlacementChangedEventArgs
    Inherits EventArgs

    Protected myNewValue As ADCaptionPlacementEnum
    Protected myPrevent As Boolean

    Sub New(ByVal newValue As ADCaptionPlacementEnum, ByVal prevent As Boolean)
        myNewValue = newValue
        myPrevent = prevent
    End Sub

    Public Property NewValue() As ADCaptionPlacementEnum
        Get
            Return myNewValue
        End Get
        Set(ByVal Value As ADCaptionPlacementEnum)
            myNewValue = Value
        End Set
    End Property

    Public Property Prevent() As Boolean
        Get
            Return myPrevent
        End Get
        Set(ByVal Value As Boolean)
            myPrevent = Value
        End Set
    End Property

End Class

'###############################
'Plazierung der Beschriftungs
'###############################
Public Enum ADCaptionPlacementEnum
    Above
    LeftSide
    RightSide
    Below
End Enum

<CLSCompliant(True)> _
Public Interface IADNullableValueControl

    Property Value() As IADDBNullableValue

    ReadOnly Property OnceModified() As Boolean
    Property IndependentDatafieldName() As String
    Property NullValueMessage() As String
    Property Text() As String

    Event ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
    Event OnceModifiedChanged(ByVal sender As Object, ByVal e As EventArgs)

End Interface

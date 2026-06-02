using ActiveDev;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace ActiveDev.Controls
{
    [Designer(typeof(ADNullableValueControlTemplateDesigner))]
    [DefaultPropertyAttribute("Text")]
    public abstract class ADNullableValueControlTemplate<ADUVType> : System.Windows.Forms.ContainerControl, IADNullableValueControl where ADUVType : IComparable
    {
        //Alle Events
        public delegate void CaptionPlacementChangedEventHandler(object sender, CaptionPlacementChangedEventArgs e);
        public event CaptionPlacementChangedEventHandler CaptionPlacementChanged;
        public delegate void CaptionAlignmentChangedEventHandler(object sender, EventArgs e);
        public event CaptionAlignmentChangedEventHandler CaptionAlignmentChanged;
        public delegate void CaptionBorderStyleChangedEventHandler(object sender, EventArgs e);
        public event CaptionBorderStyleChangedEventHandler CaptionBorderStyleChanged;
        public delegate void CaptionBackColorChangedEventHandler(object sender, EventArgs e);
        public event CaptionBackColorChangedEventHandler CaptionBackColorChanged;
        public delegate void CaptionForeColorChangedEventHandler(object sender, EventArgs e);
        public event CaptionForeColorChangedEventHandler CaptionForeColorChanged;
        public delegate void CaptionFontChangedEventHandler(object sender, EventArgs e);
        public event CaptionFontChangedEventHandler CaptionFontChanged;
        public event ActiveDev.Controls.IADNullableValueControl.OnceModifiedChangedEventHandler OnceModifiedChanged;
        public event ActiveDev.Controls.IADNullableValueControl.ValueChangedEventHandler ValueChanged;
        //##############################################################
        //Geschützte Membervariablen für's Speichern der Eigenschaften
        //##############################################################
        //### Eigenschaften der Beschriftung ###
        //Ausrichtung der Beschriftung innen
        protected object myCaptionAlignment;
        //Ausrichtung der Beschriftung außen
        protected object myCaptionPlacement;
        //Rahmen der Beschriftung
        protected object myCaptionBorderstyle;
        //Speicher für Hintergrundfarbe (des CaptionControls)
        protected Color myCaptionBackColor;
        //Speicher für Vordergrundfarbe (des CaptionControls)
        protected Color myCaptionForeColor;
        //Speicher für Hintergrundfarbe (des ValueControls)
        protected Color myBackColor;
        //Speicher für Auto-Einfärbe-Farbe (bei Focuserhalt; des ValueControls)
        protected Color myFocusAutoColor;
        //Bestimmt, ob Steuerelement bei Focuserhalt eingefärbt werden soll.
        protected bool myColorOnFocus;
        //Font der Beschriftung
        protected Font myCaptionFont;
        //Speicher für den Beschiftungstext
        protected string myText;
        //Bestimmt, ob eine Beschriftung angezeigt wird, oder nicht
        protected bool myHasCaption;
        //### Eigenschaften des ValueControls ###
        //Angezeigter Wert, nachdem das Control den Focus verloren hat
        protected object myObjectForDisplaying;
        //Editierter Wert, der auch wieder angezeigt wird, wenn das Control den Focus bekommt
        protected object myObjectForEditing;
        //Der eingentliche Wert der Controls als ADVariant
        protected IADDBNullableValue myValue;
        //DBNull erlaubt?
        protected bool myIsNullAllowed;
        //Fehlermeldung, wenn Null eingegeben wurde
        protected string myIfNullMessage;
        //Font des Wertecontrols
        protected Font myValueFont;
        //Die Höhe des Controls, die es letzten Endes hat
        protected int myFinalHeight;
        //### Eigenschaften, das gesamte Control betreffend ###
        //Länge des Beschriftungcontrols
        protected int myCaptionAreaLength;
        //Länge des Valuecontrols
        protected int myValueAreaLength;
        //Längenverhältnis
        protected double myLengthRatio;
        //Ursprünglich gewünschte Länge der Beschriftung, die gespeichert werden muss zur
        //Wiederherstellung, falls eine Einstellung des Controls die Länge nicht zulässt
        protected int myRequestedCaptionAreaLength;
        //Ursprüngliche gewünschte Länge des Wertebereichs
        protected int myRequestedValueAreaLength;
        //Höhe der Beschriftung
        protected int myCaptionAreaHeight;
        //Höhe des Wertebereichs
        protected int myValueAreaHeight;
        //Höhe des Controls
        protected int myControlHeight;
        //Ursprünglich gewünschte Höhe des Controls
        protected int myRequestedlHeight;
        //Flag, das gesetzt wird, wenn das Layout gerade durchgeführt wurde, damit
        //SetBoundsCore nicht in eine Endlosschleife läuft
        protected bool myLayoutJustSet;
        //Benachrichtigung an das Control, dass das Valuecontrol eine Eigenschaft hat,
        //die eine Größenbeschränkung erfordert, die dazu führt, dass beim
        //Aufheben der Größenbeschränkung das Control
        //seine ursprüngliche Größe automatisch wieder annehmen soll
        protected bool myConsiderFixedSize;
        //Das Control, das zur Beschriftung herangezogen wird
        //Es muss die IADCaptionControl-Schnittstelle einbinden
        protected IADCaptionForNullableValueControl myCaptionControl;
        //Das Control, das zur Werteermittlung herangezogen wird
        //Es muss die IADUVTControl-Schnittstelle einbinden
        private IADEditableValueForNullableValueControl _myValueControl;
        protected IADEditableValueForNullableValueControl myValueControl
        {
            get
            {
                return _myValueControl;
            }

            set
            {
                if (_myValueControl != null)
                {
                    _myValueControl.OnceModifiedChanged -= myValueControl_OnceModifiedChanged;
                    _myValueControl.ValueChanged -= myValueControl_ValueChanged;
                }

                _myValueControl = value;
                if (_myValueControl != null)
                {
                    _myValueControl.OnceModifiedChanged += myValueControl_OnceModifiedChanged;
                    _myValueControl.ValueChanged += myValueControl_ValueChanged;
                }
            }
        }

        //Eine Eigenschaft, die eine beliebige Zeichenkette speichern kann,
        //beispielsweise um auf Datenbankfelder zu verweisen, um einfacher
        //Masken lesen/schreiben automatisieren zu können
        protected string myIndependentDatafieldName;
        //Flag, das festhält, ob die Valueeigenschaft seit der Initialisierung
        //oder dem letzten Zuweisen verändert worden ist
        protected bool myModified;
        //Flag, das bestimmt, ob bei einem falschen Eingabeformat eine Exception ausgelöst,
        //oder ein Dialog angezeigt werden soll.
        protected bool myFireExceptionOnFailedValidation;
        //Text, der bei der Überprüfung durch die statische Funktion CheckForNullValues
        //ausgegeben wird, wenn der Wert Null ist. Wird ignoriert, wenn kein Text zugewiesen ist.
        protected string myNullValueMessage;
        //Text, der im Eingabefeld erscheint, wenn der Anwender einen "Nullwert" eingegeben hat,
        //und das Eingabefeld den Fokus verliert.
        protected string myNullString;
        //Text, der beim Auftreten eines falschen Eingabeformates ausgegben wird im Format
        //"Dialogtitel|Nachrichtentext"
        protected string myFailedValidationErrorMessage;
        //Flag, das bestimmt, ob der Wertebereich beim Verlieren des Fokus
        //aufbereitet werden soll.
        protected bool myDontConditionForDisplay;
        //Vorgabetext, der beim Auftreten eines falschen Eingabeformates ausgegben wird im Format
        //"Dialogtitel|Nachrichtentext"
        protected static string mySharedFailedValidationErrorDefaultMessage;
        protected static string mySharedInvalidCastException;
        static ADNullableValueControlTemplate()
        {
            CultureInfo locCi;
            locCi = CultureInfo.CurrentCulture;
            if (locCi.Name.StartsWith("de"))
            {
                mySharedFailedValidationErrorDefaultMessage = "Datenformatfehler|Das Eingabeformat der eingegebenen Daten ist falsch. Bitte überprüfen und korrigieren Sie Ihre Eingabe.";
                mySharedInvalidCastException = "Die eingegebenen Daten konnten nicht in den Zieltyp umgewandelt werden.";
            }
            else
            {
                mySharedFailedValidationErrorDefaultMessage = "Data format error|The input data has the wrong format. Please check and correct the data input.";
                mySharedInvalidCastException = "The input data could not be converted into the destination type.";
            }
        }

        public ADNullableValueControlTemplate() : base()
        {
            //Prozedur zum Instanzieren der beiden Controls.
            //Wichtig: Abgeleitete Controls müssen CreateControls
            //unbedingt überschreiben!
            CreateControls();
            myValueControl.Parent = this;
            myCaptionControl.Parent = this;
            //Die eigentlichen Controls dieser Komponente hinzufügen;
            //damit werden sie sichtbar
            this.Controls.AddRange(myCaptionControl.Controls);
            this.Controls.AddRange(myValueControl.Controls);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UseTextForAccessibility, true);
            SetStyle(ControlStyles.StandardClick, false);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);
            //Eigenschaften initialisieren. Wichtig für die Eigenschaften,
            //die nicht durch den Designer initialisiert werden,
            //damit sich gerade bei Enum-Werte keine "falschen" Werte
            //(nämlich Nullen) anfangs in den Eigenschaften befinden
            CaptionControl.BorderStyle = BorderStyle.Fixed3D;
            CaptionAlignment = ContentAlignment.MiddleLeft;
            BackColor = GetInitialValueControlColor();
            myCaptionControl.BackColor = SystemColors.Control;
            FocusAutoColor = Color.Yellow;
            ColorOnFocus = true;
            myCaptionAreaLength = InitialCaptionControlLength;
            myHasCaption = true;
            //Initialwerte für Breite von Beschriftungs- und Wertebereich
            myValueAreaLength = InitialValueControlLength;
            myRequestedCaptionAreaLength = InitialCaptionControlLength;
            myRequestedValueAreaLength = InitialValueControlLength;
            myLengthRatio = myRequestedCaptionAreaLength / (myRequestedCaptionAreaLength + myRequestedValueAreaLength);
        }

        //Muss die Instanz der Controls erstellen
        protected abstract void CreateControls();
        protected virtual Color GetInitialValueControlColor()
        {
            return SystemColors.Window;
        }

        //Vorgegebene Breite der Controls
        //Aus ihnen ergibt sich das anfängliche Verhältnis für
        //Captionlänge und Wertebereichlänge
        protected virtual int InitialCaptionControlLength
        {
            get
            {
                return 100;
            }
        }

        protected virtual int InitialValueControlLength
        {
            get
            {
                return 200;
            }
        }

        //######################################################
        //######################################################
        //### Interne Eigenschaften (geschützt) ################
        //######################################################
        //######################################################
        //Abgeleitete Klassen benötigen diese beiden Eigenschaften
        //zum zuweisen der beiden Control-Instanzen beim Aufruf
        //CreateControl
        protected IADCaptionForNullableValueControl CaptionControl
        {
            get
            {
                return myCaptionControl;
            }

            set
            {
                IADCaptionForNullableValueControl Value = value;
                myCaptionControl = Value;
            }
        }

        protected IADEditableValueForNullableValueControl EditableValueControl
        {
            get
            {
                return myValueControl;
            }

            set
            {
                IADEditableValueForNullableValueControl Value = value;
                myValueControl = Value;
            }
        }

        //##########################################################
        //##########################################################
        //### Eigenschaften zur Layoutsteuerung ####################
        //##########################################################
        //##########################################################
        //Kann nur von abgeleiteten Controls gelesen werden
        //Bestimmt oder ermittelt die Fixe-Größe-Eigenschaft des Controls
        //Wird zur Größenwiederherstellung benötigt; die Größe
        //selber wird durch die MeasureHeight und MeasureHeight-Eigenschaften
        //der unterliegenden Controls geregelt.
        [Browsable(false)]
        protected bool ConsiderFixedSize
        {
            get
            {
                return myConsiderFixedSize;
            }

            set
            {
                bool Value = value;
                //ursprüngliche Größe wiederherstellbar machen
                //If myConsiderFixedSize And Not Value Then
                //    myRequestedControlHeight = ControlHeight
                //End If
                //If Not myConsiderFixedSize And Value Then
                //    myControlHeight = myRequestedControlHeight
                //End If
                myConsiderFixedSize = Value;
            }
        }

        //Wird nur verwendet, um vom Designer gelesen werden zu können.
        [Browsable(false)]
        public bool ConsiderFixedSizeInternal
        {
            get
            {
                return ConsiderFixedSize;
            }
        }

        //Definiert die Länge der Beschriftung
        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Layout", "Layout")]
        [ADDescription("Bestimmt oder ermittelt die Läge des Beschriftungsbereichs.", "Sets or gets the length of the caption area.")]
        public int CaptionAreaLength
        {
            get
            {
                return myCaptionAreaLength;
            }

            set
            {
                int Value = value;
                if (myHasCaption == false)
                {
                    myRequestedCaptionAreaLength = Value;
                }
                else
                {
                    myCaptionAreaLength = Value;
                    myRequestedCaptionAreaLength = Value;
                    if (CaptionPlacement == ADCaptionPlacementEnum.Above | CaptionPlacement == ADCaptionPlacementEnum.Below)
                    {
                        myValueAreaLength = Value;
                    }

                    SetWidthInternal();
                }
            }
        }

        public bool ShouldSerializeCaptionAreaLength()
        {
            return false;
        }

        //Bestimmt die Länge des Wertebereichs
        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Layout", "Layout")]
        [ADDescription("Bestimmt oder ermittelt die Läge des Datenerfassungsbereichs.", "Sets or gets the length of the data input area.")]
        public int ValueAreaLength
        {
            get
            {
                return myValueAreaLength;
            }

            set
            {
                int Value = value;
                myValueAreaLength = Value;
                myRequestedValueAreaLength = Value;
                if (CaptionPlacement == ADCaptionPlacementEnum.Above | CaptionPlacement == ADCaptionPlacementEnum.Below)
                {
                    myCaptionAreaLength = Value;
                }

                SetWidthInternal();
            }
        }

        public bool ShouldSerializeValueAreaLength()
        {
            return !(false);
        }

        //Bestimmt die Länge (Breite) des Controls. Diese Eigenschaft wird nur intern verwendet.
        //Diese Eigenschaft steuert den Teil der Layout-Logik für die Breitenberechnung
        private int ControlWidth
        {
            get
            {
                if (CaptionPlacement == ADCaptionPlacementEnum.Above | CaptionPlacement == ADCaptionPlacementEnum.Below)
                {
                    return CaptionAreaLength;
                }
                else
                {
                    //Länge ist abhängig vom Vorhandensein der Beschriftung,
                    //wenn Beschriftung neben dem Wertebereich ist
                    if (myHasCaption)
                    {
                        return CaptionAreaLength + ValueAreaLength;
                    }
                    else
                    {
                        return ValueAreaLength;
                    }
                }
            }

            set
            {
                int Value = value;
                if (CaptionPlacement == ADCaptionPlacementEnum.Above | CaptionPlacement == ADCaptionPlacementEnum.Below)
                {
                    myValueAreaLength = Value;
                    myCaptionAreaLength = Value;
                }
                else
                {
                    if (myHasCaption)
                    {
                        int myLength = Value;
                        myCaptionAreaLength = Convert.ToInt32(myLength * myLengthRatio);
                        myValueAreaLength = Convert.ToInt32(myLength - myLength * myLengthRatio);
                    }
                    else
                    {
                        myCaptionAreaLength = 0;
                        myValueAreaLength = Value;
                    }

                    SetWidthInternal();
                }
            }
        }

        //Bestimmt die Länge (Breite) des Controls. Diese Eigenschaft wird nur intern verwendet.
        //Diese Eigenschaft steuert den Teil der Layout-Logik für die Breitenberechnung
        private int ControlHeight
        {
            get
            {
                return myControlHeight;
            }

            set
            {
                int Value = value;
                if (CaptionPlacement == ADCaptionPlacementEnum.Above | CaptionPlacement == ADCaptionPlacementEnum.Below)
                {
                    //Dieser Teil regelt das Layout, wenn die Controls untereinander stehen
                    if (myValueControl.MeasureHeight() < 0)
                    {
                        //Fixe Höhe Value
                        if (!(myHasCaption))
                        {
                            //Keine Beschriftung; fixe Höhe Value -> Höhe ist Höhe des ValueControls
                            Value = myValueControl.MeasureHeight() * -1;
                            myCaptionAreaHeight = 0;
                            myValueAreaHeight = Value;
                        }
                        else
                        {
                            //Mit Beschriftung; fixe Höhe Value; fixe Höhe Caption -> Höhe ist Value plus Caption
                            if (myCaptionControl.MeasureHeight() < 0)
                            {
                                Value = (myValueControl.MeasureHeight() * -1) + (myCaptionControl.MeasureHeight() * -1);
                                myCaptionAreaHeight = myCaptionControl.MeasureHeight() * -1;
                                myValueAreaHeight = myValueControl.MeasureHeight() * -1;
                            }
                            else
                            {
                                if (Value < (myValueControl.MeasureHeight() * -1 + myCaptionControl.MeasureHeight()))
                                {
                                    Value = (myValueControl.MeasureHeight() * -1) + myCaptionControl.MeasureHeight();
                                }

                                myValueAreaHeight = myValueControl.MeasureHeight() * -1;
                                myCaptionAreaHeight = Value - myValueAreaHeight;
                            }
                        }
                    }
                    else
                    {
                        if (!(myHasCaption))
                        {
                            //ohne Beschriftung
                            myCaptionAreaHeight = 0;
                            if (Value < myValueControl.MeasureHeight())
                            {
                                Value = myValueControl.MeasureHeight();
                            }

                            myValueAreaHeight = Value;
                        }
                        else
                        {
                            //mit Beschriftung
                            myCaptionAreaHeight = myCaptionControl.MeasureHeight();
                            if (myCaptionAreaHeight < 0)
                            {
                                myCaptionAreaHeight *= -1;
                            }

                            if (Value < (myValueControl.MeasureHeight() + myCaptionAreaHeight))
                            {
                                Value = myValueControl.MeasureHeight() + myCaptionAreaHeight;
                            }

                            myValueAreaHeight = Value - myCaptionAreaHeight;
                        }
                    }
                }
                else
                {
                    //Dieser Teil regelt das Layout, wenn die Controls nebeneinander stehen
                    if (!(myConsiderFixedSize))
                    {
                        myRequestedlHeight = Value;
                    }

                    if (myValueControl.MeasureHeight() < 0)
                    {
                        //Für feste Texthöhe
                        //Mit oder ohne Beschriftung; Value-Control-höhe regelt
                        myValueAreaHeight = myValueControl.MeasureHeight() * -1;
                        myCaptionAreaHeight = myValueAreaHeight;
                        Value = myValueAreaHeight;
                    }
                    else
                    {
                        //Nur Mindesthöhe des Valuecontrols ist vorgegeben
                        if (myHasCaption)
                        {
                            //Wenn es eine Beschriftung gibt
                            if (myCaptionControl.MeasureHeight() < 0)
                            {
                                //Feste Größe für Caption ist gewünscht
                                myValueAreaHeight = myValueControl.MeasureHeight();
                                myCaptionAreaHeight = myCaptionControl.MeasureHeight() * -1;
                                if (myCaptionAreaHeight < myValueAreaHeight)
                                {
                                    //Value-Control gewinnt, wenn es durch geringere Captionhöhe "bezwungen" werden soll
                                    myCaptionAreaHeight = myValueAreaHeight;
                                }
                                else
                                {
                                    //Größer kann das Value-Control hier ruhig werden
                                    myValueAreaHeight = myCaptionAreaHeight;
                                }

                                Value = myValueAreaHeight;
                            }
                            else
                            {
                                //Nur Mindesthöhen sind vorgegeben
                                myValueAreaHeight = myValueControl.MeasureHeight();
                                myCaptionAreaHeight = myCaptionControl.MeasureHeight();
                                if (Value < myValueAreaHeight)
                                {
                                    Value = myValueAreaHeight;
                                }

                                if (Value < myCaptionAreaHeight)
                                {
                                    Value = myCaptionAreaHeight;
                                }

                                myCaptionAreaHeight = Value;
                                myValueAreaHeight = Value;
                            }
                        }
                        else
                        {
                            //Keine Beschriftung
                            //Nur Mindesthöhe Valuecontrol zählt
                            Trace.WriteLine("Least height VariantControl:" + myValueControl.MeasureHeight());
                            if (Value < myValueControl.MeasureHeight())
                            {
                                Value = myValueControl.MeasureHeight();
                            }

                            myCaptionAreaHeight = Value;
                            myValueAreaHeight = Value;
                        }
                    }
                }

                //Properties setzen:
                myControlHeight = Value;
                myLayoutJustSet = true;
                this.SetBoundsCore(this.Left, this.Top, ControlWidth, myControlHeight, BoundsSpecified.Height);
            }
        }

        //Layoutlogik verbirgt sich in den internen Eigenschaften
        //ControlWidth und ControlHeight
        protected virtual void UpdateLayout()
        {
            ControlWidth = this.Width;
            ControlHeight = myControlHeight;
        }

        //Diese Prozedur setzt die Positionen der internen
        //Controls für Beschriftung und Wertebereich
        private void PlaceControlsInternal()
        {
            if (CaptionPlacement == ADCaptionPlacementEnum.Above)
            {
                myCaptionControl.Location = new Point(0, 0);
                myValueControl.Location = new Point(0, myCaptionAreaHeight);
            }
            else if (CaptionPlacement == ADCaptionPlacementEnum.Below)
            {
                myCaptionControl.Location = new Point(0, myValueAreaHeight);
                myValueControl.Location = new Point(0, 0);
            }
            else if (CaptionPlacement == ADCaptionPlacementEnum.LeftSide)
            {
                myCaptionControl.Location = new Point(0, 0);
                myValueControl.Location = new Point(myCaptionAreaLength);
            }
            else
            {
                myCaptionControl.Location = new Point(myValueAreaLength, 0);
                myValueControl.Location = new Point(0, 0);
            }
        }

        //Diese Prozedur setzt die Ausmaße der internen
        //Controls für Beschriftung und Wertebereich
        private void AlignControlWidthInternal()
        {
            myCaptionControl.Size = new Size(myCaptionAreaLength, myCaptionAreaHeight);
            myValueControl.Size = new Size(myValueAreaLength, myValueAreaHeight);
        }

        //Die Eigenschaft bestimmt das Verhältnis zwischen
        //Beschriftung und Wertebereich in Promille
        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Layout", "Layout")]
        [ADDescription("Bestimmt oder ermittelt das Verhältnis zwischen Beschriftungs- und Datenerfassungsbereich.", "Sets or gets the ratio between caption and data input area.")]
        public double CaptionToValueRatio
        {
            get
            {
                return Math.Round(CaptionToValueControlRatioInternal * 1000, 2);
            }

            set
            {
                double Value = value;
                if (Value > 1000 | Value < 0)
                {
                    ArgumentOutOfRangeException Up = new ArgumentOutOfRangeException("Eigenschaftenwert", "Wert muss >=0 und <=1000 sein!");
                    throw Up;
                }

                CaptionToValueControlRatioInternal = Value / 1000;
            }
        }

        public bool ShouldSerializeCaptionToValueRatio()
        {
            //Wird grundsätzlich serialisiert
            return true;
        }

        //Intern wird mit einem Bruch zwischen 0 und 1 gerechnet,
        //der das Verhältnis zwischen Beschriftung und Wertebereich regelt
        private double CaptionToValueControlRatioInternal
        {
            get
            {
                if (CaptionPlacement == ADCaptionPlacementEnum.Above | CaptionPlacement == ADCaptionPlacementEnum.Below)
                {
                    return 1;
                }
                else
                {
                    return myLengthRatio;
                }
            }

            set
            {
                double Value = value;
                int myLength = CaptionAreaLength + ValueAreaLength;
                myLengthRatio = Value;
                if (CaptionPlacement == ADCaptionPlacementEnum.Above | CaptionPlacement == ADCaptionPlacementEnum.Below)
                {
                    //Alte Werte merken
                    myRequestedCaptionAreaLength = Convert.ToInt32(myLength * myLengthRatio);
                    myRequestedValueAreaLength = Convert.ToInt32(myLength - myLength * myLengthRatio);
                }
                else
                {
                    myCaptionAreaLength = Convert.ToInt32(myLength * myLengthRatio);
                    myValueAreaLength = Convert.ToInt32(myLength - myLength * myLengthRatio);
                    myRequestedCaptionAreaLength = Convert.ToInt32(myLength * myLengthRatio);
                    myRequestedValueAreaLength = Convert.ToInt32(myLength - myLength * myLengthRatio);
                }

                SetWidthInternal();
            }
        }

        //Setzt die Ausmaße des Controls
        private void SetWidthInternal()
        {
            if (CaptionAreaLength + ValueAreaLength > 0)
            {
                myLengthRatio = CaptionAreaLength / (CaptionAreaLength + ValueAreaLength);
            }

            myLayoutJustSet = true;
            this.SetBoundsCore(this.Left, this.Top, ControlWidth, this.Height, BoundsSpecified.Width);
        }

        //Ermittelt und setzt Position und Ausmaße des Controls
        //Jede Größenveränderung von außen (Designer, Size, Location)
        //und innen (Reglementierung durch feste Höhe) läuft über die Prozedur
        protected override void SetBoundsCore(int x, int y, int width, int height, System.Windows.Forms.BoundsSpecified specified)
        {
            //If (specified And BoundsSpecified.Width) = BoundsSpecified.Width Then
            //    'Rekursion vermeiden
            //    If Not myLayoutJustSet Then
            //        ControlWidth = width
            //    End If
            //End If
            //If (specified And BoundsSpecified.Height) = BoundsSpecified.Height Then
            //    'Hier auch
            //    If Not myLayoutJustSet Then
            //        ControlHeight = height
            //    End If
            //End If
            //'Nächster Aufruf kommt wieder von außen
            //myLayoutJustSet = False
            PlaceControlsInternal();
            AlignControlWidthInternal();
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void OnLayout(System.Windows.Forms.LayoutEventArgs e)
        {
            base.OnLayout(e);
            if (e.AffectedProperty == "Bounds")
            {
                ControlWidth = this.Size.Width;
                ControlHeight = this.Size.Height;
            }
        }

        //##########################################################
        //##########################################################
        //### Eigenschaften zur Darstellungssteuerung ##############
        //##########################################################
        //##########################################################
        //### HasCaption-Eigenschaft ####################
        //Regelt, ob das Control überhaupt eine Beschriftung hat
        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt, ob das Steuerelement über einen Beschriftungsteil verfügt.", "Sets or gets, wether the control has a caption.")]
        public virtual bool HasCaption
        {
            get
            {
                return myHasCaption;
            }

            set
            {
                bool Value = value;
                if ((myHasCaption == true) & !(Value))
                {
                    //Werte merken
                    if (CaptionPlacement == ADCaptionPlacementEnum.LeftSide | CaptionPlacement == ADCaptionPlacementEnum.RightSide)
                    {
                        myRequestedCaptionAreaLength = myCaptionAreaLength;
                        myRequestedValueAreaLength = myValueAreaLength;
                    }
                    else
                    {
                        myRequestedlHeight = myControlHeight;
                    }
                }
                else if ((myHasCaption == false) & Value)
                {
                    //Werte wiederherstellen
                    if (CaptionPlacement == ADCaptionPlacementEnum.LeftSide | CaptionPlacement == ADCaptionPlacementEnum.RightSide)
                    {
                        myLengthRatio = myRequestedCaptionAreaLength / (myRequestedCaptionAreaLength + myRequestedValueAreaLength);
                    }
                    else
                    {
                        myControlHeight = myRequestedlHeight;
                    }
                }

                myHasCaption = Value;
                UpdateLayout();
            }
        }

        //### CaptionPlacement-Eigenschaft ####################
        //Bestimmt die Anordnung der Beschriftung um den Wertebereich
        [RefreshProperties(RefreshProperties.Repaint)]
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt, wie die Beschriftung um das Steuerelement herum angeordnet wird.", "Sets or gets the placement of the control's caption.")]
        public virtual ADCaptionPlacementEnum CaptionPlacement
        {
            get
            {
                //Wenn es keine Zuweisung gab, wird der Voreinstellungswert zurückgegeben
                //Damit ist gewährleistet, dass die Eigenschaft immer einen sinnvollen
                //Wert zurückliefert; selbst wenn (noch) nichts definiert wurde.
                if (myCaptionPlacement == null)
                {
                    return ADCaptionPlacementEnum.LeftSide;
                }
                else
                {
                    return ((ADCaptionPlacementEnum)myCaptionPlacement);
                }
            }

            set
            {
                ADCaptionPlacementEnum Value = value;
                CaptionPlacementChangedEventArgs e = new CaptionPlacementChangedEventArgs(Value, false);
                if (Value != CaptionPlacement)
                {
                    OnCaptionPlacementChanged(e);
                    if (e.Prevent)
                    {
                        return;
                    }
                }

                Value = e.NewValue;
                if ((CaptionPlacement == ADCaptionPlacementEnum.LeftSide | CaptionPlacement == ADCaptionPlacementEnum.RightSide) & (Value == ADCaptionPlacementEnum.Above | Value == ADCaptionPlacementEnum.Below))
                {
                    //Breiten, falls notwendig, für die Wiederherstellung merken
                    //Das ist nur notwendig, wenn die Beschriftlich vorher seitlich war,
                    //und nun auf drüber oder drunter gesetzt wird
                    myRequestedCaptionAreaLength = myCaptionAreaLength;
                    myRequestedValueAreaLength = myValueAreaLength;
                }
                else if ((CaptionPlacement == ADCaptionPlacementEnum.Above | CaptionPlacement == ADCaptionPlacementEnum.Below))
                {
                    //Höhe, falls notwendig, für die Wiederherstellung merken
                    myRequestedlHeight = myControlHeight;
                }

                if ((Value == ADCaptionPlacementEnum.Above) | (Value == ADCaptionPlacementEnum.Below))
                {
                    //Falls Beschriftung oben oder unten, dann sind alle Längen gleich
                    int locLength = ControlWidth;
                    myCaptionAreaLength = locLength;
                    myValueAreaLength = locLength;
                    myControlHeight = myRequestedlHeight;
                    ConsiderFixedSize = false;
                }
                else
                {
                    //Falls nicht,
                    //Länge kann nur über das Verhältnis wiederhergestellt werden
                    myLengthRatio = myRequestedCaptionAreaLength / (myRequestedCaptionAreaLength + myRequestedValueAreaLength);
                    ConsiderFixedSize = true;
                }

                if (Value == ADCaptionPlacementEnum.LeftSide)
                {
                    myCaptionPlacement = null;
                }
                else
                {
                    myCaptionPlacement = Value;
                }

                UpdateLayout();
            }
        }

        public virtual bool ShouldSerializeCaptionPlacement()
        {
            return !((myCaptionPlacement == null));
        }

        public void ResetCaptionPlacement()
        {
            CaptionPlacement = ADCaptionPlacementEnum.LeftSide;
        }

        protected virtual void OnCaptionPlacementChanged(CaptionPlacementChangedEventArgs e)
        {
            CaptionPlacementChanged?.Invoke(this, e);
        }

        //### CaptionAlignment-Eigenschaft ####################
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt, wie die Beschriftung innerhalb ihres Rahmens angeordnet werden soll.", "Sets or gets the alignment of the caption in its frame.")]
        public virtual ContentAlignment CaptionAlignment
        {
            get
            {
                return myCaptionControl.Alignment;
            }

            set
            {
                ContentAlignment Value = value;
                if (!(Value.Equals(myCaptionControl.Alignment)))
                {
                    OnCaptionAlignmentChanged(new EventArgs());
                }

                myCaptionControl.Alignment = Value;
            }
        }

        public bool ShouldSerializeCaptionAlignment()
        {
            return !((CaptionAlignment == ContentAlignment.MiddleLeft));
        }

        public void ResetCaptionAlignment()
        {
            CaptionAlignment = ContentAlignment.MiddleLeft;
        }

        protected virtual void OnCaptionAlignmentChanged(EventArgs e)
        {
            CaptionAlignmentChanged?.Invoke(this, e);
        }

        //### CaptionBorderStyle-Eigenschaft ####################
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt den Umrandungstyp der Beschriftung.", "Sets or gets the border style of the caption.")]
        public virtual BorderStyle CaptionBorderStyle
        {
            get
            {
                return myCaptionControl.BorderStyle;
            }

            set
            {
                BorderStyle Value = value;
                if (!(Value.Equals(myCaptionBorderstyle)))
                {
                    OnCaptionBorderStyleChanged(new EventArgs());
                }

                myCaptionControl.BorderStyle = Value;
            }
        }

        public bool ShouldSerializeCaptionBorderStyle()
        {
            return !((CaptionBorderStyle == BorderStyle.Fixed3D));
        }

        protected virtual void OnCaptionBorderStyleChanged(EventArgs e)
        {
            CaptionBorderStyleChanged?.Invoke(this, e);
        }

        //### Text-Eigenschaft ####################
        //Diese Attribute müssen "umgestellt" werden; sonst wird die Text-
        //Eigenschaft nicht serialisiert und auch nicht im Eigenschaftenfenster
        //dargestellt. Liegt daran, dass dieses Benutzersteuerelement von UserControl
        //und nicht von Control abgeleitet wurde...
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return myCaptionControl.Text;
            }

            set
            {
                string Value = value;
                myCaptionControl.Text = Value;
                base.Text = Value;
            }
        }

        //### CaptionFont-Eigenschaft ####################
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt den Font der Beschrifung.", "Sets or gets the font of the caption.")]
        public virtual Font CaptionFont
        {
            get
            {
                if (!((myCaptionFont == null)))
                {
                    return myCaptionFont;
                }

                if (!((this.Parent == null)))
                {
                    return this.Parent.Font;
                }

                return Control.DefaultFont;
            }

            set
            {
                Font Value = value;
                if (!(Value.Equals(myCaptionFont)))
                {
                    OnCaptionFontChanged(new EventArgs());
                }

                myCaptionFont = Value;
                myCaptionControl.Font = this.CaptionFont;
                UpdateLayout();
            }
        }

        public virtual bool ShouldSerializeCaptionFont()
        {
            return !((myCaptionFont == null));
        }

        protected virtual void OnCaptionFontChanged(EventArgs e)
        {
            CaptionFontChanged?.Invoke(this, e);
        }

        //### Font-Eigenschaft ####################
        //Wenn die Font-Eigenschaft überschrieben wird, wird Font dummerweise nicht
        //mehr serialisiert; ShouldSerializeFont kann leider nicht überschrieben werden
        //also hängen wir uns hier 'rein...
        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            myValueControl.Font = this.Font;
            UpdateLayout();
        }

        //### BackColor-Eigenschaft ####################
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt die Hintergrundfarbe des Datenerfassungsbereichs.", "Sets or gets the background color of the data input area.")]
        public override Color BackColor
        {
            get
            {
                if ((this.ShouldSerializeBackColor()))
                {
                    return myBackColor;
                }
                else
                {
                    if ((this.Parent != null) & (GetInitialValueControlColor() == Color.Empty))
                    {
                        return Parent.BackColor;
                    }
                    else
                    {
                        return GetInitialValueControlColor();
                    }
                }
            }

            set
            {
                Color Value = value;
                myBackColor = Value;
                myValueControl.BackColor = this.BackColor;
            }
        }

        public virtual bool ShouldSerializeBackColor()
        {
            return !((base.BackColor == GetInitialValueControlColor()));
        }

        public override void ResetBackColor()
        {
            myBackColor = GetInitialValueControlColor();
            myValueControl.BackColor = this.BackColor;
        }

        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
            BackColor = BackColor;
            CaptionBackColor = CaptionBackColor;
        }

        //### ForeColor-Eigenschaft ####################
        protected override void OnForeColorChanged(System.EventArgs e)
        {
            myValueControl.ForeColor = this.ForeColor;
        }

        //### CaptionBackColor-Eigenschaft ####################
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt die Hintergrundfarbe der Beschriftung.", "Sets or gets the background color of the caption.")]
        public virtual Color CaptionBackColor
        {
            get
            {
                if ((this.ShouldSerializeCaptionBackColor()))
                {
                    return myCaptionBackColor;
                }
                else
                {
                    if (this.Parent != null)
                    {
                        return this.Parent.BackColor;
                    }
                    else
                    {
                        return System.Drawing.SystemColors.Control;
                    }
                }
            }

            set
            {
                Color Value = value;
                if (this.Parent != null)
                {
                    if (Value == this.Parent.BackColor)
                    {
                        Value = Color.Empty;
                    }
                }

                myCaptionBackColor = Value;
                myCaptionControl.BackColor = this.CaptionBackColor;
            }
        }

        public virtual bool ShouldSerializeCaptionBackColor()
        {
            return !((myCaptionBackColor == Color.Empty));
        }

        public virtual void ResetCaptionBackColor()
        {
            myCaptionBackColor = Color.Empty;
            myCaptionControl.BackColor = this.CaptionBackColor;
        }

        //### CaptionForeColor-Eigenschaft ####################
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt die Vordergrundfarbe der Beschriftung.", "Sets or gets the foreground color of the caption.")]
        public virtual Color CaptionForeColor
        {
            get
            {
                if ((this.ShouldSerializeCaptionForeColor()))
                {
                    return myCaptionForeColor;
                }
                else
                {
                    if (this.Parent != null)
                    {
                        return Parent.ForeColor;
                    }
                    else
                    {
                        return System.Drawing.SystemColors.WindowText;
                    }
                }
            }

            set
            {
                Color Value = value;
                myCaptionForeColor = Value;
                myCaptionControl.ForeColor = CaptionForeColor;
            }
        }

        public virtual bool ShouldSerializeCaptionForeColor()
        {
            return !((myCaptionForeColor == Color.Empty));
        }

        public virtual void ResetCaptionForeColor()
        {
            myCaptionForeColor = Color.Empty;
            myCaptionControl.ForeColor = CaptionForeColor;
        }

        //### FocusAutoColor-Eigenschaft ####################
        [ADCategory("Darstellung", "Appearance")]
        [ADDescription("Bestimmt oder ermittelt die Farbe, mit der der Eingabebereich bei der Fokussierung des Steuerelementes automatisch  eingefärbt wird.", "Sets or gets the color, with which the control is colored automatically, if it gets the focus.")]
        public virtual Color FocusAutoColor
        {
            get
            {
                return myFocusAutoColor;
            }

            set
            {
                Color Value = value;
                myFocusAutoColor = Value;
            }
        }

        public virtual bool ShouldSerializeFocusAutoColor()
        {
            return !(FocusAutoColor.ToArgb() == Color.Yellow.ToArgb());
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt, ob das Steuerelement automatisch mit FocusColor eingefärbt werden soll, wenn es den Fokus erhält.", "Sets or gets the color, if the control should be colored automatically with FocusColor if it gets the focus.")]
        public virtual bool ColorOnFocus
        {
            get
            {
                return myColorOnFocus;
            }

            set
            {
                bool Value = value;
                myColorOnFocus = Value;
            }
        }

        //##########################################################
        //##########################################################
        //### Sonstige Eigenschaften ###############################
        //##########################################################
        //##########################################################
        [Browsable(false)]
        public bool OnceModified
        {
            get
            {
                return myValueControl.OnceModified;
            }
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt einen String, der für die Zuweisung des Controls an ein Datenfeld fungieren kann. Der String hat nur informative Funktion.", "Sets or gets a String, which can act as an assignment of the control to a data field. This property has only an informative effect.")]
        public string IndependentDatafieldName
        {
            get
            {
                return myIndependentDatafieldName;
            }

            set
            {
                string Value = value;
                myIndependentDatafieldName = Value;
            }
        }

        [DefaultValue(false)]
        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Falls eine ungültige Formatierung während der Eingabevalidierung entdeckt wurde, wird bei True für diese Eigenschaft eine Ausnahme ausgelöst, anderenfalls ein Nachrichtenfeld angezeigt.", "If an unvalid input format is encountered during validation, this property determines if an exception will be fired (True) or if a MessageBox will be shown (False).")]
        public bool FireExceptionOnFailedValidation
        {
            get
            {
                return myFireExceptionOnFailedValidation;
            }

            set
            {
                bool Value = value;
                myFireExceptionOnFailedValidation = Value;
            }
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt den Text, der bei der Überprüfung durch die statische Funktion 'CheckForNotAllowedNullValues' ausgegeben wird, wenn der Wert der Value-Eigenschaft Null ist. Es findet keine Überprüfung statt, wenn dieser Eigenschaft kein Text zugewiesen wurde.", "Sets or gets the text that is shown in a MessageBox by the shared function 'CheckForNotAllowedNullValues', if the value property contains Null. The value will not be checked, if no text has been assigned to this property.")]
        public string NullValueMessage
        {
            get
            {
                return myNullValueMessage;
            }

            set
            {
                string Value = value;
                myNullValueMessage = Value;
            }
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt oder ermittelt den Text, der in einem Nachrichtenfeld angezeigt wird, wenn die Eingabevalidierung eine ungültige Eingabewertformatierung festgellt hat. Nachrichtenfeldtitel und -Text werden durch das Pipe-Zeichen (|) getrennt. Der Text wird nicht ausgegeben, wenn die FireExceptionOnFailedValidation-Eigenschaft auf True gesetzt wurde.", "Sets or gets the text that is shown in a MessageBox, if the input validation encountered an unvalid input format. MessageBox Titel and Body are separated by the Pipe-Sign (|). If the FireExceptionOnFailedValidation property has been set to True, the MessageBox will not be shown.")]
        public string FailedValidationErrorMessage
        {
            get
            {
                return myFailedValidationErrorMessage;
            }

            set
            {
                string Value = value;
                myFailedValidationErrorMessage = Value;
            }
        }

        [ADCategory("Verhalten", "Behaviour")]
        [ADDescription("Bestimmt, welcher Text ausgegeben werden soll, wenn der Anwender einen NULL-entsprechenden Wert im Eingabebereich eingegeben hat und das Steuerelement den Fokus verliert.", "Determines the text which should be shown in the data input area, if the user has entered a NULL-Value, and then the control looses its focus.")]
        public string NullString
        {
            get
            {
                return myNullString;
            }

            set
            {
                string Value = value;
                myNullString = Value;
                if (myValue != null)
                {
                    UpdateValue(myValue);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual IADDBNullableValue Value
        {
            get
            {
                if (this.Focused & !(myDontConditionForDisplay))
                {
                    myValue = ToNullableValue(myValueControl.Value);
                }
                else
                {
                    myValue = GetCurrentControlValue();
                }

                return myValue;
            }

            set
            {
                IADDBNullableValue Value = value;
                myValue = Value;
                UpdateValue(Value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ADDBNullable<ADUVType> TypeSafeValue
        {
            get
            {
                return ((ADDBNullable<ADUVType>)Value);
            }

            set
            {
                this.Value = value;
            }
        }

        protected virtual void UpdateValue(IADDBNullableValue Value)
        {
            if (myDontConditionForDisplay)
            {
                myValueControl.Value = Value;
            }
            else
            {
                myObjectForDisplaying = ToObjectForDisplaying(Value, true);
                myObjectForEditing = ToObjectForEditing(Value);
                if (this.Focused)
                {
                    myValueControl.Value = myObjectForEditing;
                }
                else
                {
                    myValueControl.Value = myObjectForDisplaying;
                }
            }
        }

        protected virtual IADDBNullableValue GetCurrentControlValue()
        {
            return myValue;
        }

        [Browsable(false)]
        public virtual object ObjectValue
        {
            get
            {
                return Value.Value;
            }
        }

        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);
            if (ColorOnFocus & !(DesignMode))
            {
                myValueControl.BackColor = FocusAutoColor;
            }

            if (!(myDontConditionForDisplay))
            {
                myValueControl.Value = myObjectForEditing;
            }
        }

        protected override void OnLeave(System.EventArgs e)
        {
            base.OnLeave(e);
            if (ColorOnFocus & !(DesignMode))
            {
                myValueControl.BackColor = BackColor;
            }
        }

        protected virtual object ToObjectForEditing(IADDBNullableValue Value)
        {
            if (!(Value.HasValue))
            {
                return "";
            }
            else
            {
                return Value.Value.ToString();
            }
        }

        protected virtual object ToObjectForDisplaying(IADDBNullableValue Value, bool ForSetValue)
        {
            if (!(Value.HasValue))
            {
                return "- - -";
            }
            else
            {
                return Value.Value.ToString();
            }
        }

        protected abstract ADDBNullable<ADUVType> ToNullableValue(object Object);
        //################################################
        //### Ereignissverarbeitung und Weiterreichung ###
        //################################################
        private void myValueControl_OnceModifiedChanged(object sender, System.EventArgs e)
        {
            OnOnceModifiedChanged(e);
        }

        protected virtual void OnOnceModifiedChanged(System.EventArgs e)
        {
            OnceModifiedChanged?.Invoke(this, e);
        }

        private void myValueControl_ValueChanged(object sender, System.EventArgs e)
        {
            OnValueChanged(e);
        }

        protected virtual void OnValueChanged(System.EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        private void ADEditableValueControlTemplate_GotFocus(object sender, System.EventArgs e)
        {
            Debug.WriteLine(sender.ToString() + ": GotFocus");
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            if (e.Cancel)
            {
                return;
            }

            string locMessageString = null;
            try
            {
                myObjectForEditing = myValueControl.Value;
                myValue = ToNullableValue(myObjectForEditing);
            }
            catch (Exception ex)
            {
                if (FireExceptionOnFailedValidation)
                {
                    InvalidCastException up = new InvalidCastException("Die Eingabe konnte nicht in den Zieltyp umgewandelt werden.");
                    throw up;
                }
                else
                {
                    if (FailedValidationErrorMessage == null | FailedValidationErrorMessage == "")
                    {
                        locMessageString = mySharedFailedValidationErrorDefaultMessage;
                    }
                    else
                    {
                        locMessageString = FailedValidationErrorMessage;
                    }
                }
            }

            if (locMessageString != "")
            {
                //Auseinanderdröseln und als Messagebox ausgeben
                string[] locStringArray = locMessageString.Split(new char[] { '|' });
                try
                {
                    MessageBox.Show(locStringArray[1], locStringArray[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    CultureInfo locCi;
                    string locError;
                    locCi = CultureInfo.CurrentCulture;
                    if (locCi.Name.StartsWith("de"))
                    {
                        locError = "Eine vordefinierte Fehlermeldung sollte ausgegeben werden, allerdings entsprach der Fehlermeldungstext nicht dem korrekten Format. Möglicherweise fehlt das Pipe-Zeichen (|).";
                    }
                    else
                    {
                        locError = "A predefined error message was supposed to be shown, but the message format didn't match the correct format. Probebly the pipe sign (|) is missing.";
                    }

                    locError += System.Environment.NewLine + System.Environment.NewLine;
                    locError += "Error causing control: " + this.Name + System.Environment.NewLine;
                    locError += "Error caused while validating.";
                    SyntaxErrorException up = new SyntaxErrorException(locError);
                    throw up;
                }

                e.Cancel = true;
            }
        }

        protected override void OnValidated(System.EventArgs e)
        {
            //Bereits ungewandelten Wert in das Anzeigeformat umwandeln
            if (!(myDontConditionForDisplay))
            {
                myObjectForDisplaying = ToObjectForDisplaying(myValue, false);
                myValueControl.Value = myObjectForDisplaying;
            }

            base.OnValidated(e);
        }
    }

    //################################################
    //### ControlDesigner Pendant ####################
    //################################################
    //TODO: This method became obsolete!!!
    //WICHTIG: Wenn Sie einen ControlDesigner einfügen,
    //müssen Sie den System.Windows.Forms.Design-Namespace einbinden,
    //und SystemDesign.Dll als Verweis dem Projekt hinzufügen!
    public class ADNullableValueControlTemplateDesigner : ControlDesigner
    {
        //Diese Eigenschaft müssen Sie erweitern,
        //wenn Sie eigene Initialisierungen vornehmen wollen.
        //An dieser Stelle finden Sie den exakten Code von
        //ControlDesigner.OnSetComponentDefaults, der sich um die
        //Initialisierung der 'Text'-Eigenschaft kümmert.
        //Anstelle der kompletten Implementierung reicht auch der Aufruf
        //von 'MyBase.OnSetComponentDefaults()'
        //Public Overrides Sub OnSetComponentDefaults()
        //    'Das ist hier 'geklaut' von ControlDesigner...
        //    Dim locISite As ISite
        //    Dim locPropDescriptor As PropertyDescriptor
        //    'ISite abrufen
        //    locISite = Me.Component.Site
        //    If Not locISite Is Nothing Then
        //        'Text-Property vorhanden?
        //        locPropDescriptor = TypeDescriptor.GetProperties(Me.Component)("Text")
        //        If Not locPropDescriptor Is Nothing Then
        //            'Ja, dann die Text-Property setzen
        //            locPropDescriptor.SetValue(Me.Component, locISite.Name)
        //        End If
        //        'Back-Color vorhanden?
        //        locPropDescriptor = TypeDescriptor.GetProperties(Me.Component)("BackColor")
        //        If Not locPropDescriptor Is Nothing Then
        //            'Ja, dann die BackColor-Property setzen
        //            locPropDescriptor.SetValue(Me.Component, SystemColors.Window)
        //        End If
        //    End If
        //End Sub
        //Muss überschrieben werden, damit bei einem Control mit fixer
        //Größe tatsächlich nur ein vertikale Größenänderung möglich wird.
        //Die vertikalen Anfasspunkte sind dann ausgeblendet
        public override System.Windows.Forms.Design.SelectionRules SelectionRules
        {
            get
            {
                object locThisComponent;
                SelectionRules locSelectionRules;
                locThisComponent = this.Component;
                Debug.WriteLine("Designermessage: This Component is" + (locThisComponent == null).ToString());
                try
                {
                    //In Abhängigkeit von ConsiderFixedSize (die sich beispielsweise durch Multiline ändert)
                    if (Convert.ToBoolean(TypeDescriptor.GetProperties(locThisComponent)["ConsiderFixedSizeInternal"].GetValue(locThisComponent)))
                    {
                        //Nur vertikale Größenveränderungen...
                        locSelectionRules = SelectionRules.Moveable | SelectionRules.Visible | SelectionRules.LeftSizeable | SelectionRules.RightSizeable;
                    }
                    else
                    {
                        //...oder komplette Größenveränderungen ermöglichen
                        locSelectionRules = SelectionRules.Moveable | SelectionRules.Visible | SelectionRules.AllSizeable;
                    }

                    return locSelectionRules;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Designermessage:" + ex.Message);
                    return base.SelectionRules;
                }

                return default(System.Windows.Forms.Design.SelectionRules);
            }
        }
    }

    //################################################
    //### EventArguments #############################
    //################################################
    public class CaptionPlacementChangedEventArgs : EventArgs
    {
        protected ADCaptionPlacementEnum myNewValue;
        protected bool myPrevent;
        public CaptionPlacementChangedEventArgs(ADCaptionPlacementEnum newValue, bool prevent)
        {
            myNewValue = newValue;
            myPrevent = prevent;
        }

        public ADCaptionPlacementEnum NewValue
        {
            get
            {
                return myNewValue;
            }

            set
            {
                ADCaptionPlacementEnum Value = value;
                myNewValue = Value;
            }
        }

        public bool Prevent
        {
            get
            {
                return myPrevent;
            }

            set
            {
                bool Value = value;
                myPrevent = Value;
            }
        }
    }

    //###############################
    //Plazierung der Beschriftungs
    //###############################
    public enum ADCaptionPlacementEnum
    {
        Above,
        LeftSide,
        RightSide,
        Below,
    }

    [CLSCompliant(true)]
    public interface IADNullableValueControl
    {
        IADDBNullableValue Value { get; set; }

        bool OnceModified { get; }

        string IndependentDatafieldName { get; set; }

        string NullValueMessage { get; set; }

        string Text { get; set; }

        delegate void ValueChangedEventHandler(object sender, EventArgs e);
        event ValueChangedEventHandler ValueChanged;
        delegate void OnceModifiedChangedEventHandler(object sender, EventArgs e);
        event OnceModifiedChangedEventHandler OnceModifiedChanged;
    }
}
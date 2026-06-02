using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ActiveDev.Controls
{
    internal partial class ADCaptionForNullableValueControl : ADCaptionForNullableValueControlTemplate
    {
        private class ADLabelExInternal : Control
        {
            private const int WS_BORDER = 8388608;
            private const int WS_EX_CLIENTEDGE = 512;
            private const int myFlashInterval = 400;
            private static Timer myFlashTimer;
            private BorderStyle myBorderstyle;
            private ContentAlignment myTextAlign;
            private bool myUseMnemonic;
            private bool myDirectionVertical;
            private bool myAutoHeight;
            private int myRequestedHeight;
            private bool myTextWrap;
            private StringTrimming myTextTrimming;
            public ADLabelExInternal() : base()
            {
                this.TabStop = false;
                //Eigenschaften initialisieren
                myBorderstyle = BorderStyle.None;
                myTextAlign = ContentAlignment.TopLeft;
                myUseMnemonic = true;
                myTextWrap = true;
                myTextTrimming = StringTrimming.None;
                myFlashBackColor = Color.Empty;
                myFlashForeColor = Color.Empty;
                //Windows-Stile setzen
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.ResizeRedraw, true);
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                //Initialwert für die Höhe merken
                myRequestedHeight = this.Height;
                //Flash-Ereignishandler einrichten
                FlashOn += FlashOnHandler;
                FlashOff += FlashOffHandler;
            }

            //Definiert die Parameter für das Anlegen des "Windows-Window"
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams params1;
                    BorderStyle style1;
                    params1 = base.CreateParams;
                    //Möglicherweise eingeschaltete BorderStyles ausschalten
                    params1.ExStyle = (params1.ExStyle & ~WS_EX_CLIENTEDGE);
                    params1.Style = (params1.Style & ~WS_BORDER);
                    //Herausfinden, welcher Borderstyle eingeschaltet werden soll
                    style1 = this.myBorderstyle;
                    {
                        var __select0 = (int)(style1 - 1);
                        if (__select0 == (int)(0))
                        {
                            //Simpler Rand
                            params1.Style = (params1.Style | WS_BORDER);
                        }
                        else if (__select0 == (int)(1))
                        {
                            //Drei-D-Rand
                            params1.ExStyle = (params1.ExStyle | WS_EX_CLIENTEDGE);
                        }
                    }

                    return params1;
                }
            }

            //**************************************************************************************
            //*** Alles für das Zeichnen    ********************************************************
            //**************************************************************************************
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                //DrawString arbeitet mit RectangleF, ClientRectangle mit Rectangle;
                //deswegen die Werte ins andere "Format" konvertieren.
                RectangleF locRectf = new RectangleF(0, 0, ClientSize.Width, ClientSize.Height);
                //StringFormat-Objekt für die Ausgabe des Strings erzeugen
                StringFormat locSf = CreateStringFormat();
                //Diese "Version" malen, wenn nicht geblinkt wird, oder gerade die Aus-Phase stattfindet
                if (!(Flash) | !(myFlashState))
                {
                    //Bei der Ausgabe des Strings "CR" anhängen, damit wird bei rechtsbündiger und
                    //zentrierter Formatierung die richtige Stringlänge berücksichtigt.
                    e.Graphics.DrawString(Text + "\r", Font, new SolidBrush(ForeColor), locRectf, locSf);
                }
                else
                {
                    //Sonst die An-Phase zeichnen, mit FlashBackColor und FlashForeColor
                    e.Graphics.Clear(FlashBackColor);
                    e.Graphics.DrawString(Text + "\r", Font, new SolidBrush(FlashForeColor), locRectf, locSf);
                }

                //Kein Speicher verschwenden!
                locSf.Dispose();
            }

            //Bastelt aus der Einstellung für ContentAlignment das StringFormat-Objekt zusammen,
            //über das diese Eigenschaft bei der Ausgabe mit DrawString umgesetzt wird.
            protected virtual StringFormat StringFormatForAlignment(ContentAlignment textAlign)
            {
                StringFormat locStringFormat = new StringFormat();
                if ((textAlign & ContentAlignment.BottomLeft) == ContentAlignment.BottomLeft | (textAlign & ContentAlignment.MiddleLeft) == ContentAlignment.MiddleLeft | (textAlign & ContentAlignment.TopLeft) == ContentAlignment.TopLeft)
                {
                    locStringFormat.Alignment = StringAlignment.Near;
                }
                else if ((textAlign & ContentAlignment.BottomRight) == ContentAlignment.BottomRight | (textAlign & ContentAlignment.MiddleRight) == ContentAlignment.MiddleRight | (textAlign & ContentAlignment.TopRight) == ContentAlignment.TopRight)
                {
                    locStringFormat.Alignment = StringAlignment.Far;
                }
                else if ((textAlign & ContentAlignment.BottomCenter) == ContentAlignment.BottomCenter | (textAlign & ContentAlignment.MiddleCenter) == ContentAlignment.MiddleCenter | (textAlign & ContentAlignment.TopCenter) == ContentAlignment.TopCenter)
                {
                    locStringFormat.Alignment = StringAlignment.Center;
                }

                if ((textAlign & ContentAlignment.TopLeft) == ContentAlignment.TopLeft | (textAlign & ContentAlignment.TopRight) == ContentAlignment.TopRight | (textAlign & ContentAlignment.TopCenter) == ContentAlignment.TopCenter)
                {
                    locStringFormat.LineAlignment = StringAlignment.Near;
                }
                else if ((textAlign & ContentAlignment.MiddleLeft) == ContentAlignment.MiddleLeft | (textAlign & ContentAlignment.MiddleRight) == ContentAlignment.MiddleRight | (textAlign & ContentAlignment.MiddleCenter) == ContentAlignment.MiddleCenter)
                {
                    locStringFormat.LineAlignment = StringAlignment.Center;
                }
                else if ((textAlign & ContentAlignment.BottomLeft) == ContentAlignment.BottomLeft | (textAlign & ContentAlignment.BottomCenter) == ContentAlignment.BottomCenter | (textAlign & ContentAlignment.BottomRight) == ContentAlignment.BottomRight)
                {
                    locStringFormat.LineAlignment = StringAlignment.Far;
                }

                return locStringFormat;
            }

            //Baut das StringFormat-Objekt zusammen und berücksichtigt nicht nur ContentAlignment,
            //sondern auch andere Eigenschaften des AdLabelEx-Steuerelementes
            protected virtual StringFormat CreateStringFormat()
            {
                StringFormat locStringFormat;
                //Grundsätzliche Einstellungen aufgrund des ContentAlignment holen
                locStringFormat = StringFormatForAlignment(this.TextAlign);
                //RightToLeft-Einstellung für Arabische Sprachen berücksichtigen
                if (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                {
                    locStringFormat.FormatFlags = locStringFormat.FormatFlags | StringFormatFlags.DirectionRightToLeft;
                }

                //Zugriffstastenanzeige berücksichtigen
                if (!(this.UseMnemonic))
                {
                    locStringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                }
                else
                {
                    if ((this.ShowKeyboardCues))
                    {
                        locStringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
                    }
                    else
                    {
                        locStringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide;
                    }
                }

                //If Me.AutoSize Then
                //    locStringFormat.FormatFlags = locStringFormat.FormatFlags Or StringFormatFlags.MeasureTrailingSpaces
                //End If
                //Möglichst genaue Formatierung
                locStringFormat.FormatFlags = locStringFormat.FormatFlags | StringFormatFlags.FitBlackBox;
                //LineLimit wird nicht berücksichtigt, wenn der Text nicht in den Rahmen passt
                locStringFormat.FormatFlags = locStringFormat.FormatFlags & ~StringFormatFlags.LineLimit;
                //Text um 90 Grad im Uhrzeigersinn drehen?
                if (DirectionVertical)
                {
                    locStringFormat.FormatFlags = locStringFormat.FormatFlags | StringFormatFlags.DirectionVertical;
                }

                //Textwrapping eingeschaltet?
                if (!(TextWrap))
                {
                    locStringFormat.FormatFlags = locStringFormat.FormatFlags | StringFormatFlags.NoWrap;
                }

                //Das Trimming definieren
                locStringFormat.Trimming = TextTrimming;
                //Wert zurückgeben
                return locStringFormat;
            }

            //Misst die "echten" Ausmaße des Strings; wird für diese Version nicht mehr benötigt,
            //aus "Wissen-wie-es-funktioniert-Gründen" ist es nach wie vor im Code.
            [Obsolete("Diese Funktion wird in dieser Klasse nicht mehr verwendet")]
            private Size MeasureDisplayString(Graphics g, string text, Font font)
            {
                StringFormat locFormat = new StringFormat();
                RectangleF locRectF = new RectangleF(0, 0, ClientSize.Width, 10000);
                CharacterRange[] locRanges =
                {
                    new CharacterRange(0, text.Length)
                };
                Region[] locRegions;
                locFormat.SetMeasurableCharacterRanges(locRanges);
                locRegions = g.MeasureCharacterRanges(text, font, locRectF, locFormat);
                locRectF = locRegions[0].GetBounds(g);
                return new Size(System.Convert.ToInt32(locRectF.Width), System.Convert.ToInt32(locRectF.Height));
            }

            //**************************************************************************************
            //*** Größenhandling            ********************************************************
            //**************************************************************************************
            //Die neue Höhe einstellen. Diese Methode wird aufgerufen, wenn sich eine Eigenschaft
            //geändert hat, die die Höhe des Steuerelementes beeinflusst, wenn AutoHeight eingeschaltet ist.
            private void AdjustHeight()
            {
                int locRequestedHeightTemp;
                locRequestedHeightTemp = myRequestedHeight;
                try
                {
                    if (AutoHeight)
                    {
                        base.Size = new Size(this.Size.Width, PreferedHeight);
                    }
                    else
                    {
                        base.Size = new Size(this.Size.Width, locRequestedHeightTemp);
                    }
                }
                finally
                {
                    myRequestedHeight = locRequestedHeightTemp;
                }
            }

            //Ermittelt die Höhe des Textes bei einer bestimmten Breite. Diese Funktion
            //wird von AdjustHeight für die automatische Höhenanpassung des Steuerelementes verwendet.
            public virtual int PreferedHeight
            {
                get
                {
                    int locHeightToReturn;
                    if (this.Text == "")
                    {
                        locHeightToReturn = this.FontHeight;
                    }
                    else
                    {
                        Graphics locG;
                        StringFormat locSf;
                        SizeF locSizeF;
                        locG = Graphics.FromHwnd(this.Handle);
                        locSf = CreateStringFormat();
                        //Texthöhe automatisch ermittelt. Das erreichen Sie, wenn Sie für die Höhe 0 übergeben.
                        locSizeF = locG.MeasureString(Text, Font, new SizeF(ClientSize.Width, 0), locSf);
                        //Immer nach unten abrunden!
                        locHeightToReturn = System.Convert.ToInt32(Math.Ceiling(locSizeF.Height));
                    }

                    //Falls es einen Borderstyle gibt, 2 Pixel draufrechnen, damit es nicht
                    //zu gequetscht wird.
                    if (BorderStyle != BorderStyle.None)
                    {
                        locHeightToReturn += 2;
                    }

                    return locHeightToReturn;
                }
            }

            //Setzt alle Ausmaße des Steuerelements oder nur bestimmte Größenkomponenten,
            //die von specified bestimmt werden.
            protected override void SetBoundsCore(int x, int y, int width, int height, System.Windows.Forms.BoundsSpecified specified)
            {
                Rectangle locRect = new Rectangle();
                //Falls AutoHeight eingeschaltet ist...
                if (AutoHeight)
                {
                    //...und die Breite bestimmt werden soll...
                    if ((specified & BoundsSpecified.Width) == BoundsSpecified.Width)
                    {
                        //...dann die neue Breite im Steuerelement setzen...
                        base.SetBoundsCore(x, y, width, height, specified);
                        //...jetzt muss aber auch die Höhe neu errechnet werden
                        AdjustHeight();
                        //...und wenn die zwischengespeicherte Höhe gesetzt war...
                        if (myRequestedHeight > 0)
                        {
                            //dann bricht der Vorgang hier ab. Anderenfalls wurde myRequestedHeight nicht
                            //initialisiert, und zwar dadurch, dass Height noch 0 war, als das
                            //Steuerelement erstellt wurde. Erst die erste Zuweisung der Size-Eigenschaft
                            //bestimmt die Höhe, die aber selbst mit SetBoundsCore gesetzt wird. Aus diesem
                            //Grund kann myRequestedHeight beim ersten Durchlauf keinen anderen Wert als
                            //0 haben und muss entsprechend initialisiert werden.
                            return;
                        }
                    }
                }

                //Aktuelle Ausmaße zwischenspeichern
                locRect = this.Bounds;
                if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height)
                {
                    //myRequestedHeight wird neu definiert, wenn die Höhe (zum Beispiel durch Size)
                    //explizit zugewiesen wird. Am vom SetBoundsCore "verlangten" Height
                    //ändert sich nur dann was...
                    myRequestedHeight = height;
                }

                //...wenn AutoHeight eingeschaltet ist. Dann wird die Höhe des Steuerelementes auf die
                //gemessene Höhe des Textes festgeschrieben.
                if ((this.AutoHeight && (locRect.Height != height)))
                {
                    height = this.PreferedHeight;
                }

                //Basis aufrufen
                base.SetBoundsCore(x, y, width, height, specified);
            }

            //**************************************************************************************
            //*** Eigenschaften                      ***********************************************
            //**************************************************************************************
            //Entwerfen einer neue Eigenschaft FontHeightInternal,
            //auf die von der umgebenden Klasse zugegriffen werden kann...
            internal int FontHeightInternal
            {
                get
                {
                    return base.FontHeight;
                }
            }

            [DefaultValue(typeof(bool), "True")]
            [Category("Darstellung")]
            [Description("Ist diese Eigenschaft gesetzt, wird das erste Zeichen, dem ein Kaufmannsund vorangeht, " + "als Zugriffstaste für das nächste Steuerelement in der TAB-Reihenfolge verwendet.")]
            [Browsable(true)]
            public bool UseMnemonic
            {
                get
                {
                    return myUseMnemonic;
                }

                set
                {
                    bool Value = value;
                    myUseMnemonic = Value;
                    this.Invalidate();
                }
            }

            [DefaultValue(typeof(BorderStyle), "None")]
            [Category("Darstellung")]
            [Description("Bestimmt die Art der Umrahmung des Steuerelementes.")]
            [Browsable(true)]
            public BorderStyle BorderStyle
            {
                get
                {
                    return myBorderstyle;
                }

                set
                {
                    BorderStyle Value = value;
                    myBorderstyle = Value;
                    //Bewirkt, dass die CreateParams mit neuen Einstellungen aufgerufen, und
                    //das Steuerelement neu gezeichnet wird.
                    UpdateStyles();
                    AdjustHeight();
                }
            }

            [DefaultValue(typeof(ContentAlignment), "TopLeft")]
            [Category("Darstellung")]
            [Description("Bestimmt, wie der Text innerhalb des Steuerelementes ausgerichtet wird.")]
            [Browsable(true)]
            public ContentAlignment TextAlign
            {
                get
                {
                    return myTextAlign;
                }

                set
                {
                    ContentAlignment Value = value;
                    myTextAlign = Value;
                    //Inhalt bei der nächsten Gelegenheit neu zeichnen
                    Invalidate();
                }
            }

            [DefaultValue(typeof(bool), "False")]
            [Category("Darstellung")]
            [Description("Bestimmt, ob der Text im Uhrzeigersinn um 90 Grad gedreht angezeigt werden soll.")]
            [Browsable(true)]
            [RefreshProperties(RefreshProperties.All)]
            public bool DirectionVertical
            {
                get
                {
                    return myDirectionVertical;
                }

                set
                {
                    bool Value = value;
                    if (Value != DirectionVertical)
                    {
                        if (Value)
                        {
                            if (AutoHeight)
                            {
                                AutoHeight = false;
                            }
                        }

                        myDirectionVertical = Value;
                        //Inhalt bei der nächsten Gelegenheit neu zeichnen
                        Invalidate();
                    }
                }
            }

            [DefaultValue(typeof(bool), "False")]
            [Category("Darstellung")]
            [Description("Bestimmt, ob die Höhe des Steuerelementes automatisch angepasst werden soll.")]
            [Browsable(true)]
            [RefreshProperties(RefreshProperties.All)]
            public bool AutoHeight
            {
                get
                {
                    return myAutoHeight;
                }

                set
                {
                    bool Value = value;
                    if (Value != AutoHeight)
                    {
                        if (Value)
                        {
                            if (DirectionVertical)
                            {
                                DirectionVertical = false;
                            }
                        }

                        myAutoHeight = Value;
                        //Größe anpassen
                        AdjustHeight();
                    }
                }
            }

            [DefaultValue(typeof(bool), "True")]
            [Category("Darstellung")]
            [Description("Bestimmt, ob der Text am Ende einer Zeile umgebrochen werden soll.")]
            [Browsable(true)]
            public bool TextWrap
            {
                get
                {
                    return myTextWrap;
                }

                set
                {
                    bool Value = value;
                    myTextWrap = Value;
                    Invalidate();
                    //Das Ein- oder Ausschalten des Wrapping beeinflusst natürlich auch die Höhe!
                    AdjustHeight();
                }
            }

            [DefaultValue(typeof(StringTrimming), "None")]
            [Category("Darstellung")]
            [Description("Bestimmt, auf welche Weise nicht mehr darstellbare Zeichen abgeschnitten werden können.")]
            [Browsable(true)]
            public StringTrimming TextTrimming
            {
                get
                {
                    return myTextTrimming;
                }

                set
                {
                    StringTrimming Value = value;
                    myTextTrimming = Value;
                    Invalidate();
                }
            }

            //Wir müssen Text nicht neu implementieren, es reicht, wenn wir erfahren,
            //*dass* sich die Texteigenschaft geändert hat.
            protected override void OnTextChanged(System.EventArgs e)
            {
                AdjustHeight();
                Invalidate();
            }

            //**************************************************************************************
            //*** Flash-Handling                     ***********************************************
            //**************************************************************************************
            private static bool myFlashState;
            private static int myFlashTimerUseCounter;
            private bool myFlashTimerUsed;
            private bool myFlash;
            private Color myFlashBackColor;
            private Color myFlashForeColor;
            public delegate void FlashOnEventHandler(object sender, EventArgs e);
            public static event FlashOnEventHandler FlashOn;
            public delegate void FlashOffEventHandler(object sender, EventArgs e);
            public static event FlashOffEventHandler FlashOff;
            //Es gibt einen einzigen Timer für alle blinkenden ADLabelEx-Instanzen. Alles andere
            //wäre Verschwendung von Ressourcen.
            //Und auch der eine Timer wird erst dann angeworfen, wenn das erste ADLabelEX
            //blinken will.
            private static void StartFlashHandlerOnDemand()
            {
                if (myFlashTimerUseCounter == 0)
                {
                    myFlashTimer = new Timer();
                    myFlashTimer.Interval = myFlashInterval;
                    myFlashTimer.Start();
                    //Hier wird die Ereignisbehandlungsroutine eingebunden, die beim
                    //Ablaufen von myFlashInterval-Millisekunden (also alle 300) aufgerufen wird.
                    myFlashTimer.Tick += FlashTimeHandler;
                }

                //Damit die Steuerelement-Klasse weiß, wieviele Instanzen blinken,
                //gibt es einen Zähler...
                myFlashTimerUseCounter += 1;
            }

            private static void StopFlashHandlerOnDemand()
            {
                myFlashTimerUseCounter -= 1;
                //...damit das Timer-Objekt ordnungsgemäß entladen werden kann,
                //wenn es nicht mehr benötigt wird.
                if (myFlashTimerUseCounter == 0)
                {
                    myFlashTimer.Stop();
                    myFlashTimer.Dispose();
                }
            }

            //Dispose wird benötigt, damit der letzte das Licht (den Timer) ausmachen kann!
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (myFlashTimerUsed)
                    {
                        FlashOn -= FlashOnHandler;
                        FlashOff -= FlashOffHandler;
                        StopFlashHandlerOnDemand();
                    }
                }

                base.Dispose(disposing);
            }

            //Dieser private Ereignishandler löst zwei neue Ereignisse aus, die öffentlich empfangen werden
            //können. Es gibt jeweils für beginnende An- und Aus-Phase ein Ereignis.
            private static void FlashTimeHandler(object sender, EventArgs e)
            {
                myFlashState = !(myFlashState);
                if (myFlashState)
                {
                    FlashOn?.Invoke("ADLabelEx.FlashHandler", EventArgs.Empty);
                }
                else
                {
                    FlashOff?.Invoke("ADLabelEx.FlashHandler", EventArgs.Empty);
                }
            }

            protected virtual void FlashOnHandler(object sender, EventArgs e)
            {
                //Da die Ereignis-Handler schon im Konstruktor eingebunden werden (war einfacher ;-)
                //treten die Ereignisse auch auf, wenn ein anderen ADLabelEx blinken will.
                //Deswegen muss diese Instanz testen, ob sie blinken darf.
                if (!(myFlash))
                {
                    return;
                }

                //Alles weitere regelt OnPaint...
                this.Invalidate();
            }

            //Das Selbe in blau/schwarz.
            protected virtual void FlashOffHandler(object sender, EventArgs e)
            {
                if (!(myFlash))
                {
                    return;
                }

                this.Invalidate();
            }

            [DefaultValue(typeof(bool), "False")]
            [Category("Darstellung")]
            [Description("Bestimmt, ob der Label-Text blinked angezeigt werden soll.")]
            [Browsable(true)]
            public bool Flash
            {
                get
                {
                    return myFlash;
                }

                set
                {
                    bool Value = value;
                    myFlash = Value;
                    //Im Entwurfsmodus wird nicht geblinkt!
                    if (!(DesignMode))
                    {
                        if (Value)
                        {
                            //Erst das erste Setzen initialisiert den Blink-Timer
                            //aber nur beim ersten Mal!
                            if (!(myFlashTimerUsed))
                            {
                                StartFlashHandlerOnDemand();
                            }

                            myFlashTimerUsed = true;
                        }
                        else
                        {
                            //Alten Zustand wiederherstellen
                            Invalidate();
                        }
                    }
                }
            }

            [Category("Darstellung")]
            [Description("Bestimmt die Hintergrundfarbe beim Blinken, wenn sich das Steuerelement in der An-Phase befindet.")]
            [Browsable(true)]
            public Color FlashBackColor
            {
                get
                {
                    //Hier läufts anders mit den Standardwerten. Wenn keine Farbe definiert ist,
                    //"erbt" diese Eigenschaft von BackColor. Dadurch muss nur BackColor verändert
                    //werden, um auch FlashBackColor zu verändern. Allerdings gibt es damit keinen
                    //festen Standardwert...
                    if (myFlashBackColor.Equals(Color.Empty))
                    {
                        return BackColor;
                    }
                    else
                    {
                        return myFlashBackColor;
                    }
                }

                set
                {
                    Color Value = value;
                    if (Value.Equals(BackColor))
                    {
                        myFlashBackColor = Color.Empty;
                    }
                    else
                    {
                        myFlashBackColor = Value;
                    }
                }
            }

            //...deswegen muss mit einer Funktion ermittelt werden, ob der aktuelle Wert der Standardwert ist.
            //Nur wenn er es nicht ist, wird serialisiert (Code für die Eigenschaft in der sie einbindenden
            //Instanz erzeugt).
            public bool ShouldSerializeFlashBackColor()
            {
                return !(myFlashBackColor.Equals(Color.Empty));
            }

            //Damit wird die Reset-Funktion für diese Eigenschaft im Eigenschaftenfenster
            //(Kontext-Menü über der Eigenschaft) aktiviert.
            public void ResetFlashBackColor()
            {
                myFlashBackColor = Color.Empty;
            }

            [Category("Darstellung")]
            [Description("Bestimmt die Vordergrundfarbe beim Blinken, wenn sich das Steuerelement in der An-Phase befindet.")]
            [Browsable(true)]
            public Color FlashForeColor
            {
                get
                {
                    if (myFlashForeColor.Equals(Color.Empty))
                    {
                        return BackColor;
                    }
                    else
                    {
                        return myFlashForeColor;
                    }
                }

                set
                {
                    Color Value = value;
                    if (Value.Equals(BackColor))
                    {
                        myFlashForeColor = Color.Empty;
                    }
                    else
                    {
                        myFlashForeColor = Value;
                    }
                }
            }

            public bool ShouldSerializeFlashForeColor()
            {
                return !(myFlashForeColor.Equals(Color.Empty));
            }

            public void ResetFlashForeColor()
            {
                myFlashForeColor = Color.Empty;
            }
        }
    }
}
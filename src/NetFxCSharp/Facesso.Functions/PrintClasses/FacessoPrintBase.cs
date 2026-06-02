using ActiveDev.Printing;
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public class FacessoPrintBase
    {
        private ADSimplePrintDocument mySimplePrintDocument;
        private LayoutAndNumberformats myLayoutAndNumberFormats;
        private ADFrameCellBorderStyle myBorderStyle;
        private float myBorderLineWidth;
        private string myAnalysisTitle;
        private string myAnalysisSubTitle;
        private string myUsername;
        public FacessoPrintBase(string AnalysisTitle, string AnalysisSubTitel, string Username)
        {
            ADSimplePrintDocumentDefaultPages defaultPages = new ADSimplePrintDocumentDefaultPages(true, false);
            myLayoutAndNumberFormats = ((LayoutAndNumberformats)FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("LayoutAndNumberFormats", new LayoutAndNumberformats()));
            defaultPages.GetPage(2).LeftHeaderText = "Facesso.NET";
            defaultPages.GetPage(2).RightHeaderText = System.DateTime.Now.ToLongDateString();
            defaultPages.GetPage(2).CenterHeaderText = AnalysisTitle;
            defaultPages.GetPage(1).LeftFooterText = "Gedruckt von: " + Username;
            defaultPages.GetPage(1).RightFooterText = "(C) 05-07 by http://ActiveDevelop.de";
            defaultPages.GetPage(1).CenterFooterText = "Seite - {%page%} -";
            defaultPages.GetPage(2).LeftFooterText = "Gedruckt von: " + Username;
            defaultPages.GetPage(2).RightFooterText = "(C) 05-07 by http://ActiveDevelop.de";
            defaultPages.GetPage(2).CenterFooterText = "Seite - {%page%} -";
            mySimplePrintDocument = new ADSimplePrintDocument(AnalysisTitle, defaultPages);
            myAnalysisTitle = AnalysisTitle;
            myAnalysisSubTitle = AnalysisSubTitel;
            myUsername = Username;
            {
                var __select0 = (int)(myLayoutAndNumberFormats.Gridstyle);
                if (__select0 == (int)(FacessoLayoutGridstyle.NoGrid))
                {
                    myBorderStyle = ADFrameCellBorderStyle.None;
                    myBorderLineWidth = 0;
                }
                else if (__select0 == (int)(FacessoLayoutGridstyle.SimpleGridThin))
                {
                    myBorderStyle = ADFrameCellBorderStyle.FixedSingle;
                    myBorderLineWidth = 0.5f;
                }
                else if (__select0 == (int)(FacessoLayoutGridstyle.SimpleGridThick))
                {
                    myBorderStyle = ADFrameCellBorderStyle.FixedSingle;
                    myBorderLineWidth = 1;
                }
                else if (__select0 == (int)(FacessoLayoutGridstyle.ThreeDGrid1))
                {
                    myBorderStyle = ADFrameCellBorderStyle.Fixed3DRaisedFrame;
                    myBorderLineWidth = 1;
                }
                else if (__select0 == (int)(FacessoLayoutGridstyle.ThreeDGrid2))
                {
                    myBorderStyle = ADFrameCellBorderStyle.Fixed3DSunkenFrame;
                    myBorderLineWidth = 1;
                }
            }
        }

        protected virtual void PrepareDocument()
        {
            PrepareDocument(false);
        }

        protected virtual void PrepareDocument(bool DontPrintBeginingConclusion)
        {
            {
                var __with1 = mySimplePrintDocument;
                if (DontPrintBeginingConclusion)
                {
                    __with1.CurrentFont = myLayoutAndNumberFormats.U3Font.ToFont();
                    __with1.CurrentAlignment = ADTextAlignment.Center;
                    __with1.DefaultPages.FirstPageDifferent = false;
                }
                else
                {
                    __with1.CurrentFont = myLayoutAndNumberFormats.U1Font.ToFont();
                    __with1.CurrentAlignment = ADTextAlignment.Center;
                    //Alle Zeilen der �berschrift ausgeben
                    IADPrintableObject locIADPO = __with1.WriteLine(myAnalysisTitle);
                    locIADPO.DistanceToNext = 15;
                    __with1.CurrentFont = myLayoutAndNumberFormats.U2Font.ToFont();
                    string[] locLines = myAnalysisSubTitle.Split(new string[] { "\r".ToString() }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string locLine in locLines)
                    {
                        __with1.WriteLine(locLine);
                    }

                    __with1.WriteLine();
                    __with1.CurrentFont = myLayoutAndNumberFormats.U3Font.ToFont();
                    __with1.CurrentAlignment = ADTextAlignment.Left;
                }
            }
        }

        public virtual void ProcessDocument(AnalysisTarget ProcessTarget)
        {
            if (ProcessTarget == AnalysisTarget.PreviewBeforePrint)
            {
                PrepareDocument();
                PrintDocument.PreviewDocument();
            }
            else if (ProcessTarget == AnalysisTarget.DirectlyToPrinter)
            {
                PrepareDocument();
                PrintDocument.PrintDocument();
            }
            else
            {
                if (!(HasExcelExport))
                {
                    MessageBox.Show("Excel-Export-Funktionalit�t steht in diesem Auswertungstyp nicht zur Verf�gung!", "Export nicht m�glich!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ExcelExportHandler();
                }
            }
        }

        public virtual bool HasExcelExport
        {
            get
            {
                return false;
            }
        }

        private void ExcelExportHandler()
        {
            SaveFileDialog locSFD = new SaveFileDialog();
            {
                var __with2 = locSFD;
                __with2.Title = "Export f�r Excel als CSV-Datei";
                __with2.OverwritePrompt = true;
                __with2.CheckPathExists = true;
                __with2.DefaultExt = "*.CSV";
                __with2.Filter = "Kommagetrennte Exportdatei (*.csv)|*.csv|Textdatei (*.txt)|*.txt|Alle Dateien (*.*)|*.*";
                DialogResult dialogErgebnis = __with2.ShowDialog();
                if (dialogErgebnis == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                ExcelExport(__with2.FileName);
            }
        }

        protected virtual void ExcelExport(string Filename)
        {
        }

        [CLSCompliant(false)]
        public ADSimplePrintDocument PrintDocument
        {
            get
            {
                return mySimplePrintDocument;
            }
        }

        public LayoutAndNumberformats LayoutAndNumberFormats
        {
            get
            {
                return myLayoutAndNumberFormats;
            }
        }

        [CLSCompliant(false)]
        public ADFrameCellBorderStyle BorderStyle
        {
            get
            {
                return myBorderStyle;
            }
        }

        public float BorderLineWidth
        {
            get
            {
                return myBorderLineWidth;
            }
        }
    }
}
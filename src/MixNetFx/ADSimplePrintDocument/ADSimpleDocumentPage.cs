#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;


#endregion

namespace ActiveDev.Printing
{
    public enum ADSimpleDocumentStandardSizes
    {
        German_A4,
        US_Letter
    }

    /// <summary>
    /// Stellt die Basisklasse für eine gedruckte Seite eines SimplePrintDocuments dar.
    /// </summary>
    public abstract class ADSimplePrintDocumentPageBase
    {
        protected ADPrintableObjects myPrintableObjects;

        protected float myLeftMargin;
        protected float myRightMargin;
        protected float myTopMargin;
        protected float myBottomMargin;
        protected ADPrintableObjects myBackgroundPrintableObjects;
        protected ADPrintableObjects myInternalPrintableObjects;
        protected ADPrintableObjects myForegroundPrintableObjects;
        private int myCurrentPage;
        private float myCurrentPageWidth;
        private float myCurrentPageHeight;

        public ADSimplePrintDocumentPageBase()
        {
            myBackgroundPrintableObjects = new ADPrintableObjects();
            myInternalPrintableObjects = new ADPrintableObjects();
            myForegroundPrintableObjects = new ADPrintableObjects();
        }

        public virtual void RenderBackgroundObjects(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
        {
            foreach (IADPrintableObject locPO in myBackgroundPrintableObjects)
            {
                locPO.MeasureSize(g, currentDefaultPage);
                locPO.Render(g, currentDefaultPage);
            }

            foreach (IADPrintableObject locPO in myInternalPrintableObjects)
            {
                locPO.MeasureSize(g, currentDefaultPage);
                locPO.Render(g, currentDefaultPage);
            }
        }

        public virtual void RenderForegroundObjects(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
        {
            foreach (IADPrintableObject locPO in myForegroundPrintableObjects)
            {
                locPO.MeasureSize(g, currentDefaultPage);
                locPO.Render(g, currentDefaultPage);
            }
        }

        /// <summary>
        /// Definiert den linken Rand in Document Units.
        /// </summary>
        public float LeftMargin
        {
            get { return myLeftMargin; }
            set { myLeftMargin = value; }
        }

        /// <summary>
        /// Definiert den rechten Rand in Document Units.
        /// </summary>
        public float RightMargin
        {
            get { return myRightMargin; }
            set { myRightMargin = value; }
        }

        /// <summary>
        /// Definiert den oberen Rand.
        /// </summary>
        public float TopMargin
        {
            get { return myTopMargin; }
            set { myTopMargin = value; }
        }

        /// <summary>
        /// Definiert den unteren Rand in Document Units.
        /// </summary>
        public float BottomMargin
        {
            get { return myBottomMargin; }
            set { myBottomMargin = value; }
        }

        public ADPrintableObjects BackStaticPrintableObjects
        {
            get { return myBackgroundPrintableObjects; }
            set { myBackgroundPrintableObjects = value; }
        }

        /// <summary>
        /// Ermittelt die aktuelle Seitennummer.
        /// </summary>
        public int CurrentPage
        {
            get { return myCurrentPage; }
            internal set { myCurrentPage = value; }
        }

        /// <summary>
        /// Ermittelt die aktuelle Seitenbreite in Document Units.
        /// </summary>
        public float CurrentPageWidth
        {
            get { return myCurrentPageWidth; }
            internal set { myCurrentPageWidth = value; }
        }

        /// <summary>
        /// Ermittelt die Höhe der aktuellen Seite in Document Units.
        /// </summary>
        public float CurrentPageHeight
        {
            get { return myCurrentPageHeight; }
            internal set { myCurrentPageHeight = value; }
        }
    }

    /// <summary>
    /// Stellt eine Standardseite eines Dokuments dar, auf der alle Seiten eines SimplePrintDokumentes basieren.
    /// </summary>
    public class ADSimplePrintDocumentDefaultPage : ADSimplePrintDocumentPageBase
    {
        private string myLeftFooterText;
        private string myRightFooterText;
        private string myCenterFooterText;
        private float myFooterLineWidth;
        private float myFooterDistanceFromPageBottomMargin;
        private ADSimpleDocumentFontSetting myFooterFontSetting;
        private ADTextAlignment myFooterAlignmentSetting;
        private string myLeftHeaderText;
        private string myRightHeaderText;
        private string myCenterHeaderText;
        private float myHeaderLineWidth;
        private float myHeaderDistanceFromPageTopMargin;
        private ADSimpleDocumentFontSetting myHeaderFontSetting;
        private ADTextAlignment myHeaderAlignmentSetting;

        internal ADSimplePrintDocumentDefaultPage()
        {
            SetStandardMargins();
            SetStandardFonts();
            SetStandardAlignments();
        }

        internal ADSimplePrintDocumentDefaultPage(bool setStandardFooter)
        {
            SetStandardMargins();
            SetStandardFonts();
            SetStandardAlignments();
        }

        private void SetStandardMargins()
        {
            myFooterDistanceFromPageBottomMargin = ADSimplePrintDocument.CmToDocument(0.75f);
            myHeaderDistanceFromPageTopMargin = ADSimplePrintDocument.CmToDocument(0.75f);
        }

        private void SetStandardFonts()
        {
            myFooterFontSetting = new ADSimpleDocumentFontSetting();
            myHeaderFontSetting = new ADSimpleDocumentFontSetting();
        }

        private void SetStandardAlignments()
        {
            myFooterAlignmentSetting = ADTextAlignment.Center;
            myHeaderAlignmentSetting = ADTextAlignment.Center;
        }

        private void GenerateObjects()
        {
            myInternalPrintableObjects = new ADPrintableObjects();
            ADFooterHeaderLine fhlTemp = new ADFooterHeaderLine(LeftHeaderText, RightHeaderText, CenterHeaderText, HeaderFontSetting.Font, HeaderFontSetting.Brush, HeaderLineWidth);
            fhlTemp.IsHeader = true;
            myInternalPrintableObjects.Add(fhlTemp);
            myInternalPrintableObjects.Add(new ADFooterHeaderLine(LeftFooterText, RightFooterText, CenterFooterText, FooterFontSetting.Font, FooterFontSetting.Brush, FooterLineWidth));
        }

        /// <summary>
        /// Definiert die Fußzeile des linken Teils der Seite.
        /// </summary>
        public string LeftFooterText
        {
            get { return myLeftFooterText; }
            set
            {
                myLeftFooterText = value;
                GenerateObjects();
            }
        }

        /// <summary>
        /// Definiert die Kopfzeile des linken Teils der Seite.
        /// </summary>
        public string LeftHeaderText
        {
            get { return myLeftHeaderText; }
            set
            {
                myLeftHeaderText = value;
                GenerateObjects();
            }
        }

        /// <summary>
        /// Definiert die Fußzeile des rechten Teils der Seite.
        /// </summary>
        public string RightFooterText
        {
            get { return myRightFooterText; }
            set
            {
                myRightFooterText = value;
                GenerateObjects();
            }
        }

        /// <summary>
        /// Definiert die Kopfzeile des rechten Teils der Seite.
        /// </summary>
        public string RightHeaderText
        {
            get { return myRightHeaderText; }
            set
            {
                myRightHeaderText = value;
                GenerateObjects();
            }
        }

        /// <summary>
        /// Definiert die Fußzeile des mittleren Teils der Seite.
        /// </summary>
        public string CenterFooterText
        {
            get { return myCenterFooterText; }
            set
            {
                myCenterFooterText = value;
                GenerateObjects();
            }
        }

        /// <summary>
        /// Definiert die Kopfzeile des mittleren Teils der Seite.
        /// </summary>
        public string CenterHeaderText
        {
            get { return myCenterHeaderText; }
            set
            {
                myCenterHeaderText = value;
                GenerateObjects();
            }
        }


        /// <summary>
        /// Definiert die Breite der Fußzeile
        /// </summary>
        public float FooterLineWidth
        {
            get { return myFooterLineWidth; }
            set { myFooterLineWidth = value; }
        }

        /// <summary>
        /// Definiert die Breite der Kopfzeile.
        /// </summary>
        public float HeaderLineWidth
        {
            get { return myHeaderLineWidth; }
            set { myHeaderLineWidth = value; }
        }

        /// <summary>
        /// Definiert den Zeichensatz der Fußzeile.
        /// </summary>
        public ADSimpleDocumentFontSetting FooterFontSetting
        {
            get { return myFooterFontSetting; }
            set
            {
                myFooterFontSetting = value;
                GenerateObjects();
            }
        }

        /// <summary>
        /// Definiert den Zeichensatz der Kopfzeile.
        /// </summary>
        public ADSimpleDocumentFontSetting HeaderFontSetting
        {
            get { return myHeaderFontSetting; }
            set
            {
                myHeaderFontSetting = value;
                GenerateObjects();
            }
        }

        /// <summary>
        /// Definiert die Textausrichtung der Fußzeile.
        /// </summary>
        public ADTextAlignment FooterAlignmentSetting
        {
            get { return myFooterAlignmentSetting; }
            set
            {
                myFooterAlignmentSetting = value;
                GenerateObjects();
            }
        }

        /// <summary>
        /// Definiert die Textausrichtung der Kopfzeile.
        /// </summary>
        public ADTextAlignment HeaderAlignmentSetting
        {
            get { return myHeaderAlignmentSetting; }
            set
            {
                myHeaderAlignmentSetting = value;
                GenerateObjects();
            }
        }

        /// <summary>
        /// Definiert den Abstand der Fußzeile zum unteren Seitenrand.
        /// </summary>
        public float FooterDistanceFromPageBottomMargin
        {
            get { return myFooterDistanceFromPageBottomMargin; }
            set { myFooterDistanceFromPageBottomMargin = value; }
        }

        /// <summary>
        /// Definiert den Abstand der Kopfzeile zum oberen Seitenrand.
        /// </summary>
        public float HeaderDistanceFromPageTopMargin
        {
            get { return myHeaderDistanceFromPageTopMargin; }
            set { myHeaderDistanceFromPageTopMargin = value; }
        }
    }

    /// <summary>
    /// Stellt eine Aufistung an Druckseiten eines SimplePrintDocuments dar.
    /// </summary>
    public class ADSimplePrintDocumentPages : Collection<ADSimplePrintDocumentPageBase>
    {
        /// <summary>
        /// Liefert die Anzahl der Seiten in der Auflistung zurück.
        /// </summary>
        public int PageCount
        {
            get { return this.Count; }
        }
    }

    /// <summary>
    /// Stellt eine Aufistung mit den Standardseiten eines SimplePrintDocuments dar (erste Seite, linke Seite, rechte Seite).
    /// </summary>
    public class ADSimplePrintDocumentDefaultPages
    {
        private ADSimplePrintDocumentDefaultPage myFirstPage = null;
        private ADSimplePrintDocumentDefaultPage mySingleSidePage = null;
        private ADSimplePrintDocumentDefaultPage myLeftPage = null;
        private ADSimplePrintDocumentDefaultPage myRightPage = null;
        private bool myFirstPageDifferent;
        private bool myDifferentLeftAndRightPage;

        /// <summary>
        /// Erstellt eine Instanz dieser Klasse und bestimmt, ob die erste Seite abweichend definiert 
        /// und ob zwischen linker und rechter Seiteneinstellung unterschieden werden soll.
        /// </summary>
        /// <param name="firstPageDifferent">Bestimmt, ob die erste Seite des SimplePrintDocuments abweichende Einstellungen aufweisen soll (true).</param>
        /// <param name="differentLeftAndRightPage">Bestimmt, ob unterschiedliche Seiteneinstellungen für linke oder rechte Seiten gelten sollen.</param>
        public ADSimplePrintDocumentDefaultPages(bool firstPageDifferent, bool differentLeftAndRightPage)
        {
            myFirstPageDifferent = firstPageDifferent;
            myDifferentLeftAndRightPage = differentLeftAndRightPage;
            SetupPagesInternal();
        }

        private void SetupPagesInternal()
        {
            if (!myFirstPageDifferent && !myDifferentLeftAndRightPage)
            {
                mySingleSidePage = new ADSimplePrintDocumentDefaultPage();
                mySingleSidePage.LeftMargin = ADSimplePrintDocument.CmToDocument(0.75f);
                mySingleSidePage.RightMargin = ADSimplePrintDocument.CmToDocument(0.75f);
                mySingleSidePage.TopMargin = ADSimplePrintDocument.CmToDocument(1.5f);
                mySingleSidePage.BottomMargin = ADSimplePrintDocument.CmToDocument(1.5f);
                mySingleSidePage.CenterHeaderText = "- {%page%} -";
                return;
            }

            if (myFirstPageDifferent)
            {
                myFirstPage = new ADSimplePrintDocumentDefaultPage();
                myFirstPage.LeftMargin = ADSimplePrintDocument.CmToDocument(0.75f);
                myFirstPage.RightMargin = ADSimplePrintDocument.CmToDocument(0.75f);
                myFirstPage.TopMargin = ADSimplePrintDocument.CmToDocument(1.5f);
                myFirstPage.BottomMargin = ADSimplePrintDocument.CmToDocument(1.5f);
            }

            if (!myDifferentLeftAndRightPage)
            {
                mySingleSidePage = new ADSimplePrintDocumentDefaultPage();
                mySingleSidePage = new ADSimplePrintDocumentDefaultPage();
                mySingleSidePage.LeftMargin = ADSimplePrintDocument.CmToDocument(0.75f);
                mySingleSidePage.RightMargin = ADSimplePrintDocument.CmToDocument(0.75f);
                mySingleSidePage.TopMargin = ADSimplePrintDocument.CmToDocument(1.5f);
                mySingleSidePage.BottomMargin = ADSimplePrintDocument.CmToDocument(1.5f);
                mySingleSidePage.CenterHeaderText = "- {%page%} -";
            }
            else
            {
                myLeftPage = new ADSimplePrintDocumentDefaultPage();
                myRightPage = new ADSimplePrintDocumentDefaultPage();
                myLeftPage.LeftMargin = ADSimplePrintDocument.CmToDocument(0.75f);
                myLeftPage.RightMargin = ADSimplePrintDocument.CmToDocument(1f);
                myRightPage.LeftMargin = ADSimplePrintDocument.CmToDocument(1f);
                myRightPage.RightMargin = ADSimplePrintDocument.CmToDocument(0.75f);
                myLeftPage.TopMargin = ADSimplePrintDocument.CmToDocument(1.5f);
                myLeftPage.BottomMargin = ADSimplePrintDocument.CmToDocument(1.5f);
                myRightPage.TopMargin = ADSimplePrintDocument.CmToDocument(1.5f);
                myRightPage.BottomMargin = ADSimplePrintDocument.CmToDocument(1.5f);
                myLeftPage.LeftHeaderText = "{%page%}";
                myLeftPage.HeaderLineWidth = 0.2f;
                myRightPage.RightHeaderText = "{%page%}";
                myRightPage.HeaderLineWidth = 0.2f;
            }
        }

        /// <summary>
        /// Liefert eine Standardseite basierend auf der Seitennummer und den Einstellungen für die 
        /// erste Seite, linke bzw. rechte Seite dieser Instanz zurück.
        /// </summary>
        /// <param name="PageNr"></param>
        /// <returns></returns>
        public ADSimplePrintDocumentDefaultPage GetPage(int PageNr)
        {
            if (!myFirstPageDifferent)
                if (!myDifferentLeftAndRightPage)
                    return mySingleSidePage;

            if (PageNr == 1)
                if (myFirstPageDifferent)
                    return myFirstPage;

            if (PageNr > 1)
                if (!myDifferentLeftAndRightPage)
                    return mySingleSidePage;

            if (((float)PageNr / 2F) == ((float)PageNr % 2F))
                return myLeftPage;
            else
                return myRightPage;

        }

        /// <summary>
        /// Bestimmt oder ermittelt, ob die erste Seite abweichende Einstellungen haben soll.
        /// </summary>
        public bool FirstPageDifferent
        {
            get { return myFirstPageDifferent; }
            set { 
                myFirstPageDifferent = value;
                SetupPagesInternal();
                }
        }

        /// <summary>
        /// Bestimmt oder ermittelt, ob linke und rechte Seiten unterschiedliche Einstellungen haben sollen.
        /// </summary>
        public bool DifferentLeftAndRightPage
        {
            get { return myDifferentLeftAndRightPage; }
            set { 
                myDifferentLeftAndRightPage = value;
                SetupPagesInternal();
                }
        }

        /// <summary>
        /// Liefert die Seitenvorgaben für die abweichende erste Seite zurück.
        /// </summary>
        public ADSimplePrintDocumentDefaultPage FirstPage
        {
            get { return myFirstPage; }
        }

        /// <summary>
        /// Liefert die Seitenvorgaben für alle Seiten zurück, wenn keine abweichenden Sondereinstellungen gelten.
        /// </summary>
        public ADSimplePrintDocumentDefaultPage SingleSidePage
        {
            get { return mySingleSidePage; }
        }

        /// <summary>
        /// Liefert die Seitenvorgaben für linke Seiten zurück.
        /// </summary>
        public ADSimplePrintDocumentDefaultPage LeftPage
        {
            get { return myLeftPage; }
        }

        /// <summary>
        /// Liefert die Seitenvorgaben für rechte Seiten zurück.
        /// </summary>
        public ADSimplePrintDocumentDefaultPage RightPage
        {
            get { return myRightPage; }
        }
    }
}

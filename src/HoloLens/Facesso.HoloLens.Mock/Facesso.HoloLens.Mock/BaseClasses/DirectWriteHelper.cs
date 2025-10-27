using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.Mathematics.Interop;

namespace Facesso.HoloLens.BaseClasses
{
    class DirectWriteHelper
    {
        private string myFontName;
        private FontFamily myFont;
        private GlyphRun myGlyphRun;
        private float myFontSize;
        private SharpDX.DirectWrite.Factory myDirectWriteFactory;
        private SolidColorBrush myBrush;
        private TextFormat myTextFormat;

        public DirectWriteHelper(string fontName, float fontSize)
        {
            myFontName = fontName;
            myFontSize = fontSize;
            InitializeFontSystem();
        }

        private void InitializeFontSystem()
        {
            myDirectWriteFactory = new SharpDX.DirectWrite.Factory();

            var fontCollection = myDirectWriteFactory.GetSystemFontCollection(true);

            int fontIndex = 0;
            var fontsOnHololense = new List<string>();

            for (int fontCount = 0; fontCount < fontCollection.FontFamilyCount; fontCount++)
            {

            }

            if (fontCollection.FindFamilyName(myFontName,out fontIndex))
            {
                myFont = fontCollection.GetFontFamily(fontIndex);
            }
            else
            {
                throw new ArgumentException("The font " + myFontName + "could not be found on this system.");
            }

            var textFontFace = new FontFace(myFont.GetFirstMatchingFont(FontWeight.Normal,
                                                                        FontStretch.Normal,
                                                                        FontStyle.Normal));

            myGlyphRun = new GlyphRun()
            {
                FontFace = textFontFace,
                FontSize = myFontSize
            };
        }

        public void RenderText(RenderTarget target,
                               float x, float y, 
                               Brush foreground, 
                               string textToRender)
        {

            //var glyphIndices = myGlyphRun.FontFace.GetGlyphIndices(
            //    textToRender.ToCharArray().Select((item) => Convert.ToInt32(item)).ToArray());
            //myGlyphRun.Indices = glyphIndices;

            if (myBrush == null)
            {
                myBrush = new SolidColorBrush(target, new RawColor4(1, 1, 1, 1));
            }

            if (myTextFormat == null)
            {
                myTextFormat = new TextFormat(myDirectWriteFactory, myFontName, myFontSize);
            }

            target.DrawText(textToRender, myTextFormat, new RawRectangleF(0, 0, 1279, 0), myBrush);
        }
    }
}

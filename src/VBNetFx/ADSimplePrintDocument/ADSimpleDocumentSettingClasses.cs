#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

#endregion

namespace ActiveDev.Printing
{
	public class ADSimpleDocumentFontSetting
	{
		private string myFontname;
		private float myFontSize;
		private FontStyle myFontStyle;
		private Color myFontColor;

		public ADSimpleDocumentFontSetting()
		{
			Font locFont = new Font(FontFamily.GenericSerif, 10);
			myFontname = locFont.Name;
			myFontSize = locFont.Size;
			myFontStyle = locFont.Style;
			myFontColor = Color.Black;
			locFont.Dispose();
		}

		public ADSimpleDocumentFontSetting(FontFamily fontFamily)
		{
			Font locFont = new Font(fontFamily, 10);
			myFontname = locFont.Name;
			myFontSize = locFont.Size;
			myFontStyle = locFont.Style;
			myFontColor = Color.Black;
			locFont.Dispose();
		}

		public ADSimpleDocumentFontSetting(Font font)
		{
			Font locFont = font;
			myFontname = locFont.Name;
			myFontSize = locFont.Size;
			myFontStyle = locFont.Style;
			myFontColor = Color.Black;
		}

		public Font Font
		{
			get { return new Font(FontName, FontSize, this.FontStyle); }
		}

		public Brush Brush
		{
			get { return new SolidBrush(FontColor); }
		}

		public string FontName
		{
			get { return myFontname; }
			set { myFontname = value; }
		}

		public float FontSize
		{
			get { return myFontSize; }
			set { myFontSize = value; }
		}

		public FontStyle FontStyle
		{
			get { return myFontStyle; }
			set { myFontStyle = value; }
		}

		public Color FontColor
		{
			get { return myFontColor; }
			set { myFontColor = value; }
		}

	}

	public enum ADTextAlignment
	{
		Left,
		Center,
		Right,
		Justified,
		Spaced
	}
}

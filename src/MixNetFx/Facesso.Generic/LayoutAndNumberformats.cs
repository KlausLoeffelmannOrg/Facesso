using System.Drawing;

namespace Facesso
{
    public class LayoutAndNumberformats
    {
        private SerializableFontSetting _U1Font;
        private SerializableFontSetting _U2Font;
        private SerializableFontSetting _U3Font;
        private SerializableFontSetting _TableHeaderFont;
        private SerializableFontSetting _TextAndTableBodyFont;
        private SerializableFontSetting _SmallTableFont;
        private SerializableFontSetting _HeaderFont;
        private SerializableFontSetting _FooterFont;
        private FacessoLayoutGridstyle _Gridstyle;
        private byte _HMinPrecision;

        public LayoutAndNumberformats()
        {
            _U1Font = new SerializableFontSetting("Arial", 22, FontStyle.Bold);
            _U2Font = new SerializableFontSetting("Arial", 16, FontStyle.Bold);
            _U3Font = new SerializableFontSetting("Arial", 13, FontStyle.Bold);
            _TableHeaderFont = new SerializableFontSetting("Arial", 10, FontStyle.Bold);
            _HeaderFont = new SerializableFontSetting("Arial", 10, FontStyle.Bold);
            _FooterFont = new SerializableFontSetting("Arial", 8, FontStyle.Regular);
            _TextAndTableBodyFont = new SerializableFontSetting("Arial", 9, FontStyle.Regular);
            _SmallTableFont = new SerializableFontSetting("Arial", 8, FontStyle.Regular);
            _Gridstyle = FacessoLayoutGridstyle.ThreeDGrid1;
            _HMinPrecision = 2;
        }

        public SerializableFontSetting U1Font { get { return _U1Font; } set { _U1Font = value; } }
        public SerializableFontSetting U2Font { get { return _U2Font; } set { _U2Font = value; } }
        public SerializableFontSetting U3Font { get { return _U3Font; } set { _U3Font = value; } }
        public SerializableFontSetting TableHeaderFont { get { return _TableHeaderFont; } set { _TableHeaderFont = value; } }
        public SerializableFontSetting TextAndTableBodyFont { get { return _TextAndTableBodyFont; } set { _TextAndTableBodyFont = value; } }
        public SerializableFontSetting HeaderFont { get { return _HeaderFont; } set { _HeaderFont = value; } }
        public SerializableFontSetting FooterFont { get { return _FooterFont; } set { _FooterFont = value; } }
        public SerializableFontSetting SmallTableFont { get { return _SmallTableFont; } set { _SmallTableFont = value; } }
        public FacessoLayoutGridstyle Gridstyle { get { return _Gridstyle; } set { _Gridstyle = value; } }
        public byte HMinPrecision { get { return _HMinPrecision; } set { _HMinPrecision = value; } }

        public string HminFormated(double hmin)
        {
            string locFormat = "#,##0";
            if (HMinPrecision > 0)
                locFormat += "," + new string('0', HMinPrecision);
            return hmin.ToString(locFormat);
        }
    }

    public enum FacessoLayoutGridstyle
    {
        NoGrid,
        SimpleGridThin,
        SimpleGridThick,
        ThreeDGrid1,
        ThreeDGrid2
    }

    public class SerializableFontSetting
    {
        private string _FontName;
        private float _FontSize;
        private FontStyle _FontStyle;

        public SerializableFontSetting()
        {
            FontName = "Arial";
            FontSize = 10;
            FontStyle = FontStyle.Regular;
        }

        public SerializableFontSetting(Font font)
        {
            _FontName = font.Name;
            _FontSize = font.Size;
            _FontStyle = font.Style;
        }

        public SerializableFontSetting(string fontName, float fontSize, FontStyle fontStyle)
        {
            _FontName = fontName;
            _FontSize = fontSize;
            _FontStyle = fontStyle;
        }

        public string FontName { get { return _FontName; } set { _FontName = value; } }
        public float FontSize { get { return _FontSize; } set { _FontSize = value; } }
        public FontStyle FontStyle { get { return _FontStyle; } set { _FontStyle = value; } }

        public string FontSettingsDescription
        {
            get { return FontName + "; " + FontSize + " pt;" + FontStyle.ToString(); }
        }

        public Font ToFont()
        {
            return new Font(FontName, FontSize, FontStyle);
        }
    }
}

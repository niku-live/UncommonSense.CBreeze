using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class TextPropertiesBase : FormControlProperties, IText
    {
        private readonly ColorProperty _backColor = new ColorProperty("BackColor");
        private readonly NullableBooleanProperty _backTransparent = new NullableBooleanProperty("BackTransparent");
        private readonly NullableBooleanProperty _border = new NullableBooleanProperty("Border");
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly StringProperty _captionClass = new StringProperty("CaptionClass");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");
        private readonly StringProperty _dataSetFieldName = new StringProperty("DataSetFieldName");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _fontBold = new NullableBooleanProperty("FontBold");
        private readonly NullableBooleanProperty _fontItalic = new NullableBooleanProperty("FontItalic");
        private readonly StringProperty _fontName = new StringProperty("FontName");
        private readonly NullableIntegerProperty _fontSize = new NullableIntegerProperty("FontSize");
        private readonly NullableBooleanProperty _fontStrikethru = new NullableBooleanProperty("FontStrikethru");
        private readonly NullableBooleanProperty _fontUnderline = new NullableBooleanProperty("FontUnderline");
        private readonly ColorProperty _foreColor = new ColorProperty("ForeColor");
        private readonly HorzAlignProperty _horzAlign = new HorzAlignProperty("HorzAlign");
        private readonly NullableBooleanProperty _inColumn = new NullableBooleanProperty("InColumn");
        private readonly NullableBooleanProperty _inMatrix = new NullableBooleanProperty("InMatrix");
        private readonly NullableBooleanProperty _inMatrixHeading = new NullableBooleanProperty("InMatrixHeading");
        private readonly NullableBooleanProperty _leaderDots = new NullableBooleanProperty("LeaderDots");
        private readonly NullableBooleanProperty _multiLine = new NullableBooleanProperty("MultiLine");
        private readonly StringProperty _padChar = new StringProperty("PadChar");
        private readonly VertAlignProperty _vertAlign = new VertAlignProperty("VertAlign");

        protected TextPropertiesBase(FormControl control) : base(control)
        {
        }

        public bool? Border
        {
            get => _border.Value;
            set => _border.Value = value;
        }

        public Color BorderColor
        {
            get => _borderColor.Value;
            set => _borderColor.Value = value;
        }

        public BorderWidth BorderWidth
        {
            get => _borderWidth.Value;
            set => _borderWidth.Value = value;
        }

        public BorderStyle BorderStyle
        {
            get => _borderStyle.Value;
            set => _borderStyle.Value = value;
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;

        public string CaptionClass
        {
            get => _captionClass.Value;
            set => _captionClass.Value = value;
        }

        public Color ForeColor
        {
            get => _foreColor.Value;
            set => _foreColor.Value = value;
        }

        public string FontName
        {
            get => _fontName.Value;
            set => _fontName.Value = value;
        }

        public int? FontSize
        {
            get => _fontSize.Value;
            set => _fontSize.Value = value;
        }

        public bool? FontBold
        {
            get => _fontBold.Value;
            set => _fontBold.Value = value;
        }

        public bool? FontItalic
        {
            get => _fontItalic.Value;
            set => _fontItalic.Value = value;
        }

        public bool? FontStrikethru
        {
            get => _fontStrikethru.Value;
            set => _fontStrikethru.Value = value;
        }

        public bool? FontUnderline
        {
            get => _fontUnderline.Value;
            set => _fontUnderline.Value = value;
        }

        public HorzAlign HorzAlign
        {
            get => _horzAlign.Value;
            set => _horzAlign.Value = value;
        }

        public VertAlign VertAlign
        {
            get => _vertAlign.Value;
            set => _vertAlign.Value = value;
        }

        public string DataSetFieldName
        {
            get => _dataSetFieldName.Value;
            set => _dataSetFieldName.Value = value;
        }

        public bool? InColumn
        {
            get => _inColumn.Value;
            set => _inColumn.Value = value;
        }

        public bool? InMatrix
        {
            get => _inMatrix.Value;
            set => _inMatrix.Value = value;
        }

        public bool? InMatrixHeading
        {
            get => _inMatrixHeading.Value;
            set => _inMatrixHeading.Value = value;
        }

        public bool? MultiLine
        {
            get => _multiLine.Value;
            set => _multiLine.Value = value;
        }

        public string PadChar
        {
            get => _padChar.Value;
            set => _padChar.Value = value;
        }

        public bool? LeaderDots
        {
            get => _leaderDots.Value;
            set => _leaderDots.Value = value;
        }

        public string Description
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        public bool? BackTransparent
        {
            get => _backTransparent.Value;
            set => _backTransparent.Value = value;
        }

        public Color BackColor
        {
            get => _backColor.Value;
            set => _backColor.Value = value;
        }
    }
}
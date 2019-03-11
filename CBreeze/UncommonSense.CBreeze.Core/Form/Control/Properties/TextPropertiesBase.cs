using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class TextPropertiesBase : BaseControlBaseProperties, IText
    {
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly StringProperty _captionClass = new StringProperty("CaptionClass");
        private readonly StringProperty _dataSetFieldName = new StringProperty("DataSetFieldName");
        private readonly NullableBooleanProperty _fontBold = new NullableBooleanProperty("FontBold");
        private readonly NullableBooleanProperty _fontItalic = new NullableBooleanProperty("FontItalic");
        private readonly StringProperty _fontName = new StringProperty("FontName");
        private readonly NullableIntegerProperty _fontSize = new NullableIntegerProperty("FontSize");
        private readonly NullableBooleanProperty _fontStrikethru = new NullableBooleanProperty("FontStrikethru");
        private readonly NullableBooleanProperty _fontUnderline = new NullableBooleanProperty("FontUnderline");
        private readonly ColorProperty _foreColor = new ColorProperty("ForeColor");
        private readonly NullableBooleanProperty _inColumn = new NullableBooleanProperty("InColumn");
        private readonly NullableBooleanProperty _inMatrix = new NullableBooleanProperty("InMatrix");
        private readonly NullableBooleanProperty _inMatrixHeading = new NullableBooleanProperty("InMatrixHeading");
        private readonly NullableBooleanProperty _leaderDots = new NullableBooleanProperty("LeaderDots");
        private readonly NullableBooleanProperty _multiLine = new NullableBooleanProperty("MultiLine");
        private readonly StringProperty _padChar = new StringProperty("PadChar");

        protected TextPropertiesBase(FormControl control) : base(control)
        {
            innerList.Add(_borderColor);
            innerList.Add(_borderStyle);
            innerList.Add(_borderWidth);
            innerList.Add(_captionClass);
            innerList.Add(_dataSetFieldName);
            innerList.Add(_fontBold);
            innerList.Add(_fontItalic);
            innerList.Add(_fontName);
            innerList.Add(_fontSize);
            innerList.Add(_fontStrikethru);
            innerList.Add(_fontUnderline);
            innerList.Add(_foreColor);
            innerList.Add(_inColumn);
            innerList.Add(_inMatrix);
            innerList.Add(_inMatrixHeading);
            innerList.Add(_leaderDots);
            innerList.Add(_multiLine);
            innerList.Add(_padChar);
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

    }
}
using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseButtonProperties : BaseControlBaseProperties2, IButton
    {
        private readonly NullableIntegerProperty _bitmap = new NullableIntegerProperty("Bitmap");
        private readonly BitmapPosProperty _bitmapPos = new BitmapPosProperty("BitmapPos");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");
        private readonly NullableBooleanProperty _focusOnClick = new NullableBooleanProperty("FocusOnClick");
        private readonly NullableBooleanProperty _fontBold = new NullableBooleanProperty("FontBold");
        private readonly NullableBooleanProperty _fontItalic = new NullableBooleanProperty("FontItalic");
        private readonly StringProperty _fontName = new StringProperty("FontName");
        private readonly NullableIntegerProperty _fontSize = new NullableIntegerProperty("FontSize");
        private readonly NullableBooleanProperty _fontStrikethru = new NullableBooleanProperty("FontStrikethru");
        private readonly NullableBooleanProperty _fontUnderline = new NullableBooleanProperty("FontUnderline");
        private readonly ColorProperty _foreColor = new ColorProperty("ForeColor");
        private readonly NullableBooleanProperty _showCaption = new NullableBooleanProperty("ShowCaption");

        protected BaseButtonProperties(FormControl control) : base(control)
        {
        }

        public Color ForeColor
        {
            get => _foreColor.Value;
            set => _foreColor.Value = value;
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;
        public string CaptionClass { get; set; }

        public bool? ShowCaption
        {
            get => _showCaption.Value;
            set => _showCaption.Value = value;
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

        public bool? FocusOnClick
        {
            get => _focusOnClick.Value;
            set => _focusOnClick.Value = value;
        }

        public BitmapPos BitmapPos
        {
            get => _bitmapPos.Value;
            set => _bitmapPos.Value = value;
        }

        public int? Bitmap
        {
            get => _bitmap.Value;
            set => _bitmap.Value = value;
        }
    }
}
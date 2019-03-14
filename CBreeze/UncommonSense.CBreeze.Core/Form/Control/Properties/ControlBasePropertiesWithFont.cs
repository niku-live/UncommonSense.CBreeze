using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class ControlBasePropertiesWithFont : FormControlProperties, IFormControlProperties
    {
        private readonly NullableBooleanProperty _fontBold = new NullableBooleanProperty("FontBold");
        private readonly NullableBooleanProperty _fontItalic = new NullableBooleanProperty("FontItalic");
        private readonly StringProperty _fontName = new StringProperty("FontName");
        private readonly NullableIntegerProperty _fontSize = new NullableIntegerProperty("FontSize");
        private readonly NullableBooleanProperty _fontStrikethru = new NullableBooleanProperty("FontStrikethru");
        private readonly NullableBooleanProperty _fontUnderline = new NullableBooleanProperty("FontUnderline");
        private readonly ColorProperty _backColor = new ColorProperty("BackColor");
        private readonly NullableBooleanProperty _backTransparent = new NullableBooleanProperty("BackTransparent");
        private readonly NullableBooleanProperty _border = new NullableBooleanProperty("Border");
        private readonly ColorProperty _foreColor = new ColorProperty("ForeColor");
        private readonly NullableBooleanProperty _leaderDots = new NullableBooleanProperty("LeaderDots");
        private readonly NullableBooleanProperty _showCaption = new NullableBooleanProperty("ShowCaption");
        private readonly StringProperty _bitmap = new StringProperty("Bitmap");
        private readonly MultiLanguageProperty _toolTipMl = new MultiLanguageProperty("ToolTipML");
        private readonly NullableBooleanProperty _cancel = new NullableBooleanProperty("Cancel");
        private readonly NullableBooleanProperty _default = new NullableBooleanProperty("Default");
        private readonly PushActionProperty _pushAction = new PushActionProperty("PushAction");

        protected ControlBasePropertiesWithFont(FormControl control) : base(control)
        {
            innerList.Add(_showCaption);
            innerList.Add(_foreColor);
            innerList.Add(_backColor);
            innerList.Add(_backTransparent);
            innerList.Add(_cancel);
            innerList.Add(_default);
            innerList.Add(_pushAction);
            innerList.Add(_bitmap);
            innerList.Add(_toolTipMl);
            innerList.Add(_border);
            innerList.Add(_fontBold);
            innerList.Add(_fontItalic);
            innerList.Add(_fontName);
            innerList.Add(_fontSize);
            innerList.Add(_fontStrikethru);
            innerList.Add(_fontUnderline);
            innerList.Add(_leaderDots);
        }

        public bool? ShowCaption
        {
            get => _showCaption.Value;
            set => _showCaption.Value = value;
        }

        public MultiLanguageValue ToolTipML => _toolTipMl.Value;

        public bool? Border
        {
            get => _border.Value;
            set => _border.Value = value;
        }

        public bool? BackTransparent
        {
            get => _backTransparent.Value;
            set => _backTransparent.Value = value;
        }

        public Color? BackColor
        {
            get => _backColor.Value;
            set => _backColor.Value = value;
        }

        public Color? ForeColor
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

        public bool? LeaderDots
        {
            get => _leaderDots.Value;
            set => _leaderDots.Value = value;
        }

        public bool? Default
        {
            get => _default.Value;
            set => _default.Value = value;
        }

        public bool? Cancel
        {
            get => _cancel.Value;
            set => _cancel.Value = value;
        }

        public PushAction? PushAction
        {
            get => _pushAction.Value;
            set => _pushAction.Value = value;
        }

        public string Bitmap
        {
            get => _bitmap.Value;
            set => _bitmap.Value = value;
        }
    }
}
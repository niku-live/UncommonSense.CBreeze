using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FrameProperties : BaseControlBaseProperties2, IFrame
    {
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly NullableBooleanProperty _editable = new NullableBooleanProperty("Editable");
        private readonly NullableBooleanProperty _topLineOnly = new NullableBooleanProperty("TopLineOnly");

        public FrameProperties(FormControl control) : base(control)
        {
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

        public bool? Editable
        {
            get => _editable.Value;
            set => _editable.Value = value;
        }

        public bool? TopLineOnly
        {
            get => _topLineOnly.Value;
            set => _topLineOnly.Value = value;
        }
    }
}
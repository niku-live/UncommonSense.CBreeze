using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TableBoxProperties : FormControlProperties, ITableBox
    {
        private readonly ColorProperty _backColor = new ColorProperty("BackColor");
        private readonly NullableBooleanProperty _border = new NullableBooleanProperty("Border");
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _enabled = new NullableBooleanProperty("Enabled");
        private readonly NullableBooleanProperty _focusable = new NullableBooleanProperty("Focusable");
        private readonly NullableIntegerProperty _headingHeight = new NullableIntegerProperty("HeadingHeight");
        private readonly NullableBooleanProperty _inlineEditing = new NullableBooleanProperty("InlineEditing");
        private readonly NullableIntegerProperty _rowHeight = new NullableIntegerProperty("RowHeight");

        public TableBoxProperties(FormControl formTableBoxControl) : base(formTableBoxControl)
        {
        }

        public Color BackColor
        {
            get => _backColor.Value;
            set => _backColor.Value = value;
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

        public string Description
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        public bool? Enabled
        {
            get => _enabled.Value;
            set => _enabled.Value = value;
        }

        public bool? Focusable
        {
            get => _focusable.Value;
            set => _focusable.Value = value;
        }

        public int? RowHeight
        {
            get => _rowHeight.Value;
            set => _rowHeight.Value = value;
        }

        public bool? InlineEditing
        {
            get => _inlineEditing.Value;
            set => _inlineEditing.Value = value;
        }

        public int? HeadingHeight
        {
            get => _headingHeight.Value;
            set => _headingHeight.Value = value;
        }
    }
}
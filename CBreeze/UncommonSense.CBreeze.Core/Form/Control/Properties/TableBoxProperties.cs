using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TableBoxProperties : BaseControlBaseProperties2, ITableBox
    {
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");
        private readonly NullableIntegerProperty _headingHeight = new NullableIntegerProperty("HeadingHeight");
        private readonly NullableBooleanProperty _inlineEditing = new NullableBooleanProperty("InlineEditing");
        private readonly NullableIntegerProperty _rowHeight = new NullableIntegerProperty("RowHeight");
        private readonly NullableBooleanProperty _editable = new NullableBooleanProperty("Editable");

        public TableBoxProperties(FormControl formTableBoxControl) : base(formTableBoxControl)
        {
            innerList.Add(_borderColor);
            innerList.Add(_borderWidth);
            innerList.Add(_borderStyle);
            innerList.Add(_headingHeight);
            innerList.Add(_inlineEditing);
            innerList.Add(_rowHeight);
            innerList.Add(_editable);
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

        public bool? Editable
        {
            get => _editable.Value;
            set => _editable.Value = value;
        }
    }
}
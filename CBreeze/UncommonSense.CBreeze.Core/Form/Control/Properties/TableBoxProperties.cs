using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TableBoxProperties : BaseControlBaseProperties2, ITableBox
    {
        private readonly NullableIntegerProperty _headingHeight = new NullableIntegerProperty("HeadingHeight");
        private readonly NullableBooleanProperty _inlineEditing = new NullableBooleanProperty("InlineEditing");
        private readonly NullableIntegerProperty _rowHeight = new NullableIntegerProperty("RowHeight");

        public TableBoxProperties(FormControl formTableBoxControl) : base(formTableBoxControl)
        {
            innerList.Add(_headingHeight);
            innerList.Add(_inlineEditing);
            innerList.Add(_rowHeight);
        }

        public Color? BorderColor
        {
            get => InternalBorderColor;
            set => InternalBorderColor = value;
        }

        public BorderWidth? BorderWidth
        {
            get => InternalBorderWidth;
            set => InternalBorderWidth = value;
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
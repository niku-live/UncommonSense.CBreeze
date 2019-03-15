using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TableBoxProperties : BaseControlBaseProperties2, ITableBox
    {
        public TableBoxProperties(FormControl formTableBoxControl) : base(formTableBoxControl)
        {
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
            get => InternalRowHeight;
            set => InternalRowHeight = value;
        }

        public bool? InlineEditing
        {
            get => InternalInlineEditing;
            set => InternalInlineEditing = value;
        }

        public int? HeadingHeight
        {
            get => InternalHeadingHeight;
            set => InternalHeadingHeight = value;
        }

    }
}
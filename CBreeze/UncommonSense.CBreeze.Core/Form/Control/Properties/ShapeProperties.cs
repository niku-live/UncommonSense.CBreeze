using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class ShapeProperties : BaseControlBaseProperties, IShape
    {        
        public ShapeProperties(FormControl control) : base(control)
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

        public bool? InColumnHeading
        {
            get => InternalInColumnHeading;
            set => InternalInColumnHeading = value;
        }

        public ShapeStyle? ShapeStyle
        {
            get => InternalShapeStyle;
            set => InternalShapeStyle = value;
        }
    }
}
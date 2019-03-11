using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class ShapeProperties : BaseControlBaseProperties, IShape
    {
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly NullableBooleanProperty _inColumnHeading = new NullableBooleanProperty("InColumnHeading");
        private readonly ShapeStyleProperty _shapeStyle = new ShapeStyleProperty("ShapeStyle");

        public ShapeProperties(FormControl control) : base(control)
        {
            innerList.Add(_borderColor);
            innerList.Add(_borderWidth);
            innerList.Add(_inColumnHeading);
            innerList.Add(_shapeStyle);
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

        public bool? InColumnHeading
        {
            get => _inColumnHeading.Value;
            set => _inColumnHeading.Value = value;
        }

        public ShapeStyle ShapeStyle
        {
            get => _shapeStyle.Value;
            set => _shapeStyle.Value = value;
        }
    }
}
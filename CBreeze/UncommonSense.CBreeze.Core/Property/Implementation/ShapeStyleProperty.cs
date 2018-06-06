using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class ShapeStyleProperty : ValueProperty<ShapeStyle>
    {
        public ShapeStyleProperty(string name) : base(name)
        {
        }

        public override bool HasValue { get; }
        public override void Reset()
        {
            Value = ShapeStyle.Rectangle;
        }
    }
}
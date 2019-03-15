using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class ShapeStyleProperty : NullableValueProperty<ShapeStyle>
    {
        public ShapeStyleProperty(string name) : base(name)
        {
        }

        public string GetValueName()
        {
            if (!HasValue)
            {
                return null;
            }
            switch (Value)
            {
                case ShapeStyle.NELine:
                    return "NE-Line";
                case ShapeStyle.NWLine:
                    return "NW-Line";
                default:
                    return Value.ToString();
            }
        }
        public override void Reset()
        {
            Value = ShapeStyle.Rectangle;
        }
    }
}
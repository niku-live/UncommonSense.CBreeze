using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class BorderWidthProperty : NullableValueProperty<BorderWidth>
    {
        public BorderWidthProperty(string name) : base(name)
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
                case BorderWidth.Hairline:
                    return Value.ToString();
                default:
                    return Value.ToString().Substring(4);
            }
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
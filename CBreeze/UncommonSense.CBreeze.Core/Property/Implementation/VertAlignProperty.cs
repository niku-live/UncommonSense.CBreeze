using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class VertAlignProperty : NullableValueProperty<VertAlign>
    {
        public VertAlignProperty(string name) : base(name)
        {
        }

        public override bool HasValue => Value != VertAlign.Top;
        public override void Reset()
        {
            Value = VertAlign.Top;
        }
    }
}
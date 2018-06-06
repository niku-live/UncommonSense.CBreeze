using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class BorderWidthProperty : ValueProperty<BorderWidth>
    {
        public BorderWidthProperty(string name) : base(name)
        {
        }

        public override bool HasValue { get; }
        public override void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
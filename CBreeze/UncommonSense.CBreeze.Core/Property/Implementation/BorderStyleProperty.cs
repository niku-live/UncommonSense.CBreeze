using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class BorderStyleProperty : NullableValueProperty<BorderStyle>
    {
        public BorderStyleProperty(string name) : base(name)
        {
        }
        
        public override void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
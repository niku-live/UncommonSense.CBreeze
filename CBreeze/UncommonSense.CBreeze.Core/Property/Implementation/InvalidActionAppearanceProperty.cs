using System;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class InvalidActionAppearanceProperty : NullableValueProperty<InvalidActionAppearance>
    {
        public InvalidActionAppearanceProperty(string name) : base(name)
        {
        }

        //public override bool HasValue { get; }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
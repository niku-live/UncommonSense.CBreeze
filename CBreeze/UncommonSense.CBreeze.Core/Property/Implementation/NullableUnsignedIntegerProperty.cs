using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class NullableUnsignedIntegerProperty : NullableValueProperty<uint>
    {
        public NullableUnsignedIntegerProperty(string name) : base(name)
        {
        }
    }

}

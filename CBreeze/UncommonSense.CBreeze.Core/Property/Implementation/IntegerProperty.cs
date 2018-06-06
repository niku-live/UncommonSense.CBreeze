using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class IntegerProperty : ValueProperty<int>
    {
        public IntegerProperty(string name) : base(name)
        {
        }

        public override bool HasValue => true;
        public override void Reset()
        {
            Value = 0;
        }
    }
}

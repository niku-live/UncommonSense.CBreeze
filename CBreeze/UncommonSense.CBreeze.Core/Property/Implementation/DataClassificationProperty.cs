using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class DataClassificationProperty : NullableValueProperty<DataClassification>
    {
        internal DataClassificationProperty(string name) : base(name)
        {
        }
    }
}
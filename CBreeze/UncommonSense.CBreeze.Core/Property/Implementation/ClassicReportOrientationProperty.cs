using System;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2009
    public class ClassicReportOrientationProperty : NullableValueProperty<ClassicReportOrientation>
    {
        public ClassicReportOrientationProperty(string name) : base(name)
        {
        }
        
        public override void Reset()
        {
        }
    }
#endif
}
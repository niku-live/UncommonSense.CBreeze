using System;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2009
    public class ClassicReportOrientationProperty : ValueProperty<ClassicReportOrientation>
    {
        public ClassicReportOrientationProperty(string name) : base(name)
        {
        }

        public override bool HasValue { get; }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
#endif
}
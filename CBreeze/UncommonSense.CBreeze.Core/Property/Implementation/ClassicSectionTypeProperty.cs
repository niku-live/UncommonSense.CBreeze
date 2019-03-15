#if NAV2009
using UncommonSense.CBreeze.Core.Report.Classic.Section;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class ClassicSectionTypeProperty : NullableValueProperty<SectionType>
    {
        private SectionBase _section;

        public ClassicSectionTypeProperty(string name, SectionBase section) : base(name)
        {
            _section = section;
        }

        public override bool HasValue => _section != null;

        public override object GetValue()
        {
            return _section?.Type;
        }
    }
}
#endif
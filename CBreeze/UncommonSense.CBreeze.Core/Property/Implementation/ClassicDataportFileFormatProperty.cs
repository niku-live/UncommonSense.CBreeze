#if NAV2009
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class ClassicDataportFileFormatProperty: NullableValueProperty<ClassicDataportFileFormat>
    {
        public ClassicDataportFileFormatProperty(string name) : base(name)
        {
        }

        public override void Reset()
        {
        }
    }
}
#endif
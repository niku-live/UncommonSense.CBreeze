using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAVBC
    public class UsageCategoryProperty : NullableValueProperty<UsageCategory>
    {
        internal UsageCategoryProperty(string name) : base(name) { }
    }
#endif
}

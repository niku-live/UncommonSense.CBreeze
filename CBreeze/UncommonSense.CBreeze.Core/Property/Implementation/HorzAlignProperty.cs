using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class HorzAlignProperty : ValueProperty<HorzAlign>
    {
        public HorzAlignProperty(string name) : base(name)
        {
        }

        public override bool HasValue => Value != HorzAlign.General;
        public override void Reset()
        {
            Value = HorzAlign.General;
        }
    }
}
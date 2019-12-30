namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class OptionStringProperty : ReferenceProperty<OptionValueList>
    {
        internal OptionStringProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value != null;
            }
        }
    }
}

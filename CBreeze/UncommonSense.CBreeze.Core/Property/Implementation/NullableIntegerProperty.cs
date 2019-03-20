namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class NullableIntegerProperty : NullableValueProperty<int>
    {
        internal NullableIntegerProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue => base.HasValue || InvalidValueIsSet;

        public string GetValueForPrinting()
        {
            if (InvalidValueIsSet)
            {
                return InvalidValue;
            }
            return Value.GetValueOrDefault().ToString();
        }
    }
}

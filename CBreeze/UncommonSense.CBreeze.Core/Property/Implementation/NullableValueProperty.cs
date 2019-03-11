namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public abstract class NullableValueProperty<T> : ValueProperty<T?> where T : struct
    {
        internal NullableValueProperty(string name) : base(name)
        {
        }

        public override bool HasValue => Value.HasValue;

        public override void Reset() => Value = null;
    }
}
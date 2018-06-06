using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseControlBaseProperties2 : BaseControlBaseProperties, IBaseControl2
    {
        private readonly NullableBooleanProperty _enabled = new NullableBooleanProperty("Enabled");
        private readonly NullableBooleanProperty _focusable = new NullableBooleanProperty("Focusable");

        protected BaseControlBaseProperties2(FormControl control) : base(control)
        {
        }

        public bool? Enabled
        {
            get => _enabled.Value;
            set => _enabled.Value = value;
        }

        public bool? Focusable
        {
            get => _focusable.Value;
            set => _focusable.Value = value;
        }
    }
}
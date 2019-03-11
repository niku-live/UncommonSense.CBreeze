using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseControlBaseProperties2 : BaseControlBaseProperties, IBaseControl2
    {
        private readonly NullableBooleanProperty _enabled = new NullableBooleanProperty("Enabled");
        private readonly NullableIntegerProperty _nextControl = new NullableIntegerProperty("NextControl");
        private readonly TriggerProperty _onActivate = new TriggerProperty("OnActivate");
        private readonly TriggerProperty _onAfterValidate = new TriggerProperty("OnAfterValidate");
        private readonly TriggerProperty _onDeactivate = new TriggerProperty("OnDeactivate");
        private readonly TriggerProperty _onPush = new TriggerProperty("OnPush");
        private readonly TriggerProperty _onValidate = new TriggerProperty("OnValidate");

        protected BaseControlBaseProperties2(FormControl control) : base(control)
        {
            innerList.Add(_enabled);
            innerList.Add(_nextControl);
            innerList.Add(_onActivate);
            innerList.Add(_onDeactivate);
            innerList.Add(_onPush);
            innerList.Add(_onAfterValidate);
            innerList.Add(_onValidate);
        }

        public bool? Enabled
        {
            get => _enabled.Value;
            set => _enabled.Value = value;
        }

        public int? NextControl
        {
            get => _nextControl.Value;
            set => _nextControl.Value = value;
        }

        public Trigger OnActivate => _onActivate.Value;
        public Trigger OnDeactivate => _onDeactivate.Value;
        public Trigger OnPush => _onPush.Value;
        public Trigger OnValidate => _onValidate.Value;
        public Trigger OnAfterValidate => _onAfterValidate.Value;
    }
}
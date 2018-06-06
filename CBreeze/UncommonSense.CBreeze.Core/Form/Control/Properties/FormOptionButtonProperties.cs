using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormOptionButtonProperties : OptionButtonProperties, IActivate, IPushAble, IValidate
    {
        private readonly TriggerProperty _onActivate = new TriggerProperty("OnActivate");
        private readonly TriggerProperty _onAfterValidate = new TriggerProperty("OnAfterValidate");
        private readonly TriggerProperty _onDeactivate = new TriggerProperty("OnDeactivate");
        private readonly TriggerProperty _onPush = new TriggerProperty("OnPush");
        private readonly TriggerProperty _onValidate = new TriggerProperty("OnValidate");

        public FormOptionButtonProperties(FormControl control) : base(control)
        {
        }

        public Trigger OnActivate => _onActivate.Value;
        public Trigger OnDeactivate => _onDeactivate.Value;
        public Trigger OnPush => _onPush.Value;
        public Trigger OnValidate => _onValidate.Value;
        public Trigger OnAfterValidate => _onAfterValidate.Value;
    }
}
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormCommandButtonProperties : CommandButtonProperties, IActivate, IPushAble
    {
        private readonly TriggerProperty _onActivate = new TriggerProperty("OnActivate");
        private readonly TriggerProperty _onDeactivate = new TriggerProperty("OnDeactivate");
        private readonly TriggerProperty _onPush = new TriggerProperty("OnPush");

        public FormCommandButtonProperties(FormControl control) : base(control)
        {
        }

        public Trigger OnActivate => _onActivate.Value;
        public Trigger OnDeactivate => _onDeactivate.Value;
        public Trigger OnPush => _onPush.Value;
    }
}
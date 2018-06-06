using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormImageProperties : ImageProperties, IPushAble
    {
        private readonly TriggerProperty _onPush = new TriggerProperty("OnPush");

        public FormImageProperties(FormControl control) : base(control)
        {
        }

        public Trigger OnPush => _onPush.Value;
    }
}
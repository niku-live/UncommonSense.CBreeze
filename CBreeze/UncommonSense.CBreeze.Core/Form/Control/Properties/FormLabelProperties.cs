using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormLabelProperties : LabelProperties, IPushAble
    {
        private readonly TriggerProperty _onPush = new TriggerProperty("OnPush");

        public FormLabelProperties(FormControl control) : base(control)
        {
            innerList.Add(_onPush);
        }

        public Trigger OnPush => _onPush.Value;
    }
}
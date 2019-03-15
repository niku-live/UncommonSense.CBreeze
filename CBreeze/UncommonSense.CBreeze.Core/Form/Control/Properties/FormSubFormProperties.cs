using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormSubFormProperties : SubFormProperties, IActivate
    {
        public FormSubFormProperties(FormControl control) : base(control)
        {
        }

        public Trigger OnActivate => InternalOnActivate;
        public Trigger OnDeactivate => InternalOnDeactivate;
    }
}
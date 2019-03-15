using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormOptionButtonProperties : OptionButtonProperties, IActivate, IPushAble, IValidate
    {
        public FormOptionButtonProperties(FormControl control) : base(control)
        {
        }
    }
}
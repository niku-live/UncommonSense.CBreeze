using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class OptionButtonProperties : CheckBoxProperties, IOptionButton
    {
        public OptionButtonProperties(FormControl control) : base(control)
        {
        }

        public string OptionValue
        {
            get => InternalOptionValue;
            set => InternalOptionValue = value;
        }
    }
}
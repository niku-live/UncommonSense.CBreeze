using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class OptionButtonProperties : CheckBoxProperties, IOptionButton
    {
        private readonly StringProperty _optionValue = new StringProperty("OptionValue");

        public OptionButtonProperties(FormControl control) : base(control)
        {
            innerList.Add(_optionValue);
        }

        public string OptionValue
        {
            get => _optionValue.Value;
            set => _optionValue.Value = value;
        }
    }
}
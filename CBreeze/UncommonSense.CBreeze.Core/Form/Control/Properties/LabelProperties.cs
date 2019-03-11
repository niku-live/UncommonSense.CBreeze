using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class LabelProperties : TextPropertiesBase, ILabel
    {
        private readonly NullableBooleanProperty _inColumnHeading = new NullableBooleanProperty("InColumnHeading");

        public LabelProperties(FormControl control) : base(control)
        {
            innerList.Add(_inColumnHeading);
        }

        public bool? InColumnHeading
        {
            get => _inColumnHeading.Value;
            set => _inColumnHeading.Value = value;
        }
    }
}
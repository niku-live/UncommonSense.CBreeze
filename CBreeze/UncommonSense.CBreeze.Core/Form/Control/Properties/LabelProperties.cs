using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class LabelProperties : TextPropertiesBase, ILabel
    {
        public LabelProperties(FormControl control) : base(control)
        {
        }

        public bool? InColumnHeading
        {
            get => InternalInColumnHeading;
            set => InternalInColumnHeading = value;
        }
    }
}
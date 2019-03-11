using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class CaptionBaseProperties : FormControlProperties, ICaption
    {
        private readonly StringProperty _captionClass = new StringProperty("CaptionClass");

        protected CaptionBaseProperties(FormControl control) : base(control)
        {
            innerList.Add(_captionClass);
        }

        public string CaptionClass
        {
            get => _captionClass.Value;
            set => _captionClass.Value = value;
        }
    }
}
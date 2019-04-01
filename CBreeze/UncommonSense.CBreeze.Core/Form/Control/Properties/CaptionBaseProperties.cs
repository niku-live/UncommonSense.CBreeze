using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class CaptionBaseProperties : FormControlProperties, ICaption
    {
        protected CaptionBaseProperties(FormControl control) : base(control)
        {
        }

        public string CaptionClass
        {
            get => InternalCaptionClass;
            set => InternalCaptionClass = value;
        }

        public MultiLanguageValue CaptionMl => InternalCaptionMl;

        public string Caption { get => InternalCaption; set => InternalCaption = value; }
    }
}
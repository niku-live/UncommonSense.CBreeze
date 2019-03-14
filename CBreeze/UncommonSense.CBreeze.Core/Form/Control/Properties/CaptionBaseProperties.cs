using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class CaptionBaseProperties : ControlBasePropertiesWithFont, ICaption
    {
        private readonly StringProperty _captionClass = new StringProperty("CaptionClass");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");

        protected CaptionBaseProperties(FormControl control) : base(control)
        {
            innerList.Add(_captionClass);
            innerList.Add(_captionMl);
        }

        public string CaptionClass
        {
            get => _captionClass.Value;
            set => _captionClass.Value = value;
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;
    }
}
using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseControlBaseProperties : ControlBasePropertiesWithFont, IBaseControl
    {
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");

        protected BaseControlBaseProperties(FormControl control) : base(control)
        {
            innerList.Add(_captionMl);
            innerList.Add(_description);
        }

        public string Description
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;
    }
}
using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class FormControlBackColorProperties : FormControlProperties, IFormControlBackColorProperties
    {
        private readonly ColorProperty _backColor = new ColorProperty("BackColor");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");

        protected FormControlBackColorProperties(FormControl control) : base(control)
        {
            innerList.Add(_backColor);
            innerList.Add(_captionMl);
        }

        public Color? BackColor
        {
            get => _backColor.Value;
            set => _backColor.Value = value;
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;
    }
}
using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class FormControlBackColorProperties : FormControlProperties, IFormControlBackColorProperties
    {
        protected FormControlBackColorProperties(FormControl control) : base(control)
        {
        }

        public MultiLanguageValue CaptionMl => InternalCaptionMl;
    }
}
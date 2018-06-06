using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class FormControlBackColorProperties : FormControlProperties, IFormControlBackColorProperties
    {
        private readonly ColorProperty _backColor = new ColorProperty("BackColor");

        protected FormControlBackColorProperties(FormControl control) : base(control)
        {
            innerList.Add(_backColor);
        }

        public Color BackColor
        {
            get => _backColor.Value;
            set => _backColor.Value = value;
        }
    }
}
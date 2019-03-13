using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class SubFormProperties : FormControlProperties, ISubForm
    {
        private readonly NullableBooleanProperty _border = new NullableBooleanProperty("Border");
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _enabled = new NullableBooleanProperty("Enabled");
        private readonly NullableIntegerProperty _nextControl = new NullableIntegerProperty("NextControl");
        private readonly StringProperty _subFormId = new StringProperty("SubFormID");
        private readonly StringProperty _subFormLink = new StringProperty("SubFormLink");
        private readonly StringProperty _subFormView = new StringProperty("SubFormView");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");

        public SubFormProperties(FormControl control) : base(control)
        {
            innerList.Add(_border);
            innerList.Add(_borderColor);
            innerList.Add(_borderWidth);
            innerList.Add(_borderStyle);
            innerList.Add(_description);
            innerList.Add(_enabled);
            innerList.Add(_nextControl);
            innerList.Add(_subFormId);
            innerList.Add(_subFormLink);
            innerList.Add(_subFormView);
            innerList.Add(_captionMl);
        }

        public bool? Border
        {
            get => _border.Value;
            set => _border.Value = value;
        }

        public string Description
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        public bool? Enabled
        {
            get => _enabled.Value;
            set => _enabled.Value = value;
        }

        public Color? BorderColor
        {
            get => _borderColor.Value;
            set => _borderColor.Value = value;
        }

        public BorderWidth BorderWidth
        {
            get => _borderWidth.Value;
            set => _borderWidth.Value = value;
        }

        private BorderStyle BorderStyle
        {
            get => _borderStyle.Value;
            set => _borderStyle.Value = value;
        }


        public int? NextControl
        {
            get => _nextControl.Value;
            set => _nextControl.Value = value;
        }

        public string SubFormId
        {
            get => _subFormId.Value;
            set => _subFormId.Value = value;
        }

        public string SubFormView
        {
            get => _subFormView.Value;
            set => _subFormView.Value = value;
        }

        public string SubFormLink
        {
            get => _subFormLink.Value;
            set => _subFormLink.Value = value;
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;
    }
}
using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class SubFormProperties : FormControlProperties, ISubForm
    {
        private readonly StringProperty _subFormId = new StringProperty("SubFormID");
        private readonly StringProperty _subFormLink = new StringProperty("SubFormLink");
        private readonly StringProperty _subFormView = new StringProperty("SubFormView");

        public SubFormProperties(FormControl control) : base(control)
        {
            innerList.Add(_subFormId);
            innerList.Add(_subFormView);
            innerList.Add(_subFormLink);
        }

        public string Description
        {
            get => InternalDescription;
            set => InternalDescription = value;
        }

        public bool? Enabled
        {
            get => InternalEnabled;
            set => InternalEnabled = value;
        }

        public Color? BorderColor
        {
            get => InternalBorderColor;
            set => InternalBorderColor = value;
        }

        public BorderWidth? BorderWidth
        {
            get => InternalBorderWidth;
            set => InternalBorderWidth = value;
        }

        private BorderStyle? BorderStyle
        {
            get => InternalBorderStyle;
            set => InternalBorderStyle = value;
        }


        public int? NextControl
        {
            get => InternalNextControl;
            set => InternalNextControl = value;
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

        public MultiLanguageValue CaptionMl => InternalCaptionMl;
    }
}
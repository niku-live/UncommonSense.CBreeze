using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class SubFormProperties : FormControlProperties, ISubForm
    {
        public SubFormProperties(FormControl control) : base(control)
        {
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
            get => InternalSubFormId;
            set => InternalSubFormId = value;
        }

        public TableView SubFormView => InternalSubFormView;

        public RunObjectLink SubFormLink => InternalSubFormLink;

        public MultiLanguageValue CaptionMl => InternalCaptionMl;

        public string Caption { get => InternalCaption; set => InternalCaption = value; }
    }
}
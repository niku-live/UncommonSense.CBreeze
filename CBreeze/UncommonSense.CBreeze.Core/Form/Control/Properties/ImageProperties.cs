using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class ImageProperties : FormControlProperties, IImage
    {
   
        public ImageProperties(FormControl control) : base(control)
        {
        }

        public string Description
        {
            get => InternalDescription;
            set => InternalDescription = value;
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

        public BorderStyle? BorderStyle
        {
            get => InternalBorderStyle;
            set => InternalBorderStyle = value;
        }

        public string DataSetFieldName
        {
            get => InternalDataSetFieldName;
            set => InternalDataSetFieldName = value;
        }

        public bool? InColumnHeading
        {
            get => InternalInColumnHeading;
            set => InternalInColumnHeading = value;
        }

        public MultiLanguageValue CaptionMl => InternalCaptionMl;

        public string Caption { get => InternalCaption; set => InternalCaption = value; }
    }
}
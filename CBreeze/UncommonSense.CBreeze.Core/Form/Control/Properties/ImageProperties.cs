using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class ImageProperties : FormControlProperties, IImage
    {
        private readonly ColorProperty _backColor = new ColorProperty("BackColor");
        private readonly NullableBooleanProperty _backTransparent = new NullableBooleanProperty("BackTransparent");
        private readonly StringProperty _bitmap = new StringProperty("Bitmap");
        private readonly NullableBooleanProperty _border = new NullableBooleanProperty("Border");
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly StringProperty _dataSetFieldName = new StringProperty("DataSetFieldName");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _inColumnHeading = new NullableBooleanProperty("InColumnHeading");

        public ImageProperties(FormControl control) : base(control)
        {
            innerList.Add(_backColor);
            innerList.Add(_backTransparent);
            innerList.Add(_bitmap);
            innerList.Add(_border);
            innerList.Add(_borderColor);
            innerList.Add(_borderStyle);
            innerList.Add(_borderWidth);
            innerList.Add(_dataSetFieldName);
            innerList.Add(_description);
            innerList.Add(_inColumnHeading);
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

        public bool? BackTransparent
        {
            get => _backTransparent.Value;
            set => _backTransparent.Value = value;
        }

        public Color BackColor
        {
            get => _backColor.Value;
            set => _backColor.Value = value;
        }

        public Color BorderColor
        {
            get => _borderColor.Value;
            set => _borderColor.Value = value;
        }

        public BorderWidth BorderWidth
        {
            get => _borderWidth.Value;
            set => _borderWidth.Value = value;
        }

        public BorderStyle BorderStyle
        {
            get => _borderStyle.Value;
            set => _borderStyle.Value = value;
        }

        public string Bitmap
        {
            get => _bitmap.Value;
            set => _bitmap.Value = value;
        }

        public string DataSetFieldName
        {
            get => _dataSetFieldName.Value;
            set => _dataSetFieldName.Value = value;
        }

        public bool? InColumnHeading
        {
            get => _inColumnHeading.Value;
            set => _inColumnHeading.Value = value;
        }
    }
}
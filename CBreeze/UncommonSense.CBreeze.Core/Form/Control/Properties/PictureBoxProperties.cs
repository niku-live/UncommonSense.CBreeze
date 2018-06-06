using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class PictureBoxProperties : FormControlProperties, IPictureBox
    {
        private readonly NullableBooleanProperty _autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private readonly ColorProperty _backColor = new ColorProperty("BackColor");
        private readonly NullableBooleanProperty _backTransparent = new NullableBooleanProperty("BackTransparent");
        private readonly StringProperty _bitmapList = new StringProperty("BitmapList");
        private readonly NullableBooleanProperty _border = new NullableBooleanProperty("Border");
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly StringProperty _dataSetFieldName = new StringProperty("DataSetFieldName");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _enabled = new NullableBooleanProperty("Enabled");
        private readonly NullableBooleanProperty _focusable = new NullableBooleanProperty("Focusable");
        private readonly NullableBooleanProperty _inColumn = new NullableBooleanProperty("InColumn");
        private readonly NullableBooleanProperty _inMatrix = new NullableBooleanProperty("InMatrix");
        private readonly NullableBooleanProperty _inMatrixHeading = new NullableBooleanProperty("InMatrixHeading");
        private readonly NullableIntegerProperty _nextControl = new NullableIntegerProperty("NextControl");
        private readonly StringProperty _sourceExpr = new StringProperty("SourceExpr");

        public PictureBoxProperties(FormControl formPictureBoxControl) : base(formPictureBoxControl)
        {
        }

        public bool? Enabled
        {
            get => _enabled.Value;
            set => _enabled.Value = value;
        }

        public bool? Focusable
        {
            get => _focusable.Value;
            set => _focusable.Value = value;
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

        public int? NextControl
        {
            get => _nextControl.Value;
            set => _nextControl.Value = value;
        }

        public bool? InColumn
        {
            get => _inColumn.Value;
            set => _inColumn.Value = value;
        }

        public bool? InMatrix
        {
            get => _inMatrix.Value;
            set => _inMatrix.Value = value;
        }

        public bool? InMatrixHeading
        {
            get => _inMatrixHeading.Value;
            set => _inMatrixHeading.Value = value;
        }

        public string SourceExpr
        {
            get => _sourceExpr.Value;
            set => _sourceExpr.Value = value;
        }

        public bool? AutoCalcField
        {
            get => _autoCalcField.Value;
            set => _autoCalcField.Value = value;
        }

        public string DataSetFieldName
        {
            get => _dataSetFieldName.Value;
            set => _dataSetFieldName.Value = value;
        }

        public string BitmapList
        {
            get => _bitmapList.Value;
            set => _bitmapList.Value = value;
        }
    }
}
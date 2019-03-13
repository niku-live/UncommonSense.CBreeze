using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class PictureBoxProperties : BaseControlBaseProperties2, IPictureBox
    {
        private readonly NullableBooleanProperty _autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private readonly StringProperty _bitmapList = new StringProperty("BitmapList");
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly StringProperty _dataSetFieldName = new StringProperty("DataSetFieldName");
        private readonly NullableBooleanProperty _inColumn = new NullableBooleanProperty("InColumn");
        private readonly NullableBooleanProperty _inMatrix = new NullableBooleanProperty("InMatrix");
        private readonly NullableBooleanProperty _inMatrixHeading = new NullableBooleanProperty("InMatrixHeading");
        private readonly StringProperty _sourceExpr = new StringProperty("SourceExpr");
        private readonly BitmapPosProperty _bitmapPos = new BitmapPosProperty("BitmapPos");

        public PictureBoxProperties(FormControl formPictureBoxControl) : base(formPictureBoxControl)
        {
            innerList.Add(_autoCalcField);
            innerList.Add(_borderColor);
            innerList.Add(_borderStyle);
            innerList.Add(_borderWidth);
            innerList.Add(_dataSetFieldName);
            innerList.Add(_inColumn);
            innerList.Add(_inMatrix);
            innerList.Add(_inMatrixHeading);
            innerList.Add(_sourceExpr);
            innerList.Add(_bitmapList);
            innerList.Add(_bitmapPos);
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

        public BorderStyle BorderStyle
        {
            get => _borderStyle.Value;
            set => _borderStyle.Value = value;
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

        public BitmapPos BitmapPos
        {
            get => _bitmapPos.Value;
            set => _bitmapPos.Value = value;
        }
    }
}
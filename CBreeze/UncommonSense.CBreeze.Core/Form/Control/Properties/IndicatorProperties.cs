using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class IndicatorProperties : BaseControlBaseProperties2, IIndicator
    {
        private readonly NullableBooleanProperty _autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private readonly ColorProperty _foreColor = new ColorProperty("ForeColor");
        private readonly NullableBooleanProperty _inColumn = new NullableBooleanProperty("InColumn");
        private readonly NullableBooleanProperty _inMatrix = new NullableBooleanProperty("InMatrix");
        private readonly NullableBooleanProperty _inMatrixHeading = new NullableBooleanProperty("InMatrixHeading");
        private readonly StringProperty _maxValue = new StringProperty("MaxValue");
        private readonly StringProperty _minValue = new StringProperty("MinValue");
        private readonly OrientationProperty _orientation = new OrientationProperty("Orientation");
        private readonly NullableIntegerProperty _percentage = new NullableIntegerProperty("Percentage");
        private readonly StringProperty _sourceExpr = new StringProperty("SourceExpr");
        private readonly StringProperty _valuesAllowed = new StringProperty("ValuesAllowed");

        public IndicatorProperties(FormControl control) : base(control)
        {
        }

        public Color ForeColor
        {
            get => _foreColor.Value;
            set => _foreColor.Value = value;
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

        public string MinValue
        {
            get => _minValue.Value;
            set => _minValue.Value = value;
        }

        public string MaxValue
        {
            get => _maxValue.Value;
            set => _maxValue.Value = value;
        }

        public string ValuesAllowed
        {
            get => _valuesAllowed.Value;
            set => _valuesAllowed.Value = value;
        }

        public Orientation Orientation
        {
            get => _orientation.Value;
            set => _orientation.Value = value;
        }

        public int? Percentage
        {
            get => _percentage.Value;
            set => _percentage.Value = value;
        }
    }
}
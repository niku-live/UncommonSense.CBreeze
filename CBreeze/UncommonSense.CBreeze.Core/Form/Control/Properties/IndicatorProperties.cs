using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class IndicatorProperties : BaseControlBaseProperties2, IIndicator
    {
        private readonly OrientationProperty _orientation = new OrientationProperty("Orientation");
        private readonly NullableIntegerProperty _percentage = new NullableIntegerProperty("Percentage");

        public IndicatorProperties(FormControl control) : base(control)
        {
        }

        public string SourceExpr
        {
            get => InternalSourceExpr;
            set => InternalSourceExpr = value;
        }

        public bool? AutoCalcField
        {
            get => InternalAutoCalcField;
            set => InternalAutoCalcField = value;
        }

        public string MinValue
        {
            get => InternalMinValue;
            set => InternalMinValue = value;
        }

        public string MaxValue
        {
            get => InternalMaxValue;
            set => InternalMaxValue = value;
        }

        public string ValuesAllowed
        {
            get => InternalValuesAllowed;
            set => InternalValuesAllowed = value;
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
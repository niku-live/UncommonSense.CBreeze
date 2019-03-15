using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class IndicatorProperties : BaseControlBaseProperties2, IIndicator
    {
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
            get => InternalOrientation;
            set => InternalOrientation = value;
        }

        public int? Percentage
        {
            get => InternalPercentage;
            set => InternalPercentage = value;
        }
    }
}
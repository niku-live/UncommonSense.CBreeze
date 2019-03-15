using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class CheckBoxProperties : BaseButtonProperties, ICheckBox
    {
        public CheckBoxProperties(FormControl control) : base(control)
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

        public bool? UpdateOnAction
        {
            get => InternalUpdateOnAction;
            set => InternalUpdateOnAction = value;
        }

    }
}
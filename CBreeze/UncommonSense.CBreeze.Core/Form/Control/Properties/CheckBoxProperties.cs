using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class CheckBoxProperties : BaseButtonProperties, ICheckBox
    {
        private readonly NullableBooleanProperty _autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private readonly StringProperty _maxValue = new StringProperty("MaxValue");
        private readonly StringProperty _minValue = new StringProperty("MinValue");
        private readonly StringProperty _sourceExpr = new StringProperty("SourceExpr");
        private readonly NullableBooleanProperty _updateOnAction = new NullableBooleanProperty("UpdateOnAction");
        private readonly StringProperty _valuesAllowed = new StringProperty("ValuesAllowed");

        public CheckBoxProperties(FormControl control) : base(control)
        {
            innerList.Add(_autoCalcField);
            innerList.Add(_maxValue);
            innerList.Add(_minValue);
            innerList.Add(_sourceExpr);
            innerList.Add(_updateOnAction);
            innerList.Add(_valuesAllowed);
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

        public bool? UpdateOnAction
        {
            get => _updateOnAction.Value;
            set => _updateOnAction.Value = value;
        }

    }
}
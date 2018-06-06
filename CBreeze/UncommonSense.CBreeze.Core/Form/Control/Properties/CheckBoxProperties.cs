using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class CheckBoxProperties : BaseButtonProperties, ICheckBox
    {
        private readonly NullableBooleanProperty _autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private readonly NullableBooleanProperty _inColumn = new NullableBooleanProperty("InColumn");
        private readonly NullableBooleanProperty _inMatrix = new NullableBooleanProperty("InMatrix");
        private readonly NullableBooleanProperty _inMatrixHeading = new NullableBooleanProperty("InMatrixHeading");
        private readonly StringProperty _maxValue = new StringProperty("MaxValue");
        private readonly StringProperty _minValue = new StringProperty("MinValue");
        private readonly PushActionProperty _pushAction = new PushActionProperty("PushAction");
        private readonly StringProperty _runCommand = new StringProperty("RunCommand");
        private readonly StringProperty _runFormLink = new StringProperty("RunFormLink");
        private readonly RunFormLinkTypeProperty _runFormLinkType = new RunFormLinkTypeProperty("RunFormLinkType");
        private readonly NullableBooleanProperty _runFormOnRec = new NullableBooleanProperty("RunFormOnRec");
        private readonly StringProperty _runFormView = new StringProperty("RunFormView");
        private readonly RunObjectProperty _runObject = new RunObjectProperty("RunObject");
        private readonly StringProperty _sourceExpr = new StringProperty("SourceExpr");
        private readonly NullableBooleanProperty _updateOnAction = new NullableBooleanProperty("UpdateOnAction");
        private readonly StringProperty _valuesAllowed = new StringProperty("ValuesAllowed");

        public CheckBoxProperties(FormControl control) : base(control)
        {
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

        public PushAction PushAction
        {
            get => _pushAction.Value;
            set => _pushAction.Value = value;
        }

        public RunObject RunObject => _runObject.Value;

        public string RunFormView
        {
            get => _runFormView.Value;
            set => _runFormView.Value = value;
        }

        public string RunFormLink
        {
            get => _runFormLink.Value;
            set => _runFormLink.Value = value;
        }

        public RunFormLinkType RunFormLinkType
        {
            get => _runFormLinkType.Value;
            set => _runFormLinkType.Value = value;
        }

        public bool? RunFormOnRec
        {
            get => _runFormOnRec.Value;
            set => _runFormOnRec.Value = value;
        }

        public string RunCommand
        {
            get => _runCommand.Value;
            set => _runCommand.Value = value;
        }

        public bool? UpdateOnAction
        {
            get => _updateOnAction.Value;
            set => _updateOnAction.Value = value;
        }
    }
}
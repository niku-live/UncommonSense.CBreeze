using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Dataport
{
    public class DataportFieldProperties : Properties
    {
        NullableBooleanProperty callFieldValidate = new NullableBooleanProperty("CallFieldValidate");
        TriggerProperty onBeforeFormatField = new TriggerProperty("OnBeforeFormatField");
        TriggerProperty onAfterFormatField = new TriggerProperty("OnAfterFormatField");
        TriggerProperty onBeforeEvaluateField = new TriggerProperty("OnBeforeEvaluateField");
        TriggerProperty onAferEvaluateField = new TriggerProperty("OnAfterEvaluateField");

        internal DataportFieldProperties(DataportField dataportField)
        {
            DataportField = dataportField;

            innerList.Add(callFieldValidate);
            innerList.Add(onAferEvaluateField);
            innerList.Add(onAfterFormatField);
            innerList.Add(onBeforeEvaluateField);
            innerList.Add(onBeforeFormatField);
        }

        public DataportField DataportField { get; set; }

        public override INode ParentNode => DataportField;

        public bool? CallFieldValidate { get => callFieldValidate.Value; set => callFieldValidate.Value = value; }
        public Trigger OnBeforeFormatField { get => onBeforeFormatField.Value; }
        public Trigger OnAfterFormatField { get => onAfterFormatField.Value; }
        public Trigger OnBeforeEvaluateField { get => onBeforeEvaluateField.Value; }
        public Trigger OnAferEvaluateField { get => onAferEvaluateField.Value; }
    }
}
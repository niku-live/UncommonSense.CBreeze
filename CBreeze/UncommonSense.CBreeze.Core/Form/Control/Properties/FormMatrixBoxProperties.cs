using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormMatrixBoxProperties : MatrixBoxProperties, IRecord
    {
        private readonly TriggerProperty _onAfterGetCurrRecord = new TriggerProperty("OnAfterGetCurrRecord");
        private readonly TriggerProperty _onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private readonly TriggerProperty _onBeforePutRecord = new TriggerProperty("OnBeforePutRecord");
        private readonly TriggerProperty _onFindRecord = new TriggerProperty("OnFindRecord");
        private readonly TriggerProperty _onNextRecord = new TriggerProperty("OnNextRecord");

        public FormMatrixBoxProperties(FormControl formMatrixBoxControl) : base(formMatrixBoxControl)
        {
            innerList.Add(_onAfterGetRecord);
            innerList.Add(_onAfterGetCurrRecord);
            innerList.Add(_onBeforePutRecord);
            innerList.Add(_onFindRecord);
            innerList.Add(_onNextRecord);
        }

        public Trigger OnFindRecord => _onFindRecord.Value;
        public Trigger OnNextRecord => _onNextRecord.Value;
        public Trigger OnAfterGetRecord => _onAfterGetRecord.Value;
        public Trigger OnAfterGetCurrRecord => _onAfterGetCurrRecord.Value;
        public Trigger OnBeforePutRecord => _onBeforePutRecord.Value;
    }
}
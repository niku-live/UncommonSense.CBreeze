using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormTextBoxProperties : TextBoxProperties, IActivate, IFormatable, IInput, IValidate, IField
    {
        private readonly TriggerProperty _onActivate = new TriggerProperty("OnActivate");
        private readonly TriggerProperty _onAfterInput = new TriggerProperty("OnAfterInput");
        private readonly TriggerProperty _onAfterValidate = new TriggerProperty("OnAfterValidate");
        private readonly TriggerProperty _onAssistEdit = new TriggerProperty("OnAssistEdit");
        private readonly TriggerProperty _onBeforeInput = new TriggerProperty("OnBeforeInput");
        private readonly TriggerProperty _onDeactivate = new TriggerProperty("OnDeactivate");
        private readonly TriggerProperty _onDrillDown = new TriggerProperty("OnDrillDown");
        private readonly TriggerProperty _onFormat = new TriggerProperty("OnFormat");
        private readonly TriggerProperty _onInputChange = new TriggerProperty("OnInputChange");
        private readonly TriggerProperty _onLookup = new TriggerProperty("OnLookup");
        private readonly TriggerProperty _onValidate = new TriggerProperty("OnValidate");

        public FormTextBoxProperties(FormControl control) : base(control)
        {
            innerList.Add(_onActivate);
            innerList.Add(_onAfterInput);
            innerList.Add(_onAssistEdit);
            innerList.Add(_onBeforeInput);
            innerList.Add(_onDeactivate);
            innerList.Add(_onDrillDown);
            innerList.Add(_onFormat);
            innerList.Add(_onInputChange);
            innerList.Add(_onValidate);
            innerList.Add(_onLookup);
            innerList.Add(_onAfterValidate);
        }

        public Trigger OnActivate => _onActivate.Value;
        public Trigger OnDeactivate => _onDeactivate.Value;
        public Trigger OnLookup => _onLookup.Value;
        public Trigger OnAssistEdit => _onAssistEdit.Value;
        public Trigger OnDrillDown => _onDrillDown.Value;
        public Trigger OnFormat => _onFormat.Value;
        public Trigger OnBeforeInput => _onBeforeInput.Value;
        public Trigger OnInputChange => _onInputChange.Value;
        public Trigger OnAfterInput => _onAfterInput.Value;
        public Trigger OnValidate => _onValidate.Value;
        public Trigger OnAfterValidate => _onAfterValidate.Value;
    }
}
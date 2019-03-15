using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormTextBoxProperties : TextBoxProperties, IActivate, IFormatable, IInput, IValidate, IField
    {
        public FormTextBoxProperties(FormControl control) : base(control)
        {
        }

        public Trigger OnActivate => InternalOnActivate;
        public Trigger OnDeactivate => InternalOnDeactivate;
        public Trigger OnLookup => InternalOnLookup;
        public Trigger OnAssistEdit => InternalOnAssistEdit;
        public Trigger OnDrillDown => InternalOnDrillDown;
        public Trigger OnFormat => InternalOnFormat;
        public Trigger OnBeforeInput => InternalOnBeforeInput;
        public Trigger OnInputChange => InternalOnInputChange;
        public Trigger OnAfterInput => InternalOnAfterInput;
        public Trigger OnValidate => InternalOnValidate;
        public Trigger OnAfterValidate => InternalOnAfterValidate;
    }
}
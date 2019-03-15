using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormMatrixBoxProperties : MatrixBoxProperties, IRecord
    {
        public FormMatrixBoxProperties(FormControl formMatrixBoxControl) : base(formMatrixBoxControl)
        {
        }

        public Trigger OnFindRecord => InternalOnFindRecord;
        public Trigger OnNextRecord => InternalOnNextRecord;
        public Trigger OnAfterGetRecord => InternalOnAfterGetRecord;
        public Trigger OnAfterGetCurrRecord => InternalOnAfterGetCurrRecord;
        public Trigger OnBeforePutRecord => InternalOnBeforePutRecord;
    }
}
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseControlBaseProperties2 : BaseControlBaseProperties, IBaseControl2
    {
        protected BaseControlBaseProperties2(FormControl control) : base(control)
        {
        }

        public bool? Enabled
        {
            get => InternalEnabled;
            set => InternalEnabled = value;
        }

        public int? NextControl
        {
            get => InternalNextControl;
            set => InternalNextControl = value;
        }

        public Trigger OnActivate => InternalOnActivate;
        public Trigger OnDeactivate => InternalOnDeactivate;
        public Trigger OnPush => InternalOnPush;
        public Trigger OnValidate => InternalOnValidate;
        public Trigger OnAfterValidate => InternalOnAfterValidate;
    }
}
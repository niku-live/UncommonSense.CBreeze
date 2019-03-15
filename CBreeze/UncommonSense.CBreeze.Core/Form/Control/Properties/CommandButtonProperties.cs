using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class CommandButtonProperties : BaseButtonProperties, ICommandButton
    {
        public CommandButtonProperties(FormControl control) : base(control)
        {
        }

        public bool? AutoRepeat
        {
            get => InternalAutoRepeat;
            set => InternalAutoRepeat = value;
        }

        public InvalidActionAppearance? InvalidActionAppearance
        {
            get => InternalInvalidActionAppearance;
            set => InternalInvalidActionAppearance = value;
        }

        public bool? Ellipsis
        {
            get => InternalEllipsis;
            set => InternalEllipsis = value;
        }

    }
}
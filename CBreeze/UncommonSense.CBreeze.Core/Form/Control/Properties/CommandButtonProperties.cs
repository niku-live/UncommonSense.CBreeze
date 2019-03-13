using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class CommandButtonProperties : BaseButtonProperties, ICommandButton
    {
        private readonly NullableBooleanProperty _autoRepeat = new NullableBooleanProperty("AutoRepeat");
        private readonly NullableBooleanProperty _cancel = new NullableBooleanProperty("Cancel");
        private readonly NullableBooleanProperty _default = new NullableBooleanProperty("Default");
        private readonly NullableBooleanProperty _ellipsis = new NullableBooleanProperty("Ellipsis");
        private readonly InvalidActionAppearanceProperty _invalidActionAppearance =
            new InvalidActionAppearanceProperty("InvalidActionAppearance");

        public CommandButtonProperties(FormControl control) : base(control)
        {
            innerList.Add(_autoRepeat);
            innerList.Add(_cancel);
            innerList.Add(_default);
            innerList.Add(_ellipsis);
            innerList.Add(_invalidActionAppearance);
        }

        public bool? Default
        {
            get => _default.Value;
            set => _default.Value = value;
        }

        public bool? Cancel
        {
            get => _cancel.Value;
            set => _cancel.Value = value;
        }

        public bool? AutoRepeat
        {
            get => _autoRepeat.Value;
            set => _autoRepeat.Value = value;
        }

        public InvalidActionAppearance? InvalidActionAppearance
        {
            get => _invalidActionAppearance.Value;
            set => _invalidActionAppearance.Value = value;
        }

        public bool? Ellipsis
        {
            get => _ellipsis.Value;
            set => _ellipsis.Value = value;
        }

    }
}
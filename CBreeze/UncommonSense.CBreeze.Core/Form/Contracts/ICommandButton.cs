using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface ICommandButton : IButton
    {
        bool? Default { get; set; }
        bool? Cancel { get; set; }
        bool? AutoRepeat { get; set; }
        InvalidActionAppearance? InvalidActionAppearance { get; set; }
        bool? Ellipsis { get; set; }
    }
}
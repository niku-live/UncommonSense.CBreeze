using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface ISubForm : IFormControlProperties, IFormBorder, IDescriptionable, IEnabledFocusable,
        IExtendedFormBorder, IEditable, IControlList
    {
        string SubFormId { get; set; }
        string SubFormView { get; set; }
        RunObjectLink SubFormLink { get; }
    }
}
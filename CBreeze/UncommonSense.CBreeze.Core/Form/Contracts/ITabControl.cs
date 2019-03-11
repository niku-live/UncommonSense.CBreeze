using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface ITabControl : IEnabledFocusable, IBaseBorderlessControl, IForeColor, IEditable, IFont
    {
        MultiLanguageValue PageNamesMl { get; }
    }
}
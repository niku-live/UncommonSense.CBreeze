using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IFocusable : IFormControlProperties
    {
        bool? FocusOnClick { get; set; }
        BitmapPos BitmapPos { get; set; }
    }
}
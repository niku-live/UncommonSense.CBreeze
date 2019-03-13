using System.Drawing;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IExtendedFormBorder : IFormBorder
    {
        Color? BorderColor { get; set; }
        BorderWidth BorderWidth { get; set; }
    }
}
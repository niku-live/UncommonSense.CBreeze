using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IExtendFormBorder2 : IExtendedFormBorder
    {
        BorderStyle? BorderStyle { get; set; }
    }
}
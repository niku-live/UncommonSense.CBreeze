using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IAlignment : IFormControlProperties
    {
        HorzAlign? HorzAlign { get; set; }
        VertAlign? VertAlign { get; set; }
    }
}
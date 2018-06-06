using System.Drawing;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IFormControlBackColorProperties : IFormControlProperties
    {
        Color BackColor { get; set; }
    }
}
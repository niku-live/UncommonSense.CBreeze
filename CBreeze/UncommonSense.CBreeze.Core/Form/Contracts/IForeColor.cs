using System.Drawing;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IForeColor : IFormControlProperties
    {
        Color? ForeColor { get; set; }
    }
}
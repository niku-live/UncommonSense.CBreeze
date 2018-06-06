using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IIndicator : IBaseControl2, IForeColor, IControlList, IColumnMatrix, IExtendedSourceExpr
    {
        Orientation Orientation { get; set; }
        int? Percentage { get; set; }
    }
}
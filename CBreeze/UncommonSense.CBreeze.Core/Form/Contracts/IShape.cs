using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IShape : IBaseControl, IExtendedFormBorder, IColumnMatrixExtended
    {
        ShapeStyle? ShapeStyle { get; set; }
    }
}
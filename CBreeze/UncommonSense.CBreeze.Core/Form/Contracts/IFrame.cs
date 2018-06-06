namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IFrame : IBaseControl2, IExtendFormBorder2, IEditable
    {
        bool? TopLineOnly { get; set; }
    }
}
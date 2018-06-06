namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IEditable : IFormControlProperties
    {
        bool? Editable { get; set; }
    }
}
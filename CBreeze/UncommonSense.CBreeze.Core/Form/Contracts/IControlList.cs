namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IControlList : IFormControlProperties
    {
        int? NextControl { get; set; }
    }
}
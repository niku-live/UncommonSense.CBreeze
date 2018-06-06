namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IEnabledFocusable : IFormControlProperties
    {
        bool? Enabled { get; set; }
        bool? Focusable { get; set; }
    }
}
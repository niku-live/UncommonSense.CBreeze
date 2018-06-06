namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IExtendedText : IFormControlProperties
    {
        bool? MultiLine { get; set; }
        string PadChar { get; set; }
        bool? LeaderDots { get; set; }
    }
}
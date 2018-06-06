namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IFont : IFormControlProperties
    {
        string FontName { get; set; }
        int? FontSize { get; set; }
        bool? FontBold { get; set; }
        bool? FontItalic { get; set; }
        bool? FontStrikethru { get; set; }
        bool? FontUnderline { get; set; }
    }
}
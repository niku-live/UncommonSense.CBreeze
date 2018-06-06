using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface ICaption : IFormControlProperties
    {
        MultiLanguageValue CaptionMl { get; }
        string CaptionClass { get; set; }
    }
}
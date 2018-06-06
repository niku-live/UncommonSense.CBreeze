using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IFormControlProperties
    {
        int? InPage { get; set; }
        bool? InFrame { get; set; }
        string Name { get; set; }
        bool? Visible { get; set; }
        uint? XPos { get; set; }
        uint? YPos { get; set; }
        uint? Width { get; set; }
        uint? Height { get; set; }
        VertGlue? VertGlue { get; set; }
        HorzGlue? HorzGlue { get; set; }
        uint? ParentControl { get; set; }
        MultiLanguageValue ToolTipML { get; }
    }
}
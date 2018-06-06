using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TabControlProperties : FormControlProperties, ITabControl
    {
        public TabControlProperties(FormControl control) : base(control)
        {
        }

        public bool? Enabled { get; set; }
        public bool? Focusable { get; set; }
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
        public bool? Editable { get; set; }
        public string FontName { get; set; }
        public int? FontSize { get; set; }
        public bool? FontBold { get; set; }
        public bool? FontItalic { get; set; }
        public bool? FontStrikethru { get; set; }
        public bool? FontUnderline { get; set; }
        public MultiLanguageValue PageNamesMl { get; set; }
    }
}
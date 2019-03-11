using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TabControlProperties : ControlBasePropertiesWithFont, ITabControl
    {
        private readonly NullableBooleanProperty _editable = new NullableBooleanProperty("Editable");
        private readonly MultiLanguageProperty _pageNamesMl = new MultiLanguageProperty("PageNamesML");

        public TabControlProperties(FormControl control) : base(control)
        {
            innerList.Add(_editable);
            innerList.Add(_pageNamesMl);
        }

        public bool? Editable { get => _editable.Value; set => _editable.Value = value; }
        public MultiLanguageValue PageNamesMl { get => _pageNamesMl.Value; }
    }
}
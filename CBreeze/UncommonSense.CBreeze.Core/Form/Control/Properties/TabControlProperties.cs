using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TabControlProperties : BaseControlBaseProperties2, ITabControl
    {
        private readonly MultiLanguageProperty _pageNamesMl = new MultiLanguageProperty("PageNamesML");

        public TabControlProperties(FormControl control) : base(control)
        {
            innerList.Add(_pageNamesMl);
        }

        public MultiLanguageValue PageNamesMl { get => _pageNamesMl.Value; }
    }
}
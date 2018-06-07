using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section.Properties
{
    public class HeaderSectionProperties : SectionPropertiesBase
    {
        private readonly NullableBooleanProperty _printOnEveryPage = new NullableBooleanProperty("PrintOnEveryPage");

        public HeaderSectionProperties(SectionBase section) : base(section)
        {
            innerList.Add(_printOnEveryPage);
        }

        public bool? PrintOnEveryPage
        {
            get => _printOnEveryPage.Value;
            set => _printOnEveryPage.Value = value;
        }
    }
}
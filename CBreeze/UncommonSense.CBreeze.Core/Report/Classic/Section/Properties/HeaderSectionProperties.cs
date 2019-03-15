using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section.Properties
{
    public class HeaderSectionProperties : SectionPropertiesBase
    {
        public HeaderSectionProperties(SectionBase section) : base(section)
        {
        }

        public bool? PrintOnEveryPage
        {
            get => InternalPrintOnEveryPage;
            set => InternalPrintOnEveryPage = value;
        }
    }
}
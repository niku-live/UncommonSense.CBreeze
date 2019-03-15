using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section.Properties
{
    public class FooterSectionProperties : SectionPropertiesBase
    {
        public FooterSectionProperties(SectionBase section) : base(section)
        {
        }

        public bool? PlaceInBottom
        {
            get => InternalPlaceInBottom;
            set => InternalPlaceInBottom = value;
        }

        public bool? PrintOnEveryPage
        {
            get => InternalPrintOnEveryPage;
            set => InternalPrintOnEveryPage = value;
        }
    }
}
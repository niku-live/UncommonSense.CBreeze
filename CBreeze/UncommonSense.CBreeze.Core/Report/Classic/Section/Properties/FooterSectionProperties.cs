using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section.Properties
{
    public class FooterSectionProperties : SectionPropertiesBase
    {
        private readonly NullableBooleanProperty _placeInBottom = new NullableBooleanProperty("PlaceInBottom");
        private readonly NullableBooleanProperty _printOnEveryPage = new NullableBooleanProperty("PrintOnEveryPage");

        public FooterSectionProperties(SectionBase section) : base(section)
        {
            innerList.Add(_printOnEveryPage);
            innerList.Add(_placeInBottom);
        }

        public bool? PlaceInBottom
        {
            get => _placeInBottom.Value;
            set => _placeInBottom.Value = value;
        }

        public bool? PrintOnEveryPage
        {
            get => _printOnEveryPage.Value;
            set => _printOnEveryPage.Value = value;
        }
    }
}
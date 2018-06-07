using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section.Properties
{
    public abstract class SectionPropertiesBase : Property.Properties
    {
        private readonly NullableBooleanProperty _keepWithNext = new NullableBooleanProperty("KeepWithNext");
        private readonly TriggerProperty _onPostSection = new TriggerProperty("OnPostSection");
        private readonly TriggerProperty _onPreSection = new TriggerProperty("OnPreSection");
        private readonly IntegerProperty _sectionHeight = new IntegerProperty("SectionHeight");
        private readonly IntegerProperty _sectionWidth = new IntegerProperty("SectionWidth");

        protected SectionPropertiesBase(SectionBase section)
        {
            Section = section;
            innerList.Add(_keepWithNext);
            innerList.Add(_sectionHeight);
            innerList.Add(_sectionWidth);
            innerList.Add(_onPostSection);
            innerList.Add(_onPreSection);
        }

        public Trigger OnPreSection => _onPreSection.Value;
        public Trigger OnPostSection => _onPostSection.Value;

        public int SectionWidth
        {
            get => _sectionWidth.Value;
            set => _sectionWidth.Value = value;
        }

        public int SectionHeight
        {
            get => _sectionHeight.Value;
            set => _sectionHeight.Value = value;
        }

        public bool? KeepWithNext
        {
            get => _keepWithNext.Value;
            set => _keepWithNext.Value = value;
        }

        public override INode ParentNode => Section;

        public SectionBase Section { get; protected set; }
    }
}
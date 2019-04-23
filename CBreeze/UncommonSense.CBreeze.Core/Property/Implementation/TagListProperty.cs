using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2017
    public class TagListProperty : ReferenceProperty<TagList>
    {
        internal TagListProperty(string name, bool spaceSeparation = false) : base(name)
        {
            SpaceSeparation = spaceSeparation;
        }

        public override bool HasValue => Value.Any();

        public bool SpaceSeparation { get; set; }
    }
#endif
}

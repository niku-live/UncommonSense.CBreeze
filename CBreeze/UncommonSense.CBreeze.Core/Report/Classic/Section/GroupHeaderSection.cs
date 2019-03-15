using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Properties;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section
{
    public class GroupHeaderSection : SectionBase
    {
        public GroupHeaderSection(DataItem dataItem) : base(dataItem)
        {
            Properties = new GroupHeaderSectionProperties(this);
        }

        public override SectionType Type => SectionType.GroupHeader;

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get { yield return Properties; }
        }

        public GroupHeaderSectionProperties Properties { get; protected set; }
    }
}
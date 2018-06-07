using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Properties;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section
{
    public class HeaderSection : SectionBase
    {
        public HeaderSection(DataItem dataItem) : base(dataItem)
        {
            Properties = new HeaderSectionProperties(this);
        }

        public override SectionType Type => SectionType.Header;

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get { yield return Properties; }
        }

        public HeaderSectionProperties Properties { get; protected set; }
    }
}
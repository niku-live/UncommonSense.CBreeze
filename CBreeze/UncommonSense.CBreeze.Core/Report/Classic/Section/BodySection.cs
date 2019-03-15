using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Properties;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section
{
    public class BodySection : SectionBase
    {
        public BodySection( DataItem dataItem) : base(dataItem)
        {
            Properties = new BodySectionProperties(this);
        }

        public override SectionType Type => SectionType.Body;

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get { yield return Properties; }
        }

        public BodySectionProperties Properties { get; protected set; }
    }
}
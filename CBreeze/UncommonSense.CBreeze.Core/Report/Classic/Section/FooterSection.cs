using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Properties;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section
{
    public class FooterSection : SectionBase
    {
        public FooterSection(DataItem dataItem) : base(dataItem)
        {
            Properties = new FooterSectionProperties(this);
        }

        public override SectionType Type => SectionType.Footer;

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get { yield return Properties; }
        }

        public FooterSectionProperties Properties { get; protected set; }
    }
}
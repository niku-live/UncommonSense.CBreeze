using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Properties;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section
{
    public class TransHeaderSection : SectionBase
    {
        public TransHeaderSection(DataItem dataItem) : base(dataItem)
        {
            Properties = new TransHeaderSectionProperties(this);
        }

        public override SectionType Type => SectionType.TransHeader;

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get { yield return Properties; }
        }

        public TransHeaderSectionProperties Properties { get; protected set; }
    }
}
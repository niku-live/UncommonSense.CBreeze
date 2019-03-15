﻿using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Properties;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section
{
    public class TransFooterSection : SectionBase
    {
        public TransFooterSection(DataItem dataItem) : base(dataItem)
        {
            Properties = new TransFooterSectionProperties(this);
        }

        public override SectionType Type => SectionType.TransFooter;

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get { yield return Properties; }
        }

        public TransFooterSectionProperties Properties { get; protected set; }
    }
}
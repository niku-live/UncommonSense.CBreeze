using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section
{
    public class Sections : Collection<SectionBase>, INode
    {
        internal Sections(DataItem dataItem)
        {
            DataItem = dataItem;
        }

        public DataItem DataItem { get; protected set; }


        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public INode ParentNode => DataItem;

        protected override void RemoveItem(int index)
        {
            this[index].Container = null;
            base.RemoveItem(index);
        }
    }
}
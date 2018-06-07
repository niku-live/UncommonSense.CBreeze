using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Report.Classic
{
    public class DataItems : IntegerKeyedAndNamedContainer<DataItem>, INode
    {
        internal DataItems(Report report)
        {
            Report = report;
        }

        public Report Report { get; protected set; }

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public INode ParentNode => Report;

        public override void ValidateName(DataItem item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, DataItem item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Container = null;
            base.RemoveItem(index);
        }
    }
}
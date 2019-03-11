using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Report.Classic;

namespace UncommonSense.CBreeze.Core.Dataport
{
    public class DataportDataItems : IntegerKeyedAndNamedContainer<DataportDataItem>, INode
    {
        internal DataportDataItems(Dataport dataport)
        {
            Dataport = dataport;
        }

        public Dataport Dataport { get; protected set; }

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public INode ParentNode => Dataport;

        public override void ValidateName(DataportDataItem item)
        {
            //TestNameNotNullOrEmpty(item);
            //TestNameUnique(item);
        }

        protected override void InsertItem(int index, DataportDataItem item)
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

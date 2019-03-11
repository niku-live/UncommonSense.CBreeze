using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Dataport
{
    public class DataportFields : IntegerKeyedAndNamedContainer<DataportField>, INode
    {
        internal DataportFields(DataportDataItem dataportDataItem)
        {
            DataportDataItem = dataportDataItem;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public INode ParentNode => DataportDataItem;

        public DataportDataItem DataportDataItem
        {
            get; protected set;
        }

        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;
        protected override bool UseAlternativeRange => (Range ?? DefaultRange).Contains(DataportDataItem.ID) || DataportDataItem.ID == 0;

        public override void ValidateName(DataportField item)
        {
        }
    }
}
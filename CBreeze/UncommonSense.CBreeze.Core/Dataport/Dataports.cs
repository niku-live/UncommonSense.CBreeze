using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Dataport
{
    public class Dataports : IntegerKeyedAndNamedContainer<Dataport>, INode
    {
        internal Dataports(Application application, IEnumerable<Dataport> dataports)
        {
            Application = application;
            AddRange(dataports);
        }

        public Application Application { get; protected set; }
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Application;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;

        public override void ValidateName(Dataport item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, Dataport item)
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

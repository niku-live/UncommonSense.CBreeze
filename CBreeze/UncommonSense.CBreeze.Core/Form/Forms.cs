using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Form
{
    public class Forms : IntegerKeyedAndNamedContainer<Form>, INode
    {
        internal Forms(Application application, IEnumerable<Form> pages)
        {
            Application = application;
            AddRange(pages);
        }

        public Application Application { get; protected set; }
        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Application;

        public override void ValidateName(Form item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, Form item)
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
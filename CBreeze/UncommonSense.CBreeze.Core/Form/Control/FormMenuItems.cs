using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Form.Control
{
    public class FormMenuItems : IntegerKeyedAndNamedContainer<FormMenuItemBase>, INode
    {
        public override IEnumerable<int> ExistingIDs =>Form.Controls.Select(c => c.ID);

        public IForm Form { get; internal set; }

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public INode ParentNode => Form;

        public override void ValidateName(FormMenuItemBase itemBase)
        {
            TestNameUnique(itemBase);
        }

        protected override void InsertItem(int index, FormMenuItemBase itemBase)
        {
            if (itemBase.ID > 0)
            {
                (itemBase as Generic.KeyedItem<int>).ID = itemBase.ID;
            }
            base.InsertItem(index, itemBase);
            itemBase.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this.ElementAt(index).Container = null;
            base.RemoveItem(index);
        }
    }
}
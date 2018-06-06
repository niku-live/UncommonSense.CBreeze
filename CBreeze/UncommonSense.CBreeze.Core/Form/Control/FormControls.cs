using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Form.Control.Properties;

namespace UncommonSense.CBreeze.Core.Form.Control
{
    public class FormControls : IntegerKeyedAndNamedContainer<FormControlBase>, INode
    {
        internal FormControls(IForm form)
        {
            Form = form;
        }

        public override IEnumerable<int> ExistingIDs =>
            Form.Controls.Select(c => c.ID);

        public IForm Form { get; protected set; }

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public IEnumerable<INode> ChildNodes => this;

        public INode ParentNode => Form;

        public override void ValidateName(FormControlBase item)
        {
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, FormControlBase item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this.ElementAt(index).Container = null;
            base.RemoveItem(index);
        }
    }
}
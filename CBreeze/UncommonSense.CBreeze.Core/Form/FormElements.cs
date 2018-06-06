using System;
using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Form
{
    public class FormElements : IntegerKeyedAndNamedContainer<FormElement>, INode
    {
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public Form Form { get; protected set; }

        public INode ParentNode => Form;
        public IEnumerable<INode> ChildNodes => this;

        public override void ValidateName(FormElement item)
        {
            throw new NotImplementedException();
        }


        protected override void InsertItem(int index, FormElement item)
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
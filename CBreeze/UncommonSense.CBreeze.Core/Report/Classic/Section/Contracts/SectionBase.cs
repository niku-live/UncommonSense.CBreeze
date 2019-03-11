using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Form.Control;
using UncommonSense.CBreeze.Core.Generic;

namespace UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts
{
    public abstract class SectionBase : IHasProperties, INode, IForm
    {
        protected SectionBase(DataItem parent)
        {
            Parent = parent;
            Controls = new FormControls(this);

        }

        public DataItem Parent { get; }

        public abstract SectionType Type { get; }

        public int Index => Container.IndexOf(this);

        public Sections Container { get; internal set; }

        public FormControls Controls { get; internal set; }

        public abstract Property.Properties AllProperties { get; }

        public INode ParentNode => Container;

        public abstract IEnumerable<INode> ChildNodes { get; }

        public int ObjectID { get; internal set; }
    }
}
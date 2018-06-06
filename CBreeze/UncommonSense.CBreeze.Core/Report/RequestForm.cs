using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Form;
using UncommonSense.CBreeze.Core.Form.Control;

namespace UncommonSense.CBreeze.Core.Report
{
    public class RequestForm : IForm
    {
        internal RequestForm(IHasRequestForm container)
        {
            Container = container;

            Properties = new FormProperties(this);

            Controls = new FormControls(this);
        }

        public Application Application => Container.Application;

        public IHasRequestForm Container { get; }
        public FormProperties Properties { get; }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Controls;
            }
        }

        public FormControls Controls { get; }
        public int ObjectID => Container.ID;
        public INode ParentNode => Container;
    }
}
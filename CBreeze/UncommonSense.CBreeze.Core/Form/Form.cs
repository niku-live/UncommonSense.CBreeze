using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Form.Control;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Form
{
    public class Form : Object, IHasCode, IForm
    {
        public Form(int id, string name) : base(id, name)
        {
            Properties = new FormProperties(this);
            Controls = new FormControls(this);
            Code = new Code.Variable.Code(this);
        }

        public FormProperties Properties { get; protected set; }


        public override ObjectType Type => ObjectType.Form;
        public override Properties AllProperties => Properties;
        public override INode ParentNode => Container;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Controls;
                yield return Code;
            }
        }

        public Forms Container { get; internal set; }
        public Application Application => Container?.Application;
        public FormControls Controls { get; }
        public int ObjectID => ID;
        public Code.Variable.Code Code { get; }
    }
}
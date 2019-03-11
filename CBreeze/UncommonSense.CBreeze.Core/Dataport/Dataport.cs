using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Core.Dataport
{
    public class Dataport : Object, IHasCode, IHasRequestForm
    {
        public Dataport(string name) : this(0, name)
        {
        }

        public Dataport(int id, string name)
            : base(id, name)
        {
            Properties = new DataportProperties(this);
            Code = new Code.Variable.Code(this);
            RequestForm = new RequestForm(this);
            DataItems = new DataportDataItems(this);
        }

        public DataportDataItems DataItems { get; internal set; }

        public override ObjectType Type => ObjectType.Dataport;

        public Dataports Container { get; internal set; }

        public DataportProperties Properties { get; protected set; }

        public override Properties AllProperties => Properties;

        public Code.Variable.Code Code { get; protected set; }

        public RequestForm RequestForm { get; protected set; }

        public Application Application => Container?.Application;

        public override INode ParentNode => Container;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return DataItems;
                yield return RequestForm;
                yield return Code;
            }
        }
    }
}
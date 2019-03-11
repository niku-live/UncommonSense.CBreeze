using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;

namespace UncommonSense.CBreeze.Core.Dataport
{
    public class DataportField : KeyedItem<int>, IHasName, IHasProperties, INode
    {
        internal DataportField(int? startPos, int? width, string sourceExpr)
        {
            StartPosition = startPos;
            Width = width;
            SourceExpr = sourceExpr;
            Properties = new DataportFieldProperties(this);
        }

        public DataportFields Container { get; internal set; }

        public override string ToString()
        {
            return string.Format("{0};{1};{2}", StartPosition, Width, SourceExpr);
        }

        public string GetName()
        {
            return ToString();
        }

        public int? StartPosition
        {
            get;
            set;
        }

        public int? Width
        {
            get;
            set;
        }

        public string SourceExpr
        {
            get;
            set;
        }

        public DataportFieldProperties Properties { get; protected set; }

        public Property.Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public INode ParentNode => Container;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }
    }
}

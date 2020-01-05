using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class XmlPortParameter : Parameter, IHasSubType
    {
        public XmlPortParameter(string name, int subType, bool var = false, int id = 0) : base(name, var, id)
        {
            SubType = subType;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public override ParameterType Type => ParameterType.XmlPort;
        public override string TypeName => $"XMLport {SubType}";
    }
}
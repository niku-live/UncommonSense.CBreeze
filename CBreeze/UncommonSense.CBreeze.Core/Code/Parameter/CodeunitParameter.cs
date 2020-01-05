using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class CodeunitParameter : Parameter, IHasSubType
    {
        public CodeunitParameter(string name, int subType, bool var = false, int id = 0) : base(name, var, id)
        {
            SubType = subType;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public override ParameterType Type => ParameterType.Codeunit;
        public override string TypeName => $"Codeunit {SubType}";
    }
}
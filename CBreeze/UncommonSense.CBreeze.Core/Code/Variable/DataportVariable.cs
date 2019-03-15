#if NAV2009
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class DataportVariable : Variable, IHasDimensions
    {
        public DataportVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public DataportVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override string TypeName => $"Dataport {SubType}";

        public string Dimensions
        {
            get;
            set;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Dataport;
            }
        }
    }
}
#endif
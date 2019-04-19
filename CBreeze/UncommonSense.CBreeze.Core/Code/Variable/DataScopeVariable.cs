using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
#if NAVBC
    public class DataScopeVariable : Variable, IHasDimensions
    {
        public DataScopeVariable(string name) : this(0, name) { }
        public DataScopeVariable(int id, string name) : base(id, name) { }
        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.DataScope;
    }
#endif
}

using System.Linq;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class TextConstant : Variable
    {
        public TextConstant(string name) : this(0, name)
        {
        }

        public TextConstant(int id, string name)
            : base(id, name)
        {
            Values = new MultiLanguageValue();
        }

        public override VariableType Type => VariableType.TextConst;
        public override string TypeName => Values.Any() ? $"TextConst '{ValuesAsText}'" : "TextConst";
        public MultiLanguageValue Values { get; protected set; }
        //TODO: (t => t.LanguageID.GetLCIDFromLanguageCode()
        public string ValuesAsText => string.Join(";", Values.OrderBy(t => t.LanguageID).Select(v => string.Format("{0}={1}", v.LanguageID, v.Value.TextConstantValue(v.LanguageID == "@@@", Values.Count()))));
    }
}
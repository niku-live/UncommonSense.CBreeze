// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TextConstant : Variable
    {
        public TextConstant(int id, string name)
            : base(id, name)
        {
            Values = new MultiLanguageValue();
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.TextConstant;
            }
        }

        public MultiLanguageValue Values
        {
            get;
            protected set;
        }
    }
}

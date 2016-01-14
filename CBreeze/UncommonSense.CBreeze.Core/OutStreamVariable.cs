using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class OutStreamVariable : Variable
    {
        public OutStreamVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.OutStream;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
#if NAV2018

    public class VerbosityVariable : Variable, IHasDimensions
    {
        public VerbosityVariable(string name) : this(0, name)
        {
        }

        public VerbosityVariable(int id, string name) : base(id, name)
        {
        }

        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.Verbosity;
    }

#endif
}
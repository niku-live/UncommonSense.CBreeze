using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core.Form.Control;

namespace UncommonSense.CBreeze.Core.Contracts
{
    public interface IForm : INode
    {
        FormControls Controls { get; }

        int ObjectID { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Core.Contracts
{
    public interface IHasRequestForm : INode
    {
        int ID { get; }
        Application Application { get; }
        RequestForm RequestForm { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Common
{
    public interface INameResolver
    {
        string ResolveName(ObjectType objectType, int objectId);
    }
}

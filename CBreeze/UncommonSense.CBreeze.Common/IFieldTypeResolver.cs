using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Common
{
    public interface IFieldTypeResolver
    {
        TableFieldType? ResolveFieldType(string tableName, string fieldName);
    }
}

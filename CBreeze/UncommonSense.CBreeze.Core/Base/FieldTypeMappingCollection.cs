using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Base
{
    public class FieldTypeMappingCollection: IFieldTypeResolver
    {
        public Dictionary<string, Dictionary<string, TableFieldType>> _mapping = new Dictionary<string, Dictionary<string, TableFieldType>>();
        
        public void RegisterTableFields(string tableName, Dictionary<string, TableFieldType> tableFields)
        {
            foreach(var pair in tableFields)
            {
                RegisterTableField(tableName, pair.Key, pair.Value);
            }
        }

        public void RegisterTableField(string tableName, string fieldName, TableFieldType fieldType)
        {
            if (!_mapping.ContainsKey(tableName))
            {
                _mapping.Add(tableName, new Dictionary<string, TableFieldType>());
            }
            if (!_mapping[tableName].ContainsKey(fieldName))
            {
                _mapping[tableName].Add(fieldName, fieldType);
            }
        }

        public TableFieldType? ResolveFieldType(string tableName, string fieldName)
        {
            if (!_mapping.ContainsKey(tableName))
            {
                return null;
            }
            var fields = _mapping[tableName];
            if (!fields.ContainsKey(fieldName))
            {
                return null;
            }
            return fields[fieldName];
        }
    }
}

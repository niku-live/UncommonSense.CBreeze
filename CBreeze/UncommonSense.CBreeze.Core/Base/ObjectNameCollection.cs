using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Base
{
    public class ObjectNameCollection : INameResolver
    {
        private Dictionary<string, string> _internalDictionary = new Dictionary<string, string>();

        private string GetObjectKey(ObjectType objectType, int objectId)
        {
            return $"{objectType} {objectId}";
        }

        public void RegisterObjectName(ObjectType objectType, int objectId, string objectName)
        {
            var key = GetObjectKey(objectType, objectId);
            if (_internalDictionary.ContainsKey(key))
            {
                return;
            }
            _internalDictionary.Add(key, objectName);
        }

        public string ResolveName(ObjectType objectType, int objectId)
        {
            var key = GetObjectKey(objectType, objectId);
            if (_internalDictionary.ContainsKey(key))
            {
                return _internalDictionary[key];
            }
            return null;
        }
    }
}

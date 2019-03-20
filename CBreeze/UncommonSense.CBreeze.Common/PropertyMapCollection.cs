using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core.Common
{
    public class PropertyMapCollection
    {
        private Dictionary<string, string> _realToDisplay = new Dictionary<string, string>();
        private Dictionary<string, string> _displayToReal = new Dictionary<string, string>();

        public void Clear()
        {
            _realToDisplay.Clear();
            _displayToReal.Clear();
        }

        public void RemoveMap(string realName)
        {
            if (_realToDisplay.ContainsKey(realName))
            {
                _displayToReal.Remove(_realToDisplay[realName]);
                _realToDisplay.Remove(realName);
            }
        }

        public void AddMap(string displayName, string realName)
        {
            if (_realToDisplay.ContainsKey(realName) || _displayToReal.ContainsKey(displayName))
            {
                throw new Exception("Mapping already exists");
            }
            _realToDisplay.Add(realName, displayName);
            _displayToReal.Add(displayName, realName);
        }

        public string GetDisplayName(string realName)
        {
            if (_realToDisplay.ContainsKey(realName))
            {
                return _realToDisplay[realName];
            }
            return realName;
        }

        public string GetRealName(string displayName)
        {
            if (_displayToReal.ContainsKey(displayName))
            {
                return _displayToReal[displayName];
            }
            return displayName;
        }
    }
}

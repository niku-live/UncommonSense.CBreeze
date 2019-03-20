using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseObjectProperty(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.ObjectPropertySignature);
            var propertyName = match.Groups[1].Value;
            propertyName = CodeStyle.CustomPropertyMappings.GetRealName(propertyName);
            var propertyValue = match.Groups[2].Value;

            Listener.OnObjectProperty(propertyName, propertyValue);
        }
    }
}

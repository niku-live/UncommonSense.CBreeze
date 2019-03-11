#if NAV2009
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Form;

namespace UncommonSense.CBreeze.Write
{
    public static class FormPropertiesWriter
    {
        public static void Write(this FormProperties formProperties, CSideWriter writer)
        {
            writer.BeginSection("PROPERTIES");

            var relevantProperties = formProperties.Where(p => p.HasValue);

            foreach (var property in relevantProperties)
            {
                var isLastProperty = (property == relevantProperties.Last());
                property.Write(isLastProperty, PropertiesStyle.Object, writer);
            }

            writer.EndSection();
        }
    }
}
#endif
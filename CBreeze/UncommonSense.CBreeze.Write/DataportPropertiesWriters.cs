#if NAV2009
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Dataport;

namespace UncommonSense.CBreeze.Write
{
    public static class DataportPropertiesWriter
    {
        public static void Write(this DataportProperties dataportProperties, CSideWriter writer)
        {
            writer.BeginSection("PROPERTIES");

            var relevantProperties = dataportProperties.Where(p => p.HasValue);

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
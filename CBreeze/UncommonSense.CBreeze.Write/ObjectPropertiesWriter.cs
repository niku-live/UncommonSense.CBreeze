using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Write
{
	public static class ObjectPropertiesWriter
	{
		public static void Write(this ObjectProperties objectProperties, CSideWriter writer)
		{
			writer.BeginSection("OBJECT-PROPERTIES");
            var dateFieldName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName("Date");
            var timeFieldName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName("Time");
            var modifiedFieldName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName("Modified");
            var versionListFieldName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName("Version List");

            writer.WriteLineIf(objectProperties.DateTime.HasValue, "{1}={0};", objectProperties.HasDateComponent? objectProperties.DateTime.ToShortDateString(writer.CodeStyle.Localization) : "", dateFieldName);
            writer.WriteLineIf(objectProperties.DateTime.HasValue, "{1}={0};", objectProperties.HasTimeComponent? objectProperties.DateTime.ToShortTimeString(writer.CodeStyle.Localization, writer.CodeStyle.UseEnclosedTimeFormat) : "", timeFieldName);
            writer.WriteLineIf(objectProperties.Modified, "{1}={0};", writer.CodeStyle.Localization.LocalizedYes, modifiedFieldName);
            writer.WriteLineIf(objectProperties.VersionList != null, "{1}={0};", objectProperties.VersionList, versionListFieldName); 
			writer.EndSection();
		}
	}
}

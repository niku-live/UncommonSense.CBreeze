#if NAV2009
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Dataport;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Write
{
    public static class DataportFieldWriter
    {
        internal static string BuildControlPart(string value, int minLength, ref int debt)
        {
            var actualLength = value.Trim().Length;
            var idealLength = Math.Max(minLength - debt, 0);
            var length = Math.Max(actualLength, idealLength);

            debt += length - minLength;

            return value.PadRight(length);
        }

        public static void Write(this DataportField dataportField, CSideWriter writer, int propertyIndentation)
        {
            var debt = 0;
            var startPos = BuildControlPart(dataportField.StartPosition.HasValue? dataportField.StartPosition.Value.ToString() : "", 5, ref debt);
            var width = BuildControlPart(dataportField.Width.HasValue? dataportField.Width.Value.ToString() : "", 5, ref debt);
            var sourceExp = BuildControlPart(dataportField.SourceExpr, 21, ref debt);
            var relevantProperties = dataportField.Properties.Where(p => p.HasValue);
            var declaration = string.Format("{{ {0};{1};{2}", startPos, width, sourceExp);

            writer.Write(declaration);
            writer.Write(relevantProperties.Any() ? ";" : " ");

            if ((writer.Column > propertyIndentation) && (relevantProperties.Any()))
            {
                writer.Indent(propertyIndentation);
                writer.WriteLine("");
            }
            else
            {
                writer.Indent(writer.Column);
            }

            relevantProperties.Write(PropertiesStyle.Field, writer);

            var lastProperty = relevantProperties.LastOrDefault();
            if (lastProperty != null)
                if (lastProperty is TriggerProperty)
                    writer.Write(new string(' ', lastProperty.Name.Length + 2));

            writer.WriteLine("}");
            writer.Unindent();
        }
    }
}
#endif
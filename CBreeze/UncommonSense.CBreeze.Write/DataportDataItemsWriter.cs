#if NAV2009
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core.Dataport;

namespace UncommonSense.CBreeze.Write
{
    public static class DataportDataItemsWriter
    {
        public static void Write(this DataportDataItems dataportDataItems, CSideWriter writer)
        {
            if (writer.CodeStyle.DoNotPrintEmptyReportDataItems)
            {
                if (!dataportDataItems.Any())
                {
                    return;
                }
            }

            writer.BeginSection("DATAITEMS");

            foreach (var dataportDataItem in dataportDataItems)
            {
                dataportDataItem.Write(writer);
            }

            writer.EndSection();
        }

        public static void Write(this DataportDataItem dataportDataItem, CSideWriter writer)
        {
            writer.Write("{ ");
            writer.Indent();
            writer.BeginSection("PROPERTIES");
            dataportDataItem.Properties.Write(PropertiesStyle.Object, writer);
            writer.EndSection();
            dataportDataItem.Fields.Write(writer);      
            writer.WriteLine(" }");
            writer.Unindent();
        }

        public static void Write(this DataportFields dataportFields, CSideWriter writer)
        {
            writer.BeginSection("FIELDS");

            foreach (var dataportField in dataportFields)
            {
                dataportField.Write(writer, 43);
            }

            writer.EndSection();
        }

        internal static string BuildReportElementPart(string value, int minLength, ref int debt)
        {
            var actualLength = value.Trim().Length;
            var idealLength = Math.Max(minLength - debt, 0);
            var length = Math.Max(actualLength, idealLength);

            debt += length - minLength;

            return value.PadRight(length);
        }

    }
}
#endif
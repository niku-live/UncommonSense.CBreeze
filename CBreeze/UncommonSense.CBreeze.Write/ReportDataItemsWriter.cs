#if NAV2009
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Report.Classic;
using UncommonSense.CBreeze.Core.Report.Classic.Section;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;

namespace UncommonSense.CBreeze.Write
{
    public static class ReportDataItemsWriter
    {
        public static void Write(this DataItems reportDataItems, CSideWriter writer)
        {
            if (writer.CodeStyle.DoNotPrintEmptyReportDataItems)
            {
                if (!reportDataItems.Any())
                {
                    return;
                }
            }

            writer.BeginSection("DATAITEMS");

            foreach (var reportDataItem in reportDataItems)
            {
                reportDataItem.Write(writer);
            }

            writer.EndSection();
        }

        public static void Write(this DataItem reportDataItem, CSideWriter writer)
        {
            writer.Write("{ ");
            writer.Indent();
            writer.BeginSection("PROPERTIES");
            reportDataItem.Properties.Write(PropertiesStyle.Object, writer);
            writer.EndSection();
            if (reportDataItem.Sections != null && reportDataItem.Sections.Any())
            {
                reportDataItem.Sections.Write(writer);
            }
            writer.WriteLine(" }");
            writer.Unindent();
        }

        public static void Write(this Sections reportDataItemSections, CSideWriter writer)
        {
            writer.BeginSection("SECTIONS");

            foreach (var reportDataItemSection in reportDataItemSections)
            {
                reportDataItemSection.Write(writer);
            }

            writer.EndSection();
        }

        public static void Write(this SectionBase reportDataItemSection, CSideWriter writer)
        {
            writer.Write("{ ");
            writer.Indent();            
            writer.BeginSection("PROPERTIES");
            reportDataItemSection.AllProperties.Where(p => p.HasValue).Write(PropertiesStyle.Object, writer);
            writer.EndSection();
            reportDataItemSection.Controls.Write(writer, 58);
            writer.WriteLine(" }");
            writer.Unindent();
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
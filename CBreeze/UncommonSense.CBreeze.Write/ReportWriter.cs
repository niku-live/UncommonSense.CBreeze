using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Write
{
    public static class ReportWriter
    {
        public static void Write(this Report report, CSideWriter writer)
        {
            writer.BeginSection(report.GetObjectSignature());
			report.ObjectProperties.Write(writer);
			report.Properties.Write(writer);
#if NAV2009
            if (report.DataItems.Any())
            {
                report.DataItems.Write(writer);
            }
#endif
            if (report.Elements.Any() || !writer.CodeStyle.DoNotPrintEmptyDatasets)
            {
                report.Elements.Write(writer);
            }
#if NAV2009
            report.RequestForm.Write(writer);
#endif
            report.RequestPage.Write(writer);
            if (report.Labels.Any() || !writer.CodeStyle.DoNotPrintEmptyLabels)
            {
                report.Labels.Write(writer);
            }
			report.Code.Write(writer);
            if (report.RdlData.CodeLines.Any() || !writer.CodeStyle.DoNotPrintEmptyRdlReportLayout)
            {
                report.RdlData.Write(writer);
            }
#if NAV2015
            if (report.WordLayout.CodeLines.Any() || !writer.CodeStyle.DoNotPrintEmptyWordReportLayout)
            {
                report.WordLayout.Write(writer);
            }
#endif
            writer.EndSection();
			writer.InnerWriter.WriteLine();
        }
    }
}

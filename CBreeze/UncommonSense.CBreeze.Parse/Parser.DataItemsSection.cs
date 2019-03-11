using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseDataItemsSection(Lines lines, ObjectType objectType)
        {
            switch (objectType)
            {
                case ObjectType.Report:
                    ParseReportDataItemsSection(lines, objectType);
                    break;
                case ObjectType.Dataport:
                    ParseDataportDataItemsSection(lines, objectType);
                    break;
            }
        }

        internal void ParseReportDataItemsSection(Lines lines, ObjectType objectType)
        {
            foreach (var chunk in lines.Chunks(Patterns.BeginClassicSection))
            {
                ParseReportDataItem(chunk, objectType);
            }
        }

        internal void ParseDataportDataItemsSection(Lines lines, ObjectType objectType)
        {
            foreach (var chunk in lines.Chunks(Patterns.BeginClassicSection))
            {
                ParseDataportDataItem(chunk, objectType);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseSectionsSection(Lines lines, ObjectType objectType)
        {
            foreach (var chunk in lines.Chunks(Patterns.BeginSection))
            {
                ParseReportSection(chunk, objectType);
            }
        }
    }
}

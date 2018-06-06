using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseFormMenuItems(Lines lines)
        {
            foreach (var chunk in lines.Chunks(Patterns.MenuItem))
            {
                ParseFormMenuItem(chunk);
            }
        }
    }
}

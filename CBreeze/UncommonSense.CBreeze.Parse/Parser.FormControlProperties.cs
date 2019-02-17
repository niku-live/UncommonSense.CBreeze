﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseFormControlProperties(Lines lines)
        {
            lines.LastLineTryMatch(Patterns.BlankLine);
            lines.LastLineMustMatch(Patterns.EndPageControl);

            foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
            {
                ParseProperty(chunk, true);
            }
        }
    }
}

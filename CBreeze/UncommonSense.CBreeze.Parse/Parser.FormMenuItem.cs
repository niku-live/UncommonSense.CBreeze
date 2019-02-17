using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal void ParseFormMenuItem(Lines lines)
		{
			var match = lines.FirstLineMustMatch(Patterns.BeginMenuItem);

			Listener.OnBeginFormMenuItem();

			lines.Unindent(2);
            lines.FirstLineTryMatch(Patterns.BlankLine);
			FormMenuItemProperties(lines);

			Listener.OnEndFormMenuItem();
		}
	}
}

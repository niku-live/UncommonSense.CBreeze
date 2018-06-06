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
			var match = lines.FirstLineMustMatch(Patterns.PageAction);
			var menuItemSeparator = match.Groups[1].Value;

			Listener.OnBeginFormMenuItem();

			if (menuItemSeparator == ";")
			{
				lines.Unindent(2);
			    FormMenuItemProperties(lines);
			}

			Listener.OnEndFormMenuItem();
		}
	}
}

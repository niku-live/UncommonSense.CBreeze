using System;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal void ParseDataPortField(Lines lines)
		{
			var match = lines.FirstLineMustMatch(Patterns.DataportField);
			var startPos = match.Groups [1].Value.ToNullableInteger();
		    var width = match.Groups[2].Value.ToNullableInteger();
			var sourceExpr = match.Groups [3].Value.TrimEnd();
			var separator = match.Groups [6].Value;

		    Listener.OnBeginDataPortField(startPos, width, sourceExpr);

			if (separator == ";")
			{
				lines.Unindent(Math.Min(match.Length, 35));
			    ParseDataPortFieldProperties(lines);
			}

			Listener.OnEndDataPortField();
		}
	}
}


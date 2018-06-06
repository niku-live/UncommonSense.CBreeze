using System;
using System.Linq;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal void ParseDataPortFieldProperties(Lines lines)
		{
			lines.LastLineMustMatch(Patterns.EndDataportField);

			foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
			{
				ParseProperty(chunk, true);
			}
		}
	}
}


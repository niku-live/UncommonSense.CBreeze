using System;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal void ParseDataPortFieldsSection(Lines lines)
		{
			foreach (var chunk in lines.Chunks(Patterns.DataportField))
			{
			    ParseDataPortField(chunk);
			}
		}
	}
}


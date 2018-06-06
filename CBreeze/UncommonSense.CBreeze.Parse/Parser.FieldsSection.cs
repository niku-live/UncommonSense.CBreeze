using System;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal void ParseTableFieldsSection(Lines lines)
		{
			foreach (var chunk in lines.Chunks(Patterns.TableField))
			{
				ParseTableField(chunk);
			}
		}
	}
}


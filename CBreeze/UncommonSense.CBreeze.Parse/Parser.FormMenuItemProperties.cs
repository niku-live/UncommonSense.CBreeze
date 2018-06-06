using System;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal void FormMenuItemProperties(Lines lines)
		{
			lines.LastLineMustMatch(Patterns.EndMenuItem);

			foreach (var chunk in lines.Chunks(Patterns.PropertySignature))
			{
				ParseProperty(chunk, true);
			}
		}
	}
}


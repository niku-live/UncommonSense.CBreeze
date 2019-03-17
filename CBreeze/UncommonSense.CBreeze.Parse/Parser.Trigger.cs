using System;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal bool ParseTrigger(Lines lines)
		{
			Match match;

			if (!lines.FirstLineTryMatch(Patterns.TriggerSignature, out match))
			{
				return false;
			}

			lines.LastLineTryMatch(Patterns.BlankLine);

			var triggerName = match.Groups [1].Value;
			var firstStatement = match.Groups [3].Value;
            bool invalidTrigger = false;

            Listener.OnBeginTrigger(triggerName);
            if (Patterns.InvalidTriggerSignature.IsMatch(firstStatement))
            {
                Listener.OnInvalidTrigger(firstStatement.Trim());
                invalidTrigger = true;
            }

            if (!invalidTrigger)
            {
                lines.Unindent(triggerName.Length + 1);

                if (firstStatement == "VAR")
                {
                    ParseLocals(lines);
                }

               ParseCodeLines(lines);
            }
            Listener.OnEndTrigger();

			return true;
		}
	}
}


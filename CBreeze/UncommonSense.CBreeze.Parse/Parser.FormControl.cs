using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        private int FindBestIndentationForFormControl(string matchOfFirstLine, Lines lines)
        {
            int result = matchOfFirstLine.Length;
            var firstLine = lines.First();
            int firstIndent = firstLine.Length - firstLine.TrimStart().Length;
            if (firstIndent < result)
            {
                result = firstIndent;
            }
            if (lines.Count() > 1)
            {
                var secondLine = lines.Skip(1).First();
                int secondIndent = secondLine.Length - secondLine.TrimStart().Length;
                if (secondIndent < result)
                {
                    result = secondIndent;
                }
            }
            return result;
        }
        internal void ParseFormControl(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.FormControl);
            var controlID = match.Groups[1].Value.ToInteger();
            var controlType = match.Groups[2].Value.ToEnum<ClassicControlType>();
            var posX = match.Groups[3].Value.ToInteger();
            var posY = match.Groups[4].Value.ToInteger();
            var width = match.Groups[5].Value.ToInteger();
            var height = match.Groups[6].Value.ToInteger();
            var controlSeparator = match.Groups[7].Value;

            Listener.OnBeginFormControl(controlID, controlType, posX, posY, width, height);

            if (controlSeparator == ";")
            {
                var indentation = FindBestIndentationForFormControl(match.Value, lines);
                lines.Unindent(indentation);
                var list = lines.ToList();
                int dedent = 0;
                foreach (var line in lines.Skip(1))
                {
                    var trimmedLine = line.TrimStart();
                    if (trimmedLine.EndsWith("=BEGIN") || trimmedLine.EndsWith("=VAR") || trimmedLine.EndsWith("=MENUITEMS") || trimmedLine.Contains("RunFormLink="))
                    {
                        dedent = line.Length - trimmedLine.Length;
                        break;
                    }

                    if (dedent == 0)
                    {
                        dedent = line.Length - trimmedLine.Length;
                    }
                    int diff = line.Length - trimmedLine.Length;
                    if ((diff > 0) && (diff < dedent))
                    {
                        dedent = diff;
                    }
                }
                lines = new Lines(list);
                lines.Unindent(dedent);
                ParseFormControlProperties(lines);
            }

            Listener.OnEndFormControl();
        }
    }
}

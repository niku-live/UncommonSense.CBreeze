using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        private bool IsMultiLineProperty(string propertyName)
        {
            if (propertyName.EndsWith("ML"))
            {
                return true;
            }                
                    
            if (propertyName.EndsWith("View"))
            {
                return true;
            }

            if (propertyName.EndsWith("Link"))
            {
                return true;
            }

            if (propertyName.EndsWith("Filter"))
            {
                return true;
            }
            
            if ((propertyName == "CalcFormula") || (propertyName == "Permissions") || (propertyName == "TableRelation") || (propertyName == "OrderBy"))
            {
                return true;
            }

            return false;
        }

        internal void ParseProperty(Lines lines, bool mayHaveTriggers)
        {
            if (mayHaveTriggers)
                if (ParseTrigger(lines))
                    return;

            var match = lines.FirstLineMustMatch(Patterns.PropertySignature);
            var propertyName = match.Groups[1].Value;
            var propertyValueFirstLine = match.Groups[3].Value;

            switch (propertyName)
            {
                case "ActionList":
                    lines.FirstLineMustMatch(Patterns.BeginSection);
                    lines.LastLineMustMatch(Patterns.EndSection);
                    lines.Unindent(2);
                    ParseActionList(lines);
                    return;
                case "Menu":
                    lines.FirstLineMustMatch(Patterns.BeginSection);
                    lines.LastLineMustMatch(Patterns.EndSection);
                    lines.Unindent(2);
                    ParseFormMenuItems(lines);
                    return;
            }

            var stringBuilder = new StringBuilder(propertyValueFirstLine);
            if (IsMultiLineProperty(propertyName))
            {               
                foreach (var line in lines)
                {
                    stringBuilder.AppendFormat(" {0}", line.TrimStart());
                }                
            }
            var propertyValue = stringBuilder.ToString().TrimEnd(";".ToCharArray());

            Listener.OnProperty(propertyName, propertyValue);
        }
    }
}
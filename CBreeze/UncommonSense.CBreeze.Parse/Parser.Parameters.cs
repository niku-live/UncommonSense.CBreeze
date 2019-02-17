using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        private IEnumerable<string> IntelligentParamsSplit(string actualValue)
        {
            int position = actualValue.IndexOf(';');
            if (position < 0)
            {
                yield return actualValue;
                yield break;
            }
            int qPosition = actualValue.IndexOf('\'');
            if (qPosition < 0)
            {
                foreach (var item in actualValue.Split(";".ToCharArray()))
                {
                    yield return item;
                }
                yield break;
            }
            StringBuilder aggr = new StringBuilder();
            bool textMode = false;
            foreach (var symbol in actualValue)
            {
                switch (symbol)
                {
                    case '\'':
                        textMode = !textMode;
                        aggr.Append(symbol);
                        break;
                    case ';':
                        if (textMode)
                        {
                            aggr.Append(symbol);
                        }
                        else
                        {
                            yield return aggr.ToString();
                            aggr.Clear();
                        }
                        break;
                    default:
                        aggr.Append(symbol);
                        break;
                }
            }
            if (aggr.Length > 0)
            {
                yield return aggr.ToString();
            }
        }

        internal void ParseParameters(Lines lines)
        {
            var match = lines.FirstLineMustMatch(Patterns.ProcedureParameters);
            var parameters = match.Groups[1].Value;

            if (string.IsNullOrEmpty(parameters))
                return;

            foreach (var parameter in IntelligentParamsSplit(parameters))
            {
                ParseParameter(parameter);
            }
        }
    }
}

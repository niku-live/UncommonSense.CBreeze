using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal bool ParseVariable(Lines lines)
        {
            var variablePattern = CodeStyle.NoVariableIds ? Patterns.VariableNoId : Patterns.Variable;
            Match match = null;
            lines.FirstLineTryMatch(Patterns.BlankLine);
            if (!lines.FirstLineTryMatch(Patterns.MultiLineTextConst, out match))
                if (!lines.FirstLineTryMatch(variablePattern, out match))
                    return false;

            var variableName = match.Groups[1].Value.TrimEnd();
            var variableID = match.Groups[2].Value.ToInteger();
            var variableType = match.Groups[3].Value;
            if (String.IsNullOrEmpty(variableType))
            {
                variableType = "TextConst";
            }
            var variableSuppressDispose = ParseSuppressDispose(ref variableType);
            var variableRunOnClient = ParseRunOnClient(ref variableType);
            var variableWithEvents = ParseWithEvents(ref variableType);
            var variableSecurityFiltering = ParseSecurityFiltering(ref variableType);
            var variableInDataSet = ParseInDataSet(ref variableType);
            var variableDimensions = ParseDimensions(ref variableType);
            var variableTemporary = ParseTemporary(ref variableType);
            var variableConstValue = ParseTextConstant(ref variableType); //.ToConstValue();
            var variableSubType = ParseVariableSubType(ref variableType);
            var variableLength = ParseVariableLength(ref variableType);
            var variableOptionString = ParseOptionString(ref variableType);

            if (variableType == "TextConst")
            {
                var stringBuilder = new StringBuilder();
                while (lines.FirstLineTryMatch(Patterns.MultiLineTextConstValue, out match))
                {
                    var languageCode = match.Groups[1].Value;
                    var languageValue = match.Groups[2].Value;
                    var separator = match.Groups[3].Value;
                    if (String.IsNullOrEmpty(separator)) //TextConst value is multiline
                    {
                        while (!lines.FirstLineTryMatch(Patterns.EndMultiLineTextConstValue, true))
                        {
                            var valuePart = lines.First();
                            lines.Consume(0, 0, valuePart.Length);
                            languageValue += valuePart + "\n";
                        }
                    }
                    stringBuilder.AppendFormat("{0}={1};", languageCode, languageValue);
                }
                variableConstValue = stringBuilder.ToString();
                if (String.IsNullOrEmpty(variableConstValue))
                {
                    lines.FirstLineTryMatch(Patterns.EndOfCodeLine, true);
                }
            }

            Listener.OnVariable(
                variableID, 
                variableName, 
                variableType.ToEnum<VariableType>(), 
                variableSubType, 
                variableLength, 
                variableOptionString, 
                variableConstValue, 
                variableTemporary, 
                variableDimensions, 
                variableRunOnClient, 
                variableWithEvents, 
                variableSecurityFiltering, 
                variableInDataSet,
                variableSuppressDispose);

            return true;
        }

        internal bool ParseRunOnClient(ref string variableType)
        {
            var match = Patterns.VariableRunOnClient.Match(variableType);

            if (match.Success)
            {
                variableType = match.Groups[1].Value;
                return true;
            }

            return false;
        }

        internal bool ParseWithEvents(ref string variableType)
        {
            var match = Patterns.VariableWithEvents.Match(variableType);

            if (match.Success)
            {
                variableType = match.Groups[1].Value;
                return true;
            }

            return false;
        }

        internal string ParseSecurityFiltering(ref string variableType)
        {
            var match = Patterns.VariableSecurityFiltering.Match(variableType);

            if (match.Success)
            {
                variableType = match.Groups[1].Value;
                return match.Groups[2].Value;
            }

            return null;
        }

        internal bool ParseInDataSet(ref string variableType)
        {
            var match = Patterns.VariableInDataSet.Match(variableType);

            if (match.Success)
            {
                variableType = match.Groups[1].Value;
                return true;
            }

            return false;
        }

        internal string ParseDimensions(ref string variableType)
        {
            var match = Patterns.VariableDimensions.Match(variableType);

            if (match.Success)
            {
                variableType = variableType.Remove(0, match.Length);
                return match.Groups[1].Value + match.Groups[2].Value;
            }

            return null;
        }

        internal bool ParseTemporary(ref string variableType)
        {
            if (variableType.StartsWith("TEMPORARY ", StringComparison.InvariantCultureIgnoreCase))
            {
                variableType = variableType.Substring("TEMPORARY ".Length);
                return true;
            }

            return false;
        }

        internal string ParseTextConstant(ref string variableType)
        {
            var match = Patterns.TextConst.Match(variableType);

            if (match.Success)
            {
                variableType = VariableType.TextConst.ToString();
                return match.Groups[1].Value;
            }

            return null;
        }

        internal string ParseVariableSubType(ref string variableType)
        {
            var match = Patterns.VariableWithSubType.Match(variableType);

            if (match.Success)
            {
                variableType = match.Groups[1].Value;
                return match.Groups[2].Value;
            }

            return null;
        }

        internal int? ParseVariableLength(ref string variableType)
        {
            var match = Patterns.VariableWithLength.Match(variableType);

            if (match.Success)
            {
                variableType = match.Groups[1].Value;
                return match.Groups[2].Value.ToInteger();
            }

            return null;
        }

        internal string ParseOptionString(ref string variableType)
        {
            string result = null;

            if (variableType.StartsWith("'"))
            {
                result = variableType.Trim("'".ToCharArray());
                variableType = "Option";
            }

            return result;
        }
    }
}

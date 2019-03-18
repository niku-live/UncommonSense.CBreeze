﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal bool ParseMultiLineTextConstant(Lines lines)
        {
            Match match = null;

            if (!lines.FirstLineTryMatch(Patterns.MultiLineTextConst, out match))
                return false;

            var variableName = match.Groups[1].Value;
            var variableID = match.Groups[2].Value.ToInteger();
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

            Listener.OnVariable(variableID, variableName, VariableType.TextConst, "", null, null, stringBuilder.ToString(), false, null, false, false, null, false, false);

            return true;
        }
    }
}

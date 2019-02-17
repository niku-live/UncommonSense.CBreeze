﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseReturnValue(Lines lines)
        {
            if (lines.FirstLineTryMatch(Patterns.ProcedureNoReturnValue))
                return;

            var match = lines.FirstLineMustMatch(Patterns.ProcedureReturnValue);
            var returnValueName = match.Groups[1].Value.Trim();
            var returnValueType = match.Groups[5].Value;
            var returnValueLength = ParseVariableLength(ref returnValueType);
            var returnValueDimensions = ParseDimensions(ref returnValueType);

            Listener.OnReturnValue(returnValueName, returnValueType.ToEnum<FunctionReturnValueType>(), returnValueLength, returnValueDimensions);
        }
    }
}

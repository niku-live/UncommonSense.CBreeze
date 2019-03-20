﻿using System;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		internal void ParseTableField(Lines lines)
		{
			var match = lines.FirstLineMustMatch(Patterns.TableField);
			var fieldNo = match.Groups [1].Value.ToInteger();
			var fieldEnabled = match.Groups [2].Value.ToNullableBoolean(CodeStyle.LocalizedYes, CodeStyle.LocalizedNo);
			var fieldName = match.Groups [3].Value.TrimEnd();
			var fieldType = match.Groups [4].Value.TrimEnd();
			var fieldLength = ParseFieldLength(ref fieldType);
			var separator = match.Groups [5].Value;

			Listener.OnBeginTableField(fieldNo, fieldEnabled, fieldName, fieldType.ToEnum<TableFieldType>(), fieldLength);

			if (separator == ";")
			{
				lines.Unindent(Math.Min(match.Length, 47));
				ParseTableFieldProperties(lines);
			}

			Listener.OnEndTableField();
		}

		internal int ParseFieldLength(ref string fieldType)
		{
			var match = Regex.Match(fieldType, @"^(\D+)(\d+)$");

			if (match.Success)
			{
				fieldType = match.Groups [1].Value;
				return match.Groups [2].Value.ToInteger();
			}

			return 0;
		}
	}
}


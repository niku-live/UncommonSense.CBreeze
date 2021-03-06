﻿using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Core.Common;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public static class StringExtensionMethods
    {
        public static string ForceQuoted(this string text)
        {
            return string.Format("\"{0}\"", text);
        }

        public static string MakePlural(this string text)
        {
            if (text.EndsWith("y"))
                return Regex.Replace(text, "y$", "ies");

            if (text.EndsWith("s") || text.EndsWith("ch") || text.EndsWith("sh"))
                return string.Format("{0}es", text);

            if (text.EndsWith("f") || text.EndsWith("fe"))
                return Regex.Replace(text, "fe?$", "ves");

            return string.Format("{0}s", text);
        }

        public static string MakeVariableName(this string text)
        {
            text = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text);

            return new string((from c in text
                               where Char.IsLetterOrDigit(c)
                               select c).ToArray());
        }

        public static string Quoted(this string text)
        {
            if (text.All(c => Char.IsLetterOrDigit(c)))
                return text;

            return ForceQuoted(text);
        }

        public static bool IsAnsiLetter(this char c)
        {
            return c < 'z';
        }

        public static string QuotedTableName(this string text, ApplicationCodeStyle codeStyle)
        {
            return text.QuotedExcept(!codeStyle.NonAnsiLettersAllowedInTableName, codeStyle.TableNameExceptions);
        }

        public static string QuotedFieldName(this string text, ApplicationCodeStyle codeStyle)
        {
            return text.QuotedExcept(false, codeStyle.FieldNameExceptions);
        }

        public static bool IsAsciiLetter(this char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }

        public static string QuotedExcept(this string text, bool onlyAnsiLetters, params char[] exceptions)
        {
            // In e.g. CalcFormulas, table names containing no other special characters than a hyphen
            // (e.g. "To-do") should not be quoted In e.g. TableRelations, table names containing no
            // other special characters than a slash (e.g. "Country/Region") should not be quoted In
            // e.g. TableRelations, field names containing no other special characters than a dot
            // (e.g. "No.") should not be quoted
            if (text.All(c => (char.IsLetterOrDigit(c) && (!onlyAnsiLetters || c.IsAsciiLetter())) || exceptions.Contains(c)))
                return text;

            return text.ForceQuoted();
        }

        public static string TextConstantValue(this string text, bool isComment, int noOfValues)
        {
            var needsQuotes = (text.Trim() != text) || (text.Contains(';') || text.Contains("=") || text.StartsWith("\"") || String.IsNullOrEmpty(text));

            if (isComment && noOfValues < 2)
                needsQuotes = false;

            switch (needsQuotes)
            {
                case true:
                    return text.ForceQuoted();

                default:
                    return text;
            }
        }
    }
}
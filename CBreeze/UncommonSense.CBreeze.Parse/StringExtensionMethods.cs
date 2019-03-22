using System;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
	internal static class StringExtensionMethods
	{
        public static T ToEnum<T>(this string text, bool ignoreCase = true, bool normalize = true) where T : struct
        {
            if (!typeof(T).IsEnum)
                Exceptions.ThrowException(Exceptions.MustBeAnEnumeratedType, "T");

            if (normalize)
            {
                text = Regex.Replace(text, @"[\s-\.]", string.Empty);
            }

            return (T)Enum.Parse(typeof(T), text, ignoreCase);
        }

        public static Nullable<T> ToNullableEnum<T>(this string text, bool ignoreCase = true, bool normalize = true) where T : struct
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return text.ToEnum<T>(ignoreCase, normalize);
        }

		internal static SectionType ToSectionType(this string text)
		{
			text = Regex.Replace(text, "[^A-Z]", string.Empty);

			return (SectionType)Enum.Parse(typeof(SectionType), text, true);
		}

        internal static MenuSuiteNodeType ToMenuSuiteNodeType(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return MenuSuiteNodeType.Delta;

            return text.ToEnum<MenuSuiteNodeType>();
        }

        internal static Guid ToGuid(this string text)
        {
            return new Guid(text);
        }

		internal static int ToInteger(this string text)
		{
            int result = 0;
			if (!int.TryParse(text, out result))
            {
                return 0;
            }
            return result;
		}

        internal static bool? ToNullableBoolean(this string text, Localization localization) => localization.ConvertTextToBool(text);

        internal static int? ToNullableInteger(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return text.ToInteger();
        }

        internal static string UnIndent(this string text, int unindent)
        {
            switch (string.IsNullOrEmpty(text))
            {
                case true:
                    return text;
                default:
                    return text.Substring(unindent);
            }
        }
	}
}


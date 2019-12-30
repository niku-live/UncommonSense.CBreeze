using System;
using System.Drawing;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Common;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Type;

namespace UncommonSense.CBreeze.Read
{
    public static class StringExtensionMethods
    {
        public static BorderWidth ToBorderWidth(this string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (Char.IsDigit(text[0]))
            {
                text = "Item" + text;
            }
            return ToEnum<BorderWidth>(text);
        }

        public static T ToEnum<T>(this string text, bool ignoreCase = true, bool normalize = true, Application app = null) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(GetTranslatedString("T must be an enumerated type."));

            if (normalize) text = Regex.Replace(text, @"[\s-\.]", string.Empty);

            var mappings = app?.CodeStyle.GetEnumMapping<T>();
            if (mappings != null)
            {
                text = mappings.GetRealName(text);
            }

            return (T) Enum.Parse(typeof(T), text, ignoreCase);
        }

        public static T? ToNullableEnum<T>(this string text, bool ignoreCase = true, bool normalize = true)
            where T : struct
        {
#if NAV2016
            // Handle eventing attributes
            if (text == "DEFAULT")
                return null;
#endif

            if (string.IsNullOrWhiteSpace(text))
                return null;

            return text.ToEnum<T>(ignoreCase, normalize);
        }

        public static bool IsValidEnumValue<T>(this string text, bool ignoreCase = true, bool normalize = true)
            where T : struct
        {
            try
            {
                var enumValue = text.ToEnum<T>(ignoreCase, normalize);
                return true;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception)
            {
                return false;
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        public static AutoFormatType ToAutoFormatType(this string text)
        {
            return (AutoFormatType) text.ToInteger();
        }

        public static FormatEvaluate ToFormatEvaluate(this string text)
        {
            switch (text)
            {
                case "XML Format/Evaluate":
                    return FormatEvaluate.XmlFormatEvaluate;
                case "C/SIDE Format/Evaluate":
                    return FormatEvaluate.CSideFormatEvaluate;
                default:
                    throw new ArgumentOutOfRangeException(text);
            }
        }

        public static bool ToBoolean(this string text, Localization localization) => ToNullableBoolean(text, localization, true).GetValueOrDefault();

        public static int ToInteger(this string text, IFormatProvider formatProvider = null)
        {
            return int.Parse(text, PrepareFormatProvider(formatProvider));
        }

        public static bool? ToNullableBoolean(this string text, Localization localization, bool strict = false) => localization?.ConvertTextToBool(text, strict);

        public static decimal? ToNullableDecimal(this string text, Localization localization) => localization?.ConvertTextToNullableDecimal(text);

        public static Guid? ToNullableGuid(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            text = ApplicationExtensionMethods.RemoveSurroundingSquareBrackets(text);

            return new Guid(text);
        }

        public static long? ToNullableBigInteger(this string text, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return long.Parse(text, PrepareFormatProvider(formatProvider));
        }

        public static int? ToNullableInteger(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            if (!int.TryParse(text, out int value))
            {
                return null;
            }
            return value;
        }

        public static TimeSpan? ToNullableTime(this string text, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return TimeSpan.Parse(text, PrepareFormatProvider(formatProvider));
        }

        public static DateTime? ToNullableDateTime(this string text, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return DateTime.Parse(text, PrepareFormatProvider(formatProvider));
        }

        public static int? ToPageReference(this string text, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            var match = Regex.Match(text, @"Page(\d+)");

            if (!match.Success)
                throw new ArgumentOutOfRangeException(string.Format(PrepareFormatProvider(formatProvider), "Invalid page reference: {0}.", text));

            return match.Groups[1].Value.ToInteger();
        }

        public static int? ToFormReference(this string text, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            var match = Regex.Match(text, @"Form(\d+)");

            if (!match.Success)
                throw new ArgumentOutOfRangeException(string.Format(PrepareFormatProvider(formatProvider), "Invalid form reference: {0}.", text));

            return match.Groups[1].Value.ToInteger();
        }

        public static int? ToTableReference(this string text, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            var match = Regex.Match(text, @"Table(\d+)");

            if (!match.Success)
                throw new ArgumentOutOfRangeException(string.Format(PrepareFormatProvider(formatProvider), "Invalid table reference: {0}.", text));

            return match.Groups[1].Value.ToInteger();
        }

        public static Color ToColor(this string text, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return Color.FromArgb(100, 100, 100);

            var integer = int.Parse(text, PrepareFormatProvider(formatProvider));
            var buffer = BitConverter.GetBytes(integer);

            var red = (int) buffer[0];
            var green = (int) buffer[1];
            var blue = (int) buffer[2];

            var color = Color.FromArgb(red, green, blue);
            return color;
        }

        public static uint? ToNullableUnsignedInteger(this string text, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return uint.Parse(text, PrepareFormatProvider(formatProvider));
        }

        private static IFormatProvider PrepareFormatProvider(IFormatProvider specifiedProvider) => GlobalFormatProvider.CurrentFormatProvider.ResolveFormatProvider(specifiedProvider);

        private static string GetTranslatedString(string originalString) => GlobalFormatProvider.CurrentFormatProvider.GetTranslatedString(originalString);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core.Common;

namespace UncommonSense.CBreeze.Common
{
    public class Localization
    {
        public static readonly Localization Default = new Localization();

        public Encoding TextEncoding { get; protected set; } = Encoding.GetEncoding("ibm850");

        public string DateFormat { get; protected set; } = "dd-MM-yy";
        public string DateTimeFormat { get; protected set; } = "dd-MM-yy HH:mm";
        public string TimeFormat { get; protected set; } = "HH:mm:ss";
        public System.Globalization.NumberFormatInfo DecimalFormat { get; protected set; }

        public string LocalizedYes { get; protected set; } = "Yes";
        public string LocalizedNo { get; protected set; } = "No";

        public PropertyMapCollection CustomPropertyMappings { get; private set; } = new PropertyMapCollection();
        internal Dictionary<Type, PropertyMapCollection> EnumCustomMapping { get; private set; } = new Dictionary<Type, PropertyMapCollection>();
        internal Dictionary<Type, PropertyMapCollection> EnumTextCustomMapping { get; private set; } = new Dictionary<Type, PropertyMapCollection>();

        public PropertyMapCollection GetEnumMapping<T>(bool forTextValuePrinting = false)
        {
            return forTextValuePrinting ? GetEnumTextMapping(typeof(T)) : GetEnumMapping(typeof(T));
        }

        public PropertyMapCollection GetEnumMapping(Type enumType)
        {
            if (!EnumCustomMapping.ContainsKey(enumType))
            {
                EnumCustomMapping.Add(enumType, new PropertyMapCollection());
            }
            return EnumCustomMapping[enumType];
        }

        public PropertyMapCollection GetEnumTextMapping(Type enumType)
        {
            if (!EnumTextCustomMapping.ContainsKey(enumType))
            {
                EnumTextCustomMapping.Add(enumType, new PropertyMapCollection());
            }
            return EnumTextCustomMapping[enumType];
        }

        private bool IsYesText(string text)
        {
            return text.ToLowerInvariant() == LocalizedYes.ToLowerInvariant();
        }

        private bool IsNoText(string text)
        {
            return text.ToLowerInvariant() == LocalizedNo.ToLowerInvariant();
        }

        public DateTime? ConvertTextToDate(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            return DateTime.ParseExact(text, DateFormat, System.Globalization.CultureInfo.InvariantCulture).Date;
        }

        public TimeSpan? ConvertTextToTimeSpan(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            if (text.StartsWith("["))
            {
                text = "0" + text.Substring(1, text.Length - 2).Trim();
            }
            return DateTime.ParseExact(text, TimeFormat, System.Globalization.CultureInfo.InvariantCulture).TimeOfDay;
        }

        public string ConvertDateTimeToLongDateString(DateTime? dateTime, bool isNullable = true)
        {
            if (!dateTime.HasValue && isNullable)
                return null;

            return dateTime.GetValueOrDefault().ToString(DateTimeFormat);
        }

        public string ConvertDateTimeToShortDateString(DateTime? dateTime, bool isNullable = true)
        {
            if (!dateTime.HasValue && isNullable)
                return null;

            return dateTime.GetValueOrDefault().ToString(DateFormat);
        }

        public string ConvertDateTimeToShortTimeString(DateTime? dateTime, bool useEnclosedFormat = false)
        {
            if (!dateTime.HasValue)
                return null;
            var result = dateTime.Value.ToString(TimeFormat);
            if (result.StartsWith("0") && useEnclosedFormat)
            {
                result = "[ " + result.Substring(1) + "]";
            }
            return result;
        }

        public decimal? ConvertTextToNullableDecimal(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            if (this.DecimalFormat != null)
            {
                return decimal.Parse(text, DecimalFormat);
            }
            return decimal.Parse(text);
        }

        public string ConvertDecimalToString(decimal? actualValue)
        {
            var value = actualValue.GetValueOrDefault();
            var stringValue = value.ToString();
            if (DecimalFormat != null)
            {
                if (value % 1 == 0)
                {
                    stringValue = value.ToString("N0", DecimalFormat);
                }
                else
                {
                    stringValue = value.ToString();// "N2", writer.CodeStyle.DecimalFormat);
                }
            }
            return stringValue;
        }

        public string ConvertBoolToString(bool? actualValue)
        {
            if (!actualValue.HasValue)
            {
                return null;
            }
            return actualValue.GetValueOrDefault() ? LocalizedYes : LocalizedNo;
        }

        public bool? ConvertTextToBool(string text, bool strict = false)
        {
            var value = text.Trim().ToLowerInvariant();
            if (IsYesText(value))
            {
                return true;
            }
            else if (strict)
            {
                return false;
            }
            if (IsNoText(value))
            {
                return false;
            }

            switch (value)
            {
                case "yes":
                    return true;
                case "true":
                    return true;
                case "no":
                    return false;
                case "false":
                    return false;
                default:
                    return null;
            }
        }

    }
}

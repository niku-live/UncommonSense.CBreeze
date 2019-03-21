using System;
using System.Globalization;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Read
{
	internal static class DateTimeExtensionMethods
	{
        internal static DateTime? ToFormattedDate(this string text, Localization localization)
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            return DateTime.ParseExact(text, localization.DateFormat, CultureInfo.InvariantCulture).Date;
        }

        internal static TimeSpan? ToFormattedTimeSpan(this string text, Localization localization)
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            if (text.StartsWith("["))
            {
                text = "0" + text.Substring(1, text.Length - 2).Trim();
            }
            return DateTime.ParseExact(text, localization.TimeFormat, CultureInfo.InvariantCulture).TimeOfDay;
            //return TimeSpan.ParseExact(text, timeFormat, CultureInfo.InvariantCulture);
        }

        internal static DateTime? SetDateComponent(this DateTime? dateTime, string text, Localization localization)
		{
            if (!string.IsNullOrEmpty(text))
            {
                var time = dateTime.GetValueOrDefault(DateTime.MinValue).TimeOfDay;
                var date = text.ToFormattedDate(localization).GetValueOrDefault(DateTime.MinValue);
                return date.Add(time);
            }

            return dateTime;
		}

        internal static DateTime? SetTimeComponent(this DateTime? dateTime, string text, Localization localization)
		{
            if (!string.IsNullOrEmpty(text))
            {
                var date = dateTime.GetValueOrDefault(DateTime.MinValue).Date;
                var time = text.ToFormattedTimeSpan(localization).GetValueOrDefault(new System.TimeSpan(0, 0, 0, 0, 0));
                return date.Add(time);
            }

            return dateTime;
		}

	}
}


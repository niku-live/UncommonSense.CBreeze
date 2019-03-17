using System;
using System.Globalization;

namespace UncommonSense.CBreeze.Read
{
	internal static class DateTimeExtensionMethods
	{
        internal static DateTime? ToFormattedDate(this string text, string dateFormat = "dd-MM-yy")
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            return DateTime.ParseExact(text, dateFormat, CultureInfo.InvariantCulture).Date;
        }

        internal static TimeSpan? ToFormattedTimeSpan(this string text, string timeFormat = @"hh\:mm\:ss")
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }
            return TimeSpan.ParseExact(text, timeFormat, CultureInfo.InvariantCulture);
        }

        internal static DateTime? SetDateComponent(this DateTime? dateTime, string text, string dateFormat = "dd-MM-yy")
		{
            if (!string.IsNullOrEmpty(text))
            {
                var time = dateTime.GetValueOrDefault(DateTime.MinValue).TimeOfDay;
                var date = text.ToFormattedDate(dateFormat).GetValueOrDefault(DateTime.MinValue);
                return date.Add(time);
            }

            return dateTime;
		}

        internal static DateTime? SetTimeComponent(this DateTime? dateTime, string text)
		{
            if (!string.IsNullOrEmpty(text))
            {
                var date = dateTime.GetValueOrDefault(DateTime.MinValue).Date;
                var time = text.ToFormattedTimeSpan().GetValueOrDefault(new System.TimeSpan(0, 0, 0, 0, 0));
                return date.Add(time);
            }

            return dateTime;
		}

	}
}


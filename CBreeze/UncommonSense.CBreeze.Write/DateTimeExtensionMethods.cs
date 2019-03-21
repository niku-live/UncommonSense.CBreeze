using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Write
{
    public static class DateTimeExtensionMethods
    {
        public static string ToShortDateString(this DateTime? dateTime, Localization localization)
        {
            if (!dateTime.HasValue)
                return null;
            
            return dateTime.Value.ToString(localization.DateFormat);
        }

        public static string ToShortTimeString(this DateTime? dateTime, Localization localization, bool useEnclosedFormat = false)
        {
            if (!dateTime.HasValue)
                return null;
            var result = dateTime.Value.ToString(localization.TimeFormat);
            if (result.StartsWith("0") && useEnclosedFormat)
            {
                result = "[ " + result.Substring(1) + "]";
            }
            return result;
        }
    }
}

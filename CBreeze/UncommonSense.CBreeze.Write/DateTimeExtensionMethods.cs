using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Write
{
    public static class DateTimeExtensionMethods
    {
        public static string ToShortDateString(this DateTime? dateTime, Localization localization) => localization.ConvertDateTimeToShortDateString(dateTime);

        public static string ToShortTimeString(this DateTime? dateTime, Localization localization, bool useEnclosedFormat = false) => localization.ConvertDateTimeToShortTimeString(dateTime, useEnclosedFormat);
    }
}

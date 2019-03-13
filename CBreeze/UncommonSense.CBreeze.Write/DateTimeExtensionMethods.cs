using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Write
{
    public static class DateTimeExtensionMethods
    {
        public static string ToShortDateString(this DateTime? dateTime, string dateFormat = "dd-MM-yy")
        {
            if (!dateTime.HasValue)
                return null;
            
            return dateTime.Value.ToString(dateFormat);
        }

        public static string ToShortTimeString(this DateTime? dateTime, string timeFormat = "HH:mm:ss")
        {
            if (!dateTime.HasValue)
                return null;
            return dateTime.Value.ToString(timeFormat);
        }
    }
}

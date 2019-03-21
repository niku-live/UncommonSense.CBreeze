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


        public Encoding TextEncoding { get; set; } = Encoding.GetEncoding("ibm850");

        public string DateFormat { get; set; } = "dd-MM-yy";
        public string DateTimeFormat { get; set; } = "dd-MM-yy HH:mm";
        public string TimeFormat { get; set; } = "HH:mm:ss";
        public System.Globalization.NumberFormatInfo DecimalFormat { get; set; }

        public string LocalizedYes { get; set; } = "Yes";
        public string LocalizedNo { get; set; } = "No";

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

        public bool IsYesText(string text)
        {
            return text.ToLowerInvariant() == LocalizedYes.ToLowerInvariant();
        }

        public bool IsNoText(string text)
        {
            return text.ToLowerInvariant() == LocalizedNo.ToLowerInvariant();
        }

    }
}

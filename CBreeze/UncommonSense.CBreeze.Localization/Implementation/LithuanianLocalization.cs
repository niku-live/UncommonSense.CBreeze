using System.Text;

namespace UncommonSense.CBreeze.Localization.Implementation
{
    internal class LithuanianLocalization : Common.Localization
    {
        internal LithuanianLocalization(bool translateProperties) : base()
        {
            TextEncoding = Encoding.GetEncoding(775);            
            DateFormat = "yy.MM.dd";
            TimeFormat = @"HH\:mm\:ss";
            DateTimeFormat = "yy.MM.dd HH:mm";
            DecimalFormat = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.Clone() as System.Globalization.NumberFormatInfo;
            DecimalFormat.NumberGroupSeparator = ".";

            if (!translateProperties)
            {
                return;
            }

            LocalizedYes = "Taip";
            LocalizedNo = "Ne";
            CustomPropertyMappings.AddMap("Data", "Date");
            CustomPropertyMappings.AddMap("Laikas", "Time");
            CustomPropertyMappings.AddMap("Versijos", "Version List");
            CustomPropertyMappings.AddMap("Pakeista", "Modified");
            var blobTypeMap = GetEnumMapping<Core.Property.Type.BlobSubType>();
            var blobTypeTextMap = GetEnumMapping<Core.Property.Type.BlobSubType>(true);
            blobTypeMap.AddMap("Paveikslėlis", "Bitmap");
            blobTypeTextMap.AddMap("Paveikslėlis", "Bitmap");
            blobTypeMap.AddMap("Memolaukas", "Memo");
            blobTypeTextMap.AddMap("Memo laukas", "Memo");
            blobTypeMap.AddMap("Vartotojoapibr", "UserDefined");
            blobTypeTextMap.AddMap("Vartotojo apibr.", "User-Defined");

        }
    }
}

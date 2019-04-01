using System;

namespace UncommonSense.CBreeze.Localization
{
    public class Localizations
    {
        private static Common.Localization GetLocalizationTemplate(int majorVersion, string cultureName, bool translateProperties)
        {
            switch (cultureName)
            {
                case "lt-LT":
                    return new Implementation.LithuanianLocalization(majorVersion, translateProperties);
            }

            return Common.Localization.Default;
        }

        public static Common.Localization GetLocalization(int majorVersion, string cultureName, bool translateProperties)
        {
            var template = GetLocalizationTemplate(majorVersion, cultureName, translateProperties);
            template.ActiveCultureInfo = System.Globalization.CultureInfo.GetCultureInfo(cultureName) ?? System.Globalization.CultureInfo.InvariantCulture;
            return template;
        }

        public static Core.Common.ApplicationCodeStyle GetLocalizedCodeStyle(string navName = "NAV2018", string cultureName = null, bool translateProperties = false)
        {
            var codeStyle = Core.Common.ApplicationCodeStyle.CreateNavCodeStyle(navName);
            codeStyle.Localization = GetLocalization(codeStyle.PlatformVersion.MajorVersion, cultureName, translateProperties && (codeStyle.PlatformVersion.MajorVersion < 6));
            return codeStyle;
        }

    }
}

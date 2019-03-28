using System;

namespace UncommonSense.CBreeze.Localization
{
    public class Localizations
    {
        public static Common.Localization GetLocalization(string cultureName, bool translateProperties)
        {
            switch (cultureName)
            {
                case "lt-LT":
                    return new Implementation.LithuanianLocalization(translateProperties);
            }

            return Common.Localization.Default;
        }

        public static Core.Common.ApplicationCodeStyle GetLocalizedCodeStyle(string navName = "NAV2018", string cultureName = null, bool translateProperties = false)
        {
            var codeStyle = Core.Common.ApplicationCodeStyle.CreateNavCodeStyle(navName);
            codeStyle.Localization = GetLocalization(cultureName, translateProperties && (codeStyle.PlatformVersion.MajorVersion < 6));
            return codeStyle;
        }

    }
}

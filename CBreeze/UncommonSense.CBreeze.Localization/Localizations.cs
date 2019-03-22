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

    }
}

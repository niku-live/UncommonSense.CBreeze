using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core.Base
{
    public class GlobalFormatProvider
    {
        private GlobalFormatProvider()
        {

        }

        private static GlobalFormatProvider _globalFormatProvider = null;
        public static GlobalFormatProvider CurrentFormatProvider
        {
            get => _globalFormatProvider ?? (_globalFormatProvider = new GlobalFormatProvider());
        }

        public IFormatProvider ResolveFormatProvider(IFormatProvider specifiedProvider)
        {
            if (specifiedProvider != null)
            {
                return specifiedProvider;
            }

            //TODO
            return new System.Globalization.CultureInfo("lt-LT");
        }

        public string GetTranslatedString(string originalString)
        {
            //TODO
            return originalString;
        }

        public string GetFormattedTranslatedString(string originalString, params object[] args)
        {
            return string.Format(GetTranslatedString(originalString), args);
        }
    }
}

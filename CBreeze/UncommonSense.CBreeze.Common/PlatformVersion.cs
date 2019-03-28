using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Common
{
    public class PlatformVersion
    {
        public PlatformVersion(Version version)
        {
            Version = version;
        }

        public PlatformVersion(string versionName) : this(VersionNameToVersion(versionName)) { }

        public Version Version { get; set; }

        public int MajorVersion => Version.Major;
        public int MinorVersion => Version.Minor;
        public int Build => Version.Build;
        public int AppVersion => MajorVersion * 100 + MinorVersion;
        public int SmallAppVersion => AppVersion / 10;


        public string AppName
        {
            get
            {
                if (MajorVersion > 11)
                {
                    return "Dynamics 365 Business Central";
                }
                if (MajorVersion > 4)
                {
                    return "Dynamics NAV";
                }

                if (MajorVersion == 4)
                {
                    return "Microsoft Business Solutions NAV";
                }

                if (MajorVersion < 3)
                {
                    return "Navision Financials";
                }

                if (MinorVersion >= 70)
                {
                    return "Microsoft Business Solutions Navision";
                }

                return "Navision Attain";
            }
        }

        public string VersionName
        {
            get
            {
                if (MajorVersion > 11)
                {
                    return $"R{MinorVersion - 12}";
                }

                if (MajorVersion >= 8)
                {
                    return $"20{MajorVersion + 7}";
                }

                string name = "";
                if (MajorVersion == 7)
                {
                    name = "2013";
                }
                else if (MajorVersion == 6)
                {
                    name = "2009";
                }
                else
                {
                    name = MajorVersion.ToString();
                }

                if (MinorVersion > 0)
                {
                    if (MajorVersion < 6)
                    {
                        name = name + $".{MinorVersion}";
                    }
                    else
                    {
                        name = name + "R2";
                    }
                }

                return name;
            }
        }

        public string FullName => $"{AppName} {VersionName}";

        public string FullNameWithBuild => Version.Build > 0 ? $"{FullName} (Build {Version.Build})" : FullName;

        public override string ToString() => FullNameWithBuild;

        private static Version VersionNameToVersion(string versionName)
        {
            versionName = versionName.Trim().ToLower();
            if (versionName.StartsWith("nav"))
            {
                versionName = versionName.Substring(3);
            }
            int minVersion = 20;
            if (versionName.StartsWith("bc"))
            {
                minVersion = 130;
                versionName = versionName.Substring(2);
            }
            int version = 0;
            bool r2 = false;
            if (versionName.Contains("r2"))
            {
                versionName = versionName.Replace("r2", "");
            }

            if (!int.TryParse(versionName.Trim(), out version))
            {
                version = minVersion;
            }
            else
            {
                version *= 10;
            }

            if (version > 20000)
            {
                switch (version)
                {
                    case 2013:
                        version = 70;
                        break;
                    case 2015:
                        version = 80;
                        break;
                    case 2016:
                        version = 90;
                        break;
                    case 2017:
                        version = 100;
                        break;
                    case 2018:
                        version = 110;
                        break;
                    default:
                        version = 130;
                        break;
                }

            }
            if (r2)
            {
                version += 1;
            }
            return new Version(version / 10, version % 10, 0);
        }


    }
}

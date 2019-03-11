﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Base;

namespace UncommonSense.CBreeze.Write
{
    public static class ApplicationWriter
    {
        public static void WriteToCSideWriter(this Application application, CSideWriter writer)
        {
            application.Tables.Write(writer);
#if NAV2009
            application.Forms.Write(writer);
#endif
            application.Reports.Write(writer);
            application.Codeunits.Write(writer);
            application.XmlPorts.Write(writer);
            application.MenuSuites.Write(writer);
            application.Pages.Write(writer);
            application.Queries.Write(writer);
        }

        public static FileInfo WriteToFile(this Application application, string fileName, Encoding fileEncoding)
        {
            fileEncoding = fileEncoding ?? Encoding.GetEncoding("ibm850");
            using (var streamWriter = new StreamWriter(fileName, false, fileEncoding))
            {
                application.WriteToTextWriter(streamWriter);
            }

            return new FileInfo(fileName);
        }

        public static void WriteToStdOut(this Application application)
        {
            application.WriteToTextWriter(Console.Out);
        }

        public static void WriteToStream(this Application application, Stream stream, Encoding fileEncoding)
        {
            fileEncoding = fileEncoding ?? Encoding.GetEncoding("ibm850");
            using (var streamWriter = new StreamWriter(stream, fileEncoding))
            {
                application.WriteToTextWriter(streamWriter);
            }
        }

        public static void WriteToTextWriter(this Application application, TextWriter textWriter)
        {
            application.WriteToCSideWriter(new CSideWriter(textWriter));
        }
    }
}
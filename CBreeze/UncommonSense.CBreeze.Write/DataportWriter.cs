#if NAV2009
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Dataport;

namespace UncommonSense.CBreeze.Write
{
    public static class DataportWriter
    {
        public static void Write(this Dataport dataport, CSideWriter writer)
        {
            writer.BeginSection(dataport.GetObjectSignature());
            dataport.ObjectProperties.Write(writer);
            dataport.Properties.Write(writer);
            dataport.DataItems.Write(writer);
            dataport.Code.Write(writer);
            writer.EndSection();
            writer.InnerWriter.WriteLine();
        }
    }
}
#endif
#if NAV2009
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Form;

namespace UncommonSense.CBreeze.Write
{
    public static class FormWriter
    {
        public static void Write(this Form form, CSideWriter writer)
        {
            writer.BeginSection(form.GetObjectSignature());
            form.ObjectProperties.Write(writer);
            form.Properties.Write(writer);
            form.Controls.Write(writer, 49);
            form.Code.Write(writer);
            writer.EndSection();
            writer.InnerWriter.WriteLine();
        }
    }
}
#endif
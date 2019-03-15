#if NAV2009
using System.Linq;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Write
{
    public static class RequestFormWriter
    {
        public static void Write(this RequestForm requestForm, CSideWriter writer)
        {
            if (writer.CodeStyle.DoNotPrintEmptyRequestForm)
            {
                if (!requestForm.Controls.Any() && !requestForm.Properties.Any(p => p.HasValue))
                {
                    return;
                }
            }

            writer.BeginSection("REQUESTFORM");
            writer.BeginSection("PROPERTIES");
            requestForm.Properties.Write(PropertiesStyle.Object, writer);
            writer.EndSection();
            requestForm.Controls.Write(writer, 51);
            writer.EndSection();
        }
    }
}
#endif
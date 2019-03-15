#if NAV2009
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Write
{
    public static class RequestFormWriter
    {
        public static void Write(this RequestForm requestForm, CSideWriter writer)
        {
            writer.BeginSection("REQUESTFORM");
            writer.BeginSection("PROPERTIES");
            requestForm.Properties.Write(PropertiesStyle.Object, writer);
            writer.EndSection();
            requestForm.Controls.Write(writer, 52);
            writer.EndSection();
        }
    }
}
#endif
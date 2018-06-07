using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Form.Control.Properties;

namespace UncommonSense.CBreeze.Core.Report.Classic.Controls
{
    public class ReportImageControl : FormControl
    {
        public ReportImageControl(int id, int posX, int posY, int width, int height) : base(id, posX, posY, width, height)
        {
            Properties = new ImageProperties(this);
        }

        public override ClassicControlType Type => ClassicControlType.Image;
    }
}
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Form.Control.Properties;

namespace UncommonSense.CBreeze.Core.Form.Control
{
    public class FormFrameControl : FormControl
    {
        public FormFrameControl(int id, int posX, int posY, int width, int height) : base(id, posX, posY, width, height)
        {
            Properties = new FrameProperties(this);
        }

        public override ClassicControlType Type => ClassicControlType.Frame;
    }
}
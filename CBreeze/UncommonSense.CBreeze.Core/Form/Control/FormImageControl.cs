using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Form.Control.Properties;

namespace UncommonSense.CBreeze.Core.Form.Control
{
    public class FormImageControl : FormControl
    {
        public FormImageControl(int id, int posX, int posY, int width, int height) : base(id, posX, posY, width, height)
        {
            Properties = new FormImageProperties(this);
        }

        public override ClassicControlType Type => ClassicControlType.Image;
    }
}
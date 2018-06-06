using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Form.Control.Properties;

namespace UncommonSense.CBreeze.Core.Form.Control
{
    public class FormCommandButtonControl : FormControl
    {
        public FormCommandButtonControl(int id, int posX, int posY, int width, int height) : base(id, posX, posY, width,
            height)
        {
            Properties = new FormCommandButtonProperties(this);
        }


        public override ClassicControlType Type => ClassicControlType.CommandButton;
    }
}
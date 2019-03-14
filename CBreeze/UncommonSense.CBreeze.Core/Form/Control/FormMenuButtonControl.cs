using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Form.Control.Properties;

namespace UncommonSense.CBreeze.Core.Form.Control
{
    public class FormMenuButtonControl : FormControl
    {
        public FormMenuButtonControl(int id, int posX, int posY, int width, int height) : base(id, posX, posY, width,
            height)
        {
            MenuItems = new FormMenuItems();
            Properties = new FormMenuButtonProperties(this);           
        }

        public FormMenuItems MenuItems { get; set; }

        public override ClassicControlType Type => ClassicControlType.MenuButton;
    }
}
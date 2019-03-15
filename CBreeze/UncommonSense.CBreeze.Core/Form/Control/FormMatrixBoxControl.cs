using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Form.Control.Properties;

namespace UncommonSense.CBreeze.Core.Form.Control
{
    public class FormMatrixBoxControl : FormControl
    {
        public FormMatrixBoxControl(int id, int posX, int posY, int width, int height) : base(id, posX, posY, width, height)
        {
            Properties = new FormMatrixBoxProperties(this);
        }

        public override ClassicControlType Type => ClassicControlType.MatrixBox;
    }
}
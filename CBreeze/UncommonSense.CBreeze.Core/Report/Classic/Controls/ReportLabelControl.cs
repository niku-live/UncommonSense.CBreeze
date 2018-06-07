using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Form.Control.Properties;

namespace UncommonSense.CBreeze.Core.Report.Classic.Controls
{
    public class ReportLabelControl : FormControl
    {
        public ReportLabelControl(int id, int posX, int posY, int width, int height) : base(id, posX, posY, width, height)
        {
            Properties = new LabelProperties(this);
        }

        public override ClassicControlType Type => ClassicControlType.Label;
    }
}

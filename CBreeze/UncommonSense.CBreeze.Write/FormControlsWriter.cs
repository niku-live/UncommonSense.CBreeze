#if NAV2009
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Form.Control;

namespace UncommonSense.CBreeze.Write
{
    public static class FormControlsWriter
    {
        public static void Write(this FormControls formControls, CSideWriter writer, int propertyIndentation)
        {
            writer.BeginSection("CONTROLS");

            foreach (var formControl in formControls)
            {
                formControl.Write(writer, propertyIndentation);
            }

            writer.EndSection();
        }
    }
}
#endif
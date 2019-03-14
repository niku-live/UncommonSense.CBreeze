#if NAV2009
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Form.Control;
using UncommonSense.CBreeze.Core.Form.Control.Properties;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Write
{
    public static class FormMenuItemWriter
    {
        public static void Write(this FormMenuItemBase fieldFormControl, CSideWriter writer)
        {
            var relevantProperties = fieldFormControl.Properties.Where(p => p.HasValue);
            var declaration = "{ ";
            writer.Write(declaration);
            writer.Indent(writer.Column);

            relevantProperties.Write(PropertiesStyle.Field, writer);

            var lastProperty = relevantProperties.LastOrDefault();
            if (lastProperty != null)
                if (lastProperty is TriggerProperty)
                    writer.Write(new string(' ', lastProperty.Name.Length + 2));

            writer.WriteLine("}");
            writer.Unindent();
        }
    }
}
#endif
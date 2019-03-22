using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Table.Key;

namespace UncommonSense.CBreeze.Write
{
    public static class TableKeyWriter
    {
        public static void Write(this TableKey key, CSideWriter writer)
        {
            writer.Write("{");
            
            switch (key.Enabled)
            {
                case null: writer.Write("    "); break;
                default:
                    writer.Write(writer.CodeStyle.Localization.ConvertBoolToString(key.Enabled).EqualPad(4));
                    break;
            }

            writer.Write(";");

            key.Fields.Write(writer);

            if (key.Properties.Any(p => p.HasValue))
            {
                writer.Write(";");

                if (writer.Column > 51)
                {
                    writer.Indent(51);
                    writer.WriteLine("");
                }
                else
                {
                    writer.Indent(writer.Column);
                }

                key.Properties.Write(PropertiesStyle.Field, writer);
                writer.Unindent();
            }
            else
            {
                writer.Write(" ");
            }

            writer.WriteLine("}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Code.Variable;

namespace UncommonSense.CBreeze.Write
{
    public static class FieldListWriter
    {
        public static void Write(this FieldList fieldList, CSideWriter writer)
        {
            if (writer.CodeStyle.UseQuitesInFieldList)
            {
                writer.Write(string.Join(",", fieldList.Select(f => f.QuotedFieldName(writer.CodeStyle))).PadRight(40));
            }
            else
            {
                writer.Write(string.Join(",", fieldList).PadRight(40));
            }
        }
    }
}

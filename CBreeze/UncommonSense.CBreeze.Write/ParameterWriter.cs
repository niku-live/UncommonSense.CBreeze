﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Parameter;

namespace UncommonSense.CBreeze.Write
{
    public static class ParameterWriter
    {
        private static void DoWrite(bool var, string name, int uid, bool temporary, string typeName, string dimensions, bool inDataSet, CSideWriter writer)
        {
            if (var)
                writer.Write("VAR ");

            if (writer.CodeStyle.NoVariableIds)
            {
                writer.Write("{0} : ", name, uid);
            }
            else
            {
                writer.Write("{0}@{1} : ", name, uid);
            }

            if (!string.IsNullOrEmpty(dimensions))
                writer.Write("ARRAY [{0}] OF ", dimensions.Replace(';', ','));

            if (temporary)
                writer.Write("TEMPORARY ");

            writer.Write(typeName);

            if (inDataSet)
                writer.Write(" INDATASET");
        }

        public static void Write(this Parameter parameter, CSideWriter writer)
        {
            switch (parameter)
            {
                case RecordParameter recordParameter: DoWrite(recordParameter.Var, recordParameter.Name, recordParameter.ID, recordParameter.Temporary.GetValueOrDefault(false), recordParameter.TypeName, recordParameter.Dimensions, recordParameter.InDataSet, writer); break;
                default: DoWrite(parameter.Var, parameter.Name, parameter.ID, false, parameter.TypeName, parameter.Dimensions, parameter.InDataSet, writer); break;
            }
        }
    }
}
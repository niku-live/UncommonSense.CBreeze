using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Parameter;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;

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
            string typeName = parameter.TypeName;
            if (writer.CodeStyle.PrintObjectReferenceAsName)
            {
                ObjectType? objType = RefParameterTypeToObjectType(parameter.Type);
                if (objType != null)
                {
                    var subType = (parameter as IHasSubType).SubType;
                    var objName = writer.CodeStyle.ResolveObjectName(objType.Value, subType);
                    if (objName != null)
                    {
                        typeName = $"{parameter.Type} {objName.QuotedTableName(writer.CodeStyle)}";
                    }
                }
            }

            switch (parameter)
            {
                case RecordParameter recordParameter: DoWrite(recordParameter.Var, recordParameter.Name, recordParameter.ID, recordParameter.Temporary.GetValueOrDefault(false), typeName, recordParameter.Dimensions, recordParameter.InDataSet, writer); break;
                default: DoWrite(parameter.Var, parameter.Name, parameter.ID, false, typeName, parameter.Dimensions, parameter.InDataSet, writer); break;
            }
        }

        private static ObjectType? RefParameterTypeToObjectType(ParameterType varType)
        {
            switch (varType)
            {
                case ParameterType.Record:
                    return ObjectType.Table;
                case ParameterType.Form:
                    return ObjectType.Form;
                case ParameterType.Report:
                    return ObjectType.Report;
                case ParameterType.Dataport:
                    return ObjectType.Dataport;
                case ParameterType.Codeunit:
                    return ObjectType.Codeunit;
                case ParameterType.XmlPort:
                    return ObjectType.XmlPort;
                case ParameterType.Page:
                    return ObjectType.Page;
                case ParameterType.Query:
                    return ObjectType.Query;
                default:
                    return null;
            }
        }
    }
}
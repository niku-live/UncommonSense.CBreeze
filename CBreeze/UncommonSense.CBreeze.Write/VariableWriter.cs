using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Extension;
using System.Globalization;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Code.Variable;

namespace UncommonSense.CBreeze.Write
{
    public static class VariableWriter
    {
        public static void Write(this Variable variable, CSideWriter writer)
        {
            // FIXME: Simplify, avoid TypeSwitch
            // FIXME: First, uniformize, e.g. by using p.TypeName instead of hard-coded type

            TypeSwitch.Do(
                variable,
                TypeSwitch.Case<ActionVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<AutomationVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, false, false, p.WithEvents.GetValueOrDefault(false), false, null, false, writer)),
                TypeSwitch.Case<BigIntegerVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<BigTextVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<BinaryVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<BooleanVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, false, p.IncludeInDataset.GetValueOrDefault(false), false, false, null, false, writer)),
                TypeSwitch.Case<ByteVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<CharVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#if NAV2017
                TypeSwitch.Case<ClientTypeVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#endif
                TypeSwitch.Case<CodeunitVariable>(p => WriteObjectReference(p, p.SubType, p.Dimensions, false, null, writer)),
                TypeSwitch.Case<CodeVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, false, p.IncludeInDataset.GetValueOrDefault(false), false, false, null, false, writer)),
#if NAV2018
                TypeSwitch.Case<DataClassificationVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#endif
#if NAVBC
                TypeSwitch.Case<DataScopeVariable>(p=>DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#endif
                TypeSwitch.Case<DateFormulaVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<DateTimeVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<DateVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<DecimalVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<DialogVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<DotNetVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, false, false, p.WithEvents.GetValueOrDefault(false), p.RunOnClient.GetValueOrDefault(false), null, p.SuppressDispose.GetValueOrDefault(false), writer)),
                TypeSwitch.Case<DurationVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<ExecutionModeVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<FieldRefVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<FileVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#if NAV2016
                TypeSwitch.Case<FilterPageBuilderVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#endif
                TypeSwitch.Case<GuidVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<InStreamVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<IntegerVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, false, p.IncludeInDataset.GetValueOrDefault(false), false, false, null,false,  writer)),
                TypeSwitch.Case<KeyRefVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#if NAV2017
                TypeSwitch.Case<NotificationVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#endif
                TypeSwitch.Case<OcxVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<OptionVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<OutStreamVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<PageVariable>(p => WriteObjectReference(p, p.SubType, p.Dimensions, false, null, writer)),
                TypeSwitch.Case<QueryVariable>(p => WriteObjectReference(p, p.SubType, p.Dimensions, false, p.SecurityFiltering.HasValue? p.SecurityFiltering.Value.ToString() : null, writer)),
                TypeSwitch.Case<RecordVariable>(p => WriteObjectReference(p, p.SubType, p.Dimensions, p.Temporary, p.SecurityFiltering.HasValue ? p.SecurityFiltering.Value.ToString() : null, writer)),
                TypeSwitch.Case<RecordIDVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<RecordRefVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, false, false, false, false, p.SecurityFiltering.HasValue ? p.SecurityFiltering.Value.ToString() : null, false, writer)),
                TypeSwitch.Case<ReportVariable>(p => WriteObjectReference(p, p.SubType, p.Dimensions, false, null, writer)),
#if NAV2016
                TypeSwitch.Case<ReportFormatVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<TableConnectionTypeVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#endif
#if NAV2018
                TypeSwitch.Case<SessionSettingsVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#endif
                TypeSwitch.Case<TestPageVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<TextConstant>(p => WriteTextConstant(p, writer)),
#if NAV2016
                TypeSwitch.Case<TextEncodingVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#endif
#if NAV2009
                TypeSwitch.Case<FormVariable>(p => WriteObjectReference(p, p.SubType, p.Dimensions, false, null, writer)),
                TypeSwitch.Case<DataportVariable>(p => WriteObjectReference(p, p.SubType, p.Dimensions, false, null, writer)),
#endif
                TypeSwitch.Case<TextVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, false, p.IncludeInDataset.GetValueOrDefault(false), false, false, null, false, writer)),
                TypeSwitch.Case<TimeVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<TransactionTypeVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
                TypeSwitch.Case<VariantVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#if NAV2018
                TypeSwitch.Case<VerbosityVariable>(p => DoWrite(p.Name, p.ID, p.TypeName, p.Dimensions, writer)),
#endif
                TypeSwitch.Case<XmlPortVariable>(p => WriteObjectReference(p, p.SubType, p.Dimensions, false, null, writer)),
                TypeSwitch.Default(() => throw new ArgumentOutOfRangeException($"Don't know how to write a variable of type {variable.Type}."))
                );
        }

        private static ObjectType? RefVariableTypeToObjectType(VariableType varType)
        {
            switch (varType)
            {
                case VariableType.Record:
                    return ObjectType.Table;
                case VariableType.Form:
                    return ObjectType.Form;
                case VariableType.Report:
                    return ObjectType.Report;
                case VariableType.Dataport:
                    return ObjectType.Dataport;
                case VariableType.Codeunit:
                    return ObjectType.Codeunit;
                case VariableType.XmlPort:
                    return ObjectType.XmlPort;
                case VariableType.Page:
                    return ObjectType.Page;
                case VariableType.Query:
                    return ObjectType.Query;
                default:
                    return null;
            }
        }

        private static void WriteObjectReference(Variable variable, int subType, string dimensions, bool temporary, string securityFiltering, CSideWriter writer)
        {
            string typeName = variable.TypeName;
            if (writer.CodeStyle.PrintObjectReferenceAsName)
            {
                ObjectType? objType = RefVariableTypeToObjectType(variable.Type);
                if (objType != null)
                {
                    var objName = writer.CodeStyle.ResolveObjectName(objType.Value, subType);
                    if (objName != null)
                    {
                        typeName = $"{variable.Type} {objName}";
                    }
                }
            }
            DoWrite(variable.Name, variable.ID, typeName, dimensions, temporary, false, false, false, securityFiltering, false, writer);
        }

        private static void DoWrite(string name, int id, string type, string dimensions, CSideWriter writer)
        {
            DoWrite(name, id, type, dimensions, false, false, false, false, null, false, writer);
        }

        private static void DoWrite(string name, int id, string type, string dimensions, bool temporary, bool includeInDataset, bool withEvents, bool runOnClient, string securityFiltering, bool suppressDispose, CSideWriter writer)
        {
            var stringBuilder = new StringBuilder();

            if (writer.CodeStyle.NoVariableIds)
            {
                stringBuilder.AppendFormat("{0} : ", name);
            }
            else
            {
                stringBuilder.AppendFormat("{0}@{1} : ", name, id);
            }

            if (!string.IsNullOrEmpty(dimensions))
                stringBuilder.AppendFormat("ARRAY [{0}] OF ", dimensions.Replace(';', ','));

            if (temporary)
                stringBuilder.Append("TEMPORARY ");

            stringBuilder.Append(type);
            if (writer.CodeStyle.PlatformVersion.MajorVersion < 13)
                if (suppressDispose)
                    stringBuilder.Append(" SUPPRESSDISPOSE");

            if (withEvents)
                stringBuilder.Append(" WITHEVENTS");

            if (runOnClient)
                stringBuilder.Append(" RUNONCLIENT");

            if (includeInDataset)
                stringBuilder.Append(" INDATASET");

            if (writer.CodeStyle.PlatformVersion.MajorVersion >= 13)
                if (suppressDispose)
                    stringBuilder.Append(" SUPPRESSDISPOSE");

            if (!string.IsNullOrEmpty(securityFiltering))
                stringBuilder.AppendFormat(" SECURITYFILTERING({0})", securityFiltering);

            stringBuilder.Append(";");

            writer.WriteLine(stringBuilder.ToString());
        }

        private static void WriteTextConstant(TextConstant textConstant, CSideWriter writer)
        {
            if (writer.CodeStyle.NewLineBeforeTextConst)
            {
                writer.InnerWriter.WriteLine();
            }
            if (IsMultiLineTextConstant(textConstant) || writer.CodeStyle.TextConstIsAlwaysMultiLine)
            {
                WriteMultiLineTextConstant(textConstant, writer);
            }
            else
            {
                WriteSingleLineTextConstant(textConstant, writer);
            }
        }

        private static bool IsMultiLineTextConstant(TextConstant textConstant)
        {
            return textConstant.Values.Sum(v => v.QuotedValue.Length) >= 1002;
        }

        private static void WriteSingleLineTextConstant(TextConstant textConstant, CSideWriter writer)
        {
            DoWrite(
                textConstant.Name,
                textConstant.ID,
                textConstant.TypeName,
                "",
                writer);
        }

        private static void WriteMultiLineTextConstant(TextConstant textConstant, CSideWriter writer)
        {
            var sortedValues = textConstant.Values.OrderBy(v => v.LanguageID.GetLCIDFromLanguageCode());            

#if !NAV2017
            writer.InnerWriter.WriteLine();
#endif
            writer.WriteLine("{0}@{1} : TextConst", textConstant.Name, textConstant.ID);
            writer.Indent();

            foreach (var value in sortedValues)
            {
                var isLastValue = (value.LanguageID == sortedValues.Last().LanguageID);
                writer.WriteLine("'{0}={1}'{2}", value.LanguageID, value.QuotedValue, isLastValue ? ";" : ",");
            }

            writer.Unindent();
        }
    }
}
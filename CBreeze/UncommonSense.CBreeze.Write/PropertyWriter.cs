﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using System.Globalization;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;
using UncommonSense.CBreeze.Core.Extension;
using System.Drawing;
using UncommonSense.CBreeze.Core.Table.Relation;

namespace UncommonSense.CBreeze.Write
{
    public static class PropertyWriter
    {
        public static void Write(this Property property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            if (style == PropertiesStyle.Object)
                isLastProperty = false;

            TypeSwitch.Do(
                property,
#if NAV2015
                TypeSwitch.Case<AccessByPermissionProperty>(p => WriteSimpleProperty(p.Name, string.Format("{0} {1}={2}", p.Value.ObjectType, p.Value.ObjectID, p.Value.ToString()), isLastProperty, writer)),
                TypeSwitch.Case<PreviewModeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PageActionScopeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<UpdatePropagationProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DefaultLayoutProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
#endif
#if NAV2016
                TypeSwitch.Case<ExternalAccessProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<TableTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<EventSubscriberInstanceProperty>(p => WriteSimpleProperty(p.Name, p.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<XmlPortNamespacesProperty>(p => p.Write(isLastProperty, style, writer)),
#endif
#if NAV2017
                TypeSwitch.Case<TestPermissionsProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
#endif
                TypeSwitch.Case<MenuItemRunObjectTypeProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<MenuItemDepartmentCategoryProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(p.Name == "UsageCategory"), isLastProperty, writer)),
                TypeSwitch.Case<PaperSourceProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DataItemLinkTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<SqlJoinTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<TextEncodingProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<QueryDataItemLinkProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<ReportDataItemLinkProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<ColumnFilterProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<ReadStateProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<MethodTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DateMethodProperty>(p => WriteSimpleProperty("Method", p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<TotalsMethodProperty>(p => WriteSimpleProperty("Method", p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<TableFieldTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<TextTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<TransactionTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DirectionProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<XmlPortEncodingProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<XmlVersionNoProperty>(p => WriteSimpleProperty("XMLVersionNo", p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<XmlPortFormatProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<ControlListProperty>(p => WriteSimpleProperty(p.Name, string.Join(",", p.Value), isLastProperty, writer)),
                TypeSwitch.Case<RunObjectLinkProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<StyleProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PromotedCategoryProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<RunPageModeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ObjectProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ImportanceProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PermissionsProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<ActionListProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<FieldListProperty>(p => p.Write(isLastProperty, writer)),
                TypeSwitch.Case<LinkFieldsProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<CalcFormulaProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TableViewProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<DecimalPlacesProperty>(p => WriteSimpleProperty(p.Name, string.Format("{0}:{1}", p.Value.AtLeast.AsString(), p.Value.AtMost.AsString()), isLastProperty, writer)),
                TypeSwitch.Case<SourceFieldProperty>(p => WriteSimpleProperty(p.Name, string.Format("{0}::{1}", p.Value.TableVariableName, p.Value.FieldName), isLastProperty, writer)),
                TypeSwitch.Case<FieldClassProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PageControlContainerTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PageControlGroupTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PageControlGroupLayoutProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PageControlPartTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PageTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<SystemPartIDProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PageActionContainerTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ScopedTriggerProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TriggerProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<SemiColonSeparatedStringProperty>(p => WriteSimpleProperty(p.Name, p.Value.Contains(";") ? string.Format("[{0}]", p.Value) : p.Value, isLastProperty, writer)),
                TypeSwitch.Case<OptionStringProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<StringProperty>(p => WriteSimpleProperty(p.Name, p.Value, isLastProperty, writer)),
                TypeSwitch.Case<DurationProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<AutoFormatTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.Value.ToString("d"), isLastProperty, writer)),
                TypeSwitch.Case<CodeunitSubTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ExtendedDataTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.Value.AsString(), isLastProperty, writer)),
                TypeSwitch.Case<SqlDataTypeProperty>(p => WriteSimpleProperty("SQL Data Type", p.Value.Value.AsString(), isLastProperty, writer)),
                TypeSwitch.Case<BlankNumbersProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<StandardDayTimeUnitProperty>(p => WriteSimpleProperty("Standard Day/Time Unit", p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<BlobSubTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString().ToLocalizedString<BlobSubType>(writer.CodeStyle), isLastProperty, writer)),
                TypeSwitch.Case<FormatEvaluateProperty>(p => WriteSimpleProperty("Format/Evaluate", p.Value.Value.AsString(), isLastProperty, writer)),
                TypeSwitch.Case<MinOccursProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<MaxOccursProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<OccurrenceProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<MultiLanguageProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TableRelationProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TableReferenceProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<PageReferenceProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<RunObjectProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<QueryOrderByLinesProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<DataItemQueryElementTableFilterProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<SIFTLevelsProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TestIsolationProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
#if NAV2009
                TypeSwitch.Case<FormReferenceProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<CaptionBarProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ClassicReportOrientationProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ClassicControlBorderStyleProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<VertAlignProperty>(p => { if (p.HasValue) WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer); }),
                TypeSwitch.Case<VertGlueProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<HorzAlignProperty>(p => { if (p.HasValue) WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer); }),
                TypeSwitch.Case<HorzGlueProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ShapeStyleProperty>(p => WriteSimpleProperty(p.Name, p.GetValueName(), isLastProperty, writer)),
                TypeSwitch.Case<ColorProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<AutoPositionProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<SourceTablePlacementProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PushActionProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<InvalidActionAppearanceProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<BitmapPosProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<RunFormLinkTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<BorderStyleProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ClassicMenuProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<MenuItemTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<BorderWidthProperty>(p => WriteSimpleProperty(p.Name, p.GetValueName(), isLastProperty, writer)),
                TypeSwitch.Case<ClassicSectionTypeProperty>(p => WriteSimpleProperty(p.Name, p.GetValue().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ClassicDataportFileFormatProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
#endif
                TypeSwitch.Case<NullableBooleanProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<NullableDateTimeProperty>(p => WriteSimpleProperty(p.Name, writer.CodeStyle.Localization.ConvertDateTimeToLongDateString(p.Value), isLastProperty, writer)),
                TypeSwitch.Case<NullableDateProperty>(p => WriteSimpleProperty(p.Name, writer.CodeStyle.Localization.ConvertDateTimeToShortDateString(p.Value, false), isLastProperty, writer)),
                TypeSwitch.Case<NullableDecimalProperty>(p => p.Write(isLastProperty, writer)),
                TypeSwitch.Case<NullableBigIntegerProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<NullableGuidProperty>(p => WriteSimpleProperty(p.Name, string.Format("[{0}]", p.Value.GetValueOrDefault().ToString("B").ToUpper()), isLastProperty, writer)),
                TypeSwitch.Case<NullableIntegerProperty>(p => WriteSimpleProperty(p.Name, p.GetValueForPrinting(), isLastProperty, writer)),
                TypeSwitch.Case<NullableUnsignedIntegerProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<NullableTimeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString("c"), isLastProperty, writer)),
                TypeSwitch.Case<XmlPortNodeDataTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DataClassificationProperty>(p => WriteSimpleProperty(p.Name, p.GetValue().ToString(), isLastProperty, writer)),
#if NAV2017
                TypeSwitch.Case<TagListProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<GestureProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
#endif
#if NAV2018
                TypeSwitch.Case<QueryTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ObsoleteStateProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DataClassificationProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
#endif
                TypeSwitch.Case<IntegerProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
#if NAVBC
                TypeSwitch.Case<UsageCategoryProperty>(p=>WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
#endif
            TypeSwitch.Default(() => throw new ArgumentOutOfRangeException($"Don't know how to write property type {property.GetType().FullName}."))
            );
        }

        public static void WriteSimpleProperty(string propertyName, string propertyValue, bool isLastProperty, CSideWriter writer)
        {
            propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(propertyName);
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} ", propertyName, propertyValue);
                    break;

                case false:
                    writer.WriteLine("{0}={1};", propertyName, propertyValue);
                    break;
            }
        }

#if NAV2009
        public static void Write(this ClassicMenuProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.WriteLine("{0}=MENUITEMS", propertyName);
            writer.WriteLine("{");
            writer.Indent();
            foreach (var item in property.Items)
            {
                item.Write(writer);
            }
            writer.Unindent();
            writer.WriteLine("}");
            if (isLastProperty)
            {
                writer.Write(" ");
            }
        }
#endif

        public static void Write(this FieldListProperty property, bool isLastProperty, CSideWriter writer)
        {
            string values = string.Empty;

            if (writer.CodeStyle.UseQuitesInFieldList)
            {
                values = string.Join(",", property.Value.Select(v => v.QuotedFieldName(writer.CodeStyle)));
            }
            else
            {
                values = string.Join(",", property.Value);
            }
            WriteSimpleProperty(property.Name, values, isLastProperty, writer);
        }

        public static void Write(this RunObjectLinkProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            if (property.EmptyValueIsSet)
            {
                WriteSimpleProperty(property.Name, "", isLastProperty, writer);
                return;
            }
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}=", propertyName);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());

                switch (isLastProperty && isLastLine)
                {
                    case true:
                        writer.Write("{0}={1}({2}) ", line.FieldName, line.Type.GetValueOrDefault().AsString(), line.Value);
                        break;

                    case false:
                        writer.Write("{0}={1}({2})", line.FieldName, line.Type.GetValueOrDefault().AsString(), line.Value);
                        writer.WriteLineIf(isLastLine, ";");
                        writer.WriteLineIf(!isLastLine, ",");
                        break;
                }
            }

            writer.Unindent();
        }

        public static void Write(this PermissionsProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            if (property.EmptyValueIsSet)
            {
                WriteSimpleProperty(property.Name, "", isLastProperty, writer);
                return;
            }
            writer.Write("{0}=", propertyName);
            writer.Indent(writer.Column);

            foreach (var permission in property.Value)
            {
                var isLastValue = (permission == property.Value.Last());
                var terminator = isLastValue ? ";" : ",";
                var read = permission.ReadPermission ? "r" : "";
                var insert = permission.InsertPermission ? "i" : "";
                var modify = permission.ModifyPermission ? "m" : "";
                var delete = permission.DeletePermission ? "d" : "";

                var objectName = permission.TableID.ToString();
                if (writer.CodeStyle.PrintObjectReferenceAsName)
                {
                    var objName = writer.CodeStyle.ResolveObjectName(ObjectType.Table, permission.TableID);
                    if (objName != null)
                    {
                        objectName = objName;
                    }
                }

                writer.WriteLine("TableData {0}={1}{2}{3}{4}{5}", objectName, read, insert, modify, delete, terminator);
            }

            writer.Unindent();
        }

        public static void Write(this ActionListProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.WriteLine("{0}=ACTIONS", propertyName);
            writer.WriteLine("{");
            writer.Indent();

            foreach (var action in property.Value)
            {
                action.Write(writer);
            }

            writer.Unindent();
            writer.WriteLine("}");
        }

        public static void Write(this LinkFieldsProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}=", propertyName);
            writer.Indent(writer.Column);

            foreach (var linkField in property.Value)
            {
                writer.Write("Field{0}=FIELD(Field{1})", linkField.Field, linkField.ReferenceField);

                var isLastLine = (linkField == property.Value.Last());

                if (!isLastLine)
                    writer.WriteLine(",");
                else
                    if (isLastProperty)
                    writer.Write(" ");
                else
                    writer.WriteLine(";");
            }

            writer.Unindent();
        }

        public static void Write(this CalcFormulaProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            var requiresSquareBrackets = property.Value.TableFilter.Any(f => f.Value.Any(c => "{}".Contains(c)));
            var openingBracket = requiresSquareBrackets ? "[" : "";
            var closingBracket = requiresSquareBrackets ? "]" : "";
            var sign = property.Value.ReverseSign ? "-" : "";

            writer.Write($"{propertyName}={openingBracket}{sign}{property.Value.Method}(");

            switch (property.Value.Method.Value)
            {
                case CalcFormulaMethod.Exist:
                case CalcFormulaMethod.Count:
                    writer.Write(property.Value.TableName.QuotedTableName(writer.CodeStyle));
                    break;

                case CalcFormulaMethod.Lookup:
                case CalcFormulaMethod.Average:
                case CalcFormulaMethod.Max:
                case CalcFormulaMethod.Min:
                case CalcFormulaMethod.Sum:
                    writer.Write("{0}.{1}", property.Value.TableName.QuotedTableName(writer.CodeStyle), property.Value.FieldName.QuotedFieldName(writer.CodeStyle));
                    break;
            }

            if (property.Value.TableFilter.Any())
            {
                writer.Write(" WHERE (");
                writer.Indent(writer.Column);

                foreach (var tableFilterLine in property.Value.TableFilter)
                {
                    var value = TableFilterLineValueAsString(property.Value.TableName, tableFilterLine.FieldName, tableFilterLine.Value, tableFilterLine.Type, writer);
                    var fieldName = TableFilterLineFieldNameAsString(tableFilterLine.FieldName, writer);

                    if (tableFilterLine.ValueIsFilter)
                        value = string.Format("FILTER({0})", value);
                    if (tableFilterLine.OnlyMaxLimit)
                        value = string.Format("UPPERLIMIT({0})", value);

                    writer.Write("{0}={1}({2})", fieldName, tableFilterLine.Type.AsString(), value);
                    if (tableFilterLine != property.Value.TableFilter.Last())
                        writer.WriteLine(",");
                }
                writer.Write(")");
                writer.Unindent();
            }

            writer.Write(")");
            writer.Write(closingBracket);

            if (!isLastProperty)
            {
                writer.WriteLine(";");
            }
            else
            {
                writer.Write(" ");
            }
        }

        public static void Write(this TableViewProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            if (property.EmptyValueIsSet)
            {
                WriteSimpleProperty(property.Name, "", isLastProperty, writer);
                return;
            }
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            var requiresSquareBrackets = property.Value.TableFilter.Any(f => f.Value.Any(c => "{}".Contains(c)));
            var openingBracket = requiresSquareBrackets ? "[" : "";
            var closingBracket = requiresSquareBrackets ? "]" : "";

            var components = new List<string>();

            if (!string.IsNullOrEmpty(property.Value.Key))
                components.Add(string.Format("SORTING({0})", property.Value.Key));

            if (property.Value.Order.HasValue)
                components.Add(string.Format("ORDER({0})", property.Value.Order));

            if (property.Value.TableFilter.Any())
                components.AddRange(property.Value.TableFilter.AsStrings());

            writer.Write("{0}={1}", propertyName, openingBracket);
            writer.Indent(writer.Column);

            foreach (var component in components)
            {
                var isLastComponent = (component == components.Last());

                switch (isLastProperty && isLastComponent)
                {
                    case true:
                        writer.Write("{0}{1} ", component, closingBracket);
                        break;

                    case false:
                        writer.Write(component);
                        writer.WriteLineIf(isLastComponent, $"{closingBracket};");
                        writer.WriteLineIf(!isLastComponent, string.Empty);
                        break;
                }
            }

            writer.Unindent();
        }

        public static void Write(this TriggerProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}=", propertyName);
            if (property.Value.InvalidTrigger)
            {
                var value = property.Value.InvalidTriggerValue;

                switch (isLastProperty)
                {
                    case true:
                        writer.Write("{0} ", value);
                        break;

                    case false:
                        writer.WriteLine("{0};", value);
                        break;
                }
                return;
            }
            writer.Indent(writer.Column);
            property.Value.Variables.Write(writer);

            writer.WriteLine("BEGIN");
            writer.Indent();
            property.Value.CodeLines.Write(writer);
            writer.Unindent();
            writer.WriteLine("END;");

            writer.Unindent();

            if (!isLastProperty || style == PropertiesStyle.Object)
                writer.InnerWriter.WriteLine();
        }

        public static void Write(this ScopedTriggerProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.ScopedName());
            if (property.Value.InvalidTrigger)
            {
                var value = property.Value.InvalidTriggerValue;

                switch (isLastProperty)
                {
                    case true:
                        writer.Write("{0} ", value);
                        break;

                    case false:
                        writer.WriteLine("{0};", value);
                        break;
                }
                return;
            }
            writer.Indent(writer.Column);
            property.Value.Variables.Write(writer);

            writer.WriteLine("BEGIN");
            writer.Indent();
            property.Value.CodeLines.Write(writer);
            writer.Unindent();
            writer.WriteLine("END;");

            writer.Unindent();

            if (!isLastProperty || style == PropertiesStyle.Object)
                writer.InnerWriter.WriteLine();
        }

        public static void Write(this OptionStringProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            var value = property.Value.ActualString;
            if (value.Trim() != value)
            {
                value = $"[{value}]";
            }
            if (writer.CodeStyle.UseQuitesInFieldList)
            {
                value = string.Join(",", property.Value.Select(ov => ov.OptionValueName.QuotedFieldName(writer.CodeStyle)));
            }

            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} ", propertyName, value);
                    break;

                case false:
                    writer.WriteLine("{0}={1};", propertyName, value);
                    break;
            }
        }

#if NAV2009
        public static void Write(this ColorProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            var color = property.Value.Value;
            var red = (byte)color.R;
            var green = (byte)color.G;
            var blue = (byte)color.B;

            var bytes = new byte[] { red, green, blue, 0 };
            var integer = BitConverter.ToInt32(bytes, 0);

            var value = integer.ToString();
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} ", propertyName, value);
                    break;

                case false:
                    writer.WriteLine("{0}={1};", propertyName, value);
                    break;
            }
        }
#endif

        public static void Write(this NullableBooleanProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            var resultValue = writer.CodeStyle.Localization.ConvertBoolToString(property.Value);

            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} ", propertyName, resultValue);
                    break;

                case false:
                    writer.WriteLine("{0}={1};", propertyName, resultValue);
                    break;
            }
        }

#if NAV2016

        public static void Write(this XmlPortNamespacesProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            var requiresBrackets = (property.Value.Count() > 1); // ?

            writer.Write("{0}=", propertyName);
            if (requiresBrackets)
                writer.Write("[");

            writer.Indent(writer.Column - 1);

            foreach (var xmlPortNamespace in property.Value)
            {
                writer.Write("{0}={1}", xmlPortNamespace.Prefix, xmlPortNamespace.Namespace);
                writer.WriteLineIf(xmlPortNamespace != property.Value.Last(), ";");
            }

            writer.Unindent();
            if (requiresBrackets)
                writer.Write("]");

            switch (style)
            {
                case PropertiesStyle.Object:
                    writer.WriteLine(";");
                    break;

                case PropertiesStyle.Field:
                    if (!isLastProperty)
                        writer.WriteLine(";");
                    else
                        writer.Write(" ");
                    break;
            }
        }

#endif

        public static void Write(this MultiLanguageProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            var requiresBrackets = (
                property.Value.Count() > 1 ||
                property.Value.Any(e => e.Value.Contains('{') ||
                property.Value.Any(f => f.Value.Contains(';'))));

            writer.Write("{0}=", propertyName);
            if (requiresBrackets)
                writer.Write("[");
            writer.Indent(writer.Column);

            var multiLanguageEntries = property.Value.OrderBy(e => e.LanguageID.GetLCIDFromLanguageCode());            

            foreach (var multiLanguageEntry in multiLanguageEntries)
            {
                string value = multiLanguageEntry.QuotedValue;
                if (writer.CodeStyle.EmptyCaptionIsNotQuited && (value == "\"\""))
                {
                    value = "";
                }

                writer.Write("{0}={1}", multiLanguageEntry.LanguageID, value);
                writer.WriteLineIf(multiLanguageEntry != multiLanguageEntries.Last(), ";");
            }

            writer.Unindent();
            if (requiresBrackets)
                writer.Write("]");

            switch (style)
            {
                case PropertiesStyle.Object:
                    writer.WriteLine(";");
                    break;

                case PropertiesStyle.Field:
                    if (!isLastProperty)
                        writer.WriteLine(";");
                    else
                        writer.Write(" ");
                    break;
            }
        }

        public static void Write(this TableRelationProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            var indentations = 0;

            writer.Write("{0}=", propertyName);
            writer.Indent(writer.Column);
            indentations++;

            foreach (var tableRelationLine in property.Value)
            {
                if (tableRelationLine != property.Value.First())
                    writer.Write("ELSE ");

                if (tableRelationLine.Conditions.Any())
                {
                    writer.Write("IF (");

                    // Only indent if multiple conditions exist. Note that C/SIDE doesn't properly unindent.
                    if (tableRelationLine.Conditions.Count() > 1)
                    {
                        writer.Indent(writer.Column); // conditions
                        indentations++;
                    }

                    foreach (var condition in tableRelationLine.Conditions)
                    {
                        writer.Write("{0}={1}({2})", condition.FieldName, condition.Type.ToString().ToUpper(), condition.Value);

                        var isLastCondition = (condition == tableRelationLine.Conditions.Last());

                        switch (isLastCondition)
                        {
                            case false:
                                writer.WriteLine(",");
                                break;
                        }
                    }

                    writer.Write(") ");
                }

                writer.Write(tableRelationLine.TableName.QuotedTableName(writer.CodeStyle));

                if (!string.IsNullOrEmpty(tableRelationLine.FieldName))
                {
                    writer.Write(".{0}", tableRelationLine.FieldName.QuotedFieldName(writer.CodeStyle));
                }

                if (tableRelationLine.TableFilter.Any())
                {
                    writer.Write(" WHERE (");

                    if (tableRelationLine.TableFilter.Count() > 1)
                    {
                        writer.Indent(writer.Column); // filters
                        indentations++;
                    }

                    foreach (var tableFilterLine in tableRelationLine.TableFilter)
                    {
                        var value = TableFilterLineValueAsString(tableRelationLine.TableName, tableFilterLine.FieldName, tableFilterLine.Value, tableFilterLine.Type, writer);
                        var fieldName = TableFilterLineFieldNameAsString(tableFilterLine.FieldName, writer);
                        writer.Write("{0}={1}({2})", fieldName, tableFilterLine.Type.AsString(), value);

                        switch (tableFilterLine == tableRelationLine.TableFilter.Last())
                        {
                            case true:
                                writer.Write(")");
                                break;

                            default:
                                writer.WriteLine(",");
                                break;
                        }
                    }
                }

                var isLastLine = (tableRelationLine == property.Value.Last());

                if (!isLastLine)
                    writer.WriteLine("");
                else
                    if (isLastProperty)
                    writer.Write(" ");
                else
                    writer.WriteLine(";");

                //switch (tableRelationLine == property.Value.Last() && !isLastProperty)
                //{
                //    case true:
                //        writer.WriteLine(";");
                //        break;
                //    default:
                //        writer.Write(" ");
                //        break;
                //}
            }

            for (var i = 0; i < indentations; i++)
                writer.Unindent();
        }

        public static string TableFilterLineFieldNameAsString(string fieldName, CSideWriter writer)
        {
            if (writer.CodeStyle.UseQuitesInFieldList)
            {
                fieldName = fieldName.QuotedFieldName(writer.CodeStyle);
            }
            return fieldName;
        }

        public static string TableFilterLineValueAsString(string tableName, string fieldName, string lineValue, Core.Table.Field.TableFilterType tableFilterLineType, CSideWriter writer)
        {
            var value = lineValue;
            if (tableFilterLineType == Core.Table.Field.TableFilterType.Field)
            {
                if (writer.CodeStyle.UseQuitesInFieldList)
                {
                    value = value.QuotedFieldName(writer.CodeStyle);
                }
            }
            if (tableFilterLineType == Core.Table.Field.TableFilterType.Const)
            {
                if (writer.CodeStyle.ExportToNewSyntax)
                {
                    var fieldType = writer.CodeStyle.ResolveTableFieldType(tableName, fieldName);
                    switch (fieldType)
                    {
                        case TableFieldType.Boolean:
                            value = (value.ToLower().Substring(0, 1) == "n") ? writer.CodeStyle.Localization.LocalizedNo : writer.CodeStyle.Localization.LocalizedYes;
                            break;
                        case TableFieldType.Text:
                        case TableFieldType.Code:
                            value = $"'{value}'";
                            break;
                    }
                }
            }
            return value;
        }

        public static void Write(this TableReferenceProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}=Table{1} ", propertyName, property.Value.Value);
                    break;

                case false:
                    writer.WriteLine("{0}=Table{1};", propertyName, property.Value.Value);
                    break;
            }
        }

        public static void Write(this TagListProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            bool useSpace = property.SpaceSeparation;
            if (!useSpace)
            {
                WriteSimpleProperty(property.Name, property.Value.ToString(), isLastProperty, writer);
            }
            else
            {
                WriteSimpleProperty(property.Name, String.Join(", ", property.Value), isLastProperty, writer);
            }
        }

        public static void Write(this PageReferenceProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            var pageName = $"Page{property.Value.Value}";
            if (writer.CodeStyle.PrintObjectReferenceAsName)
            {
                var objName = writer.CodeStyle.ResolveObjectName(ObjectType.Page, property.Value.Value);
                if (objName != null)
                {
                    pageName = objName;
                }
            }

            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} ", propertyName, pageName);
                    break;

                case false:
                    writer.WriteLine("{0}={1};", propertyName, pageName);
                    break;
            }
        }

        public static void Write(this RunObjectProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} {2} ", propertyName, FormatRunObjectType(property.Value.Type.Value), property.Value.ID);
                    break;

                case false:
                    writer.WriteLine("{0}={1} {2};", propertyName, FormatRunObjectType(property.Value.Type.Value), property.Value.ID);
                    break;
            }
        }

        public static void Write(this FormReferenceProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}=Form{1} ", propertyName, property.Value.Value);
                    break;

                case false:
                    writer.WriteLine("{0}=Form{1};", propertyName, property.Value.Value);
                    break;
            }
        }

        private static string FormatRunObjectType(RunObjectType value)
        {
            switch (value)
            {
                case RunObjectType.XmlPort:
                    return "XMLport";

                default:
                    return value.ToString();
            }
        }

        public static void Write(this MenuItemRunObjectTypeProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}={1}", propertyName, FormatMenuItemRunObjectType(property.Value.Value));
            writer.WriteIf(isLastProperty, " ");
            writer.WriteLineIf(!isLastProperty, ";");
        }

        private static string FormatMenuItemRunObjectType(MenuItemRunObjectType value)
        {
            switch (value)
            {
                case MenuItemRunObjectType.XmlPort:
                    return "XMLport";

                default:
                    return value.ToString();
            }
        }

        public static void Write(this QueryOrderByLinesProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}=", propertyName);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());
                writer.WriteLine("{0}={1}{2}", line.Column, line.Direction, isLastLine ? ";" : ",");
            }

            writer.Unindent();
        }

        public static void Write(this DataItemQueryElementTableFilterProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}=", propertyName);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());
                writer.Write("{0}={1}({2})", line.FieldName, line.Type.AsString(), line.Value);

                switch (isLastLine)
                {
                    case true:
                        if (isLastProperty)
                        {
                            writer.Write(" ");
                        }
                        else
                        {
                            writer.WriteLine(";");
                        }

                        break;

                    case false:
                        writer.WriteLine(",");
                        break;
                }
            }

            writer.Unindent();
        }

        public static void Write(this ColumnFilterProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}=", propertyName);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());
                writer.WriteLine("{0}={1}({2}){3}", line.FieldName, line.Type.AsString(), line.Value, isLastLine ? ";" : ",");
            }

            writer.Unindent();
        }

        public static void Write(this QueryDataItemLinkProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}=", propertyName);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());

                switch (isLastProperty && isLastLine)
                {
                    case true:
                        writer.Write("{0}={1}.{2} ", line.Field, line.ReferenceTable, line.ReferenceField);
                        break;

                    case false:
                        writer.WriteLine("{0}={1}.{2}{3}", line.Field, line.ReferenceTable, line.ReferenceField, isLastLine ? ";" : ",");
                        break;
                }
            }

            writer.Unindent();
        }

        public static void Write(this ReportDataItemLinkProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}=", propertyName);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());

                switch (isLastProperty && isLastLine)
                {
                    case true:
                        writer.Write("{0}=FIELD({1}) ", line.FieldName, line.ReferenceFieldName);
                        break;

                    case false:
                        writer.WriteLine("{0}=FIELD({1}){2}", line.FieldName, line.ReferenceFieldName, isLastLine ? ";" : ",");
                        break;
                }
            }

            writer.Unindent();
        }

        public static void Write(this NullableDecimalProperty property, bool isLastProperty, CSideWriter writer)
        {
            var stringValue = writer.CodeStyle.Localization.ConvertDecimalToString(property.Value);
            WriteSimpleProperty(property.Name, stringValue, isLastProperty, writer);
        }

        public static void Write(this SIFTLevelsProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            if (property.EmptyValueIsSet)
            {
                WriteSimpleProperty(property.Name, "", isLastProperty, writer);
                return;
            }
            //SIFTLevelsToMaintain=[{G/L Account No.,Global Dimension 1 Code},
            //          {G/L Account No.,Global Dimension 1 Code,Global Dimension 2 Code},
            //          {G/L Account No.,Global Dimension 1 Code,Global Dimension 2 Code,Posting Date:Year},
            //          {G/L Account No.,Global Dimension 1 Code,Global Dimension 2 Code,Posting Date:Month},
            //          {G/L Account No.,Global Dimension 1 Code,Global Dimension 2 Code,Posting Date:Day}] }
            var propertyName = writer.CodeStyle.CustomPropertyMappings.GetDisplayName(property.Name);
            writer.Write("{0}=[", propertyName);
            writer.Indent(writer.Column);

            foreach (var siftLevel in property.Value)
            {
                writer.Write("{");
                writer.Write(string.Join(",", siftLevel.Components.Select(f => f.FieldName + (!string.IsNullOrEmpty(f.Aspect) ? string.Format(":{0}", f.Aspect) : string.Empty))));

                var isLastLine = (siftLevel == property.Value.Last());

                switch (isLastLine)
                {
                    case true:
                        switch (isLastProperty)
                        {
                            case true:
                                writer.Write("}] ");
                                break;

                            default:
                                writer.WriteLine("}];");
                                break;
                        }
                        break;

                    default:
                        writer.WriteLine("},");
                        break;
                }
            }

            writer.Unindent();
        }
    }
}
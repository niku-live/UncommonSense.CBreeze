﻿using System;
using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static class ToInvocationMethods
    {
        private static string FunctionType(Function function)
        {
            if (function.TestFunctionType.HasValue)
                return "TestFunction";
            if (function.UpgradeFunctionType.HasValue)
                return "UpgradeFunction";
            if (!function.Event.HasValue)
                return "Function";
            if (function.Event == EventPublisherSubscriber.Subscriber)
                return "EventSubscriberFunction";
            if (function.EventType == EventType.Business)
                return "BusinessEventPublisherFunction";

            return "IntegrationEventPublisherFunction";
        }

        public static IEnumerable<ParameterBase> Parameters(this TableField field)
        {
            yield return new SimpleParameter("ID", field.ID);
            yield return new SimpleParameter("Name", field.Name);

            switch (field)
            {
                case CodeTableField c:
                    yield return new SimpleParameter("DataLength", c.DataLength);
                    break;

                case TextTableField t:
                    yield return new SimpleParameter("DataLength", t.DataLength);
                    break;
            }

            foreach (var parameter in field.AllProperties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> Parameters(this Variable variable)
        {
            yield return new SimpleParameter("ID", variable.ID);
            yield return new SimpleParameter("Name", variable.Name);

            switch (variable)
            {
                case CodeunitVariable c:
                    yield return new SimpleParameter("Dimensions", c.Dimensions); 
                    yield return new SimpleParameter("SubType", c.SubType);
                    break;

                case RecordVariable r:
                    yield return new SimpleParameter("Dimensions", r.Dimensions);
                    yield return new SimpleParameter("SubType", r.SubType);
                    yield return new SimpleParameter("Temporary", r.Temporary);
                    break;

                case TextConstant t:
                    yield return new SimpleParameter("Values", t.Values);
                    break;
            }

            // FIXME
        }

        public static IEnumerable<ParameterBase> Parameters(this TableFieldGroup fieldGroup)
        {
            yield return new SimpleParameter("ID", fieldGroup.ID);
            yield return new SimpleParameter("Name", fieldGroup.Name);
            yield return new SimpleParameter("FieldNames", fieldGroup.Fields);

            // FIXME: Properties
        }

        public static IEnumerable<ParameterBase> Parameters(this Function function)
        {
            yield return new SimpleParameter("ID", function.ID);
            yield return new SimpleParameter("Name", function.Name);
            yield return new SimpleParameter("Local", function.Local);
            yield return new SimpleParameter("ReturnValueName", function.ReturnValue.Name);
            yield return new SimpleParameter("ReturnValueType", function.ReturnValue.Type);
            yield return new SimpleParameter("ReturnValueDataLength", function.ReturnValue.DataLength);
            yield return new SimpleParameter("ReturnValueDimensions", function.ReturnValue.Dimensions);
            yield return new ScriptBlockParameter("SubObjects",
                function.Parameters.Select(
                    p => p.ToInvocation())
                        .Concat(function.CodeLines.Select(l => new Invocation($"'{l.Replace("'", "''")}'")))
                        .Concat(function.Variables.Select(v => v.ToInvocation()))
                    );
        }

        public static IEnumerable<ParameterBase> Parameters(this Parameter parameter)
        {
            yield return new SimpleParameter("ID", parameter.ID);
            yield return new SimpleParameter("Name", parameter.Name);
            yield return new SimpleParameter("Dimensions", parameter.Dimensions);
            yield return new SwitchParameter("Var", parameter.Var);

            switch (parameter)
            {
                case CodeParameter c:
                    yield return new SimpleParameter("DataLength", c.DataLength);
                    break;

                case TextParameter t:
                    yield return new SimpleParameter("DataLength", t.DataLength);
                    break;

                case RecordParameter r:
                    yield return new SimpleParameter("SubType", r.SubType);
                    break;
            }
        }

        public static IEnumerable<ParameterBase> Parameters(this TableRelationLine tableRelationLine)
        {
            yield return new SimpleParameter("TableName", tableRelationLine.TableName);
            yield return new SimpleParameter("FieldName", tableRelationLine.FieldName);

            yield return new ScriptBlockParameter(
               "SubObjects",
                tableRelationLine.Conditions.ToInvocations()
                .Concat(tableRelationLine.TableFilter.ToInvocations()));
        }

        public static Invocation ToInvocation(this Application application)
        {
            return new Invocation(
                "New-CBreezeApplication",
                new ScriptBlockParameter("Objects", application.Tables.ToInvocation()));
        }

        public static Invocation ToInvocation(this Table table)
        {
            IEnumerable<ParameterBase> signature = new[] {
                new SimpleParameter("ID", table.ID),
                new SimpleParameter("Name", table.Name)
            };

            IEnumerable<ParameterBase> objectProperties = table
                .ObjectProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> properties = table
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                    table.Fields.ToInvocation()
                    .Concat(table.FieldGroups.ToInvocation())
                    .Concat(table.Keys.ToInvocation())
                    .Concat(table.Code.Variables.ToInvocation())
                    .Concat(table.Code.Functions.ToInvocation()))
            };

            return new Invocation(
                "New-CBreezeTable",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects));
        }

        public static IEnumerable<Invocation> ToInvocation(this Tables tables) => tables.Select(t => t.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this TableFields fields) => fields.Select(f => f.ToInvocation());

        public static Invocation ToInvocation(this TableField field) => new Invocation($"New-CBreeze{field.Type}TableField", field.Parameters());

        public static IEnumerable<Invocation> ToInvocation(this TableKeys keys) => keys.Select(k => k.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this TableFieldGroups fieldGroups) => fieldGroups.Select(g => g.ToInvocation());

        public static Invocation ToInvocation(this TableFieldGroup fieldGroup) => new Invocation("New-CBreezeTableFieldGroup", fieldGroup.Parameters());
        public static IEnumerable<Invocation> ToInvocation(this Variables variables) => variables.Select(v => v.ToInvocation());

        public static Invocation ToInvocation(this Variable variable) => new Invocation($"New-CBreeze{variable.GetType().Name}", variable.Parameters());

        public static Invocation ToInvocation(this CalcFormula calcFormula)
        {
            return new Invocation("New-CBreezeCalcFormula",
                new SwitchParameter(calcFormula.Method.ToString(), true),
                new SimpleParameter("TableName", calcFormula.TableName),
                new SimpleParameter("FieldName", calcFormula.FieldName),
                new SwitchParameter("ReverseSign", calcFormula.ReverseSign),
                new ScriptBlockParameter("Filters", calcFormula.TableFilter.ToInvocations()))
            { SuppressTrailingNewLine = true }; // FIXME
        }

        public static IEnumerable<Invocation> ToInvocations(this CalcFormulaTableFilter calcFormulaTableFilter) => calcFormulaTableFilter.Select(l => l.ToInvocation());

        public static Invocation ToInvocation(this CalcFormulaTableFilterLine calcFormulaTableFilterLine)
        {
            return new Invocation("New-CBreezeCalcFormulaFilter", calcFormulaTableFilterLine.Parameters());
        }

        public static IEnumerable<ParameterBase> Parameters(this CalcFormulaTableFilterLine calcFormulaTableFilterLine)
        {
            yield return new SimpleParameter("FieldName", calcFormulaTableFilterLine.FieldName);
            yield return new SimpleParameter("Type", calcFormulaTableFilterLine.Type);
            yield return new SimpleParameter("Value", calcFormulaTableFilterLine.Value);
            yield return new SwitchParameter("OnlyMaxLimit", calcFormulaTableFilterLine.OnlyMaxLimit);
            yield return new SwitchParameter("ValueIsFilter", calcFormulaTableFilterLine.ValueIsFilter);
        }

        public static Invocation ToInvocation(this AccessByPermission accessByPermission)
        {
            return new Invocation("New-CBreezeAccessByPermission",
                new SimpleParameter("ObjectType", accessByPermission.ObjectType),
                new SimpleParameter("ObjectID", accessByPermission.ObjectID),
                new SwitchParameter("Read", accessByPermission.Read),
                new SwitchParameter("Insert", accessByPermission.Insert),
                new SwitchParameter("Modify", accessByPermission.Modify),
                new SwitchParameter("Delete", accessByPermission.Delete),
                new SwitchParameter("Execute", accessByPermission.Execute))
            { SuppressTrailingNewLine = true };
        }

        public static Invocation ToInvocation(this TableKey key)
        {
            var fields = new[] {
                new SimpleParameter("Fields", key.Fields)
            };

            var properties = key
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            return new Invocation("New-CBreezeTableKey", fields.Concat(properties));
        }

        public static IEnumerable<Invocation> ToInvocation(this Functions functions) => functions.Select(f => f.ToInvocation());

        public static Invocation ToInvocation(this Function function) => new Invocation($"New-CBreeze{FunctionType(function)}", function.Parameters());
        public static Invocation ToInvocation(this Parameter parameter) => new Invocation($"New-CBreeze{parameter.Type}Parameter", parameter.Parameters());
        public static Invocation ToInvocation(this TableRelationLine tableRelationLine) => new Invocation("New-CBreezeTableRelation", tableRelationLine.Parameters());

        public static Invocation ToInvocation(this TableRelationCondition condition)
        {
            return new Invocation("New-CBreezeTableRelationCondition", condition.Parameters());
        }

        public static IEnumerable<ParameterBase> Parameters(this TableRelationCondition condition)
        {
            yield return new SimpleParameter("FieldName", condition.FieldName);
            yield return new SimpleParameter("Type", condition.Type);
            yield return new SimpleParameter("Value", condition.Value);
        }

        public static IEnumerable<Invocation> ToInvocations(this TableRelation tableRelation) => tableRelation.Select(l => l.ToInvocation());
        public static IEnumerable<Invocation> ToInvocations(this TableRelationConditions conditions) => conditions.Select(c => c.ToInvocation());
        public static IEnumerable<Invocation> ToInvocations(this TableRelationTableFilter filter) => filter.Select(l => l.ToInvocation());

        public static Invocation ToInvocation(this TableRelationTableFilterLine tableRelationFilterLine)
        {
            return new Invocation("New-CBreezeTableRelationFilter", tableRelationFilterLine.Parameters());
        }

        public static IEnumerable<ParameterBase> Parameters(this TableRelationTableFilterLine tableRelationTableFilterLine)
        {
            yield return new SimpleParameter("FieldName", tableRelationTableFilterLine.FieldName);
            yield return new SimpleParameter("Type", tableRelationTableFilterLine.Type);
            yield return new SimpleParameter("Value", tableRelationTableFilterLine.Value);
        }

        public static IEnumerable<ParameterBase> ToParameters(this Property property)
        {
            switch (property)
            {
                case TriggerProperty t:
                    yield return new ScriptBlockParameter(
                        t.Name,
                        t.Value.Variables.ToInvocation().Concat(
                            t.Value.CodeLines.Select(c => new Invocation($"'{c.Replace("'", "''")}'"))));
                    yield break;

                case TableRelationProperty t:
                    yield return new ScriptBlockParameter("SubObjects", t.Value.ToInvocations());
                    yield break;

                case CalcFormulaProperty c:
                    yield return new SimpleParameter(c.Name, c.Value.ToInvocation());
                    yield break;

                case AccessByPermissionProperty a:
                    yield return new SimpleParameter(a.Name, a.Value.ToInvocation());
                    yield break;

                case DecimalPlacesProperty d:
                    yield return new SimpleParameter("DecimalPlacesAtLeast", d.Value.AtLeast);
                    yield return new SimpleParameter("DecimalPlacesAtMost", d.Value.AtMost);
                    yield break;

                default:
                    yield return new SimpleParameter(property.Name, property.GetValue());
                    yield break;
            }
        }
    }
}
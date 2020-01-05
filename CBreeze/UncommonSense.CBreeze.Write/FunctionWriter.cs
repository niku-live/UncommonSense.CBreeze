﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Function;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Property.Type;

namespace UncommonSense.CBreeze.Write
{
    public static class FunctionWriter
    {
        public static void Write(this Function function, CSideWriter writer)
        {
            writer.InnerWriter.WriteLine();
#if NAV2016
            WriteSubscriberAttributes(function, writer);
            writer.WriteLineIf(function.TryFunction.GetValueOrDefault(false), "[TryFunction]");
            WritePublisherAttributes(function, writer);
#endif
#if NAV2018
            writer.WriteLineIf(
                function.FunctionVisibility.GetValueOrDefault(Common.FunctionVisibility.Internal) == Common.FunctionVisibility.External &&
                function.ServiceEnabled.GetValueOrDefault(false),
                "[ServiceEnabled]");
#endif
#if NAV2019 || NAVBC
            writer.WriteLineIf(function.NormalFunctionType.HasValue, "[{0}]", function.NormalFunctionType);
#endif
#if NAV2015
            writer.WriteLineIf(function.UpgradeFunctionType.HasValue, "[{0}]", function.UpgradeFunctionType);
#endif
            writer.WriteLineIf(function.TestFunctionType.HasValue, "[{0}]", function.TestFunctionType);
            writer.WriteLineIf(function.HandlerFunctions != null, "[HandlerFunctions({0})]", function.HandlerFunctions);
            writer.WriteLineIf(function.TransactionModel.HasValue, "[TransactionModel({0})]", function.TransactionModel);
#if NAV2017
            writer.WriteLineIf(function.TestPermissions.HasValue, "[TestPermissions({0})]", function.TestPermissions);
#endif
#if NAV2018
            writer.WriteLineIf(function.FunctionVisibility.HasValue, "[{0}]", function.FunctionVisibility);
#endif
#if NAVBC
            writer.WriteLineIf(function.LineStart.HasValue, "[LineStart({0})]", GetLineStartForWrite(function, writer));
#endif
            writer.Write("{2}PROCEDURE {0}@{1}(", function.Name, function.ID, function.Local ? "LOCAL " : "");
            function.Parameters.Write(writer);
            writer.Write(")");
            function.ReturnValue.Write(writer);
            writer.WriteLine(";");
            function.Variables.Write(writer);
            writer.WriteLine("BEGIN");
            writer.Indent();
            function.CodeLines.Write(writer);
            writer.Unindent();
            writer.WriteLine("END;");
        }

#if NAV2016

        private static int? GetLineStartForWrite(Function function, CSideWriter writer)
        {
            if (writer.CodeStyle.ExportToNewSyntax)
            {
                return function.LineStart + 38;
            }
            return function.LineStart;
        }

        public static void WritePublisherAttributes(Function function, CSideWriter writer)
        {
            if (function.Event.GetValueOrDefault(EventPublisherSubscriber.No) != EventPublisherSubscriber.Publisher)
                return;

            switch (function.EventType)
            {
                case EventType.Business:
                    WriteBusinessEventAttributes(function, writer);
                    break;

                case EventType.Integration:
                    WriteIntegrationEventAttributes(function, writer);
                    break;
            }
        }

        public static void WriteSubscriberAttributes(Function function, CSideWriter writer)
        {
            if (function.Event.GetValueOrDefault(EventPublisherSubscriber.No) != EventPublisherSubscriber.Subscriber)
                return;

            if (function.EventPublisherObject.Type == null)
                return;
            if (function.EventPublisherObject.ID == null)
                return;
            if (string.IsNullOrEmpty(function.EventFunction))
                return;

            writer.Write(
                "[EventSubscriber({0},{1},{2}",
                function.EventPublisherObject.Type,
                function.EventPublisherObject.ID,
                function.EventFunction);

            var parameters =
                string.Format(
                    ",{0},{1}",
                    function.OnMissingLicense.HasValue ? function.OnMissingLicense.ToString() : "DEFAULT",
                    function.OnMissingPermission.HasValue ? function.OnMissingPermission.ToString() : "DEFAULT");
            var eventPublisherElement = string.IsNullOrEmpty(function.EventPublisherElement) ? ",\"\"" : string.Format(",{0}", function.EventPublisherElement);

            // Handle exceptional cases
            parameters = parameters == ",DEFAULT,DEFAULT" ? "" : parameters;
            parameters = parameters == ",Skip,DEFAULT" ? ",Skip" : parameters;
            parameters = parameters == ",Error,DEFAULT" ? ",Error" : parameters;
            eventPublisherElement = (parameters == "" && eventPublisherElement == ",\"\"" ? "" : eventPublisherElement);

            writer.WriteLine("{0}{1})]", eventPublisherElement, parameters);
        }

        public static void WriteBusinessEventAttributes(Function function, CSideWriter writer)
        {
            switch (function.IncludeSender)
            {
                case null:
                    writer.WriteLine("[Business]");
                    break;

                case true:
                    writer.WriteLine("[Business(TRUE)]");
                    break;

                case false:
                    writer.WriteLine("[Business(FALSE)]");
                    break;
            }
        }

        public static void WriteIntegrationEventAttributes(Function function, CSideWriter writer)
        {
            var parameters =
                string.Format(
                    "({0},{1})",
                    function.IncludeSender.HasValue ? function.IncludeSender.ToString().ToUpperInvariant() : "DEFAULT",
                    function.GlobalVarAccess.HasValue ? function.GlobalVarAccess.ToString().ToUpperInvariant() : "DEFAULT");

            // Handle exceptional cases
            parameters = parameters == "(DEFAULT,DEFAULT)" ? "" : parameters;
            parameters = parameters == "(FALSE,DEFAULT)" ? "(FALSE)" : parameters;
            parameters = parameters == "(TRUE,DEFAULT)" ? "(TRUE)" : parameters;

            writer.WriteLine("[Integration{0}]", parameters);
        }

#endif
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Common
{
    public class ApplicationCodeStyle
    {
        public static ApplicationCodeStyle CreateNav2CodeStyle()
        {
            return new ApplicationCodeStyle()
            {
                TextConstIsAlwaysMultiLine = false,
                NewLineBeforeTextConst = false,
                DoNotPrintEmptyReportDataItems = false,
                DoNotPrintEmptyRequestForm = false,
                DoNotPrintEmptyRequestPage = true,
                DoNotPrintEmptyFieldGroups = true,
                DoNotPrintEmptyDatasets = true,
                DoNotPrintEmptyLabels = true,
                DoNotPrintEmptyRdlReportLayout = true,
                DoNotPrintEmptyWordReportLayout = true,
                EmptyCaptionIsNotQuited = true,
                NoVariableIds = true,
                NonAnsiLettersAllowedInTableName = true,
                TableNameExceptions = new[] { '-' }
            };
        }


        public static ApplicationCodeStyle CreateNav4CodeStyle()
        {
            return new ApplicationCodeStyle()
            {
                TextConstIsAlwaysMultiLine = true,
                NewLineBeforeTextConst = true,
                DoNotPrintEmptyReportDataItems = false,
                DoNotPrintEmptyRequestForm = false,
                DoNotPrintEmptyRequestPage = true,
                DoNotPrintEmptyFieldGroups = true,
                DoNotPrintEmptyDatasets = true,
                DoNotPrintEmptyLabels = true,
                DoNotPrintEmptyRdlReportLayout = true,
                DoNotPrintEmptyWordReportLayout = true
            };
        }

        public static ApplicationCodeStyle CreateNav5CodeStyle()
        {
            return new ApplicationCodeStyle()
            {
                TextConstIsAlwaysMultiLine = false,
                NewLineBeforeTextConst = false,
                DoNotPrintEmptyReportDataItems = false,
                DoNotPrintEmptyRequestForm = false,
                DoNotPrintEmptyRequestPage = true,
                DoNotPrintEmptyFieldGroups = true,
                DoNotPrintEmptyDatasets = true,
                DoNotPrintEmptyLabels = true,
                DoNotPrintEmptyRdlReportLayout = true,
                DoNotPrintEmptyWordReportLayout = true
            };
        }

        public static ApplicationCodeStyle CreateNav2009CodeStyle()
        {
            return new ApplicationCodeStyle()
            {
                TextConstIsAlwaysMultiLine = false,
                NewLineBeforeTextConst = false,
                DoNotPrintEmptyReportDataItems = false,
                DoNotPrintEmptyRequestForm = false,
                DoNotPrintEmptyRequestPage = false,
                DoNotPrintEmptyFieldGroups = false,
                DoNotPrintEmptyDatasets = true,
                DoNotPrintEmptyLabels = true,
                DoNotPrintEmptyRdlReportLayout = false,
                DoNotPrintEmptyWordReportLayout = true
            };
        }

        public static ApplicationCodeStyle CreateNav2013CodeStyle()
        {
            return new ApplicationCodeStyle()
            {
                TextConstIsAlwaysMultiLine = false,
                NewLineBeforeTextConst = false,
                DoNotPrintEmptyReportDataItems = true,
                DoNotPrintEmptyRequestForm = true,
                DoNotPrintEmptyRequestPage = false,
                DoNotPrintEmptyFieldGroups = false,
                DoNotPrintEmptyDatasets = false,
                DoNotPrintEmptyLabels = false,
                DoNotPrintEmptyRdlReportLayout = false,
                DoNotPrintEmptyWordReportLayout = true
            };
        }


        public ApplicationCodeStyle()
        {
            DoNotPrintEmptyReportDataItems = true;
            DoNotPrintEmptyWordReportLayout = true;
            DoNotPrintEmptyRequestForm = true;
        }

        public bool TextConstIsAlwaysMultiLine { get; set; }
        public bool NewLineBeforeTextConst { get; set; }
        public bool DoNotPrintEmptyFieldGroups { get; set; }
        public bool DoNotPrintEmptyReportDataItems { get; set; }
        public bool DoNotPrintEmptyDatasets { get; set; }
        public bool DoNotPrintEmptyLabels { get; set; }
        public bool DoNotPrintEmptyRdlReportLayout { get; set; }
        public bool DoNotPrintEmptyWordReportLayout { get; set; }
        public bool DoNotPrintEmptyRequestPage { get; set; }
        public bool DoNotPrintEmptyRequestForm { get; set; }

        public PropertyMapCollection CustomPropertyMappings { get => Localization?.CustomPropertyMappings; }

        public PropertyMapCollection GetEnumMapping<T>(bool forTextValuePrinting = false)
        {
            return Localization?.GetEnumMapping<T>(forTextValuePrinting);
        }

        public bool UseEnclosedTimeFormat { get; set; }
        public bool EmptyCaptionIsNotQuited { get; set; }
        public bool NoVariableIds { get; set; }
        public bool NonAnsiLettersAllowedInTableName { get; set; }

        public char[] TableNameExceptions { get; set; } = { '-', '/', '.' };
        public char[] FieldNameExceptions { get; set; } = { '-', '/', '.', '_' };

        public Localization Localization { get; set; } = Localization.Default;

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Common
{
    public class ApplicationCodeStyle
    {
        public static ApplicationCodeStyle CreateNav1CodeStyle()
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
                UseEnclosedTimeFormat = true,
                PlatformVersion = new PlatformVersion("NAV1")
            };
        }

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
                UseEnclosedTimeFormat = true,
                PlatformVersion = new PlatformVersion("NAV2")
            };
        }

        public static ApplicationCodeStyle CreateNav3CodeStyle()
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
                PlatformVersion = new PlatformVersion("NAV3")
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
                DoNotPrintEmptyWordReportLayout = true,
                PlatformVersion = new PlatformVersion("NAV4")
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
                DoNotPrintEmptyWordReportLayout = true,
                PlatformVersion = new PlatformVersion("NAV5")
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
                DoNotPrintEmptyWordReportLayout = true,
                PlatformVersion = new PlatformVersion("NAV2009")
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
                DoNotPrintEmptyWordReportLayout = true,
                PlatformVersion = new PlatformVersion("NAV2013")
            };
        }

        public static ApplicationCodeStyle CreateNavCodeStyle(string versionName = "NAV2018")
        {
            PlatformVersion version = new PlatformVersion(versionName);
            ApplicationCodeStyle resultStyle = null;
            switch (version.MajorVersion)
            {
                case 1:
                    resultStyle = CreateNav1CodeStyle();
                    break;
                case 2:
                    resultStyle = CreateNav2CodeStyle();
                    break;
                case 3:
                    resultStyle = CreateNav3CodeStyle();
                    break;
                case 4:
                    resultStyle = CreateNav4CodeStyle();
                    break;
                case 5:
                    resultStyle = CreateNav5CodeStyle();
                    break;
                case 6:
                    resultStyle = CreateNav2009CodeStyle();
                    break;
                default:
                    resultStyle = CreateNav2013CodeStyle();
                    break;
            }
            resultStyle.PlatformVersion = version;
            return resultStyle;
        }


        public ApplicationCodeStyle()
        {
            DoNotPrintEmptyReportDataItems = true;
            DoNotPrintEmptyWordReportLayout = true;
            DoNotPrintEmptyRequestForm = true;
            PlatformVersion = new PlatformVersion("NAV2013");
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
        public bool PrintObjectReferenceAsName { get; set; }

        public PropertyMapCollection CustomPropertyMappings { get => Localization?.CustomPropertyMappings; }

        public List<INameResolver> ObjectNameResolvers { get; private set; } = new List<INameResolver>();

        public List<IFieldTypeResolver> FieldTypeResolvers { get; private set; } = new List<IFieldTypeResolver>();

        public PropertyMapCollection GetEnumMapping<T>(bool forTextValuePrinting = false)
        {
            return Localization?.GetEnumMapping<T>(forTextValuePrinting);
        }

        public bool UseEnclosedTimeFormat { get; set; }
        public bool EmptyCaptionIsNotQuited { get; set; }
        public bool NoVariableIds { get; set; }
        public bool NonAnsiLettersAllowedInTableName { get; set; }

        public char[] TableNameExceptions => Localization?.TableNameExceptions ?? new [] { '-', '/', '.' };
        public char[] FieldNameExceptions => Localization?.FieldNameExceptions ?? new [] { '-', '/', '.', '_' };

        public Localization Localization { get; set; } = Localization.Default;

        public PlatformVersion PlatformVersion { get; set; }
        public bool UseQuitesInFieldList { get; set; }
        public bool ExportToNewSyntax { get; set; }

        public override string ToString()
        {
            return $"Codestyle for {PlatformVersion} (locale: {Localization})";
        }

        public string ResolveObjectName(ObjectType objectType, int objectId)
        {
            return ObjectNameResolvers.Select(r => r.ResolveName(objectType, objectId)).FirstOrDefault(n => n != null);
        }

        public TableFieldType? ResolveTableFieldType(string tableName, string fieldName)
        {
            return FieldTypeResolvers.Select(r => r.ResolveFieldType(tableName, fieldName)).FirstOrDefault(t => t != null);
        }
    }
}

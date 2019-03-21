using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core.Common
{
    public class ApplicationCodeStyle
    {
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
            DateFormat = "dd-MM-yy";
            DateTimeFormat = "dd-MM-yy HH:mm";
            TimeFormat = "HH:mm:ss";
            DoNotPrintEmptyReportDataItems = true;
            DoNotPrintEmptyWordReportLayout = true;
            DoNotPrintEmptyRequestForm = true;
        }

        public string DateFormat { get; set; }
        public string DateTimeFormat { get; set; }
        public string TimeFormat { get; set; }
        public System.Globalization.NumberFormatInfo DecimalFormat { get; set; }


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

        public PropertyMapCollection CustomPropertyMappings { get; private set; } = new PropertyMapCollection();
        internal Dictionary<Type, PropertyMapCollection> EnumCustomMapping { get; private set; } = new Dictionary<Type, PropertyMapCollection>();
        internal Dictionary<Type, PropertyMapCollection> EnumTextCustomMapping { get; private set; } = new Dictionary<Type, PropertyMapCollection>();

        public PropertyMapCollection GetEnumMapping<T>(bool forTextValuePrinting = false)
        {            
            return forTextValuePrinting? GetEnumTextMapping(typeof(T)) : GetEnumMapping(typeof(T));
        }

        public PropertyMapCollection GetEnumMapping(Type enumType)
        {
            if (!EnumCustomMapping.ContainsKey(enumType))
            {
                EnumCustomMapping.Add(enumType, new PropertyMapCollection());
            }
            return EnumCustomMapping[enumType];
        }

        public PropertyMapCollection GetEnumTextMapping(Type enumType)
        {
            if (!EnumTextCustomMapping.ContainsKey(enumType))
            {
                EnumTextCustomMapping.Add(enumType, new PropertyMapCollection());
            }
            return EnumTextCustomMapping[enumType];
        }

        public string LocalizedYes { get; set; } = "Yes";
        public string LocalizedNo { get; set; } = "No";

        public bool UseEnclosedTimeFormat { get; set; }

        public bool EmptyCaptionIsNotQuited { get; set; }

        public bool NoVariableIds { get; set; }

        public bool NonAnsiLettersAllowedInTableName { get; set; }

        public char[] TableNameExceptions { get; set; } = { '-', '/', '.' };
        public char[] FieldNameExceptions { get; set; } = { '-', '/', '.', '_' };
    }
}

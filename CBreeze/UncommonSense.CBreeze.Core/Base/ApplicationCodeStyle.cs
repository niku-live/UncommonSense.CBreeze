using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core.Base
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

    }
}

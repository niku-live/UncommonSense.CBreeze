using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core.Base
{
    public class ApplicationCodeStyle
    {
        public string DateFormat { get; set; } = "dd-MM-yy";
        public string DateTimeFormat { get; set; } = "dd-MM-yy HH:mm";
        public string TimeFormat { get; set; } = "HH:mm:ss";

        public bool TextConstIsAlwaysMultiLine { get; set; }
        public bool NewLineBeforeTextConst { get; set; }
        public bool DoNotPrintEmptyFieldGroups { get; set; }
        public bool DoNotPrintEmptyReportDataItems { get; set; } = true;
        public bool DoNotPrintEmptyDatasets { get; set; }
        public bool DoNotPrintEmptyLabels { get; set; }
        public bool DoNotPrintEmptyRdlReportLayout { get; set; }
        public bool DoNotPrintEmptyWordReportLayout { get; set; } = true;
        public bool DoNotPrintEmptyRequestPage { get; set; }
        public bool DoNotPrintEmptyRequestForm { get; set; } = true;
    }
}

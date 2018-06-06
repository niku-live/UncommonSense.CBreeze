using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Common
{
    public enum SectionType
    {
        // General:
        ObjectProperties,
        Properties,

        // Table:
        Fields,
        Keys,
        FieldGroups,

        // Page, Form, Report:
        Controls,

        // Query:
        Elements,

        // XmlPort:
        Events,
        RequestPage,

        // Report:
        Dataset,
        Labels,
        RdlData,
        WordLayout,
        RequestForm,
        DataItems,
        Sections,

        // Menusuite:
        MenuNodes,

        // General:
        Code
    }
}

using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Codeunit;
using UncommonSense.CBreeze.Core.Common;
using UncommonSense.CBreeze.Core.Contracts;
#if NAV2009
using UncommonSense.CBreeze.Core.Dataport;
using UncommonSense.CBreeze.Core.Form;
#endif
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Query;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Table;
using UncommonSense.CBreeze.Core.XmlPort;

namespace UncommonSense.CBreeze.Core.Base
{
    public class Application : INode
    {
        public Application(params Object[] objects)
        {
            Tables = new Tables(this, objects.OfType<Table.Table>());
#if NAV2009
            Forms = new Forms(this, objects.OfType<Form.Form>());
            Dataports = new Dataports(this, objects.OfType<Dataport.Dataport>());
#endif
            Pages = new Pages(this, objects.OfType<Page.Page>());
            Reports = new Reports(this, objects.OfType<Report.Report>());
            XmlPorts = new XmlPorts(this, objects.OfType<XmlPort.XmlPort>());
            Codeunits = new Codeunits(this, objects.OfType<Codeunit.Codeunit>());
            Queries = new Queries(this, objects.OfType<Query.Query>());
            MenuSuites = new MenuSuites(this, objects.OfType<MenuSuite.MenuSuite>());
            CodeStyle = new ApplicationCodeStyle();
        }

        public ApplicationCodeStyle CodeStyle { get; set; }

        public Codeunits Codeunits { get; protected set; }

        public MenuSuites MenuSuites { get; protected set; }

        public IEnumerable<Object> Objects => Tables
            .AsEnumerable<Object>()
            .Concat(Pages.AsEnumerable<Object>())
#if NAV2009
            .Concat(Forms.AsEnumerable<Object>())
            .Concat(Dataports.AsEnumerable<Object>())
#endif
            .Concat(Reports.AsEnumerable<Object>())
            .Concat(XmlPorts.AsEnumerable<Object>())
            .Concat(Codeunits.AsEnumerable<Object>())
            .Concat(Queries.AsEnumerable<Object>())
            .Concat(MenuSuites.AsEnumerable<Object>());

        public Pages Pages { get; protected set; }

        public Queries Queries { get; protected set; }

        public Reports Reports { get; protected set; }

        public Tables Tables { get; protected set; }
#if NAV2009
        public Forms Forms { get; protected set; }

        public Dataports Dataports { get; protected set; }
#endif
        public XmlPorts XmlPorts { get; protected set; }

        IEnumerable<INode> INode.ChildNodes
        {
            get
            {
                yield return Tables;
#if NAV2009
                yield return Forms;
                yield return Dataports;
#endif
                yield return Pages;
                yield return Reports;
                yield return XmlPorts;
                yield return Codeunits;
                yield return Queries;
                yield return MenuSuites;
            }
        }

        public INode ParentNode => null;

        public void Clear()
        {
            Tables.Clear();
#if NAV2009
            Forms.Clear();
            Dataports.Clear();
#endif
            Pages.Clear();
            Reports.Clear();
            XmlPorts.Clear();
            Codeunits.Clear();
            Queries.Clear();
            MenuSuites.Clear();
        }
    }
}
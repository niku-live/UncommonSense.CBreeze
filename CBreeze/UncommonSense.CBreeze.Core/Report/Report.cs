using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Report
{
    public class Report : Object, IHasCode, IHasRequestPage, IHasRequestForm
    {
        public Report(string name) : this(0, name)
        {
        }

        public Report(int id, string name)
            : base(id, name)
        {
            Properties = new ReportProperties(this);
            Elements = new ReportElements(this);
            RequestPage = new RequestPage(this);
            Labels = new ReportLabels(this);
            Code = new Code.Variable.Code(this);
            RdlData = new RdlData(this);
#if NAV2015
            WordLayout = new WordLayout(this);
#endif
            RequestForm = new RequestForm(this);
        }

        public override ObjectType Type => ObjectType.Report;

        public Reports Container { get; internal set; }

        public ReportProperties Properties { get; protected set; }

        public ReportElements Elements { get; protected set; }

        public ReportLabels Labels { get; protected set; }

        public RdlData RdlData { get; protected set; }

#if NAV2015

        public WordLayout WordLayout { get; protected set; }

#endif

        public override Properties AllProperties => Properties;

        public Code.Variable.Code Code { get; protected set; }

        public RequestForm RequestForm { get; protected set; }

        public Application Application => Container?.Application;

        public RequestPage RequestPage { get; protected set; }

        public override INode ParentNode => Container;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Elements;
                yield return RequestPage;
                yield return Labels;
                yield return Code;
                yield return RdlData;
#if NAV2015
                yield return WordLayout;
#endif
                yield return RequestForm;
            }
        }
    }
}
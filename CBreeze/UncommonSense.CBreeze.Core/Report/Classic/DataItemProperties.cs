using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Report.Classic
{
    public class DataItemProperties : Properties
    {
        private readonly FieldListProperty _groupTotalFields = new FieldListProperty("GroupTotalFields");
        private readonly NullableBooleanProperty _newPagePerGroup = new NullableBooleanProperty("NewPagePerGroup");
        private readonly NullableBooleanProperty _newPagePerRecord = new NullableBooleanProperty("NewPagePerRecord");
        private readonly FieldListProperty _totalFields = new FieldListProperty("TotalFields");
        private readonly FieldListProperty calcFields = new FieldListProperty("CalcFields");
        private readonly ReportDataItemLinkProperty dataItemLink = new ReportDataItemLinkProperty("DataItemLink");
        private readonly StringProperty dataItemLinkReference = new StringProperty("DataItemLinkReference");
        private readonly TableReferenceProperty dataItemTable = new TableReferenceProperty("DataItemTable");
        private readonly TableViewProperty dataItemTableView = new TableViewProperty("DataItemTableView");
        private readonly NullableIntegerProperty maxIteration = new NullableIntegerProperty("MaxIteration");
        private readonly TriggerProperty onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private readonly TriggerProperty onPostDataItem = new TriggerProperty("OnPostDataItem");
        private readonly TriggerProperty onPreDataItem = new TriggerProperty("OnPreDataItem");
        private readonly NullableBooleanProperty printOnlyIfDetail = new NullableBooleanProperty("PrintOnlyIfDetail");
        private readonly FieldListProperty reqFilterFields = new FieldListProperty("ReqFilterFields");
        private readonly MultiLanguageProperty reqFilterHeadingML = new MultiLanguageProperty("ReqFilterHeadingML");

        internal DataItemProperties(DataItem dataItem)
        {
            DataItem = dataItem;
            innerList.Add(dataItemTable);
            innerList.Add(dataItemTableView);
            innerList.Add(maxIteration);
            innerList.Add(printOnlyIfDetail);
            innerList.Add(reqFilterHeadingML);
            innerList.Add(onPreDataItem);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onPostDataItem);
            innerList.Add(reqFilterFields);
            innerList.Add(calcFields);
            innerList.Add(dataItemLinkReference);
            innerList.Add(dataItemLink);
            innerList.Add(_groupTotalFields);
            innerList.Add(_newPagePerGroup);
            innerList.Add(_newPagePerRecord);
            innerList.Add(_totalFields);
        }

        public bool? NewPagePerGroup
        {
            get => _newPagePerGroup.Value;
            set => _newPagePerGroup.Value = value;
        }

        public bool? NewPagePerRecord
        {
            get => _newPagePerRecord.Value;
            set => _newPagePerRecord.Value = value;
        }

        public FieldList TotalFields => _totalFields.Value;

        public FieldList GroupTotalFields => _groupTotalFields.Value;


        public DataItem DataItem { get; protected set; }

        public override INode ParentNode => DataItem;

        public FieldList CalcFields => calcFields.Value;

        public ReportDataItemLink DataItemLink => dataItemLink.Value;

        public string DataItemLinkReference
        {
            get => dataItemLinkReference.Value;
            set => dataItemLinkReference.Value = value;
        }

        public int? DataItemTable
        {
            get => dataItemTable.Value;
            set => dataItemTable.Value = value;
        }

        public TableView DataItemTableView => dataItemTableView.Value;

        public int? MaxIteration
        {
            get => maxIteration.Value;
            set => maxIteration.Value = value;
        }

        public Trigger OnAfterGetRecord => onAfterGetRecord.Value;

        public Trigger OnPostDataItem => onPostDataItem.Value;

        public Trigger OnPreDataItem => onPreDataItem.Value;

        public bool? PrintOnlyIfDetail
        {
            get => printOnlyIfDetail.Value;
            set => printOnlyIfDetail.Value = value;
        }

        public FieldList ReqFilterFields => reqFilterFields.Value;

        public MultiLanguageValue ReqFilterHeadingML => reqFilterHeadingML.Value;
    }
}
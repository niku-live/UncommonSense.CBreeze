using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Core.Dataport
{
    public class DataportDataItemProperties : Properties
    {
        private readonly FieldListProperty calcFields = new FieldListProperty("CalcFields");
        private readonly ReportDataItemLinkProperty dataItemLink = new ReportDataItemLinkProperty("DataItemLink");
        private readonly StringProperty dataItemLinkReference = new StringProperty("DataItemLinkReference");
        private readonly TableReferenceProperty dataItemTable = new TableReferenceProperty("DataItemTable");
        private readonly TableViewProperty dataItemTableView = new TableViewProperty("DataItemTableView");
        private readonly NullableIntegerProperty maxIteration = new NullableIntegerProperty("MaxIteration");
        private readonly TriggerProperty onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private readonly TriggerProperty onPostDataItem = new TriggerProperty("OnPostDataItem");
        private readonly TriggerProperty onPreDataItem = new TriggerProperty("OnPreDataItem");
        private readonly FieldListProperty reqFilterFields = new FieldListProperty("ReqFilterFields");
        private readonly MultiLanguageProperty reqFilterHeadingML = new MultiLanguageProperty("ReqFilterHeadingML");
        private readonly NullableIntegerProperty _dataItemIndent = new NullableIntegerProperty("DataItemIndent");
        private readonly StringProperty _dataItemVarName = new StringProperty("DataItemVarName");
        private readonly NullableBooleanProperty _autoSave = new NullableBooleanProperty("AutoSave");
        private readonly NullableBooleanProperty _autoUpdate = new NullableBooleanProperty("AutoUpdate");
        private readonly NullableBooleanProperty _autoReplace = new NullableBooleanProperty("AutoReplace");
        private readonly TriggerProperty onBeforeExportRecord = new TriggerProperty("OnBeforeExportRecord");
        private readonly TriggerProperty onAfterExportRecord = new TriggerProperty("OnAfterExportRecord");
        private readonly TriggerProperty onBeforeImportRecord = new TriggerProperty("OnBeforeImportRecord");
        private readonly TriggerProperty onAfterImportRecord = new TriggerProperty("OnAfterImportRecord");
#if NAV3
        private readonly StringProperty _xmlDataItemName = new StringProperty("XMLDataItemName");
#endif


        internal DataportDataItemProperties(DataportDataItem dataItem)
        {
            DataItem = dataItem;
            innerList.Add(_dataItemIndent);
            innerList.Add(dataItemTable);
            innerList.Add(maxIteration);

            innerList.Add(calcFields);
            innerList.Add(_dataItemVarName);
            innerList.Add(_autoSave);
            innerList.Add(_autoUpdate);
            innerList.Add(_autoReplace);
            innerList.Add(dataItemLinkReference);
            innerList.Add(reqFilterHeadingML);
            innerList.Add(dataItemTableView);
            innerList.Add(dataItemLink);
            innerList.Add(reqFilterFields);
#if NAV3
            innerList.Add(_xmlDataItemName);
#endif
            innerList.Add(onPreDataItem);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onPostDataItem);
            innerList.Add(onBeforeExportRecord);
            innerList.Add(onAfterExportRecord);
            innerList.Add(onBeforeImportRecord);
            innerList.Add(onAfterImportRecord);
        }

        public DataportDataItem DataItem { get; protected set; }

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

        public FieldList ReqFilterFields => reqFilterFields.Value;

        public MultiLanguageValue ReqFilterHeadingML => reqFilterHeadingML.Value;

        public int? DataItemIndent
        {
            get => _dataItemIndent.Value;
            set => _dataItemIndent.Value = value;
        }

        public string DataItemVarName
        {
            get => _dataItemVarName.Value;
            set => _dataItemVarName.Value = value;
        }

        public bool? AutoSave
        {
            get => _autoSave.Value;
            set => _autoSave.Value = value;
        }

        public bool? AutoUpdate
        {
            get => _autoUpdate.Value;
            set => _autoUpdate.Value = value;
        }

        public bool? AutoReplace
        {
            get => _autoReplace.Value;
            set => _autoReplace.Value = value;
        }

        public Trigger OnBeforeExportRecord
        {
            get => onBeforeExportRecord.Value;
        }

        public Trigger OnAfterExportRecord
        {
            get => onAfterExportRecord.Value;
        }

        public Trigger OnBeforeImportRecord
        {
            get => onBeforeImportRecord.Value;
        }

        public Trigger OnAfterImportRecord
        {
            get => onAfterImportRecord.Value;
        }

#if NAV3
        public string XmlDataItemName
        {
            get => _xmlDataItemName.Value;
            set => _xmlDataItemName.Value = value;
        }
#endif
    }
}
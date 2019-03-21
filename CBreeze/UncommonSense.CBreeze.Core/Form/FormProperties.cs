using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form
{
    public class FormProperties : Properties
    {
        private readonly NullableIntegerProperty _activeControlOnOpen =
            new NullableIntegerProperty("ActiveControlOnOpen");

        private readonly AutoPositionProperty _autoPosition = new AutoPositionProperty("AutoPosition");
        private readonly NullableBooleanProperty _autoSplitKey = new NullableBooleanProperty("AutoSplitKey");
        private readonly NullableIntegerProperty _backColor = new NullableIntegerProperty("BackColor");
        private readonly FieldListProperty _calcFields = new FieldListProperty("CalcFields");
        private readonly CaptionBarProperty _captionBar = new CaptionBarProperty("CaptionBar");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");
        private readonly StringProperty _dataCaptionExpr = new StringProperty("DataCaptionExpr");
        private readonly FieldListProperty _dataCaptionFields = new FieldListProperty("DataCaptionFields");
        private readonly NullableBooleanProperty _delayedInsert = new NullableBooleanProperty("DelayedInsert");
        private readonly NullableBooleanProperty _deleteAllowed = new NullableBooleanProperty("DeleteAllowed");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _editable = new NullableBooleanProperty("Editable");
        private readonly NullableUnsignedIntegerProperty _height = new NullableUnsignedIntegerProperty("Height");
        private readonly NullableUnsignedIntegerProperty _horzGrid = new NullableUnsignedIntegerProperty("HorzGrid");
        private readonly NullableBooleanProperty _insertAllowed = new NullableBooleanProperty("InsertAllowed");
        private readonly NullableBooleanProperty _linksAllowed = new NullableBooleanProperty("LinksAllowed");
        private readonly StringProperty _logHeight = new StringProperty("LogHeight");
        private readonly StringProperty _logWidth = new StringProperty("LogWidth");
        private readonly NullableBooleanProperty _lookupMode = new NullableBooleanProperty("LookupMode");
        private readonly NullableBooleanProperty _maximizable = new NullableBooleanProperty("Maximizable");
        private readonly NullableBooleanProperty _maximizedOnOpen = new NullableBooleanProperty("MaximizedOnOpen");
        private readonly NullableBooleanProperty _minimizable = new NullableBooleanProperty("Minimizable");
        private readonly NullableBooleanProperty _minimizedOnOpen = new NullableBooleanProperty("MinimizedOnOpen");
        private readonly NullableBooleanProperty _modifyAllowed = new NullableBooleanProperty("ModifyAllowed");
        private readonly NullableBooleanProperty _multipleNewLines = new NullableBooleanProperty("MultipleNewLines");
        private readonly TriggerProperty _onActivateForm = new TriggerProperty("OnActivateForm");
        private readonly TriggerProperty _onAfterGetCurrRecord = new TriggerProperty("OnAfterGetCurrRecord");
        private readonly TriggerProperty _onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private readonly TriggerProperty _onBeforePutRecord = new TriggerProperty("OnBeforePutRecord");
        private readonly TriggerProperty _onCloseForm = new TriggerProperty("OnCloseForm");
        private readonly TriggerProperty _onCreateHyperlink = new TriggerProperty("OnCreateHyperlink");
        private readonly TriggerProperty _onDeactivateForm = new TriggerProperty("OnDeactivateForm");
        private readonly TriggerProperty _onDeleteRecord = new TriggerProperty("OnDeleteRecord");
        private readonly TriggerProperty _onFindRecord = new TriggerProperty("OnFindRecord");
        private readonly TriggerProperty _onHyperlink = new TriggerProperty("OnHyperlink");
        private readonly TriggerProperty _onInit = new TriggerProperty("OnInit");
        private readonly TriggerProperty _onInsertRecord = new TriggerProperty("OnInsertRecord");
        private readonly TriggerProperty _onModifyRecord = new TriggerProperty("OnModifyRecord");
        private readonly TriggerProperty _onNewRecord = new TriggerProperty("OnNewRecord");
        private readonly TriggerProperty _onNextRecord = new TriggerProperty("OnNextRecord");
        private readonly TriggerProperty _onOpenForm = new TriggerProperty("OnOpenForm");
        private readonly TriggerProperty _onQueryCloseForm = new TriggerProperty("OnQueryCloseForm");
        private readonly TriggerProperty _onTimer = new TriggerProperty("OnTimer");
        private readonly PermissionsProperty _permissions = new PermissionsProperty("Permissions");
        private readonly NullableBooleanProperty _populateAllFields = new NullableBooleanProperty("PopulateAllFields");
        private readonly NullableBooleanProperty _refreshOnActivate = new NullableBooleanProperty("RefreshOnActivate");
        private readonly NullableBooleanProperty _saveColumnWidths = new NullableBooleanProperty("SaveColumnWidths");
        private readonly NullableBooleanProperty _saveControlInfo = new NullableBooleanProperty("SaveControlInfo");
        private readonly NullableBooleanProperty _savePosAndSize = new NullableBooleanProperty("SavePosAndSize");
        private readonly NullableBooleanProperty _saveTableView = new NullableBooleanProperty("SaveTableView");
        private readonly NullableBooleanProperty _saveValues = new NullableBooleanProperty("SaveValues");
        private readonly NullableBooleanProperty _showFilter = new NullableBooleanProperty("ShowFilter");
        private readonly NullableBooleanProperty _sizeable = new NullableBooleanProperty("Sizeable");
        private readonly TableReferenceProperty _sourceTable = new TableReferenceProperty("SourceTable");

        private readonly SourceTablePlacementProperty _sourceTablePlacement =
            new SourceTablePlacementProperty("SourceTablePlacement");

        private readonly StringProperty _sourceTableRecord = new StringProperty("RecordID");

        private readonly NullableBooleanProperty _sourceTableTemporary =
            new NullableBooleanProperty("SourceTableTemporary");

        private readonly TableViewProperty _sourceTableView = new TableViewProperty("SourceTableView");
        private readonly NullableIntegerProperty _tableBoxId = new NullableIntegerProperty("TableBoxID");
        private readonly NullableIntegerProperty _timerInterval = new NullableIntegerProperty("TimerInterval");
        private readonly NullableBooleanProperty _updateOnActivate = new NullableBooleanProperty("UpdateOnActivate");
        private readonly NullableUnsignedIntegerProperty _vertGrid = new NullableUnsignedIntegerProperty("VertGrid");
        private readonly NullableBooleanProperty _visible = new NullableBooleanProperty("Visible");
        private readonly NullableUnsignedIntegerProperty _width = new NullableUnsignedIntegerProperty("Width");
        private readonly NullableUnsignedIntegerProperty _xPos = new NullableUnsignedIntegerProperty("XPos");
        private readonly NullableUnsignedIntegerProperty _yPos = new NullableUnsignedIntegerProperty("YPos");
        private readonly ClassicControlBorderStyleProperty _borderStyle = new ClassicControlBorderStyleProperty("BorderStyle");

        internal FormProperties(IForm form)
        {
            Form = form;

            innerList.Add(_permissions);
            innerList.Add(_xPos);
            innerList.Add(_yPos);
            innerList.Add(_width);
            innerList.Add(_height);
            innerList.Add(_editable);
            innerList.Add(_backColor);
            innerList.Add(_captionMl);
            innerList.Add(_borderStyle);
            innerList.Add(_captionBar);
            innerList.Add(_description);
            innerList.Add(_minimizable);
            innerList.Add(_minimizedOnOpen);
            innerList.Add(_maximizable);
            innerList.Add(_maximizedOnOpen);
            innerList.Add(_sizeable);
            innerList.Add(_activeControlOnOpen);
            innerList.Add(_saveControlInfo);
            innerList.Add(_saveValues);
            innerList.Add(_multipleNewLines);
            innerList.Add(_autoPosition);
            innerList.Add(_savePosAndSize);
            innerList.Add(_logWidth);
            innerList.Add(_logHeight);
            innerList.Add(_insertAllowed);
            innerList.Add(_deleteAllowed);
            innerList.Add(_modifyAllowed);
            innerList.Add(_linksAllowed);
            innerList.Add(_tableBoxId);
            innerList.Add(_lookupMode);
            innerList.Add(_sourceTable);
            innerList.Add(_autoSplitKey);
            innerList.Add(_sourceTablePlacement);
            innerList.Add(_saveTableView);
            innerList.Add(_dataCaptionExpr);
            innerList.Add(_updateOnActivate);
            innerList.Add(_delayedInsert);
            innerList.Add(_populateAllFields);
            innerList.Add(_sourceTableView);
            innerList.Add(_timerInterval);
            innerList.Add(_dataCaptionFields);
            innerList.Add(_sourceTableTemporary);
            innerList.Add(_refreshOnActivate);
            innerList.Add(_showFilter);
            innerList.Add(_sourceTableRecord);
            innerList.Add(_calcFields);
            innerList.Add(_horzGrid);
            innerList.Add(_vertGrid);
            innerList.Add(_saveColumnWidths);
            innerList.Add(_visible);
            innerList.Add(_onInit);
            innerList.Add(_onOpenForm);
            innerList.Add(_onCloseForm);
            innerList.Add(_onQueryCloseForm);
            innerList.Add(_onActivateForm);
            innerList.Add(_onFindRecord);
            innerList.Add(_onNextRecord);
            innerList.Add(_onAfterGetRecord);
            innerList.Add(_onAfterGetCurrRecord);
            innerList.Add(_onBeforePutRecord);
            innerList.Add(_onNewRecord);
            innerList.Add(_onInsertRecord);
            innerList.Add(_onModifyRecord);
            innerList.Add(_onDeleteRecord);
            innerList.Add(_onHyperlink);
            innerList.Add(_onCreateHyperlink);
            innerList.Add(_onTimer);
            innerList.Add(_onDeactivateForm);

        }

        public IForm Form { get; protected set; }

        public override INode ParentNode => Form;

        public bool? AutoSplitKey
        {
            get => _autoSplitKey.Value;
            set => _autoSplitKey.Value = value;
        }

        public MultiLanguageValue CaptionML => _captionMl.Value;

        public string DataCaptionExpr
        {
            get => _dataCaptionExpr.Value;
            set => _dataCaptionExpr.Value = value;
        }

        public FieldList DataCaptionFields => _dataCaptionFields.Value;

        public bool? DelayedInsert
        {
            get => _delayedInsert.Value;
            set => _delayedInsert.Value = value;
        }

        public ClassicControlBorderStyle? BorderStyle
        {
            get => _borderStyle.Value;
            set => _borderStyle.Value = value;
        }

        public bool? DeleteAllowed
        {
            get => _deleteAllowed.Value;
            set => _deleteAllowed.Value = value;
        }

        public string Description
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        public bool? Editable
        {
            get => _editable.Value;
            set => _editable.Value = value;
        }

        public bool? InsertAllowed
        {
            get => _insertAllowed.Value;
            set => _insertAllowed.Value = value;
        }

        public bool? LinksAllowed
        {
            get => _linksAllowed.Value;
            set => _linksAllowed.Value = value;
        }

        public bool? ModifyAllowed
        {
            get => _modifyAllowed.Value;
            set => _modifyAllowed.Value = value;
        }

        public bool? MultipleNewLines
        {
            get => _multipleNewLines.Value;
            set => _multipleNewLines.Value = value;
        }

        public Trigger OnBeforePutRecord => _onBeforePutRecord.Value;

        public Trigger OnDeactivateForm => _onDeactivateForm.Value;

        public Trigger OnActivateForm => _onActivateForm.Value;

        public Trigger OnAfterGetCurrRecord => _onAfterGetCurrRecord.Value;

        public Trigger OnAfterGetRecord => _onAfterGetRecord.Value;

        public Trigger OnCloseForm => _onCloseForm.Value;

        public Trigger OnDeleteRecord => _onDeleteRecord.Value;

        public Trigger OnFindRecord => _onFindRecord.Value;

        public Trigger OnInit => _onInit.Value;

        public Trigger OnInsertRecord => _onInsertRecord.Value;

        public Trigger OnModifyRecord => _onModifyRecord.Value;

        public Trigger OnNewRecord => _onNewRecord.Value;

        public Trigger OnNextRecord => _onNextRecord.Value;

        public Trigger OnOpenForm => _onOpenForm.Value;

        public Trigger OnQueryCloseForm => _onQueryCloseForm.Value;

        public Permissions Permissions => _permissions.Value;

        public bool? PopulateAllFields
        {
            get => _populateAllFields.Value;
            set => _populateAllFields.Value = value;
        }

        public bool? RefreshOnActivate
        {
            get => _refreshOnActivate.Value;
            set => _refreshOnActivate.Value = value;
        }

        public bool? SaveValues
        {
            get => _saveValues.Value;
            set => _saveValues.Value = value;
        }

        public bool? ShowFilter
        {
            get => _showFilter.Value;
            set => _showFilter.Value = value;
        }

        public int? SourceTable
        {
            get => _sourceTable.Value;
            set => _sourceTable.Value = value;
        }

        public bool? SourceTableTemporary
        {
            get => _sourceTableTemporary.Value;
            set => _sourceTableTemporary.Value = value;
        }

        public ClassicControlCaptionBar? CaptionBar => _captionBar.Value;

        public bool? Minimizable
        {
            get => _minimizable.Value;
            set => _minimizable.Value = value;
        }

        public bool? Maximizable
        {
            get => _maximizable.Value;
            set => _maximizable.Value = value;
        }

        public bool? Sizeable
        {
            get => _sizeable.Value;
            set => _sizeable.Value = value;
        }

        public string LogWidth
        {
            get => _logWidth.Value;
            set => _logWidth.Value = value;
        }

        public string LogHeight
        {
            get => _logHeight.Value;
            set => _logHeight.Value = value;
        }

        public uint? Width
        {
            get => _width.Value;
            set => _width.Value = value;
        }

        public uint? Height
        {
            get => _height.Value;
            set => _height.Value = value;
        }

        public uint? XPos
        {
            get => _xPos.Value;
            set => _xPos.Value = value;
        }

        public uint? YPos
        {
            get => _yPos.Value;
            set => _yPos.Value = value;
        }

        public int? BackColor
        {
            get => _backColor.Value;
            set => _backColor.Value = value;
        }

        public bool? Visible
        {
            get => _visible.Value;
            set => _visible.Value = value;
        }

        public int? ActiveControlOnOpen
        {
            get => _activeControlOnOpen.Value;
            set => _activeControlOnOpen.Value = value;
        }

        public bool? MinimizedOnOpen
        {
            get => _minimizedOnOpen.Value;
            set => _minimizedOnOpen.Value = value;
        }

        public bool? MaximizedOnOpen
        {
            get => _maximizedOnOpen.Value;
            set => _maximizedOnOpen.Value = value;
        }

        public ClassicControlAutoPosition? AutoPosition => _autoPosition.Value;

        public int? TableBoxID
        {
            get => _tableBoxId.Value;
            set => _tableBoxId.Value = value;
        }

        public bool? LookupMode
        {
            get => _lookupMode.Value;
            set => _lookupMode.Value = value;
        }

        public FieldList CalcFields => _calcFields.Value;

        public ClassicControlSourceTablePlacement? SourceTablePlacement => _sourceTablePlacement.Value;

        public string SourceTableRecord
        {
            get => _sourceTableRecord.Value;
            set => _sourceTableRecord.Value = value;
        }

        public bool? SaveTableView
        {
            get => _saveTableView.Value;
            set => _saveTableView.Value = value;
        }

        public bool? SaveControlInfo
        {
            get => _saveControlInfo.Value;
            set => _saveControlInfo.Value = value;
        }

        public bool? SaveColumnWidths
        {
            get => _saveColumnWidths.Value;
            set => _saveColumnWidths.Value = value;
        }

        public bool? SavePosAndSize
        {
            get => _savePosAndSize.Value;
            set => _savePosAndSize.Value = value;
        }

        public bool? UpdateOnActivate
        {
            get => _updateOnActivate.Value;
            set => _updateOnActivate.Value = value;
        }

        public uint? HorzGrid
        {
            get => _horzGrid.Value;
            set => _horzGrid.Value = value;
        }

        public uint? VertGrid
        {
            get => _vertGrid.Value;
            set => _vertGrid.Value = value;
        }

        public int? TimerInterval
        {
            get => _timerInterval.Value;
            set => _timerInterval.Value = value;
        }

        public TableView SourceTableView => _sourceTableView.Value;

        public Trigger OnTimer => _onTimer.Value;

        public Trigger OnCreateHyperlink => _onCreateHyperlink.Value;

        public Trigger OnHyperlink => _onHyperlink.Value;
    }
}
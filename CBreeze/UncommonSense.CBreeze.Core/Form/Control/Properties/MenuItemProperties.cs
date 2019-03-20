using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class MenuItemProperties : Property.Properties
    {
        private readonly StringProperty _captionClass = new StringProperty("CaptionClass");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _ellipsis = new NullableBooleanProperty("Ellipsis");
        private readonly NullableBooleanProperty _enabled = new NullableBooleanProperty("Enabled");
        private readonly IntegerProperty _id = new IntegerProperty("ID");

        private readonly InvalidActionAppearanceProperty _invalidActionAppearance =
            new InvalidActionAppearanceProperty("InvalidActionAppearance");

        private readonly MenuItemTypeProperty _menuItemType = new MenuItemTypeProperty("MenuItemType");
        private readonly NullableIntegerProperty _menuLevel = new NullableIntegerProperty("MenuLevel");
        private readonly StringProperty _name = new StringProperty("Name");
        private readonly PushActionProperty _pushAction = new PushActionProperty("PushAction");
        private readonly StringProperty _runCommand = new StringProperty("RunCommand");
        private readonly RunObjectLinkProperty _runFormLink = new RunObjectLinkProperty("RunFormLink");
        private readonly RunFormLinkTypeProperty _runFormLinkType = new RunFormLinkTypeProperty("RunFormLinkType");
        private readonly NullableBooleanProperty _runFormOnRec = new NullableBooleanProperty("RunFormOnRec");
        private readonly TableViewProperty _runFormView = new TableViewProperty("RunFormView");
        private readonly RunObjectProperty _runObject = new RunObjectProperty("RunObject");
        private readonly StringProperty _shortCutKey = new StringProperty("ShortCutKey");
        private readonly StringProperty _sourceExpr = new StringProperty("SourceExpr");
        private readonly MultiLanguageProperty _tooltipMl = new MultiLanguageProperty("TooltipML");
        private readonly NullableBooleanProperty _updateOnAction = new NullableBooleanProperty("UpdateOnAction");
        private readonly NullableBooleanProperty _visible = new NullableBooleanProperty("Visible");
        private readonly TriggerProperty _onPush = new TriggerProperty("OnPush");
        private FormMenuItemBase menuItemBase;

        public MenuItemProperties(FormMenuItemBase menuItemBase)
        {
            this.menuItemBase = menuItemBase;
            innerList.Add(_id);
            innerList.Add(_pushAction);
            innerList.Add(_shortCutKey);
            innerList.Add(_menuItemType);
            innerList.Add(_ellipsis);
            innerList.Add(_menuLevel);
            innerList.Add(_captionClass);
            innerList.Add(_visible);
            innerList.Add(_name);
            innerList.Add(_enabled);
            innerList.Add(_captionMl);
            innerList.Add(_description);
            innerList.Add(_invalidActionAppearance);
            innerList.Add(_runCommand);
            innerList.Add(_runObject);
            innerList.Add(_runFormLinkType);
            innerList.Add(_runFormOnRec);
            innerList.Add(_updateOnAction);
            innerList.Add(_runFormView);
            innerList.Add(_runFormLink);
            innerList.Add(_sourceExpr);
            innerList.Add(_tooltipMl);
            innerList.Add(_onPush);
        }

        public override INode ParentNode { get; }

        /*public PushAction PushAction
        {
            get => _pushAction.Value;
            set => _pushAction.Value = value;
        }*/

        public RunObject RunObject => _runObject.Value;

        public TableView RunFormView => _runFormView.Value;

        public RunObjectLink RunFormLink
        {
            get => _runFormLink.Value;
        }

        public RunFormLinkType? RunFormLinkType
        {
            get => _runFormLinkType.Value;
            set => _runFormLinkType.Value = value;
        }

        public bool? RunFormOnRec
        {
            get => _runFormOnRec.Value;
            set => _runFormOnRec.Value = value;
        }

        public string RunCommand
        {
            get => _runCommand.Value;
            set => _runCommand.Value = value;
        }

        public bool? UpdateOnAction
        {
            get => _updateOnAction.Value;
            set => _updateOnAction.Value = value;
        }

        public int Id
        {
            get => _id.Value;
            set => _id.Value = value;
        }

        public string Name
        {
            get => _name.Value;
            set => _name.Value = value;
        }

        public bool? Visible
        {
            get => _visible.Value;
            set => _visible.Value = value;
        }

        public bool? Enabled
        {
            get => _enabled.Value;
            set => _enabled.Value = value;
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;

        public InvalidActionAppearance? InvalidActionAppearance
        {
            get => _invalidActionAppearance.Value;
            set => _invalidActionAppearance.Value = value;
        }

        public MenuItemType MenuItemType
        {
            get => _menuItemType.Value;
            set => _menuItemType.Value = value;
        }

        public string ShortCutKey
        {
            get => _shortCutKey.Value;
            set => _shortCutKey.Value = value;
        }

        public bool? Ellipsis
        {
            get => _ellipsis.Value;
            set => _ellipsis.Value = value;
        }

        public int? MenuLevel
        {
            get => _menuLevel.Value;
            set => _menuLevel.Value = value;
        }

        public MultiLanguageValue TooltipMl => _tooltipMl.Value;

        public string Description
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        public string CaptionClass
        {
            get => _captionClass.Value;
            set => _captionClass.Value = value;
        }

        public string SourceExpr
        {
            get => _sourceExpr.Value;
            set => _sourceExpr.Value = value;
        }

        public Trigger OnPush
        {
            get => _onPush.Value;
        }
    }
}
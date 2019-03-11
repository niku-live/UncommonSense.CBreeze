using System.Drawing;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseButtonProperties : ControlBasePropertiesWithFont, IButton
    {
        private readonly StringProperty _bitmap = new StringProperty("Bitmap");
        private readonly BitmapPosProperty _bitmapPos = new BitmapPosProperty("BitmapPos");
        private readonly NullableBooleanProperty _focusOnClick = new NullableBooleanProperty("FocusOnClick");
        private readonly PushActionProperty _pushAction = new PushActionProperty("PushAction");
        private readonly StringProperty _runCommand = new StringProperty("RunCommand");
        private readonly StringProperty _runFormLink = new StringProperty("RunFormLink");
        private readonly RunFormLinkTypeProperty _runFormLinkType = new RunFormLinkTypeProperty("RunFormLinkType");
        private readonly NullableBooleanProperty _runFormOnRec = new NullableBooleanProperty("RunFormOnRec");
        private readonly StringProperty _runFormView = new StringProperty("RunFormView");
        private readonly RunObjectProperty _runObject = new RunObjectProperty("RunObject");

        protected BaseButtonProperties(FormControl control) : base(control)
        {
            innerList.Add(_bitmap);
            innerList.Add(_bitmapPos);
            innerList.Add(_focusOnClick);
            innerList.Add(_pushAction);
            innerList.Add(_runCommand);
            innerList.Add(_runFormLink);
            innerList.Add(_runFormLinkType);
            innerList.Add(_runFormOnRec);
            innerList.Add(_runFormView);
            innerList.Add(_runObject);
        }

        public string CaptionClass { get; set; }

        public bool? FocusOnClick
        {
            get => _focusOnClick.Value;
            set => _focusOnClick.Value = value;
        }

        public BitmapPos BitmapPos
        {
            get => _bitmapPos.Value;
            set => _bitmapPos.Value = value;
        }

        public string Bitmap
        {
            get => _bitmap.Value;
            set => _bitmap.Value = value;
        }

        public PushAction PushAction
        {
            get => _pushAction.Value;
            set => _pushAction.Value = value;
        }

        public RunObject RunObject => _runObject.Value;

        public string RunFormView
        {
            get => _runFormView.Value;
            set => _runFormView.Value = value;
        }

        public string RunFormLink
        {
            get => _runFormLink.Value;
            set => _runFormLink.Value = value;
        }

        public RunFormLinkType RunFormLinkType
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

    }
}
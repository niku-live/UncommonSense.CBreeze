using System.Drawing;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseButtonProperties : BaseControlBaseProperties2, IButton
    {
        protected BaseButtonProperties(FormControl control) : base(control)
        {
        }

        public bool? FocusOnClick
        {
            get => InternalFocusOnClick;
            set => InternalFocusOnClick = value;
        }

        public BitmapPos? BitmapPos
        {
            get => InternalBitmapPos;
            set => InternalBitmapPos = value;
        }

        public string CaptionClass
        {
            get => InternalCaptionClass;
            set => InternalCaptionClass = value;
        }

        public RunObject RunObject => InternalRunObject;

        public string RunFormView
        {
            get => InternalRunFormView;
            set => InternalRunFormView = value;
        }

        public RunObjectLink RunFormLink
        {
            get => InternalRunFormLink;
        }

        public RunFormLinkType? RunFormLinkType
        {
            get => InternalRunFormLinkType;
            set => InternalRunFormLinkType = value;
        }

        public bool? RunFormOnRec
        {
            get => InternalRunFormOnRec;
            set => InternalRunFormOnRec = value;
        }

        public string RunCommand
        {
            get => InternalRunCommand;
            set => InternalRunCommand = value;
        }

    }
}
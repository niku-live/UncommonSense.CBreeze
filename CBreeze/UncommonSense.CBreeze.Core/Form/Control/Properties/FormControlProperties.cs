using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class FormControlProperties : Property.Properties, IFormControlProperties
    {
        private readonly NullableUnsignedIntegerProperty _height = new NullableUnsignedIntegerProperty("Height");
        private readonly HorzGlueProperty _horzGlue = new HorzGlueProperty("HorzGlue");
        private readonly NullableBooleanProperty _inFrame = new NullableBooleanProperty("InFrame");
        private readonly NullableIntegerProperty _inPage = new NullableIntegerProperty("InFrame");
        private readonly StringProperty _name = new StringProperty("Name");

        private readonly NullableUnsignedIntegerProperty _parentControl =
            new NullableUnsignedIntegerProperty("ParentControl");

        private readonly MultiLanguageProperty _toolTipMl = new MultiLanguageProperty("ToolTipML");
        private readonly VertGlueProperty _vertGlue = new VertGlueProperty("VertGlue");
        private readonly NullableBooleanProperty _visible = new NullableBooleanProperty("Visible");
        private readonly NullableUnsignedIntegerProperty _width = new NullableUnsignedIntegerProperty("Width");
        private readonly NullableUnsignedIntegerProperty _xPos = new NullableUnsignedIntegerProperty("XPos");
        private readonly NullableUnsignedIntegerProperty _yPos = new NullableUnsignedIntegerProperty("YPos");

        protected FormControlProperties(FormControl control)
        {
            Control = control;

            innerList.Add(_name);
            innerList.Add(_height);
            innerList.Add(_horzGlue);
            innerList.Add(_inFrame);
            innerList.Add(_inPage);
            innerList.Add(_parentControl);
            innerList.Add(_toolTipMl);
            innerList.Add(_vertGlue);
            innerList.Add(_visible);
            innerList.Add(_width);
            innerList.Add(_xPos);
            innerList.Add(_yPos);
        }

        public FormControl Control { get; }

        public override INode ParentNode => Control;


        private FormControlBase Parent { get; set; }

        public int? InPage
        {
            get => _inPage.Value;
            set => _inPage.Value = value;
        }

        public bool? InFrame
        {
            get => _inFrame.Value;
            set => _inFrame.Value = value;
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

        public VertGlue? VertGlue
        {
            get => _vertGlue.Value;
            set => _vertGlue.Value = value;
        }

        public HorzGlue? HorzGlue
        {
            get => _horzGlue.Value;
            set => _horzGlue.Value = value;
        }

        public uint? ParentControl
        {
            get => _parentControl.Value;
            set => _parentControl.Value = value;
        }


        public MultiLanguageValue ToolTipML => _toolTipMl.Value;
    }
}
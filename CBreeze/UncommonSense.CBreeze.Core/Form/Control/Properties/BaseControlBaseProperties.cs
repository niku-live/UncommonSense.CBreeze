using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseControlBaseProperties : FormControlProperties, IBaseControl
    {
        private readonly NullableBooleanProperty _focusable = new NullableBooleanProperty("Focusable");
        private readonly ColorProperty _backColor = new ColorProperty("BackColor");
        private readonly NullableBooleanProperty _backTransparent = new NullableBooleanProperty("BackTransparent");
        private readonly NullableBooleanProperty _border = new NullableBooleanProperty("Border");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _showCaption = new NullableBooleanProperty("ShowCaption");

        protected BaseControlBaseProperties(FormControl control) : base(control)
        {
            innerList.Add(_focusable);
            innerList.Add(_showCaption);
            innerList.Add(_backColor);
            innerList.Add(_backTransparent);
            innerList.Add(_border);
            innerList.Add(_description);
        }

        public bool? Focusable
        {
            get => _focusable.Value;
            set => _focusable.Value = value;
        }

        public bool? ShowCaption
        {
            get => _showCaption.Value;
            set => _showCaption.Value = value;
        }

        public bool? Border
        {
            get => _border.Value;
            set => _border.Value = value;
        }

        public string Description
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        public bool? BackTransparent
        {
            get => _backTransparent.Value;
            set => _backTransparent.Value = value;
        }

        public Color BackColor
        {
            get => _backColor.Value;
            set => _backColor.Value = value;
        }
    }
}
using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FrameProperties : BaseControlBaseProperties2, IFrame
    {
        private readonly NullableBooleanProperty _topLineOnly = new NullableBooleanProperty("TopLineOnly");

        public FrameProperties(FormControl control) : base(control)
        {
            innerList.Add(_topLineOnly);
        }

        public Color? BorderColor
        {
            get => InternalBorderColor;
            set => InternalBorderColor = value;
        }

        public BorderWidth? BorderWidth
        {
            get => InternalBorderWidth;
            set => InternalBorderWidth = value;
        }

        public bool? TopLineOnly
        {
            get => _topLineOnly.Value;
            set => _topLineOnly.Value = value;
        }
    }
}
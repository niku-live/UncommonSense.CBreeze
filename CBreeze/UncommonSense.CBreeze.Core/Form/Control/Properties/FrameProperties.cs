using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FrameProperties : BaseControlBaseProperties2, IFrame
    {        
        public FrameProperties(FormControl control) : base(control)
        {
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
            get => InternalTopLineOnly;
            set => InternalTopLineOnly = value;
        }
    }
}
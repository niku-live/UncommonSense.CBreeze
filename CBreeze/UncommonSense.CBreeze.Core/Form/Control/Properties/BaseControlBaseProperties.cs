using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseControlBaseProperties : FormControlProperties, IBaseControl
    {
        protected BaseControlBaseProperties(FormControl control) : base(control)
        {
        }

        public BorderStyle? BorderStyle
        {
            get => InternalBorderStyle;
            set => InternalBorderStyle = value;
        }

        public string Description
        {
            get => InternalDescription;
            set => InternalDescription = value;
        }

        public MultiLanguageValue CaptionMl => InternalCaptionMl;

        public string Caption { get => InternalCaption; set => InternalCaption = value; }

        public bool? DropDown
        {
            get => InternalDropDown;
            set => InternalDropDown = value;
        }

        public bool? DrillDown
        {
            get => InternalDrillDown;
            set => InternalDrillDown = value;
        }

        public string DrillDownFormID
        {
            get => InternalDrillDownFormID;
            set => InternalDrillDownFormID = value;
        }
    }
}
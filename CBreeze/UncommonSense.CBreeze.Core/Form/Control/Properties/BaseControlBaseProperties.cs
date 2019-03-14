using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseControlBaseProperties : ControlBasePropertiesWithFont, IBaseControl
    {
        private readonly NullableBooleanProperty _drillDown = new NullableBooleanProperty("DrillDown");
        private readonly StringProperty _drillDownFormID = new StringProperty("DrillDownFormID");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _dropDown = new NullableBooleanProperty("DropDown");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");

        protected BaseControlBaseProperties(FormControl control) : base(control)
        {
            innerList.Add(_drillDown);
            innerList.Add(_drillDownFormID);
            innerList.Add(_borderStyle);
            innerList.Add(_dropDown);
            innerList.Add(_captionMl);
            innerList.Add(_description);
        }

        public BorderStyle? BorderStyle
        {
            get => _borderStyle.Value;
            set => _borderStyle.Value = value;
        }

        public string Description
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;

        public bool? DropDown
        {
            get => _dropDown.Value;
            set => _dropDown.Value = value;
        }

        public bool? DrillDown
        {
            get => _drillDown.Value;
            set => _drillDown.Value = value;
        }

        public string DrillDownFormID
        {
            get => _drillDownFormID.Value;
            set => _drillDownFormID.Value = value;
        }
    }
}
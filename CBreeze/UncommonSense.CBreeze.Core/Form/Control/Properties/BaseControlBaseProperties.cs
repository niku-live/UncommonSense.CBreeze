using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class BaseControlBaseProperties : ControlBasePropertiesWithFont, IBaseControl
    {
        private readonly NullableBooleanProperty _drillDown = new NullableBooleanProperty("DrillDown");
        private readonly StringProperty _drillDownFormID = new StringProperty("DrillDownFormID");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");

        protected BaseControlBaseProperties(FormControl control) : base(control)
        {
            innerList.Add(_drillDown);
            innerList.Add(_drillDownFormID);
            innerList.Add(_captionMl);
            innerList.Add(_description);
        }

        public string Description
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;

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
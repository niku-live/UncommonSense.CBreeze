namespace UncommonSense.CBreeze.Core.Form.Control
{
    public class FormMenuItem : FormMenuItemBase
    {
        internal FormMenuItem(int id, int? menuLevel, FormMenuButtonControl parent) : base(id, menuLevel, parent)
        {
        }

        public FormMenuItem(FormMenuButtonControl parent) : base(parent)
        {
        }
    }
}
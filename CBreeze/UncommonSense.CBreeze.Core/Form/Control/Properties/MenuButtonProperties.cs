using UncommonSense.CBreeze.Core.Form.Contracts;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class MenuButtonProperties : BaseButtonProperties, IMenuButton
    {
        private Property.Implementation.ClassicMenuProperty _menu;

        public MenuButtonProperties(FormControl control) : base(control)
        {
            _menu =  new Property.Implementation.ClassicMenuProperty("Menu", control);
            innerList.Add(_menu);
           
        }

        public FormMenuItems Menu
        {
            get => _menu.Value;
        }
    }
}
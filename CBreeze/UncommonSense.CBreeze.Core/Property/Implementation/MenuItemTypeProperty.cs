using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class MenuItemTypeProperty : ValueProperty<MenuItemType>
    {
        public MenuItemTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue => Value != MenuItemType.MenuItem;
        public override void Reset()
        {
            Value = MenuItemType.MenuItem;
        }
    }
}
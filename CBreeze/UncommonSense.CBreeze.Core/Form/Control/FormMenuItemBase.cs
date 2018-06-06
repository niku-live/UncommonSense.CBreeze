using System;
using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Form.Control.Properties;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form.Control
{
    public class FormMenuItemBase : KeyedItem<int>, IHasName, IHasProperties, INode
    {
        internal FormMenuItemBase(int id, int? menuLevel, FormMenuButtonControl parent) : this(parent)
        {
            ID = id;
            Properties.Id = id;
            Properties.MenuLevel = menuLevel;
            MenuLevel = menuLevel;
        }

        public FormMenuItemBase(FormMenuButtonControl parent)
        {
            Parent = parent;
            Properties = new MenuItemProperties(this);
        }

        public FormMenuButtonControl Parent { get; }

        public FormMenuItems Container { get; internal set; }

        public int? MenuLevel
        {
            get => Properties.MenuLevel;
            set => Properties.MenuLevel = value;
        }

        public new int ID
        {
            get => Properties.Id;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                ID = value;
                Properties.Id = value;
            }
        }

        public int Index => Container.IndexOf(this);

        public IEnumerable<FormMenuItemBase> Descendants =>
            Container.Skip(Index + 1).TakeWhile(a => a.MenuLevel > (MenuLevel ?? 0));

        public IEnumerable<FormMenuItemBase> Children =>
            Descendants.Where(a => a.MenuLevel == (MenuLevel ?? 0) + 1);

        public MenuItemType MenuItemType
        {
            get => Properties.MenuItemType;
            set => Properties.MenuItemType = value;
        }


        public MenuItemProperties Properties { get; protected set; }

        public string GetName()
        {
            return Properties.Name;
        }

        public Property.Properties AllProperties => Properties;

        public INode ParentNode => Container;

        public IEnumerable<INode> ChildNodes
        {
            get { yield return Properties; }
        }

        public T AddChildMenuItem<T>(T child, Position position) where T : FormMenuItemBase
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var descendantsMenuItems = Descendants;
                    var lastIndex = descendantsMenuItems.Any() ? descendantsMenuItems.Last().Index : Index;
                    Container.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }
    }
}
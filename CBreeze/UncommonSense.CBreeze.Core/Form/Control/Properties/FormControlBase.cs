using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class FormControlBase : KeyedItem<int>, IHasProperties, INode, IHasName
    {
        internal FormControlBase(int id, int posX, int posY, int width, int height)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            ID = id;
        }

        public int PosX { get; protected set; }
        public int PosY { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public virtual FormControls Container { get; internal set; }

        public int Index => Container.IndexOf(this);

        public abstract ClassicControlType Type { get; }

        public abstract string GetName();

        public abstract Property.Properties AllProperties { get; }

        public abstract IEnumerable<INode> ChildNodes { get; }

        public INode ParentNode => Container;

        public T AddChildPageControl<T>(T child, Position position) where T : FormControlBase
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;

                case Position.LastWithinContainer:
                    var lastIndex = Index;
                    Container.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }
    }
}
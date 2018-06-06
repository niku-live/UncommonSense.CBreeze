using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Form
{
    public abstract class FormElement : KeyedItem<int>, IHasName, IHasProperties, INode
    {
        public string Name { get; set; }

        public int? IndentationLevel { get; protected set; }

        public FormElements Container { get; internal set; }

        public int Index => Container.IndexOf(this);

        public IEnumerable<FormElement> Descendants => Container.Skip(Index + 1).TakeWhile(e =>
            e.IndentationLevel.GetValueOrDefault(0) > IndentationLevel.GetValueOrDefault(0));

        public IEnumerable<FormElement> Children =>
            Descendants.Where(e => e.IndentationLevel == IndentationLevel.GetValueOrDefault(0) + 1);

        public string GetName()
        {
            return Name;
        }

        public abstract Properties AllProperties { get; }
        public INode ParentNode => Container;
        public abstract IEnumerable<INode> ChildNodes { get; }

        public T AddChildNode<T>(T child, Position position) where T : FormElement
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var descendantElements = Descendants;
                    var lastIndex = descendantElements.Any() ? descendantElements.Last().Index : Index;
                    Container.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }
    }
}
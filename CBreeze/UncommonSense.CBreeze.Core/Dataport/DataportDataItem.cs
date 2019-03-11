using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Report.Classic.Section;

namespace UncommonSense.CBreeze.Core.Dataport
{
    public class DataportDataItem : KeyedItem<int>, IHasName, IHasProperties, INode
    {
        public DataportDataItem()
        {
            Properties = new DataportDataItemProperties(this);
            Fields = new DataportFields(this);
        }

        public int Index => Container.IndexOf(this);

        public IEnumerable<DataportDataItem> Descendants => Container.Skip(Index + 1).TakeWhile(e =>
            e.IndentationLevel.GetValueOrDefault(0) > IndentationLevel.GetValueOrDefault(0));

        public IEnumerable<DataportDataItem> Children =>
            Descendants.Where(e => e.IndentationLevel == IndentationLevel.GetValueOrDefault(0) + 1);

        public DataportDataItems Container { get; internal set; }

        public int? IndentationLevel { get; protected set; }

        public string Name { get; set; }

        public DataportFields Fields { get; set; }

        public DataportDataItemProperties Properties { get; protected set; }

        public string GetName()
        {
            return Name;
        }

        public Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public INode ParentNode => Container;

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Fields;
            }
        }

        public T AddChildNode<T>(T child, Position position) where T : DataportDataItem
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
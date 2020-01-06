using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core.Filter
{
    public abstract class CollectionFilterExpressionItem: FilterExpressionItem
    {
        public List<FilterExpressionItem> Children { get; private set; } = new List<FilterExpressionItem>();
    }
}

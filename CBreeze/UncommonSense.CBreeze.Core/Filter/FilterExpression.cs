using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core.Filter
{
    public class FilterExpression
    {
        public FilterExpressionItem RootItem { get; set; }

        public void Parse(string expression)
        {
            if (OrFilterExpressionItem.ValidateStringForOrExp(expression))
            {
                RootItem = new OrFilterExpressionItem();
            }
            else if (AndFilterExpressionItem.ValidateStringForAndExp(expression))
            {
                RootItem = new AndFilterExpressionItem();
            }
            else if (EqualityFilterExpressionItem.ValidateStringForEqualityExp(expression))
            {
                RootItem = new EqualityFilterExpressionItem();
            }
            else if (RangeFilterExpressionItem.ValidateStringForRangeExp(expression))
            {
                RootItem = new RangeFilterExpressionItem();
            }
            else if (String.IsNullOrEmpty(expression))
            {
                RootItem = new EmptyFilterExpressionItem();
            }
            else
            {
                RootItem = new StringFilterExpressionItem();
            }
            RootItem.Parse(expression);            
        }
    }
}

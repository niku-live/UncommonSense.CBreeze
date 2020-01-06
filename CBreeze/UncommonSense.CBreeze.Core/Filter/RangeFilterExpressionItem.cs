using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core.Filter
{
    public class RangeFilterExpressionItem: CollectionFilterExpressionItem
    {
        public static bool ValidateStringForRangeExp(string value)
        {
            return value.Contains("..");
        }

        public FilterExpressionItem FirstItem { get => Children[0]; }
        public FilterExpressionItem SecondItem { get => Children[1]; }

        public override string GetValueToPrint()
        {
            return $"{FirstItem.GetValueToPrint()}..{SecondItem.GetValueToPrint()}";
        }

        public override bool Parse(string value)
        {
            if (!base.Parse(value))
            {
                return false;
            }

            int operatorLocation = value.IndexOf("..");
            if (operatorLocation < 0)
            {
                return false;
            }

            string firstItem = operatorLocation > 0 ? value.Substring(0, operatorLocation) : null;
            string secondItem = operatorLocation + 3 < value.Length ? value.Substring(operatorLocation + 2) : null;

            Children.Clear();
            Children.Add(ParseChild(firstItem));
            Children.Add(ParseChild(secondItem));
            return true;
        }

        private FilterExpressionItem ParseChild(string expression)
        {
            if (String.IsNullOrEmpty(expression))
            {
                return new EmptyFilterExpressionItem();
            }
            var result = new StringFilterExpressionItem();
            result.Parse(expression);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core.Filter
{
    public class AndFilterExpressionItem: CollectionFilterExpressionItem
    {
        public static bool ValidateStringForAndExp(string value)
        {
            return value.Contains("&");
        }

        public override string GetValueToPrint()
        {
            return string.Join("&", Children.Select(c => c.GetValueToPrint()));
        }

        public override bool Parse(string value)
        {
            if (!base.Parse(value))
            {
                return false;
            }

            if (!ValidateStringForAndExp(value))
            {
                return false;
            }

            Children.Clear();
            while (value.Contains("&"))
            {
                int location = value.IndexOf("&");
                var exp = value.Substring(0, location);
                value = value.Substring(location + 1);
                Children.Add(ParseChild(exp));
            }
            Children.Add(ParseChild(value));

            return true;
        }

        private FilterExpressionItem ParseChild(string expression)
        {            
            if (EqualityFilterExpressionItem.ValidateStringForEqualityExp(expression))
            {
                var eqExp = new EqualityFilterExpressionItem();
                eqExp.Parse(expression);
                return eqExp;
            }
            else if (RangeFilterExpressionItem.ValidateStringForRangeExp(expression))
            {
                var rangeExp = new RangeFilterExpressionItem();
                rangeExp.Parse(expression);
                return rangeExp;
            }
            else if (String.IsNullOrEmpty(expression))
            {
                return new EmptyFilterExpressionItem();
            }
            var stringExp = new StringFilterExpressionItem();
            stringExp.Parse(expression);
            return stringExp;
        }
    }
}

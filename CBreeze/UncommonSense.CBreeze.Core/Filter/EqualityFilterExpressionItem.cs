using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core.Filter
{
    public class EqualityFilterExpressionItem: FilterExpressionItem
    {

        public static bool ValidateStringForEqualityExp(string value)
        {
            return value.StartsWith("<") || value.StartsWith(">") || value.StartsWith("=");
        }

        public string Operator { get; set; }
        public FilterExpressionItem Operand { get; set; }

        public override string GetValueToPrint()
        {
            return $"{Operator}{Operand.GetValueToPrint()}";
        }

        public override bool Parse(string value)
        {
            if (!base.Parse(value))
            {
                return false;
            }

            if (!ValidateStringForEqualityExp(value))
            {
                return false;
            }

            var op2 = value.Length > 1 ? value.Substring(1, 1) : "";            
            var op = (op2 == ">") || (op2 == "=") ? value.Substring(0, 2) : value.Substring(0, 1);

            Operator = op;
            var expression = value.Substring(op.Length);
            var arg = new StringFilterExpressionItem();
            arg.Parse(expression);
            Operand = arg;
            return true;
        }
    }
    
}

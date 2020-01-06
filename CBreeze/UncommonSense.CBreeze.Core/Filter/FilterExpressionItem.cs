using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core.Filter
{
    public abstract class FilterExpressionItem
    {
        public string OriginalString { get; set; }
        
        public virtual string GetValueToPrint()
        {
            return OriginalString;
        }

        public virtual bool Parse(string value)
        {
            OriginalString = value;
            return true;
        }
    }
}

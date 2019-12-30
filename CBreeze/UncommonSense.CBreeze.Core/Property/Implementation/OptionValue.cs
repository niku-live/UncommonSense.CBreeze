using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class OptionValue
    {
        public OptionValue()
        {
        }

        public OptionValue(int no, string name)
        {
            OptionValueName = name;
            OptionActualValue = no;
        }

        public string OptionValueName { get; set; }
        public int OptionActualValue { get; set; }

        public override string ToString() => OptionValueName;
    }
}

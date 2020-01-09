﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core.Filter
{
    public class EmptyFilterExpressionItem: FilterExpressionItem
    {
        public override string GetValueToPrint()
        {
            return "";
        }

        public override bool Parse(string value)
        {
            OriginalString = null;
            return true;
        }
    }
}
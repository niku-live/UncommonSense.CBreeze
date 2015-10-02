﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class CmdletWithDynamicParams : Cmdlet, IDynamicParameters
    {
        public object GetDynamicParameters()
        {
            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();

            foreach (var dynamicParameter in DynamicParameters)
            {
                runtimeDefinedParameterDictionary.Add(dynamicParameter.Name, dynamicParameter);
            }

            return runtimeDefinedParameterDictionary;
        }

        public abstract IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get;
        }
    }
}
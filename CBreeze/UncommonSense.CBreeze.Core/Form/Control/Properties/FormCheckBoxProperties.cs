﻿using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormCheckBoxProperties : CheckBoxProperties, IActivate, IPushAble, IValidate
    {
        public FormCheckBoxProperties(FormControl control) : base(control)
        {
        }
    }
}
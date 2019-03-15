﻿using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Form.Contracts.Trigger;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class FormShapeControlProperties : ShapeProperties, IPushAble
    {
        public FormShapeControlProperties(FormControl control) : base(control)
        {
        }

        public Trigger OnPush => InternalOnPush;
    }
}
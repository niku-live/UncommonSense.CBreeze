using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core.Form.Control;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class ClassicMenuProperty : ReferenceProperty<FormMenuItems>
    {
        public ClassicMenuProperty(string name, Form.Control.Properties.FormControlBase container)
            : base(name)
        {
            _container = container;
        }

        Form.Control.Properties.FormControlBase _container;

        public FormMenuItems Items { get => (_container as FormMenuButtonControl)?.MenuItems; }

        public override object GetValue()
        {
            return Items;
        }

        public override void Reset()
        {
        }

        public override bool HasValue => (Items != null) && (Items.Any());
    }
}

﻿using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TabControlProperties : BaseControlBaseProperties2, ITabControl
    {
        public TabControlProperties(FormControl control) : base(control)
        {
        }

        public MultiLanguageValue PageNamesMl => InternalPageNamesMl;

        public string PageNames => InternalPageNames;
    }
}
﻿using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class FormControlBackColorProperties : ControlBasePropertiesWithFont, IFormControlBackColorProperties
    {
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");

        protected FormControlBackColorProperties(FormControl control) : base(control)
        {
            innerList.Add(_captionMl);
        }

        public MultiLanguageValue CaptionMl => _captionMl.Value;
    }
}
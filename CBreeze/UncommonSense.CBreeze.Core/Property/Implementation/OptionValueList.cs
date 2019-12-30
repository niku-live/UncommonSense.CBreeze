using System;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Core.Generic;
using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2017
    public class OptionValueList : Collection<OptionValue>
    {
        public OptionValueList()
        {
        }

        public OptionValueList(params OptionValue[] values)
        {
            AddRange(values);
        }

        public void Set(OptionValue[] values)
        {
            Clear();
            _actualString = null;
            if (values != null)
                AddRange(values);
        }

        public string ValidTagPattern => @"^#[A-Za-z0-9]+$";

        public bool IsValidTag(string tag) => Regex.IsMatch(tag, ValidTagPattern);

        public override string ToString() => string.Join(",", this);

        protected override void InsertItem(int index, OptionValue item)
        {
            _actualString = null;
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, OptionValue item)
        {
            _actualString = null;
            base.SetItem(index, item);
        }

        public bool WasPreviouslySet { get; set; }

        private string _actualString = null;
        public string ActualString
        {
            get
            {
                if (_actualString == null)
                {
                    _actualString = string.Join(",", this);
                }
                return _actualString;
            }
        }

        public void SetFromString(string values)
        {
            if (values.StartsWith("["))
            {
                values = values.Substring(1, values.Length - 2);
            }
            var splits = values.Split(new[] { "," }, StringSplitOptions.None);
            for (int index = 0; index < splits.Length; index++)
            {
                var optionValue = new OptionValue(index, splits[index]);
                Add(optionValue);
            }
            WasPreviouslySet = true;
            _actualString = values;
        }
    }
#endif
}
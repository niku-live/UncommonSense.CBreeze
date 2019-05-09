using System;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Core.Generic;
using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2017
    public class TagList : Collection<string>
    {
        public TagList()
        {
        }

        public TagList(params string[] tags)
        {
            AddRange(tags);
        }

        public void Set(string[] values)
        {
            Clear();
            _actualString = null;
            if (values != null)
                AddRange(values);
        }

        public string ValidTagPattern => @"^#[A-Za-z0-9]+$";

        public bool IsValidTag(string tag) => Regex.IsMatch(tag, ValidTagPattern);

        public override string ToString() => string.Join(",", this);

        protected override void InsertItem(int index, string item)
        {
            item = item.Trim();
            TestTag(item);
            _actualString = null;
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, string item)
        {
            item = item.Trim();
            TestTag(item);
            _actualString = null;
            base.SetItem(index, item);
        }

        protected void TestTag(string tag)
        {
            if (!IsValidTag(tag))
                throw new ArgumentOutOfRangeException("tag", $"Invalid tag '{tag}'. Valid tags match pattern '{ValidTagPattern}'.");
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
            AddRange(values.Split(",".ToCharArray()).Where(s => !String.IsNullOrEmpty(s)));
            WasPreviouslySet = true;
            _actualString = values;
        }
    }
#endif
}
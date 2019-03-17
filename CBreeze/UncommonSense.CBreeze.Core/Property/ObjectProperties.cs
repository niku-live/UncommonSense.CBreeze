using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Property
{
    public class ObjectProperties : IProperties
    {
        private List<Implementation.Property> innerList = new List<Implementation.Property>();

        private NullableDateTimeProperty dateTime = new NullableDateTimeProperty("DateTime");
        private BooleanProperty modified = new BooleanProperty("Modified");
        private StringProperty versionList = new StringProperty("VersionList");

        internal ObjectProperties()
        {
            innerList.Add(dateTime);
            innerList.Add(modified);
            innerList.Add(versionList);
        }

        public Implementation.Property this[string name]
        {
            get
            {
                return innerList.FirstOrDefault(p => p.Name == name);
            }
        }

        public System.DateTime? DateTime
        {
            get
            {
                return this.dateTime.Value;
            }
            set
            {
                this.dateTime.Value = value;
                HasTimeComponent = true;
                HasDateComponent = true;
            }
        }

        public System.DateTime? Date
        {
            get
            {
                return GetDateComponent(DateTime);
            }
            set
            {
                DateTime = SetDateComponent(DateTime, value);
                HasDateComponent = true;
            }
        }

        public System.TimeSpan? Time
        {
            get
            {
                return GetTimeComponent(DateTime);
            }
            set
            {
                DateTime = SetTimeComponent(DateTime, value);
                HasTimeComponent = true;
            }
        }

        public bool HasTimeComponent { get; set; }
        public bool HasDateComponent { get; set; }

        public bool Modified
        {
            get
            {
                return this.modified.Value;
            }
            set
            {
                this.modified.Value = value;
            }
        }

        public string VersionList
        {
            get
            {
                return this.versionList.Value;
            }
            set
            {
                this.versionList.Value = value;
            }
        }

        public IEnumerator<Implementation.Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        private static System.DateTime? GetDateComponent(System.DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            var date = dateTime.GetValueOrDefault(System.DateTime.MinValue).Date;
            return date;
        }

        private static System.TimeSpan? GetTimeComponent(System.DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            var time = dateTime.GetValueOrDefault(System.DateTime.MinValue).TimeOfDay;
            return time;
        }

        private static System.DateTime? SetDateComponent(System.DateTime? dateTime, System.DateTime? newValue)
        {
            var setValue = newValue.GetValueOrDefault(System.DateTime.MinValue);
            var time = GetTimeComponent(dateTime).GetValueOrDefault(new System.TimeSpan(0, 0, 0, 0, 0));
            return setValue.Add(time);
        }

        private static System.DateTime? SetTimeComponent(System.DateTime? dateTime, System.TimeSpan? newValue)
        {
            var date = GetDateComponent(dateTime).GetValueOrDefault(System.DateTime.MinValue);
            var setValue = newValue.GetValueOrDefault(new System.TimeSpan(0, 0, 0, 0, 0));
            return date.Add(setValue);
        }
    }
}

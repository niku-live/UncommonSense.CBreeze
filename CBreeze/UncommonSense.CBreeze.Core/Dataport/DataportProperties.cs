using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;

namespace UncommonSense.CBreeze.Core.Dataport
{
    public class DataportProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private TriggerProperty onInitDataport = new TriggerProperty("OnInitDataport");
        private TriggerProperty onPostDataport = new TriggerProperty("OnPostDataport");
        private TriggerProperty onPreDataport = new TriggerProperty("OnPreDataport");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty useReqForm = new NullableBooleanProperty("UseReqForm");
        private NullableBooleanProperty import = new NullableBooleanProperty("Import");
        private NullableBooleanProperty showStatus = new NullableBooleanProperty("ShowStatus");
        private ClassicDataportFileFormatProperty fileFormat = new ClassicDataportFileFormatProperty("FileFormat");
        private StringProperty fieldStartDelimiter = new StringProperty("FieldStartDelimiter");
        private StringProperty fieldEndDelimiter = new StringProperty("FieldEndDelimiter");
        private StringProperty fieldSeparator = new StringProperty("FieldSeparator");
        private StringProperty recordSeparator = new StringProperty("RecordSeparator");
        private StringProperty dataItemSeparator = new StringProperty("DataItemSeparator");

        internal DataportProperties(Dataport dataport)
        {
            Dataport = dataport;

            innerList.Add(permissions);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(import);
            innerList.Add(fileFormat);
            innerList.Add(fieldStartDelimiter);
            innerList.Add(fieldEndDelimiter);
            innerList.Add(fieldSeparator);
            innerList.Add(recordSeparator);
            innerList.Add(dataItemSeparator);
            innerList.Add(useReqForm);
            innerList.Add(showStatus);
            innerList.Add(onInitDataport);
            innerList.Add(onPreDataport);
            innerList.Add(onPostDataport);
        }

        public Dataport Dataport { get; protected set; }

        public override INode ParentNode => Dataport;

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

        public Trigger OnInitDataport
        {
            get
            {
                return this.onInitDataport.Value;
            }
        }

        public Trigger OnPostDataport
        {
            get
            {
                return this.onPostDataport.Value;
            }
        }

        public Trigger OnPreDataport
        {
            get
            {
                return this.onPreDataport.Value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

        public bool? UseReqForm
        {
            get => useReqForm.Value;
            set => useReqForm.Value = value;
        }
        public bool? Import { get => import.Value; set => import.Value = value; }
        public bool? ShowStatus { get => showStatus.Value; set => showStatus.Value = value; }
        public string FieldStartDelimiter { get => fieldStartDelimiter.Value; set => fieldStartDelimiter.Value = value; }
        public string FieldEndDelimiter { get => fieldEndDelimiter.Value; set => fieldEndDelimiter.Value = value; }
        public string FieldSeparator { get => fieldSeparator.Value; set => fieldSeparator.Value = value; }

        public string RecordSeparator { get => recordSeparator.Value; set => recordSeparator.Value = value; }
        public string DataItemSeparator { get => dataItemSeparator.Value; set => dataItemSeparator.Value = value; }

        public ClassicDataportFileFormat? FileFormat { get => fileFormat.Value; set => fileFormat.Value = value; }
    }
}

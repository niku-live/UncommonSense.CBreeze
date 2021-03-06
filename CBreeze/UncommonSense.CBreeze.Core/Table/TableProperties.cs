using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Table
{
        public class TableProperties : Properties
    {
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private FieldListProperty dataCaptionFields = new FieldListProperty("DataCaptionFields");
#if NAV2018
        private DataClassificationProperty dataClassification = new DataClassificationProperty("DataClassification");
#endif
        private NullableBooleanProperty dataPerCompany = new NullableBooleanProperty("DataPerCompany");
        private NullableBooleanProperty includeDataInDesc = new NullableBooleanProperty("IncludeDataInDesc");
        private StringProperty description = new StringProperty("Description");
        private PageReferenceProperty drillDownPageID = new PageReferenceProperty("DrillDownPageID");
        private NullableBooleanProperty linkedInTransaction = new NullableBooleanProperty("LinkedInTransaction");
        private NullableBooleanProperty linkedObject = new NullableBooleanProperty("LinkedObject");
        private PageReferenceProperty lookupPageID = new PageReferenceProperty("LookupPageID");
#if NAV2018
        private ObsoleteStateProperty obsoleteState = new ObsoleteStateProperty("ObsoleteState");
        private StringProperty obsoleteReason = new StringProperty("ObsoleteReason");
#endif
        private TriggerProperty onDelete = new TriggerProperty("OnDelete");
        private TriggerProperty onInsert = new TriggerProperty("OnInsert");
        private TriggerProperty onModify = new TriggerProperty("OnModify");
        private TriggerProperty onRename = new TriggerProperty("OnRename");
        private NullableBooleanProperty pasteIsValid = new NullableBooleanProperty("PasteIsValid");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
#if NAVBC || NAV2019
        private NullableBooleanProperty replicateData = new NullableBooleanProperty("ReplicateData");
#endif
#if NAV2016
        private TableTypeProperty tableType = new TableTypeProperty("TableType");
        private StringProperty externalName = new StringProperty("ExternalName");
        private StringProperty externalSchema = new StringProperty("ExternalSchema");
        private NullableBooleanProperty writeProtected = new NullableBooleanProperty("WriteProtected");
#endif
#if NAV2009
        private FormReferenceProperty lookupFormID = new FormReferenceProperty("LookupFormID");
        private FormReferenceProperty drillDownFormID = new FormReferenceProperty("DrillDownFormID");
#endif
        internal TableProperties(Table table)
        {
            Table = table;

#if NAV2016
            innerList.Add(writeProtected); 
#endif
            innerList.Add(dataPerCompany); // 4935
            innerList.Add(permissions); // 4947
            innerList.Add(dataCaptionFields); // 21105
            innerList.Add(linkedInTransaction); // 4984
            innerList.Add(linkedObject); // 4983
            innerList.Add(onInsert);
            innerList.Add(onModify);
            innerList.Add(onDelete);
            innerList.Add(onRename);
#if NAV2016
            innerList.Add(tableType); // 5044
            innerList.Add(externalName); // 5045
            innerList.Add(externalSchema);
#endif
#if NAV2018
            innerList.Add(obsoleteState);
            innerList.Add(obsoleteReason);
            innerList.Add(dataClassification);
#endif
#if NAVBC || NAV2019
            innerList.Add(replicateData);
#endif
            innerList.Add(includeDataInDesc);
            innerList.Add(captionML); // 8629
            innerList.Add(description); // 15386
            innerList.Add(pasteIsValid); // 15423
            innerList.Add(lookupPageID); // 55116
            innerList.Add(drillDownPageID); // 55117
#if NAV2009
            innerList.Add(lookupFormID);
            innerList.Add(drillDownFormID);
#endif
        }

    public Table Table { get; protected set; }

        public override INode ParentNode => Table;

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public FieldList DataCaptionFields
        {
            get
            {
                return this.dataCaptionFields.Value;
            }
        }

      public bool? DataPerCompany
        {
            get
            {
                return this.dataPerCompany.Value;
            }
            set
            {
                this.dataPerCompany.Value = value;
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

      public int? DrillDownPageID
        {
            get
            {
                return this.drillDownPageID.Value;
            }
            set
            {
                this.drillDownPageID.Value = value;
            }
        }

      public bool? LinkedInTransaction
        {
            get
            {
                return this.linkedInTransaction.Value;
            }
            set
            {
                this.linkedInTransaction.Value = value;
            }
        }

      public bool? LinkedObject
        {
            get
            {
                return this.linkedObject.Value;
            }
            set
            {
                this.linkedObject.Value = value;
            }
        }

      public int? LookupPageID
        {
            get
            {
                return this.lookupPageID.Value;
            }
            set
            {
                this.lookupPageID.Value = value;
            }
        }

#if NAV2018

        public ObsoleteState? ObsoleteState
        {
            get => obsoleteState.Value;
            set => obsoleteState.Value = value;
        }

        public string ObsoleteReason
        {
            get => obsoleteReason.Value;
            set => obsoleteReason.Value = value;
        }


        public DataClassification? DataClassification
        {
            get => dataClassification.Value;
            set => dataClassification.Value = value;
        }
#endif

        public Trigger OnDelete
        {
            get
            {
                return this.onDelete.Value;
            }
        }

        public Trigger OnInsert
        {
            get
            {
                return this.onInsert.Value;
            }
        }

        public Trigger OnModify
        {
            get
            {
                return this.onModify.Value;
            }
        }

        public Trigger OnRename
        {
            get
            {
                return this.onRename.Value;
            }
        }

      public bool? PasteIsValid
        {
            get
            {
                return this.pasteIsValid.Value;
            }
            set
            {
                this.pasteIsValid.Value = value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

#if NAVBC || NAV2019
        public bool? ReplicateData
        {
            get => replicateData.Value;
            set => replicateData.Value = value;
        }
#endif

#if NAV2016
        public TableType? TableType
        {
            get
            {
                return this.tableType.Value;
            }
            set
            {
                this.tableType.Value = value;
            }
        }

        public string ExternalName
        {
            get
            {
                return this.externalName.Value;
            }
            set
            {
                this.externalName.Value = value;
            }
        }

        public string ExternalSchema
        {
            get
            {
                return this.externalSchema.Value;
            }
            set
            {
                this.externalSchema.Value = value;
            }
        }

        public bool? WriteProtected
        {
            get
            {
                return this.writeProtected.Value;
            }
            set
            {
                this.writeProtected.Value = value;
            }
        }
#endif
#if NAV2009
        public int? LookupFormID
        {
            get
            {
                return this.lookupFormID.Value;
            }
            set
            {
                this.lookupFormID.Value = value;
            }
        }

        public int? DrillDownFormID
        {
            get
            {
                return this.drillDownFormID.Value;
            }
            set
            {
                this.drillDownFormID.Value = value;
            }
        }

        public bool? IncludeDataInDesc
        {
            get => includeDataInDesc.Value;
            set => includeDataInDesc.Value = value;
        }
#endif
    }
}

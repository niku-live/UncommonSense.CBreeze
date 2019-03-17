using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Table.Field.Properties
{
        public class BlobTableFieldProperties : Property.Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty compressed = new NullableBooleanProperty("Compressed");
#if NAV2018
        private DataClassificationProperty dataClassification = new DataClassificationProperty("DataClassification");
#endif
        private StringProperty description = new StringProperty("Description");
#if NAV2016
        private ExternalAccessProperty externalAccess = new ExternalAccessProperty("ExternalAccess");
        private StringProperty externalName = new StringProperty("ExternalName");
        private StringProperty externalType = new StringProperty("ExternalType");
#endif
#if NAV2018
        private ObsoleteStateProperty obsoleteState = new ObsoleteStateProperty("ObsoleteState");
        private StringProperty obsoleteReason = new StringProperty("ObsoleteReason");
#endif
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private StringProperty owner = new StringProperty("Owner");
        private BlobSubTypeProperty subType = new BlobSubTypeProperty("SubType");
        private NullableBooleanProperty @volatile = new NullableBooleanProperty("Volatile");
#if NAV2009
        private StringProperty sqlDataType = new StringProperty("SQL Data Type");
#endif

        internal BlobTableFieldProperties(BlobTableField field)
        {
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(compressed);
            innerList.Add(@volatile);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
#if NAV2016
            innerList.Add(externalName);
            innerList.Add(externalType);
            innerList.Add(externalAccess);
#endif
#if NAV2018
            innerList.Add(obsoleteState);
            innerList.Add(obsoleteReason);
            innerList.Add(dataClassification);
#endif
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(owner);
            innerList.Add(subType);
#if NAV2009
            innerList.Add(sqlDataType);
#endif
        }

        public BlobTableField Field { get; protected set; }

        public override INode ParentNode => Field;

#if NAV2015

        public AccessByPermission AccessByPermission
        {
            get
            {
                return accessByPermission.Value;
            }
        }

#endif

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

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public bool? Compressed
        {
            get
            {
                return this.compressed.Value;
            }
            set
            {
                this.compressed.Value = value;
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

#if NAV2016

        public ExternalAccess? ExternalAccess
        {
            get
            {
                return this.externalAccess.Value;
            }
            set
            {
                this.externalAccess.Value = value;
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

        public string ExternalType
        {
            get
            {
                return this.externalType.Value;
            }
            set
            {
                this.externalType.Value = value;
            }
        }

#endif

        public Trigger OnLookup
        {
            get
            {
                return this.onLookup.Value;
            }
        }

        public Trigger OnValidate
        {
            get
            {
                return this.onValidate.Value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner.Value;
            }
            set
            {
                this.owner.Value = value;
            }
        }

        public BlobSubType? SubType
        {
            get
            {
                return this.subType.Value;
            }
            set
            {
                this.subType.Value = value;
            }
        }

        public bool? Volatile
        {
            get
            {
                return this.@volatile.Value;
            }
            set
            {
                this.@volatile.Value = value;
            }
        }
    }
}

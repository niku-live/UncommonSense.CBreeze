using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;
using UncommonSense.CBreeze.Core.Table.Relation;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Table.Field.Properties
{
        public class CodeTableFieldProperties : Property.Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty charAllowed = new StringProperty("CharAllowed");
#if NAV2018
        private DataClassificationProperty dataClassification = new DataClassificationProperty("DataClassification");
#endif
        private NullableBooleanProperty dateFormula = new NullableBooleanProperty("DateFormula");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
#if NAV2016
        private ExternalAccessProperty externalAccess = new ExternalAccessProperty("ExternalAccess");
        private StringProperty externalName = new StringProperty("ExternalName");
        private StringProperty externalType = new StringProperty("ExternalType");
#endif
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private StringProperty initValue = new StringProperty("InitValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private NullableBooleanProperty numeric = new NullableBooleanProperty("Numeric");
#if NAV2018
        private ObsoleteStateProperty obsoleteState = new ObsoleteStateProperty("ObsoleteState");
        private StringProperty obsoleteReason = new StringProperty("ObsoleteReason");
#endif
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private SqlDataTypeProperty sQLDataType = new SqlDataTypeProperty("SQLDataType");
        private TableRelationProperty tableRelation = new TableRelationProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");
#if NAV2009
        private StringProperty sqlDataType = new StringProperty("SQLDataType");
#endif

        internal CodeTableFieldProperties(CodeTableField field, int majorVersion = 0, bool exportToNewSyntax = false)
        {
            Field = field;

            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            if ((majorVersion < 9) || exportToNewSyntax)
            {
                innerList.Add(altSearchField);
            }
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            if ((majorVersion >= 9) && !exportToNewSyntax)
            {
                innerList.Add(altSearchField);
            }
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(width);
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
            innerList.Add(sQLDataType);
            innerList.Add(notBlank);
            innerList.Add(numeric);
            innerList.Add(charAllowed);
            innerList.Add(dateFormula);
            innerList.Add(valuesAllowed);
#if NAV2009
            innerList.Add(sqlDataType);
#endif
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

        public CodeTableField Field { get; protected set; }

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

        public string AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
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

        public string AutoFormatExpr
        {
            get
            {
                return this.autoFormatExpr.Value;
            }
            set
            {
                this.autoFormatExpr.Value = value;
            }
        }

        public AutoFormatType? AutoFormatType
        {
            get
            {
                return this.autoFormatType.Value;
            }
            set
            {
                this.autoFormatType.Value = value;
            }
        }

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

        public string CaptionClass
        {
            get
            {
                return this.captionClass.Value;
            }
            set
            {
                this.captionClass.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public string CharAllowed
        {
            get
            {
                return this.charAllowed.Value;
            }
            set
            {
                this.charAllowed.Value = value;
            }
        }

        public bool? DateFormula
        {
            get
            {
                return this.dateFormula.Value;
            }
            set
            {
                this.dateFormula.Value = value;
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

        public bool? Editable
        {
            get
            {
                return this.editable.Value;
            }
            set
            {
                this.editable.Value = value;
            }
        }

        public ExtendedDataType? ExtendedDatatype
        {
            get
            {
                return this.extendedDatatype.Value;
            }
            set
            {
                this.extendedDatatype.Value = value;
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

        public string InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

        public bool? NotBlank
        {
            get
            {
                return this.notBlank.Value;
            }
            set
            {
                this.notBlank.Value = value;
            }
        }

        public bool? Numeric
        {
            get
            {
                return this.numeric.Value;
            }
            set
            {
                this.numeric.Value = value;
            }
        }

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

        public SqlDataType? SQLDataType
        {
            get
            {
                return this.sQLDataType.Value;
            }
            set
            {
                this.sQLDataType.Value = value;
            }
        }

        public TableRelation TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

        public bool? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

        public bool? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

        public string ValuesAllowed
        {
            get
            {
                return this.valuesAllowed.Value;
            }
            set
            {
                this.valuesAllowed.Value = value;
            }
        }

        public int? Width
        {
            get
            {
                return this.width.Value;
            }
            set
            {
                this.width.Value = value;
            }
        }
    }
}

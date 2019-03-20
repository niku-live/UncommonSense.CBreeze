using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Table.Relation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TextBoxProperties : TextPropertiesBase, ITextBox
    {
        public TextBoxProperties(FormControl control) : base(control)
        {
        }

        public bool? AutoCalcField
        {
            get => InternalAutoCalcField;
            set => InternalAutoCalcField = value;
        }

        public string MinValue
        {
            get => InternalMinValue;
            set => InternalMinValue = value;
        }

        public string MaxValue
        {
            get => InternalMaxValue;
            set => InternalMaxValue = value;
        }

        public string ValuesAllowed
        {
            get => InternalValuesAllowed;
            set => InternalValuesAllowed = value;
        }

        public bool? Enabled
        {
            get => InternalEnabled;
            set => InternalEnabled = value;
        }

        public int? MaxLength
        {
            get => InternalMaxLength;
            set => InternalMaxLength = value;
        }

        public bool? PasswordText
        {
            get => InternalPasswordText;
            set => InternalPasswordText = value;
        }

        public bool? AutoEnter
        {
            get => InternalAutoEnter;
            set => InternalAutoEnter = value;
        }

        public bool? Lookup
        {
            get => InternalLookup;
            set => InternalLookup = value;
        }

        public bool? AssistEdit
        {
            get => InternalAssistEdit;
            set => InternalAssistEdit = value;
        }

        public bool? PermanentAssist
        {
            get => InternalPermanentAssist;
            set => InternalPermanentAssist = value;
        }

        public DecimalPlaces DecimalPlaces => InternalDecimalPlaces;

        public string Title
        {
            get => InternalTitle;
            set => InternalTitle = value;
        }

        public bool? NotBlank
        {
            get => InternalNotBlank;
            set => InternalNotBlank = value;
        }

        public bool? Numeric
        {
            get => InternalNumeric;
            set => InternalNumeric = value;
        }

        public string CharAllowed
        {
            get => InternalCharAllowed;
            set => InternalCharAllowed = value;
        }

        public string DateFormula
        {
            get => InternalDateFormula;
            set => InternalDateFormula = value;
        }

        public bool? ClosingDates
        {
            get => InternalClosingDates;
            set => InternalClosingDates = value;
        }

        public string Format
        {
            get => InternalFormat;
            set => InternalFormat = value;
        }

        public bool? SignDisplacement
        {
            get => InternalSignDisplacement;
            set => InternalSignDisplacement = value;
        }

        public string AutoFormatType
        {
            get => InternalAutoFormatType;
            set => InternalAutoFormatType = value;
        }

        public string AutoFormatExpr
        {
            get => InternalAutoFormatExpr;
            set => InternalAutoFormatExpr = value;
        }

        public string Divisor
        {
            get => InternalDivisor;
            set => InternalDivisor = value;
        }

        public TableRelation TableRelation => InternalTableRelation;

        public bool? ValidateTableRelation
        {
            get => InternalValidateTableRelation;
            set => InternalValidateTableRelation = value;
        }

        public string LookupFormID
        {
            get => InternalLookupFormID;
            set => InternalLookupFormID = value;
        }

        public bool? InColumnHeading
        {
            get => InternalInColumnHeading;
            set => InternalInColumnHeading = value;
        }
    }
}
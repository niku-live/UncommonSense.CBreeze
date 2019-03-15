using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TextBoxProperties : TextPropertiesBase, ITextBox
    {
        private readonly NullableBooleanProperty _assistEdit = new NullableBooleanProperty("AssistEdit");
        private readonly NullableBooleanProperty _autoEnter = new NullableBooleanProperty("AutoEnter");
        private readonly StringProperty _autoFormatExpr = new StringProperty("AutoFormatExpr");
        private readonly StringProperty _autoFormatType = new StringProperty("AutoFormatType");
        private readonly StringProperty _charAllowed = new StringProperty("CharAllowed");
        private readonly NullableBooleanProperty _closingDates = new NullableBooleanProperty("ClosingDates");
        private readonly StringProperty _dateFormula = new StringProperty("DateFormula");
        private readonly DecimalPlacesProperty _decimalPlaces = new DecimalPlacesProperty("DecimalPlaces");
        private readonly StringProperty _divisor = new StringProperty("Divisor");
        private readonly StringProperty _format = new StringProperty("Format");
        private readonly NullableBooleanProperty _lookup = new NullableBooleanProperty("Lookup");
        private readonly StringProperty _lookupFormID = new StringProperty("LookupFormID");
        private readonly NullableIntegerProperty _maxLength = new NullableIntegerProperty("MaxLength");
        private readonly NullableBooleanProperty _notBlank = new NullableBooleanProperty("NotBlank");
        private readonly NullableBooleanProperty _numeric = new NullableBooleanProperty("Numeric");
        private readonly NullableBooleanProperty _passwordText = new NullableBooleanProperty("PasswordText");
        private readonly NullableBooleanProperty _permanentAssist = new NullableBooleanProperty("PermanentAssist");
        private readonly NullableBooleanProperty _signDisplacement = new NullableBooleanProperty("SignDisplacement");
        private readonly StringProperty _tableRelation = new StringProperty("TableRelation");
        private readonly StringProperty _title = new StringProperty("Title");

        private readonly NullableBooleanProperty _validateTableRelation =
            new NullableBooleanProperty("ValidateTableRelation");

        private readonly StringProperty _valuesAllowed = new StringProperty("ValuesAllowed");

        public TextBoxProperties(FormControl control) : base(control)
        {
            innerList.Add(_assistEdit);
            innerList.Add(_autoEnter);
            innerList.Add(_charAllowed);
            innerList.Add(_closingDates);
            innerList.Add(_dateFormula);
            innerList.Add(_decimalPlaces);
            innerList.Add(_divisor);
            innerList.Add(_format);
            innerList.Add(_maxLength);
            innerList.Add(_notBlank);
            innerList.Add(_numeric);
            innerList.Add(_passwordText);
            innerList.Add(_permanentAssist);
            innerList.Add(_autoFormatType);
            innerList.Add(_autoFormatExpr);
            innerList.Add(_lookup);
            innerList.Add(_lookupFormID);
            innerList.Add(_tableRelation);
            innerList.Add(_title);
            innerList.Add(_validateTableRelation);
            innerList.Add(_valuesAllowed);
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
            get => _maxLength.Value;
            set => _maxLength.Value = value;
        }

        public bool? PasswordText
        {
            get => _passwordText.Value;
            set => _passwordText.Value = value;
        }

        public bool? AutoEnter
        {
            get => _autoEnter.Value;
            set => _autoEnter.Value = value;
        }

        public bool? Lookup
        {
            get => _lookup.Value;
            set => _lookup.Value = value;
        }

        public bool? AssistEdit
        {
            get => _assistEdit.Value;
            set => _assistEdit.Value = value;
        }

        public bool? PermanentAssist
        {
            get => _permanentAssist.Value;
            set => _permanentAssist.Value = value;
        }

        public DecimalPlaces DecimalPlaces => _decimalPlaces.Value;

        public string Title
        {
            get => _title.Value;
            set => _title.Value = value;
        }

        public bool? NotBlank
        {
            get => _notBlank.Value;
            set => _notBlank.Value = value;
        }

        public bool? Numeric
        {
            get => _numeric.Value;
            set => _numeric.Value = value;
        }

        public string CharAllowed
        {
            get => _charAllowed.Value;
            set => _charAllowed.Value = value;
        }

        public string DateFormula
        {
            get => _dateFormula.Value;
            set => _dateFormula.Value = value;
        }

        public bool? ClosingDates
        {
            get => _closingDates.Value;
            set => _closingDates.Value = value;
        }

        public string Format
        {
            get => _format.Value;
            set => _format.Value = value;
        }

        public bool? SignDisplacement
        {
            get => _signDisplacement.Value;
            set => _signDisplacement.Value = value;
        }

        public string AutoFormatType
        {
            get => _autoFormatType.Value;
            set => _autoFormatType.Value = value;
        }

        public string AutoFormatExpr
        {
            get => _autoFormatExpr.Value;
            set => _autoFormatExpr.Value = value;
        }

        public string Divisor
        {
            get => _divisor.Value;
            set => _divisor.Value = value;
        }

        public string TableRelation
        {
            get => _tableRelation.Value;
            set => _tableRelation.Value = value;
        }

        public bool? ValidateTableRelation
        {
            get => _validateTableRelation.Value;
            set => _validateTableRelation.Value = value;
        }

        public string LookupFormID
        {
            get => _lookupFormID.Value;
            set => _lookupFormID.Value = value;
        }

        public bool? InColumnHeading
        {
            get => InternalInColumnHeading;
            set => InternalInColumnHeading = value;
        }
    }
}
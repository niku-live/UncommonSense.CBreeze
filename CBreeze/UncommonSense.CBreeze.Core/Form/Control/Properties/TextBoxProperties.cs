using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class TextBoxProperties : TextPropertiesBase, ITextBox
    {
        private readonly NullableBooleanProperty _assistEdit = new NullableBooleanProperty("AssistEdit");
        private readonly NullableBooleanProperty _autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private readonly NullableBooleanProperty _autoEnter = new NullableBooleanProperty("AutoEnter");
        private readonly StringProperty _autoFormatExpr = new StringProperty("AutoFormatExpr");
        private readonly StringProperty _autoFormatType = new StringProperty("AutoFormatType");
        private readonly BlankNumbersProperty _blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private readonly NullableBooleanProperty _blankZero = new NullableBooleanProperty("BlankZero");
        private readonly StringProperty _charAllowed = new StringProperty("CharAllowed");
        private readonly NullableBooleanProperty _clearOnLookup = new NullableBooleanProperty("ClearOnLookup");
        private readonly NullableBooleanProperty _closingDates = new NullableBooleanProperty("ClosingDates");
        private readonly StringProperty _dateFormula = new StringProperty("DateFormula");
        private readonly DecimalPlacesProperty _decimalPlaces = new DecimalPlacesProperty("DecimalPlaces");
        private readonly StringProperty _divisor = new StringProperty("Divisor");
        private readonly NullableBooleanProperty _drillDown = new NullableBooleanProperty("DrillDown");
        private readonly StringProperty _drillDownFormID = new StringProperty("DrillDownFormID");
        private readonly NullableBooleanProperty _dropDown = new NullableBooleanProperty("DropDown");
        private readonly NullableBooleanProperty _editable = new NullableBooleanProperty("Editable");
        private readonly NullableBooleanProperty _enabled = new NullableBooleanProperty("Enabled");
        private readonly NullableBooleanProperty _focusable = new NullableBooleanProperty("Focusable");
        private readonly StringProperty _format = new StringProperty("Format");
        private readonly NullableBooleanProperty _lookup = new NullableBooleanProperty("Lookup");
        private readonly StringProperty _lookupFormID = new StringProperty("LookupFormID");
        private readonly NullableIntegerProperty _maxLength = new NullableIntegerProperty("MaxLength");
        private readonly StringProperty _maxValue = new StringProperty("MaxValue");
        private readonly StringProperty _minValue = new StringProperty("MinValue");
        private readonly NullableIntegerProperty _nextControl = new NullableIntegerProperty("NextControl");
        private readonly NullableBooleanProperty _notBlank = new NullableBooleanProperty("NotBlank");
        private readonly NullableBooleanProperty _numeric = new NullableBooleanProperty("Numeric");
        private readonly MultiLanguageProperty _optionCaptionML = new MultiLanguageProperty("OptionCaptionML");
        private readonly StringProperty _optionString = new StringProperty("OptionString");
        private readonly NullableBooleanProperty _passwordText = new NullableBooleanProperty("PasswordText");
        private readonly NullableBooleanProperty _permanentAssist = new NullableBooleanProperty("PermanentAssist");
        private readonly NullableBooleanProperty _signDisplacement = new NullableBooleanProperty("SignDisplacement");
        private readonly StringProperty _sourceExpr = new StringProperty("SourceExpr");
        private readonly StringProperty _tableRelation = new StringProperty("TableRelation");
        private readonly StringProperty _title = new StringProperty("Title");

        private readonly NullableBooleanProperty _validateTableRelation =
            new NullableBooleanProperty("ValidateTableRelation");

        private readonly StringProperty _valuesAllowed = new StringProperty("ValuesAllowed");

        public TextBoxProperties(FormControl control) : base(control)
        {
            innerList.Add(_blankNumbers);
            innerList.Add(_decimalPlaces);
            innerList.Add(_autoFormatType);
            innerList.Add(_autoFormatExpr);
            innerList.Add(_format);
            innerList.Add(_autoCalcField);
            innerList.Add(_passwordText);
            innerList.Add(_divisor);
            innerList.Add(_optionString);
            innerList.Add(_enabled);
        }

        public int? NextControl
        {
            get => _nextControl.Value;
            set => _nextControl.Value = value;
        }

        public string SourceExpr
        {
            get => _sourceExpr.Value;
            set => _sourceExpr.Value = value;
        }

        public bool? AutoCalcField
        {
            get => _autoCalcField.Value;
            set => _autoCalcField.Value = value;
        }

        public string MinValue
        {
            get => _minValue.Value;
            set => _minValue.Value = value;
        }

        public string MaxValue
        {
            get => _maxValue.Value;
            set => _maxValue.Value = value;
        }

        public string ValuesAllowed
        {
            get => _valuesAllowed.Value;
            set => _valuesAllowed.Value = value;
        }

        public bool? Editable
        {
            get => _editable.Value;
            set => _editable.Value = value;
        }

        public bool? Enabled
        {
            get => _enabled.Value;
            set => _enabled.Value = value;
        }

        public bool? Focusable
        {
            get => _focusable.Value;
            set => _focusable.Value = value;
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

        public bool? DrillDown
        {
            get => _drillDown.Value;
            set => _drillDown.Value = value;
        }

        public bool? AssistEdit
        {
            get => _assistEdit.Value;
            set => _assistEdit.Value = value;
        }

        public bool? DropDown
        {
            get => _dropDown.Value;
            set => _dropDown.Value = value;
        }

        public bool? PermanentAssist
        {
            get => _permanentAssist.Value;
            set => _permanentAssist.Value = value;
        }

        public string OptionString
        {
            get => _optionString.Value;
            set => _optionString.Value = value;
        }

        public MultiLanguageValue OptionCaptionML => _optionCaptionML.Value;
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

        public bool? ClearOnLookup
        {
            get => _clearOnLookup.Value;
            set => _clearOnLookup.Value = value;
        }

        public string Format
        {
            get => _format.Value;
            set => _format.Value = value;
        }

        public BlankNumbers? BlankNumbers
        {
            get => _blankNumbers.Value;
            set => _blankNumbers.Value = value;
        }

        public bool? BlankZero
        {
            get => _blankZero.Value;
            set => _blankZero.Value = value;
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

        public string DrillDownFormID
        {
            get => _drillDownFormID.Value;
            set => _drillDownFormID.Value = value;
        }
    }
}
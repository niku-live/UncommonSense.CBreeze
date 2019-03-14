using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class TextPropertiesBase : BaseControlBaseProperties, IText
    {
        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly StringProperty _captionClass = new StringProperty("CaptionClass");
        private readonly StringProperty _dataSetFieldName = new StringProperty("DataSetFieldName");
        private readonly NullableBooleanProperty _multiLine = new NullableBooleanProperty("MultiLine");
        private readonly StringProperty _padChar = new StringProperty("PadChar");
        private readonly StringProperty _sourceExpr = new StringProperty("SourceExpr");
        private readonly NullableIntegerProperty _nextControl = new NullableIntegerProperty("NextControl");
        private readonly NullableBooleanProperty _clearOnLookup = new NullableBooleanProperty("ClearOnLookup");
        private readonly BlankNumbersProperty _blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private readonly NullableBooleanProperty _blankZero = new NullableBooleanProperty("BlankZero");

        protected TextPropertiesBase(FormControl control) : base(control)
        {
            innerList.Add(_borderColor);
            innerList.Add(_borderWidth);
            innerList.Add(_nextControl);
            innerList.Add(_clearOnLookup);
            innerList.Add(_blankNumbers);
            innerList.Add(_blankZero);
            innerList.Add(_sourceExpr);
            innerList.Add(_captionClass);
            innerList.Add(_dataSetFieldName);
            innerList.Add(_multiLine);
            innerList.Add(_padChar);
        }

        public int? NextControl
        {
            get => _nextControl.Value;
            set => _nextControl.Value = value;
        }

        public bool? ClearOnLookup
        {
            get => _clearOnLookup.Value;
            set => _clearOnLookup.Value = value;
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

        public string SourceExpr
        {
            get => _sourceExpr.Value;
            set => _sourceExpr.Value = value;
        }

        public Color? BorderColor
        {
            get => _borderColor.Value;
            set => _borderColor.Value = value;
        }

        public BorderWidth BorderWidth
        {
            get => _borderWidth.Value;
            set => _borderWidth.Value = value;
        }

        public string CaptionClass
        {
            get => _captionClass.Value;
            set => _captionClass.Value = value;
        }

        public string DataSetFieldName
        {
            get => _dataSetFieldName.Value;
            set => _dataSetFieldName.Value = value;
        }

        public bool? MultiLine
        {
            get => _multiLine.Value;
            set => _multiLine.Value = value;
        }

        public string PadChar
        {
            get => _padChar.Value;
            set => _padChar.Value = value;
        }

    }
}
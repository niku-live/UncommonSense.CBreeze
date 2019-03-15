using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class TextPropertiesBase : BaseControlBaseProperties, IText
    {
        protected TextPropertiesBase(FormControl control) : base(control)
        {
        }

        public int? NextControl
        {
            get => InternalNextControl;
            set => InternalNextControl = value;
        }

        public bool? ClearOnLookup
        {
            get => InternalClearOnLookup;
            set => InternalClearOnLookup = value;
        }

        public BlankNumbers? BlankNumbers
        {
            get => InternalBlankNumbers;
            set => InternalBlankNumbers = value;
        }

        public bool? BlankZero
        {
            get => InternalBlankZero;
            set => InternalBlankZero = value;
        }

        public string SourceExpr
        {
            get => InternalSourceExpr;
            set => InternalSourceExpr = value;
        }

        public Color? BorderColor
        {
            get => InternalBorderColor;
            set => InternalBorderColor = value;
        }

        public BorderWidth? BorderWidth
        {
            get => InternalBorderWidth;
            set => InternalBorderWidth = value;
        }

        public string CaptionClass
        {
            get => InternalCaptionClass;
            set => InternalCaptionClass = value;
        }

        public string DataSetFieldName
        {
            get => InternalDataSetFieldName;
            set => InternalDataSetFieldName = value;
        }

        public bool? MultiLine
        {
            get => InternalMultiLine;
            set => InternalMultiLine = value;
        }

        public string PadChar
        {
            get => InternalPadChar;
            set => InternalPadChar = value;
        }

        public string OptionString
        {
            get => InternalOptionString;
            set => InternalOptionString = value;
        }

        public MultiLanguageValue OptionCaptionML => InternalOptionCaptionML;

    }
}
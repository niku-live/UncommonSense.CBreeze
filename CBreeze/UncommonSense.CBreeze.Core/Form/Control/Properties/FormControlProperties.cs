using System.Drawing;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class FormControlProperties : Property.Properties
    {
        private readonly NullableBooleanProperty _focusable = new NullableBooleanProperty("Focusable");
        private readonly NullableBooleanProperty _editable = new NullableBooleanProperty("Editable");
        private readonly NullableUnsignedIntegerProperty _height = new NullableUnsignedIntegerProperty("Height");
        private readonly HorzGlueProperty _horzGlue = new HorzGlueProperty("HorzGlue");
        private readonly NullableBooleanProperty _inFrame = new NullableBooleanProperty("InFrame");
        private readonly NullableIntegerProperty _inPage = new NullableIntegerProperty("InPage");
        private readonly NullableBooleanProperty _inColumn = new NullableBooleanProperty("InColumn");
        private readonly NullableBooleanProperty _inMatrix = new NullableBooleanProperty("InMatrix");
        private readonly NullableBooleanProperty _inMatrixHeading = new NullableBooleanProperty("InMatrixHeading");
        private readonly StringProperty _name = new StringProperty("Name");

        private readonly NullableUnsignedIntegerProperty _parentControl =
            new NullableUnsignedIntegerProperty("ParentControl");

        private readonly VertGlueProperty _vertGlue = new VertGlueProperty("VertGlue");
        private readonly NullableBooleanProperty _visible = new NullableBooleanProperty("Visible");
        private readonly NullableUnsignedIntegerProperty _width = new NullableUnsignedIntegerProperty("Width");
        private readonly NullableUnsignedIntegerProperty _xPos = new NullableUnsignedIntegerProperty("XPos");
        private readonly NullableUnsignedIntegerProperty _yPos = new NullableUnsignedIntegerProperty("YPos");

        private readonly HorzAlignProperty _horzAlign = new HorzAlignProperty("HorzAlign");
        private readonly VertAlignProperty _vertAlign = new VertAlignProperty("VertAlign");

        private readonly NullableBooleanProperty _fontBold = new NullableBooleanProperty("FontBold");
        private readonly NullableBooleanProperty _fontItalic = new NullableBooleanProperty("FontItalic");
        private readonly StringProperty _fontName = new StringProperty("FontName");
        private readonly NullableIntegerProperty _fontSize = new NullableIntegerProperty("FontSize");
        private readonly NullableBooleanProperty _fontStrikethru = new NullableBooleanProperty("FontStrikethru");
        private readonly NullableBooleanProperty _fontUnderline = new NullableBooleanProperty("FontUnderline");
        private readonly ColorProperty _backColor = new ColorProperty("BackColor");
        private readonly NullableBooleanProperty _backTransparent = new NullableBooleanProperty("BackTransparent");
        private readonly NullableBooleanProperty _border = new NullableBooleanProperty("Border");
        private readonly ColorProperty _foreColor = new ColorProperty("ForeColor");
        private readonly NullableBooleanProperty _leaderDots = new NullableBooleanProperty("LeaderDots");
        private readonly NullableBooleanProperty _showCaption = new NullableBooleanProperty("ShowCaption");
        private readonly StringProperty _bitmap = new StringProperty("Bitmap");
        private readonly MultiLanguageProperty _toolTipMl = new MultiLanguageProperty("ToolTipML");
        private readonly NullableBooleanProperty _cancel = new NullableBooleanProperty("Cancel");
        private readonly NullableBooleanProperty _default = new NullableBooleanProperty("Default");
        private readonly PushActionProperty _pushAction = new PushActionProperty("PushAction");

        private readonly NullableBooleanProperty _drillDown = new NullableBooleanProperty("DrillDown");
        private readonly StringProperty _drillDownFormID = new StringProperty("DrillDownFormID");
        private readonly StringProperty _description = new StringProperty("Description");
        private readonly NullableBooleanProperty _dropDown = new NullableBooleanProperty("DropDown");
        private readonly NullableBooleanProperty _focusOnClick = new NullableBooleanProperty("FocusOnClick");
        private readonly MultiLanguageProperty _captionMl = new MultiLanguageProperty("CaptionML");
        private readonly BorderStyleProperty _borderStyle = new BorderStyleProperty("BorderStyle");

        private readonly NullableBooleanProperty _enabled = new NullableBooleanProperty("Enabled");
        private readonly NullableIntegerProperty _nextControl = new NullableIntegerProperty("NextControl");
        private readonly TriggerProperty _onActivate = new TriggerProperty("OnActivate");
        private readonly TriggerProperty _onAfterValidate = new TriggerProperty("OnAfterValidate");
        private readonly TriggerProperty _onDeactivate = new TriggerProperty("OnDeactivate");
        private readonly TriggerProperty _onPush = new TriggerProperty("OnPush");
        private readonly TriggerProperty _onValidate = new TriggerProperty("OnValidate");
        private readonly StringProperty _bitmapList = new StringProperty("BitmapList");
        private readonly BitmapPosProperty _bitmapPos = new BitmapPosProperty("BitmapPos");
        private readonly StringProperty _sourceExpr = new StringProperty("SourceExpr");

        private readonly StringProperty _runCommand = new StringProperty("RunCommand");
        private readonly RunObjectLinkProperty _runFormLink = new RunObjectLinkProperty("RunFormLink");
        private readonly RunFormLinkTypeProperty _runFormLinkType = new RunFormLinkTypeProperty("RunFormLinkType");
        private readonly NullableBooleanProperty _runFormOnRec = new NullableBooleanProperty("RunFormOnRec");
        private readonly StringProperty _runFormView = new StringProperty("RunFormView");
        private readonly RunObjectProperty _runObject = new RunObjectProperty("RunObject");

        private readonly ColorProperty _borderColor = new ColorProperty("BorderColor");
        private readonly BorderWidthProperty _borderWidth = new BorderWidthProperty("BorderWidth");
        private readonly StringProperty _captionClass = new StringProperty("CaptionClass");
        private readonly StringProperty _dataSetFieldName = new StringProperty("DataSetFieldName");
        private readonly NullableBooleanProperty _multiLine = new NullableBooleanProperty("MultiLine");
        private readonly StringProperty _padChar = new StringProperty("PadChar");
        private readonly MultiLanguageProperty _optionCaptionML = new MultiLanguageProperty("OptionCaptionML");
        private readonly StringProperty _optionString = new StringProperty("OptionString");
        private readonly NullableBooleanProperty _clearOnLookup = new NullableBooleanProperty("ClearOnLookup");
        private readonly BlankNumbersProperty _blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private readonly NullableBooleanProperty _blankZero = new NullableBooleanProperty("BlankZero");

        private readonly NullableBooleanProperty _inColumnHeading = new NullableBooleanProperty("InColumnHeading");

        private readonly NullableBooleanProperty _autoCalcField = new NullableBooleanProperty("AutoCalcField");

        private readonly StringProperty _maxValue = new StringProperty("MaxValue");
        private readonly StringProperty _minValue = new StringProperty("MinValue");
        private readonly NullableBooleanProperty _updateOnAction = new NullableBooleanProperty("UpdateOnAction");
        private readonly StringProperty _valuesAllowed = new StringProperty("ValuesAllowed");

        protected FormControlProperties(FormControl control)
        {
            Control = control;

            innerList.Add(_name);
            innerList.Add(_horzGlue);
            innerList.Add(_vertGlue);
            innerList.Add(_visible);
            innerList.Add(_editable);
            innerList.Add(_focusable);
            innerList.Add(_enabled);
            innerList.Add(_height);
            innerList.Add(_parentControl);
            innerList.Add(_inFrame);
            innerList.Add(_inColumn);
            innerList.Add(_inMatrix);
            innerList.Add(_inMatrixHeading);
            innerList.Add(_inColumnHeading);
            innerList.Add(_inPage);
            innerList.Add(_width);
            innerList.Add(_xPos);
            innerList.Add(_yPos);
            innerList.Add(_horzAlign);
            innerList.Add(_vertAlign);
            innerList.Add(_showCaption);
            innerList.Add(_foreColor);
            innerList.Add(_backColor);
            innerList.Add(_backTransparent);
            innerList.Add(_cancel);
            innerList.Add(_default);
            innerList.Add(_pushAction);
            innerList.Add(_border);
            innerList.Add(_borderStyle);
            innerList.Add(_borderColor);
            innerList.Add(_borderWidth);
            innerList.Add(_bitmapPos);
            innerList.Add(_bitmap);

            innerList.Add(_fontBold);
            innerList.Add(_fontItalic);
            innerList.Add(_fontName);
            innerList.Add(_fontSize);
            innerList.Add(_fontStrikethru);
            innerList.Add(_fontUnderline);
            innerList.Add(_multiLine);
            innerList.Add(_leaderDots);

            innerList.Add(_drillDown);
            innerList.Add(_drillDownFormID);
            innerList.Add(_dropDown);
            innerList.Add(_focusOnClick);
            innerList.Add(_captionMl);
            innerList.Add(_toolTipMl);
            innerList.Add(_description);

            innerList.Add(_nextControl);
            innerList.Add(_bitmapList);
            innerList.Add(_clearOnLookup);
            innerList.Add(_blankNumbers);
            innerList.Add(_blankZero);
            innerList.Add(_optionCaptionML);
            innerList.Add(_optionString);
            innerList.Add(_sourceExpr);
            innerList.Add(_captionClass);
            innerList.Add(_onActivate);
            innerList.Add(_onDeactivate);
            innerList.Add(_onPush);
            innerList.Add(_onValidate);
            innerList.Add(_onAfterValidate);

            innerList.Add(_runCommand);
            innerList.Add(_runObject);
            innerList.Add(_runFormLinkType);
            innerList.Add(_runFormLink);
            innerList.Add(_runFormOnRec);
            innerList.Add(_runFormView);

            innerList.Add(_dataSetFieldName);
            innerList.Add(_padChar);

            innerList.Add(_autoCalcField);

            innerList.Add(_maxValue);
            innerList.Add(_minValue);
            innerList.Add(_updateOnAction);
            innerList.Add(_valuesAllowed);
        }

        public FormControl Control { get; }

        public bool? Focusable
        {
            get => _focusable.Value;
            set => _focusable.Value = value;
        }

        public bool? Editable { get => _editable.Value; set => _editable.Value = value; }

        public override INode ParentNode => Control;


        private FormControlBase Parent { get; set; }

        public int? InPage
        {
            get => _inPage.Value;
            set => _inPage.Value = value;
        }

        public bool? InFrame
        {
            get => _inFrame.Value;
            set => _inFrame.Value = value;
        }

        public bool? InColumn
        {
            get => _inColumn.Value;
            set => _inColumn.Value = value;
        }

        public bool? InMatrix
        {
            get => _inMatrix.Value;
            set => _inMatrix.Value = value;
        }

        public bool? InMatrixHeading
        {
            get => _inMatrixHeading.Value;
            set => _inMatrixHeading.Value = value;
        }

        public string Name
        {
            get => _name.Value;
            set => _name.Value = value;
        }

        public bool? Visible
        {
            get => _visible.Value;
            set => _visible.Value = value;
        }

        public uint? XPos
        {
            get => _xPos.Value;
            set => _xPos.Value = value;
        }

        public uint? YPos
        {
            get => _yPos.Value;
            set => _yPos.Value = value;
        }

        public uint? Width
        {
            get => _width.Value;
            set => _width.Value = value;
        }

        public uint? Height
        {
            get => _height.Value;
            set => _height.Value = value;
        }

        public VertGlue? VertGlue
        {
            get => _vertGlue.Value;
            set => _vertGlue.Value = value;
        }

        public HorzGlue? HorzGlue
        {
            get => _horzGlue.Value;
            set => _horzGlue.Value = value;
        }

        public uint? ParentControl
        {
            get => _parentControl.Value;
            set => _parentControl.Value = value;
        }

        public HorzAlign? HorzAlign
        {
            get => _horzAlign.Value;
            set => _horzAlign.Value = value;
        }

        public VertAlign? VertAlign
        {
            get => _vertAlign.Value;
            set => _vertAlign.Value = value;
        }

        public bool? ShowCaption
        {
            get => _showCaption.Value;
            set => _showCaption.Value = value;
        }

        public MultiLanguageValue ToolTipML => _toolTipMl.Value;

        public bool? Border
        {
            get => _border.Value;
            set => _border.Value = value;
        }

        public bool? BackTransparent
        {
            get => _backTransparent.Value;
            set => _backTransparent.Value = value;
        }

        public Color? BackColor
        {
            get => _backColor.Value;
            set => _backColor.Value = value;
        }

        public Color? ForeColor
        {
            get => _foreColor.Value;
            set => _foreColor.Value = value;
        }

        public string FontName
        {
            get => _fontName.Value;
            set => _fontName.Value = value;
        }

        public int? FontSize
        {
            get => _fontSize.Value;
            set => _fontSize.Value = value;
        }

        public bool? FontBold
        {
            get => _fontBold.Value;
            set => _fontBold.Value = value;
        }

        public bool? FontItalic
        {
            get => _fontItalic.Value;
            set => _fontItalic.Value = value;
        }

        public bool? FontStrikethru
        {
            get => _fontStrikethru.Value;
            set => _fontStrikethru.Value = value;
        }

        public bool? FontUnderline
        {
            get => _fontUnderline.Value;
            set => _fontUnderline.Value = value;
        }

        public bool? LeaderDots
        {
            get => _leaderDots.Value;
            set => _leaderDots.Value = value;
        }

        public bool? Default
        {
            get => _default.Value;
            set => _default.Value = value;
        }

        public bool? Cancel
        {
            get => _cancel.Value;
            set => _cancel.Value = value;
        }

        public PushAction? PushAction
        {
            get => _pushAction.Value;
            set => _pushAction.Value = value;
        }

        public string Bitmap
        {
            get => _bitmap.Value;
            set => _bitmap.Value = value;
        }

        protected bool? InternalFocusOnClick
        {
            get => _focusOnClick.Value;
            set => _focusOnClick.Value = value;
        }

        protected MultiLanguageValue InternalCaptionMl => _captionMl.Value;

        protected string InternalDescription
        {
            get => _description.Value;
            set => _description.Value = value;
        }

        protected BorderStyle? InternalBorderStyle
        {
            get => _borderStyle.Value;
            set => _borderStyle.Value = value;
        }

        protected bool? InternalDropDown
        {
            get => _dropDown.Value;
            set => _dropDown.Value = value;
        }

        protected bool? InternalDrillDown
        {
            get => _drillDown.Value;
            set => _drillDown.Value = value;
        }

        protected string InternalDrillDownFormID
        {
            get => _drillDownFormID.Value;
            set => _drillDownFormID.Value = value;
        }

        protected string InternalSourceExpr
        {
            get => _sourceExpr.Value;
            set => _sourceExpr.Value = value;
        }

        protected string InternalBitmapList
        {
            get => _bitmapList.Value;
            set => _bitmapList.Value = value;
        }

        protected BitmapPos? InternalBitmapPos
        {
            get => _bitmapPos.Value;
            set => _bitmapPos.Value = value;
        }

        protected bool? InternalEnabled
        {
            get => _enabled.Value;
            set => _enabled.Value = value;
        }

        protected int? InternalNextControl
        {
            get => _nextControl.Value;
            set => _nextControl.Value = value;
        }

        protected Trigger InternalOnActivate => _onActivate.Value;
        protected Trigger InternalOnDeactivate => _onDeactivate.Value;
        protected Trigger InternalOnPush => _onPush.Value;
        protected Trigger InternalOnValidate => _onValidate.Value;
        protected Trigger InternalOnAfterValidate => _onAfterValidate.Value;

        protected RunObject InternalRunObject => _runObject.Value;

        protected string InternalRunFormView
        {
            get => _runFormView.Value;
            set => _runFormView.Value = value;
        }

        protected RunObjectLink InternalRunFormLink
        {
            get => _runFormLink.Value;
        }

        protected RunFormLinkType? InternalRunFormLinkType
        {
            get => _runFormLinkType.Value;
            set => _runFormLinkType.Value = value;
        }

        protected bool? InternalRunFormOnRec
        {
            get => _runFormOnRec.Value;
            set => _runFormOnRec.Value = value;
        }

        protected string InternalRunCommand
        {
            get => _runCommand.Value;
            set => _runCommand.Value = value;
        }

        protected bool? InternalClearOnLookup
        {
            get => _clearOnLookup.Value;
            set => _clearOnLookup.Value = value;
        }

        protected BlankNumbers? InternalBlankNumbers
        {
            get => _blankNumbers.Value;
            set => _blankNumbers.Value = value;
        }

        protected bool? InternalBlankZero
        {
            get => _blankZero.Value;
            set => _blankZero.Value = value;
        }

        protected Color? InternalBorderColor
        {
            get => _borderColor.Value;
            set => _borderColor.Value = value;
        }

        protected BorderWidth? InternalBorderWidth
        {
            get => _borderWidth.Value;
            set => _borderWidth.Value = value;
        }

        protected string InternalCaptionClass
        {
            get => _captionClass.Value;
            set => _captionClass.Value = value;
        }

        protected string InternalDataSetFieldName
        {
            get => _dataSetFieldName.Value;
            set => _dataSetFieldName.Value = value;
        }

        protected bool? InternalMultiLine
        {
            get => _multiLine.Value;
            set => _multiLine.Value = value;
        }

        protected string InternalPadChar
        {
            get => _padChar.Value;
            set => _padChar.Value = value;
        }

        protected string InternalOptionString
        {
            get => _optionString.Value;
            set => _optionString.Value = value;
        }

        protected MultiLanguageValue InternalOptionCaptionML => _optionCaptionML.Value;

        protected bool? InternalInColumnHeading
        {
            get => _inColumnHeading.Value;
            set => _inColumnHeading.Value = value;
        }

        protected bool? InternalAutoCalcField
        {
            get => _autoCalcField.Value;
            set => _autoCalcField.Value = value;
        }

        protected string InternalMinValue
        {
            get => _minValue.Value;
            set => _minValue.Value = value;
        }

        protected string InternalMaxValue
        {
            get => _maxValue.Value;
            set => _maxValue.Value = value;
        }

        protected string InternalValuesAllowed
        {
            get => _valuesAllowed.Value;
            set => _valuesAllowed.Value = value;
        }

        protected bool? InternalUpdateOnAction
        {
            get => _updateOnAction.Value;
            set => _updateOnAction.Value = value;
        }
    }
}
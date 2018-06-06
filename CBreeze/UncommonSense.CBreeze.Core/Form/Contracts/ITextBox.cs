using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    //IExtendFormBorder2, ICaption, IForeColor, IFont, IAlignment, IDataSetField,IColumnMatrixExtended, IExtendedText, IBaseControl
    //IExtendFormBorder2, ICaption, IForeColor, IFont, IAlignment, IDataSetField, IColumnMatrix, , IExtendedText,  IBaseControl

    public interface IText : IExtendFormBorder2, ICaption, IForeColor, IFont, IAlignment, IDataSetField, IColumnMatrix,
        IExtendedText, IBaseControl
    {
    }

    public interface ITextBox : IControlList, IExtendedSourceExpr, IEditable, IBaseControl2, IText
    {
        int? MaxLength { get; set; }
        bool? PasswordText { get; set; }
        bool? AutoEnter { get; set; }
        bool? Lookup { get; set; }
        bool? DrillDown { get; set; }
        bool? AssistEdit { get; set; }
        bool? DropDown { get; set; }
        bool? PermanentAssist { get; set; }

        string OptionString { get; set; }
        MultiLanguageValue OptionCaptionML { get; }
        DecimalPlaces DecimalPlaces { get; }
        string Title { get; set; }
        bool? NotBlank { get; set; }
        bool? Numeric { get; set; }
        string CharAllowed { get; set; }
        string DateFormula { get; set; }
        bool? ClosingDates { get; set; }


        bool? ClearOnLookup { get; set; }
        string Format { get; set; }
        BlankNumbers? BlankNumbers { get; set; }
        bool? BlankZero { get; set; }
        bool? SignDisplacement { get; set; }
        string AutoFormatType { get; set; }
        string AutoFormatExpr { get; set; }

        string Divisor { get; set; }
        string TableRelation { get; set; }
        bool? ValidateTableRelation { get; set; }
        string LookupFormID { get; set; }
        string DrillDownFormID { get; set; }
    }
}
namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface ITableBox : IFormControlProperties, IFormControlBackColorProperties, IExtendedFormBorder,
        IDescriptionable, IEnabledFocusable
    {
        int? RowHeight { get; set; }
        bool? InlineEditing { get; set; }
        int? HeadingHeight { get; set; }
    }
}
namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IColumnMatrix : IFormControlProperties
    {
        bool? InColumn { get; set; }
        bool? InMatrix { get; set; }
        bool? InMatrixHeading { get; set; }
    }
}
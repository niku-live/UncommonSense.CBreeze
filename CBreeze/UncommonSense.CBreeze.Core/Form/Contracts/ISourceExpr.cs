namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface ISourceExpr : IFormControlProperties
    {
        string SourceExpr { get; set; }
        bool? AutoCalcField { get; set; }
    }
}
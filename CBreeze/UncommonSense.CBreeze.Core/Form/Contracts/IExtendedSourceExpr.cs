namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IExtendedSourceExpr : ISourceExpr
    {
        string MinValue { get; set; }
        string MaxValue { get; set; }
        string ValuesAllowed { get; set; }
    }
}
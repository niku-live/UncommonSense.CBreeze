namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IMatrixBox : ITableBox
    {
        int? MatrixColumnWidth { get; set; }
        string MatrixSourceTable { get; set; }
    }
}
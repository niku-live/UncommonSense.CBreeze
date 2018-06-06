namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IPictureBox : IBaseControl2, IExtendFormBorder2, IControlList, IColumnMatrix, ISourceExpr,
        IDataSetField
    {
        string BitmapList { get; set; }
    }
}
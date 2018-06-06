namespace UncommonSense.CBreeze.Core.Form.Contracts.Trigger
{
    public interface IPushAble
    {
        Code.Variable.Trigger OnPush { get; }
    }
}
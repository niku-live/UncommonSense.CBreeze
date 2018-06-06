namespace UncommonSense.CBreeze.Core.Form.Contracts.Trigger
{
    public interface IHyperlink
    {
        Code.Variable.Trigger OnCreateHyperlink { get; }
        Code.Variable.Trigger OnHyperlink { get; }
    }
}
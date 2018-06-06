namespace UncommonSense.CBreeze.Core.Form.Contracts.Trigger
{
    public interface IActivate
    {
        Code.Variable.Trigger OnActivate { get; }
        Code.Variable.Trigger OnDeactivate { get; }
    }
}
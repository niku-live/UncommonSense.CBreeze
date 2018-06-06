namespace UncommonSense.CBreeze.Core.Form.Contracts.Trigger
{
    public interface IInput
    {
        Code.Variable.Trigger OnBeforeInput { get; }
        Code.Variable.Trigger OnInputChange { get; }
        Code.Variable.Trigger OnAfterInput { get; }
    }
}
namespace UncommonSense.CBreeze.Core.Form.Contracts.Trigger
{
    public interface IValidate
    {
        Code.Variable.Trigger OnValidate { get; }
        Code.Variable.Trigger OnAfterValidate { get; }
    }
}
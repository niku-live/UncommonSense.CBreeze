namespace UncommonSense.CBreeze.Core.Form.Contracts.Trigger
{
    public interface IForm
    {
        Code.Variable.Trigger OnInit { get; }
        Code.Variable.Trigger OnOpenForm { get; }
        Code.Variable.Trigger OnCloseForm { get; }
        Code.Variable.Trigger OnQueryCloseForm { get; }
        Code.Variable.Trigger OnActivateForm { get; }
        Code.Variable.Trigger OnDeactivateForm { get; }
    }
}
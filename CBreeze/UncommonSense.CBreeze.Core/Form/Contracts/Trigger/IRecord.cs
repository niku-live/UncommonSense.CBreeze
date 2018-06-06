namespace UncommonSense.CBreeze.Core.Form.Contracts.Trigger
{
    public interface IRecord
    {
        Code.Variable.Trigger OnFindRecord { get; }

        Code.Variable.Trigger OnNextRecord { get; }

        Code.Variable.Trigger OnAfterGetRecord { get; }
        Code.Variable.Trigger OnAfterGetCurrRecord { get; }
        Code.Variable.Trigger OnBeforePutRecord { get; }
    }
}
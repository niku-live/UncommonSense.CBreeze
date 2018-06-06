namespace UncommonSense.CBreeze.Core.Form.Contracts.Trigger
{
    public interface IRecord2
    {
        Code.Variable.Trigger OnNewRecord { get; }
        Code.Variable.Trigger OnInsertRecord { get; }
        Code.Variable.Trigger OnModifyRecord { get; }

        Code.Variable.Trigger OnDeleteRecord { get; }
    }
}
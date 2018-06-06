namespace UncommonSense.CBreeze.Core.Form.Contracts.Trigger
{
    public interface IField
    {
        Code.Variable.Trigger OnLookup { get; }
        Code.Variable.Trigger OnAssistEdit { get; }
        Code.Variable.Trigger OnDrillDown { get; }
    }
}
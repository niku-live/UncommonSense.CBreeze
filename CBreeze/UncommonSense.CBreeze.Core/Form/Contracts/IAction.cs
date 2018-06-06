using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Contracts
{
    public interface IAction : IFormControlProperties
    {
        PushAction PushAction { get; set; }
        RunObject RunObject { get; }
        string RunFormView { get; set; }
        string RunFormLink { get; set; }
        RunFormLinkType RunFormLinkType { get; set; }
        bool? RunFormOnRec { get; set; }
        string RunCommand { get; set; }
        bool? UpdateOnAction { get; set; }
    }
}
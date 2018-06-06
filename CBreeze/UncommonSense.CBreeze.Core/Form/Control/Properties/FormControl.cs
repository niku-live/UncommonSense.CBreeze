using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public abstract class FormControl : FormControlBase
    {
        protected FormControl(int id, int posX, int posY, int width, int height) : base(id, posX, posY, width, height)
        {
        }


        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get { yield return Properties; }
        }

        public FormControlProperties Properties { get; protected set; }

        public override string GetName()
        {
            return Properties.Name;
        }
    }
}
// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Page : Object
    {
        public Page(Int32 id, String name)
            : base(id, name)
        {
            Properties = new PageProperties();
            Controls = new PageControls();
            Code = new Code();
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Page;
            }
        }

        public PageProperties Properties
        {
            get;
            protected set;
        }

        public PageControls Controls
        {
            get;
            protected set;
        }

        public Code Code
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}

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
    public partial class XmlPortTextElement : XmlPortNode
    {
        public XmlPortTextElement(Guid id, String nodeName, Int32? indentationLevel)
            : base(id, nodeName, indentationLevel)
        {
            Properties = new XmlPortTextElementProperties();
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.XmlPortTextElement;
            }
        }

        public XmlPortTextElementProperties Properties
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

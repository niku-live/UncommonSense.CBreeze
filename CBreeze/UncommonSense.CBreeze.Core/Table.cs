using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Table : Object, IHasCode
    {
        public Table(int id, string name)
            : base(id, name)
        {
            Properties = new TableProperties();
            Fields = new TableFields();
            Keys = new TableKeys();
            FieldGroups = new TableFieldGroups();
            Code = new Code(this);
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Table;
            }
        }

        public TableProperties Properties
        {
            get;
            protected set;
        }

        public TableFields Fields
        {
            get;
            protected set;
        }

        public TableKeys Keys
        {
            get;
            protected set;
        }

        public TableFieldGroups FieldGroups
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

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
    public partial class Permission
    {
        private int tableID;
        private bool readPermission;
        private bool insertPermission;
        private bool modifyPermission;
        private bool deletePermission;

        internal Permission(int tableID, bool readPermission, bool insertPermission, bool modifyPermission, bool deletePermission)
        {
            this.deletePermission = deletePermission;
            this.insertPermission = insertPermission;
            this.modifyPermission = modifyPermission;
            this.readPermission = readPermission;
            this.tableID = tableID;
        }

        public int TableID
        {
            get
            {
                return this.tableID;
            }
        }

        public bool ReadPermission
        {
            get
            {
                return this.readPermission;
            }
        }

        public bool InsertPermission
        {
            get
            {
                return this.insertPermission;
            }
        }

        public bool ModifyPermission
        {
            get
            {
                return this.modifyPermission;
            }
        }

        public bool DeletePermission
        {
            get
            {
                return this.deletePermission;
            }
        }

    }
}

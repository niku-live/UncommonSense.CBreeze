using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core.Property.Enumeration
{
    public enum DataClassification
    {
        CustomerContent,
        EndUserIdentifiableInformation,
        AccountData,
        EndUserPseudonymousIdentifiers,
        OrganizationIdentifiableInformation,
        SystemMetadata,
        ToBeClassified
    }
}

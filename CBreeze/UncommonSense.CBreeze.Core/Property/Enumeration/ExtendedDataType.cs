namespace UncommonSense.CBreeze.Core.Property.Enumeration
{
    public enum ExtendedDataType
    {
        None,
        PhoneNo,
        Url,
        EMail,
        Ratio,
        Masked,
#if NAV2017
        Person,
#endif
#if (NAV2017 && !NAV2018)
        Resource
#endif
    }
}
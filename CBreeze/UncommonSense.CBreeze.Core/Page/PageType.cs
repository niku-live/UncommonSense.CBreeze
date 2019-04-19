namespace UncommonSense.CBreeze.Core.Page
{
    public enum PageType
    {
        Card,
        List,
        RoleCenter,
        CardPart,
        ListPart,
        Document,
        Worksheet,
        ListPlus,
        ConfirmationDialog,
        NavigatePage,
        StandardDialog,
#if NAV2018
        API,
#endif
#if NAVBC || NAV2019
        HeadlinePart,
#endif
    }
}
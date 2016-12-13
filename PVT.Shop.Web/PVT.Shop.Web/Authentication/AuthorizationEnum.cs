namespace PVT.Shop.Web.Authentication
{
    using System;

    [Flags]
    public enum AuthorizationRoles
    {
        User = 0x01,
        Seller = 0x02,
        Admin = 0x04
    }
}

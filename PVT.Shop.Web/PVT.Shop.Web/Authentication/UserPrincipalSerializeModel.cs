namespace PVT.Shop.Web.Authentication
{
    using System;
    using Infrastructure.Common;

    [Serializable]
    public class UserPrincipalSerializeModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public Role CurrentRole { get; set; }
    }
}
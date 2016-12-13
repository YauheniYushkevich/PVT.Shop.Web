namespace PVT.Shop.Web.Authentication
{
    using System.Security.Principal;
    using Infrastructure.Common;

    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }

        string Login { get; set; }

        Role CurrentRole { get; set; }

        bool IsInRole(AuthorizationRoles role);
    }
}
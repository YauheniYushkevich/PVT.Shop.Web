namespace PVT.Shop.Web.Authentication
{
    using System;
    using System.Linq;
    using System.Security.Principal;
    using Infrastructure.Common;

    public class UserPrincipal : ICustomPrincipal
    {
        public UserPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public Role CurrentRole { get; set; }

        public string Login { get; set; }

        public int Id { get; set; }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                return false;
            }

            var rolesArray = role.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var rol in rolesArray)
            {
                if (rol == this.CurrentRole.ToString())
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsInRole(AuthorizationRoles role)
        {
            string principalRole = this.CurrentRole.ToString();
            var roleArray = new string[3];
            if (role.HasFlag(AuthorizationRoles.User))
            {
                roleArray[0] = "User";
            }

            if (role.HasFlag(AuthorizationRoles.Seller))
            {
                roleArray[1] = "Seller";
            }

            if (role.HasFlag(AuthorizationRoles.Admin))
            {
                roleArray[2] = "Admin";
            }

            if (roleArray.Any(authRole => string.Compare(principalRole, authRole, StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                return true;
            }

            return false;
        }
    }
}

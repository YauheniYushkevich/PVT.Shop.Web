namespace PVT.Shop.Web.Authentication
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public new AuthorizationRoles Roles { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            IPrincipal curUser = httpContext.User;
            if (curUser.Identity.IsAuthenticated == true)
            {
                var user = curUser as UserPrincipal;
                bool isInRole = user.IsInRole(this.Roles);

                return user.Identity.IsAuthenticated && isInRole;
            }

            return false;
        }
    }
}

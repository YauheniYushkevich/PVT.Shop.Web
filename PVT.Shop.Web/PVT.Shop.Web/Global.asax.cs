namespace PVT.Shop.Web
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Script.Serialization;
    using System.Web.Security;
    using Authentication;
    using Infrastructure.Common;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(Storage), new StorageModelBinder());
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var serializer = new JavaScriptSerializer();

                var serializeModel = serializer.Deserialize<UserPrincipalSerializeModel>(authTicket.UserData);

                var newUser = new UserPrincipal(authTicket.Name);
                newUser.Id = serializeModel.Id;
                newUser.Login = serializeModel.Login;
                newUser.CurrentRole = serializeModel.CurrentRole;

                HttpContext.Current.User = newUser;
            }
        }
    }
}
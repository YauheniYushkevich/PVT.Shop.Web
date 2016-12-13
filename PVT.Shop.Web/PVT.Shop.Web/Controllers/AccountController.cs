namespace PVT.Shop.Web.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using System.Web.Security;
    using Authentication;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;

    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        [ChildActionOnly]
        public ActionResult NavbarLogin()
        {
            var vm = new LoginUserViewModel();

            return this.PartialView("_NavbarLogin", vm);
        }

        [ChildActionOnly]
        public ActionResult UserInfo(int id)
        {
            var vm = new UserInfoViewModel();
            var user = this._userService.GetUser(id);

            vm.UserEmail = user.Email.ToLower();
            vm.UserFullName = user.FirstName + " " + user.LastName;
            vm.UserShortAdress = user.Address.City + ", " + user.Address.Country.Name;
            vm.UserBirthday = user.Birthday.ToString("D");
            vm.UserPhone = user.Phone;
            vm.UserSex = user.Gender;
            vm.UserRole = user.Role;
            vm.UserLogin = user.Login;

            return this.PartialView("_NavbarUserInfo", vm);
        }

        public ActionResult Login()
        {
            ViewBag.AuthenticationFailedMessage = false;
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(LoginUserViewModel userlog)
        {
            ViewBag.AuthenticationFailedMessage = false;
            if (userlog.UserName != null && userlog.Password != null)
            {
                var user = this._userService.LoginUser(userlog.UserName, userlog.Password);
                if (user != null)
                {
                    var serializeModel = new UserPrincipalSerializeModel
                    {
                        Id = user.Id,
                        Login = user.Login,
                        Email = user.Email,
                        CurrentRole = user.Role
                    };

                    var serializer = new JavaScriptSerializer();

                    var userData = serializer.Serialize(serializeModel);

                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        user.Email,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(60),
                        false,
                        userData);

                    var encTicket = FormsAuthentication.Encrypt(authTicket);
                    var facookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(facookie);

                    return this.RedirectToAction("Index", "Catalog");
                }
            }

            ViewBag.AuthenticationFailedMessage = true;
            return this.View("LogIn");
        }

        public ActionResult LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }

            return this.RedirectToAction("Index", "Catalog");
        }

        public ActionResult PersonalAccount()
        {
            var vm = new UserInfoViewModel();
            var user = this._userService.GetUser((User as UserPrincipal).Id);

            vm.UserEmail = user.Email.ToLower();
            vm.UserFullName = user.FirstName + " " + user.LastName;
            vm.UserShortAdress = user.Address.City + ", " + user.Address.Country.Name;
            vm.UserBirthday = user.Birthday.ToString("D");
            vm.UserPhone = user.Phone;
            vm.UserSex = user.Gender;
            vm.UserRole = user.Role;
            vm.UserLogin = user.Login;

            return this.View(vm);
        }

        public ActionResult Tools()
        {
            return this.View();
        }
    }
}

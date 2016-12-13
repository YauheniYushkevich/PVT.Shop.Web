namespace PVT.Shop.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Authentication;
    using DAL.Repositories;
    using Infrastructure.Common;
    using Infrastructure.Common.Enums;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;
    using PagedList;

    public class UserController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IUserService _userService;
        private readonly UserRepository _repository;

        public UserController(IUserService userService, ICountryService countryService, UserRepository repository)
        {
            this._userService = userService;
            this._countryService = countryService;
            this._repository = repository;
            ViewBag.SavedSuccessfullyMessage = false;
            ViewBag.ErrorSavingMessage = false;
        }

        [CustomAuthorize(Roles = AuthorizationRoles.Admin)]
        public ActionResult Users(SortEnumByUserProp? sortOrder, string currentFilter, string searchString, int page = 1, int pageSize = 5)
        {
            ViewBag.SavedSuccessfullyMessage = false;
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 5;
            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<User> users = this._userService.GetAllUsers();

            if (!string.IsNullOrEmpty(searchString))
            {
                users = this._userService.GetUsersByRole(searchString);
            }

            if (sortOrder == null)
            {
                sortOrder = SortEnumByUserProp.Id;
            }

            ViewBag.SortBy = sortOrder;
            return this.View(this._userService.SortByUserProp(users, sortOrder.Value).ToPagedList(page, pageSize));
        }

        [HttpGet]
        [CustomAuthorize(Roles = AuthorizationRoles.User | AuthorizationRoles.Admin)]
        public ActionResult Delete(int id)
        {
            var b = this._userService.GetUser(id);
            if (this._repository.IsExistAnyAdmin(id))
            {
                return this.View(b);
            }

            return this.RedirectToAction("ErrorForAdmin");
        }

        [HttpPost, ActionName("Delete")]
        [CustomAuthorize(Roles = AuthorizationRoles.User | AuthorizationRoles.Admin)]
        public ActionResult DeleteConfirmed(int id)
        {
            if (this._userService.GetUser(id) != null)
            {
                this._userService.DeleteUser(id);
                this._userService.SaveUser();
                if (Request.IsAuthenticated && User.IsInRole("Admin"))
                {
                    return this.RedirectToAction("Users");
                }
                else
                {
                    return this.RedirectToAction("LogOut", "Account");
                }
            }

            return this.View();
        }

        public ActionResult RegistrationUser()
        {
            var viewModel = new RegistrationUserViewModel
                            {
                                CurrentCountries = this._countryService.GetCountries()
                            };

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult RegistrationUser(RegistrationUserViewModel user)
        {
            var country = this._countryService.GetCountry(user.CurrentCountryId);
            user.CurrentUser.Address.Country = country;
            string message;
            bool isExist = this._userService.IsExist(user.CurrentUser.Login, user.CurrentUser.Password, out message);
            if (isExist)
            {
                ModelState.AddModelError(string.Empty, message);
            }

            if (ModelState.IsValid)
            {
                this._userService.AddUser(user.CurrentUser);
                this._userService.SaveUser();
                ViewBag.SavedSuccessfullyMessage = true;
                if (Request.IsAuthenticated && User.IsInRole("Admin"))
                {
                    return this.Redirect("Users");
                }
                else
                {
                    return this.RedirectToAction("LogIn", "Account");
                }
            }

            ViewBag.ErrorSavingMessage = true;

            return this.View(new RegistrationUserViewModel
                             {
                                 CurrentCountries = this._countryService.GetCountries()
                             });
        }

        [CustomAuthorize(Roles = AuthorizationRoles.User | AuthorizationRoles.Seller | AuthorizationRoles.Admin)]
        public ActionResult EditUser(int? id)
        {
            if (!id.HasValue)
            {
                return this.HttpNotFound();
            }

            var user = this._userService.GetUser((int)id);
            if (user == null)
            {
                return this.HttpNotFound();
            }

            return this.View(user);
        }

        [HttpPost, ActionName("EditUser")]
        [CustomAuthorize(Roles = AuthorizationRoles.User | AuthorizationRoles.Seller | AuthorizationRoles.Admin)]
        public ActionResult EditUser(User user)
        {
            ModelState.Remove("Password");
            var role = (User as UserPrincipal).CurrentRole;
            if (ModelState.IsValid)
            {
                user.Password = this._userService.GetUser(user.Id).Password;
                if (role == Role.Admin)
                {
                    bool isExistAnyAdmin = this._userService.IsExistAnyAdmin(user.Id);
                    if (!isExistAnyAdmin && user.Role != Role.Admin)
                    {
                        ModelState.AddModelError(string.Empty, "Sorry. You are the only administrator. Your role can not be changed.");
                        ViewBag.ErrorSavingMessage = true;
                        return this.View();
                    }
                }

                this._userService.UpdateUser(user);
                this._userService.SaveUser();
                ViewBag.SavedSuccessfullyMessage = true;
                return this.View(user);
            }

            ViewBag.ErrorSavingMessage = true;

            return this.View();
        }

        public ActionResult ChangePass()
        {
            var vm = new ChangePassViewModel();
            return this.View("ChangePass", vm);
        }

        [HttpPost]
        public ActionResult ChangePass(ChangePassViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = this._userService.GetUser((HttpContext.User as UserPrincipal).Id);
                if (user.Password != vm.OldPassword)
                {
                    ViewBag.ErrorSavingMessage = true;
                    return this.View();
                }

                user.Password = user.PasswordConfirm = vm.NewPassword;
                this._userService.SaveUser();
                ViewBag.SavedSuccessfullyMessage = true;
                return this.View();
            }

            return this.View();
        }

        public ActionResult ErrorForAdmin()
        {
            return this.View();
        }
    }
}

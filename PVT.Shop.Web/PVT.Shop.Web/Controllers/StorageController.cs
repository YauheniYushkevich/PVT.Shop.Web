namespace PVT.Shop.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Filters;
    using Infrastructure.Common;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;
    using PagedList;

    [LoggingActionAttributeFilter]
    [Authorize(Roles = "Admin")]
    public class StorageController : Controller
    {
        private readonly IStorageService _storageService;

        private readonly ICountryService _countryService;

        public StorageController(IStorageService storageService, ICountryService countryService)
        {
            this._storageService = storageService;
            this._countryService = countryService;
        }

        #region Storage Actions

        /// <summary>
        ///     Show all storages from db
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(SortByEnum? sortByNew, int? pageSize, int page = 1)
        {
            IEnumerable<Storage> result;

            if (sortByNew.HasValue)
            {
                ViewBag.SortBy = sortByNew.Value;
            }
            else
            {
                sortByNew = ViewBag.SortBy == null ? SortByEnum.Name : ViewBag.SortBy;
                ViewBag.SortBy = sortByNew;
            }

            if (!pageSize.HasValue)
            {
                if (ViewBag.PageSize == null)
                {
                    ViewBag.PageSize = 5;
                    pageSize = 5;
                }
                else
                {
                    pageSize = ViewBag.PageSize;
                }
            }
            else
            {
                ViewBag.PageSize = pageSize.Value;
            }

            result = this._storageService.GetStorages(sortByNew);

            return this.View(result.ToPagedList(page, pageSize.Value));
        }

        /// <summary>
        ///     Return form for editing of concrete storage from db or empty form for new record in db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            var model = new StorageViewModel { Countries = this._countryService.GetCountries() };

            if (id != null)
            {
                var storage = this._storageService.GetStorage((int)id);
                model.Storage = storage ?? new Storage();
            }
            else
            {
                model.Storage = new Storage();
            }

            return this.View(model);
        }

        /// <summary>
        ///     SaveRepository storage
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Storage storage)
        {
            this.ModelState.Clear();
            this.TryValidateModel(storage.Address.Country);
            this.TryValidateModel(storage.Address);
            this.TryValidateModel(storage);

            if (!ModelState.IsValid)
            {
                var model = new StorageViewModel { Countries = this._countryService.GetCountries() };
                model.Storage = storage;
                return this.View(model);
            }

            if (this._storageService.GetStorage(storage.Id) == null)
            {
                this._storageService.AddStorage(storage);
                this._storageService.SaveStorage();
            }
            else
            {
                this._storageService.UpdateStorage(storage);
                this._storageService.SaveStorage();
            }

            return this.RedirectToAction("Index");
        }

        /// <summary>
        ///     Return concrete storage instance for detail view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            var storage = this._storageService.GetStorage(id);
            return storage != null ? this.View(storage) : this.View("Error");
        }

        public ActionResult Delete(int id)
        {
            this._storageService.DeleteStorage(id);
            this._storageService.SaveStorage();
            return this.RedirectToAction("Index");
        }

        #endregion
    }
}
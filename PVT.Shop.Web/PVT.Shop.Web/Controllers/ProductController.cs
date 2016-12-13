namespace PVT.Shop.Web.Controllers
{
    using System.Web.Mvc;
    using Authentication;
    using Extensions;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;
    using PagedList;

    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly IProductService _productService;

        private readonly IStorageService _storageService;

        private readonly IOnlinerProductParser _parser;

        public ProductController(ICategoryService categoryService, IProductService productService, IStorageService storageService, IOnlinerProductParser parser)
        {
            this._categoryService = categoryService;
            this._productService = productService;
            this._storageService = storageService;
            this._parser = parser;
        }

        #region Product Actions

        [Authorize(Roles = "Admin,Seller")]
        public ActionResult Index(string sortOrder = "id", int page = 1, int pageSize = 50)
        {
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 5;

            ViewBag.NameSortParam = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.IdSortParam = sortOrder == "id" ? "id_desc" : "id";
            ViewBag.CountSortParam = sortOrder == "count" ? "count_desc" : "count";
            ViewBag.PriceSortParam = sortOrder == "price" ? "price_desc" : "price";
            ViewBag.CurrentSort = sortOrder;

            var query = this._productService.GetProducts(sortOrder, ((UserPrincipal)User).Id);

            return this.View(query.ToPagedList(page, pageSize));
        }

        [Authorize(Roles = "Admin,Seller")]
        public ActionResult DeleteProduct(int id)
        {
            var product = this._productService.GetProduct(id);

            if (product != null)
            {
                this._productService.DeleteProduct(id);
                this._productService.SaveChanges();

                this.TempData["state"] = "true";
                this.TempData["message"] = product.Name + " successfully deleted!";

                return this.RedirectToAction("Index");
            }

            this.TempData["state"] = "false";
            this.TempData["message"] = "Error! Product with given id not found!";

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Seller")]
        public ActionResult AddProduct()
        {
            var vm = new ProductViewModel
            {
                CurrentCategories = this._categoryService.GetCategories(),
                CurrentStorages = this._storageService.GetStorages(),
            };

            return this.View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Seller")]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                product.Current.CurrentUserId = ((UserPrincipal)User).Id;

                this._productService.AddProduct(product.Current);
                this._productService.SaveChanges();

                this.TempData["state"] = "true";
                this.TempData["message"] = product.Current.Name + " successfully added!";

                return this.RedirectToAction("Index");
            }

            this.TempData["state"] = "false";
            this.TempData["message"] = product.Current.Name + " Validation Error! Please try again.";

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Seller")]
        public ActionResult EditProduct(int id)
        {
            var product = this._productService.GetProduct(id);

            if (product != null)
            {
                var vm = new ProductViewModel
                {
                    CurrentCategories = this._categoryService.GetCategories(),
                    CurrentStorages = this._storageService.GetStorages(),
                    Current = this._productService.GetProduct(id),
                };

                return this.View(vm);
            }

            this.TempData["state"] = "false";
            this.TempData["message"] = "Error! Product with given id not found!";

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Seller")]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                this._productService.UpdateProduct(product.Current);
                this._productService.SaveChanges();

                this.TempData["state"] = "true";
                this.TempData["message"] = product.Current.Name + " successfully changed!";

                return this.RedirectToAction("Index");
            }

            this.TempData["state"] = false;
            this.TempData["message"] = "Validation Error! Please try again.";

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult LoadProductFromOnliner(string category, int categoryId, int storageId)
        {
            this._parser.ParseCatalog(category, 1, categoryId, storageId, ((UserPrincipal)User).Id);

            return this.RedirectToAction("Tools", "Account");
        }

        #endregion
    }
}
namespace PVT.Shop.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Services;
    using PagedList;

    public class CatalogController : Controller
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        public CatalogController(IProductService productService, ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
        }

        public ActionResult Index(int id = 100, int page = 1, int pageSize = 30)
        {
            var vm = this._productService.GetProducts(id);

            var query = vm.Query;

            ViewBag.BreadCrumb = vm.BreadCrumb;
            ViewBag.CategoryId = id;

            if (id == 100)
            {
                ViewBag.CategoryDescription = "Product Directory contains a list of all products. In each section, the product catalog is a description of a particular product, including its ID, name, category, information on the availability and other product attributes";
                ViewBag.CategoryIcon = "http://image.flaticon.com/icons/svg/274/274719.svg";
                ViewBag.Count = this._productService.GetProducts().Count();
            }
            else
            {
                var cataegory = this._categoryService.GetCategory(id);

                ViewBag.CategoryDescription = cataegory.Description;
                ViewBag.CategoryIcon = cataegory.Icon;
                ViewBag.Count = this._productService.GetProducts(id).Query.Count();

                if (cataegory.Parent == null)
                {
                    return this.View(query.ToPagedList(page, pageSize));
                }

                ViewBag.ParentCategory = cataegory.Parent.Name;
                ViewBag.ParentCategoryId = cataegory.Parent.Id;
            }

            return this.View(query.ToPagedList(page, pageSize));
        }

        public ActionResult Search(string q, int page = 1, int pageSize = 30)
        {
            if (q == string.Empty)
            {
                return this.RedirectToAction("Index");
            }

            var vm = this._productService.GetProductsByName(q);

            ViewBag.BreadCrumb = vm.BreadCrumb;
            ViewBag.SearchQuery = q;
            ViewBag.CategoryIcon = "http://image.flaticon.com/icons/svg/214/214340.svg";
            ViewBag.Count = vm.Query.Count();

            var query = vm.Query;

            return this.View("Index", query.ToPagedList(page, pageSize));
        }
    }
}
namespace PVT.Shop.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Common;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;

    public class BasketController : Controller
    {
        private readonly IProductService _productRepository;

        public BasketController(IProductService repository)
        {
            this._productRepository = repository;
        }

        public RedirectToRouteResult AddToBasket(int id, string returnUrl)
        {
            var product = this._productRepository.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                this.GetBasket().AddItem(product, 1);
            }

            return this.RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromBasket(int id, string returnUrl)
        {
            var product = this._productRepository.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                this.GetBasket().RemoveItem(product);
            }

            return this.RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return this.View(new BasketViewModel
                             {
                                 Basket = this.GetBasket(),
                                 ReturnUrl = returnUrl
                             });
        }

        public PartialViewResult BasketSummary(Basket basket)
        {
            return this.PartialView(basket);
        }

        private Basket GetBasket()
        {
            var basket = (Basket)Session["Basket"];
            if (basket == null)
            {
                basket = new Basket();
                this.Session["Basket"] = basket;
            }

            return basket;
        }
    }
}
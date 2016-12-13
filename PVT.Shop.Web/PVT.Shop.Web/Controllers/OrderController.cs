namespace PVT.Shop.Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.Services;
    using PagedList;

    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [Authorize]
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var userRole = ((Authentication.UserPrincipal)User).CurrentRole;
            var userId = ((Authentication.UserPrincipal)User).Id;
            var query = this._orderService.GetOrders();
            switch (userRole)
            {
                case Infrastructure.Common.Role.User:
                    query = this._orderService.GetOrders(userId);
                    break;
                case Infrastructure.Common.Role.Seller:
                    // query = this._orderService.GetOrders();
                    query = this._orderService.GetOrdersBySel(userId);
                    break;
                case Infrastructure.Common.Role.Admin:
                    query = this._orderService.GetOrders();
                    break;
                default:
                    break;
            }
            Response.Write("USerRole=" + userRole + " USerID=" + userId);
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 5;

            return this.View(query.ToPagedList(page, pageSize)); 
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteOrder(int id)
        {
            this._orderService.DeleteOrder(id);
            return this.RedirectToAction("Index");
        }
    }
}
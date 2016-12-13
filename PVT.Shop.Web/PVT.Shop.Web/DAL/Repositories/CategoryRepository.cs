namespace PVT.Shop.Web.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Common;
    using Infrastructure.Repositories;

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository() : base(new ShopContext())
        {
        }

        public override void Delete(int id)
        {
            var childs = this.GetAll(x => x.Parent.Id == id).ToList();
            foreach (var childId in this.GetAllChilds(id))
            {
                base.Delete(childId);
            }
        }

        private List<int> GetAllChilds(int id)
        {
            var category = this.GetById(id);
            var result = new List<int> { category.Id };

            foreach (var categoryId in this.GetAll(c => c.Parent.Id == id).Select(c => c.Id).ToList())
            {
                result.AddRange(this.GetAllChilds(categoryId));
            }

            return result;
        }
    }
}
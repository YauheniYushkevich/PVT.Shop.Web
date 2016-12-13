namespace PVT.Shop.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Common;
    using Infrastructure.Common.Comparer;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Repositories;
    using Infrastructure.Services;
    using PagedList;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IProductRepository _productRepository;

        private readonly IPropertyRepository _propertyRepository;

        private readonly IPropertyValueRepository _propertyValueRepository;

        public CategoryService(ICategoryRepository categoryRepository, IPropertyRepository propertyRepository, IPropertyValueRepository propertyValueRepository, IProductRepository productRepository)
        {
            this._propertyRepository = propertyRepository;
            this._categoryRepository = categoryRepository;
            this._productRepository = productRepository;
            this._propertyValueRepository = propertyValueRepository;
        }

        public Category GetCategory(int id)
        {
            var category = this._categoryRepository.GetById(id);
            if (category == null)
            {
                return null;
            }

            ////adding subcategories of the category
            category.Childs = this._categoryRepository.GetAll(c => c.Parent.Id == id)
                                  .OrderBy(c => c.Name).ToList();
            this._categoryRepository.GetAllDeleted(c => c.Parent.Id == id).OrderBy(c => c.Name).ToList();

            ////adding childs of subcategories 
            foreach (var child in category.Childs)
            {
                child.Childs = this._categoryRepository.GetAll(c => c.Parent.Id == child.Id).ToList();
                this._categoryRepository.GetAllDeleted(c => c.Parent.Id == child.Id).ToList();
            }

            return category;
        }

        public Category GetCatalog()
        {
            var root = this._categoryRepository.GetById(1);
            this.BuildCatalog(root);
            return root;
        }

        public CategoryProductsViewModel GetCategoryProducts(int categoryId, int page = 1, int pageSize = 6)
        {
            var categoriesId = this.GetChildsId(categoryId);
            var products = this._productRepository.GetAll(p => categoriesId.Any(id => id == p.CurrentCategoryId)).Where(p => p.Display.Equals(true)).ToList();

            var categoryProducts = new CategoryProductsViewModel
            {
                Category = this._categoryRepository.GetById(categoryId),
                Products = new PagedList<Product>(products, page, pageSize),
                CategoryProductsCount = products.Count
            };

            return categoryProducts;
        }

        public CategoryForEditViewModel GetCategoryForEdit(int categoryId, int parentId = 1)
        {
            //// get category by id or create new category with Parent.Id == parentId
            var category = this._categoryRepository.GetById(categoryId) ??
                           new Category() { Id = 0, Parent = this._categoryRepository.GetById(parentId) };

            //// get all categories without current category and her subcategories
            var categoriesId = this.GetChildsId(categoryId);
            var parents = this._categoryRepository.GetAll()
                              .Except(this._categoryRepository.GetAll(c => categoriesId.Any(id => id == c.Id)))
                              .OrderBy(c => c.Name).ToList();

            //// get all category properties 
            if (category.Id != 0)
            {
                category.Properties =
                this._propertyRepository.GetAll(p => p.Category.Id == categoryId).ToList();
                category.Properties.AddRange(this._propertyRepository.GetAllDeleted());
            }
            
            return new CategoryForEditViewModel() { Category = category, Categories = parents };
        }

        public void UpdateCategoryState(int id, bool delete)
        {
            if (delete)
            {
                //// remove category (deleted and sub-categories)
                this._categoryRepository.Delete(id);
                this._categoryRepository.Save();

                //// remove category properties
                var properties = this._propertyRepository.GetAll(p => p.CategoryId == id).ToList();
                foreach (var property in properties)
                {
                    this._propertyRepository.Delete(property.Id);
                }
            }
            else
            {
                //// restore category (only current category)
                this._categoryRepository.Restore(id);
                this._categoryRepository.Save();

                //// restore category properties
                var properties = this._propertyRepository.GetAll(p => p.CategoryId == id).ToList();
                foreach (var property in properties)
                {
                    this._propertyRepository.Restore(property.Id);
                }
            }
        }

        public void MowToHellProperty(int id)
        {
            //// remove all propertyValues of this property (No cascade delete)
            foreach (var propertyValueId in this._propertyValueRepository.GetAll(p => p.Property.Id == id).Select(p => p.Id).ToList())
            {
                this._propertyValueRepository.MowToHell(propertyValueId);
            }

            this._propertyValueRepository.Save();

            //// remove property
            this._propertyRepository.MowToHell(id);
            this._propertyRepository.Save();
        }

        public void SaveCategory(Category category)
        {
            if (category.Id != 0)
            {
                this.UpdateCategory(category);
            }
            else
            {
                this.CreateCategory(category);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return this._categoryRepository.GetAll();
        }

        public int GetParentId(int id)
        {
            var category = this._categoryRepository.GetById(id);
            return category?.Parent?.Id ?? 1;
        }

        private void UpdateCategory(Category category)
        {
            this.DeleteOldProperties(category);

            this.SaveCategoryProperties(category);

            ////Save category changes
            var updatedCategory = this._categoryRepository.GetById(category.Id);
            updatedCategory.Name = category.Name;
            updatedCategory.Description = category.Description;
            updatedCategory.Parent = this._categoryRepository.GetById(category.Parent.Id);
            updatedCategory.Icon = category.Icon;

            this._categoryRepository.Update(updatedCategory);
            this._categoryRepository.Save();
        }

        private void CreateCategory(Category newCategory)
        {
            //// create category entry in repository
            var addedCategory = new Category()
                                {
                                    Name = newCategory.Name,
                                    Description = newCategory.Description,
                                    Icon = newCategory.Icon
                                };
            this._categoryRepository.Create(addedCategory);

            //// update category parent
            if (newCategory.Parent.Id != 0)
            {
                addedCategory.Parent = this._categoryRepository.GetById(newCategory.Parent.Id);
            }

            this._categoryRepository.Save();

            //// save cagory properties
            if (newCategory.Properties.Any())
            {
                addedCategory.Properties = newCategory.Properties;
                this.SaveCategoryProperties(addedCategory);
            }
        }

        private void DeleteOldProperties(Category changedCategory)
        {
            var deletedProperties = this._propertyRepository.GetAll(p => p.Category.Id == changedCategory.Id).Except(changedCategory.Properties, new PropertyComparer()).ToList();
            foreach (var property in deletedProperties)
            {
                this.MowToHellProperty(property.Id);
            }
        }

        private void SaveCategoryProperties(Category category)
        {
            foreach (var property in category.Properties)
            {
                Property savedProperty;
                if (property.Id != 0)
                {
                    ////Update property
                    savedProperty = this._propertyRepository.GetById(property.Id);
                    savedProperty.Name = property.Name;
                    savedProperty.Description = property.Description;
                    this._propertyRepository.Update(savedProperty);
                }
                else
                {
                    ////Create new property
                    savedProperty = new Property()
                    {
                        Id = 0,
                        Name = property.Name,
                        Description = property.Description
                    };
                    this._propertyRepository.Create(savedProperty);
                }

                savedProperty.CategoryId = category.Id;
            }

            this._propertyRepository.Save();
        }

        private void BuildCatalog(Category root)
        {
            root.Childs = this._categoryRepository.GetAll(c => (root.Id != 0 ? c.Parent.Id == root.Id : c.Parent == null)).OrderBy(c => c.Name).ToList();
            foreach (var child in root.Childs)
            {
                this.BuildCatalog(child);
            }
        }

        private List<int> GetChildsId(int categoryId)
        {
            var result = new List<int>() { categoryId };
            var ids = this._categoryRepository.GetAll(c => (categoryId != 0 ? c.Parent.Id == categoryId : c.Parent == null)).Select(c => c.Id).ToList();
            foreach (var i in ids)
            {
                result.AddRange(this.GetChildsId(i));
            }

            return result;
        }
    }
}
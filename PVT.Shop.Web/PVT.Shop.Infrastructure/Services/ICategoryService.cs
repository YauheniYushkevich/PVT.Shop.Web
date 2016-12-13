namespace PVT.Shop.Infrastructure.Services
{
    using System.Collections.Generic;
    using Common;
    using Common.ViewModels;

    public interface ICategoryService
    {
        /// <summary>
        /// Search by category Id
        /// </summary>
        /// <param name="id">id of the required category</param>
        /// <returns>category with the given id, null if there is no such category or root of catalog if id = 0.
        /// Category filled with a list of sub-categories(deleted and not deleted)</returns>
        Category GetCategory(int id);

        /// <summary>
        /// Search all categories and bild catalog of this categories
        /// </summary>
        /// <returns>Root of the catalog</returns>
        Category GetCatalog();

        /// <summary>
        /// Search products in the category
        /// </summary>
        /// <param name="categoryId">id of the required category products</param>
        /// <param name="page">page of products</param>
        /// <param name="pageSize">count of properties per page</param>
        /// <returns>all products of the category on the pagination</returns>
        CategoryProductsViewModel GetCategoryProducts(int categoryId, int page = 1, int pageSize = 6);

        /// <summary>
        /// Search or create category by ID
        /// </summary>
        /// <param name="categoryId">id of the required category, if categoryId is zero creates a new category</param>
        /// <param name="parentId">if creates a new category parentId indication of the anticipated category </param>
        /// <returns> category and all properties of this category, or empty category if there is no such category</returns>
        CategoryForEditViewModel GetCategoryForEdit(int categoryId, int parentId = 0);

        /// <summary>
        /// Removes and restores category
        /// </summary>
        /// <param name="id">id of the deleted/restored category </param>
        /// <param name="delete">delete or restore </param>
        void UpdateCategoryState(int id, bool delete);

        /// <summary>
        /// Removes the specified property and all of connected with it objects
        /// </summary>
        /// <param name="id">Id delete property</param>
        void MowToHellProperty(int id);

        /// <summary>
        /// Update or create entry in CategoryRepository.
        /// </summary>
        /// <param name="category"></param>
        void SaveCategory(Category category);

        /// <summary>
        /// Search all categories
        /// </summary>
        /// <returns>List of categories</returns>
        IEnumerable<Category> GetCategories();

        int GetParentId(int id);
    }
}
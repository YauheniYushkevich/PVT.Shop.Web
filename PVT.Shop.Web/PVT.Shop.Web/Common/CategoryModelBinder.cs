namespace PVT.Shop.Web.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Common;

    public class CategoryModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;
            
            //// get category
            var category = new Category
                           {
                               Id = int.Parse(form.Get("Category.Id")),
                               Name = form.Get("Category.Name"),
                               Description = form.Get("Category.Description"),
                               Icon = form.Get("Category.Icon"),
                               Parent = new Category() { Id = int.Parse(form.Get("Category.Parent.Id")) }
                           };
            //// get all category properties
            var strPropertyIds = form.Get("property.Id");
            var strPropertyNames = form.Get("property.Name");
            var strPropertyDescriptions = form.Get("property.Description");

            var properties = new List<Property>();

            if (strPropertyIds != null)
            {
                var propertyIds = strPropertyIds.Split(',');
                var propertyNames = strPropertyNames.Split(',');
                var propertyDescriptions = strPropertyDescriptions.Split(',');

                properties.AddRange(propertyIds.Select((t,
                                                        i) =>
                                                       new Property
                                                       {
                                                           Category = category,
                                                           Id = int.Parse(t),
                                                           Name = propertyNames[i],
                                                           Description = propertyDescriptions[i]
                                                       }));
            }

            category.Properties = properties;

            return category;
        }
    }
}
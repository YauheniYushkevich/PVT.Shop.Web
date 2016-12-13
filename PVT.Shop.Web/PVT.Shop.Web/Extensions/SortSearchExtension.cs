namespace PVT.Shop.Web.Extensions
{
    using System.Collections.Specialized;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class Extensions
    {
        /// <summary>
        ///     Used to determine the direction of the sort identifier used when filtering lists
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="sortOrder">the current sort order being used on the page</param>
        /// <param name="field">the field that we are attaching this sort identifier to</param>
        /// <returns>MvcHtmlString used to indicate the sort order of the field</returns>
        public static IHtmlString SortIdentifier(this HtmlHelper htmlHelper, string sortOrder, string field)
        {
            if (string.IsNullOrEmpty(sortOrder) || ((sortOrder.Trim() != field) && (sortOrder.Replace("_desc", string.Empty).Trim() != field)))
            {
                return null;
            }

            var span = new TagBuilder("span");

            return MvcHtmlString.Create(span.ToString());
        }

        /// <summary>
        ///     Converts a NameValueCollection into a RouteValueDictionary containing all of the elements in the collection, and
        ///     optionally appends
        ///     {newKey: newValue} if they are not null
        /// </summary>
        /// <param name="collection">NameValue collection to convert into a RouteValueDictionary</param>
        /// <param name="newKey">the name of a key to add to the RouteValueDictionary</param>
        /// <param name="newValue">the value associated with newKey to add to the RouteValueDictionary</param>
        /// <returns>
        ///     A RouteValueDictionary containing all of the keys in collection, as well as {newKey: newValue} if they are not
        ///     null
        /// </returns>
        public static RouteValueDictionary ToRouteValueDictionary(this NameValueCollection collection, string newKey, string newValue)
        {
            var routeValueDictionary = new RouteValueDictionary();

            foreach (var key in collection.AllKeys)
            {
                if (key == null)
                {
                    continue;
                }

                if (routeValueDictionary.ContainsKey(key))
                {
                    routeValueDictionary.Remove(key);
                }   
                         
                routeValueDictionary.Add(key, collection[key]);
            }

            if (string.IsNullOrEmpty(newValue))
            {
                routeValueDictionary.Remove(newKey);
            }
            else
            {
                if (routeValueDictionary.ContainsKey(newKey))
                {
                    routeValueDictionary.Remove(newKey);
                }

                routeValueDictionary.Add(newKey, newValue);
            }

            return routeValueDictionary;
        }
    }
}
namespace PVT.Shop.Web
{
    using System.Web.Mvc;

    /// <summary>
    /// Contains extension method for HtmlHelper class
    /// </summary>
    public static class InputHtmlHeler
    {
        /// <summary>
        /// Method represens <input/> tag with 4 attributes (type, name, value, class)
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="inputType"></param>
        /// <param name="inputName"></param>
        /// <param name="inputValue"></param>
        /// <param name="cssClass"></param>
        /// <returns></returns>
        public static MvcHtmlString Input(this HtmlHelper helper, string inputType, string inputName, string inputValue, string cssClass)
        {
            var tag = new TagBuilder("input");
            tag.Attributes.Add("type", inputType);
            tag.Attributes.Add("name", inputName);
            tag.Attributes.Add("value", inputValue);
            tag.Attributes.Add("class", cssClass);
            return new MvcHtmlString(tag.ToString());
        }

        /// <summary>
        /// Method represens <input/> tag with 3 attributes (type, name, value)
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="inputType"></param>
        /// <param name="inputName"></param>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static MvcHtmlString Input(this HtmlHelper helper, string inputType, string inputName, string inputValue)
        {
            var tag = new TagBuilder("input");
            tag.Attributes.Add("type", inputType);
            tag.Attributes.Add("name", inputName);
            tag.Attributes.Add("value", inputValue);
            return new MvcHtmlString(tag.ToString());
        }

        /// <summary>
        /// Method represens <input/> tag which have same name and value attributes
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="inputType"></param>
        /// <param name="inputSameNameAndValue"></param>
        /// <returns></returns>
        public static MvcHtmlString Input(this HtmlHelper helper, string inputType, string inputSameNameAndValue)
        {
            var tag = new TagBuilder("input");
            tag.Attributes.Add("type", inputType);
            tag.Attributes.Add("name", inputSameNameAndValue);
            tag.Attributes.Add("value", inputSameNameAndValue);
            return new MvcHtmlString(tag.ToString());
        }
    }
}
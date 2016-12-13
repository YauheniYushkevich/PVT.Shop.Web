namespace PVT.Shop.Web.Services
{
    using System.Collections.Generic;
    using Infrastructure.Common;
    using Infrastructure.Services;

    public class Calculator : ICalculator
    {
        public decimal Calculate(IList<Product> basketItem)
        {
            decimal sum = 0;
            foreach (var item in basketItem)
            {
                sum += item.Price;
            }

            return sum;
        }
    }
}
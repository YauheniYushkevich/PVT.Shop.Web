namespace PVT.Shop.Infrastructure.Services
{
    using System.Collections.Generic;
    using Common;

    public interface ICalculator
    {
        decimal Calculate(IList<Product> prod);
    }
}

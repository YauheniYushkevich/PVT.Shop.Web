namespace PVT.Shop.Infrastructure.Common.ViewModels
{
    using System.Collections.Generic;
  
    public class StorageViewModel
    {

        public Storage Storage { get; set; }


        public IEnumerable<Country> Countries { get; set; }
    }

}


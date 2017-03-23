using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.ViewModel
{
    public class ProductPostModel
    {
        public decimal Price { get; set; }
        public int ManufacturerID { get; set; }
        public int ProductID{ get; set; }
        public int ProductTypeID{ get; set; }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Name{ get; set; }
    }
}

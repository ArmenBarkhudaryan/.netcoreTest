using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.ViewModel
{
    public class ProductViewModel
    {
        public int ProductHistoryID { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public Manufacturer Manufacture { get; set; }
        public DateTime CreationDate { get; set; }
        public string ProductType { get; set; }
        public int ProductTypeID { get; set; }
        public ProductViewModel()
        {
            Manufacture = new Manufacturer();
            Product = new Product();
        }
         public ProductViewModel(int ProductHistoryID, decimal Price, string ProductType)
        {
            this.ProductHistoryID = ProductHistoryID;
            this.Price = Price;
            this.ProductType = ProductType;
            Manufacture = new Manufacturer();
            Product = new Product();
        }
    }
}

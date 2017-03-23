using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class ProductHistoryDM
    {

        public ProductDM ProductModel;
        public ManufacturerDM Manufacturer;
        public ProductTypeDM ProductType;
        public int ProductHistoryID { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }

        public ProductHistoryDM()
        {
            ProductType = new ProductTypeDM();
            Manufacturer = new ManufacturerDM();
            ProductModel = new ProductDM();
        }
    }
}


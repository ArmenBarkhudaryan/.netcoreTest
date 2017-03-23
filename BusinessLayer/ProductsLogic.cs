using CommonLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductsLogic
    {
        public class ProductsBL
        {
            DataAccesLayer DataCommunicationLayer = new DataAccesLayer();

            public List<ProductHistoryDM> GetAllProducts()
            {
                return DataCommunicationLayer.SP_GetAllProducts();
            }

            public List<ProductHistoryDM> GetProductsByID(int id)
            {
                return DataCommunicationLayer.SP_GetProductsByID(id);
            }

            public void AddProduct(ProductHistoryDM ProdHisModel)
            {
                DataCommunicationLayer.SP_AddProduct(ProdHisModel);
            }


        }
    }
}

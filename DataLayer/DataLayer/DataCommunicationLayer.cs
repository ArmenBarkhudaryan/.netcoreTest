using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;

namespace DataLayer
{
    public class DataAccesLayer : BaseDataLayer
    {

        public List<ProductHistoryDM> SP_GetAllProducts()
        {
            DbDataReader reader = SP_Exec_StoredProcedure("SP_GetAllProducts", DictonaryParamValues);
            List<ProductHistoryDM> DataModel = new List<ProductHistoryDM>();



            while (reader.Read())
            {
                ProductHistoryDM model = new ProductHistoryDM();
                model.ProductHistoryID = (int)reader[0];
                model.ProductModel.Id = (int)reader[1];
                model.ProductModel.Name = reader[2].ToString();
                model.Price = (decimal)reader[3];
                model.Manufacturer.ID = (int)reader[4];
                model.Manufacturer.Name = reader[5].ToString();
                model.ProductType.ID = (int)reader[6];
                model.ProductType.Type = reader[7].ToString();
                model.CreationDate = (DateTime)reader[8];
                DataModel.Add(model);
            }

            return DataModel;
        }

        public List<ProductHistoryDM> SP_GetProductsByID(int id)
        {
            DictonaryParamValues.Add("ProductID", id);
            DbDataReader reader = SP_Exec_StoredProcedure("SP_GetProductsByID", DictonaryParamValues);
            List<ProductHistoryDM> DataModel = new List<ProductHistoryDM>();

            while (reader.Read())
            {
                ProductHistoryDM model = new ProductHistoryDM();
                model.ProductHistoryID = (int)reader[0];
                model.Price = (decimal)reader[1];
                model.ProductModel.Id = (int)reader[2];
                model.ProductModel.Name = reader[3].ToString();
                model.ProductType.ID = (int)reader[4];
                model.ProductType.Type = reader[5].ToString();
                model.Manufacturer.ID = (int)reader[6];
                model.Manufacturer.Name = reader[7].ToString();
                model.CreationDate = (DateTime)reader[8];
                DataModel.Add(model);
            }

            return DataModel;
        }

        public void SP_AddProduct(ProductHistoryDM ProductDataModel)
        {
            try
            {
                DictonaryParamValues.Add("Price", ProductDataModel.Price);
                DictonaryParamValues.Add("ManufacturerID", ProductDataModel.Manufacturer.ID);
                DictonaryParamValues.Add("ProductID", ProductDataModel.ProductModel.Id);
                DictonaryParamValues.Add("ProductType", ProductDataModel.ProductType.ID);

                SP_Exec_StoredProcedure("SP_AddProduct", DictonaryParamValues);
            }
            catch (Exception ex)
            {

            }
        }

    }
}

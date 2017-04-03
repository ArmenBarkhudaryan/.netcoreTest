using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using System.Collections;

namespace DataLayer
{
    public class DataAccesLayer
    {
        BaseDataLayer dataLayer = BaseDataLayer.BaseDataAccessLayer;

        private static DataAccesLayer _instance;
        private DataAccesLayer() { }
        public static  DataAccesLayer DataLayer
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DataAccesLayer();
                }
                return _instance;
            }
        }

        public List<ProductHistoryDM> SP_GetAllProducts()
        {
            try
            {
                List<ArrayList> ArrList = dataLayer.SP_Exec_StoredProcedure("SP_GetAllProducts", new Dictionary<string, object> ());
                List<ProductHistoryDM> DataModel = new List<ProductHistoryDM>();

                foreach (var item in ArrList)
                {
                    ProductHistoryDM model = new ProductHistoryDM();
                    model.ProductHistoryID = (int)item[0];
                    model.ProductModel.Id = (int)item[1];
                    model.ProductModel.Name = item[2].ToString();
                    model.Price = (decimal)item[3];
                    model.Manufacturer.ID = (int)item[4];
                    model.Manufacturer.Name = item[5].ToString();
                    model.ProductType.ID = (int)item[6];
                    model.ProductType.Type = item[7].ToString();
                    model.CreationDate = (DateTime)item[8];
                    DataModel.Add(model);
                }
                return DataModel;
            }
            catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        //public List<ProductHistoryDM> SP_GetProductsByID(int id)
        //{
        //    DictonaryParamValues.Add("ProductID", id);
        //    DbDataReader reader = SP_Exec_StoredProcedure("SP_GetProductsByID", DictonaryParamValues);
        //    List<ProductHistoryDM> DataModel = new List<ProductHistoryDM>();

        //    while (reader.Read())
        //    {
        //        ProductHistoryDM model = new ProductHistoryDM();
        //        model.ProductHistoryID = (int)reader[0];
        //        model.Price = (decimal)reader[1];
        //        model.ProductModel.Id = (int)reader[2];
        //        model.ProductModel.Name = reader[3].ToString();
        //        model.ProductType.ID = (int)reader[4];
        //        model.ProductType.Type = reader[5].ToString();
        //        model.Manufacturer.ID = (int)reader[6];
        //        model.Manufacturer.Name = reader[7].ToString();
        //        model.CreationDate = (DateTime)reader[8];
        //        DataModel.Add(model);
        //    }

        //    return DataModel;
        //}

        public void SP_AddProduct(ProductHistoryDM ProductDataModel)
        {
            try
            {
                Dictionary<string, object> ParamsAndValues = new Dictionary<string, object>();

                ParamsAndValues.Add("Price", ProductDataModel.Price);
                ParamsAndValues.Add("ManufacturerID", ProductDataModel.Manufacturer.ID);
                ParamsAndValues.Add("ProductID", ProductDataModel.ProductModel.Id);
                ParamsAndValues.Add("ProductType", ProductDataModel.ProductType.ID);

                dataLayer.SP_Exec_StoredProcedure("SP_AddProduct", ParamsAndValues);
            }
            catch (Exception ex)
            {
                
            }
        }

        public int SP_ErrorLogger(string ExceptionName, string JsonExceptionStackTrace)
        {
            Dictionary<string, object> ParamsAndValues = new Dictionary<string, object>();
            ParamsAndValues.Add("ExceptionName", ExceptionName);
            ParamsAndValues.Add("StackTrace", JsonExceptionStackTrace);
            List<ArrayList> ArrList = dataLayer.SP_Exec_StoredProcedure("SP_ErrorLogger", ParamsAndValues);

            int ExceptionId = (int)ArrList[0][0];
            return ExceptionId;
        }
    }
}

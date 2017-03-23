using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class BaseDataLayer
    {
        public static string ConnectionString = null;
        public Dictionary<string, object> DictonaryParamValues = new Dictionary<string, object>();
        

        public DbDataReader SP_Exec_StoredProcedure(string ProdcedureName, Dictionary<string, object> DictonaryParamsValues)
        {
            DbDataReader bdreader;
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand SqlCommand = new SqlCommand(ProdcedureName, connection);
                connection.Open();
                SqlCommand.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < DictonaryParamsValues.Count; i++)
                {
                    SqlCommand.Parameters.Add(new SqlParameter(DictonaryParamsValues.ElementAt(i).Key, DictonaryParamsValues.ElementAt(i).Value == null ? (object)DBNull.Value : DictonaryParamsValues.ElementAt(i).Value.ToString()));
                }
               
                bdreader = SqlCommand.ExecuteReader();

                DictonaryParamValues.Clear();
                return bdreader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DataLayer
{
    public class BaseDataLayer
    {
        public static string ConnectionString = null;
        public Dictionary<string, object> DictonaryParamValues = new Dictionary<string, object>();
        

        public List<ArrayList> SP_Exec_StoredProcedure(string ProdcedureName, Dictionary<string, object> DictonaryParamsValues)
        {
            List<ArrayList> ArrayList = new List<ArrayList>();
            DbDataReader bdreader;
            
            try
            {
                using(SqlConnection connection = new SqlConnection(ConnectionString))
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
                    while (bdreader.Read())
                    {
                        ArrayList array = new ArrayList();
                        for (int i = 0; i < bdreader.FieldCount; i++)
                        {
                            array.Add(bdreader[i]);
                        }
                        ArrayList.Add(array);
                    }
                    return ArrayList;
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}

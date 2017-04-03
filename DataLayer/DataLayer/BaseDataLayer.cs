using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using System.IO;

namespace DataLayer
{
    public class BaseDataLayer
    {
        public static string ConnectionString = null;

        private static BaseDataLayer _instance;
        private BaseDataLayer() { }
        public static BaseDataLayer BaseDataAccessLayer
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new BaseDataLayer();
                }
                return _instance;
            }
        }

        public List<ArrayList> SP_Exec_StoredProcedure(string ProdcedureName, Dictionary<string, object> DictonaryParamsValues)
        {
            DbDataReader bdreader;
            try
            {
                using(SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    int.Parse("dsd");
                    SqlCommand SqlCommand = new SqlCommand(ProdcedureName, connection);
                    connection.Open();
                    SqlCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < DictonaryParamsValues.Count; i++)
                    {
                        SqlCommand.Parameters.Add(new SqlParameter(DictonaryParamsValues.ElementAt(i).Key, DictonaryParamsValues.ElementAt(i).Value == null ? (object)DBNull.Value : DictonaryParamsValues.ElementAt(i).Value.ToString()));
                    }
                    bdreader = SqlCommand.ExecuteReader();
                    List<ArrayList> ArrayList = new List<ArrayList>();

                    while (bdreader.Read())
                    {
                        ArrayList array = new ArrayList(bdreader.FieldCount);
                        for (int i = 0; i < bdreader.FieldCount; i++)
                        {
                            array.Add(bdreader[i]);
                        }
                        ArrayList.Add(array);
                    }
                    ArrayList.TrimExcess();
                    return ArrayList;
                }

            }
            catch (Exception ex)
            {
                string ExceptionStackTrace = ex.StackTrace;
                string ExceptionMessage = ex.Message;

                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("ExceptionMessage",ExceptionStackTrace);
                dictionary.Add("ExceptionData",ExceptionMessage);
                string jsondata = JsonConvert.SerializeObject(dictionary);

                string path = @"c:\Users\MyTest.txt";
             
                File.AppendAllText(path, jsondata);

                  
                System.IO.File.WriteAllText(path + "output.json", jsondata);
                return new List<ArrayList>();
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using DataLayer;

namespace BusinessLayer
{
    public class ErrorLogger 
    {
        DataAccesLayer DataLayer = DataAccesLayer.DataLayer;

        private static ErrorLogger _instance;
        private ErrorLogger() { }
        public static ErrorLogger loger
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ErrorLogger();
                }
                return _instance;
            }
        }

        public int Log(string Name,string StackTrace )
        {
            var JsonObject = JsonConvert.SerializeObject(StackTrace);
            int ExceptionId =  DataLayer.SP_ErrorLogger(Name, JsonObject);

            return ExceptionId;
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics.Views;
using System.Diagnostics;
using BusinessLayer;

namespace ProductsSore.Middleware
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;
            ErrorLogger logger = ErrorLogger.loger;

            Type exceptionType = context.Exception.GetType();

            switch (exceptionType.Name)
                {
                case "UnauthorizedAccessException":
                    message = "Unauthorized Access";
                    status = HttpStatusCode.Unauthorized;
                    break;
                case "NotImplementedException":
                    message = "A server error occurred.";
                    status = HttpStatusCode.NotImplemented;
                    break;
                case "MyCustomException":
                    message = context.Exception.ToString();
                    status = HttpStatusCode.InternalServerError;
                    break;
                default:
                    message = context.Exception.Message;
                    status = HttpStatusCode.NotFound;
                    break;
            } 

            //Logging exception in database
            int ExceptionId = logger.Log(exceptionType.Name, context.Exception.StackTrace);

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";

            //var err = message + " " + context.Exception.StackTrace;
            //response.WriteAsync(err, Encoding.UTF8);

            //response.WriteAsync(c,Encoding.UTF8);
          
              var jsonString = "{\"status\":false,\"ExceptionId\":" + ExceptionId + ",\"message\":"+message+"}";
              response.WriteAsync(jsonString, Encoding.UTF8);

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsSore.Middleware
{
    public class MyCustomException:Exception
    {
        public MyCustomException()
        {
                
        }
        public MyCustomException(string message):base(message)
        {

        }
        public MyCustomException(string message,Exception innerException):base(message,innerException)
        {

        }
    }
}
